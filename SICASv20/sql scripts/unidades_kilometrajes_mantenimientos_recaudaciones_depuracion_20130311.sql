/*
DROP TABLE Temp_UK_Eliminadas
CREATE TABLE Temp_UK_Eliminadas
(
	Unidad_Kilometraje_ID int,
	Unidad_ID int,
	Conductor_ID int,
	Kilometraje int,
	Fecha datetime,
	Kilometraje_anterior int,
	Fecha_anterior datetime,
	Diferencia int,
	Kilometros int,
	Dias int,
	Motivo varchar(100)
)*/

/*DELETE
FROM	Temp_UK_Eliminadas*/

DECLARE	@FechaInicial datetime = '2013-02-01',
		@FechaFinal datetime = '2013-02-28 23:59:59'
		
DECLARE @UK TABLE
(
	Unidad_Kilometraje_ID int,
	Unidad_ID int,
	Kilometraje int,
	Fecha datetime
)

INSERT	@UK
SELECT	Unidad_Kilometraje_ID,
		Unidad_ID,
		Kilometraje,
		Fecha
FROM	Unidades_Kilometrajes
WHERE	Fecha BETWEEN @FechaInicial AND @FechaFinal
AND		Unidad_ID = 34137

DECLARE @Unidad_Kilometraje_ID int,
		@Unidad_ID int,
		@Kilometraje int,
		@Fecha datetime,
		@Unidad_Kilometraje_ID_anterior int,
		@Unidad_ID_anterior int,
		@Kilometraje_anterior int,
		@Fecha_anterior datetime,
		@Dias int,
		@Kilometros int,
		@Diferencia int,
		@Motivo varchar(100)
		
WHILE	( ( SELECT COUNT(*) FROM @UK ) > 0 )
BEGIN
	
	--	Obtener la ultima lectura.
	SELECT	@Unidad_Kilometraje_ID = Unidad_Kilometraje_ID,
			@Unidad_ID = Unidad_ID,
			@Kilometraje = Kilometraje,
			@Fecha = Fecha
	FROM	@UK
	ORDER BY	Unidad_Kilometraje_ID
	
	SELECT	TOP 1 @Unidad_Kilometraje_ID_anterior = Unidad_Kilometraje_ID,
			@Unidad_ID_anterior = Unidad_ID,
			@Kilometraje_anterior = Kilometraje,
			@Fecha_anterior = Fecha
	FROM	Unidades_Kilometrajes
	WHERE	Unidad_ID = @Unidad_ID
	AND		Fecha < @Fecha	
	ORDER BY	Fecha DESC
	
	--SELECT @Unidad_ID, @Unidad_ID_anterior, @Fecha, @Fecha_anterior
	
	--	Si es menor, borrar
	IF ( @Kilometraje < @Kilometraje_anterior )
	BEGIN
		
		-- Eliminar, menor que anterior
		SET	@Motivo = 'MENOR'
		-- Eliminar, se pasa de captura permitida			
		INSERT Temp_UK_Eliminadas
		SELECT	*, @Kilometraje_anterior, @Fecha_anterior, null, null, null, @Motivo
		FROM	Unidades_Kilometrajes
		WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
		
		DELETE
		FROM	Unidades_Kilometrajes
		WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
	END
	ELSE
	BEGIN
		--	Obtener la diferencia en dias
		SET	@Dias = DATEDIFF(DAY, @Fecha_anterior, @Fecha)
		
		IF ( @Dias = 0 )
		BEGIN
			SET @Dias = 1
		END -- Dias > 0
		
		--	Multiplicar por 722
		SET	@Kilometros = @Dias * 722
		
		SET	@Diferencia = @Kilometraje - @Kilometraje_anterior
			
		IF ( @Diferencia > @Kilometros )		
		BEGIN
			
			SET	@Motivo = 'MAYOR'
			-- Eliminar, se pasa de captura permitida			
			INSERT Temp_UK_Eliminadas
			SELECT	*, @Kilometraje_anterior, @Fecha_anterior, @Diferencia, @Kilometros, @Dias, @Motivo
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
			
			DELETE
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
			
		END -- Diferencia
		
	END -- END ELSE Kilometraje < Anterior
	
	DELETE
	FROM	@UK
	WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
	
	PRINT ( 'Unidad eliminada' )
END

SELECT	*
FROM	Temp_UK_Eliminadas
-- WHERE	Unidad_Kilometraje_ID IN (2094939,2094690)