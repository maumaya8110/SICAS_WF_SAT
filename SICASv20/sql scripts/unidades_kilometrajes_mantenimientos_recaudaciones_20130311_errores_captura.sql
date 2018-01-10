
DECLARE	@FechaInicial datetime = '2013-02-01',
		@FechaFinal datetime = '2013-03-01',
		@Dias int

		
SET	@Dias =  DATEDIFF(DAY,@FechaInicial,@FechaFinal)
DECLARE @Maximos TABLE (
Unidad_ID int,
Maximo int
)

INSERT @Maximos
SELECT	U.Unidad_ID,
		MAX(UK.Kilometraje) Maximo
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		UK.Unidad_ID = U.Unidad_ID
WHERE	UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	U.Unidad_ID

SELECT	DISTINCT U.NumeroEconomico,
		UK.Kilometraje,
		UK.Fecha
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		UK.Unidad_ID = U.Unidad_ID
INNER JOIN @Maximos M
ON		UK.Unidad_ID = M.Unidad_ID
		AND	UK.Kilometraje = M.Maximo

SELECT	U.Unidad_ID,
		AVG(UK.Kilometraje) Promedio,
		MIN(UK.Kilometraje) Minimo,
		MAX(UK.Kilometraje) Maximo,
		MAX(UK.Kilometraje)-MIN(UK.Kilometraje) Recorrido
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		UK.Unidad_ID = U.Unidad_ID
WHERE	UK.Fecha BETWEEN @FechaInicial AND @FechaFinal
GROUP BY	U.Unidad_ID