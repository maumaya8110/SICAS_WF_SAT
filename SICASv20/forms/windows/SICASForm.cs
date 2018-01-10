/*
 * SICASForm
 * Formulario contenedor
 * SICASv20.forms.SICASForm
 * Codificado por Luis Espino
 * Ultima Revision 2012-08-08
 * 
 * **  HISTORIAL  **
 *      2012-10-27, Modificado por Luis Espino
 *          Se incluyó la función de buscar el permiso para "ConductoresOperativos"
 *          y mostrar la pantalla de "LicenciasPorVencer"
 *          Luego se eliminaron estas funciones y se le agregaron a "blankForm"
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario principal de SICAS, hereda de containerForm,
	/// contiene todos los formularios ha utilizar en el sistema
	/// </summary>
	public partial class SICASForm : containerForm
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SICASForm()
		{
			InitializeComponent();

			//  Configuramos el tamaño del panel
			SetPanelSize();

			//  Cargamos los formularios del sistema
			CargarFormularios();

			//  Verificamos si estamos en ambiente de pruebas
			if (Sesion.EsPrueba)
			{
				//  Si es así, cambiamos el titulo de la aplicación
				//  y su color de fondo
				this.Text = "||**** APLICACION DE PRUEBA DE SICAS ****|| " + AppHelper.Version;
				this.Color1 = Color.Green;
			}

			//  Agregamos el número de versión a la barra de título
			this.Text += " Versión " + AppHelper.Version;

			//  Configuramos las opciones que estarán disponibles
			SetMenuOptions();
		}

		/// <summary>
		/// El formulario de licencias vencidas
		/// </summary>
		private forms.LicenciasPorVencer LicenciasForm = null;

		/// <summary>
		/// Modela las funcionalidades de los permisos de usuario
		/// </summary>
		public class PermisosDeUsuario_Model
		{
			private List<Entities.Vista_PermisosUsuarios> _Permisos;

			/// <summary>
			/// Lista de Permisos
			/// </summary>
			public List<Entities.Vista_PermisosUsuarios> Permisos
			{
				get { return _Permisos; }
				set { _Permisos = value; }
			}

			//  Datatable para los permisos
			private DataTable _PermisosTable;

			private string _Usuario_ID;

			/// <summary>
			/// El ID de usuario actual del sistema
			/// </summary>
			public string Usuario_ID
			{
				get { return _Usuario_ID; }
				set { _Usuario_ID = value; }
			}

			private int _Modulo_ID;

			/// <summary>
			/// Almacena el modulo actual
			/// </summary>
			public int Modulo_ID
			{
				get { return _Modulo_ID; }
				set { _Modulo_ID = value; }
			}

			private int _Menu_ID;

			/// <summary>
			/// Almacena el menu actual
			/// </summary>
			public int Menu_ID
			{
				get { return _Menu_ID; }
				set { _Menu_ID = value; }
			}

			private List<Entities.Modulos> _Modulos;

			/// <summary>
			/// La lista de Modulos
			/// </summary>
			public List<Entities.Modulos> Modulos
			{
				get { return _Modulos; }
				set { _Modulos = value; }
			}

			private List<Entities.Menues> _Menues;

			/// <summary>
			/// La lista de Menues
			/// </summary>
			public List<Entities.Menues> Menues
			{
				get { return _Menues; }
				set { _Menues = value; }
			}

			/// <summary>
			/// Consulta los permisos del usuario en la base de datos
			/// </summary>
			public void ConsultarPermisos()
			{
				this._PermisosTable = Entities.Vista_PermisosUsuarios.GetDataTable(this.Usuario_ID);
			}

			/// <summary>
			/// Consulta los Moudlos de los permisos del usuario
			/// </summary>
			public void ConsultarModulos()
			{
				//  Instanciamos la lista de modulos
				this.Modulos = new List<Entities.Modulos>();

				//  Filtramos los resultados
				//  y los asignamos en una nueva datatable
				DataTable distinctDataTable =
				    _PermisosTable.DefaultView.ToTable(
					   true,
					   "Modulo_ID",
					   "Modulo"
				    );

				//  Los cargamos en la lista
				foreach (DataRow dr in distinctDataTable.Rows)
				{
					this.Modulos.Add(
					    new Entities.Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Modulo"]))
					);
				}
			}

			/// <summary>
			/// Consulta los Menus de los permisos del usuario
			/// </summary>
			public void ConsultarMenues()
			{
				//  Instanciamos la lista
				this.Menues = new List<Entities.Menues>();

				//  Filtramos los resultados en un arreglo de DataRows
				DataRow[] drMenues =
				    _PermisosTable.DefaultView.ToTable(
					   true,
					   "Modulo_ID",
					   "Menu_ID",
					   "Menu").Select(
						  string.Format(
							 "Modulo_ID = {0}",
							 this.Modulo_ID
						  )
					   );

				//  Los cargamos a la lista
				foreach (DataRow dr in drMenues)
				{
					this.Menues.Add(
					    new Entities.Menues(
						   Convert.ToInt32(dr["Menu_ID"]),
						   this.Modulo_ID,
						   Convert.ToString(dr["Menu"]),
						   ""
					    )
					);
				}
			}

			/// <summary>
			/// Consultamos las opciones de los permisos del usuario
			/// </summary>
			public void ConsultarPermisosOpciones()
			{
				//  Instanciamos la lista
				this.Permisos = new List<Entities.Vista_PermisosUsuarios>();

				//  Filtramos los permisos
				//  en una arreglo de DataRows
				DataRow[] drPermisos =
				    _PermisosTable.Select(
					   string.Format(
						  "Menu_ID = {0}",
						  this.Menu_ID
					   )
				    );

				//  Los cargamos a la lista
				foreach (DataRow dr in drPermisos)
				{
					this.Permisos.Add(
					    new Entities.Vista_PermisosUsuarios(
						   DB.GetNullableInt32(dr["Modulo_ID"]),
						   Convert.ToString(dr["Modulo"]),
						   DB.GetNullableInt32(dr["Menu_ID"]),
						   Convert.ToString(dr["Menu"]),
						   DB.GetNullableInt32(dr["Opcion_ID"]),
						   Convert.ToString(dr["Opcion"]),
						   Convert.ToString(dr["Usuario_ID"]),
						   DB.GetNullableBoolean(dr["EsPermitido"]),
						   Convert.ToString(dr["OpcionTexto"]),
						   Convert.ToString(dr["OpcionImagen"]),
						   DB.GetNullableBoolean(dr["EsHerramienta"]),
						   DB.GetNullableBoolean(dr["EsActivo"])
					    )
					);
				} // end foreach
			} // end void            
		} // end class

		private string _currentForm;

		/// <summary>
		/// Cadena que representa el nombre del formulario actual del sistema
		/// </summary>
		public string CurrentForm
		{
			get { return _currentForm; }
			set { _currentForm = value; }
		}


		private string _prevForm;

		/// <summary>
		/// Cadena que representa el nombre del formulario anterior del sistema
		/// </summary>
		public string PrevForm
		{
			get { return _prevForm; }
			set { _prevForm = value; }
		}

		public PermisosDeUsuario_Model Model;

		/// <summary>
		/// Instancia un Diccionario para los Menues
		/// </summary>
		private Dictionary<string, MenuStrip> Menues = new Dictionary<string, MenuStrip>();

		/// <summary>
		/// Instanciamos un Diccionario para las barras de herramientas
		/// </summary>
		private Dictionary<string, ToolStrip> ToolBars = new Dictionary<string, ToolStrip>();

		/// <summary>
		/// Instanciamos un Diccionario para los formularios
		/// </summary>
		private Dictionary<string, forms.baseForm> formularios = new Dictionary<string, forms.baseForm>();

		/// <summary>
		/// Variable Enumerable que contiene los objetos Fomulario en el sistema
		/// </summary>
		private AppHelper.Formularios formas = new AppHelper.Formularios();

		/// <summary>
		/// Contiene el nombre del Módulo activo en el sistema
		/// </summary>
		private string ModuloActivo;

		#region Forms Declaration

		//  Aqui declaramos todos los formularios a utilizar en el sistema
		forms.blankForm blankForm = null;
		forms.Arrendamientos arrendamientos = null;
		forms.ClasesPublicidad clasesPublicidad = null;
		forms.Concesiones concesiones = null;
		forms.Conductores conductores = null;
		forms.Empresas empresas = null;
		forms.Estaciones estaciones = null;
		forms.EstatusConductores estatusConductores = null;
		forms.EstatusFinancieros estatusFinancieros = null;
		forms.EstatusUnidades estatusUnidades = null;
		forms.LocacionesUnidades locacionesUnidades = null;
		forms.MarcasUnidades marcasUnidades = null;
		forms.MediosPublicitarios mediosPublicitarios = null;
		forms.Mercados mercados = null;
		forms.ModelosUnidades modelosUnidades = null;
		forms.TiposConcesiones tiposConcesiones = null;
		forms.TiposEmpresas tiposEmpresas = null;
		forms.Unidades unidades = null;
		forms.ReporteSaldosCuentasConductores reporteSaldosCuentasConductores = null;
		forms.AltaConductor altaConductor = null;
		forms.AltaContrato altaContrato = null;
		forms.AltaArrendamiento altaArrendamiento = null;
		forms.Contratos contratos = null;
		forms.AltaUnidad altaUnidad = null;
		forms.ActualizacionContrato actualizacionContrato = null;
		forms.ActualizacionUnidad actualizacionUnidad = null;
		forms.ReporteFlotilla reporteFlotilla = null;
		forms.ReporteLocaciones reporteLocaciones = null;
		forms.ReporteSaldosCuentasUnidades reporteSaldosCuentasUnidades = null;
		forms.ReporteIndicadoresUnidades reporteIndicadoresUnidades = null;
		forms.ActualizacionConductor actualizacionConductor = null;
		forms.ReporteEstadoCuentaConductor reporteEstadoCuentaConductor = null;
		forms.LicenciasVencidas licenciasVencidas = null;
		forms.ReporteTicketsDeSesion reporteTicketsDeSesion = null;
		forms.CancelacionTickets cancelacionTickets = null;
		forms.AltaCuentaConductores altaCuentaConductores = null;
		forms.Usuarios usuarios = null;
		forms.AltaUsuario altaUsuario = null;
		forms.ActualizacionUsuario actualizacionUsuario = null;
		forms.ReporteFlujoDeCajaSesion reporteFlujoDeCajaSesion = null;
		forms.ReporteRecaudacionCajaSesion reporteRecaudacionCajaSesion = null;
		forms.Modulos modulos = null;
		forms.Menues menues = null;
		forms.Opciones opciones = null;
		forms.AltaOpcion altaOpcion = null;
		forms.ActualizacionOpcion actualizacionOpcion = null;
		forms.CobranzaAtencionYControl cobranzaAtencionYControl = null;
		forms.ActualizacionArrendamiento actualizacionArrendamiento = null;
		forms.VentaServicios ventaServicios = null;
		forms.ComisionesServicios comisionesServicios = null;
		forms.ReporteCorteDeVentas reporteCorteDeVentas = null;
		forms.AltaComisionServicio altaComisionServicio = null;
		forms.ActualizacionComisionServicio actualizacionComisionServicio = null;
		forms.AsignacionServicios asignacionServicios = null;
		forms.IngresosEgresosCajasPorFechas ingresosEgresosCajasPorFechas = null;
		forms.AltaFamilia altaFamilia = null;
		forms.Familias familias = null;
		forms.ActualizacionFamilia actualizacionFamilia = null;
		forms.ServiciosMantenimientos serviciosMantenimientos = null;
		forms.AltaServiciosMantenimientos altaServiciosMantenimientos = null;
		forms.ActualizacionServiciosMantenimientos actualizacionServiciosMantenimientos = null;
		forms.CategoriasMecanicos categoriasMecanicos = null;
		forms.AltaCategoriasMecanicos altaCategoriasMecanicos = null;
		forms.ActualizacionCategoriasMecanicos actualizacionCategoriasMecanicos = null;
		forms.Mecanicos mecanicos = null;
		forms.AltaMecanicos altaMecanicos = null;
		forms.ActualizacionMecanicos actualizacionMecanicos = null;
		forms.TiposMantenimientos tiposMantenimientos = null;
		forms.AltaTiposMantenimientos altaTiposMantenimientos = null;
		forms.ActualizacionTiposMantenimientos actualizacionTiposMantenimientos = null;
		forms.Refacciones refacciones = null;
		forms.AltaRefacciones altaRefacciones = null;
		forms.ActualizacionRefacciones actualizacionRefacciones = null;
		forms.OrdenesTrabajos ordenesTrabajos = null;
		forms.ReporteDeVentasTaller reporteDeVentasTaller = null;
		forms.ReporteDeVentasRefaccionesTaller reporteDeVentasRefaccionesTaller = null;
		forms.NuevaOrdenTrabajo nuevaOrdenTrabajo = null;
		forms.MonitorDeRentas monitorDeRentas = null;
		forms.Cuentas cuentas = null;
		forms.Conceptos conceptos = null;
		forms.Empresas_Cuentas empresas_Cuentas = null;
		forms.AsistenteContratos asistenteContratos = null;
		forms.AltaOrdenCompra altaOrdenCompra = null;
		forms.EntradaInventario entradaInventario = null;
		forms.SalidaInventario salidaInventario = null;
		forms.CajaDeCobro cajaDeCobro = null;
		forms.Zonas zonas = null;
		forms.AltaZonas altaZonas = null;
		forms.Tarifas tarifas = null;
		forms.AltaTarifas altaTarifas = null;
		forms.ActualizacionZonas actualizacionZonas = null;
		forms.ActualizacionTarifas actualizacionTarifas = null;
		forms.SICASTestLauncher sICASTestLauncher = null;
		forms.CambioContraseña cambioContraseña = null;
		forms.CambioLocacion cambioLocacion = null;
		forms.AltaValesPrepagados altaValesPrepagados = null;
		forms.AltaPlanillasFiscales altaPlanillasFiscales = null;
		forms.CancelacionesOrdenesTrabajos cancelacionesOrdenesTrabajos = null;
		forms.OrdenesComprasCanceladas ordenesComprasCanceladas = null;
		forms.VentaComisionada ventaComisionada = null;
		forms.VentaRegresos ventaRegresos = null;
		forms.VentaServiciosConductor ventaServiciosConductor = null;
		forms.ReporteDeVentasTotales reporteDeVentasTotales = null;
		forms.ReporteCorteCajaCobro reporteCorteCajaCobro = null;
		forms.CajaCobroOrdenesTrabajos cajaCobroOrdenesTrabajos = null;
		forms.ReimprimirTickets reimprimirTickets = null;
		forms.ReporteOrdenesTrabajoCobradasCaja reporteOrdenesTrabajoCobradasCaja = null;
		forms.ReportePlanillasVendidas reportePlanillasVendidas = null;
		forms.ReporteUnidadesConductoresActuales reporteUnidadesConductoresActuales = null;
		forms.AsistenteContratosRenta asistenteContratosRenta = null;
		forms.ReporteUnidadesKilometrajes reporteUnidadesKilometrajes = null;
		forms.ReporteRecaudacionPorEstacion reporteRecaudacionPorEstacion = null;
		forms.PlanesDeRenta planesDeRenta = null;
		forms.AltaPlanesDeRenta altaPlanesDeRenta = null;
		forms.ActualizacionPlanesDeRenta actualizacionPlanesDeRenta = null;
		forms.ContratosRenta contratosRenta = null;
		forms.AltaContratoRenta altaContratoRenta = null;
		forms.ActualizacionContratoRenta actualizacionContratoRenta = null;
		forms.TerminacionContrato terminacionContrato = null;
		forms.ContratosLiquidados contratosLiquidados = null;
		forms.ReporteTicketsEstacion reporteTicketsEstacion = null;
		forms.OrdenesCompras ordenesCompras = null;
		forms.ComprasConsolidado comprasConsolidado = null;
		forms.VentasConsolidado ventasConsolidado = null;
		forms.ReporteConsumoCostoDia reporteConsumoCostoDia = null;
		forms.ReporteConsumosConsolidados reporteConsumosConsolidados = null;
		forms.ReportePreciosServiciosMantenimientos reportePreciosServiciosMantenimientos = null;
		forms.AjusteInventario ajusteInventario = null;
		forms.ReporteAjustesInventario reporteAjustesInventario = null;
		forms.ReporteMovimientosInventario reporteMovimientosInventario = null;
		forms.OrdenesTrabajoAbiertas ordenesTrabajoAbiertas = null;
		forms.DevolucionOrdenTrabajo devolucionOrdenTrabajo = null;
		forms.DevolucionOrdenCompra devolucionOrdenCompra = null;
		forms.CancelacionOrdenesTrabajos cancelacionOrdenesTrabajos = null;
		forms.CancelacionOrdenesCompras cancelacionOrdenesCompras = null;
		forms.TerminacionOrdenesTrabajo terminacionOrdenesTrabajo = null;
		forms.ActualizacionOrdenesCompras actualizacionOrdenesCompras = null;
		forms.AltaEmpresa altaEmpresa = null;
		forms.ActualizacionEmpresa actualizacionEmpresa = null;
		forms.ReporteInventario reporteInventario = null;
		forms.AltaEstaciones altaEstaciones = null;
		forms.ActualizacionEstaciones actualizacionEstaciones = null;
		forms.ServiciosVendidos serviciosVendidos = null;
		forms.ReportePublicitarioConsolidado reportePublicitarioConsolidado = null;
		forms.ReporteHistorialCobranzaConductor reporteHistorialCobranzaConductor = null;
		forms.GruposUsuarios gruposUsuarios = null;
		forms.ActualizacionPermisosGruposUsuarios actualizacionPermisosGruposUsuarios = null;
		forms.Manuales manuales = null;
		forms.RentasCobradasDiarias rentasCobradasDiarias = null;
		forms.ReporteRegistroSolicitantesForm reporteRegistroSolicitantes = null;
		forms.ReportePlanillasVendidasCajas reportePlanillasVendidasCajas = null;
		forms.SeleccionarEstacion seleccionarEstacion = null;
		forms.ServiciosMantenimientosPrecios serviciosMantenimientosPrecios = null;
		forms.ServiciosMantenimientosTiposRefacciones serviciosMantenimientosTiposRefacciones = null;
		forms.OrdenesTrabajosClientes ordenesTrabajosClientes = null;
		forms.ReporteDeVentasTallerClientes reporteDeVentasTallerClientes = null;
		forms.ReimprimirOrdenesCompras reimprimirOrdenesCompras = null;
		forms.CancelacionValesPrepagados cancelacionValesPrepagados = null;
		forms.ReporteValesPrepagados reporteValesPrepagados = null;
		forms.CortesDeVentas cortesDeVentas = null;
		forms.CajaDeServicios cajaDeServicios = null;
		forms.CajaCobro cajaCobro = null;
		forms.AltaFlujoCaja altaFlujoCaja = null;
		forms.UnidadesConductoresOperativos unidadesConductoresOperativos = null;
		forms.AltaTiposRefacciones altaTiposRefacciones = null;
		forms.TiposRefacciones tiposRefacciones = null;
		forms.ActualizacionTiposRefacciones actualizacionTiposRefacciones = null;
		forms.ImpresionVentaLoteServicios impresionVentaLoteServicios = null;
		forms.ReporteTicketsEmpresa reporteTicketsEmpresa = null;
		forms.ConfiguracionesDeCaja configuracionesDeCaja = null;
		forms.CancelarServicio cancelarServicio = null;
		forms.VentaServiciosPersonalizada ventaServiciosPersonalizada = null;
		forms.VerificacionBoletos verificacionBoletos = null;
		forms.BitacoraUnidadesLauncher bitacoraUnidadesLauncher = null;
		forms.ReporteServiciosPagadosPorModelo reporteServiciosPagadosPorModelo = null;
		forms.ReporteMovimientosFlujoDeCajaSesion reporteMovimientosFlujoDeCajaSesion = null;
		forms.ReporteMovimientosRecaudacionSesion reporteMovimientosRecaudacionSesion = null;
		forms.ReporteServiciosRegresos reporteServiciosRegresos = null;
		forms.ReporteMovimientosRecaudacionPorFechas reporteMovimientosRecaudacionPorFechas = null;
		forms.PermisosCajasUsuarios permisosCajasUsuarios = null;
		forms.Cajas cajas = null;
		forms.AltaCajas altaCajas = null;
		forms.ActualizacionCajas actualizacionCajas = null;
		forms.ReporteCargosAjustesConductor reporteCargosAjustes = null;
		forms.CargoCuentaConductores cargoCuentaConductores = null;
		forms.AjusteCuentaConductores ajusteCuentaConductores = null;
		forms.ReporteIngresosEmpresas reporteIngresosEmpresas = null;
		forms.ReporteProductividadServicios reporteProductividadServicios = null;
		forms.ReporteRecaudacionPorEmpresa reporteRecaudacionPorEmpresa = null;
		forms.AltaCuentaUnidades altaCuentaUnidades = null;
		//forms.AltaAtencionClientes altaAtencionClientes = null;
		forms.ConductoresOperativos conductoresOperativos = null;
		forms.ReporteRecaudacion reporteRecaudacion = null;
		forms.ReporteKilometrajesPromedio reporteKilometrajesPromedio = null;
		forms.ReporteHistorialUnidadesConductores reporteHistorialUnidadesConductores = null;
		forms.ReporteKilometrajesMantenimientos reporteKilometrajesMantenimientos = null;
		forms.VentaEmpresarial ventaEmpresarial = null;
		/*
		 * Actualización, 8 de Mayo de 2013
		 * Modificado por Luis Espino
		 * 
		 * Agregamos el formulario LicenciasPorVencerLauncher
		 */
		forms.LicenciasPorVencerLauncher licenciasPorVencerLauncher = null;
		forms.AsignacionSeries asignacionSeries = null;
		forms.ListadoEdicionUnidades listadoEdicionUnidades = null;
		forms.Adendums adendums = null;
		forms.ReporteAdendums reporteAdendums = null;
		forms.TarifasEdicion tarifasEdicion = null;
		forms.aeropuerto.herramientas.Programacion programacion = null;
		forms.aeropuerto.herramientas.BuscaRegresos BuscarRegresos = null;

		forms.AjusteCuentaConductorNomina AjustesConductoresNomina = null;
		forms.CargoCuentaConductorNomina CargoCuentaConductorNomina = null;
		forms.ReporteProductividadNomina ReporteProductividadNomina = null;

		forms.aeropuerto.nomina.ConductoresTipoNominaPeriodo ConductoresTipoNominaPeriodo = null;
		forms.aeropuerto.nomina.ReporteNominaCAT ReportenominaCAT = null;
		forms.aeropuerto.nomina.CapturaIncidenciasConductores CapturaIncidenciasConductores = null;
		forms.aeropuerto.nomina.CapturaBoletosporPeriodo CapturaBoletosPorPeriodo = null;
		forms.aeropuerto.nomina.CapturaBoletosTiempoExtra CapturaBoletosTiempoExtra = null;
		forms.aeropuerto.nomina.QuitaBoletosAConductor QuitaBoletosAConductor = null;
		forms.aeropuerto.nomina.QuitaBoletosTiempoExtraAConductor QuitaBoletosTiempoExtraAConductor = null;
		forms.aeropuerto.nomina.ConsultaConvenios ConsultaConvenios = null;
		forms.aeropuerto.nomina.CapturaConvenio CapturaConvenio = null;

		forms.empresas.equiposgas.ConsultarConductoresEquiposGas ConsultarConductoresEquiposGas = null;
		forms.empresas.equiposgas.EquiposGas EquiposGas = null;
		forms.empresas.equiposgas.ProveedoresEquipoGas ProveedoresEquipoGas = null;
		forms.empresas.equiposgas.CatalogoEquipos CatalogoEquipos = null;

		forms.abastos.archivo.Proveedores Proveedores = null;
		forms.abastos.archivo.Servicios Servicios = null;
		forms.abastos.ManttoVehicular.OrdenesDeTrabajo OrdenesDeTrabajo = null;
		forms.abastos.ManttoVehicular.ListadoMantenimientos ListadoMantenimientos = null;
		forms.abastos.ManttoVehicular.Semaforizacion Semaforizacion = null;
		forms.abastos.ManttoVehicular.Plantillas Plantillas = null;
		forms.abastos.ManttoVehicular.AsociaServiciosModeloUnidad AsociaServiciosModeloUnidad = null;

		forms.callcenter.valesempresariales.ValesEmpresariales ReporteValesEmpresariales = null;

		forms.caja.reportes.ArqueoDeCajaMetropolitano ArqueoDeCajaMetropolitano = null;
		forms.caja.reportes.ArqueoDeCajaApto ArqueoDeCajaApto = null;

		forms.empresas.documentos.Digitalizados ConcesionesD = null;
		forms.empresas.documentos.Digitalizados ConveniosD = null;
		forms.empresas.documentos.Digitalizados ContratosD = null;
		forms.empresas.documentos.Digitalizados PolizasD = null;
		forms.empresas.documentos.Digitalizados ActasAdministrativasD = null;

		forms.caja.herramientas.CanjeDeVales CanjeDeVales = null;
		forms.caja.herramientas.ReimpresionDeclaracionCorteCaja ReimpresionDeclaracionCorteCaja = null;
		#endregion

		#region Carga de formularios

		/// <summary>
		/// Carga todos los objetos AppHelper.Formulario que se utilizarán en el sistema
		/// </summary>
		private void CargarFormularios()
		{
			//  Realizamos la inserción de todos los objetos formularios que utilizaremos en el sistema
			//  Utilizaremos los formularios declarados previamente
			formas.Add(new AppHelper.Formulario("Arrendamientos", arrendamientos, "SICASv20.forms.Arrendamientos"));
			formas.Add(new AppHelper.Formulario("ClasesPublicidad", clasesPublicidad, "SICASv20.forms.ClasesPublicidad"));
			formas.Add(new AppHelper.Formulario("Concesiones", concesiones, "SICASv20.forms.Concesiones"));
			formas.Add(new AppHelper.Formulario("Conductores", conductores, "SICASv20.forms.Conductores"));
			formas.Add(new AppHelper.Formulario("Empresas", empresas, "SICASv20.forms.Empresas"));
			formas.Add(new AppHelper.Formulario("Estaciones", estaciones, "SICASv20.forms.Estaciones"));
			formas.Add(new AppHelper.Formulario("EstatusConductores", estatusConductores, "SICASv20.forms.EstatusConductores"));
			formas.Add(new AppHelper.Formulario("EstatusFinancieros", estatusFinancieros, "SICASv20.forms.EstatusFinancieros"));
			formas.Add(new AppHelper.Formulario("EstatusUnidades", estatusUnidades, "SICASv20.forms.EstatusUnidades"));
			formas.Add(new AppHelper.Formulario("LocacionesUnidades", locacionesUnidades, "SICASv20.forms.LocacionesUnidades"));
			formas.Add(new AppHelper.Formulario("MarcasUnidades", marcasUnidades, "SICASv20.forms.MarcasUnidades"));
			formas.Add(new AppHelper.Formulario("MediosPublicitarios", mediosPublicitarios, "SICASv20.forms.MediosPublicitarios"));
			formas.Add(new AppHelper.Formulario("Mercados", mercados, "SICASv20.forms.Mercados"));
			formas.Add(new AppHelper.Formulario("ModelosUnidades", modelosUnidades, "SICASv20.forms.ModelosUnidades"));
			formas.Add(new AppHelper.Formulario("TiposConcesiones", tiposConcesiones, "SICASv20.forms.TiposConcesiones"));
			formas.Add(new AppHelper.Formulario("TiposEmpresas", tiposEmpresas, "SICASv20.forms.TiposEmpresas"));
			formas.Add(new AppHelper.Formulario("Unidades", unidades, "SICASv20.forms.Unidades"));
			formas.Add(new AppHelper.Formulario("ReporteSaldosCuentasConductores", reporteSaldosCuentasConductores, "SICASv20.forms.ReporteSaldosCuentasConductores"));
			formas.Add(new AppHelper.Formulario("AltaContrato", altaContrato, "SICASv20.forms.AltaContrato"));
			formas.Add(new AppHelper.Formulario("AltaConductor", altaConductor, "SICASv20.forms.AltaConductor"));
			formas.Add(new AppHelper.Formulario("AltaArrendamiento", altaArrendamiento, "SICASv20.forms.AltaArrendamiento"));
			formas.Add(new AppHelper.Formulario("Contratos", contratos, "SICASv20.forms.Contratos"));
			formas.Add(new AppHelper.Formulario("AltaUnidad", altaUnidad, "SICASv20.forms.AltaUnidad"));
			formas.Add(new AppHelper.Formulario("BlankForm", blankForm, "SICASv20.forms.blankForm"));
			formas.Add(new AppHelper.Formulario("ActualizacionContrato", actualizacionContrato, "SICASv20.forms.ActualizacionContrato"));
			formas.Add(new AppHelper.Formulario("ActualizacionUnidad", actualizacionUnidad, "SICASv20.forms.ActualizacionUnidad"));
			formas.Add(new AppHelper.Formulario("ReporteFlotilla", reporteFlotilla, "SICASv20.forms.ReporteFlotilla"));
			formas.Add(new AppHelper.Formulario("ReporteLocaciones", reporteLocaciones, "SICASv20.forms.ReporteLocaciones"));
			formas.Add(new AppHelper.Formulario("ReporteSaldosCuentasUnidades", reporteSaldosCuentasUnidades, "SICASv20.forms.ReporteSaldosCuentasUnidades"));
			formas.Add(new AppHelper.Formulario("ReporteIndicadoresUnidades", reporteIndicadoresUnidades, "SICASv20.forms.ReporteIndicadoresUnidades"));
			formas.Add(new AppHelper.Formulario("ActualizacionConductor", actualizacionConductor, "SICASv20.forms.ActualizacionConductor"));
			formas.Add(new AppHelper.Formulario("ReporteEstadoCuentaConductor", reporteEstadoCuentaConductor, "SICASv20.forms.ReporteEstadoCuentaConductor"));
			formas.Add(new AppHelper.Formulario("LicenciasVencidas", licenciasVencidas, "SICASv20.forms.LicenciasVencidas"));
			formas.Add(new AppHelper.Formulario("ReporteTicketsDeSesion", reporteTicketsDeSesion, "SICASv20.forms.ReporteTicketsDeSesion"));
			formas.Add(new AppHelper.Formulario("CancelacionTickets", cancelacionTickets, "SICASv20.forms.CancelacionTickets"));
			formas.Add(new AppHelper.Formulario("AltaCuentaConductores", altaCuentaConductores, "SICASv20.forms.AltaCuentaConductores"));
			formas.Add(new AppHelper.Formulario("Usuarios", usuarios, "SICASv20.forms.Usuarios"));
			formas.Add(new AppHelper.Formulario("AltaUsuario", altaUsuario, "SICASv20.forms.AltaUsuario"));
			formas.Add(new AppHelper.Formulario("ActualizacionUsuario", actualizacionUsuario, "SICASv20.forms.ActualizacionUsuario"));
			formas.Add(new AppHelper.Formulario("ReporteFlujoDeCajaSesion", reporteFlujoDeCajaSesion, "SICASv20.forms.ReporteFlujoDeCajaSesion"));
			formas.Add(new AppHelper.Formulario("ReporteRecaudacionCajaSesion", reporteRecaudacionCajaSesion, "SICASv20.forms.ReporteRecaudacionCajaSesion"));
			formas.Add(new AppHelper.Formulario("Modulos", modulos, "SICASv20.forms.Modulos"));
			formas.Add(new AppHelper.Formulario("Menues", menues, "SICASv20.forms.Menues"));
			formas.Add(new AppHelper.Formulario("Opciones", opciones, "SICASv20.forms.Opciones"));
			formas.Add(new AppHelper.Formulario("AltaOpcion", altaOpcion, "SICASv20.forms.AltaOpcion"));
			formas.Add(new AppHelper.Formulario("ActualizacionOpcion", actualizacionOpcion, "SICASv20.forms.ActualizacionOpcion"));
			formas.Add(new AppHelper.Formulario("CobranzaAtencionYControl", cobranzaAtencionYControl, "SICASv20.forms.CobranzaAtencionYControl"));
			formas.Add(new AppHelper.Formulario("ActualizacionArrendamiento", actualizacionArrendamiento, "SICASv20.forms.ActualizacionArrendamiento"));
			formas.Add(new AppHelper.Formulario("VentaServicios", ventaServicios, "SICASv20.forms.VentaServicios"));
			formas.Add(new AppHelper.Formulario("ComisionesServicios", comisionesServicios, "SICASv20.forms.ComisionesServicios"));
			formas.Add(new AppHelper.Formulario("ReporteCorteDeVentas", reporteCorteDeVentas, "SICASv20.forms.ReporteCorteDeVentas"));
			formas.Add(new AppHelper.Formulario("AltaComisionServicio", altaComisionServicio, "SICASv20.forms.AltaComisionServicio"));
			formas.Add(new AppHelper.Formulario("ActualizacionComisionServicio", actualizacionComisionServicio, "SICASv20.forms.ActualizacionComisionServicio"));
			formas.Add(new AppHelper.Formulario("AsignacionServicios", asignacionServicios, "SICASv20.forms.AsignacionServicios"));
			formas.Add(new AppHelper.Formulario("IngresosEgresosCajasPorFechas", ingresosEgresosCajasPorFechas, "SICASv20.forms.IngresosEgresosCajasPorFechas"));
			formas.Add(new AppHelper.Formulario("AltaFamilia", altaFamilia, "SICASv20.forms.AltaFamilia"));
			formas.Add(new AppHelper.Formulario("Familias", familias, "SICASv20.forms.Familias"));
			formas.Add(new AppHelper.Formulario("ActualizacionFamilia", actualizacionFamilia, "SICASv20.forms.ActualizacionFamilia"));
			formas.Add(new AppHelper.Formulario("ServiciosMantenimientos", serviciosMantenimientos, "SICASv20.forms.ServiciosMantenimientos"));
			formas.Add(new AppHelper.Formulario("AltaServiciosMantenimientos", altaServiciosMantenimientos, "SICASv20.forms.AltaServiciosMantenimientos"));
			formas.Add(new AppHelper.Formulario("ActualizacionServiciosMantenimientos", actualizacionServiciosMantenimientos, "SICASv20.forms.ActualizacionServiciosMantenimientos"));
			formas.Add(new AppHelper.Formulario("CategoriasMecanicos", categoriasMecanicos, "SICASv20.forms.CategoriasMecanicos"));
			formas.Add(new AppHelper.Formulario("AltaCategoriasMecanicos", altaCategoriasMecanicos, "SICASv20.forms.AltaCategoriasMecanicos"));
			formas.Add(new AppHelper.Formulario("ActualizacionCategoriasMecanicos", actualizacionCategoriasMecanicos, "SICASv20.forms.ActualizacionCategoriasMecanicos"));
			formas.Add(new AppHelper.Formulario("Mecanicos", mecanicos, "SICASv20.forms.Mecanicos"));
			formas.Add(new AppHelper.Formulario("AltaMecanicos", altaMecanicos, "SICASv20.forms.AltaMecanicos"));
			formas.Add(new AppHelper.Formulario("ActualizacionMecanicos", actualizacionMecanicos, "SICASv20.forms.ActualizacionMecanicos"));
			formas.Add(new AppHelper.Formulario("Refacciones", refacciones, "SICASv20.forms.Refacciones"));
			formas.Add(new AppHelper.Formulario("AltaRefacciones", altaRefacciones, "SICASv20.forms.AltaRefacciones"));
			formas.Add(new AppHelper.Formulario("ActualizacionRefacciones", actualizacionRefacciones, "SICASv20.forms.ActualizacionRefacciones"));
			formas.Add(new AppHelper.Formulario("TiposMantenimientos", tiposMantenimientos, "SICASv20.forms.TiposMantenimientos"));
			formas.Add(new AppHelper.Formulario("AltaTiposMantenimientos", altaTiposMantenimientos, "SICASv20.forms.AltaTiposMantenimientos"));
			formas.Add(new AppHelper.Formulario("ActualizacionTiposMantenimientos", actualizacionTiposMantenimientos, "SICASv20.forms.ActualizacionTiposMantenimientos"));
			formas.Add(new AppHelper.Formulario("OrdenesTrabajos", ordenesTrabajos, "SICASv20.forms.OrdenesTrabajos"));
			formas.Add(new AppHelper.Formulario("ReporteDeVentasTaller", reporteDeVentasTaller, "SICASv20.forms.ReporteDeVentasTaller"));
			formas.Add(new AppHelper.Formulario("ReporteDeVentasRefaccionesTaller", reporteDeVentasRefaccionesTaller, "SICASv20.forms.ReporteDeVentasRefaccionesTaller"));
			formas.Add(new AppHelper.Formulario("NuevaOrdenTrabajo", nuevaOrdenTrabajo, "SICASv20.forms.NuevaOrdenTrabajo"));
			formas.Add(new AppHelper.Formulario("MonitorDeRentas", monitorDeRentas, "SICASv20.forms.MonitorDeRentas"));
			formas.Add(new AppHelper.Formulario("Cuentas", cuentas, "SICASv20.forms.Cuentas"));
			formas.Add(new AppHelper.Formulario("Conceptos", conceptos, "SICASv20.forms.Conceptos"));
			formas.Add(new AppHelper.Formulario("Empresas_Cuentas", empresas_Cuentas, "SICASv20.forms.Empresas_Cuentas"));
			formas.Add(new AppHelper.Formulario("AsistenteContratos", asistenteContratos, "SICASv20.forms.AsistenteContratos"));
			formas.Add(new AppHelper.Formulario("AltaOrdenCompra", altaOrdenCompra, "SICASv20.forms.AltaOrdenCompra"));
			formas.Add(new AppHelper.Formulario("EntradaInventario", entradaInventario, "SICASv20.forms.EntradaInventario"));
			formas.Add(new AppHelper.Formulario("SalidaInventario", salidaInventario, "SICASv20.forms.SalidaInventario"));
			formas.Add(new AppHelper.Formulario("CajaDeCobro", cajaDeCobro, "SICASv20.forms.CajaDeCobro"));
			formas.Add(new AppHelper.Formulario("Zonas", zonas, "SICASv20.forms.Zonas"));
			formas.Add(new AppHelper.Formulario("AltaZonas", altaZonas, "SICASv20.forms.AltaZonas"));
			formas.Add(new AppHelper.Formulario("ActualizacionZonas", actualizacionZonas, "SICASv20.forms.ActualizacionZonas"));
			formas.Add(new AppHelper.Formulario("Tarifas", tarifas, "SICASv20.forms.Tarifas"));
			formas.Add(new AppHelper.Formulario("AltaTarifas", altaTarifas, "SICASv20.forms.AltaTarifas"));
			formas.Add(new AppHelper.Formulario("ActualizacionTarifas", actualizacionTarifas, "SICASv20.forms.ActualizacionTarifas"));
			formas.Add(new AppHelper.Formulario("SICASTestLauncher", sICASTestLauncher, "SICASv20.forms.SICASTestLauncher"));
			formas.Add(new AppHelper.Formulario("CambioContraseña", cambioContraseña, "SICASv20.forms.CambioContraseña"));
			formas.Add(new AppHelper.Formulario("CambioLocacion", cambioLocacion, "SICASv20.forms.CambioLocacion"));
			formas.Add(new AppHelper.Formulario("AltaPlanillasFiscales", altaPlanillasFiscales, "SICASv20.forms.AltaPlanillasFiscales"));
			formas.Add(new AppHelper.Formulario("AltaValesPrepagados", altaValesPrepagados, "SICASv20.forms.AltaValesPrepagados"));
			formas.Add(new AppHelper.Formulario("CancelacionesOrdenesTrabajos", cancelacionesOrdenesTrabajos, "SICASv20.forms.CancelacionesOrdenesTrabajos"));
			formas.Add(new AppHelper.Formulario("OrdenesComprasCanceladas", ordenesComprasCanceladas, "SICASv20.forms.OrdenesComprasCanceladas"));
			formas.Add(new AppHelper.Formulario("VentaComisionada", ventaComisionada, "SICASv20.forms.VentaComisionada"));
			formas.Add(new AppHelper.Formulario("VentaRegresos", ventaRegresos, "SICASv20.forms.VentaRegresos"));
			formas.Add(new AppHelper.Formulario("VentaServiciosConductor", ventaServiciosConductor, "SICASv20.forms.VentaServiciosConductor"));
			formas.Add(new AppHelper.Formulario("ReporteDeVentasTotales", reporteDeVentasTotales, "SICASv20.forms.ReporteDeVentasTotales"));
			formas.Add(new AppHelper.Formulario("ReporteCorteCajaCobro", reporteCorteCajaCobro, "SICASv20.forms.ReporteCorteCajaCobro"));
			formas.Add(new AppHelper.Formulario("CajaCobroOrdenesTrabajos", cajaCobroOrdenesTrabajos, "SICASv20.forms.CajaCobroOrdenesTrabajos"));
			formas.Add(new AppHelper.Formulario("ReimprimirTickets", reimprimirTickets, "SICASv20.forms.ReimprimirTickets"));
			formas.Add(new AppHelper.Formulario("ReporteOrdenesTrabajoCobradasCaja", reporteOrdenesTrabajoCobradasCaja, "SICASv20.forms.ReporteOrdenesTrabajoCobradasCaja"));
			formas.Add(new AppHelper.Formulario("ReportePlanillasVendidas", reportePlanillasVendidas, "SICASv20.forms.ReportePlanillasVendidas"));
			formas.Add(new AppHelper.Formulario("ReporteUnidadesConductoresActuales", reporteUnidadesConductoresActuales, "SICASv20.forms.ReporteUnidadesConductoresActuales"));
			formas.Add(new AppHelper.Formulario("AsistenteContratosRenta", asistenteContratosRenta, "SICASv20.forms.AsistenteContratosRenta"));
			formas.Add(new AppHelper.Formulario("ReporteUnidadesKilometrajes", reporteUnidadesKilometrajes, "SICASv20.forms.ReporteUnidadesKilometrajes"));
			formas.Add(new AppHelper.Formulario("ReporteRecaudacionPorEstacion", reporteRecaudacionPorEstacion, "SICASv20.forms.ReporteRecaudacionPorEstacion"));
			formas.Add(new AppHelper.Formulario("PlanesDeRenta", planesDeRenta, "SICASv20.forms.PlanesDeRenta"));
			formas.Add(new AppHelper.Formulario("AltaPlanesDeRenta", altaPlanesDeRenta, "SICASv20.forms.AltaPlanesDeRenta"));
			formas.Add(new AppHelper.Formulario("ActualizacionPlanesDeRenta", actualizacionPlanesDeRenta, "SICASv20.forms.ActualizacionPlanesDeRenta"));
			formas.Add(new AppHelper.Formulario("ContratosRenta", contratosRenta, "SICASv20.forms.ContratosRenta"));
			formas.Add(new AppHelper.Formulario("AltaContratoRenta", altaContratoRenta, "SICASv20.forms.AltaContratoRenta"));
			formas.Add(new AppHelper.Formulario("ActualizacionContratoRenta", actualizacionContratoRenta, "SICASv20.forms.ActualizacionContratoRenta"));
			formas.Add(new AppHelper.Formulario("TerminacionContrato", terminacionContrato, "SICASv20.forms.TerminacionContrato"));
			formas.Add(new AppHelper.Formulario("ContratosLiquidados", contratosLiquidados, "SICASv20.forms.ContratosLiquidados"));
			formas.Add(new AppHelper.Formulario("ReporteTicketsEstacion", reporteTicketsEstacion, "SICASv20.forms.ReporteTicketsEstacion"));
			formas.Add(new AppHelper.Formulario("OrdenesCompras", ordenesCompras, "SICASv20.forms.OrdenesCompras"));
			formas.Add(new AppHelper.Formulario("ComprasConsolidado", comprasConsolidado, "SICASv20.forms.ComprasConsolidado"));
			formas.Add(new AppHelper.Formulario("VentasConsolidado", ventasConsolidado, "SICASv20.forms.VentasConsolidado"));
			formas.Add(new AppHelper.Formulario("ReporteConsumoCostoDia", reporteConsumoCostoDia, "SICASv20.forms.ReporteConsumoCostoDia"));
			formas.Add(new AppHelper.Formulario("ReporteConsumosConsolidados", reporteConsumosConsolidados, "SICASv20.forms.ReporteConsumosConsolidados"));
			formas.Add(new AppHelper.Formulario("ReportePreciosServiciosMantenimientos", reportePreciosServiciosMantenimientos, "SICASv20.forms.ReportePreciosServiciosMantenimientos"));
			formas.Add(new AppHelper.Formulario("AjusteInventario", ajusteInventario, "SICASv20.forms.AjusteInventario"));
			formas.Add(new AppHelper.Formulario("ReporteAjustesInventario", reporteAjustesInventario, "SICASv20.forms.ReporteAjustesInventario"));
			formas.Add(new AppHelper.Formulario("ReporteMovimientosInventario", reporteMovimientosInventario, "SICASv20.forms.ReporteMovimientosInventario"));
			formas.Add(new AppHelper.Formulario("OrdenesTrabajoAbiertas", ordenesTrabajoAbiertas, "SICASv20.forms.OrdenesTrabajoAbiertas"));
			formas.Add(new AppHelper.Formulario("DevolucionOrdenTrabajo", devolucionOrdenTrabajo, "SICASv20.forms.DevolucionOrdenTrabajo"));
			formas.Add(new AppHelper.Formulario("DevolucionOrdenCompra", devolucionOrdenCompra, "SICASv20.forms.DevolucionOrdenCompra"));
			formas.Add(new AppHelper.Formulario("CancelacionesOrdenesTrabajos", cancelacionesOrdenesTrabajos, "SICASv20.forms.CancelacionesOrdenesTrabajos"));
			formas.Add(new AppHelper.Formulario("CancelacionOrdenesCompras", cancelacionOrdenesCompras, "SICASv20.forms.CancelacionOrdenesCompras"));
			formas.Add(new AppHelper.Formulario("CancelacionOrdenesTrabajos", cancelacionOrdenesTrabajos, "SICASv20.forms.CancelacionOrdenesTrabajos"));
			formas.Add(new AppHelper.Formulario("TerminacionOrdenesTrabajo", terminacionOrdenesTrabajo, "SICASv20.forms.TerminacionOrdenesTrabajo"));
			formas.Add(new AppHelper.Formulario("ActualizacionOrdenesCompras", actualizacionOrdenesCompras, "SICASv20.forms.ActualizacionOrdenesCompras"));
			formas.Add(new AppHelper.Formulario("AltaEmpresa", altaEmpresa, "SICASv20.forms.AltaEmpresa"));
			formas.Add(new AppHelper.Formulario("ActualizacionEmpresa", actualizacionEmpresa, "SICASv20.forms.ActualizacionEmpresa"));
			formas.Add(new AppHelper.Formulario("ReporteInventario", reporteInventario, "SICASv20.forms.ReporteInventario"));
			formas.Add(new AppHelper.Formulario("AltaEstaciones", altaEstaciones, "SICASv20.forms.AltaEstaciones"));
			formas.Add(new AppHelper.Formulario("ActualizacionEstaciones", actualizacionEstaciones, "SICASv20.forms.ActualizacionEstaciones"));
			formas.Add(new AppHelper.Formulario("ServiciosVendidos", serviciosVendidos, "SICASv20.forms.ServiciosVendidos"));
			formas.Add(new AppHelper.Formulario("ReportePublicitarioConsolidado", reportePublicitarioConsolidado, "SICASv20.forms.ReportePublicitarioConsolidado"));
			formas.Add(new AppHelper.Formulario("ReporteHistorialCobranzaConductor", reporteHistorialCobranzaConductor, "SICASv20.forms.ReporteHistorialCobranzaConductor"));
			formas.Add(new AppHelper.Formulario("GruposUsuarios", gruposUsuarios, "SICASv20.forms.GruposUsuarios"));
			formas.Add(new AppHelper.Formulario("ActualizacionPermisosGruposUsuarios", actualizacionPermisosGruposUsuarios, "SICASv20.forms.ActualizacionPermisosGruposUsuarios"));
			formas.Add(new AppHelper.Formulario("Manuales", manuales, "SICASv20.forms.Manuales"));
			formas.Add(new AppHelper.Formulario("RentasCobradasDiarias", rentasCobradasDiarias, "SICASv20.forms.RentasCobradasDiarias"));
			formas.Add(new AppHelper.Formulario("ReporteRegistroSolicitantes", reporteRegistroSolicitantes, "SICASv20.forms.ReporteRegistroSolicitantesForm"));
			formas.Add(new AppHelper.Formulario("ReportePlanillasVendidasCajas", reportePlanillasVendidasCajas, "SICASv20.forms.ReportePlanillasVendidasCajas"));
			formas.Add(new AppHelper.Formulario("SeleccionarEstacion", seleccionarEstacion, "SICASv20.forms.SeleccionarEstacion"));
			formas.Add(new AppHelper.Formulario("ServiciosMantenimientosPrecios", serviciosMantenimientosPrecios, "SICASv20.forms.ServiciosMantenimientosPrecios"));
			formas.Add(new AppHelper.Formulario("ServiciosMantenimientosTiposRefacciones", serviciosMantenimientosTiposRefacciones, "SICASv20.forms.ServiciosMantenimientosTiposRefacciones"));
			formas.Add(new AppHelper.Formulario("OrdenesTrabajosClientes", ordenesTrabajosClientes, "SICASv20.forms.OrdenesTrabajosClientes"));
			formas.Add(new AppHelper.Formulario("ReporteDeVentasTallerClientes", reporteDeVentasTallerClientes, "SICASv20.forms.ReporteDeVentasTallerClientes"));
			formas.Add(new AppHelper.Formulario("ReimprimirOrdenesCompras", reimprimirOrdenesCompras, "SICASv20.forms.ReimprimirOrdenesCompras"));
			formas.Add(new AppHelper.Formulario("CancelacionValesPrepagados", cancelacionValesPrepagados, "SICASv20.forms.CancelacionValesPrepagados"));
			formas.Add(new AppHelper.Formulario("ReporteValesPrepagados", reporteValesPrepagados, "SICASv20.forms.ReporteValesPrepagados"));
			formas.Add(new AppHelper.Formulario("CortesDeVentas", cortesDeVentas, "SICASv20.forms.CortesDeVentas"));
			formas.Add(new AppHelper.Formulario("CajaDeServicios", cajaDeServicios, "SICASv20.forms.CajaDeServicios"));
			formas.Add(new AppHelper.Formulario("CajaCobro", cajaCobro, "SICASv20.forms.CajaCobro"));
			formas.Add(new AppHelper.Formulario("AltaFlujoCaja", altaFlujoCaja, "SICASv20.forms.AltaFlujoCaja"));
			formas.Add(new AppHelper.Formulario("UnidadesConductoresOperativos", unidadesConductoresOperativos, "SICASv20.forms.UnidadesConductoresOperativos"));
			formas.Add(new AppHelper.Formulario("AltaTiposRefacciones", altaTiposRefacciones, "SICASv20.forms.AltaTiposRefacciones"));
			formas.Add(new AppHelper.Formulario("ActualizacionTiposRefacciones", actualizacionTiposRefacciones, "SICASv20.forms.ActualizacionTiposRefacciones"));
			formas.Add(new AppHelper.Formulario("TiposRefacciones", tiposRefacciones, "SICASv20.forms.TiposRefacciones"));
			formas.Add(new AppHelper.Formulario("ImpresionVentaLoteServicios", impresionVentaLoteServicios, "SICASv20.forms.ImpresionVentaLoteServicios"));
			formas.Add(new AppHelper.Formulario("ReporteTicketsEmpresa", reporteTicketsEmpresa, "SICASv20.forms.ReporteTicketsEmpresa"));
			formas.Add(new AppHelper.Formulario("ConfiguracionesDeCaja", configuracionesDeCaja, "SICASv20.forms.ConfiguracionesDeCaja"));
			formas.Add(new AppHelper.Formulario("CancelarServicio", cancelarServicio, "SICASv20.forms.CancelarServicio"));
			formas.Add(new AppHelper.Formulario("VentaServiciosPersonalizada", ventaServiciosPersonalizada, "SICASv20.forms.VentaServiciosPersonalizada"));
			formas.Add(new AppHelper.Formulario("BitacoraUnidadesLauncher", bitacoraUnidadesLauncher, "SICASv20.forms.BitacoraUnidadesLauncher"));
			formas.Add(new AppHelper.Formulario("VerificacionBoletos", verificacionBoletos, "SICASv20.forms.VerificacionBoletos"));
			formas.Add(new AppHelper.Formulario("ReporteServiciosPagadosPorModelo", reporteServiciosPagadosPorModelo, "SICASv20.forms.ReporteServiciosPagadosPorModelo"));
			formas.Add(new AppHelper.Formulario("ReporteMovimientosFlujoDeCajaSesion", reporteMovimientosFlujoDeCajaSesion, "SICASv20.forms.ReporteMovimientosFlujoDeCajaSesion"));
			formas.Add(new AppHelper.Formulario("ReporteMovimientosRecaudacionSesion", reporteMovimientosRecaudacionSesion, "SICASv20.forms.ReporteMovimientosRecaudacionSesion"));
			formas.Add(new AppHelper.Formulario("ReporteServiciosRegresos", reporteServiciosRegresos, "SICASv20.forms.ReporteServiciosRegresos"));
			formas.Add(new AppHelper.Formulario("ReporteMovimientosRecaudacionPorFechas", reporteMovimientosRecaudacionPorFechas, "SICASv20.forms.ReporteMovimientosRecaudacionPorFechas"));
			formas.Add(new AppHelper.Formulario("PermisosCajasUsuarios", permisosCajasUsuarios, "SICASv20.forms.PermisosCajasUsuarios"));
			formas.Add(new AppHelper.Formulario("Cajas", cajas, "SICASv20.forms.Cajas"));
			formas.Add(new AppHelper.Formulario("ActualizacionCajas", actualizacionCajas, "SICASv20.forms.ActualizacionCajas"));
			formas.Add(new AppHelper.Formulario("AltaCajas", altaCajas, "SICASv20.forms.AltaCajas"));
			formas.Add(new AppHelper.Formulario("ReporteCargosAjustesConductor", reporteCargosAjustes, "SICASv20.forms.ReporteCargosAjustesConductor"));
			formas.Add(new AppHelper.Formulario("CargoCuentaConductores", cargoCuentaConductores, "SICASv20.forms.CargoCuentaConductores"));
			formas.Add(new AppHelper.Formulario("AjusteCuentaConductores", ajusteCuentaConductores, "SICASv20.forms.AjusteCuentaConductores"));
			formas.Add(new AppHelper.Formulario("ReporteIngresosEmpresas", reporteIngresosEmpresas, "SICASv20.forms.ReporteIngresosEmpresas"));
			formas.Add(new AppHelper.Formulario("ReporteProductividadServicios", reporteProductividadServicios, "SICASv20.forms.ReporteProductividadServicios"));
			formas.Add(new AppHelper.Formulario("ReporteRecaudacionPorEmpresa", reporteRecaudacionPorEmpresa, "SICASv20.forms.ReporteRecaudacionPorEmpresa"));
			formas.Add(new AppHelper.Formulario("AltaCuentaUnidades", altaCuentaUnidades, "SICASv20.forms.AltaCuentaUnidades"));
			//formas.Add(new AppHelper.Formulario("AltaAtencionClientes", altaAtencionClientes, "SICASv20.forms.AltaAtencionClientes"));
			formas.Add(new AppHelper.Formulario("ConductoresOperativos", conductoresOperativos, "SICASv20.forms.ConductoresOperativos"));
			formas.Add(new AppHelper.Formulario("ReporteRecaudacion", reporteRecaudacion, "SICASv20.forms.ReporteRecaudacion"));
			formas.Add(new AppHelper.Formulario("ReporteKilometrajesPromedio", reporteKilometrajesPromedio, "SICASv20.forms.ReporteKilometrajesPromedio"));
			formas.Add(new AppHelper.Formulario("ReporteHistorialUnidadesConductores", reporteHistorialUnidadesConductores, "SICASv20.forms.ReporteHistorialUnidadesConductores"));
			formas.Add(new AppHelper.Formulario("ReporteKilometrajesMantenimientos", reporteKilometrajesMantenimientos, "SICASv20.forms.ReporteKilometrajesMantenimientos"));
			formas.Add(new AppHelper.Formulario("VentaEmpresarial", ventaEmpresarial, "SICASv20.forms.VentaEmpresarial"));
			/*
			 * Actualización, 8 de Mayo de 2013
			 * Modificado por Luis Espino
			 * 
			 * Agregamos el formulario LicenciasPorVencerLauncher
			 */
			formas.Add(new AppHelper.Formulario("LicenciasPorVencerLauncher", licenciasPorVencerLauncher, "SICASv20.forms.LicenciasPorVencerLauncher"));

			formas.Add(new AppHelper.Formulario("AsignacionSeries", asignacionSeries, "SICASv20.forms.AsignacionSeries"));
			formas.Add(new AppHelper.Formulario("ListadoEdicionUnidades", listadoEdicionUnidades, "SICASv20.forms.ListadoEdicionUnidades"));
			formas.Add(new AppHelper.Formulario("Adendums", adendums, "SICASv20.forms.Adendums"));
			formas.Add(new AppHelper.Formulario("ReporteAdendums", reporteAdendums, "SICASv20.forms.ReporteAdendums"));
			formas.Add(new AppHelper.Formulario("TarifasEdicion", tarifasEdicion, "SICASv20.forms.TarifasEdicion"));
			formas.Add(new AppHelper.Formulario("Programacion", programacion, "SICASv20.forms.aeropuerto.herramientas.Programacion"));
			formas.Add(new AppHelper.Formulario("BuscaRegresosVendidos", BuscarRegresos, "SICASv20.forms.aeropuerto.herramientas.BuscaRegresos"));

			formas.Add(new AppHelper.Formulario("AjustesConductoresNomina", AjustesConductoresNomina, "SICASv20.forms.AjusteCuentaConductorNomina"));
			formas.Add(new AppHelper.Formulario("CargoCuentaConductorNomina", CargoCuentaConductorNomina, "SICASv20.forms.CargoCuentaConductorNomina"));
			formas.Add(new AppHelper.Formulario("ReporteProductividadNomina", ReporteProductividadNomina, "SICASv20.forms.ReporteProductividadNomina"));

			formas.Add(new AppHelper.Formulario("ConductoresTipoNominaPeriodo", ConductoresTipoNominaPeriodo, "SICASv20.forms.aeropuerto.nomina.ConductoresTipoNominaPeriodo"));
			formas.Add(new AppHelper.Formulario("ReporteNomina", ReportenominaCAT, "SICASv20.forms.aeropuerto.nomina.ReporteNominaCAT"));
			formas.Add(new AppHelper.Formulario("IncidenciasConductor", CapturaIncidenciasConductores, "SICASv20.forms.aeropuerto.nomina.CapturaIncidenciasConductores"));
			formas.Add(new AppHelper.Formulario("Captura_Boletos_Pago", CapturaBoletosPorPeriodo, "SICASv20.forms.aeropuerto.nomina.CapturaBoletosporPeriodo"));
			formas.Add(new AppHelper.Formulario("Captura_Boletos_Tiempo_Extra", CapturaBoletosTiempoExtra, "SICASv20.forms.aeropuerto.nomina.CapturaBoletosTiempoExtra"));
			formas.Add(new AppHelper.Formulario("Quita_Boletos_A_Conductor", QuitaBoletosAConductor, "SICASv20.forms.aeropuerto.nomina.QuitaBoletosAConductor"));
			formas.Add(new AppHelper.Formulario("Quita_Boletos_TE_A_Conductor", QuitaBoletosTiempoExtraAConductor, "SICASv20.forms.aeropuerto.nomina.QuitaBoletosTiempoExtraAConductor"));
			formas.Add(new AppHelper.Formulario("ConsultaConvenios",ConsultaConvenios,"SICASv20.forms.aeropuerto.nomina.ConsultaConvenios"));
			formas.Add(new AppHelper.Formulario("CapturaConvenio",CapturaConvenio,"SICASv20.forms.aeropuerto.nomina.CapturaConvenio"));

			formas.Add(new AppHelper.Formulario("ConsultaConductoresEquiposGas", ConsultarConductoresEquiposGas, "SICASv20.forms.empresas.equiposgas.ConsultarConductoresEquiposGas"));
			formas.Add(new AppHelper.Formulario("EquiposGas", EquiposGas, "SICASv20.forms.empresas.equiposgas.EquiposGas"));
			formas.Add(new AppHelper.Formulario("ProveedoresEquipoGas", ProveedoresEquipoGas, "SICASv20.forms.empresas.equiposgas.ProveedoresEquipoGas"));
			formas.Add(new AppHelper.Formulario("CatalogoEquipos", CatalogoEquipos, "SICASv20.forms.empresas.equiposgas.CatalogoEquipos"));

			formas.Add(new AppHelper.Formulario("AbastosProveedores", Proveedores, "SICASv20.forms.abastos.archivo.Proveedores"));
			formas.Add(new AppHelper.Formulario("AbastosServicios", Servicios, "SICASv20.forms.abastos.archivo.Servicios"));
			formas.Add(new AppHelper.Formulario("OrdenesDeTrabajo", OrdenesDeTrabajo, "SICASv20.forms.abastos.ManttoVehicular.OrdenesDeTrabajo"));
			formas.Add(new AppHelper.Formulario("AbastosListadoMantenimientos", ListadoMantenimientos, "SICASv20.forms.abastos.ManttoVehicular.ListadoMantenimientos"));
			formas.Add(new AppHelper.Formulario("AbastosSemaforizacion", Semaforizacion, "SICASv20.forms.abastos.ManttoVehicular.Semaforizacion"));
			formas.Add(new AppHelper.Formulario("AbastosPlantillas", Plantillas, "SICASv20.forms.abastos.ManttoVehicular.Plantillas"));
			formas.Add(new AppHelper.Formulario("AsociaServiciosModeloUnidad", AsociaServiciosModeloUnidad, "SICASv20.forms.abastos.ManttoVehicular.AsociaServiciosModeloUnidad"));
			
			formas.Add(new AppHelper.Formulario("ReporteValesEmpresariales", ReporteValesEmpresariales, "SICASv20.forms.callcenter.valesempresariales.ValesEmpresariales"));
			formas.Add(new AppHelper.Formulario("ArqueoDeCajaMetropolitano", ArqueoDeCajaMetropolitano, "SICASv20.forms.caja.reportes.ArqueoDeCajaMetropolitano"));
			formas.Add(new AppHelper.Formulario("ArqueoDeCajaApto", ArqueoDeCajaApto, "SICASv20.forms.caja.reportes.ArqueoDeCajaApto"));
			
			formas.Add(new AppHelper.Formulario("ConcesionesD", ConcesionesD, "SICASv20.forms.empresas.documentos.Digitalizados"));
			formas.Add(new AppHelper.Formulario("ConveniosD", ConveniosD, "SICASv20.forms.empresas.documentos.Digitalizados"));
			formas.Add(new AppHelper.Formulario("ContratosD", ContratosD, "SICASv20.forms.empresas.documentos.Digitalizados"));
			formas.Add(new AppHelper.Formulario("PolizasD", PolizasD, "SICASv20.forms.empresas.documentos.Digitalizados"));
			formas.Add(new AppHelper.Formulario("ActasAdministrativasD", ActasAdministrativasD, "SICASv20.forms.empresas.documentos.Digitalizados"));

			formas.Add(new AppHelper.Formulario("CanjeDeVales", CanjeDeVales, "SICASv20.forms.caja.herramientas.CanjeDeVales")); 
			formas.Add(new AppHelper.Formulario("ReimpresionDeclaracionCorteCaja", ReimpresionDeclaracionCorteCaja, "SICASv20.forms.caja.herramientas.ReimpresionDeclaracionCorteCaja"));
		}

		#endregion

		/// <summary>
		/// Realiza el cambio del formulario actual en el sistema
		/// </summary>
		/// <param name="formulario">El nombre del formulario a establecer como actual</param>
		/// <param name="forma">El objeto formulario a establecer como actual</param>
		public override void SwitchForma(string formulario, baseForm forma)
		{
			try
			{
				//  Inhabilitamos el formulario principal
				this.Cursor = Cursors.WaitCursor;
				this.Enabled = false;

				//  Verificamos que el formulario a establecer como actual no sea el actual
				if (formulario != CurrentForm)
				{
					//  Establecemos el nombre del formulario actual como anterior
					PrevForm = CurrentForm;

					//  Establecemos el nombre del formulario nuevo como el actual
					CurrentForm = formulario;

					//  Declaramos tipo
					//  Encontramos el tipo de Formulario a establecer como actual
					string tipo = formas.Find(formulario).FormClass;

					//  Encontramos el objeto formulario a establecer como actual
					AppHelper.Formulario f = formas.Find(formulario);

					//  Asignamos el objeto formulario
					f.Forma = forma;

					//  Asignamos el formulario principal como padre del formulario a establecer como actul
					f.Forma.Padre = this;

					//  Le asignamos el nombre al formulario
					f.Forma.Name = formas.Find(formulario).Key;
					f.Forma.Tag = formas.Find(formulario).Key;

					//  Ligamos los datos necesarios de la base de datos
					//  llamando a BindData
					f.Forma.BindData();

					//  Establecemos el estilo de los controles
					//  llamando a SetStylish
					SetStylish(f.Forma);

					//  Mostramos el formulario
					//  lo hacemos visible
					f.Forma.Show();

					//  Limpiamos los controles del Panel Principal
					PanelMain.Controls.Clear();

					//  Agregamos el control del formulario actual al Panel Principal
					PanelMain.Controls.Add(formas.Find(formulario).Forma);

					//  Llamamos a BringToFront para que se muestre al frente
					PanelMain.Controls[formulario].BringToFront();

					//  Intentaremos eliminar el formulario actual
					//  para liberar memoria
					try
					{
						//  Encontramos el formulario anterior
						baseForm prev = formas.Find(PrevForm).Forma;

						//  "Desligamos" los datos
						AppHelper.ClearDataSources(prev);

						//  Cerramos el formulario
						prev.Close();

						//  Llamamos a Dispose
						prev.Dispose();

						//  Lo hacemos nulo
						prev = null;
					}
					catch // En caso de error
					{
						//  Revertimos los papeles
						//  y el formulario anterior será el actual
						CurrentForm = PrevForm;
					}
				}
			}
			catch (Exception ex) // En caso de error
			{
				//  Manejar regreso a prev form
				CurrentForm = PrevForm;

				//  Mostramos mensaje de error
				AppHelper.Error(ex.Message);
			}
			finally
			{
				//  Desbloqueamos el formulario
				//  para que usuario pueda volver a utilizarlo
				this.Cursor = Cursors.Default;
				this.Enabled = true;
			}
		}

		/// <summary>
		/// Establece un formulario en blanco como el formulario actual
		/// </summary>
		public override void CancelCurrentForm()
		{
			this.SwitchForma("BlankForm");
			base.CancelCurrentForm();
		}

		/// <summary>
		/// Realiza el cambio del formulario actual en el sistema
		/// </summary>
		/// <param name="formulario">El nombre del formulario a establecer como actual</param>
		public override void SwitchForma(string formulario)
		{
			try
			{
				//  Dehabilitamos el formulario
				//  para que el usuario no pueda usarlo
				//  y mostramos el cursor de espera
				this.Cursor = Cursors.WaitCursor;
				this.Enabled = false;

				//  Verificamos que el formulario a establecer no sea el actual en el sistema
				if (formulario != CurrentForm)
				{
					//  Establecemos el nombre del formulario actual como anterior
					PrevForm = CurrentForm;

					//  Asginamos el nombre del formulario a establcer como actual en el sistema
					CurrentForm = formulario;

					//  Declaramos tipo
					//  y le asignamos el tipo de formulario a establecer
					string tipo = formas.Find(formulario).FormClass;

					//  f es la variable que contendrá el objeto formulario
					//  a establecer en el sistema
					AppHelper.Formulario f = formas.Find(formulario);

					//  Instanciamos el objeto Form del formulario a partir de su tipo
					//  convirtiendolo a baseForm
					f.Forma = (baseForm)Activator.CreateInstance(Type.GetType(tipo));

					//  Asignamos el formulario principal como padre del formulario actual
					f.Forma.Padre = this;

					//  Le asignamos el nombre al formulario actual
					f.Forma.Name = formas.Find(formulario).Key;
					f.Forma.Tag = formas.Find(formulario).Key;

					//  Ligamos los datos de la base de datos
					//  llamando BindData
					f.Forma.BindData();

					//  Damos estilos a los controles de la forma
					//  llamando a SetStylish
					SetStylish(f.Forma);

					//  Mostramos el formulario
					f.Forma.Show();

					//  Eliminamos los controles del Panel Principal
					PanelMain.Controls.Clear();

					//  Asignamos el formulario actual como control del Panel Principal
					PanelMain.Controls.Add(formas.Find(formulario).Forma);

					//  Traemos al frente del Panel Principal el formulario actual
					PanelMain.Controls[formulario].BringToFront();

					//  Intentamos eliminar el formulario anterior
					//  para liberar memoria
					try
					{

						//  Verificamos que exista el formulario anterior
						if (PrevForm != null)
						{
							//  Encontramos su objeto baseForm
							baseForm prev = formas.Find(PrevForm).Forma;

							//  Desligamos los datos actuales
							AppHelper.ClearDataSources(prev);

							//  Cerramos el formulario
							prev.Close();

							//  Mandamos llamar Dispose
							prev.Dispose();

							//  Lo hacemos nulo
							prev = null;
						}
					}
					catch // En caso de error
					{
						//  Establecemos el formulario anterior como el actual
						CurrentForm = PrevForm;
					}
				}
			}
			catch (Exception ex) // En caso de error
			{
				//  Establecemos el formulario anterior como el actual
				CurrentForm = PrevForm;

				AppHelper.Error(ex.InnerException.Message);
				//  Mostramos el mensaje de error
				AppHelper.Error(ex.Message);
			}
            finally //  por último
			{
				//  Activamos de nuevo el formulario principal
				//  y el cursor
				this.Cursor = Cursors.Default;
				this.Enabled = true;
			}
		}

		/// <summary>
		/// Aplica estilos a los controles, de manera recursiva
		/// </summary>
		/// <param name="ctrl">El control al que se aplicaran los estilos</param>
		private void SetStylish(Control ctrl)
		{
			//  Esta variable almacenará verdadero si el control es baseform
			bool IsBaseForm = false;

			//  Hacemos la prueba, para saber si es baseForm
			try
			{
				//  Los intentamos castear
				//  si se puede es verdadero
				baseForm bf = (baseForm)ctrl;
				IsBaseForm = true;
			}
			catch // en caso de error
			{
				//  Es falso, no es baseForm
				IsBaseForm = false;
			}

			//  Si el control es baseForm
			if (IsBaseForm)
			{
				//  Le establecemos las propiedades de los baseForm
				SetBaseFormProperties((baseForm)ctrl);
			}

			//  Para cado control hijo que tenga el control a verificar
			foreach (Control c in ctrl.Controls)
			{
				//  Si es DataGridView
				if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
				{
					//  Le establcemos las propiedades correspondientes
					SetDataGridViewProperties((DataGridView)c);
				}

				//  Si es Label
				if (c.GetType() == typeof(System.Windows.Forms.Label))
				{
					//  Le establecemos las propiedades correspondientes
					Strip_IDLabel((Label)c);
				}

				//  Si es Textbox
				if (c.GetType() == typeof(System.Windows.Forms.TextBox))
				{
					//  Le establecemos las propiedades correspondientes
					SetTextBoxProperties((TextBox)c);
				}

				//  Si es GroupBox
				if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
				{
					//  Le establecemos las propiedades correspondientes
					GroupBox gbox = (GroupBox)c;
					gbox.BackColor = Color.Transparent;
				}

				//  Aplicamos recursivamente el mismo procedimiento
				//  al control hijo
				SetStylish(c);
			}
		}

		/// <summary>
		/// Establece las propiedades de los controles de tipo baseForm
		/// </summary>
		/// <param name="bform">El objeto baseForm a modificar</param>
		private void SetBaseFormProperties(baseForm bform)
		{
			bform.Size = this.PanelMain.Size;
		}

		/// <summary>
		/// Establece el tamaño del Panel Principal
		/// </summary>
		private void SetPanelSize()
		{
			Rectangle screen = Screen.PrimaryScreen.Bounds;
			this.PanelMain.Width = screen.Width;
			this.MenuesPanel.Width = screen.Width;
			this.ToolBarPanel.Width = screen.Width;
			this.PanelMain.Height = screen.Height - this.MenuesPanel.Height - this.ToolBarPanel.Height - this.ModulosMenu.Height - 15;
		}

		/// <summary>
		/// Establece las propiedades de los controles de tipo TextForm
		/// </summary>
		/// <param name="bform"></param>
		private void SetTextBoxProperties(TextBox txt)
		{
			//txt.CharacterCasing = CharacterCasing.Upper;
		}

		/// <summary>
		/// Elimina la cadena " ID" del texto de un control Label
		/// </summary>
		/// <param name="lbl">El control label que será modificado</param>
		private void Strip_IDLabel(Label lbl)
		{
			lbl.Text = lbl.Text.Replace(" ID", "").Replace("_ID", "");
		}

		/// <summary>
		/// Configura propiedades a un control <remarks>DataGridView</remarks>
		/// </summary>
		/// <param name="dgv">Control <remarks>DataGridView</remarks> que será configurado</param>
		private void SetDataGridViewProperties(DataGridView dgv)
		{
			dgv.AutoGenerateColumns = false;
			dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.GridColor = System.Drawing.Color.Gainsboro;
			dgv.RowHeadersVisible = false;
			dgv.AllowUserToResizeRows = false;
		}

		/// <summary>
		/// Crear los menues y submenues a partir de los privilegios
		/// del usuario
		/// </summary>
		public void SetMenuOptions()
		{
			//  Instanciamos el modelo
			Model = new PermisosDeUsuario_Model();

			//  Asignamos el usuario actual de la sesion
			Model.Usuario_ID = Sesion.Usuario_ID;

			//  Consultamos sus permisos
			Model.ConsultarPermisos();

			//  Consultamos los modulos de sus permisos
			Model.ConsultarModulos();

			//  Iteramos los modulos
			foreach (Entities.Modulos modulo in Model.Modulos)
			{
				//  Obtener nombre y id
				string modulo_nombre = modulo.Nombre;
				int modulo_id = modulo.Modulo_ID;

				//  Crear objeto de menu para el modulo
				MenuStrip ModuleMenu = new MenuStrip();

				//  Asignarle nombre y propiedades
				ModuleMenu.Name = modulo_nombre;
				ModuleMenu.BackgroundImage = Image.FromFile(AppHelper.ImagePath + "menu_bg.png");

				//  Crear el objeto de barra de herramientas para el modulo
				ToolStrip ModuleToolBar = new ToolStrip();

				//  Asignarle nombre y propiedades
				ModuleToolBar.Name = modulo_nombre;
				ModuleToolBar.BackgroundImage = Image.FromFile(AppHelper.ImagePath + "toolbar_bg.png");

				//  Crear objeto de menuItem para el menú de módulos                
				ToolStripMenuItem ModuleMenuItem = new ToolStripMenuItem();

				//  Asignarle nombre y propiedades                
				ModuleMenuItem.Name = modulo_nombre;
				ModuleMenuItem.Text = modulo_nombre;

				//  Asignarle eventos         
				ModuleMenuItem.Click += ModuleMenu_Click;
				//ModuleMenuItem.MouseEnter += ModuleMenu_MouseEnter;
				//ModuleMenuItem.MouseLeave += ModuleMenu_MouseLeave;

				//  Obtener el listado de menues del módulo
				Model.Modulo_ID = modulo_id;
				Model.ConsultarMenues();

				//  Para cada menu
				foreach (Entities.Menues menu in Model.Menues)
				{
					//  Obtener nombre y id                    
					int menu_id = menu.Menu_ID;
					string menu_nombre = menu.Nombre;
					string menu_image = menu.Imagen;

					//  Crear objeto del menu
					ToolStripMenuItem MenuMenu = new ToolStripMenuItem();

					//  Asignarle nombre y texto
					MenuMenu.Name = menu_nombre;
					MenuMenu.Text = menu_nombre;

					//  Asignarle imagen, si la tiene
					if (menu_image != "")
					{
						MenuMenu.Image = Image.FromFile(AppHelper.ImagePath + menu_image);
						MenuMenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
						MenuMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
					}

					//  Asignarle eventos
					MenuMenu.MouseEnter += Menu_MouseEnter;
					MenuMenu.MouseLeave += Menu_MouseLeave;

					//  Obtener el listado de opciones del menu
					Model.Menu_ID = menu_id;
					Model.ConsultarPermisosOpciones();

					//  Para cada opcion
					foreach (Entities.Vista_PermisosUsuarios permiso in Model.Permisos)
					{
						if (permiso.EsPermitido.Value)
						{
							//  Obtener nombre, id, texto e imagen
							int opcion_id = permiso.Opcion_ID.Value;
							string opcion_nombre = permiso.Opcion;
							string opcion_texto = permiso.OpcionTexto;
							string opcion_imagen = permiso.OpcionImagen;
							bool esHerramienta = Convert.ToBoolean(AppHelper.IsNull(permiso.EsHerramienta.Value, 0));
							bool esActivo = Convert.ToBoolean(permiso.EsActivo.Value);

							if (esActivo)
							{
								//  Menu Item
								//  Crear el menu item
								ToolStripMenuItem OpcionMenuItem = new ToolStripMenuItem();

								//  Asignarle nombre y texto
								OpcionMenuItem.Name = opcion_nombre;
								OpcionMenuItem.Text = opcion_texto;

								//  Asignarle imágen
								if (opcion_imagen != "")
								{
									OpcionMenuItem.Image = Image.FromFile(AppHelper.ImagePath + opcion_imagen);
									OpcionMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;
									OpcionMenuItem.TextImageRelation = TextImageRelation.ImageBeforeText;
								}

								//  Asignarle el evento click
								OpcionMenuItem.Click += Menu_Click;

								//  Agregarlo al menu de opciones
								MenuMenu.DropDownItems.Add(OpcionMenuItem);

								//  Si es herramienta
								if (esHerramienta)
								{
									//  Crear el toolstrip
									ToolStripLabel OpcionLabel = new ToolStripLabel();

									//  Asignarle propiedades
									OpcionLabel.Text = opcion_texto;
									OpcionLabel.Name = opcion_nombre;

									if (opcion_imagen != "")
									{
										OpcionLabel.Image = Image.FromFile(AppHelper.ImagePath + opcion_imagen);
										OpcionLabel.TextImageRelation = TextImageRelation.ImageBeforeText;
										OpcionLabel.ImageScaling = ToolStripItemImageScaling.SizeToFit;
									}

									//  Asignarle eventos
									OpcionLabel.Click += ToolStrip_Click;
									OpcionLabel.MouseEnter += ToolStrip_MouseEnter;
									OpcionLabel.MouseLeave += ToolStrip_MouseLeave;

									//  Agregar la opcion a la barra de herramientas del modulo
									ModuleToolBar.Items.Add(OpcionLabel);
								}
							}
						}
					}
					//  Agregarlo al menú de modulo
					if (MenuMenu.DropDownItems.Count > 0)
					{
						ModuleMenu.Items.Add(MenuMenu);
					}
				}

				//  Agregarlo al menu principal                
				//  Agregar el menu al diccionario
				if (ModuleMenu.Items.Count > 0)
				{
					ModulosMenu.Items.Add(ModuleMenuItem);
					Menues.Add(modulo_nombre, ModuleMenu);
				}

				//  Agregar la barra de herramientas al diccionario
				if (ModuleToolBar.Items.Count > 0)
				{
					ToolBars.Add(modulo_nombre, ModuleToolBar);
				}
			}

			//  Efectuar el cambio de menu al primer modulo
			//  Cambiamos el modulo al inicial, en el lugar 0
			SwitchModulo(ModulosMenu.Items[0].Name);

			//  Iniciamos el formulario
			InitForm();

		} // end void

		/// <summary>
		/// Inicia un formulario según los permisos del usuario
		/// </summary>
		public void InitForm()
		{
			//  Verificaremos si tiene acceso a "ConductoresOperativos"
			//  Si es asi, mostraremos la pantalla de "Licencias por Vencer"

			// Creamos una variable de Permisos  
			Entities.Vista_PermisosUsuarios permisoRCD = null;

			//  Establecemos el modulo "Conductores"
			Model.Modulo_ID = 2;

			//  Establecemos la opción "Herramientas"
			Model.Menu_ID = 21;

			//  Consultar los permisos
			Model.ConsultarPermisosOpciones();

			/* 
			 * Modificación de código, 8 de Mayo de 2013
			 * Modificado por Luis Espino
			 * Se cambio el formulario a "LicenciasPorVencerLauncher"
			 */
			//  Buscamos en los permisos la opción LicenciasPorVencerLauncher
			//  y la asignamos a la variable
			foreach (Entities.Vista_PermisosUsuarios permiso in Model.Permisos)
			{
				if (permiso.Usuario_ID.ToUpper().Equals(Sesion.Usuario_ID.ToUpper()) &&
				    permiso.Opcion == "LicenciasPorVencerLauncher")
				{
					permisoRCD = permiso;
				} // end if

			} // end foreach

			//  Verificar si tiene asignada una sola estación
			//  Verificar si tiene permiso para la opción ConductoresOperativos
			if (Sesion.Estacion_ID != null &&
			    permisoRCD != null)
			{
				//  Si tiene permitida la opción, la mostraremos,
				//  Si no, mostraremos un formulario en blanco
				if (permisoRCD.EsPermitido.Value)
				{
					LicenciasForm = new LicenciasPorVencer();
					LicenciasForm.ShowDialog();
				} // end if

			} // end if

			//  Verificaremos si tiene acceso a la opción de rentas cobradas diarias
			//  Si es asi, la mostraremos al inicio de la sesión            

			// Creamos una variable de Permisos  
			permisoRCD = null;

			//  Buscamos en los permisos la opción
			//  y la asignamos a la variable
			foreach (Entities.Vista_PermisosUsuarios permiso in Model.Permisos)
			{
				if (permiso.Usuario_ID.ToUpper().Equals(Sesion.Usuario_ID.ToUpper()) &&
				    permiso.Opcion == "RentasCobradasDiarias")
				{
					permisoRCD = permiso;
				}
			}

			//  Verificar si tiene asignada una sola estación
			//  Verificar si tiene permiso para la opción RentasCobradasDiaris
			if (Sesion.Estacion_ID != null &&
			    permisoRCD != null)
			{
				//  Si tiene permitida la opción, la mostraremos,
				//  Si no, mostraremos un formulario en blanco
				if (permisoRCD.EsPermitido.Value)
					SwitchForma("RentasCobradasDiarias");
			} // end if

		} // end InitForm


		/// <summary>
		/// Hover para barra de herramientas
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStrip_MouseEnter(object sender, EventArgs e)
		{
			ToolStripLabel ts = (ToolStripLabel)sender;
			ts.BackgroundImage = Image.FromFile(AppHelper.ImagePath + "toolbar_hover_bg.png");
			ts.BackgroundImageLayout = ImageLayout.Stretch;
		}

		/// <summary>
		/// Al salir el mouse de la barra de herramientas
		/// quitamos la imagen de fondo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStrip_MouseLeave(object sender, EventArgs e)
		{
			ToolStripLabel ts = (ToolStripLabel)sender;
			ts.BackgroundImage = null;
		}

		/// <summary>
		/// Al clic en barra de herramientas cambiamos el formulario actual
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStrip_Click(object sender, EventArgs e)
		{
			//  Convertir sender a ToolStripLabel
			ToolStripLabel ts = (ToolStripLabel)sender;

			//  Invocar SwitchForma
			SwitchForma(ts.Name);
		}

		/// <summary>
		/// Hover de los menues
		/// le ponemos imagen de fondo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Menu_MouseEnter(object sender, EventArgs e)
		{
			//  Convertir a menu
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			//  Asignar imagen
			mnu.BackgroundImage = Image.FromFile(AppHelper.ImagePath + "menu_hover_bg.png");
			mnu.BackgroundImageLayout = ImageLayout.Stretch;
		}

		/// <summary>
		/// Al salir el cursor de los menues
		/// eliminamos la imagen de fondo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Menu_MouseLeave(object sender, EventArgs e)
		{
			//  Convertir a menu
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			//  Asignar imagen
			mnu.BackgroundImage = null;
		}

		/// <summary>
		/// Hover de modulos
		/// asignamos imagen de fondo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModuleMenu_MouseEnter(object sender, EventArgs e)
		{
			//  Convertir a menu
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			//  Asignar imagen
			mnu.BackgroundImage = Image.FromFile(AppHelper.ImagePath + "modulemenu_hover_bg.png");
			mnu.BackgroundImageLayout = ImageLayout.Stretch;

		}

		/// <summary>
		/// Al salir el cursor de los modulo
		/// eliminamos la imagen de fondo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModuleMenu_MouseLeave(object sender, EventArgs e)
		{
			//  Convertir a menu
			ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

			//  Asignar imagen
			mnu.BackgroundImage = null;
		}

		/// <summary>
		/// Cambia de módulo la interfaz, los menues y la barra de herramientas
		/// </summary>
		/// <param name="modulo">El modulo al que se va a cambiar en la interfaz</param>
		private void SwitchModulo(string modulo)
		{
			//  Asignar modulo activo
			ModuloActivo = modulo;

			//  Efectuar el cambio de menú            
			MenuesPanel.Controls.Clear();
			MenuesPanel.Controls.Add(Menues[modulo]);

			//  Efectuar el cambio de barra de herramientas
			if (ToolBars.ContainsKey(modulo))
			{
				ToolBarPanel.Controls.Clear();
				ToolBarPanel.Controls.Add(ToolBars[modulo]);
			}

			//  Hacemos nula las imagen de fondo de todos los modulos individales
			foreach (ToolStripMenuItem mnu in ModulosMenu.Items)
			{
				mnu.BackgroundImage = null;
			}

			//  Aisgnamos la imagen de fondo al modulo actual
			ModulosMenu.Items[modulo].BackgroundImage = Image.FromFile(AppHelper.ImagePath + "modulemenu_hover_bg.png");
			ModulosMenu.Items[modulo].BackgroundImageLayout = ImageLayout.Stretch;
		}

		/// <summary>
		/// Al efectuar clic en los menues de Módulo
		/// Se utiliza para cambiar de menues y barras de herramientas
		/// </summary>
		private void ModuleMenu_Click(object sender, EventArgs e)
		{
			//  Convertir el objeto en menu
			ToolStripMenuItem menu;
			menu = (ToolStripMenuItem)sender;

			SwitchModulo(menu.Name);
		}

		/// <summary>
		/// Al efectuar clic en los menues.        
		/// Se utiliza para cambiar de pantalla en el "PanelMain"
		/// </summary>
		private void Menu_Click(object sender, EventArgs e)
		{
			//  Convertir el objeto en menu
			ToolStripMenuItem menu;
			menu = (ToolStripMenuItem)sender;

			//  Invocar "SwitchForma"
			SwitchForma(menu.Name);
		}

		/// <summary>
		/// Registra en la base de datos la salida de la aplicación
		/// </summary>
		public void RegistrarSalida()
		{
			Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
			registro.Accion = "SALIR";
			registro.Comentarios = "Version " + AppHelper.Version;
			registro.Fecha = DB.GetDate();
			registro.Formulario = this.Name;
			registro.Opcion_ID = null;
			registro.Usuario_ID = Sesion.Usuario_ID;
			registro.Create();
		}

		/// <summary>
		/// Al cerrar el formulario se manda a registrar la salida y cierra la aplicacion
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SICASForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			AppHelper.DoMethod(
			    delegate
			    {
				    //  Cerrar sesión
				    RegistrarSalida();
			    },
			    this,
			    delegate
			    {
				    //  Salir del sistema
				    Application.Exit();
			    }
			);
		} // End void

	} // End class

} // End namespace