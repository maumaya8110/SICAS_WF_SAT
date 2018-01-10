CREATE PROCEDURE usp_RegistroDiarioKilometrajesMantenimientos

AS

DECLARE @FechaInicial datetime,
		@FechaFinal datetime
	
SET	@FechaInicial = DATEADD(DAY, -1, GETDATE())
SET	@FechaInicial = dbo.udf_DateValue(@FechaInicial)
SET	@FechaFinal = DATEADD(HOUR, 23, @FechaInicial)
SET	@FechaFinal = DATEADD(MINUTE, 59, @FechaFinal)
SET	@FechaFinal = DATEADD(SECOND, 59, @FechaFinal)

DECLARE @KMAcumulados TABLE
(
	Unidad_ID int,
	Fecha datetime,
	Kilometraje int
)

INSERT	@KMAcumulados
SELECT	U.Unidad_ID,
		MAX(UK.Fecha) Fecha,
		MAX(UK.Kilometraje) Kilometraje
FROM	Unidades U
LEFT JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
		AND	UK.Fecha <= @FechaFinal		
WHERE	U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Unidad_ID

DECLARE	@Recaudaciones TABLE
(
	Unidad_ID int,
	Recaudacion money
)

INSERT	@Recaudaciones
SELECT	U.Unidad_ID,
		ISNULL(SUM(CC.Abono),0) Recaudacion
FROM	Unidades U
LEFT JOIN	CuentaConductores CC
ON		U.Unidad_ID = CC.Unidad_ID
		AND	CC.Fecha BETWEEN @FechaInicial AND @FechaFinal
		AND	CC.Cuenta_ID = 1
WHERE	U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Unidad_ID

DECLARE @Mantenimientos TABLE
(
	Unidad_ID int,
	Mantenimientos money
)

INSERT	@Mantenimientos
SELECT	U.Unidad_ID,
		ISNULL(SUM(OT.Subtotal),0) Mantenimientos
FROM	Unidades U
LEFT JOIN	OrdenesTrabajos OT
ON		U.Unidad_ID = OT.Unidad_ID
		AND	OT.EstatusOrdenTrabajo_ID IN (3,4)
		AND	OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal
WHERE	U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Empresa_ID,
			U.Estacion_ID,
			U.Unidad_ID,
			U.NumeroEconomico

DECLARE	@KMRecorridos TABLE
(
	Unidad_ID int,
	KMInicial int,
	KMFinal int
)

INSERT	@KMRecorridos
SELECT	U.Unidad_ID,
		ISNULL(MIN(UK.Kilometraje),0) KMInicial,
		ISNULL(MAX(UK.Kilometraje),0) KMFinal		
FROM	Unidades U
LEFT JOIN	Unidades_Kilometrajes UK
ON		U.Unidad_ID = UK.Unidad_ID
		AND	UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
WHERE	U.EstatusUnidad_ID IN (1,2)
GROUP BY	U.Unidad_ID

INSERT	RegistroKilometrajesMantenimiento
SELECT	@FechaInicial Fecha,
		U.Unidad_ID,
		U.NumeroEconomico,
		KMR.KMInicial,
		KMR.KMFinal,
		M.Mantenimientos,
		R.Recaudacion,
		ISNULL(KMA.Kilometraje,0) UltimoKM,
		--ISNULL(CONVERT(varchar,KMA.Fecha,103), '') UltimaCaptura
		KMA.Fecha UltimaCaptura
FROM	Unidades U
LEFT JOIN	@KMRecorridos KMR
ON		U.Unidad_ID = KMR.Unidad_ID
LEFT JOIN	@KMAcumulados KMA
ON		U.Unidad_ID = KMA.Unidad_ID
LEFT JOIN	@Recaudaciones R
ON		U.Unidad_ID = R.Unidad_ID
LEFT JOIN	@Mantenimientos M
ON		U.Unidad_ID = M.Unidad_ID
WHERE	U.EstatusUnidad_ID IN (1,2)

GO

-- Tabla para el registro diario de kilometrajes,
-- mantenimientos & recaudaciones
CREATE TABLE	RegistroKilometrajesMantenimiento
(
	Fecha datetime not null,	
	Unidad_ID int not null,
	NumeroEconomico int not null,
	KMInicial int not null,
	KMFinal int not null,
	Mantenimientos money not null,
	Recaudacion money not null,
	UltimoKM int not null,
	UltimaCaptura datetime null,
	CONSTRAINT PK_RegistroKilometrajesMantenimiento
	PRIMARY KEY ( Fecha, Unidad_ID )
)
GO

CREATE INDEX IDX_RKM_NumeroEconomico 
ON dbo.RegistroKilometrajesMantenimiento (NumeroEconomico)
GO

SELECT * FROM RegistroKilometrajesMantenimiento