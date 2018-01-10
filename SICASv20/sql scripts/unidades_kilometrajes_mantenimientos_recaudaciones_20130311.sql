/*
DECLARE	@FechaInicial datetime = '2013-03-01',
		@FechaFinal datetime = '2013-03-19',
		@Dias int
		
EXEC	usp_ReporteKilometrajesMantenimientos @FechaInicial, @FechaFinal

*/
CREATE PROCEDURE usp_RegistroMensualKilometrajesMantenimientos
AS

DECLARE	@FechaInicial datetime,
		@FechaFinal datetime
		
SET	@FechaInicial = dbo.udf_DateValue( GETDATE() )

IF ( DATEPART(DAY, @FechaInicial) <> 1 )
BEGIN
	PRINT 'NO ES PRIMERO DE MES'
	RETURN;
END

--	Ayer, hace un mes
SET	@FechaInicial =  DATEADD( MONTH, -1, @FechaInicial )

--	Hoy
SET	@FechaFinal = dbo.udf_DateValue( GETDATE() )

INSERT INTO RegistroMensualKilometrajesMantenimientos
EXEC usp_ReporteKilometrajesMantenimientos @FechaInicial, @FechaFinal

GO


CREATE PROCEDURE usp_ReporteKilometrajesMantenimientos
(
	@FechaInicial datetime,
	@FechaFinal datetime
)
AS

DECLARE @Dias int
SET	@Dias =  DATEDIFF(DAY,@FechaInicial,@FechaFinal)

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
ORDER BY	E.Nombre, U.NumeroEconomico

GO

CREATE TABLE RegistroMensualKilometrajesMantenimientos
(
	Anio int not null,
	Mes int not null,
	Empresa varchar(50) not null,
	NumeroEconomico int not null,
	KMInicial int not null,
	KMRecorrido int not null,
	Mantenimiento money not null,
	Recaudacion money not null,
	Diferencia money not null,
	MttoPorKM money not null,
	KMPromedio int not null,
	MttoPorDia money not null,
	RecaudacionPorDia money not null,
	NumDias int not null,
	KMAcumulado int null,
	UltimaCaptura datetime null
)