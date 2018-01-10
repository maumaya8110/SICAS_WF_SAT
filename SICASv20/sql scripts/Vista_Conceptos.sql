/*
	Vista Conceptos
	
	Debe contener
	Concepto,
	Cuenta,
	ID's y Nombres,
	Atributos de los conceptos
	
	Debe poder ser consultarse por 
	Concepto
	Cuenta
*/

DECLARE	@Cuenta_ID int, @Concepto_ID int

SELECT	C.Concepto_ID,
		C.Nombre,
		C.Cuenta_ID,
		CU.Nombre Cuenta,
		C.EnRecibo,
		C.VisibleRecibo,
		C.Activo
FROM	Conceptos C
INNER JOIN	Cuentas CU
ON		C.Cuenta_ID = CU.Cuenta_ID
WHERE	( @Concepto_ID IS NULL OR C.Concepto_ID = @Concepto_ID )
AND		( @Cuenta_ID IS NULL OR C.Cuenta_ID = @Cuenta_ID )