/*
	Actualización de Estaciones
	
	Eliminará las estaciones duplicadas en la base de datos
	
	Creado el 18 de Octubre del 2012
	Codificado por Luis Espino
	
	**	Hay un problema con Usuarios_Estaciones, ya que no permite
		una misma estación con un mismo usuario: Las cambiará pero
		los usuarios son diferentes
		Debemos eliminarlas, no actualizarlas
	
	**	Toma mas de 15 minutos llevar a cabo la actualización
*/

USE SICASSync
GO

-- Eliminamos los registros de la tabla 'Usuarios_Estaciones'
DELETE
FROM	Usuarios_Estaciones

-- La tabla temporal que contiene
-- los nombres de las tablas a actualizar
DECLARE	@TABLES TABLE
(
	TABLE_NAME varchar(50)
)

-- La tabla temporal que se utilizará para llevar a cabo
-- las operaciones
DECLARE	@TEMP_TABLES TABLE
(
	TABLE_NAME varchar(50)
)

--	Cargamos los nombres de las tablas,
--	basadas en las columnas con nombre
--	Estacion_ID
INSERT	@TABLES
SELECT	DISTINCT TABLE_NAME
FROM	INFORMATION_SCHEMA.COLUMNS
WHERE	COLUMN_NAME = 'Estacion_ID'
AND		TABLE_NAME NOT IN ('Vista_RegistroIndicadores', 'Estaciones')	-- Evitamos la misma tabla de estaciones
																		-- y las vistas
-- La tabla de las equivalencias
DECLARE @Estaciones TABLE
(
	New_Estacion_ID int,
	Old_Estacion_ID int
)

-- Insertamos las equivalencias
INSERT INTO	@Estaciones VALUES
(1, 19), (9, 18), (10, 16), (11, 17), (15, 12),
(13, 22), (13, 23), (20, 21)

-- Declaramos las variables
DECLARE	@TABLE_NAME varchar(50),
		@New_Estacion_ID int,
		@Old_Estacion_ID int,
		@Statement varchar(max),
		@Temp_Statement varchar(max)

-- Configuramos la instrucción SQL
SET	@Statement = 'UPDATE	@TABLE_NAME
SET		Estacion_ID = @New_Estacion_ID
WHERE	Estacion_ID = @Old_Estacion_ID'

-- Recorremos la tabla de Estaciones
WHILE ( ( SELECT COUNT(*) FROM @Estaciones) > 0 )
BEGIN
	--	Obtenemos las estaciones
	SELECT	TOP 1	@New_Estacion_ID = New_Estacion_ID,
					@Old_Estacion_ID = Old_Estacion_ID
	FROM	@Estaciones
	
	-- Cargamos los nombres de tablas
	INSERT	@TEMP_TABLES
	SELECT	*
	FROM	@TABLES
	
	-- Recorremos los registros de tablas
	WHILE ( ( SELECT COUNT(*) FROM @TEMP_TABLES ) > 0 )
	BEGIN
		-- Obtenemos el nombre de la tabla
		SELECT	TOP 1 @TABLE_NAME = TABLE_NAME
		FROM	@TEMP_TABLES
		ORDER BY	TABLE_NAME

		SET	@Temp_Statement = @Statement
		SET	@Temp_Statement = REPLACE(@Temp_Statement, '@TABLE_NAME', @TABLE_NAME)
		SET	@Temp_Statement = REPLACE(@Temp_Statement, '@New_Estacion_ID', @New_Estacion_ID)
		SET	@Temp_Statement = REPLACE(@Temp_Statement, '@Old_Estacion_ID', @Old_Estacion_ID)
		
		EXEC ( @Temp_Statement )

		DELETE
		FROM	@TEMP_TABLES
		WHERE	TABLE_NAME = @TABLE_NAME
	END
	
	-- Eliminamos la estacion
	DELETE
	FROM	Estaciones
	WHERE	Estacion_ID = @Old_Estacion_ID
	
	-- Borramos el registro
	DELETE
	FROM	@Estaciones
	WHERE	New_Estacion_ID = @New_Estacion_ID
	AND		Old_Estacion_ID = @Old_Estacion_ID
		
END

/* Se termina la actualización */

-- Seleccionamos las estaciones
SELECT * FROM Estaciones

/*
-- La prueba
SELECT COUNT(*) EST_18
FROM CuentaConductores
WHERE Estacion_ID = 18

SELECT COUNT(*) EST_9
FROM CuentaConductores
WHERE Estacion_ID = 9

*/