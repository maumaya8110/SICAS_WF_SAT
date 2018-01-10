/*
Fecha de creación 2012-09-12
Codificado por Luis Espino

Objetivo:
Crear records para AtencionClientes

Nota: (2012-09-12 18:24)
EsEntregado debe ser el equivalente a EsCerrado
Se debe eliminar de la tabla
*/

-- select * from atencionclientes

DECLARE	@Cont int = 1, @ContTipo int = 1;

DECLARE @TipoAtencionCliente_ID int = 1,
		@TipoIncidencia_ID int,
		@Empresa_ID int,
		@Estacion_ID int,
		@Conductor_ID int,
		@Unidad_ID int,
		@NumeroConfirmacion varchar(10),
		@FechaInicial datetime,
		@FechaFinal datetime,
		@Motivo varchar(250),
		@EsEntregado bit,
		@EsCerrado bit,
		@Solucion varchar(250),
		@AtencionClienteIncidencia_ID int,
		@FolioCortesia varchar(10),
		@FechaVencimiento datetime,
		@ObjetoExtraviado varchar(50),
		@Observaciones varchar(250),
		@MontoCargo money,
		@EsAutorizadoReembolso bit,
		@FechaAutorizacionReembolso datetime

--	Las unidades de cam
DECLARE	@UnidadesCAM TABLE (
	Numero int,
	Unidad_ID int,
	Conductor_ID int
)

INSERT @UnidadesCAM
SELECT	ROW_NUMBER() OVER(ORDER BY Unidad_ID) Numero,
		Unidad_ID, 
		ConductorOperativo_ID
FROM	Unidades
WHERE	Empresa_ID = 2
AND		Estacion_ID = 10
AND		Unidad_ID IN ( SELECT Unidad_ID FROM Contratos WHERE EstatusContrato_ID = 1 )

-- El máximo de unidades
DECLARE @MaxUnidadesCAM int, @ContUnidadesCAM int = 1
SELECT	@MaxUnidadesCAM = MAX(Numero) FROM @UnidadesCAM

-- Las unidades de CAT
DECLARE	@UnidadesCAT TABLE (
	Numero int,
	Unidad_ID int,
	Conductor_ID int
)

INSERT @UnidadesCAT
SELECT	ROW_NUMBER() OVER(ORDER BY Unidad_ID) Numero,
		Unidad_ID, 
		ConductorOperativo_ID
FROM	Unidades
WHERE	Empresa_ID = 3
AND		Estacion_ID = 5
AND		Unidad_ID IN ( SELECT Unidad_ID FROM Contratos WHERE EstatusContrato_ID = 1 )

-- El máximo de unidades
DECLARE @MaxUnidadesCAT int, @ContUnidadesCAT int = 1
SELECT	@MaxUnidadesCAT = MAX(Numero) FROM @UnidadesCAT

WHILE ( @Cont <= 1000 )
BEGIN

	--	Encontramos la empresas
	SELECT @Empresa_ID = FLOOR(2 + (4-2)*RAND())	
	
	--	A partir de la empresa, la estación
	IF ( @Empresa_ID = 2 )
	BEGIN
		SET	@Estacion_ID = 10
		
		SELECT	@Unidad_ID = Unidad_ID,
				@Conductor_ID = Conductor_ID
		FROM	@UnidadesCAM
		WHERE	Numero = @ContUnidadesCAM
		
		--	Avanzamos el contador
		SET	@ContUnidadesCAM = @ContUnidadesCAM + 1
		
		--	Si es mayor que el máximo
		--	Lo configuramos como uno
		IF ( @ContUnidadesCAM > @MaxUnidadesCAM )
		BEGIN
			SET	@ContUnidadesCAM = 1
		END
	
	END
	ELSE
	BEGIN
		SET	@Estacion_ID = 5
		
		SELECT	@Unidad_ID = Unidad_ID,
				@Conductor_ID = Conductor_ID
		FROM	@UnidadesCAT
		WHERE	Numero = @ContUnidadesCAT
		
		--	Avanzamos el contador
		SET	@ContUnidadesCAT = @ContUnidadesCAT + 1
		
		--	Si es mayor que el máximo
		--	Lo configuramos como uno
		IF ( @ContUnidadesCAT > @MaxUnidadesCAT )
		BEGIN
			SET	@ContUnidadesCAT = 1
		END
		
	END
	
	-- Si es incidencia, el tipo de incidencia
	IF ( @TipoAtencionCliente_ID = 1 )
	BEGIN
		SELECT @TipoIncidencia_ID = FLOOR(1 + (3-1)*RAND())		
	END
	ELSE
	BEGIN
		SET	@TipoIncidencia_ID = null
	END
	
	--	El número de confirmacion
	SET @NumeroConfirmacion = FLOOR(100000 * RAND())	
	
	--	La fecha inicial
	SET	@FechaInicial = DATEADD(HOUR, @Cont * -1, GETDATE())
	
	--	Es cerrado
	SELECT @EsCerrado = FLOOR(1 + (3-1)*RAND())		
	
	--	La fecha final
	IF ( @EsCerrado = 1 )
	BEGIN
		SET	@FechaFinal = DATEADD(HOUR, @Cont, GETDATE())
	END
	ELSE
	BEGIN
		SET	@FechaFinal = NULL
	END
	
	-- DEPENDIENDO DEL TIPO DE ATENCION
	
	-- Las Incidencias
	IF ( @TipoAtencionCliente_ID = 1 )
	BEGIN
	
		SET	@Solucion = RAND()
		
		SELECT	@FolioCortesia = NULL,
				@AtencionClienteIncidencia_ID = NULL,
				@FolioCortesia = NULL,
				@FechaVencimiento = NULL,
				@ObjetoExtraviado = NULL,
				@Observaciones = NULL,
				@MontoCargo = NULL,
				@EsAutorizadoReembolso = NULL,
				@FechaAutorizacionReembolso = NULL,
				@Motivo = NULL
	END
	
	-- Las cortesias
	IF ( @TipoAtencionCliente_ID = 2 )
	BEGIN
	
		SELECT	@AtencionClienteIncidencia_ID = MAX(AtencionCliente_ID)
		FROM	AtencionClientes
		WHERE	TipoAtencionCliente_ID = 1
		
		SET	@FolioCortesia = FLOOR(RAND() * 10000)
		SET	@Motivo = RAND()
		SET	@FechaVencimiento = DATEADD(MONTH, 3, GETDATE())		
		SET @EsEntregado = @EsCerrado
		
		SELECT	@Solucion = NULL,
				@ObjetoExtraviado = NULL,
				@Observaciones = NULL,
				@MontoCargo = NULL,
				@EsAutorizadoReembolso = NULL,
				@FechaAutorizacionReembolso = NULL
				
	END
	
	-- Los objetos extraviados
	IF ( @TipoAtencionCliente_ID = 3 )
	BEGIN
	
		SET	@ObjetoExtraviado = RAND()
		SET	@Observaciones = RAND()
		SET	@EsEntregado = @EsCerrado
		
		SELECT	@FolioCortesia = NULL,
				@AtencionClienteIncidencia_ID = NULL,
				@FolioCortesia = NULL,
				@FechaVencimiento = NULL,				
				@MontoCargo = NULL,
				@EsAutorizadoReembolso = NULL,
				@FechaAutorizacionReembolso = NULL,
				@Motivo = NULL
	END
	
	-- Los reembolsos	
	IF ( @TipoAtencionCliente_ID = 4 )
	BEGIN
	
		SET	@Motivo = RAND()
		SET	@MontoCargo = RAND()
		SET	@EsAutorizadoReembolso = 1
		SET @FechaAutorizacionReembolso = @FechaInicial
		
		SELECT	@FolioCortesia = NULL,
				@AtencionClienteIncidencia_ID = NULL,
				@FolioCortesia = NULL,
				@FechaVencimiento = NULL,
				@ObjetoExtraviado = NULL,
				@Observaciones = NULL
	END
	
	-- La insercion
	INSERT INTO	AtencionClientes VALUES
	(
		@TipoAtencionCliente_ID,
		@TipoIncidencia_ID,
		@Empresa_ID,
		@Estacion_ID,
		@Conductor_ID,
		@Unidad_ID,
		'admin',
		@NumeroConfirmacion,
		@FechaInicial,
		@FechaFinal,
		@Motivo,
		@EsEntregado,
		@EsCerrado,
		@Solucion,
		@AtencionClienteIncidencia_ID,
		@FolioCortesia,
		@FechaVencimiento,
		@ObjetoExtraviado,
		@Observaciones,
		@MontoCargo,
		@EsAutorizadoReembolso,
		@FechaAutorizacionReembolso
	)
	
	-- Los conteos
	SET	@Cont = @Cont + 1
	SET	@TipoAtencionCliente_ID = @TipoAtencionCliente_ID + 1
	
	IF ( @TipoAtencionCliente_ID > 4 )
	BEGIN
		SET	@TipoAtencionCliente_ID = 1
	END
		
END -- end while

/*

	
	SELECT        *
FROM        (
                SELECT        ROW_NUMBER() OVER(ORDER BY u.numeroeconomico) AS rn,
                            u.*
				FROM	Unidades U
            ) AS sub
WHERE        rn >= 10 AND rn <= 20


SELECT * FROM (
SELECT	ROW_NUMBER() OVER(ORDER BY Unidad_ID) Numero,
		Unidad_ID, 
		ConductorOperativo_ID
FROM	Unidades
WHERE	Empresa_ID = 2
AND		Estacion_ID = 10
AND		Unidad_ID IN ( SELECT Unidad_ID FROM Contratos WHERE EstatusContrato_ID = 1 )
) U

*/
