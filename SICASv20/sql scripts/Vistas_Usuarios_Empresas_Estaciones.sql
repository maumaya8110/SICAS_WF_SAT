/*
	Vistas:
		Usuarios_Empresas
		Usuarios_Estaciones
		
	Creado el 17 de Octubre de 2012
	Codificado por Luis Espino	
*/

DECLARE @Usuario_ID varchar(30) = 'prueba.b'

SELECT	Empresa_ID, Nombre,
		(	SELECT	COUNT(*)
			FROM	Usuarios_Empresas
			WHERE	Empresa_ID = E.Empresa_ID
			AND		Usuario_ID = @Usuario_ID
		) EsPermitido
FROM	Empresas E
WHERE	TipoEmpresa_ID IN ( 1,2 )
AND		Activo = 1
ORDER BY	Nombre

SELECT	Estacion_ID, Nombre,
		(	SELECT	COUNT(*)
			FROM	Usuarios_Estaciones
			WHERE	Estacion_ID = E.Estacion_ID
			AND		Usuario_ID = @Usuario_ID
		) EsPermitido
FROM	Estaciones E
WHERE	E.Activo = 1
ORDER BY	E.Nombre

