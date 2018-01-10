DELETE FROM RegistroKilometrajesMantenimiento

DECLARE	@FechaInicial datetime,
		@FechaFinal datetime

SET	@FechaInicial = '2013-01-01'
SET	@FechaFinal = '2013-03-21'

WHILE ( @FechaInicial <= @FechaFinal )
BEGIN

	EXEC usp_RegistroKilometrajesMantenimientos @FechaInicial 
	
	SET	@FechaInicial = DATEADD( DAY, 1, @FechaInicial )
	
END

SELECT * FROM RegistroKilometrajesMantenimiento

GO