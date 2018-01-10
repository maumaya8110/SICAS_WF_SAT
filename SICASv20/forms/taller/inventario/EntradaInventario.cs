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
    public partial class EntradaInventario : baseForm
    {
        public EntradaInventario()
        {
            InitializeComponent();
        }

        #region Declarations
        
        Entities.NotasAlmacen NotaAlmacen;
        Entities.OrdenesCompras OrdenCompra;
        Entities.MovimientosInventario MovimientoInventario;
        List<Entities.Vista_ComprasAlmacen> VistaCompras;
        object ValorPrevio;
        
        #endregion

        #region Methods (Controller)

        private void BuscarOrdenCompra()
        {
            int ordencompra_id = Convert.ToInt32(this.OrdenCompraTextBox.Text);
            OrdenCompra = Entities.OrdenesCompras.Read(ordencompra_id);

            if (OrdenCompra.EstatusOrdenCompra_ID != 1)
            {
                throw new Exception("La orden de compra esta cancelada");
            }
            this.label4.Visible = true;
            this.FacturaTextBox.Visible = true;
            VistaCompras = Entities.Vista_ComprasAlmacen.Get(ordencompra_id, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
            this.vista_ComprasAlmacenBindingSource.DataSource = VistaCompras;
        }

        private void RegistrarMovimiento()
        {
            DoValidate();

            int PorSurtir = 0;
            foreach (Entities.Vista_ComprasAlmacen vistaCompra in VistaCompras)
            {
                PorSurtir += vistaCompra.Entrada;
            }

            if (PorSurtir == 0)
            {
                AppHelper.ThrowException(
                "La orden de compra {0} esta completamente surtida",
                this.OrdenCompra.OrdenCompra_ID);
            }  

            NotaAlmacen = new Entities.NotasAlmacen();
            MovimientoInventario = new Entities.MovimientosInventario();

            //  Insertar Nota Almacen
            NotaAlmacen.Fecha = DB.GetDate();
            NotaAlmacen.OrdenCompra_ID = OrdenCompra.OrdenCompra_ID;
            NotaAlmacen.TipoMovimientoInventario_ID = 2; // Compra
            NotaAlmacen.Usuario_ID = Sesion.Usuario_ID;
            NotaAlmacen.Empresa_ID = Sesion.Empresa_ID.Value;
            NotaAlmacen.Estacion_ID = Sesion.Estacion_ID.Value;
            NotaAlmacen.Factura = FacturaTextBox.Text;
            NotaAlmacen.Create();            

            //  Insertar Movimientos Inventario
            foreach (Entities.Vista_ComprasAlmacen compra in VistaCompras)
            {
                if (compra.Entrada > 0)
                {
                    MovimientoInventario.Cantidad = compra.Entrada;
                    MovimientoInventario.CantidadPost = MovimientoInventario.CantidadPrev + compra.Entrada;
                    MovimientoInventario.CostoUnitario = compra.CostoUnitario;
                    MovimientoInventario.Fecha = NotaAlmacen.Fecha;
                    MovimientoInventario.NotaAlmacen_ID = NotaAlmacen.NotaAlmacen_ID;
                    MovimientoInventario.OrdenCompra_ID = NotaAlmacen.OrdenCompra_ID;
                    MovimientoInventario.Refaccion_ID = compra.Refaccion_ID;
                    MovimientoInventario.TipoMovimientoInventario_ID = NotaAlmacen.TipoMovimientoInventario_ID;
                    MovimientoInventario.Usuario_ID = NotaAlmacen.Usuario_ID;
                    MovimientoInventario.Valor = compra.Entrada * compra.CostoUnitario;
                    MovimientoInventario.Empresa_ID = Sesion.Empresa_ID.Value;
                    MovimientoInventario.Estacion_ID = Sesion.Estacion_ID.Value;
                    MovimientoInventario.Calculate();
                    MovimientoInventario.Create();

                    //  Actualizar refaccion
                    MovimientoInventario.UpdateRefaccion(true);
                }
            }

            //  Actualizar compra y sacar totale de Orden de Compra
            decimal subtotal = 0;
            foreach (Entities.Vista_ComprasAlmacen vistaCompra in VistaCompras)
            {
                Entities.Compras compra = Entities.Compras.Read(vistaCompra.Compra_ID);
                if (vistaCompra.Entrada > 0)
                {
                    compra.RefaccionesSurtidas += vistaCompra.Entrada;
                    compra.CostoUnitario = vistaCompra.CostoUnitario;
                    compra.Update();
                    subtotal += vistaCompra.CostoUnitario * compra.Cantidad;
                }
                else
                {
                    subtotal += compra.CostoUnitario * compra.Cantidad;
                }
            }

            // Actualizar Factura y Totales de Orden de Compra
            if (String.IsNullOrEmpty(OrdenCompra.Factura))
                OrdenCompra.Factura = FacturaTextBox.Text.ToUpper().Trim();
            else
                OrdenCompra.Factura = OrdenCompra.Factura.Trim() + ", " + FacturaTextBox.Text.ToUpper().Trim();
            OrdenCompra.Subtotal = subtotal;
            OrdenCompra.IVA = OrdenCompra.Subtotal * (decimal)0.16;
            OrdenCompra.Total = OrdenCompra.Subtotal + OrdenCompra.IVA;
            OrdenCompra.Update();
            OrdenCompra = null;
            this.label4.Visible = false;
            this.FacturaTextBox.Visible = false;

        }

        private void SurtirTodas()
        {
            DoValidate();

            int PorSurtir = 0;
            foreach (Entities.Vista_ComprasAlmacen vistaCompra in VistaCompras)
            {
                vistaCompra.Entrada = vistaCompra.PorSurtir;
                PorSurtir+=vistaCompra.Entrada;
            }

            if (PorSurtir == 0)
            {
                AppHelper.ThrowException(
                "La orden de compra {0} esta completamente surtida",
                this.OrdenCompra.OrdenCompra_ID);
            }                

            RegistrarMovimiento();            
        }

        private void Clear()
        {
            AppHelper.ClearControl(this);
            this.vista_ComprasAlmacenBindingSource.DataSource = null;
        }

        private void DisplayReport()
        {
 
        }

        private void DoValidate()
        {
            if (this.OrdenCompra == null) AppHelper.ThrowException("Debe capturar una orden de compra");
            if (this.VistaCompras == null) AppHelper.ThrowException("No hay refacciones que registrar");
            if (String.IsNullOrEmpty(this.FacturaTextBox.Text)) AppHelper.ThrowException("Debe ingresar el número de factura");
        }
        #endregion

        #region Events (View)

        private void RegistrarMovimientoButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                RegistrarMovimiento();
                Clear();
                DisplayReport();
                AppHelper.Info("Movimientos efectuados");
            }, this);
        }

        private void OrdenCompraTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    BuscarOrdenCompra();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
        #endregion

        private void RefaccionesGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ValorPrevio = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void RefaccionesGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].DataPropertyName == "Entrada")
                {
                    object valor = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    
                    if(valor==null)
                    {
                        throw new Exception("No se pueden ingresar valores nulos");
                    }

                    Entities.Vista_ComprasAlmacen compraAlmacen = (Entities.Vista_ComprasAlmacen)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;
                    if (Convert.ToInt32(valor) < 0)
                    {
                        throw new Exception("No se pueden ingresar valores negativos");
                    }

                    if (Convert.ToInt32(valor) > compraAlmacen.PorSurtir)
                    {
                        throw new Exception("Se esta dando entrada a un numero mayor de lo que se debe surtir");
                    }
                }
                if (RefaccionesGridView.Columns[e.ColumnIndex].DataPropertyName == "CostoUnitario")
                {
                    object valor = RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (valor == null)
                    {
                        throw new Exception("No se pueden ingresar valores nulos en Costo Unitario");
                    }

                    if (Convert.ToDecimal(valor) <= 0)
                    {
                        throw new Exception("No se puede ingresar un costo cero o negativo");
                    }
                }
            }
            catch (Exception ex)
            {
                RefaccionesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ValorPrevio;
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


    } // End Class
} // End Namespace
