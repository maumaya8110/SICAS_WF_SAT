using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario utilizado para registrar ventas comisionadas
	/// Una venta comisionada es aquella que paga una comisión a un tercero
	/// por concepto de promoción
	/// </summary>
	public partial class VentaComisionada : baseForm
	{
		#region Properties

		/// <summary>
		/// Estructura del servicio a vender
		/// </summary>
		Entities.Servicios Servicio;

		/// <summary>
		/// Listado de comisiones pagadas por el servicio
		/// </summary>
		List<Entities.Servicios_Comisiones> Comisiones;

		/// <summary>
		/// Contrato del conductor que realiza el servicio
		/// </summary>
		Entities.Contratos Contrato;

		/// <summary>
		/// El concepto de comision de regresos
		/// </summary>
		private const int COMISIONREGRESOS_ID = 18;

		/// <summary>
		/// El concepto de comisión PRONATURA
		/// </summary>
		private const int COMISIONPRONATURA_ID = 38;

		/// <summary>
		/// La cantidad de servicios a vender
		/// </summary>
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}
		private int _Cantidad;

		#endregion

		#region Constructors

		/// <summary>
		/// Crea una nueva instancia del formulario para registrar
		/// ventas comisionadas
		/// </summary>
		public VentaComisionada()
		{
			InitializeComponent();
			AppHelper.AddTextBoxOnlyNumbersValidation(ref this.CantidadTextBox);
		}

		#endregion

		/// <summary>
		/// Liga los datos a la base de datos
		/// </summary>
		public override void BindData()
		{
			//  Instanciamos el servicio
			Servicio = new Entities.Servicios();

			//  Obtenemos los tipos de servicio
			this.tiposServiciosBindingSource.DataSource = Entities.TiposServicios.Read();

			//  Obtenemos las monedas
			this.monedasBindingSource.DataSource = Entities.Monedas.Read();

			//  Obtenemos las zonas
			this.zonasBindingSource.DataSource = Entities.Zonas.Read("ComisionServicio_ID IS NOT NULL AND Zona_ID IN (SELECT Zona_ID FROM Tarifas)", null, null);

			//  Configuramos el tipo de servicio
			SelectTipoServicio();

			//  Configuramos la moneda
			SelectMoneda();
			base.BindData();
		}

		// Metodos
		#region Metodos

		/// <summary>
		/// Selecciona el tipo de servicio del control y lo
		/// almacena en la estructura
		/// </summary>
		private void SelectTipoServicio()
		{
			if (!AppHelper.IsNullOrEmpty(TiposServiciosComboBox.SelectedItem))
			{
				Servicio.TipoServicio_ID = ((Entities.TiposServicios)TiposServiciosComboBox.SelectedItem).TipoServicio_ID;
			}
		}

		/// <summary>
		/// Selecciona la moneda con que se paga el servicio
		/// y la almacena en la estructura del servicio
		/// </summary>
		private void SelectMoneda()
		{
			if (!AppHelper.IsNullOrEmpty(MonedasComboBox.SelectedItem))
			{
				Entities.Monedas m = (Entities.Monedas)MonedasComboBox.SelectedItem;
				Servicio.Moneda_ID = m.Moneda_ID;
				lblCtaBanco.Visible = false;
				txtCtaBanco.Visible = false;
				txtCtaBanco.Clear();
				if (m.TipoTarjeta_ID > 0)
				{
					lblCtaBanco.Visible = true;
					txtCtaBanco.Visible = true;
					txtCtaBanco.Focus();
				}
			}
		}

		/// <summary>
		/// Selecciona la zona, obtiene el precio, actualiza el servicio y
		/// los controles de la interfaz de usuario
		/// </summary>
		private void SelectZona()
		{
			if (!AppHelper.IsNullOrEmpty(ZonasComboBox.SelectedItem))
			{
				Entities.Zonas zona = (Entities.Zonas)ZonasComboBox.SelectedItem;
				Servicio.Zona_ID = zona.Zona_ID;
				GetPrecio();
				PrecioTextBox.Text = AppHelper.N2(Servicio.Precio);
			}
		}

		/// <summary>
		/// Obtiene los datos del conductor a partir del número económico de la unidad
		/// </summary>
		private void GetDatosConductorUnidad()
		{
			//  Obtenemos el número económico del control
			int numeroeconomico = DB.GetNullableInt32(NumeroEconomicoTextBox.Text).Value;

			//  Obtenemos el contrato
			this.Contrato =
			    Entities.Contratos.Read(
				   DB.Param("EstatusContrato_ID", 1),
					  DB.Param("NumeroEconomico", numeroeconomico),
						 DB.Param("Empresa_ID", Sesion.Empresa_ID),
							DB.Param("Estacion_ID", Sesion.Estacion_ID));

			//  Si no hay contrato, mandamos excepcion
			if (Contrato == null) throw new Exception(string.Format("La unidad {0} no tiene contrato activo", numeroeconomico));

			//  Configuramos conductor y unidad
			Servicio.Conductor_ID = Contrato.Conductor_ID;
			Servicio.Unidad_ID = Contrato.Unidad_ID;

			//  Obtenemos al conductor
			Entities.Conductores conductor = Entities.Conductores.Read(Contrato.Conductor_ID);

			//  Si no hay conductor, mandamos excepción
			if (conductor == null) throw new Exception(string.Format("No existe el conductor especificado para la unidad {0}", numeroeconomico));

			//  Actualizamos el nombre del conductor en la GUI
			this.ConductorTextBox.Text = conductor.Apellidos + " " + conductor.Nombre;
		}

		/// <summary>
		/// Asigna las comisiones correspondientes al servicio a partir de la configuración por zona
		/// </summary>
		private void GetComisiones()
		{
			//  Instanciamos el listado
			Comisiones = new List<Entities.Servicios_Comisiones>();

			//  Configuramos el pago a 0
			Servicio.PagoComisiones = 0;

			//  Configuramos el pago al conductor como el precio total del boleto
			Servicio.PagoConductor = Servicio.Precio;

			//  Obtenemos la zona
			Entities.Zonas zona = Entities.Zonas.Read((int)Servicio.Zona_ID);

			//  Si es comisionada
			if (!AppHelper.IsNullOrEmpty(zona.ComisionServicio_ID))
			{
				//  Obtenemos la comisión
				Entities.ComisionesServicios comisionServicio = Entities.ComisionesServicios.Read((int)zona.ComisionServicio_ID);

				//  Calcular comision
				CalcularComision(comisionServicio);
			}

			//  Calculamos Comision pronatura
			Entities.ComisionesServicios comisionPronatura =
			    Entities.ComisionesServicios.Read(COMISIONPRONATURA_ID);
			CalcularComision(comisionPronatura);
		}

		/// <summary>
		/// Calcula la comisión del servicio, a partir de un objeto ComisionesServicios
		/// </summary>
		/// <param name="comisionServicio">El objeto <remarks>ComisionesServicio</remarks> a calcularle comisión</param>
		private void CalcularComision(Entities.ComisionesServicios comisionServicio)
		{
			//  Inicializamos la comisión en cero
			decimal comision = 0;

			//  Si la comisión es de tipo 1
			if (comisionServicio.TipoComision_ID == 1)
			{
				//  Es absoluto
				//  La comisión es el monto
				comision = comisionServicio.Monto;
			}
			else if (comisionServicio.TipoComision_ID == 2) // Si la comisión es de tipo 2
			{
				//  Es porcentaje
				//  Lo calculamos
				comision = Servicio.Precio * (comisionServicio.Monto / (decimal)100);
			}

			//  Incrementamos el pago de comisiones
			Servicio.PagoComisiones += comision;

			//  Disminuimos el pago del conductor
			Servicio.PagoConductor = Servicio.Precio - Servicio.PagoComisiones;

			//  Ingresamos la comisión calculada al listado
			Comisiones.Add(new Entities.Servicios_Comisiones(
									  Servicio.Servicio_ID, comisionServicio.ComisionServicio_ID, Servicio.Ticket_ID, comision));
		}

		/// <summary>
		/// Obtiene la productividad del servicio
		/// </summary>
		private void GetProductividad()
		{
			//  Tipo servicio conductor
			if (!AppHelper.IsNullOrEmpty(Servicio.TipoServicioConductor_ID))
			{
				Entities.TiposServiciosConductores tipoServicioConductor = Entities.TiposServiciosConductores.Read((int)Servicio.TipoServicioConductor_ID);
				//  Verificar si es valido como carrera
				//  Si es, productividad = 1
				if (tipoServicioConductor.EsValidoCarrera)
				{
					Servicio.Productividad = 1;
				}
			}
			else
			{
				//  Tipo de Zona
				Entities.Zonas zona = Entities.Zonas.Read((int)Servicio.Zona_ID);
				Entities.TiposZonas tipoZona = Entities.TiposZonas.Read(zona.TipoZona_ID);

				if (tipoZona.EsAcreditable)
				{
					//  Obtener la base de acreditación
					decimal baseAcreditación = Convert.ToDecimal(Entities.VariablesNegocio.Read("BaseAcreditacion").Valor);

					//  Dividir el precio entre la misma
					decimal productividad = Servicio.Precio / baseAcreditación;

					//  Si es menor que 1, entonces 1
					if (productividad < 0) productividad = 1;

					//  Caso contrario, el cociente es la productividad
					Servicio.Productividad = productividad;
				}
				else
				{
					Servicio.Productividad = 1;
				}
			}
		}

		/// <summary>
		/// Obtiene el precio de la tarida, a partir de la zona y tipo de servicio
		/// </summary>
		private void GetPrecio()
		{
			try
			{
				Servicio.Precio = Entities.PrecioServicio.Get((int)Servicio.Zona_ID, Servicio.TipoServicio_ID, true).Precio;
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Valida los datos de entrada en los controles
		/// </summary>
		private void DoValidate()
		{
			if (txtCtaBanco.Visible && txtCtaBanco.Text.Trim().Length != 4)
			{
				throw new Exception("El método de pago requiere la captura de los últimos 4 digitos de la Tarjeta usada para el pago.");
			}

			AppHelper.ValidateControl(this.CantidadTextBox, AppHelper.ValidateRule.Required);
			this.Cantidad = Convert.ToInt32(this.CantidadTextBox.Text);
			// Obtener las comisiones
		}

		/// <summary>
		/// Obtiene la cuenta a la cual se cargará el servicio a partir  del tipo de servicio
		/// </summary>
		private void GetCuenta()
		{
			Entities.TiposServicios tipoServicio = Entities.TiposServicios.Read((int)Servicio.TipoServicio_ID);
			Servicio.Cuenta_ID = (int)tipoServicio.Cuenta_ID;
		}

		/// <summary>
		/// Ingresa los datos a la base de datos
		/// </summary>
		private void DoInsert()
		{
			//  Obtenemos la productividad
			GetProductividad();

			//  Obtenemos la cuenta
			GetCuenta();

			//  Configuramos los datos
			Servicio.Caja_ID = Sesion.Caja_ID;
			Servicio.ClaseServicio_ID = 2; // Ciudad aeropuerto
			Servicio.Cliente_ID = null;
			Servicio.Empresa_ID = Sesion.Empresa_ID.Value;
			Servicio.Estacion_ID = Sesion.Estacion_ID;
			Servicio.EstatusServicio_ID = 2; // Venta + Asignacion
			Servicio.Fecha = DB.GetDate();
			Servicio.FechaExpiracion = null;
			Servicio.FechaPago = null;
			Servicio.FechaServicio = Servicio.Fecha;
			Servicio.FolioDiario = Entities.Servicios.GetFolioDiario();
			Servicio.Mercado_ID = 2; // Aeropuerto                                    
			Servicio.Servicio_ID = Entities.Servicios.GenerarCodigoVenta(this.Servicio.FolioDiario);
			Servicio.Sesion_ID = Sesion.Sesion_ID;
			Servicio.Ticket_ID = null;
			Servicio.TipoVenta_ID = GetTipoVenta();
			Servicio.TipoServicioConductor_ID = null; // venta directa es de tipo cliente
			Servicio.Usuario_ID = Sesion.Usuario_ID;
			Servicio.CtaBanco = txtCtaBanco.Text.Trim();

			//  Obtenemos las comisiones
			GetComisiones();

			//  Creamos el servicio en la base de datos
			Servicio.Create();

			//  Ingresamos las comisiones
			foreach (Entities.Servicios_Comisiones sc in Comisiones)
			{
				sc.Create();
			}
		}

		/// <summary>
		/// El tipo de venta siempre es 1
		/// </summary>
		/// <returns></returns>
		private int? GetTipoVenta()
		{
			return 1;
		}

		#region Impresion

		/*
         * Esta region contiene las variables y métodos para imprimir
         * los boletos de servicios de transportación terrestre
         * 
         * Los boletos son dibujados mediante objetos Graphics
         * e impresos copiandolos directamente al puerto de impresión
         */

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
		/// La clase entidad para contener las variables del boleto a imprimir
		/// </summary>
		private Entities.BoletoVenta Boleto;

		/// <summary>
		/// El puerto de impresión al que se copiaran los archivos
		/// </summary>
		//string PuertoImpresion = @"LPT1";

		/// <summary>
		/// Regresa la ruta al directorio actual
		/// </summary>
		/// <returns></returns>
		private string CurDir()
		{
			return System.Environment.CurrentDirectory;
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
			_with1.DrawString("Conductor:", vFuente3, Brushes.Black, 10, 135);
			_with1.DrawString(Boleto.Conductor, vFuente2, Brushes.Black, 85, 135);
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
			_with1.DrawString("Conductor:", vFuente3, Brushes.Black, 10, 135);
			_with1.DrawString(Boleto.Conductor, vFuente2, Brushes.Black, 85, 135);
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

			Bitmap catlogo = new Bitmap(CurDir() + "\\images\\catlogo.gif");

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
			_with1.DrawString("Unidad:", vFuente3, Brushes.Black, 10, 160);
			_with1.DrawString(Boleto.Unidad.ToString(), vFuente2, Brushes.Black, 65, 160);
			_with1.DrawString("Boleto:", vFuente3, Brushes.Black, 10, 175);
			_with1.DrawString(Boleto.Servicio_ID, vFuente3, Brushes.Black, 65, 175);


			_with1.DrawString(Boleto.RazonSocial, vFuente3, Brushes.Black, 10, 200);
			_with1.DrawString(Boleto.RFC, vFuente3, Brushes.Black, 10, 215);
			_with1.DrawString(Boleto.Domicilio, vFuente3, Brushes.Black, 10, 230);
			_with1.DrawString("C.P.:" + Boleto.CodigoPostal, vFuente3, Brushes.Black, 10, 245);
			_with1.DrawString("Tel:" + Boleto.Telefono1, vFuente3, Brushes.Black, 10, 260);

			_with1.DrawString(Boleto.LeyendaFiscal, vFuente4, Brushes.Black, new RectangleF(10, 310, 290, 55));

		}

		#endregion

		/// <summary>
		/// Manda a imprimir el boleto
		/// </summary>
		private void DoPrint()
		{
			//  Obtenemos los datos del boleto
			this.Boleto = Entities.BoletoVenta.Get(Servicio.Servicio_ID);

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
		/// Limpia la forma, y reinicializa las variables
		/// </summary>
		private void DoClear()
		{
			AppHelper.ClearControl(this);
			Servicio = new Entities.Servicios();
			Servicio.Zona_ID = DB.GetNullableInt32(this.ZonasComboBox.SelectedValue);
			Servicio.TipoServicio_ID = DB.GetNullableInt32(this.TiposServiciosComboBox.SelectedValue);
			Servicio.Moneda_ID = Convert.ToInt32(this.MonedasComboBox.SelectedValue);
			txtCtaBanco.Clear();
			txtCtaBanco.Visible = false;
		}

		/// <summary>
		/// Registra la venta en la base de datos y envia la impresión
		/// </summary>
		private void DoSave()
		{
			//  Validamos la venta
			DoValidate();

			//  Generamos la cantidad de boletos
			//  especificada
			int i = 0;
			for (i = 0; i < this.Cantidad; i++)
			{
				DoInsert();
			}

			//  Realizamos la impresión
			DoPrint();

			//  Limpiamos la forma
			DoClear();
		}

		#endregion

		#region Eventos

		/// <summary>
		/// Al presionar "Enter" en la caja de texto "Numero Economico",
		/// consulta los datos de la unidad, a partir del número economico
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				AppHelper.DoMethod(GetDatosConductorUnidad, this);
			}
		}

		/// <summary>
		/// Selecciona el valor del tipo de servicio
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TiposServiciosComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			AppHelper.Try(delegate { SelectTipoServicio(); });
		}

		/// <summary>
		/// Selecciona la moneda (tipo de pago) con la que se pagará el boleto
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MonedasComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			AppHelper.Try(delegate { SelectMoneda(); });
		}

		/// <summary>
		/// Al hacer clic en "Aceptar", se realiza la venta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AceptarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
		}

		/// <summary>
		/// Selecciona la zona del servicio a vender
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ZonasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				SelectZona();
			}
			catch (Exception ex)
			{
				this.PrecioTextBox.Text = "0";
				this.Servicio.Precio = 0;
				AppHelper.Error(ex.Message);
			}
		}

		#endregion

	} // End Class
} // End Namespace
