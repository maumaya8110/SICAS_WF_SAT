/*
 * 2013-01-03, Modificado por Luis Espino
 *      Se incluye la funcionalidad de verificar inventario diferido,
 *      es decir, el inventario existen más el que esta por surtir
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ServiciosUC : baseUserControl
    {
        public ServiciosUC()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        private InventarioRefaccionesServicioMantenimiento InventarioRefaccionesForm;
        public NuevaOrdenTrabajo Padre;
        private BuscarServicios BuscarServiciosForm = new BuscarServicios();
        private BuscarRefacciones BuscarRefaccionesForm = new BuscarRefacciones();

        private int _TipoClienteTaller_ID;
        public int TipoClienteTaller_ID
        {
            get { return _TipoClienteTaller_ID; }
            set { _TipoClienteTaller_ID = value; }
        }
        
        public void BindData()
        {
            this.ServiciosAgregadosDataGridView.Enabled = true;
            this.RefaccionesAgregadasDataGrdiView.Enabled = true;
            
            if (Padre.OrdenTrabajo.TipoMantenimiento_ID == 14)
            {
                this.RefaccionesAgregadasDataGrdiView.Enabled = false;
            }                    

            ConsultarModelo();
        }

        public void ShowInventarioServicio(string servicio, List<Entities.Vista_InventarioRefaccionesServicio> inventario)
        {
            if (InventarioRefaccionesForm == null)
                this.InventarioRefaccionesForm = new InventarioRefaccionesServicioMantenimiento();

            if(InventarioRefaccionesForm.IsDisposed)
                this.InventarioRefaccionesForm = new InventarioRefaccionesServicioMantenimiento();

            this.InventarioRefaccionesForm.NombreServicio = servicio;
            this.InventarioRefaccionesForm.Inventario = inventario;
            this.InventarioRefaccionesForm.BindData();
            this.InventarioRefaccionesForm.Show();
        }

        private void ConsultarModelo()
        {            
            ObtenerTipoClienteTaller();
        }
       
        private void DoValidate()
        {
            if (Padre.OrdenTrabajo.OrdenesServicios.Count == 0)
            {
                throw new Exception("Debe seleccionar al menos un servicio");
            }
        }        

        private void ObtenerTipoClienteTaller()
        {            
            //  Si empresa existe en tiposcliente, obtener su tipocliente.
            if (DB.Exists(
                "TiposClientesTaller",
                DB.Param("Empresa_ID", this.Padre.OrdenTrabajo.ClienteFacturar_ID)
                ))
            {
                //  Consultar precio por su tipo de cliente
                Entities.TiposClientesTaller tipoclientetaller =
                    Entities.TiposClientesTaller.Read(
                        DB.Param(
                            "Empresa_ID",
                            this.Padre.OrdenTrabajo.ClienteFacturar_ID
                        )
                    );

                this.TipoClienteTaller_ID = tipoclientetaller.TipoClienteTaller_ID;
            }
            else
            {
                //  Si no existe, es externo, consultar por externo
                this.TipoClienteTaller_ID = 4;
            }

        }

        private void AgregarVentaServicio(Entities.Vista_ServiciosMantenimientos vistaServicio, int cantidadServicios)
        {            
            Entities.OrdenesServicios ordenServicio = new Entities.OrdenesServicios();
            ordenServicio.Cantidad = cantidadServicios;
            ordenServicio.EstatusOrdenServicio_ID = 1;
            ordenServicio.Precio = vistaServicio.Precio;
            ordenServicio.ServicioMantenimiento_ID = vistaServicio.ServicioMantenimiento_ID;
            ordenServicio.Total = ordenServicio.Cantidad * ordenServicio.Precio;
            ordenServicio.ServicioMantenimiento_Descripcion = vistaServicio.Nombre;

            Padre.OrdenTrabajo.OrdenesServicios.Add(ordenServicio);

            MostrarTotales();
        }

        private void AgregarServicio(Entities.Vista_ServiciosMantenimientos vistaServicio, int cantidadServicios)
        {
            Entities.OrdenesServicios ordenServicio = new Entities.OrdenesServicios();
            ordenServicio.Cantidad = cantidadServicios;
            ordenServicio.EstatusOrdenServicio_ID = 1;
            ordenServicio.Precio = vistaServicio.Precio;
            ordenServicio.ServicioMantenimiento_ID = vistaServicio.ServicioMantenimiento_ID;
            ordenServicio.Total = ordenServicio.Cantidad * ordenServicio.Precio;
            ordenServicio.ServicioMantenimiento_Descripcion = vistaServicio.Nombre;

            if(vistaServicio.Nombre == "VENTA DE REFACCIONES")
            {
                Padre.OrdenTrabajo.OrdenesServicios.Add(ordenServicio);

                MostrarTotales();
                return;
            }

            // Consultar las refacciones que necesita el servicio            
            List<Entities.ServiciosMantenimientos_TiposRefacciones> serviciosTiposRefacciones =
                Entities.ServiciosMantenimientos_TiposRefacciones.Read(ordenServicio.ServicioMantenimiento_ID);

            //  Si no tiene configuradas refacciones
            if (serviciosTiposRefacciones.Count == 0 ) 
            { 
                throw new Exception("No hay refacciones asociadas con el servicio"); 
            }

            // Obtener el modelo
            int? modeloUnidad_ID = DB.GetNullableInt32(this.Padre.Modelo_ID);

            bool ExisteInventario = false;

            // Para cada una, buscar en inventario, si hay existencia
            foreach (Entities.ServiciosMantenimientos_TiposRefacciones tipoRef in serviciosTiposRefacciones)
            {
                // Obtener las refacciones por tipo de servicio y modelo del auto                
                List<Entities.Vista_Refacciones> refacciones =
                    Entities.Vista_Refacciones.Get(
                        null,
                        tipoRef.TipoRefaccion_ID,
                        null,
                        modeloUnidad_ID,
                        null,
                        null,
                        null,
                        Sesion.Empresa_ID.Value,
                        Sesion.Estacion_ID.Value
                    );

                foreach (Entities.Vista_Refacciones refaccion in refacciones)
                {
                    //  Si hay inventario
                    int cantidad = tipoRef.Cantidad * ordenServicio.Cantidad;

                    /*  Verificar el inventario
                      Consultamos el inventario existente de la refacción, así como la cantidad
                      por surtir. Si la cantidad restante no es suficente, enviaremos aviso
                     * */
                    int inventario =
                        Entities.Functions.GetInventarioDiferido(
                            refaccion.Refaccion_ID.Value,
                            Sesion.Empresa_ID.Value,
                            Sesion.Estacion_ID.Value
                        );

                    //  Si hay inventario suficiente
                    if (inventario >= cantidad)
                    {
                        Entities.OrdenesServiciosRefacciones osr = new Entities.OrdenesServiciosRefacciones();
                        osr.Cantidad = cantidad;
                        osr.CostoUnitario = refaccion.CostoUnitario.Value;
                        
                        // Aqui debe verificar si el precio es interno o externo
                        if (this.TipoClienteTaller_ID == 1 || this.TipoClienteTaller_ID == 2 || this.TipoClienteTaller_ID == 3)
                        {
                            osr.PrecioUnitario = refaccion.PrecioInterno.Value;
                        }
                        else
                        {
                            osr.PrecioUnitario = refaccion.PrecioExterno.Value;
                        }                        
                        // Fin de verificación

                        osr.Refaccion_ID = refaccion.Refaccion_ID.Value;
                        osr.RefSurtidas = 0;
                        osr.Total = osr.PrecioUnitario * osr.Cantidad;
                        osr.Refaccion_Descripcion = refaccion.Descripcion;
                        ordenServicio.OrdenesServiciosRefacciones.Add(osr);

                        //  Si hay inventario para la refacción
                        ExisteInventario = true;

                        //  Salir del ciclo
                        break;
                    } // End if
                } // End foreach

                //  Si no existe inventario
                if (!ExisteInventario)
                {
                    // Obtener las refacciones por tipo de servicio y modelo del auto  generico
                    refacciones =
                    Entities.Vista_Refacciones.Get(
                        null,
                        tipoRef.TipoRefaccion_ID,
                        null,
                        9,
                        null,
                        null,
                        null,
                        Sesion.Empresa_ID.Value,
                        Sesion.Estacion_ID.Value
                    );

                    //  Verificamos que existan refacciones
                    if (refacciones.Count == 0)
                    {
                        Entities.TiposRefacciones tiporefaccion = Entities.TiposRefacciones.Read(tipoRef.TipoRefaccion_ID);
                        Entities.Modelos modelo = Entities.Modelos.Read(modeloUnidad_ID.Value);

                        AppHelper.ThrowException("No hay refacciones del tipo {0} y modelo {1}", tiporefaccion.Nombre, modelo.Nombre);
                    }
                    
                    foreach (Entities.Vista_Refacciones refaccion in refacciones)
                    {
                        //  Si hay inventario
                        int cantidad = tipoRef.Cantidad * ordenServicio.Cantidad;

                        /*  Verificar el inventario
                          Consultamos el inventario existente de la refacción, así como la cantidad
                          por surtir. Si la cantidad restante no es suficente, enviaremos aviso
                         * */
                        int inventario =
                            Entities.Functions.GetInventarioDiferido(
                                refaccion.Refaccion_ID.Value,
                                Sesion.Empresa_ID.Value,
                                Sesion.Estacion_ID.Value
                            );

                        //  Si hay inventario suficiente
                        if (inventario >= cantidad)
                        {
                            //  Agregamos las refacciones
                            //  a la orden de servicio
                            Entities.OrdenesServiciosRefacciones osr = new Entities.OrdenesServiciosRefacciones();
                            osr.Cantidad = cantidad;
                            osr.CostoUnitario = refaccion.CostoUnitario.Value;

                            // Aqui debe verificar si el precio es interno o externo
                            if (this.TipoClienteTaller_ID == 1 || this.TipoClienteTaller_ID == 2 || this.TipoClienteTaller_ID == 3)
                            {
                                osr.PrecioUnitario = refaccion.PrecioInterno.Value;
                            }
                            else
                            {
                                osr.PrecioUnitario = refaccion.PrecioExterno.Value;
                            }
                            // Fin de verificación

                            osr.Refaccion_ID = refaccion.Refaccion_ID.Value;
                            osr.RefSurtidas = 0;
                            osr.Total = osr.PrecioUnitario * osr.Cantidad;
                            osr.Refaccion_Descripcion = refaccion.Descripcion;
                            ordenServicio.OrdenesServiciosRefacciones.Add(osr);

                            //  Si existe inventario
                            ExisteInventario = true;

                            //  Salimos del ciclo
                            break;
                        }   //  End if
                    } // End foreach
                } // End if

                //  Si no hay inventario, ni siguiera con modelo genérico
                if (!ExisteInventario)
                {
                    Entities.TiposRefacciones tiporefaccion = Entities.TiposRefacciones.Read(tipoRef.TipoRefaccion_ID);
                    Entities.Modelos modelo = Entities.Modelos.Read(modeloUnidad_ID.Value);

                    AppHelper.ThrowException("No hay refacciones del tipo {0} y modelo {1}", tiporefaccion.Nombre, modelo.Nombre);
                }

                ExisteInventario = false; continue;
            } // End foreach

            Padre.OrdenTrabajo.OrdenesServicios.Add(ordenServicio);

            MostrarTotales();
        }

        private void MostrarTotales()
        {
            //  Databind a servicios
            this.ordenesServiciosBindingSource.DataSource = Padre.OrdenTrabajo.OrdenesServicios;
            this.ordenesServiciosBindingSource.ResetBindings(false);

            //  Generar una lista total de refacciones de todas las ordenes de servicios
            List<Entities.OrdenesServiciosRefacciones> ordenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();
            foreach (Entities.OrdenesServicios os in Padre.OrdenTrabajo.OrdenesServicios)
            {
                ordenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
            }

            //  DataBind a refacciones
            this.RefaccionesAgregadasDataGrdiView.DataSource = ordenesServiciosRefacciones;
            this.vista_ServiciosMantenimientosBindingSource.DataSource = null;
            Padre.OrdenTrabajo.CalcularTotales();
            Padre.MostrarTotales();
        }

        private void EliminarOrdenServicio(Entities.OrdenesServicios os)
        {
            Padre.OrdenTrabajo.OrdenesServicios.Remove(os);
            MostrarTotales();
        }

        private void AgregarRefaccion(Entities.Vista_Refacciones refaccion, int cantidad)
        {
            /*  Verificar el inventario
              Consultamos el inventario existente de la refacción, así como la cantidad
              por surtir. Si la cantidad restante no es suficente, enviaremos aviso
            */
            int inventario = 
                Entities.Functions.GetInventarioDiferido(
                    refaccion.Refaccion_ID.Value, 
                    Sesion.Empresa_ID.Value, 
                    Sesion.Estacion_ID.Value
                );

            if (inventario < cantidad)
            {
                throw new Exception("No hay inventario suficiente de la refacción (incluyendo refacciones por surtir)");
            }
            //  Obtener el tipo de cliente

            Entities.OrdenesServiciosRefacciones osr = new Entities.OrdenesServiciosRefacciones();
            osr.Cantidad = cantidad;
            osr.CostoUnitario = refaccion.CostoUnitario.Value;
            osr.PrecioUnitario = refaccion.PrecioInterno.Value; // Verificar
            osr.Refaccion_Descripcion = refaccion.Descripcion;
            osr.Refaccion_ID = refaccion.Refaccion_ID.Value;
            osr.RefSurtidas = 0;
            osr.Total = osr.PrecioUnitario * osr.Cantidad;

            if (this.Padre.OrdenTrabajo.OrdenesServicios.Count == 0)
            {
                Entities.OrdenesServicios ordenServicio = new Entities.OrdenesServicios();
                ordenServicio.Cantidad = 1;
                ordenServicio.EstatusOrdenServicio_ID = 1;
                ordenServicio.Precio = 0;
                ordenServicio.ServicioMantenimiento_ID = 872;
                ordenServicio.Total = 0;
                ordenServicio.ServicioMantenimiento_Descripcion = "VENTA DE REFACCIONES";
                this.Padre.OrdenTrabajo.OrdenesServicios.Add(ordenServicio);
            }

            this.Padre.OrdenTrabajo.OrdenesServicios[0].OrdenesServiciosRefacciones.Add(osr);

            MostrarTotales();
        }

        private void EliminarOrdenServicioRefaccion(Entities.OrdenesServiciosRefacciones osr)
        {
            this.Padre.OrdenTrabajo.OrdenesServicios[0].OrdenesServiciosRefacciones.Remove(osr);

            MostrarTotales();
        }
        
        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoValidate();
                Padre.SwitchPanel("Mecanico");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void AnteriorButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("CobrarA");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }        

        private void ServiciosAgregadosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ServiciosAgregadosDataGridView.Columns["EliminarOS"].Index == e.ColumnIndex)
                {
                    Entities.OrdenesServicios os = (Entities.OrdenesServicios)ServiciosAgregadosDataGridView.Rows[e.RowIndex].DataBoundItem;
                    EliminarOrdenServicio(os);
                } // End if
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }        

        private void ServiciosButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    ObtenerTipoClienteTaller();
                    this.BuscarServiciosForm.TipoClienteTaller_ID = this.TipoClienteTaller_ID;
                    this.BuscarServiciosForm.Padre = this.Padre;

                    if (this.BuscarServiciosForm.ShowDialog() == DialogResult.OK)
                    {
                        if (this.BuscarServiciosForm.EsRefaccionesIncluidas)
                        {
                            AgregarServicio(this.BuscarServiciosForm.Servicio, this.BuscarServiciosForm.Cantidad);
                        }
                        else
                        {
                            AgregarVentaServicio(this.BuscarServiciosForm.Servicio, this.BuscarServiciosForm.Cantidad);
                        } // end else
                    } // end if        
                } // end delegate
            ); // end AppHelper.Try()
        } // end void ServiciosButton_Click

        private void RefaccionesButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (this.BuscarRefaccionesForm.ShowDialog() == DialogResult.OK)
                    {
                        AgregarRefaccion(
                            this.BuscarRefaccionesForm.Refaccion, 
                            this.BuscarRefaccionesForm.Cantidad
                        );
                    } // end if        
                } // end delegate
            ); // end AppHelper.Try
        } // end void RefaccionesButton_Click

        private void ServiciosUC_Load(object sender, EventArgs e)
        {

        }

        private void RefaccionesAgregadasDataGrdiView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.RefaccionesAgregadasDataGrdiView.Columns["EliminarRef"].Index == e.ColumnIndex)
                {
                    Entities.OrdenesServiciosRefacciones osr =
                        (Entities.OrdenesServiciosRefacciones)RefaccionesAgregadasDataGrdiView.Rows[e.RowIndex].DataBoundItem;
                    EliminarOrdenServicioRefaccion(osr);
                } // End if
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        } // End void

    } // End class
} // End namespace
