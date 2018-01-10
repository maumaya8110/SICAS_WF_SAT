/* Consulta Base*/

SELECT	CL.Conductor_ID,
		CONT.FechaInicial Inicio,
		CL.Fecha Terminacion,
		TC.Nombre TipoContrato,
		DATEDIFF(DAY, CONT.FechaInicial, CL.Fecha) DuracionDias,
		COND.Edad,
		UPPER(CL.Comentarios) Comentarios
FROM	ContratosLiquidados CL
INNER JOIN	Contratos CONT
ON		CL.Contrato_ID = CONT.Contrato_ID
INNER JOIN	Conductores COND
ON		CL.Conductor_ID = COND.Conductor_ID
INNER JOIN TiposContratos TC
ON		CONT.TipoContrato_ID = TC.TipoContrato_ID

/* Inicia construccion de consulta Reporte de Motivos y Periodos de Bajas */

DECLARE @Motivos TABLE 
(
	Motivo varchar(50)
)

INSERT INTO @Motivos ( Motivo ) VALUES
( 'COBRANZA' ),
('COLISION'),
('VOLUNTARIA'),
('SALE DE CIUDAD'),
('ALTA RENTA'),
('LICENCIA'),
('ENFERMEDAD'),
('EBRIEDAD'),
('IMSS')

DECLARE @Periodos TABLE
(
	DiasInicial int,
	DiasFinal int,
	Descripcion varchar(50)
)

INSERT INTO @Periodos ( DiasInicial, DiasFinal, Descripcion)
VALUES ( -1, 15, '0-15 dias' ), ( 16, 30, '16-30d'), ( 31, 90, '2-3 meses' ),
(91, 180, '4-6 meses'), (181, 365, '6-12 meses'), (366, 730, '12-24 meses'),
(731, 1096, '24-36 meses'), ( 1097, 10000, '+36 meses')


SELECT	Bajas.TipoContrato,
		P.Descripcion Periodo,
		Bajas.Edad,
		M.Motivo
FROM	(
	SELECT	CL.Conductor_ID,
			--CONT.FechaInicial Inicio,
			--CL.Fecha Terminacion,
			TC.Nombre TipoContrato,
			DATEDIFF(DAY, CONT.FechaInicial, CL.Fecha) DuracionDias,
			COND.Edad,
			UPPER(CL.Comentarios) Comentarios
	FROM	ContratosLiquidados CL
	INNER JOIN	Contratos CONT
	ON		CL.Contrato_ID = CONT.Contrato_ID
	INNER JOIN	Conductores COND
	ON		CL.Conductor_ID = COND.Conductor_ID
	INNER JOIN TiposContratos TC
	ON		CONT.TipoContrato_ID = TC.TipoContrato_ID
) Bajas 
LEFT JOIN	@Periodos P
ON	Bajas.DuracionDias BETWEEN P.DiasInicial AND P.DiasFinal
LEFT JOIN	@Motivos M
ON	Bajas.Comentarios LIKE '%' + M.Motivo + '%'

--WHERE	Contrato_ID = 12368

select * from locacionesunidades
