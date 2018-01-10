DECLARE	@FechaInicial datetime = '2013-01-01',
		@FechaFinal datetime = '2013-03-01'

SELECT	@FechaInicial = MIN(Fecha),
		@FechaFinal = MAX(Fecha)
FROM	Unidades_Kilometrajes

select * from unidades_kilometrajes
where unidad_id = 2615
and fecha between @fechainicial and @fechafinal
order by fecha asc

select datediff(
	day,
	'2009-05-30 11:49:25.890',
	'2011-11-01 16:29:20.043'
)

--delete from Temp_UK_Eliminadas
/*
delete from unidades_kilometrajes

set identity_insert unidades_kilometrajes on
insert into unidades_kilometrajes 
( unidad_kilometraje_id, unidad_id, conductor_id, kilometraje, fecha)
select  unidad_kilometraje_id, unidad_id, conductor_id, kilometraje, fecha
from sicassync.dbo.unidades_kilometrajes
set identity_insert unidades_kilometrajes off

DECLARE	@FechaInicial datetime = '2013-01-01',
		@FechaFinal datetime = '2013-03-22'

SELECT	@FechaInicial = MIN(Fecha),
		@FechaFinal = MAX(Fecha)
FROM	Unidades_Kilometrajes

DELETE FROM	Unidades_Kilometrajes
WHERE	Fecha BETWEEN @FechaInicial AND @FechaFinal

insert	unidades_kilometrajes
select	suk.unidad_id, suk.conductor_id, suk.kilometraje, suk.fecha
from	sicassync.dbo.unidades_kilometrajes suk
where	suk.fecha between @fechainicial and @fechafinal
*/
