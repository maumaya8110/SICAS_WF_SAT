/*

	Actualización de Permisos de Usuarios
	en Empresas y Estaciones
	
	Actualiza los permisos de usuarios,
	a partir de los actuales, en un desgloce
	por empresa y estación.
	
	Creado el 21 de Febrero de 2012
	Codificado por Luis Espino

*/

USE SICASSync
GO

-- Actualizamos al usuario admin
UPDATE	Usuarios 
SET		Empresa_ID = NULL, 
		Estacion_ID = NULL
WHERE	Usuario_ID = 'admin'

-- Borramos los registros de permisos por empresas
DELETE	FROM	Usuarios_Empresas
GO

-- Borramos los registros de permisos por estaciones
DELETE	FROM	Usuarios_Estaciones
GO

-- Ingresamos los permisos por empresas
INSERT	Usuarios_Empresas
SELECT	DISTINCT Usuario_ID, Empresa_ID
FROM	Usuarios
WHERE	Empresa_ID IS NOT NULL
UNION
SELECT	DISTINCT U.Usuario_ID, E.Empresa_ID
FROM	Usuarios U, Empresas E
WHERE	E.TipoEmpresa_ID IN (1,2)
AND		U.Empresa_ID IS NULL
AND		E.Activo = 1
AND		U.Activo = 1
GO

-- Ingresamos los permisos por estaciones
INSERT	Usuarios_Estaciones
SELECT	Usuario_ID, Estacion_ID
FROM	Usuarios
WHERE	Estacion_ID IS NOT NULL
UNION
SELECT	U.Usuario_ID, E.Estacion_ID
FROM	Usuarios U, Estaciones E
WHERE	U.Estacion_ID IS NULL
AND		E.Activo = 1
AND		U.Activo = 1
GO

SELECT	*
FROM	Usuarios_Empresas

SELECT	*
FROM	Usuarios_Estaciones