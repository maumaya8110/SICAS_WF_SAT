/*
	Vista_ReporteFlotilla
	Creado el 31 de Octubre por Luis Espino
*/

DECLARE	@Empresa_ID int,
		@Estacion_ID int,
		@Usuario_ID varchar(30) = 'luis.escareño'
		
SELECT	U.Empresa, U.Estacion, U.NumeroEconomico, ISNULL(C.Conductor,'-NO ASIGNADA-') Conductor,
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
AND		U.LocacionUnidad_ID <> 22
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
WHERE	C.EstatusContrato_ID = 1
AND		( C.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( C.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR C.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR C.Estacion_ID = @Estacion_ID )
) C
ON	U.Unidad_ID = C.Unidad_ID
ORDER BY	Empresa, Estacion, NumeroEconomico


--select * from usuarios_empresas
--where usuario_id = 'luis.escareño'