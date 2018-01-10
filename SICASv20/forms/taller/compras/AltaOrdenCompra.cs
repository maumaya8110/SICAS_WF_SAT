using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SICASv20.forms
{
    public partial class AltaOrdenCompra : baseForm
    {
        public AltaOrdenCompra()
        {
            InitializeComponent();
        }

        #region Declarations

        Entities.OrdenesCompras OrdenCompra = new Entities.OrdenesCompras();
        Entities.Vista_Refacciones Refaccion = new Entities.Vista_Refacciones();
        Entities.Empresas Proveedor = new Entities.Empresas();
        forms.BuscarProveedor BusquedaProveedor;
        forms.BuscarRefaccion BusquedaRefaccion;

        public override void BindData()
        {
            this.BusquedaProveedor = new BuscarProveedor();            
            this.BusquedaRefaccion = new BuscarRefaccion();
            this.BusquedaRefaccion.Padre = this;
            base.BindData();
        }
        
        #endregion

        #region Methods (Model)

        private void ShowBusquedaRefaccion()
        {
            if (this.BusquedaRefaccion.IsDisposed)
            {
                this.BusquedaRefaccion = new BuscarRefaccion();
                this.BusquedaRefaccion.Padre = this;
            }
            this.BusquedaRefaccion.Show();            
        }

        public void Set_Refaccion(Entities.Vista_Refacciones refaccion)
        {
            this.Refaccion = refaccion;
            this.CodigoRefaccionTextBox.Text = refaccion.NumeroSerial;
            this.NombreRefaccionTextBox.Text = refaccion.Descripcion;
            this.CostoUnitarioTextBox.Text = AppHelper.N2(refaccion.CostoUnitario);
            this.CantidadNumericUpDown.Value = 1;
            this.TotalRefaccionTextBox.Text = AppHelper.N2(refaccion.CostoUnitario);
        }

        private void ShowBusquedaProveedor()
        {
            if (this.BusquedaProveedor.IsDisposed)
            {
                this.BusquedaProveedor = new BuscarProveedor();                
            }
            if (this.BusquedaProveedor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set_Proveedor(this.BusquedaProveedor.Proveedor);
            }
        }

        public void Set_Proveedor(Entities.Empresas empresa)
        {
            this.Proveedor = empresa;
            this.OrdenCompra.Proveedor_ID = this.Proveedor.Empresa_ID;
            this.NombreProveedorTextBox.Text = this.Proveedor.RazonSocial;
        }

        private void BuscarProveedorPorID()
        {
            int Proveedor_ID = Convert.ToInt32(this.CodigoProveedorTextBox.Text);
            
            Entities.Empresas proveedor = Entities.Empresas.ReadSingle("Empresa_ID = @Empresa_ID AND TipoEmpresa_ID = 4", null, DB.Param("@Empresa_ID",Proveedor_ID));
            if (proveedor == null) throw new Exception("Código de proveedor inválido");

            OrdenCompra.Proveedor_ID = proveedor.Empresa_ID;
            NombreProveedorTextBox.Text = proveedor.RazonSocial;
        }

        private void BuscarRefaccionPorCodigo()
        {
            string codigo = this.CodigoRefaccionTextBox.Text;
            
            List<Entities.Vista_Refacciones> refs = Entities.Vista_Refacciones.Get(
                null,
                null,
                null,
                null,
                null,
                null,
                codigo,
                Sesion.Empresa_ID.Value,
                Sesion.Estacion_ID.Value
            );

            if (refs.Count > 0)
            {
                Refaccion = refs[0];
            }
            else
            {
                Refaccion = null;
            }

            if (Refaccion == null) throw new Exception("Código de refaccion inválido");            

            this.NombreRefaccionTextBox.Text = Refaccion.Descripcion;
            this.CostoUnitarioTextBox.Text = AppHelper.N2(Refaccion.CostoUnitario);
            this.CantidadNumericUpDown.Value = 1;
            this.TotalRefaccionTextBox.Text = AppHelper.N2(Refaccion.CostoUnitario);
        }

        private void AgregarRefaccion()
        {
            Entities.Compras compra = new Entities.Compras();
            compra.Cantidad = (int)this.CantidadNumericUpDown.Value;
            compra.CostoUnitario = Convert.ToDecimal(this.CostoUnitarioTextBox.Text);

            if (compra.CostoUnitario <= 0)
            {
                throw new Exception("No se pueden comprar articulos con costo 0");
            }

            compra.MarcaRefaccion_ID = Refaccion.MarcaRefaccion_ID.Value;
            compra.Refaccion_Descripcion = Refaccion.Descripcion;
            compra.Refaccion_ID = Refaccion.Refaccion_ID.Value;
            compra.RefaccionesSurtidas = 0;            
            compra.Usuario_ID = Sesion.Usuario_ID;

            OrdenCompra.Compras.Add(compra);
            comprasBindingSource.DataSource = null;
            comprasBindingSource.DataSource = OrdenCompra.Compras;
            CalcularTotales();
            ClearRefaccion();
        }

        private void CalcularTotalRefaccion()
        {
            try
            {
                decimal totalrefaccion, costounitario, cantidad;
                costounitario = Convert.ToDecimal(CostoUnitarioTextBox.Text);
                cantidad = Convert.ToDecimal(CantidadNumericUpDown.Value);
                totalrefaccion = costounitario * cantidad;
                TotalRefaccionTextBox.Text = AppHelper.N2(totalrefaccion);
            }
            catch { }           
        }

        private void ClearRefaccion()
        {            
            this.CodigoRefaccionTextBox.Text = string.Empty;
            this.NombreRefaccionTextBox.Text = string.Empty;
            this.CostoUnitarioTextBox.Text = string.Empty;
            this.CantidadNumericUpDown.Value = 1;
            this.TotalRefaccionTextBox.Text = string.Empty;
            this.CodigoRefaccionTextBox.Text = string.Empty;
            this.NombreRefaccionTextBox.Text = string.Empty;
            this.Refaccion = null;
            this.CodigoRefaccionTextBox.Focus();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0, iva = 0, total = 0;
            int cantidad = 0;
            foreach (Entities.Compras compra in OrdenCompra.Compras)
            {
                subtotal += compra.CostoUnitario * compra.Cantidad;
                cantidad += compra.Cantidad;
            }

            iva = subtotal * (decimal)0.16;
            total = subtotal + iva;

            OrdenCompra.Subtotal = subtotal;
            OrdenCompra.IVA = iva;
            OrdenCompra.Total = total;

            CantidadRefaccionesTextBox.Text = cantidad.ToString();
            SubTotalTextBox.Text = AppHelper.N2(OrdenCompra.Subtotal);
            IVATextBox.Text = AppHelper.N2(OrdenCompra.IVA);
            TotalTextBox.Text = AppHelper.N2(OrdenCompra.Total);
        }

        private void RemoverCompra(Entities.Compras compra)
        {
            comprasBindingSource.DataSource = null;
            OrdenCompra.Compras.Remove(compra);
            comprasBindingSource.DataSource = OrdenCompra.Compras;
            CalcularTotales();
        }

        private void InsertOrden()
        {
            OrdenCompra.Empresa_ID = Sesion.Empresa_ID.Value;
            OrdenCompra.Estacion_ID = Sesion.Estacion_ID.Value;
            OrdenCompra.EstatusOrdenCompra_ID = 1;
            OrdenCompra.Factura = " ";
            OrdenCompra.Usuario_ID = Sesion.Usuario_ID;
            OrdenCompra.Fecha = DB.GetDate();
            OrdenCompra.Create();
            int i = 0;
            for (i = 0; i < OrdenCompra.Compras.Count; i++)
            {
                OrdenCompra.Compras[i].OrdenCompra_ID = OrdenCompra.OrdenCompra_ID;
                OrdenCompra.Compras[i].Fecha = OrdenCompra.Fecha;
                OrdenCompra.Compras[i].Empresa_ID = OrdenCompra.Empresa_ID;
                OrdenCompra.Compras[i].Estacion_ID = OrdenCompra.Estacion_ID;
                OrdenCompra.Compras[i].Create();
            }
        }

        private void Clear()
        {
            OrdenCompra = new Entities.OrdenesCompras();
            comprasBindingSource.DataSource = null;
            AppHelper.ClearControl(this);
            this.CodigoProveedorTextBox.Focus();
            this.FacturaTextBox.Text = "N/A";
        }

        private void DisplayReport()
        {
            
        }

        #endregion

        #region Events (View Events)
        private void CodigoProveedorTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    BuscarProveedorPorID();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void CodigoRefaccionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    BuscarRefaccionPorCodigo();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }        

        private void AgregarAOrdenButton_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarRefaccion();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }        

        private void RefaccionesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].Name == "Cancelar")
                {
                    Entities.Compras compra = (Entities.Compras)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;
                    RemoverCompra(compra);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }        

        private void RegistrarOrdenButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate {
                    InsertOrden();
                    //Impresion();
                    AppHelper.Info("Orden de compra capturada");
                    Clear();
                }, 
                this
            );
        }
       
        private void BuscarProveedorButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBusquedaProveedor();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BuscarRefaccionButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBusquedaRefaccion();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotalRefaccion();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
        
        private void CostoUnitarioTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalcularTotalRefaccion();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
        #endregion

        #region "Impresion"


        public void DibujaDocumentoReimpresion(System.Drawing.Printing.PrintPageEventArgs e)
        {            
            Font _Fuente8 = new Font("Arial", 8);
            Font _Fuente10 = new Font("Arial", 10);
            Font _Fuente12 = new Font("Arial", 12);
            Font _Fuente10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font _Fuente12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font _Fuente14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font _FuenteCodBar = new Font("Code 39", 12);

            Bitmap img = new Bitmap(global::SICASv20.Properties.Resources.CSC, 114, 73);

            var _with1 = e.Graphics;

            float x1 = 0;
            float y = 0;
            float x2 = 0;
            float x3 = 0;
            float x4 = 0;
            float x5 = 0;
            y = 10;
            x1 = 10;
            x2 = 300;
            x3 = 475;
            x4 = 550;
            x5 = 625;

            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawImage(img, x1 + 1, y + 1);
            _with1.DrawLine(Pens.Black, x1, y + 105, 700, y + 105);

            _with1.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with1.DrawString("ORDEN DE COMPRA", _Fuente12Bold, Brushes.Black, 350, y + 50);
            _with1.DrawString("FOLIO: " + Convert.ToString(OrdenCompra.OrdenCompra_ID), _Fuente12Bold, Brushes.Black, 380, y + 65);
            _with1.DrawString(Strings.Format(OrdenCompra.Fecha, "dd/MM/yyyy"), _Fuente10, Brushes.Black, 350, y + 80);
            _with1.DrawString(Strings.Format(OrdenCompra.Fecha, "hh:mm"), _Fuente10, Brushes.Black, 450, y + 80);


            _with1.DrawString("PROVEEDOR:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with1.DrawString(Entities.Empresas.Read(OrdenCompra.Proveedor_ID).RazonSocial.ToUpper(), _Fuente10, Brushes.Black, x2, y + 130);
            _with1.DrawString("FACTURA DE PROVEEDOR:", _Fuente10Bold, Brushes.Black, x1, y + 145);
            _with1.DrawString(OrdenCompra.Factura, _Fuente10, Brushes.Black, x2, y + 145);


            _with1.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);
            _with1.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 161);
            _with1.DrawString("MARCA", _Fuente10, Brushes.Black, x2, y + 161);
            _with1.DrawString("COSTO", _Fuente10, Brushes.Black, x3, y + 161);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x4, y + 161);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x5, y + 161);
            _with1.DrawLine(Pens.Black, x1, y + 175, 700, y + 175);

            y = y + 176;
            foreach (Entities.Compras compra in OrdenCompra.Compras)
            {
                _with1.DrawString(Strings.UCase(compra.Refaccion_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Entities.MarcasRefacciones.Read(compra.MarcaRefaccion_ID).Nombre.ToUpper(), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(compra.CostoUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(string.Format("{0:N}", compra.Cantidad), _Fuente10, Brushes.Black, x4, y);
                _with1.DrawString(Strings.Format(compra.CostoUnitario * compra.Cantidad, "$ #,###.00"), _Fuente10, Brushes.Black, x5, y);
                y += 15;
            }

            _with1.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with1.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 150, y + 16);
            _with1.DrawString(Strings.Format(OrdenCompra.Subtotal, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 16);

            _with1.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 150, y + 31);
            _with1.DrawString(Strings.Format(OrdenCompra.IVA, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 31);

            _with1.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 150, y + 46);
            _with1.DrawString(Strings.Format(OrdenCompra.Total, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 46);

            _with1.DrawString("_________________________________________", _Fuente10, Brushes.Black, x2 + 150, y + 100);
            _with1.DrawString("JEFE ALMACEN", _Fuente10, Brushes.Black, x2 + 150, y + 120);

        }


        public void DibujaDocumento(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font _Fuente8 = new Font("Arial", 8);
            Font _Fuente10 = new Font("Arial", 10);
            Font _Fuente12 = new Font("Arial", 12);
            Font _Fuente10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font _Fuente12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font _Fuente14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font _FuenteCodBar = new Font("Code 39", 12);

            Bitmap img = new Bitmap(global::SICASv20.Properties.Resources.CSC, 114, 73);

            var _with2 = e.Graphics;

            float x1 = 0;
            float y = 0;
            float x2 = 0;
            float x3 = 0;
            float x4 = 0;
            float x5 = 0;
            y = 10;
            x1 = 10;
            x2 = 300;
            x3 = 475;
            x4 = 550;
            x5 = 625;

            _with2.DrawLine(Pens.Black, x1, y, 700, y);
            _with2.DrawImage(img, x1 + 1, y + 1);
            _with2.DrawLine(Pens.Black, x1, y + 105, 700, y + 105);

            _with2.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with2.DrawString("ORDEN DE COMPRA", _Fuente12Bold, Brushes.Black, 350, y + 50);
            _with2.DrawString("FOLIO: " + Convert.ToString(OrdenCompra.OrdenCompra_ID), _Fuente12Bold, Brushes.Black, 380, y + 65);
            _with2.DrawString(DateAndTime.Now.ToShortDateString(), _Fuente10, Brushes.Black, 350, y + 80);
            _with2.DrawString(DateAndTime.Now.ToShortTimeString(), _Fuente10, Brushes.Black, 450, y + 80);


            _with2.DrawString("PROVEEDOR:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with2.DrawString(Entities.Empresas.Read(OrdenCompra.Proveedor_ID).RazonSocial.ToUpper(), _Fuente10, Brushes.Black, x2, y + 130);
            //// .DrawString("FACTURA DE PROVEEDOR:", _Fuente10Bold, Brushes.Black, x1, y + 145)
            //// .DrawString(Me.txtFactura.Text, _Fuente10, Brushes.Black, x2, y + 145)


            _with2.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);
            _with2.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 161);
            _with2.DrawString("MARCA", _Fuente10, Brushes.Black, x2, y + 161);
            _with2.DrawString("COSTO", _Fuente10, Brushes.Black, x3, y + 161);
            _with2.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x4, y + 161);
            _with2.DrawString("TOTAL", _Fuente10, Brushes.Black, x5, y + 161);
            _with2.DrawLine(Pens.Black, x1, y + 175, 700, y + 175);

            y = y + 176;
            foreach (Entities.Compras compra in OrdenCompra.Compras)
            {
                _with2.DrawString(Strings.UCase(compra.Refaccion_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with2.DrawString(Entities.MarcasRefacciones.Read(compra.MarcaRefaccion_ID).Nombre.ToUpper(), _Fuente10, Brushes.Black, x2, y);
                _with2.DrawString(Strings.Format(compra.CostoUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with2.DrawString(Strings.Format(compra.Cantidad, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                _with2.DrawString(Strings.Format(compra.Cantidad * compra.CostoUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x5, y);
                y += 15;
            }

            _with2.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with2.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 150, y + 16);
            _with2.DrawString(Strings.Format(OrdenCompra.Subtotal, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 16);

            _with2.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 150, y + 31);
            _with2.DrawString(Strings.Format(OrdenCompra.IVA, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 31);

            _with2.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 150, y + 46);
            _with2.DrawString(Strings.Format(OrdenCompra.Total, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x5, y + 46);

            _with2.DrawString("_________________________________________", _Fuente10, Brushes.Black, x2 + 150, y + 100);
            _with2.DrawString("JEFE ALMACEN", _Fuente10, Brushes.Black, x2 + 150, y + 120);

        }


        public void VistaPrevia()
        {            
            try
            {
                System.Drawing.Printing.PrintDocument printDocReimpresion = new System.Drawing.Printing.PrintDocument();
                printDocReimpresion.PrintPage += PrintDocReimpresion_PrintPage;
                printDocReimpresion.Print();
                printDocReimpresion.Print();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        public void Impresion()
        {

            try
            {
                System.Drawing.Printing.PrintDocument printDocReimpresion = new System.Drawing.Printing.PrintDocument();
                printDocReimpresion.PrintPage += PrintDocReimpresion_PrintPage;
                printDocReimpresion.Print();
                printDocReimpresion.Print();

            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }

        }

        private void PrintDocReimpresion_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DibujaDocumentoReimpresion(e);
        }

        private void PrintDoc_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DibujaDocumento(e);
        }

        #endregion

    } // End Class
} // End Namespace
