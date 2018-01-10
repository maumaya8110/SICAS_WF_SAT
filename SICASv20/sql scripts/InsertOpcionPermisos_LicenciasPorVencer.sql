DECLARE	@Opcion_ID int

INSERT INTO Opciones
VALUES ( 21, 'LicenciasPorVencerLauncher', 'Licencias Por Vencer', 'licencias.png', 1, 1)

--	Obtenemos el numero de opcion
SELECT	@Opcion_ID = MAX(Opcion_ID)
FROM	Opciones
WHERE	Nombre = 'LicenciasPorVencerLauncher'

--	Insertamos todos los permisos en 0
INSERT	PermisosUsuarios
SELECT	Usuario_ID, @Opcion_ID, 0
FROM	Usuarios

--	Actualizamos los que habilitaremos
UPDATE	PermisosUsuarios
SET		EsPermitido = 1
WHERE	Opcion_ID = @Opcion_ID
AND		Usuario_ID IN
(
	SELECT	Usuario_ID
	FROM	PermisosUsuarios
	WHERE	( Opcion_ID = 21
	AND		EsPermitido = 1 )
	OR		( Opcion_ID = 182
	AND		EsPermitido = 1 )
	AND		Usuario_ID IN
	(
		SELECT	Usuario_ID
		FROM	Usuarios_Estaciones
		GROUP BY	Usuario_ID
		HAVING	COUNT(*) = 1
	)
)

--	Validaciones
SELECT	*
FROM	Opciones
WHERE	Opcion_ID = @Opcion_ID

SELECT	*
FROM	PermisosUsuarios
WHERE	Opcion_ID = @Opcion_ID
AND		EsPermitido = 1