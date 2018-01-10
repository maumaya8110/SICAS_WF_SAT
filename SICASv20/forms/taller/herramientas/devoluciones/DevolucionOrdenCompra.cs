using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class DevolucionOrdenCompra : baseForm
    {
        public DevolucionOrdenCompra()
        {
            InitializeComponent();
        }

        #region Properties

        DevolucionOrdenCompra_Model Model;

        #endregion

        #region Model
        /// <summary>
        /// Clase Model para la operación de Devoluciones de Refacciones de Ordenes de Trabajo
        /// </summary>
        class DevolucionOrdenCompra_Model
        {
            /// <summary>
            /// ID de la orden de compra a efectuar devolución
            /// </summary>            
            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            /// <summary>
            /// La lista de refacciones de la orden de compra
            /// </summary>
            private List<Entities.Vista_RefaccionesDevolucionesOrdenesCompras> _ListaRefacciones;
            public List<Entities.Vista_RefaccionesDevolucionesOrdenesCompras> ListaRefacciones
            {
                get { return _ListaRefacciones; }
                set { _ListaRefacciones = value; }
            }

            /// <summary>
            /// Verifica que la orden de compra esta cancelada
            /// </summary>
            public void VerificarCancelacion()
            {                
                DB.Params = DB.GetParams(
                        DB.Param("OrdenCompra_ID",this.OrdenCompra_ID)
                        );

                int cont = DB.GetCount("OrdenesComprasCanceladas", DB.Params);

                if (cont == 0) AppHelper.ThrowException("La orden de compra {0} no esta cancelada", this.OrdenCompra_ID);

                DB.Params = DB.GetParams(
                        DB.Param("EstatusOrdenCompra_ID", 2),
                        DB.Param("OrdenCompra_ID", this.OrdenCompra_ID)
                        );

                cont = DB.GetCount("OrdenesCompras",DB.Params);

                if (cont == 0) AppHelper.ThrowException("La orden de compra {0} no esta cancelada", this.OrdenCompra_ID);

                //  Verificar devoluciones
                cont = DB.GetCount(
                        "MovimientosInventario",
                        DB.GetParams(
                            DB.Param("OrdenCompra_ID", this.OrdenCompra_ID),
                            DB.Param("TipoMovimientoInventario_ID", 4) // La devolucion por cancelación
                        )
                    );

                if (cont > 0)
                {
                    AppHelper.ThrowException("Las devoluciones de la orden de compra {0} ya han sido realizadas", this.OrdenCompra_ID);
                }

                //  Verificar que pertenezca a empresa y estación

                DB.Params = DB.GetParams(
                       DB.Param("OrdenCompra_ID", this.OrdenCompra_ID),
                       DB.Param("Empresa_ID", Sesion.Empresa_ID.Value),
                       DB.Param("Estacion_ID", Sesion.Estacion_ID.Value)
                    );

                cont = DB.GetCount("OrdenesCompras", DB.Params);

                if (cont == 0) AppHelper.ThrowException("La orden de compra {0} no pertenece a la empresa y a la estación del usuario", this.OrdenCompra_ID);
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
                NotaAlmacen.OrdenCompra_ID = this.OrdenCompra_ID;
                NotaAlmacen.TipoMovimientoInventario_ID = 4; // Cancelacion de O.C.
                NotaAlmacen.Usuario_ID = Sesion.Usuario_ID;
                NotaAlmacen.Empresa_ID = Sesion.Empresa_ID.Value;
                NotaAlmacen.Estacion_ID = Sesion.Estacion_ID.Value;
                NotaAlmacen.Create();

                //  Registrar el movimiento para cada refaccion
                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesCompras devolucion in this.ListaRefacciones)
                {
                    if (devolucion.Salida > 0)
                    {
                        MovimientoInventario.Cantidad = devolucion.Salida * -1;
                        MovimientoInventario.CostoUnitario = devolucion.CostoUnitario;
                        MovimientoInventario.Fecha = NotaAlmacen.Fecha;
                        MovimientoInventario.NotaAlmacen_ID = NotaAlmacen.NotaAlmacen_ID;
                        MovimientoInventario.OrdenCompra_ID = NotaAlmacen.OrdenCompra_ID;
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

                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesCompras vistaOSR in ListaRefacciones)
                {
                    PorDevolver += vistaOSR.PorDevolver;
                }

                if (PorDevolver == 0)
                {
                    AppHelper.ThrowException(
                    "En la orden de compra {0} las devoluciones se han realizado completamente",
                    this.OrdenCompra_ID);
                }
            }

            public void DevolverTodas()
            {
                foreach (Entities.Vista_RefaccionesDevolucionesOrdenesCompras vistaOSR in ListaRefacciones)
                {
                    vistaOSR.Salida = vistaOSR.PorDevolver;
                }
                EfectuarDevolucion();
            }

            public void ConsultarRefacciones()
            {
                this.ListaRefacciones = Entities.Vista_RefaccionesDevolucionesOrdenesCompras.Get(this.OrdenCompra_ID);
            }

            public void Validar()
            {
                if (this.OrdenCompra_ID == 0)
                    AppHelper.ThrowException("Debe capturar una orden de compra");

                if (this.ListaRefacciones == null)
                    AppHelper.ThrowException("Debe capturar una orden de compra");

                if (this.ListaRefacciones.Count == 0)
                    AppHelper.ThrowException("La orden de compra no tiene refacciones");
            }
        }
        #endregion

        #region Eventos
        public override void BindData()
        {
            this.Model = new DevolucionOrdenCompra_Model();
            base.BindData();
        }

        private void OrdenTrabajoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(delegate
            {
                if (e.KeyData == Keys.Enter)
                {
                    Model.OrdenCompra_ID = Convert.ToInt32(this.OrdenCompraTextBox.Text);
                    Model.VerificarCancelacion();
                    Model.ConsultarRefacciones();
                    Model.VerificarDevoluciones();
                    this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource.DataSource = Model.ListaRefacciones;
                }
            });
        }

        private void RefaccionesGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(delegate
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].DataPropertyName == "Salida")
                {
                    object valor = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (valor == null)
                    {
                        throw new Exception("No se pueden ingresar valores nulos");
                    }

                    Entities.Vista_RefaccionesDevolucionesOrdenesCompras oc =
                        (Entities.Vista_RefaccionesDevolucionesOrdenesCompras)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;

                    if (Convert.ToInt32(valor) < 0)
                    {
                        throw new Exception("No se pueden ingresar valores negativos");
                    }

                    if (Convert.ToInt32(valor) > oc.PorDevolver)
                    {
                        throw new Exception("Se esta dando salida a un numero mayor de lo que se debe devolver");
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
                AppHelper.Info("Devolución realizada");
            }, this);
        }

        private void RegistrarMovimientoButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                Model.Validar();
                Model.EfectuarDevolucion();
                AppHelper.ClearControl(this);
                AppHelper.Info("Devolución realizada");
            }, this);
        }
        #endregion
    }
}
