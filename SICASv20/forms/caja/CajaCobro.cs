/*
 * CajaCobro
 * 
 * Modificado el 18 de Octubre de 2012
 * por Luis Espino
 * 
 * Se modifió para eliminar el uso de Sesion.Empresa_ID
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario de la caja de cobro.
	/// La diferencia entre esta clase y "CajaDeCobro",
	/// es que esta es para las cajas del mercado "Aeropuerto",
	/// y "CajaCobro" para las cajas del mercado "Metropolitano"
	/// </summary>
	public partial class CajaCobro : baseForm
	{

		public CajaCobro()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Variable utilizada para indicar si el conductor
		/// ha sido o nó bloqueado
		/// </summary>
		private bool EsBloqueado = false;

		/// <summary>
		/// Variable utilizada para indicar si el pago
		/// contiene servicios (boletos de aeropuerto)
		/// </summary>
		private bool EsServiciosConductor = false;

		/// <summary>
		/// Se utiliza para almacenar la fecha
		/// </summary>
		private DateTime getDate;

		/// <summary>
		/// Almacena los ValePrepagados que el conductor cobre 
		/// durante la operación
		/// </summary>
		private List<Entities.ValesPrepagados> Vales;

		/// <summary>
		/// Almacena las Planillas fiscales que el conductor compre
		/// durante la operación
		/// </summary>
		private List<Entities.PlanillasFiscales> Planillas;

		/// <summary>
		/// La entidad de Ticket que se produce durante cada
		/// operación de caja
		/// </summary>
		private Entities.Tickets Ticket;

		/// <summary>
		/// Almacena la estructura de variables de la operación de caja
		/// </summary>
		private Entities.OperacionCaja Operacion;

		/// <summary>
		/// Almacena los datos del conductor
		/// </summary>
		private Entities.DatosConductorUnidad DatosConductor;

		/// <summary>
		/// Los adeudos del conductor
		/// </summary>
		private BindingList<Entities.AdeudosDeConductor> Adeudos;

		/// <summary>
		/// Contiene el formulario utilizado para buscar conductor
		/// </summary>
		private BuscarConductor BusquedaConductor;

		/// <summary>
		/// Almacena la cantidad total a pagar por servicios al conductor
		/// </summary>
		private decimal TotalServicios;

		/// <summary>
		/// Almacena los servicios pendientes de pago al conductor
		/// </summary>
		public BindingList<Entities.ServiciosPendientesConductor> ServiciosPendientes
		{
			get { return _ServiciosPendientes; }
			set { _ServiciosPendientes = value; }
		}
		private BindingList<Entities.ServiciosPendientesConductor> _ServiciosPendientes;

		#endregion

		#region Metodos

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{

			base.BindData();
		}

		/// <summary>
		/// Liga los datos a los controles
		/// Se usa en lugar de "BindData" debido a que esta
		/// se llama al crear el objeto
		/// </summary>
		public void DoBindData()
		{
			//  Limpia la forma
			AppHelper.ClearControl(this);

			//  Inicializamos las variables
			this.Adeudos = new BindingList<Entities.AdeudosDeConductor>();
			this.Vales = new List<Entities.ValesPrepagados>();
			this.Planillas = new List<Entities.PlanillasFiscales>();
			this.Operacion = new Entities.OperacionCaja();
			this.BusquedaConductor = new BuscarConductor();

			//  Ligamos los datos
			OperacionCajaBindingSource.DataSource = Operacion;
			this.AdeudosGridView.DataSource = this.adeudosDeConductorBindingSource;

			UnidadTextBox.Focus();
		}

		/// <summary>
		/// Actualiza un vale prepagado como cobrado
		/// </summary>
		/// <param name="vale"></param>
		private void MarcarVale(Entities.ValesPrepagados vale)
		{
			vale.EstatusValePrepagado_ID = 2;
			vale.Update();
		}

		/// <summary>
		/// Actualiza una planilla como vendida
		/// </summary>
		/// <param name="planilla"></param>
		private void MarcarPlanilla(Entities.PlanillasFiscales planilla)
		{
			planilla.EstatusPlanillaFiscal_ID = 2;
			planilla.Ticket_ID = Ticket.Ticket_ID;
			planilla.Update();
		}

		/// <summary>
		/// Actualiza un servicio como pagado
		/// </summary>
		/// <param name="sp"></param>
		private void MarcarServicio(Entities.ServiciosPendientesConductor sp)
		{
			Entities.Servicios servicio = Entities.Servicios.Read(sp.Servicio_ID);
			servicio.FechaPago = getDate;
			servicio.Ticket_ID = Ticket.Ticket_ID;
			servicio.EstatusServicio_ID = 3; // Boleto pagado
			servicio.Update();
		}

		/// <summary>
		/// Consulta los datos de un conductor, a partir de su número ID
		/// </summary>
		/// <param name="conductor"></param>
		private void ObtenerDatosDeConductor(int conductor)
		{
			//  Obtener los datos del conductor
			this.DatosConductor = Entities.DatosConductorUnidad.GetFromConductor(conductor);
			this.datosConductorBindingSource.DataSource = this.DatosConductor;

			//  Verificar si el conductor esta bloqueado
			EsBloqueado = (bool)DB.QueryScalar(
			    string.Format("SELECT BloquearConductor FROM Conductores WHERE Conductor_ID = {0}",
				   this.DatosConductor.Conductor_ID));

			if (EsBloqueado)
			{
				//  El conductor está bloqueado 
				//  Enviar mensaje
				AppHelper.ThrowException("Conductor está bloqueado");
			}
			else
			{
				//  El conductor no está bloquedado
				//  Si hay mensaje a caja, lo mostramos
				if (!string.IsNullOrEmpty(this.DatosConductor.MensajeACaja))
				{
					AppHelper.Info(this.DatosConductor.MensajeACaja);
				}

				//  Obtenemos los adeudos de conductor
				ObtenerAdeudosDeConductor();

				//  Reinicializamos las variables de operación de caja
				Operacion = new Entities.OperacionCaja();
				OperacionCajaBindingSource.DataSource = Operacion;

			}
		}

		/// <summary>
		/// Obtenemos los datos de la unidad a partir de su número económico
		/// </summary>
		/// <param name="unidad"></param>
		private void ObtenerDatosDeUnidad(int unidad)
		{
			this.DatosConductor = Entities.DatosConductorUnidad.Get(unidad, null, Sesion.Estacion_ID.Value, false);
			//this.DatosConductor = Entities.DatosConductorUnidad.Get(unidad);
			this.datosConductorBindingSource.DataSource = this.DatosConductor;

			//  Verificamos si el conductor está bloqueado
			EsBloqueado = false;
			EsBloqueado = (bool)DB.QueryScalar(
			    string.Format("SELECT BloquearConductor FROM Conductores WHERE Conductor_ID = {0}",
				   this.DatosConductor.Conductor_ID));

			//  Si esta bloqueado, enviamos un error
			if (EsBloqueado)
			{
				AppHelper.ThrowException("Conductor está bloqueado");
			}
			else
			{
				//  Si hay mensaje a caja
				if (!string.IsNullOrEmpty(this.DatosConductor.MensajeACaja))
				{
					AppHelper.Info(this.DatosConductor.MensajeACaja);
				}

				//  Obtenemos los adeudos
				ObtenerAdeudosDeConductor();

				//  Reinicializamos las variables de operación
				Operacion = new Entities.OperacionCaja();
				OperacionCajaBindingSource.DataSource = Operacion;
			}
		}

		/// <summary>
		/// Consulta los adeudos del conductor y los despliega en la tabla de adeudos
		/// </summary>
		private void ObtenerAdeudosDeConductor()
		{
			this.Adeudos = Entities.AdeudosDeConductor.Get(DatosConductor.Conductor_ID);
			adeudosDeConductorBindingSource.DataSource = this.Adeudos;
			CalcularTotales();
		}

		/// <summary>
		/// Verifica si un vale se encuentra en la lista
		/// </summary>
		/// <param name="vale"></param>
		/// <param name="vales"></param>
		/// <returns></returns>
		private bool CompararVale(Entities.ValesPrepagados vale, List<Entities.ValesPrepagados> vales)
		{
			foreach (Entities.ValesPrepagados v in vales)
			{
				if (v.ValePrepagado_ID == vale.ValePrepagado_ID)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Agrega un vale prepagado a la lista de vales a cobrar
		/// </summary>
		/// <param name="valeprepagado"></param>
		private void AgregarValePrepagado(string valeprepagado)
		{
			//  Limpiamos la tablas
			valesPrepagadosBindingSource.DataSource = null;

			//  Validamos el vale
			Entities.ValesPrepagados.Validar(valeprepagado);

			//  Crear un nuevo vale
			Entities.ValesPrepagados vale = Entities.ValesPrepagados.Read(valeprepagado);

			//  Verificar que no esté en lista
			if (CompararVale(vale, Vales))
			{
				valesPrepagadosBindingSource.DataSource = Vales;
				throw new Exception("El vale prepagado ya se encuentra en la lista");
			}

			//  Agregarlo a la lista
			Vales.Add(vale);

			//  Consultar totales
			CalcularTotales();

			//  Desplegar datos
			valesPrepagadosBindingSource.DataSource = Vales;

		}

		/// <summary>
		/// Verifica si una planilla fiscal se encuentra en la lista
		/// </summary>
		/// <param name="planilla"></param>
		/// <param name="planillas"></param>
		/// <returns></returns>
		private bool ComparaPlanilla(Entities.PlanillasFiscales planilla, List<Entities.PlanillasFiscales> planillas)
		{
			foreach (Entities.PlanillasFiscales p in planillas)
			{
				if (p.Serie == planilla.Serie && p.Folio == planilla.Folio && p.Estacion_ID == planilla.Estacion_ID)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Agrega una planilla fiscal a la lista de planillas a comprar
		/// </summary>
		/// <param name="folio"></param>
		/// <param name="serie"></param>
		private void AgregarPlanillaFiscal(int folio, string serie)
		{
			//  Limpiamos la tabla
			planillasFiscalesBindingSource.DataSource = null;

			//  Obtenemos un grupo de planillas
			List<Entities.PlanillasFiscales> planillas = ObtenerGrupoPlanillas(folio, Sesion.Estacion_ID.Value, serie);

			//  Si las planillas existen
			if (planillas.Count > 0)
			{ //  Verificar que no esté en lista
				if (ComparaPlanilla(planillas[0], Planillas))
				{
					planillasFiscalesBindingSource.DataSource = Planillas;
					throw new Exception("Las planillas ya estan en la lista");
				}

				//  Las agregamos a la lista
				Planillas.AddRange(planillas);

				//  Calculamos los totales
				CalcularTotales();

				//  Ligamos los datos de planillas
				planillasFiscalesBindingSource.DataSource = Planillas;
			}
			else
			{
				//  Si no hay planillas
				planillasFiscalesBindingSource.DataSource = Planillas;
				throw new Exception(string.Format("No hay planillas fiscales con serie {0} y folio {1}", serie, folio));
			}
		}

		/// <summary>
		/// Busca un grupo especifico de planillas en la base de datos
		/// y lo regresa
		/// </summary>
		/// <param name="folio"></param>
		/// <param name="estacion"></param>
		/// <param name="serie"></param>
		/// <returns></returns>
		private List<Entities.PlanillasFiscales> ObtenerGrupoPlanillas(int folio, int estacion, string serie)
		{
			//  Variables de folios
			int folioinicial, foliofinal;

			//  Obtenemos la base entera
			//  Se divide entre 5 por que las planillas
			//  se venden en paquetes de 5
			int baseint = (int)Math.Floor(((double)folio / 5D));

			//  Obtenemos la base con decimales
			double basedec = ((double)folio / 5D);

			//  obtenemos el residuo
			double res = basedec - baseint;

			//  Si el residuo es o
			if (res == 0)
			{
				//  Obtenemos los folios
				foliofinal = baseint * 5;
				folioinicial = foliofinal - 4;
			}
			else // Si no
			{
				//  Recalculamos los folios
				folioinicial = (baseint * 5) + 1;
				foliofinal = folioinicial + 4;
			}

			//  Consultamos las planillas
			List<Entities.PlanillasFiscales> list =
			    Entities.PlanillasFiscales.Read("Folio BETWEEN @FolioInicial AND @FolioFinal AND Estacion_ID = @Estacion_ID AND Serie = @Serie",
				   null, DB.Param("@FolioInicial", folioinicial), DB.Param("@FolioFinal", foliofinal), DB.Param("@Estacion_ID", estacion),
					  DB.Param("@Serie", serie));

			//  Para cada planilla en la lista,
			//  verificamos que no haya sido vendida
			foreach (Entities.PlanillasFiscales planilla in list)
			{
				if (planilla.EstatusPlanillaFiscal_ID != 1)
				{
					throw new Exception(String.Format("Planilla fiscal {0} ya ha sido vendida", planilla.Folio));
				}
			}

			//  regresamos el resultado
			return list;
		}

		/// <summary>
		/// Elimina un vale prepagado de la lista actual
		/// </summary>
		/// <param name="vale"></param>
		private void EliminarValePrepagado(Entities.ValesPrepagados vale)
		{
			valesPrepagadosBindingSource.DataSource = null;
			Vales.Remove(vale);
			CalcularTotales();
			valesPrepagadosBindingSource.DataSource = Vales;
		}

		/// Elimina una planilla fiscal de la lista actual
		/// </summary>
		/// <param name="planilla"></param>
		private void EliminarPlanillaFiscal(Entities.PlanillasFiscales planilla)
		{
			//  Desligamos los datos
			planillasFiscalesBindingSource.DataSource = null;

			//  Obtener las 5 planillas a eliminar            
			int folioinicial, foliofinal;

			//  Obtenemos el residuo de la división del folio entre 5,
			//  ya que las planillas se venden en paquetes de 5
			int baseint = (int)Math.Floor(((double)planilla.Folio / 5D));
			double basedec = ((double)planilla.Folio / 5D);
			double res = basedec - baseint;

			//  Si el residuo es 0,
			if (res == 0)
			{
				//  El folio final es el folio, la base multiplicada por 5
				foliofinal = baseint * 5;

				//  Para el folio inicial, reducimos el final en 5
				folioinicial = foliofinal - 5;
			}
			else // si el residuo no es 0
			{
				//  El folio inicial es la base multiplicada pos 5, más 1
				folioinicial = (baseint * 5) + 1;

				//  El folio final es el folio inicial, más cuatro unidades
				foliofinal = folioinicial + 4;
			}

			//  Buscamos las planitllas en la lista
			List<Entities.PlanillasFiscales> list =
			    Planillas.FindAll(
				   delegate(Entities.PlanillasFiscales p)
				   { return p.Folio >= folioinicial && p.Folio <= foliofinal; });

			//  Eliminar cada planilla
			foreach (Entities.PlanillasFiscales p in list)
			{
				Planillas.Remove(p);
			}

			//  Recalculamos los totales
			CalcularTotales();

			//  Volvemos a ligar datos
			planillasFiscalesBindingSource.DataSource = Planillas;
		}

		private bool ValidaKilometraje()
		{
			//Validar que se haya capturado el kilometraje
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text) && AppHelper.IsNumeric(KilometrajeActualTextBox.Text))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Calcula los totales de la operación actual
		/// </summary>
		private void CalcularTotales()
		{
			//  Reinicializamos la operación
			Operacion = new Entities.OperacionCaja();

			//  Sumamos los adeudos
			foreach (Entities.AdeudosDeConductor adeudo in Adeudos)
			{
				Operacion.TotalAdeudos += adeudo.Pagar;
			}

			//  Sumamos los vales
			foreach (Entities.ValesPrepagados vale in Vales)
			{
				Operacion.TotalVales += vale.Denominacion;
			}

			//  Sumamos las planillas
			foreach (Entities.PlanillasFiscales planilla in Planillas)
			{
				Operacion.TotalPlanillasFiscales += planilla.Precio;
			}

			//  Calculamos los totales

			Operacion.TotalServicios = this.TotalServicios;
			Operacion.TotalAdeudos += Operacion.TotalPlanillasFiscales;
			Operacion.APagarEfectivo = Operacion.TotalAdeudos - Operacion.TotalVales - Operacion.TotalServicios;
			if (!string.IsNullOrEmpty(PagaconTextBox.Text)) Operacion.PagoEfectivo = Convert.ToDecimal(PagaconTextBox.Text);
			Operacion.Cambio = Operacion.TotalAdeudos - Operacion.TotalVales - Operacion.PagoEfectivo - Operacion.TotalServicios;

			OperacionCajaBindingSource.DataSource = Operacion;
			OperacionCajaBindingSource.ResetBindings(false);
			if (Operacion.PagoEfectivo == 0) PagaconTextBox.Text = "";
			if (Operacion.Cambio > 0) CambioTextBox.Text = "";
		}

		/// <summary>
		/// Valida la operación de caja
		/// </summary>
		private void Validar()
		{
			// Si hay cambio
			if (Operacion.Cambio > 0)
			{
				throw new Exception("La cantidad a pagar es mayor que la cantidad capturada");
			}

			//  Si no hay conductor capturado
			if (DatosConductor == null)
			{
				throw new Exception("Debe capturar un conductor para llevar a cabo el pago");
			}

			//  Si no hay conductor capturado
			if (DatosConductor.Conductor_ID == 0)
			{
				throw new Exception("Debe capturar un conductor para llevar a cabo el pago");
			}

			//  Si no hay adeudos pagados ni planillas compradas
			if (Adeudos.Count == 0 && Planillas.Count == 0)
			{
				throw new Exception("No existen movimientos para registrar pago");
			}

			//  Variable para indicar si existen pagos realizados
			bool ExistenPagos = false;

			//  Verificamos cada adeudo
			foreach (Entities.AdeudosDeConductor adeudo in Adeudos)
			{
				if (adeudo.Pagar > 0)
				{
					//  Si al menos uno ha sido pagado, si existen pagos
					ExistenPagos = true;
				}
			}

			//  Si no existen pagos realizados
			if (!ExistenPagos)
			{
				if (Planillas.Count == 0)
				{
					throw new Exception("No existen pagos para registrar");
				}
			}

			//  Si hay cambio
			if (Operacion.Cambio < 0)
			{
				//  Obtenemos el saldo en efectivo
				string sql = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaFlujoCajas WHERE Sesion_ID = @Sesion_ID AND Moneda_ID = @Moneda_ID";

				decimal saldoEfectivo = Convert.ToDecimal(
				    DB.QueryScalar(
					   sql,
					   DB.GetParams(
						  DB.Param("@Sesion_ID", Sesion.Sesion_ID),
						  DB.Param("@Moneda_ID", 1)
					   )
				    )
				);

				//  Le sumamos el efectivo externo de la operación
				saldoEfectivo += Operacion.EfectivoExterno;

				//  Si el cambio es mayor al saldo
				if (Math.Abs(Operacion.Cambio) > Math.Abs(saldoEfectivo))
				{
					AppHelper.ThrowException("No hay suficiente efectivo para completar la operación");
				}
			}
		}

		/// <summary>
		/// Obtiene la empresa a la cual pertencerá el ticket, en cado
		/// de que el conductor sea liquidado
		/// </summary>
		/// <returns></returns>
		private int GetEmpresa_ID()
		{
			//  Declaramos las variables
			//  Variable de control, para verificar el pago máximo
			decimal maxpagar = 0;

			//  Variable de la empresa, que regresaremos como resultado
			int empresa_id = 0;

			//  Recorremos los adeudos
			foreach (Entities.AdeudosDeConductor adeudo in Adeudos)
			{
				//  Si por pagar es mayor que la cantidad maxima actual
				if (adeudo.Pagar > maxpagar)
				{
					//  Lo asignamos como la cantidad maxima
					maxpagar = adeudo.Pagar;

					//  configuramos la empresa
					empresa_id = adeudo.Empresa_ID;
				}
			}

			return empresa_id;
		}

		/// <summary>
		/// Registra las operaciones de caja en la base de datos
		/// </summary>
		private void RegistrarOperaciones()
		{
			//  Validamos las operaciones
			Validar();

			//  Obtenemos la fecha
			getDate = DB.GetDate();

			//  Instanciamos una cuenta de flujo de caja
			Entities.CuentaFlujoCajas CuentaFlujo = new Entities.CuentaFlujoCajas();

			//  Creamos el ticket
			Ticket = new Entities.Tickets();
			Ticket.Caja_ID = Sesion.Caja_ID.Value;
			Ticket.Conductor_ID = DatosConductor.Conductor_ID;
			Ticket.Empresa_ID = (DatosConductor.Empresa_ID != null) ? DatosConductor.Empresa_ID.Value : GetEmpresa_ID();
			Ticket.Estacion_ID = Sesion.Estacion_ID.Value;
			Ticket.EstatusTicket_ID = 1;
			Ticket.Fecha = getDate;
			Ticket.Sesion_ID = Sesion.Sesion_ID;
			Ticket.Unidad_ID = DatosConductor.Unidad_ID;
			Ticket.Usuario_ID = Sesion.Usuario_ID;

			Ticket.Create();

			//  Realizamos las operaciones de Cuenta conductores // Cuenta cajas // Cuenta Unidades

			//  Para cada adeudo en la lista
			foreach (Entities.AdeudosDeConductor adeudo in Adeudos)
			{
				//  Si el adeudo ha sido pagado
				if (adeudo.Pagar > 0)
				{
					#region CuentaConductores

					//  Ingresamos en pago en la cuenta de conductores
					Entities.CuentaConductores cc = new Entities.CuentaConductores();
					cc.Abono = adeudo.Pagar;
					cc.Caja_ID = Sesion.Caja_ID.Value;
					cc.Cargo = 0;
					cc.Comentarios = "PAGO EN CAJA";
					cc.Concepto_ID = adeudo.Concepto_ID;
					cc.Conductor_ID = Ticket.Conductor_ID;
					cc.Cuenta_ID = adeudo.Cuenta_ID;
					cc.Empresa_ID = adeudo.Empresa_ID;
					cc.Estacion_ID = Sesion.Estacion_ID.Value;
					cc.Fecha = getDate;
					cc.Saldo = 0; // Se calcula solo
					cc.Ticket_ID = Ticket.Ticket_ID;
					cc.Unidad_ID = DatosConductor.Unidad_ID;
					cc.Usuario_ID = Sesion.Usuario_ID;
					cc.Create();

					//  Si la cuenta es de "SUPERPRODUCTIVIDAD"
					//  calculamos el cargo correspondiente
					if (adeudo.Cuenta_ID == 18)
					{
						cc = new Entities.CuentaConductores();
						cc.Abono = 0;
						cc.Caja_ID = Sesion.Caja_ID.Value;
						cc.Cargo = adeudo.Pagar;
						cc.Comentarios = "CARGO POR SUPERPRODUCTIVIDAD";
						cc.Concepto_ID = 133; // El concepto de cargo
						cc.Conductor_ID = Ticket.Conductor_ID;
						cc.Cuenta_ID = adeudo.Cuenta_ID;
						cc.Empresa_ID = adeudo.Empresa_ID;
						cc.Estacion_ID = Sesion.Estacion_ID.Value;
						cc.Fecha = getDate;
						cc.Saldo = 0; // Se calcula solo
						//cc.Ticket_ID = Ticket.Ticket_ID; //   Entra sin ticket, para no afectar el reporte de tickets
						cc.Unidad_ID = DatosConductor.Unidad_ID;
						cc.Usuario_ID = Sesion.Usuario_ID;
						cc.Create();
					}

					#endregion

					#region CuentaUnidades

					//  Si hay registro de unidad
					if (DatosConductor.Unidad_ID != null)
					{
						//  Realizamos el registro de un abono
						//  a la cuenta de unidad
						Entities.CuentaUnidades cu = new Entities.CuentaUnidades();
						cu.Abono = adeudo.Pagar;
						cu.Caja_ID = Sesion.Caja_ID.Value;
						cu.Comentarios = "PAGO EN CAJA";
						cu.Concepto_ID = adeudo.Concepto_ID;
						cu.Conductor_ID = Ticket.Conductor_ID;
						cu.Cuenta_ID = adeudo.Cuenta_ID;
						cu.Empresa_ID = adeudo.Empresa_ID;
						cu.Estacion_ID = Sesion.Estacion_ID.Value;
						cu.Fecha = getDate;
						cu.Saldo = 0; // Se calcula solo;
						cu.Ticket_ID = Ticket.Ticket_ID;
						cu.Unidad_ID = DatosConductor.Unidad_ID.Value;
						cu.Usuario_ID = Sesion.Usuario_ID;
						cu.Create();
					}

					#endregion

					#region CuentaCajas

					//  El pago lo registramos en la cuenta de cajas
					Entities.CuentaCajas ccs = new Entities.CuentaCajas();
					ccs.Abono = adeudo.Pagar;
					ccs.Caja_ID = Sesion.Caja_ID.Value;
					ccs.Cargo = 0;
					ccs.Comentarios = "PAGO EN CAJA";
					ccs.Concepto_ID = adeudo.Concepto_ID;
					ccs.Cuenta_ID = adeudo.Cuenta_ID;
					ccs.Empresa_ID = adeudo.Empresa_ID;
					ccs.Estacion_ID = Sesion.Estacion_ID.Value;
					ccs.Fecha = getDate;
					ccs.Saldo = 0; // Se calcula solo
					ccs.Sesion_ID = Sesion.Sesion_ID;
					ccs.Ticket_ID = Ticket.Ticket_ID;
					ccs.Usuario_ID = Sesion.Usuario_ID;
					ccs.Create();

					#endregion
				}
			}

			#region Planillas Cuenta Cajas

			//  Para cada planilla fiscal
			foreach (Entities.PlanillasFiscales planilla in Planillas)
			{
				//  Creamos un abono en la cuenta de cajas
				Entities.CuentaCajas ccs = new Entities.CuentaCajas();
				ccs.Abono = planilla.Precio;
				ccs.Caja_ID = Sesion.Caja_ID.Value;
				ccs.Cargo = 0;
				ccs.Comentarios = "PAGO EN CAJA - PLANILLAS -";
				ccs.Concepto_ID = 147;
				ccs.Cuenta_ID = 6;
				ccs.Empresa_ID = planilla.Empresa_ID;
				ccs.Estacion_ID = Sesion.Estacion_ID.Value;
				ccs.Fecha = getDate;
				ccs.Saldo = 0; // Se calcula solo
				ccs.Sesion_ID = Sesion.Sesion_ID;
				ccs.Ticket_ID = Ticket.Ticket_ID;
				ccs.Usuario_ID = Sesion.Usuario_ID;
				ccs.Create();
			}

			#endregion


			#region Vales Cuenta Cajas

			//  Para cada vale prepagado
			foreach (Entities.ValesPrepagados vale in Vales)
			{
				//  Creamos un abono en la cuenta de cajas
				Entities.CuentaCajas ccs = new Entities.CuentaCajas();
				ccs.Abono = vale.Denominacion;
				ccs.Caja_ID = Sesion.Caja_ID.Value;
				ccs.Cargo = 0;
				ccs.Comentarios = "PAGO EN CAJA - VALES -";
				ccs.Concepto_ID = 148;
				ccs.Cuenta_ID = 5;
				ccs.Empresa_ID = 6; // Los vales son de Axertis
				ccs.Estacion_ID = Sesion.Estacion_ID.Value;
				ccs.Fecha = getDate;
				ccs.Saldo = 0; // Se calcula solo
				ccs.Sesion_ID = Sesion.Sesion_ID;
				ccs.Ticket_ID = Ticket.Ticket_ID;
				ccs.Usuario_ID = Sesion.Usuario_ID;
				ccs.Create();
			}

			#endregion

			// Si hay vales prepagados
			if (Operacion.TotalVales > 0)
			{
				#region Flujo Caja Vales

				//  Creamos un abono en la cuenta de flujo de caja
				CuentaFlujo = new Entities.CuentaFlujoCajas();
				CuentaFlujo.Abono = Operacion.TotalVales;
				CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
				CuentaFlujo.Cargo = 0;
				CuentaFlujo.Concepto = "PAGO CON VALES";
				CuentaFlujo.Fecha = getDate;
				CuentaFlujo.Moneda_ID = 3; // Los vales
				CuentaFlujo.Saldo = 0; // Se calcula solo
				CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
				CuentaFlujo.Ticket_ID = Ticket.Ticket_ID;
				CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
				CuentaFlujo.Create();

				#endregion

				#region Retribucion de Vales

				//  El total de los vales
				decimal totalvales = this.Operacion.TotalVales;

				//  El pago con vales
				decimal pagovales;

				//  Para cada adeudo
				foreach (Entities.AdeudosDeConductor adeudo in Adeudos)
				{
					//  Si fue pagado
					if (adeudo.Pagar > 0)
					{
						//  Si el total de vales es menor o igual que el adeudo pagado
						if (totalvales <= adeudo.Pagar)
						{
							//  El pago de vales es el tota
							pagovales = totalvales;
						}
						else // Si no
						{
							//  El pago de vales es la cantidad pagada
							pagovales = adeudo.Pagar;
						}

						//  Creamos la retribución de vales para la cuenta de cajas
						//  es decir, se carga la cantidad de pago con vales
						//  que fueron utilizados en lugar del pago con efectivo
						Entities.CuentaCajas ccs = new Entities.CuentaCajas();
						ccs.Cargo = Math.Abs(pagovales);
						ccs.Caja_ID = Sesion.Caja_ID.Value;
						ccs.Abono = 0;
						ccs.Comentarios = "RETRIBUCION EN CAJA - VALES -";
						ccs.Concepto_ID = adeudo.Concepto_ID;
						ccs.Cuenta_ID = adeudo.Cuenta_ID;
						ccs.Empresa_ID = adeudo.Empresa_ID; // Los vales son de Axertis
						ccs.Estacion_ID = Sesion.Estacion_ID.Value;
						ccs.Fecha = getDate;
						ccs.Saldo = 0; // Se calcula solo
						ccs.Sesion_ID = Sesion.Sesion_ID;
						ccs.Ticket_ID = Ticket.Ticket_ID;
						ccs.Usuario_ID = Sesion.Usuario_ID;
						ccs.Create();

						//  Se disminuye el total de vales
						totalvales -= pagovales;

						//  En cuanto se llegue a 0
						//  sale del ciclo
						if (totalvales == 0)
							break;
					}
				}
				#endregion
			}

			//  Si hubo pago con efectivo pago con efectivo
			if (Operacion.PagoEfectivo > 0)
			{
				//  El efectivo se ingresa a la cuenta de flujo de caja
				CuentaFlujo = new Entities.CuentaFlujoCajas();
				CuentaFlujo.Abono = Operacion.PagoEfectivo;
				CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
				CuentaFlujo.Cargo = 0;
				CuentaFlujo.Concepto = "PAGO CON EFECTIVO";
				CuentaFlujo.Fecha = getDate;
				CuentaFlujo.Moneda_ID = 1; // El efectivo
				CuentaFlujo.Saldo = 0; // Se calcula automáticamente
				CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
				CuentaFlujo.Ticket_ID = Ticket.Ticket_ID;
				CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
				CuentaFlujo.Create();
			}

			//  Si hay cambio            
			if (Math.Abs(Operacion.Cambio) > 0)
			{
				//  El cambio, en efectivo, sale de la caja
				CuentaFlujo = new Entities.CuentaFlujoCajas();
				CuentaFlujo.Abono = 0;
				CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
				CuentaFlujo.Cargo = Math.Abs(Operacion.Cambio);
				CuentaFlujo.Concepto = "CAMBIO / PAGO CONDUCTOR";
				CuentaFlujo.Fecha = getDate;
				CuentaFlujo.Moneda_ID = 1; // El efectivo
				CuentaFlujo.Saldo = 0; // Se calcula automáticamente
				CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
				CuentaFlujo.Ticket_ID = Ticket.Ticket_ID;
				CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
				CuentaFlujo.Create();
			}

			//  Solamente si hay servicios, estos se ingresan
			//  a la cuenta de flujo de caja
			if (Math.Abs(Operacion.TotalServicios) > 0)
			{
				CuentaFlujo.Cargo = 0;
				CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
				CuentaFlujo.Abono = Math.Abs(Operacion.TotalServicios);
				CuentaFlujo.Concepto = "CANJE DE BOLETOS";
				CuentaFlujo.Fecha = getDate;
				CuentaFlujo.Moneda_ID = 2; // Boletos de Servicios
				CuentaFlujo.Saldo = 0; // Se calcula automáticamente
				CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
				CuentaFlujo.Ticket_ID = Ticket.Ticket_ID;
				CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
				CuentaFlujo.Create();
			}

			// Dar de baja los vales
			foreach (Entities.ValesPrepagados vale in Vales)
			{
				MarcarVale(vale);
			}

			// Dar de baja las planillas fiscales
			foreach (Entities.PlanillasFiscales planilla in Planillas)
			{
				MarcarPlanilla(planilla);
			}

			//  Dar de baja los servicios que existan
			foreach (Entities.ServiciosPendientesConductor sp in this.ServiciosPendientes)
			{
				MarcarServicio(sp);
			}
		}

		/// <summary>
		/// Imprime el ticket de pago
		/// </summary>
		private void ImprimirTicketPago()
		{
			Entities.Cajas caja = Entities.Cajas.Read(Sesion.Caja_ID.Value);
			if (caja.ImpresionDoble.Value)
			{
				Imprimir(caja.EnClave.Value, caja.ImprimirFirmas, 1);
				Imprimir(caja.EnClave.Value, caja.ImprimirFirmas, 2);
			}
			else
			{
				Imprimir(caja.EnClave.Value, caja.ImprimirFirmas, 1);
			}
		}

		/// <summary>
		/// Realiza la impresión del ticket de pago
		/// </summary>
		/// <param name="EnClave">Indica si se imprimiran claves de conceptos, o no</param>
		/// <param name="ImprimirFirmas">Indica si se imprimiran las firmas</param>
		private void Imprimir(bool EnClave, bool ImprimirFirmas, int ncopia)
		{
			bool HayImpresion = false;

			//  Instancia de la impresión
			PrintHelper printer = new PrintHelper();

			// Obtener datos del ticket
			List<Entities.Get_DatosTicket> ticketdata = Entities.Get_DatosTicket.Get(Ticket.Ticket_ID);

			//  Nueva tabla de datos
			DataTable dtable = new DataTable();

			// Agregamos las columnas
			// Si es en clave
			if (EnClave)
			{
				// La columna como entero
				dtable.Columns.Add("CIUD", typeof(System.Int32));
			}
			else
			{
				// Si no es en clave
				// La columna como cadena
				dtable.Columns.Add("CIUD", typeof(System.String));
			}
			dtable.Columns.Add("M", typeof(System.Decimal));
			dtable.Columns.Add("S", typeof(System.Decimal));

			//  Si hay registros en el ticket
			if (ticketdata.Count > 0)
			{
				Entities.Get_DatosTicket data = ticketdata[0];

				//  Recorrer los registros del ticket
				foreach (Entities.Get_DatosTicket mov in ticketdata)
				{
					// Si es clave
					if (EnClave)
					{
						//   Ingresar el numero de la cuenta
						dtable.Rows.Add(mov.Cuenta_ID, mov.Abono, mov.Saldo);
					}
					else
					{
						//  Ingresar la descripcion de la cuenta
						dtable.Rows.Add(mov.Cuenta, mov.Abono, mov.Saldo);
					}
				}

				// Imprimir los datos de empresa, estacion, unidad, conductor
				printer.PrintText(string.Format("#COPIA:   {0}", ncopia));
				printer.PrintCLRF();
				printer.PrintText(string.Format("TID:   {0}     EID:    {1}", data.Ticket_ID, data.Empresa_ID));
				printer.PrintText(string.Format("CID:   {0}     ESTID:    {1}", data.Conductor_ID, data.Estacion_ID));
				printer.PrintText(string.Format("UID:   {0}     CAID:    {1}", data.Unidad_ID, data.Caja_ID));
				printer.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", data.Fecha));
				printer.PrintCLRF();

				//  Si no es en clave
				if (!EnClave)
				{
					//  Imprimir numero economico y nombre del conductor
					printer.PrintText(string.Format("U{0}", data.NumeroEconomico));
					printer.PrintText(data.Conductor.ToUpper());
				}

				printer.PrintCLRF();

				// Imprimir la tabla
				printer.PrintTable(dtable);

				printer.PrintText("$ TA:    {0:N2}", Operacion.TotalAdeudos);

				HayImpresion = true;
			}

			//  Si hay servicios
			if (this.ServiciosPendientes.Count > 0)
			{
				// Creamos la tabla de servicios
				DataTable boltable = new DataTable();
				boltable.Columns.Add("B", typeof(System.String));
				boltable.Columns.Add("P", typeof(System.Decimal));

				foreach (Entities.ServiciosPendientesConductor spc in this.ServiciosPendientes)
				{
					boltable.Rows.Add(spc.Servicio_ID, spc.PagoConductor);
				}

				printer.PrintCLRF();
				printer.PrintCLRF();

				// Imprimimos la tabla de servicios
				printer.PrintTable(boltable);

				printer.PrintText("# B:    {0:N0}", this.ServiciosPendientes.Count);
				printer.PrintText("$ B:    {0:N2}", Operacion.TotalServicios);
			}

			// Si hay planillas
			if (this.Planillas.Count > 0)
			{
				printer.PrintCLRF();

				// Obtenemos el total
				decimal totalPlanillas = 0;

				// Recorriendo la colección de planillas
				foreach (Entities.PlanillasFiscales planilla in Planillas)
				{
					totalPlanillas += planilla.Precio;
				}

				// Imprimimos el total
				printer.PrintText("PF:  " + Math.Round(totalPlanillas, 2).ToString());

				// Informamos que hay datos por imprimir
				HayImpresion = true;
			}

			// Si hay vales
			if (this.Vales.Count > 0)
			{
				printer.PrintCLRF();

				// Obtenemos el total
				decimal totalVales = 0;

				// Recorriendo la colección
				foreach (Entities.ValesPrepagados vale in this.Vales)
				{
					totalVales += vale.Denominacion;
				}

				// Imprimimos el total
				printer.PrintText("VP:  " + Math.Round(totalVales, 2).ToString());

				// Informamos que hay datos por imprimir
				HayImpresion = true;
			}

			printer.PrintText("TPC:    {0:N2}", Math.Abs(this.Operacion.Cambio));
			printer.PrintLine();

			// Si hay datos por imprimir
			if (HayImpresion)
			{
				// Imprimir firmas
				if (ImprimirFirmas)
				{
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintText("-------------------------------");
					printer.PrintText("F CA");
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintText("-------------------------------");
					printer.PrintText("F CO");
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintLine();
					printer.PrintText("================================");
				}
				LogHelper.Logger.InfoFormat("Busca ticket #{0} en Base de Datos.", Ticket.Ticket_ID);
				if (SICASv20.Entities.Tickets.ExisteTicketEnDB(Ticket.Ticket_ID))
				{
					LogHelper.Logger.InfoFormat("Imprimiendo ticket #{0} - copia {1}", Ticket.Ticket_ID, ncopia);
					printer.Print();
					LogHelper.Logger.InfoFormat("Se imprimió ticket #{0} - copia {1}", Ticket.Ticket_ID, ncopia);
					Entities.Tickets.InsertaBitacoraTicket(Ticket, ncopia);
				}
				else
				{
					LogHelper.Logger.InfoFormat("Ticket #{0} no encontrado en Base de Datos.", Ticket.Ticket_ID);
				}
			}
		}

		/// <summary>
		/// Configura a un conductor y sus servicios
		/// para el pago en caja
		/// </summary>
		/// <param name="datosconductor">Los datos del conductor</param>
		/// <param name="servicios">El listado de sus servicios</param>
		/// <param name="totalservicios">El total de sus servicios</param>
		/// <param name="fechapago">La fecha de pago</param>
		public void Set_ConductorPago(
		    Entities.DatosConductorUnidad datosconductor,
		    BindingList<Entities.ServiciosPendientesConductor> servicios,
		    decimal totalservicios,
		    DateTime fechapago)
		{
			//  Es pago de conductor
			this.EsServiciosConductor = true;

			//  Asignamos los parámetros a las variables locales
			this.DatosConductor = datosconductor;
			this.ServiciosPendientes = servicios;
			this.TotalServicios = totalservicios;

			//  Obtenemos los adeudos
			this.Adeudos = Entities.AdeudosDeConductor.Get(DatosConductor.Conductor_ID);

			//  Calculamos la productividad
			int productividad = 0;
			foreach (Entities.ServiciosPendientesConductor s in servicios)
			{
				if (s.TipoServicioConductor_ID == null)
				{
					productividad++;
				}
			}

			//  Obtenemos las carreras ya pagadas de ese dia
			string sql = @"SELECT	COUNT(*)
FROM	Servicios
WHERE	Conductor_ID = @Conductor_ID
AND		EstatusServicio_ID = 3
AND     TipoServicioConductor_ID IS NULL
AND		dbo.udf_DateValue(FechaPago) = dbo.udf_DateValue(@FechaPago)
AND		dbo.udf_ObtenerFechaPagoBoleto(Caja_ID, Fecha, FechaServicio) = dbo.udf_DateValue(@FechaPago)";

			//  Obtenemos las carreras pagadas
			int carreraspagadas =
			    Convert.ToInt32(
				   DB.QueryScalar(
					  sql,
					  DB.Param("@Conductor_ID", datosconductor.Conductor_ID),
					  DB.Param("@FechaPago", fechapago)
				   )
			    );

			//  Incrementamos las productividad con las carreras que ya han sido pagadas
			productividad += carreraspagadas;

			//  Obtenemos los registros de superproductividad,
			//  a partir de la productividad calculada
			Entities.SuperProductividad superProductividad = Entities.SuperProductividad.Read(productividad);

			//  Si hay superproductividad
			if (superProductividad != null)
			{
				//  Si la superproductividad es > 0
				if (superProductividad.Tarifa > 0)
				{
					//  Obtenemos lo que ya pago:
					sql = @"SELECT	ISNULL(SUM(Abono),0)
FROM	CuentaConductores
WHERE	Conductor_ID = @Conductor_ID
AND		Cuenta_ID = 18
AND		dbo.udf_DateValue(Fecha) = dbo.udf_DateValue(@FechaPago)";

					decimal superproductividadpagada =
					    Convert.ToDecimal(
						   DB.QueryScalar(
							  sql,
							  DB.Param("@Conductor_ID", datosconductor.Conductor_ID),
							  DB.Param("@FechaPago", fechapago)
						   )
					    );

					//  Lo que se cobrará será tarifa menos lo ya pagado 
					decimal cobrosuperproductividad = superProductividad.Tarifa - superproductividadpagada;

					//  Si sale negativo, es 0
					if (cobrosuperproductividad < 0) cobrosuperproductividad = 0;

					//  Variable temporal de adeudo de superproductividad
					Entities.AdeudosDeConductor adeudosp = null;

					//  Buscamos la superproductividad en los adeudos
					foreach (Entities.AdeudosDeConductor adeudo in this.Adeudos)
					{
						if (adeudo.Cuenta_ID == 18) // Es la superproductividad
						{
							//  La asignamos
							adeudosp = adeudo;
						}
					}

					//  Si la encontramos, la removemos
					if (adeudosp != null) this.Adeudos.Remove(adeudosp);

					//  Ingresamos a los adeudos la superproductividad calculada
					this.Adeudos.Insert(
					    0,
					    new Entities.AdeudosDeConductor(
						   3, // Es CAT, debe ser CAT
						   "CAT",
						   18, // La cuenta
						   134, // El concepto
						   "SUPERPRODUCTIVIDAD",
						   Math.Abs(cobrosuperproductividad) * -1,
						   0
					    )
					);
				}
			}

			//  Volvemos a ligar los datos
			adeudosDeConductorBindingSource.DataSource = this.Adeudos;
			this.datosConductorBindingSource.DataSource = this.DatosConductor;
			this.UnidadTextBox.Text = this.DatosConductor.NumeroEconomico.ToString();
			this.UnidadTextBox.Enabled = false;

			//  Y a calcular los totales
			CalcularTotales();
		}

		#endregion

		#region Eventos "View"

		/// <summary>
		/// Al teclear enter en "Unidad",
		/// se busca la unidad y se cargan los adeudos
		/// de su conductor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UnidadTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				//  Si el cobro es de tipo "ServiciosConductor"
				//  regresar sin efectuar ninguna operación
				if (EsServiciosConductor) return;

				//  Si se oprimió Enter
				if (e.KeyData == Keys.Enter)
				{
					//  Si hay datos en la caja de texto de "Unidad"
					if (!string.IsNullOrEmpty(UnidadTextBox.Text))
					{
						//  Si los datos son numéricos
						if (AppHelper.IsNumeric(UnidadTextBox.Text))
						{
							//  Ligamos los adeudos
							this.AdeudosGridView.DataSource = this.adeudosDeConductorBindingSource;

							//  Obtenemos la unidad
							int unidad;
							unidad = Convert.ToInt32(UnidadTextBox.Text);

							//  Cargamos su información
							ObtenerDatosDeUnidad(unidad);
						}
						else // Si los datos no son numéricos
						{
							//  Lanzamos excepción
							throw new Exception("Debe teclar datos numéricos");

						} // end else

					} // end if

				} // end if Enter

			} // end try
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al oprimir "Enter" en la caja de texto "ValePrepagado"
		/// este se agrega a la lista actual de vales por cobrar,
		/// en la operación actual de caja
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ValePrepagadoTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				//  Si oprimimos "Enter"
				if (e.KeyData == Keys.Enter)
				{
					//  Si hay datos en la caja de texto
					if (!string.IsNullOrEmpty(ValePrepagadoTextBox.Text))
					{
						//  Si los datos son numéricos
						if (AppHelper.IsNumeric(ValePrepagadoTextBox.Text))
						{
							//  Agregamos el vale prepagado
							AgregarValePrepagado(ValePrepagadoTextBox.Text);

							//  Limpiamos la forma
							ValePrepagadoTextBox.Text = string.Empty;
						}
						else // Si no
						{
							//  Lanzamos excepción
							throw new Exception("Debe teclar datos numéricos");
						}
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al oprimir "Enter" en la caja de texto "Planilla Fiscal",
		/// se agrega una nueva serie de folios a la lista
		/// PlanillasFiscales por comprar, en la operación actual de caja
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlanillaFiscalTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				//  Si se oprimió "Enter"
				if (e.KeyData == Keys.Enter)
				{
					//  Si hay datos en la caja de texto
					if (!string.IsNullOrEmpty(PlanillaFiscalTextBox.Text) && !string.IsNullOrEmpty(SeriePlanillaTextBox.Text))
					{
						//  Si los datos son numéricos
						if (AppHelper.IsNumeric(PlanillaFiscalTextBox.Text))
						{
							//  Agregamos la planilla
							AgregarPlanillaFiscal(Convert.ToInt32(PlanillaFiscalTextBox.Text), SeriePlanillaTextBox.Text);

							//  Limpiamos las cajas de texto
							PlanillaFiscalTextBox.Text = string.Empty;
							SeriePlanillaTextBox.Text = string.Empty;
						}
						else // Si no
						{
							//  Lanzamos la expepción
							throw new Exception("Debe teclar datos numéricos");
						}
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Actualiza el kilometraje de la unidad
		/// en la base de datos
		/// </summary>
		private void ActualizarKilometraje()
		{
			//  Si hay datos en la caja de texto
			//  "Kilometraje Actual"
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text))
			{
				//  Si los datos son numéricos
				if (AppHelper.IsNumeric(KilometrajeActualTextBox.Text))
				{
					//  Ingresamos el registro de kilometraje
					Entities.Unidades_Kilometrajes uk = new Entities.Unidades_Kilometrajes();
					uk.Unidad_ID = DatosConductor.Unidad_ID.Value;
					uk.Kilometraje = Convert.ToInt32(this.KilometrajeActualTextBox.Text);
					uk.Conductor_ID = DatosConductor.Conductor_ID;
					uk.Fecha = DB.GetDate();
					uk.Create();

					//  Actualizamos el kilometraje en la unidad
					DB.UpdateRow(
					    "Unidades",
					    DB.GetParams(
						   DB.Param("Kilometraje", uk.Kilometraje)
					    ),
					    DB.GetParams(
						   DB.Param("Unidad_ID", uk.Unidad_ID)
					    )
					);

				} // end if

			} // end if

		} // end void ActualizarKilometraje

		/// <summary>
		/// Limpia las variables
		/// </summary>
		private void Clear()
		{
			this.Operacion = new Entities.OperacionCaja();
			this.valesPrepagadosBindingSource.DataSource = null;
			this.planillasFiscalesBindingSource.DataSource = null;
			this.Vales.Clear();
			this.Planillas.Clear();
			this.Adeudos.Clear();
			this.DatosConductor = new Entities.DatosConductorUnidad();
			this.datosConductorBindingSource.ResetBindings(false);
			this.OperacionCajaBindingSource.ResetBindings(false);
			AppHelper.ClearControlExcept(this, this.SeriePlanillaTextBox.Name);
		}

		/// <summary>
		/// Registra las operaciones en la base de datos,
		/// imprime los tickets de pago
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PagaconTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				//  Si se oprimió enter
				if (e.KeyData == Keys.Enter)
				{
					if (ValidaKilometraje())
					{
						//  Realiza las transacciones en la base de datos
						AppHelper.DoTransactions(
						    delegate
						    {
							    //  Actualiza el kilometraje
							    ActualizarKilometraje();

							    //  Calcula los totales
							    CalcularTotales();

							    //  Registra las operaciones
							    RegistrarOperaciones();
						    },
						    this
						);

						AppHelper.DoMethod(
							delegate
							{ //  Imprime el ticket de pago
								ImprimirTicketPago();

								//  Limpia la forma
								this.Clear();

								//  Devuelve el foco a la forma de "Caja de Servicios"
								Padre.SwitchForma("CajaDeServicios");
							},
							this
						);
						
					}
					else // Si el kilometráje no es válido
					{
						//  Lanzamos excepción
						throw new Exception("Se debe capturar un Kilometraje válido");
					}
				}
			} // end try
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al hacer clic en la celda "EliminarVale",
		/// procede con la eliminación de vales
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ValesPrepagadosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				// Eliminar vale prepagado de lista
				if (ValesPrepagadosDataGridView.Columns[e.ColumnIndex].Name == "EliminarVale")
				{
					Entities.ValesPrepagados vale = (Entities.ValesPrepagados)ValesPrepagadosDataGridView.Rows[e.RowIndex].DataBoundItem;
					EliminarValePrepagado(vale);
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al hacer clic en la celda "EliminarPlanilla",
		/// elimina la planilla
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlanillasFiscalesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				// Eliminar planilla fiscal de lista
				if (PlanillasFiscalesDataGridView.Columns[e.ColumnIndex].Name == "EliminarPlanilla")
				{
					Entities.PlanillasFiscales planilla = (Entities.PlanillasFiscales)PlanillasFiscalesDataGridView.Rows[e.RowIndex].DataBoundItem;
					EliminarPlanillaFiscal(planilla);
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al terminar de editar una celda, calcula los totales
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AdeudosGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				//  Si la celda editada es de la columna "Pagar"
				if (AdeudosGridView.Columns[e.ColumnIndex].DataPropertyName == "Pagar")
				{
					//  Si los adeudos es menor que 0
					if (Convert.ToDecimal(AdeudosGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) < (decimal)0)
					{
						//  Regresamos el valor de "Pagar" a cero
						AdeudosGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

						//  Lanzamos excepción
						//  No es posible capturar un pago "Negativo"
						throw new Exception("No se puede capturar un pago en números negativos");
					}
					else
					{
						//   Calcular totales
						this.CalcularTotales();
					} // End if
				} // End if
			} // End try
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Cada que cambia el contenido de "Paga Con",
		/// calcula los totales
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PagaconTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string text = PagaconTextBox.Text;

				//  Verifica que no se esten capturando decimales
				//  al momento del calculo
				if (!text.EndsWith("."))
				{
					CalcularTotales();
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Si se oprime el botón "Buscar Conductor",
		/// muestra la pantalla para buscar y seleccionar
		/// conductores
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuscarConductorButton_Click(object sender, EventArgs e)
		{
			AppHelper.Try(delegate
			{
				if (this.BusquedaConductor == null)
				{
					this.BusquedaConductor = new BuscarConductor();
				}

				if (this.BusquedaConductor.IsDisposed)
				{
					this.BusquedaConductor = new BuscarConductor();
				}

				if (this.BusquedaConductor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.ObtenerDatosDeConductor(this.BusquedaConductor.Conductor_ID);
				}
			});
		}

		/// <summary>
		/// Al capturar texto en el nuevo kilometraje, solamente permitiremos numeros
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KilometrajeActualTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// Si se oprime enter en la caja de texto "Kilometraje Actual",
		/// se actualiza el kilometraje de la unidad
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KilometrajeActualTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				AppHelper.Try(
				    delegate
				    {
					    ActualizarKilometraje();

					    AppHelper.Info("Kilometraje actualizado");
				    }
				);
			}
        }

        private void UnidadTextBox_TextChanged(object sender, EventArgs e)
        {

        }  // End void

		#endregion
	} // En class
} // End namespace