/*
DROP TABLE RegistrosKilometrajesEliminados
CREATE TABLE RegistrosKilometrajesEliminados
(
	Unidad_Kilometraje_ID int,
	Unidad_ID int,
	Conductor_ID int,
	Kilometraje int,
	Fecha datetime,
	Kilometraje_comparado int,
	Fecha_comparado datetime,
	Diferencia int,
	Kilometros int,
	Dias int,
	Motivo varchar(100)
)*/

SET NOCOUNT ON;

DELETE
FROM	RegistrosKilometrajesEliminados

DECLARE	@FechaInicial datetime = '2013-01-01',
		@FechaFinal datetime = '2013-03-01'

SELECT	@FechaInicial = MIN(Fecha),
		@FechaFinal = MAX(Fecha)
FROM	Unidades_Kilometrajes

--SELECT	@FechaInicial, @FechaFinal
		
DECLARE @Unidades TABLE
(
	Unidad_ID int
)

DECLARE @UK TABLE
(
	Unidad_Kilometraje_ID int,
	Unidad_ID int,
	Kilometraje int,
	Fecha datetime
)

DECLARE @Unidad_Kilometraje_ID int,
		@Unidad_ID int,
		@Kilometraje int,
		@Fecha datetime,
		@Unidad_Kilometraje_ID_siguiente int,
		@Unidad_ID_siguiente int,
		@Kilometraje_siguiente int,
		@Fecha_siguiente datetime,
		@Unidad_Kilometraje_ID_anterior int,
		@Unidad_ID_anterior int,
		@Kilometraje_anterior int,
		@Fecha_anterior datetime,
		@Dias int,
		@Kilometros int,
		@Diferencia int,
		@Motivo varchar(100),
		@UltimoKmValido int,
		@EsPrimero bit,
		@Count int

INSERT	@Unidades
SELECT	Unidad_ID
FROM	Unidades
WHERE	EstatusUnidad_ID IN (1,2)

WHILE ( (SELECT COUNT(*) FROM @Unidades) > 0)
BEGIN
	SELECT	TOP 1 @Unidad_ID = Unidad_ID
	FROM	@Unidades
	ORDER BY	Unidad_ID
	
	
	INSERT	@UK
	SELECT	Unidad_Kilometraje_ID,
			Unidad_ID,
			Kilometraje,
			Fecha
	FROM	Unidades_Kilometrajes
	WHERE	Fecha BETWEEN @FechaInicial AND @FechaFinal
	AND		Unidad_ID = @Unidad_ID
	ORDER BY Fecha ASC


			
	SET	@EsPrimero = 1

	--	Obtener la ultima lectura.
	SELECT	TOP 1 @Unidad_Kilometraje_ID = Unidad_Kilometraje_ID,
			@Unidad_ID = Unidad_ID,
			@Kilometraje = Kilometraje,						
			@Fecha = Fecha
	FROM	@UK
	ORDER BY	Fecha ASC

	DELETE
	FROM	@UK
	WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
	
	WHILE	( ( SELECT COUNT(*) FROM @UK ) > 0 )
	BEGIN
		
		SELECT	@Dias = 0, @Kilometros = 0, @Diferencia = 0
		
		SELECT	TOP 1 @Unidad_Kilometraje_ID_siguiente = Unidad_Kilometraje_ID,
				@Unidad_ID_siguiente = Unidad_ID,
				@Kilometraje_siguiente = Kilometraje,
				@Fecha_siguiente = Fecha
		FROM	@UK
		WHERE	Unidad_ID = @Unidad_ID
		AND		Fecha > @Fecha	
		ORDER BY	Fecha ASC
		
		--	Si es menor, borrar
		IF ( @Kilometraje > @Kilometraje_siguiente )
		BEGIN
			
			-- Eliminar, menor que siguiente
			SET	@Motivo = 'MENOR'
			-- Eliminar, se pasa de captura permitida			
			INSERT RegistrosKilometrajesEliminados
			SELECT	*, @Kilometraje, @Fecha, null, null, null, @Motivo
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
			
			DELETE
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
			
			DELETE
			FROM	@UK
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
			
			
		END
		ELSE
		BEGIN
			--	Obtener la diferencia en dias
			SET	@Dias = ABS(DATEDIFF(DAY, @Fecha, @Fecha_siguiente))
			
			IF ( @Dias = 0 )
			BEGIN
				SET @Dias = 1
			END -- Dias > 0
			
			--	Multiplicar por 1440
			SET	@Kilometros = @Dias * 1440
			
			SET	@Diferencia = @Kilometraje_siguiente - @Kilometraje
				
			IF ( @Diferencia > @Kilometros )		
			BEGIN
				
				SET	@Motivo = 'MUY MAYOR'
				-- Eliminar, se pasa de captura permitida			
				INSERT RegistrosKilometrajesEliminados
				SELECT	*, @Kilometraje, @Fecha, @Diferencia, @Kilometros, @Dias, @Motivo
				FROM	Unidades_Kilometrajes
				WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
				
				DELETE
				FROM	Unidades_Kilometrajes
				WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
				
				DELETE
				FROM	@UK
				WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
				
			END -- Diferencia
			ELSE
			BEGIN
				-- Aqui es valido
				SELECT	TOP 1 @Unidad_Kilometraje_ID = Unidad_Kilometraje_ID,
						@Unidad_ID = Unidad_ID,
						@Kilometraje = Kilometraje,						
						@Fecha = Fecha
				FROM	@UK
				WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID_siguiente
				
				DELETE
				FROM	@UK
				WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
			END
		END -- END ELSE Kilometraje < siguiente
		
	END
	
	
	DELETE FROM @Unidades
	WHERE	Unidad_ID = @Unidad_ID
	
END

GO

--	Seleccionamos la tabla
SELECT	*
FROM	RegistrosKilometrajesEliminados

GO
/*
--	Si es menor, borrar
	IF ( @Kilometraje < @Kilometraje_anterior )
	BEGIN
		
		-- Eliminar, menor que siguiente
		SET	@Motivo = 'ANTERIOR MENOR'
		-- Eliminar, se pasa de captura permitida			
		INSERT RegistrosKilometrajesEliminados
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
		SET	@Dias = ABS(DATEDIFF(DAY, @Fecha, @Fecha_siguiente))
		
		IF ( @Dias = 0 )
		BEGIN
			SET @Dias = 1
		END -- Dias > 0
		
		--	Multiplicar por 722
		SET	@Kilometros = @Dias * 722
		
		SET	@Diferencia = @Kilometraje - @Kilometraje_anterior
			
		IF ( @Diferencia > @Kilometros )		
		BEGIN
			
			SET	@Motivo = 'ANTERIOR MAYOR'
			-- Eliminar, se pasa de captura permitida			
			INSERT RegistrosKilometrajesEliminados
			SELECT	*, @Kilometraje_anterior, @Fecha_anterior, @Diferencia, @Kilometros, @Dias, @Motivo
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
			
			DELETE
			FROM	Unidades_Kilometrajes
			WHERE	Unidad_Kilometraje_ID = @Unidad_Kilometraje_ID
			
		END -- Diferencia
		
	END -- END ELSE Kilometraje_anterior < Kilometraje
*/