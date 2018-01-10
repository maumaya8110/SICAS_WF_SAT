/*
	Vista_Empresas_Cuentas
	
	Debe contener
	La Empresa
	La Cuenta
	
	Debe poder consultar por
	Empresa
*/

DECLARE	@Empresa_ID int = null

SELECT	EC.Empresa_ID,
		E.Nombre Empresa,
		EC.Cuenta_ID,		
		C.Nombre Cuenta
FROM	Empresas_Cuentas EC
INNER JOIN	Empresas E
ON		E.Empresa_ID = EC.Empresa_ID
INNER JOIN	Cuentas C
ON		C.Cuenta_ID = EC.Cuenta_ID
WHERE	( @Empresa_ID IS NULL OR EC.Empresa_ID = @Empresa_ID )
