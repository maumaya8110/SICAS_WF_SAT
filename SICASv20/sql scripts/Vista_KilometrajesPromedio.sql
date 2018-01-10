/*
	Reporte de Promedios de Kilometraje
	
	Resultado deseado:
	NumeroEconomico, KmInicial, KmFinal, PromedioDiario
*/

DECLARE	@FechaInicial datetime = '2012-10-01',
		@FechaFinal datetime = '2012-10-01 23:59:59',
		@Empresa_ID int,
		@Estacion_ID int,
		@Usuario_ID varchar(30) = 'luis.escareño'
		
SELECT	E.Nombre Empresa,
		EST.Nombre Estacion,
		U.NumeroEconomico,
		MIN(UK.Kilometraje) KmInicial,
		MAX(UK.Kilometraje) KmFinal,		
		CASE 
		WHEN ( DATEDIFF(DAY,@FechaInicial, @FechaFinal) )  <= 0 THEN ( MAX(UK.Kilometraje) - MIN(UK.Kilometraje) ) / 1
		ELSE ( MAX(UK.Kilometraje) - MIN(UK.Kilometraje) ) / ( DATEDIFF(DAY,@FechaInicial, @FechaFinal) )
		END	PromedioDiario
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		UK.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		U.Estacion_ID = EST.Estacion_ID
WHERE	( U.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( U.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		U.EstatusUnidad_ID <> 5
AND		U.LocacionUnidad_ID <> 22
AND		UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	E.Nombre, EST.Nombre, U.NumeroEconomico
ORDER BY	E.Nombre, EST.Nombre, U.NumeroEconomico

/*
select * from unidades
where numeroeconomico = 2083

select * from unidades_kilometrajes
where unidad_id = 32557
and kilometraje = 12081
*/