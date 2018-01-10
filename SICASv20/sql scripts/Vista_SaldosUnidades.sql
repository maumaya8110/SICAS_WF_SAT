/*
	Vista_SaldosUnidades
	Debe Contener:
	La Unidad
	La Empresa
	La Cuenta
	El Saldo
	
	Se debe poder consultar por unidad
*/
DECLARE	@Unidad_ID int, @Empresa_ID int, @Cuenta_ID int, @FechaInicial datetime, @FechaFinal datetime
SET	@Unidad_ID = 2532

SELECT	U.Unidad_ID,
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
		C.Nombre