/*
	Reporte de Utilizacion de Unidades
	
	A partir de una unidad, nos brinda los conductores que la condujeron,
	y sus fechas.
	
	Parametro: @Unidad
	
	Resultado esperado
	
	NumeroEconomico, Conductor, FechaInicial, FechaFinal
*/

DECLARE	@NumeroEconomico int = 5021,
		@Empresa_ID int,
		@Estacion_ID int,
		@Usuario_ID varchar(30) = 'luis.escareño'

SELECT	E.Nombre Empresa,
		EST.Nombre Estacion,
		U.NumeroEconomico,
		UPPER(C.Apellidos + ' ' + C.Nombre) Conductor,
		MIN(UK.Fecha) FechaInicial,
		MAX(UK.Fecha) FechaFinal
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		UK.Unidad_ID = U.Unidad_ID
INNER JOIN	Conductores C
ON		UK.Conductor_ID = C.Conductor_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
On		U.Estacion_ID = EST.Estacion_ID
WHERE	( U.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( U.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		U.EstatusUnidad_ID <> 5
AND		U.LocacionUnidad_ID <> 22
AND		( @NumeroEconomico IS NULL OR U.NumeroEconomico = @NumeroEconomico )
GROUP BY	E.Nombre,
			EST.Nombre,
			U.NumeroEconomico,
			C.Apellidos + ' ' + C.Nombre
ORDER BY	E.Nombre,
			EST.Nombre,
			U.NumeroEconomico,
			FechaInicial
