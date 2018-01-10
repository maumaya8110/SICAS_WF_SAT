using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario de la caja de cobro.
	/// La diferencia entre esta clase y "CajaCobro",
	/// es que esta es para las cajas del mercado "Metropolitano",
	/// y "CajaCobro" para las cajas del mercado "Aeropuerto"
	/// </summary>
	public partial class CajaDeCobro : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia del formulario
		/// de caja de cobro
		/// </summary>
		public CajaDeCobro()
		{
			if (!Sesion.Activo)
			{
				throw new Exception("No hay una sesión activa. No se pueden realizar cobros");
			}
			InitializeComponent();
			this.dgvValesEmpresariales.AutoGenerateColumns = false;
		}

		/// <summary>
		/// Indica si un conductor está bloqueado
		/// </summary>
		private bool EsBloqueado = false;

		/// <summary>
		/// Almacena los ValePrepagados que el conductor cobre 
		/// durante la operación
		/// </summary>
		private List<Entities.ValesPrepagados> Vales;

		/// <summary>
		/// Almacena los Vales Empresariales que el conductor cobre 
		/// durante la operación
		/// </summary>
		private List<Entities.ValesEmpresariales> ValesEmpresariales;

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

		private DataTable AdeudosImpresion;

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			//  Limpia la forma
			AppHelper.ClearControl(this);

			//  Inicializamos las variables
			this.Adeudos = new BindingList<Entities.AdeudosDeConductor>();
			this.Vales = new List<Entities.ValesPrepagados>();
			this.ValesEmpresariales = new List<Entities.ValesEmpresariales>();
			this.Planillas = new List<Entities.PlanillasFiscales>();
			this.Operacion = new Entities.OperacionCaja();
			this.BusquedaConductor = new BuscarConductor();

			//  Ligamos los datos
			OperacionCajaBindingSource.DataSource = Operacion;
			this.AdeudosGridView.DataSource = this.adeudosDeConductorBindingSource;

			this.dgvValesEmpresariales.DataSource = null;
			if (ValesEmpresariales.Count > 0)
				this.dgvValesEmpresariales.DataSource = ValesEmpresariales;

			UnidadTextBox.Focus();
			base.BindData();
		}

		#region Eventos

		/// <summary>
		/// Actualiza un vale prepagado como cobrado
		/// </summary>
		/// <param name="vale"></param>
		private void MarcarVale(Entities.ValesPrepagados vale)
		{
			vale.EstatusValePrepagado_ID = 2;
			vale.FechaCanje = DateTime.Now;
			vale.Ticket_ID = Ticket.Ticket_ID;
			vale.Update();
		}

		private void MarcarValeEmpresarial(Entities.ValesEmpresariales vale)
		{
			vale.EstatusValeEmpresarial_ID = 2;
			vale.FechaCanje = DateTime.Now;
			vale.Caja_ID = Sesion.Caja_ID;
			vale.UsuarioCaja_ID = Sesion.Usuario_ID;
			vale.Ticket_ID = Ticket.Ticket_ID;
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
			this.DatosConductor = Entities.DatosConductorUnidad.Get(unidad, null, null, true); // Estacion null = cualquier estación
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
			MensajeCuentasConAdeudoACubrir(this.Adeudos);
			CalcularTotales();
		}

		private void MensajeCuentasConAdeudoACubrir(BindingList<Entities.AdeudosDeConductor> lAdeudos)
		{
			foreach (Entities.AdeudosDeConductor a in lAdeudos)
			{
				if (a.Cuenta_ID == 42)//Equipo de Gas
				{
					MessageBox.Show("Recuerde al conductor que debe cubrir su Adeudo de Equipo de Gas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
				}
			}
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

		/// <summary>
		/// Elimina un grupo de planillas fiscales de la lista actual
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

			//  Sumamos los vales prepagados
			foreach (Entities.ValesPrepagados vale in Vales)
			{
				Operacion.TotalVales += vale.Denominacion;
			}

			//  Sumamos los vales empresariales
			foreach (Entities.ValesEmpresariales vale in ValesEmpresariales)
			{
				Operacion.TotalValesEmpresariales += (decimal)vale.Monto;
			}

			//  Sumamos las planillas
			foreach (Entities.PlanillasFiscales planilla in Planillas)
			{
				Operacion.TotalPlanillasFiscales += planilla.Precio;
			}

			//  Calculamos los totales
			Operacion.TotalAdeudos += Operacion.TotalPlanillasFiscales;
			Operacion.APagarEfectivo = Operacion.TotalAdeudos - Operacion.TotalVales - Operacion.TotalValesEmpresariales;
			if (!string.IsNullOrEmpty(PagaconTextBox.Text)) Operacion.PagoEfectivo = Convert.ToDecimal(PagaconTextBox.Text);
			Operacion.Cambio = Operacion.TotalAdeudos - Operacion.TotalVales - Operacion.TotalValesEmpresariales - Operacion.PagoEfectivo;

			OperacionCajaBindingSource.DataSource = Operacion;
			if (Operacion.PagoEfectivo == 0) PagaconTextBox.Text = "";
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
			DateTime getDate = DB.GetDate();

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

					// No hay superproductividad en Metropolitano

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

			#region Vales Prepagados Cuenta Cajas
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
				ccs.Empresa_ID = Ticket.Empresa_ID;//vale.EmpresaEmite_ID; 
				ccs.Estacion_ID = Sesion.Estacion_ID.Value;
				ccs.Fecha = getDate;
				ccs.Saldo = 0; // Se calcula solo
				ccs.Sesion_ID = Sesion.Sesion_ID;
				ccs.Ticket_ID = Ticket.Ticket_ID;
				ccs.Usuario_ID = Sesion.Usuario_ID;
				ccs.Create();
			}
			#endregion

			#region Vales Empresariales Cuenta Cajas
			//  Para cada vale empresarial
			foreach (Entities.ValesEmpresariales vale in ValesEmpresariales)
			{
				//  Creamos un abono en la cuenta de cajas
				Entities.CuentaCajas ccs = new Entities.CuentaCajas();
				ccs.Abono = (decimal)vale.Monto;
				ccs.Caja_ID = Sesion.Caja_ID.Value;
				ccs.Cargo = 0;
				ccs.Comentarios = "PAGO EN CAJA - VALES EMPRESARIALES -";
				ccs.Concepto_ID = 148;
				ccs.Cuenta_ID = 5;
				ccs.Empresa_ID = Ticket.Empresa_ID;//3;
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
			if (Operacion.TotalVales > 0 || Operacion.TotalValesEmpresariales > 0)
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

				//  Creamos un abono en la cuenta de flujo de caja
				CuentaFlujo = new Entities.CuentaFlujoCajas();
				CuentaFlujo.Abono = Operacion.TotalValesEmpresariales;
				CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
				CuentaFlujo.Cargo = 0;
				CuentaFlujo.Concepto = "PAGO CON VALES EMPRESARIALES";
				CuentaFlujo.Fecha = getDate;
				CuentaFlujo.Moneda_ID = 4; // Servicios Empresariales
				CuentaFlujo.Saldo = 0; // Se calcula solo
				CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
				CuentaFlujo.Ticket_ID = Ticket.Ticket_ID;
				CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
				CuentaFlujo.Create();

				#endregion

				#region Retribucion de Vales

				//  El total de los vales
				decimal totalvales = this.Operacion.TotalVales + this.Operacion.TotalValesEmpresariales;

				//  El pago con vales prepagados
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
							//  El pago de vales es el total
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
						ccs.Empresa_ID = Ticket.Empresa_ID;//adeudo.Empresa_ID;
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

			// No hay servicios en metropolitano

			// Dar de baja los vales
			foreach (Entities.ValesPrepagados vale in Vales)
			{
				MarcarVale(vale);
			}

			// Dar de baja los vales empresariales
			foreach (Entities.ValesEmpresariales vale in ValesEmpresariales)
			{
				MarcarValeEmpresarial(vale);
			}

			// Dar de baja las planillas fiscales
			foreach (Entities.PlanillasFiscales planilla in Planillas)
			{
				MarcarPlanilla(planilla);
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

		private void ImprimirTicket()
		{
			DataTable dt = Entities.Get_DatosTicket.GetDataTable(Ticket.Ticket_ID);

			ReportDataSource rds = new ReportDataSource("DatosTicket_DataSet", dt);

			AppHelper.TicketReport = new LocalReport();
			AppHelper.TicketReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_TicketCobroConductores.rdlc";
			AppHelper.TicketReport.DataSources.Add(rds);
			AppHelper.TicketReport.Refresh();

			AppHelper.PrintTicket();
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

				HayImpresion = true;
			}
			/* No hay servicios en metropolitano */

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
				printer.PrintLine();

				// Informamos que hay datos por imprimir
				HayImpresion = true;
			}

			// Si hay vales empresariales
			if (this.ValesEmpresariales.Count > 0)
			{
				// Obtenemos el total
				decimal totalVales = 0;

				// Recorriendo la colección
				foreach (Entities.ValesEmpresariales vale in this.ValesEmpresariales)
				{
					totalVales += (decimal)vale.Monto;
				}

				// Imprimimos el total
				printer.PrintText("VEMP:  " + Math.Round(totalVales, 2).ToString());
				printer.PrintLine();

				// Informamos que hay datos por imprimir
				HayImpresion = true;
			}

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

				//Impresion de los saldos a la fecha                
				printer.PrintLine();
				printer.PrintText("SALDOS A LA FECHA");
				printer.PrintText("_______________________________________");
				//Formar la tabla del saldo que debe el conductor de las demas empresas a la fecha

				if (this.AdeudosImpresion != null && this.AdeudosImpresion.Rows.Count > 0)
				{
					printer.PrintTable(this.AdeudosImpresion);
				}

				printer.PrintLine();
				printer.PrintLine();
				printer.PrintText("================================");
				printer.PrintLine();

				//Imprimir, si es que existe el Ticket_ID en DB
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

		private void AgregarAdeudosImpresion()
		{
			//Tabla para imprimir historico
			DataTable dtCargosHistorico = new DataTable();
			DataColumn dc = new DataColumn("EMP", typeof(string));
			dtCargosHistorico.Columns.Add(dc);
			dc = new DataColumn("CIUD", typeof(string));
			dtCargosHistorico.Columns.Add(dc);
			dc = new DataColumn("S", typeof(decimal));
			dtCargosHistorico.Columns.Add(dc);


			BindingList<Entities.AdeudosDeConductor> adeudosList = Entities.AdeudosDeConductor.Get(DatosConductor.Conductor_ID);

			foreach (Entities.AdeudosDeConductor datos in adeudosList)
			{
				DataRow drOK = dtCargosHistorico.NewRow();
				drOK["EMP"] = datos.Empresa;
				drOK["CIUD"] = datos.Cuenta;
				drOK["S"] = datos.Saldo;
				dtCargosHistorico.Rows.Add(drOK);
			}
			AdeudosImpresion = dtCargosHistorico;
		}

		/// <summary>
		/// De acuerdo a la Información del Conductor, la Unidad, la Empresa y la Cuenta
		/// determina si el contrato al que estaría asociado el pago se ecuentra Vigente.
		/// En caso de que el contrato no este vigente, solicita confirmación del usuario.
		/// </summary>
		/// <returns>true: si se desea aplicar el pago. false: en caso contrario</returns>
		private bool ValidarVigenciaContrato()
		{
			bool show_msg = true;
			DialogResult respuesta = DialogResult.Yes;

			Entities.AdeudosDeConductor adeudos_cond = (Entities.AdeudosDeConductor)adeudosDeConductorBindingSource.Current;
			Entities.DatosConductorUnidad datos_cond_unidad = (Entities.DatosConductorUnidad)datosConductorBindingSource.Current;
			List<Entities.Vista_EstatusContrato> lEstatusContratos = Entities.Vista_EstatusContrato.Get(datos_cond_unidad.Conductor_ID, adeudos_cond.Empresa_ID, datos_cond_unidad.Unidad_ID, adeudos_cond.Cuenta_ID);
			show_msg = lEstatusContratos.Count > 0;

			if (show_msg)
			{
				show_msg = lEstatusContratos[0].EstatusContrato_ID != 1;
			}

			if (show_msg)
			{
				string msg = String.Format("El contrato #{0} se encuentra {1}\n\rAsegurese que desea realizar el pago a la Cuenta {2} de la Empresa {3} en lugar de a la cuenta vigente.", lEstatusContratos[0].Contrato_ID, lEstatusContratos[0].Nombre, adeudos_cond.Cuenta, adeudos_cond.Empresa);
				respuesta = MessageBox.Show(msg, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			}

			return respuesta == DialogResult.Yes;
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
				//  Si se tecleo enter
				if (e.KeyData == Keys.Enter)
				{
                    // Resguardo Parcial
                    // Se obtiene el monto Sugerido para la estacion                    
                    if (Sesion.Estacion_ID != 0 && Sesion.Estacion_ID != null)
                    {
                        resguardoParcialForm();
                    }

					//  Si hay datos en la caja de texto de unidad
					if (!string.IsNullOrEmpty(UnidadTextBox.Text))
					{
						//  Si los datos son numéricos
						if (AppHelper.IsNumeric(UnidadTextBox.Text))
						{
							//  Ligamos los datos de adeudos
							this.AdeudosGridView.DataSource = this.adeudosDeConductorBindingSource;

							//  unidad es el número economico,
							//  unidades es la cantidad de unidades que tienen el mismo número económico
							int unidad, unidades;

							unidad = Convert.ToInt32(UnidadTextBox.Text);

							unidades = Entities.DatosConductorUnidad.GetNumeroUnidades(unidad);

							//  Si no hay unidades
							if (unidades == 0)
							{
								//  Entonces no está asignada
								throw new Exception(string.Format("Unidad {0} no esta asignada", unidad));
							}
							else if (unidades == 1) // Si hay una unidad
							{
								//  Se obtienen los datos de la misma
								ObtenerDatosDeUnidad(unidad);
							}
							else // Si hay mas de una unidad
							{
								//  Mostramos una lista para selección
								SeleccionarUnidadConductor seleccionarUnidadForm = new SeleccionarUnidadConductor();
								seleccionarUnidadForm.GetUnidades(unidad);

								//  Si se selecciona una
								if (seleccionarUnidadForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
								{
									//  Obtenemos los datos del conductor de la unidad seleccionada
									ObtenerDatosDeConductor(seleccionarUnidadForm.DatosConductor.Conductor_ID);
								}
								else // Si no
								{
									//  Enviamos error
									throw new Exception("Debe seleccionar una unidad");
								}
							}
						}
						else // Si los datos no son numéricos
						{
							//  Lanzamos excepción
							throw new Exception("Debe teclar datos numéricos");
						} // end else

					} // end if    

				} // end if

			} // end try
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Al oprimir "Enter" en la caja de texto "ValePrepagado"
		/// este se agrega a la lista actual de vales por cobrar
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
			dgvValesEmpresariales.DataSource = null;
			this.Operacion = new Entities.OperacionCaja();
			this.valesPrepagadosBindingSource.DataSource = null;
			this.planillasFiscalesBindingSource.DataSource = null;
			this.Vales.Clear();
			this.ValesEmpresariales.Clear();
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
			bool imprimeTicket = false;

			//  Si se oprimió enter
			if (e.KeyData == Keys.Enter)
			{
                // Activacion de Resguardo Parcial
                if (Sesion.Estacion_ID != 0 && Sesion.Estacion_ID != null)
                {
                    resguardoParcialForm();
                }

				//ToDo - Validar si conductor tiene pagos realizados recientemente
				// Valida si exite un cobro al conductor en un periodo determinado
				//string smensaje = Entities.Conductores.TienePagosRecientes(DatosConductor.Conductor_ID);
				//if (smensaje.Length > 0)
				//{
				//     if (AppHelper.Confirm(smensaje) != System.Windows.Forms.DialogResult.Yes)
				//          return;
				//}

				// Realiza las transacciones en la base de datos
				AppHelper.DoTransactions(
				    delegate
				    {
					    //  Actualiza el kilometraje
					    ActualizarKilometraje();

					    //  Calcula los totales
					    CalcularTotales();

					    //  Registra las operaciones
					    RegistrarOperaciones();

					    //Vamos a la base de datos para imprimir 
					    //todos los adeudos despues de haberse efecutado el pago
					    this.AgregarAdeudosImpresion();

					    imprimeTicket = true;
				    },
				    this
				);

                // Si se concluyen las transacciones Imprimr Tickets
				if (imprimeTicket)
				{
					AppHelper.DoMethod(
						delegate
						{ //  Imprime el ticket de pago

							ImprimirTicketPago();

							//  Limpia la forma
							this.Clear();

							//  Devuelve el foco a unidad
							this.UnidadTextBox.Focus();
						},
						this
					);
				}

                // Validar el monto de caja para guardar dinero en Caja Fuerte 
                // Requerimiento 26-10-2017


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
						if ((decimal)AdeudosGridView.CurrentCell.Value != 0 && !ValidarVigenciaContrato())
						{
							AdeudosGridView.CurrentCell.Value = (decimal)0.0;
						}
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

		private void KilometrajeActualTextBox_Leave(object sender, EventArgs e)
		{
			AppHelper.Try(
				 delegate
				 { ValidaKilometrajeRecorrido(); }
		    );
		}

		private void ValidaKilometrajeRecorrido()
		{
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text) && !string.IsNullOrEmpty(KilometrajeAnteriorTextBox.Text))
			{
				if (AppHelper.IsNumeric(KilometrajeActualTextBox.Text) && AppHelper.IsNumeric(KilometrajeAnteriorTextBox.Text))
				{
					int kmActual = Convert.ToInt32(this.KilometrajeActualTextBox.Text);
					int kmAnterior = Convert.ToInt32(this.KilometrajeAnteriorTextBox.Text.Replace(",", ""));
					if ((kmActual - kmAnterior) >= 400)
					{
						string msg = string.Format("Los Kilómetros recorridos desde el último pago son: {0} km", (kmActual - kmAnterior));
						MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private void AgregarValeEmpresarial(int folio, string serie, double monto)
		{
			//  Limpiamos la tablas
			dgvValesEmpresariales.DataSource = null;

			//  Validamos el vale
			Entities.ValesEmpresariales.Validar(serie, folio);

			//  Crear un nuevo vale
			KeyValuePair<string, object> a1 = new KeyValuePair<string, object>("serie", serie);
			KeyValuePair<string, object> a2 = new KeyValuePair<string, object>("folio", folio);
			Entities.ValesEmpresariales vale = Entities.ValesEmpresariales.Read(a1, a2);

			//  Verificar que no esté en lista
			if (CompararValeEmpresarial(vale, ValesEmpresariales))
			{
				dgvValesEmpresariales.DataSource = ValesEmpresariales;
				dgvValesEmpresariales.Refresh();
				throw new Exception("El vale empresarial ya se encuentra en la lista");
			}
			vale.Monto = (decimal)monto;
			//  Agregarlo a la lista
			ValesEmpresariales.Add(vale);

			//  Consultar totales
			CalcularTotales();

			//  Desplegar datos
			dgvValesEmpresariales.DataSource = ValesEmpresariales;
			dgvValesEmpresariales.Refresh();
		}

		private bool CompararValeEmpresarial(Entities.ValesEmpresariales vale, List<Entities.ValesEmpresariales> ValesEmpresariales)
		{
			foreach (Entities.ValesEmpresariales v in ValesEmpresariales)
			{
				if (v.ValeEmpresarial_ID == vale.ValeEmpresarial_ID)
				{
					return true;
				}
			}

			return false;
		}

		private void txtMontoVE_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				//  Si se oprimió "Enter"
				if (e.KeyData == Keys.Enter)
				{
					//  Si hay datos en la caja de texto
					if (!string.IsNullOrEmpty(txtMontoVE.Text) && !string.IsNullOrEmpty(txtSerieVE.Text) && !string.IsNullOrEmpty(txtFolioVE.Text))
					{
						//  Si los datos son numéricos
						if (AppHelper.IsNumeric(txtMontoVE.Text) && AppHelper.IsNumeric(txtFolioVE.Text))
						{
							//  Agregamos el vale
							AgregarValeEmpresarial(Convert.ToInt32(txtFolioVE.Text), txtSerieVE.Text, Convert.ToDouble(txtMontoVE.Text));

							//  Limpiamos las cajas de texto
							txtFolioVE.Text = string.Empty;
							txtSerieVE.Text = string.Empty;
							txtMontoVE.Text = string.Empty;
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

		private void dgvValesEmpresariales_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				// Eliminar vale empresarial de lista
				if (dgvValesEmpresariales.Columns[e.ColumnIndex].Name == "EliminarValeEmpresarial")
				{
					Entities.ValesEmpresariales vale = (Entities.ValesEmpresariales)dgvValesEmpresariales.Rows[e.RowIndex].DataBoundItem;
					EliminarValeEmpresariales(vale);
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void EliminarValeEmpresariales(Entities.ValesEmpresariales vale)
		{
			dgvValesEmpresariales.DataSource = null;
			ValesEmpresariales.Remove(vale);
			CalcularTotales();
			if (ValesEmpresariales.Count > 0)
			{
				dgvValesEmpresariales.DataSource = ValesEmpresariales;
				dgvValesEmpresariales.Refresh();
			}
		}

        /// <summary>
        /// Aqui se llama al formulario para resguardos de caja en caso de que exiata monto sugerido.
        /// </summary>
        private void resguardoParcialForm()
        {
            try
            {
                Decimal resguadoPendiente = Entities.Cajas_ResguardoEfectivoSesion.ReadMontoPendienteResguardoSesion(Sesion.Sesion_ID, Convert.ToInt32(Sesion.Estacion_ID));
                Entities.Cajas_ResguardoEfectivoEstaciones montoResguardoEstacion = Entities.Cajas_ResguardoEfectivoEstaciones.Read(Convert.ToInt16(Sesion.Estacion_ID));
                if (montoResguardoEstacion.MontoResguardo > 0)
                {
                    if (resguadoPendiente > montoResguardoEstacion.MontoResguardo)
                    {
                        SICASv20.forms.caja.ResguardoEfectivoParcial resguardo = new SICASv20.forms.caja.ResguardoEfectivoParcial();
                        resguardo.TopMost = true;
                        resguardo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        resguardo.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                //AppHelper.Error(ex.Message);
            }
        }

		#endregion
		
	} // En class
} // End namespace