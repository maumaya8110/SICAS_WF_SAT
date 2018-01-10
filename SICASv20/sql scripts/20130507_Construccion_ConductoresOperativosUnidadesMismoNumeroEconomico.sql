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
WHERE	Co.Conductor_ID = 38571
--AND		U.NumeroEconomico = 2107
ORDER BY	MontoDiario DESC

select conductoroperativo_id, COUNT(*)
from Unidades
group by ConductorOperativo_ID
having COUNT(*) > 1

select * from Unidades
where ConductorOperativo_ID is null
and EstatusUnidad_ID <> 5

update Unidades set ConductorOperativo_ID = 38571
where Unidad_ID = 2024

select numeroeconomico, COUNT(*)
from Unidades
where	EstatusUnidad_ID<> 5
group by NumeroEconomico
having COUNT(*) > 1