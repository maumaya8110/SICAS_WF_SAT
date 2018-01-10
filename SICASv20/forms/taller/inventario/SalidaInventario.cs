using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SICASv20.forms
{
    public partial class SalidaInventario : baseForm
    {
        public SalidaInventario()
        {
            InitializeComponent();
            this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource.DataSource = null;
        }

        #region Declarations
        
        Entities.NotasAlmacen NotaAlmacen;
        Entities.OrdenesTrabajos OrdenTrabajo;
        Entities.MovimientosInventario MovimientoInventario;
        List<Entities.Vista_OrdenesServiciosRefaccionesAlmacen> Vista_OSR = new List<Entities.Vista_OrdenesServiciosRefaccionesAlmacen>();
        
        #endregion

        #region Methods (Controller)

        private void DoValidate()
        {
            if (this.OrdenTrabajo == null) AppHelper.ThrowException("Debe capturar una orden de trabajo");
            if (this.Vista_OSR == null) AppHelper.ThrowException("No hay refacciones que registrar");
        }

        private void BuscarOrdenTrabajo()
        {
            int ordentrabajo_id = Convert.ToInt32(this.OrdenTrabajoTextBox.Text);
            OrdenTrabajo = Entities.OrdenesTrabajos.Read(ordentrabajo_id);

            if (OrdenTrabajo.EstatusOrdenTrabajo_ID == 5)
            {
                throw new Exception("La orden de trabajo está cancelada");
            }

            Vista_OSR = Entities.Vista_OrdenesServiciosRefaccionesAlmacen.Get(Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value, ordentrabajo_id);

            if (Vista_OSR.Count == 0)
            {
                AppHelper.ThrowException("No existen refacciones para la orden de trabajo");
            }

            this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource.DataSource = Vista_OSR;
        }

        private void RegistrarMovimiento()
        {
            DoValidate();

            int PorSurtir = 0;

            foreach (Entities.Vista_OrdenesServiciosRefaccionesAlmacen vistaOSR in Vista_OSR)
            {
                PorSurtir += vistaOSR.Salida.Value;
            }

            if (PorSurtir == 0)
            {
                AppHelper.ThrowException(
                "La orden de trabajo {0} esta completamente surtida",
                this.OrdenTrabajo.OrdenTrabajo_ID);
            } 

            NotaAlmacen = new Entities.NotasAlmacen();
            MovimientoInventario = new Entities.MovimientosInventario();

            //  Insertar Nota Almacen
            NotaAlmacen.Fecha = DB.GetDate();
            NotaAlmacen.OrdenTrabajo_ID = OrdenTrabajo.OrdenTrabajo_ID;
            NotaAlmacen.TipoMovimientoInventario_ID = 1; // O.T.
            NotaAlmacen.Usuario_ID = Sesion.Usuario_ID;
            NotaAlmacen.Empresa_ID = Sesion.Empresa_ID.Value;
            NotaAlmacen.Estacion_ID = Sesion.Estacion_ID.Value;
            NotaAlmacen.Create();

            //  Insertar Movimientos Inventario
            foreach (Entities.Vista_OrdenesServiciosRefaccionesAlmacen osr in Vista_OSR)
            {
                if (osr.Salida.Value > 0 && osr.CantidadInventario.Value >= osr.Salida.Value)
                {
                    MovimientoInventario.Cantidad = osr.Salida.Value * -1;
                    MovimientoInventario.CantidadPost = MovimientoInventario.CantidadPrev - osr.Salida.Value;
                    MovimientoInventario.CostoUnitario = osr.CostoUnitario.Value;
                    MovimientoInventario.Fecha = NotaAlmacen.Fecha;
                    MovimientoInventario.NotaAlmacen_ID = NotaAlmacen.NotaAlmacen_ID;
                    MovimientoInventario.OrdenTrabajo_ID = NotaAlmacen.OrdenTrabajo_ID;
                    MovimientoInventario.Refaccion_ID = osr.Refaccion_ID.Value;
                    MovimientoInventario.TipoMovimientoInventario_ID = NotaAlmacen.TipoMovimientoInventario_ID;
                    MovimientoInventario.Usuario_ID = NotaAlmacen.Usuario_ID;
                    MovimientoInventario.Valor = MovimientoInventario.Cantidad * MovimientoInventario.CostoUnitario;
                    MovimientoInventario.Empresa_ID = Sesion.Empresa_ID.Value;
                    MovimientoInventario.Estacion_ID = Sesion.Estacion_ID.Value;
                    MovimientoInventario.Calculate();
                    MovimientoInventario.Create();

                    //  Actualizar refaccion
                    MovimientoInventario.UpdateRefaccion(false);

                    //  Actualizar compra
                    Entities.OrdenesServiciosRefacciones OSR = Entities.OrdenesServiciosRefacciones.Read(osr.OrdenServicioRefaccion_ID.Value);
                    OSR.RefSurtidas += osr.Salida;
                    OSR.Update();
                }                
            }            
        }

        private void Clear()
        {
            AppHelper.ClearControl(this);
            this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource.DataSource = null;
        }

        private void DisplayReport()
        {

        }

        private void SurtirTodas()
        {
            DoValidate();

            foreach (Entities.Vista_OrdenesServiciosRefaccionesAlmacen vistaOSR in Vista_OSR)
            {
                vistaOSR.Salida = vistaOSR.PorSurtir;
            }

            RegistrarMovimiento();            
        }
        #endregion

        #region Events (View)

        private void RegistrarMovimientoButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod
            (
                delegate
                {
                    RegistrarMovimiento();
                    Clear();
                    DisplayReport();
                    AppHelper.Info("Movimientos efectuados");
                },
                this
            );
        }

        private void OrdenTrabajoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    BuscarOrdenTrabajo();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
        #endregion

        private void RefaccionesGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].DataPropertyName == "Salida")
                {
                    object valor = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if(valor==null)
                    {
                        throw new Exception("No se pueden ingresar valores nulos");
                    }

                    Entities.Vista_OrdenesServiciosRefaccionesAlmacen osr = (Entities.Vista_OrdenesServiciosRefaccionesAlmacen)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;
                    if (Convert.ToInt32(valor) < 0)
                    {
                        throw new Exception("No se pueden ingresar valores negativos");
                    }

                    if (Convert.ToInt32(valor) > osr.PorSurtir)
                    {
                        throw new Exception("Se esta dando salida a un numero mayor de lo que se debe surtir");
                    }
                }
            }
            catch (Exception ex)
            {
                RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                AppHelper.Error(ex.Message);
            }
        }

        private void SurtirTodasButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {                
                SurtirTodas();
                Clear();
                DisplayReport();
                AppHelper.Info("Movimientos efectuados");
            }, this);
        }

        private void RefaccionesGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (vista_OrdenesServiciosRefaccionesAlmacenBindingSource.DataSource != null)
                    {
                        this.SurtirTodasButton.Enabled = true;
                        this.RegistrarMovimientoButton.Enabled = true;

                        bool FaltaInventario = false;
                        int cont, totalrows;

                        totalrows = this.RefaccionesGridView.Rows.Count;
                        cont = 0;

                        foreach (DataGridViewRow row in RefaccionesGridView.Rows)
                        {
                            Entities.Vista_OrdenesServiciosRefaccionesAlmacen osr =
                                (Entities.Vista_OrdenesServiciosRefaccionesAlmacen)row.DataBoundItem;

                            if (osr.PorSurtir.Value > osr.CantidadInventario.Value)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                row.DefaultCellStyle.ForeColor = Color.White;

                                FaltaInventario = true;

                                cont++;
                            }
                        }

                        if (FaltaInventario)
                        {
                            AppHelper.Info(@"Existen refacciones que no se pueden surtir por falta de inventario
- Resaltadas en rojo -");
                        }

                        if (cont == totalrows)
                        {
                            AppHelper.Error(@"Ninguna refacción puede surtirse por falta de inventario");
                            this.SurtirTodasButton.Enabled = false;
                            this.RegistrarMovimientoButton.Enabled = false;
                        }
                    }
                }
            );
        }

    } // End Class
} // End Namespace
