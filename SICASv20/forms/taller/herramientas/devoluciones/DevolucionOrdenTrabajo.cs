using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class DevolucionOrdenTrabajo : baseForm
    {
        public DevolucionOrdenTrabajo()
        {
            InitializeComponent();
        }

        #region Properties

        DevolucionOrdenTrabajo_Model Model;

        #endregion

        #region Model
        /// <summary>
        /// Clase Model para la operación de Devoluciones de Refacciones de Ordenes de Trabajo
        /// </summary>
        class DevolucionOrdenTrabajo_Model
        {
            /// <summary>
            /// ID de la orden de trabajo a efectuar devolución
            /// </summary>            
            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            /// <summary>
            /// La lista de refacciones de la orden de trabajo
            /// </summary>
            private List<Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo> _ListaRefacciones;
            public List<Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo> ListaRefacciones
            {
                get { return _ListaRefacciones; }
                set { _ListaRefacciones = value; }
            }

            /// <summary>
            /// Verifica que la orden de trabajo esta cancelada
            /// </summary>
            public void VerificarCancelacion()
            {
                int cont = DB.GetCount(
                    "CancelacionesOrdenesTrabajos", 
                    DB.GetParams(
                        DB.Param(
                            "OrdenTrabajo_ID", 
                            this.OrdenTrabajo_ID)
                        )
                    );

                if (cont == 0) AppHelper.ThrowException("La orden de trabajo {0} no esta cancelada", this.OrdenTrabajo_ID);

                cont = DB.GetCount(
                    "OrdenesTrabajos",
                    DB.GetParams(
                        DB.Param("EstatusOrdenTrabajo_ID",5)
                        )
                    );

                if (cont == 0) AppHelper.ThrowException("La orden de trabajo {0} no esta cancelada", this.OrdenTrabajo_ID);

                cont = DB.GetCount(
                        "MovimientosInventario",
                        DB.GetParams(
                            DB.Param("OrdenTrabajo_ID", this.OrdenTrabajo_ID),
                            DB.Param("TipoMovimientoInventario_ID", 6) // La devolucion por cancelación
                        )
                    );

                if (cont > 0) AppHelper.ThrowException("Las devoluciones de la orden de trabajo {0} ya han sido realizadas", this.OrdenTrabajo_ID);

                cont = DB.GetCount(
                    "OrdenesTrabajos",
                    DB.GetParams(
                        DB.Param("Empresa_ID", Sesion.Empresa_ID.Value),
                        DB.Param("Estacion_ID", Sesion.Estacion_ID.Value)
                        )
                    );
                
                if (cont == 0) AppHelper.ThrowException("La orden de trabajo {0} no pertenece a la empresa y a la estación del usuario", this.OrdenTrabajo_ID);
            }

            /// <summary>
            /// Realiza la devolución de las refacciones
            /// </summary>
            public void EfectuarDevolucion()
            {
                //  Variables
                Entities.NotasAlmacen NotaAlmacen = new Entities.NotasAlmacen();
                Entities.MovimientosInventario MovimientoInventario = new Entities.MovimientosInventario();

                //  Crear la nota de almacen                
                NotaAlmacen.Fecha = DB.GetDate();
                NotaAlmacen.OrdenCompra_ID = null;
                NotaAlmacen.OrdenTrabajo_ID = this.OrdenTrabajo_ID;
                NotaAlmacen.TipoMovimientoInventario_ID = 6; // Cancelacion de O.T.
                NotaAlmacen.Usuario_ID = Sesion.Usuario_ID;
                NotaAlmacen.Empresa_ID = Sesion.Empresa_ID.Value;
                NotaAlmacen.Estacion_ID = Sesion.Estacion_ID.Value;
                NotaAlmacen.Create();

                //  Registrar el movimiento para cada refaccion
                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo devolucion in this.ListaRefacciones)
                {
                    if (devolucion.Entrada > 0)
                    {                        
                        MovimientoInventario.Cantidad = devolucion.Entrada;
                        MovimientoInventario.CostoUnitario = devolucion.CostoUnitario;
                        MovimientoInventario.Fecha = NotaAlmacen.Fecha;
                        MovimientoInventario.NotaAlmacen_ID = NotaAlmacen.NotaAlmacen_ID;
                        MovimientoInventario.OrdenTrabajo_ID = NotaAlmacen.OrdenTrabajo_ID;
                        MovimientoInventario.Refaccion_ID = devolucion.Refaccion_ID;
                        MovimientoInventario.TipoMovimientoInventario_ID = NotaAlmacen.TipoMovimientoInventario_ID;
                        MovimientoInventario.Usuario_ID = NotaAlmacen.Usuario_ID;
                        MovimientoInventario.Valor = MovimientoInventario.Cantidad * MovimientoInventario.CostoUnitario;
                        MovimientoInventario.Empresa_ID = NotaAlmacen.Empresa_ID;
                        MovimientoInventario.Estacion_ID = NotaAlmacen.Estacion_ID;
                        MovimientoInventario.Calculate();
                        MovimientoInventario.Create();

                        //  Actualizar refaccion
                        MovimientoInventario.UpdateRefaccion(false);
                    }
                }
            }

            public void VerificarDevoluciones()
            {
                int PorDevolver = 0;

                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo vistaOSR in ListaRefacciones)
                {
                    PorDevolver += vistaOSR.PorDevolver;
                }

                if (PorDevolver == 0)
                {
                    AppHelper.ThrowException(
                    "En la orden de trabajo {0} las devoluciones se han realizado completamente",
                    this.OrdenTrabajo_ID);
                } 
            }

            public void DevolverTodas()
            {
                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo vistaOSR in ListaRefacciones)
                {
                    vistaOSR.Entrada = vistaOSR.PorDevolver;
                }
                EfectuarDevolucion();
            }

            public void ConsultarRefacciones()
            {
                this.ListaRefacciones = Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo.Get(this.OrdenTrabajo_ID);
            }

            public void Validar()
            {
                if (this.OrdenTrabajo_ID == 0)
                    AppHelper.ThrowException("Debe capturar una orden de trabajo");

                if (this.ListaRefacciones == null)
                    AppHelper.ThrowException("Debe capturar una orden de trabajo");

                if(this.ListaRefacciones.Count==0)
                    AppHelper.ThrowException("La orden de trabajo no tiene refacciones");                
            }
        }
        #endregion

        #region Eventos
        public override void BindData()
        {
            this.Model = new DevolucionOrdenTrabajo_Model();
            base.BindData();
        }

        private void OrdenTrabajoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(delegate
            {
                if (e.KeyData == Keys.Enter)
                {
                    Model.OrdenTrabajo_ID = Convert.ToInt32(this.OrdenTrabajoTextBox.Text);
                    Model.VerificarCancelacion();
                    Model.ConsultarRefacciones();
                    Model.VerificarDevoluciones();
                    this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource.DataSource = Model.ListaRefacciones;
                }
            });
        }

        private void RefaccionesGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(delegate 
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].DataPropertyName == "Entrada")
                {
                    object valor = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (valor == null)
                    {
                        throw new Exception("No se pueden ingresar valores nulos");
                    }

                    Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo osr =
                        (Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;

                    if (Convert.ToInt32(valor) < 0)
                    {
                        throw new Exception("No se pueden ingresar valores negativos");
                    }

                    if (Convert.ToInt32(valor) > osr.PorDevolver)
                    {
                        throw new Exception("Se esta dando entrada a un numero mayor de lo que se debe devolver");
                    }
                }
            });
        }

        private void SurtirTodasButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                Model.Validar();
                Model.DevolverTodas();
                AppHelper.ClearControl(this);
                this.Model = new DevolucionOrdenTrabajo_Model();
                this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource.DataSource = null;
                AppHelper.Info("Devolución realizada");
            },this);
        }

        private void RegistrarMovimientoButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                Model.Validar();
                Model.EfectuarDevolucion();
                AppHelper.ClearControl(this);
                this.Model = new DevolucionOrdenTrabajo_Model();
                this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource.DataSource = null;
                AppHelper.Info("Devolución realizada");
            }, this);
        }
        #endregion
    }        
}
