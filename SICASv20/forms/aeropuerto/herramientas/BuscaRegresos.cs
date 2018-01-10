using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SICASv20.forms.aeropuerto.herramientas
{
	public partial class BuscaRegresos : baseForm
	{

		/// <summary>
		/// El documento de impresión para imprimir la tercera copia del boleto
		/// </summary>
		private PrintDocument PrintDoc3;

		/// <summary>
		/// El documento de impresión para imprimir la segunda copia del boleto
		/// </summary>
		private PrintDocument PrintDoc2;

		/// <summary>
		/// El documento de impresión para imprimir la primera copia del boleto
		/// </summary>
		private PrintDocument PrintDoc;

		/// <summary>
		/// Regresa la ruta al directorio actual
		/// </summary>
		/// <returns></returns>
		private string CurDir()
		{
			return System.Environment.CurrentDirectory;
		}

		private Entities.BoletoVenta Boleto;

		public BuscaRegresos()
		{
			InitializeComponent();
			cmbZona.DataSource = Entities.Zonas.Read();
			cmbZona.DisplayMember = "Nombre";
			cmbZona.ValueMember = "Zona_ID";
			txtFolio.Focus();
		}

		private void chkFolio_Click(object sender, EventArgs e)
		{
			txtFolio.Enabled = chkFolio.Checked;
			if (txtFolio.Enabled) txtFolio.Focus();
		}

		private void chkFecha_Click(object sender, EventArgs e)
		{
			dteFecha.Enabled = chkFecha.Checked;
			if (dteFecha.Enabled) dteFecha.Focus();
		}

		private void chkZona_Click(object sender, EventArgs e)
		{
			cmbZona.Enabled = chkZona.Checked;
			if (cmbZona.Enabled) cmbZona.Focus();
		}

		private void checkBox4_Click(object sender, EventArgs e)
		{
			txtPrecio.Enabled = chkPrecio.Checked;
			if (txtPrecio.Enabled) txtPrecio.Focus();
		}

		private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnBuscar_Click(null, null);
			}
			if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
			{
				e.Handled = true;
				return;
			}
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			AppHelper.Try(DoQuery);
		}

		private void DoQuery()
		{
			DoValidate();
			DoGetInformacion();
		}

		private void DoValidate()
		{
			if (!chkFolio.Checked && !chkFecha.Checked && !chkZona.Checked && !chkPrecio.Checked)
			{ throw new Exception("Debe seleccionar un parámetro para la consulta."); }
			if (!chkFolio.Checked && !chkFecha.Checked && !chkZona.Checked && chkPrecio.Checked)
			{ throw new Exception("No puede consultar solo por precio, seleccione un parámetro adicional."); }
			if (!chkFolio.Checked && !chkFecha.Checked && chkZona.Checked && !chkPrecio.Checked)
			{ throw new Exception("No puede consultar solo por zona, seleccione un parámetro adicional."); }
			if (chkFolio.Checked && txtFolio.Text.Trim().Length == 0)
			{
				txtFolio.Focus();
				throw new Exception("Es necesario introducir todo o parte del número de boleto.");
			}
			if (chkPrecio.Checked && txtPrecio.Text.Trim().Length == 0)
			{
				txtPrecio.Focus(); 
				throw new Exception("Es necesario introducir el precio.");
			}
			if (chkFolio.Checked && !AppHelper.IsNumeric(txtFolio.Text))
			{
				txtFolio.Focus();
				throw new Exception("El Boleto debe ser un Número.");
			}
			if (chkPrecio.Checked && !AppHelper.IsNumeric(txtPrecio.Text))
			{
				txtPrecio.Focus();
				throw new Exception("El Precio debe ser un Número.");
			}
		}

		private void DoGetInformacion()
		{
			string folio = null;
			if (chkFolio.Checked) folio = txtFolio.Text.Trim();

			double? precio = null;
			if (chkPrecio.Checked) precio = Convert.ToInt32(txtPrecio.Text.Trim());

			int? zona_id = null;
			if (chkZona.Checked) zona_id = (int)cmbZona.SelectedValue;

			DateTime? fecha = null;
			if (chkFecha.Checked) fecha = dteFecha.Value;

			List<classes.Aeropuerto.RegresoVendido> lr = new List<classes.Aeropuerto.RegresoVendido>();
			lr = Entities.Vista_RegresosVendidos.BuscaRegresosVendidos(folio, fecha, zona_id, precio);
			
			bsRegresosVendidos.DataSource = lr;

			splitContainer1.Panel2.Controls.Clear();
			dgv = new DataGridView();
			dgv.AutoGenerateColumns = true;
			dgv.DataSource = lr;
			dgv.Dock = DockStyle.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.ReadOnly = true;
			dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
			splitContainer1.Panel2.Controls.Add(dgv);
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			AppHelper.Try(ImprimirBoletos);		
		}

		private void ImprimirBoletos()
		{
			DoValidateServicio();
			DoPrint();	
		}

		private void DoPrint()
		{
			string servicio_id = dgv.SelectedRows[0].Cells[0].Value.ToString();
			Entities.Servicios s = Entities.Servicios.Read(servicio_id);

			//  Obtenemos los datos del boleto
			Boleto = Entities.BoletoVenta.Get(s.Servicio_ID);

			//  Inicializamos los documentos
			PrintDoc = new PrintDocument();
			PrintDoc2 = new PrintDocument();
			PrintDoc3 = new PrintDocument();

			//  Connfiguramos la impresión
			PrintDoc.PrintPage += this.DibujaDocumento;
			PrintDoc2.PrintPage += this.DibujaDocumento2;
			PrintDoc3.PrintPage += this.DibujaDocumento3;

			//  Mandamos la impresión
			VistaPrevia();
		}

		/// <summary>
		/// Genera los documentos de impresión del boleto
		/// </summary>
		public void VistaPrevia()
		{

			this.PrintDoc3.DefaultPageSettings.Margins.Top = 0;
			this.PrintDoc3.DefaultPageSettings.Margins.Left = 0;
			this.PrintDoc3.DefaultPageSettings.Margins.Bottom = 0;
			this.PrintDoc3.DefaultPageSettings.Margins.Right = 0;
			//this.PrintDoc3.PrinterSettings.PrintFileName = CurDir() + "Archivo3.prn";
			//this.PrintDoc3.PrinterSettings.PrintToFile = true;
			this.PrintDoc3.Print();
			//File.Copy(CurDir() + "Archivo3.prn", PuertoImpresion);

			this.PrintDoc2.DefaultPageSettings.Margins.Top = 0;
			this.PrintDoc2.DefaultPageSettings.Margins.Left = 0;
			this.PrintDoc2.DefaultPageSettings.Margins.Bottom = 0;
			this.PrintDoc2.DefaultPageSettings.Margins.Right = 0;
			//this.PrintDoc2.PrinterSettings.PrintFileName = CurDir() + "Archivo2.prn";
			//this.PrintDoc2.PrinterSettings.PrintToFile = true;
			this.PrintDoc2.Print();
			//File.Copy(CurDir() + "Archivo2.prn", PuertoImpresion);

			this.PrintDoc.DefaultPageSettings.Margins.Top = 0;
			this.PrintDoc.DefaultPageSettings.Margins.Left = 0;
			this.PrintDoc.DefaultPageSettings.Margins.Bottom = 0;
			this.PrintDoc.DefaultPageSettings.Margins.Right = 0;
			//this.PrintDoc.PrinterSettings.PrintFileName = CurDir() + "Archivo.prn";
			//this.PrintDoc.PrinterSettings.PrintToFile = true;
			this.PrintDoc.Print();
			//File.Copy(CurDir() + "Archivo.prn", PuertoImpresion);
		}

		/// <summary>
		/// Dibuja la primer copia del boleto
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void DibujaDocumento(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{

			Font vFuente = new Font("Times New Roman", 7);
			Font vFuente2 = new Font("Microsoft Sans Serif", 9);
			Font vFuente3 = new Font("Microsoft Sans Serif", 9);
			Font vFuente4 = new Font("Arial", 14, FontStyle.Bold);

			System.DateTime vigencia = default(System.DateTime);
			vigencia = Convert.ToDateTime(Boleto.Fecha);
			vigencia = vigencia.AddYears(1);

			System.Drawing.Bitmap bmp = new Bitmap(GenCode128.Code128Rendering.MakeBarcodeImage(Boleto.Servicio_ID, 2, true));

			var _with1 = e.Graphics;

			_with1.DrawLine(Pens.Black, 65, 43, 250, 43);
			_with1.DrawLine(Pens.Black, 65, 58, 250, 58);
			_with1.DrawLine(Pens.Black, 65, 73, 250, 73);
			_with1.DrawLine(Pens.Black, 65, 88, 250, 88);
			_with1.DrawLine(Pens.Black, 65, 103, 250, 103);
			_with1.DrawLine(Pens.Black, 65, 118, 250, 118);

			_with1.DrawString(":: COPIA DE CAJA ::", vFuente4, Brushes.Black, 1, 5);
			_with1.DrawString("Folio:", vFuente3, Brushes.Black, 10, 30);
			_with1.DrawString(Boleto.FolioDiario.ToString(), vFuente2, Brushes.Black, 65, 30);
			_with1.DrawString("Fecha:", vFuente3, Brushes.Black, 10, 45);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", Boleto.Fecha), vFuente2, Brushes.Black, 65, 45);
			_with1.DrawString("Tipo:", vFuente3, Brushes.Black, 10, 60);
			_with1.DrawString("Ciudad - Aeropuerto", vFuente2, Brushes.Black, 65, 60);
			_with1.DrawString("Zona:", vFuente3, Brushes.Black, 10, 75);
			_with1.DrawString(Boleto.Zona.ToString(), vFuente2, Brushes.Black, 65, 75);
			_with1.DrawString("Vigencia:", vFuente3, Brushes.Black, 10, 90);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", vigencia), vFuente2, Brushes.Black, 65, 90);
			_with1.DrawString("Valor:", vFuente3, Brushes.Black, 10, 105);
			_with1.DrawString(String.Format("{0:c}", Boleto.Precio), vFuente2, Brushes.Black, 65, 105);
			_with1.DrawString("Unidad:", vFuente3, Brushes.Black, 10, 120);
			_with1.DrawString(Boleto.Unidad.ToString(), vFuente2, Brushes.Black, 65, 120);
			_with1.DrawString("BOLETO DE REGRESO", vFuente3, Brushes.Black, 10, 135);
			_with1.DrawString(Boleto.Servicio_ID, vFuente3, Brushes.Black, 50, 150);
			_with1.DrawImage(bmp, 1, 170, 260, 30);
			_with1.DrawString("Conserve este boleto.", vFuente, Brushes.Black, 1, 220);
		}

		/// <summary>
		/// Dibuja la segunda copia del boleto
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="i"></param>
		public void DibujaDocumento2(object sender, System.Drawing.Printing.PrintPageEventArgs i)
		{

			Font vFuente = new Font("Times New Roman", 7);
			Font vFuente2 = new Font("Microsoft Sans Serif", 9);
			Font vFuente3 = new Font("Microsoft Sans Serif", 9);
			Font vFuente4 = new Font("Arial", 14, FontStyle.Bold);

			System.DateTime vigencia = default(System.DateTime);
			vigencia = Convert.ToDateTime(Boleto.Fecha);
			vigencia = vigencia.AddYears(1);


			System.Drawing.Bitmap bmp = new Bitmap(GenCode128.Code128Rendering.MakeBarcodeImage(Boleto.Servicio_ID, 2, true));

			var _with1 = i.Graphics;

			_with1.DrawLine(Pens.Black, 65, 43, 250, 43);
			_with1.DrawLine(Pens.Black, 65, 58, 250, 58);
			_with1.DrawLine(Pens.Black, 65, 73, 250, 73);
			_with1.DrawLine(Pens.Black, 65, 88, 250, 88);
			_with1.DrawLine(Pens.Black, 65, 103, 250, 103);
			_with1.DrawLine(Pens.Black, 65, 118, 250, 118);

			_with1.DrawString(":: COPIA DE CONDUCTOR ::", vFuente4, Brushes.Black, 1, 5);
			_with1.DrawString("Folio:", vFuente3, Brushes.Black, 10, 30);
			_with1.DrawString(Boleto.FolioDiario.ToString(), vFuente2, Brushes.Black, 65, 30);
			_with1.DrawString("Fecha:", vFuente3, Brushes.Black, 10, 45);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", Boleto.Fecha), vFuente2, Brushes.Black, 65, 45);
			_with1.DrawString("Tipo:", vFuente3, Brushes.Black, 10, 60);
			_with1.DrawString("Ciudad - Aeropuerto", vFuente2, Brushes.Black, 65, 60);
			_with1.DrawString("Zona:", vFuente3, Brushes.Black, 10, 75);
			_with1.DrawString(Boleto.Zona, vFuente2, Brushes.Black, 65, 75);
			_with1.DrawString("Vigencia:", vFuente3, Brushes.Black, 10, 90);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", vigencia), vFuente2, Brushes.Black, 65, 90);
			_with1.DrawString("Valor:", vFuente3, Brushes.Black, 10, 105);
			_with1.DrawString(String.Format("{0:c}", Boleto.Precio), vFuente2, Brushes.Black, 65, 105);
			_with1.DrawString("Unidad:", vFuente3, Brushes.Black, 10, 120);
			_with1.DrawString(Boleto.Unidad.ToString(), vFuente2, Brushes.Black, 65, 120);
			_with1.DrawString("BOLETO DE REGRESO", vFuente3, Brushes.Black, 10, 135);
			_with1.DrawString(Boleto.Servicio_ID, vFuente3, Brushes.Black, 50, 150);
			_with1.DrawImage(bmp, 1, 170, 260, 30);
			_with1.DrawString("Conserve este boleto.", vFuente, Brushes.Black, 1, 220);

		}

		/// <summary>
		/// Dibuja la tercer copia del boleto
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="j"></param>
		public void DibujaDocumento3(object sender, System.Drawing.Printing.PrintPageEventArgs j)
		{
			Font vFuente = new Font("Code 39", 12);
			Font vFuente2 = new Font("Arial", 9, FontStyle.Italic);
			Font vFuente3 = new Font("Arial", 9, FontStyle.Bold);
			Font vFuente4 = new Font("Times New Roman", 8);
			Font vFuente5 = new Font("Microsoft Sans Serif", 16, FontStyle.Bold & FontStyle.Italic);

			System.DateTime vigencia = default(System.DateTime);
			vigencia = Convert.ToDateTime(Boleto.Fecha);
			vigencia = vigencia.AddYears(1);


			var _with1 = j.Graphics;

			Bitmap catlogo = new Bitmap(Properties.Resources.catlogo);

			_with1.DrawImage(catlogo, 30, 1, 100, 40);
			_with1.DrawString("Reservaciones: ", vFuente4, Brushes.Black, 145, 10);
			_with1.DrawString("81.300.600", vFuente5, Brushes.Black, 135, 20);

			_with1.DrawString("Folio:", vFuente3, Brushes.Black, 10, 70);
			_with1.DrawString(Boleto.FolioDiario.ToString(), vFuente2, Brushes.Black, 65, 70);
			_with1.DrawString("Fecha:", vFuente3, Brushes.Black, 10, 85);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", Boleto.Fecha), vFuente2, Brushes.Black, 65, 85);
			_with1.DrawString("Tipo:", vFuente3, Brushes.Black, 10, 100);
			_with1.DrawString("Ciudad - Aeropuerto", vFuente2, Brushes.Black, 65, 100);
			_with1.DrawString("Zona:", vFuente3, Brushes.Black, 10, 115);
			_with1.DrawString(Boleto.Zona.ToUpper(), vFuente2, Brushes.Black, 65, 115);
			_with1.DrawString("Vigencia:", vFuente3, Brushes.Black, 10, 130);
			_with1.DrawString(String.Format("{0:yyyy-MM-dd}", vigencia), vFuente2, Brushes.Black, 65, 130);
			_with1.DrawString("Valor:", vFuente3, Brushes.Black, 10, 145);
			_with1.DrawString(String.Format("{0:c}", Boleto.Precio), vFuente2, Brushes.Black, 65, 145);
			_with1.DrawString("BOLETO DE REGRESO", vFuente3, Brushes.Black, 10, 160);
			_with1.DrawString("Boleto:", vFuente3, Brushes.Black, 10, 175);
			_with1.DrawString(Boleto.Servicio_ID, vFuente3, Brushes.Black, 65, 175);

			_with1.DrawString(Boleto.RazonSocial, vFuente3, Brushes.Black, 10, 200);
			_with1.DrawString(Boleto.RFC, vFuente3, Brushes.Black, 10, 215);
			_with1.DrawString(Boleto.Domicilio, vFuente3, Brushes.Black, 10, 230);
			_with1.DrawString("C.P.:" + Boleto.CodigoPostal, vFuente3, Brushes.Black, 10, 245);
			_with1.DrawString("Tel:" + Boleto.Telefono1, vFuente3, Brushes.Black, 10, 260);

			_with1.DrawString(Boleto.LeyendaRegresos, vFuente4, Brushes.Black, new RectangleF(10, 285, 280, 105));
			_with1.DrawString(Boleto.LeyendaFiscal, vFuente4, Brushes.Black, new RectangleF(10, 400, 290, 55));

		}

		private void DoValidateServicio()
		{
			if (dgv.Rows.Count <= 0)
			{
				throw new Exception("No hay servicios de regreso para imprimir.");
			}
			if (dgv.SelectedRows.Count <= 0)
			{ throw new Exception("Debe seleccionar una servicio para reimprimir el Ticket de Regreso."); }
			string estatus = dgv.SelectedRows[0].Cells[8].Value.ToString();
			if (estatus != "VENDIDO")
			{
				throw new Exception("El estatus del boleto no permite Re-impresión."+Environment.NewLine+"Solo se permiten boletos sin asignar y sin cancelar.");
			}
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgv.Columns[e.ColumnIndex].Name == "Estatus")
			{
				if (e.Value.ToString() != "VENDIDO")
				{
					dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
				}
				else { dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue; }
			}
		}

	}
}
