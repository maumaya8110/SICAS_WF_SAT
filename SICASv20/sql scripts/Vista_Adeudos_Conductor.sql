/*
	Vista Adeudos de Conductor
	
	Modificado el 18 de Octubre de 2012
	por Luis Espino
	
	Se eliminó la necesidad de consultar
	el campo "Empresa_ID" de la tabla "Estaciones"
*/
DECLARE @Conductor_ID int = 36407

SELECT	CC.Empresa_ID, E.Nombre Empresa, CC.Cuenta_ID, CC.Concepto_ID, C.Nombre Cuenta, CC.Saldo, 0.00 Pagar     
FROM	(     
SELECT	Conductor_ID, Empresa_ID, Cuenta_ID,      
        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = CuentaConductores.Cuenta_ID)     
        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,     
        (SUM(Abono)-SUM(Cargo)) Saldo     
FROM	CuentaConductores
WHERE   Conductor_ID = @Conductor_ID
GROUP BY Conductor_ID, Empresa_ID, Cuenta_ID   
        ) CC     
INNER JOIN	Empresas E     
ON		E.Empresa_ID = CC.Empresa_ID     
INNER JOIN	Cuentas C     
ON		C.Cuenta_ID = CC.Cuenta_ID
WHERE   C.Cuenta_ID NOT IN ( 9, 35, 17 )

UNION 

SELECT	EC.Empresa_ID, E.Nombre Empresa, EC.Cuenta_ID, 
        (SELECT MIN(Concepto_ID) FROM Conceptos WHERE (Cuenta_ID = 3)     
        AND (Nombre LIKE '%ABONO%' OR Nombre LIKE '%Pago%')) Concepto_ID,
        C.Nombre Cuenta, 
        (SELECT ISNULL(SUM(Abono-Cargo),0) FROM CuentaConductores
        WHERE Cuenta_ID = 3
        AND Conductor_ID = @Conductor_ID) Saldo, 
        0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
WHERE	EC.Cuenta_ID = 3

UNION

SELECT	EC.Empresa_ID,
		E.Nombre Empresa,
		C.Cuenta_ID,
		( 
			SELECT MIN(Concepto_ID) 
			FROM Conceptos			
			WHERE	Cuenta_ID = C.Cuenta_ID
			AND	Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%'
		) Concepto_ID,
		C.Nombre Cuenta,
		ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MIN(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
		FROM	Tickets,
				VariablesNegocio
		WHERE	Tickets.Conductor_ID = @Conductor_ID
		AND		VariableNegocio_ID = 'TarifaDescanso'
		GROUP BY	Valor ),0) Saldo,
		0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
WHERE	C.Cuenta_ID = 17
AND		EC.Empresa_ID IN
(
	SELECT	Empresa_ID
	FROM	Contratos
	WHERE	EstatusContrato_ID = 1
	AND		Conductor_ID = @Conductor_ID	
)



UNION

SELECT	EC.Empresa_ID,
		E.Nombre Empresa,
		C.Cuenta_ID,
		( 
			SELECT MIN(Concepto_ID) 
			FROM Conceptos			
			WHERE	Cuenta_ID = C.Cuenta_ID
			AND	Nombre LIKE '%PAGO%' OR Nombre LIKE '%ABONO%'
		) Concepto_ID,
		C.Nombre Cuenta,
		ISNULL(( SELECT DATEDIFF(DAY,ISNULL(MIN(Fecha),GETDATE()),GETDATE()) * CONVERT(money,Valor) * -1
		FROM	Tickets,
				VariablesNegocio
		WHERE	Tickets.Conductor_ID = @Conductor_ID
		AND		VariableNegocio_ID = 'TarifaCooperativa'
		GROUP BY	Valor ),0) Saldo,
		0.00 Pagar
FROM	Empresas_Cuentas EC
INNER JOIN	Cuentas C
ON		EC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		EC.Empresa_ID = E.Empresa_ID
WHERE	C.Cuenta_ID = 35
AND		EC.Empresa_ID IN
(
	SELECT	Empresa_ID
	FROM	Contratos
	WHERE	EstatusContrato_ID = 1
	AND		Conductor_ID = @Conductor_ID
)

ORDER BY Empresa_ID, Cuenta_ID