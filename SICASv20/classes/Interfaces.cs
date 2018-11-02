/*
 * Interfaces.cs
 * Namespaces Entities
 * 
 * Contiene todas las clases asistentes en la consulta
 * de datos a la base de datos
 * 
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 * 
 * Clase: Vista_MonitorRentas
 * 
 * Se eliminó la directiva de consultar saldos
 * por estación. Los saldos de otros cargos
 * se consultan por empresa solamente
 * 
 * Se agregó la clase Vista_Usuarios_Empresas
 * 
 * Se agregó la clase Vista_Usuarios_Estaciones
 * 
 *      2012-10-25  -   Modificado  -   Luis Espino
 *          Se agregó la clase Vista_ConductoresOperativos
 *          Se agregó la clase Vista_LicenciasPorVencer
 *      
 *      2013-01-04  -   Modificado  -   Luis Espino
 *          Se modificó la función GetInventarioDiferido, corrigiendo
 *          el error de Nulo cuando no hay inventario.
 *          
 *      2013-01-09  -   Modificado  -   Luis Espino
 *          Se creo la clase Vista_Reporte_FlujoCaja
 *          
 *      2013-03-21  -   Modificado  -   Luis Espino
 *          Se creo la clase Vista_ReporteKilometrajesMantenimientos
 *          Se creó la clase Vista_ReporteKilometrajesMantenimientos_Diario
 *          
 *      2013-05-07  -   Modificado  -   Luis Espino
 *          Se creó la función GetByConductor_ID(int conductor_id, int numeroeconomico)
 *          Lineas 24290 a 24422
 *          
 *      2013-05-13  -   Modificado  -   Ricardo Ponce
 *          Se creó modificó la clase Vista_LicenciasPorVencer para agregar condiciones
 *          al query y separa aeropuerto del resto de las estaciones
 *          Lineas 1319 a 1347 y 1370 a 1398
 *          Se modificó la clase AdeudosDeConductor para que aparezca Descanso y Cooperativa
 *          a conductores cubredescansos así como se eliminan registros con saldo 0
 *          Lineas 23527 a 23635 y 23654 a 23762
 *          
 *      2013-06-24  -   Modificado  -   Ricardo Ponce
 *          Se agregó la clausula ORDER BY a la clase Vista_MovimientosInventario para su 
 *          mejor entendimiento 
 *          Lineas 11311 y 11379
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace SICASv20.Entities
{
    public class Vista_ReporteKilometrajesMantenimiento_Diario
    {

        #region Constructors
        public Vista_ReporteKilometrajesMantenimiento_Diario()
        {
        }

        public Vista_ReporteKilometrajesMantenimiento_Diario(
            System.String fecha,
            System.String empresa,
            System.Int32? numeroeconomico,
            System.Int32? kminicial,
            System.Int32? kmrecorrido,
            System.Decimal? mantenimientos,
            System.Decimal? recaudacion,
            System.Int32? ultimokm,
            System.String ultimacaptura
            )
        {
            this.Fecha = fecha;
            this.Empresa = empresa;
            this.NumeroEconomico = numeroeconomico;
            this.KMInicial = kminicial;
            this.KMRecorrido = kmrecorrido;
            this.Mantenimientos = mantenimientos;
            this.Recaudacion = recaudacion;
            this.UltimoKM = ultimokm;
            this.UltimaCaptura = ultimacaptura;
        }

        #endregion

        #region Properties
        private System.String _Fecha;
        public System.String Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _KMInicial;
        public System.Int32? KMInicial
        {
            get { return _KMInicial; }
            set { _KMInicial = value; }
        }

        private System.Int32? _KMRecorrido;
        public System.Int32? KMRecorrido
        {
            get { return _KMRecorrido; }
            set { _KMRecorrido = value; }
        }

        private System.Decimal? _Mantenimientos;
        public System.Decimal? Mantenimientos
        {
            get { return _Mantenimientos; }
            set { _Mantenimientos = value; }
        }

        private System.Decimal? _Recaudacion;
        public System.Decimal? Recaudacion
        {
            get { return _Recaudacion; }
            set { _Recaudacion = value; }
        }

        private System.Int32? _UltimoKM;
        public System.Int32? UltimoKM
        {
            get { return _UltimoKM; }
            set { _UltimoKM = value; }
        }

        private System.String _UltimaCaptura;
        public System.String UltimaCaptura
        {
            get { return _UltimaCaptura; }
            set { _UltimaCaptura = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteKilometrajesMantenimiento_Diario> Get(
            System.String fecha)
        {
            string sqlstr = @"dbo.usp_Rpt_KilometrajesMantenimientoDiario";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            List<Vista_ReporteKilometrajesMantenimiento_Diario> list = new List<Vista_ReporteKilometrajesMantenimiento_Diario>();
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Vista_ReporteKilometrajesMantenimiento_Diario(
                       Convert.ToString(dr["Fecha"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["KMInicial"]),
                       DB.GetNullableInt32(dr["KMRecorrido"]),
                       DB.GetNullableDecimal(dr["Mantenimientos"]),
                       DB.GetNullableDecimal(dr["Recaudacion"]),
                       DB.GetNullableInt32(dr["UltimoKM"]),
                       Convert.ToString(dr["UltimaCaptura"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String fecha)
        {
            string sqlstr = @"dbo.usp_Rpt_KilometrajesMantenimientoDiario";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        #endregion
    } // End Class Vista_ReporteKilometrajesMantenimiento_Diario

    public class Vista_ReporteKilometrajesMantenimientos
    {
        #region Constructors
        public Vista_ReporteKilometrajesMantenimientos()
        {
        }

        public Vista_ReporteKilometrajesMantenimientos(
            System.String empresa,
            System.Int32? numeroeconomico,
            System.Int32? kminicial,
            System.Int32? kmrecorrido,
            System.Decimal? mantenimiento,
            System.Decimal? recaudacion,
            System.Decimal? diferencia,
            System.Decimal? mttoporkm,
            System.Int32? kmpromedio,
            System.Decimal? mttopordia,
            System.Decimal? recaudacionpordia,
            System.Int32? numdias,
            System.Int32? kmacumulado,
            System.DateTime? ultimacaptura
            )
        {
            this.Empresa = empresa;
            this.NumeroEconomico = numeroeconomico;
            this.KMInicial = kminicial;
            this.KMRecorrido = kmrecorrido;
            this.Mantenimiento = mantenimiento;
            this.Recaudacion = recaudacion;
            this.Diferencia = diferencia;
            this.MttoPorKM = mttoporkm;
            this.KMPromedio = kmpromedio;
            this.MttoPorDia = mttopordia;
            this.RecaudacionPorDia = recaudacionpordia;
            this.NumDias = numdias;
            this.KMAcumulado = kmacumulado;
            this.UltimaCaptura = ultimacaptura;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _KMInicial;
        public System.Int32? KMInicial
        {
            get { return _KMInicial; }
            set { _KMInicial = value; }
        }

        private System.Int32? _KMRecorrido;
        public System.Int32? KMRecorrido
        {
            get { return _KMRecorrido; }
            set { _KMRecorrido = value; }
        }

        private System.Decimal? _Mantenimiento;
        public System.Decimal? Mantenimiento
        {
            get { return _Mantenimiento; }
            set { _Mantenimiento = value; }
        }

        private System.Decimal? _Recaudacion;
        public System.Decimal? Recaudacion
        {
            get { return _Recaudacion; }
            set { _Recaudacion = value; }
        }

        private System.Decimal? _Diferencia;
        public System.Decimal? Diferencia
        {
            get { return _Diferencia; }
            set { _Diferencia = value; }
        }

        private System.Decimal? _MttoPorKM;
        public System.Decimal? MttoPorKM
        {
            get { return _MttoPorKM; }
            set { _MttoPorKM = value; }
        }

        private System.Int32? _KMPromedio;
        public System.Int32? KMPromedio
        {
            get { return _KMPromedio; }
            set { _KMPromedio = value; }
        }

        private System.Decimal? _MttoPorDia;
        public System.Decimal? MttoPorDia
        {
            get { return _MttoPorDia; }
            set { _MttoPorDia = value; }
        }

        private System.Decimal? _RecaudacionPorDia;
        public System.Decimal? RecaudacionPorDia
        {
            get { return _RecaudacionPorDia; }
            set { _RecaudacionPorDia = value; }
        }

        private System.Int32? _NumDias;
        public System.Int32? NumDias
        {
            get { return _NumDias; }
            set { _NumDias = value; }
        }

        private System.Int32? _KMAcumulado;
        public System.Int32? KMAcumulado
        {
            get { return _KMAcumulado; }
            set { _KMAcumulado = value; }
        }

        private System.DateTime? _UltimaCaptura;
        public System.DateTime? UltimaCaptura
        {
            get { return _UltimaCaptura; }
            set { _UltimaCaptura = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteKilometrajesMantenimientos> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = "usp_Obtiene_ReporteKilometrajesMantenimientos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_ReporteKilometrajesMantenimientos> list = new List<Vista_ReporteKilometrajesMantenimientos>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteKilometrajesMantenimientos(
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["KMInicial"]),
                       DB.GetNullableInt32(dr["KMRecorrido"]),
                       DB.GetNullableDecimal(dr["Mantenimiento"]),
                       DB.GetNullableDecimal(dr["Recaudacion"]),
                       DB.GetNullableDecimal(dr["Diferencia"]),
                       DB.GetNullableDecimal(dr["MttoPorKM"]),
                       DB.GetNullableInt32(dr["KMPromedio"]),
                       DB.GetNullableDecimal(dr["MttoPorDia"]),
                       DB.GetNullableDecimal(dr["RecaudacionPorDia"]),
                       DB.GetNullableInt32(dr["NumDias"]),
                       DB.GetNullableInt32(dr["KMAcumulado"]),
                       DB.GetNullableDateTime(dr["UltimaCaptura"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"usp_Obtiene_ReporteKilometrajesMantenimientos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteKilometrajesMantenimientos

    public class Vista_Reporte_FlujoCaja
    {

        #region Constructors
        public Vista_Reporte_FlujoCaja()
        {
        }

        public Vista_Reporte_FlujoCaja(
            System.Int32? cuentaflujocaja_id,
            System.Int32? sesion_id,
            System.Int32? empresa_id,
            System.String empresa,
            System.Int32? estacion_id,
            System.String estacion,
            System.Int32? caja_id,
            System.String caja,
            System.Int32? moneda_id,
            System.String moneda,
            System.Int32? ticket_id,
            System.Decimal? cargo,
            System.Decimal? abono,
            System.Decimal? saldo,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.CuentaFlujoCaja_ID = cuentaflujocaja_id;
            this.Sesion_ID = sesion_id;
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Estacion_ID = estacion_id;
            this.Estacion = estacion;
            this.Caja_ID = caja_id;
            this.Caja = caja;
            this.Moneda_ID = moneda_id;
            this.Moneda = moneda;
            this.Ticket_ID = ticket_id;
            this.Cargo = cargo;
            this.Abono = abono;
            this.Saldo = saldo;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _CuentaFlujoCaja_ID;
        public System.Int32? CuentaFlujoCaja_ID
        {
            get { return _CuentaFlujoCaja_ID; }
            set { _CuentaFlujoCaja_ID = value; }
        }

        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _Estacion_ID;
        public System.Int32? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Caja_ID;
        public System.Int32? Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        private System.Int32? _Moneda_ID;
        public System.Int32? Moneda_ID
        {
            get { return _Moneda_ID; }
            set { _Moneda_ID = value; }
        }

        private System.String _Moneda;
        public System.String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Decimal? _Cargo;
        public System.Decimal? Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Reporte_FlujoCaja> Get(
            System.Int32? sesion_id)
        {
            string sqlstr = @"dbo.usp_Rpt_FlujoCaja";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_Reporte_FlujoCaja> list = new List<Vista_Reporte_FlujoCaja>();
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Reporte_FlujoCaja(
                       DB.GetNullableInt32(dr["CuentaFlujoCaja_ID"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Estacion_ID"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Caja_ID"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Moneda_ID"]),
                       Convert.ToString(dr["Moneda"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? sesion_id)
        {
            string sqlstr = @"dbo.usp_Rpt_FlujoCaja";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_Reporte_FlujoCaja

    public class Vista_HistorialConductoresUnidades
    {

        #region Constructors
        public Vista_HistorialConductoresUnidades()
        {
        }

        public Vista_HistorialConductoresUnidades(
            System.String empresa,
            System.String estacion,
            System.Int32? numeroeconomico,
            System.String conductor,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor = conductor;
            this.FechaInicial = fechainicial;
            this.FechaFinal = fechafinal;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.DateTime? _FechaInicial;
        public System.DateTime? FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime? _FechaFinal;
        public System.DateTime? FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_HistorialConductoresUnidades> Get(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.Int32? numeroeconomico)
        {
            string sqlstr = @"[dbo].[usp_HistorialConductoresUnidades_Get]";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<Vista_HistorialConductoresUnidades> list = new List<Vista_HistorialConductoresUnidades>();
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            //foreach (DataRow dr in dt.Rows)
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Vista_HistorialConductoresUnidades(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableDateTime(dr["FechaInicial"]),
                       DB.GetNullableDateTime(dr["FechaFinal"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.Int32? numeroeconomico)
        {
            string sqlstr = @"[dbo].[usp_HistorialConductoresUnidades_Get]";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            return DB.QueryDS(sqlstr, m_params).Tables[0];
            //return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_HistorialConductoresUnidades

    public class Vista_KilometrajesPromedio
    {

        #region Constructors
        public Vista_KilometrajesPromedio()
        {
        }

        public Vista_KilometrajesPromedio(
            System.String empresa,
            System.String estacion,
            System.Int32? numeroeconomico,
            System.Int32? kminicial,
            System.Int32? kmfinal,
            System.Int32? promediodiario
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.NumeroEconomico = numeroeconomico;
            this.KmInicial = kminicial;
            this.KmFinal = kmfinal;
            this.PromedioDiario = promediodiario;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _KmInicial;
        public System.Int32? KmInicial
        {
            get { return _KmInicial; }
            set { _KmInicial = value; }
        }

        private System.Int32? _KmFinal;
        public System.Int32? KmFinal
        {
            get { return _KmFinal; }
            set { _KmFinal = value; }
        }

        private System.Int32? _PromedioDiario;
        public System.Int32? PromedioDiario
        {
            get { return _PromedioDiario; }
            set { _PromedioDiario = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_KilometrajesPromedio> Get(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"usp_KilometrajesPromedio";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_KilometrajesPromedio> list = new List<Vista_KilometrajesPromedio>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_KilometrajesPromedio(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["KmInicial"]),
                       DB.GetNullableInt32(dr["KmFinal"]),
                       DB.GetNullableInt32(dr["PromedioDiario"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"dbo.usp_KilometrajesPromedio";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_KilometrajesPromedio

    public class Vista_LicenciasPorVencer
    {
        #region Constructors
        public Vista_LicenciasPorVencer()
        {
        }

        public Vista_LicenciasPorVencer(
            System.Int32? conductor_id,
            System.String nombre,
            System.String licencialiberada,
            System.DateTime? vencelicencia
            )
        {
            this.Conductor_ID = conductor_id;
            this.Nombre = nombre;
            this.LicenciaLiberada = licencialiberada;
            this.VenceLicencia = vencelicencia;
        }

        #endregion

        #region Properties
        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _LicenciaLiberada;
        public System.String LicenciaLiberada
        {
            get { return _LicenciaLiberada; }
            set { _LicenciaLiberada = value; }
        }

        private System.DateTime? _VenceLicencia;
        public System.DateTime? VenceLicencia
        {
            get { return _VenceLicencia; }
            set { _VenceLicencia = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_LicenciasPorVencer> Get(
            System.Int32 estacion_id)
        {
            string sqlstr = @"dbo.usp_LicenciasPorVencer";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_LicenciasPorVencer> list = new List<Vista_LicenciasPorVencer>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_LicenciasPorVencer(
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToString(dr["LicenciaLiberada"]),
                       DB.GetNullableDateTime(dr["VenceLicencia"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 estacion_id)
        {
            string sqlstr = @"dbo.usp_LicenciasPorVencer";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_LicenciasPorVencer

    public class Vista_ConductoresOperativos
    {

        #region Constructors
        public Vista_ConductoresOperativos()
        {
        }

        public Vista_ConductoresOperativos(
            System.Int32? conductor_id,
            System.String nombre,
            System.Boolean? primercursolicencia,
            System.Boolean? segundocursolicencia,
            System.Boolean? examenmedico,
            System.String licencialiberada,
            System.DateTime? vencelicencia,
            System.Int32? cubre,
            System.Int32? titular,
            System.Boolean? nomina
            )
        {
            this.Conductor_ID = conductor_id;
            this.Nombre = nombre;
            this.PrimerCursoLicencia = primercursolicencia;
            this.SegundoCursoLicencia = segundocursolicencia;
            this.ExamenMedico = examenmedico;
            this.LicenciaLiberada = licencialiberada;
            this.VenceLicencia = vencelicencia;
            this.Cubre = cubre;
            this.Titular = titular;
            this.Nomina = nomina;
        }

        #endregion

        #region Properties
        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Boolean? _PrimerCursoLicencia;
        public System.Boolean? PrimerCursoLicencia
        {
            get { return _PrimerCursoLicencia; }
            set { _PrimerCursoLicencia = value; }
        }

        private System.Boolean? _SegundoCursoLicencia;
        public System.Boolean? SegundoCursoLicencia
        {
            get { return _SegundoCursoLicencia; }
            set { _SegundoCursoLicencia = value; }
        }

        private System.Boolean? _ExamenMedico;
        public System.Boolean? ExamenMedico
        {
            get { return _ExamenMedico; }
            set { _ExamenMedico = value; }
        }

        private System.String _LicenciaLiberada;
        public System.String LicenciaLiberada
        {
            get { return _LicenciaLiberada; }
            set { _LicenciaLiberada = value; }
        }

        private System.DateTime? _VenceLicencia;
        public System.DateTime? VenceLicencia
        {
            get { return _VenceLicencia; }
            set { _VenceLicencia = value; }
        }

        private System.Int32? _Cubre;
        public System.Int32? Cubre
        {
            get { return _Cubre; }
            set { _Cubre = value; }
        }

        private System.Int32? _Titular;
        public System.Int32? Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }

        private System.Boolean? _Nomina;
        public System.Boolean? Nomina
        {
            get { return _Nomina; }
            set { _Nomina = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ConductoresOperativos> Get(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.String nombre,
            System.Int32? numeroeconomico)
        {
            string sqlstr = @"dbo.usp_Vista_ConductoresOperativos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<Vista_ConductoresOperativos> list = new List<Vista_ConductoresOperativos>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ConductoresOperativos(
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
                       DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
                       DB.GetNullableBoolean(dr["ExamenMedico"]),
                       Convert.ToString(dr["LicenciaLiberada"]),
                       DB.GetNullableDateTime(dr["VenceLicencia"]),
                       DB.GetNullableInt32(dr["Cubre"]),
                       DB.GetNullableInt32(dr["Titular"]),
                       DB.GetNullableBoolean(dr["Nomina"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.String nombre,
            System.Int32? numeroeconomico)
        {
            string sqlstr = @"dbo.usp_Vista_ConductoresOperativos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ConductoresOperativos

    public class Vista_Usuarios_Empresas
    {
        public override string ToString()
        {
            return this.Nombre;
        }

        #region Constructors
        public Vista_Usuarios_Empresas()
        {
        }

        public Vista_Usuarios_Empresas(
            System.Int32? empresa_id,
            System.String nombre,
            System.Boolean? espermitido
            )
        {
            this.Empresa_ID = empresa_id;
            this.Nombre = nombre;
            this.EsPermitido = espermitido;
        }

        #endregion

        #region Properties
        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Boolean? _EsPermitido;
        public System.Boolean? EsPermitido
        {
            get { return _EsPermitido; }
            set { _EsPermitido = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Usuarios_Empresas> Get(
            System.String usuario_id)
        {
            string sqlstr = @"dbo.usp_Vista_UsuariosEmpresa";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_Usuarios_Empresas> list = new List<Vista_Usuarios_Empresas>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Usuarios_Empresas(
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableBoolean(dr["EsPermitido"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id)
        {
            string sqlstr = @"usp_Vista_UsuariosEmpresa";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        #endregion
    } // End Class Vista_Usuarios_Empresas

    public class Vista_Usuarios_Estaciones
    {
        public override string ToString()
        {
            return this.Nombre;
        }

        #region Constructors
        public Vista_Usuarios_Estaciones()
        {
        }

        public Vista_Usuarios_Estaciones(
            System.Int32? estacion_id,
            System.String nombre,
            System.Boolean? espermitido
            )
        {
            this.Estacion_ID = estacion_id;
            this.Nombre = nombre;
            this.EsPermitido = espermitido;
        }

        #endregion

        #region Properties
        private System.Int32? _Estacion_ID;
        public System.Int32? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Boolean? _EsPermitido;
        public System.Boolean? EsPermitido
        {
            get { return _EsPermitido; }
            set { _EsPermitido = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Usuarios_Estaciones> Get(
            System.String usuario_id)
        {
            string sqlstr = @"usp_Vista_Usuarios_Estaciones";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_Usuarios_Estaciones> list = new List<Vista_Usuarios_Estaciones>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Usuarios_Estaciones(
                       DB.GetNullableInt32(dr["Estacion_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableBoolean(dr["EsPermitido"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id)
        {
            string sqlstr = @"usp_Vista_Usuarios_Estaciones";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        #endregion
    } // End Class Vista_Usuarios_Estaciones

    //     public class Vista_AtencionClientes
    //     {
    //          #region Constructors
    //          public Vista_AtencionClientes()
    //          {
    //          }

    //          public Vista_AtencionClientes(
    //              System.Int32? atencioncliente_id,
    //              System.String tipoatencioncliente,
    //              System.String tipoincidencia,
    //              System.String empresa,
    //              System.String estacion,
    //              System.String conductor,
    //              System.Int32? unidad,
    //              System.String usuario_id,
    //              System.String numeroconfirmacion,
    //              System.DateTime? fechainicial,
    //              System.DateTime? fechafinal,
    //              System.Boolean? esentregado,
    //              System.Boolean? escerrado,
    //              System.String motivo,
    //              System.String solucion,
    //              System.Int32? atencionclienteincidencia_id,
    //              System.String foliocortesia,
    //              System.DateTime? fechavencimiento,
    //              System.String objetoextraviado,
    //              System.String observaciones,
    //              System.Decimal? montocargo,
    //              System.Boolean? esautorizadoreembolso,
    //              System.DateTime? fechaautorizacionreembolso
    //              )
    //          {
    //               this.AtencionCliente_ID = atencioncliente_id;
    //               this.TipoAtencionCliente = tipoatencioncliente;
    //               this.TipoIncidencia = tipoincidencia;
    //               this.Empresa = empresa;
    //               this.Estacion = estacion;
    //               this.Conductor = conductor;
    //               this.Unidad = unidad;
    //               this.Usuario_ID = usuario_id;
    //               this.NumeroConfirmacion = numeroconfirmacion;
    //               this.FechaInicial = fechainicial;
    //               this.FechaFinal = fechafinal;
    //               this.EsEntregado = esentregado;
    //               this.EsCerrado = escerrado;
    //               this.Motivo = motivo;
    //               this.Solucion = solucion;
    //               this.AtencionClienteIncidencia_ID = atencionclienteincidencia_id;
    //               this.FolioCortesia = foliocortesia;
    //               this.FechaVencimiento = fechavencimiento;
    //               this.ObjetoExtraviado = objetoextraviado;
    //               this.Observaciones = observaciones;
    //               this.MontoCargo = montocargo;
    //               this.EsAutorizadoReembolso = esautorizadoreembolso;
    //               this.FechaAutorizacionReembolso = fechaautorizacionreembolso;
    //          }

    //          #endregion

    //          #region Properties
    //          private System.Int32? _AtencionCliente_ID;
    //          public System.Int32? AtencionCliente_ID
    //          {
    //               get { return _AtencionCliente_ID; }
    //               set { _AtencionCliente_ID = value; }
    //          }

    //          private System.String _TipoAtencionCliente;
    //          public System.String TipoAtencionCliente
    //          {
    //               get { return _TipoAtencionCliente; }
    //               set { _TipoAtencionCliente = value; }
    //          }

    //          private System.String _TipoIncidencia;
    //          public System.String TipoIncidencia
    //          {
    //               get { return _TipoIncidencia; }
    //               set { _TipoIncidencia = value; }
    //          }

    //          private System.String _Empresa;
    //          public System.String Empresa
    //          {
    //               get { return _Empresa; }
    //               set { _Empresa = value; }
    //          }

    //          private System.String _Estacion;
    //          public System.String Estacion
    //          {
    //               get { return _Estacion; }
    //               set { _Estacion = value; }
    //          }

    //          private System.String _Conductor;
    //          public System.String Conductor
    //          {
    //               get { return _Conductor; }
    //               set { _Conductor = value; }
    //          }

    //          private System.Int32? _Unidad;
    //          public System.Int32? Unidad
    //          {
    //               get { return _Unidad; }
    //               set { _Unidad = value; }
    //          }

    //          private System.String _Usuario_ID;
    //          public System.String Usuario_ID
    //          {
    //               get { return _Usuario_ID; }
    //               set { _Usuario_ID = value; }
    //          }

    //          private System.String _NumeroConfirmacion;
    //          public System.String NumeroConfirmacion
    //          {
    //               get { return _NumeroConfirmacion; }
    //               set { _NumeroConfirmacion = value; }
    //          }

    //          private System.DateTime? _FechaInicial;
    //          public System.DateTime? FechaInicial
    //          {
    //               get { return _FechaInicial; }
    //               set { _FechaInicial = value; }
    //          }

    //          private System.DateTime? _FechaFinal;
    //          public System.DateTime? FechaFinal
    //          {
    //               get { return _FechaFinal; }
    //               set { _FechaFinal = value; }
    //          }

    //          private System.Boolean? _EsEntregado;
    //          public System.Boolean? EsEntregado
    //          {
    //               get { return _EsEntregado; }
    //               set { _EsEntregado = value; }
    //          }

    //          private System.Boolean? _EsCerrado;
    //          public System.Boolean? EsCerrado
    //          {
    //               get { return _EsCerrado; }
    //               set { _EsCerrado = value; }
    //          }

    //          private System.String _Motivo;
    //          public System.String Motivo
    //          {
    //               get { return _Motivo; }
    //               set { _Motivo = value; }
    //          }

    //          private System.String _Solucion;
    //          public System.String Solucion
    //          {
    //               get { return _Solucion; }
    //               set { _Solucion = value; }
    //          }

    //          private System.Int32? _AtencionClienteIncidencia_ID;
    //          public System.Int32? AtencionClienteIncidencia_ID
    //          {
    //               get { return _AtencionClienteIncidencia_ID; }
    //               set { _AtencionClienteIncidencia_ID = value; }
    //          }

    //          private System.String _FolioCortesia;
    //          public System.String FolioCortesia
    //          {
    //               get { return _FolioCortesia; }
    //               set { _FolioCortesia = value; }
    //          }

    //          private System.DateTime? _FechaVencimiento;
    //          public System.DateTime? FechaVencimiento
    //          {
    //               get { return _FechaVencimiento; }
    //               set { _FechaVencimiento = value; }
    //          }

    //          private System.String _ObjetoExtraviado;
    //          public System.String ObjetoExtraviado
    //          {
    //               get { return _ObjetoExtraviado; }
    //               set { _ObjetoExtraviado = value; }
    //          }

    //          private System.String _Observaciones;
    //          public System.String Observaciones
    //          {
    //               get { return _Observaciones; }
    //               set { _Observaciones = value; }
    //          }

    //          private System.Decimal? _MontoCargo;
    //          public System.Decimal? MontoCargo
    //          {
    //               get { return _MontoCargo; }
    //               set { _MontoCargo = value; }
    //          }

    //          private System.Boolean? _EsAutorizadoReembolso;
    //          public System.Boolean? EsAutorizadoReembolso
    //          {
    //               get { return _EsAutorizadoReembolso; }
    //               set { _EsAutorizadoReembolso = value; }
    //          }

    //          private System.DateTime? _FechaAutorizacionReembolso;
    //          public System.DateTime? FechaAutorizacionReembolso
    //          {
    //               get { return _FechaAutorizacionReembolso; }
    //               set { _FechaAutorizacionReembolso = value; }
    //          }

    //          #endregion

    //          #region Methods
    //          public static List<Vista_AtencionClientes> Get(
    //              System.Int32? atencioncliente_id,
    //               System.Int32? tipoatencioncliente_id,
    //               System.Int32? unidad_id,
    //               System.String numeroconfirmacion,
    //               System.DateTime? fechainicial,
    //               System.DateTime? fechafinal)
    //          {
    //               string sqlstr = @"SELECT	AC.AtencionCliente_ID,
    //		TAC.Nombre TipoAtencionCliente,
    //		TI.Nombre TipoIncidencia,
    //		E.Nombre Empresa,
    //		EST.Nombre Estacion,
    //		COND.Apellidos + ' ' + COND.Nombre Conductor,
    //		U.NumeroEconomico Unidad,
    //		AC.Usuario_ID,
    //		AC.NumeroConfirmacion,
    //		AC.FechaInicial,
    //		AC.FechaFinal,
    //		AC.EsEntregado,
    //		AC.EsCerrado,
    //		AC.Motivo,
    //		AC.Solucion,
    //		AC.AtencionClienteIncidencia_ID,
    //		AC.FolioCortesia,
    //		AC.FechaVencimiento,
    //		AC.ObjetoExtraviado,
    //		AC.Observaciones,
    //		AC.MontoCargo,
    //		AC.EsAutorizadoReembolso,
    //		AC.FechaAutorizacionReembolso
    //FROM	AtencionClientes AC
    //INNER JOIN	TiposAtencionClientes TAC
    //ON		AC.TipoAtencionCliente_ID = TAC.TipoAtencionCliente_ID
    //LEFT JOIN	TiposIncidencias TI
    //ON		AC.TipoIncidencia_ID = TI.TipoIncidencia_ID
    //INNER JOIN	Empresas E
    //ON		AC.Empresa_ID = E.Empresa_ID
    //INNER JOIN	Estaciones EST
    //ON		AC.Estacion_ID = EST.Estacion_ID
    //INNER JOIN	Conductores COND
    //ON		AC.Conductor_ID = COND.Conductor_ID
    //INNER JOIN	Unidades U
    //ON		AC.Unidad_ID = U.Unidad_ID
    //WHERE	( @AtencionCliente_ID IS NULL OR AC.AtencionCliente_ID = @AtencionCliente_ID )
    //AND		( @TipoAtencionCliente_ID IS NULL OR AC.TipoAtencionCliente_ID = @TipoAtencionCliente_ID )
    //AND		( @Unidad_ID IS NULL OR AC.Unidad_ID = @Unidad_ID )
    //AND		( @NumeroConfirmacion IS NULL OR AC.NumeroConfirmacion = @NumeroConfirmacion )
    //AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR ( AC.FechaInicial BETWEEN @FechaInicial AND @FechaFinal ) )";

    //               Hashtable m_params = new Hashtable();
    //               m_params.Add("@AtencionCliente_ID", atencioncliente_id);
    //               m_params.Add("@TipoAtencionCliente_ID", tipoatencioncliente_id);
    //               m_params.Add("@Unidad_ID", unidad_id);
    //               m_params.Add("@NumeroConfirmacion", numeroconfirmacion);
    //               m_params.Add("@FechaInicial", fechainicial);
    //               m_params.Add("@FechaFinal", fechafinal);

    //               List<Vista_AtencionClientes> list = new List<Vista_AtencionClientes>();
    //               DataTable dt = DB.QueryCommand(sqlstr, m_params);
    //               foreach (DataRow dr in dt.Rows)
    //               {
    //                    list.Add(
    //                        new Vista_AtencionClientes(
    //                            DB.GetNullableInt32(dr["AtencionCliente_ID"]),
    //                            Convert.ToString(dr["TipoAtencionCliente"]),
    //                            Convert.ToString(dr["TipoIncidencia"]),
    //                            Convert.ToString(dr["Empresa"]),
    //                            Convert.ToString(dr["Estacion"]),
    //                            Convert.ToString(dr["Conductor"]),
    //                            DB.GetNullableInt32(dr["Unidad"]),
    //                            Convert.ToString(dr["Usuario_ID"]),
    //                            Convert.ToString(dr["NumeroConfirmacion"]),
    //                            DB.GetNullableDateTime(dr["FechaInicial"]),
    //                            DB.GetNullableDateTime(dr["FechaFinal"]),
    //                            DB.GetNullableBoolean(dr["EsEntregado"]),
    //                            DB.GetNullableBoolean(dr["EsCerrado"]),
    //                            Convert.ToString(dr["Motivo"]),
    //                            Convert.ToString(dr["Solucion"]),
    //                            DB.GetNullableInt32(dr["AtencionClienteIncidencia_ID"]),
    //                            Convert.ToString(dr["FolioCortesia"]),
    //                            DB.GetNullableDateTime(dr["FechaVencimiento"]),
    //                            Convert.ToString(dr["ObjetoExtraviado"]),
    //                            Convert.ToString(dr["Observaciones"]),
    //                            DB.GetNullableDecimal(dr["MontoCargo"]),
    //                            DB.GetNullableBoolean(dr["EsAutorizadoReembolso"]),
    //                            DB.GetNullableDateTime(dr["FechaAutorizacionReembolso"])
    //                            )
    //                        );
    //               }
    //               return list;
    //          } // End GetData

    //          public static DataTable GetDataTable(
    //              System.Int32? atencioncliente_id,
    //               System.Int32? tipoatencioncliente_id,
    //               System.Int32? unidad_id,
    //               System.String numeroconfirmacion,
    //               System.DateTime? fechainicial,
    //               System.DateTime? fechafinal)
    //          {
    //               string sqlstr = @"SELECT	AC.AtencionCliente_ID,
    //		TAC.Nombre TipoAtencionCliente,
    //		TI.Nombre TipoIncidencia,
    //		E.Nombre Empresa,
    //		EST.Nombre Estacion,
    //		COND.Apellidos + ' ' + COND.Nombre Conductor,
    //		U.NumeroEconomico Unidad,
    //		AC.Usuario_ID,
    //		AC.NumeroConfirmacion,
    //		AC.FechaInicial,
    //		AC.FechaFinal,
    //		AC.EsEntregado,
    //		AC.EsCerrado,
    //		AC.Motivo,
    //		AC.Solucion,
    //		AC.AtencionClienteIncidencia_ID,
    //		AC.FolioCortesia,
    //		AC.FechaVencimiento,
    //		AC.ObjetoExtraviado,
    //		AC.Observaciones,
    //		AC.MontoCargo,
    //		AC.EsAutorizadoReembolso,
    //		AC.FechaAutorizacionReembolso
    //FROM	AtencionClientes AC
    //INNER JOIN	TiposAtencionClientes TAC
    //ON		AC.TipoAtencionCliente_ID = TAC.TipoAtencionCliente_ID
    //LEFT JOIN	TiposIncidencias TI
    //ON		AC.TipoIncidencia_ID = TI.TipoIncidencia_ID
    //INNER JOIN	Empresas E
    //ON		AC.Empresa_ID = E.Empresa_ID
    //INNER JOIN	Estaciones EST
    //ON		AC.Estacion_ID = EST.Estacion_ID
    //INNER JOIN	Conductores COND
    //ON		AC.Conductor_ID = COND.Conductor_ID
    //INNER JOIN	Unidades U
    //ON		AC.Unidad_ID = U.Unidad_ID
    //WHERE	( @AtencionCliente_ID IS NULL OR AC.AtencionCliente_ID = @AtencionCliente_ID )
    //AND		( @TipoAtencionCliente_ID IS NULL OR AC.TipoAtencionCliente_ID = @TipoAtencionCliente_ID )
    //AND		( @Unidad_ID IS NULL OR AC.Unidad_ID = @Unidad_ID )
    //AND		( @NumeroConfirmacion IS NULL OR AC.NumeroConfirmacion = @NumeroConfirmacion )
    //AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR ( AC.FechaInicial BETWEEN @FechaInicial AND @FechaFinal ) )";

    //               Hashtable m_params = new Hashtable();
    //               m_params.Add("@AtencionCliente_ID", atencioncliente_id);
    //               m_params.Add("@TipoAtencionCliente_ID", tipoatencioncliente_id);
    //               m_params.Add("@Unidad_ID", unidad_id);
    //               m_params.Add("@NumeroConfirmacion", numeroconfirmacion);
    //               m_params.Add("@FechaInicial", fechainicial);
    //               m_params.Add("@FechaFinal", fechafinal);

    //               return DB.QueryCommand(sqlstr, m_params);
    //          } // End GetDataTable


    //          #endregion
    //     } // End Class Vista_AtencionClientes

    public class Vista_Conceptos
    {

        #region Constructors
        public Vista_Conceptos()
        {
        }

        public Vista_Conceptos(
            System.Int32? concepto_id,
            System.String nombre,
            System.Int32? cuenta_id,
            System.String cuenta,
            System.Boolean? enrecibo,
            System.Boolean? visiblerecibo,
            System.Boolean? activo
            )
        {
            this.Concepto_ID = concepto_id;
            this.Nombre = nombre;
            this.Cuenta_ID = cuenta_id;
            this.Cuenta = cuenta;
            this.EnRecibo = enrecibo;
            this.VisibleRecibo = visiblerecibo;
            this.Activo = activo;
        }

        #endregion

        #region Properties
        private System.Int32? _Concepto_ID;
        public System.Int32? Concepto_ID
        {
            get { return _Concepto_ID; }
            set { _Concepto_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Int32? _Cuenta_ID;
        public System.Int32? Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Boolean? _EnRecibo;
        public System.Boolean? EnRecibo
        {
            get { return _EnRecibo; }
            set { _EnRecibo = value; }
        }

        private System.Boolean? _VisibleRecibo;
        public System.Boolean? VisibleRecibo
        {
            get { return _VisibleRecibo; }
            set { _VisibleRecibo = value; }
        }

        private System.Boolean? _Activo;
        public System.Boolean? Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Conceptos> Get(
            System.Int32? concepto_id,
            System.Int32? cuenta_id)
        {
            string sqlstr = @"usp_Vista_Conceptos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Concepto_ID", concepto_id);
            m_params.Add("@Cuenta_ID", cuenta_id);

            List<Vista_Conceptos> list = new List<Vista_Conceptos>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Conceptos(
                       DB.GetNullableInt32(dr["Concepto_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       DB.GetNullableBoolean(dr["EnRecibo"]),
                       DB.GetNullableBoolean(dr["VisibleRecibo"]),
                       DB.GetNullableBoolean(dr["Activo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? concepto_id,
            System.Int32? cuenta_id)
        {
            string sqlstr = @"usp_Vista_Conceptos";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Concepto_ID", concepto_id);
            m_params.Add("@Cuenta_ID", cuenta_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_Conceptos

    public class Vista_Empresas_Cuentas
    {

        #region Constructors
        public Vista_Empresas_Cuentas()
        {
        }

        public Vista_Empresas_Cuentas(
            System.Int32? empresa_id,
            System.String empresa,
            System.Int32? cuenta_id,
            System.String cuenta
            )
        {
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Cuenta_ID = cuenta_id;
            this.Cuenta = cuenta;
        }

        #endregion

        #region Properties
        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _Cuenta_ID;
        public System.Int32? Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Empresas_Cuentas> Get(
            System.Int32? empresa_id)
        {
            string sqlstr = @"usp_Vista_Empresas_Cuentas";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);

            List<Vista_Empresas_Cuentas> list = new List<Vista_Empresas_Cuentas>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Empresas_Cuentas(
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? empresa_id)
        {
            string sqlstr = @"usp_Vista_Empresas_Cuentas";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_Empresas_Cuentas

    public class Vista_SaldosTotalesUnidades
    {

        #region Constructors
        public Vista_SaldosTotalesUnidades()
        {
        }

        public Vista_SaldosTotalesUnidades(
            System.String empresa,
            System.String estacion,
            System.Int32? unidad_id,
            System.Int32? unidad,
            System.Decimal? ingreso,
            System.Decimal? gasto,
            System.Decimal? saldo
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Unidad_ID = unidad_id;
            this.Unidad = unidad;
            this.Ingreso = ingreso;
            this.Gasto = gasto;
            this.Saldo = saldo;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Decimal? _Ingreso;
        public System.Decimal? Ingreso
        {
            get { return _Ingreso; }
            set { _Ingreso = value; }
        }

        private System.Decimal? _Gasto;
        public System.Decimal? Gasto
        {
            get { return _Gasto; }
            set { _Gasto = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_SaldosTotalesUnidades> Get(
            System.Int32? unidad_id,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	E.Nombre Empresa,
		EST.Nombre Estacion,
		U.Unidad_ID,
		U.NumeroEconomico Unidad,
		SUM ( CU.Abono ) Ingreso,
		SUM ( CU.Cargo ) Gasto,
		SUM ( CU.Abono - CU.Cargo ) Saldo
FROM	CuentaUnidades CU
INNER JOIN	Unidades U
ON		CU.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	( @Unidad_ID IS NULL OR CU.Unidad_ID = @Unidad_ID )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
GROUP BY	E.Nombre,
		EST.Nombre,
		U.Unidad_ID,
		U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_SaldosTotalesUnidades> list = new List<Vista_SaldosTotalesUnidades>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_SaldosTotalesUnidades(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableDecimal(dr["Ingreso"]),
                       DB.GetNullableDecimal(dr["Gasto"]),
                       DB.GetNullableDecimal(dr["Saldo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? unidad_id,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	E.Nombre Empresa,
		EST.Nombre Estacion,
		U.Unidad_ID,
		U.NumeroEconomico Unidad,
		SUM ( CU.Abono ) Ingreso,
		SUM ( CU.Cargo ) Gasto,
		SUM ( CU.Abono - CU.Cargo ) Saldo
FROM	CuentaUnidades CU
INNER JOIN	Unidades U
ON		CU.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	( @Unidad_ID IS NULL OR CU.Unidad_ID = @Unidad_ID )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
GROUP BY	E.Nombre,
		EST.Nombre,
		U.Unidad_ID,
		U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_SaldosTotalesUnidades

    public class Vista_SaldosUnidades
    {

        #region Constructors
        public Vista_SaldosUnidades()
        {
        }

        public Vista_SaldosUnidades(
            System.Int32? unidad_id,
            System.Int32? unidad,
            System.Int32? empresa_id,
            System.String empresa,
            System.Int32? cuenta_id,
            System.String cuenta,
            System.Decimal? saldo
            )
        {
            this.Unidad_ID = unidad_id;
            this.Unidad = unidad;
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Cuenta_ID = cuenta_id;
            this.Cuenta = cuenta;
            this.Saldo = saldo;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _Cuenta_ID;
        public System.Int32? Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_SaldosUnidades> Get(
            System.Int32? unidad_id,
            System.Int32? empresa_id,
            System.Int32? cuenta_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID,
		U.NumeroEconomico Unidad,
		E.Empresa_ID,
		E.Nombre Empresa,		
		C.Cuenta_ID,
		C.Nombre Cuenta,		
		SUM( CU.Abono - CU.Cargo ) Saldo
FROM	CuentaUnidades CU
INNER JOIN	Unidades U
ON		CU.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		CU.Empresa_ID = E.Empresa_ID
INNER JOIN	Cuentas C
ON		CU.Cuenta_ID = C.Cuenta_ID
WHERE	( @Unidad_ID IS NULL OR CU.Unidad_ID = @Unidad_ID )
AND		( @Empresa_ID IS NULL OR CU.Empresa_ID = @Empresa_ID )
AND		( @Cuenta_ID IS NULL OR CU.Cuenta_ID = @Cuenta_ID )
GROUP BY	U.Unidad_ID,
		U.NumeroEconomico,
		E.Empresa_ID,
		E.Nombre,		
		C.Cuenta_ID,
		C.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Cuenta_ID", cuenta_id);

            List<Vista_SaldosUnidades> list = new List<Vista_SaldosUnidades>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_SaldosUnidades(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       DB.GetNullableDecimal(dr["Saldo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? unidad_id,
            System.Int32? empresa_id,
            System.Int32? cuenta_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID,
		U.NumeroEconomico Unidad,
		E.Empresa_ID,
		E.Nombre Empresa,		
		C.Cuenta_ID,
		C.Nombre Cuenta,		
		SUM( CU.Abono - CU.Cargo ) Saldo
FROM	CuentaUnidades CU
INNER JOIN	Unidades U
ON		CU.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		CU.Empresa_ID = E.Empresa_ID
INNER JOIN	Cuentas C
ON		CU.Cuenta_ID = C.Cuenta_ID
WHERE	( @Unidad_ID IS NULL OR CU.Unidad_ID = @Unidad_ID )
AND		( @Empresa_ID IS NULL OR CU.Empresa_ID = @Empresa_ID )
AND		( @Cuenta_ID IS NULL OR CU.Cuenta_ID = @Cuenta_ID )
GROUP BY	U.Unidad_ID,
		U.NumeroEconomico,
		E.Empresa_ID,
		E.Nombre,		
		C.Cuenta_ID,
		C.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Cuenta_ID", cuenta_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_SaldosUnidades

    public class Vista_Reporte_Locaciones
    {

        #region Constructors
        public Vista_Reporte_Locaciones()
        {
        }

        public Vista_Reporte_Locaciones(
            System.String empresa,
            System.String estacion,
            System.Int32? unidad_id,
            System.String locacion,
            System.String contrato,
            System.Int32? conGasolina,
            System.Int32? conEquipoDeGas
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Unidad_ID = unidad_id;
            this.Locacion = locacion;
            this.Contrato = contrato;
            this.ConGasolina = conGasolina;
            this.ConEquipoDeGas = conEquipoDeGas;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.String _Locacion;
        public System.String Locacion
        {
            get { return _Locacion; }
            set { _Locacion = value; }
        }

        private System.String _Contrato;
        public System.String Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }

        private System.Int32? _conGasolina;
        public System.Int32? ConGasolina
        {
            get { return _conGasolina; }
            set { _conGasolina = value; }
        }

        private System.Int32? _conEquipoDeGas;
        public System.Int32? ConEquipoDeGas
        {
            get { return _conEquipoDeGas; }
            set { _conEquipoDeGas = value; }
        }
        #endregion

        #region Methods
        public static List<Vista_Reporte_Locaciones> Get(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Obtiene_ReporteLocaciones";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Reporte_Locaciones> list = new List<Vista_Reporte_Locaciones>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Reporte_Locaciones(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Contrato"]),
                       DB.GetNullableInt32(dr["ConEquipoDeGas"]),
                       DB.GetNullableInt32(dr["ConGasolina"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Obtiene_ReporteLocaciones";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_Reporte_Locaciones


    public class Vista_ReporteRecaudacionPorEmpresa
    {

        #region Constructors
        public Vista_ReporteRecaudacionPorEmpresa()
        {
        }

        public Vista_ReporteRecaudacionPorEmpresa(
            System.DateTime? fecha,
            System.String estacion,
            System.String cuenta,
            System.Decimal? total
            )
        {
            this.Fecha = fecha;
            this.Estacion = estacion;
            this.Cuenta = cuenta;
            this.Total = total;
        }

        #endregion

        #region Properties
        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteRecaudacionPorEmpresa> Get(
            System.Int32? empresa_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	CONVERT(DATE,CC.Fecha) Fecha,
		EST.Nombre Estacion,
		CU.Nombre Cuenta,
		SUM(CC.Abono - CC.Cargo) Total
FROM	CuentaCajas CC
INNER JOIN	Estaciones EST
ON		CC.Estacion_ID = EST.Estacion_ID
INNER JOIN	Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
WHERE	( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	CONVERT(DATE,CC.Fecha),
			EST.Nombre,
			CU.Nombre
ORDER BY	CONVERT(DATE,CC.Fecha), EST.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_ReporteRecaudacionPorEmpresa> list = new List<Vista_ReporteRecaudacionPorEmpresa>();

            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteRecaudacionPorEmpresa(
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Cuenta"]),
                       DB.GetNullableDecimal(dr["Total"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? empresa_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	CONVERT(DATE,CC.Fecha) Fecha,
		EST.Nombre Estacion,
		CU.Nombre Cuenta,
		SUM(CC.Abono - CC.Cargo) Total
FROM	CuentaCajas CC
INNER JOIN	Estaciones EST
ON		CC.Estacion_ID = EST.Estacion_ID
INNER JOIN	Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
WHERE	( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	CONVERT(DATE,CC.Fecha),
			EST.Nombre,
			CU.Nombre
ORDER BY	CONVERT(DATE,CC.Fecha), EST.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteRecaudacionPorEmpresa

    public class Vista_ProductividadServicios
    {

        #region Constructors
        public Vista_ProductividadServicios()
        {
        }

        public Vista_ProductividadServicios(
            System.DateTime? fecha,
            System.Int32? numeroeconomico,
            System.Int32? conductor_Id,
            System.String conductor,
            System.Int32? servicios,
            System.Int32? productividad,
            System.Decimal? total,
            System.Decimal? pagoconductor
            )
        {
            this.Fecha = fecha;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_Id = conductor_Id;
            this.Conductor = conductor;
            this.Servicios = servicios;
            this.Productividad = productividad;
            this.Total = total;
            this.PagoConductor = pagoconductor;
        }

        #endregion

        #region Properties
        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _Conductor_Id;
        public System.Int32? Conductor_Id
        {
            get { return _Conductor_Id; }
            set { _Conductor_Id = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Servicios;
        public System.Int32? Servicios
        {
            get { return _Servicios; }
            set { _Servicios = value; }
        }

        private System.Int32? _Productividad;
        public System.Int32? Productividad
        {
            get { return _Productividad; }
            set { _Productividad = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.Decimal? _PagoConductor;
        public System.Decimal? PagoConductor
        {
            get { return _PagoConductor; }
            set { _PagoConductor = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ProductividadServicios> Get(
            System.Int32? numeroeconomico,
            System.String nombre,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"SELECT	CONVERT(DATE, T.Fecha) Fecha,
		U.NumeroEconomico,
        C.Conductor_ID,
		UPPER(C.Apellidos + ' ' + C.Nombre) Conductor,		
		S.Servicios,
		S.Productividad,		
		S.PagoConductor Total,
		S.PagoConductor - CC.Pagos PagoConductor		
FROM	Tickets T
INNER JOIN	Conductores C
ON		T.Conductor_ID = C.Conductor_ID
INNER JOIN	Unidades U
ON		T.Unidad_ID = U.Unidad_ID
INNER JOIN	(
SELECT	Ticket_ID,
		SUM(Abono) Pagos
FROM	CuentaConductores
GROUP BY	Ticket_ID
)	CC
ON	CC.Ticket_ID = T.Ticket_ID
INNER JOIN	(
SELECT	Ticket_ID,	
		COUNT(*) Servicios,	
		SUM(PagoConductor) PagoConductor,
		SUM(CASE 
		WHEN TipoServicioConductor_ID IS NULL THEN 1
		ELSE 0
		END) Productividad
FROM	Servicios
WHERE	EstatusServicio_ID <> 4
AND		( Empresa_ID = @Empresa_ID )
AND		( Estacion_ID = @Estacion_ID )
GROUP BY	Ticket_ID
)	S
ON	T.Ticket_ID = S.Ticket_ID
WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
AND		( @Nombre IS NULL OR C.Apellidos + ' ' + C.Nombre LIKE @Nombre + '%' )
AND		T.Fecha BETWEEN @FechaInicial AND @FechaFinal
ORDER BY	CONVERT(DATE,T.Fecha),
			U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ProductividadServicios> list = new List<Vista_ProductividadServicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ProductividadServicios(
                       DB.GetNullableDateTime(dr["Fecha"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Servicios"]),
                       DB.GetNullableInt32(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["Total"]),
                       DB.GetNullableDecimal(dr["PagoConductor"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? numeroeconomico,
            System.String nombre,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"SELECT	CONVERT(DATE, T.Fecha) Fecha,
		U.NumeroEconomico,
        C.Conductor_ID,
		UPPER(C.Apellidos + ' ' + C.Nombre) Conductor,		
		S.Servicios,
		S.Productividad,		
		S.PagoConductor Total,
		S.PagoConductor - CC.Pagos PagoConductor		
FROM	Tickets T
INNER JOIN	Conductores C
ON		T.Conductor_ID = C.Conductor_ID
INNER JOIN	Unidades U
ON		T.Unidad_ID = U.Unidad_ID
INNER JOIN	(
SELECT	Ticket_ID,
		SUM(Abono) Pagos
FROM	CuentaConductores
GROUP BY	Ticket_ID
)	CC
ON	CC.Ticket_ID = T.Ticket_ID
INNER JOIN	(
SELECT	Ticket_ID,	
		COUNT(*) Servicios,	
		SUM(PagoConductor) PagoConductor,
		SUM(CASE 
		WHEN TipoServicioConductor_ID IS NULL THEN 1
		ELSE 0
		END) Productividad
FROM	Servicios
WHERE	EstatusServicio_ID <> 4
AND		( Empresa_ID = @Empresa_ID )
AND		( Estacion_ID = @Estacion_ID )
GROUP BY	Ticket_ID
)	S
ON	T.Ticket_ID = S.Ticket_ID
WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
AND		( @Nombre IS NULL OR C.Apellidos + ' ' + C.Nombre LIKE @Nombre + '%' )
AND		T.Fecha BETWEEN @FechaInicial AND @FechaFinal
ORDER BY	CONVERT(DATE,T.Fecha),
			U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ProductividadServicios

    public class Vista_ProductividadServiciosNomina
    {

        #region Constructors
        public Vista_ProductividadServiciosNomina()
        {
        }

        public Vista_ProductividadServiciosNomina(
            System.DateTime? fecha,
            System.Int32? numeroeconomico,
            System.Int32? conductor_Id,
            System.String conductor,
            System.Int32? servicios,
            System.Int32? productividad,
            System.Decimal? total,
            System.Decimal? pagoconductor
            )
        {
            this.Fecha = fecha;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_Id = conductor_Id;
            this.Conductor = conductor;
            this.Servicios = servicios;
            this.Productividad = productividad;
            this.Total = total;
            this.PagoConductor = pagoconductor;
        }

        #endregion

        #region Properties
        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _Conductor_Id;
        public System.Int32? Conductor_Id
        {
            get { return _Conductor_Id; }
            set { _Conductor_Id = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Servicios;
        public System.Int32? Servicios
        {
            get { return _Servicios; }
            set { _Servicios = value; }
        }

        private System.Int32? _Productividad;
        public System.Int32? Productividad
        {
            get { return _Productividad; }
            set { _Productividad = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.Decimal? _PagoConductor;
        public System.Decimal? PagoConductor
        {
            get { return _PagoConductor; }
            set { _PagoConductor = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ProductividadServiciosNomina> Get(
            System.Int32? numeroeconomico,
            System.String nombre,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"dbo.usp_Obtiene_ProductividadNomina";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ProductividadServiciosNomina> list = new List<Vista_ProductividadServiciosNomina>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ProductividadServiciosNomina(
                       DB.GetNullableDateTime(dr["Fecha"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Servicios"]),
                       DB.GetNullableInt32(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["Total"]),
                       DB.GetNullableDecimal(dr["PagoConductor"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? numeroeconomico,
            System.String nombre,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"usp_Obtiene_ProductividadNomina";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_ProductividadServiciosNomina

    public class Vista_CuentaEmpresasConsolidado
    {

        #region Constructors
        public Vista_CuentaEmpresasConsolidado()
        {
        }

        public Vista_CuentaEmpresasConsolidado(
            System.DateTime? fecha,
            System.String empresa,
            System.Decimal? ingresos
            )
        {
            this.Fecha = fecha;
            this.Empresa = empresa;
            this.Ingresos = ingresos;
        }

        #endregion

        #region Properties
        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Decimal? _Ingresos;
        public System.Decimal? Ingresos
        {
            get { return _Ingresos; }
            set { _Ingresos = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_CuentaEmpresasConsolidado> Get(
            System.Int32? empresa_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	CONVERT(DATE,CE.Fecha) Fecha,
		E.Nombre Empresa,
		SUM(Abono) Ingresos
FROM	CuentaEmpresas CE
INNER JOIN	Empresas E
ON		CE.Empresa_ID = E.Empresa_ID
WHERE	( @Empresa_ID IS NULL OR CE.Empresa_ID = @Empresa_ID )
AND		( CE.Fecha BETWEEN @FechaInicial AND @FechaFinal )
GROUP BY	CONVERT(DATE,CE.Fecha),
			E.Nombre
ORDER BY	CONVERT(DATE,CE.Fecha),
			E.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_CuentaEmpresasConsolidado> list = new List<Vista_CuentaEmpresasConsolidado>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaEmpresasConsolidado(
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableDecimal(dr["Ingresos"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? empresa_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	CONVERT(DATE,CE.Fecha) Fecha,
		E.Nombre Empresa,
		SUM(Abono) Ingresos
FROM	CuentaEmpresas CE
INNER JOIN	Empresas E
ON		CE.Empresa_ID = E.Empresa_ID
WHERE	( @Empresa_ID IS NULL OR CE.Empresa_ID = @Empresa_ID )
AND		( CE.Fecha BETWEEN @FechaInicial AND @FechaFinal )
GROUP BY	CONVERT(DATE,CE.Fecha),
			E.Nombre
ORDER BY	CONVERT(DATE,CE.Fecha),
			E.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_CuentaEmpresasConsolidado


    public class SelectConceptos
    {

        #region Constructors
        public SelectConceptos()
        {
        }

        public SelectConceptos(
            System.Int32? concepto_id,
            System.String nombre
            )
        {
            this.Concepto_ID = concepto_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties
        private System.Int32? _Concepto_ID;
        public System.Int32? Concepto_ID
        {
            get { return _Concepto_ID; }
            set { _Concepto_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public static List<SelectConceptos> Get(
            System.Object cuenta_id,
            System.String nombre)
        {
            string sqlstr = @"SELECT	NULL Concepto_ID, 
		'-NINGUNO-' Nombre 
UNION ALL 
SELECT	Concepto_ID, Nombre 
FROM	Conceptos
WHERE	( @Cuenta_ID IS NULL OR Cuenta_ID = @Cuenta_ID )
AND		( @Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Cuenta_ID", cuenta_id);
            m_params.Add("@Nombre", nombre);

            List<SelectConceptos> list = new List<SelectConceptos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectConceptos(
                       DB.GetNullableInt32(dr["Concepto_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object cuenta_id,
            System.String nombre)
        {
            string sqlstr = @"SELECT	NULL Concepto_ID, 
		'-NINGUNO-' Nombre 
UNION ALL 
SELECT	Concepto_ID, Nombre 
FROM	Conceptos
WHERE	( @Cuenta_ID IS NULL OR Cuenta_ID = @Cuenta_ID )
AND		( @Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Cuenta_ID", cuenta_id);
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class SelectConceptos


    public class Vista_Usuarios
    {

        #region Constructors
        public Vista_Usuarios()
        {
        }

        public Vista_Usuarios(
            System.String usuario_id,
            System.String nombre,
            System.String apellidos,
            System.String email,
            System.Boolean? activo,
            System.String empresa,
            System.String estacion
            )
        {
            this.Usuario_ID = usuario_id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Email = email;
            this.Activo = activo;
            this.Empresa = empresa;
            this.Estacion = estacion;
        }

        #endregion

        #region Properties
        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Apellidos;
        public System.String Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        private System.String _Email;
        public System.String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private System.Boolean? _Activo;
        public System.Boolean? Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Usuarios> Get(
            System.String usuario_id,
            System.String nombre,
            System.String apellidos,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	U.Usuario_ID,
		U.Nombre,
		U.Apellidos,
		U.Email,
		U.Activo,
		E.Nombre Empresa,
		EST.Nombre Estacion
FROM	Usuarios U
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_Id
INNER JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	( @Usuario_ID IS NULL OR U.Usuario_ID = @Usuario_ID )
AND		( @Nombre IS NULL OR U.Nombre LIKE @Nombre + '%' )
AND		( @Apellidos IS NULL OR U.Apellidos LIKE @Apellidos + '%' )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Apellidos", apellidos);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Usuarios> list = new List<Vista_Usuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Usuarios(
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToString(dr["Apellidos"]),
                       Convert.ToString(dr["Email"]),
                       DB.GetNullableBoolean(dr["Activo"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static Vista_Usuarios Get(
            System.String usuario_id)
        {
            string sqlstr = @"SELECT	U.Usuario_ID,
		U.Nombre,
		U.Apellidos,
		U.Email,
		U.Activo,
		E.Nombre Empresa,
		EST.Nombre Estacion
FROM	Usuarios U
LEFT JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_Id
LEFT JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	U.Usuario_ID = @Usuario_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_Usuarios> list = new List<Vista_Usuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow dr = dt.Rows[0];

            return new Vista_Usuarios(
                Convert.ToString(dr["Usuario_ID"]),
                Convert.ToString(dr["Nombre"]),
                Convert.ToString(dr["Apellidos"]),
                Convert.ToString(dr["Email"]),
                DB.GetNullableBoolean(dr["Activo"]),
                Convert.ToString(dr["Empresa"]),
                Convert.ToString(dr["Estacion"])
            );
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.String nombre,
            System.String apellidos,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	U.Usuario_ID,
		U.Nombre,
		U.Apellidos,
		U.Email,
		U.Activo,
		E.Nombre Empresa,
		EST.Nombre Estacion
FROM	Usuarios U
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_Id
INNER JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	( @Usuario_ID IS NULL OR U.Usuario_ID = @Usuario_ID )
AND		( @Nombre IS NULL OR U.Nombre LIKE @Nombre + '%' )
AND		( @Apellidos IS NULL OR U.Apellidos LIKE @Apellidos + '%' )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Apellidos", apellidos);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Usuarios

    public class Vista_Usuarios_Cajas
    {

        #region Constructors
        public Vista_Usuarios_Cajas()
        {
        }

        public Vista_Usuarios_Cajas(
            System.String usuario_id,
            System.String nombre,
            System.Int32? caja_id,
            System.String caja
            )
        {
            this.Usuario_ID = usuario_id;
            this.Nombre = nombre;
            this.Caja_ID = caja_id;
            this.Caja = caja;
        }

        #endregion

        #region Properties
        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Int32? _Caja_ID;
        public System.Int32? Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Usuarios_Cajas> Get(
            System.String usuario_id)
        {
            string sqlstr = @"SELECT	U.Usuario_ID,
		U.Apellidos + ' ' + U.Nombre Nombre,
		C.Caja_ID,
		C.Nombre Caja
FROM	Usuarios_Cajas UC
INNER JOIN	Cajas C
ON		C.Caja_ID = UC.Caja_ID
INNER JOIN	Usuarios U
ON		UC.Usuario_ID = U.Usuario_ID
WHERE	( @Usuario_ID IS NULL OR U.Usuario_ID = @Usuario_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_Usuarios_Cajas> list = new List<Vista_Usuarios_Cajas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Usuarios_Cajas(
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableInt32(dr["Caja_ID"]),
                       Convert.ToString(dr["Caja"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id)
        {
            string sqlstr = @"SELECT	U.Usuario_ID,
		U.Apellidos + ' ' + U.Nombre Nombre,
		C.Caja_ID,
		C.Nombre Caja
FROM	Usuarios_Cajas UC
INNER JOIN	Cajas C
ON		C.Caja_ID = UC.Caja_ID
INNER JOIN	Usuarios U
ON		UC.Usuario_ID = U.Usuario_ID
WHERE	( @Usuario_ID IS NULL OR U.Usuario_ID = @Usuario_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Usuarios_Cajas


    public class Vista_ServiciosRegresos
    {

        #region Constructors
        public Vista_ServiciosRegresos()
        {
        }

        public Vista_ServiciosRegresos(
            System.String servicio_id,
            System.String conductor,
            System.Int32? unidad,
            System.Decimal? precio,
            System.Decimal? porcentajeregreso,
            System.Decimal? comisionregreso,
            System.String usuario_id,
            System.DateTime? fecha
            )
        {
            this.Servicio_ID = servicio_id;
            this.Conductor = conductor;
            this.Unidad = unidad;
            this.Precio = precio;
            this.PorcentajeRegreso = porcentajeregreso;
            this.ComisionRegreso = comisionregreso;
            this.Usuario_ID = usuario_id;
            this.Fecha = fecha;
        }

        #endregion

        #region Properties
        private System.String _Servicio_ID;
        public System.String Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal? _PorcentajeRegreso;
        public System.Decimal? PorcentajeRegreso
        {
            get { return _PorcentajeRegreso; }
            set { _PorcentajeRegreso = value; }
        }

        private System.Decimal? _ComisionRegreso;
        public System.Decimal? ComisionRegreso
        {
            get { return _ComisionRegreso; }
            set { _ComisionRegreso = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ServiciosRegresos> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		C.Apellidos + ' ' + C.Nombre Conductor,
		U.NumeroEconomico Unidad,
		S.Precio,
		S.PorcentajeRegreso,
		S.ComisionRegreso,
		S.Usuario_ID,
		S.Fecha
FROM	Servicios S
LEFT JOIN	Conductores C
ON		S.ConductorRegreso_ID = C.Conductor_ID
LEFT JOIN	Unidades U
ON		S.UnidadRegreso_ID = U.Unidad_ID
WHERE	S.Fecha BETWEEN	@FechaInicial AND @FechaFinal
AND		( @Empresa_ID IS NULL OR S.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		S.ComisionRegreso IS NOT NULL";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ServiciosRegresos> list = new List<Vista_ServiciosRegresos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosRegresos(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       DB.GetNullableDecimal(dr["PorcentajeRegreso"]),
                       DB.GetNullableDecimal(dr["ComisionRegreso"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       DB.GetNullableDateTime(dr["Fecha"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		C.Apellidos + ' ' + C.Nombre Conductor,
		U.NumeroEconomico Unidad,
		S.Precio,
		S.PorcentajeRegreso,
		S.ComisionRegreso,
		S.Usuario_ID,
		S.Fecha
FROM	Servicios S
LEFT JOIN	Conductores C
ON		S.ConductorRegreso_ID = C.Conductor_ID
LEFT JOIN	Unidades U
ON		S.UnidadRegreso_ID = U.Unidad_ID
WHERE	S.Fecha BETWEEN	@FechaInicial AND @FechaFinal
AND		( @Empresa_ID IS NULL OR S.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		S.ComisionRegreso IS NOT NULL";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ServiciosRegresos



    public class Vista_MovimientosRecaudacionSesion
    {

        #region Constructors
        public Vista_MovimientosRecaudacionSesion()
        {
        }

        public Vista_MovimientosRecaudacionSesion(
            System.Int32? folio,
            System.String empresa,
            System.String estacion,
            System.Int32? ticket_id,
            System.Int32? numeroeconomico,
            System.Int32? conductor_Id,
            System.String conductor,
            System.String cuenta,
            System.String concepto,
            System.Decimal? cargo,
            System.Decimal? abono,
            System.Decimal? saldo,
            System.String comentarios,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.Folio = folio;
            this.Ticket_ID = ticket_id;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_Id = conductor_Id;
            this.Conductor = conductor;
            this.Cuenta = cuenta;
            this.Concepto = concepto;
            this.Cargo = cargo;
            this.Abono = abono;
            this.Saldo = saldo;
            this.Comentarios = comentarios;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _Folio;
        public System.Int32? Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _Conductor_Id;
        public System.Int32? Conductor_Id
        {
            get { return _Conductor_Id; }
            set { _Conductor_Id = value; }
        }
        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private System.Decimal? _Cargo;
        public System.Decimal? Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_MovimientosRecaudacionSesion> Get(
            System.Object sesion_id)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID Folio,
        E.Nombre Empresa,
        EST.Nombre Estacion,
		CC.Ticket_ID,
		U.NumeroEconomico,
        C.Conductor_ID,
		C.Apellidos + ' ' + C.Nombre Conductor,
		CU.Nombre Cuenta,
		CO.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
INNER JOIN Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Conceptos CO
ON		CC.Concepto_ID = CO.Concepto_ID
INNER JOIN	Tickets T
ON		CC.Ticket_ID = T.Ticket_ID
INNER JOIN  Empresas E
ON      CC.Empresa_ID = E.Empresa_ID
INNER JOIN  Estaciones EST
ON      CC.Estacion_ID = EST.Estacion_ID
LEFT JOIN	Unidades U
ON		T.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores C
ON		T.Conductor_ID = C.Conductor_ID
WHERE	CC.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_MovimientosRecaudacionSesion> list = new List<Vista_MovimientosRecaudacionSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_MovimientosRecaudacionSesion(
                       DB.GetNullableInt32(dr["Folio"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.String usuario_id)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID Folio,
        E.Nombre Empresa,
        EST.Nombre Estacion,
		CC.Ticket_ID,
		U.NumeroEconomico,
        C.Conductor_ID,
		C.Apellidos + ' ' + C.Nombre Conductor,
		CU.Nombre Cuenta,
		CO.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
INNER JOIN Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Conceptos CO
ON		CC.Concepto_ID = CO.Concepto_ID
INNER JOIN	Tickets T
ON		CC.Ticket_ID = T.Ticket_ID
INNER JOIN  Empresas E
ON      CC.Empresa_ID = E.Empresa_ID
INNER JOIN  Estaciones EST
ON      CC.Estacion_ID = EST.Estacion_ID
LEFT JOIN	Unidades U
ON		T.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores C
ON		T.Conductor_ID = C.Conductor_ID
WHERE	( CC.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( CC.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND     ( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND     CC.Fecha BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static DataTable GetDataTable(
            System.Object sesion_id)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID Folio,
        E.Nombre Empresa,
        EST.Nombre Estacion,
		CC.Ticket_ID,
		U.NumeroEconomico,
        C.Conductor_ID,
		C.Apellidos + ' ' + C.Nombre Conductor,
		CU.Nombre Cuenta,
		CO.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
INNER JOIN Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Conceptos CO
ON		CC.Concepto_ID = CO.Concepto_ID
INNER JOIN	Tickets T
ON		CC.Ticket_ID = T.Ticket_ID
INNER JOIN  Empresas E
ON      CC.Empresa_ID = E.Empresa_ID
INNER JOIN  Estaciones EST
ON      CC.Estacion_ID = EST.Estacion_ID
LEFT JOIN	Unidades U
ON		T.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores C
ON		T.Conductor_ID = C.Conductor_ID
WHERE	CC.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_MovimientosRecaudacionSesion


    public class Vista_RentasPagadasPorModelo
    {

        #region Constructors
        public Vista_RentasPagadasPorModelo()
        {
        }

        public Vista_RentasPagadasPorModelo(
            System.String nombre,
            System.Decimal? rentas
            )
        {
            this.Nombre = nombre;
            this.Rentas = rentas;
        }

        #endregion

        #region Properties
        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Decimal? _Rentas;
        public System.Decimal? Rentas
        {
            get { return _Rentas; }
            set { _Rentas = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_RentasPagadasPorModelo> Get(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	M.Nombre,
		SUM(Abono) Rentas
FROM	CuentaConductores CC
INNER JOIN	Unidades U
ON		CC.Unidad_ID = U.Unidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
WHERE	CC.Fecha BETWEEN @FechaInicial  AND	@FechaFinal
AND		( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND		CC.Cuenta_ID = 1
GROUP BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_RentasPagadasPorModelo> list = new List<Vista_RentasPagadasPorModelo>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_RentasPagadasPorModelo(
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableDecimal(dr["Rentas"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	M.Nombre,
		SUM(Abono) Rentas
FROM	CuentaConductores CC
INNER JOIN	Unidades U
ON		CC.Unidad_ID = U.Unidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
WHERE	CC.Fecha BETWEEN @FechaInicial  AND	@FechaFinal
AND		( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND		CC.Cuenta_ID = 1
GROUP BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_RentasPagadasPorModelo

    public class Vista_ServiciosPagadosPorModelo
    {

        #region Constructors
        public Vista_ServiciosPagadosPorModelo()
        {
        }

        public Vista_ServiciosPagadosPorModelo(
            System.String modelo,
            System.Int32? servicios,
            System.Decimal? total,
            System.Decimal? totaldc
            )
        {
            this.Modelo = modelo;
            this.Servicios = servicios;
            this.Total = total;
            this.TotalDC = totaldc;
        }

        #endregion

        #region Properties
        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.Int32? _Servicios;
        public System.Int32? Servicios
        {
            get { return _Servicios; }
            set { _Servicios = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.Decimal? _TotalDC;
        public System.Decimal? TotalDC
        {
            get { return _TotalDC; }
            set { _TotalDC = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ServiciosPagadosPorModelo> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	M.Nombre Modelo,
		COUNT(S.Servicio_ID) Servicios,
		SUM(S.Precio) Total,
		SUM(S.Precio - ISNULL(SC.Comision,0)) TotalDC
FROM	Servicios S
LEFT JOIN	(
	SELECT	Servicio_ID, SUM(Monto) Comision
	FROM	Servicios_Comisiones
	GROUP BY	Servicio_ID
) SC
ON		S.Servicio_ID = SC.Servicio_ID
INNER JOIN	Unidades U
ON		S.Unidad_ID = U.Unidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
WHERE	S.Fecha BETWEEN @FechaInicial  AND	@FechaFinal
AND		( @Empresa_ID IS NULL OR S.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		S.EstatusServicio_ID = 3
GROUP BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ServiciosPagadosPorModelo> list = new List<Vista_ServiciosPagadosPorModelo>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosPagadosPorModelo(
                       Convert.ToString(dr["Modelo"]),
                       DB.GetNullableInt32(dr["Servicios"]),
                       DB.GetNullableDecimal(dr["Total"]),
                       DB.GetNullableDecimal(dr["TotalDC"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	M.Nombre Modelo,
		COUNT(S.Servicio_ID) Servicios,
		SUM(S.Precio) Total,
		SUM(S.Precio - ISNULL(SC.Comision,0)) TotalDC
FROM	Servicios S
LEFT JOIN	(
	SELECT	Servicio_ID, SUM(Monto) Comision
	FROM	Servicios_Comisiones
	GROUP BY	Servicio_ID
) SC
ON		S.Servicio_ID = SC.Servicio_ID
INNER JOIN	Unidades U
ON		S.Unidad_ID = U.Unidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
WHERE	S.Fecha BETWEEN @FechaInicial  AND	@FechaFinal
AND		( @Empresa_ID IS NULL OR S.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		S.EstatusServicio_ID = 3
GROUP BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ServiciosPagadosPorModelo


    public class Vista_TiposServiciosConductores
    {

        #region Constructors
        public Vista_TiposServiciosConductores()
        {
        }

        public Vista_TiposServiciosConductores(
            System.Int32? tiposervicioconductor_id,
            System.String nombre,
            System.Decimal? precio,
            System.String estatus
            )
        {
            this.TipoServicioConductor_ID = tiposervicioconductor_id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Estatus = estatus;
        }

        #endregion

        #region Properties
        private System.Int32? _TipoServicioConductor_ID;
        public System.Int32? TipoServicioConductor_ID
        {
            get { return _TipoServicioConductor_ID; }
            set { _TipoServicioConductor_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_TiposServiciosConductores> Get()
        {
            string sqlstr = @"SELECT	TSC.TipoServicioConductor_ID,
		TSC.Nombre,
		TSC.Precio,
		ETSC.Nombre Estatus
FROM	TiposServiciosConductores TSC
INNER JOIN	EstatusTiposServiciosConductores ETSC
ON		TSC.EstatusTipoServicioConductor_ID = ETSC.EstatusTipoServicioConductor_ID";

            List<Vista_TiposServiciosConductores> list = new List<Vista_TiposServiciosConductores>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_TiposServiciosConductores(
                       DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       Convert.ToString(dr["Estatus"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	TSC.TipoServicioConductor_ID,
		TSC.Nombre,
		TSC.Precio,
		ETSC.Nombre Estatus
FROM	TiposServiciosConductores TSC
INNER JOIN	EstatusTiposServiciosConductores ETSC
ON		TSC.EstatusTipoServicioConductor_ID = ETSC.EstatusTipoServicioConductor_ID";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class Vista_TiposServiciosConductores


    public class Vista_Cajas
    {

        #region Constructors
        public Vista_Cajas()
        {
        }

        public Vista_Cajas(
            System.Int32? caja_id,
            System.String empresa,
            System.String estacion,
            System.String nombre,
            System.Boolean? activa,
            System.Boolean? impresiondoble,
            System.Boolean? enclave
            )
        {
            this.Caja_ID = caja_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Nombre = nombre;
            this.Activa = activa;
            this.ImpresionDoble = impresiondoble;
            this.EnClave = enclave;
        }

        #endregion

        #region Properties
        private System.Int32? _Caja_ID;
        public System.Int32? Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Boolean? _Activa;
        public System.Boolean? Activa
        {
            get { return _Activa; }
            set { _Activa = value; }
        }

        private System.Boolean? _ImpresionDoble;
        public System.Boolean? ImpresionDoble
        {
            get { return _ImpresionDoble; }
            set { _ImpresionDoble = value; }
        }

        private System.Boolean? _EnClave;
        public System.Boolean? EnClave
        {
            get { return _EnClave; }
            set { _EnClave = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Cajas> Get(
            System.Int32? caja_id)
        {
            string sqlstr = @"SELECT	C.Caja_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		C.Nombre,
		C.Activa,
		C.ImpresionDoble,
		C.EnClave
FROM	Cajas C
INNER JOIN	Empresas E
ON		C.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		C.Estacion_ID = EST.Estacion_ID
WHERE	( @Caja_ID IS NULL OR C.Caja_ID = @Caja_ID )
";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);

            List<Vista_Cajas> list = new List<Vista_Cajas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Cajas(
                       DB.GetNullableInt32(dr["Caja_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Nombre"]),
                       DB.GetNullableBoolean(dr["Activa"]),
                       DB.GetNullableBoolean(dr["ImpresionDoble"]),
                       DB.GetNullableBoolean(dr["EnClave"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? caja_id)
        {
            string sqlstr = @"SELECT	C.Caja_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		C.Nombre,
		C.Activa,
		C.ImpresionDoble,
		C.EnClave
FROM	Cajas C
INNER JOIN	Empresas E
ON		C.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		C.Estacion_ID = EST.Estacion_ID
WHERE	( @Caja_ID IS NULL OR C.Caja_ID = @Caja_ID )
";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Cajas


    public class Vista_ComisionesVentaSesion
    {

        #region Constructors
        public Vista_ComisionesVentaSesion()
        {
        }

        public Vista_ComisionesVentaSesion(
            System.String comisionista,
            System.Decimal? total
            )
        {
            this.Comisionista = comisionista;
            this.Total = total;
        }

        #endregion

        #region Properties
        private System.String _Comisionista;
        public System.String Comisionista
        {
            get { return _Comisionista; }
            set { _Comisionista = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ComisionesVentaSesion> Get(
            System.Int32 sesion_id)
        {
            string sqlstr = @"SELECT	CS.Nombre Comisionista,
		SUM(SC.Monto) Total
FROM	Servicios S
INNER JOIN	Servicios_Comisiones SC
ON		S.Servicio_ID = SC.Servicio_ID
INNER JOIN	ComisionesServicios CS
ON		SC.ComisionServicio_ID = CS.ComisionServicio_ID
WHERE	S.Sesion_ID = @Sesion_ID
GROUP BY	CS.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_ComisionesVentaSesion> list = new List<Vista_ComisionesVentaSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ComisionesVentaSesion(
                       Convert.ToString(dr["Comisionista"]),
                       DB.GetNullableDecimal(dr["Total"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 sesion_id)
        {
            string sqlstr = @"SELECT	CS.Nombre Comisionista,
		SUM(SC.Monto) Total
FROM	Servicios S
INNER JOIN	Servicios_Comisiones SC
ON		S.Servicio_ID = SC.Servicio_ID
INNER JOIN	ComisionesServicios CS
ON		SC.ComisionServicio_ID = CS.ComisionServicio_ID
WHERE	S.Sesion_ID = @Sesion_ID
GROUP BY	CS.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ComisionesVentaSesion

    public class Vista_TiposRefacciones
    {

        #region Constructors
        public Vista_TiposRefacciones()
        {
        }

        public Vista_TiposRefacciones(
            System.Int32? tiporefaccion_id,
            System.String familia,
            System.String nombre
            )
        {
            this.TipoRefaccion_ID = tiporefaccion_id;
            this.Familia = familia;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties
        private System.Int32? _TipoRefaccion_ID;
        public System.Int32? TipoRefaccion_ID
        {
            get { return _TipoRefaccion_ID; }
            set { _TipoRefaccion_ID = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_TiposRefacciones> Get(
            System.Int32? familia_id,
            System.String nombre)
        {
            string sqlstr = @"SELECT	TR.TipoRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre
FROM	TiposRefacciones TR
INNER	JOIN	Familias F
ON		TR.Familia_ID = F.Familia_ID
WHERE	( @Familia_ID IS NULL OR F.Familia_ID = @Familia_ID )
AND		( @Nombre IS NULL OR TR.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_TiposRefacciones> list = new List<Vista_TiposRefacciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_TiposRefacciones(
                       DB.GetNullableInt32(dr["TipoRefaccion_ID"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? familia_id,
            System.String nombre)
        {
            string sqlstr = @"SELECT	TR.TipoRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre
FROM	TiposRefacciones TR
INNER	JOIN	Familias F
ON		TR.Familia_ID = F.Familia_ID
WHERE	( @Familia_ID IS NULL OR F.Familia_ID = @Familia_ID )
AND		( @Nombre IS NULL OR TR.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_TiposRefacciones

    public class Vista_UnidadesConductoresOperativos
    {

        #region Constructors
        public Vista_UnidadesConductoresOperativos()
        {
        }

        public Vista_UnidadesConductoresOperativos(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? conductortitular_id,
            System.String conductortitular,
            System.Int32? conductoroperativo_id,
            System.String conductoroperativo
            )
        {
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.ConductorTitular_ID = conductortitular_id;
            this.ConductorTitular = conductortitular;
            this.ConductorOperativo_ID = conductoroperativo_id;
            this.ConductorOperativo = conductoroperativo;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _ConductorTitular_ID;
        public System.Int32? ConductorTitular_ID
        {
            get { return _ConductorTitular_ID; }
            set { _ConductorTitular_ID = value; }
        }

        private System.String _ConductorTitular;
        public System.String ConductorTitular
        {
            get { return _ConductorTitular; }
            set { _ConductorTitular = value; }
        }

        private System.Int32? _ConductorOperativo_ID;
        public System.Int32? ConductorOperativo_ID
        {
            get { return _ConductorOperativo_ID; }
            set { _ConductorOperativo_ID = value; }
        }

        private System.String _ConductorOperativo;
        public System.String ConductorOperativo
        {
            get { return _ConductorOperativo; }
            set { _ConductorOperativo = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_UnidadesConductoresOperativos> Get(
            System.Int32 estacion_id,
            System.Int32? numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID,
		U.NumeroEconomico,
		C.Conductor_ID ConductorTitular_ID,
		UPPER(C.Apellidos + ' ' + C.Nombre) ConductorTitular,
		COND.Conductor_ID ConductorOperativo_ID,
		UPPER(COND.Apellidos + ' ' + COND.Nombre) ConductorOperativo
FROM	Unidades U
LEFT JOIN	Contratos CONT
ON		U.Unidad_ID = CONT.Unidad_ID
		AND	CONT.EstatusContrato_ID = 1
LEFT JOIN	Conductores C
ON		CONT.Conductor_ID = C.Conductor_ID
LEFT JOIN	Conductores COND
ON		COND.Conductor_ID = U.ConductorOperativo_ID
WHERE	U.Estacion_ID = @Estacion_ID
AND		U.EstatusUnidad_ID NOT IN ( 4, 5, 8 )
AND     ( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
--AND CONT.TipoContrato_ID IN (1,2)
ORDER BY	U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<Vista_UnidadesConductoresOperativos> list = new List<Vista_UnidadesConductoresOperativos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_UnidadesConductoresOperativos(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["ConductorTitular_ID"]),
                       Convert.ToString(dr["ConductorTitular"]),
                       DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
                       Convert.ToString(dr["ConductorOperativo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID,
		U.NumeroEconomico,
		C.Conductor_ID ConductorTitular_ID,
		UPPER(C.Apellidos + ' ' + C.Nombre) ConductorTitular,
		COND.Conductor_ID ConductorOperativo_ID,
		UPPER(COND.Apellidos + ' ' + COND.Nombre) ConductorOperativo
FROM	Unidades U
LEFT JOIN	Contratos CONT
ON		U.Unidad_ID = CONT.Unidad_ID
		AND	CONT.EstatusContrato_ID = 1
LEFT JOIN	Conductores C
ON		CONT.Conductor_ID = C.Conductor_ID
LEFT JOIN	Conductores COND
ON		COND.Conductor_ID = U.ConductorOperativo_ID
WHERE	U.Estacion_ID = @Estacion_ID
AND		U.EstatusUnidad_ID NOT IN ( 4, 5, 8 )
--AND CONT.TipoContrato_ID IN (1,2)
ORDER BY	U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_UnidadesConductoresOperativos

    public class Vista_MovimientosFlujoCajaSesion
    {

        #region Constructors
        public Vista_MovimientosFlujoCajaSesion()
        {
        }

        public Vista_MovimientosFlujoCajaSesion(
            System.Int32? sesion_id,
            System.String moneda,
            System.Int32? ticket_id,
            System.String concepto,
            System.Decimal? cargo,
            System.Decimal? abono,
            System.Decimal? saldo,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.Sesion_ID = sesion_id;
            this.Moneda = moneda;
            this.Ticket_ID = ticket_id;
            this.Concepto = concepto;
            this.Cargo = cargo;
            this.Abono = abono;
            this.Saldo = saldo;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.String _Moneda;
        public System.String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private System.Decimal? _Cargo;
        public System.Decimal? Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_MovimientosFlujoCajaSesion> Get(
            System.Int32? sesion_id)
        {
            string sqlstr = @"SELECT	CFC.Sesion_ID,
		M.Nombre Moneda,
		CFC.Ticket_ID,
		CFC.Concepto,
		CFC.Cargo,
		CFC.Abono,
		CFC.Saldo,
		CFC.Fecha,
		CFC.Usuario_ID
FROM	CuentaFlujoCajas CFC
INNER JOIN	Monedas M
ON		CFC.Moneda_ID = M.Moneda_ID
WHERE	Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_MovimientosFlujoCajaSesion> list = new List<Vista_MovimientosFlujoCajaSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_MovimientosFlujoCajaSesion(
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Moneda"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? sesion_id)
        {
            string sqlstr = @"SELECT	CFC.Sesion_ID,
		M.Nombre Moneda,
		CFC.Ticket_ID,
		CFC.Concepto,
		CFC.Cargo,
		CFC.Abono,
		CFC.Saldo,
		CFC.Fecha,
		CFC.Usuario_ID
FROM	CuentaFlujoCajas CFC
INNER JOIN	Monedas M
ON		CFC.Moneda_ID = M.Moneda_ID
WHERE	Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_MovimientosFlujoCajaSesion

    public class Vista_SaldosFlujoCajaSesion
    {

        #region Constructors
        public Vista_SaldosFlujoCajaSesion()
        {
        }

        public Vista_SaldosFlujoCajaSesion(
            System.String moneda,
            System.Decimal? saldo
            )
        {
            this.Moneda = moneda;
            this.Saldo = saldo;
        }

        #endregion

        #region Properties
        private System.String _Moneda;
        public System.String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_SaldosFlujoCajaSesion> Get(
            System.Object sesion_id)
        {
            string sqlstr = @"SELECT	M.Nombre Moneda,
		SUM(CFC.Abono - CFC.Cargo) Saldo
FROM	CuentaFlujoCajas CFC
INNER JOIN	Monedas M
ON		CFC.Moneda_ID = M.Moneda_ID
WHERE	CFC.Sesion_ID = @Sesion_ID
GROUP BY	M.Nombre
ORDER BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_SaldosFlujoCajaSesion> list = new List<Vista_SaldosFlujoCajaSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_SaldosFlujoCajaSesion(
                       Convert.ToString(dr["Moneda"]),
                       DB.GetNullableDecimal(dr["Saldo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object sesion_id)
        {
            string sqlstr = @"SELECT	M.Nombre Moneda,
		SUM(CFC.Abono - CFC.Cargo) Saldo
FROM	CuentaFlujoCajas CFC
INNER JOIN	Monedas M
ON		CFC.Moneda_ID = M.Moneda_ID
WHERE	CFC.Sesion_ID = @Sesion_ID
GROUP BY	M.Nombre
ORDER BY	M.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_SaldosFlujoCajaSesion


    public class Vista_MatrizVentasTaller
    {

        #region Constructors
        public Vista_MatrizVentasTaller()
        {
        }

        public Vista_MatrizVentasTaller(
            System.DateTime? fecha,
            System.String cliente,
            System.String familia,
            System.Decimal? total,
            System.String concepto
            )
        {
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.Familia = familia;
            this.Total = total;
            this.Concepto = concepto;
        }

        #endregion

        #region Properties
        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_MatrizVentasTaller> Get(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"
		--convert(date,OT.FechaTerminacion) Fecha,
		SELECT	
		Convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
        F.Nombre Familia, 
        SUM(OS.Total) Total,
        'MANO OBRA' Concepto
FROM	OrdenesServicios OS
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	Convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre
--GROUP BY	dconvert(date, OT.FechaTerminacion), E.Nombre, F.Nombre

UNION

SELECT	Convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
		CASE OT.TipoMantenimiento_ID		
		WHEN 13
		THEN FR.Nombre
		ELSE F.Nombre
		END Familia,
		SUM(OSR.Total) Total,
		'REFACCIONES' Concepto
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Refacciones R
ON		OSR.Refaccion_ID = R.Refaccion_ID
INNER JOIN	TiposRefacciones TR
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID
INNER JOIN	Familias FR
ON		TR.Familia_ID = FR.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	Convert(date,OT.FechaTerminacion), E.Nombre, CASE OT.TipoMantenimiento_ID	
		WHEN 13 THEN FR.Nombre
		ELSE F.Nombre
		END";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_MatrizVentasTaller> list = new List<Vista_MatrizVentasTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_MatrizVentasTaller(
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Cliente"]),
                       Convert.ToString(dr["Familia"]),
                       DB.GetNullableDecimal(dr["Total"]),
                       Convert.ToString(dr["Concepto"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
        F.Nombre Familia, 
        SUM(OS.Total) Total,
        'MANO OBRA' Concepto
FROM	OrdenesServicios OS
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre
UNION 
SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
		F.Nombre Familia,
		SUM(OSR.Total) Total,
		'REFACCIONES' Concepto
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre ";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_MatrizVentasTaller

    public class Vista_ReporteLocaciones
    {

        #region Constructors
        public Vista_ReporteLocaciones()
        {
        }

        public Vista_ReporteLocaciones(
            System.String estacion,
            System.Int32? unidad_id,
            System.String locacion,
            System.String contrato
            )
        {
            this.Estacion = estacion;
            this.Unidad_ID = unidad_id;
            this.Locacion = locacion;
            this.Contrato = contrato;
        }

        #endregion

        #region Properties
        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.String _Locacion;
        public System.String Locacion
        {
            get { return _Locacion; }
            set { _Locacion = value; }
        }

        private System.String _Contrato;
        public System.String Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteLocaciones> Get(
            System.Int32? estacion_id,
            System.Int32? empresa_id)
        {
            string sqlstr = @"SELECT	Est.Nombre Estacion,
		U.Unidad_ID,
		ISNULL(LU.Nombre,'') Locacion,
		CASE 
		WHEN	C.Contrato_ID IS NULL THEN 'SIN CONTRATO'
		ELSE	'CON CONTRATO' END Contrato
FROM	Unidades	U
INNER JOIN	Estaciones Est
ON		U.Estacion_ID = Est.Estacion_ID
LEFT JOIN	Contratos	C
ON		C.Unidad_ID = U.Unidad_ID
		AND C.EstatusContrato_ID = 1
LEFT JOIN	LocacionesUnidades	LU
ON		LU.LocacionUnidad_ID = U.LocacionUnidad_ID
WHERE	(@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)
AND		(@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID)
--AND C.TipoContrato_ID IN (1,2)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Empresa_ID", empresa_id);

            List<Vista_ReporteLocaciones> list = new List<Vista_ReporteLocaciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteLocaciones(
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Contrato"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? estacion_id,
            System.Int32? empresa_id)
        {
            string sqlstr = @"SELECT	Est.Nombre Estacion,
		U.Unidad_ID,
		ISNULL(LU.Nombre,'') Locacion,
		CASE 
		WHEN	C.Contrato_ID IS NULL THEN 'SIN CONTRATO'
		ELSE	'CON CONTRATO' END Contrato
FROM	Unidades	U
INNER JOIN	Estaciones Est
ON		U.Estacion_ID = Est.Estacion_ID
LEFT JOIN	Contratos	C
ON		C.Unidad_ID = U.Unidad_ID
		AND C.EstatusContrato_ID = 1
LEFT JOIN	LocacionesUnidades	LU
ON		LU.LocacionUnidad_ID = U.LocacionUnidad_ID
WHERE	(@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)
AND		(@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID)
--AND C.TipoContrato_ID IN (1,2)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Empresa_ID", empresa_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteLocaciones

    public class SelectEstatusValesPrepagados
    {

        #region Constructors
        public SelectEstatusValesPrepagados()
        {
        }

        public SelectEstatusValesPrepagados(
            System.Int32? estatusvaleprepagado_id,
            System.String nombre
            )
        {
            this.EstatusValePrepagado_ID = estatusvaleprepagado_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties

        private System.Int32? _EstatusValePrepagado_ID;
        public System.Int32? EstatusValePrepagado_ID
        {
            get { return _EstatusValePrepagado_ID; }
            set { _EstatusValePrepagado_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods

        public static List<SelectEstatusValesPrepagados> Get()
        {
            string sqlstr = @"SELECT	NULL EstatusValePrepagado_ID, '- TODOS -' Nombre
						UNION
						SELECT	EstatusValePrepagado_ID, Nombre
						FROM	EstatusValesPrepagados";

            List<SelectEstatusValesPrepagados> list = new List<SelectEstatusValesPrepagados>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectEstatusValesPrepagados(
                       DB.GetNullableInt32(dr["EstatusValePrepagado_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	NULL EstatusValePrepagado_ID, '- TODOS -' Nombre
UNION
SELECT	EstatusValePrepagado_ID, Nombre
FROM	EstatusValesPrepagados";

            return DB.Query(sqlstr);
        } // End GetDataTable

        #endregion
    } // End Class SelectEstatusValesPrepagados

    public class Vista_CortesDeVentas
    {

        #region Constructors
        public Vista_CortesDeVentas()
        {
        }

        public Vista_CortesDeVentas(
            System.String empresa,
            System.String estacion,
            System.Int32? sesion_id,
            System.String vendedor,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.DateTime? fechacorte
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Sesion_ID = sesion_id;
            this.Vendedor = vendedor;
            this.FechaInicial = fechainicial;
            this.FechaFinal = fechafinal;
            this.FechaCorte = fechacorte;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.String _Vendedor;
        public System.String Vendedor
        {
            get { return _Vendedor; }
            set { _Vendedor = value; }
        }

        private System.DateTime? _FechaInicial;
        public System.DateTime? FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime? _FechaFinal;
        public System.DateTime? FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        private System.DateTime? _FechaCorte;
        public System.DateTime? FechaCorte
        {
            get { return _FechaCorte; }
            set { _FechaCorte = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_CortesDeVentas> Get(
            System.Int32? estacion_id,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal)
        {
            string sqlstr = @"SELECT	'CASCO' Empresa, 
		EST.Nombre Estacion, 
		S.Sesion_ID, 
		LOWER(S.Usuario_ID) Vendedor, 
		S.FechaInicial, 
		S.FechaFinal, 
		convert(date,S.FechaInicial) FechaCorte
FROM	Sesiones S
INNER JOIN	Estaciones EST
ON		S.Estacion_ID = EST.Estacion_ID
WHERE	( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		( 
			( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR 
			( convert(date,S.FechaInicial) BETWEEN @FechaInicial AND @FechaFinal ) 
		)
AND		S.Sesion_ID IN
(
	SELECT	DISTINCT Sesion_ID
	FROM	Servicios
)
ORDER BY	S.Sesion_ID DESC";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_CortesDeVentas> list = new List<Vista_CortesDeVentas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CortesDeVentas(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Vendedor"]),
                       DB.GetNullableDateTime(dr["FechaInicial"]),
                       DB.GetNullableDateTime(dr["FechaFinal"]),
                       DB.GetNullableDateTime(dr["FechaCorte"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? estacion_id,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal)
        {
            string sqlstr = @"SELECT	'CASCO' Empresa, 
EST.Nombre Estacion, 
S.Sesion_ID, 
LOWER(S.Usuario_ID) Vendedor, 
S.FechaInicial,
S.FechaFinal, 
convert(date,S.FechaInicial) FechaCorte
FROM	Sesiones S
INNER JOIN	Servicios SV
ON		S.Sesion_ID = SV.Sesion_ID
INNER JOIN	Estaciones EST
ON		S.Estacion_ID = EST.Estacion_ID
WHERE	( @Estacion_ID IS NULL OR S.Estacion_ID = @Estacion_ID )
AND		( 
			( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR 
			( convert(date,S.FechaInicial) BETWEEN @FechaInicial AND @FechaFinal ) 
		)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_CortesDeVentas

    public class Vista_ReporteValesPrepagados
    {

        #region Constructors
        public Vista_ReporteValesPrepagados()
        {
        }

        public Vista_ReporteValesPrepagados(
            System.String codigo,
            System.Int32? foliodiario,
            System.Decimal? denominacion,
            System.String cliente,
            System.String status,
            System.DateTime? fechaemision,
            System.DateTime? fechaexpiracion,
            System.String usuarioemision
            )
        {
            this.Codigo = codigo;
            this.FolioDiario = foliodiario;
            this.Denominacion = denominacion;
            this.Cliente = cliente;
            this.Status = status;
            this.FechaEmision = fechaemision;
            this.FechaExpiracion = fechaexpiracion;
            this.UsuarioEmision = usuarioemision;
        }

        #endregion

        #region Properties
        private System.String _Codigo;
        public System.String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private System.Int32? _FolioDiario;
        public System.Int32? FolioDiario
        {
            get { return _FolioDiario; }
            set { _FolioDiario = value; }
        }

        private System.Decimal? _Denominacion;
        public System.Decimal? Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.String _Status;
        public System.String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private System.DateTime? _FechaEmision;
        public System.DateTime? FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }

        private System.DateTime? _FechaExpiracion;
        public System.DateTime? FechaExpiracion
        {
            get { return _FechaExpiracion; }
            set { _FechaExpiracion = value; }
        }

        private System.String _UsuarioEmision;
        public System.String UsuarioEmision
        {
            get { return _UsuarioEmision; }
            set { _UsuarioEmision = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteValesPrepagados> Get(
            System.Object empresacliente_id,
            System.Object estatusvaleprepagado_id,
            System.Object fechainicial,
            System.Object fechafinal,
              System.Object empresaEmite_id)
        {
            string sqlstr = @"SELECT	VP.ValePrepagado_ID Codigo,
		VP.FolioDiario,
		VP.Denominacion,
		C.RazonSocial Cliente,
		SVP.Nombre [Status],
		VP.FechaEmision, 
		VP.FechaExpiracion,
		VP.Usuario_ID UsuarioEmision
FROM		dbo.ValesPrepagados VP
INNER JOIN	dbo.Empresas C
ON		VP.EmpresaCliente_ID = C.Empresa_ID
INNER JOIN	dbo.EstatusValesPrepagados SVP
ON		SVP.EstatusValePrepagado_ID = VP.EstatusValePrepagado_ID
WHERE	( @EmpresaCliente_ID IS NULL OR VP.EmpresaCliente_ID = @EmpresaCliente_ID )
AND		( @EstatusValePrepagado_ID IS NULL OR VP.EstatusValePrepagado_ID = @EstatusValePrepagado_ID )
AND		( @EmpresaEmite_ID IS NULL OR VP.Empresa_ID = @EmpresaEmite_ID )
AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )
		OR ( VP.FechaEmision BETWEEN @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@EmpresaCliente_ID", empresacliente_id);
            m_params.Add("@EstatusValePrepagado_ID", estatusvaleprepagado_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@EmpresaEmite_ID", empresaEmite_id);

            List<Vista_ReporteValesPrepagados> list = new List<Vista_ReporteValesPrepagados>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteValesPrepagados(
                       Convert.ToString(dr["Codigo"]),
                       DB.GetNullableInt32(dr["FolioDiario"]),
                       DB.GetNullableDecimal(dr["Denominacion"]),
                       Convert.ToString(dr["Cliente"]),
                       Convert.ToString(dr["Status"]),
                       DB.GetNullableDateTime(dr["FechaEmision"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       Convert.ToString(dr["UsuarioEmision"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object empresacliente_id,
            System.Object estatusvaleprepagado_id,
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresaEmite_id)
        {
            string sqlstr = @"SELECT	VP.ValePrepagado_ID Codigo,
		VP.FolioDiario,
		VP.Denominacion,
		C.RazonSocial Cliente,
		SVP.Nombre [Status],
		VP.FechaEmision, 
		VP.FechaExpiracion,
		VP.Usuario_ID UsuarioEmision
FROM		dbo.ValesPrepagados VP
INNER JOIN	dbo.Empresas C
ON		VP.EmpresaCliente_ID = C.Empresa_ID
INNER JOIN	dbo.EstatusValesPrepagados SVP
ON		SVP.EstatusValePrepagado_ID = VP.EstatusValePrepagado_ID
WHERE	( @EmpresaCliente_ID IS NULL OR VP.EmpresaCliente_ID = @EmpresaCliente_ID )
AND		( @EstatusValePrepagado_ID IS NULL OR VP.EstatusValePrepagado_ID = @EstatusValePrepagado_ID )
AND		( @EmpresaEmite_ID IS NULL OR VP.Empresa_ID = @EmpresaEmite_ID )
AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )
		OR ( VP.FechaEmision BETWEEN @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@EmpresaCliente_ID", empresacliente_id);
            m_params.Add("@EstatusValePrepagado_ID", estatusvaleprepagado_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@EmpresaEmite_ID", empresaEmite_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteValesPrepagados

    public class Vista_InventarioRefaccionesServicio
    {

        #region Constructors
        public Vista_InventarioRefaccionesServicio()
        {
        }

        public Vista_InventarioRefaccionesServicio(
            System.String refaccion,
            System.Int32? inventario,
            System.Int32? requiere,
            System.Int32? diferencia
            )
        {
            this.Refaccion = refaccion;
            this.Inventario = inventario;
            this.Requiere = requiere;
            this.Diferencia = diferencia;
        }

        #endregion

        #region Properties
        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Int32? _Inventario;
        public System.Int32? Inventario
        {
            get { return _Inventario; }
            set { _Inventario = value; }
        }

        private System.Int32? _Requiere;
        public System.Int32? Requiere
        {
            get { return _Requiere; }
            set { _Requiere = value; }
        }

        private System.Int32? _Diferencia;
        public System.Int32? Diferencia
        {
            get { return _Diferencia; }
            set { _Diferencia = value; }
        }

        #endregion

        #region Methods

        public static List<Vista_InventarioRefaccionesServicio> Get(
            System.Object empresa_id,
            System.Object estacion_id,
            System.Object tipoclientetaller_id,
            System.Object nombre)
        {
            string sqlstr = @"SELECT	R.Descripcion Refaccion,
        I.CantidadInventario Inventario,
        SMTR.Cantidad Requiere,
        SMTR.Cantidad - I.CantidadInventario Diferencia
FROM	ServiciosMantenimientos SM 
INNER JOIN	TiposServiciosMantenimientos TSM 
ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
INNER JOIN	Familias F 
ON		SM.Familia_ID = F.Familia_ID 
INNER JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
INNER JOIN	Refacciones R
ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
INNER JOIN	Inventario I
ON		( R.Refaccion_ID = I.Refaccion_ID
			AND	I.Empresa_ID = @Empresa_ID
			AND	I.Estacion_ID = @Estacion_ID )
INNER JOIN	ServiciosMantenimientosPrecios SMP
ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
    AND SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID )
INNER JOIN	Modelos MU 
ON		( R.Modelo_ID = MU.Modelo_ID )
WHERE	SM.Nombre LIKE @Nombre + '%'";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_InventarioRefaccionesServicio> list = new List<Vista_InventarioRefaccionesServicio>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_InventarioRefaccionesServicio(
                       Convert.ToString(dr["Refaccion"]),
                       DB.GetNullableInt32(dr["Inventario"]),
                       DB.GetNullableInt32(dr["Requiere"]),
                       DB.GetNullableInt32(dr["Diferencia"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_InventarioRefaccionesServicio> Get(
            System.Object empresa_id,
            System.Object estacion_id,
            System.Object tipoclientetaller_id,
            System.Object nombre,
            System.Object modelo_id)
        {
            string sqlstr = @"SELECT	R.Descripcion Refaccion,
        I.CantidadInventario Inventario,
        SMTR.Cantidad Requiere,
        SMTR.Cantidad - I.CantidadInventario Diferencia
FROM	ServiciosMantenimientos SM 
INNER JOIN	TiposServiciosMantenimientos TSM 
ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
INNER JOIN	Familias F 
ON		SM.Familia_ID = F.Familia_ID 
INNER JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
INNER JOIN	Refacciones R
ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
INNER JOIN	Inventario I
ON		( R.Refaccion_ID = I.Refaccion_ID
			AND	I.Empresa_ID = @Empresa_ID
			AND	I.Estacion_ID = @Estacion_ID )
INNER JOIN	ServiciosMantenimientosPrecios SMP
ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
    AND SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID )
INNER JOIN	Modelos MU 
ON		( R.Modelo_ID = MU.Modelo_ID )
WHERE	SM.Nombre LIKE @Nombre + '%'
AND		R.Modelo_ID IN (@Modelo_ID, 9)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Modelo_ID", modelo_id);

            List<Vista_InventarioRefaccionesServicio> list = new List<Vista_InventarioRefaccionesServicio>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_InventarioRefaccionesServicio(
                       Convert.ToString(dr["Refaccion"]),
                       DB.GetNullableInt32(dr["Inventario"]),
                       DB.GetNullableInt32(dr["Requiere"]),
                       DB.GetNullableInt32(dr["Diferencia"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object empresa_id,
            System.Object estacion_id,
            System.Object tipoclientetaller_id,
            System.Object nombre,
            System.Object modelo_id)
        {
            string sqlstr = @"SELECT	R.Descripcion Refaccion,
        I.CantidadInventario Inventario,
        SMTR.Cantidad Requiere,
        SMTR.Cantidad - I.CantidadInventario Diferencia
FROM	ServiciosMantenimientos SM 
INNER JOIN	TiposServiciosMantenimientos TSM 
ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
INNER JOIN	Familias F 
ON		SM.Familia_ID = F.Familia_ID 
INNER JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
INNER JOIN	Refacciones R
ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
INNER JOIN	Inventario I
ON		( R.Refaccion_ID = I.Refaccion_ID
			AND	I.Empresa_ID = @Empresa_ID
			AND	I.Estacion_ID = @Estacion_ID )
INNER JOIN	ServiciosMantenimientosPrecios SMP
ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
    AND SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID )
INNER JOIN	Modelos MU 
ON		( R.Modelo_ID = MU.Modelo_ID )
WHERE	SM.Nombre LIKE @Nombre + '%'
AND		R.Modelo_ID IN (@Modelo_ID, 9)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Modelo_ID", modelo_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_InventarioRefaccionesServicio

    public class Vista_ServiciosMantenimientos_TiposRefacciones
    {

        #region Constructors
        public Vista_ServiciosMantenimientos_TiposRefacciones()
        {
        }

        public Vista_ServiciosMantenimientos_TiposRefacciones(
            System.Int32 serviciomantenimiento_id,
            System.String servicio,
            System.Int32 tiporefaccion_id,
            System.String refaccion,
            System.Int32 cantidad
            )
        {
            this.ServicioMantenimiento_ID = serviciomantenimiento_id;
            this.Servicio = servicio;
            this.TipoRefaccion_ID = tiporefaccion_id;
            this.Refaccion = refaccion;
            this.Cantidad = cantidad;
        }

        #endregion

        #region Properties
        private System.Int32 _ServicioMantenimiento_ID;
        public System.Int32 ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        private System.String _Servicio;
        public System.String Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }

        private System.Int32 _TipoRefaccion_ID;
        public System.Int32 TipoRefaccion_ID
        {
            get { return _TipoRefaccion_ID; }
            set { _TipoRefaccion_ID = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ServiciosMantenimientos_TiposRefacciones> Get(
            System.Int32? serviciomantenimiento_id)
        {
            string sqlstr = @"SELECT	SM.ServicioMantenimiento_ID, 
		SM.Nombre Servicio,
		TR.TipoRefaccion_ID, 
		TR.Nombre Refaccion,
		SMTR.Cantidad
FROM	ServiciosMantenimientos_TiposRefacciones SMTR
INNER JOIN	ServiciosMantenimientos SM
ON		SMTR.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
WHERE	( @ServicioMantenimiento_ID IS NULL OR SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);

            List<Vista_ServiciosMantenimientos_TiposRefacciones> list = new List<Vista_ServiciosMantenimientos_TiposRefacciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosMantenimientos_TiposRefacciones(
                       Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                       Convert.ToString(dr["Servicio"]),
                       Convert.ToInt32(dr["TipoRefaccion_ID"]),
                       Convert.ToString(dr["Refaccion"]),
                       Convert.ToInt32(dr["Cantidad"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? serviciomantenimiento_id)
        {
            string sqlstr = @"SELECT	SM.ServicioMantenimiento_ID, 
		SM.Nombre Servicio,
		TR.TipoRefaccion_ID, 
		TR.Nombre Refaccion,
		SMTR.Cantidad
FROM	ServiciosMantenimientos_TiposRefacciones SMTR
INNER JOIN	ServiciosMantenimientos SM
ON		SMTR.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
WHERE	( @ServicioMantenimiento_ID IS NULL OR SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ServiciosMantenimientos_TiposRefacciones

    public class Vista_PreciosServicioMantenimiento_TiposClientes
    {

        #region Constructors
        public Vista_PreciosServicioMantenimiento_TiposClientes()
        {
        }

        public Vista_PreciosServicioMantenimiento_TiposClientes(
            System.String tipocliente,
            System.String servicio,
            System.Decimal? precio
            )
        {
            this.TipoCliente = tipocliente;
            this.Servicio = servicio;
            this.Precio = precio;
        }

        #endregion

        #region Properties
        private System.String _TipoCliente;
        public System.String TipoCliente
        {
            get { return _TipoCliente; }
            set { _TipoCliente = value; }
        }

        private System.String _Servicio;
        public System.String Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_PreciosServicioMantenimiento_TiposClientes> Get(
            System.Object tipoclientetaller_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	UPPER(TCC.Nombre) TipoCliente, UPPER(SM.Nombre) Servicio, SMP.Precio
FROM	ServiciosMantenimientosPrecios SMP
INNER JOIN	ServiciosMantenimientos SM
ON		SMP.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
INNER JOIN	TiposClientesTaller TCC
ON		SMP.TipoClienteTaller_ID = TCC.TipoClienteTaller_ID
WHERE	SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID
AND		SMP.Empresa_ID = @Empresa_ID
AND		SMP.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_PreciosServicioMantenimiento_TiposClientes> list = new List<Vista_PreciosServicioMantenimiento_TiposClientes>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PreciosServicioMantenimiento_TiposClientes(
                       Convert.ToString(dr["TipoCliente"]),
                       Convert.ToString(dr["Servicio"]),
                       DB.GetNullableDecimal(dr["Precio"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object tipoclientetaller_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	UPPER(TCC.Nombre) TipoCliente, UPPER(SM.Nombre) Servicio, SMP.Precio
FROM	ServiciosMantenimientosPrecios SMP
INNER JOIN	ServiciosMantenimientos SM
ON		SMP.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
INNER JOIN	TiposClientesTaller TCC
ON		SMP.TipoClienteTaller_ID = TCC.TipoClienteTaller_ID
WHERE	SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID
AND		SMP.Empresa_ID = @Empresa_ID
AND		SMP.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_PreciosServicioMantenimiento_TiposClientes



    public class Vista_PreciosServicioMantenimiento
    {

        #region Constructors
        public Vista_PreciosServicioMantenimiento()
        {
        }

        public Vista_PreciosServicioMantenimiento(
            System.Int32? serviciomantenimiento_id,
            System.Int32? tipoclientetaller_id,
            System.String serviciomantenimiento,
            System.String cliente,
            System.Decimal? precio
            )
        {
            this.ServicioMantenimiento_ID = serviciomantenimiento_id;
            this.TipoClienteTaller_ID = tipoclientetaller_id;
            this.ServicioMantenimiento = serviciomantenimiento;
            this.Cliente = cliente;
            this.Precio = precio;
        }

        #endregion

        #region Properties
        private System.Int32? _ServicioMantenimiento_ID;
        public System.Int32? ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        private System.Int32? _TipoClienteTaller_ID;
        public System.Int32? TipoClienteTaller_ID
        {
            get { return _TipoClienteTaller_ID; }
            set { _TipoClienteTaller_ID = value; }
        }

        private System.String _ServicioMantenimiento;
        public System.String ServicioMantenimiento
        {
            get { return _ServicioMantenimiento; }
            set { _ServicioMantenimiento = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_PreciosServicioMantenimiento> Get(
            System.Int32? serviciomantenimiento_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	SM.ServicioMantenimiento_ID,
		SM.TipoClienteTaller_ID,
		SM.ServicioMantenimiento,
		SM.Cliente,
		ISNULL(SMP.Precio,0) Precio
FROM	(
SELECT	SM.ServicioMantenimiento_ID,
		UPPER(SM.Nombre) ServicioMantenimiento,
		TE.TipoClienteTaller_ID,
		UPPER(TE.Nombre) Cliente		
FROM	ServiciosMantenimientos SM
CROSS JOIN	TiposClientesTaller TE
WHERE	SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID
		) SM
LEFT JOIN	ServiciosMantenimientosPrecios SMP
ON		SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
		AND		SM.TipoClienteTaller_ID = SMP.TipoClienteTaller_ID
        AND SMP.Empresa_ID = @Empresa_ID 
        AND SMP.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_PreciosServicioMantenimiento> list = new List<Vista_PreciosServicioMantenimiento>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PreciosServicioMantenimiento(
                       DB.GetNullableInt32(dr["ServicioMantenimiento_ID"]),
                       DB.GetNullableInt32(dr["TipoClienteTaller_ID"]),
                       Convert.ToString(dr["ServicioMantenimiento"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableDecimal(dr["Precio"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? serviciomantenimiento_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	SM.ServicioMantenimiento_ID,
		SM.TipoClienteTaller_ID,
		SM.ServicioMantenimiento,
		SM.Cliente,
		ISNULL(SMP.Precio,0) Precio
FROM	(
SELECT	SM.ServicioMantenimiento_ID,
		UPPER(SM.Nombre) ServicioMantenimiento,
		TE.TipoClienteTaller_ID,
		UPPER(TE.Nombre) Cliente		
FROM	ServiciosMantenimientos SM
CROSS JOIN	TiposClientesTaller TE
WHERE	SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID
		) SM
LEFT JOIN	ServiciosMantenimientosPrecios SMP
ON		SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
		AND		SM.TipoClienteTaller_ID = SMP.TipoClienteTaller_ID
        AND SMP.Empresa_ID = @Empresa_ID 
        AND SMP.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_PreciosServicioMantenimiento



    public class Vista_RegistroPublicitario
    {

        #region Constructors
        public Vista_RegistroPublicitario()
        {
        }

        public Vista_RegistroPublicitario(
            System.String empresa,
            System.String estacion,
            System.String nombre,
            System.String telefono,
            System.String clasepublicidad,
            System.String mediopublicitario,
            System.Boolean? cumplioperfil,
            System.Boolean? interesado,
            System.String mercado,
            System.String comentarios,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ClasePublicidad = clasepublicidad;
            this.MedioPublicitario = mediopublicitario;
            this.CumplioPerfil = cumplioperfil;
            this.Interesado = interesado;
            this.Mercado = mercado;
            this.Comentarios = comentarios;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _ClasePublicidad;
        public System.String ClasePublicidad
        {
            get { return _ClasePublicidad; }
            set { _ClasePublicidad = value; }
        }

        private System.String _MedioPublicitario;
        public System.String MedioPublicitario
        {
            get { return _MedioPublicitario; }
            set { _MedioPublicitario = value; }
        }

        private System.Boolean? _CumplioPerfil;
        public System.Boolean? CumplioPerfil
        {
            get { return _CumplioPerfil; }
            set { _CumplioPerfil = value; }
        }

        private System.Boolean? _Interesado;
        public System.Boolean? Interesado
        {
            get { return _Interesado; }
            set { _Interesado = value; }
        }

        private System.String _Mercado;
        public System.String Mercado
        {
            get { return _Mercado; }
            set { _Mercado = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_RegistroPublicitario> Get(
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal
            )
        {
            string sqlstr = @"SELECT	'CASCO' Empresa, Est.Nombre Estacion,
		UPPER(C.Apellidos + ' ' + C.Nombre) Nombre, C.Telefono, 
		CP.Nombre ClasePublicidad,
		MP.Nombre MedioPublicitario, 
		C.CumplioPerfil, C.Interesado, M.Nombre Mercado,
		C.Comentarios, C.Fecha, C.Usuario_ID
FROM	Conductores C
INNER JOIN	MediosPublicitarios MP
ON		C.MedioPublicitario_ID = MP.MedioPublicitario_ID
INNER JOIN	ClasesPublicidad CP
ON		CP.ClasePublicidad_ID = MP.ClasePublicidad_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	Mercados M
ON		C.Mercado_ID = M.Mercado_ID
WHERE	(@Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
AND	C.Fecha BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_RegistroPublicitario> list = new List<Vista_RegistroPublicitario>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_RegistroPublicitario(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToString(dr["Telefono"]),
                       Convert.ToString(dr["ClasePublicidad"]),
                       Convert.ToString(dr["MedioPublicitario"]),
                       DB.GetNullableBoolean(dr["CumplioPerfil"]),
                       DB.GetNullableBoolean(dr["Interesado"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	'CASCO' Empresa, Est.Nombre Estacion,
		UPPER(C.Apellidos + ' ' + C.Nombre) Nombre, C.Telefono, 
		CP.Nombre ClasePublicidad,
		MP.Nombre MedioPublicitario, 
		C.CumplioPerfil, C.Interesado, M.Nombre Mercado,
		C.Comentarios, C.Fecha, C.Usuario_ID
FROM	Conductores C
INNER JOIN	MediosPublicitarios MP
ON		C.MedioPublicitario_ID = MP.MedioPublicitario_ID
INNER JOIN	ClasesPublicidad CP
ON		CP.ClasePublicidad_ID = MP.ClasePublicidad_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	Mercados M
ON		C.Mercado_ID = M.Mercado_ID
WHERE	(@Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
AND	C.Fecha BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_RegistroPublicitario


    public class Vista_ReporteFlotilla
    {

        #region Constructors
        public Vista_ReporteFlotilla()
        {
        }

        public Vista_ReporteFlotilla(
            System.String empresa,
            System.String estacion,
            System.Int32? numeroeconomico,
            System.String conductor,
            System.String locacion,
            System.String modelo,
            System.String placas,
            System.String numeroserie,
            System.Decimal? rentadiaria,
            System.String plandecobro
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor = conductor;
            this.Locacion = locacion;
            this.Modelo = modelo;
            this.Placas = placas;
            this.NumeroSerie = numeroserie;
            this.RentaDiaria = rentadiaria;
            this.PlanDeCobro = plandecobro;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Locacion;
        public System.String Locacion
        {
            get { return _Locacion; }
            set { _Locacion = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.String _Placas;
        public System.String Placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }

        private System.String _NumeroSerie;
        public System.String NumeroSerie
        {
            get { return _NumeroSerie; }
            set { _NumeroSerie = value; }
        }

        private System.Decimal? _RentaDiaria;
        public System.Decimal? RentaDiaria
        {
            get { return _RentaDiaria; }
            set { _RentaDiaria = value; }
        }

        private System.String _PlanDeCobro;
        public System.String PlanDeCobro
        {
            get { return _PlanDeCobro; }
            set { _PlanDeCobro = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteFlotilla> Get(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	U.Empresa, U.Estacion, U.NumeroEconomico, ISNULL(C.Conductor,'-NO ASIGNADA-') Conductor,
		U.Locacion, U.Modelo,  U.Placas,
		U.NumeroSerie, C.RentaDiaria, C.PlanDeCobro
FROM	(
SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, U.NumeroSerie, 
	LU.Nombre Locacion, E.Nombre Estacion, MU.Descripcion Modelo,
	EM.Nombre Empresa
FROM	Unidades U
INNER JOIN	Empresas EM
ON		U.Empresa_ID = EM.Empresa_ID
INNER JOIN	Estaciones E
ON		U.Estacion_ID = E.Estacion_ID
INNER JOIN	LocacionesUnidades LU
ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
WHERE	( U.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( U.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		U.EstatusUnidad_ID <> 5
) U
LEFT JOIN
(
SELECT	U.Unidad_ID, COND.Apellidos + ' ' + COND.Nombre Conductor,
		C.MontoDiario RentaDiaria,
		DDC.Nombre + ' ' + CONVERT(varchar,C.MontoDiario) PlanDeCobro
FROM	Contratos C
INNER JOIN	Unidades U
ON		C.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores COND
ON		C.Conductor_ID = COND.Conductor_ID
INNER JOIN	DiasDeCobros DDC
ON		C.DiasDeCobro_ID = DDC.DiasDeCobro_ID
WHERE	C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1
AND		( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
--AND C.TipoContrato_ID IN (1,2)
) C
ON	U.Unidad_ID = C.Unidad_ID
ORDER BY	Empresa, Estacion, NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ReporteFlotilla> list = new List<Vista_ReporteFlotilla>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteFlotilla(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Placas"]),
                       Convert.ToString(dr["NumeroSerie"]),
                       DB.GetNullableDecimal(dr["RentaDiaria"]),
                       Convert.ToString(dr["PlanDeCobro"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	U.Empresa, U.Estacion, U.NumeroEconomico, ISNULL(C.Conductor,'-NO ASIGNADA-') Conductor,
		U.Locacion, U.Modelo,  U.Placas,
		U.NumeroSerie, C.RentaDiaria, C.PlanDeCobro
FROM	(
SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, U.NumeroSerie, 
	LU.Nombre Locacion, E.Nombre Estacion, MU.Descripcion Modelo,
	EM.Nombre Empresa
FROM	Unidades U
INNER JOIN	Empresas EM
ON		U.Empresa_ID = EM.Empresa_ID
INNER JOIN	Estaciones E
ON		U.Estacion_ID = E.Estacion_ID
INNER JOIN	LocacionesUnidades LU
ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
WHERE	( U.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( U.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		U.EstatusUnidad_ID <> 5
) U
LEFT JOIN
(
SELECT	U.Unidad_ID, COND.Apellidos + ' ' + COND.Nombre Conductor,
		C.MontoDiario RentaDiaria,
		DDC.Nombre + ' ' + CONVERT(varchar,C.MontoDiario) PlanDeCobro
FROM	Contratos C
INNER JOIN	Unidades U
ON		C.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores COND
ON		C.Conductor_ID = COND.Conductor_ID
INNER JOIN	DiasDeCobros DDC
ON		C.DiasDeCobro_ID = DDC.DiasDeCobro_ID
WHERE	C.EstatusContrato_ID = 1 AND C.Cuenta_ID in (select Cuenta_ID from Transacciones.CuentasCobro where Activo = 1)
AND		( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
--AND C.TipoContrato_ID IN (1,2)
) C
ON	U.Unidad_ID = C.Unidad_ID
ORDER BY	Empresa, Estacion, NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteFlotilla



    public class Vista_Conductores
    {

        #region Constructors
        public Vista_Conductores()
        {
        }

        public Vista_Conductores(
            System.String estacion,
            System.String estado,
            System.Int32? conductor_id,
            System.String rfc,
            System.String nombre,
            System.String domicilio,
            System.String ciudad,
            System.String entidad,
            System.String telefono,
            System.String telefono2,
            System.String movil,
            System.String telefono_aval
            )
        {
            this.Estacion = estacion;
            this.Estado = estado;
            this.Conductor_ID = conductor_id;
            this.Rfc = rfc;
            this.Nombre = nombre;
            this.Domicilio = domicilio;
            this.Ciudad = ciudad;
            this.Entidad = entidad;
            this.Telefono = telefono;
            this.Telefono2 = telefono2;
            this.Movil = movil;
            this.Telefono_Aval = telefono_aval;
        }

        #endregion

        #region Properties
        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Estado;
        public System.String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Rfc;
        public System.String Rfc
        {
            get { return _Rfc; }
            set { _Rfc = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Domicilio;
        public System.String Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private System.String _Ciudad;
        public System.String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        private System.String _Entidad;
        public System.String Entidad
        {
            get { return _Entidad; }
            set { _Entidad = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _Telefono2;
        public System.String Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }

        private System.String _Movil;
        public System.String Movil
        {
            get { return _Movil; }
            set { _Movil = value; }
        }

        private System.String _Telefono_Aval;
        public System.String Telefono_Aval
        {
            get { return _Telefono_Aval; }
            set { _Telefono_Aval = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Conductores> Get(
            System.Int32? conductor_id,
            System.String nombre,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	Est.Nombre Estacion, EC.Nombre Estado, C.Conductor_ID, C.Rfc, (C.Apellidos + ' ' + C.Nombre) Nombre, C.Domicilio, 
		C.Ciudad, C.Entidad, C.Telefono, C.Telefono2, C.Movil, C.Telefono_Aval
FROM	Conductores C
INNER JOIN Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN EstatusConductores EC
ON      C.EstatusConductor_ID = EC.EstatusConductor_ID
WHERE	(@Conductor_ID IS NULL OR C.Conductor_ID = @Conductor_ID)
AND		(@Nombre IS NULL OR (C.Apellidos + ' ' + C.Nombre) LIKE '%' + @Nombre + '%')
AND		(@Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Conductores> list = new List<Vista_Conductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Conductores(
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Estado"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Rfc"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToString(dr["Domicilio"]),
                       Convert.ToString(dr["Ciudad"]),
                       Convert.ToString(dr["Entidad"]),
                       Convert.ToString(dr["Telefono"]),
                       Convert.ToString(dr["Telefono2"]),
                       Convert.ToString(dr["Movil"]),
                       Convert.ToString(dr["Telefono_Aval"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? conductor_id,
            System.String nombre,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	Est.Nombre Estacion, EC.Nombre Estado, C.Conductor_ID, C.Rfc, (C.Apellidos + ' ' + C.Nombre) Nombre, C.Domicilio, 
		C.Ciudad, C.Entidad, C.Telefono, C.Telefono2, C.Movil, C.Telefono_Aval
FROM	Conductores C
INNER JOIN Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN EstatusConductores EC
ON      C.EstatusConductor_ID = EC.EstatusConductor_ID
WHERE	(@Conductor_ID IS NULL OR C.Conductor_ID = @Conductor_ID)
AND		(@Nombre IS NULL OR (C.Apellidos + ' ' + C.Nombre) LIKE '%' + @Nombre + '%')
AND		(@Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Conductores


    public class Vista_PermisosUsuarios
    {

        #region Constructors
        public Vista_PermisosUsuarios()
        {
        }

        public Vista_PermisosUsuarios(
            System.Int32? modulo_id,
            System.String modulo,
            System.Int32? menu_id,
            System.String menu,
            System.Int32? opcion_id,
            System.String opcion,
            System.String usuario_id,
            System.Boolean? espermitido,
            System.String opciontexto,
            System.String opcionimagen,
            System.Boolean? esherramienta,
            System.Boolean? esactivo
            )
        {
            this.Modulo_ID = modulo_id;
            this.Modulo = modulo;
            this.Menu_ID = menu_id;
            this.Menu = menu;
            this.Opcion_ID = opcion_id;
            this.Opcion = opcion;
            this.Usuario_ID = usuario_id;
            this.EsPermitido = espermitido;
            this.OpcionTexto = opciontexto;
            this.OpcionImagen = opcionimagen;
            this.EsHerramienta = esherramienta;
            this.EsActivo = esactivo;
        }

        #endregion

        #region Properties
        private System.Int32? _Modulo_ID;
        public System.Int32? Modulo_ID
        {
            get { return _Modulo_ID; }
            set { _Modulo_ID = value; }
        }

        private System.String _Modulo;
        public System.String Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }

        private System.Int32? _Menu_ID;
        public System.Int32? Menu_ID
        {
            get { return _Menu_ID; }
            set { _Menu_ID = value; }
        }

        private System.String _Menu;
        public System.String Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }

        private System.Int32? _Opcion_ID;
        public System.Int32? Opcion_ID
        {
            get { return _Opcion_ID; }
            set { _Opcion_ID = value; }
        }

        private System.String _Opcion;
        public System.String Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.Boolean? _EsPermitido;
        public System.Boolean? EsPermitido
        {
            get { return _EsPermitido; }
            set { _EsPermitido = value; }
        }

        private System.String _OpcionTexto;
        public System.String OpcionTexto
        {
            get { return _OpcionTexto; }
            set { _OpcionTexto = value; }
        }

        private System.String _OpcionImagen;
        public System.String OpcionImagen
        {
            get { return _OpcionImagen; }
            set { _OpcionImagen = value; }
        }

        private System.Boolean? _EsHerramienta;
        public System.Boolean? EsHerramienta
        {
            get { return _EsHerramienta; }
            set { _EsHerramienta = value; }
        }

        private System.Boolean? _EsActivo;
        public System.Boolean? EsActivo
        {
            get { return _EsActivo; }
            set { _EsActivo = value; }
        }

        #endregion

        #region Methods

        public static bool EsOpcionPermitida(string usuario_id, int opcion_id)
        {
            string sql = @"SELECT EsPermitido 
FROM PermisosUsuarios 
WHERE Usuario_ID = @Usuario_ID 
AND Opcion_ID = @Opcion_ID";

            return Convert.ToBoolean(
                DB.QueryScalar(
                   sql,
                   DB.Param("@Usuario_ID", usuario_id),
                   DB.Param("@Opcion_ID", opcion_id)
                )
            );
        }

        public static List<Vista_PermisosUsuarios> Get(
            System.String usuario_id)
        {




            string sqlstr;


            sqlstr = @"exec spMenuSicas @Usuario_ID";

//                sqlstr = @"SELECT	MO.Modulo_ID,
//		MO.Nombre Modulo, 
//		M.Menu_ID,
//		M.Nombre Menu,
//		O.Opcion_ID,
//		O.Nombre Opcion,
//		PU.Usuario_ID,
//		ISNULL(PU.EsPermitido, 0) EsPermitido,
//		O.Texto OpcionTexto,
//		O.Imagen OpcionImagen,
//		O.EsHerramienta,
//		O.EsActivo			
//FROM	Opciones O
//	LEFT JOIN	PermisosUsuarios PU
//		ON		 ( PU.Opcion_ID = O.Opcion_ID
//					AND PU.Usuario_ID = @Usuario_ID )
//	INNER JOIN	Menues M
//		ON		O.Menu_ID = M.Menu_ID
//	INNER JOIN	Modulos MO
//		ON		M.Modulo_ID = MO.Modulo_ID
//ORDER BY	Modulo, Menu, Opcion";

          

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_PermisosUsuarios> list = new List<Vista_PermisosUsuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PermisosUsuarios(
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
            }
            return list;
        } // End GetData

        public static List<Vista_PermisosUsuarios> Get(
            System.String usuario_id,
            System.Int32? menu_id)
        {
            string sqlstr = @"SELECT	MO.Modulo_ID,
		MO.Nombre Modulo, 
		M.Menu_ID,
		M.Nombre Menu,
		O.Opcion_ID,
		O.Nombre Opcion,
		PU.Usuario_ID,
		ISNULL(PU.EsPermitido, 0) EsPermitido,
		O.Texto OpcionTexto,
		O.Imagen OpcionImagen,
		O.EsHerramienta,
		O.EsActivo			
FROM	Opciones O
	LEFT JOIN	PermisosUsuarios PU
		ON		 ( PU.Opcion_ID = O.Opcion_ID
					AND PU.Usuario_ID = @Usuario_ID )
	INNER JOIN	Menues M
		ON		O.Menu_ID = M.Menu_ID
	INNER JOIN	Modulos MO
		ON		M.Modulo_ID = MO.Modulo_ID
WHERE	M.Menu_ID = @Menu_ID
ORDER BY	Modulo, Menu, Opcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Menu_ID", menu_id);

            List<Vista_PermisosUsuarios> list = new List<Vista_PermisosUsuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PermisosUsuarios(
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
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String usuario_id)
        {
            string sqlstr = "";
//            string sqlstr = @"SELECT	MO.Modulo_ID,
//		MO.Nombre Modulo, 
//		M.Menu_ID,
//		M.Nombre Menu,
//		O.Opcion_ID,
//		O.Nombre Opcion,
//		PU.Usuario_ID,
//		ISNULL(PU.EsPermitido, 0) EsPermitido,
//		O.Texto OpcionTexto,
//		O.Imagen OpcionImagen,
//		O.EsHerramienta,
//		O.EsActivo			
//FROM	Opciones O
//	LEFT JOIN	PermisosUsuarios PU
//		ON		 ( PU.Opcion_ID = O.Opcion_ID
//					AND PU.Usuario_ID = @Usuario_ID )
//	INNER JOIN	Menues M
//		ON		O.Menu_ID = M.Menu_ID
//	INNER JOIN	Modulos MO
//		ON		M.Modulo_ID = MO.Modulo_ID
//ORDER BY	Modulo, Menu, Opcion";


            sqlstr = @"exec spMenuSicas @Usuario_ID";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static DataTable GetDataTable(
            System.String usuario_id,
            System.Int32? menu_id)
        {
            string sqlstr = @"SELECT	MO.Modulo_ID,
		MO.Nombre Modulo, 
		M.Menu_ID,
		M.Nombre Menu,
		O.Opcion_ID,
		O.Nombre Opcion,
		PU.Usuario_ID,
		ISNULL(PU.EsPermitido, 0) EsPermitido,
		O.Texto OpcionTexto,
		O.Imagen OpcionImagen,
		O.EsHerramienta,
		O.EsActivo			
FROM	Opciones O
	LEFT JOIN	PermisosUsuarios PU
		ON		 ( PU.Opcion_ID = O.Opcion_ID
					AND PU.Usuario_ID = @Usuario_ID )
	INNER JOIN	Menues M
		ON		O.Menu_ID = M.Menu_ID
	INNER JOIN	Modulos MO
		ON		M.Modulo_ID = MO.Modulo_ID
WHERE	M.Menu_ID = @Menu_ID
ORDER BY	Modulo, Menu, Opcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@Menu_ID", menu_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_PermisosUsuarios

    public class Vista_PermisosGruposUsuarios
    {

        #region Constructors
        public Vista_PermisosGruposUsuarios()
        {
        }

        public Vista_PermisosGruposUsuarios(
            System.Int32? modulo_id,
            System.String modulo,
            System.Int32? menu_id,
            System.String menu,
            System.Int32? opcion_id,
            System.String opcion,
            System.Int32? grupousuario_id,
            System.String grupousuario,
            System.Boolean? espermitido
            )
        {
            this.Modulo_ID = modulo_id;
            this.Modulo = modulo;
            this.Menu_ID = menu_id;
            this.Menu = menu;
            this.Opcion_ID = opcion_id;
            this.Opcion = opcion;
            this.GrupoUsuario_ID = grupousuario_id;
            this.GrupoUsuario = grupousuario;
            this.EsPermitido = espermitido;
        }

        #endregion

        #region Properties
        private System.Int32? _Modulo_ID;
        public System.Int32? Modulo_ID
        {
            get { return _Modulo_ID; }
            set { _Modulo_ID = value; }
        }

        private System.String _Modulo;
        public System.String Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }

        private System.Int32? _Menu_ID;
        public System.Int32? Menu_ID
        {
            get { return _Menu_ID; }
            set { _Menu_ID = value; }
        }

        private System.String _Menu;
        public System.String Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }

        private System.Int32? _Opcion_ID;
        public System.Int32? Opcion_ID
        {
            get { return _Opcion_ID; }
            set { _Opcion_ID = value; }
        }

        private System.String _Opcion;
        public System.String Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }

        private System.Int32? _GrupoUsuario_ID;
        public System.Int32? GrupoUsuario_ID
        {
            get { return _GrupoUsuario_ID; }
            set { _GrupoUsuario_ID = value; }
        }

        private System.String _GrupoUsuario;
        public System.String GrupoUsuario
        {
            get { return _GrupoUsuario; }
            set { _GrupoUsuario = value; }
        }

        private System.Boolean? _EsPermitido;
        public System.Boolean? EsPermitido
        {
            get { return _EsPermitido; }
            set { _EsPermitido = value; }
        }

        #endregion

        #region Methods

        public static List<Vista_PermisosGruposUsuarios> Get(
            System.Int32? menu_id,
            System.Int32? grupousuario_id
            )
        {
            string sqlstr = @"SELECT	MO.Modulo_ID,
		MO.Nombre Modulo, 
		M.Menu_ID,
		M.Nombre Menu,
		O.Opcion_ID,
		O.Nombre Opcion,
		GU.GrupoUsuario_ID,
		GU.Nombre GrupoUsuario,
		ISNULL(PGU.EsPermitido, 0) EsPermitido	
FROM	Opciones O
LEFT JOIN	PermisosGruposUsuarios PGU
ON		 ( PGU.Opcion_ID = O.Opcion_ID
			AND PGU.GrupoUsuario_ID = @GrupoUsuario_ID )
LEFT JOIN	GruposUsuarios GU
ON		PGU.GrupoUsuario_ID = GU.GrupoUsuario_ID
INNER JOIN	Menues M
ON		O.Menu_ID = M.Menu_ID
INNER JOIN	Modulos MO
ON		M.Modulo_ID = MO.Modulo_ID
WHERE	M.Menu_ID = @Menu_ID
ORDER BY	Modulo, Menu, Opcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@GrupoUsuario_ID", grupousuario_id);
            m_params.Add("@Menu_ID", menu_id);

            List<Vista_PermisosGruposUsuarios> list = new List<Vista_PermisosGruposUsuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PermisosGruposUsuarios(
                       DB.GetNullableInt32(dr["Modulo_ID"]),
                       Convert.ToString(dr["Modulo"]),
                       DB.GetNullableInt32(dr["Menu_ID"]),
                       Convert.ToString(dr["Menu"]),
                       DB.GetNullableInt32(dr["Opcion_ID"]),
                       Convert.ToString(dr["Opcion"]),
                       DB.GetNullableInt32(dr["GrupoUsuario_ID"]),
                       Convert.ToString(dr["GrupoUsuario"]),
                       DB.GetNullableBoolean(dr["EsPermitido"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_PermisosGruposUsuarios> Get(
            System.Int32? grupousuario_id)
        {
            string sqlstr = @"SELECT	MO.Modulo_ID,
		MO.Nombre Modulo, 
		M.Menu_ID,
		M.Nombre Menu,
		O.Opcion_ID,
		O.Nombre Opcion,
		GU.GrupoUsuario_ID,
		GU.Nombre GrupoUsuario,
		ISNULL(PGU.EsPermitido, 0) EsPermitido	
FROM	Opciones O
LEFT JOIN	PermisosGruposUsuarios PGU
ON		 ( PGU.Opcion_ID = O.Opcion_ID
			AND PGU.GrupoUsuario_ID = @GrupoUsuario_ID )
LEFT JOIN	GruposUsuarios GU
ON		PGU.GrupoUsuario_ID = GU.GrupoUsuario_ID
INNER JOIN	Menues M
ON		O.Menu_ID = M.Menu_ID
INNER JOIN	Modulos MO
ON		M.Modulo_ID = MO.Modulo_ID
ORDER BY	Modulo, Menu, Opcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@GrupoUsuario_ID", grupousuario_id);

            List<Vista_PermisosGruposUsuarios> list = new List<Vista_PermisosGruposUsuarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PermisosGruposUsuarios(
                       DB.GetNullableInt32(dr["Modulo_ID"]),
                       Convert.ToString(dr["Modulo"]),
                       DB.GetNullableInt32(dr["Menu_ID"]),
                       Convert.ToString(dr["Menu"]),
                       DB.GetNullableInt32(dr["Opcion_ID"]),
                       Convert.ToString(dr["Opcion"]),
                       DB.GetNullableInt32(dr["GrupoUsuario_ID"]),
                       Convert.ToString(dr["GrupoUsuario"]),
                       DB.GetNullableBoolean(dr["EsPermitido"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? grupousuario_id)
        {
            string sqlstr = @"SELECT	MO.Modulo_ID,
		MO.Nombre Modulo, 
		M.Menu_ID,
		M.Nombre Menu,
		O.Opcion_ID,
		O.Nombre Opcion,
		GU.GrupoUsuario_ID,
		GU.Nombre GrupoUsuario,
		ISNULL(PGU.EsPermitido, 0) EsPermitido	
FROM	Opciones O
LEFT JOIN	PermisosGruposUsuarios PGU
ON		 ( PGU.Opcion_ID = O.Opcion_ID
			AND PGU.GrupoUsuario_ID = @GrupoUsuario_ID )
LEFT JOIN	GruposUsuarios GU
ON		PGU.GrupoUsuario_ID = GU.GrupoUsuario_ID
INNER JOIN	Menues M
ON		O.Menu_ID = M.Menu_ID
INNER JOIN	Modulos MO
ON		M.Modulo_ID = MO.Modulo_ID
ORDER BY	Modulo, Menu, Opcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@GrupoUsuario_ID", grupousuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_PermisosGruposUsuarios

    public class Vista_HistorialCobranzaConductores
    {

        #region Constructors
        public Vista_HistorialCobranzaConductores()
        {
        }

        public Vista_HistorialCobranzaConductores(
            System.Int32? conductor_id,
            System.DateTime? fecha,
            System.String estacion,
            System.String conductor,
            System.String accion,
            System.String comentario,
            System.String usuario_id
            )
        {
            this.Conductor_ID = conductor_id;
            this.Fecha = fecha;
            this.Estacion = estacion;
            this.Conductor = conductor;
            this.Accion = accion;
            this.Comentario = comentario;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Accion;
        public System.String Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }

        private System.String _Comentario;
        public System.String Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_HistorialCobranzaConductores> Get(
            System.Int32? conductor_id)
        {
            string sqlstr = @"SELECT	HCC.Conductor_ID,
		HCC.Fecha,
		EST.Nombre Estacion,
		C.Apellidos + ' ' + C.Nombre Conductor,
		HCC.Accion,
		HCC.Comentario,
		HCC.Usuario_ID
FROM	HistorialCobranzaConductores HCC
INNER JOIN	Conductores C
ON		HCC.Conductor_ID = C.Conductor_ID
INNER JOIN	Estaciones EST
ON		HCC.Estacion_ID = EST.Estacion_ID
WHERE		( HCC.Conductor_ID = @Conductor_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);

            List<Vista_HistorialCobranzaConductores> list = new List<Vista_HistorialCobranzaConductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_HistorialCobranzaConductores(
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Accion"]),
                       Convert.ToString(dr["Comentario"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? conductor_id)
        {
            string sqlstr = @"SELECT	HCC.Conductor_ID,
		HCC.Fecha,
		EST.Nombre Estacion,
		C.Apellidos + ' ' + C.Nombre Conductor,
		HCC.Accion,
		HCC.Comentario,
		HCC.Usuario_ID
FROM	HistorialCobranzaConductores HCC
INNER JOIN	Conductores C
ON		HCC.Conductor_ID = C.Conductor_ID
INNER JOIN	Estaciones EST
ON		HCC.Estacion_ID = EST.Estacion_ID
WHERE		( HCC.Conductor_ID = @Conductor_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_HistorialCobranzaConductores

    public class Vista_MediosPublicitarios
    {

        #region Constructors
        public Vista_MediosPublicitarios()
        {
        }

        public Vista_MediosPublicitarios(
            System.String empresa,
            System.String estacion,
            System.String nombre,
            System.String telefono,
            System.String clasepublicidad,
            System.String mediopublicitario,
            System.Boolean? cumplioperfil,
            System.Boolean? interesado,
            System.String mercado,
            System.String comentarios,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ClasePublicidad = clasepublicidad;
            this.MedioPublicitario = mediopublicitario;
            this.CumplioPerfil = cumplioperfil;
            this.Interesado = interesado;
            this.Mercado = mercado;
            this.Comentarios = comentarios;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _ClasePublicidad;
        public System.String ClasePublicidad
        {
            get { return _ClasePublicidad; }
            set { _ClasePublicidad = value; }
        }

        private System.String _MedioPublicitario;
        public System.String MedioPublicitario
        {
            get { return _MedioPublicitario; }
            set { _MedioPublicitario = value; }
        }

        private System.Boolean? _CumplioPerfil;
        public System.Boolean? CumplioPerfil
        {
            get { return _CumplioPerfil; }
            set { _CumplioPerfil = value; }
        }

        private System.Boolean? _Interesado;
        public System.Boolean? Interesado
        {
            get { return _Interesado; }
            set { _Interesado = value; }
        }

        private System.String _Mercado;
        public System.String Mercado
        {
            get { return _Mercado; }
            set { _Mercado = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_MediosPublicitarios> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"SELECT	'INDEFINIDA' Empresa, Est.Nombre Estacion,
		C.Nombre, C.Telefono, 
		CP.Nombre ClasePublicidad,
		MP.Nombre MedioPublicitario, 
		C.CumplioPerfil, C.Interesado, M.Nombre Mercado,
		C.Comentarios, C.Fecha, C.Usuario_ID
FROM	Conductores C
INNER JOIN	MediosPublicitarios MP
ON		C.MedioPublicitario_ID = MP.MedioPublicitario_ID
INNER JOIN	ClasesPublicidad CP
ON		CP.ClasePublicidad_ID = MP.ClasePublicidad_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	Mercados M
ON		C.Mercado_ID = M.Mercado_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_MediosPublicitarios> list = new List<Vista_MediosPublicitarios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_MediosPublicitarios(
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToString(dr["Telefono"]),
                       Convert.ToString(dr["ClasePublicidad"]),
                       Convert.ToString(dr["MedioPublicitario"]),
                       DB.GetNullableBoolean(dr["CumplioPerfil"]),
                       DB.GetNullableBoolean(dr["Interesado"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32? estacion_id
        )
        {
            string sqlstr = @"SELECT	'INDEFINIDA' Empresa, Est.Nombre Estacion,
		C.Nombre, C.Telefono, 
		CP.Nombre ClasePublicidad,
		MP.Nombre MedioPublicitario, 
		C.CumplioPerfil, C.Interesado, M.Nombre Mercado,
		C.Comentarios, C.Fecha, C.Usuario_ID
FROM	Conductores C
INNER JOIN	MediosPublicitarios MP
ON		C.MedioPublicitario_ID = MP.MedioPublicitario_ID
INNER JOIN	ClasesPublicidad CP
ON		CP.ClasePublicidad_ID = MP.ClasePublicidad_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	Mercados M
ON		C.Mercado_ID = M.Mercado_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_MediosPublicitarios

    public class Vista_CuentaCajas
    {

        #region Constructors
        public Vista_CuentaCajas()
        {
        }

        public Vista_CuentaCajas(
            System.Int32? cuentacaja_id,
            System.Int32? ticket_id,
            System.Int32? sesion_id,
            System.String empresa,
            System.String estacion,
            System.String caja,
            System.String cuenta,
            System.String concepto,
            System.Decimal? cargo,
            System.Decimal? abono,
            System.Decimal? saldo,
            System.String comentarios,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.CuentaCaja_ID = cuentacaja_id;
            this.Ticket_ID = ticket_id;
            this.Sesion_ID = sesion_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Caja = caja;
            this.Cuenta = cuenta;
            this.Concepto = concepto;
            this.Cargo = cargo;
            this.Abono = abono;
            this.Saldo = saldo;
            this.Comentarios = comentarios;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _CuentaCaja_ID;
        public System.Int32? CuentaCaja_ID
        {
            get { return _CuentaCaja_ID; }
            set { _CuentaCaja_ID = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private System.Decimal? _Cargo;
        public System.Decimal? Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_CuentaCajas> Get(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID,
		T.Ticket_ID,
		CC.Sesion_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
	INNER JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	LEFT JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID
WHERE	( T.Ticket_ID = @Ticket_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            List<Vista_CuentaCajas> list = new List<Vista_CuentaCajas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaCajas(
                       DB.GetNullableInt32(dr["CuentaCaja_ID"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID,
		T.Ticket_ID,
		CC.Sesion_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
	INNER JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	LEFT JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID
WHERE	( T.Ticket_ID = @Ticket_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static DataTable GetDataTable(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.String usuario_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	CC.CuentaCaja_ID,
		T.Ticket_ID,
		CC.Sesion_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
INNER JOIN	Tickets T
ON		CC.Ticket_ID = T.Ticket_ID
INNER JOIN	Cuentas C
ON		CC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		CC.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		CC.Estacion_ID = EST.Estacion_ID
INNER JOIN	Cajas CA
ON		CC.Caja_ID = CA.Caja_ID
LEFT JOIN	Conceptos CON
ON		CC.Concepto_ID = CON.Concepto_ID
WHERE	( CC.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( CC.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND		( CC.Fecha BETWEEN @FechaInicial AND @FechaFinal )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        #endregion
    } // End Class Vista_CuentaCajas

    public class Vista_CuentaConductores
    {

        #region Constructors
        public Vista_CuentaConductores()
        {
        }

        public Vista_CuentaConductores(
            System.Int32? cuentaconductor_id,
            System.String conductor,
            System.Int32? unidad,
            System.Int32? ticket_id,
            System.String empresa,
            System.String estacion,
            System.String caja,
            System.String cuenta,
            System.String concepto,
            System.Decimal? cargo,
            System.Decimal? abono,
            System.Decimal? saldo,
            System.String comentarios,
            System.DateTime? fecha,
            System.String usuario_id
            )
        {
            this.CuentaConductor_ID = cuentaconductor_id;
            this.Conductor = conductor;
            this.Unidad = unidad;
            this.Ticket_ID = ticket_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Caja = caja;
            this.Cuenta = cuenta;
            this.Concepto = concepto;
            this.Cargo = cargo;
            this.Abono = abono;
            this.Saldo = saldo;
            this.Comentarios = comentarios;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _CuentaConductor_ID;
        public System.Int32? CuentaConductor_ID
        {
            get { return _CuentaConductor_ID; }
            set { _CuentaConductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private System.Decimal? _Cargo;
        public System.Decimal? Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods

        public static List<Vista_CuentaConductores> Get(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal
            )
        {
            string sqlstr = @"SELECT	CC.CuentaConductor_ID,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		U.NumeroEconomico Unidad,
		T.Ticket_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaConductores CC
	LEFT JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	LEFT JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	INNER JOIN	Conductores CO
		ON		CC.Conductor_ID = CO.Conductor_ID
	LEFT JOIN	Unidades U
		ON		CC.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID		
WHERE	( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND		CC.Ticket_ID IS NULL
AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		CC.Usuario_ID NOT IN ('Admin','SICAS')
ORDER BY CC.Fecha, U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_CuentaConductores> list = new List<Vista_CuentaConductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaConductores(
                       DB.GetNullableInt32(dr["CuentaConductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_CuentaConductores> Get(
            System.Int32 conductor_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal
            )
        {
            string sqlstr = @"SELECT	CC.CuentaConductor_ID,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		U.NumeroEconomico Unidad,
		T.Ticket_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaConductores CC
	LEFT JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	LEFT JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	INNER JOIN	Conductores CO
		ON		CC.Conductor_ID = CO.Conductor_ID
	LEFT JOIN	Unidades U
		ON		CC.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID		
WHERE	( CC.Conductor_ID = @Conductor_ID )
AND		CC.Ticket_ID IS NULL
AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		CC.Usuario_ID NOT IN ('Admin','SICAS')
ORDER BY CC.Fecha, U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_CuentaConductores> list = new List<Vista_CuentaConductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaConductores(
                       DB.GetNullableInt32(dr["CuentaConductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_CuentaConductores> Get(
            System.Int32? conductor_id,
            System.Int32? cuenta_id
            )
        {
            string sqlstr = @"dbo.usp_Detalle_Edo_Cta_Conductor_Cuenta_Empresa";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Cuenta_ID", cuenta_id);
            //m_params.Add("@Empresa_ID", empresa_id);

            List<Vista_CuentaConductores> list = new List<Vista_CuentaConductores>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Vista_CuentaConductores(
                       DB.GetNullableInt32(dr["CuentaConductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_CuentaConductores> Get(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	CC.CuentaConductor_ID,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		U.NumeroEconomico Unidad,
		T.Ticket_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaConductores CC
	INNER JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	LEFT JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	INNER JOIN	Conductores CO
		ON		CC.Conductor_ID = CO.Conductor_ID
	LEFT JOIN	Unidades U
		ON		CC.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID		
WHERE	( CC.Ticket_ID = @Ticket_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            List<Vista_CuentaConductores> list = new List<Vista_CuentaConductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaConductores(
                       DB.GetNullableInt32(dr["CuentaConductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_CuentaConductores> Get(
            System.Int32 estacion_ID, System.DateTime fecha)
        {
            string sqlstr = @"SELECT	CC.CuentaConductor_ID,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		U.NumeroEconomico Unidad,
		T.Ticket_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaConductores CC
	LEFT JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	LEFT JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	INNER JOIN	Conductores CO
		ON		CC.Conductor_ID = CO.Conductor_ID
	LEFT JOIN	Unidades U
		ON		CC.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID		
WHERE	convert(date,CC.Fecha) = convert(date,@Fecha)
AND CC.Concepto_ID = 1
AND CC.Estacion_ID = @Estacion_ID
AND	CC.Usuario_ID IN ('SICAS', 'Sistema')
ORDER BY    U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_ID);
            m_params.Add("@Fecha", fecha);

            List<Vista_CuentaConductores> list = new List<Vista_CuentaConductores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CuentaConductores(
                       DB.GetNullableInt32(dr["CuentaConductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Caja"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Concepto"]),
                       DB.GetNullableDecimal(dr["Cargo"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"]),
                       Convert.ToString(dr["Comentarios"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	CC.CuentaConductor_ID,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		U.NumeroEconomico Unidad,
		T.Ticket_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaConductores CC
	INNER JOIN	Tickets T
		ON		CC.Ticket_ID = T.Ticket_ID
	INNER JOIN	Cuentas C
		ON		CC.Cuenta_ID = C.Cuenta_ID
	INNER JOIN	Empresas E
		ON		CC.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		CC.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Cajas CA
		ON		CC.Caja_ID = CA.Caja_ID
	INNER JOIN	Conductores CO
		ON		CC.Conductor_ID = CO.Conductor_ID
	INNER JOIN	Unidades U
		ON		CC.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conceptos CON
		ON		CC.Concepto_ID = CON.Concepto_ID		
WHERE	( CC.Ticket_ID = @Ticket_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_CuentaConductores

    public class SelectMonedas
    {

        #region Constructors
        public SelectMonedas()
        {
        }

        public SelectMonedas(
            System.Int32? moneda_id,
            System.String nombre
            )
        {
            this.Moneda_ID = moneda_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties
        private System.Int32? _Moneda_ID;
        public System.Int32? Moneda_ID
        {
            get { return _Moneda_ID; }
            set { _Moneda_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public static List<SelectMonedas> Get()
        {
            string sqlstr = @"SELECT	NULL	Moneda_ID,
		'- TODOS -'	Nombre
UNION
SELECT	Moneda_ID, Nombre
FROM	Monedas
";

            List<SelectMonedas> list = new List<SelectMonedas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectMonedas(
                       DB.GetNullableInt32(dr["Moneda_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	NULL	Moneda_ID,
		'- TODOS -'	Nombre
UNION
SELECT	Moneda_ID, Nombre
FROM	Monedas
";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class SelectMonedas

    public class SelectClasesServicios
    {

        #region Constructors
        public SelectClasesServicios()
        {
        }

        public SelectClasesServicios(
            System.Int32? claseservicio_id,
            System.String nombre
            )
        {
            this.ClaseServicio_ID = claseservicio_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties
        private System.Int32? _ClaseServicio_ID;
        public System.Int32? ClaseServicio_ID
        {
            get { return _ClaseServicio_ID; }
            set { _ClaseServicio_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public static List<SelectClasesServicios> Get()
        {
            string sqlstr = @"SELECT	NULL ClaseServicio_ID, '- TODOS -' Nombre
UNION
SELECT	ClaseServicio_ID, Nombre
FROM	ClasesServicios";

            List<SelectClasesServicios> list = new List<SelectClasesServicios>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectClasesServicios(
                       DB.GetNullableInt32(dr["ClaseServicio_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	NULL ClaseServicio_ID, '- TODOS -' Nombre
UNION
SELECT	ClaseServicio_ID, Nombre
FROM	ClasesServicios";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class SelectClasesServicios

    public class Vista_Servicios
    {

        #region Constructors
        public Vista_Servicios()
        {
        }

        public Vista_Servicios(
            System.String servicio_id,
            System.String empresa,
            System.String estacion,
            System.String mercado,
            System.String caja,
            System.Int32? sesion_id,
            System.String zona,
            System.String claseservicio,
            System.String tiposervicio,
            System.String tiposervicioconductor,
            System.String moneda,
            System.String estatus,
            System.Int32? unidad,
            System.String conductor,
            System.String usuario_id,
            System.String cliente,
            System.Int32? ticket_id,
            System.String tipoventa,
            System.String cuenta,
            System.Int32 foliodiario,
            System.Decimal precio,
            System.DateTime fecha,
            System.DateTime? fechaservicio,
            System.DateTime? fechaexpiracion,
            System.DateTime? fechapago,
            System.Decimal? productividad,
            System.Decimal? pagoconductor,
            System.Decimal? pagocomisiones
            )
        {
            this.Servicio_ID = servicio_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Mercado = mercado;
            this.Caja = caja;
            this.Sesion_ID = sesion_id;
            this.Zona = zona;
            this.ClaseServicio = claseservicio;
            this.TipoServicio = tiposervicio;
            this.TipoServicioConductor = tiposervicioconductor;
            this.Moneda = moneda;
            this.Estatus = estatus;
            this.Unidad = unidad;
            this.Conductor = conductor;
            this.Usuario_ID = usuario_id;
            this.Cliente = cliente;
            this.Ticket_ID = ticket_id;
            this.TipoVenta = tipoventa;
            this.Cuenta = cuenta;
            this.FolioDiario = foliodiario;
            this.Precio = precio;
            this.Fecha = fecha;
            this.FechaServicio = fechaservicio;
            this.FechaExpiracion = fechaexpiracion;
            this.FechaPago = fechapago;
            this.Productividad = productividad;
            this.PagoConductor = pagoconductor;
            this.PagoComisiones = pagocomisiones;
        }

        #endregion

        #region Properties
        private System.String _Servicio_ID;
        public System.String Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Mercado;
        public System.String Mercado
        {
            get { return _Mercado; }
            set { _Mercado = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.String _Zona;
        public System.String Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        private System.String _ClaseServicio;
        public System.String ClaseServicio
        {
            get { return _ClaseServicio; }
            set { _ClaseServicio = value; }
        }

        private System.String _TipoServicio;
        public System.String TipoServicio
        {
            get { return _TipoServicio; }
            set { _TipoServicio = value; }
        }

        private System.String _TipoServicioConductor;
        public System.String TipoServicioConductor
        {
            get { return _TipoServicioConductor; }
            set { _TipoServicioConductor = value; }
        }

        private System.String _Moneda;
        public System.String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.String _TipoVenta;
        public System.String TipoVenta
        {
            get { return _TipoVenta; }
            set { _TipoVenta = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Int32 _FolioDiario;
        public System.Int32 FolioDiario
        {
            get { return _FolioDiario; }
            set { _FolioDiario = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.DateTime? _FechaServicio;
        public System.DateTime? FechaServicio
        {
            get { return _FechaServicio; }
            set { _FechaServicio = value; }
        }

        private System.DateTime? _FechaExpiracion;
        public System.DateTime? FechaExpiracion
        {
            get { return _FechaExpiracion; }
            set { _FechaExpiracion = value; }
        }

        private System.DateTime? _FechaPago;
        public System.DateTime? FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }

        private System.Decimal? _Productividad;
        public System.Decimal? Productividad
        {
            get { return _Productividad; }
            set { _Productividad = value; }
        }

        private System.Decimal? _PagoConductor;
        public System.Decimal? PagoConductor
        {
            get { return _PagoConductor; }
            set { _PagoConductor = value; }
        }

        private System.Decimal? _PagoComisiones;
        public System.Decimal? PagoComisiones
        {
            get { return _PagoComisiones; }
            set { _PagoComisiones = value; }
        }

        #endregion

        #region Methods

        public static Vista_Servicios Get(string servicio_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	LEFT JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
WHERE   S.Servicio_ID = @Servicio_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio_id);

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];

            return new Vista_Servicios(
                Convert.ToString(dr["Servicio_ID"]),
                Convert.ToString(dr["Empresa"]),
                Convert.ToString(dr["Estacion"]),
                Convert.ToString(dr["Mercado"]),
                Convert.ToString(dr["Caja"]),
                DB.GetNullableInt32(dr["Sesion_ID"]),
                Convert.ToString(dr["Zona"]),
                Convert.ToString(dr["ClaseServicio"]),
                Convert.ToString(dr["TipoServicio"]),
                Convert.ToString(dr["TipoServicioConductor"]),
                Convert.ToString(dr["Moneda"]),
                Convert.ToString(dr["Estatus"]),
                DB.GetNullableInt32(dr["Unidad"]),
                Convert.ToString(dr["Conductor"]),
                Convert.ToString(dr["Usuario_ID"]),
                Convert.ToString(dr["Cliente"]),
                DB.GetNullableInt32(dr["Ticket_ID"]),
                Convert.ToString(dr["TipoVenta"]),
                Convert.ToString(dr["Cuenta"]),
                Convert.ToInt32(dr["FolioDiario"]),
                Convert.ToDecimal(dr["Precio"]),
                Convert.ToDateTime(dr["Fecha"]),
                DB.GetNullableDateTime(dr["FechaServicio"]),
                DB.GetNullableDateTime(dr["FechaExpiracion"]),
                DB.GetNullableDateTime(dr["FechaPago"]),
                DB.GetNullableDecimal(dr["Productividad"]),
                DB.GetNullableDecimal(dr["PagoConductor"]),
                DB.GetNullableDecimal(dr["PagoComisiones"])
            );
        } // End GetData

        public static List<Vista_Servicios> Get()
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	LEFT JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID";

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Servicios(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Zona"]),
                       Convert.ToString(dr["ClaseServicio"]),
                       Convert.ToString(dr["TipoServicio"]),
                       Convert.ToString(dr["TipoServicioConductor"]),
                       Convert.ToString(dr["Moneda"]),
                       Convert.ToString(dr["Estatus"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["TipoVenta"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       DB.GetNullableDateTime(dr["FechaServicio"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaPago"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       DB.GetNullableDecimal(dr["PagoComisiones"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	LEFT JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
";

            return DB.Query(sqlstr);
        } // End GetDataTable

        public static List<Vista_Servicios> GetVentaBySesion(
            System.Int32 sesion_id
        )
        {
            string sqlstr = @"
SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	LEFT JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
WHERE	S.Sesion_ID = @Sesion_ID
AND S.TipoServicioConductor_ID IS NULL
AND		S.EstatusServicio_ID <> 4";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Servicios(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Zona"]),
                       Convert.ToString(dr["ClaseServicio"]),
                       Convert.ToString(dr["TipoServicio"]),
                       Convert.ToString(dr["TipoServicioConductor"]),
                       Convert.ToString(dr["Moneda"]),
                       Convert.ToString(dr["Estatus"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["TipoVenta"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       DB.GetNullableDateTime(dr["FechaServicio"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaPago"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       DB.GetNullableDecimal(dr["PagoComisiones"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Servicios> GetServiciosConductorBySesion(
            System.Int32 sesion_id
        )
        {
            string sqlstr = @"
SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	INNER JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
WHERE	S.Sesion_ID = @Sesion_ID
AND S.TipoServicioConductor_ID IS NOT NULL
AND		S.EstatusServicio_ID <> 4";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Servicios(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Zona"]),
                       Convert.ToString(dr["ClaseServicio"]),
                       Convert.ToString(dr["TipoServicio"]),
                       Convert.ToString(dr["TipoServicioConductor"]),
                       Convert.ToString(dr["Moneda"]),
                       Convert.ToString(dr["Estatus"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["TipoVenta"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       DB.GetNullableDateTime(dr["FechaServicio"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaPago"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       DB.GetNullableDecimal(dr["PagoComisiones"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Servicios> GetByFecha(
          System.DateTime? fecha)
        {
            string sqlstr = @"SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
INNER JOIN	Cajas CA
	ON		S.Caja_ID = CA.Caja_ID
INNER JOIN	Empresas E
	ON		S.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
	ON		S.Estacion_ID = EST.Estacion_ID
INNER JOIN	Mercados M
	ON		S.Mercado_ID = M.Mercado_ID
INNER JOIN	Zonas Z
	ON		S.Zona_ID = Z.Zona_ID
INNER JOIN	ClasesServicios CS
	ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
LEFT JOIN	TiposServicios TS
	ON		S.TipoServicio_ID = TS.TipoServicio_ID
LEFT JOIN	TiposServiciosConductores TSC
	ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
INNER JOIN	Monedas MO
	ON		S.Moneda_ID = MO.Moneda_ID
INNER JOIN	EstatusServicios ES
	ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
INNER JOIN	Unidades U
	ON		S.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores C
	ON		S.Conductor_ID = C.Conductor_Id
LEFT JOIN	Empresas EC
	ON		S.Cliente_ID = EC.Empresa_ID
LEFT JOIN	Tickets T
	ON		S.Ticket_ID = T.Ticket_ID
LEFT JOIN	TiposVenta TV
	ON		S.TipoVenta_ID = TV.TipoVenta_ID
LEFT JOIN	Cuentas CU
	ON		S.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Sesiones SES
	ON		S.Sesion_ID = SES.Sesion_ID
WHERE	Convert(date,SES.FechaInicial) = Convert(date,@Fecha)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Servicios(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Zona"]),
                       Convert.ToString(dr["ClaseServicio"]),
                       Convert.ToString(dr["TipoServicio"]),
                       Convert.ToString(dr["TipoServicioConductor"]),
                       Convert.ToString(dr["Moneda"]),
                       Convert.ToString(dr["Estatus"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["TipoVenta"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       DB.GetNullableDateTime(dr["FechaServicio"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaPago"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       DB.GetNullableDecimal(dr["PagoComisiones"])
                       )
                    );
            }
            return list;
        }

        public static List<Vista_Servicios> Get(
            System.String nombrezona,
            System.Int32? claseservicio_id,
            System.Int32? tiposervicio_id,
            System.Int32? moneda_id,
            System.Int32? numeroeconomico,
            System.String nombreconductor,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal
        )
        {
            string sqlstr = @"
SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	INNER JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
WHERE	( @NombreZona IS NULL OR Z.Nombre LIKE @NombreZona + '%' )
	AND		( @ClaseServicio_ID IS NULL OR S.ClaseServicio_ID = @ClaseServicio_ID )
	AND		( @TipoServicio_ID IS NULL OR S.TipoServicio_ID = @TipoServicio_ID )
	AND		( @Moneda_ID IS NULL OR S.Moneda_ID = @Moneda_ID )
	AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
	AND		( @NombreConductor IS NULL OR ( C.Apellidos + ' ' + C.Nombre ) LIKE '%' + @NombreConductor + '%' )
	AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )
			OR	( S.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NombreZona", nombrezona);
            m_params.Add("@ClaseServicio_ID", claseservicio_id);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);
            m_params.Add("@Moneda_ID", moneda_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@NombreConductor", nombreconductor);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_Servicios> list = new List<Vista_Servicios>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Servicios(
                       Convert.ToString(dr["Servicio_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Mercado"]),
                       Convert.ToString(dr["Caja"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       Convert.ToString(dr["Zona"]),
                       Convert.ToString(dr["ClaseServicio"]),
                       Convert.ToString(dr["TipoServicio"]),
                       Convert.ToString(dr["TipoServicioConductor"]),
                       Convert.ToString(dr["Moneda"]),
                       Convert.ToString(dr["Estatus"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Cliente"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["TipoVenta"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       DB.GetNullableDateTime(dr["FechaServicio"]),
                       DB.GetNullableDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaPago"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       DB.GetNullableDecimal(dr["PagoComisiones"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String nombrezona,
            System.Int32? claseservicio_id,
            System.Int32? tiposervicio_id,
            System.Int32? moneda_id,
            System.Int32? numeroeconomico,
            System.String nombreconductor,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal
        )
        {
            string sqlstr = @"
SELECT	S.Servicio_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		M.Nombre Mercado,
		CA.Nombre Caja,
		S.Sesion_ID,
		Z.Nombre Zona,
		CS.Nombre ClaseServicio,
		TS.Nombre TipoServicio,
		TSC.Nombre TipoServicioConductor,
		MO.Nombre Moneda,
		ES.Nombre Estatus,
		U.NumeroEconomico Unidad,
		C.Apellidos + ' ' + C.Nombre Conductor,
		S.Usuario_ID,
		EC.Nombre Cliente,
		S.Ticket_ID,
		TV.Nombre TipoVenta,
		CU.Nombre Cuenta,
		S.FolioDiario,
		S.Precio,
		S.Fecha,
		S.FechaServicio,
		S.FechaExpiracion,
		S.FechaPago,
		S.Productividad,
		S.PagoConductor,
		S.PagoComisiones
FROM	Servicios S
	INNER JOIN	Cajas CA
		ON		S.Caja_ID = CA.Caja_ID
	INNER JOIN	Empresas E
		ON		S.Empresa_ID = E.Empresa_ID
	INNER JOIN	Estaciones EST
		ON		S.Estacion_ID = EST.Estacion_ID
	INNER JOIN	Mercados M
		ON		S.Mercado_ID = M.Mercado_ID
	INNER JOIN	Zonas Z
		ON		S.Zona_ID = Z.Zona_ID
	INNER JOIN	ClasesServicios CS
		ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
	LEFT JOIN	TiposServicios TS
		ON		S.TipoServicio_ID = TS.TipoServicio_ID
	LEFT JOIN	TiposServiciosConductores TSC
		ON		S.TipoServicioConductor_ID = TSC.TipoServicioConductor_ID
	INNER JOIN	Monedas MO
		ON		S.Moneda_ID = MO.Moneda_ID
	INNER JOIN	EstatusServicios ES
		ON		S.EstatusServicio_ID = ES.EstatusServicio_ID
	INNER JOIN	Unidades U
		ON		S.Unidad_ID = U.Unidad_ID
	INNER JOIN	Conductores C
		ON		S.Conductor_ID = C.Conductor_Id
	LEFT JOIN	Empresas EC
		ON		S.Cliente_ID = EC.Empresa_ID
	LEFT JOIN	Tickets T
		ON		S.Ticket_ID = T.Ticket_ID
	LEFT JOIN	TiposVenta TV
		ON		S.TipoVenta_ID = TV.TipoVenta_ID
	LEFT JOIN	Cuentas CU
		ON		S.Cuenta_ID = CU.Cuenta_ID
WHERE	( @NombreZona IS NULL OR Z.Nombre LIKE @NombreZona + '%' )
	AND		( @ClaseServicio_ID IS NULL OR S.ClaseServicio_ID = @ClaseServicio_ID )
	AND		( @TipoServicio_ID IS NULL OR S.TipoServicio_ID = @TipoServicio_ID )
	AND		( @Moneda_ID IS NULL OR S.Moneda_ID = @Moneda_ID )
	AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
	AND		( @NombreConductor IS NULL OR ( C.Apellidos + ' ' + C.Nombre ) LIKE @'%' + @NombreConductor + '%' )
	AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )
			OR	( S.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NombreZona", nombrezona);
            m_params.Add("@ClaseServicio_ID", claseservicio_id);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);
            m_params.Add("@Moneda_ID", moneda_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@NombreConductor", nombreconductor);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable
        #endregion
    } // End Class Vista_Servicios


    public class Vista_ValesPrepagados
    {

        #region Constructors
        public Vista_ValesPrepagados()
        {
        }

        public Vista_ValesPrepagados(
            System.String codigo,
            System.Int32 foliodiario,
            System.String razonsocial,
            System.Decimal denominacion,
            System.String cantidadconletra,
            System.DateTime fechaemision,
            System.DateTime fechaexpiracion,
            System.DateTime? fechacanje,
            System.Int32? ticket_id,
            System.String usuario_id,
            System.String estatus,
            System.Int32 empresa_id
            )
        {
            this.Codigo = codigo;
            this.FolioDiario = foliodiario;
            this.RazonSocial = razonsocial;
            this.Denominacion = denominacion;
            this.CantidadConLetra = cantidadconletra;
            this.FechaEmision = fechaemision;
            this.FechaExpiracion = fechaexpiracion;
            this.FechaCanje = fechacanje;
            this.Ticket_ID = ticket_id;
            this.Usuario_ID = usuario_id;
            this.Estatus = estatus;
            this.Empresa_ID = empresa_id;
        }

        #endregion

        #region Properties
        private System.String _Codigo;
        public System.String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private System.Int32 _FolioDiario;
        public System.Int32 FolioDiario
        {
            get { return _FolioDiario; }
            set { _FolioDiario = value; }
        }

        private System.String _RazonSocial;
        public System.String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private System.Decimal _Denominacion;
        public System.Decimal Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        private System.String _CantidadConLetra;
        public System.String CantidadConLetra
        {
            get { return _CantidadConLetra; }
            set { _CantidadConLetra = value; }
        }

        private System.DateTime _FechaEmision;
        public System.DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }

        private System.DateTime _FechaExpiracion;
        public System.DateTime FechaExpiracion
        {
            get { return _FechaExpiracion; }
            set { _FechaExpiracion = value; }
        }

        private System.DateTime? _FechaCanje;
        public System.DateTime? FechaCanje
        {
            get { return _FechaCanje; }
            set { _FechaCanje = value; }
        }

        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        #endregion

        #region Methods

        public static Vista_ValesPrepagados Get(
            System.String valeprepagado_id)
        {
            string sqlstr = @"
SELECT	VP.ValePrepagado_ID Codigo,
		VP.FolioDiario,
		E.RazonSocial,
		VP.Denominacion,
		'' CantidadConLetra,
		VP.FechaEmision,
		VP.FechaExpiracion,
		VP.FechaCanje,
		VP.Ticket_ID,
		VP.Usuario_ID,
		EVP.[Nombre] as [Estatus],
		VP.Empresa_ID
FROM	ValesPrepagados VP
	INNER JOIN	Empresas E
		ON		VP.EmpresaCliente_ID = E.Empresa_ID	
	INNER JOIN	EstatusValesPrepagados EVP
		ON		VP.EstatusValePrepagado_ID = EVP.EstatusValePrepagado_ID
WHERE	( @ValePrepagado_ID IS NULL OR VP.ValePrepagado_ID = @ValePrepagado_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ValePrepagado_ID", valeprepagado_id);

            List<Vista_ValesPrepagados> list = new List<Vista_ValesPrepagados>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];

            return new Vista_ValesPrepagados(
                      Convert.ToString(dr["Codigo"]),
                      Convert.ToInt32(dr["FolioDiario"]),
                      Convert.ToString(dr["RazonSocial"]),
                      Convert.ToDecimal(dr["Denominacion"]),
                      Convert.ToString(dr["CantidadConLetra"]),
                      Convert.ToDateTime(dr["FechaEmision"]),
                      Convert.ToDateTime(dr["FechaExpiracion"]),
                      DB.GetNullableDateTime(dr["FechaCanje"]),
                      DB.GetNullableInt32(dr["Ticket_ID"]),
                      Convert.ToString(dr["Usuario_ID"]),
                      Convert.ToString(dr["Estatus"]),
                      Convert.ToInt32(dr["Empresa_ID"])
                   );
        } // End GetData

        public static List<Vista_ValesPrepagados> Get(
            System.String valeprepagado_id,
            System.Int32? empresacliente_id,
            System.Int32? estatusvaleprepagado_id,
            System.Decimal? denominacion,
            System.DateTime? fechaemisioninicial,
            System.DateTime? fechaemisionfinal,
            System.DateTime? fechaexpiracioninicial,
            System.DateTime? fechaexpiracionfinal,
            System.DateTime? fechacanjeinicial,
            System.DateTime? fechacanjefinal,
            System.Int32? ticket_id,
            System.String usuario_id,
            System.Int32? empresaEmite_id)
        {
            string sqlstr = @"
SELECT	VP.ValePrepagado_ID Codigo,
		VP.FolioDiario,
		E.RazonSocial,
		VP.Denominacion,
		'' CantidadConLetra,
		VP.FechaEmision,
		VP.FechaExpiracion,
		VP.FechaCanje,
		VP.Ticket_ID,
		VP.Usuario_ID,
		EVP.[Nombre Estatus],
		VP.Empresa_ID
FROM	ValesPrepagados VP
	INNER JOIN	Empresas E
		ON		VP.EmpresaCliente_ID = E.Empresa_ID	
	INNER JOIN	EstatusValesPrepagados EVP
		ON		VP.EstatusValePrepagado_ID = EVP.EstatusValePrepagado_ID
WHERE	( @ValePrepagado_ID IS NULL OR VP.ValePrepagado_ID LIKE @ValePrepagado_ID + '%' )
	AND		( @EmpresaCliente_ID IS NULL OR VP.EmpresaCliente_ID = @EmpresaCliente_ID )
	AND		( @EstatusValePrepagado_ID IS NULL OR VP.EstatusValePrepagado_ID = @EstatusValePrepagado_ID )
	AND		( @Denominacion IS NULL OR VP.Denominacion = @Denominacion )
	AND		( ( @FechaEmisionInicial IS NULL OR @FechaEmisionFinal IS NULL ) OR
				( VP.FechaEmision BETWEEN @FechaEmisionInicial AND @FechaEmisionFinal ) )
	AND		( ( @FechaExpiracionInicial IS NULL OR @FechaExpiracionFinal IS NULL ) OR
				( VP.FechaExpiracion BETWEEN @FechaExpiracionInicial AND @FechaExpiracionFinal ) )
	AND		( ( @FechaCanjeInicial IS NULL OR @FechaCanjeFinal IS NULL ) OR
				( VP.FechaCanje BETWEEN @FechaCanjeInicial AND @FechaCanjeFinal ) )
	AND		( @Ticket_ID IS NULL OR VP.Ticket_ID = @Ticket_ID )
	AND		( @EmpresaEmite_ID IS NULL OR VP.Empresa_ID = @EmpresaEmite_ID )
	AND		( @Usuario_ID IS NULL OR VP.Usuario_ID LIKE @Usuario_ID + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ValePrepagado_ID", valeprepagado_id);
            m_params.Add("@EmpresaCliente_ID", empresacliente_id);
            m_params.Add("@EstatusValePrepagado_ID", estatusvaleprepagado_id);
            m_params.Add("@Denominacion", denominacion);
            m_params.Add("@FechaEmisionInicial", fechaemisioninicial);
            m_params.Add("@FechaEmisionFinal", fechaemisionfinal);
            m_params.Add("@FechaExpiracionInicial", fechaexpiracioninicial);
            m_params.Add("@FechaExpiracionFinal", fechaexpiracionfinal);
            m_params.Add("@FechaCanjeInicial", fechacanjeinicial);
            m_params.Add("@FechaCanjeFinal", fechacanjefinal);
            m_params.Add("@Ticket_ID", ticket_id);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@EmpresaEmite_ID", empresaEmite_id);


            List<Vista_ValesPrepagados> list = new List<Vista_ValesPrepagados>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ValesPrepagados(
                       Convert.ToString(dr["Codigo"]),
                       Convert.ToInt32(dr["FolioDiario"]),
                       Convert.ToString(dr["RazonSocial"]),
                       Convert.ToDecimal(dr["Denominacion"]),
                       Convert.ToString(dr["CantidadConLetra"]),
                       Convert.ToDateTime(dr["FechaEmision"]),
                       Convert.ToDateTime(dr["FechaExpiracion"]),
                       DB.GetNullableDateTime(dr["FechaCanje"]),
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       Convert.ToString(dr["Estatus"]),
                       Convert.ToInt32(dr["Empresa_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.String valeprepagado_id,
            System.Int32? empresacliente_id,
            System.Int32? estatusvaleprepagado_id,
            System.Decimal? denominacion,
            System.DateTime? fechaemisioninicial,
            System.DateTime? fechaemisionfinal,
            System.DateTime? fechaexpiracioninicial,
            System.DateTime? fechaexpiracionfinal,
            System.DateTime? fechacanjeinicial,
            System.DateTime? fechacanjefinal,
            System.Int32? ticket_id,
            System.String usuario_id,
            System.Int32? empresaEmite_id)
        {
            string sqlstr = @"
SELECT	VP.ValePrepagado_ID Codigo,
		VP.FolioDiario,
		E.RazonSocial,
		VP.Denominacion,
		'' CantidadConLetra,
		VP.FechaEmision,
		VP.FechaExpiracion,
		VP.FechaCanje,
		VP.Ticket_ID,
		VP.Usuario_ID,
		EVP.[Nombre Estatus],
		VP.Empresa_ID
FROM	ValesPrepagados VP
	INNER JOIN	Empresas E
		ON		VP.EmpresaCliente_ID = E.Empresa_ID	
	INNER JOIN	EstatusValesPrepagados EVP
		ON		VP.EstatusValePrepagado_ID = EVP.EstatusValePrepagado_ID
WHERE	( @ValePrepagado_ID IS NULL OR VP.ValePrepagado_ID LIKE @ValePrepagado_ID + '%' )
	AND		( @EmpresaCliente_ID IS NULL OR VP.EmpresaCliente_ID = @EmpresaCliente_ID )
	AND		( @EstatusValePrepagado_ID IS NULL OR VP.EstatusValePrepagado_ID = @EstatusValePrepagado_ID )
	AND		( @Denominacion IS NULL OR VP.Denominacion = @Denominacion )
	AND		( ( @FechaEmisionInicial IS NULL OR @FechaEmisionFinal IS NULL ) OR
				( VP.FechaEmision BETWEEN @FechaEmisionInicial AND @FechaEmisionFinal ) )
	AND		( ( @FechaExpiracionInicial IS NULL OR @FechaExpiracionFinal IS NULL ) OR
				( VP.FechaExpiracion BETWEEN @FechaExpiracionInicial AND @FechaExpiracionFinal ) )
	AND		( ( @FechaCanjeInicial IS NULL OR @FechaCanjeFinal IS NULL ) OR
				( VP.FechaCanje BETWEEN @FechaCanjeInicial AND @FechaCanjeFinal ) )
	AND		( @Ticket_ID IS NULL OR VP.Ticket_ID = @Ticket_ID )
	AND		( @EmpresaEmite_ID IS NULL OR VP.Empresa_ID = @EmpresaEmite_ID )
	AND		( @Usuario_ID IS NULL OR VP.Usuario_ID LIKE @Usuario_ID + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ValePrepagado_ID", valeprepagado_id);
            m_params.Add("@EmpresaCliente_ID", empresacliente_id);
            m_params.Add("@EstatusValePrepagado_ID", estatusvaleprepagado_id);
            m_params.Add("@Denominacion", denominacion);
            m_params.Add("@FechaEmisionInicial", fechaemisioninicial);
            m_params.Add("@FechaEmisionFinal", fechaemisionfinal);
            m_params.Add("@FechaExpiracionInicial", fechaexpiracioninicial);
            m_params.Add("@FechaExpiracionFinal", fechaexpiracionfinal);
            m_params.Add("@FechaCanjeInicial", fechacanjeinicial);
            m_params.Add("@FechaCanjeFinal", fechacanjefinal);
            m_params.Add("@Ticket_ID", ticket_id);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@EmpresaEmite_ID", empresaEmite_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ValesPrepagados

    public class SelectTiposMovimientosInventario
    {

        #region Constructors
        public SelectTiposMovimientosInventario()
        {
        }

        public SelectTiposMovimientosInventario(
            System.Int32? tipomovimientoinventario_id,
            System.String nombre
            )
        {
            this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties
        private System.Int32? _TipoMovimientoInventario_ID;
        public System.Int32? TipoMovimientoInventario_ID
        {
            get { return _TipoMovimientoInventario_ID; }
            set { _TipoMovimientoInventario_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public static List<SelectTiposMovimientosInventario> Get()
        {
            string sqlstr = @"SELECT	NULL TipoMovimientoInventario_ID, '- TODOS -' Nombre
UNION
SELECT	TipoMovimientoInventario_ID, Nombre
FROM	TiposMovimientosInventario";

            List<SelectTiposMovimientosInventario> list = new List<SelectTiposMovimientosInventario>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectTiposMovimientosInventario(
                       DB.GetNullableInt32(dr["TipoMovimientoInventario_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"SELECT	NULL TipoMovimientoInventario_ID, '- TODOS -' Nombre
UNION
SELECT	TipoMovimientoInventario_ID, Nombre
FROM	TiposMovimientosInventario";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class SelectTiposMovimientosInventario

    public class Vista_RefaccionesDevolucionesOrdenesCompras
    {

        public Vista_RefaccionesDevolucionesOrdenesCompras()
        {
        }

        public Vista_RefaccionesDevolucionesOrdenesCompras(System.Int32 ordencompra_id, System.Int32 refaccion_id, System.String descripcion, System.Decimal costounitario, System.Int32 pordevolver, System.Int32 salida)
        {
            this.OrdenCompra_ID = ordencompra_id;
            this.Refaccion_ID = refaccion_id;
            this.Descripcion = descripcion;
            this.CostoUnitario = costounitario;
            this.PorDevolver = pordevolver;
            this.Salida = salida;
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.Int32 _Refaccion_ID;
        public System.Int32 Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Decimal _CostoUnitario;
        public System.Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Int32 _PorDevolver;
        public System.Int32 PorDevolver
        {
            get { return _PorDevolver; }
            set { _PorDevolver = value; }
        }

        private System.Int32 _Salida;
        public System.Int32 Salida
        {
            get { return _Salida; }
            set { _Salida = value; }
        }


        public static List<Vista_RefaccionesDevolucionesOrdenesCompras> Get(System.Int32 ordencompra_id)
        {
            string sqlstr = "SELECT	OCC.OrdenCompra_ID, C.Refaccion_ID,  \r\n" +
            "		R.Descripcion, C.CostoUnitario, \r\n" +
            "		C.RefaccionesSurtidas PorDevolver, 0 Salida \r\n" +
            "FROM	OrdenesComprasCanceladas OCC \r\n" +
            "INNER JOIN	OrdenesCompras OC \r\n" +
            "ON		OCC.OrdenCompra_ID = OC.OrdenCompra_ID \r\n" +
            "INNER JOIN	Compras C \r\n" +
            "ON		OC.OrdenCompra_ID = C.OrdenCompra_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		C.Refaccion_ID = R.Refaccion_ID \r\n" +
            "WHERE	OCC.OrdenCompra_ID = @OrdenCompra_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);

            List<Vista_RefaccionesDevolucionesOrdenesCompras> list = new List<Vista_RefaccionesDevolucionesOrdenesCompras>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_RefaccionesDevolucionesOrdenesCompras(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["CostoUnitario"]), Convert.ToInt32(dr["PorDevolver"]), Convert.ToInt32(dr["Salida"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ordencompra_id)
        {
            string sqlstr = "SELECT	OCC.OrdenCompra_ID, C.Refaccion_ID,  \r\n" +
            "		R.Descripcion, C.CostoUnitario, \r\n" +
            "		C.RefaccionesSurtidas PorDevolver, 0 Salida \r\n" +
            "FROM	OrdenesComprasCanceladas OCC \r\n" +
            "INNER JOIN	OrdenesCompras OC \r\n" +
            "ON		OCC.OrdenCompra_ID = OC.OrdenCompra_ID \r\n" +
            "INNER JOIN	Compras C \r\n" +
            "ON		OC.OrdenCompra_ID = C.OrdenCompra_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		C.Refaccion_ID = R.Refaccion_ID \r\n" +
            "WHERE	OCC.OrdenCompra_ID = @OrdenCompra_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_RefaccionesDevolucionesOrdenesCompras

    public class Vista_RefaccionesDevolucionesOrdenesTrabajo
    {

        public Vista_RefaccionesDevolucionesOrdenesTrabajo()
        {
        }

        public Vista_RefaccionesDevolucionesOrdenesTrabajo(System.Int32 ordentrabajo_id, System.Int32 refaccion_id, System.String descripcion, System.Decimal costounitario, System.Int32 pordevolver, System.Int32 entrada)
        {
            this.OrdenTrabajo_ID = ordentrabajo_id;
            this.Refaccion_ID = refaccion_id;
            this.Descripcion = descripcion;
            this.CostoUnitario = costounitario;
            this.PorDevolver = pordevolver;
            this.Entrada = entrada;
        }

        private System.Int32 _OrdenTrabajo_ID;
        public System.Int32 OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private System.Int32 _Refaccion_ID;
        public System.Int32 Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Decimal _CostoUnitario;
        public System.Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Int32 _PorDevolver;
        public System.Int32 PorDevolver
        {
            get { return _PorDevolver; }
            set { _PorDevolver = value; }
        }

        private System.Int32 _Entrada;
        public System.Int32 Entrada
        {
            get { return _Entrada; }
            set { _Entrada = value; }
        }


        public static List<Vista_RefaccionesDevolucionesOrdenesTrabajo> Get(System.Int32 ordentrabajo_id)
        {
            string sqlstr = "SELECT	C.OrdenTrabajo_ID, OSR.Refaccion_ID, R.Descripcion, \r\n" +
            "		OSR.CostoUnitario, OSR.RefSurtidas PorDevolver, 0 Entrada \r\n" +
            "FROM	CancelacionesOrdenesTrabajos C \r\n" +
            "INNER JOIN	OrdenesTrabajos OT \r\n" +
            "ON		C.OrdenTrabajo_ID = OT.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	OrdenesServicios OS \r\n" +
            "ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	OrdenesServiciosRefacciones OSR \r\n" +
            "ON		OS.OrdenServicio_ID = OSR.OrdenServicio_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		OSR.Refaccion_ID = R.Refaccion_ID \r\n" +
            "WHERE	C.OrdenTrabajo_ID = @OrdenTrabajo_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);

            List<Vista_RefaccionesDevolucionesOrdenesTrabajo> list = new List<Vista_RefaccionesDevolucionesOrdenesTrabajo>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_RefaccionesDevolucionesOrdenesTrabajo(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["CostoUnitario"]), Convert.ToInt32(dr["PorDevolver"]), Convert.ToInt32(dr["Entrada"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ordentrabajo_id)
        {
            string sqlstr = "SELECT	C.OrdenTrabajo_ID, OSR.Refaccion_ID, R.Descripcion, \r\n" +
            "		OSR.CostoUnitario, OSR.RefSurtidas PorDevolver, 0 Entrada \r\n" +
            "FROM	CancelacionesOrdenesTrabajos C \r\n" +
            "INNER JOIN	OrdenesTrabajos OT \r\n" +
            "ON		C.OrdenTrabajo_ID = OT.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	OrdenesServicios OS \r\n" +
            "ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	OrdenesServiciosRefacciones OSR \r\n" +
            "ON		OS.OrdenServicio_ID = OSR.OrdenServicio_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		OSR.Refaccion_ID = R.Refaccion_ID \r\n" +
            "WHERE	C.OrdenTrabajo_ID = @OrdenTrabajo_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_RefaccionesDevolucionesOrdenesTrabajo

    public class Vista_MovimientosInventario
    {

        public Vista_MovimientosInventario()
        {
        }

        public Vista_MovimientosInventario(
            System.Int32 id,
            System.String tipo,
            System.Int32? ordencompra,
            System.Int32? ordentrabajo,
            System.Int32? ajuste,
            System.Int32? notaalmacen,
            System.String refaccion,
            System.Int32 cantidadprev,
            System.Int32 cantidad,
            System.Int32 cantidadpost,
            System.DateTime fecha,
            System.String usuario_id)
        {
            this.ID = id;
            this.Tipo = tipo;
            this.OrdenCompra = ordencompra;
            this.OrdenTrabajo = ordentrabajo;
            this.Ajuste = ajuste;
            this.NotaAlmacen = notaalmacen;
            this.Refaccion = refaccion;
            this.CantidadPrev = cantidadprev;
            this.Cantidad = cantidad;
            this.CantidadPost = cantidadpost;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        private System.Int32 _ID;
        public System.Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.Int32? _OrdenCompra;
        public System.Int32? OrdenCompra
        {
            get { return _OrdenCompra; }
            set { _OrdenCompra = value; }
        }

        private System.Int32? _OrdenTrabajo;
        public System.Int32? OrdenTrabajo
        {
            get { return _OrdenTrabajo; }
            set { _OrdenTrabajo = value; }
        }

        private System.Int32? _Ajuste;
        public System.Int32? Ajuste
        {
            get { return _Ajuste; }
            set { _Ajuste = value; }
        }

        private System.Int32? _NotaAlmacen;
        public System.Int32? NotaAlmacen
        {
            get { return _NotaAlmacen; }
            set { _NotaAlmacen = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Int32 _CantidadPrev;
        public System.Int32 CantidadPrev
        {
            get { return _CantidadPrev; }
            set { _CantidadPrev = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Int32 _CantidadPost;
        public System.Int32 CantidadPost
        {
            get { return _CantidadPost; }
            set { _CantidadPost = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }


        public static List<Vista_MovimientosInventario> Get(
            System.Int32? tipomovimientoinventario_id,
            System.String descripcion,
            System.Int32? ordencompra_id,
            System.Int32? ordentrabajo_id,
            System.Int32? ajusteinventario_id,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	MI.MovimientoInventario_ID [ID],
		TMI.Nombre Tipo,
		MI.OrdenCompra_ID OrdenCompra,
		MI.OrdenTrabajo_ID OrdenTrabajo,
		MI.AjusteInventario_ID Ajuste,
		MI.NotaAlmacen_ID NotaAlmacen,
		R.Descripcion Refaccion,
		MI.CantidadPrev,
		MI.Cantidad,		
		MI.CantidadPost,
		MI.Fecha,
		MI.Usuario_ID		
FROM	MovimientosInventario MI
INNER JOIN	TiposMovimientosInventario TMI
ON		MI.TipoMovimientoInventario_ID = TMI.TipoMovimientoInventario_ID
INNER JOIN	Refacciones R
ON		MI.Refaccion_ID = R.Refaccion_ID
WHERE	( @TipoMovimientoInventario_ID IS NULL 
			OR MI.TipoMovimientoInventario_ID = @TipoMovimientoInventario_ID )
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @OrdenCompra_ID IS NULL OR MI.OrdenCompra_ID = @OrdenCompra_ID )
AND		( @OrdenTrabajo_ID IS NULL OR MI.OrdenTrabajo_ID = @OrdenTrabajo_ID )
AND		( @AjusteInventario_ID IS NULL OR MI.AjusteInventario_ID = @AjusteInventario_ID )
AND		(	( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR
			( MI.Fecha BETWEEN @FechaInicial AND @FechaFinal )	)
AND		( MI.Empresa_ID = @Empresa_ID )
AND		( MI.Estacion_ID = @Estacion_ID )
ORDER BY R.Descripcion,  MI.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoMovimientoInventario_ID", tipomovimientoinventario_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@AjusteInventario_ID", ajusteinventario_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_MovimientosInventario> list = new List<Vista_MovimientosInventario>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_MovimientosInventario(
                       Convert.ToInt32(dr["ID"]),
                       Convert.ToString(dr["Tipo"]),
                       DB.GetNullableInt32(dr["OrdenCompra"]),
                       DB.GetNullableInt32(dr["OrdenTrabajo"]),
                       DB.GetNullableInt32(dr["Ajuste"]),
                       DB.GetNullableInt32(dr["NotaAlmacen"]),
                       Convert.ToString(dr["Refaccion"]),
                       Convert.ToInt32(dr["CantidadPrev"]),
                       Convert.ToInt32(dr["Cantidad"]),
                       Convert.ToInt32(dr["CantidadPost"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? tipomovimientoinventario_id,
            System.String descripcion,
            System.Int32? ordencompra_id,
            System.Int32? ordentrabajo_id,
            System.Int32? ajusteinventario_id,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	MI.MovimientoInventario_ID [ID],
		TMI.Nombre Tipo,
		MI.OrdenCompra_ID OrdenCompra,
		MI.OrdenTrabajo_ID OrdenTrabajo,
		MI.AjusteInventario_ID Ajuste,
		MI.NotaAlmacen_ID NotaAlmacen,
		R.Descripcion Refaccion,
		MI.CantidadPrev,
		MI.Cantidad,		
		MI.CantidadPost,
		MI.Fecha,
		MI.Usuario_ID		
FROM	MovimientosInventario MI
INNER JOIN	TiposMovimientosInventario TMI
ON		MI.TipoMovimientoInventario_ID = TMI.TipoMovimientoInventario_ID
INNER JOIN	Refacciones R
ON		MI.Refaccion_ID = R.Refaccion_ID
WHERE	( @TipoMovimientoInventario_ID IS NULL 
			OR MI.TipoMovimientoInventario_ID = @TipoMovimientoInventario_ID )
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @OrdenCompra_ID IS NULL OR MI.OrdenCompra_ID = @OrdenCompra_ID )
AND		( @OrdenTrabajo_ID IS NULL OR MI.OrdenTrabajo_ID = @OrdenTrabajo_ID )
AND		( @AjusteInventario_ID IS NULL OR MI.AjusteInventario_ID = @AjusteInventario_ID )
AND		(	( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR
			( MI.Fecha BETWEEN @FechaInicial AND @FechaFinal )	)
AND		( MI.Empresa_ID = @Empresa_ID )
AND		( MI.Estacion_ID = @Estacion_ID )
ORDER BY R.Descripcion,  MI.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoMovimientoInventario_ID", tipomovimientoinventario_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@AjusteInventario_ID", ajusteinventario_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_MovimientosInventario

    public class Vista_AjustesInventario
    {

        #region Constructors
        public Vista_AjustesInventario()
        {
        }

        public Vista_AjustesInventario(
            System.Int32? id,
            System.String tipo,
            System.String refaccion,
            System.Int32? cantidad,
            System.DateTime? fecha,
            System.String comentarios,
            System.String usuario_id
            )
        {
            this.ID = id;
            this.Tipo = tipo;
            this.Refaccion = refaccion;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
            this.Comentarios = comentarios;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties
        private System.Int32? _ID;
        public System.Int32? ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Int32? _Cantidad;
        public System.Int32? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_AjustesInventario> Get(
            System.Int32? tipoajusteinventario_id,
            System.String descripcion,
            System.Int32 empresa_id,
            System.Int32 estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	AI.AjusteInventario_ID [ID],
		TAI.Nombre Tipo,
		R.Descripcion Refaccion,
		AI.Cantidad,
		AI.Fecha,
		AI.Comentarios,
		AI.Usuario_ID
FROM	AjustesInventario AI
INNER JOIN	TiposAjustesInventario TAI
ON		AI.TipoAjusteInventario_ID = TAI.TipoAjusteInventario_ID
INNER JOIN	Refacciones R
ON		AI.Refaccion_ID = R.Refaccion_ID
WHERE	( @TipoAjusteInventario_ID IS NULL OR TAI.TipoAjusteInventario_ID = @TipoAjusteInventario_ID )
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		AI.Empresa_ID = @Empresa_ID
AND		AI.Estacion_ID = @Estacion_ID
AND		AI.Fecha BETWEEN @FechaInicial AND @FechaFinal
ORDER BY	AI.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoAjusteInventario_ID", tipoajusteinventario_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_AjustesInventario> list = new List<Vista_AjustesInventario>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_AjustesInventario(
                       DB.GetNullableInt32(dr["ID"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Refaccion"]),
                       DB.GetNullableInt32(dr["Cantidad"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Comentarios"]),
                       Convert.ToString(dr["Usuario_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? tipoajusteinventario_id,
            System.String descripcion,
            System.Int32 empresa_id,
            System.Int32 estacion_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = @"SELECT	AI.AjusteInventario_ID [ID],
		TAI.Nombre Tipo,
		R.Descripcion Refaccion,
		AI.Cantidad,
		AI.Fecha,
		AI.Comentarios,
		AI.Usuario_ID
FROM	AjustesInventario AI
INNER JOIN	TiposAjustesInventario TAI
ON		AI.TipoAjusteInventario_ID = TAI.TipoAjusteInventario_ID
INNER JOIN	Refacciones R
ON		AI.Refaccion_ID = R.Refaccion_ID
WHERE	( @TipoAjusteInventario_ID IS NULL OR TAI.TipoAjusteInventario_ID = @TipoAjusteInventario_ID )
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		AI.Empresa_ID = @Empresa_ID
AND		AI.Estacion_ID = @Estacion_ID
AND		AI.Fecha BETWEEN @FechaInicial AND @FechaFinal
ORDER BY	AI.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoAjusteInventario_ID", tipoajusteinventario_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_AjustesInventario



    public class Vista_NotaAlmacenCompras
    {

        public Vista_NotaAlmacenCompras()
        {
        }

        public Vista_NotaAlmacenCompras(System.Int32 notaalmacen_id, System.DateTime fecha, System.String proveedor, System.String descripcion, System.Int32 ordencompra_id, System.Int32 cantidad, System.Int32 stock)
        {
            this.NotaAlmacen_ID = notaalmacen_id;
            this.Fecha = fecha;
            this.Proveedor = proveedor;
            this.Descripcion = descripcion;
            this.OrdenCompra_ID = ordencompra_id;
            this.Cantidad = cantidad;
            this.Stock = stock;
        }

        private System.Int32 _NotaAlmacen_ID;
        public System.Int32 NotaAlmacen_ID
        {
            get { return _NotaAlmacen_ID; }
            set { _NotaAlmacen_ID = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Proveedor;
        public System.String Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Int32 _Stock;
        public System.Int32 Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }


        public static List<Vista_NotaAlmacenCompras> Get(System.Int32 notaalmacen_id)
        {
            string sqlstr = "SELECT	NA.NotaAlmacen_ID, \r\n" +
            "		NA.Fecha, \r\n" +
            "		E.RazonSocial Proveedor, \r\n" +
            "		R.Descripcion, \r\n" +
            "		MI.OrdenCompra_ID, \r\n" +
            "		MI.Cantidad,		 \r\n" +
            "		MI.CantidadPost Stock \r\n" +
            "FROM	NotasAlmacen NA \r\n" +
            "INNER JOIN	MovimientosInventario MI \r\n" +
            "ON		NA.NotaAlmacen_ID = MI.NotaAlmacen_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		MI.Refaccion_ID = R.Refaccion_ID \r\n" +
            "INNER JOIN	OrdenesCompras OC \r\n" +
            "ON		MI.OrdenCompra_ID = OC.OrdenCompra_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OC.Proveedor_ID = E.Empresa_ID \r\n" +
            "WHERE	NA.NotaAlmacen_ID = @NotaAlmacen_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NotaAlmacen_ID", notaalmacen_id);

            List<Vista_NotaAlmacenCompras> list = new List<Vista_NotaAlmacenCompras>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_NotaAlmacenCompras(Convert.ToInt32(dr["NotaAlmacen_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Proveedor"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToInt32(dr["Stock"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 notaalmacen_id)
        {
            string sqlstr = "SELECT	NA.NotaAlmacen_ID, \r\n" +
            "		NA.Fecha, \r\n" +
            "		E.RazonSocial Proveedor, \r\n" +
            "		R.Descripcion, \r\n" +
            "		MI.OrdenCompra_ID, \r\n" +
            "		MI.Cantidad,		 \r\n" +
            "		MI.CantidadPost Stock \r\n" +
            "FROM	NotasAlmacen NA \r\n" +
            "INNER JOIN	MovimientosInventario MI \r\n" +
            "ON		NA.NotaAlmacen_ID = MI.NotaAlmacen_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		MI.Refaccion_ID = R.Refaccion_ID \r\n" +
            "INNER JOIN	OrdenesCompras OC \r\n" +
            "ON		MI.OrdenCompra_ID = OC.OrdenCompra_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OC.Proveedor_ID = E.Empresa_ID \r\n" +
            "WHERE	NA.NotaAlmacen_ID = @NotaAlmacen_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NotaAlmacen_ID", notaalmacen_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_NotaAlmacenCompras

    public class SelectMercados
    {

        public SelectMercados()
        {
        }

        public SelectMercados(System.Int32? mercado_id, System.String nombre)
        {
            this.Mercado_ID = mercado_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Mercado_ID;
        public System.Int32? Mercado_ID
        {
            get { return _Mercado_ID; }
            set { _Mercado_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectMercados> Get()
        {
            string sqlstr = "SELECT NULL Mercado_ID, '- TODOS -' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	Mercado_ID, Nombre \r\n" +
            "FROM	Mercados";

            List<SelectMercados> list = new List<SelectMercados>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectMercados(
                       DB.GetNullableInt32(dr["Mercado_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT NULL Mercado_ID, '- TODOS -' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	Mercado_ID, Nombre \r\n" +
            "FROM	Mercados";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectMercados

    public class SelectTiposEmpresas
    {

        public SelectTiposEmpresas()
        {
        }

        public SelectTiposEmpresas(System.Int32? tipoempresa_id, System.String nombre)
        {
            this.TipoEmpresa_ID = tipoempresa_id;
            this.Nombre = nombre;
        }

        private System.Int32? _TipoEmpresa_ID;
        public System.Int32? TipoEmpresa_ID
        {
            get { return _TipoEmpresa_ID; }
            set { _TipoEmpresa_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposEmpresas> Get()
        {
            string sqlstr = "SELECT NULL TipoEmpresa_ID, '- TODOS -' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	TipoEmpresa_ID, Nombre \r\n" +
            "FROM	TiposEmpresas";

            List<SelectTiposEmpresas> list = new List<SelectTiposEmpresas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new SelectTiposEmpresas(
                       DB.GetNullableInt32(dr["TipoEmpresa_ID"]),
                       Convert.ToString(dr["Nombre"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT NULL TipoEmpresa_ID, '- TODOS -' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	TipoEmpresa_ID, Nombre \r\n" +
            "FROM	TiposEmpresas";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectTiposEmpresas


    public class Vista_PreciosServiciosTiposEmpresas
    {

        public Vista_PreciosServiciosTiposEmpresas()
        {
        }

        public Vista_PreciosServiciosTiposEmpresas(System.String servicio, System.String tipocliente, System.Decimal precio)
        {
            this.Servicio = servicio;
            this.TipoCliente = tipocliente;
            this.Precio = precio;
        }

        private System.String _Servicio;
        public System.String Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }

        private System.String _TipoCliente;
        public System.String TipoCliente
        {
            get { return _TipoCliente; }
            set { _TipoCliente = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }


        public static List<Vista_PreciosServiciosTiposEmpresas> Get(System.Object tipoempresa_id)
        {
            string sqlstr = "SELECT	UPPER(SM.Nombre) Servicio, UPPER(TE.Nombre) TipoCliente, SMP.Precio \r\n" +
            "FROM	ServiciosMantenimientosPrecios SMP \r\n" +
            "INNER JOIN	ServiciosMantenimientos SM \r\n" +
            "ON		SMP.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID \r\n" +
            "INNER JOIN	TiposEmpresas TE \r\n" +
            "ON		TE.TipoEmpresa_ID = SMP.TipoEmpresa_ID \r\n" +
            "WHERE	@TipoEmpresa_ID IS NULL OR TE.TipoEmpresa_ID = @TipoEmpresa_ID \r\n" +
            "ORDER BY SM.Nombre, TE.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoEmpresa_ID", tipoempresa_id);

            List<Vista_PreciosServiciosTiposEmpresas> list = new List<Vista_PreciosServiciosTiposEmpresas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_PreciosServiciosTiposEmpresas(Convert.ToString(dr["Servicio"]), Convert.ToString(dr["TipoCliente"]), Convert.ToDecimal(dr["Precio"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Object tipoempresa_id)
        {
            string sqlstr = "SELECT	UPPER(SM.Nombre) Servicio, UPPER(TE.Nombre) TipoCliente, SMP.Precio \r\n" +
            "FROM	ServiciosMantenimientosPrecios SMP \r\n" +
            "INNER JOIN	ServiciosMantenimientos SM \r\n" +
            "ON		SMP.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID \r\n" +
            "INNER JOIN	TiposEmpresas TE \r\n" +
            "ON		TE.TipoEmpresa_ID = SMP.TipoEmpresa_ID \r\n" +
            "WHERE	@TipoEmpresa_ID IS NULL OR TE.TipoEmpresa_ID = @TipoEmpresa_ID \r\n" +
            "ORDER BY SM.Nombre, TE.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoEmpresa_ID", tipoempresa_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_PreciosServiciosTiposEmpresas


    public class Vista_ConsumosCostoDia
    {

        public Vista_ConsumosCostoDia()
        {
        }

        public Vista_ConsumosCostoDia(System.DateTime fecha, System.String cliente, System.String modelo, System.String tipomantenimiento, System.Decimal total, System.Decimal promedio)
        {
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.Modelo = modelo;
            this.TipoMantenimiento = tipomantenimiento;
            this.Total = total;
            this.Promedio = promedio;
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.String _TipoMantenimiento;
        public System.String TipoMantenimiento
        {
            get { return _TipoMantenimiento; }
            set { _TipoMantenimiento = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.Decimal _Promedio;
        public System.Decimal Promedio
        {
            get { return _Promedio; }
            set { _Promedio = value; }
        }


        public static List<Vista_ConsumosCostoDia> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
		M.Nombre Modelo,
		TM.Nombre TipoMantenimiento,
		OT.Total,
		OT.Total / DATEDIFF(dd,@FechaInicial,@FechaFinal) Promedio
FROM	OrdenesTrabajos OT
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
INNER JOIN	Unidades U
ON		OT.Unidad_ID = U.Unidad_ID
INNER JOIN	ModelosUnidades MU
ON		MU.ModeloUnidad_ID = U.ModeloUnidad_ID
INNER JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
INNER JOIN	TiposMantenimientos TM
ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID
WHERE	OT.EstatusOrdenTrabajo_ID <> 5
AND		OT.FechaTerminacion IS NOT NULL
AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
ORDER BY convert(date,OT.FechaTerminacion), 
       E.Nombre,
       M.Nombre,
       TM.Nombre,
       OT.Total";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ConsumosCostoDia> list = new List<Vista_ConsumosCostoDia>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ConsumosCostoDia(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Modelo"]), Convert.ToString(dr["TipoMantenimiento"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["Promedio"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.DateTime fechainicial, System.DateTime fechafinal)
        {
            string sqlstr = "SELECT	convert(date, OT.FechaTerminacion) Fecha, \r\n" +
            "		E.Nombre Cliente, \r\n" +
            "		M.Nombre Modelo, \r\n" +
            "		TM.Nombre TipoMantenimiento, \r\n" +
            "		OT.Total, \r\n" +
            "		OT.Total / DATEDIFF(dd,@FechaInicial,@FechaFinal) Promedio \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.ClienteFacturar_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Unidades U \r\n" +
            "ON		OT.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	ModelosUnidades MU \r\n" +
            "ON		MU.ModeloUnidad_ID = U.ModeloUnidad_ID \r\n" +
            "INNER JOIN	Modelos M \r\n" +
            "ON		MU.Modelo_ID = M.Modelo_ID \r\n" +
            "INNER JOIN	TiposMantenimientos TM \r\n" +
            "ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID \r\n" +
            "WHERE	OT.EstatusOrdenTrabajo_ID <> 5 \r\n" +
            "AND		OT.FechaTerminacion IS NOT NULL \r\n" +
            "AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ConsumosCostoDia

    public class Vista_ComprasConsolidadas
    {

        public Vista_ComprasConsolidadas()
        {
        }

        public Vista_ComprasConsolidadas(System.String descripcion, System.String proveedor, System.DateTime fecha, System.Decimal subtotal, System.Decimal iva, System.Decimal total)
        {
            this.Descripcion = descripcion;
            this.Proveedor = proveedor;
            this.Fecha = fecha;
            this.Subtotal = subtotal;
            this.IVA = iva;
            this.Total = total;
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.String _Proveedor;
        public System.String Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Decimal _Subtotal;
        public System.Decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public static List<Vista_ComprasConsolidadas> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	R.Descripcion, E.RazonSocial Proveedor,
		convert(date,OC.Fecha) Fecha,
		OC.Subtotal, OC.IVA, OC.Total
FROM	OrdenesCompras OC
INNER JOIN	Compras C
ON		OC.OrdenCompra_ID = C.OrdenCompra_ID
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
WHERE	OC.EstatusOrdenCompra_ID <> 2
AND		OC.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		OC.Empresa_ID = @Empresa_ID
AND		OC.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ComprasConsolidadas> list = new List<Vista_ComprasConsolidadas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ComprasConsolidadas(Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Proveedor"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	R.Descripcion, E.RazonSocial Proveedor,
		convert(date,OC.Fecha) Fecha,
		OC.Subtotal, OC.IVA, OC.Total
FROM	OrdenesCompras OC
INNER JOIN	Compras C
ON		OC.OrdenCompra_ID = C.OrdenCompra_ID
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
WHERE	OC.EstatusOrdenCompra_ID <> 2
AND		OC.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		OC.Empresa_ID = @Empresa_ID
AND		OC.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ComprasConsolidadas

    public class Vista_VentasTaller
    {

        public Vista_VentasTaller()
        {
        }

        public Vista_VentasTaller(System.DateTime fecha, System.String empresa, System.String familia, System.Decimal manoobra, System.Decimal refacciones, System.Decimal iva, System.Decimal total)
        {
            this.Fecha = fecha;
            this.Empresa = empresa;
            this.Familia = familia;
            this.ManoObra = manoobra;
            this.Refacciones = refacciones;
            this.IVA = iva;
            this.Total = total;
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.Decimal _ManoObra;
        public System.Decimal ManoObra
        {
            get { return _ManoObra; }
            set { _ManoObra = value; }
        }

        private System.Decimal _Refacciones;
        public System.Decimal Refacciones
        {
            get { return _Refacciones; }
            set { _Refacciones = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public static List<Vista_VentasTaller> Get(System.DateTime fechainicial, System.DateTime fechafinal)
        {
            string sqlstr = "SELECT	convert(date,OT.FechaTerminacion) Fecha, \r\n" +
            "		E.Nombre Empresa,  \r\n" +
            "		F.Nombre Familia, \r\n" +
            "		OT.ManoObra, \r\n" +
            "		OT.Refacciones, \r\n" +
            "		OT.IVA, \r\n" +
            "		OT.Total \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	OrdenesServicios OS \r\n" +
            "ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	ServiciosMantenimientos SM \r\n" +
            "ON		OS.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		SM.Familia_ID = F.Familia_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.ClienteFacturar_ID = E.Empresa_ID \r\n" +
            "WHERE	OT.EstatusOrdenTrabajo_ID <> 5 \r\n" +
            "AND		OT.FechaTerminacion IS NOT NULL \r\n" +
            "AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_VentasTaller> list = new List<Vista_VentasTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_VentasTaller(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Familia"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["Refacciones"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.DateTime fechainicial, System.DateTime fechafinal)
        {
            string sqlstr = "SELECT	convert(date,OT.FechaTerminacion) Fecha, \r\n" +
            "		E.Nombre Empresa,  \r\n" +
            "		F.Nombre Familia, \r\n" +
            "		OT.ManoObra, \r\n" +
            "		OT.Refacciones, \r\n" +
            "		OT.IVA, \r\n" +
            "		OT.Total \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	OrdenesServicios OS \r\n" +
            "ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	ServiciosMantenimientos SM \r\n" +
            "ON		OS.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		SM.Familia_ID = F.Familia_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.ClienteFacturar_ID = E.Empresa_ID \r\n" +
            "WHERE	OT.EstatusOrdenTrabajo_ID <> 5 \r\n" +
            "AND		OT.FechaTerminacion IS NOT NULL \r\n" +
            "AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_VentasTaller


    public class SelectDiasDeCobros
    {

        public SelectDiasDeCobros()
        {
        }

        public SelectDiasDeCobros(System.Int32? diasdecobro_id, System.String nombre)
        {
            this.DiasDeCobro_ID = diasdecobro_id;
            this.Nombre = nombre;
        }

        private System.Int32? _DiasDeCobro_ID;
        public System.Int32? DiasDeCobro_ID
        {
            get { return _DiasDeCobro_ID; }
            set { _DiasDeCobro_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectDiasDeCobros> Get()
        {
            string sqlstr = "SELECT	NULL DiasDeCobro_ID, '-TODOS-' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	DiasDeCobro_ID, Nombre \r\n" +
            "FROM	DiasDeCobros";

            List<SelectDiasDeCobros> list = new List<SelectDiasDeCobros>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectDiasDeCobros(DB.GetNullableInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL DiasDeCobro_ID, '-TODOS-' Nombre \r\n" +
            "UNION \r\n" +
            "SELECT	DiasDeCobro_ID, Nombre \r\n" +
            "FROM	DiasDeCobros";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectDiasDeCobros

    public class Vista_PlanesDeRenta
    {

        #region Constructors
        public Vista_PlanesDeRenta()
        {
        }

        public Vista_PlanesDeRenta(
            System.Int32? planderenta_id,
            System.String estacion,
            System.String modelo,
            System.String diasdecobro,
            System.String descripcion,
            System.Decimal? rentabase,
            System.String usuario_id,
            System.DateTime? fecha
            )
        {
            this.PlanDeRenta_ID = planderenta_id;
            this.Estacion = estacion;
            this.Modelo = modelo;
            this.DiasDeCobro = diasdecobro;
            this.Descripcion = descripcion;
            this.RentaBase = rentabase;
            this.Usuario_ID = usuario_id;
            this.Fecha = fecha;
        }

        #endregion

        #region Properties
        private System.Int32? _PlanDeRenta_ID;
        public System.Int32? PlanDeRenta_ID
        {
            get { return _PlanDeRenta_ID; }
            set { _PlanDeRenta_ID = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.String _DiasDeCobro;
        public System.String DiasDeCobro
        {
            get { return _DiasDeCobro; }
            set { _DiasDeCobro = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Decimal? _RentaBase;
        public System.Decimal? RentaBase
        {
            get { return _RentaBase; }
            set { _RentaBase = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_PlanesDeRenta> Get(
            System.Int32? modelounidad_id,
            System.Int32? diasdecobro_id,
            System.String descripcion,
            System.Decimal? rentabase,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	PR.PlanDeRenta_ID, 
		E.Nombre Estacion,
		MU.Descripcion Modelo, 
		DC.Nombre DiasDeCobro,
		PR.Descripcion, 
		PR.RentaBase, 
		PR.Usuario_ID,
		PR.Fecha
FROM	PlanesDeRenta PR
INNER JOIN	ModelosUnidades MU
ON		PR.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	DiasDeCobros DC
ON		PR.DiasDeCobro_ID = DC.DiasDeCobro_ID
INNER JOIN	Estaciones E
ON		PR.Estacion_ID = E.Estacion_ID
WHERE	( @ModeloUnidad_ID IS NULL OR MU.ModeloUnidad_ID = @ModeloUnidad_ID )
AND		( @DiasDeCobro_ID IS NULL OR PR.DiasDeCobro_ID = @DiasDeCobro_ID )
AND		( @Descripcion IS NULL OR PR.Descripcion LIKE @Descripcion + '%' )
AND		( @RentaBase IS NULL OR PR.RentaBase = @RentaBase )
AND		( @Estacion_ID IS NULL OR PR.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ModeloUnidad_ID", modelounidad_id);
            m_params.Add("@DiasDeCobro_ID", diasdecobro_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@RentaBase", rentabase);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_PlanesDeRenta> list = new List<Vista_PlanesDeRenta>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_PlanesDeRenta(
                       DB.GetNullableInt32(dr["PlanDeRenta_ID"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["DiasDeCobro"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableDecimal(dr["RentaBase"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       DB.GetNullableDateTime(dr["Fecha"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? modelounidad_id,
            System.Int32? diasdecobro_id,
            System.String descripcion,
            System.Decimal? rentabase,
            System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	PR.PlanDeRenta_ID, 
		E.Nombre Estacion,
		MU.Descripcion Modelo, 
		DC.Nombre DiasDeCobro,
		PR.Descripcion, 
		PR.RentaBase, 
		PR.Usuario_ID,
		PR.Fecha
FROM	PlanesDeRenta PR
INNER JOIN	ModelosUnidades MU
ON		PR.ModeloUnidad_ID = MU.ModeloUnidad_ID
INNER JOIN	DiasDeCobros DC
ON		PR.DiasDeCobro_ID = DC.DiasDeCobro_ID
INNER JOIN	Estaciones E
ON		PR.Estacion_ID = E.Estacion_ID
WHERE	( @ModeloUnidad_ID IS NULL OR MU.ModeloUnidad_ID = @ModeloUnidad_ID )
AND		( @DiasDeCobro_ID IS NULL OR PR.DiasDeCobro_ID = @DiasDeCobro_ID )
AND		( @Descripcion IS NULL OR PR.Descripcion LIKE @Descripcion + '%' )
AND		( @RentaBase IS NULL OR PR.RentaBase = @RentaBase )
AND		( @Estacion_ID IS NULL OR PR.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ModeloUnidad_ID", modelounidad_id);
            m_params.Add("@DiasDeCobro_ID", diasdecobro_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@RentaBase", rentabase);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_PlanesDeRenta

    public class Vista_ContratosLiquidados
    {

        public Vista_ContratosLiquidados()
        {
        }

        public Vista_ContratosLiquidados(System.Int32 folio, System.String conductor, System.Int32 unidad, System.String locacionunidad, System.String estatusconductor, System.String estatuscontrato, System.DateTime fechaliquidacion, System.String usuarioliquidacion, System.String comentario, System.String estacion)
        {
            this.Folio = folio;
            this.Conductor = conductor;
            this.Unidad = unidad;
            this.LocacionUnidad = locacionunidad;
            this.EstatusConductor = estatusconductor;
            this.EstatusContrato = estatuscontrato;
            this.FechaLiquidacion = fechaliquidacion;
            this.UsuarioLiquidacion = usuarioliquidacion;
            this.Comentario = comentario;
            this.Estacion = estacion;
        }

        private System.Int32 _Folio;
        public System.Int32 Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32 _Unidad;
        public System.Int32 Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _LocacionUnidad;
        public System.String LocacionUnidad
        {
            get { return _LocacionUnidad; }
            set { _LocacionUnidad = value; }
        }

        private System.String _EstatusConductor;
        public System.String EstatusConductor
        {
            get { return _EstatusConductor; }
            set { _EstatusConductor = value; }
        }

        private System.String _EstatusContrato;
        public System.String EstatusContrato
        {
            get { return _EstatusContrato; }
            set { _EstatusContrato = value; }
        }

        private System.DateTime _FechaLiquidacion;
        public System.DateTime FechaLiquidacion
        {
            get { return _FechaLiquidacion; }
            set { _FechaLiquidacion = value; }
        }

        private System.String _UsuarioLiquidacion;
        public System.String UsuarioLiquidacion
        {
            get { return _UsuarioLiquidacion; }
            set { _UsuarioLiquidacion = value; }
        }

        private System.String _Comentario;
        public System.String Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }

        private System.String _estacion;
        public System.String Estacion
        {
            get { return _estacion; }
            set { _estacion = value; }
        }


        public static List<Vista_ContratosLiquidados> Get(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime? fechainicial,
            System.DateTime? fechafinal)
        {
            string sqlstr = "dbo.usp_ContratosLiquidados_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_ContratosLiquidados> list = new List<Vista_ContratosLiquidados>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ContratosLiquidados(
                       Convert.ToInt32(dr["Folio"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToInt32(dr["Unidad"]),
                       Convert.ToString(dr["LocacionUnidad"]),
                       Convert.ToString(dr["EstatusConductor"]),
                       Convert.ToString(dr["EstatusContrato"]),
                       Convert.ToDateTime(dr["FechaLiquidacion"]),
                       Convert.ToString(dr["UsuarioLiquidacion"]),
                       Convert.ToString(dr["Comentario"]),
                       Convert.ToString(dr["Estacion"])
                    )
                );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Object empresa_id, System.Object estacion_id, System.Object fechainicial, System.Object fechafinal)
        {
            string sqlstr = "dbo.usp_ContratosLiquidados_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class Vista_ContratosLiquidados


    public class Vista_ReporteLicenciasVencidas
    {

        public Vista_ReporteLicenciasVencidas()
        {
        }

        public Vista_ReporteLicenciasVencidas(System.Int32 unidad, System.String conductor, System.String foliolicencia, System.String tipo, System.DateTime fechavencimiento, System.Int32 diasvencida)
        {
            this.Unidad = unidad;
            this.Conductor = conductor;
            this.FolioLicencia = foliolicencia;
            this.Tipo = tipo;
            this.FechaVencimiento = fechavencimiento;
            this.DiasVencida = diasvencida;
        }

        private System.Int32 _Unidad;
        public System.Int32 Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _FolioLicencia;
        public System.String FolioLicencia
        {
            get { return _FolioLicencia; }
            set { _FolioLicencia = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.DateTime _FechaVencimiento;
        public System.DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        private System.Int32 _DiasVencida;
        public System.Int32 DiasVencida
        {
            get { return _DiasVencida; }
            set { _DiasVencida = value; }
        }


        public static List<Vista_ReporteLicenciasVencidas> Get()
        {
            string sqlstr = "SELECT	CONT.NumeroEconomico Unidad, \r\n" +
            "		C.Apellidos + ' ' + C.Nombre Conductor,		 \r\n" +
            "		C.FolioLicencia, \r\n" +
            "		TL.Nombre Tipo, C.VenceLicencia FechaVencimiento, \r\n" +
            "		DATEDIFF(dd, C.VenceLicencia, GETDATE()) DiasVencida \r\n" +
            "FROM	Conductores C \r\n" +
            "INNER JOIN	TiposLicencias TL \r\n" +
            "ON		C.TipoLicencia_ID = TL.TipoLicencia_ID \r\n" +
            "LEFT JOIN	Contratos CONT \r\n" +
            "ON		( C.Conductor_ID = CONT.Conductor_ID  \r\n" +
            "			AND CONT.EstatusContrato_ID = 1  \r\n" +
            "			AND CONT.Unidad_ID IS NOT NULL ) --AND CONT.TipoContrato_ID IN (1,2) \r\n" +
            "WHERE	C.FolioLicencia IS NOT NULL \r\n" +
            "AND		C.VenceLicencia < GETDATE() \r\n" +
            "AND		C.EstatusConductor_ID IN (6,7,11) \r\n" +
            "ORDER BY	C.VenceLicencia";

            List<Vista_ReporteLicenciasVencidas> list = new List<Vista_ReporteLicenciasVencidas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReporteLicenciasVencidas(Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Conductor"]), Convert.ToString(dr["FolioLicencia"]), Convert.ToString(dr["Tipo"]), Convert.ToDateTime(dr["FechaVencimiento"]), Convert.ToInt32(dr["DiasVencida"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	CONT.NumeroEconomico Unidad, \r\n" +
            "		C.Apellidos + ' ' + C.Nombre Conductor,		 \r\n" +
            "		C.FolioLicencia, \r\n" +
            "		TL.Nombre Tipo, C.VenceLicencia FechaVencimiento, \r\n" +
            "		DATEDIFF(dd, C.VenceLicencia, GETDATE()) DiasVencida \r\n" +
            "FROM	Conductores C \r\n" +
            "INNER JOIN	TiposLicencias TL \r\n" +
            "ON		C.TipoLicencia_ID = TL.TipoLicencia_ID \r\n" +
            "LEFT JOIN	Contratos CONT \r\n" +
            "ON		( C.Conductor_ID = CONT.Conductor_ID  \r\n" +
            "			AND CONT.EstatusContrato_ID = 1  \r\n" +
            "			AND CONT.Unidad_ID IS NOT NULL --AND CONT.TipoContrato_ID IN (1,2) ) \r\n" +
            "WHERE	C.FolioLicencia IS NOT NULL \r\n" +
            "AND		C.VenceLicencia < GETDATE() \r\n" +
            "AND		C.EstatusConductor_ID IN (6,7,11) \r\n" +
            "ORDER BY	C.VenceLicencia";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class Vista_ReporteLicenciasVencidas

    public class Vista_ReporteUnidadesKilometrajes
    {

        public Vista_ReporteUnidadesKilometrajes()
        {
        }

        public Vista_ReporteUnidadesKilometrajes(System.Int32 numeroeconomico, System.String conductor, System.Int32 kilometraje, System.DateTime fecha)
        {
            this.NumeroEconomico = numeroeconomico;
            this.Conductor = conductor;
            this.Kilometraje = kilometraje;
            this.Fecha = fecha;
        }

        private System.Int32 _NumeroEconomico;
        public System.Int32 NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32 _Kilometraje;
        public System.Int32 Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }


        public static List<Vista_ReporteUnidadesKilometrajes> Get(
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? numeroeconomico)
        {
            string sqlstr = "SELECT	U.NumeroEconomico, C.Apellidos + ' ' + C.Nombre Conductor, \r\n" +
            "		UK.Kilometraje, \r\n" +
            "		UK.Fecha \r\n" +
            "FROM	Unidades_Kilometrajes UK \r\n" +
            "INNER JOIN	Unidades U \r\n" +
            "ON		UK.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	Conductores C \r\n" +
            "ON		UK.Conductor_ID = C.Conductor_ID \r\n" +
            "WHERE	( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )  \r\n" +
            "			OR ( UK.Fecha BETWEEN @FechaInicial AND @FechaFinal ) ) \r\n" +
            "AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<Vista_ReporteUnidadesKilometrajes> list = new List<Vista_ReporteUnidadesKilometrajes>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReporteUnidadesKilometrajes(Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["Conductor"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime? fechainicial,
            System.DateTime? fechafinal,
            System.Int32? numeroeconomico)
        {
            string sqlstr = "SELECT	U.NumeroEconomico, C.Apellidos + ' ' + C.Nombre Conductor, \r\n" +
            "		UK.Kilometraje, \r\n" +
            "		UK.Fecha \r\n" +
            "FROM	Unidades_Kilometrajes UK \r\n" +
            "INNER JOIN	Unidades U \r\n" +
            "ON		UK.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	Conductores C \r\n" +
            "ON		UK.Conductor_ID = C.Conductor_ID \r\n" +
            "WHERE	( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )  \r\n" +
            "			OR ( UK.Fecha BETWEEN @FechaInicial AND @FechaFinal ) ) \r\n" +
            "AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ReporteUnidadesKilometrajes

    public class Vista_ConductoresUnidadesActuales
    {

        #region Constructors
        public Vista_ConductoresUnidadesActuales()
        {
        }

        public Vista_ConductoresUnidadesActuales(
            System.String estacion,
            System.Int32? numeroeconomico,
            System.String conductor,
            System.String placas,
            System.String telefono,
            System.String telefono2,
            System.String domicilio,
            System.String aval,
            System.String telefono_aval,
            System.String domicilioaval
            )
        {
            this.Estacion = estacion;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor = conductor;
            this.Placas = placas;
            this.Telefono = telefono;
            this.Telefono2 = telefono2;
            this.Domicilio = domicilio;
            this.Aval = aval;
            this.Telefono_Aval = telefono_aval;
            this.DomicilioAval = domicilioaval;
        }

        #endregion

        #region Properties
        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Placas;
        public System.String Placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _Telefono2;
        public System.String Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }

        private System.String _Domicilio;
        public System.String Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private System.String _Aval;
        public System.String Aval
        {
            get { return _Aval; }
            set { _Aval = value; }
        }

        private System.String _Telefono_Aval;
        public System.String Telefono_Aval
        {
            get { return _Telefono_Aval; }
            set { _Telefono_Aval = value; }
        }

        private System.String _DomicilioAval;
        public System.String DomicilioAval
        {
            get { return _DomicilioAval; }
            set { _DomicilioAval = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ConductoresUnidadesActuales> Get(
            System.Int32? numeroeconomico,
            System.String placas)
        {
            string sqlstr = @"SELECT	EST.Nombre Estacion, 
		U.NumeroEconomico,  
		UPPER(CO.Apellidos + ' ' + CO.Nombre) Conductor, 
		U.Placas,
		CO.Telefono, 
		CO.Telefono2,  
		UPPER(CO.Domicilio + ', ' + CO.Ciudad + ', ' + CO.Entidad) Domicilio, 
		UPPER(CO.Apellidos_Aval + ' ' + CO.Nombre_Aval) Aval,  
		CO.Telefono_Aval,  
		UPPER(CO.Domicilio_Aval + ', ' + CO.Ciudad_Aval + ', ' + CO.Estado_Aval) DomicilioAval 
FROM	Contratos C 
INNER JOIN	Conductores CO 
ON		C.Conductor_ID = CO.Conductor_ID 
INNER JOIN	Unidades U 
ON		( U.Unidad_ID = C.Unidad_ID AND U.NumeroEconomico = C.NumeroEconomico ) 
INNER JOIN	Estaciones EST 
ON		C.Estacion_ID = EST.Estacion_ID 
WHERE	Cuenta_ID = 1 
AND		EstatusContrato_ID = 1 
--AND C.TipoContrato_ID IN (1,2)
AND		( @NumeroEconomico IS NULL OR C.NumeroEconomico = @NumeroEconomico ) 
AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )
ORDER BY EST.Nombre, C.NumeroEconomico, CO.Apellidos, CO.Nombre;";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Placas", placas);

            List<Vista_ConductoresUnidadesActuales> list = new List<Vista_ConductoresUnidadesActuales>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ConductoresUnidadesActuales(
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Placas"]),
                       Convert.ToString(dr["Telefono"]),
                       Convert.ToString(dr["Telefono2"]),
                       Convert.ToString(dr["Domicilio"]),
                       Convert.ToString(dr["Aval"]),
                       Convert.ToString(dr["Telefono_Aval"]),
                       Convert.ToString(dr["DomicilioAval"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? numeroeconomico,
            System.String placas)
        {
            string sqlstr = @"SELECT	EST.Nombre Estacion, 
		U.NumeroEconomico,  
		UPPER(CO.Apellidos + ' ' + CO.Nombre) Conductor, 
		U.Placas,
		CO.Telefono, 
		CO.Telefono2,  
		UPPER(CO.Domicilio + ', ' + CO.Ciudad + ', ' + CO.Entidad) Domicilio, 
		UPPER(CO.Apellidos_Aval + ' ' + CO.Nombre_Aval) Aval,  
		CO.Telefono_Aval,  
		UPPER(CO.Domicilio_Aval + ', ' + CO.Ciudad_Aval + ', ' + CO.Estado_Aval) DomicilioAval 
FROM	Contratos C 
INNER JOIN	Conductores CO 
ON		C.Conductor_ID = CO.Conductor_ID 
INNER JOIN	Unidades U 
ON		( U.Unidad_ID = C.Unidad_ID AND U.NumeroEconomico = C.NumeroEconomico ) 
INNER JOIN	Estaciones EST 
ON		C.Estacion_ID = EST.Estacion_ID 
WHERE	Cuenta_ID = 1 
AND		EstatusContrato_ID = 1 
--AND C.TipoContrato_ID IN (1,2)
AND		( @NumeroEconomico IS NULL OR C.NumeroEconomico = @NumeroEconomico ) 
AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )
ORDER BY EST.Nombre, C.NumeroEconomico, CO.Apellidos, CO.Nombre;";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Placas", placas);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ConductoresUnidadesActuales



    public class Vista_ReporteOrdenesTrabajoCobradasCaja
    {

        public Vista_ReporteOrdenesTrabajoCobradasCaja()
        {
        }

        public Vista_ReporteOrdenesTrabajoCobradasCaja(System.Int32 ordentrabajo_id, System.String codigobarras, System.String cliente, System.Decimal total, System.DateTime fechapago)
        {
            this.OrdenTrabajo_ID = ordentrabajo_id;
            this.CodigoBarras = codigobarras;
            this.Cliente = cliente;
            this.Total = total;
            this.FechaPago = fechapago;
        }

        private System.Int32 _OrdenTrabajo_ID;
        public System.Int32 OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private System.String _CodigoBarras;
        public System.String CodigoBarras
        {
            get { return _CodigoBarras; }
            set { _CodigoBarras = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.DateTime _FechaPago;
        public System.DateTime FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }


        public static List<Vista_ReporteOrdenesTrabajoCobradasCaja> Get(System.Int32 sesion_id)
        {
            string sqlstr = "SELECT	OT.OrdenTrabajo_ID, OT.CodigoBarras, E.RazonSocial Cliente, \r\n" +
            "		OT.Total, OT.FechaPago \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	Cajas C \r\n" +
            "ON		OT.Caja_ID = C.Caja_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		( S.Caja_ID = C.Caja_ID \r\n" +
            "		AND OT.FechaPago BETWEEN S.FechaInicial AND ISNULL(S.FechaFinal,GETDATE()) ) \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.ClienteFacturar_ID = E.Empresa_ID \r\n" +
            "WHERE	S.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_ReporteOrdenesTrabajoCobradasCaja> list = new List<Vista_ReporteOrdenesTrabajoCobradasCaja>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReporteOrdenesTrabajoCobradasCaja(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["CodigoBarras"]), Convert.ToString(dr["Cliente"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaPago"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 sesion_id)
        {
            string sqlstr = "SELECT	OT.OrdenTrabajo_ID, OT.CodigoBarras, E.RazonSocial Cliente, \r\n" +
            "		OT.Total, OT.FechaPago \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	Cajas C \r\n" +
            "ON		OT.Caja_ID = C.Caja_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		( S.Caja_ID = C.Caja_ID \r\n" +
            "		AND OT.FechaPago BETWEEN S.FechaInicial AND ISNULL(S.FechaFinal,GETDATE()) ) \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.ClienteFacturar_ID = E.Empresa_ID \r\n" +
            "WHERE	S.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ReporteOrdenesTrabajoCobradasCaja

    public class Vista_ReportePlanillasVendidas
    {

        public Vista_ReportePlanillasVendidas()
        {
        }

        public Vista_ReportePlanillasVendidas(System.String serie, System.Int32 folio, System.Decimal precio, System.Decimal denominacion, System.Int32 ticket_id, System.DateTime fecha, System.Int32 sesion_id)
        {
            this.Serie = serie;
            this.Folio = folio;
            this.Precio = precio;
            this.Denominacion = denominacion;
            this.Ticket_ID = ticket_id;
            this.Fecha = fecha;
            this.Sesion_ID = sesion_id;
        }

        private System.String _Serie;
        public System.String Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        private System.Int32 _Folio;
        public System.Int32 Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal _Denominacion;
        public System.Decimal Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        private System.Int32 _Ticket_ID;
        public System.Int32 Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32 _Sesion_ID;
        public System.Int32 Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }


        public static List<Vista_ReportePlanillasVendidas> Get(System.Int32 sesion_id)
        {
            string sqlstr = "SELECT	PF.Serie, PF.Folio, PF.Precio, PF.Denominacion, PF.Ticket_ID, \r\n" +
            "		T.Fecha, S.Sesion_ID \r\n" +
            "FROM	PlanillasFiscales PF \r\n" +
            "INNER JOIN	Tickets T \r\n" +
            "ON		PF.Ticket_ID = T.Ticket_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		T.Sesion_ID = S.Sesion_ID \r\n" +
            "WHERE	S.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_ReportePlanillasVendidas> list = new List<Vista_ReportePlanillasVendidas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReportePlanillasVendidas(Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Sesion_ID"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 sesion_id)
        {
            string sqlstr = "SELECT	PF.Serie, PF.Folio, PF.Precio, PF.Denominacion, PF.Ticket_ID, \r\n" +
            "		T.Fecha, S.Sesion_ID \r\n" +
            "FROM	PlanillasFiscales PF \r\n" +
            "INNER JOIN	Tickets T \r\n" +
            "ON		PF.Ticket_ID = T.Ticket_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		T.Sesion_ID = S.Sesion_ID \r\n" +
            "WHERE	S.Sesion_ID = @Sesion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static List<Vista_ReportePlanillasVendidas> Get(
            System.Int32? caja_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal)
        {
            string sqlstr = "SELECT	PF.Serie, PF.Folio, PF.Precio, PF.Denominacion, PF.Ticket_ID, \r\n" +
            "		T.Fecha, S.Sesion_ID \r\n" +
            "FROM	PlanillasFiscales PF \r\n" +
            "INNER JOIN	Tickets T \r\n" +
            "ON		PF.Ticket_ID = T.Ticket_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		T.Sesion_ID = S.Sesion_ID \r\n" +
            "WHERE	(@Caja_ID IS NULL OR T.Caja_ID = @Caja_ID) \r\n" +
            "AND T.Fecha BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_ReportePlanillasVendidas> list = new List<Vista_ReportePlanillasVendidas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReportePlanillasVendidas(Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Sesion_ID"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? caja_id,
            System.DateTime fechainicial,
            System.DateTime fechafinal
        )
        {
            string sqlstr = "SELECT	PF.Serie, PF.Folio, PF.Precio, PF.Denominacion, PF.Ticket_ID, \r\n" +
            "		T.Fecha, S.Sesion_ID \r\n" +
            "FROM	PlanillasFiscales PF \r\n" +
            "INNER JOIN	Tickets T \r\n" +
            "ON		PF.Ticket_ID = T.Ticket_ID \r\n" +
            "INNER JOIN	Sesiones S \r\n" +
            "ON		T.Sesion_ID = S.Sesion_ID \r\n" +
            "WHERE	(@Caja_ID IS NULL OR T.Caja_ID = @Caja_ID) \r\n" +
            "AND T.Fecha BETWEEN @FechaInicial AND @FechaFinal";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ReportePlanillasVendidas

    public class Vista_ReporteVentasTaller
    {

        #region Constructors
        public Vista_ReporteVentasTaller()
        {
        }

        public Vista_ReporteVentasTaller(
            System.Int32? ordentrabajo_id,
            System.DateTime? fecha,
            System.String empresa,
            System.Int32? unidad,
            System.String tipo,
            System.String servicio,
            System.Int32? cantidad,
            System.String refaccion,
            System.Decimal? costo,
            System.Decimal? precio,
            System.Decimal? manoobra,
            System.Decimal? iva,
            System.Decimal? total
            )
        {
            this.OrdenTrabajo_ID = ordentrabajo_id;
            this.Fecha = fecha;
            this.Empresa = empresa;
            this.Unidad = unidad;
            this.Tipo = tipo;
            this.Servicio = servicio;
            this.Cantidad = cantidad;
            this.Refaccion = refaccion;
            this.Costo = costo;
            this.Precio = precio;
            this.ManoObra = manoobra;
            this.IVA = iva;
            this.Total = total;
        }

        #endregion

        #region Properties
        private System.Int32? _OrdenTrabajo_ID;
        public System.Int32? OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.String _Servicio;
        public System.String Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }

        private System.Int32? _Cantidad;
        public System.Int32? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Decimal? _Costo;
        public System.Decimal? Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal? _ManoObra;
        public System.Decimal? ManoObra
        {
            get { return _ManoObra; }
            set { _ManoObra = value; }
        }

        private System.Decimal? _IVA;
        public System.Decimal? IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ReporteVentasTaller> Get(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,
		convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Empresa,
		OT.NumeroEconomico Unidad,
		TM.Nombre Tipo,
		SM.Nombre Servicio,
		OSR.Cantidad,
		R.Descripcion Refaccion,
		OSR.Cantidad * OSR.CostoUnitario Costo,
		OSR.Total Precio,		
		OT.ManoObra, OT.IVA, OT.Total
FROM	OrdenesTrabajos OT
LEFT JOIN	OrdenesServicios OS
ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID
LEFT JOIN	OrdenesServiciosRefacciones OSR
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
LEFT JOIN	Refacciones R
ON		OSR.Refaccion_ID = R.Refaccion_ID
LEFT JOIN	ServiciosMantenimientos SM
ON		OS.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
LEFT JOIN	TiposMantenimientos TM
ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID
LEFT JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.EstatusOrdenTrabajo_ID <> 5
AND		OT.FechaTerminacion IS NOT NULL
AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
ORDER BY	OT.OrdenTrabajo_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ReporteVentasTaller> list = new List<Vista_ReporteVentasTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ReporteVentasTaller(
                       DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Servicio"]),
                       DB.GetNullableInt32(dr["Cantidad"]),
                       Convert.ToString(dr["Refaccion"]),
                       DB.GetNullableDecimal(dr["Costo"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       DB.GetNullableDecimal(dr["ManoObra"]),
                       DB.GetNullableDecimal(dr["IVA"]),
                       DB.GetNullableDecimal(dr["Total"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,
		convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Empresa,
		OT.NumeroEconomico Unidad,
		TM.Nombre Tipo,
		SM.Nombre Servicio,
		OSR.Cantidad,
		R.Descripcion Refaccion,
		OSR.Cantidad * OSR.CostoUnitario Costo,
		OSR.Total Precio,		
		OT.ManoObra, OT.IVA, OT.Total
FROM	OrdenesTrabajos OT
LEFT JOIN	OrdenesServicios OS
ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID
LEFT JOIN	OrdenesServiciosRefacciones OSR
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
LEFT JOIN	Refacciones R
ON		OSR.Refaccion_ID = R.Refaccion_ID
LEFT JOIN	ServiciosMantenimientos SM
ON		OS.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID
LEFT JOIN	TiposMantenimientos TM
ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID
LEFT JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.EstatusOrdenTrabajo_ID <> 5
AND		OT.FechaTerminacion IS NOT NULL
AND		OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
ORDER BY	OT.OrdenTrabajo_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteVentasTaller

    public class Vista_ConsumosConsolidadosTaller
    {

        public Vista_ConsumosConsolidadosTaller()
        {
        }

        public Vista_ConsumosConsolidadosTaller(System.DateTime fecha, System.String cliente, System.String familia, System.Decimal manoobra, System.Decimal refacciones, System.Decimal iva, System.Decimal total)
        {
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.Familia = familia;
            this.ManoObra = manoobra;
            this.Refacciones = refacciones;
            this.IVA = iva;
            this.Total = total;
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.Decimal _ManoObra;
        public System.Decimal ManoObra
        {
            get { return _ManoObra; }
            set { _ManoObra = value; }
        }

        private System.Decimal _Refacciones;
        public System.Decimal Refacciones
        {
            get { return _Refacciones; }
            set { _Refacciones = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public static List<Vista_ConsumosConsolidadosTaller> Get(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	MO.Fecha, MO.Cliente, MO.Familia, MO.ManoObra, R.Refacciones,
		( MO.ManoObra + R.Refacciones ) * 0.16 IVA,
		( MO.ManoObra + R.Refacciones ) * 1.16 Total
FROM
(
SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
        F.Nombre Familia, 
        SUM(OS.Total) ManoObra
FROM	OrdenesServicios OS
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre
) MO
INNER JOIN
(
SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
		F.Nombre Familia,
		SUM(OSR.Total) Refacciones
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre
) R
ON	MO.Fecha = R.Fecha AND MO.Cliente = R.Cliente AND MO.Familia = R.Familia";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ConsumosConsolidadosTaller> list = new List<Vista_ConsumosConsolidadosTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ConsumosConsolidadosTaller(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Familia"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["Refacciones"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object fechainicial,
            System.Object fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	convert(date,OT.FechaTerminacion) Fecha,
		E.Nombre Cliente,
        F.Nombre Familia, 
        SUM(OT.ManoObra) ManoObra,
        SUM(OT.Refacciones) Refacciones,
        SUM(OT.IVA) IVA,
        SUM(OT.Total) Total
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	ServiciosMantenimientos S
ON		OS.ServicioMantenimiento_ID = S.ServicioMantenimiento_ID
INNER JOIN	Familias F
ON		S.Familia_ID = F.Familia_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	OT.FechaTerminacion IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID <> 5
AND     OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID
GROUP BY	convert(date,OT.FechaTerminacion), E.Nombre, F.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ConsumosConsolidadosTaller


    public class Vista_OrdenesComprasCanceladas
    {

        public Vista_OrdenesComprasCanceladas()
        {
        }

        public Vista_OrdenesComprasCanceladas(System.Int32 ordencompra_id, System.String proveedor, System.String factura, System.String comentarios, System.DateTime fechacancelacion, System.String usuariocancelo, System.DateTime fechaalta, System.String usuarioalta, System.Decimal subtotal, System.Decimal iva, System.Decimal total)
        {
            this.OrdenCompra_ID = ordencompra_id;
            this.Proveedor = proveedor;
            this.Factura = factura;
            this.Comentarios = comentarios;
            this.FechaCancelacion = fechacancelacion;
            this.UsuarioCancelo = usuariocancelo;
            this.FechaAlta = fechaalta;
            this.UsuarioAlta = usuarioalta;
            this.Subtotal = subtotal;
            this.IVA = iva;
            this.Total = total;
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.String _Proveedor;
        public System.String Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        private System.String _Factura;
        public System.String Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime _FechaCancelacion;
        public System.DateTime FechaCancelacion
        {
            get { return _FechaCancelacion; }
            set { _FechaCancelacion = value; }
        }

        private System.String _UsuarioCancelo;
        public System.String UsuarioCancelo
        {
            get { return _UsuarioCancelo; }
            set { _UsuarioCancelo = value; }
        }

        private System.DateTime _FechaAlta;
        public System.DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }

        private System.String _UsuarioAlta;
        public System.String UsuarioAlta
        {
            get { return _UsuarioAlta; }
            set { _UsuarioAlta = value; }
        }

        private System.Decimal _Subtotal;
        public System.Decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public static List<Vista_OrdenesComprasCanceladas> Get(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenCompra_ID, E.Nombre Proveedor, OC.Factura,
		C.Comentarios, C.Fecha FechaCancelacion, C.Usuario_ID UsuarioCancelo,
		OC.Fecha FechaAlta,
		OC.Usuario_ID UsuarioAlta,
		OC.Subtotal, OC.IVA, OC.Total
FROM	OrdenesComprasCanceladas C
INNER JOIN	OrdenesCompras OC
ON		C.OrdenCompra_ID = OC.OrdenCompra_ID
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		OC.Empresa_ID = @Empresa_ID
AND		OC.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_OrdenesComprasCanceladas> list = new List<Vista_OrdenesComprasCanceladas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesComprasCanceladas(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Proveedor"]), Convert.ToString(dr["Factura"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["FechaCancelacion"]), Convert.ToString(dr["UsuarioCancelo"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.DateTime fechainicial,
            System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenCompra_ID, E.Nombre Proveedor, OC.Factura,
		C.Comentarios, C.Fecha FechaCancelacion, C.Usuario_ID UsuarioCancelo,
		OC.Fecha FechaAlta,
		OC.Usuario_ID UsuarioAlta,
		OC.Subtotal, OC.IVA, OC.Total
FROM	OrdenesComprasCanceladas C
INNER JOIN	OrdenesCompras OC
ON		C.OrdenCompra_ID = OC.OrdenCompra_ID
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		OC.Empresa_ID = @Empresa_ID
AND		OC.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_OrdenesComprasCanceladas

    public class Vista_CancelacionesOrdenesTrabajo
    {

        public Vista_CancelacionesOrdenesTrabajo()
        {
        }

        public Vista_CancelacionesOrdenesTrabajo(System.Int32 ordentrabajo_id, System.Int32 unidad, System.String cliente, System.String comentarios, System.DateTime fechacancelacion, System.String usuariocancelo, System.DateTime fechaalta, System.String usuarioalta, System.Decimal subtotal, System.Decimal iva, System.Decimal total)
        {
            this.OrdenTrabajo_ID = ordentrabajo_id;
            this.Unidad = unidad;
            this.Cliente = cliente;
            this.Comentarios = comentarios;
            this.FechaCancelacion = fechacancelacion;
            this.UsuarioCancelo = usuariocancelo;
            this.FechaAlta = fechaalta;
            this.UsuarioAlta = usuarioalta;
            this.Subtotal = subtotal;
            this.IVA = iva;
            this.Total = total;
        }

        private System.Int32 _OrdenTrabajo_ID;
        public System.Int32 OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private System.Int32 _Unidad;
        public System.Int32 Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Cliente;
        public System.String Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.DateTime _FechaCancelacion;
        public System.DateTime FechaCancelacion
        {
            get { return _FechaCancelacion; }
            set { _FechaCancelacion = value; }
        }

        private System.String _UsuarioCancelo;
        public System.String UsuarioCancelo
        {
            get { return _UsuarioCancelo; }
            set { _UsuarioCancelo = value; }
        }

        private System.DateTime _FechaAlta;
        public System.DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }

        private System.String _UsuarioAlta;
        public System.String UsuarioAlta
        {
            get { return _UsuarioAlta; }
            set { _UsuarioAlta = value; }
        }

        private System.Decimal _Subtotal;
        public System.Decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }


        public static List<Vista_CancelacionesOrdenesTrabajo> Get(System.DateTime fechainicial, System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenTrabajo_ID, OT.NumeroEconomico Unidad,
		E.Nombre Cliente,
		C.Comentarios,
		C.Fecha FechaCancelacion,
		C.Usuario_ID UsuarioCancelo,
		OT.FechaAlta,
		OT.Usuario_ID UsuarioAlta,
		OT.Subtotal, OT.IVA, OT.Total			
FROM	CancelacionesOrdenestrabajos C
INNER JOIN	OrdenesTrabajos OT
ON		C.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND     OT.Empresa_ID = @Empresa_ID
AND     OT.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_CancelacionesOrdenesTrabajo> list = new List<Vista_CancelacionesOrdenesTrabajo>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_CancelacionesOrdenesTrabajo(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["FechaCancelacion"]), Convert.ToString(dr["UsuarioCancelo"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.DateTime fechainicial, System.DateTime fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenTrabajo_ID, OT.NumeroEconomico Unidad,
		E.Nombre Cliente,
		C.Comentarios,
		C.Fecha FechaCancelacion,
		C.Usuario_ID UsuarioCancelo,
		OT.FechaAlta,
		OT.Usuario_ID UsuarioAlta,
		OT.Subtotal, OT.IVA, OT.Total			
FROM	CancelacionesOrdenestrabajos C
INNER JOIN	OrdenesTrabajos OT
ON		C.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	Empresas E
ON		OT.ClienteFacturar_ID = E.Empresa_ID
WHERE	C.Fecha BETWEEN @FechaInicial AND @FechaFinal
AND     OT.Empresa_ID = @Empresa_ID
AND     OT.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_CancelacionesOrdenesTrabajo

    public class Vista_TicketsDeSesion
    {

        public Vista_TicketsDeSesion()
        {
        }

        public Vista_TicketsDeSesion(
            System.Int32 ticket_id,
            System.Int32 sesion_id,
            System.Int32 empresa_id,
            System.String empresa,
            System.Int32 estacion_id,
            System.String estacion,
            System.Int32 conductor_id,
            System.String conductor,
            System.Int32? unidad_id,
            System.Int32? unidad,
            System.Int32 cuenta_id,
            System.String cuenta,
            System.Decimal monto,
            System.DateTime fecha,
            System.String usuario_id)
        {
            this.Ticket_ID = ticket_id;
            this.Sesion_ID = sesion_id;
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Estacion_ID = estacion_id;
            this.Estacion = estacion;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.Unidad_ID = unidad_id;
            this.Unidad = unidad;
            this.Cuenta_ID = cuenta_id;
            this.Cuenta = cuenta;
            this.Monto = monto;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        private System.Int32 _Ticket_ID;
        public System.Int32 Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Int32 _Sesion_ID;
        public System.Int32 Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32 _Estacion_ID;
        public System.Int32 Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32 _Conductor_ID;
        public System.Int32 Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Int32 _Cuenta_ID;
        public System.Int32 Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal _Monto;
        public System.Decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }


        public static List<Vista_TicketsDeSesion> Get(System.Int32? sesion_id, System.Int32? conductor_id)
        {
            string sqlstr = "SELECT	T.Ticket_ID, T.Sesion_ID, CC.Empresa_ID, E.Nombre Empresa, \r\n" +
            "		CC.Estacion_ID, EST.Nombre Estacion, \r\n" +
            "		T.Conductor_ID, C.Apellidos + ' ' + C.Nombre Conductor, \r\n" +
            "		T.Unidad_ID, U.NumeroEconomico Unidad, \r\n" +
            "		CC.Cuenta_ID, CU.Nombre Cuenta, \r\n" +
            "		(CC.Abono - CC.Cargo) Monto, \r\n" +
            "		T.Fecha, T.Usuario_ID \r\n" +
            "FROM	Tickets T \r\n" +
            "INNER JOIN	CuentaConductores CC \r\n" +
            "ON		T.Ticket_ID = CC.Ticket_ID \r\n" +
            "INNER JOIN	Conductores C \r\n" +
            "ON		T.Conductor_ID = C.Conductor_ID \r\n" +
            "LEFT JOIN	Unidades U \r\n" +
            "ON		T.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		CC.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		CC.Estacion_ID = EST.Estacion_ID \r\n" +
            "INNER JOIN	Cuentas CU \r\n" +
            "ON		CC.Cuenta_ID = CU.Cuenta_ID \r\n" +
            "WHERE	( @Sesion_ID IS NULL OR Sesion_ID = @Sesion_ID ) \r\n" +
            "AND		( @Conductor_ID IS NULL OR T.Conductor_ID = @Conductor_ID ) \r\n" +
            "ORDER BY	CC.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Conductor_ID", conductor_id);

            List<Vista_TicketsDeSesion> list = new List<Vista_TicketsDeSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_TicketsDeSesion(
                       Convert.ToInt32(dr["Ticket_ID"]),
                       Convert.ToInt32(dr["Sesion_ID"]),
                       Convert.ToInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToInt32(dr["Estacion_ID"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToDecimal(dr["Monto"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? sesion_id, System.Int32? conductor_id)
        {
            string sqlstr = "SELECT	T.Ticket_ID, T.Sesion_ID, CC.Empresa_ID, E.Nombre Empresa, \r\n" +
            "		CC.Estacion_ID, EST.Nombre Estacion, \r\n" +
            "		T.Conductor_ID, C.Apellidos + ' ' + C.Nombre Conductor, \r\n" +
            "		T.Unidad_ID, U.NumeroEconomico Unidad, \r\n" +
            "		CC.Cuenta_ID, CU.Nombre Cuenta, \r\n" +
            "		(CC.Abono - CC.Cargo) Monto, \r\n" +
            "		T.Fecha, T.Usuario_ID \r\n" +
            "FROM	Tickets T \r\n" +
            "INNER JOIN	CuentaConductores CC \r\n" +
            "ON		T.Ticket_ID = CC.Ticket_ID \r\n" +
            "INNER JOIN	Conductores C \r\n" +
            "ON		T.Conductor_ID = C.Conductor_ID \r\n" +
            "LEFT JOIN	Unidades U \r\n" +
            "ON		T.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		CC.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		CC.Estacion_ID = EST.Estacion_ID \r\n" +
            "INNER JOIN	Cuentas CU \r\n" +
            "ON		CC.Cuenta_ID = CU.Cuenta_ID \r\n" +
            "WHERE	( @Sesion_ID IS NULL OR Sesion_ID = @Sesion_ID ) \r\n" +
            "AND		( @Conductor_ID IS NULL OR T.Conductor_ID = @Conductor_ID ) \r\n" +
            "ORDER BY	CC.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Conductor_ID", conductor_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static DataTable GetTicketsEstacionDataTable(DateTime? fechainicial, DateTime? fechafinal, int? estacion_id)
        {
            string sqlstr = @"SELECT	T.Ticket_ID, T.Sesion_ID, CC.Empresa_ID, E.Nombre Empresa,
	            CC.Estacion_ID, EST.Nombre Estacion,
	            T.Conductor_ID, C.Apellidos + ' ' + C.Nombre Conductor,
	            T.Unidad_ID, U.NumeroEconomico Unidad,
	            CC.Cuenta_ID, CU.Nombre Cuenta,
	            (CC.Abono - CC.Cargo) Monto,
	            T.Fecha, T.Usuario_ID
            FROM	Tickets T
            INNER JOIN	CuentaConductores CC
            ON		T.Ticket_ID = CC.Ticket_ID
            INNER JOIN	Conductores C
            ON		T.Conductor_ID = C.Conductor_ID
            LEFT JOIN	Unidades U
            ON		T.Unidad_ID = U.Unidad_ID
            INNER JOIN	Empresas E
            ON		CC.Empresa_ID = E.Empresa_ID
            INNER JOIN	Estaciones EST
            ON		CC.Estacion_ID = EST.Estacion_ID
            INNER JOIN	Cuentas CU
            ON		CC.Cuenta_ID = CU.Cuenta_ID
            WHERE	( @Estacion_ID IS NULL OR T.Estacion_ID = @Estacion_ID )
            AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) 
		            OR ( T.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )
            ORDER BY	CC.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static List<Vista_TicketsDeSesion> GetTicketsEstacion(DateTime? fechainicial, DateTime? fechafinal, int? estacion_id, string usuario_id)
        {
            string sqlstr = @"SELECT	T.Ticket_ID, T.Sesion_ID, CC.Empresa_ID, E.Nombre Empresa,
	            CC.Estacion_ID, EST.Nombre Estacion,
	            T.Conductor_ID, C.Apellidos + ' ' + C.Nombre Conductor,
	            T.Unidad_ID, U.NumeroEconomico Unidad,
	            CC.Cuenta_ID, CU.Nombre Cuenta,
	            (CC.Abono - CC.Cargo) Monto,
	            T.Fecha, T.Usuario_ID
            FROM	Tickets T
            INNER JOIN	CuentaConductores CC
            ON		T.Ticket_ID = CC.Ticket_ID
            INNER JOIN	Conductores C
            ON		T.Conductor_ID = C.Conductor_ID
            LEFT JOIN	Unidades U
            ON		T.Unidad_ID = U.Unidad_ID
            INNER JOIN	Empresas E
            ON		CC.Empresa_ID = E.Empresa_ID
            INNER JOIN	Estaciones EST
            ON		CC.Estacion_ID = EST.Estacion_ID
            INNER JOIN	Cuentas CU
            ON		CC.Cuenta_ID = CU.Cuenta_ID
            WHERE	( T.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
            AND		( T.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) ) 
            AND     ( @Estacion_ID IS NULL OR T.Estacion_ID = @Estacion_ID )
            AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) 
		            OR ( T.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )
            ORDER BY	CC.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_TicketsDeSesion> list = new List<Vista_TicketsDeSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_TicketsDeSesion(
                       Convert.ToInt32(dr["Ticket_ID"]),
                       Convert.ToInt32(dr["Sesion_ID"]),
                       Convert.ToInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToInt32(dr["Estacion_ID"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToDecimal(dr["Monto"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"]))
                    );
            }
            return list;
        } // End GetDataTable

        public static List<Vista_TicketsDeSesion> GetTicketsEmpresa(DateTime? fechainicial, DateTime? fechafinal, int? empresa_id)
        {
            string sqlstr = @"SELECT	T.Ticket_ID, T.Sesion_ID, CC.Empresa_ID, E.Nombre Empresa,
	            CC.Estacion_ID, EST.Nombre Estacion,
	            T.Conductor_ID, C.Apellidos + ' ' + C.Nombre Conductor,
	            T.Unidad_ID, U.NumeroEconomico Unidad,
	            CC.Cuenta_ID, CU.Nombre Cuenta,
	            (CC.Abono - CC.Cargo) Monto,
	            T.Fecha, T.Usuario_ID
            FROM	Tickets T
            INNER JOIN	CuentaConductores CC
            ON		T.Ticket_ID = CC.Ticket_ID
            INNER JOIN	Conductores C
            ON		T.Conductor_ID = C.Conductor_ID
            LEFT JOIN	Unidades U
            ON		T.Unidad_ID = U.Unidad_ID
            INNER JOIN	Empresas E
            ON		CC.Empresa_ID = E.Empresa_ID
            INNER JOIN	Estaciones EST
            ON		CC.Estacion_ID = EST.Estacion_ID
            INNER JOIN	Cuentas CU
            ON		CC.Cuenta_ID = CU.Cuenta_ID
            WHERE	( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
            AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) 
		            OR ( T.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )
            ORDER BY	CC.Fecha";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_TicketsDeSesion> list = new List<Vista_TicketsDeSesion>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_TicketsDeSesion(
                       Convert.ToInt32(dr["Ticket_ID"]),
                       Convert.ToInt32(dr["Sesion_ID"]),
                       Convert.ToInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToInt32(dr["Estacion_ID"]),
                       Convert.ToString(dr["Estacion"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToDecimal(dr["Monto"]),
                       Convert.ToDateTime(dr["Fecha"]),
                       Convert.ToString(dr["Usuario_ID"]))
                    );
            }
            return list;
        } // End GetDataTable

    } // End Class Vista_TicketsDeSesion

    public class Vista_CobranzaAtencionYControl
    {

        public Vista_CobranzaAtencionYControl()
        {
        }

        public Vista_CobranzaAtencionYControl(System.Int32 contrato_id, System.Int32 conductor_id, System.Int32 unidad, System.String conductor, System.Decimal rentas, System.Decimal otroscargos, System.Decimal cargosestacion, System.Decimal scp, System.Int32 kilometraje, System.Decimal saldoatratar, System.Boolean cronocasco, System.Boolean terminaldatos, System.Boolean bloquearconductor, System.String mensajeacaja, System.String copia, System.String estatus, System.String empresa, System.String estacion)
        {
            this.Contrato_ID = contrato_id;
            this.Conductor_ID = conductor_id;
            this.Unidad = unidad;
            this.Conductor = conductor;
            this.Rentas = rentas;
            this.OtrosCargos = otroscargos;
            this.CargosEstacion = cargosestacion;
            this.SCP = scp;
            this.Kilometraje = kilometraje;
            this.SaldoATratar = saldoatratar;
            this.Cronocasco = cronocasco;
            this.TerminalDatos = terminaldatos;
            this.BloquearConductor = bloquearconductor;
            this.MensajeACaja = mensajeacaja;
            this.Copia = copia;
            this.Estatus = estatus;
            this.Empresa = empresa;
            this.Estacion = estacion;
        }

        private System.Int32 _Contrato_ID;
        public System.Int32 Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }

        private System.Int32 _Conductor_ID;
        public System.Int32 Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.Int32 _Unidad;
        public System.Int32 Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Decimal _Rentas;
        public System.Decimal Rentas
        {
            get { return _Rentas; }
            set { _Rentas = value; }
        }

        private System.Decimal _OtrosCargos;
        public System.Decimal OtrosCargos
        {
            get { return _OtrosCargos; }
            set { _OtrosCargos = value; }
        }

        private System.Decimal _CargosEstacion;
        public System.Decimal CargosEstacion
        {
            get { return _CargosEstacion; }
            set { _CargosEstacion = value; }
        }

        private System.Decimal _SCP;
        public System.Decimal SCP
        {
            get { return _SCP; }
            set { _SCP = value; }
        }

        private System.Int32 _Kilometraje;
        public System.Int32 Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }

        private System.Decimal _SaldoATratar;
        public System.Decimal SaldoATratar
        {
            get { return _SaldoATratar; }
            set { _SaldoATratar = value; }
        }

        private System.Boolean _Cronocasco;
        public System.Boolean Cronocasco
        {
            get { return _Cronocasco; }
            set { _Cronocasco = value; }
        }

        private System.Boolean _TerminalDatos;
        public System.Boolean TerminalDatos
        {
            get { return _TerminalDatos; }
            set { _TerminalDatos = value; }
        }

        private System.Boolean _BloquearConductor;
        public System.Boolean BloquearConductor
        {
            get { return _BloquearConductor; }
            set { _BloquearConductor = value; }
        }

        private System.String _MensajeACaja;
        public System.String MensajeACaja
        {
            get { return _MensajeACaja; }
            set { _MensajeACaja = value; }
        }

        private System.String _Copia;
        public System.String Copia
        {
            get { return _Copia; }
            set { _Copia = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }


        public static List<Vista_CobranzaAtencionYControl> Get(System.Int32? numeroeconomico, System.String nombre,
            System.Int32? empresa_id, System.Int32? estacion_id, System.String usuario_id)
        {
            string sqlstr = @"SELECT  C.Contrato_ID, 
		C.Conductor_ID, 
		U.NumeroEconomico AS Unidad, 
		COND.Apellidos + ' ' + COND.Nombre AS Conductor,		
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 1)) AS Rentas, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_7 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 2)) AS OtrosCargos, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_6 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 10)) AS CargosEstacion, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_5 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 8)) AS SCP,		
		U.Kilometraje, 
		COND.SaldoATratar, 
		COND.Cronocasco,	
		COND.TerminalDatos, 
		COND.BloquearConductor, 
		ISNULL(COND.MensajeACaja,'') MensajeACaja, 
		COP.Apellidos + ' ' + COP.Nombre AS Copia, 
		EC.Nombre AS Estatus,
        E.Nombre Empresa,
        EST.Nombre Estacion                         
FROM    Contratos AS C 
INNER JOIN Conductores AS COND 
ON C.Conductor_ID = COND.Conductor_ID 
INNER JOIN Unidades AS U 
ON C.Unidad_ID = U.Unidad_ID
INNER JOIN  Empresas E
ON      E.Empresa_ID = C.Empresa_ID
INNER JOIN  Estaciones EST
ON      EST.Estacion_ID = C.Estacion_ID
LEFT JOIN Conductores AS COP 
ON C.ConductorCopia_ID = COP.Conductor_ID 
INNER JOIN EstatusConductores AS EC 
ON COND.EstatusConductor_ID = EC.EstatusConductor_ID 
WHERE	( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND     ( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID ) 
AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
AND		( @Nombre IS NULL OR (COND.Apellidos + ' ' + COND.Nombre) LIKE @Nombre + '%')
AND		C.EstatusContrato_ID = 1
--AND C.TipoContrato_ID IN (1,2)
ORDER BY	U.NumeroEconomico, COND.Apellidos + ' ' + COND.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_CobranzaAtencionYControl> list = new List<Vista_CobranzaAtencionYControl>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_CobranzaAtencionYControl(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Conductor"]), Convert.ToDecimal(dr["Rentas"]), Convert.ToDecimal(dr["OtrosCargos"]), Convert.ToDecimal(dr["CargosEstacion"]), Convert.ToDecimal(dr["SCP"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDecimal(dr["SaldoATratar"]), Convert.ToBoolean(dr["Cronocasco"]), Convert.ToBoolean(dr["TerminalDatos"]), Convert.ToBoolean(dr["BloquearConductor"]), Convert.ToString(dr["MensajeACaja"]), Convert.ToString(dr["Copia"]), Convert.ToString(dr["Estatus"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? numeroeconomico, System.String nombre,
            System.Int32? empresa_id, System.Int32? estacion_id, System.String usuario_id)
        {
            string sqlstr = @"SELECT  C.Contrato_ID, 
		C.Conductor_ID, 
		U.NumeroEconomico AS Unidad, 
		COND.Apellidos + ' ' + COND.Nombre AS Conductor,		
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 1)) AS Rentas, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_7 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 2)) AS OtrosCargos, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_6 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 10)) AS CargosEstacion, 
		(SELECT        ISNULL(SUM(Abono - Cargo), 0) AS Expr1 
		FROM            CuentaConductores AS CuentaConductores_5 
		WHERE        (Conductor_ID = COND.Conductor_ID) AND (Cuenta_ID = 8)) AS SCP,		
		U.Kilometraje, 
		COND.SaldoATratar, 
		COND.Cronocasco,	
		COND.TerminalDatos, 
		COND.BloquearConductor, 
		ISNULL(COND.MensajeACaja,'') MensajeACaja, 
		COP.Apellidos + ' ' + COP.Nombre AS Copia, 
		EC.Nombre AS Estatus,
        E.Nombre Empresa,
        EST.Nombre Estacion                         
FROM    Contratos AS C 
INNER JOIN Conductores AS COND 
ON C.Conductor_ID = COND.Conductor_ID 
INNER JOIN Unidades AS U 
ON C.Unidad_ID = U.Unidad_ID
INNER JOIN  Empresas E
ON      E.Empresa_ID = C.Empresa_ID
INNER JOIN  Estaciones EST
ON      EST.Estacion_ID = C.Estacion_ID
LEFT JOIN Conductores AS COP 
ON C.ConductorCopia_ID = COP.Conductor_ID 
INNER JOIN EstatusConductores AS EC 
ON COND.EstatusConductor_ID = EC.EstatusConductor_ID 
WHERE	( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND     ( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID ) 
AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
AND		( @Nombre IS NULL OR (COND.Apellidos + ' ' + COND.Nombre) LIKE @Nombre + '%')
AND		C.EstatusContrato_ID = 1
--AND C.TipoContrato_ID IN (1,2)
ORDER BY	U.NumeroEconomico, COND.Apellidos + ' ' + COND.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_CobranzaAtencionYControl

    public class Vista_SaldosConductores
    {
        #region Constructores
        public Vista_SaldosConductores()
        {
        }

        public Vista_SaldosConductores(
           System.Int32? unidad_id,
           System.Int32? unidad,
           System.Int32 conductor_id,
           System.String conductor,
           System.Int32 empresa_id,
           System.String empresa,
           System.Int32 cuenta_id,
           System.String cuenta,
           System.Decimal saldo)
        {
            this.Unidad_ID = unidad_id;
            this.Unidad = unidad;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Cuenta_ID = cuenta_id;
            this.Cuenta = cuenta;
            this.Saldo = saldo;
        }
        #endregion

        #region Propiedades

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.Int32 _Conductor_ID;
        public System.Int32 Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32 _Cuenta_ID;
        public System.Int32 Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal _Saldo;
        public System.Decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        #endregion

        #region Metodos

        public static List<Vista_SaldosConductores> Get(System.Int32 conductor_id)
        {
            string sqlstr = @"usp_SaldoConductor_Get_Por_ConductorID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);

            List<Vista_SaldosConductores> list = new List<Vista_SaldosConductores>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            //foreach (DataRow dr in dt.Rows)
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Vista_SaldosConductores(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToDecimal(dr["Saldo"])
                       )
                       );
            }
            return list;
        } // End GetData

        public static List<Vista_SaldosConductores> Get(System.Int32? empresa_id, System.Int32? estacion_id,
            System.Boolean activo, System.Int32? numeroeconomico, System.String nombre, System.String usuario_id)
        {
            string sqlstr = "dbo.usp_SaldosConductores_Get";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@activo", activo);

            List<Vista_SaldosConductores> list = new List<Vista_SaldosConductores>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);            
            //foreach (DataRow dr in dt.Rows)
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Vista_SaldosConductores(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["Unidad"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToInt32(dr["Cuenta_ID"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToDecimal(dr["Saldo"])
                    )
                );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? empresa_id, System.Int32? estacion_id,
            System.Boolean activo, System.Int32? numeroeconomico, System.String nombre, System.String usuario_id)
        {
            string sqlstr = "dbo.usp_SaldosConductores_Get";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Usuario_ID", usuario_id);
            m_params.Add("@activo", activo);

            return DB.QueryDS(sqlstr, m_params).Tables[0];

            //return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        #endregion

    } // End Class Vista_SaldosConductores

    public class Vista_RegistroIndicadores
    {

        public Vista_RegistroIndicadores()
        {
        }

        public Vista_RegistroIndicadores(System.String empresa, System.String estacion, System.String indicador, System.Object estrato,
            System.Int32 anio, System.Int32 mes, System.Int32 semana, System.Int32 dia, System.String fecha, System.Object valor)
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Indicador = indicador;
            this.Estrato = estrato;
            this.Anio = anio;
            this.Mes = mes;
            this.Semana = semana;
            this.Dia = dia;
            this.Fecha = fecha;
            this.Valor = valor;
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Indicador;
        public System.String Indicador
        {
            get { return _Indicador; }
            set { _Indicador = value; }
        }

        private System.Object _Estrato;
        public System.Object Estrato
        {
            get { return _Estrato; }
            set { _Estrato = value; }
        }

        private System.Int32 _Anio;
        public System.Int32 Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private System.Int32 _Mes;
        public System.Int32 Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }

        private System.Int32 _Semana;
        public System.Int32 Semana
        {
            get { return _Semana; }
            set { _Semana = value; }
        }

        private System.Int32 _Dia;
        public System.Int32 Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }

        private System.String _Fecha;
        public System.String Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Object _Valor;
        public System.Object Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }


        public static List<Vista_RegistroIndicadores> Get(System.Int32? empresa_id, System.Int32? estacion_id, System.Int32? indicador_id,
            System.Int32? anio, System.Int32? mes, System.Int32? semana, System.Int32? dia,
            System.DateTime? fechainicial, System.DateTime? fechafinal)
        {
            string sqlstr = "SELECT	E.Nombre Empresa, EST.Nombre Estacion, I.Nombre Indicador, RI.Estrato, \r\n" +
            "		RI.Anio, RI.Mes, RI.Semana, RI.Dia, CONVERT(varchar,RI.Fecha,105) Fecha, RI.Valor  \r\n" +
            "FROM	RegistroIndicadores RI \r\n" +
            "INNER JOIN	Indicadores I \r\n" +
            "ON		RI.Indicador_ID = I.Indicador_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		E.Empresa_ID = RI.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		EST.Estacion_ID = RI.Estacion_ID \r\n" +
            "WHERE	( @Empresa_ID IS NULL OR RI.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND		( @Estacion_ID IS NULL OR RI.Estacion_ID = @Estacion_ID ) \r\n" +
            "AND		( @Indicador_ID IS NULL OR RI.Indicador_ID = @Indicador_ID ) \r\n" +
            "AND		( @Anio IS NULL OR RI.Anio = @Anio ) \r\n" +
            "AND		( @Mes IS NULL OR RI.Mes = @Mes ) \r\n" +
            "AND		( @Semana IS NULL OR RI.Semana = @Semana ) \r\n" +
            "AND		( @Dia IS NULL OR RI.Dia = @Dia ) \r\n" +
            "AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR ( RI.Fecha BETWEEN  @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Indicador_ID", indicador_id);
            m_params.Add("@Anio", anio);
            m_params.Add("@Mes", mes);
            m_params.Add("@Semana", semana);
            m_params.Add("@Dia", dia);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_RegistroIndicadores> list = new List<Vista_RegistroIndicadores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_RegistroIndicadores(Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"]), Convert.ToString(dr["Indicador"]),
                    dr["Estrato"], Convert.ToInt32(dr["Anio"]), Convert.ToInt32(dr["Mes"]), Convert.ToInt32(dr["Semana"]),
                    Convert.ToInt32(dr["Dia"]), Convert.ToString(dr["Fecha"]), dr["Valor"]));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? empresa_id, System.Int32? estacion_id, System.Int32? indicador_id,
            System.Int32? anio, System.Int32? mes, System.Int32? semana, System.Int32? dia,
            System.DateTime? fechainicial, System.DateTime? fechafinal)
        {
            string sqlstr = "SELECT	E.Nombre Empresa, EST.Nombre Estacion, I.Nombre Indicador, RI.Estrato, \r\n" +
            "		RI.Anio, RI.Mes, RI.Semana, RI.Dia, CONVERT(varchar,RI.Fecha,105) Fecha, RI.Valor  \r\n" +
            "FROM	RegistroIndicadores RI \r\n" +
            "INNER JOIN	Indicadores I \r\n" +
            "ON		RI.Indicador_ID = I.Indicador_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		E.Empresa_ID = RI.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		EST.Estacion_ID = RI.Estacion_ID \r\n" +
            "WHERE	( @Empresa_ID IS NULL OR RI.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND		( @Estacion_ID IS NULL OR RI.Estacion_ID = @Estacion_ID ) \r\n" +
            "AND		( @Indicador_ID IS NULL OR RI.Indicador_ID = @Indicador_ID ) \r\n" +
            "AND		( @Anio IS NULL OR RI.Anio = @Anio ) \r\n" +
            "AND		( @Mes IS NULL OR RI.Mes = @Mes ) \r\n" +
            "AND		( @Semana IS NULL OR RI.Semana = @Semana ) \r\n" +
            "AND		( @Dia IS NULL OR RI.Dia = @Dia ) \r\n" +
            "AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR ( RI.Fecha BETWEEN  @FechaInicial AND @FechaFinal ) )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Indicador_ID", indicador_id);
            m_params.Add("@Anio", anio);
            m_params.Add("@Mes", mes);
            m_params.Add("@Semana", semana);
            m_params.Add("@Dia", dia);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_RegistroIndicadores

    public class SelectIndicadores
    {

        public SelectIndicadores()
        {
        }

        public SelectIndicadores(System.Int32 indicador_id, System.String nombre)
        {
            this.Indicador_ID = indicador_id;
            this.Nombre = nombre;
        }

        private System.Int32 _Indicador_ID;
        public System.Int32 Indicador_ID
        {
            get { return _Indicador_ID; }
            set { _Indicador_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectIndicadores> Get()
        {
            string sqlstr = "SELECT	NULL Indicador_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Indicador_ID, Nombre \r\n" +
            "FROM	Indicadores";

            List<SelectIndicadores> list = new List<SelectIndicadores>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectIndicadores(Convert.ToInt32(dr["Indicador_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Indicador_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Indicador_ID, Nombre \r\n" +
            "FROM	Indicadores";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectIndicadores

    public class SelectFuncionesAgregado
    {

        public SelectFuncionesAgregado()
        {
        }

        public SelectFuncionesAgregado(System.Int32 funcionagregado_id, System.String nombre)
        {
            this.FuncionAgregado_ID = funcionagregado_id;
            this.Nombre = nombre;
        }

        private System.Int32 _FuncionAgregado_ID;
        public System.Int32 FuncionAgregado_ID
        {
            get { return _FuncionAgregado_ID; }
            set { _FuncionAgregado_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectFuncionesAgregado> Get()
        {
            string sqlstr = "SELECT	NULL FuncionAgregado_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	FuncionAgregado_ID, Nombre \r\n" +
            "FROM	FuncionesAgregado";

            List<SelectFuncionesAgregado> list = new List<SelectFuncionesAgregado>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectFuncionesAgregado(Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL FuncionAgregado_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	FuncionAgregado_ID, Nombre \r\n" +
            "FROM	FuncionesAgregado";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectFuncionesAgregado

    public class SelectPeriodos
    {

        public SelectPeriodos()
        {
        }

        public SelectPeriodos(System.Int32 periodo_id, System.String nombre)
        {
            this.Periodo_ID = periodo_id;
            this.Nombre = nombre;
        }

        private System.Int32 _Periodo_ID;
        public System.Int32 Periodo_ID
        {
            get { return _Periodo_ID; }
            set { _Periodo_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectPeriodos> Get()
        {
            string sqlstr = "SELECT	NULL Periodo_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Periodo_ID, Nombre \r\n" +
            "FROM	Periodos";

            List<SelectPeriodos> list = new List<SelectPeriodos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectPeriodos(Convert.ToInt32(dr["Periodo_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Periodo_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Periodo_ID, Nombre \r\n" +
            "FROM	Periodos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectPeriodos

    public class SelectTiposReportes
    {

        public SelectTiposReportes()
        {
        }

        public SelectTiposReportes(System.Int32 tiporeporte_id, System.String nombre)
        {
            this.TipoReporte_ID = tiporeporte_id;
            this.Nombre = nombre;
        }

        private System.Int32 _TipoReporte_ID;
        public System.Int32 TipoReporte_ID
        {
            get { return _TipoReporte_ID; }
            set { _TipoReporte_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposReportes> Get()
        {
            string sqlstr = "SELECT	NULL TipoReporte_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoReporte_ID, Nombre \r\n" +
            "FROM	TiposReportes";

            List<SelectTiposReportes> list = new List<SelectTiposReportes>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectTiposReportes(Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL TipoReporte_ID, '-TODAS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoReporte_ID, Nombre \r\n" +
            "FROM	TiposReportes";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectTiposReportes



    public class Vista_ReportesIndicadores
    {

        public Vista_ReportesIndicadores()
        {
        }

        public Vista_ReportesIndicadores(System.Int32 reporteindicador_id, System.String nombre, System.String indicador, System.String periodo, System.Int32 cantidadperiodos, System.String tiporeporte, System.String funcionagregado)
        {
            this.ReporteIndicador_ID = reporteindicador_id;
            this.Nombre = nombre;
            this.Indicador = indicador;
            this.Periodo = periodo;
            this.CantidadPeriodos = cantidadperiodos;
            this.TipoReporte = tiporeporte;
            this.FuncionAgregado = funcionagregado;
        }

        private System.Int32 _ReporteIndicador_ID;
        public System.Int32 ReporteIndicador_ID
        {
            get { return _ReporteIndicador_ID; }
            set { _ReporteIndicador_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Indicador;
        public System.String Indicador
        {
            get { return _Indicador; }
            set { _Indicador = value; }
        }

        private System.String _Periodo;
        public System.String Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }

        private System.Int32 _CantidadPeriodos;
        public System.Int32 CantidadPeriodos
        {
            get { return _CantidadPeriodos; }
            set { _CantidadPeriodos = value; }
        }

        private System.String _TipoReporte;
        public System.String TipoReporte
        {
            get { return _TipoReporte; }
            set { _TipoReporte = value; }
        }

        private System.String _FuncionAgregado;
        public System.String FuncionAgregado
        {
            get { return _FuncionAgregado; }
            set { _FuncionAgregado = value; }
        }


        public static List<Vista_ReportesIndicadores> Get(System.Int32? indicador_id, System.Int32? periodo_id,
            System.Int32? tiporeporte_id, System.Int32? funcionagregado_id, System.String nombre)
        {
            string sqlstr = "SELECT	RI.ReporteIndicador_ID, RI.Nombre, I.Nombre Indicador,  \r\n" +
            "		P.Nombre Periodo, RI.CantidadPeriodos,  \r\n" +
            "		TR.Nombre TipoReporte, FA.Nombre FuncionAgregado \r\n" +
            "FROM	ReportesIndicadores RI \r\n" +
            "INNER JOIN	Indicadores I \r\n" +
            "ON		RI.Indicador_ID = I.Indicador_ID \r\n" +
            "INNER JOIN	Periodos P \r\n" +
            "ON		RI.Periodo_ID = P.Periodo_ID \r\n" +
            "INNER JOIN	TiposReportes TR \r\n" +
            "ON		RI.TipoReporte_ID = TR.TipoReporte_ID \r\n" +
            "INNER JOIN	FuncionesAgregado FA \r\n" +
            "ON		RI.FuncionAgregado_ID = FA.FuncionAgregado_ID \r\n" +
            "WHERE	( @Indicador_ID IS NULL OR RI.Indicador_ID = @Indicador_ID ) \r\n" +
            "AND		( @Periodo_ID IS NULL OR RI.Periodo_ID = @Periodo_ID ) \r\n" +
            "AND		( @TipoReporte_ID IS NULL OR RI.TipoReporte_ID = @TipoReporte_ID ) \r\n" +
            "AND		( @FuncionAgregado_ID IS NULL OR RI.FuncionAgregado_ID = @FuncionAgregado_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR RI.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Indicador_ID", indicador_id);
            m_params.Add("@Periodo_ID", periodo_id);
            m_params.Add("@TipoReporte_ID", tiporeporte_id);
            m_params.Add("@FuncionAgregado_ID", funcionagregado_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_ReportesIndicadores> list = new List<Vista_ReportesIndicadores>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ReportesIndicadores(Convert.ToInt32(dr["ReporteIndicador_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Indicador"]), Convert.ToString(dr["Periodo"]), Convert.ToInt32(dr["CantidadPeriodos"]), Convert.ToString(dr["TipoReporte"]), Convert.ToString(dr["FuncionAgregado"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? indicador_id, System.Int32? periodo_id,
            System.Int32? tiporeporte_id, System.Int32? funcionagregado_id, System.String nombre)
        {
            string sqlstr = "SELECT	RI.ReporteIndicador_ID, RI.Nombre, I.Nombre Indicador,  \r\n" +
            "		P.Nombre Periodo, RI.CantidadPeriodos,  \r\n" +
            "		TR.Nombre TipoReporte, FA.Nombre FuncionAgregado \r\n" +
            "FROM	ReportesIndicadores RI \r\n" +
            "INNER JOIN	Indicadores I \r\n" +
            "ON		RI.Indicador_ID = I.Indicador_ID \r\n" +
            "INNER JOIN	Periodos P \r\n" +
            "ON		RI.Periodo_ID = P.Periodo_ID \r\n" +
            "INNER JOIN	TiposReportes TR \r\n" +
            "ON		RI.TipoReporte_ID = TR.TipoReporte_ID \r\n" +
            "INNER JOIN	FuncionesAgregado FA \r\n" +
            "ON		RI.FuncionAgregado_ID = FA.FuncionAgregado_ID \r\n" +
            "WHERE	( @Indicador_ID IS NULL OR RI.Indicador_ID = @Indicador_ID ) \r\n" +
            "AND		( @Periodo_ID IS NULL OR RI.Periodo_ID = @Periodo_ID ) \r\n" +
            "AND		( @TipoReporte_ID IS NULL OR RI.TipoReporte_ID = @TipoReporte_ID ) \r\n" +
            "AND		( @FuncionAgregado_ID IS NULL OR RI.FuncionAgregado_ID = @FuncionAgregado_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR RI.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Indicador_ID", indicador_id);
            m_params.Add("@Periodo_ID", periodo_id);
            m_params.Add("@TipoReporte_ID", tiporeporte_id);
            m_params.Add("@FuncionAgregado_ID", funcionagregado_id);
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ReportesIndicadores

    public class Vista_OrdenesCompras
    {

        public Vista_OrdenesCompras()
        {
        }

        public Vista_OrdenesCompras(System.Int32 ordencompra_id, System.String estado, System.String proveedor, System.String factura, System.Decimal subtotal, System.Decimal iva, System.Decimal total, System.DateTime fecha, System.String usuario_id)
        {
            this.OrdenCompra_ID = ordencompra_id;
            this.Estado = estado;
            this.Proveedor = proveedor;
            this.Factura = factura;
            this.Subtotal = subtotal;
            this.IVA = iva;
            this.Total = total;
            this.Fecha = fecha;
            this.Usuario_ID = usuario_id;
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.String _Estado;
        public System.String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private System.String _Proveedor;
        public System.String Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        private System.String _Factura;
        public System.String Factura
        {
            get { return _Factura; }
            set { _Factura = value; }
        }

        private System.Decimal _Subtotal;
        public System.Decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }


        public static List<Vista_OrdenesCompras> Get(System.Int32? ordencompra_id, System.Int32? proveedor_id,
            System.Int32? estatusordencompra_id, System.DateTime? fechainicial, System.DateTime? fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	OC.OrdenCompra_ID, EOC.Nombre Estado,
		E.RazonSocial Proveedor, OC.Factura, OC.Subtotal,
		OC.IVA, OC.Total, OC.Fecha, OC.Usuario_ID
FROM	OrdenesCompras OC
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
INNER JOIN	EstatusOrdenesCompras EOC
ON		OC.EstatusOrdenCompra_ID = EOC.EstatusOrdenCompra_ID
WHERE	( @OrdenCompra_ID IS NULL OR OC.OrdenCompra_ID = @OrdenCompra_ID )
AND		( @Proveedor_ID IS NULL OR OC.Proveedor_ID = @Proveedor_ID )
AND		( @EstatusOrdenCompra_ID IS NULL OR OC.EstatusOrdenCompra_ID = @EstatusOrdenCompra_ID )
AND		( (@FechaInicial IS NULL AND @FechaFinal IS NULL) OR Fecha BETWEEN @FechaInicial AND @FechaFinal )
AND		( OC.Empresa_ID = @Empresa_ID )
AND		( OC.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Proveedor_ID", proveedor_id);
            m_params.Add("@EstatusOrdenCompra_ID", estatusordencompra_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_OrdenesCompras> list = new List<Vista_OrdenesCompras>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesCompras(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Proveedor"]), Convert.ToString(dr["Factura"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? ordencompra_id, System.Int32? proveedor_id,
            System.Int32? estatusordencompra_id, System.DateTime? fechainicial, System.DateTime? fechafinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	OC.OrdenCompra_ID, EOC.Nombre Estado,
		E.RazonSocial Proveedor, OC.Factura, OC.Subtotal,
		OC.IVA, OC.Total, OC.Fecha, OC.Usuario_ID
FROM	OrdenesCompras OC
INNER JOIN	Empresas E
ON		OC.Proveedor_ID = E.Empresa_ID
INNER JOIN	EstatusOrdenesCompras EOC
ON		OC.EstatusOrdenCompra_ID = EOC.EstatusOrdenCompra_ID
WHERE	( @OrdenCompra_ID IS NULL OR OC.OrdenCompra_ID = @OrdenCompra_ID )
AND		( @Proveedor_ID IS NULL OR OC.Proveedor_ID = @Proveedor_ID )
AND		( @EstatusOrdenCompra_ID IS NULL OR OC.EstatusOrdenCompra_ID = @EstatusOrdenCompra_ID )
AND		( (@FechaInicial IS NULL AND @FechaFinal IS NULL) OR Fecha BETWEEN @FechaInicial AND @FechaFinal )
AND		( OC.Empresa_ID = @Empresa_ID )
AND		( OC.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Proveedor_ID", proveedor_id);
            m_params.Add("@EstatusOrdenCompra_ID", estatusordencompra_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_OrdenesCompras

    public class Vista_Arrendamientos
    {

        public Vista_Arrendamientos()
        {
        }

        public Vista_Arrendamientos(System.Int32 arrendamiento_id, System.String descripcion, System.Int32 referencia, System.String catalogoreferencia, System.String arrendador, System.String arrendatario, System.Decimal montoafinanciar, System.Decimal valorfactura, System.Int32 plazos, System.Decimal mensualidad, System.Decimal residual, System.Decimal tasa, System.Decimal amortizacionresidual, System.String estatusfinanciero, System.Decimal montopagado, System.Decimal saldo, System.Int32 plazosrestantes, System.DateTime fechainicial, System.DateTime fechafinal, System.DateTime ultimafecha, System.DateTime proximafecha, System.Boolean activo, System.String comentarios)
        {
            this.Arrendamiento_ID = arrendamiento_id;
            this.Descripcion = descripcion;
            this.Referencia = referencia;
            this.CatalogoReferencia = catalogoreferencia;
            this.Arrendador = arrendador;
            this.Arrendatario = arrendatario;
            this.MontoAFinanciar = montoafinanciar;
            this.ValorFactura = valorfactura;
            this.Plazos = plazos;
            this.Mensualidad = mensualidad;
            this.Residual = residual;
            this.Tasa = tasa;
            this.AmortizacionResidual = amortizacionresidual;
            this.EstatusFinanciero = estatusfinanciero;
            this.MontoPagado = montopagado;
            this.Saldo = saldo;
            this.PlazosRestantes = plazosrestantes;
            this.FechaInicial = fechainicial;
            this.FechaFinal = fechafinal;
            this.UltimaFecha = ultimafecha;
            this.ProximaFecha = proximafecha;
            this.Activo = activo;
            this.Comentarios = comentarios;
        }

        private System.Int32 _Arrendamiento_ID;
        public System.Int32 Arrendamiento_ID
        {
            get { return _Arrendamiento_ID; }
            set { _Arrendamiento_ID = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Int32 _Referencia;
        public System.Int32 Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private System.String _CatalogoReferencia;
        public System.String CatalogoReferencia
        {
            get { return _CatalogoReferencia; }
            set { _CatalogoReferencia = value; }
        }

        private System.String _Arrendador;
        public System.String Arrendador
        {
            get { return _Arrendador; }
            set { _Arrendador = value; }
        }

        private System.String _Arrendatario;
        public System.String Arrendatario
        {
            get { return _Arrendatario; }
            set { _Arrendatario = value; }
        }

        private System.Decimal _MontoAFinanciar;
        public System.Decimal MontoAFinanciar
        {
            get { return _MontoAFinanciar; }
            set { _MontoAFinanciar = value; }
        }

        private System.Decimal _ValorFactura;
        public System.Decimal ValorFactura
        {
            get { return _ValorFactura; }
            set { _ValorFactura = value; }
        }

        private System.Int32 _Plazos;
        public System.Int32 Plazos
        {
            get { return _Plazos; }
            set { _Plazos = value; }
        }

        private System.Decimal _Mensualidad;
        public System.Decimal Mensualidad
        {
            get { return _Mensualidad; }
            set { _Mensualidad = value; }
        }

        private System.Decimal _Residual;
        public System.Decimal Residual
        {
            get { return _Residual; }
            set { _Residual = value; }
        }

        private System.Decimal _Tasa;
        public System.Decimal Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }

        private System.Decimal _AmortizacionResidual;
        public System.Decimal AmortizacionResidual
        {
            get { return _AmortizacionResidual; }
            set { _AmortizacionResidual = value; }
        }

        private System.String _EstatusFinanciero;
        public System.String EstatusFinanciero
        {
            get { return _EstatusFinanciero; }
            set { _EstatusFinanciero = value; }
        }

        private System.Decimal _MontoPagado;
        public System.Decimal MontoPagado
        {
            get { return _MontoPagado; }
            set { _MontoPagado = value; }
        }

        private System.Decimal _Saldo;
        public System.Decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.Int32 _PlazosRestantes;
        public System.Int32 PlazosRestantes
        {
            get { return _PlazosRestantes; }
            set { _PlazosRestantes = value; }
        }

        private System.DateTime _FechaInicial;
        public System.DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime _FechaFinal;
        public System.DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        private System.DateTime _UltimaFecha;
        public System.DateTime UltimaFecha
        {
            get { return _UltimaFecha; }
            set { _UltimaFecha = value; }
        }

        private System.DateTime _ProximaFecha;
        public System.DateTime ProximaFecha
        {
            get { return _ProximaFecha; }
            set { _ProximaFecha = value; }
        }

        private System.Boolean _Activo;
        public System.Boolean Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }


        public static List<Vista_Arrendamientos> Get(System.Int32? arrendamiento_id, System.String descripcion,
            System.Int32? arrendador_id, System.Int32? arrendatario_id)
        {
            string sqlstr = "SELECT	A.Arrendamiento_ID, A.Descripcion, A.Referencia, A.CatalogoReferencia, \r\n" +
            "		E.Nombre Arrendador, EE.Nombre Arrendatario, A.MontoAFinanciar,  \r\n" +
            "		A.ValorFactura, A.Plazos, A.Mensualidad, A.Residual, \r\n" +
            "		A.Tasa, A.AmortizacionResidual, EF.Nombre EstatusFinanciero, \r\n" +
            "		A.MontoPagado, A.Saldo, A.PlazosRestantes, A.FechaInicial, A.FechaFinal, \r\n" +
            "		A.UltimaFecha, A.ProximaFecha, A.Activo, A.Comentarios \r\n" +
            "FROM	Arrendamientos A \r\n" +
            "INNER JOIN	EstatusFinancieros EF \r\n" +
            "ON		A.EstatusFinanciero_ID = EF.EstatusFinanciero_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		A.Arrendador_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Empresas EE \r\n" +
            "ON		A.Arrendatario_ID = EE.Empresa_ID \r\n" +
            "WHERE	(@Arrendamiento_ID IS NULL OR A.Arrendamiento_ID = @Arrendamiento_ID) \r\n" +
            "AND		(@Descripcion IS NULL OR A.Descripcion = @Descripcion) \r\n" +
            "AND		(@Arrendador_ID IS NULL OR A.Arrendador_ID = @Arrendador_ID) \r\n" +
            "AND		(@Arrendatario_ID IS NULL OR A.Arrendatario_ID = @Arrendatario_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Arrendamiento_ID", arrendamiento_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@Arrendador_ID", arrendador_id);
            m_params.Add("@Arrendatario_ID", arrendatario_id);

            List<Vista_Arrendamientos> list = new List<Vista_Arrendamientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Arrendamientos(Convert.ToInt32(dr["Arrendamiento_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Referencia"]), Convert.ToString(dr["CatalogoReferencia"]), Convert.ToString(dr["Arrendador"]), Convert.ToString(dr["Arrendatario"]), Convert.ToDecimal(dr["MontoAFinanciar"]), Convert.ToDecimal(dr["ValorFactura"]), Convert.ToInt32(dr["Plazos"]), Convert.ToDecimal(dr["Mensualidad"]), Convert.ToDecimal(dr["Residual"]), Convert.ToDecimal(dr["Tasa"]), Convert.ToDecimal(dr["AmortizacionResidual"]), Convert.ToString(dr["EstatusFinanciero"]), Convert.ToDecimal(dr["MontoPagado"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToInt32(dr["PlazosRestantes"]), Convert.ToDateTime(dr["FechaInicial"]), Convert.ToDateTime(dr["FechaFinal"]), Convert.ToDateTime(dr["UltimaFecha"]), Convert.ToDateTime(dr["ProximaFecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? arrendamiento_id, System.String descripcion,
            System.Int32? arrendador_id, System.Int32? arrendatario_id)
        {
            string sqlstr = "SELECT	A.Arrendamiento_ID, A.Descripcion, A.Referencia, A.CatalogoReferencia, \r\n" +
            "		E.Nombre Arrendador, EE.Nombre Arrendatario, A.MontoAFinanciar,  \r\n" +
            "		A.ValorFactura, A.Plazos, A.Mensualidad, A.Residual, \r\n" +
            "		A.Tasa, A.AmortizacionResidual, EF.Nombre EstatusFinanciero, \r\n" +
            "		A.MontoPagado, A.Saldo, A.PlazosRestantes, A.FechaInicial, A.FechaFinal, \r\n" +
            "		A.UltimaFecha, A.ProximaFecha, A.Activo, A.Comentarios \r\n" +
            "FROM	Arrendamientos A \r\n" +
            "INNER JOIN	EstatusFinancieros EF \r\n" +
            "ON		A.EstatusFinanciero_ID = EF.EstatusFinanciero_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		A.Arrendador_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Empresas EE \r\n" +
            "ON		A.Arrendatario_ID = EE.Empresa_ID \r\n" +
            "WHERE	(@Arrendamiento_ID IS NULL OR A.Arrendamiento_ID = @Arrendamiento_ID) \r\n" +
            "AND		(@Descripcion IS NULL OR A.Descripcion = @Descripcion) \r\n" +
            "AND		(@Arrendador_ID IS NULL OR A.Arrendador_ID = @Arrendador_ID) \r\n" +
            "AND		(@Arrendatario_ID IS NULL OR A.Arrendatario_ID = @Arrendatario_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Arrendamiento_ID", arrendamiento_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@Arrendador_ID", arrendador_id);
            m_params.Add("@Arrendatario_ID", arrendatario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Arrendamientos

    /*
    /// <summary>
    /// Consulta las unidades para visualización del usuario,
    /// con los datos referidos de otras tablas
    /// </summary>
    public class Vista_Unidades
    {

        #region Constructors
        public Vista_Unidades()
        {
        }

        public Vista_Unidades(
           System.Int32? unidad_id,
           System.String empresa,
           System.String estacion,
           System.Int32? numeroeconomico,
           System.String descripcion,
           System.Int32? anio,
           System.Decimal? preciolista,
           System.String numeroserie,
           System.String numeroseriemotor,
           System.String tarjetacirculacion,
           System.String estatus,
           System.String locacion,
           System.String placas,
           System.Int32? kilometraje,
           System.String propietario,
           System.Int32? arrendamiento_id,
           System.String arrendamiento,
           System.Int32? concesion_id,
           System.String numeroconcesion,
           System.String conductorrfc,
           System.String conductor
           )
        {
           this.Unidad_ID = unidad_id;
           this.Empresa = empresa;
           this.Estacion = estacion;
           this.NumeroEconomico = numeroeconomico;
           this.Descripcion = descripcion;
           this.Anio = anio;
           this.PrecioLista = preciolista;
           this.NumeroSerie = numeroserie;
           this.NumeroSerieMotor = numeroseriemotor;
           this.TarjetaCirculacion = tarjetacirculacion;
           this.Estatus = estatus;
           this.Locacion = locacion;
           this.Placas = placas;
           this.Kilometraje = kilometraje;
           this.Propietario = propietario;
           this.Arrendamiento_ID = arrendamiento_id;
           this.Arrendamiento = arrendamiento;
           this.Concesion_ID = concesion_id;
           this.NumeroConcesion = numeroconcesion;
           this.ConductorRFC = conductorrfc;
           this.Conductor = conductor;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
           get { return _Unidad_ID; }
           set { _Unidad_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
           get { return _Empresa; }
           set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
           get { return _Estacion; }
           set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
           get { return _NumeroEconomico; }
           set { _NumeroEconomico = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
           get { return _Descripcion; }
           set { _Descripcion = value; }
        }

        private System.Int32? _Anio;
        public System.Int32? Anio
        {
           get { return _Anio; }
           set { _Anio = value; }
        }

        private System.Decimal? _PrecioLista;
        public System.Decimal? PrecioLista
        {
           get { return _PrecioLista; }
           set { _PrecioLista = value; }
        }

        private System.String _NumeroSerie;
        public System.String NumeroSerie
        {
           get { return _NumeroSerie; }
           set { _NumeroSerie = value; }
        }

        private System.String _NumeroSerieMotor;
        public System.String NumeroSerieMotor
        {
           get { return _NumeroSerieMotor; }
           set { _NumeroSerieMotor = value; }
        }

        private System.String _TarjetaCirculacion;
        public System.String TarjetaCirculacion
        {
           get { return _TarjetaCirculacion; }
           set { _TarjetaCirculacion = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
           get { return _Estatus; }
           set { _Estatus = value; }
        }

        private System.String _Locacion;
        public System.String Locacion
        {
           get { return _Locacion; }
           set { _Locacion = value; }
        }

        private System.String _Placas;
        public System.String Placas
        {
           get { return _Placas; }
           set { _Placas = value; }
        }

        private System.Int32? _Kilometraje;
        public System.Int32? Kilometraje
        {
           get { return _Kilometraje; }
           set { _Kilometraje = value; }
        }

        private System.String _Propietario;
        public System.String Propietario
        {
           get { return _Propietario; }
           set { _Propietario = value; }
        }

        private System.Int32? _Arrendamiento_ID;
        public System.Int32? Arrendamiento_ID
        {
           get { return _Arrendamiento_ID; }
           set { _Arrendamiento_ID = value; }
        }

        private System.String _Arrendamiento;
        public System.String Arrendamiento
        {
           get { return _Arrendamiento; }
           set { _Arrendamiento = value; }
        }

        private System.Int32? _Concesion_ID;
        public System.Int32? Concesion_ID
        {
           get { return _Concesion_ID; }
           set { _Concesion_ID = value; }
        }

        private System.String _NumeroConcesion;
        public System.String NumeroConcesion
        {
           get { return _NumeroConcesion; }
           set { _NumeroConcesion = value; }
        }

        private System.String _ConductorRFC;
        public System.String ConductorRFC
        {
           get { return _ConductorRFC; }
           set { _ConductorRFC = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
           get { return _Conductor; }
           set { _Conductor = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Unidades> Get(
           System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
           string sqlstr = @"SELECT	U.Unidad_ID,  
         E.Nombre Empresa, 
         Est.Nombre Estacion, 
         U.NumeroEconomico,  
         MU.Descripcion, 
         MU.Anio, 
         U.PrecioLista, 
         U.NumeroSerie, 
         U.NumeroSerieMotor, 
         U.TarjetaCirculacion, 
         EU.Nombre Estatus, 
         LU.Nombre Locacion, 
         U.Placas, 
         ISNULL(U.Kilometraje,0) Kilometraje, 
         Em.Nombre Propietario, 
         U.Arrendamiento_ID, 
         A.Descripcion Arrendamiento, 
         U.Concesion_ID, 
         C.NumeroConcesion,
         COND.RFC ConductorRFC,
         COND.Apellidos + ' ' + COND.Nombre Conductor
 FROM	Unidades U 
 INNER JOIN	Empresas E 
 ON		U.Empresa_ID = E.Empresa_ID 
 INNER JOIN	Estaciones Est 
 ON		U.Estacion_ID = Est.Estacion_ID 
 INNER JOIN	ModelosUnidades MU 
 ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID 
 INNER JOIN	EstatusUnidades EU 
 ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID 
 INNER JOIN	LocacionesUnidades LU 
 ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID 
 INNER JOIN	Empresas Em 
 ON		U.Propietario_ID = Em.Empresa_ID 
 LEFT JOIN	Arrendamientos A 
 ON		U.Arrendamiento_ID = A.Arrendamiento_ID 
 LEFT JOIN	Concesiones C 
 ON		U.Concesion_ID = C.Concesion_ID 
 LEFT JOIN	Conductores COND
 ON		U.ConductorOperativo_ID = COND.Conductor_ID
 WHERE	(@Unidad_ID IS NULL OR U.Unidad_ID = @Unidad_ID) 
 AND		(@NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico) 
 AND		(@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID) 
 AND		(@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)";

           Hashtable m_params = new Hashtable();
           m_params.Add("@Unidad_ID", unidad_id);
           m_params.Add("@NumeroEconomico", numeroeconomico);
           m_params.Add("@Empresa_ID", empresa_id);
           m_params.Add("@Estacion_ID", estacion_id);

           List<Vista_Unidades> list = new List<Vista_Unidades>();
           DataTable dt = DB.QueryCommand(sqlstr, m_params);
           foreach (DataRow dr in dt.Rows)
           {
              list.Add(
                 new Vista_Unidades(
                    DB.GetNullableInt32(dr["Unidad_ID"]),
                    Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["Estacion"]),
                    DB.GetNullableInt32(dr["NumeroEconomico"]),
                    Convert.ToString(dr["Descripcion"]),
                    DB.GetNullableInt32(dr["Anio"]),
                    DB.GetNullableDecimal(dr["PrecioLista"]),
                    Convert.ToString(dr["NumeroSerie"]),
                    Convert.ToString(dr["NumeroSerieMotor"]),
                    Convert.ToString(dr["TarjetaCirculacion"]),
                    Convert.ToString(dr["Estatus"]),
                    Convert.ToString(dr["Locacion"]),
                    Convert.ToString(dr["Placas"]),
                    DB.GetNullableInt32(dr["Kilometraje"]),
                    Convert.ToString(dr["Propietario"]),
                    DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                    Convert.ToString(dr["Arrendamiento"]),
                    DB.GetNullableInt32(dr["Concesion_ID"]),
                    Convert.ToString(dr["NumeroConcesion"]),
                    Convert.ToString(dr["ConductorRFC"]),
                    Convert.ToString(dr["Conductor"])
                    )
                 );
           }
           return list;
        } // End GetData

        public static List<Vista_Unidades> GetActivas(
           System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
           string sqlstr = @"SELECT	U.Unidad_ID,  
         E.Nombre Empresa, 
         Est.Nombre Estacion, 
         U.NumeroEconomico,  
         MU.Descripcion, 
         MU.Anio, 
         U.PrecioLista, 
         U.NumeroSerie, 
         U.NumeroSerieMotor, 
         U.TarjetaCirculacion, 
         EU.Nombre Estatus, 
         LU.Nombre Locacion, 
         U.Placas, 
         ISNULL(U.Kilometraje,0) Kilometraje, 
         Em.Nombre Propietario, 
         U.Arrendamiento_ID, 
         A.Descripcion Arrendamiento, 
         U.Concesion_ID, 
         C.NumeroConcesion,
         COND.RFC ConductorRFC,
         COND.Apellidos + ' ' + COND.Nombre Conductor
 FROM	Unidades U 
 INNER JOIN	Empresas E 
 ON		U.Empresa_ID = E.Empresa_ID 
 INNER JOIN	Estaciones Est 
 ON		U.Estacion_ID = Est.Estacion_ID 
 INNER JOIN	ModelosUnidades MU 
 ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID 
 INNER JOIN	EstatusUnidades EU 
 ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID 
 INNER JOIN	LocacionesUnidades LU 
 ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID 
 INNER JOIN	Empresas Em 
 ON		U.Propietario_ID = Em.Empresa_ID 
 LEFT JOIN	Arrendamientos A 
 ON		U.Arrendamiento_ID = A.Arrendamiento_ID 
 LEFT JOIN	Concesiones C 
 ON		U.Concesion_ID = C.Concesion_ID 
 LEFT JOIN	Conductores COND
 ON		U.ConductorOperativo_ID = COND.Conductor_ID
 WHERE	(@Unidad_ID IS NULL OR U.Unidad_ID = @Unidad_ID) 
 AND		(@NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico) 
 AND		(@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID) 
 AND		(@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)
 AND     U.EstatusUnidad_ID NOT IN (4,5,6,8,9)";

           Hashtable m_params = new Hashtable();
           m_params.Add("@Unidad_ID", unidad_id);
           m_params.Add("@NumeroEconomico", numeroeconomico);
           m_params.Add("@Empresa_ID", empresa_id);
           m_params.Add("@Estacion_ID", estacion_id);

           List<Vista_Unidades> list = new List<Vista_Unidades>();
           DataTable dt = DB.QueryCommand(sqlstr, m_params);
           foreach (DataRow dr in dt.Rows)
           {
              list.Add(
                 new Vista_Unidades(
                    DB.GetNullableInt32(dr["Unidad_ID"]),
                    Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["Estacion"]),
                    DB.GetNullableInt32(dr["NumeroEconomico"]),
                    Convert.ToString(dr["Descripcion"]),
                    DB.GetNullableInt32(dr["Anio"]),
                    DB.GetNullableDecimal(dr["PrecioLista"]),
                    Convert.ToString(dr["NumeroSerie"]),
                    Convert.ToString(dr["NumeroSerieMotor"]),
                    Convert.ToString(dr["TarjetaCirculacion"]),
                    Convert.ToString(dr["Estatus"]),
                    Convert.ToString(dr["Locacion"]),
                    Convert.ToString(dr["Placas"]),
                    DB.GetNullableInt32(dr["Kilometraje"]),
                    Convert.ToString(dr["Propietario"]),
                    DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                    Convert.ToString(dr["Arrendamiento"]),
                    DB.GetNullableInt32(dr["Concesion_ID"]),
                    Convert.ToString(dr["NumeroConcesion"]),
                    Convert.ToString(dr["ConductorRFC"]),
                    Convert.ToString(dr["Conductor"])
                    )
                 );
           }
           return list;
        } // End GetData

        public static List<Vista_Unidades> GetActivas()
        {
           string sqlstr = @"SELECT	U.Unidad_ID,  
         E.Nombre Empresa, 
         Est.Nombre Estacion, 
         U.NumeroEconomico,  
         MU.Descripcion, 
         MU.Anio, 
         U.PrecioLista, 
         U.NumeroSerie, 
         U.NumeroSerieMotor, 
         U.TarjetaCirculacion, 
         EU.Nombre Estatus, 
         LU.Nombre Locacion, 
         U.Placas, 
         ISNULL(U.Kilometraje,0) Kilometraje, 
         Em.Nombre Propietario, 
         U.Arrendamiento_ID, 
         A.Descripcion Arrendamiento, 
         U.Concesion_ID, 
         C.NumeroConcesion,
         COND.RFC ConductorRFC,
         COND.Apellidos + ' ' + COND.Nombre Conductor
 FROM	Unidades U 
 INNER JOIN	Empresas E 
 ON		U.Empresa_ID = E.Empresa_ID 
 INNER JOIN	Estaciones Est 
 ON		U.Estacion_ID = Est.Estacion_ID 
 INNER JOIN	ModelosUnidades MU 
 ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID 
 INNER JOIN	EstatusUnidades EU 
 ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID 
 INNER JOIN	LocacionesUnidades LU 
 ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID 
 INNER JOIN	Empresas Em 
 ON		U.Propietario_ID = Em.Empresa_ID 
 LEFT JOIN	Arrendamientos A 
 ON		U.Arrendamiento_ID = A.Arrendamiento_ID 
 LEFT JOIN	Concesiones C 
 ON		U.Concesion_ID = C.Concesion_ID 
 LEFT JOIN	Conductores COND
 ON		U.ConductorOperativo_ID = COND.Conductor_ID
 AND     U.EstatusUnidad_ID NOT IN (4,5,6,8,9)";

           Hashtable m_params = new Hashtable();

           List<Vista_Unidades> list = new List<Vista_Unidades>();
           DataTable dt = DB.QueryCommand(sqlstr, m_params);
           foreach (DataRow dr in dt.Rows)
           {
              list.Add(
                 new Vista_Unidades(
                    DB.GetNullableInt32(dr["Unidad_ID"]),
                    Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["Estacion"]),
                    DB.GetNullableInt32(dr["NumeroEconomico"]),
                    Convert.ToString(dr["Descripcion"]),
                    DB.GetNullableInt32(dr["Anio"]),
                    DB.GetNullableDecimal(dr["PrecioLista"]),
                    Convert.ToString(dr["NumeroSerie"]),
                    Convert.ToString(dr["NumeroSerieMotor"]),
                    Convert.ToString(dr["TarjetaCirculacion"]),
                    Convert.ToString(dr["Estatus"]),
                    Convert.ToString(dr["Locacion"]),
                    Convert.ToString(dr["Placas"]),
                    DB.GetNullableInt32(dr["Kilometraje"]),
                    Convert.ToString(dr["Propietario"]),
                    DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                    Convert.ToString(dr["Arrendamiento"]),
                    DB.GetNullableInt32(dr["Concesion_ID"]),
                    Convert.ToString(dr["NumeroConcesion"]),
                    Convert.ToString(dr["ConductorRFC"]),
                    Convert.ToString(dr["Conductor"])
                    )
                 );
           }
           return list;
        } // End GetData

        public static DataTable GetDataTable(
           System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
           string sqlstr = @"SELECT	U.Unidad_ID,  
         E.Nombre Empresa, 
         Est.Nombre Estacion, 
         U.NumeroEconomico,  
         MU.Descripcion, 
         MU.Anio, 
         U.PrecioLista, 
         U.NumeroSerie, 
         U.NumeroSerieMotor, 
         U.TarjetaCirculacion, 
         EU.Nombre Estatus, 
         LU.Nombre Locacion, 
         U.Placas, 
         ISNULL(U.Kilometraje,0) Kilometraje, 
         Em.Nombre Propietario, 
         U.Arrendamiento_ID, 
         A.Descripcion Arrendamiento, 
         U.Concesion_ID, 
         C.NumeroConcesion,
         COND.RFC ConductorRFC,
         COND.Apellidos + ' ' + COND.Nombre Conductor
 FROM	Unidades U 
 INNER JOIN	Empresas E 
 ON		U.Empresa_ID = E.Empresa_ID 
 INNER JOIN	Estaciones Est 
 ON		U.Estacion_ID = Est.Estacion_ID 
 INNER JOIN	ModelosUnidades MU 
 ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID 
 INNER JOIN	EstatusUnidades EU 
 ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID 
 INNER JOIN	LocacionesUnidades LU 
 ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID 
 INNER JOIN	Empresas Em 
 ON		U.Propietario_ID = Em.Empresa_ID 
 LEFT JOIN	Arrendamientos A 
 ON		U.Arrendamiento_ID = A.Arrendamiento_ID 
 LEFT JOIN	Concesiones C 
 ON		U.Concesion_ID = C.Concesion_ID 
 LEFT JOIN	Conductores COND
 ON		U.ConductorOperativo_ID = COND.Conductor_ID
 WHERE	(@Unidad_ID IS NULL OR U.Unidad_ID = @Unidad_ID) 
 AND		(@NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico) 
 AND		(@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID) 
 AND		(@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)";

           Hashtable m_params = new Hashtable();
           m_params.Add("@Unidad_ID", unidad_id);
           m_params.Add("@NumeroEconomico", numeroeconomico);
           m_params.Add("@Empresa_ID", empresa_id);
           m_params.Add("@Estacion_ID", estacion_id);

           return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Unidades
    */

    public class Vista_Unidades
    {

        #region Constructors
        public Vista_Unidades()
        {
        }

        public Vista_Unidades(
            System.Int32? unidad_id,
            System.String empresa,
            System.String estacion,
            System.Int32? numeroeconomico,
            System.String descripcion,
            System.Int32? anio,
            System.Decimal? preciolista,
            System.String numeroserie,
            System.String numeroseriemotor,
            System.String tarjetacirculacion,
            System.String estatus,
            System.String locacion,
            System.String placas,
            System.Int32? kilometraje,
            System.String propietario,
            System.Int32? arrendamiento_id,
            System.String arrendamiento,
            System.Int32? concesion_id,
            System.String numeroconcesion,
            System.String conductorrfc,
            System.String conductor,
            System.String gps,
            System.Int32? modelounidad_id,
            System.String modelounidad
            )
        {
            this.Unidad_ID = unidad_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.NumeroEconomico = numeroeconomico;
            this.Descripcion = descripcion;
            this.Anio = anio;
            this.PrecioLista = preciolista;
            this.NumeroSerie = numeroserie;
            this.NumeroSerieMotor = numeroseriemotor;
            this.TarjetaCirculacion = tarjetacirculacion;
            this.Estatus = estatus;
            this.Locacion = locacion;
            this.Placas = placas;
            this.Kilometraje = kilometraje;
            this.Propietario = propietario;
            this.Arrendamiento_ID = arrendamiento_id;
            this.Arrendamiento = arrendamiento;
            this.Concesion_ID = concesion_id;
            this.NumeroConcesion = numeroconcesion;
            this.ConductorRFC = conductorrfc;
            this.Conductor = conductor;
            this.GPS = gps;
            this.ModeloUnidad_ID = modelounidad_id;
            this.ModeloUnidad = modelounidad;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Int32? _Anio;
        public System.Int32? Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private System.Decimal? _PrecioLista;
        public System.Decimal? PrecioLista
        {
            get { return _PrecioLista; }
            set { _PrecioLista = value; }
        }

        private System.String _NumeroSerie;
        public System.String NumeroSerie
        {
            get { return _NumeroSerie; }
            set { _NumeroSerie = value; }
        }

        private System.String _NumeroSerieMotor;
        public System.String NumeroSerieMotor
        {
            get { return _NumeroSerieMotor; }
            set { _NumeroSerieMotor = value; }
        }

        private System.String _TarjetaCirculacion;
        public System.String TarjetaCirculacion
        {
            get { return _TarjetaCirculacion; }
            set { _TarjetaCirculacion = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.String _Locacion;
        public System.String Locacion
        {
            get { return _Locacion; }
            set { _Locacion = value; }
        }

        private System.String _Placas;
        public System.String Placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }

        private System.Int32? _Kilometraje;
        public System.Int32? Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }

        private System.String _Propietario;
        public System.String Propietario
        {
            get { return _Propietario; }
            set { _Propietario = value; }
        }

        private System.Int32? _Arrendamiento_ID;
        public System.Int32? Arrendamiento_ID
        {
            get { return _Arrendamiento_ID; }
            set { _Arrendamiento_ID = value; }
        }

        private System.String _Arrendamiento;
        public System.String Arrendamiento
        {
            get { return _Arrendamiento; }
            set { _Arrendamiento = value; }
        }

        private System.Int32? _Concesion_ID;
        public System.Int32? Concesion_ID
        {
            get { return _Concesion_ID; }
            set { _Concesion_ID = value; }
        }

        private System.String _NumeroConcesion;
        public System.String NumeroConcesion
        {
            get { return _NumeroConcesion; }
            set { _NumeroConcesion = value; }
        }

        private System.String _ConductorRFC;
        public System.String ConductorRFC
        {
            get { return _ConductorRFC; }
            set { _ConductorRFC = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _GPS;
        public System.String GPS
        {
            get { return _GPS; }
            set { _GPS = value; }
        }

        private System.Int32? _ModeloUnidad_ID;
        public System.Int32? ModeloUnidad_ID
        {
            get { return _ModeloUnidad_ID; }
            set { _ModeloUnidad_ID = value; }
        }

        private System.String _ModeloUnidad;
        public System.String ModeloUnidad
        {
            get { return _ModeloUnidad; }
            set { _ModeloUnidad = value; }
        }
        #endregion

        #region Methods
        public static List<Vista_Unidades> Get(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Vista_Unidades";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Unidades> list = new List<Vista_Unidades>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Unidades(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       DB.GetNullableDecimal(dr["PrecioLista"]),
                       Convert.ToString(dr["NumeroSerie"]),
                       Convert.ToString(dr["NumeroSerieMotor"]),
                       Convert.ToString(dr["TarjetaCirculacion"]),
                       Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Placas"]),
                       DB.GetNullableInt32(dr["Kilometraje"]),
                       Convert.ToString(dr["Propietario"]),
                       DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                       Convert.ToString(dr["Arrendamiento"]),
                       DB.GetNullableInt32(dr["Concesion_ID"]),
                       Convert.ToString(dr["NumeroConcesion"]),
                       Convert.ToString(dr["ConductorRFC"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["GPS"]),
                       DB.GetNullableInt32(dr["ModeloUnidad_ID"]),
                       Convert.ToString(dr["Descripcion"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Unidades> GetActivas(
     System.Int32? unidad_id,
      System.Int32? numeroeconomico,
      System.Int32? empresa_id,
      System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Vista_UnidadesActivas";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Unidades> list = new List<Vista_Unidades>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Unidades(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       DB.GetNullableDecimal(dr["PrecioLista"]),
                       Convert.ToString(dr["NumeroSerie"]),
                       Convert.ToString(dr["NumeroSerieMotor"]),
                       Convert.ToString(dr["TarjetaCirculacion"]),
                       Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Placas"]),
                       DB.GetNullableInt32(dr["Kilometraje"]),
                       Convert.ToString(dr["Propietario"]),
                       DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                       Convert.ToString(dr["Arrendamiento"]),
                       DB.GetNullableInt32(dr["Concesion_ID"]),
                       Convert.ToString(dr["NumeroConcesion"]),
                       Convert.ToString(dr["ConductorRFC"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["GPS"]),
                       DB.GetNullableInt32(dr["ModeloUnidad_ID"]),
                       Convert.ToString(dr["Descripcion"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Unidades> GetActivas()
        {
            string sqlstr = @"usp_Vista_UnidadesActivas";

            Hashtable m_params = new Hashtable();

            List<Vista_Unidades> list = new List<Vista_Unidades>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Unidades(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       Convert.ToString(dr["Empresa"]),
                       Convert.ToString(dr["Estacion"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       DB.GetNullableDecimal(dr["PrecioLista"]),
                       Convert.ToString(dr["NumeroSerie"]),
                       Convert.ToString(dr["NumeroSerieMotor"]),
                       Convert.ToString(dr["TarjetaCirculacion"]),
                       Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["Locacion"]),
                       Convert.ToString(dr["Placas"]),
                       DB.GetNullableInt32(dr["Kilometraje"]),
                       Convert.ToString(dr["Propietario"]),
                       DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                       Convert.ToString(dr["Arrendamiento"]),
                       DB.GetNullableInt32(dr["Concesion_ID"]),
                       Convert.ToString(dr["NumeroConcesion"]),
                       Convert.ToString(dr["ConductorRFC"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["GPS"]),
                       DB.GetNullableInt32(dr["ModeloUnidad_ID"]),
                       Convert.ToString(dr["Descripcion"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? empresa_id,
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Vista_Unidades";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_Unidades

    public class Vista_Contratos
    {

        public Vista_Contratos()
        {
        }

        public Vista_Contratos(System.Int32 contrato_id, System.String empresa, System.String estacion, System.String tipo, System.String descripcion,
            System.String modelo, System.Decimal montodiario, System.String diascobro, System.Decimal fondoresidual, System.String conductor,
            System.Int32? unidad, System.String cuenta, System.String concepto, System.DateTime fechainicial, System.DateTime? fechafinal,
            System.String estatus, System.String comentarios, System.String conductorcopia)
        {
            this.Contrato_ID = contrato_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Tipo = tipo;
            this.Descripcion = descripcion;
            this.Modelo = modelo;
            this.MontoDiario = montodiario;
            this.DiasCobro = diascobro;
            this.FondoResidual = fondoresidual;
            this.Conductor = conductor;
            this.Unidad = unidad;
            this.Cuenta = cuenta;
            this.Concepto = concepto;
            this.FechaInicial = fechainicial;
            this.FechaFinal = fechafinal;
            this.Estatus = estatus;
            this.Comentarios = comentarios;
            this.ConductorCopia = conductorcopia;
        }

        private System.Int32 _Contrato_ID;
        public System.Int32 Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.Decimal _MontoDiario;
        public System.Decimal MontoDiario
        {
            get { return _MontoDiario; }
            set { _MontoDiario = value; }
        }

        private System.String _DiasCobro;
        public System.String DiasCobro
        {
            get { return _DiasCobro; }
            set { _DiasCobro = value; }
        }

        private System.Decimal _FondoResidual;
        public System.Decimal FondoResidual
        {
            get { return _FondoResidual; }
            set { _FondoResidual = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.String _Concepto;
        public System.String Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private System.DateTime _FechaInicial;
        public System.DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime? _FechaFinal;
        public System.DateTime? FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        private System.String _ConductorCopia;
        public System.String ConductorCopia
        {
            get { return _ConductorCopia; }
            set { _ConductorCopia = value; }
        }

        public static List<Vista_Contratos> Get(System.Int32 contrato_id)
        {
            string sqlstr = @"SELECT	C.Contrato_ID, E.Nombre Empresa, Est.Nombre Estacion, TC.Nombre Tipo,
		C.Descripcion, MU.Descripcion Modelo, C.MontoDiario, DC.Nombre DiasCobro,
		C.FondoResidual, Co.Apellidos + ' ' + Co.Nombre Conductor,
		U.NumeroEconomico Unidad, Cu.Nombre Cuenta, Con.Nombre Concepto,
		C.FechaInicial, C.FechaFinal, EC.Nombre Estatus, C.Comentarios,
		CC.Apellidos + ' ' + CC.Nombre ConductorCopia
FROM	Contratos C
INNER JOIN	Empresas E
ON		C.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	TiposContratos TC
ON		TC.TipoContrato_ID = C.TipoContrato_ID
LEFT JOIN	ModelosUnidades MU
ON		MU.ModeloUnidad_ID = C.ModeloUnidad_ID
INNER JOIN	DiasDeCobros DC
ON		DC.DiasDeCobro_ID = C.DiasDeCobro_ID
INNER JOIN	Conductores Co
ON		Co.Conductor_ID = C.Conductor_ID	
LEFT JOIN	Unidades U
ON		C.Unidad_ID = U.Unidad_ID
INNER JOIN	Cuentas Cu
ON		C.Cuenta_ID = Cu.Cuenta_ID
INNER JOIN	Conceptos Con
ON		C.Concepto_ID = Con.Concepto_ID
INNER JOIN	EstatusContratos EC
ON		C.EstatusContrato_ID = EC.EstatusContrato_ID
LEFT JOIN	Conductores CC
ON		C.ConductorCopia_ID = CC.Conductor_ID
WHERE	( C.Contrato_ID = @Contrato_ID ) --AND C.TipoContrato_ID IN (1,2)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Contrato_ID", contrato_id);

            List<Vista_Contratos> list = new List<Vista_Contratos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"]),
                    Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Modelo"]), Convert.ToDecimal(dr["MontoDiario"]),
                    Convert.ToString(dr["DiasCobro"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToString(dr["Conductor"]),
                    DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["Cuenta"]), Convert.ToString(dr["Concepto"]), Convert.ToDateTime(dr["FechaInicial"]),
                    DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["Estatus"]), Convert.ToString(dr["Comentarios"]),
                    Convert.ToString(dr["ConductorCopia"])));
            }
            return list;
        } // End GetData

        public static List<Vista_Contratos> Get(System.Int32? contrato_id, System.Int32? empresa_id, System.Int32? estacion_id,
            System.String descripcion, System.Int32? numeroeconomico, bool incluirterminados, string usuario_id)
        {
            string sqlstr = @"SELECT	C.Contrato_ID, E.Nombre Empresa, Est.Nombre Estacion, TC.Nombre Tipo,
            		C.Descripcion, MU.Descripcion Modelo, C.MontoDiario, DC.Nombre DiasCobro,
            		C.FondoResidual, Co.Apellidos + ' ' + Co.Nombre Conductor,
            		U.NumeroEconomico Unidad, Cu.Nombre Cuenta, Con.Nombre Concepto,
            		C.FechaInicial, C.FechaFinal, EC.Nombre Estatus, C.Comentarios,
            		CC.Apellidos + ' ' + CC.Nombre ConductorCopia
            FROM	Contratos C
            INNER JOIN	Empresas E
            ON		C.Empresa_ID = E.Empresa_ID
            INNER JOIN	Estaciones Est
            ON		C.Estacion_ID = Est.Estacion_ID
            INNER JOIN	TiposContratos TC
            ON		TC.TipoContrato_ID = C.TipoContrato_ID
            LEFT JOIN	ModelosUnidades MU
            ON		MU.ModeloUnidad_ID = C.ModeloUnidad_ID
            INNER JOIN	DiasDeCobros DC
            ON		DC.DiasDeCobro_ID = C.DiasDeCobro_ID
            INNER JOIN	Conductores Co
            ON		Co.Conductor_ID = C.Conductor_ID	
            LEFT JOIN	Unidades U
            ON		C.Unidad_ID = U.Unidad_ID
            INNER JOIN	Cuentas Cu
            ON		C.Cuenta_ID = Cu.Cuenta_ID
            INNER JOIN	Conceptos Con
            ON		C.Concepto_ID = Con.Concepto_ID
            INNER JOIN	EstatusContratos EC
            ON		C.EstatusContrato_ID = EC.EstatusContrato_ID
            LEFT JOIN	Conductores CC
            ON		C.ConductorCopia_ID = CC.Conductor_ID
            WHERE	( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
            AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
            AND     ( @Contrato_ID IS NULL OR C.Contrato_ID = @Contrato_ID )
            AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID )
            AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
            AND		( @Descripcion IS NULL OR C.Descripcion LIKE @Descripcion + '%')
            AND		( @NumeroEconomico IS NULL OR C.NumeroEconomico = @NumeroEconomico )
			--AND C.TipoContrato_ID IN (1,2)";

            if (!incluirterminados)
                sqlstr += "\r\nAND C.EstatusContrato_ID = 1";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Contrato_ID", contrato_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_Contratos> list = new List<Vista_Contratos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"]),
                    Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Modelo"]), Convert.ToDecimal(dr["MontoDiario"]),
                    Convert.ToString(dr["DiasCobro"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToString(dr["Conductor"]),
                    DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["Cuenta"]), Convert.ToString(dr["Concepto"]), Convert.ToDateTime(dr["FechaInicial"]),
                    DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["Estatus"]), Convert.ToString(dr["Comentarios"]),
                    Convert.ToString(dr["ConductorCopia"])));
            }
            return list;
        } // End GetData

        public static List<Vista_Contratos> Get(System.Int32? contrato_id, System.Int32? empresa_id, System.Int32? estacion_id,
            System.String descripcion, System.Int32? numeroeconomico)
        {
            string sqlstr = @"SELECT	C.Contrato_ID, E.Nombre Empresa, Est.Nombre Estacion, TC.Nombre Tipo,
		C.Descripcion, MU.Descripcion Modelo, C.MontoDiario, DC.Nombre DiasCobro,
		C.FondoResidual, Co.Apellidos + ' ' + Co.Nombre Conductor,
		U.NumeroEconomico Unidad, Cu.Nombre Cuenta, Con.Nombre Concepto,
		C.FechaInicial, C.FechaFinal, EC.Nombre Estatus, C.Comentarios,
		CC.Apellidos + ' ' + CC.Nombre ConductorCopia
FROM	Contratos C
INNER JOIN	Empresas E
ON		C.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones Est
ON		C.Estacion_ID = Est.Estacion_ID
INNER JOIN	TiposContratos TC
ON		TC.TipoContrato_ID = C.TipoContrato_ID
LEFT JOIN	ModelosUnidades MU
ON		MU.ModeloUnidad_ID = C.ModeloUnidad_ID
INNER JOIN	DiasDeCobros DC
ON		DC.DiasDeCobro_ID = C.DiasDeCobro_ID
INNER JOIN	Conductores Co
ON		Co.Conductor_ID = C.Conductor_ID	
LEFT JOIN	Unidades U
ON		C.Unidad_ID = U.Unidad_ID
INNER JOIN	Cuentas Cu
ON		C.Cuenta_ID = Cu.Cuenta_ID
INNER JOIN	Conceptos Con
ON		C.Concepto_ID = Con.Concepto_ID
INNER JOIN	EstatusContratos EC
ON		C.EstatusContrato_ID = EC.EstatusContrato_ID
LEFT JOIN	Conductores CC
ON		C.ConductorCopia_ID = CC.Conductor_ID
WHERE	( @Contrato_ID IS NULL OR C.Contrato_ID = @Contrato_ID )
AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
AND		( @Descripcion IS NULL OR C.Descripcion LIKE @Descripcion + '%')
AND		( @NumeroEconomico IS NULL OR C.NumeroEconomico = @NumeroEconomico )
AND     ( C.EstatusContrato_ID = 1 ) --AND C.TipoContrato_ID IN (1,2)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Contrato_ID", contrato_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<Vista_Contratos> list = new List<Vista_Contratos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"]),
                    Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Modelo"]), Convert.ToDecimal(dr["MontoDiario"]),
                    Convert.ToString(dr["DiasCobro"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToString(dr["Conductor"]),
                    DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["Cuenta"]), Convert.ToString(dr["Concepto"]), Convert.ToDateTime(dr["FechaInicial"]),
                    DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["Estatus"]), Convert.ToString(dr["Comentarios"]),
                    Convert.ToString(dr["ConductorCopia"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? contrato_id, System.Int32? empresa_id, System.Int32? estacion_id,
            System.String descripcion, System.Int32? numeroeconomico)
        {
            string sqlstr = "SELECT	C.Contrato_ID, E.Nombre Empresa, Est.Nombre Estacion, TC.Nombre Tipo, \r\n" +
            "		C.Descripcion, MU.Descripcion Modelo, C.MontoDiario, DC.Nombre DiasCobro, \r\n" +
            "		C.FondoResidual, Co.Apellidos + ' ' + Co.Nombre Conductor, \r\n" +
            "		U.NumeroEconomico Unidad, Cu.Nombre Cuenta, Con.Nombre Concepto, \r\n" +
            "		C.FechaInicial, C.FechaFinal, EC.Nombre Estatus, C.Comentarios, \r\n" +
            "		CC.Apellidos + ' ' + CC.Nombre ConductorCopia \r\n" +
            "FROM	Contratos C \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		C.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones Est \r\n" +
            "ON		C.Estacion_ID = Est.Estacion_ID \r\n" +
            "INNER JOIN	TiposContratos TC \r\n" +
            "ON		TC.TipoContrato_ID = C.TipoContrato_ID \r\n" +
            "LEFT JOIN	ModelosUnidades MU \r\n" +
            "ON		MU.ModeloUnidad_ID = C.ModeloUnidad_ID \r\n" +
            "INNER JOIN	DiasDeCobros DC \r\n" +
            "ON		DC.DiasDeCobro_ID = C.DiasDeCobro_ID \r\n" +
            "INNER JOIN	Conductores Co \r\n" +
            "ON		Co.Conductor_ID = C.Conductor_ID	 \r\n" +
            "LEFT JOIN	Unidades U \r\n" +
            "ON		C.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	Cuentas Cu \r\n" +
            "ON		C.Cuenta_ID = Cu.Cuenta_ID \r\n" +
            "INNER JOIN	Conceptos Con \r\n" +
            "ON		C.Concepto_ID = Con.Concepto_ID \r\n" +
            "INNER JOIN	EstatusContratos EC \r\n" +
            "ON		C.EstatusContrato_ID = EC.EstatusContrato_ID \r\n" +
            "LEFT JOIN	Conductores CC \r\n" +
            "ON		C.ConductorCopia_ID = CC.Conductor_ID \r\n" +
            "WHERE	( @Contrato_ID IS NULL OR C.Contrato_ID = @Contrato_ID ) \r\n" +
            "AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND		( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID ) \r\n" +
            "AND		( @Descripcion IS NULL OR C.Descripcion = @Descripcion ) \r\n" +
            "AND		( @NumeroEconomico IS NULL OR C.NumeroEconomico = @NumeroEconomico )" +
            "--AND C.TipoContrato_ID IN (1,2)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Contrato_ID", contrato_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroEconomico", numeroeconomico);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Contratos

    public class OperacionCaja
    {
        private decimal _TotalAdeudos;
        public decimal TotalAdeudos
        {
            get { return _TotalAdeudos; }
            set { _TotalAdeudos = value; }
        }

        private decimal _PagoVales;
        public decimal PagoVales
        {
            get { return _PagoVales; }
            set { _PagoVales = value; }
        }

        private decimal _APagarEfectivo;
        public decimal APagarEfectivo
        {
            get { return _APagarEfectivo; }
            set { _APagarEfectivo = value; }
        }

        private decimal _PagoEfectivo;
        public decimal PagoEfectivo
        {
            get { return _PagoEfectivo; }
            set { _PagoEfectivo = value; }
        }

        private decimal _Cambio;
        public decimal Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        private decimal _TotalVales;
        public decimal TotalVales
        {
            get { return _TotalVales; }
            set { _TotalVales = value; }
        }

        private decimal _TotalValesEmpresariales;
        public decimal TotalValesEmpresariales
        {
            get { return _TotalValesEmpresariales; }
            set { _TotalValesEmpresariales = value; }
        }

        public string TotalValesCaja
        {
            get { return string.Format("{0:0.00}", _TotalVales + _TotalValesEmpresariales); }
        }

        private decimal _TotalPlanillasFiscales;
        public decimal TotalPlanillasFiscales
        {
            get { return _TotalPlanillasFiscales; }
            set { _TotalPlanillasFiscales = value; }
        }

        private decimal _TotalServicios;
        public decimal TotalServicios
        {
            get { return _TotalServicios; }
            set { _TotalServicios = value; }
        }

        private decimal _TotalConductor;
        public decimal TotalConductor
        {
            get { return _TotalConductor; }
            set { _TotalConductor = value; }
        }

        private decimal _EfectivoExterno;
        public decimal EfectivoExterno
        {
            get { return _EfectivoExterno; }
            set { _EfectivoExterno = value; }
        }
    }

    public class Get_DatosTicket
    {

        #region Constructors
        public Get_DatosTicket()
        {
        }

        public Get_DatosTicket(
            System.Int32? ticket_id,
            System.Int32? sesion_id,
            System.Int32? caja_id,
            System.Int32? conductor_id,
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.String conductor,
            System.String cuenta,
            System.String usuario_id,
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.DateTime? fecha,
            System.Int32? cuenta_id,
            System.Decimal? abono,
            System.Decimal? saldo
            )
        {
            this.Ticket_ID = ticket_id;
            this.Sesion_ID = sesion_id;
            this.Caja_ID = caja_id;
            this.Conductor_ID = conductor_id;
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor = conductor;
            this.Cuenta = cuenta;
            this.Usuario_ID = usuario_id;
            this.Empresa_ID = empresa_id;
            this.Estacion_ID = estacion_id;
            this.Fecha = fecha;
            this.Cuenta_ID = cuenta_id;
            this.Abono = abono;
            this.Saldo = saldo;
        }

        #endregion

        #region Properties
        private System.Int32? _Ticket_ID;
        public System.Int32? Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Int32? _Sesion_ID;
        public System.Int32? Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.Int32? _Caja_ID;
        public System.Int32? Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.Int32? _Estacion_ID;
        public System.Int32? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32? _Cuenta_ID;
        public System.Int32? Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.Decimal? _Abono;
        public System.Decimal? Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private System.Decimal? _Saldo;
        public System.Decimal? Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        #endregion

        #region Methods
        public static List<Get_DatosTicket> Get(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	T.Ticket_ID, T.Sesion_ID, T.Caja_ID, T.Conductor_ID, T.Unidad_ID,
		U.NumeroEconomico,
		C.Apellidos + ' ' + C.Nombre Conductor,
		CU.Nombre Cuenta,
		T.Usuario_ID, T.Empresa_ID, T.Estacion_ID, T.Fecha,
		CC.Cuenta_ID, CC.Abono, CC.Saldo
FROM	Tickets T
INNER JOIN	CuentaConductores CC
ON		T.Ticket_ID = CC.Ticket_ID
INNER JOIN	Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Conductores C
ON		C.Conductor_ID = CC.Conductor_ID
LEFT JOIN	Unidades U
ON		CC.Unidad_ID = U.Unidad_ID
WHERE	T.Ticket_ID = @Ticket_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            List<Get_DatosTicket> list = new List<Get_DatosTicket>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Get_DatosTicket(
                       DB.GetNullableInt32(dr["Ticket_ID"]),
                       DB.GetNullableInt32(dr["Sesion_ID"]),
                       DB.GetNullableInt32(dr["Caja_ID"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["Cuenta"]),
                       Convert.ToString(dr["Usuario_ID"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       DB.GetNullableInt32(dr["Estacion_ID"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       DB.GetNullableInt32(dr["Cuenta_ID"]),
                       DB.GetNullableDecimal(dr["Abono"]),
                       DB.GetNullableDecimal(dr["Saldo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? ticket_id)
        {
            string sqlstr = @"SELECT	T.Ticket_ID, T.Sesion_ID, T.Caja_ID, T.Conductor_ID, T.Unidad_ID,
		U.NumeroEconomico,
		C.Apellidos + ' ' + C.Nombre Conductor,
		CU.Nombre Cuenta,
		T.Usuario_ID, T.Empresa_ID, T.Estacion_ID, T.Fecha,
		CC.Cuenta_ID, CC.Abono, CC.Saldo
FROM	Tickets T
INNER JOIN	CuentaConductores CC
ON		T.Ticket_ID = CC.Ticket_ID
INNER JOIN	Cuentas CU
ON		CC.Cuenta_ID = CU.Cuenta_ID
INNER JOIN	Conductores C
ON		C.Conductor_ID = CC.Conductor_ID
LEFT JOIN	Unidades U
ON		CC.Unidad_ID = U.Unidad_ID
WHERE	T.Ticket_ID = @Ticket_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Get_DatosTicket



    public class SelectTiposServicios
    {
        public SelectTiposServicios()
        {
        }

        public SelectTiposServicios(System.Int32? tiposervicio_id, System.String nombre)
        {
            this.TipoServicio_ID = tiposervicio_id;
            this.Nombre = nombre;
        }

        private System.Int32? _TipoServicio_ID;
        public System.Int32? TipoServicio_ID
        {
            get { return _TipoServicio_ID; }
            set { _TipoServicio_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposServicios> Get()
        {
            string sqlstr = "SELECT	NULL TipoServicio_ID, '-TODOS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoServicio_ID, Nombre \r\n" +
            "FROM	TiposServicios";

            List<SelectTiposServicios> list = new List<SelectTiposServicios>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectTiposServicios(DB.GetNullableInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL TipoServicio_ID, '-TODOS-' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoServicio_ID, Nombre \r\n" +
            "FROM	TiposServicios";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectTiposServicios



    public class Vista_Tarifas
    {

        public Vista_Tarifas()
        {
        }

        public Vista_Tarifas(System.Int32 zona_id, System.Int32 tiposervicio_id, System.String zona, System.String tiposervicio, System.Decimal tarifa)
        {
            this.Zona_ID = zona_id;
            this.TipoServicio_ID = tiposervicio_id;
            this.Zona = zona;
            this.TipoServicio = tiposervicio;
            this.Tarifa = tarifa;
        }

        private System.Int32 _Zona_ID;
        public System.Int32 Zona_ID
        {
            get { return _Zona_ID; }
            set { _Zona_ID = value; }
        }

        private System.Int32 _TipoServicio_ID;
        public System.Int32 TipoServicio_ID
        {
            get { return _TipoServicio_ID; }
            set { _TipoServicio_ID = value; }
        }

        private System.String _Zona;
        public System.String Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        private System.String _TipoServicio;
        public System.String TipoServicio
        {
            get { return _TipoServicio; }
            set { _TipoServicio = value; }
        }

        private System.Decimal _Tarifa;
        public System.Decimal Tarifa
        {
            get { return _Tarifa; }
            set { _Tarifa = value; }
        }


        public static List<Vista_Tarifas> Get(System.String nombre, System.Int32? tiposervicio_id)
        {
            string sqlstr = "SELECT	T.Zona_ID, T.TipoServicio_ID, Z.Nombre Zona, TS.Nombre TipoServicio, T.Tarifa \r\n" +
            "FROM	Tarifas T \r\n" +
            "INNER JOIN	Zonas Z \r\n" +
            "ON		T.Zona_ID = Z.Zona_ID \r\n" +
            "INNER JOIN	TiposServicios TS \r\n" +
            "ON		T.TipoServicio_ID = TS.TipoServicio_ID \r\n" +
            "WHERE	(@Nombre IS NULL OR Z.Nombre LIKE @Nombre + '%') \r\n" +
            "AND		(@TipoServicio_ID IS NULL OR T.TipoServicio_ID = @TipoServicio_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);

            List<Vista_Tarifas> list = new List<Vista_Tarifas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Zona"]), Convert.ToString(dr["TipoServicio"]), Convert.ToDecimal(dr["Tarifa"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.String nombre, System.Int32? tiposervicio_id)
        {
            string sqlstr = "SELECT	T.Zona_ID, T.TipoServicio_ID, Z.Nombre Zona, TS.Nombre TipoServicio, T.Tarifa \r\n" +
            "FROM	Tarifas T \r\n" +
            "INNER JOIN	Zonas Z \r\n" +
            "ON		T.Zona_ID = Z.Zona_ID \r\n" +
            "INNER JOIN	TiposServicios TS \r\n" +
            "ON		T.TipoServicio_ID = TS.TipoServicio_ID \r\n" +
            "WHERE	(@Nombre IS NULL OR Z.Nombre LIKE @Nombre + '%') \r\n" +
            "AND		(@TipoServicio_ID IS NULL OR T.TipoServicio_ID = @TipoServicio_ID)";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Tarifas

    public class Vista_Zonas
    {

        public Vista_Zonas()
        {
        }

        public Vista_Zonas(System.Int32 zona_id, System.String nombre, System.String tipozona, System.String comisionservicio)
        {
            this.Zona_ID = zona_id;
            this.Nombre = nombre;
            this.TipoZona = tipozona;
            this.ComisionServicio = comisionservicio;
        }

        private System.Int32 _Zona_ID;
        public System.Int32 Zona_ID
        {
            get { return _Zona_ID; }
            set { _Zona_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _TipoZona;
        public System.String TipoZona
        {
            get { return _TipoZona; }
            set { _TipoZona = value; }
        }

        private System.String _ComisionServicio;
        public System.String ComisionServicio
        {
            get { return _ComisionServicio; }
            set { _ComisionServicio = value; }
        }


        public static List<Vista_Zonas> Get(System.String nombre)
        {
            string sqlstr = "SELECT	Z.Zona_ID, Z.Nombre, TZ.Nombre TipoZona, CS.Nombre ComisionServicio \r\n" +
            "FROM	Zonas Z \r\n" +
            "INNER JOIN TiposZonas TZ \r\n" +
            "ON		Z.TipoZona_ID = TZ.TipoZona_ID \r\n" +
            "LEFT JOIN	ComisionesServicios CS \r\n" +
            "ON		Z.ComisionServicio_ID = CS.ComisionServicio_ID \r\n" +
            "WHERE	(@Nombre IS NULL OR Z.Nombre LIKE @Nombre + '%')";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);

            List<Vista_Zonas> list = new List<Vista_Zonas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["TipoZona"]), Convert.ToString(dr["ComisionServicio"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.String nombre)
        {
            string sqlstr = "SELECT	Z.Zona_ID, Z.Nombre, TZ.Nombre TipoZona, CS.Nombre ComisionServicio \r\n" +
            "FROM	Zonas Z \r\n" +
            "INNER JOIN TiposZonas TZ \r\n" +
            "ON		Z.TipoZona_ID = TZ.TipoZona_ID \r\n" +
            "LEFT JOIN	ComisionesServicios CS \r\n" +
            "ON		Z.ComisionServicio_ID = CS.ComisionServicio_ID \r\n" +
            "WHERE	(@Nombre IS NULL OR Z.Nombre LIKE @Nombre + '%')";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Zonas

    public class SelectEstaciones
    {

        public SelectEstaciones()
        {
        }

        public SelectEstaciones(System.Int32? estacion_id, System.String nombre)
        {
            this.Estacion_ID = estacion_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Estacion_ID;
        public System.Int32? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public static List<SelectEstaciones> GetUnionAll()
        {
            string sqlstr;
            sqlstr = @"SELECT NULL Estacion_ID, '- TODAS -' Nombre
UNION ALL
SELECT	Estacion_ID, Nombre
FROM	Estaciones
WHERE   Activo = 1";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt = DB.Query(sqlstr);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> GetUnionAllEmpresa()
        {
            string sqlstr;
            sqlstr = @"SELECT NULL Estacion_ID, '- TODAS -' Nombre
UNION ALL
SELECT	Estacion_ID, Nombre
FROM	Estaciones
WHERE   Activo = 1
AND     ( @Empresa_ID IS NULL OR Empresa_ID = @Empresa_ID )";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Empresa_ID",
                         Sesion.Empresa_ID
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> GetAll(int? estacion_ID)
        {
            string sqlstr;
            sqlstr = "SELECT	Estacion_ID, Nombre \r\n" +
                "FROM	Estaciones \r\n" +
                "WHERE ( @Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID )";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Estacion_ID",
                         estacion_ID
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> GetEstaciones(string usuario_id)
        {
            string sqlstr;
            sqlstr = @"SELECT	E.Estacion_ID, E.Nombre
FROM	Estaciones E
INNER JOIN	Usuarios_Estaciones UE
ON		E.Estacion_ID = UE.Estacion_ID
WHERE	UE.Usuario_ID = @Usuario_ID";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Usuario_ID",
                         usuario_id
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> GetAllEstaciones(string usuario_id)
        {
            string sqlstr;
            sqlstr = @"SELECT NULL Estacion_ID, '-TODAS-' Nombre
UNION
SELECT	E.Estacion_ID, E.Nombre
FROM	Estaciones E
INNER JOIN	Usuarios_Estaciones UE
ON		E.Estacion_ID = UE.Estacion_ID
WHERE	UE.Usuario_ID = @Usuario_ID";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Usuario_ID",
                         usuario_id
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> Get(string usuario_id)
        {
            string sqlstr;
            sqlstr = @"DECLARE	@Empresa_ID int, @Estacion_ID int

SELECT	@Empresa_ID = Empresa_ID,
		@Estacion_ID = Estacion_ID
FROM	Usuarios
WHERE	Usuario_ID = @Usuario_ID

IF ( @Estacion_ID IS NULL )
BEGIN
	IF ( @Empresa_ID IS NULL )
	BEGIN
		SELECT	NULL Estacion_ID, '- TODAS -' Nombre
		UNION
		SELECT	Estacion_ID, Nombre
		FROM	Estaciones
		WHERE	Activo = 1
	END
	ELSE
	BEGIN
		SELECT	NULL Estacion_ID, '- TODAS -' Nombre
		UNION
		SELECT	Estacion_ID, Nombre
		FROM	Estaciones
		WHERE	Activo = 1
		AND		Empresa_ID = @Empresa_ID
        UNION
        SELECT	DISTINCT E.Estacion_ID, E.Nombre
        FROM	Contratos C
        INNER JOIN	Estaciones E
        ON		C.Estacion_ID = E.Estacion_ID
        WHERE	C.Empresa_ID = @Empresa_ID
	END	
END
ELSE
BEGIN
	SELECT	Estacion_ID, Nombre
	FROM	Estaciones
	WHERE	Activo = 1
	AND		Estacion_ID = @Estacion_ID	
END";

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Usuario_ID",
                         usuario_id
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEstaciones> Get()
        {
            string sqlstr;
            if (Sesion.Estacion_ID == null)
            {
                sqlstr = "SELECT	NULL Estacion_ID, '- TODAS -' Nombre \r\n" +
                "UNION ALL \r\n" +
                "SELECT	Estacion_ID, Nombre \r\n" +
                "FROM	Estaciones \r\n" +
                "WHERE ( @Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID )";
            }
            else
            {
                sqlstr = "SELECT	Estacion_ID, Nombre \r\n" +
                "FROM	Estaciones \r\n" +
                "WHERE ( @Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID )";
            }

            List<SelectEstaciones> list = new List<SelectEstaciones>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param(
                         "@Estacion_ID",
                         Sesion.Estacion_ID
                      )
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstaciones(DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Estacion_ID, '- TODAS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Estacion_ID, Nombre \r\n" +
            "FROM	Estaciones";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectEstaciones

    public class SelectEmpresasInternas
    {
        public override string ToString()
        {
            return this.Nombre;
        }

        public SelectEmpresasInternas()
        {
        }

        public SelectEmpresasInternas(System.Int32? empresa_id, System.String nombre)
        {
            this.Empresa_ID = empresa_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public static List<SelectEmpresasInternas> GetUnionALL()
        {
            string sqlstr;
            sqlstr = @"SELECT NULL Empresa_ID, '-TODAS-' Nombre
UNION
SELECT	Empresa_ID, Nombre
FROM	Empresas
WHERE	TipoEmpresa_ID IN (1,2)";

            List<SelectEmpresasInternas> list = new List<SelectEmpresasInternas>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param("@Empresa_ID",
                      Sesion.Empresa_ID)
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresasInternas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEmpresasInternas> GetAll()
        {
            string sqlstr;
            sqlstr = @"SELECT	Empresa_ID, Nombre
    FROM	Empresas
    WHERE	TipoEmpresa_ID IN (1,2)";

            List<SelectEmpresasInternas> list = new List<SelectEmpresasInternas>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param("@Empresa_ID",
                      Sesion.Empresa_ID)
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresasInternas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEmpresasInternas> Get()
        {
            string sqlstr;
            if (Sesion.Empresa_ID == null)
            {
                sqlstr = "SELECT	NULL Empresa_ID, '- Todas -' Nombre \r\n" +
                "UNION ALL \r\n" +
                "SELECT	Empresa_ID, Nombre \r\n" +
                "FROM	Empresas \r\n" +
                "WHERE	TipoEmpresa_ID IN (1,2) \r\n" +
                "AND (@Empresa_ID IS NULL OR Empresa_ID = @Empresa_ID)";
            }
            else
            {
                sqlstr = "SELECT	Empresa_ID, Nombre \r\n" +
                "FROM	Empresas \r\n" +
                "WHERE	TipoEmpresa_ID IN (1,2) \r\n" +
                "AND (@Empresa_ID IS NULL OR Empresa_ID = @Empresa_ID)";
            }

            List<SelectEmpresasInternas> list = new List<SelectEmpresasInternas>();
            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param("@Empresa_ID",
                      Sesion.Empresa_ID)
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresasInternas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Empresa_ID, '- Todas -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Empresa_ID, Nombre \r\n" +
            "FROM	Empresas \r\n" +
            "WHERE	TipoEmpresa_ID IN (1,2)";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectEmpresasInternas

    public class Vista_MonitorRentas
    {

        #region Constructors
        public Vista_MonitorRentas()
        {
        }

        public Vista_MonitorRentas(
            System.String empresa,
            System.String estacion,
            System.Int32? conductor_id,
            System.Int32? unidad,
            System.String nombre,
            System.String telefono,
            System.String domicilio,
            System.String cuenta,
            System.Decimal? montodiario,
            System.DateTime? fechainicial,
            System.DateTime? ultimopago,
            System.Decimal? rentas,
            System.Decimal? abonos,
            System.Decimal? cargos,
            System.Decimal? otroscargos,
            System.Decimal? abonoajustes,
            System.Int32? diassinpagar,
            System.Int32? diassinpresentarse,
            System.String tipocontrato,
            System.String nombre_aval,
            System.String domicilioaval,
            System.String telefono_aval,
            bool adendumVigente,
            Decimal? saldo_equipodegas,
            Int32? diassinpagar_equipodegas,
            Decimal? montodiario_equipodegas,
            Decimal? engancheSolicitado_EG,
                Decimal? enganchePagado_EG,
                Decimal? saldoFinal_EG

            )
        {
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Conductor_ID = conductor_id;
            this.Unidad = unidad;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Domicilio = domicilio;
            this.Cuenta = cuenta;
            this.MontoDiario = montodiario;
            this.FechaInicial = fechainicial;
            this.UltimoPago = ultimopago;
            this.Rentas = rentas;
            this.Abonos = abonos;
            this.Cargos = cargos;
            this.AbonoAjustes = abonoajustes;
            this.OtrosCargos = otroscargos;
            this.DiasSinPagar = diassinpagar;
            this.DiasSinPresentarse = diassinpresentarse;
            this.TipoContrato = tipocontrato;
            this.Nombre_Aval = nombre_aval;
            this.DomicilioAval = domicilioaval;
            this.Telefono_Aval = telefono_aval;
            this.AdendumVigente = adendumVigente;
            this.Saldo_EquipoDeGas = saldo_equipodegas;
            this.DiasSinPagar_EquipoDeGas = diassinpagar_equipodegas;
            this.MontoDiario_EquipoDeGas = montodiario_equipodegas;

            this.EngancheSolicitado_EG = engancheSolicitado_EG;
            this.EnganchePagado_EG = enganchePagado_EG;
            this.SaldoFinal_EG = saldoFinal_EG;
        }

        #endregion

        #region Properties
        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _Domicilio;
        public System.String Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private System.Decimal? _MontoDiario;
        public System.Decimal? MontoDiario
        {
            get { return _MontoDiario; }
            set { _MontoDiario = value; }
        }

        private System.DateTime? _FechaInicial;
        public System.DateTime? FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime? _UltimoPago;
        public System.DateTime? UltimoPago
        {
            get { return _UltimoPago; }
            set { _UltimoPago = value; }
        }

        private System.Decimal? _Rentas;
        public System.Decimal? Rentas
        {
            get { return _Rentas; }
            set { _Rentas = value; }
        }

        private System.Decimal? _Abonos;
        public System.Decimal? Abonos
        {
            get { return _Abonos; }
            set { _Abonos = value; }
        }

        private System.Decimal? _Cargos;
        public System.Decimal? Cargos
        {
            get { return _Cargos; }
            set { _Cargos = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal? _OtrosCargos;
        public System.Decimal? OtrosCargos
        {
            get { return _OtrosCargos; }
            set { _OtrosCargos = value; }
        }

        private System.Decimal? _AbonoAjustes;
        public System.Decimal? AbonoAjustes
        {
            get { return _AbonoAjustes; }
            set { _AbonoAjustes = value; }
        }

        private System.Int32? _DiasSinPagar;
        public System.Int32? DiasSinPagar
        {
            get { return _DiasSinPagar; }
            set { _DiasSinPagar = value; }
        }

        private System.Int32? _DiasSinPresentarse;
        public System.Int32? DiasSinPresentarse
        {
            get { return _DiasSinPresentarse; }
            set { _DiasSinPresentarse = value; }
        }

        private System.String _TipoContrato;
        public System.String TipoContrato
        {
            get { return _TipoContrato; }
            set { _TipoContrato = value; }
        }

        private System.String _Nombre_Aval;
        public System.String Nombre_Aval
        {
            get { return _Nombre_Aval; }
            set { _Nombre_Aval = value; }
        }

        private System.String _DomicilioAval;
        public System.String DomicilioAval
        {
            get { return _DomicilioAval; }
            set { _DomicilioAval = value; }
        }

        private System.String _Telefono_Aval;
        public System.String Telefono_Aval
        {
            get { return _Telefono_Aval; }
            set { _Telefono_Aval = value; }
        }

        //private bool _adendumVigente = false;
        public bool AdendumVigente
        {
            get;
            set;
            //get { return _adendumVigente; }
            //set { _adendumVigente = value; }
        }

        private Decimal? _saldo_equipodegas;
        public Decimal? Saldo_EquipoDeGas
        {
            get { return _saldo_equipodegas; }
            set { _saldo_equipodegas = value; }
        }

        private Int32? _diassinpagar_equipodegas;
        public Int32? DiasSinPagar_EquipoDeGas
        {
            get { return _diassinpagar_equipodegas; }
            set { _diassinpagar_equipodegas = value; }
        }

        private Decimal? _montodiario_equipodegas;
        public Decimal? MontoDiario_EquipoDeGas
        {
            get { return _montodiario_equipodegas; }
            set { _montodiario_equipodegas = value; }
        }




        private Decimal? _EngancheSolicitado_EG;
        public Decimal? EngancheSolicitado_EG
        {
            get { return _EngancheSolicitado_EG; }
            set { _EngancheSolicitado_EG = value; }
        }


        private Decimal? _EnganchePagado_EG;
        public Decimal? EnganchePagado_EG
        {
            get { return _EnganchePagado_EG; }
            set { _EnganchePagado_EG = value; }
        }

        private Decimal? _SaldoFinal_EG;
        public Decimal? SaldoFinal_EG
        {
            get { return _SaldoFinal_EG; }
            set { _SaldoFinal_EG = value; }
        }

        #endregion

        #region Methods

        /*
         * Modificado el 17 de Octubre de 2012
         * por Luis Espino
         * 
         * Se eliminó la directiva de consultar saldos
         * por estación. Los saldos de otros cargos
         * se consultan por empresa solamente
         */

        public static List<Vista_MonitorRentas> Get(
            System.Int32? empresa_id,
            System.Int32? estacion_id,
            System.String usuario_id)
        {
            string sqlstr = @"dbo.usp_MonitorDeRentas_Get";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_MonitorRentas> list = new List<Vista_MonitorRentas>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(
                        new Vista_MonitorRentas(
                           Convert.ToString(dr["Empresa"]),
                           Convert.ToString(dr["Estacion"]),
                           DB.GetNullableInt32(dr["Conductor_ID"]),
                           DB.GetNullableInt32(dr["Unidad"]),
                           Convert.ToString(dr["Nombre"]),
                           Convert.ToString(dr["Telefono"]),
                           Convert.ToString(dr["Domicilio"]),
                           Convert.ToString(dr["Cuenta"]),
                           DB.GetNullableDecimal(dr["MontoDiario"]),
                           DB.GetNullableDateTime(dr["FechaInicial"]),
                           DB.GetNullableDateTime(dr["UltimoPago"]),
                           DB.GetNullableDecimal(dr["Rentas"]),
                           DB.GetNullableDecimal(dr["Abonos"]),
                           DB.GetNullableDecimal(dr["Cargos"]),
                           DB.GetNullableDecimal(dr["OtrosCargos"]),
                           DB.GetNullableDecimal(dr["AbonoAjustes"]),
                           DB.GetNullableInt32(dr["DiasSinPagar"]),
                           DB.GetNullableInt32(dr["DiasSinPresentarse"]),
                           Convert.ToString(dr["TipoContrato"]),
                           Convert.ToString(dr["Nombre_Aval"]),
                           Convert.ToString(dr["DomicilioAval"]),
                           Convert.ToString(dr["Telefono_Aval"]),
                           Convert.ToBoolean(dr["AdendumVigente"]),
                           DB.GetNullableDecimal(dr["Saldo_EG"]),
                           DB.GetNullableInt32(dr["DiasSinPagar_EG"]),
                           DB.GetNullableDecimal(dr["MontoDiario_EG"]),
                           DB.GetNullableDecimal(dr["EngancheSolicitado_EG"]),
                           DB.GetNullableDecimal(dr["EnganchePagado_EG"]),
                           DB.GetNullableDecimal(dr["SaldoFinal_EG"])


                           )
                        );
                }
            }
            ds.Dispose();
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"DECLARE @OtrosCargos TABLE
(
	Conductor_ID int,
	Saldo money
)

DECLARE @EquipoGas TABLE(Conductor_ID int, Saldo money, DiasSinPagar int, MontoDiario money, PRIMARY KEY (Conductor_ID))

INSERT @OtrosCargos
SELECT	Conductor_ID,
		SUM(Abono - Cargo) Saldo
FROM	CuentaConductores
WHERE	Cuenta_ID = 2
AND		( @Empresa_ID IS NULL OR Empresa_ID = @Empresa_ID )
GROUP BY	Conductor_ID

INSERT @EquipoGas
	SELECT
		CC.Conductor_ID
		, SUM(CC.Abono - CC.Cargo) Saldo
		, CASE
			WHEN SUM(CC.Abono - CC.Cargo) < 0 THEN CONVERT(int,ROUND(ABS(SUM(CC.Abono - CC.Cargo) / MAX(G.MontoDiario)),0))
			ELSE 0
		END DiasSinPagar
		, MAX(G.MontoDiario) AS MontoDiario
	FROM	CuentaConductores as CC
	WHERE	Cuenta_ID = 42
	AND ( @Empresa_ID IS NULL OR Empresa_ID IN (SELECT DISTINCT Empresa_ID FROM @EmpresasTbl) )
	GROUP BY	Conductor_ID

SELECT	E.Nombre Empresa, 
		Est.Nombre Estacion, 
		Cont.Conductor_ID, 
		Cont.NumeroEconomico Unidad,
		Cond.Apellidos + ' ' + Cond.Nombre Nombre,
		Cond.Telefono,
		Cond.Domicilio + ' ' + Cond.Ciudad Domicilio,		 
		Cont.MontoDiario, 
		Cont.FechaInicial,
		(SELECT convert(date,ISNULL(MAX(Fecha),GETDATE())) FROM CuentaConductores
		WHERE	Conductor_ID = Cont.Conductor_ID
		AND		Concepto_ID = 2) UltimoPago,		
		SUM(CC.Abono - CC.Cargo) Rentas,
		ISNULL(OC.Saldo,0) OtrosCargos,
		CASE
		WHEN SUM(CC.Abono - CC.Cargo) < 0 
		THEN CONVERT(int,ROUND(ABS(SUM(CC.Abono - CC.Cargo) / Cont.MontoDiario),0))
		ELSE 0
		END DiasSinPagar,
		DATEDIFF(dd, (SELECT covnert(date,ISNULL(MAX(Fecha),GETDATE())) FROM CuentaConductores
		WHERE	Conductor_ID = Cont.Conductor_ID
		AND		Concepto_ID = 2), convert(date,GETDATE())) DiasSinPresentarse,
		TC.Nombre TipoContrato,
		Cond.Apellidos_Aval + ' ' + Cond.Nombre_Aval Nombre_Aval,
		Cond.Domicilio_Aval + ' ' + Cond.Ciudad_Aval DomicilioAval,
		Cond.Telefono_Aval
		, MAX(EG.Saldo) Saldo_EG
		, MAX(EG.DiasSinPagar) DiasSinPagar_EG
		, MAX(ISNULL(EG.MontoDiario,0)) MontoDiario_EG
FROM	Contratos Cont
INNER JOIN	Conductores Cond
ON		Cont.Conductor_ID = Cond.Conductor_ID
INNER JOIN	CuentaConductores CC
ON		(  CC.Conductor_ID = Cont.Conductor_ID
			AND CC.Cuenta_ID = Cont.Cuenta_ID )
INNER JOIN	Empresas E
ON		Cont.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones Est
ON		Cont.Estacion_ID = Est.Estacion_ID
INNER JOIN	TiposContratos TC
ON		Cont.TipoContrato_ID = TC.TipoContrato_ID
LEFT JOIN	@OtrosCargos OC
ON		OC.Conductor_ID = Cond.Conductor_ID
LEFT JOIN @EquipoGas EG
		ON EG.Conductor_ID = Cont.Conductor_ID
WHERE	Cont.EstatusContrato_ID = 1
AND		Cont.Cuenta_ID = 1
AND		( @Empresa_ID IS NULL OR Cont.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR Cont.Estacion_ID = @Estacion_ID )
AND		Cont.MontoDiario > 0
--AND CONT.TipoContrato_ID IN (1,2)
GROUP BY	E.Nombre, 
			Est.Nombre, 
			Cont.Conductor_ID, 
			Cont.NumeroEconomico, 
			Cond.Apellidos + ' ' + Cond.Nombre,
			Cond.Telefono,		
			Cond.Domicilio + ' ' + Cond.Ciudad,	
			Cont.MontoDiario,
			Cont.FechaInicial,
			OC.Saldo,
			TC.Nombre,
			Cond.Apellidos_Aval + ' ' + Cond.Nombre_Aval,
			Cond.Domicilio_Aval + ' ' + Cond.Ciudad_Aval,
			Cond.Telefono_Aval
ORDER BY	Rentas, 
            E.Nombre, 
			Est.Nombre, 
			Cont.NumeroEconomico, 
			Cond.Apellidos + ' ' + Cond.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_MonitorRentas

    public class Vista_OrdenesServiciosRefaccionesAlmacen
    {

        #region Constructors
        public Vista_OrdenesServiciosRefaccionesAlmacen()
        {
        }

        public Vista_OrdenesServiciosRefaccionesAlmacen(
            System.Int32? ordenserviciorefaccion_id,
            System.Int32? refaccion_id,
            System.Decimal? costounitario,
            System.Decimal? preciounitario,
            System.Int32? cantidad,
            System.Decimal? total,
            System.Int32? refsurtidas,
            System.Int32? porsurtir,
            System.Int32? salida,
            System.String refaccion,
            System.Int32? cantidadinventario
            )
        {
            this.OrdenServicioRefaccion_ID = ordenserviciorefaccion_id;
            this.Refaccion_ID = refaccion_id;
            this.CostoUnitario = costounitario;
            this.PrecioUnitario = preciounitario;
            this.Cantidad = cantidad;
            this.Total = total;
            this.RefSurtidas = refsurtidas;
            this.PorSurtir = porsurtir;
            this.Salida = salida;
            this.Refaccion = refaccion;
            this.CantidadInventario = cantidadinventario;
        }

        #endregion

        #region Properties
        private System.Int32? _OrdenServicioRefaccion_ID;
        public System.Int32? OrdenServicioRefaccion_ID
        {
            get { return _OrdenServicioRefaccion_ID; }
            set { _OrdenServicioRefaccion_ID = value; }
        }

        private System.Int32? _Refaccion_ID;
        public System.Int32? Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private System.Decimal? _CostoUnitario;
        public System.Decimal? CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Decimal? _PrecioUnitario;
        public System.Decimal? PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }

        private System.Int32? _Cantidad;
        public System.Int32? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.Int32? _RefSurtidas;
        public System.Int32? RefSurtidas
        {
            get { return _RefSurtidas; }
            set { _RefSurtidas = value; }
        }

        private System.Int32? _PorSurtir;
        public System.Int32? PorSurtir
        {
            get { return _PorSurtir; }
            set { _PorSurtir = value; }
        }

        private System.Int32? _Salida;
        public System.Int32? Salida
        {
            get { return _Salida; }
            set { _Salida = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Int32? _CantidadInventario;
        public System.Int32? CantidadInventario
        {
            get { return _CantidadInventario; }
            set { _CantidadInventario = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_OrdenesServiciosRefaccionesAlmacen> Get(
            System.Int32 empresa_id,
            System.Int32 estacion_id,
            System.Int32 ordentrabajo_id)
        {
            string sqlstr = @"SELECT	OSR.OrdenServicioRefaccion_ID, OSR.Refaccion_ID, OSR.CostoUnitario, 
		OSR.PrecioUnitario, OSR.Cantidad,
		OSR.Total, OSR.RefSurtidas, OSR.Cantidad - OSR.RefSurtidas PorSurtir,
		0 Salida, R.Descripcion Refaccion,
		ISNULL(I.CantidadInventario,0) CantidadInventario
FROM	OrdenesServiciosRefacciones OSR
LEFT JOIN	Refacciones R
ON		OSR.Refaccion_ID = R.Refaccion_ID
INNER JOIN	OrdenesServicios OS
ON		OS.OrdenServicio_ID = OSR.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
LEFT JOIN	Inventario I
ON		( OSR.Refaccion_ID = I.Refaccion_ID
			AND		I.Empresa_ID = @Empresa_ID
			AND		I.Estacion_ID = @Estacion_ID
		)			
WHERE	OT.OrdenTrabajo_ID = @OrdenTrabajo_ID
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);

            List<Vista_OrdenesServiciosRefaccionesAlmacen> list = new List<Vista_OrdenesServiciosRefaccionesAlmacen>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_OrdenesServiciosRefaccionesAlmacen(
                       DB.GetNullableInt32(dr["OrdenServicioRefaccion_ID"]),
                       DB.GetNullableInt32(dr["Refaccion_ID"]),
                       DB.GetNullableDecimal(dr["CostoUnitario"]),
                       DB.GetNullableDecimal(dr["PrecioUnitario"]),
                       DB.GetNullableInt32(dr["Cantidad"]),
                       DB.GetNullableDecimal(dr["Total"]),
                       DB.GetNullableInt32(dr["RefSurtidas"]),
                       DB.GetNullableInt32(dr["PorSurtir"]),
                       DB.GetNullableInt32(dr["Salida"]),
                       Convert.ToString(dr["Refaccion"]),
                       DB.GetNullableInt32(dr["CantidadInventario"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 empresa_id,
            System.Int32 estacion_id,
            System.Int32 ordentrabajo_id)
        {
            string sqlstr = @"SELECT	OSR.OrdenServicioRefaccion_ID, OSR.Refaccion_ID, OSR.CostoUnitario, 
		OSR.PrecioUnitario, OSR.Cantidad,
		OSR.Total, OSR.RefSurtidas, OSR.Cantidad - OSR.RefSurtidas PorSurtir,
		0 Salida, R.Descripcion Refaccion,
		ISNULL(I.CantidadInventario,0) CantidadInventario
FROM	OrdenesServiciosRefacciones OSR
LEFT JOIN	Refacciones R
ON		OSR.Refaccion_ID = R.Refaccion_ID
INNER JOIN	OrdenesServicios OS
ON		OS.OrdenServicio_ID = OSR.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
INNER JOIN	Inventario I
ON		( OSR.Refaccion_ID = I.Refaccion_ID
			AND		I.Empresa_ID = @Empresa_ID
			AND		I.Estacion_ID = @Estacion_ID
		)			
WHERE	OT.OrdenTrabajo_ID = @OrdenTrabajo_ID
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_OrdenesServiciosRefaccionesAlmacen



    public class Vista_Compras
    {

        public Vista_Compras()
        {
        }

        public Vista_Compras(System.Int32 ordencompra_id, System.String refaccion, System.Decimal costounitario, System.Int32 cantidad, System.Decimal total, System.DateTime fecha, System.String estado)
        {
            this.OrdenCompra_ID = ordencompra_id;
            this.Refaccion = refaccion;
            this.CostoUnitario = costounitario;
            this.Cantidad = cantidad;
            this.Total = total;
            this.Fecha = fecha;
            this.Estado = estado;
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }

        private System.Decimal _CostoUnitario;
        public System.Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Estado;
        public System.String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public static List<Vista_Compras> Get(System.Int32 ordencompra_id, System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenCompra_ID,
		R.Descripcion Refaccion,
		C.CostoUnitario,
		C.Cantidad,
		C.CostoUnitario * Cantidad Total,
		C.Fecha,
		CASE 
		WHEN	C.Cantidad = C.RefaccionesSurtidas THEN 'Surtida'
		ELSE 'Por Surtir'
		END Estado
FROM	Compras C
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
INNER JOIN	MarcasRefacciones MR
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
WHERE	C.OrdenCompra_ID = @OrdenCompra_ID
AND		C.Empresa_ID = @Empresa_ID
AND		C.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Compras> list = new List<Vista_Compras>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Compras(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Refaccion"]), Convert.ToDecimal(dr["CostoUnitario"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Estado"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ordencompra_id, System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.OrdenCompra_ID,
		R.Descripcion Refaccion,
		C.CostoUnitario,
		C.Cantidad,
		C.CostoUnitario * Cantidad Total,
		C.Fecha,
		CASE 
		WHEN	C.Cantidad = C.RefaccionesSurtidas THEN 'Surtida'
		ELSE 'Por Surtir'
		END Estado
FROM	Compras C
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
INNER JOIN	MarcasRefacciones MR
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
WHERE	C.OrdenCompra_ID = @OrdenCompra_ID
AND		C.Empresa_ID = @Empresa_ID
AND		C.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Compras



    public class Vista_ComprasAlmacen
    {

        public Vista_ComprasAlmacen()
        {
        }

        public Vista_ComprasAlmacen(System.Int32 compra_id, System.Int32 ordencompra_id, System.Int32 refaccion_id, System.Int32 marcarefaccion_id, System.String usuario_id, System.Decimal costounitario, System.Int32 cantidad, System.DateTime fecha, System.Int32 refaccionessurtidas, System.Int32 porsurtir, System.Int32 entrada, System.String refaccion)
        {
            this.Compra_ID = compra_id;
            this.OrdenCompra_ID = ordencompra_id;
            this.Refaccion_ID = refaccion_id;
            this.MarcaRefaccion_ID = marcarefaccion_id;
            this.Usuario_ID = usuario_id;
            this.CostoUnitario = costounitario;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
            this.RefaccionesSurtidas = refaccionessurtidas;
            this.PorSurtir = porsurtir;
            this.Entrada = entrada;
            this.Refaccion = refaccion;
        }

        private System.Int32 _Compra_ID;
        public System.Int32 Compra_ID
        {
            get { return _Compra_ID; }
            set { _Compra_ID = value; }
        }

        private System.Int32 _OrdenCompra_ID;
        public System.Int32 OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private System.Int32 _Refaccion_ID;
        public System.Int32 Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private System.Int32 _MarcaRefaccion_ID;
        public System.Int32 MarcaRefaccion_ID
        {
            get { return _MarcaRefaccion_ID; }
            set { _MarcaRefaccion_ID = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.Decimal _CostoUnitario;
        public System.Decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32 _RefaccionesSurtidas;
        public System.Int32 RefaccionesSurtidas
        {
            get { return _RefaccionesSurtidas; }
            set { _RefaccionesSurtidas = value; }
        }

        private System.Int32 _PorSurtir;
        public System.Int32 PorSurtir
        {
            get { return _PorSurtir; }
            set { _PorSurtir = value; }
        }

        private System.Int32 _Entrada;
        public System.Int32 Entrada
        {
            get { return _Entrada; }
            set { _Entrada = value; }
        }

        private System.String _Refaccion;
        public System.String Refaccion
        {
            get { return _Refaccion; }
            set { _Refaccion = value; }
        }


        public static List<Vista_ComprasAlmacen> Get(System.Int32 ordencompra_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.Compra_ID, C.OrdenCompra_ID, C.Refaccion_ID, C.MarcaRefaccion_ID, C.Usuario_ID, 
		C.CostoUnitario, C.Cantidad, C.Fecha, C.RefaccionesSurtidas,
		C.Cantidad - C.RefaccionesSurtidas PorSurtir, 
		0 Entrada, R.Descripcion Refaccion
FROM	Compras C
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
WHERE	C.OrdenCompra_ID = @OrdenCompra_ID
AND		C.Empresa_ID = @Empresa_ID
AND		C.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ComprasAlmacen> list = new List<Vista_ComprasAlmacen>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ComprasAlmacen(Convert.ToInt32(dr["Compra_ID"]), Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDecimal(dr["CostoUnitario"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["RefaccionesSurtidas"]), Convert.ToInt32(dr["PorSurtir"]), Convert.ToInt32(dr["Entrada"]), Convert.ToString(dr["Refaccion"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ordencompra_id,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	C.Compra_ID, C.OrdenCompra_ID, C.Refaccion_ID, C.MarcaRefaccion_ID, C.Usuario_ID, 
		C.CostoUnitario, C.Cantidad, C.Fecha, C.RefaccionesSurtidas,
		C.Cantidad - C.RefaccionesSurtidas PorSurtir, 
		0 Entrada, R.Descripcion Refaccion
FROM	Compras C
INNER JOIN	Refacciones R
ON		C.Refaccion_ID = R.Refaccion_ID
WHERE	C.OrdenCompra_ID = @OrdenCompra_ID
AND		C.Empresa_ID = @Empresa_ID
AND		C.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenCompra_ID", ordencompra_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_ComprasAlmacen


    public class DatosUnidadTaller
    {
        #region Constructors

        public DatosUnidadTaller()
        {
        }

        public DatosUnidadTaller(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.String placas,
            System.String empresa,
            System.Int32? empresa_id,
            System.Int32? conductor_id,
            System.String conductor,
            System.Int32? modelounidad_id,
            System.Int32? modelo_id,
            System.String modelo
            )
        {
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.Placas = placas;
            this.Empresa = empresa;
            this.Empresa_ID = empresa_id;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.ModeloUnidad_ID = modelounidad_id;
            this.Modelo_ID = modelo_id;
            this.Modelo = modelo;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _Placas;
        public System.String Placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _ModeloUnidad_ID;
        public System.Int32? ModeloUnidad_ID
        {
            get { return _ModeloUnidad_ID; }
            set { _ModeloUnidad_ID = value; }
        }

        private System.Int32? _Modelo_ID;
        public System.Int32? Modelo_ID
        {
            get { return _Modelo_ID; }
            set { _Modelo_ID = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        #endregion

        public static List<DatosUnidadTaller> Get(System.Int32 numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, 
	U.NumeroEconomico, 
	UPPER(U.Placas) Placas, 
	E.Nombre Empresa, U.Empresa_ID, 
	NULL Conductor_ID, 
	UPPER(ISNULL((C.Apellidos + ' ' + C.Nombre),E.Nombre)) Conductor,
	MU.ModeloUnidad_ID,
	M.Modelo_ID, 
	ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
FROM	Unidades U 
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
LEFT JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
INNER JOIN	Empresas E 
ON		U.Empresa_ID = E.Empresa_ID 
LEFT JOIN	Conductores C
ON		U.ConductorOperativo_ID = C.Conductor_ID 
WHERE	U.NumeroEconomico = @NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);

            List<DatosUnidadTaller> list = new List<DatosUnidadTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new DatosUnidadTaller(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Placas"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["ModeloUnidad_ID"]),
                       DB.GetNullableInt32(dr["Modelo_ID"]),
                       Convert.ToString(dr["Modelo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, 
	U.NumeroEconomico, 
	UPPER(U.Placas) Placas, 
	E.Nombre Empresa, U.Empresa_ID, 
	NULL Conductor_ID, 
	UPPER(ISNULL((C.Apellidos + ' ' + C.Nombre),E.Nombre)) Conductor,
	MU.ModeloUnidad_ID,
	M.Modelo_ID, 
	ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
FROM	Unidades U 
INNER JOIN	ModelosUnidades MU
ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
LEFT JOIN	Modelos M
ON		MU.Modelo_ID = M.Modelo_ID
INNER JOIN	Empresas E 
ON		U.Empresa_ID = E.Empresa_ID 
LEFT JOIN	Conductores C
ON		U.ConductorOperativo_ID = C.Conductor_ID 
WHERE	U.NumeroEconomico = @NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static List<DatosUnidadTaller> Get(System.Int32? numeroeconomico, System.String cliente, System.String placas)
        {
            string sqlstr = @"
IF ( (	SELECT TOP 1 TipoEmpresa_ID
		FROM Empresas
		WHERE	Empresa_ID IN
			(	SELECT Empresa_ID
				FROM	Unidades
				WHERE	NumeroEconomico = @NumeroEconomico
			)
	) IN (1,2) )
BEGIN	
	PRINT 'ES INTERNA'
	IF EXISTS (
		SELECT	*
		FROM	Contratos
		WHERE	NumeroEconomico = @NumeroEconomico
		AND		EstatusContrato_ID = 1 --AND TipoContrato_ID IN (1,2)
	)
	BEGIN
		PRINT 'TIENE CONTRATO ACTIVO'
		-- Tiene contrato activo
		SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
				E.Nombre Empresa, U.Empresa_ID, 
				CO.Conductor_ID, 
				(CO.Apellidos + ' ' + CO.Nombre) Conductor,
				MU.ModeloUnidad_ID,
				M.Modelo_ID, ISNULL(M.Nombre,'NO ASIGNADO') Modelo
		FROM	Unidades U
		INNER JOIN	ModelosUnidades MU
		ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
		LEFT JOIN	Modelos M
		ON		MU.Modelo_ID = M.Modelo_ID
		INNER JOIN	Empresas E 
		ON		U.Empresa_ID = E.Empresa_ID 
		INNER JOIN	Contratos C 
		ON		U.Unidad_ID = C.Unidad_ID 
		INNER JOIN	Conductores CO 
		ON		C.Conductor_ID = CO.Conductor_ID 
		WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico ) 
        AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' ) 
        AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )
		AND		C.EstatusContrato_ID = 1 --AND C.TipoContrato_ID IN (1,2)
	END
	ELSE
	BEGIN
		PRINT 'NO TIENE CONTRATO ACTIVO'
		--	No tiene contrato activo,
		--  Si tiene algun contrato
		IF EXISTS (
			SELECT	*
			FROM	Contratos
			WHERE	NumeroEconomico = @NumeroEconomico			
		)
		BEGIN
			PRINT 'TIENE ALGUN CONTRATO'
			--	Consultar su ultimo contrato
			SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
					E.Nombre Empresa, U.Empresa_ID, 
					CO.Conductor_ID, 
					(CO.Apellidos + ' ' + CO.Nombre) Conductor,
					MU.ModeloUnidad_ID,
					M.Modelo_ID, ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
			FROM	Unidades U 
			INNER JOIN	ModelosUnidades MU
			ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
			LEFT JOIN	Modelos M
			ON		MU.Modelo_ID = M.Modelo_ID
			INNER JOIN	Empresas E 
			ON		U.Empresa_ID = E.Empresa_ID 
			INNER JOIN	Contratos C 
			ON		U.Unidad_ID = C.Unidad_ID 
			INNER JOIN	Conductores CO 
			ON		C.Conductor_ID = CO.Conductor_ID 
			WHERE	C.Contrato_ID = ( SELECT	TOP 1	Contrato_ID
					FROM	Contratos
					WHERE	( @NumeroEconomico IS NULL OR NumeroEconomico = @NumeroEconomico )
                    OR      Unidad_ID IN
                    (
                        SELECT  Unidad_ID
                        FROM    Unidades
                        WHERE	( @NumeroEconomico IS NULL OR NumeroEconomico = @NumeroEconomico )
                        AND   ( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )
                    )
					ORDER BY	FechaInicial DESC )              
            AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' )   
		  --AND C.TipoContrato_ID IN (1,2)
		
		END
		ELSE
		BEGIN
			PRINT 'NO TIENE CONTRATO ALGUNO'
			--	Unidad no cuenta con contrato alguno
			
			--	Verificar el ultimo movimiento, en caso de haberlo
			IF EXISTS ( SELECT *
						FROM	CuentaConductores
						WHERE	Conductor_ID IS NOT NULL
						AND	Unidad_ID IN (
												SELECT Unidad_ID
												FROM	Unidades
												WHERE	NumeroEconomico = @NumeroEconomico
											)
						)
			BEGIN
				PRINT 'TIENE MOVIMIENTOS'
				
				SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
						E.Nombre Empresa, U.Empresa_ID, 
						CO.Conductor_ID, 
						(CO.Apellidos + ' ' + CO.Nombre) Conductor,
						MU.ModeloUnidad_ID,
						M.Modelo_ID, ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
				FROM	Unidades U 
				INNER JOIN	ModelosUnidades MU
				ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
				LEFT JOIN	Modelos M
				ON		MU.Modelo_ID = M.Modelo_ID
				INNER JOIN	Empresas E 
				ON		U.Empresa_ID = E.Empresa_ID 
				INNER JOIN	CuentaConductores C 
				ON		U.Unidad_ID = C.Unidad_ID 
				INNER JOIN	Conductores CO 
				ON		C.Conductor_ID = CO.Conductor_ID 
				WHERE	C.CuentaConductor_ID = (	SELECT	TOP 1	CuentaConductor_ID
													FROM	CuentaConductores
													WHERE	Unidad_ID = (	SELECT TOP 1 Unidad_ID 
																			FROM Unidades 
																			WHERE	( @NumeroEconomico IS NULL OR NumeroEconomico = @NumeroEconomico ) 
                                                                            AND		( @Placas IS NULL OR Placas LIKE @Placas + '%' )
																			AND	Unidad_ID IN
																			(
																				SELECT	Unidad_ID FROM CuentaConductores
																			)
																		)
													AND		Conductor_ID IS NOT NULL
													ORDER BY	Fecha DESC 
												)
                AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' ) 
				
			END
			ELSE
			BEGIN
				PRINT 'NO TIENE MOVIMIENTOS'
				--	Nunca tuvo conductor,
				--	Seleccionar con la empresa como conductor				
				SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
						E.Nombre Empresa, U.Empresa_ID, 
						NULL Conductor_ID, 
						E.Nombre Conductor,
						MU.ModeloUnidad_ID,
						M.Modelo_ID, ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
				FROM	Unidades U 
				INNER JOIN	ModelosUnidades MU
				ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
				LEFT JOIN	Modelos M
				ON		MU.Modelo_ID = M.Modelo_ID
				INNER JOIN	Empresas E 
				ON		U.Empresa_ID = E.Empresa_ID 
				LEFT JOIN	CuentaConductores C 
				ON		U.Unidad_ID = C.Unidad_ID 
				WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico ) 
                AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' ) 
                AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )
			END
		END		
	END

END
ELSE
BEGIN

	PRINT 'ES UNIDAD EXTERNA'
	SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
			E.Nombre Empresa, U.Empresa_ID, 
			NULL Conductor_ID, 
			E.RazonSocial Conductor,
			MU.ModeloUnidad_ID,
			M.Modelo_ID, ISNULL(M.Nombre,'NO ASIGNADO') Modelo 
	FROM	Unidades U 
	INNER JOIN	ModelosUnidades MU
	ON		U.ModeloUnidad_ID = MU.ModeloUnidad_ID
	LEFT JOIN	Modelos M
	ON		MU.Modelo_ID = M.Modelo_ID
	INNER JOIN	Empresas E 
	ON		U.Empresa_ID = E.Empresa_ID 
	WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico ) 
    AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' ) 
    AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )

END
";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Cliente", cliente);
            m_params.Add("@Placas", placas);

            List<DatosUnidadTaller> list = new List<DatosUnidadTaller>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new DatosUnidadTaller(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToString(dr["Placas"]),
                       Convert.ToString(dr["Empresa"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["ModeloUnidad_ID"]),
                       DB.GetNullableInt32(dr["Modelo_ID"]),
                       Convert.ToString(dr["Modelo"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? numeroeconomico, System.String cliente, System.String placas)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, U.Placas, 
		E.Nombre Empresa, U.Empresa_ID, 
		CO.Conductor_ID, 
		(CO.Apellidos + ' ' + CO.Nombre) Conductor 
FROM	Unidades U 
INNER JOIN	Empresas E 
ON		U.Empresa_ID = E.Empresa_ID 
LEFT JOIN	Contratos C 
ON		U.Unidad_ID = C.Unidad_ID 
--AND C.TipoContrato_ID IN (1,2)
LEFT JOIN	Conductores CO 
ON		C.Conductor_ID = CO.Conductor_ID 
WHERE	( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico ) 
AND		( @Cliente IS NULL OR E.RazonSocial LIKE @Cliente + '%' ) 
AND		( @Placas IS NULL OR U.Placas LIKE @Placas + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@Cliente", cliente);
            m_params.Add("@Placas", placas);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class DatosUnidadTaller


    public class SelectServiciosMantenimientos
    {

        public SelectServiciosMantenimientos()
        {
        }

        public SelectServiciosMantenimientos(System.Int32? serviciomantenimiento_id, System.String nombre)
        {
            this.ServicioMantenimiento_ID = serviciomantenimiento_id;
            this.Nombre = nombre;
        }

        private System.Int32? _ServicioMantenimiento_ID;
        public System.Int32? ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectServiciosMantenimientos> Get()
        {
            string sqlstr = "SELECT	NULL ServicioMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	ServicioMantenimiento_ID, Nombre \r\n" +
            "FROM	ServiciosMantenimientos";

            List<SelectServiciosMantenimientos> list = new List<SelectServiciosMantenimientos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectServiciosMantenimientos(DB.GetNullableInt32(dr["ServicioMantenimiento_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL ServicioMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	ServicioMantenimiento_ID, Nombre \r\n" +
            "FROM	ServiciosMantenimientos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectServiciosMantenimientos

    public class SelectModelos
    {

        public SelectModelos()
        {
        }

        public SelectModelos(System.Int32? modelo_id, System.String nombre)
        {
            this.Modelo_ID = modelo_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Modelo_ID;
        public System.Int32? Modelo_ID
        {
            get { return _Modelo_ID; }
            set { _Modelo_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectModelos> Get()
        {
            string sqlstr = "SELECT	NULL Modelo_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Modelo_ID, Nombre \r\n" +
            "FROM	Modelos";

            List<SelectModelos> list = new List<SelectModelos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectModelos(DB.GetNullableInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Modelo_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Modelo_ID, Nombre \r\n" +
            "FROM	Modelos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectModelos

    public class SelectEstatusOrdenesTrabajos
    {

        public SelectEstatusOrdenesTrabajos()
        {
        }

        public SelectEstatusOrdenesTrabajos(System.Int32? estatusordentrabajo_id, System.String nombre)
        {
            this.EstatusOrdenTrabajo_ID = estatusordentrabajo_id;
            this.Nombre = nombre;
        }

        private System.Int32? _EstatusOrdenTrabajo_ID;
        public System.Int32? EstatusOrdenTrabajo_ID
        {
            get { return _EstatusOrdenTrabajo_ID; }
            set { _EstatusOrdenTrabajo_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectEstatusOrdenesTrabajos> Get()
        {
            string sqlstr = "SELECT	NULL EstatusOrdenTrabajo_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	EstatusOrdenTrabajo_ID, Nombre \r\n" +
            "FROM	EstatusOrdenesTrabajos";

            List<SelectEstatusOrdenesTrabajos> list = new List<SelectEstatusOrdenesTrabajos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEstatusOrdenesTrabajos(DB.GetNullableInt32(dr["EstatusOrdenTrabajo_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL EstatusOrdenTrabajo_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	EstatusOrdenTrabajo_ID, Nombre \r\n" +
            "FROM	EstatusOrdenesTrabajos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectEstatusOrdenesTrabajos

    public class SelectTiposMantenimientos
    {

        public SelectTiposMantenimientos()
        {
        }

        public SelectTiposMantenimientos(System.Int32? tipomantenimiento_id, System.String nombre)
        {
            this.TipoMantenimiento_ID = tipomantenimiento_id;
            this.Nombre = nombre;
        }

        private System.Int32? _TipoMantenimiento_ID;
        public System.Int32? TipoMantenimiento_ID
        {
            get { return _TipoMantenimiento_ID; }
            set { _TipoMantenimiento_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposMantenimientos> Get()
        {
            string sqlstr = "SELECT	NULL TipoMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoMantenimiento_ID, Nombre \r\n" +
            "FROM	TiposMantenimientos";

            List<SelectTiposMantenimientos> list = new List<SelectTiposMantenimientos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectTiposMantenimientos(DB.GetNullableInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL TipoMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoMantenimiento_ID, Nombre \r\n" +
            "FROM	TiposMantenimientos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectTiposMantenimientos

    public class SelectEmpresas
    {

        public SelectEmpresas()
        {
        }

        public SelectEmpresas(System.Int32? empresa_id, System.String nombre)
        {
            this.Empresa_ID = empresa_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public static List<SelectEmpresas> GetInternas()
        {
            string sqlstr = @"SELECT	Empresa_ID, Nombre
FROM	Empresas
WHERE   TipoEmpresa_ID IN (1,2)";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData


        public static List<SelectEmpresas> Get()
        {
            string sqlstr = "SELECT	NULL Empresa_ID, '- TODAS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Empresa_ID, Nombre \r\n" +
            "FROM	Empresas";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData


        public static List<SelectEmpresas> GetEmpresasX(string usuario_id)
        {
            //            string sqlstr = @"SELECT	E.Empresa_ID, E.Nombre
            //FROM	Empresas E
            //INNER JOIN	Usuarios_Empresas UE
            //ON		E.Empresa_ID = UE.Empresa_ID
            //and e.Empresa_ID not in (4,1081)
            //AND		Usuario_ID = @Usuario_ID";

            string sqlstr = @"SELECT	E.Empresa_ID, E.Nombre
FROM	Empresas E
INNER JOIN	Usuarios_Empresas UE
ON		E.Empresa_ID = UE.Empresa_ID
AND		Usuario_ID = @Usuario_ID";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.QueryCommand(sqlstr, DB.GetParams(DB.Param("@Usuario_ID", usuario_id)));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // 


        public static List<SelectEmpresas> GetEmpresas(string usuario_id)
        {
            string sqlstr = @"SELECT	E.Empresa_ID, E.Nombre
FROM	Empresas E
INNER JOIN	Usuarios_Empresas UE
ON		E.Empresa_ID = UE.Empresa_ID
AND		Usuario_ID = @Usuario_ID";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.QueryCommand(sqlstr, DB.GetParams(DB.Param("@Usuario_ID", usuario_id)));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEmpresas> GetAllEmpresas(string usuario_id)
        {
            string sqlstr = @"SELECT    NULL Empresa_ID, '-TODAS-' Nombre
UNION
SELECT	E.Empresa_ID, E.Nombre
FROM	Empresas E
INNER JOIN	Usuarios_Empresas UE
ON		E.Empresa_ID = UE.Empresa_ID
AND		Usuario_ID = @Usuario_ID";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.QueryCommand(sqlstr, DB.GetParams(DB.Param("@Usuario_ID", usuario_id)));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEmpresas> Get(string usuario_id)
        {
            string sqlstr = @"DECLARE	@Empresa_ID int
SELECT	@Empresa_ID = Empresa_ID
FROM	Usuarios
WHERE	Usuario_ID = @Usuario_ID

IF ( @Empresa_ID IS NULL )
BEGIN
	SELECT	NULL Empresa_ID, '- TODAS -' Nombre
	UNION
	SELECT	Empresa_ID, Nombre
	FROM	Empresas
	WHERE	TipoEmpresa_ID IN (1,2)
END
ELSE
BEGIN
	SELECT	Empresa_ID, Nombre
	FROM	Empresas
	WHERE	Empresa_ID = @Empresa_ID	
END";

            List<SelectEmpresas> list = new List<SelectEmpresas>();

            DataTable dt =
                DB.QueryCommand(
                   sqlstr,
                   DB.GetParams(
                      DB.Param("@Usuario_ID", usuario_id)
                   )
                );

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<SelectEmpresas> GetClientes()
        {
            string sqlstr = "SELECT	NULL Empresa_ID, '- TODAS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Empresa_ID, Nombre \r\n" +
            "FROM	Empresas \r\n" +
            "WHERE  TipoEmpresa_ID = 3";

            List<SelectEmpresas> list = new List<SelectEmpresas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectEmpresas(DB.GetNullableInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Empresa_ID, '- TODAS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Empresa_ID, Nombre \r\n" +
            "FROM	Empresas";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectEmpresas

    public class Vista_OrdenesTrabajos
    {

        #region Constructors

        public Vista_OrdenesTrabajos()
        {
        }

        public Vista_OrdenesTrabajos(System.Int32 ordentrabajo_id, System.String empresa, System.String tipomantenimiento, System.String clientefactura,
            System.String estatus, System.String foliofactura, System.Int32 numeroeconomico, System.String usuariocaptura, System.String codigobarras,
               System.Decimal subtotal, System.Decimal iva, System.Decimal total, System.DateTime fechaalta, System.DateTime? fechainicioreparacion,
                  System.DateTime? fechaterminacion, System.DateTime? fechapago, System.DateTime? fechafacturacion, System.Decimal manoobra,
                     System.Decimal ivamanoobra, System.Decimal ivarefacciones, System.Int32? kilometraje, System.Decimal costorefacciones,
                        System.Decimal costomanoobra, System.Boolean cargoaconductor, System.String cb, System.Boolean cb_activo,
                            System.String comentarios)
        {
            this.OrdenTrabajo_ID = ordentrabajo_id;
            this.Empresa = empresa;
            this.TipoMantenimiento = tipomantenimiento;
            this.ClienteFactura = clientefactura;
            this.Estatus = estatus;
            this.FolioFactura = foliofactura;
            this.NumeroEconomico = numeroeconomico;
            this.UsuarioCaptura = usuariocaptura;
            this.CodigoBarras = codigobarras;
            this.Subtotal = subtotal;
            this.IVA = iva;
            this.Total = total;
            this.FechaAlta = fechaalta;
            this.FechaInicioReparacion = fechainicioreparacion;
            this.FechaTerminacion = fechaterminacion;
            this.FechaPago = fechapago;
            this.FechaFacturacion = fechafacturacion;
            this.ManoObra = manoobra;
            this.IVAManoObra = ivamanoobra;
            this.IVARefacciones = ivarefacciones;
            this.Kilometraje = kilometraje;
            this.CostoRefacciones = costorefacciones;
            this.CostoManoObra = costomanoobra;
            this.CargoAConductor = cargoaconductor;
            this.CB = cb;
            this.CB_Activo = cb_activo;
            this.Comentarios = comentarios;
        }

        #endregion

        #region Propierties

        private System.Int32 _OrdenTrabajo_ID;
        public System.Int32 OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _TipoMantenimiento;
        public System.String TipoMantenimiento
        {
            get { return _TipoMantenimiento; }
            set { _TipoMantenimiento = value; }
        }

        private System.String _ClienteFactura;
        public System.String ClienteFactura
        {
            get { return _ClienteFactura; }
            set { _ClienteFactura = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.String _FolioFactura;
        public System.String FolioFactura
        {
            get { return _FolioFactura; }
            set { _FolioFactura = value; }
        }

        private System.Int32 _NumeroEconomico;
        public System.Int32 NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.String _UsuarioCaptura;
        public System.String UsuarioCaptura
        {
            get { return _UsuarioCaptura; }
            set { _UsuarioCaptura = value; }
        }

        private System.String _CodigoBarras;
        public System.String CodigoBarras
        {
            get { return _CodigoBarras; }
            set { _CodigoBarras = value; }
        }

        private System.Decimal _Subtotal;
        public System.Decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }

        private System.Decimal _IVA;
        public System.Decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private System.DateTime _FechaAlta;
        public System.DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }

        private System.DateTime? _FechaInicioReparacion;
        public System.DateTime? FechaInicioReparacion
        {
            get { return _FechaInicioReparacion; }
            set { _FechaInicioReparacion = value; }
        }

        private System.DateTime? _FechaTerminacion;
        public System.DateTime? FechaTerminacion
        {
            get { return _FechaTerminacion; }
            set { _FechaTerminacion = value; }
        }

        private System.DateTime? _FechaPago;
        public System.DateTime? FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }

        private System.DateTime? _FechaFacturacion;
        public System.DateTime? FechaFacturacion
        {
            get { return _FechaFacturacion; }
            set { _FechaFacturacion = value; }
        }

        private System.Decimal _ManoObra;
        public System.Decimal ManoObra
        {
            get { return _ManoObra; }
            set { _ManoObra = value; }
        }

        private System.Decimal _IVAManoObra;
        public System.Decimal IVAManoObra
        {
            get { return _IVAManoObra; }
            set { _IVAManoObra = value; }
        }

        private System.Decimal _IVARefacciones;
        public System.Decimal IVARefacciones
        {
            get { return _IVARefacciones; }
            set { _IVARefacciones = value; }
        }

        private System.Int32? _Kilometraje;
        public System.Int32? Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }

        private System.Decimal _CostoRefacciones;
        public System.Decimal CostoRefacciones
        {
            get { return _CostoRefacciones; }
            set { _CostoRefacciones = value; }
        }

        private System.Decimal _CostoManoObra;
        public System.Decimal CostoManoObra
        {
            get { return _CostoManoObra; }
            set { _CostoManoObra = value; }
        }

        private System.Boolean _CargoAConductor;
        public System.Boolean CargoAConductor
        {
            get { return _CargoAConductor; }
            set { _CargoAConductor = value; }
        }

        private System.String _CB;
        public System.String CB
        {
            get { return _CB; }
            set { _CB = value; }
        }

        private System.Boolean _CB_Activo;
        public System.Boolean CB_Activo
        {
            get { return _CB_Activo; }
            set { _CB_Activo = value; }
        }

        private System.String _Comentarios;
        public System.String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Devuelve las ordenes de trabajo abiertas
        /// </summary>
        /// <returns>List<Vista_OrdenesTrabajos></returns>
        public static List<Vista_OrdenesTrabajos> GetOrdenesAbiertas(System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,    
		                E.Nombre Empresa,    
		                TM.Nombre TipoMantenimiento,    
		                EC.Nombre ClienteFactura,    
		                EOT.Nombre Estatus,    
		                F.FolioFiscal FolioFactura,    
		                OT.NumeroEconomico,    
		                OT.Usuario_ID UsuarioCaptura,    
		                OT.CodigoBarras,    
		                OT.Subtotal,    
		                OT.IVA,    
		                OT.Total,    
		                OT.FechaAlta,    
		                OT.FechaInicioReparacion,    
		                OT.FechaTerminacion,    
		                OT.FechaPago,    
		                OT.FechaFacturacion,    
		                OT.ManoObra,    
		                OT.IVAManoObra,    
		                OT.IVARefacciones,    
		                OT.Kilometraje,    
		                OT.CostoRefacciones,    
		                OT.CostoManoObra,    
		                OT.CargoAConductor,    
		                OT.CB,    
		                OT.CB_Activo,    
		                OT.Comentarios	    
                FROM	OrdenesTrabajos OT    
                INNER JOIN	Empresas E    
                ON		OT.Empresa_ID = E.Empresa_ID    
                INNER JOIN	TiposMantenimientos TM    
                ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
                INNER JOIN	Empresas EC    
                ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
                INNER JOIN	Unidades U    
                ON		OT.Unidad_ID = U.Unidad_ID    
                INNER JOIN	EstatusOrdenesTrabajo EOT    
                ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
                LEFT JOIN	Cajas C    
                ON		OT.Caja_ID = C.Caja_ID    
                LEFT JOIN	Facturas F    
                ON		OT.Factura_ID = F.Factura_ID    
                WHERE	OT.EstatusOrdenTrabajo_ID IN (1,2)
                AND     OT.FechaTerminacion IS NULL
                AND     OT.Empresa_ID = @Empresa_ID
                AND     OT.Estacion_ID = @Estacion_ID";

            List<Vista_OrdenesTrabajos> list = new List<Vista_OrdenesTrabajos>();

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["TipoMantenimiento"]), Convert.ToString(dr["ClienteFactura"]), Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["FolioFactura"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["UsuarioCaptura"]),
                          Convert.ToString(dr["CodigoBarras"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]),
                             Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaAlta"]), DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                                DB.GetNullableDateTime(dr["FechaTerminacion"]), DB.GetNullableDateTime(dr["FechaPago"]),
                                    DB.GetNullableDateTime(dr["FechaFacturacion"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["IVAManoObra"]),
                                       Convert.ToDecimal(dr["IVARefacciones"]), DB.GetNullableInt32(dr["Kilometraje"]),
                                          Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToDecimal(dr["CostoManoObra"]),
                                             Convert.ToBoolean(dr["CargoAConductor"]), Convert.ToString(dr["CB"]), Convert.ToBoolean(dr["CB_Activo"]),
                                                Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        public static List<Vista_OrdenesTrabajos> Get(string filters, System.Int32? ordentrabajo_id,
        System.Int32? clientefacturar_id, System.Int32? numeroeconomico, System.String cb, System.DateTime? fechaaltainicial,
        System.DateTime? fechaaltafinal, System.DateTime? fechaterminacioninicial, System.DateTime? fechaterminacionfinal,
        System.Int32 empresa_id,
        System.Int32? estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,    
		                E.Nombre Empresa,    
		                TM.Nombre TipoMantenimiento,    
		                EC.Nombre ClienteFactura,    
		                EOT.Nombre Estatus,    
		                F.FolioFiscal FolioFactura,    
		                OT.NumeroEconomico,    
		                OT.Usuario_ID UsuarioCaptura,    
		                OT.CodigoBarras,    
		                OT.Subtotal,    
		                OT.IVA,    
		                OT.Total,    
		                OT.FechaAlta,    
		                OT.FechaInicioReparacion,    
		                OT.FechaTerminacion,    
		                OT.FechaPago,    
		                OT.FechaFacturacion,    
		                OT.ManoObra,    
		                OT.IVAManoObra,    
		                OT.IVARefacciones,    
		                OT.Kilometraje,    
		                OT.CostoRefacciones,    
		                OT.CostoManoObra,    
		                OT.CargoAConductor,    
		                OT.CB,    
		                OT.CB_Activo,    
		                OT.Comentarios	    
                FROM	OrdenesTrabajos OT    
                INNER JOIN	Empresas E    
                ON		OT.Empresa_ID = E.Empresa_ID    
                INNER JOIN	TiposMantenimientos TM    
                ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
                INNER JOIN	Empresas EC    
                ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
                INNER JOIN	Unidades U    
                ON		OT.Unidad_ID = U.Unidad_ID    
                INNER JOIN	EstatusOrdenesTrabajo EOT    
                ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
                LEFT JOIN	Cajas C    
                ON		OT.Caja_ID = C.Caja_ID    
                LEFT JOIN	Facturas F    
                ON		OT.Factura_ID = F.Factura_ID    
                WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID )     
                AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID )      
                AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico )    
                AND	( @CB IS NULL OR OT.CB = @CB )
                AND	( ( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL ) OR ( OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) )
                AND	( ( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL ) OR ( OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal ) )
                AND ( OT.Empresa_ID = @Empresa_ID )
                AND ( @Estacion_ID IS NULL OR OT.Estacion_ID = @Estacion_ID )";

            if (!string.IsNullOrEmpty(filters)) sqlstr += " AND " + filters;

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@ClienteFacturar_ID", clientefacturar_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@CB", cb);
            m_params.Add("@FechaAltaInicial", fechaaltainicial);
            m_params.Add("@FechaAltaFinal", fechaaltafinal);
            m_params.Add("@FechaTerminacionInicial", fechaterminacioninicial);
            m_params.Add("@FechaTerminacionFinal", fechaterminacionfinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_OrdenesTrabajos> list = new List<Vista_OrdenesTrabajos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["TipoMantenimiento"]), Convert.ToString(dr["ClienteFactura"]), Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["FolioFactura"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["UsuarioCaptura"]),
                          Convert.ToString(dr["CodigoBarras"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]),
                             Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaAlta"]), DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                                DB.GetNullableDateTime(dr["FechaTerminacion"]), DB.GetNullableDateTime(dr["FechaPago"]),
                                    DB.GetNullableDateTime(dr["FechaFacturacion"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["IVAManoObra"]),
                                       Convert.ToDecimal(dr["IVARefacciones"]), DB.GetNullableInt32(dr["Kilometraje"]),
                                          Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToDecimal(dr["CostoManoObra"]),
                                             Convert.ToBoolean(dr["CargoAConductor"]), Convert.ToString(dr["CB"]), Convert.ToBoolean(dr["CB_Activo"]),
                                                Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        public static List<Vista_OrdenesTrabajos> GetFromUser(string filters, System.Int32? ordentrabajo_id,
        System.Int32? clientefacturar_id, System.Int32? numeroeconomico, System.String cb, System.DateTime? fechaaltainicial,
        System.DateTime? fechaaltafinal, System.DateTime? fechaterminacioninicial, System.DateTime? fechaterminacionfinal,
        System.Int32 empresa_id,
        System.Int32? estacion_id,
        System.String usuario_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,    
		                E.Nombre Empresa,    
		                TM.Nombre TipoMantenimiento,    
		                EC.Nombre ClienteFactura,    
		                EOT.Nombre Estatus,    
		                F.FolioFiscal FolioFactura,    
		                OT.NumeroEconomico,    
		                OT.Usuario_ID UsuarioCaptura,    
		                OT.CodigoBarras,    
		                OT.Subtotal,    
		                OT.IVA,    
		                OT.Total,    
		                OT.FechaAlta,    
		                OT.FechaInicioReparacion,    
		                OT.FechaTerminacion,    
		                OT.FechaPago,    
		                OT.FechaFacturacion,    
		                OT.ManoObra,    
		                OT.IVAManoObra,    
		                OT.IVARefacciones,    
		                OT.Kilometraje,    
		                OT.CostoRefacciones,    
		                OT.CostoManoObra,    
		                OT.CargoAConductor,    
		                OT.CB,    
		                OT.CB_Activo,    
		                OT.Comentarios	    
                FROM	OrdenesTrabajos OT    
                INNER JOIN	Empresas E    
                ON		OT.Empresa_ID = E.Empresa_ID    
                INNER JOIN	TiposMantenimientos TM    
                ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
                INNER JOIN	Empresas EC    
                ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
                INNER JOIN	Unidades U    
                ON		OT.Unidad_ID = U.Unidad_ID    
                INNER JOIN	EstatusOrdenesTrabajo EOT    
                ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
                LEFT JOIN	Cajas C    
                ON		OT.Caja_ID = C.Caja_ID    
                LEFT JOIN	Facturas F    
                ON		OT.Factura_ID = F.Factura_ID    
                WHERE	( OT.ClienteFacturar_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
                AND ( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID )     
                AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID )      
                AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico )    
                AND	( @CB IS NULL OR OT.CB = @CB )
                AND	( ( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL ) OR ( OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) )
                AND	( ( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL ) OR ( OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal ) )
                AND ( OT.Empresa_ID = @Empresa_ID )
                AND ( @Estacion_ID IS NULL OR OT.Estacion_ID = @Estacion_ID )";

            if (!string.IsNullOrEmpty(filters)) sqlstr += " AND " + filters;

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@ClienteFacturar_ID", clientefacturar_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@CB", cb);
            m_params.Add("@FechaAltaInicial", fechaaltainicial);
            m_params.Add("@FechaAltaFinal", fechaaltafinal);
            m_params.Add("@FechaTerminacionInicial", fechaterminacioninicial);
            m_params.Add("@FechaTerminacionFinal", fechaterminacionfinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@Usuario_ID", usuario_id);

            List<Vista_OrdenesTrabajos> list = new List<Vista_OrdenesTrabajos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["TipoMantenimiento"]), Convert.ToString(dr["ClienteFactura"]), Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["FolioFactura"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["UsuarioCaptura"]),
                          Convert.ToString(dr["CodigoBarras"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]),
                             Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaAlta"]), DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                                DB.GetNullableDateTime(dr["FechaTerminacion"]), DB.GetNullableDateTime(dr["FechaPago"]),
                                    DB.GetNullableDateTime(dr["FechaFacturacion"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["IVAManoObra"]),
                                       Convert.ToDecimal(dr["IVARefacciones"]), DB.GetNullableInt32(dr["Kilometraje"]),
                                          Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToDecimal(dr["CostoManoObra"]),
                                             Convert.ToBoolean(dr["CargoAConductor"]), Convert.ToString(dr["CB"]), Convert.ToBoolean(dr["CB_Activo"]),
                                                Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(string filters, System.Int32? ordentrabajo_id,
            System.Int32? clientefacturar_id, System.Int32? numeroeconomico, System.String cb, System.DateTime? fechaaltainicial,
               System.DateTime? fechaaltafinal, System.DateTime? fechaterminacioninicial, System.DateTime? fechaterminacionfinal,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,    
		                E.Nombre Empresa,    
		                TM.Nombre TipoMantenimiento,    
		                EC.Nombre ClienteFactura,    
		                EOT.Nombre Estatus,    
		                F.FolioFiscal FolioFactura,    
		                OT.NumeroEconomico,    
		                OT.Usuario_ID UsuarioCaptura,    
		                OT.CodigoBarras,    
		                OT.Subtotal,    
		                OT.IVA,    
		                OT.Total,    
		                OT.FechaAlta,    
		                OT.FechaInicioReparacion,    
		                OT.FechaTerminacion,    
		                OT.FechaPago,    
		                OT.FechaFacturacion,    
		                OT.ManoObra,    
		                OT.IVAManoObra,    
		                OT.IVARefacciones,    
		                OT.Kilometraje,    
		                OT.CostoRefacciones,    
		                OT.CostoManoObra,    
		                OT.CargoAConductor,    
		                OT.CB,    
		                OT.CB_Activo,    
		                OT.Comentarios	    
                FROM	OrdenesTrabajos OT    
                INNER JOIN	Empresas E    
                ON		OT.Empresa_ID = E.Empresa_ID    
                INNER JOIN	TiposMantenimientos TM    
                ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
                INNER JOIN	Empresas EC    
                ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
                INNER JOIN	Unidades U    
                ON		OT.Unidad_ID = U.Unidad_ID    
                INNER JOIN	EstatusOrdenesTrabajo EOT    
                ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
                LEFT JOIN	Cajas C    
                ON		OT.Caja_ID = C.Caja_ID    
                LEFT JOIN	Facturas F    
                ON		OT.Factura_ID = F.Factura_ID    
                WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID )     
                AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID )      
                AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico )    
                AND	( @CB IS NULL OR OT.CB = @CB )
                AND	( ( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL ) OR ( OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) )
                AND	( ( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL ) OR ( OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal ) )
                AND ( OT.Empresa_ID = @Empresa_ID )
                AND ( OT.Estacion_ID = @Estacion_ID )";

            if (!string.IsNullOrEmpty(filters)) sqlstr += " AND " + filters;

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@ClienteFacturar_ID", clientefacturar_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@CB", cb);
            m_params.Add("@FechaAltaInicial", fechaaltainicial);
            m_params.Add("@FechaAltaFinal", fechaaltafinal);
            m_params.Add("@FechaTerminacionInicial", fechaterminacioninicial);
            m_params.Add("@FechaTerminacionFinal", fechaterminacionfinal);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);

        } // End GetData

        public static List<Vista_OrdenesTrabajos> Get(System.Int32? ordentrabajo_id, System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = @"SELECT	OT.OrdenTrabajo_ID,    
		                E.Nombre Empresa,    
		                TM.Nombre TipoMantenimiento,    
		                EC.Nombre ClienteFactura,    
		                EOT.Nombre Estatus,    
		                F.FolioFiscal FolioFactura,    
		                OT.NumeroEconomico,    
		                OT.Usuario_ID UsuarioCaptura,    
		                OT.CodigoBarras,    
		                OT.Subtotal,    
		                OT.IVA,    
		                OT.Total,    
		                OT.FechaAlta,    
		                OT.FechaInicioReparacion,    
		                OT.FechaTerminacion,    
		                OT.FechaPago,    
		                OT.FechaFacturacion,    
		                OT.ManoObra,    
		                OT.IVAManoObra,    
		                OT.IVARefacciones,    
		                OT.Kilometraje,    
		                OT.CostoRefacciones,    
		                OT.CostoManoObra,    
		                OT.CargoAConductor,    
		                OT.CB,    
		                OT.CB_Activo,    
		                OT.Comentarios	    
                FROM	OrdenesTrabajos OT    
                INNER JOIN	Empresas E    
                ON		OT.Empresa_ID = E.Empresa_ID    
                INNER JOIN	TiposMantenimientos TM    
                ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
                INNER JOIN	Empresas EC    
                ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
                INNER JOIN	Unidades U    
                ON		OT.Unidad_ID = U.Unidad_ID    
                INNER JOIN	EstatusOrdenesTrabajo EOT    
                ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
                LEFT JOIN	Cajas C    
                ON		OT.Caja_ID = C.Caja_ID    
                LEFT JOIN	Facturas F    
                ON		OT.Factura_ID = F.Factura_ID    
                WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID )
                AND ( OT.Empresa_ID = @Empresa_ID )
                AND ( OT.Estacion_ID = @Estacion_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_OrdenesTrabajos> list = new List<Vista_OrdenesTrabajos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_OrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Empresa"]),
                    Convert.ToString(dr["TipoMantenimiento"]), Convert.ToString(dr["ClienteFactura"]), Convert.ToString(dr["Estatus"]),
                       Convert.ToString(dr["FolioFactura"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["UsuarioCaptura"]),
                          Convert.ToString(dr["CodigoBarras"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]),
                             Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaAlta"]), DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                                DB.GetNullableDateTime(dr["FechaTerminacion"]), DB.GetNullableDateTime(dr["FechaPago"]),
                                    DB.GetNullableDateTime(dr["FechaFacturacion"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["IVAManoObra"]),
                                       Convert.ToDecimal(dr["IVARefacciones"]), DB.GetNullableInt32(dr["Kilometraje"]),
                                          Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToDecimal(dr["CostoManoObra"]),
                                             Convert.ToBoolean(dr["CargoAConductor"]), Convert.ToString(dr["CB"]), Convert.ToBoolean(dr["CB_Activo"]),
                                                Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        /*
        public static List<Vista_OrdenesTrabajos> Get(System.Int32? ordentrabajo_id, System.Int32? empresa_id, System.Int32? tipomantenimiento_id, 
            System.Int32? clientefacturar_id, System.Int32? estatusordentrabajo_id, System.Int32? numeroeconomico, System.DateTime? fechaaltainicial,
               System.DateTime? fechaaltafinal, System.DateTime? fechaterminacioninicial, System.DateTime? fechaterminacionfinal)
        {
            string sqlstr = "SELECT	OT.OrdenTrabajo_ID, \r\n" +
            "		E.Nombre Empresa, \r\n" +
            "		TM.Nombre TipoMantenimiento, \r\n" +
            "		EC.Nombre ClienteFactura, \r\n" +
            "		EOT.Nombre Estatus, \r\n" +
            "		F.FolioFiscal FolioFactura, \r\n" +
            "		OT.NumeroEconomico, \r\n" +
            "		OT.Usuario_ID UsuarioCaptura, \r\n" +
            "		OT.CodigoBarras, \r\n" +
            "		OT.Subtotal, \r\n" +
            "		OT.IVA, \r\n" +
            "		OT.Total, \r\n" +
            "		OT.FechaAlta, \r\n" +
            "		OT.FechaInicioReparacion, \r\n" +
            "		OT.FechaTerminacion, \r\n" +
            "		OT.FechaPago, \r\n" +
            "		OT.FechaFacturacion, \r\n" +
            "		OT.ManoObra, \r\n" +
            "		OT.IVAManoObra, \r\n" +
            "		OT.IVARefacciones, \r\n" +
            "		OT.Kilometraje, \r\n" +
            "		OT.CostoRefacciones, \r\n" +
            "		OT.CostoManoObra, \r\n" +
            "		OT.CargoAConductor, \r\n" +
            "		OT.CB, \r\n" +
            "		OT.CB_Activo, \r\n" +
            "		OT.Comentarios	 \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	TiposMantenimientos TM \r\n" +
            "ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID \r\n" +
            "INNER JOIN	Empresas EC \r\n" +
            "ON		OT.ClienteFacturar_ID = EC.Empresa_ID \r\n" +
            "INNER JOIN	Unidades U \r\n" +
            "ON		OT.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	EstatusOrdenesTrabajo EOT \r\n" +
            "ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID \r\n" +
            "LEFT JOIN	Cajas C \r\n" +
            "ON		OT.Caja_ID = C.Caja_ID \r\n" +
            "LEFT JOIN	Facturas F \r\n" +
            "ON		OT.Factura_ID = F.Factura_ID \r\n" +
            "WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID ) \r\n" +
            "AND	( @Empresa_ID IS NULL OR OT.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND	( @TipoMantenimiento_ID IS NULL OR OT.TipoMantenimiento_ID = @TipoMantenimiento_ID ) \r\n" +
            "AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID ) \r\n" +
            "AND	( @EstatusOrdenTrabajo_ID IS NULL OR OT.EstatusOrdenTrabajo_ID = @EstatusOrdenTrabajo_ID ) \r\n" +
            "AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico ) \r\n" +
            "AND	( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL OR OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) \r\n" +
            "AND	( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL OR OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@TipoMantenimiento_ID", tipomantenimiento_id);
            m_params.Add("@ClienteFacturar_ID", clientefacturar_id);
            m_params.Add("@EstatusOrdenTrabajo_ID", estatusordentrabajo_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@FechaAltaInicial", fechaaltainicial);
            m_params.Add("@FechaAltaFinal", fechaaltafinal);
            m_params.Add("@FechaTerminacionInicial", fechaterminacioninicial);
            m_params.Add("@FechaTerminacionFinal", fechaterminacionfinal);

            List<Vista_OrdenesTrabajos> list = new List<Vista_OrdenesTrabajos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
               list.Add(new Vista_OrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Empresa"]), 
                  Convert.ToString(dr["TipoMantenimiento"]), Convert.ToString(dr["ClienteFactura"]), Convert.ToString(dr["Estatus"]), 
                     Convert.ToString(dr["FolioFactura"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["UsuarioCaptura"]), 
                        Convert.ToString(dr["CodigoBarras"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["IVA"]), 
                            Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaAlta"]), DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                               DB.GetNullableDateTime(dr["FechaTerminacion"]), DB.GetNullableDateTime(dr["FechaPago"]),
                                  DB.GetNullableDateTime(dr["FechaFacturacion"]), Convert.ToDecimal(dr["ManoObra"]), Convert.ToDecimal(dr["IVAManoObra"]),
                                     Convert.ToDecimal(dr["IVARefacciones"]), DB.GetNullableInt32(dr["Kilometraje"]), 
                                        Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToDecimal(dr["CostoManoObra"]), 
                                            Convert.ToBoolean(dr["CargoAConductor"]), Convert.ToString(dr["CB"]), Convert.ToBoolean(dr["CB_Activo"]), 
                                               Convert.ToString(dr["Comentarios"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ordentrabajo_id, System.Object empresa_id, System.Object tipomantenimiento_id, System.Object clientefacturar_id, System.Object estatusordentrabajo_id, System.Int32 numeroeconomico, System.Object fechaaltainicial, System.Object fechaaltafinal, System.Object fechaterminacioninicial, System.Object fechaterminacionfinal)
        {
            string sqlstr = "SELECT	OT.OrdenTrabajo_ID, \r\n" +
            "		E.Nombre Empresa, \r\n" +
            "		TM.Nombre TipoMantenimiento, \r\n" +
            "		EC.Nombre ClienteFactura, \r\n" +
            "		EOT.Nombre Estatus, \r\n" +
            "		F.FolioFiscal FolioFactura, \r\n" +
            "		OT.NumeroEconomico, \r\n" +
            "		OT.Usuario_ID UsuarioCaptura, \r\n" +
            "		OT.CodigoBarras, \r\n" +
            "		OT.Subtotal, \r\n" +
            "		OT.IVA, \r\n" +
            "		OT.Total, \r\n" +
            "		OT.FechaAlta, \r\n" +
            "		OT.FechaInicioReparacion, \r\n" +
            "		OT.FechaTerminacion, \r\n" +
            "		OT.FechaPago, \r\n" +
            "		OT.FechaFacturacion, \r\n" +
            "		OT.ManoObra, \r\n" +
            "		OT.IVAManoObra, \r\n" +
            "		OT.IVARefacciones, \r\n" +
            "		OT.Kilometraje, \r\n" +
            "		OT.CostoRefacciones, \r\n" +
            "		OT.CostoManoObra, \r\n" +
            "		OT.CargoAConductor, \r\n" +
            "		OT.CB, \r\n" +
            "		OT.CB_Activo, \r\n" +
            "		OT.Comentarios	 \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		OT.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	TiposMantenimientos TM \r\n" +
            "ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID \r\n" +
            "INNER JOIN	Empresas EC \r\n" +
            "ON		OT.ClienteFacturar_ID = EC.Empresa_ID \r\n" +
            "INNER JOIN	Unidades U \r\n" +
            "ON		OT.Unidad_ID = U.Unidad_ID \r\n" +
            "INNER JOIN	EstatusOrdenesTrabajo EOT \r\n" +
            "ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID \r\n" +
            "LEFT JOIN	Cajas C \r\n" +
            "ON		OT.Caja_ID = C.Caja_ID \r\n" +
            "LEFT JOIN	Facturas F \r\n" +
            "ON		OT.Factura_ID = F.Factura_ID \r\n" +
            "WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID ) \r\n" +
            "AND	( @Empresa_ID IS NULL OR OT.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND	( @TipoMantenimiento_ID IS NULL OR OT.TipoMantenimiento_ID = @TipoMantenimiento_ID ) \r\n" +
            "AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID ) \r\n" +
            "AND	( @EstatusOrdenTrabajo_ID IS NULL OR OT.EstatusOrdenTrabajo_ID = @EstatusOrdenTrabajo_ID ) \r\n" +
            "AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico ) \r\n" +
            "AND	( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL OR OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) \r\n" +
            "AND	( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL OR OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@OrdenTrabajo_ID", ordentrabajo_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@TipoMantenimiento_ID", tipomantenimiento_id);
            m_params.Add("@ClienteFacturar_ID", clientefacturar_id);
            m_params.Add("@EstatusOrdenTrabajo_ID", estatusordentrabajo_id);
            m_params.Add("@NumeroEconomico", numeroeconomico);
            m_params.Add("@FechaAltaInicial", fechaaltainicial);
            m_params.Add("@FechaAltaFinal", fechaaltafinal);
            m_params.Add("@FechaTerminacionInicial", fechaterminacioninicial);
            m_params.Add("@FechaTerminacionFinal", fechaterminacionfinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable
        */
        #endregion

    } // End Class Vista_OrdenesTrabajos

    public class SelectTiposRefacciones
    {

        public SelectTiposRefacciones()
        {
        }

        public SelectTiposRefacciones(System.Int32? tiporefaccion_id, System.String nombre)
        {
            this.TipoRefaccion_ID = tiporefaccion_id;
            this.Nombre = nombre;
        }

        private System.Int32? _TipoRefaccion_ID;
        public System.Int32? TipoRefaccion_ID
        {
            get { return _TipoRefaccion_ID; }
            set { _TipoRefaccion_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposRefacciones> Get()
        {
            string sqlstr = "SELECT	NULL TipoRefaccion_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoRefaccion_ID, Nombre \r\n" +
            "FROM	TiposRefacciones \r\n" +
            "ORDER BY Nombre";

            List<SelectTiposRefacciones> list = new List<SelectTiposRefacciones>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectTiposRefacciones(DB.GetNullableInt32(dr["TipoRefaccion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL TipoRefaccion_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoRefaccion_ID, Nombre \r\n" +
            "FROM	TiposRefacciones \r\n" +
            "ORDER BY Nombre";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectTiposRefacciones

    public class SelectMarcasRefacciones
    {

        public SelectMarcasRefacciones()
        {
        }

        public SelectMarcasRefacciones(System.Int32? marcarefaccion_id, System.String nombre)
        {
            this.MarcaRefaccion_ID = marcarefaccion_id;
            this.Nombre = nombre;
        }

        private System.Int32? _MarcaRefaccion_ID;
        public System.Int32? MarcaRefaccion_ID
        {
            get { return _MarcaRefaccion_ID; }
            set { _MarcaRefaccion_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectMarcasRefacciones> Get()
        {
            string sqlstr = "SELECT	NULL MarcaRefaccion_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	MarcaRefaccion_ID, Nombre \r\n" +
            "FROM	MarcasRefacciones \r\n" +
            "ORDER BY Nombre";

            List<SelectMarcasRefacciones> list = new List<SelectMarcasRefacciones>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectMarcasRefacciones(DB.GetNullableInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL MarcaRefaccion_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	MarcaRefaccion_ID, Nombre \r\n" +
            "FROM	MarcasRefacciones \r\n" +
            "ORDER BY Nombre";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectMarcasRefacciones

    public class Vista_Refacciones
    {

        #region Constructors
        public Vista_Refacciones()
        {
        }

        public Vista_Refacciones(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String familia,
            System.String tipo,
            System.String modelo,
            System.String marca,
            System.String numeroserial,
            System.String descripcion,
            System.Int32? anio,
            System.String pasillo,
            System.String estante,
            System.String seccion,
            System.Decimal? costounitario,
            System.Decimal? preciointerno,
            System.Decimal? precioexterno,
            System.Decimal? margeninterno,
            System.Decimal? margenexterno,
            System.Int32? cantidadinventario,
            System.Decimal? valorinventario,
            System.Int32? puntodereorden
            )
        {
            this.Refaccion_ID = refaccion_id;
            this.TipoRefaccion_ID = tiporefaccion_id;
            this.Modelo_ID = modelo_id;
            this.MarcaRefaccion_ID = marcarefaccion_id;
            this.Familia = familia;
            this.Tipo = tipo;
            this.Modelo = modelo;
            this.Marca = marca;
            this.NumeroSerial = numeroserial;
            this.Descripcion = descripcion;
            this.Anio = anio;
            this.Pasillo = pasillo;
            this.Estante = estante;
            this.Seccion = seccion;
            this.CostoUnitario = costounitario;
            this.PrecioInterno = preciointerno;
            this.PrecioExterno = precioexterno;
            this.MargenInterno = margeninterno;
            this.MargenExterno = margenexterno;
            this.CantidadInventario = cantidadinventario;
            this.ValorInventario = valorinventario;
            this.PuntoDeReOrden = puntodereorden;
        }

        #endregion

        #region Properties
        private System.Int32? _Refaccion_ID;
        public System.Int32? Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private System.Int32? _TipoRefaccion_ID;
        public System.Int32? TipoRefaccion_ID
        {
            get { return _TipoRefaccion_ID; }
            set { _TipoRefaccion_ID = value; }
        }

        private System.Int32? _Modelo_ID;
        public System.Int32? Modelo_ID
        {
            get { return _Modelo_ID; }
            set { _Modelo_ID = value; }
        }

        private System.Int32? _MarcaRefaccion_ID;
        public System.Int32? MarcaRefaccion_ID
        {
            get { return _MarcaRefaccion_ID; }
            set { _MarcaRefaccion_ID = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.String _Marca;
        public System.String Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        private System.String _NumeroSerial;
        public System.String NumeroSerial
        {
            get { return _NumeroSerial; }
            set { _NumeroSerial = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private System.Int32? _Anio;
        public System.Int32? Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private System.String _Pasillo;
        public System.String Pasillo
        {
            get { return _Pasillo; }
            set { _Pasillo = value; }
        }

        private System.String _Estante;
        public System.String Estante
        {
            get { return _Estante; }
            set { _Estante = value; }
        }

        private System.String _Seccion;
        public System.String Seccion
        {
            get { return _Seccion; }
            set { _Seccion = value; }
        }

        private System.Decimal? _CostoUnitario;
        public System.Decimal? CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        private System.Decimal? _PrecioInterno;
        public System.Decimal? PrecioInterno
        {
            get { return _PrecioInterno; }
            set { _PrecioInterno = value; }
        }

        private System.Decimal? _PrecioExterno;
        public System.Decimal? PrecioExterno
        {
            get { return _PrecioExterno; }
            set { _PrecioExterno = value; }
        }

        private System.Decimal? _MargenInterno;
        public System.Decimal? MargenInterno
        {
            get { return _MargenInterno; }
            set { _MargenInterno = value; }
        }

        private System.Decimal? _MargenExterno;
        public System.Decimal? MargenExterno
        {
            get { return _MargenExterno; }
            set { _MargenExterno = value; }
        }

        private System.Int32? _CantidadInventario;
        public System.Int32? CantidadInventario
        {
            get { return _CantidadInventario; }
            set { _CantidadInventario = value; }
        }

        private System.Decimal? _ValorInventario;
        public System.Decimal? ValorInventario
        {
            get { return _ValorInventario; }
            set { _ValorInventario = value; }
        }

        private System.Int32? _PuntoDeReOrden;
        public System.Int32? PuntoDeReOrden
        {
            get { return _PuntoDeReOrden; }
            set { _PuntoDeReOrden = value; }
        }

        #endregion

        #region Methods

        public static List<Vista_Refacciones> GetListado(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Object familia_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String descripcion,
            System.String numeroserial,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	R.Refaccion_ID, 
		R.TipoRefaccion_ID,
		R.Modelo_ID,
		R.MarcaRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre Tipo, MU.Nombre Modelo, 
		MR.Nombre Marca,  
		R.NumeroSerial, R.Descripcion, 
		R.Anio, I.Pasillo, I.Estante, I.Seccion, 
		I.CostoUnitario, I.PrecioInterno, 
		I.PrecioExterno, I.MargenInterno, I.MargenExterno, I.CantidadInventario, 
		I.ValorInventario, I.PuntoDeReOrden 
FROM	Refacciones	R
LEFT JOIN	Inventario I
ON		R.Refaccion_ID = I.Refaccion_ID
INNER JOIN	TiposRefacciones TR 
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID 
INNER JOIN	Modelos MU 
ON		R.Modelo_ID = MU.Modelo_ID 
INNER JOIN	MarcasRefacciones MR 
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
INNER JOIN	Familias F
ON		F.Familia_ID = TR.Familia_ID 
WHERE	( @Refaccion_ID IS NULL OR R.Refaccion_ID = @Refaccion_ID ) 
AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) 
AND		( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID )
AND		( @Modelo_ID IS NULL OR R.Modelo_ID = @Modelo_ID ) 
AND		( @MarcaRefaccion_ID IS NULL OR R.MarcaRefaccion_ID = @MarcaRefaccion_ID ) 
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @NumeroSerial IS NULL OR R.NumeroSerial LIKE @NumeroSerial + '%' )
AND		( I.Empresa_ID = @Empresa_ID )
AND		( I.Estacion_ID = @Estacion_ID )
AND     I.CantidadInventario > 0
ORDER BY	Familia, Descripcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Refaccion_ID", refaccion_id);
            m_params.Add("@TipoRefaccion_ID", tiporefaccion_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@MarcaRefaccion_ID", marcarefaccion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroSerial", numeroserial);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Refacciones> list = new List<Vista_Refacciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Refacciones(
                       DB.GetNullableInt32(dr["Refaccion_ID"]),
                       DB.GetNullableInt32(dr["TipoRefaccion_ID"]),
                       DB.GetNullableInt32(dr["Modelo_ID"]),
                       DB.GetNullableInt32(dr["MarcaRefaccion_ID"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Marca"]),
                       Convert.ToString(dr["NumeroSerial"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       Convert.ToString(dr["Pasillo"]),
                       Convert.ToString(dr["Estante"]),
                       Convert.ToString(dr["Seccion"]),
                       DB.GetNullableDecimal(dr["CostoUnitario"]),
                       DB.GetNullableDecimal(dr["PrecioInterno"]),
                       DB.GetNullableDecimal(dr["PrecioExterno"]),
                       DB.GetNullableDecimal(dr["MargenInterno"]),
                       DB.GetNullableDecimal(dr["MargenExterno"]),
                       DB.GetNullableInt32(dr["CantidadInventario"]),
                       DB.GetNullableDecimal(dr["ValorInventario"]),
                       DB.GetNullableInt32(dr["PuntoDeReOrden"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Refacciones> GetInventario(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Object familia_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String descripcion,
            System.String numeroserial,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	R.Refaccion_ID, 
		R.TipoRefaccion_ID,
		R.Modelo_ID,
		R.MarcaRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre Tipo, MU.Nombre Modelo, 
		MR.Nombre Marca,  
		R.NumeroSerial, R.Descripcion, 
		R.Anio, I.Pasillo, I.Estante, I.Seccion, 
		I.CostoUnitario, I.PrecioInterno, 
		I.PrecioExterno, I.MargenInterno, I.MargenExterno, I.CantidadInventario, 
		I.ValorInventario, I.PuntoDeReOrden 
FROM	Refacciones	R
LEFT JOIN	Inventario I
ON		R.Refaccion_ID = I.Refaccion_ID
INNER JOIN	TiposRefacciones TR 
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID 
INNER JOIN	Modelos MU 
ON		R.Modelo_ID = MU.Modelo_ID 
INNER JOIN	MarcasRefacciones MR 
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
INNER JOIN	Familias F
ON		F.Familia_ID = TR.Familia_ID 
WHERE	( @Refaccion_ID IS NULL OR R.Refaccion_ID = @Refaccion_ID ) 
AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) 
AND		( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID )
AND		( @Modelo_ID IS NULL OR R.Modelo_ID = @Modelo_ID ) 
AND		( @MarcaRefaccion_ID IS NULL OR R.MarcaRefaccion_ID = @MarcaRefaccion_ID ) 
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @NumeroSerial IS NULL OR R.NumeroSerial LIKE @NumeroSerial + '%' )
AND		( I.Empresa_ID = @Empresa_ID )
AND		( I.Estacion_ID = @Estacion_ID )
AND     I.CantidadInventario > 0
ORDER BY	Familia, Descripcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Refaccion_ID", refaccion_id);
            m_params.Add("@TipoRefaccion_ID", tiporefaccion_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@MarcaRefaccion_ID", marcarefaccion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroSerial", numeroserial);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Refacciones> list = new List<Vista_Refacciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Refacciones(
                       DB.GetNullableInt32(dr["Refaccion_ID"]),
                       DB.GetNullableInt32(dr["TipoRefaccion_ID"]),
                       DB.GetNullableInt32(dr["Modelo_ID"]),
                       DB.GetNullableInt32(dr["MarcaRefaccion_ID"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Marca"]),
                       Convert.ToString(dr["NumeroSerial"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       Convert.ToString(dr["Pasillo"]),
                       Convert.ToString(dr["Estante"]),
                       Convert.ToString(dr["Seccion"]),
                       DB.GetNullableDecimal(dr["CostoUnitario"]),
                       DB.GetNullableDecimal(dr["PrecioInterno"]),
                       DB.GetNullableDecimal(dr["PrecioExterno"]),
                       DB.GetNullableDecimal(dr["MargenInterno"]),
                       DB.GetNullableDecimal(dr["MargenExterno"]),
                       DB.GetNullableInt32(dr["CantidadInventario"]),
                       DB.GetNullableDecimal(dr["ValorInventario"]),
                       DB.GetNullableInt32(dr["PuntoDeReOrden"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_Refacciones> Get(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Object familia_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String descripcion,
            System.String numeroserial,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	R.Refaccion_ID, 
		R.TipoRefaccion_ID,
		R.Modelo_ID,
		R.MarcaRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre Tipo, MU.Nombre Modelo, 
		MR.Nombre Marca,  
		R.NumeroSerial, R.Descripcion, 
		R.Anio, I.Pasillo, I.Estante, I.Seccion, 
		I.CostoUnitario, I.PrecioInterno, 
		I.PrecioExterno, I.MargenInterno, I.MargenExterno, I.CantidadInventario, 
		I.ValorInventario, I.PuntoDeReOrden 
FROM	Refacciones	R
LEFT JOIN	Inventario I
ON		( R.Refaccion_ID = I.Refaccion_ID
        AND		I.Empresa_ID = @Empresa_ID
        AND		I.Estacion_ID = @Estacion_ID )
INNER JOIN	TiposRefacciones TR 
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID 
INNER JOIN	Modelos MU 
ON		R.Modelo_ID = MU.Modelo_ID 
INNER JOIN	MarcasRefacciones MR 
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
INNER JOIN	Familias F
ON		F.Familia_ID = TR.Familia_ID 
WHERE	( @Refaccion_ID IS NULL OR R.Refaccion_ID = @Refaccion_ID ) 
AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) 
AND		( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID )
AND		( @Modelo_ID IS NULL OR R.Modelo_ID = @Modelo_ID ) 
AND		( @MarcaRefaccion_ID IS NULL OR R.MarcaRefaccion_ID = @MarcaRefaccion_ID ) 
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @NumeroSerial IS NULL OR R.NumeroSerial LIKE @NumeroSerial + '%' )
ORDER BY	Familia, Descripcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Refaccion_ID", refaccion_id);
            m_params.Add("@TipoRefaccion_ID", tiporefaccion_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@MarcaRefaccion_ID", marcarefaccion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroSerial", numeroserial);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Refacciones> list = new List<Vista_Refacciones>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Refacciones(
                       DB.GetNullableInt32(dr["Refaccion_ID"]),
                       DB.GetNullableInt32(dr["TipoRefaccion_ID"]),
                       DB.GetNullableInt32(dr["Modelo_ID"]),
                       DB.GetNullableInt32(dr["MarcaRefaccion_ID"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Marca"]),
                       Convert.ToString(dr["NumeroSerial"]),
                       Convert.ToString(dr["Descripcion"]),
                       DB.GetNullableInt32(dr["Anio"]),
                       Convert.ToString(dr["Pasillo"]),
                       Convert.ToString(dr["Estante"]),
                       Convert.ToString(dr["Seccion"]),
                       DB.GetNullableDecimal(dr["CostoUnitario"]),
                       DB.GetNullableDecimal(dr["PrecioInterno"]),
                       DB.GetNullableDecimal(dr["PrecioExterno"]),
                       DB.GetNullableDecimal(dr["MargenInterno"]),
                       DB.GetNullableDecimal(dr["MargenExterno"]),
                       DB.GetNullableInt32(dr["CantidadInventario"]),
                       DB.GetNullableDecimal(dr["ValorInventario"]),
                       DB.GetNullableInt32(dr["PuntoDeReOrden"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static Vista_Refacciones GetSingle(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Object familia_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String descripcion,
            System.String numeroserial,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	R.Refaccion_ID, 
		R.TipoRefaccion_ID,
		R.Modelo_ID,
		R.MarcaRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre Tipo, MU.Nombre Modelo, 
		MR.Nombre Marca,  
		R.NumeroSerial, R.Descripcion, 
		R.Anio, I.Pasillo, I.Estante, I.Seccion, 
		I.CostoUnitario, I.PrecioInterno, 
		I.PrecioExterno, I.MargenInterno, I.MargenExterno, I.CantidadInventario, 
		I.ValorInventario, I.PuntoDeReOrden 
FROM	Refacciones	R
LEFT JOIN	Inventario I
ON		R.Refaccion_ID = I.Refaccion_ID
INNER JOIN	TiposRefacciones TR 
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID 
INNER JOIN	Modelos MU 
ON		R.Modelo_ID = MU.Modelo_ID 
INNER JOIN	MarcasRefacciones MR 
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
INNER JOIN	Familias F
ON		F.Familia_ID = TR.Familia_ID 
WHERE	( @Refaccion_ID IS NULL OR R.Refaccion_ID = @Refaccion_ID ) 
AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) 
AND		( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID )
AND		( @Modelo_ID IS NULL OR R.Modelo_ID = @Modelo_ID ) 
AND		( @MarcaRefaccion_ID IS NULL OR R.MarcaRefaccion_ID = @MarcaRefaccion_ID ) 
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @NumeroSerial IS NULL OR R.NumeroSerial LIKE @NumeroSerial + '%' )
AND		( I.Empresa_ID = @Empresa_ID )
AND		( I.Estacion_ID = @Estacion_ID )
ORDER BY	Familia, Descripcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Refaccion_ID", refaccion_id);
            m_params.Add("@TipoRefaccion_ID", tiporefaccion_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@MarcaRefaccion_ID", marcarefaccion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroSerial", numeroserial);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];

            return new Vista_Refacciones(
                      DB.GetNullableInt32(dr["Refaccion_ID"]),
                      DB.GetNullableInt32(dr["TipoRefaccion_ID"]),
                      DB.GetNullableInt32(dr["Modelo_ID"]),
                      DB.GetNullableInt32(dr["MarcaRefaccion_ID"]),
                      Convert.ToString(dr["Familia"]),
                      Convert.ToString(dr["Tipo"]),
                      Convert.ToString(dr["Modelo"]),
                      Convert.ToString(dr["Marca"]),
                      Convert.ToString(dr["NumeroSerial"]),
                      Convert.ToString(dr["Descripcion"]),
                      DB.GetNullableInt32(dr["Anio"]),
                      Convert.ToString(dr["Pasillo"]),
                      Convert.ToString(dr["Estante"]),
                      Convert.ToString(dr["Seccion"]),
                      DB.GetNullableDecimal(dr["CostoUnitario"]),
                      DB.GetNullableDecimal(dr["PrecioInterno"]),
                      DB.GetNullableDecimal(dr["PrecioExterno"]),
                      DB.GetNullableDecimal(dr["MargenInterno"]),
                      DB.GetNullableDecimal(dr["MargenExterno"]),
                      DB.GetNullableInt32(dr["CantidadInventario"]),
                      DB.GetNullableDecimal(dr["ValorInventario"]),
                      DB.GetNullableInt32(dr["PuntoDeReOrden"])
                   );
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? refaccion_id,
            System.Int32? tiporefaccion_id,
            System.Object familia_id,
            System.Int32? modelo_id,
            System.Int32? marcarefaccion_id,
            System.String descripcion,
            System.String numeroserial,
            System.Object empresa_id,
            System.Object estacion_id)
        {
            string sqlstr = @"SELECT	R.Refaccion_ID, 
		R.TipoRefaccion_ID,
		R.Modelo_ID,
		R.MarcaRefaccion_ID,
		F.Nombre Familia,
		TR.Nombre Tipo, MU.Nombre Modelo, 
		MR.Nombre Marca,  
		R.NumeroSerial, R.Descripcion, 
		R.Anio, I.Pasillo, I.Estante, I.Seccion, 
		I.CostoUnitario, I.PrecioInterno, 
		I.PrecioExterno, I.MargenInterno, I.MargenExterno, I.CantidadInventario, 
		I.ValorInventario, I.PuntoDeReOrden 
FROM	Refacciones	R
LEFT JOIN	Inventario I
ON		R.Refaccion_ID = I.Refaccion_ID
INNER JOIN	TiposRefacciones TR 
ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID 
INNER JOIN	Modelos MU 
ON		R.Modelo_ID = MU.Modelo_ID 
INNER JOIN	MarcasRefacciones MR 
ON		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID
INNER JOIN	Familias F
ON		F.Familia_ID = TR.Familia_ID 
WHERE	( @Refaccion_ID IS NULL OR R.Refaccion_ID = @Refaccion_ID ) 
AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) 
AND		( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID )
AND		( @Modelo_ID IS NULL OR R.Modelo_ID = @Modelo_ID ) 
AND		( @MarcaRefaccion_ID IS NULL OR R.MarcaRefaccion_ID = @MarcaRefaccion_ID ) 
AND		( @Descripcion IS NULL OR R.Descripcion LIKE @Descripcion + '%' )
AND		( @NumeroSerial IS NULL OR R.NumeroSerial LIKE @NumeroSerial + '%' )
AND		( I.Empresa_ID = @Empresa_ID )
AND		( I.Estacion_ID = @Estacion_ID )
ORDER BY	Familia, Descripcion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Refaccion_ID", refaccion_id);
            m_params.Add("@TipoRefaccion_ID", tiporefaccion_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@MarcaRefaccion_ID", marcarefaccion_id);
            m_params.Add("@Descripcion", descripcion);
            m_params.Add("@NumeroSerial", numeroserial);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Refacciones



    public class Vista_TiposMantenimientos
    {

        public Vista_TiposMantenimientos()
        {
        }

        public Vista_TiposMantenimientos(System.Int32 tipomantenimiento_id, System.String nombre, System.Boolean activo)
        {
            this.TipoMantenimiento_ID = tipomantenimiento_id;
            this.Nombre = nombre;
            this.Activo = activo;
        }

        private System.Int32 _TipoMantenimiento_ID;
        public System.Int32 TipoMantenimiento_ID
        {
            get { return _TipoMantenimiento_ID; }
            set { _TipoMantenimiento_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Boolean _Activo;
        public System.Boolean Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        public static List<Vista_TiposMantenimientos> Get(System.Int32? tipomantenimiento_id, System.String nombre)
        {
            string sqlstr = "SELECT	TM.TipoMantenimiento_ID, TM.Nombre, TM.Activo \r\n" +
            "FROM	TiposMantenimientos TM \r\n" +
            "WHERE	( @TipoMantenimiento_ID IS NULL OR TM.TipoMantenimiento_ID = @TipoMantenimiento_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR TM.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoMantenimiento_ID", tipomantenimiento_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_TiposMantenimientos> list = new List<Vista_TiposMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_TiposMantenimientos(Convert.ToInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activo"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? tipomantenimiento_id, System.String nombre)
        {
            string sqlstr = "SELECT	TM.TipoMantenimiento_ID, TM.Nombre, TM.Activo \r\n" +
            "FROM	TiposMantenimientos TM \r\n" +
            "WHERE	( @TipoMantenimiento_ID IS NULL OR TM.TipoMantenimiento_ID = @TipoMantenimiento_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR TM.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@TipoMantenimiento_ID", tipomantenimiento_id);
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_TiposMantenimientos

    public class Vista_CategoriasMecanicos
    {

        public Vista_CategoriasMecanicos()
        {
        }

        public Vista_CategoriasMecanicos(System.Int32? categoriamecanico_id, System.String familia, System.String nombre)
        {
            this.CategoriaMecanico_ID = categoriamecanico_id;
            this.Familia = familia;
            this.Nombre = nombre;
        }

        private System.Int32? _CategoriaMecanico_ID;
        public System.Int32? CategoriaMecanico_ID
        {
            get { return _CategoriaMecanico_ID; }
            set { _CategoriaMecanico_ID = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<Vista_CategoriasMecanicos> Get(System.Int32? categoriamecanico_id, System.Object familia_id, System.String nombre)
        {
            string sqlstr = "SELECT	CM.CategoriaMecanico_ID, F.Nombre Familia, CM.Nombre \r\n" +
            "FROM	CategoriasMecanicos CM \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		CM.Familia_ID = F.Familia_ID \r\n" +
            "WHERE	( @CategoriaMecanico_ID IS NULL OR CM.CategoriaMecanico_ID = @CategoriaMecanico_ID ) \r\n" +
            "AND		( @Familia_ID IS NULL OR CM.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR CM.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@CategoriaMecanico_ID", categoriamecanico_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_CategoriasMecanicos> list = new List<Vista_CategoriasMecanicos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_CategoriasMecanicos(Convert.ToInt32(dr["CategoriaMecanico_ID"]), Convert.ToString(dr["Familia"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? categoriamecanico_id, System.Object familia_id, System.String nombre)
        {
            string sqlstr = "SELECT	CM.CategoriaMecanico_ID, F.Nombre Familia, CM.Nombre \r\n" +
            "FROM	CategoriasMecanicos CM \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		CM.Familia_ID = F.Familia_ID \r\n" +
            "WHERE	( @CategoriaMecanico_ID IS NULL OR CM.CategoriaMecanico_ID = @CategoriaMecanico_ID ) \r\n" +
            "AND		( @Familia_ID IS NULL OR CM.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @Nombre IS NULL OR CM.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@CategoriaMecanico_ID", categoriamecanico_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Nombre", nombre);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_CategoriasMecanicos

    public class SelectCategoriasMecanicos
    {

        public SelectCategoriasMecanicos()
        {
        }

        public SelectCategoriasMecanicos(System.Int32? categoriamecanico_id, System.String nombre)
        {
            this.CategoriaMecanico_ID = categoriamecanico_id;
            this.Nombre = nombre;
        }

        private System.Int32? _CategoriaMecanico_ID;
        public System.Int32? CategoriaMecanico_ID
        {
            get { return _CategoriaMecanico_ID; }
            set { _CategoriaMecanico_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectCategoriasMecanicos> Get()
        {
            string sqlstr = "SELECT	NULL CategoriaMecanico_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	CategoriaMecanico_ID, Nombre \r\n" +
            "FROM	CategoriasMecanicos \r\n" +
            "ORDER BY	Nombre";

            List<SelectCategoriasMecanicos> list = new List<SelectCategoriasMecanicos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectCategoriasMecanicos(DB.GetNullableInt32(dr["CategoriaMecanico_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL CategoriaMecanico_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	CategoriaMecanico_ID, Nombre \r\n" +
            "FROM	CategoriasMecanicos \r\n" +
            "ORDER BY	Nombre";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectCategoriasMecanicos

    public class Vista_Mecanicos
    {

        public Vista_Mecanicos()
        {
        }

        public Vista_Mecanicos(System.Int32 mecanico_id, System.String categoria, System.String nombres, System.String apellidos, System.String rfc, System.String curp, System.String nss, System.String domicilio, System.String ciudad, System.String entidad, System.String codigopostal, System.String telefono, System.String correoelectronico, System.Decimal salariodiario, System.String horarioentrada, System.String horariosalida, System.String estatus, System.String usuario_id, System.DateTime fecha, System.String codigobarras)
        {
            this.Mecanico_ID = mecanico_id;
            this.Categoria = categoria;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Rfc = rfc;
            this.Curp = curp;
            this.NSS = nss;
            this.Domicilio = domicilio;
            this.Ciudad = ciudad;
            this.Entidad = entidad;
            this.CodigoPostal = codigopostal;
            this.Telefono = telefono;
            this.CorreoElectronico = correoelectronico;
            this.SalarioDiario = salariodiario;
            this.HorarioEntrada = horarioentrada;
            this.HorarioSalida = horariosalida;
            this.Estatus = estatus;
            this.Usuario_ID = usuario_id;
            this.Fecha = fecha;
            this.CodigoBarras = codigobarras;
        }

        private System.Int32 _Mecanico_ID;
        public System.Int32 Mecanico_ID
        {
            get { return _Mecanico_ID; }
            set { _Mecanico_ID = value; }
        }

        private System.String _Categoria;
        public System.String Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        private System.String _Nombres;
        public System.String Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        private System.String _Apellidos;
        public System.String Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        private System.String _Rfc;
        public System.String Rfc
        {
            get { return _Rfc; }
            set { _Rfc = value; }
        }

        private System.String _Curp;
        public System.String Curp
        {
            get { return _Curp; }
            set { _Curp = value; }
        }

        private System.String _NSS;
        public System.String NSS
        {
            get { return _NSS; }
            set { _NSS = value; }
        }

        private System.String _Domicilio;
        public System.String Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private System.String _Ciudad;
        public System.String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        private System.String _Entidad;
        public System.String Entidad
        {
            get { return _Entidad; }
            set { _Entidad = value; }
        }

        private System.String _CodigoPostal;
        public System.String CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }

        private System.String _Telefono;
        public System.String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private System.String _CorreoElectronico;
        public System.String CorreoElectronico
        {
            get { return _CorreoElectronico; }
            set { _CorreoElectronico = value; }
        }

        private System.Decimal _SalarioDiario;
        public System.Decimal SalarioDiario
        {
            get { return _SalarioDiario; }
            set { _SalarioDiario = value; }
        }

        private System.String _HorarioEntrada;
        public System.String HorarioEntrada
        {
            get { return _HorarioEntrada; }
            set { _HorarioEntrada = value; }
        }

        private System.String _HorarioSalida;
        public System.String HorarioSalida
        {
            get { return _HorarioSalida; }
            set { _HorarioSalida = value; }
        }

        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.String _Usuario_ID;
        public System.String Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _CodigoBarras;
        public System.String CodigoBarras
        {
            get { return _CodigoBarras; }
            set { _CodigoBarras = value; }
        }


        public static List<Vista_Mecanicos> Get(
            System.Int32? mecanico_id,
            System.Int32? categoriamecanico_id,
            System.String nombres,
            System.String apellidos,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = "SELECT	M.Mecanico_ID, CM.Nombre Categoria,  \r\n" +
            "		M.Nombres, M.Apellidos, \r\n" +
            "		M.Rfc, M.Curp, M.NSS, M.Domicilio, M.Ciudad, M.Entidad, M.CodigoPostal, \r\n" +
            "		M.Telefono, M.CorreoElectronico, M.SalarioDiario, M.HorarioEntrada, M.HorarioSalida, \r\n" +
            "		EM.Nombre Estatus, M.Usuario_ID, M.Fecha, M.CodigoBarras \r\n" +
            "FROM	Mecanicos M \r\n" +
            "INNER JOIN	CategoriasMecanicos CM \r\n" +
            "ON		CM.CategoriaMecanico_ID = M.CategoriaMecanico_ID \r\n" +
            "INNER JOIN	EstatusMecanicos EM \r\n" +
            "ON		M.EstatusMecanico_ID = EM.EstatusMecanico_ID \r\n" +
            "WHERE	( @Mecanico_ID IS NULL OR M.Mecanico_ID = @Mecanico_ID ) \r\n" +
            "AND		( @CategoriaMecanico_ID IS NULL OR M.CategoriaMecanico_ID = @CategoriaMecanico_ID ) \r\n" +
            "AND		( @Nombres IS NULL OR M.Nombres LIKE @Nombres + '%' ) \r\n" +
            "AND		( @Apellidos IS NULL OR M.Apellidos LIKE @Apellidos + '%' ) \r\n" +
            "AND M.Empresa_ID = @Empresa_ID AND M.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Mecanico_ID", mecanico_id);
            m_params.Add("@CategoriaMecanico_ID", categoriamecanico_id);
            m_params.Add("@Nombres", nombres);
            m_params.Add("@Apellidos", apellidos);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_Mecanicos> list = new List<Vista_Mecanicos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_Mecanicos(Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToString(dr["Categoria"]), Convert.ToString(dr["Nombres"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Rfc"]), Convert.ToString(dr["Curp"]), Convert.ToString(dr["NSS"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Entidad"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["CorreoElectronico"]), Convert.ToDecimal(dr["SalarioDiario"]), Convert.ToString(dr["HorarioEntrada"]), Convert.ToString(dr["HorarioSalida"]), Convert.ToString(dr["Estatus"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["CodigoBarras"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? mecanico_id,
            System.Int32? categoriamecanico_id,
            System.String nombres,
            System.String apellidos,
            System.Int32 empresa_id,
            System.Int32 estacion_id)
        {
            string sqlstr = "SELECT	M.Mecanico_ID, CM.Nombre Categoria,  \r\n" +
            "		M.Nombres, M.Apellidos, \r\n" +
            "		M.Rfc, M.Curp, M.NSS, M.Domicilio, M.Ciudad, M.Entidad, M.CodigoPostal, \r\n" +
            "		M.Telefono, M.CorreoElectronico, M.SalarioDiario, M.HorarioEntrada, M.HorarioSalida, \r\n" +
            "		EM.Nombre Estatus, M.Usuario_ID, M.Fecha, M.CodigoBarras \r\n" +
            "FROM	Mecanicos M \r\n" +
            "INNER JOIN	CategoriasMecanicos CM \r\n" +
            "ON		CM.CategoriaMecanico_ID = M.CategoriaMecanico_ID \r\n" +
            "INNER JOIN	EstatusMecanicos EM \r\n" +
            "ON		M.EstatusMecanico_ID = EM.EstatusMecanico_ID \r\n" +
            "WHERE	( @Mecanico_ID IS NULL OR M.Mecanico_ID = @Mecanico_ID ) \r\n" +
            "AND		( @CategoriaMecanico_ID IS NULL OR M.CategoriaMecanico_ID = @CategoriaMecanico_ID ) \r\n" +
            "AND		( @Nombres IS NULL OR M.Nombres LIKE @Nombres + '%' ) \r\n" +
            "AND		( @Apellidos IS NULL OR M.Apellidos LIKE @Apellidos + '%' ) \r\n" +
            "AND M.Empresa_ID = @Empresa_ID AND M.Estacion_ID = @Estacion_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Mecanico_ID", mecanico_id);
            m_params.Add("@CategoriaMecanico_ID", categoriamecanico_id);
            m_params.Add("@Nombres", nombres);
            m_params.Add("@Apellidos", apellidos);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class Vista_Mecanicos

    public class SelectModelosUnidades
    {

        public SelectModelosUnidades()
        {
        }

        public SelectModelosUnidades(System.Int32? modelounidad_id, System.String nombre)
        {
            this.ModeloUnidad_ID = modelounidad_id;
            this.Nombre = nombre;
        }

        private System.Int32? _ModeloUnidad_ID;
        public System.Int32? ModeloUnidad_ID
        {
            get { return _ModeloUnidad_ID; }
            set { _ModeloUnidad_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectModelosUnidades> Get()
        {
            string sqlstr = "SELECT	NULL ModeloUnidad_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	ModeloUnidad_ID, Descripcion + ' - ' + CONVERT(varchar,Anio) Nombre \r\n" +
            "FROM	ModelosUnidades \r\n" +
            "WHERE	Activo = 1 \r\n" +
            "ORDER BY	Nombre";

            List<SelectModelosUnidades> list = new List<SelectModelosUnidades>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectModelosUnidades(DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL ModeloUnidad_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	ModeloUnidad_ID, Descripcion + ' - ' + CONVERT(varchar,Anio) Nombre \r\n" +
            "FROM	ModelosUnidades \r\n" +
            "WHERE	Activo = 1 \r\n" +
            "ORDER BY	Nombre";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectModelosUnidades

    public class SelectFamilias
    {

        public SelectFamilias()
        {
        }

        public SelectFamilias(System.Int32? familia_id, System.String nombre)
        {
            this.Familia_ID = familia_id;
            this.Nombre = nombre;
        }

        private System.Int32? _Familia_ID;
        public System.Int32? Familia_ID
        {
            get { return _Familia_ID; }
            set { _Familia_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectFamilias> Get()
        {
            string sqlstr = "SELECT	NULL Familia_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Familia_ID, Nombre \r\n" +
            "FROM	Familias \r\n" +
            "ORDER BY	Nombre";

            List<SelectFamilias> list = new List<SelectFamilias>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectFamilias(DB.GetNullableInt32((dr["Familia_ID"])), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Familia_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	Familia_ID, Nombre \r\n" +
            "FROM	Familias \r\n" +
            "ORDER BY	Nombre";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class SelectFamilias

    public class SelectTiposServiciosMantenimientos
    {

        public SelectTiposServiciosMantenimientos()
        {
        }

        public SelectTiposServiciosMantenimientos(System.Int32? tiposerviciomantenimiento_id, System.String nombre)
        {
            this.TipoServicioMantenimiento_ID = tiposerviciomantenimiento_id;
            this.Nombre = nombre;
        }

        private System.Int32? _TipoServicioMantenimiento_ID;
        public System.Int32? TipoServicioMantenimiento_ID
        {
            get { return _TipoServicioMantenimiento_ID; }
            set { _TipoServicioMantenimiento_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<SelectTiposServiciosMantenimientos> Get()
        {
            string sqlstr = "SELECT	NULL TipoServicioMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoServicioMantenimiento_ID, Nombre \r\n" +
            "FROM	TiposServiciosMantenimientos";

            List<SelectTiposServiciosMantenimientos> list = new List<SelectTiposServiciosMantenimientos>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectTiposServiciosMantenimientos(DB.GetNullableInt32((dr["TipoServicioMantenimiento_ID"])), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL TipoServicioMantenimiento_ID, '- TODOS -' Nombre \r\n" +
            "UNION ALL \r\n" +
            "SELECT	TipoServicioMantenimiento_ID, Nombre \r\n" +
            "FROM	TiposServiciosMantenimientos";

            return DB.Query(sqlstr);
        } // End GetDataTable

    } // End Class Select_TiposServiciosMantenimientos

    public class Vista_ServiciosMantenimientos
    {

        public Vista_ServiciosMantenimientos()
        {
        }

        public Vista_ServiciosMantenimientos(System.Int32 serviciomantenimiento_id, System.String tipo, System.String familia, System.String modelo, System.String nombre, System.Int32 tiempoaplicado, System.Decimal costomanoobraareaminuto, System.Decimal preciominuto, System.Decimal costo, System.Decimal precio, System.Decimal porcentajeutilidad, System.Decimal cuotamanoobra)
        {
            this.ServicioMantenimiento_ID = serviciomantenimiento_id;
            this.Tipo = tipo;
            this.Familia = familia;
            this.Modelo = modelo;
            this.Nombre = nombre;
            this.TiempoAplicado = tiempoaplicado;
            this.CostoManoObraAreaMinuto = costomanoobraareaminuto;
            this.PrecioMinuto = preciominuto;
            this.Costo = costo;
            this.Precio = precio;
            this.PorcentajeUtilidad = porcentajeutilidad;
            this.CuotaManoObra = cuotamanoobra;
        }

        private System.Int32 _ServicioMantenimiento_ID;
        public System.Int32 ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        private System.String _Tipo;
        public System.String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private System.String _Familia;
        public System.String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        private System.String _Modelo;
        public System.String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Int32 _TiempoAplicado;
        public System.Int32 TiempoAplicado
        {
            get { return _TiempoAplicado; }
            set { _TiempoAplicado = value; }
        }

        private System.Decimal _CostoManoObraAreaMinuto;
        public System.Decimal CostoManoObraAreaMinuto
        {
            get { return _CostoManoObraAreaMinuto; }
            set { _CostoManoObraAreaMinuto = value; }
        }

        private System.Decimal _PrecioMinuto;
        public System.Decimal PrecioMinuto
        {
            get { return _PrecioMinuto; }
            set { _PrecioMinuto = value; }
        }

        private System.Decimal _Costo;
        public System.Decimal Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal _PorcentajeUtilidad;
        public System.Decimal PorcentajeUtilidad
        {
            get { return _PorcentajeUtilidad; }
            set { _PorcentajeUtilidad = value; }
        }

        private System.Decimal _CuotaManoObra;
        public System.Decimal CuotaManoObra
        {
            get { return _CuotaManoObra; }
            set { _CuotaManoObra = value; }
        }

        public static List<Vista_ServiciosMantenimientos> Get(
            System.String nombre,
            System.Int32? serviciomantenimiento_id,
            System.Int32? tiposerviciomantenimiento_id,
            System.Int32? familia_id,
            System.Int32? modelo_id)
        {
            string sqlstr = "SELECT	SM.ServicioMantenimiento_ID,  \r\n" +
            "		TSM.Nombre Tipo, \r\n" +
            "		F.Nombre Familia, \r\n" +
            "		MU.Nombre Modelo, \r\n" +
            "		SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, \r\n" +
            "		SM.PrecioMinuto, SM.Costo, SM.Precio, \r\n" +
            "		SM.PorcentajeUtilidad, SM.CuotaManoObra \r\n" +
            "FROM	ServiciosMantenimientos SM \r\n" +
            "INNER JOIN	TiposServiciosMantenimientos TSM \r\n" +
            "ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		SM.Familia_ID = F.Familia_ID \r\n" +
            "INNER JOIN	Modelos MU \r\n" +
            "ON		SM.Modelo_ID = MU.Modelo_ID \r\n" +
            "WHERE	( @ServicioMantenimiento_ID IS NULL OR SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID ) \r\n" +
            "AND		( @TipoServicioMantenimiento_ID IS NULL OR SM.TipoServicioMantenimiento_ID = @TipoServicioMantenimiento_ID ) \r\n" +
            "AND		( @Familia_ID IS NULL OR SM.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @Modelo_ID IS NULL OR SM.Modelo_ID = @Modelo_ID ) \r\n" +
            "AND        ( @Nombre IS NULL OR SM.Nombre LIKE @Nombre + '%' )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);
            m_params.Add("@TipoServicioMantenimiento_ID", tiposerviciomantenimiento_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@Nombre", nombre);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Familia"]), Convert.ToString(dr["Modelo"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
            }
            return list;
        } // End GetData


        public static List<Vista_ServiciosMantenimientos> Get(
            System.Int32? serviciomantenimiento_id,
            System.Int32? tiposerviciomantenimiento_id,
            System.Int32? familia_id,
            System.Int32? modelo_id)
        {
            string sqlstr = "SELECT	SM.ServicioMantenimiento_ID,  \r\n" +
            "		TSM.Nombre Tipo, \r\n" +
            "		F.Nombre Familia, \r\n" +
            "		MU.Nombre Modelo, \r\n" +
            "		SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, \r\n" +
            "		SM.PrecioMinuto, SM.Costo, SM.Precio, \r\n" +
            "		SM.PorcentajeUtilidad, SM.CuotaManoObra \r\n" +
            "FROM	ServiciosMantenimientos SM \r\n" +
            "INNER JOIN	TiposServiciosMantenimientos TSM \r\n" +
            "ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		SM.Familia_ID = F.Familia_ID \r\n" +
            "INNER JOIN	Modelos MU \r\n" +
            "ON		SM.Modelo_ID = MU.Modelo_ID \r\n" +
            "WHERE	( @ServicioMantenimiento_ID IS NULL OR SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID ) \r\n" +
            "AND		( @TipoServicioMantenimiento_ID IS NULL OR SM.TipoServicioMantenimiento_ID = @TipoServicioMantenimiento_ID ) \r\n" +
            "AND		( @Familia_ID IS NULL OR SM.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @Modelo_ID IS NULL OR SM.Modelo_ID = @Modelo_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);
            m_params.Add("@TipoServicioMantenimiento_ID", tiposerviciomantenimiento_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Familia"]), Convert.ToString(dr["Modelo"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
            }
            return list;
        } // End GetData

        public static List<Vista_ServiciosMantenimientos> GetServicios(
            string nombre,
            int modelo_id,
            int tipoclientetaller_id,
            int empresa_id,
            int estacion_id)
        {
            string sqlstr = @"SELECT	DISTINCT SM.ServicioMantenimiento_ID,  
        TSM.Nombre Tipo, 
        F.Nombre Familia, 
        MU.Nombre Modelo, 
        SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, 
        SM.PrecioMinuto, SM.Costo, SMP.Precio, 
        SM.PorcentajeUtilidad, SM.CuotaManoObra 
FROM	ServiciosMantenimientos SM 
INNER JOIN	TiposServiciosMantenimientos TSM 
ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
INNER JOIN	Familias F 
ON		SM.Familia_ID = F.Familia_ID 
INNER JOIN	ServiciosMantenimientosPrecios SMP
ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
    AND SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID )
INNER JOIN	Modelos MU
ON		MU.Modelo_ID = @Modelo_ID
WHERE	SM.Nombre LIKE @Nombre + '%'";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosMantenimientos(
                       Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToInt32(dr["TiempoAplicado"]),
                       Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]),
                       Convert.ToDecimal(dr["PrecioMinuto"]),
                       Convert.ToDecimal(dr["Costo"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDecimal(dr["PorcentajeUtilidad"]),
                       Convert.ToDecimal(dr["CuotaManoObra"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static List<Vista_ServiciosMantenimientos> Get(
            string nombre,
            int modelo_id,
            int tipoclientetaller_id,
            int empresa_id,
            int estacion_id)
        {
            string sqlstr = @"SELECT	DISTINCT SM.ServicioMantenimiento_ID,  
        TSM.Nombre Tipo, 
        F.Nombre Familia, 
        MU.Nombre Modelo, 
        SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, 
        SM.PrecioMinuto, SM.Costo, SMP.Precio, 
        SM.PorcentajeUtilidad, SM.CuotaManoObra 
FROM	ServiciosMantenimientos SM 
INNER JOIN	TiposServiciosMantenimientos TSM 
ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
INNER JOIN	Familias F 
ON		SM.Familia_ID = F.Familia_ID 
INNER JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
INNER JOIN	TiposRefacciones TR
ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
INNER JOIN	Refacciones R
ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
INNER JOIN	Inventario I
ON		( R.Refaccion_ID = I.Refaccion_ID
			AND	I.Empresa_ID = @Empresa_ID
			AND	I.Estacion_ID = @Estacion_ID )
INNER JOIN	ServiciosMantenimientosPrecios SMP
ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
    AND SMP.TipoClienteTaller_ID = @TipoClienteTaller_ID )
INNER JOIN	Modelos MU 
ON		( R.Modelo_ID = MU.Modelo_ID )
WHERE	I.CantidadInventario > 0
AND		SM.Nombre LIKE @Nombre + '%'
AND		R.Modelo_ID IN (@Modelo_ID, 9)
--AND		SMP.Precio > 0";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Modelo_ID", modelo_id);
            m_params.Add("@TipoClienteTaller_ID", tipoclientetaller_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosMantenimientos(
                       Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                       Convert.ToString(dr["Tipo"]),
                       Convert.ToString(dr["Familia"]),
                       Convert.ToString(dr["Modelo"]),
                       Convert.ToString(dr["Nombre"]),
                       Convert.ToInt32(dr["TiempoAplicado"]),
                       Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]),
                       Convert.ToDecimal(dr["PrecioMinuto"]),
                       Convert.ToDecimal(dr["Costo"]),
                       Convert.ToDecimal(dr["Precio"]),
                       Convert.ToDecimal(dr["PorcentajeUtilidad"]),
                       Convert.ToDecimal(dr["CuotaManoObra"])
                       )
                    );
            }
            return list;
        } // End GetData

        /*
        public static List<Vista_ServiciosMantenimientos> Get(string nombre, int modelo_id)
        {
            string sqlstr = @"SELECT	DISTINCT SM.ServicioMantenimiento_ID,  
                            TSM.Nombre Tipo, 
                            F.Nombre Familia, 
                            MU.Nombre Modelo, 
                            SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, 
                            SM.PrecioMinuto, SM.Costo, SMP.Precio, 
                            SM.PorcentajeUtilidad, SM.CuotaManoObra 
                     FROM	ServiciosMantenimientos SM 
                     INNER JOIN	TiposServiciosMantenimientos TSM 
                     ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
                     INNER JOIN	Familias F 
                     ON		SM.Familia_ID = F.Familia_ID 
                     INNER JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
                     ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
                     INNER JOIN	TiposRefacciones TR
                     ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
                     INNER JOIN	Refacciones R
                     ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
                     INNER JOIN	ServiciosMantenimientosPrecios SMP
                     ON		( SM.ServicioMantenimiento_ID = SMP.ServicioMantenimiento_ID
                         AND SMP.TipoEmpresa_ID = @TipoEmpresa_ID )
                     INNER JOIN	Modelos MU 
                     ON		R.Modelo_ID = MU.Modelo_ID
                     WHERE	R.CantidadInventario > 0
                     AND		SM.Nombre LIKE @Nombre + '%'
                     AND		R.Modelo_ID = @Modelo_ID
                     AND		SMP.Precio > 0";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Modelo_ID", modelo_id);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
               list.Add(
                  new Vista_ServiciosMantenimientos(
                     Convert.ToInt32(dr["ServicioMantenimiento_ID"]), 
                     Convert.ToString(dr["Tipo"]),
                     Convert.ToString(dr["Familia"]), 
                     Convert.ToString(dr["Modelo"]), 
                     Convert.ToString(dr["Nombre"]), 
                     Convert.ToInt32(dr["TiempoAplicado"]), 
                     Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), 
                     Convert.ToDecimal(dr["PrecioMinuto"]), 
                     Convert.ToDecimal(dr["Costo"]), 
                     Convert.ToDecimal(dr["Precio"]), 
                     Convert.ToDecimal(dr["PorcentajeUtilidad"]), 
                     Convert.ToDecimal(dr["CuotaManoObra"])
                     )
                  );
            }
            return list;
        } // End GetData
        */

        public static List<Vista_ServiciosMantenimientos> Get(string nombre,
            int empresa_id,
            int estacion_id)
        {
            string sqlstr = @"SELECT	DISTINCT SM.ServicioMantenimiento_ID,  
		            TSM.Nombre Tipo, 
		            F.Nombre Familia, 
		            MU.Nombre Modelo, 
		            SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, 
		            SM.PrecioMinuto, SM.Costo, SM.Precio, 
		            SM.PorcentajeUtilidad, SM.CuotaManoObra 
            FROM	ServiciosMantenimientos SM 
            INNER JOIN	TiposServiciosMantenimientos TSM 
            ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID 
            INNER JOIN	Familias F 
            ON		SM.Familia_ID = F.Familia_ID 
            INNER JOIN	Modelos MU 
            ON		SM.Modelo_ID = MU.Modelo_ID
            LEFT JOIN	ServiciosMantenimientos_TiposRefacciones SMTR
            ON		SM.ServicioMantenimiento_ID = SMTR.ServicioMantenimiento_ID
            LEFT JOIN	TiposRefacciones TR
            ON		SMTR.TipoRefaccion_ID = TR.TipoRefaccion_ID
            LEFT JOIN	Refacciones R
            ON		TR.TipoRefaccion_ID = R.TipoRefaccion_ID
            LEFT JOIN	Inventario I
            ON		( R.Refaccion_ID = I.Refaccion_ID
			        AND	I.Empresa_ID = @Empresa_ID
			        AND	I.Estacion_ID = @Estacion_ID )
            WHERE	SM.Nombre = @Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_ServiciosMantenimientos> list = new List<Vista_ServiciosMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToString(dr["Tipo"]), Convert.ToString(dr["Familia"]), Convert.ToString(dr["Modelo"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
            }
            return list;
        } // End GetData
        /*
        public static DataTable GetDataTable(System.Int32 serviciomantenimiento_id, System.Object tiposerviciomantenimiento_id, System.Object familia_id, System.Object modelo_id)
        {
            string sqlstr = "SELECT	SM.ServicioMantenimiento_ID,  \r\n" +
            "		TSM.Nombre Tipo, \r\n" +
            "		F.Nombre Familia, \r\n" +
            "		MU.Nombre Modelo, \r\n" +
            "		SM.Nombre, SM.TiempoAplicado, SM.CostoManoObraAreaMinuto, \r\n" +
            "		SM.PrecioMinuto, SM.Costo, SM.Precio, \r\n" +
            "		SM.PorcentajeUtilidad, SM.CuotaManoObra \r\n" +
            "FROM	ServiciosMantenimientos SM \r\n" +
            "INNER JOIN	TiposServiciosMantenimientos TSM \r\n" +
            "ON		SM.TipoServicioMantenimiento_ID = TSM.TipoServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		SM.Familia_ID = F.Familia_ID \r\n" +
            "INNER JOIN	Modelos MU \r\n" +
            "ON		SM.Modelo_ID = MU.Modelo_ID \r\n" +
            "WHERE	( @ServicioMantenimiento_ID IS NULL OR SM.ServicioMantenimiento_ID = @ServicioMantenimiento_ID ) \r\n" +
            "AND		( @TipoServicioMantenimiento_ID IS NULL OR SM.TipoServicioMantenimiento_ID = @TipoServicioMantenimiento_ID ) \r\n" +
            "AND		( @Familia_ID IS NULL OR SM.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @Modelo_ID IS NULL OR SM.Modelo_ID = @Modelo_ID )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ServicioMantenimiento_ID", serviciomantenimiento_id);
            m_params.Add("@TipoServicioMantenimiento_ID", tiposerviciomantenimiento_id);
            m_params.Add("@Familia_ID", familia_id);
            m_params.Add("@Modelo_ID", modelo_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable
        */
    } // End Class Vista_ServiciosMantenimientos

    public class SelectCajasActivas
    {

        public SelectCajasActivas()
        {
        }

        public SelectCajasActivas(System.Int32? caja_id, System.String descripcion)
        {
            this.Caja_ID = caja_id;
            this.Descripcion = descripcion;
        }

        private System.Int32? _Caja_ID;
        public System.Int32? Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private System.String _Descripcion;
        public System.String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


        public static List<SelectCajasActivas> Get()
        {
            string sqlstr = "SELECT	NULL Caja_ID, \r\n" +
            "		'- TODAS -' Descripcion \r\n" +
            "UNION ALL \r\n" +
            "SELECT	C.Caja_ID, \r\n" +
            "		E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion \r\n" +
            "FROM	Cajas C \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		C.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		C.Estacion_ID = EST.Estacion_ID \r\n" +
            "WHERE	C.Activa = 1 \r\n" +
            "ORDER BY	Descripcion";

            List<SelectCajasActivas> list = new List<SelectCajasActivas>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectCajasActivas(DB.GetNullableInt32((dr["Caja_ID"])), Convert.ToString(dr["Descripcion"])));
            }
            return list;
        } // End GetData

        public static List<SelectCajasActivas> Get(string usuario_id)
        {
            string sqlstr = @"SELECT	Caja_ID, Nombre Descripcion
FROM	Cajas
WHERE	Estacion_ID IN
(
	SELECT	Estacion_ID
	FROM	Usuarios_Estaciones
	WHERE	Usuario_ID = @Usuario_ID
)
AND		Activa = 1";

            sqlstr = @"DECLARE	@Empresa_ID int, @Estacion_ID int

SELECT	@Empresa_ID = Empresa_ID,
		@Estacion_ID = Estacion_ID
FROM	Usuarios
WHERE	Usuario_ID = @Usuario_ID

IF ( @Estacion_ID IS NULL )
BEGIN
	IF ( @Empresa_ID IS NULL )
	BEGIN
		SELECT	NULL Caja_ID, 
				'- TODAS -' Descripcion 
		UNION ALL 
		SELECT	C.Caja_ID, 
				E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion 
		FROM	Cajas C 
		INNER JOIN	Empresas E 
		ON		C.Empresa_ID = E.Empresa_ID 
		INNER JOIN	Estaciones EST 
		ON		C.Estacion_ID = EST.Estacion_ID 
		WHERE	C.Activa = 1 
		ORDER BY	Descripcion
	END
	ELSE
	BEGIN		
		SELECT	C.Caja_ID, 
				E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion 
		FROM	Cajas C 
		INNER JOIN	Empresas E 
		ON		C.Empresa_ID = E.Empresa_ID 
		INNER JOIN	Estaciones EST 
		ON		C.Estacion_ID = EST.Estacion_ID 
		WHERE	C.Activa = 1 
		AND		C.Empresa_ID = @Empresa_ID
		ORDER BY	Descripcion
	END	
END
ELSE
BEGIN
	SELECT	C.Caja_ID, 
			E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion 
	FROM	Cajas C 
	INNER JOIN	Empresas E 
	ON		C.Empresa_ID = E.Empresa_ID 
	INNER JOIN	Estaciones EST 
	ON		C.Estacion_ID = EST.Estacion_ID 
	WHERE	C.Activa = 1 
	AND		C.Estacion_ID = @Estacion_ID
	ORDER BY	Descripcion
END";

            List<SelectCajasActivas> list = new List<SelectCajasActivas>();
            DataTable dt = DB.QueryCommand(sqlstr, DB.GetParams(DB.Param("@Usuario_ID", usuario_id)));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SelectCajasActivas(DB.GetNullableInt32((dr["Caja_ID"])), Convert.ToString(dr["Descripcion"])));
            }
            return list;
        } // End GetData

        public static List<SelectCajasActivas> GetActivasPorUsuario(string usuario_id)
        {
            string sqlstr = @"dbo.usp_SelectCajasActivas";
            List<SelectCajasActivas> list = new List<SelectCajasActivas>();
            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectCajasActivas(DB.GetNullableInt32((dr["Caja_ID"])), Convert.ToString(dr["Descripcion"])));
            }
            return list;
        } // End GetActivasPorUsuario

        public static DataTable GetDataTable()
        {
            string sqlstr = "SELECT	NULL Caja_ID, \r\n" +
            "		'- TODAS -' Descripcion \r\n" +
            "UNION ALL \r\n" +
            "SELECT	C.Caja_ID, \r\n" +
            "		E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion \r\n" +
            "FROM	Cajas C \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		C.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		C.Estacion_ID = EST.Estacion_ID \r\n" +
            "WHERE	C.Activa = 1 \r\n" +
            "ORDER BY	Descripcion";

            return DB.Query(sqlstr);
        } // End GetDataTable

        public static DataTable GetDataTable(int estacion_id)
        {
            string sqlstr = "SELECT	C.Caja_ID, \r\n" +
            "		E.Nombre + ' -> ' + EST.Nombre + ' -> ' + C.Nombre Descripcion \r\n" +
            "FROM	Cajas C \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		C.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		C.Estacion_ID = EST.Estacion_ID \r\n" +
            "WHERE	C.Activa = 1 \r\n" +
            "AND C.Estacion_ID = @Estacion_ID \r\n" +
            "ORDER BY	Descripcion";

            return DB.QueryCommand(sqlstr, DB.GetParams(DB.Param("@Estacion_ID", estacion_id)));
        } // End GetDataTable

    } // End Class SelectCajasActivas

    public static class RegistraAsignacionDeServicio
    {
        public static void InsertaAsigancionDeServicioPorusuario(string user_id, string servicio, DateTime? FechaServicio, int? unidad_id, int? conductor_id)
        {
            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", user_id);
            m_params.Add("@Servicio_ID", servicio);
            m_params.Add("@FechaServicio", FechaServicio);
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Conductor_ID", conductor_id);
            DB.ExecuteCommandSP("usp_Usuario_AsignaServicio", m_params);
        }
    }

    public class SaldosCuentaCajasPorFechas
    {

        public SaldosCuentaCajasPorFechas()
        {
        }

        public SaldosCuentaCajasPorFechas(System.DateTime fecha, System.String empresa, System.String cuenta, System.Decimal saldo)
        {
            this.Fecha = fecha;
            this.Empresa = empresa;
            this.Cuenta = cuenta;
            this.Saldo = saldo;
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal _Saldo;
        public System.Decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        public static List<SaldosCuentaCajasPorFechas> Get(System.Int32? caja_id, System.DateTime fechainicial, System.DateTime fechafinal)
        {
            string sqlstr = "SELECT	convert(date,CC.Fecha) Fecha, E.Nombre Empresa, CU.Nombre Cuenta,  \r\n" +
            "		SUM(Abono - Cargo) Saldo \r\n" +
            "FROM	CuentaCajas CC \r\n" +
            "INNER JOIN	Cajas C \r\n" +
            "ON		CC.Caja_ID = C.Caja_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		CC.Estacion_ID = EST.Estacion_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		CC.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Cuentas	CU \r\n" +
            "ON		CC.Cuenta_ID = CU.Cuenta_ID \r\n" +
            "WHERE	( @Caja_ID IS NULL OR CC.Caja_ID = @Caja_ID ) \r\n" +
            "AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal \r\n" +
            "AND	(   CC.Comentarios NOT LIKE '%RETIRO%' OR CC.Comentarios IS NULL ) \r\n" +
            "GROUP BY	convert(date,CC.Fecha), E.Nombre, CU.Nombre \r\n" +
            "ORDER BY	convert(date,CC.Fecha), E.Nombre, CU.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<SaldosCuentaCajasPorFechas> list = new List<SaldosCuentaCajasPorFechas>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SaldosCuentaCajasPorFechas(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Empresa"]),
                             Convert.ToString(dr["Cuenta"]), Convert.ToDecimal(dr["Saldo"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? caja_id, System.DateTime fechainicial, System.DateTime fechafinal)
        {
            string sqlstr = "SELECT convert(date, CC.Fecha) Fecha, E.Nombre Empresa, CU.Nombre Cuenta,  \r\n" +
            "		SUM(Abono - Cargo) Saldo \r\n" +
            "FROM	CuentaCajas CC \r\n" +
            "INNER JOIN	Cajas C \r\n" +
            "ON		CC.Caja_ID = C.Caja_ID \r\n" +
            "INNER JOIN	Estaciones EST \r\n" +
            "ON		CC.Estacion_ID = EST.Estacion_ID \r\n" +
            "INNER JOIN	Empresas E \r\n" +
            "ON		CC.Empresa_ID = E.Empresa_ID \r\n" +
            "INNER JOIN	Cuentas	CU \r\n" +
            "ON		CC.Cuenta_ID = CU.Cuenta_ID \r\n" +
            "WHERE	( @Caja_ID IS NULL OR CC.Caja_ID = @Caja_ID ) \r\n" +
            "AND	(	CC.Fecha BETWEEN @FechaInicial AND @FechaFinal ) \r\n" +
            "AND	(   CC.Comentarios NOT LIKE '%RETIRO%' OR CC.Comentarios IS NULL ) \r\n" +
            "GROUP BY	convert(date, CC.Fecha), E.Nombre, CU.Nombre \r\n" +
            "ORDER BY	convert(date, CC.Fecha), E.Nombre, CU.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Caja_ID", caja_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

        public static DataTable GetDataTableByEstacion(System.Int32? estacion_id, System.DateTime fechainicial, System.DateTime fechafinal, string usuario_id)
        {
            string sqlstr = @"SELECT	convert(date,CC.Fecha) Fecha, E.Nombre Empresa, CU.Nombre Cuenta,  
            		SUM(Abono - Cargo) Saldo 
            FROM	CuentaCajas CC 
            INNER JOIN	Cajas C 
            ON		CC.Caja_ID = C.Caja_ID 
            INNER JOIN	Estaciones EST 
            ON		CC.Estacion_ID = EST.Estacion_ID 
            INNER JOIN	Empresas E 
            ON		CC.Empresa_ID = E.Empresa_ID 
            INNER JOIN	Cuentas	CU 
            ON		CC.Cuenta_ID = CU.Cuenta_ID 
            WHERE	( CC.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
            AND     ( CC.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
            AND     ( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID ) 
            AND		CC.Fecha BETWEEN @FechaInicial AND @FechaFinal 
            AND	(   CC.Comentarios NOT LIKE '%RETIRO%' OR CC.Comentarios IS NULL ) 
            GROUP BY	convert(date,CC.Fecha), E.Nombre, CU.Nombre 
            ORDER BY	convert(date,CC.Fecha), E.Nombre, CU.Nombre";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);
            m_params.Add("@Usuario_ID", usuario_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class SaldosCuentaCajasPorFechas

    public class Functions
    {
        public static DateTime? FechaUltimoPagoConductor(int conductor_id)
        {
            string strsql = "SELECT MAX(Fecha) FROM CuentaConductores WHERE Conductor_ID = @Conductor_ID AND Concepto_ID = 2";
            DateTime? result = DB.GetNullableDateTime(DB.QueryScalar(strsql, DB.Param("@Conductor_ID", conductor_id)));
            return result;
        }

        public static decimal SaldoRentasConductor(int conductor_id)
        {
            string strsql = "SELECT SUM(Abono - Cargo) FROM CuentaConductores WHERE Conductor_ID = @Conductor_ID " +
                "AND Cuenta_ID = 1";
            decimal? result = DB.GetNullableDecimal(DB.QueryScalar(strsql, DB.Param("@Conductor_ID", conductor_id)));
            return (result == null) ? 0 : result.Value;
        }

        public static void ActualizarLocacionUnidad(int unidad_id, int locacionunidad_id, DateTime fecha, string usuario, string comentarios)
        {
            //  Obtenemos el estatus
            Entities.LocacionesUnidades locacionunidad = Entities.LocacionesUnidades.Read(locacionunidad_id);

            //  Declaramos los parámetros
            Hashtable m_params, w_params;
            m_params = new Hashtable();
            w_params = new Hashtable();

            //  Configuramos los parámetros, estatus y locación
            m_params.Add("LocacionUnidad_ID", locacionunidad_id);
            m_params.Add("EstatusUnidad_ID", locacionunidad.EstatusUnidad_ID);
            w_params.Add("Unidad_ID", unidad_id);

            // Validamos que el cambio pueda proceder a menos que la unidad esté en contrato.
            if (locacionunidad_id == 5 || locacionunidad_id == 14 || locacionunidad_id == 22 || locacionunidad_id == 28 || locacionunidad_id == 29 || locacionunidad_id == 30 || locacionunidad_id == 31)
            {
                string filter = "Unidad_ID = " + unidad_id.ToString() + " AND EstatusContrato_ID = 1";
                if (DB.GetCount("Contratos", filter) > 0) throw new Exception("Esa unidad se encuentra en contrato y no puede ser movida a la locación especificada. Primero se debe liquidar el contrato");
            }

            //  Actualizamos la unidad
            DB.UpdateRow("Unidades", m_params, w_params);

            //  Obtenemos la unidad_locación y realizamos la inserción
            Unidades_Locaciones unidad_locacion =
                new Unidades_Locaciones(
                   0,
                   unidad_id,
                   locacionunidad_id,
                   fecha,
                   usuario,
                   comentarios
                );

            unidad_locacion.Create();
        }

        public static void ActualizarEstatusOperativoUnidad(int unidad_id, int estatusoperativounidad_id, string usuario_id)
        {
            Hashtable m_params;

            //  Inserción de registro
            string sql = "INSERT INTO Unidades_EstatusOperativos VALUES (@Unidad_ID, @EstatusOperativoUnidad_ID, GETDATE(), @Usuario_ID)";

            m_params = new Hashtable();
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@EstatusOperativoUnidad_ID", estatusoperativounidad_id);
            m_params.Add("@Usuario_ID", usuario_id);

            DB.ExecuteCommand(sql, m_params);

            //  Actualizacion de Unidad

            sql = @"UPDATE Unidades 
SET  EstatusOperativoUnidad_ID = @EstatusOperativoUnidad_ID, 
UltimaActualizacion = GETDATE()
WHERE   Unidad_ID = @Unidad_ID";

            m_params = new Hashtable();

            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@EstatusOperativoUnidad_ID", estatusoperativounidad_id);

            DB.ExecuteCommand(sql, m_params);
        }

        public static void AsignarServicio(string servicio_id, int conductor_id, int unidad_id, DateTime fechaservicio)
        {
            //  Actualizar servicio
            Hashtable m_params, w_params;
            m_params = new Hashtable();
            w_params = new Hashtable();

            m_params.Add("Conductor_ID", conductor_id);
            m_params.Add("Unidad_ID", unidad_id);
            m_params.Add("EstatusServicio_ID", 2);
            m_params.Add("FechaServicio", fechaservicio);

            w_params.Add("Servicio_ID", servicio_id);

            if (DB.UpdateRow("Servicios", m_params, w_params) == 0)
                AppHelper.ThrowException("No se ha actualizado ningun servicio");

            //GMD - 2016-05-20
            //Registra que usuario realiza la asiganación del servicio
            RegistraAsignacionDeServicio.InsertaAsigancionDeServicioPorusuario(Sesion.Usuario_ID, servicio_id, fechaservicio, unidad_id, conductor_id);
        }

        public static void Registrarkilometraje(
            int unidad_id,
            int conductor_id,
            int kilometraje,
            DateTime fecha)
        {
            //  Alta del registro
            Unidades_Kilometrajes uk =
                new Unidades_Kilometrajes(
                   0,
                   unidad_id,
                   conductor_id,
                   kilometraje,
                   fecha
                );

            uk.Create();

            //  Actualización de la unidad
            Hashtable m_params, w_params;
            m_params = new Hashtable();
            w_params = new Hashtable();

            m_params.Add("Kilometraje", kilometraje);
            w_params.Add("Unidad_ID", unidad_id);

            DB.UpdateRow("Unidades", m_params, w_params);
        }

        public static void CancelarTicket(int ticket_id, string motivo, string usuario_id, DateTime fecha)
        {
            Entities.Tickets ticket = Entities.Tickets.Read(ticket_id);
            ticket.EstatusTicket_ID = 2;
            ticket.Update();

            //Galdino Melchor Díaz 2016-10-10
            //Actualiza Estatus del Vale prepagado si es que en el ticket se uso un vale prepagado
            List<ValesPrepagados> lvp = new List<ValesPrepagados>();
            List<KeyValuePair<string, object>> lp = new List<KeyValuePair<string, object>>();
            KeyValuePair<string, object> param1 = new KeyValuePair<string, object>("Ticket_ID", ticket_id);
            lp.Add(param1);

            lvp = ValesPrepagados.ReadList(lp.ToArray());
            foreach (ValesPrepagados vp in lvp)
            {
                if (vp != null && vp.ValePrepagado_ID.Trim().Length > 0)
                {
                    vp.EstatusValePrepagado_ID = 1;
                    vp.Ticket_ID = null;
                    vp.FechaCanje = null;
                    vp.Update();
                }
            }

            //Actualiza Estatus del Vale Empresarial si es que en el ticket se uso un vale empresarial
            List<Entities.ValesEmpresariales> lve = new List<Entities.ValesEmpresariales>();
            lve = Entities.ValesEmpresariales.ReadList(lp.ToArray());
            foreach (Entities.ValesEmpresariales ve in lve)
            {
                if (ve != null && ve.ValeEmpresarial_ID > 0)
                {
                    ve.EstatusValeEmpresarial_ID = 1;
                    ve.Ticket_ID = null;
                    ve.FechaCanje = null;
                    ve.Update();
                }
            }
            ////

            TicketsCancelados ticketCancelado = new TicketsCancelados(ticket_id, motivo, usuario_id, fecha);
            ticketCancelado.Create();

            Hashtable m_params, w_params;
            m_params = new Hashtable();
            w_params = new Hashtable();

            m_params.Add("FechaPago", null);
            m_params.Add("EstatusServicio_ID", 2);
            w_params.Add("Ticket_ID", ticket_id);

            //Elimina el ticket de las tablas que afectan el corte de caja
            DB.UpdateRow("Servicios", m_params, w_params);
            DB.DeleteRow("CuentaConductores", w_params);
            DB.DeleteRow("CuentaCajas", w_params);
            DB.DeleteRow("CuentaFlujoCajas", w_params);
            DB.DeleteRow("CuentaUnidades", w_params);
        }

        public static DataTable GetAniosCuentaConductores()
        {
            string sql = @"
DECLARE	@MinDate datetime,
		@MaxDate datetime,
		@MinYear int,
		@MaxYear int

SELECT	@MinDate = MIN(Fecha), 
		@MaxDate = MAX(Fecha)
FROM	CuentaConductores

SELECT	@MinYear = YEAR(@MinDate),
		@MaxYear = YEAR(@MaxDate)

DECLARE	@Years TABLE
(
	Anio int,
	Nombre varchar(20)
)

INSERT	@Years
SELECT	NULL, '- TODOS -'

WHILE ( @MinYear <= @MaxYear )
BEGIN
	INSERT	@Years
	SELECT	@MinYear,  CONVERT(varchar(4),@MinYear)
	SET	@MinYear = @MinYear + 1
END

SELECT * FROM @Years";

            return DB.Query(sql);
        }

        public static DataTable GetMesesFromAnio(int anio)
        {
            string sql = @"DECLARE	@MinDate datetime,
		@MaxDate datetime,
		@MinMonth int,
		@MaxMonth int,
		@InitialDate datetime,
		@FinalDate datetime
	
SET	@InitialDate = CONVERT(varchar(4), @Anio) + '-01-01'
SET	@FinalDate = DATEADD(DAY, 364, @InitialDate)

SELECT	@MinDate = MIN(Fecha), 
		@MaxDate = MAX(Fecha)
FROM	CuentaConductores
WHERE	Fecha BETWEEN @InitialDate AND @FinalDate

SELECT	@MinMonth = DATEPART(MONTH,@MinDate),
		@MaxMonth= DATEPART(MONTH,@MaxDate)

DECLARE	@Meses TABLE
(
	Mes int,
	Nombre varchar(20)
)

INSERT	@Meses
SELECT	NULL, '- TODOS -'

WHILE ( @MinMonth <= @MaxMonth )
BEGIN	
	INSERT	@Meses
	SELECT	@MinMonth,  UPPER(DATENAME(MONTH,@InitialDate))
	SET	@MinMonth = @MinMonth + 1
	SET	@InitialDate = DATEADD(MONTH,1,@InitialDate)
END

SELECT * FROM @Meses";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Anio", anio);
            return DB.QueryCommand(sql, m_params);
        }

        public static int GetInventarioDiferido(int refaccion_id, int empresa_id, int estacion_id)
        {
            string sql = @"DECLARE @InventarioTotal int
		
SELECT	@InventarioTotal = CantidadInventario
FROM	Inventario
WHERE	Refaccion_ID = @Refaccion_ID
AND		Empresa_ID = @Empresa_ID
AND		Estacion_ID = @Estacion_ID

SET	@InventarioTotal = ISNULL(@InventarioTotal,0)

SELECT	@InventarioTotal = @InventarioTotal - ISNULL(SUM(OSR.Cantidad - OSR.RefSurtidas),0)
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
WHERE	OSR.Cantidad > OSR.RefSurtidas
AND	OT.EstatusOrdenTrabajo_ID NOT IN (3,4,5)
AND		OSR.Refaccion_ID = @Refaccion_ID
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID

SELECT	@InventarioTotal as InventarioTotal";

            return Convert.ToInt32(
                DB.QueryScalar(
                   sql,
                   DB.Param("@Refaccion_ID", refaccion_id),
                   DB.Param("@Empresa_ID", empresa_id),
                   DB.Param("@Estacion_ID", estacion_id)
                )
            );
        } // end int GetInventarioDiferido

        /// <summary>
        /// Devuelve Verdadero si la empresa es interna. Falso en caso contrario
        /// </summary>
        /// <param name="empresa_id">El número de identificación de la empresa a verificar</param>
        /// <returns></returns>
        public static bool EsEmpresaInterna(int empresa_id)
        {
            string sql = @"SELECT TipoEmpresa_ID
FROM    Empresas
WHERE   Empresa_ID = @Empresa_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Empresa_ID", empresa_id);

            int tipoEmpresa_ID =
                Convert.ToInt32(
                   DB.QueryScalar(sql, m_params)
                );

            return (tipoEmpresa_ID == 1 || tipoEmpresa_ID == 2);
        }

    } // end class Functions

    public class AdeudosDeConductor
    {

        public AdeudosDeConductor()
        {
        }

        public AdeudosDeConductor(System.Int32 empresa_id, System.String empresa, System.Int32 cuenta_id, System.Int32 concepto_id, System.String cuenta, System.Decimal saldo, System.Decimal pagar)
        {
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
            this.Cuenta_ID = cuenta_id;
            this.Concepto_ID = concepto_id;
            this.Cuenta = cuenta;
            this.Saldo = saldo;
            this.Pagar = pagar;
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.Int32 _Cuenta_ID;
        public System.Int32 Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.Int32 _Concepto_ID;
        public System.Int32 Concepto_ID
        {
            get { return _Concepto_ID; }
            set { _Concepto_ID = value; }
        }

        private System.String _Cuenta;
        public System.String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private System.Decimal _Saldo;
        public System.Decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        private System.Decimal _Pagar;
        public System.Decimal Pagar
        {
            get { return _Pagar; }
            set { _Pagar = value; }
        }


        public static BindingList<AdeudosDeConductor> Get(System.Object conductor_id, System.Object usuario_id)
        {
            //            string sqlstr = @"SELECT	CC.Empresa_ID, E.Nombre Empresa, CC.Cuenta_ID, CC.Concepto_ID, C.Nombre Cuenta, CC.Saldo, 0.00 Pagar     
            //FROM	(     
            //SELECT	Conductor_ID, Empresa_ID, Cuenta_ID,      
            //        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = CuentaConductores.Cuenta_ID)     
            //        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,     
            //        (SUM(Abono)-SUM(Cargo)) Saldo     
            //FROM	CuentaConductores
            //WHERE   Conductor_ID = @Conductor_ID
            //GROUP BY Conductor_ID, Empresa_ID, Cuenta_ID   
            //        ) CC     
            //INNER JOIN	Empresas E     
            //ON		E.Empresa_ID = CC.Empresa_ID     
            //INNER JOIN	Cuentas C     
            //ON		C.Cuenta_ID = CC.Cuenta_ID
            //WHERE   C.Cuenta_ID NOT IN (42, 9, 35, 17 )
            //		AND CC.Saldo <> 0
            //
            //UNION
            //
            //--SELECT	EC.Empresa_ID, E.Nombre Empresa, EC.Cuenta_ID, 
            //--        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = 3)     
            //--        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,
            //--        C.Nombre Cuenta, 
            //--        (SELECT ISNULL(SUM(Abono-Cargo),0) FROM CuentaConductores
            //--        WHERE Cuenta_ID = 3
            //--        AND Conductor_ID = @Conductor_ID) Saldo, 
            //--        0.00 Pagar
            //--FROM	Empresas_Cuentas EC
            //--INNER JOIN	Empresas E
            //--ON		EC.Empresa_ID = E.Empresa_ID
            //--INNER JOIN	Cuentas C
            //--ON		EC.Cuenta_ID = C.Cuenta_ID
            //--WHERE	EC.Cuenta_ID = 3 
            //--		AND	EC.Empresa_ID <> 3
            //--		AND	EC.Empresa_ID IN
            //--						(
            //--							SELECT	Empresa_ID
            //--							FROM	Contratos
            //--							WHERE	EstatusContrato_ID = 1
            //--							AND		Conductor_ID = @Conductor_ID	
            //--						)
            //
            //
            //
            //--SELECT	EC.Empresa_ID,
            //	--	E.Nombre Empresa,
            //	--	C.Cuenta_ID,
            //	--	( 
            //	--		SELECT MIN(Concepto_ID) 
            //	--		FROM Conceptos			
            //    --		WHERE	Cuenta_ID = C.Cuenta_ID
            //	--		AND	(Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%')
            //	--	) Concepto_ID,
            //	--	C.Nombre Cuenta,
            //	--	ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
            //		--FROM	Tickets,
            //			--	VariablesNegocio
            //		--WHERE	Tickets.Conductor_ID = @Conductor_ID
            //		--AND		VariableNegocio_ID = 'TarifaDescanso'
            //		--GROUP BY	Valor ),0) Saldo,
            //	--	0.00 Pagar
            //--FROM	Empresas_Cuentas EC
            //--INNER JOIN	Cuentas C
            //--ON		EC.Cuenta_ID = C.Cuenta_ID
            //--INNER JOIN	Empresas E
            //--ON		EC.Empresa_ID = E.Empresa_ID
            //--WHERE	C.Cuenta_ID = 42
            //--AND		EC.Empresa_ID IN
            //--(
            //	--SELECT	CONT.Empresa_ID
            //	--FROM	Contratos CONT JOIN Unidades UNID ON CONT.Unidad_ID = UNID.Unidad_ID
            //	--WHERE	CONT.EstatusContrato_ID = 1
            //	--AND		UNID.ConductorOperativo_ID = @Conductor_ID
            //--)
            //
            //
            //--UNION
            //
            //
            //
            //
            //SELECT	EC.Empresa_ID,
            //		E.Nombre Empresa,
            //		C.Cuenta_ID,
            //		( 
            //			SELECT MIN(Concepto_ID) 
            //			FROM Conceptos			
            //			WHERE	Cuenta_ID = C.Cuenta_ID
            //			AND	(Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%')
            //		) Concepto_ID,
            //		C.Nombre Cuenta,
            //		ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
            //		FROM	Tickets,
            //				VariablesNegocio
            //		WHERE	Tickets.Conductor_ID = @Conductor_ID
            //		AND		VariableNegocio_ID = 'TarifaDescanso'
            //		GROUP BY	Valor ),0) Saldo,
            //		0.00 Pagar
            //FROM	Empresas_Cuentas EC
            //INNER JOIN	Cuentas C
            //ON		EC.Cuenta_ID = C.Cuenta_ID
            //INNER JOIN	Empresas E
            //ON		EC.Empresa_ID = E.Empresa_ID
            //WHERE	C.Cuenta_ID = 17
            //AND		EC.Empresa_ID IN
            //(
            //	SELECT	CONT.Empresa_ID
            //	FROM	Contratos CONT JOIN Unidades UNID ON CONT.Unidad_ID = UNID.Unidad_ID
            //	WHERE	CONT.EstatusContrato_ID = 1
            //	AND		UNID.ConductorOperativo_ID = @Conductor_ID
            //)
            //
            //UNION
            //
            //SELECT	EC.Empresa_ID,
            //		E.Nombre Empresa,
            //		C.Cuenta_ID,
            //		( 
            //			SELECT MIN(Concepto_ID) 
            //			FROM Conceptos			
            //			WHERE	Cuenta_ID = C.Cuenta_ID
            //			AND	(Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%')
            //		) Concepto_ID,
            //		C.Nombre Cuenta,
            //		CASE EC.Empresa_ID
            //			WHEN 3 THEN
            //					ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
            //					FROM	Tickets,
            //							VariablesNegocio
            //					WHERE	Tickets.Conductor_ID = @Conductor_ID
            //					AND		VariableNegocio_ID = 'TarifaCooperativa'
            //					GROUP BY	Valor ),0)
            //			ELSE
            //					ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
            //					FROM	Tickets,
            //							VariablesNegocio
            //					WHERE	Tickets.Conductor_ID = @Conductor_ID
            //					AND		VariableNegocio_ID = 'TarifaCooperativaMetro'
            //					GROUP BY	Valor ),0)
            //		END Saldo,
            //		0.00 Pagar
            //FROM	Empresas_Cuentas EC
            //INNER JOIN	Cuentas C
            //ON		EC.Cuenta_ID = C.Cuenta_ID
            //INNER JOIN	Empresas E
            //ON		EC.Empresa_ID = E.Empresa_ID
            //WHERE	C.Cuenta_ID = 35
            //AND		EC.Empresa_ID IN
            //(
            //	SELECT	CONT.Empresa_ID
            //	FROM	Contratos CONT JOIN Unidades UNID ON CONT.Unidad_ID = UNID.Unidad_ID
            //	WHERE	CONT.EstatusContrato_ID = 1
            //	AND		UNID.ConductorOperativo_ID = @Conductor_ID	
            //)
            //
            //ORDER BY Empresa_ID, Cuenta_ID";


            // string sqlstr = @"exec spCuentaporPagar_CajaCobro @Conductor_ID";
            string sqlstr = @"exec  spCuentaporPagar_CajaCobro_usuario @Conductor_ID,@Usuario_ID";

            /* Por corregir: Debe ser por empresa el saldo de depósitos varios */

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("Usuario_ID", usuario_id);

            BindingList<AdeudosDeConductor> list = new BindingList<AdeudosDeConductor>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new AdeudosDeConductor(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToString(dr["Empresa"]), Convert.ToInt32(dr["Cuenta_ID"]),
                    Convert.ToInt32(dr["Concepto_ID"]), Convert.ToString(dr["Cuenta"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToDecimal(dr["Pagar"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Object conductor_id)
        {
            string sqlstr = @"SELECT	CC.Empresa_ID, E.Nombre Empresa, CC.Cuenta_ID, CC.Concepto_ID, C.Nombre Cuenta, CC.Saldo, 0.00 Pagar     
FROM	(     
SELECT	Conductor_ID, Empresa_ID, Cuenta_ID,      
        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = CuentaConductores.Cuenta_ID)     
        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,     
        (SUM(Abono)-SUM(Cargo)) Saldo     
FROM	CuentaConductores
WHERE   Conductor_ID = @Conductor_ID
GROUP BY Conductor_ID, Empresa_ID, Cuenta_ID   
        ) CC     
INNER JOIN	Empresas E     
ON		E.Empresa_ID = CC.Empresa_ID     
INNER JOIN	Cuentas C     
ON		C.Cuenta_ID = CC.Cuenta_ID
WHERE   C.Cuenta_ID NOT IN ( 9, 35, 17 )
		AND CC.Saldo <> 0

UNION 

SELECT	EC.Empresa_ID, E.Nombre Empresa, EC.Cuenta_ID, 
        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = 3)     
        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,
        C.Nombre Cuenta, 
        (SELECT ISNULL(SUM(Abono-Cargo),0) FROM CuentaConductores
        WHERE Cuenta_ID = 3
        AND Conductor_ID = @Conductor_ID) Saldo, 
        0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
WHERE	EC.Cuenta_ID = 3 
		AND	EC.Empresa_ID <> 3
		AND	EC.Empresa_ID IN
						(
							SELECT	Empresa_ID
							FROM	Contratos
							WHERE	EstatusContrato_ID = 1
							AND		Conductor_ID = @Conductor_ID	
						)

UNION

SELECT	EC.Empresa_ID,
		E.Nombre Empresa,
		C.Cuenta_ID,
		( 
			SELECT MIN(Concepto_ID) 
			FROM Conceptos			
			WHERE	Cuenta_ID = C.Cuenta_ID
			AND	(Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%')
		) Concepto_ID,
		C.Nombre Cuenta,
		ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
		FROM	Tickets,
				VariablesNegocio
		WHERE	Tickets.Conductor_ID = @Conductor_ID
		AND		VariableNegocio_ID = 'TarifaDescanso'
		GROUP BY	Valor ),0) Saldo,
		0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
WHERE	C.Cuenta_ID = 17
AND		EC.Empresa_ID IN
(
	SELECT	CONT.Empresa_ID
	FROM	Contratos CONT JOIN Unidades UNID ON CONT.Unidad_ID = UNID.Unidad_ID
	WHERE	CONT.EstatusContrato_ID = 1
	AND		UNID.ConductorOperativo_ID = @Conductor_ID
)

UNION

SELECT	EC.Empresa_ID,
		E.Nombre Empresa,
		C.Cuenta_ID,
		( 
			SELECT MIN(Concepto_ID) 
			FROM Conceptos			
			WHERE	Cuenta_ID = C.Cuenta_ID
			AND	(Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%')
		) Concepto_ID,
		C.Nombre Cuenta,
		CASE EC.Empresa_ID
			WHEN 3 THEN
					ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
					FROM	Tickets,
							VariablesNegocio
					WHERE	Tickets.Conductor_ID = @Conductor_ID
					AND		VariableNegocio_ID = 'TarifaCooperativa'
					GROUP BY	Valor ),0)
			ELSE
					ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MAX(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
					FROM	Tickets,
							VariablesNegocio
					WHERE	Tickets.Conductor_ID = @Conductor_ID
					AND		VariableNegocio_ID = 'TarifaCooperativaMetro'
					GROUP BY	Valor ),0)
		END Saldo,
		0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
WHERE	C.Cuenta_ID = 35
AND		EC.Empresa_ID IN
(
	SELECT	CONT.Empresa_ID
	FROM	Contratos CONT JOIN Unidades UNID ON CONT.Unidad_ID = UNID.Unidad_ID
	WHERE	CONT.EstatusContrato_ID = 1
	AND		UNID.ConductorOperativo_ID = @Conductor_ID	
)

ORDER BY Empresa_ID, Cuenta_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class AdeudosDeConductor

    public class DatosConductorUnidad
    {

        public DatosConductorUnidad()
        {
        }

        public DatosConductorUnidad(System.Int32? unidad_id, System.Int32? numeroeconomico, System.Int32 conductor_id, System.String conductor,
            System.Int32? kilometraje, System.String conductorcopia, System.Int32? contrato_id, System.String mensajeacaja, System.Int32? empresa_id)
        {
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.Kilometraje = kilometraje;
            this.ConductorCopia = conductorcopia;
            this.Contrato_ID = contrato_id;
            this.MensajeACaja = mensajeacaja;
            this.Empresa_ID = empresa_id;
        }

        public DatosConductorUnidad(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32 conductor_id,
            System.String conductor,
            System.Int32? kilometraje,
            System.String conductorcopia,
            System.Int32? contrato_id,
            System.String mensajeacaja,
            System.Int32? empresa_id,
            System.String empresa)
        {
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.Kilometraje = kilometraje;
            this.ConductorCopia = conductorcopia;
            this.Contrato_ID = contrato_id;
            this.MensajeACaja = mensajeacaja;
            this.Empresa_ID = empresa_id;
            this.Empresa = empresa;
        }

        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32 _Conductor_ID;
        public System.Int32 Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.Int32? _Kilometraje;
        public System.Int32? Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }

        private System.String _ConductorCopia;
        public System.String ConductorCopia
        {
            get { return _ConductorCopia; }
            set { _ConductorCopia = value; }
        }

        private System.Int32? _Contrato_ID;
        public System.Int32? Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }

        private System.String _MensajeACaja;
        public System.String MensajeACaja
        {
            get { return _MensajeACaja; }
            set { _MensajeACaja = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private decimal? _MontoDiario;
        public decimal? MontoDiario
        {
            get { return _MontoDiario; }
            set { _MontoDiario = value; }
        }

        private DateTime? _FechaUltimoPago;
        public DateTime? FechaUltimoPago
        {
            get { return _FechaUltimoPago; }
            set { _FechaUltimoPago = value; }
        }

        private int? _DiasSinPagar;
        public int? DiasSinPagar
        {
            get { return _DiasSinPagar; }
            set { _DiasSinPagar = value; }
        }

        private int? _AdeudoEnDias;
        public int? AdeudoEnDias
        {
            get { return _AdeudoEnDias; }
            set { _AdeudoEnDias = value; }
        }

        private decimal? _PagoRecomendado;
        public decimal? PagoRecomendado
        {
            get { return _PagoRecomendado; }
            set { _PagoRecomendado = value; }
        }

        private string _Empresa;
        public string Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        public string Descripcion
        {
            get
            {
                return Empresa + " - " + NumeroEconomico.ToString() + " - " + Conductor;
            }
        }

        public static DatosConductorUnidad GetFromConductorNomina(int conductor_id)
        {
            string sqlstr = @"dbo.usp_Nomina_Obtiene_DatosConductorUnidad";

            Hashtable @params = new Hashtable();
            @params.Add("@Conductor_ID", conductor_id);

            DataTable dt = (DB.QueryDS(sqlstr, @params)).Tables[0];

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            return datos;
        }

        public static DatosConductorUnidad GetFromConductor(int conductor_id)
        {
            string sqlstr = @"IF ( (SELECT COUNT(*) FROM Contratos
		WHERE	Conductor_ID = @Conductor_ID
		AND		EstatusContrato_ID = 1) = 0 )
BEGIN
	SELECT	TOP 1 NULL Unidad_ID, NULL NumeroEconomico, Co.Conductor_ID, Co.Apellidos + ' ' + Co.Nombre Conductor,
			U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
			Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario
	FROM	Conductores Co
	LEFT JOIN	Contratos C
	ON		C.Conductor_ID = Co.Conductor_ID
	LEFT JOIN	Unidades U
	ON		C.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores CoC
	ON		C.ConductorCopia_ID = CoC.Conductor_ID
	WHERE	Co.Conductor_ID = @Conductor_ID
	ORDER	BY	C.FechaInicial DESC
END
ELSE
BEGIN
	SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, Co.Apellidos + ' ' + Co.Nombre Conductor,
			U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
			Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario
	FROM	Conductores Co
	INNER JOIN	Contratos C
	ON		C.Conductor_ID = Co.Conductor_ID AND C.EstatusContrato_ID = 1
	LEFT JOIN	Unidades U
	ON		C.Unidad_ID = U.Unidad_ID
	LEFT JOIN	Conductores CoC
	ON		C.ConductorCopia_ID = CoC.Conductor_ID
	WHERE	Co.Conductor_ID = @Conductor_ID
END";

            Hashtable @params = new Hashtable();
            @params.Add("@Conductor_ID", conductor_id);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo, montodiario;
            montodiario = (datos.MontoDiario == 0) ? 1 : datos.MontoDiario.Value;

            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                datos.AdeudoEnDias = Math.Abs((int)(saldo / montodiario));
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        /// <summary>
        /// Obtiene el unidad_id del numero economico
        /// </summary>
        /// <param name="numeroeconomico"></param>
        /// <param name="empresa_id"></param>
        /// <param name="estacion_id"></param>
        /// <returns></returns>
        public static DatosConductorUnidad GetUnidad_ID(int numeroeconomico, int estacion_id)
        {
            //  El estatus de la unidad debe ser de alta
            DatosConductorUnidad datos = new DatosConductorUnidad();

            string sql = @"SELECT   Unidad_ID 
FROM Unidades
WHERE   NumeroEconomico = @NumeroEconomico
AND     Estacion_ID = @Estacion_ID
AND     EstatusUnidad_ID IN (2,10)";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);
            @params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sql, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Unidad no existe o es baja.");
            }

            DataRow dr = dt.Rows[0];

            datos.Unidad_ID = Convert.ToInt32(dr["Unidad_ID"]);
            datos.NumeroEconomico = numeroeconomico;

            return datos;
        }

        public static DatosConductorUnidad Get(int numeroeconomico, int? empresa_id, int? estacion_id, bool IncluirInactivos)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, Co.Apellidos + ' ' + Co.Nombre Conductor,
            		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
            		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario
            FROM	Unidades U
            INNER JOIN	Contratos C
            ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID in (SELECT Cuenta_ID FROM Transacciones.CuentasCobro Where Activo = 1))
            INNER JOIN	Conductores Co
            ON		C.Conductor_ID = Co.Conductor_ID
            LEFT JOIN	Conductores CoC
            ON		C.ConductorCopia_ID = CoC.Conductor_ID
            WHERE	U.NumeroEconomico = @NumeroEconomico
            AND (@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID)
            AND (@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID)";

            if (!IncluirInactivos)
                sqlstr = sqlstr + @"
            AND		U.EstatusUnidad_ID  = 2";
            else
                sqlstr = sqlstr + @"
            AND		U.EstatusUnidad_ID IN (2,6)";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);
            @params.Add("@Empresa_ID", empresa_id);
            @params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        public static DatosConductorUnidad GetConductorOperativo(int numeroeconomico, int? empresa_id, int? estacion_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		            UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		            U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		            Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
            FROM	Unidades U
            INNER JOIN	Conductores Co
            ON		U.ConductorOperativo_ID = Co.Conductor_ID
            LEFT JOIN	Contratos C
            ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
            LEFT JOIN	Conductores CoC
            ON		C.ConductorCopia_ID = CoC.Conductor_ID
            INNER JOIN   Empresas E
            ON      U.Empresa_ID = E.Empresa_ID
            WHERE	U.NumeroEconomico = @NumeroEconomico
            AND (@Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID)
            AND (@Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID);";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);
            @params.Add("@Empresa_ID", empresa_id);
            @params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                if (datos.MontoDiario != 0)
                {
                    datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
                }
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        public static int GetNumeroUnidades(int numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID IN (select Cuenta_ID from Transacciones.CuentasCobro WHERE Activo = 1) )
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	U.NumeroEconomico = @NumeroEconomico";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            return dt.Rows.Count;
        } // End GetData


        public static DatosConductorUnidad Get(int numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, Co.Apellidos + ' ' + Co.Nombre Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario
FROM	Unidades U
LEFT JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
WHERE	U.NumeroEconomico = @NumeroEconomico
ORDER BY	Conductor DESC";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                if (datos.MontoDiario != 0)
                {
                    datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
                }
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        public static DatosConductorUnidad GetByConductor_ID(int conductor_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	Co.Conductor_ID = @Conductor_ID
ORDER BY	Conductor DESC";

            Hashtable @params = new Hashtable();
            @params.Add("@Conductor_ID", conductor_id);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                if (datos.MontoDiario != 0)
                {
                    datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
                }
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        /*
         * Inicia modificación de código
         *  7 de Mayo de 2013, modificado por Luis Espino
         *      Se agrege la función GetByConductor_ID(int conductor_id, int numeroeconomico)
         *      para consultar los datos del conductor por numeroeconomico de unidad asignada,
         *      además de por folio (id) del conductor.
         */
        /// <summary>
        /// Devuelve los datos de conductor, a partir de un folio de conductor (conductor_id)
        /// y del número económico de la unidad
        /// </summary>
        /// <param name="conductor_id">El identificador o folio del conductor</param>
        /// <param name="numeroeconomico">El número económico de la unidad</param>
        /// <returns></returns>
        public static DatosConductorUnidad GetByConductor_ID(int conductor_id, int numeroeconomico)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	Co.Conductor_ID = @Conductor_ID
AND     U.NumeroEconomico = @NumeroEconomico
ORDER BY	MontoDiario DESC";

            Hashtable @params = new Hashtable();
            @params.Add("@Conductor_ID", conductor_id);
            @params.Add("@NumeroEconomico", numeroeconomico);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No hay datos que devolver");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                if (datos.MontoDiario != 0)
                {
                    datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
                }
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        public static List<DatosConductorUnidad> GetList(int numeroeconomico)
        {
            List<DatosConductorUnidad> list = new List<DatosConductorUnidad>();

            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	U.NumeroEconomico = @NumeroEconomico
ORDER BY	Conductor DESC";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new DatosConductorUnidad(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       Convert.ToInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       DB.GetNullableInt32(dr["Kilometraje"]),
                       Convert.ToString(dr["ConductorCopia"]),
                       DB.GetNullableInt32(dr["Contrato_ID"]),
                       Convert.ToString(dr["MensajeACaja"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       Convert.ToString(dr["Empresa"])
                    )
                );
            }

            return list;
        } // End GetData 

        public static DatosConductorUnidad Get(int numeroeconomico, int estacion_id)
        {
            string sqlstr = @"SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	U.NumeroEconomico = @NumeroEconomico
AND     Co.Estacion_ID = @Estacion_ID
ORDER BY	Conductor DESC";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);
            @params.Add("@Estacion_ID", estacion_id);

            DataTable dt = DB.QueryCommand(sqlstr, @params);

            if (dt.Rows.Count == 0)
            {
                throw new Exception("No data.");
            }

            DataRow dr = dt.Rows[0];
            DatosConductorUnidad datos = new DatosConductorUnidad(DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]),
                Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Conductor"]), DB.GetNullableInt32(dr["Kilometraje"]),
                   Convert.ToString(dr["ConductorCopia"]), DB.GetNullableInt32(dr["Contrato_ID"]), Convert.ToString(dr["MensajeACaja"]),
                      DB.GetNullableInt32(dr["Empresa_ID"]));

            // Calcular propiedades restantes
            datos.MontoDiario = Convert.ToDecimal(dr["MontoDiario"]);

            // Fecha ultimo pago            
            datos.FechaUltimoPago = Functions.FechaUltimoPagoConductor(datos.Conductor_ID);

            // Dias sin pagar
            if (datos.FechaUltimoPago == null)
            {
                datos.DiasSinPagar = 0;
            }
            else
            {
                DateTime ultimoPago = (DateTime)datos.FechaUltimoPago;
                TimeSpan diff = DateTime.Today.Subtract(ultimoPago);
                datos.DiasSinPagar = diff.Days;
            }

            // Adeudo en dias
            decimal saldo;
            saldo = Functions.SaldoRentasConductor(datos.Conductor_ID);
            if (saldo < 0)
            {
                //Validación para conductores de nomina en aeropuerto
                //o cualquiera cuyo monto diario a pagar sea 0
                datos.AdeudoEnDias = 0;
                if (datos.MontoDiario != 0)
                {
                    datos.AdeudoEnDias = Math.Abs((int)(saldo / datos.MontoDiario));
                }
            }

            //  Aqui es el cambio: saldo o dias por renta            
            datos.PagoRecomendado = datos.DiasSinPagar.Value * datos.MontoDiario.Value;

            return datos;

        } // End GetData

        public static DataTable GetDataTable(int numeroeconomico)
        {
            string sqlstr = "SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, Co.Apellidos + ' ' + Co.Nombre Conductor, \r\n" +
            "		U.Kilometraje, CoC.Apellidos + ' ' + CoC.Nombre ConductorCopia, C.Contrato_ID, \r\n" +
            "		Co.MensajeACaja, U.Empresa_ID \r\n" +
            "FROM	Unidades U \r\n" +
            "LEFT JOIN	Contratos C \r\n" +
            "ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1) \r\n" +
            "LEFT JOIN	Conductores Co \r\n" +
            "ON		C.Conductor_ID = Co.Conductor_ID \r\n" +
            "LEFT JOIN	Conductores CoC \r\n" +
            "ON		C.ConductorCopia_ID = CoC.Conductor_ID \r\n" +
            "WHERE	U.NumeroEconomico = @NumeroEconomico AND		U.EstatusUnidad_ID = 2";

            Hashtable @params = new Hashtable();
            @params.Add("@NumeroEconomico", numeroeconomico);

            return DB.QueryCommand(sqlstr, @params);
        }

    } // End Class DatosConductorUnidad

    public class BuscarZonas
    {

        public BuscarZonas()
        {
        }

        public BuscarZonas(System.Int32 zona_id, System.String nombre)
        {
            this.Zona_ID = zona_id;
            this.Nombre = nombre;
        }

        private System.Int32 _Zona_ID;
        public System.Int32 Zona_ID
        {
            get { return _Zona_ID; }
            set { _Zona_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public static List<BuscarZonas> GetPersonalizadas()
        {
            string sqlstr = "SELECT	Zona_ID, Nombre \r\n" +
            "FROM	Zonas \r\n" +
            "WHERE	Nombre LIKE '%Personal%' \r\n" +
            "ORDER BY Nombre ASC";

            List<BuscarZonas> list = new List<BuscarZonas>();
            DataTable dt = DB.Query(sqlstr);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BuscarZonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static List<BuscarZonas> Get(System.String nombre)
        {
            //string sqlstr = "SELECT	Zona_ID, Nombre \r\n" +
            //"FROM	Zonas \r\n" +
            //"WHERE	Nombre LIKE @Nombre + '%' \r\n" +
            //"AND Zona_ID IN ( SELECT Zona_ID FROM Tarifas ) \r\n" +
            //"ORDER BY Nombre ASC";
            string sqlstr = "dbo.usp_Obtiene_Zonas_Activas";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);

            List<BuscarZonas> list = new List<BuscarZonas>();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            //DataTable dt = DB.QueryCommand(sqlstr, m_params);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BuscarZonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToString(dr["Nombre"])));
                }
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.String nombre)
        {
            //string sqlstr = "SELECT	Zona_ID, Nombre \r\n" +
            //"FROM	Zonas \r\n" +
            //"WHERE	Nombre LIKE @Nombre + '%' \r\n" +
            //"AND Zona_ID IN ( SELECT Zona_ID FROM Tarifas ) \r\n" +
            //"ORDER BY Nombre ASC";
            string sqlstr = "dbo.usp_Obtiene_Zonas_Activas";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Nombre", nombre);

            DataSet ds = DB.QueryDS(sqlstr, m_params);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
            //return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class BuscarZonas

    public class PrecioServicio
    {

        public PrecioServicio()
        {
        }

        public PrecioServicio(System.Decimal precio)
        {
            this.Precio = precio;
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }


        public static PrecioServicio Get(System.Int32 zona_id, System.Int32? tiposervicio_id, bool ConComision)
        {
            string sqlstr = "dbo.usp_PrecioServicio_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Zona_ID", zona_id);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);
            m_params.Add("@ConComision", ConComision);
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            if (dt.Rows.Count == 0)
            {
                throw new Exception("La zona y el tipo de servicio no tienen configurado precio.");
            }
            DataRow dr = dt.Rows[0];
            return new PrecioServicio(Convert.ToDecimal(dr["Precio"]));
        } // End GetData

        public static DataTable GetDataTable(System.Int32 zona_id, System.Int32? tiposervicio_id, bool ConComision)
        {
            string sqlstr = "dbo.usp_PrecioServicio_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Zona_ID", zona_id);
            m_params.Add("@TipoServicio_ID", tiposervicio_id);
            m_params.Add("@ConComision", ConComision);
            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class PrecioServicio

    public class BoletoVenta
    {
        public BoletoVenta() { }

        public BoletoVenta(System.String servicio_id, System.Int32 foliodiario, System.Decimal precio, System.DateTime fecha, System.Int32? unidad,
            System.String claseservicio, System.String zona, System.String rfc, System.String razonsocial, System.String domicilio,
            System.String codigopostal, System.String ciudad, System.String estado, System.String telefono1, System.String leyendafiscal,
            System.String conductor, System.String leyendaregresos)
        {
            this.Servicio_ID = servicio_id;
            this.FolioDiario = foliodiario;
            this.Precio = precio;
            this.Fecha = fecha;
            this.Unidad = unidad;
            this.ClaseServicio = claseservicio;
            this.Zona = zona;
            this.RFC = rfc;
            this.RazonSocial = razonsocial;
            this.Domicilio = domicilio;
            this.CodigoPostal = codigopostal;
            this.Ciudad = ciudad;
            this.Estado = estado;
            this.Telefono1 = telefono1;
            this.LeyendaFiscal = leyendafiscal;
            this.LeyendaRegresos = leyendaregresos;
            this.Conductor = conductor;
        }

        private System.String _Servicio_ID;
        public System.String Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private System.Int32 _FolioDiario;
        public System.Int32 FolioDiario
        {
            get { return _FolioDiario; }
            set { _FolioDiario = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.DateTime _Fecha;
        public System.DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32? _Unidad;
        public System.Int32? Unidad
        {
            get { return _Unidad; }
            set { _Unidad = value; }
        }

        private System.String _ClaseServicio;
        public System.String ClaseServicio
        {
            get { return _ClaseServicio; }
            set { _ClaseServicio = value; }
        }

        private System.String _Zona;
        public System.String Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        private System.String _RFC;
        public System.String RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private System.String _RazonSocial;
        public System.String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private System.String _Domicilio;
        public System.String Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private System.String _CodigoPostal;
        public System.String CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }

        private System.String _Ciudad;
        public System.String Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        private System.String _Estado;
        public System.String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private System.String _Telefono1;
        public System.String Telefono1
        {
            get { return _Telefono1; }
            set { _Telefono1 = value; }
        }

        private System.String _LeyendaFiscal;
        public System.String LeyendaFiscal
        {
            get { return _LeyendaFiscal; }
            set { _LeyendaFiscal = value; }
        }

        private System.String _LeyendaRegresos;
        public System.String LeyendaRegresos
        {
            get { return _LeyendaRegresos; }
            set { _LeyendaRegresos = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        public static BoletoVenta Get(System.String servicio_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID, S.FolioDiario,    
		            S.Precio, S.Fecha, U.NumeroEconomico Unidad,  
		            C.Apellidos + ' ' + C.Nombre Conductor,  
		            CS.Nombre ClaseServicio, Z.Nombre Zona,    
		            E.RFC, E.RazonSocial, E.Domicilio, E.CodigoPostal,    
		            E.Ciudad, E.Estado, E.Telefono1, VN.Valor LeyendaFiscal
					, VNR.Valor LeyendaRegresos  
            FROM	Servicios S  WITH(NOLOCK)  
            INNER JOIN	Empresas E WITH(NOLOCK)
            ON		S.Empresa_ID = E.Empresa_ID    
            LEFT JOIN	Zonas Z WITH(NOLOCK)
            ON		Z.Zona_ID = S.Zona_ID    
            LEFT JOIN	Unidades U WITH(NOLOCK)
            ON		CASE WHEN S.Unidad_ID IS NULL THEN S.UnidadRegreso_ID ELSE S.Unidad_ID END = U.Unidad_ID
            LEFT JOIN	ClasesServicios CS WITH(NOLOCK)
            ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
            LEFT JOIN	Conductores C WITH(NOLOCK)
            ON		CASE WHEN S.Conductor_ID IS NULL THEN S.ConductorRegreso_ID ELSE S.Conductor_ID END = C.Conductor_ID
            CROSS JOIN	VariablesNegocio VN WITH(NOLOCK)
		  CROSS JOIN	VariablesNegocio VNR WITH(NOLOCK)
            WHERE	VN.VariableNegocio_ID = 'LeyendaFiscal'
		  AND VNR.VariableNegocio_ID = 'LeyendaRegresos'  
            AND		S.Servicio_ID = @Servicio_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio_id);

            List<BoletoVenta> list = new List<BoletoVenta>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow dr = dt.Rows[0];

            return new BoletoVenta(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Precio"]),
                Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["ClaseServicio"]), Convert.ToString(dr["Zona"]),
                Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]),
                Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["LeyendaFiscal"]),
                Convert.ToString(dr["Conductor"]), Convert.ToString(dr["LeyendaRegresos"]));

        } // End GetData

        public static List<BoletoVenta> GetList(List<string> servicios)
        {
            string sqlstr = @"SELECT	S.Servicio_ID, S.FolioDiario,    
		            S.Precio, S.Fecha, U.NumeroEconomico Unidad,  
		            C.Apellidos + ' ' + C.Nombre Conductor,  
		            CS.Nombre ClaseServicio, Z.Nombre Zona,    
		            E.RFC, E.RazonSocial, E.Domicilio, E.CodigoPostal,    
		            E.Ciudad, E.Estado, E.Telefono1, VN.Valor LeyendaFiscal
					, VNR.Valor LeyendaRegresos
            FROM	Servicios S WITH(NOLOCK)   
            INNER JOIN	Empresas E WITH(NOLOCK)
            ON		S.Empresa_ID = E.Empresa_ID WITH(NOLOCK)
            LEFT JOIN	Zonas Z WITH(NOLOCK)
            ON		Z.Zona_ID = S.Zona_ID    
            LEFT JOIN	Unidades U WITH(NOLOCK)
            ON		CASE WHEN S.Unidad_ID IS NULL THEN S.UnidadRegreso_ID ELSE S.Unidad_ID END = U.Unidad_ID
            LEFT JOIN	ClasesServicios CS WITH(NOLOCK)
            ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
            LEFT JOIN	Conductores C WITH(NOLOCK)
            ON		CASE WHEN S.Conductor_ID IS NULL THEN S.ConductorRegreso_ID ELSE S.Conductor_ID END = C.Conductor_ID
            CROSS JOIN	VariablesNegocio VN WITH(NOLOCK)
		  CROSS JOIN	VariablesNegocio VNR WITH(NOLOCK)
            WHERE	VN.VariableNegocio_ID = 'LeyendaFiscal'    
		  AND VNR.VariableNegocio_ID = 'LeyendaRegresos' 
            AND		S.Servicio_ID IN ( @Servicios )";

            sqlstr = sqlstr.Replace("@Servicios", string.Join(",", servicios.ToArray()));

            List<BoletoVenta> list = new List<BoletoVenta>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BoletoVenta(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Precio"]),
                    Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["ClaseServicio"]), Convert.ToString(dr["Zona"]),
                    Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Domicilio"]),
                    Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]),
                    Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["LeyendaFiscal"]),
                    Convert.ToString(dr["Conductor"]), Convert.ToString(dr["LeyendaRegresos"])));
            }
            return list;
        } // End GetData


        public static List<BoletoVenta> GetList(System.String servicio_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID, S.FolioDiario,    
		            S.Precio, S.Fecha, U.NumeroEconomico Unidad,  
		            C.Apellidos + ' ' + C.Nombre Conductor,  
		            CS.Nombre ClaseServicio, Z.Nombre Zona,    
		            E.RFC, E.RazonSocial, E.Domicilio, E.CodigoPostal,    
		            E.Ciudad, E.Estado, E.Telefono1, VN.Valor LeyendaFiscal  
				, VNR.Valor LeyendaRegresos  
            FROM	Servicios S WITH(NOLOCK)
            INNER JOIN	Empresas E WITH(NOLOCK)
            ON		S.Empresa_ID = E.Empresa_ID    
            LEFt JOIN	Zonas Z WITH(NOLOCK)
            ON		Z.Zona_ID = S.Zona_ID    
            LEFT JOIN	Unidades U WITH(NOLOCK)
            ON		CASE WHEN S.Unidad_ID IS NULL THEN S.UnidadRegreso_ID ELSE S.Unidad_ID END = U.Unidad_ID
            LEFT JOIN	ClasesServicios CS WITH(NOLOCK)
            ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
            INNER JOIN	Conductores C WITH(NOLOCK)
            ON		CASE WHEN S.Conductor_ID IS NULL THEN S.ConductorRegreso_ID ELSE S.Conductor_ID END = C.Conductor_ID
            CROSS JOIN	VariablesNegocio VN WITH(NOLOCK)
		  CROSS JOIN	VariablesNegocio VNR WITH(NOLOCK)
            WHERE	VN.VariableNegocio_ID = 'LeyendaFiscal'
		  AND VNR.VariableNegocio_ID = 'LeyendaRegresos' 
            AND		S.Servicio_ID = @Servicio_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio_id);

            List<BoletoVenta> list = new List<BoletoVenta>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BoletoVenta(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Precio"]),
                    Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Unidad"]), Convert.ToString(dr["ClaseServicio"]), Convert.ToString(dr["Zona"]),
                    Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Domicilio"]),
                    Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]),
                    Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["LeyendaFiscal"]),
                    Convert.ToString(dr["Conductor"]), Convert.ToString(dr["LeyendaRegresos"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.String servicio_id)
        {
            string sqlstr = @"SELECT	S.Servicio_ID, S.FolioDiario,    
		            S.Precio, S.Fecha, U.NumeroEconomico Unidad,  
		            C.Apellidos + ' ' + C.Nombre Conductor,  
		            CS.Nombre ClaseServicio, Z.Nombre Zona,    
		            E.RFC, E.RazonSocial, E.Domicilio, E.CodigoPostal,    
		            E.Ciudad, E.Estado, E.Telefono1, VN.Valor LeyendaFiscal   
				, VNR.Valor LeyendaRegresos 
            FROM	Servicios S WITH(NOLOCK)
            INNER JOIN	Empresas E WITH(NOLOCK)
            ON		S.Empresa_ID = E.Empresa_ID    
            LEFT JOIN	Zonas Z WITH(NOLOCK)
            ON		Z.Zona_ID = S.Zona_ID    
            INNER JOIN	Unidades U WITH(NOLOCK)
            ON		CASE WHEN S.Unidad_ID IS NULL THEN S.UnidadRegreso_ID ELSE S.Unidad_ID END = U.Unidad_ID
            LEFT JOIN	ClasesServicios CS WITH(NOLOCK)
            ON		S.ClaseServicio_ID = CS.ClaseServicio_ID
            INNER JOIN	Conductores C WITH(NOLOCK)
            ON		CASE WHEN S.Conductor_ID IS NULL THEN S.ConductorRegreso_ID ELSE S.Conductor_ID END = C.Conductor_ID
            CROSS JOIN	VariablesNegocio VN WITH(NOLOCK)
		  CROSS JOIN VariablesNegocio VNR WITH(NOLOCK)
            WHERE	VN.VariableNegocio_ID = 'LeyendaFiscal'
		  AND VNR.VariableNegocio_ID = 'LeyendaRegresos'
            AND		S.Servicio_ID = @Servicio_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable

    } // End Class BoletoVenta

    public class Vista_ComisionesServicios
    {

        public Vista_ComisionesServicios() { }

        public Vista_ComisionesServicios(System.Int32 comisionservicio_id, System.String nombre, System.Int32 comisionista_id, System.String comisionista, System.Int32 tipocomision_id, System.String tipocomision, System.Decimal monto)
        {
            this.ComisionServicio_ID = comisionservicio_id;
            this.Nombre = nombre;
            this.Comisionista_ID = comisionista_id;
            this.Comisionista = comisionista;
            this.TipoComision_ID = tipocomision_id;
            this.TipoComision = tipocomision;
            this.Monto = monto;
        }

        private System.Int32 _ComisionServicio_ID;
        public System.Int32 ComisionServicio_ID
        {
            get { return _ComisionServicio_ID; }
            set { _ComisionServicio_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private System.Int32 _Comisionista_ID;
        public System.Int32 Comisionista_ID
        {
            get { return _Comisionista_ID; }
            set { _Comisionista_ID = value; }
        }

        private System.String _Comisionista;
        public System.String Comisionista
        {
            get { return _Comisionista; }
            set { _Comisionista = value; }
        }

        private System.Int32 _TipoComision_ID;
        public System.Int32 TipoComision_ID
        {
            get { return _TipoComision_ID; }
            set { _TipoComision_ID = value; }
        }

        private System.String _TipoComision;
        public System.String TipoComision
        {
            get { return _TipoComision; }
            set { _TipoComision = value; }
        }

        private System.Decimal _Monto;
        public System.Decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        public static List<Vista_ComisionesServicios> Get(System.Int32? comisionservicio_id, System.Int32? comisionista_id,
            System.Int32? tipocomision_id, System.String nombre, System.Decimal? monto)
        {
            string sqlstr = @"usp_Vista_ComisionesServicios";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ComisionServicio_ID", comisionservicio_id);
            m_params.Add("@Comisionista_ID", comisionista_id);
            m_params.Add("@TipoComision_ID", tipocomision_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Monto", monto);

            List<Vista_ComisionesServicios> list = new List<Vista_ComisionesServicios>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ComisionesServicios(Convert.ToInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]),
                          Convert.ToInt32(dr["Comisionista_ID"]), Convert.ToString(dr["Comisionista"]), Convert.ToInt32(dr["TipoComision_ID"]),
                             Convert.ToString(dr["TipoComision"]), Convert.ToDecimal(dr["Monto"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32? comisionservicio_id, System.Int32? comisionista_id,
            System.Int32? tipocomision_id, System.String nombre, System.Decimal? monto)
        {
            string sqlstr = @"usp_Vista_ComisionesServicios";

            Hashtable m_params = new Hashtable();
            m_params.Add("@ComisionServicio_ID", comisionservicio_id);
            m_params.Add("@Comisionista_ID", comisionista_id);
            m_params.Add("@TipoComision_ID", tipocomision_id);
            m_params.Add("@Nombre", nombre);
            m_params.Add("@Monto", monto);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class Vista_ComisionesServicios

    public class Vista_VentasServiciosDeSesion_Consolidado
    {

        #region Constructors
        public Vista_VentasServiciosDeSesion_Consolidado()
        {
        }

        public Vista_VentasServiciosDeSesion_Consolidado(
            System.String zona,
            System.Decimal? precio,
            System.Int32? cantidad,
            System.Decimal? total
            )
        {
            this.Zona = zona;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        #endregion

        #region Properties
        private System.String _Zona;
        public System.String Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Int32? _Cantidad;
        public System.Int32? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_VentasServiciosDeSesion_Consolidado> Get(
            System.Object sesion_id)
        {
            string sqlstr = @"usp_Vista_VentasServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_VentasServiciosDeSesion_Consolidado> list = new List<Vista_VentasServiciosDeSesion_Consolidado>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_VentasServiciosDeSesion_Consolidado(
                       Convert.ToString(dr["Zona"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       DB.GetNullableInt32(dr["Cantidad"]),
                       DB.GetNullableDecimal(dr["Total"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object sesion_id)
        {
            string sqlstr = @"usp_Vista_VentasServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        /// <summary>
        /// Esta incluye tanto servicios de zonas como de tipos de servicio de conductor
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByFecha(System.DateTime fecha)
        {
            string sqlstr = @"usp_Vista_VentasServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        #endregion
    } // End Class Vista_VentasServiciosDeSesion_Consolidado

    public class Vista_ServiciosConductorDeSesion_Consolidado
    {

        #region Constructors
        public Vista_ServiciosConductorDeSesion_Consolidado()
        {
        }

        public Vista_ServiciosConductorDeSesion_Consolidado(
            System.String zona,
            System.Decimal? precio,
            System.Int32? cantidad,
            System.Decimal? total
            )
        {
            this.Zona = zona;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        #endregion

        #region Properties
        private System.String _Zona;
        public System.String Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Int32? _Cantidad;
        public System.Int32? Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Decimal? _Total;
        public System.Decimal? Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_ServiciosConductorDeSesion_Consolidado> Get(
            System.Object sesion_id)
        {
            string sqlstr = @"usp_Vista_ServiciosConductorDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_ServiciosConductorDeSesion_Consolidado> list = new List<Vista_ServiciosConductorDeSesion_Consolidado>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_ServiciosConductorDeSesion_Consolidado(
                       Convert.ToString(dr["Zona"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       DB.GetNullableInt32(dr["Cantidad"]),
                       DB.GetNullableDecimal(dr["Total"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Object sesion_id)
        {
            string sqlstr = @"usp_Vista_ServiciosConductorDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable


        #endregion
    } // End Class Vista_ServiciosConductorDeSesion_Consolidado

    public class Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado
    {

        public Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado() { }

        public Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado(System.String moneda, System.Int32 cantidad, System.Decimal total)
        {
            this.Moneda = moneda;
            this.Cantidad = cantidad;
            this.Total = total;
        }

        private System.String _Moneda;
        public System.String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        private System.Int32 _Cantidad;
        public System.Int32 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private System.Decimal _Total;
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public static List<Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado> Get(System.Int32 sesion_id)
        {
            string sqlstr = @"dbo.usp_Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado> list = new List<Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado(Convert.ToString(dr["Moneda"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Total"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 sesion_id)
        {
            string sqlstr = @"dbo.usp_Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        public static DataTable GetDataTableByFecha(System.DateTime fecha)
        {
            string sqlstr = @"dbo.usp_Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado

    public class Vista_DatosDeSesion
    {

        public Vista_DatosDeSesion()
        {
        }

        public Vista_DatosDeSesion(System.Int32 sesion_id, System.String empresa, System.String estacion, System.String caja, System.String vendedor, System.DateTime fechainicial, System.DateTime fechafinal)
        {
            this.Sesion_ID = sesion_id;
            this.Empresa = empresa;
            this.Estacion = estacion;
            this.Caja = caja;
            this.Vendedor = vendedor;
            this.FechaInicial = fechainicial;
            this.FechaFinal = fechafinal;
        }

        private System.Int32 _Sesion_ID;
        public System.Int32 Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private System.String _Empresa;
        public System.String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        private System.String _Estacion;
        public System.String Estacion
        {
            get { return _Estacion; }
            set { _Estacion = value; }
        }

        private System.String _Caja;
        public System.String Caja
        {
            get { return _Caja; }
            set { _Caja = value; }
        }

        private System.String _Vendedor;
        public System.String Vendedor
        {
            get { return _Vendedor; }
            set { _Vendedor = value; }
        }

        private System.DateTime _FechaInicial;
        public System.DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private System.DateTime _FechaFinal;
        public System.DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }


        public static List<Vista_DatosDeSesion> Get(System.Int32 sesion_id)
        {
            string sqlstr = "usp_Vista_DatosDeSesion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            List<Vista_DatosDeSesion> list = new List<Vista_DatosDeSesion>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_DatosDeSesion(Convert.ToInt32(dr["Sesion_ID"]), Convert.ToString(dr["Empresa"]), Convert.ToString(dr["Estacion"]),
                          Convert.ToString(dr["Caja"]), Convert.ToString(dr["Vendedor"]), Convert.ToDateTime(dr["FechaInicial"]),
                             Convert.ToDateTime(dr["FechaFinal"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 sesion_id)
        {
            string sqlstr = "usp_Vista_DatosDeSesion";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class Vista_DatosDeSesion

    public class Vista_ComisionistasServicios
    {

        public Vista_ComisionistasServicios()
        {
        }

        public Vista_ComisionistasServicios(System.Int32 empresa_id, System.String nombre)
        {
            this.Empresa_ID = empresa_id;
            this.Nombre = nombre;
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.String _Nombre;
        public System.String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public static List<Vista_ComisionistasServicios> Get()
        {
            string sqlstr = @"dbo.usp_Vista_ComisionistasServicios";
            List<Vista_ComisionistasServicios> list = new List<Vista_ComisionistasServicios>();
            DataTable dt = DB.QueryDS(sqlstr).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_ComisionistasServicios(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"dbo.usp_Vista_ComisionistasServicios";
            return DB.QueryDS(sqlstr).Tables[0];
        } // End GetDataTable

    } // End Class Vista_ComisionistasServicios

    public class ServiciosPendientesConductor
    {

        #region Constructors
        public ServiciosPendientesConductor()
        {
        }

        public ServiciosPendientesConductor(
            System.String servicio_id,
            System.Int32? empresa_id,
            System.Int32? cuenta_id,
            System.Decimal? precio,
            System.Decimal? pagoconductor,
            System.String destino,
            System.Decimal? productividad,
            System.Int32? tiposervicioconductor_id
            )
        {
            this.Servicio_ID = servicio_id;
            this.Empresa_ID = empresa_id;
            this.Cuenta_ID = cuenta_id;
            this.Precio = precio;
            this.PagoConductor = pagoconductor;
            this.Destino = destino;
            this.Productividad = productividad;
            this.TipoServicioConductor_ID = tiposervicioconductor_id;
        }

        #endregion

        #region Properties
        private System.String _Servicio_ID;
        public System.String Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private System.Int32? _Empresa_ID;
        public System.Int32? Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.Int32? _Cuenta_ID;
        public System.Int32? Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.Decimal? _Precio;
        public System.Decimal? Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal? _PagoConductor;
        public System.Decimal? PagoConductor
        {
            get { return _PagoConductor; }
            set { _PagoConductor = value; }
        }

        private System.String _Destino;
        public System.String Destino
        {
            get { return _Destino; }
            set { _Destino = value; }
        }

        private System.Decimal? _Productividad;
        public System.Decimal? Productividad
        {
            get { return _Productividad; }
            set { _Productividad = value; }
        }

        private System.Int32? _TipoServicioConductor_ID;
        public System.Int32? TipoServicioConductor_ID
        {
            get { return _TipoServicioConductor_ID; }
            set { _TipoServicioConductor_ID = value; }
        }

        #endregion

        #region Methods
        public static List<ServiciosPendientesConductor> Get(
            System.Int32 conductor_id,
            System.DateTime fecha)
        {
            DateTime fechainicial, fechafinal;
            fechainicial = fecha.Date.AddDays(-1).AddHours(6);
            fechafinal = fechainicial.AddDays(1);

            string sqlstr = @"dbo.usp_ServiciosPendientesConductor";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<ServiciosPendientesConductor> list = new List<ServiciosPendientesConductor>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new ServiciosPendientesConductor(
                       Convert.ToString(dr["Servicio_ID"]),
                       DB.GetNullableInt32(dr["Empresa_ID"]),
                       DB.GetNullableInt32(dr["Cuenta_ID"]),
                       DB.GetNullableDecimal(dr["Precio"]),
                       DB.GetNullableDecimal(dr["PagoConductor"]),
                       Convert.ToString(dr["Destino"]),
                       DB.GetNullableDecimal(dr["Productividad"]),
                       DB.GetNullableInt32(dr["TipoServicioConductor_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 conductor_id,
            System.DateTime fecha)
        {
            DateTime fechainicial, fechafinal;
            fechainicial = fecha.Date.AddDays(-1).AddHours(6);
            fechafinal = fechainicial.AddDays(1);

            string sqlstr = @"dbo.usp_ServiciosPendientesConductor";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class ServiciosPendientesConductor

    public class Vista_BoletosTicketPago
    {

        public Vista_BoletosTicketPago()
        {
        }

        public Vista_BoletosTicketPago(System.String servicio_id, System.Int32 ticket_id, System.Int32 unidad_id, System.Int32 conductor_id, System.Int32 empresa_id, System.Int32 cuenta_id, System.Decimal precio, System.Decimal pagoconductor)
        {
            this.Servicio_ID = servicio_id;
            this.Ticket_ID = ticket_id;
            this.Unidad_ID = unidad_id;
            this.Conductor_ID = conductor_id;
            this.Empresa_ID = empresa_id;
            this.Cuenta_ID = cuenta_id;
            this.Precio = precio;
            this.PagoConductor = pagoconductor;
        }

        private System.String _Servicio_ID;
        public System.String Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private System.Int32 _Ticket_ID;
        public System.Int32 Ticket_ID
        {
            get { return _Ticket_ID; }
            set { _Ticket_ID = value; }
        }

        private System.Int32 _Unidad_ID;
        public System.Int32 Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32 _Conductor_ID;
        public System.Int32 Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.Int32 _Empresa_ID;
        public System.Int32 Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private System.Int32 _Cuenta_ID;
        public System.Int32 Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }

        private System.Decimal _Precio;
        public System.Decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private System.Decimal _PagoConductor;
        public System.Decimal PagoConductor
        {
            get { return _PagoConductor; }
            set { _PagoConductor = value; }
        }


        public static List<Vista_BoletosTicketPago> Get(System.Int32 ticket_id)
        {
            string sqlstr = "dbo.usp_Vista_BoletosTicketPago";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            List<Vista_BoletosTicketPago> list = new List<Vista_BoletosTicketPago>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Vista_BoletosTicketPago(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PagoConductor"])));
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(System.Int32 ticket_id)
        {
            string sqlstr = "usp_Vista_BoletosTicketPago";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Ticket_ID", ticket_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

    } // End Class Vista_BoletosTicketPago

    public class Vista_BitacoraUnidades
    {

        #region Constructors
        public Vista_BitacoraUnidades()
        {
        }

        public Vista_BitacoraUnidades(
            System.Int32? unidad_id,
            System.Int32? numeroeconomico,
            System.Int32? conductor_id,
            System.String conductor,
            System.String estatusoperativo,
            System.DateTime? fecha,
            System.Int32? estacion_id
            )
        {
            this.Unidad_ID = unidad_id;
            this.NumeroEconomico = numeroeconomico;
            this.Conductor_ID = conductor_id;
            this.Conductor = conductor;
            this.EstatusOperativo = estatusoperativo;
            this.Fecha = fecha;
            this.Estacion_ID = estacion_id;
        }

        #endregion

        #region Properties
        private System.Int32? _Unidad_ID;
        public System.Int32? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private System.Int32? _NumeroEconomico;
        public System.Int32? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private System.Int32? _Conductor_ID;
        public System.Int32? Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private System.String _Conductor;
        public System.String Conductor
        {
            get { return _Conductor; }
            set { _Conductor = value; }
        }

        private System.String _EstatusOperativo;
        public System.String EstatusOperativo
        {
            get { return _EstatusOperativo; }
            set { _EstatusOperativo = value; }
        }

        private System.DateTime? _Fecha;
        public System.DateTime? Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private System.Int32? _Estacion_ID;
        public System.Int32? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_BitacoraUnidades> Get(
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Vista_BitacoraUnidades";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);

            List<Vista_BitacoraUnidades> list = new List<Vista_BitacoraUnidades>();
            DataTable dt = DB.QueryDS(sqlstr, m_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_BitacoraUnidades(
                       DB.GetNullableInt32(dr["Unidad_ID"]),
                       DB.GetNullableInt32(dr["NumeroEconomico"]),
                       DB.GetNullableInt32(dr["Conductor_ID"]),
                       Convert.ToString(dr["Conductor"]),
                       Convert.ToString(dr["EstatusOperativo"]),
                       DB.GetNullableDateTime(dr["Fecha"]),
                       DB.GetNullableInt32(dr["Estacion_ID"])
                       )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32? estacion_id)
        {
            string sqlstr = @"usp_Vista_BitacoraUnidades";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Estacion_ID", estacion_id);

            return DB.QueryDS(sqlstr, m_params).Tables[0];
        } // End GetDataTable

        #endregion
    } // End Class Vista_BitacoraUnidades

    #region Adendums

    public class Vista_ContratosAdendum
    {
        public int Contrato { get; set; }
        public string Conductor { get; set; }
        public int Unidad { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Observaciones { get; set; }

        public static DataTable GetDataTable()
        {
            return DB.Query("usp_Contratos_Vigentes");
        }
    }

    public class Vista_ContratosAdendumDetalle
    {
        public int Adendum_ID { get; set; }
        public int Contrato_ID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Indefinido { get; set; }
        public string ClasificacionAdendums_Descripcion { get; set; }
        public string EstatusAdendums_Descripcion { get; set; }
        public int ClasificacionAdendum_ID { get; set; }
        public decimal TotalMontoAjustado { get; set; }
        public decimal TotalDiasAjustar { get; set; }
        public string Observaciones { get; set; }

        public static DataTable GetDataTable()
        {
            return DB.Query("usp_Adendums_Consulta");
        }

        public static DataTable GetDataTable(int ContratoId)
        {
            return DB.Query(string.Format("usp_Adendums_Consulta {0}", ContratoId));
        }

        public static DataTable GetDataTable(int ContratoId, int BuscaCancelar)
        {
            return DB.Query(string.Format("usp_Adendums_Consulta {0},{1}", ContratoId, BuscaCancelar));
        }
    }

    public class Vista_ClasificacionAdendum
    {
        public DataTable GetDataTable()
        {
            return DB.Query("usp_ClasificacionAdendums");
        }
    }

    public class Vista_ReporteAdendums
    {
        public string Conductor { get; set; }
        public int NumeroEconomico { get; set; }
        public int Adendum_ID { get; set; }
        public int Contrato_ID { get; set; }
        public string ClasificacionAdendums_Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Indefinido { get; set; }
        public decimal MontoAjustadoAlDiaDeHoy { get; set; }
        public int DiasAjustadosAlDiaDeHoy { get; set; }
        public string Observaciones { get; set; }

        public DataTable GetDataTable(string dtIni, string dtFin)
        {
            return DB.Query(string.Format("exec usp_ReporteAdendums @FechaInicio = '{0}', @FechaFin = '{1}'", dtIni, dtFin));
        }

        public DataTable GetDataTable()
        {

            return DB.Query("exec usp_ReporteAdendums");
        }

        public List<Vista_ReporteAdendums> Get(int Adendum_ID)
        {
            List<Vista_ReporteAdendums> lista = new List<Vista_ReporteAdendums>();
            Vista_ReporteAdendums ad = new Vista_ReporteAdendums();

            DataTable dt = DB.Query(string.Format("exec usp_ReporteAdendums @Adendum_ID = {0}", Adendum_ID));

            foreach (DataRow dr in dt.Rows)
            {
                ad = new Vista_ReporteAdendums();
                ad.Adendum_ID = Convert.ToInt32(dr["Adendum_ID"].ToString());
                ad.Contrato_ID = Convert.ToInt32(dr["Contrato_ID"].ToString());
                ad.Conductor = dr["Conductor"].ToString();
                ad.DiasAjustadosAlDiaDeHoy = Convert.ToInt32(dr["DiasAjustadosAlDiaDeHoy"].ToString());
                ad.FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString());
                ad.FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString());
                ad.Indefinido = Convert.ToBoolean(dr["Indefinido"].ToString());
                ad.NumeroEconomico = Convert.ToInt32(dr["NumeroEconomico"].ToString());
                ad.MontoAjustadoAlDiaDeHoy = Convert.ToDecimal(dr["MontoAjustadoAlDiaDeHoy"].ToString());
                ad.ClasificacionAdendums_Descripcion = dr["ClasificacionAdendums_Descripcion"].ToString();
                ad.Observaciones = dr["Observaciones"].ToString();
                lista.Add(ad);
            }

            return lista;
        }
    }

    #endregion

    public class Vista_EstatusContrato
    {
        public int Contrato_ID { get; set; }
        public int EstatusContrato_ID { get; set; }
        public string Nombre { get; set; }

        public static List<Vista_EstatusContrato> Get(int conductor_id, int empresa_id, int? unidad_id, int cuenta_id)
        {
            List<Vista_EstatusContrato> lista = new List<Vista_EstatusContrato>();
            Vista_EstatusContrato ad = new Vista_EstatusContrato();
            string sqlstr = "dbo.usp_ObtieneEstatusContrato";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Empresa_ID", empresa_id);
            m_params.Add("@Unidad_ID", unidad_id);
            m_params.Add("@Cuenta_ID", cuenta_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ad = new Vista_EstatusContrato();
                ad.Contrato_ID = Convert.ToInt32(dr["Contrato_ID"].ToString());
                ad.EstatusContrato_ID = Convert.ToInt32(dr["EstatusContrato_ID"].ToString());
                ad.Nombre = dr["Nombre"].ToString();
                lista.Add(ad);
            }

            return lista;
        }
    }

    public class Vista_ProgramacionPista
    {
        private List<List<classes.Aeropuerto.ProgramacionPistas>> lProgramaciones = new List<List<classes.Aeropuerto.ProgramacionPistas>>();

        public List<classes.Aeropuerto.ProgramacionPistas> SemanaActualAñoActual { get { return lProgramaciones[0]; } }
        public List<classes.Aeropuerto.ProgramacionPistas> SemanaAnteriorAñoActual
        {
            get
            {
                return lProgramaciones[2].GetRange((lProgramaciones[2].Count - (37 * 15)), (37 * 6));
            }
        }
        public List<classes.Aeropuerto.ProgramacionPistas> SemanaActualAñoAnterior { get { return lProgramaciones[1]; } }
        public List<classes.Aeropuerto.ProgramacionPistas> UltimasSemanasAñoActual { get { return lProgramaciones[2]; } }
        public List<classes.Aeropuerto.ProgramacionPistas> UltimasSemanasAñoAnterior { get { return lProgramaciones[3]; } }

        public Vista_ProgramacionPista()
        {
            lProgramaciones = Get(null);
        }

        private static List<List<classes.Aeropuerto.ProgramacionPistas>> Get(DateTime? fecha)
        {
            List<List<classes.Aeropuerto.ProgramacionPistas>> lEstadisticas = new List<List<classes.Aeropuerto.ProgramacionPistas>>();

            if (fecha == null)
                fecha = DateTime.Now.Date;
            string sqlstr = "dbo.usp_ProgramacionDiaria_Obtiene_Estadisticas";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Desde", fecha);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataTable t in ds.Tables)
            {
                List<classes.Aeropuerto.ProgramacionPistas> lp = new List<classes.Aeropuerto.ProgramacionPistas>();
                foreach (DataRow dr in t.Rows)
                {
                    classes.Aeropuerto.ProgramacionPistas p = new classes.Aeropuerto.ProgramacionPistas();
                    p.Id = Convert.ToInt32(dr["ProgramacionDiaria_ID"].ToString());
                    p.Año = Convert.ToInt32(dr["Año"].ToString());
                    p.Mes = dr["Mes"].ToString();
                    p.Semana = Convert.ToInt32(dr["Semana"].ToString());
                    p.Dia_Semana = dr["Dia_Semana"].ToString();
                    p.Num_Dia = Convert.ToInt32(dr["Num_Dia"].ToString());
                    p.Dia = Convert.ToDateTime(dr["Dia"].ToString());
                    p.HPeriodo = p.Dia.AddTicks(Convert.ToDateTime(dr["Periodo"].ToString()).TimeOfDay.Ticks);
                    p.Servicios_Disponibles = Convert.ToInt32(dr["ServDisponibles"].ToString());
                    p.Servicios_Programados = Convert.ToInt32(dr["ServProgramados"].ToString());
                    lp.Add(p);
                }
                lEstadisticas.Add(lp);
            }

            return lEstadisticas;
        }

        public void ActualizaProgramaciones(DateTime fecha)
        {
            lProgramaciones.Clear();
            lProgramaciones = Get(fecha);
        }

        public static bool ActualizaPista(int id, int cantidad, string usuario_id)
        {
            string sqlstr = "dbo.usp_ProgramacionDiaria_Actualiza";
            Hashtable m_params = new Hashtable();
            m_params.Add("@ProgramacionDiaria_ID", id);
            m_params.Add("@ServDisponibles", cantidad);
            m_params.Add("@UsuarioActualiza", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }
    }

    public class Vista_RegresosVendidos
    {
        private List<classes.Aeropuerto.RegresoVendido> RegresosVendidos = new List<classes.Aeropuerto.RegresoVendido>();

        public Vista_RegresosVendidos()
        {

        }

        public static List<classes.Aeropuerto.RegresoVendido> BuscaRegresosVendidos(string folio, DateTime? fecha, int? zona_id, double? precio)
        {
            List<classes.Aeropuerto.RegresoVendido> lRegresos = new List<classes.Aeropuerto.RegresoVendido>();

            string sqlstr = "dbo.usp_Obtiene_RegresosVendidos";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Folio", folio);
            m_params.Add("@fecha", fecha);
            m_params.Add("@Zona_ID", zona_id);
            m_params.Add("@Precio", precio);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.RegresoVendido r = new classes.Aeropuerto.RegresoVendido();
                r.Boleto = dr["Boleto"].ToString();
                r.Folio = Convert.ToInt32(dr["Folio"].ToString());
                r.Precio = Convert.ToDouble(dr["Precio"].ToString());
                r.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                if (!DB.IsNullOrEmpty(dr["FechaExpiracion"]))
                    r.Fecha_Expiracion = Convert.ToDateTime(dr["FechaExpiracion"].ToString());
                r.Zona = dr["Zona"].ToString();
                r.Forma_Pago = dr["FormaPago"].ToString();
                r.Estatus = dr["Estatus"].ToString();
                r.Tipo_Servicio = dr["TipoServicio"].ToString();
                r.Numero_Confirmacion = dr["Reservacion_ID"].ToString();
                r.Payback = dr["Referencia_PayBack"].ToString();
                r.Unidad = dr["Unidad"].ToString();
                r.Conductor = dr["Conductor"].ToString();
                if (!DB.IsNullOrEmpty(dr["FechaServicio"]))
                    r.Fecha_Servicio = Convert.ToDateTime(dr["FechaServicio"].ToString());
                if (!DB.IsNullOrEmpty(dr["Unidad_Venta"]))
                    r.Unidad_Vende = dr["Unidad_Venta"].ToString();
                if (!DB.IsNullOrEmpty(dr["Conductor_Venta"]))
                    r.Conductor_Vende = dr["Conductor_Venta"].ToString();
                lRegresos.Add(r);
            }
            return lRegresos;
        }
    }

    public static class Vista_EquipoGas
    {
        public static bool UnidadConEquipoGas(int contrato_id)
        {
            string sp = "dbo.usp_EquipoGas_ContratoConEquipo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Contrato_ID", contrato_id);
            object o = DB.ExecuteCommandSP_With_Return(sp, m_params);
            return (bool)o;
        }
    }

    public static class Vista_NominaCAT
    {
        public static List<classes.Aeropuerto.ConductorTipoNomina> GetConductoresEnContratoPorPeriodo(DateTime periodo)
        {
            List<classes.Aeropuerto.ConductorTipoNomina> lRegresos = new List<classes.Aeropuerto.ConductorTipoNomina>();

            string sqlstr = "dbo.usp_Nomina_Obtiene_Conductores_en_Contrato_por_Periodo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@InicioPeriodo", periodo);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.ConductorTipoNomina c = new classes.Aeropuerto.ConductorTipoNomina();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Conductor = dr["Conductor"].ToString();
                c.TipoNomina.TipoNominaVigente_ID = Convert.ToInt32(dr["TipoNominaVigente_ID"]);
                c.TipoNomina.SueldoFijo = Convert.ToDouble(dr["SueldoFijo"]);
                c.TipoNomina.CargaSocial = Convert.ToDouble(dr["CargaSocial"]);
                c.TipoNomina.VigenciaInicio = Convert.ToDateTime(dr["VigenciaInicio"]);
                c.TipoNomina.VigenciaFin = Convert.ToDateTime(dr["VigenciaFin"]);
                c.TipoNomina.Vigente = Convert.ToBoolean(dr["Vigente"]);
                c.TipoNomina.Tiponomina.TipoNomina_ID = Convert.ToInt32(dr["TipoNomina_ID"]);
                c.TipoNomina.Tiponomina.Nombre = dr["TipoNomina"].ToString();
                c.Periodo = Convert.ToDateTime(dr["Periodo"]);
                lRegresos.Add(c);
            }
            return lRegresos;
        }

        public static DataTable GetTblConductoresEnContratoPorPeriodo(DateTime periodo)
        {
            List<classes.Aeropuerto.ConductorTipoNomina> lRegresos = new List<classes.Aeropuerto.ConductorTipoNomina>();

            string sqlstr = "dbo.usp_Nomina_Obtiene_Conductores_en_Contrato_por_Periodo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@InicioPeriodo", periodo);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            return ds.Tables[0];
        }

        public static List<classes.Aeropuerto.TipoIncidenciaConductor> GetTiposIncidenciasConductor()
        {
            List<classes.Aeropuerto.TipoIncidenciaConductor> lti = new List<classes.Aeropuerto.TipoIncidenciaConductor>();
            string sqlstr = "dbo.usp_Nomina_IncidenciasConductor_ObtieneTiposIncidencias";
            Hashtable m_params = new Hashtable();
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.TipoIncidenciaConductor i = new classes.Aeropuerto.TipoIncidenciaConductor();
                i.TipoIncidenciaConductor_ID = Convert.ToInt32(dr["TipoIncidencia_ID"]);
                i.Nombre = dr["Nombre"].ToString();
                i.AnulaMontoVariable = Convert.ToBoolean(dr["AnulaMontoVariable"]);
                i.ClasificacionIncidencia = Convert.ToInt32(dr["ClasificacionIncidencia_ID"]);
                lti.Add(i);
            }

            return lti;
        }

        public static List<classes.Aeropuerto.EstatusIncidenciaConductor> GetEstatusIncidenciaConductor()
        {
            List<classes.Aeropuerto.EstatusIncidenciaConductor> dic = new List<classes.Aeropuerto.EstatusIncidenciaConductor>();
            string sqlstr = "dbo.usp_Nomina_IncidenciasConductor_ObtieneEstatusIncidencias";
            Hashtable m_params = new Hashtable();
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dic.Add(new classes.Aeropuerto.EstatusIncidenciaConductor(Convert.ToInt32(dr[0]), dr[1].ToString()));
            }

            return dic;
        }

        public static List<classes.Aeropuerto.IncidenciaConductor> GetIncidenciasConductor(DateTime desde, DateTime hasta, int? tipo, int? conductor, int? estatus)
        {
            List<classes.Aeropuerto.IncidenciaConductor> lti = new List<classes.Aeropuerto.IncidenciaConductor>();
            string sqlstr = "dbo.usp_Nomina_IncidenciasConductor_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Desde", desde);
            m_params.Add("@Hasta", hasta);
            if (tipo != null)
                m_params.Add("@TipoIncidencia_ID", tipo);
            if (conductor != null)
                m_params.Add("@Conductor_ID", conductor);
            if (estatus != null)
                m_params.Add("@EstatusIncidenciaConductor_ID", estatus);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.IncidenciaConductor i = new classes.Aeropuerto.IncidenciaConductor();
                i.IncidenciaConductor_ID = Convert.ToInt32(dr["IncidenciaConductor_ID"]);
                i.Conductor = new classes.Aeropuerto.ConductorNomina();
                i.Conductor.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                i.Conductor.Conductor = dr["Conductor"].ToString();
                i.TipoIncidencia = new classes.Aeropuerto.TipoIncidenciaConductor();
                i.TipoIncidencia.TipoIncidenciaConductor_ID = Convert.ToInt32(dr["TipoIncidencia_ID"]);
                i.TipoIncidencia.Nombre = dr["Incidencia"].ToString();
                i.TipoIncidencia.AnulaMontoVariable = Convert.ToBoolean(dr["AnulaMontoVariable"]);
                i.Monto = Convert.ToDouble(dr["Monto"]);
                i.Observaciones = dr["Observaciones"].ToString();
                i.Usuario_ID = dr["Usuario_ID"].ToString();
                i.FechaCaptura = Convert.ToDateTime(dr["FechaCaptura"]);
                i.EstatusIncidencia_Conductor = new classes.Aeropuerto.EstatusIncidenciaConductor();
                i.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID = Convert.ToInt32(dr["EstatusIncidenciaConductor_ID"]);
                i.EstatusIncidencia_Conductor.Nombre = dr["Estatus"].ToString();
                i.PeriodoAplicacionIncidencia = Convert.ToDateTime(dr["PeriodoAplicacionIncidencia"]);
                lti.Add(i);
            }

            return lti;
        }

        public static bool InsertaConductorTipoNominaPeriodo(int conductor_id, int tiponomina, DateTime periodo)
        {
            string sqlstr = "usp_Nomina_Inserta_ConductorTipoNomina";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@TipoNomina_ID", tiponomina);
            m_params.Add("@Periodo", periodo);
            bool r = false;
            try
            {
                r = DB.ExecuteCommandSP(sqlstr, m_params);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el Tipo de Nómina del Conductor.", ex);
            }
            return r;
        }

        public static List<classes.Aeropuerto.ConductorNomina> GetConductoresAeropuertoPorPeriodo(DateTime periodo)
        {
            List<classes.Aeropuerto.ConductorNomina> lCond = new List<classes.Aeropuerto.ConductorNomina>();
            string sqlstr = "dbo.usp_Nomina_Obtiene_Conductores_por_Periodo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.ConductorNomina c = new classes.Aeropuerto.ConductorNomina();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Conductor = dr["Nombre"].ToString();
                lCond.Add(c);
            }

            return lCond;
        }

        public static List<classes.Aeropuerto.ConductorNomina> GetConductoresAeropuerto()
        {
            List<classes.Aeropuerto.ConductorNomina> lCond = new List<classes.Aeropuerto.ConductorNomina>();
            string sqlstr = "dbo.usp_Nomina_IncidenciasConductor_ObtieneConductores";
            Hashtable m_params = new Hashtable();
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.ConductorNomina c = new classes.Aeropuerto.ConductorNomina();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Conductor = dr["Nombre"].ToString();
                lCond.Add(c);
            }

            return lCond;
        }

        public static List<classes.Aeropuerto.BoletoConductor> GetDetalleBoletosPorConductorFechaPago(int Conductor_ID, DateTime FechaPago)
        {
            List<classes.Aeropuerto.BoletoConductor> l = new List<classes.Aeropuerto.BoletoConductor>();

            string sqlstr = "dbo.usp_Nomina_Obtiene_DetalleBoletos_Conductor_FechaPago";
            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaPago", FechaPago);
            m_params.Add("@Conductor_ID", Conductor_ID);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.BoletoConductor c = new classes.Aeropuerto.BoletoConductor();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Unidad_ID = Convert.ToInt32(dr["Unidad_ID"]);
                c.Numero_Economico = dr["Numero_Economico"].ToString();
                c.Servicio = dr["Servicio"].ToString();
                c.Fecha_Servicio = Convert.ToDateTime(dr["Fecha_Servicio"]);
                c.Fecha_Pago = Convert.ToDateTime(dr["Fecha_Pago"]);
                c.Fecha_Captura = Convert.ToDateTime(dr["Fecha_Captura"]);
                c.Monto = Convert.ToDouble(dr["Monto"]);
                l.Add(c);
            }
            return l;
        }

        public static List<classes.Aeropuerto.BoletoConductor> GetDetalleBoletosTEPorConductorFechaPago(int Conductor_ID, DateTime FechaPago)
        {
            List<classes.Aeropuerto.BoletoConductor> l = new List<classes.Aeropuerto.BoletoConductor>();

            string sqlstr = "dbo.usp_Nomina_Obtiene_DetalleBoletos_TE_Conductor_FechaPago";
            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaPago", FechaPago);
            m_params.Add("@Conductor_ID", Conductor_ID);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.BoletoConductor c = new classes.Aeropuerto.BoletoConductor();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Unidad_ID = Convert.ToInt32(dr["Unidad_ID"]);
                c.Numero_Economico = dr["Numero_Economico"].ToString();
                c.Servicio = dr["Servicio"].ToString();
                c.Fecha_Servicio = Convert.ToDateTime(dr["Fecha_Servicio"]);
                c.Fecha_Pago = Convert.ToDateTime(dr["Fecha_Pago"]);
                c.Fecha_Captura = Convert.ToDateTime(dr["Fecha_Captura"]);
                c.Monto = Convert.ToDouble(dr["Monto"]);
                l.Add(c);
            }
            return l;
        }

        public static bool AgregaServicioAConductorFechaPago(string Servicio_ID, int Conductor_ID, DateTime Periodo, DateTime FechaPago, string usuario)
        {
            string sqlstr = "[dbo].[usp_Nomina_BoletosConductor_Inserta]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", Servicio_ID);
            m_params.Add("@FechaPagoCAT", FechaPago);
            m_params.Add("@Periodo", Periodo);
            m_params.Add("@Conductor_ID", Conductor_ID);
            m_params.Add("@Usuario_ID", usuario);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool AgregaServicioTEAConductorFechaPago(string Servicio_ID, int Conductor_ID, DateTime Periodo, DateTime FechaPago, string usuario)
        {
            string sqlstr = "[dbo].[usp_Nomina_IncidenciasConductor_InsertaIncidencia]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@IncidenciaConductor_ID", null);
            m_params.Add("@Conductor_ID", Conductor_ID);
            m_params.Add("@TipoIncidencia_ID", 1);
            m_params.Add("@Observaciones", Servicio_ID);
            m_params.Add("@Usuario_ID", usuario);
            m_params.Add("@FechaCaptura", DateTime.Now);
            m_params.Add("@EstatusIncidenciaConductor_ID", 3);
            m_params.Add("@PeriodoAplicacionIncidencia", Periodo);
            m_params.Add("@Monto", Entities.VariablesNegocio.Read("MontoBoletoTiempoExtra").Valor);
            m_params.Add("@AnulaMontoVariable", 0);
            m_params.Add("@FechaPagoCAT", FechaPago);

            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool QuitaConductorPeriodoNomina(classes.Aeropuerto.ConductorTipoNomina conductor)
        {
            string sqlstr = "usp_Nomina_Delete_Conductor_Periodo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", conductor.Periodo);
            m_params.Add("@Conductor_ID", conductor.Conductor_ID);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool AgregaIncidenciaConductor(classes.Aeropuerto.IncidenciaConductor incidencia)
        {
            string sqlstr = "[dbo].[usp_Nomina_IncidenciasConductor_InsertaIncidencia]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@IncidenciaConductor_ID", incidencia.IncidenciaConductor_ID);
            m_params.Add("@Conductor_ID", incidencia.Conductor.Conductor_ID);
            m_params.Add("@TipoIncidencia_ID", incidencia.TipoIncidencia.TipoIncidenciaConductor_ID);
            m_params.Add("@Observaciones", incidencia.Observaciones);
            m_params.Add("@Usuario_ID", incidencia.Usuario_ID);
            m_params.Add("@FechaCaptura", incidencia.FechaCaptura);
            m_params.Add("@EstatusIncidenciaConductor_ID", incidencia.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID);
            m_params.Add("@PeriodoAplicacionIncidencia", incidencia.PeriodoAplicacionIncidencia);
            m_params.Add("@Monto", incidencia.Monto);
            m_params.Add("@AnulaMontoVariable", incidencia.TipoIncidencia.AnulaMontoVariable);
            m_params.Add("@FechaPagoCAT", incidencia.PeriodoAplicacionIncidencia);

            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool EsPeriodoAbierto(DateTime periodo, string usuario_id)
        {
            string sqlstr = "[dbo].[usp_Nomina_ValidaEstatusPeriodo]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            m_params.Add("@Usuario_ID", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool AutorizaNominaPeriodo(DateTime periodo, string usuario_id)
        {
            string sqlstr = "[dbo].[usp_Nomina_AutorizaNomina]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            m_params.Add("@Usuario_ID", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool ReiniciaFlujoAutorizacionNomina(DateTime periodo, string usuario_id)
        {
            string sqlstr = "[dbo].[usp_Nomina_ReiniciaAutorizacionNomina]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            m_params.Add("@Usuario_ID", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static List<classes.Aeropuerto.ConductorNominaCAT> GetReporteNomina(DateTime periodo)
        {
            List<classes.Aeropuerto.ConductorNominaCAT> lRegresos = new List<classes.Aeropuerto.ConductorNominaCAT>();

            string sqlstr = "dbo.usp_Nomina_Obtiene_NominaCAT_Semanal";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.ConductorNominaCAT c = new classes.Aeropuerto.ConductorNominaCAT();
                c.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Conductor = dr["Conductor"].ToString();
                c.Periodo = Convert.ToDateTime(dr["Periodo"]);
                c.DiasLaborados = Convert.ToInt32(dr["DiasLaborados"]);
                c.Tiponomina.TipoNomina_ID = Convert.ToInt32(dr["TipoNominaVigente_ID"]);
                c.Tiponomina.Nombre = dr["TipoNomina"].ToString();
                c.ServiciosRealizados = Convert.ToInt32(dr["ServiciosRealizados"]);
                c.IngresoXBoletos = Convert.ToDouble(dr["IngresoXBoletos"]);
                c.Comision_Porc = Convert.ToDouble(dr["Comision"]);
                c.Comision_Monto = Convert.ToDouble(dr["ComisionM"]);
                c.CargaSocial = Convert.ToDouble(dr["CargaSocial"]);
                c.SueldoFijo = Convert.ToDouble(dr["SueldoFijo"]);
                c.TiempoExtra = Convert.ToDouble(dr["Incidencias_TiempoExtra"]);
                c.PagoExtra = Convert.ToDouble(dr["Incidencias_PagoExtra"]);
                c.Descuento = Convert.ToDouble(dr["Incidencias_Descuento"]);

                c.ServTE = Convert.ToDouble(dr["ServiciosRealizadosTE"]);
                c.IngServTE = Convert.ToDouble(dr["IngresoXBoletosTE"]);

                c.Bono = Convert.ToDouble(dr["Bono"]);
                c.SueldoVariable = Convert.ToDouble(dr["SueldoVariable"]);
                c.Sueldo = Convert.ToDouble(dr["Sueldo"]);

                lRegresos.Add(c);
            }
            return lRegresos;
        }

        public static List<classes.Aeropuerto.IncidenciaConductor> GetDetalleIncidenciasNomina(DateTime periodo)
        {
            List<classes.Aeropuerto.IncidenciaConductor> lRegresos = new List<classes.Aeropuerto.IncidenciaConductor>();

            string sqlstr = "dbo.usp_Nomina_IncidenciasConductor_Consulta_RptNomina";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Desde", periodo.AddHours(11));
            m_params.Add("@Hasta", periodo.AddDays(7).AddHours(11));
            DataSet ds = DB.QueryDS(sqlstr, m_params);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classes.Aeropuerto.IncidenciaConductor c = new classes.Aeropuerto.IncidenciaConductor();
                c.IncidenciaConductor_ID = Convert.ToInt32(dr["IncidenciaConductor_ID"]);
                c.Conductor = new classes.Aeropuerto.ConductorNomina();
                c.Conductor.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
                c.Conductor.Conductor = dr["Conductor"].ToString();
                c.TipoIncidencia = new classes.Aeropuerto.TipoIncidenciaConductor();
                c.TipoIncidencia.TipoIncidenciaConductor_ID = Convert.ToInt32(dr["TipoIncidencia_ID"]);
                c.TipoIncidencia.Nombre = dr["Incidencia"].ToString();
                c.TipoIncidencia.AnulaMontoVariable = Convert.ToBoolean(dr["AnulaMontoVariable"].ToString());
                c.Monto = Convert.ToDouble(dr["Monto"].ToString());
                c.Observaciones = dr["Observaciones"].ToString();
                c.Usuario_ID = dr["Usuario_ID"].ToString();
                c.FechaCaptura = Convert.ToDateTime(dr["FechaCaptura"].ToString());
                c.EstatusIncidencia_Conductor = new classes.Aeropuerto.EstatusIncidenciaConductor();
                c.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID = Convert.ToInt32(dr["EstatusIncidenciaConductor_ID"]);
                c.EstatusIncidencia_Conductor.Nombre = dr["Estatus"].ToString();
                c.PeriodoAplicacionIncidencia = Convert.ToDateTime(dr["PeriodoAplicacionIncidencia"]);
                lRegresos.Add(c);
            }
            return lRegresos;
        }

        public static classes.Aeropuerto.EstatusNomina GetEstatusNominaPorPeriodo(DateTime periodo)
        {
            string sqlstr = "dbo.usp_Nomina_Obtiene_EstatusNomina";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Periodo", periodo);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            classes.Aeropuerto.EstatusNomina c = new classes.Aeropuerto.EstatusNomina();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                c = new classes.Aeropuerto.EstatusNomina();
                c.EstatusNomina_ID = Convert.ToInt32(dr["EstatusNomina_ID"]);
                if (!DB.IsNullOrEmpty(dr["Nombre"]))
                    c.Nombre = dr["Nombre"].ToString();
            }
            return c;
        }

        public static int GetPermisosUsuario(string usuario_id)
        {
            string sqlstr = "dbo.usp_Nomina_Obtiene_PermisosUsuario";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Usuario_ID", usuario_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            int permisos = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                permisos = Convert.ToInt32(dr["EstatusNomina_ID"].ToString());
            }
            return permisos;
        }

        public static int GetMaxEstatusNomina_ID()
        {
            string sqlstr = "dbo.usp_Nomina_Obtiene_MaxEstatusNomina";
            Hashtable m_params = new Hashtable();
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            int max = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                max = Convert.ToInt32(dr["MAX_ESTATUS"].ToString());
            }
            return max;
        }

        public static bool QuitaServicioAConductor(string servicio, int conductor_id, string usuario_id)
        {
            string sqlstr = "[dbo].[usp_Nomina_BoletosConductor_QuitaServicio]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio);
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Usuario_ID", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static bool QuitaServicioTEAConductor(string servicio, int conductor_id, string usuario_id)
        {
            string sqlstr = "[dbo].[usp_Nomina_BoletosConductor_QuitaServicioTE]";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Servicio_ID", servicio);
            m_params.Add("@Conductor_ID", conductor_id);
            m_params.Add("@Usuario_ID", usuario_id);
            return DB.ExecuteCommandSP(sqlstr, m_params);
        }
    }

} // End Namespace