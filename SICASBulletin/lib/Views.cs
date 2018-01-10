using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace SICASBulletin.Views
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
            System.DateTime fecha)
        {
            string sqlstr = @"SELECT	CONVERT(varchar,RKM.Fecha,103) Fecha,
		E.Nombre Empresa,
		RKM.NumeroEconomico,
		RKM.KMInicial,
		RKM.KMFinal - RKM.KMInicial KMRecorrido,
		RKM.Mantenimientos,
		RKM.Recaudacion,
		RKM.UltimoKM,
		ISNULL(CONVERT(varchar,RKM.UltimaCaptura,103),'') UltimaCaptura
FROM	RegistroKilometrajesMantenimiento RKM
INNER JOIN	Unidades U
ON		RKM.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
WHERE	RKM.Fecha = dbo.udf_DateValue( @Fecha )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            List<Vista_ReporteKilometrajesMantenimiento_Diario> list = new List<Vista_ReporteKilometrajesMantenimiento_Diario>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
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
            System.DateTime fecha)
        {
            string sqlstr = @"SELECT	CONVERT(varchar,RKM.Fecha,103) Fecha,
		E.Nombre Empresa,
		RKM.NumeroEconomico,
		RKM.KMInicial,
		RKM.KMFinal - RKM.KMInicial KMRecorrido,
		RKM.Mantenimientos,
		RKM.Recaudacion,
		RKM.UltimoKM,
		ISNULL(CONVERT(varchar,RKM.UltimaCaptura,103),'') UltimaCaptura
FROM	RegistroKilometrajesMantenimiento RKM
INNER JOIN	Unidades U
ON		RKM.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
WHERE	RKM.Fecha = dbo.udf_DateValue( @Fecha )";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", fecha);

            return DB.QueryCommand(sqlstr, m_params);
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
            string sqlstr = @"DECLARE @Dias int
SET	@Dias =  DATEDIFF(DAY,@FechaInicial,@FechaFinal)
SET @Dias = @Dias + 1

DECLARE	@Recaudacion TABLE
(
	Unidad_ID int,
	Recaudacion money
)

INSERT	@Recaudacion
SELECT	Unidad_ID,
		SUM(Abono) Recaudacion
FROM	CuentaConductores 
WHERE	Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		Cuenta_ID = 1
GROUP BY	Unidad_ID

DECLARE	@Mantenimientos TABLE
(
	Unidad_ID int,
	Mantenimiento money
)

INSERT	@Mantenimientos
SELECT	Unidad_ID,
		SUM(SubTotal) Mantenimiento
FROM	OrdenesTrabajos OT
WHERE	FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		EstatusOrdenTrabajo_ID NOT IN (5)
GROUP BY	Unidad_ID

DECLARE @KMRecorridos TABLE
(
	Unidad_ID int,
	KMInicial int,
	KMRecorrido int
)

INSERT	@KMRecorridos
SELECT	U.Unidad_ID,
		MIN(UK.Kilometraje) KMInicial,		
		(MAX(UK.Kilometraje) - MIN(UK.Kilometraje)) KMRecorrido
FROM	Unidades U
INNER JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
WHERE	UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	U.Unidad_ID,
			U.NumeroEconomico
HAVING	(MAX(UK.Kilometraje) - MIN(UK.Kilometraje)) > 0

DECLARE	@KMAcumulados TABLE
(
	Unidad_ID int,
	KMAcumulado int,
	Fecha datetime
)

INSERT	@KMAcumulados
SELECT	U.Unidad_ID,
		MAX(UK.Kilometraje) KMAcumulado,
		MAX(UK.Fecha) Fecha
FROM	Unidades U
INNER JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
WHERE	UK.Fecha <= @FechaFinal
AND		U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Unidad_ID,
			U.NumeroEconomico

SELECT	E.Nombre Empresa,
		U.NumeroEconomico,
		ISNULL(KMR.KMInicial,0) KMInicial,
		ISNULL(KMR.KMRecorrido,0) KMRecorrido,
		ISNULL(M.Mantenimiento,0) Mantenimiento, 
		ISNULL(R.Recaudacion,0) Recaudacion,		
		ISNULL((ISNULL(R.Recaudacion,0) - ISNULL(M.Mantenimiento,0)),0) Diferencia,
		ISNULL((M.Mantenimiento / KMR.KMRecorrido),0) MttoPorKM,
		ISNULL((KMR.KMrecorrido / @Dias),0) KMPromedio,
		(ISNULL(M.Mantenimiento,0) / @Dias) MttoPorDia,
		ISNULL((R.Recaudacion / @Dias),0) RecaudacionPorDia,
		@Dias NumDias,
		ISNULL(KMA.KMAcumulado, 0) KMAcumulado,
		KMA.Fecha UltimaCaptura
FROM	Unidades U
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
LEFT JOIN	@KMRecorridos KMR
ON		U.Unidad_ID = KMR.Unidad_ID
LEFT JOIN	@KMAcumulados KMA
ON		U.Unidad_ID = KMA.Unidad_ID
LEFT JOIN	@Mantenimientos M
ON		KMR.Unidad_ID = M.Unidad_ID
LEFT JOIN	@Recaudacion R
ON		KMR.Unidad_ID = R.Unidad_ID
WHERE	U.EstatusUnidad_ID IN (1,2)
ORDER BY	E.Nombre, U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            List<Vista_ReporteKilometrajesMantenimientos> list = new List<Vista_ReporteKilometrajesMantenimientos>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
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
            string sqlstr = @"DECLARE @Dias int
SET	@Dias =  DATEDIFF(DAY,@FechaInicial,@FechaFinal)
SET @Dias = @Dias + 1

DECLARE	@Recaudacion TABLE
(
	Unidad_ID int,
	Recaudacion money
)

INSERT	@Recaudacion
SELECT	Unidad_ID,
		SUM(Abono) Recaudacion
FROM	CuentaConductores 
WHERE	Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		Cuenta_ID = 1
GROUP BY	Unidad_ID

DECLARE	@Mantenimientos TABLE
(
	Unidad_ID int,
	Mantenimiento money
)

INSERT	@Mantenimientos
SELECT	Unidad_ID,
		SUM(SubTotal) Mantenimiento
FROM	OrdenesTrabajos OT
WHERE	FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
AND		EstatusOrdenTrabajo_ID NOT IN (5)
GROUP BY	Unidad_ID

DECLARE @KMRecorridos TABLE
(
	Unidad_ID int,
	KMInicial int,
	KMRecorrido int
)

INSERT	@KMRecorridos
SELECT	U.Unidad_ID,
		MIN(UK.Kilometraje) KMInicial,		
		(MAX(UK.Kilometraje) - MIN(UK.Kilometraje)) KMRecorrido
FROM	Unidades U
INNER JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
WHERE	UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	U.Unidad_ID,
			U.NumeroEconomico
HAVING	(MAX(UK.Kilometraje) - MIN(UK.Kilometraje)) > 0

DECLARE	@KMAcumulados TABLE
(
	Unidad_ID int,
	KMAcumulado int,
	Fecha datetime
)

INSERT	@KMAcumulados
SELECT	U.Unidad_ID,
		MAX(UK.Kilometraje) KMAcumulado,
		MAX(UK.Fecha) Fecha
FROM	Unidades U
INNER JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
WHERE	UK.Fecha <= @FechaFinal
AND		U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Unidad_ID,
			U.NumeroEconomico

SELECT	E.Nombre Empresa,
		U.NumeroEconomico,
		ISNULL(KMR.KMInicial,0) KMInicial,
		ISNULL(KMR.KMRecorrido,0) KMRecorrido,
		ISNULL(M.Mantenimiento,0) Mantenimiento, 
		ISNULL(R.Recaudacion,0) Recaudacion,		
		ISNULL((ISNULL(R.Recaudacion,0) - ISNULL(M.Mantenimiento,0)),0) Diferencia,
		ISNULL((M.Mantenimiento / KMR.KMRecorrido),0) MttoPorKM,
		ISNULL((KMR.KMrecorrido / @Dias),0) KMPromedio,
		(ISNULL(M.Mantenimiento,0) / @Dias) MttoPorDia,
		ISNULL((R.Recaudacion / @Dias),0) RecaudacionPorDia,
		@Dias NumDias,
		ISNULL(KMA.KMAcumulado, 0) KMAcumulado,
		KMA.Fecha UltimaCaptura
FROM	Unidades U
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
LEFT JOIN	@KMRecorridos KMR
ON		U.Unidad_ID = KMR.Unidad_ID
LEFT JOIN	@KMAcumulados KMA
ON		U.Unidad_ID = KMA.Unidad_ID
LEFT JOIN	@Mantenimientos M
ON		KMR.Unidad_ID = M.Unidad_ID
LEFT JOIN	@Recaudacion R
ON		KMR.Unidad_ID = R.Unidad_ID
WHERE	U.EstatusUnidad_ID IN (1,2)
ORDER BY	E.Nombre, U.NumeroEconomico";

            Hashtable m_params = new Hashtable();
            m_params.Add("@FechaInicial", fechainicial);
            m_params.Add("@FechaFinal", fechafinal);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_ReporteKilometrajesMantenimientos

    public class Vista_Reporte_Concentrado_Flotilla_Estatus
    {

        #region Constructors
        public Vista_Reporte_Concentrado_Flotilla_Estatus()
        {
        }

        public Vista_Reporte_Concentrado_Flotilla_Estatus(
            System.String estatus,
            System.Int32? unidades,
            System.Decimal? porcentaje
            )
        {
            this.Estatus = estatus;
            this.Unidades = unidades;
            this.Porcentaje = porcentaje;
        }

        #endregion

        #region Properties
        private System.String _Estatus;
        public System.String Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private System.Int32? _Unidades;
        public System.Int32? Unidades
        {
            get { return _Unidades; }
            set { _Unidades = value; }
        }

        private System.Decimal? _Porcentaje;
        public System.Decimal? Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Reporte_Concentrado_Flotilla_Estatus> Get()
        {
            string sqlstr = @"DECLARE	@TotalFlotilla int

SELECT	@TotalFlotilla = COUNT(*)
FROM	Unidades
WHERE	EstatusUnidad_ID <> 5
AND		Empresa_ID IN (2,3,5,601)

SELECT	EU.Nombre Estatus,
		COUNT(*) Unidades,
		CONVERT(decimal(5,2), COUNT(*) * 100.00 / @TotalFlotilla) Porcentaje		
FROM	Unidades U
INNER JOIN	EstatusUnidades EU
ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID
WHERE	EU.EstatusUnidad_ID <> 5
AND		Empresa_ID IN (2,3,5,601)
GROUP BY	EU.Nombre
ORDER BY	EU.Nombre
";

            List<Vista_Reporte_Concentrado_Flotilla_Estatus> list = new List<Vista_Reporte_Concentrado_Flotilla_Estatus>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Reporte_Concentrado_Flotilla_Estatus(
                        Convert.ToString(dr["Estatus"]),
                        DB.GetNullableInt32(dr["Unidades"]),
                        DB.GetNullableDecimal(dr["Porcentaje"])
                        )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"DECLARE	@TotalFlotilla int

SELECT	@TotalFlotilla = COUNT(*)
FROM	Unidades
WHERE	EstatusUnidad_ID <> 5
AND		Empresa_ID IN (2,3,5,601)

SELECT	EU.Nombre Estatus,
		COUNT(*) Unidades,
		CONVERT(decimal(5,2), COUNT(*) * 100.00 / @TotalFlotilla) Porcentaje		
FROM	Unidades U
INNER JOIN	EstatusUnidades EU
ON		U.EstatusUnidad_ID = EU.EstatusUnidad_ID
WHERE	EU.EstatusUnidad_ID <> 5
AND		Empresa_ID IN (2,3,5,601)
GROUP BY	EU.Nombre
ORDER BY	EU.Nombre
";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Reporte_Concentrado_Flotilla_Estatus

    public class Vista_Reporte_Concentrado_Flotilla_Locaciones
    {

        #region Constructors
        public Vista_Reporte_Concentrado_Flotilla_Locaciones()
        {
        }

        public Vista_Reporte_Concentrado_Flotilla_Locaciones(
            System.String indicador,
            System.Int32? unidades,
            System.Decimal? porcentaje
            )
        {
            this.Locacion = indicador;
            this.Unidades = unidades;
            this.Porcentaje = porcentaje;
        }

        #endregion

        #region Properties
        private System.String _Locacion;
        public System.String Locacion
        {
            get { return _Locacion; }
            set { _Locacion = value; }
        }

        private System.Int32? _Unidades;
        public System.Int32? Unidades
        {
            get { return _Unidades; }
            set { _Unidades = value; }
        }

        private System.Decimal? _Porcentaje;
        public System.Decimal? Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_Reporte_Concentrado_Flotilla_Locaciones> Get()
        {
            string sqlstr = @"DECLARE	@TotalInactivas int

SELECT	@TotalInactivas = COUNT(*)
FROM	Unidades
WHERE	EstatusUnidad_ID = 6
AND		Empresa_ID IN (2,3,5,601)

SELECT	LU.Nombre Locacion,
		COUNT(*) Unidades,
		CONVERT(decimal(5,2), COUNT(*) * 100.00 / @TotalInactivas) Porcentaje
FROM	Unidades U
INNER JOIN	LocacionesUnidades LU
ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID
WHERE	U.EstatusUnidad_ID = 6
AND		Empresa_ID IN (2,3,5,601)
GROUP BY	LU.Nombre
ORDER BY	LU.Nombre
";

            List<Vista_Reporte_Concentrado_Flotilla_Locaciones> list = new List<Vista_Reporte_Concentrado_Flotilla_Locaciones>();
            DataTable dt = DB.Query(sqlstr);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_Reporte_Concentrado_Flotilla_Locaciones(
                        Convert.ToString(dr["Locacion"]),
                        DB.GetNullableInt32(dr["Unidades"]),
                        DB.GetNullableDecimal(dr["Porcentaje"])
                        )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable()
        {
            string sqlstr = @"DECLARE	@TotalInactivas int

SELECT	@TotalInactivas = COUNT(*)
FROM	Unidades
WHERE	EstatusUnidad_ID = 6
AND		Empresa_ID IN (2,3,5,601)

SELECT	LU.Nombre Locacion,
		COUNT(*) Unidades,
		CONVERT(decimal(5,2), COUNT(*) * 100.00 / @TotalInactivas) Porcentaje
FROM	Unidades U
INNER JOIN	LocacionesUnidades LU
ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID
WHERE	U.EstatusUnidad_ID = 6
AND		Empresa_ID IN (2,3,5,601)
GROUP BY	LU.Nombre
ORDER BY	LU.Nombre
";

            return DB.Query(sqlstr);
        } // End GetDataTable


        #endregion
    } // End Class Vista_Reporte_Concentrado_Flotilla_Locaciones

    public class Vista_CorreosParaBoletin
    {

        #region Constructors
        public Vista_CorreosParaBoletin()
        {
        }

        public Vista_CorreosParaBoletin(
            System.String email
            )
        {
            this.Email = email;
        }

        #endregion

        #region Properties
        private System.String _Email;
        public System.String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        #endregion

        #region Methods
        public static List<Vista_CorreosParaBoletin> Get(
            System.Int32 boletin_id)
        {
            string sqlstr = @"SELECT	U.Email
FROM	Usuarios U
INNER JOIN	Boletines_Usuarios BU
ON		BU.Usuario_ID = U.Usuario_ID
WHERE	BU.Boletin_ID = @Boletin_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Boletin_ID", boletin_id);

            List<Vista_CorreosParaBoletin> list = new List<Vista_CorreosParaBoletin>();
            DataTable dt = DB.QueryCommand(sqlstr, m_params);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Vista_CorreosParaBoletin(
                        Convert.ToString(dr["Email"])
                        )
                    );
            }
            return list;
        } // End GetData

        public static DataTable GetDataTable(
            System.Int32 boletin_id)
        {
            string sqlstr = @"SELECT	U.Email
FROM	Usuarios U
INNER JOIN	Boletines_Usuarios BU
ON		BU.Usuario_ID = U.Usuario_ID
WHERE	BU.Boletin_ID = @Boletin_ID";

            Hashtable m_params = new Hashtable();
            m_params.Add("@Boletin_ID", boletin_id);

            return DB.QueryCommand(sqlstr, m_params);
        } // End GetDataTable


        #endregion
    } // End Class Vista_CorreosParaBoletin


}
