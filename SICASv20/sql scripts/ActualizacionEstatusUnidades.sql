/*
	7 de Mayo de 2013
	Creado por Luis Espino
	
	Script para actualización de estatus de unidades
	a partir de locaciones	
*/

--	Verificador, compara los estatus de las unidades
--	contra los estatus correspondientes según las locaciones
SELECT	U.Unidad_ID, U.EstatusUnidad_ID, LU.EstatusUnidad_ID
FROM	Unidades U
INNER JOIN	LocacionesUnidades LU
ON		U.LocacionUnidad_ID = LU.LocacionUnidad_ID
WHERE	U.EstatusUnidad_ID <> LU.EstatusUnidad_ID
AND		U.EstatusUnidad_ID <> 5
GO

--	Actualiza los estatus de las unidades
--	a partir de las locaciones
UPDATE	Unidades
SET		EstatusUnidad_ID = LU.EstatusUnidad_ID
FROM	Unidades U, LocacionesUnidades LU
WHERE	U.LocacionUnidad_ID = LU.LocacionUnidad_ID
GO