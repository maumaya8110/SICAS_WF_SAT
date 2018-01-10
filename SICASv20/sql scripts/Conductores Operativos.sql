/*
	Conductores Operativos
	
	Creado el 25 de Octubre de 2012
	por Luis Espino
	
	Resumen:	Extendemos los datos del catálogo de conductores
	
	
*/

--	Agregamos la columna "PrimerCursoLicencia"
ALTER TABLE	Conductores
ADD		PrimerCursoLicencia bit
GO

--	Agregamos la columna "SegundoCursoLicencia"
ALTER TABLE Conductores
ADD		SegundoCursoLicencia bit
GO

--	Agregamos la columna "ExamenMedico"
ALTER TABLE	Conductores
ADD		ExamenMedico bit
GO

--	Agregamos la columna "Nomina"
ALTER TABLE	Conductores
ADD		Nomina bit
GO

/*
	La consulta para la vista
*/

--	Declaramos las variables
DECLARE	@Empresa_ID int = 3,
		@Estacion_ID int = 5,
		@Nombre varchar,
		@NumeroEconomico int

SELECT	C.Conductor_ID,
		UPPER(C.Apellidos + ' ' + C.Nombre) Nombre,
		C.PrimerCursoLicencia,
		C.SegundoCursoLicencia,
		C.ExamenMedico,
		C.FolioLicencia LicenciaLiberada,
		CONVERT(DATE,C.VenceLicencia) VenceLicencia,
		U.NumeroEconomico Cubre,
		CONT.NumeroEconomico Titular,
		C.Nomina
FROM	Conductores C
INNER JOIN	Unidades U
ON		C.Conductor_ID = U.ConductorOperativo_ID
LEFT JOIN	Contratos CONT
ON		C.Conductor_ID = CONT.Conductor_ID
		AND	CONT.EstatusContrato_ID = 1
WHERE	( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		( @Nombre IS NULL OR (C.Apellidos + ' ' + C.Nombre) LIKE Nombre + '%' )
AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico OR CONT.NumeroEconomico = @NumeroEconomico )

/*
	Vista de Licencias por Vencer
*/

--	Declaramos las variables
DECLARE	@Estacion_ID int = 5
		
SELECT	Conductor_ID,
		UPPER(Apellidos + ' ' + Nombre) Nombre,
		FolioLicencia LicenciaLiberada,
		CONVERT(DATE, VenceLicencia) VenceLicencia
FROM	Conductores
WHERE	VenceLicencia IS NOT NULL
AND		VenceLicencia <= DATEADD(MONTH,6,GETDATE())
AND		( @Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID )
ORDER BY	VenceLicencia