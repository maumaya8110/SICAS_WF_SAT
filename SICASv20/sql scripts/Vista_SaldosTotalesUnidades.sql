/*
	Vista_SaldosTotalesUnidades
	
	Debe incluir
	Empresa,
	Estacion,
	Unidad,
	Ingreso,
	Gasto,
	Saldo
	
	Debe poder ser consultada por
	Empresa,
	Estacion,
	Unidad
	
	El propósito es conocer que tan rentable es una unidad
*/
DECLARE	@Unidad_ID int, @Empresa_ID int, @Estacion_ID int, @FechaInicial datetime, @FechaFinal datetime
SELECT	@Empresa_ID = 2, @Estacion_ID = 1

SELECT	E.Nombre Empresa,
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
		U.NumeroEconomico