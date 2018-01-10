/*
	Vista_ReporteFlotilla
	Creado el 31 de Octubre por Luis Espino
*/

DECLARE	@Empresa_ID int,
		@Estacion_ID int,
		@Usuario_ID varchar(30) = 'luis.escareño'
		
SELECT	E.Nombre Empresa,
		Est.Nombre Estacion,
		U.Unidad_ID,
		ISNULL(LU.Nombre,'') Locacion,
		CASE 
		WHEN (SELECT COUNT(*)
		FROM Contratos
		WHERE	Unidad_ID = U.Unidad_ID
		AND		EstatusContrato_ID = 1) = 0
		THEN	'SIN CONTRATO'
		ELSE	'CON CONTRATO'
		END Contrato
FROM	Unidades	U
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones Est
ON		U.Estacion_ID = Est.Estacion_ID
LEFT JOIN	LocacionesUnidades	LU
ON		LU.LocacionUnidad_ID = U.LocacionUnidad_ID
WHERE	( U.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( U.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR U.Empresa_ID = @Empresa_ID )
AND		( @Estacion_ID IS NULL OR U.Estacion_ID = @Estacion_ID )
AND		U.EstatusUnidad_ID <> 5
AND		U.LocacionUnidad_ID <> 22
ORDER BY Empresa, Estacion