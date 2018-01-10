SELECT	U.Unidad_ID, U.NumeroEconomico, Co.Conductor_ID, 
		UPPER(Co.Apellidos + ' ' + Co.Nombre) Conductor,
		U.Kilometraje Kilometraje, ISNULL(CoC.Apellidos + ' ' + CoC.Nombre,'') ConductorCopia, C.Contrato_ID,
		Co.MensajeACaja, U.Empresa_ID, ISNULL(C.MontoDiario,0) MontoDiario, E.Nombre Empresa
FROM	Unidades U
INNER JOIN	Conductores Co
ON		U.ConductorOperativo_ID = Co.Conductor_ID
LEFT JOIN	Contratos C
ON		(U.Unidad_ID = C.Unidad_ID AND C.EstatusContrato_ID = 1 AND C.Cuenta_ID = 1)
LEFT JOIN	Conductores CoC
ON		C.ConductorCopia_ID = CoC.Conductor_ID
INNER JOIN   Empresas E
ON      U.Empresa_ID = E.Empresa_ID
WHERE	U.NumeroEconomico = 2107
ORDER BY	Conductor DESC