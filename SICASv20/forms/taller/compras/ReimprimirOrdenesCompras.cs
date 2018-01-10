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
    public partial class ReimprimirOrdenesCompras : baseForm
    {
        public ReimprimirOrdenesCompras()
        {
            InitializeComponent();
        }

        private ReimprimirOrdenesCompras_Model Model;
        private Entities.OrdenesCompras _OrdenCompra;
        public Entities.OrdenesCompras OrdenCompra
        {
            get { return _OrdenCompra; }
            set { _OrdenCompra = value; }
        }

        class ReimprimirOrdenesCompras_Model
        {
            private Entities.OrdenesCompras _OrdenCompra;
            public Entities.OrdenesCompras OrdenCompra
            {
                get { return _OrdenCompra; }
                set { _OrdenCompra = value; }
            }

            public void Consultar(int ordencompra_id)
            {
                this.OrdenCompra = Entities.OrdenesCompras.Read(ordencompra_id);
                this.OrdenCompra.LoadRelations();
            }
        }        

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
                printDocReimpresion.DocumentName = string.Format("OrdenCompra_{0}", this.OrdenCompra.OrdenCompra_ID);
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

        public override void BindData()
        {
            this.Model = new ReimprimirOrdenesCompras_Model();
            base.BindData();
        }

        private void OrdenCompra_ID_TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        if (string.IsNullOrEmpty(this.OrdenCompra_ID_TextBox.Text))
                        {
                            throw new Exception("Debe capturar un folio de orden de compra");
                        }

                        this.Model.Consultar(Convert.ToInt32(this.OrdenCompra_ID_TextBox.Text));
                        this.OrdenCompra = this.Model.OrdenCompra;
                        this.Impresion();
                    }
                }
            );
        }
    }
}
