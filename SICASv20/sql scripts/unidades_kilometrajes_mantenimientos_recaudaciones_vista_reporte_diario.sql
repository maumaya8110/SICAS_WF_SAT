DECLARE	@Fecha datetime = '2013-01-01'

SELECT	CONVERT(varchar,RKM.Fecha,103) Fecha,
		E.Nombre Empresa,
		RKM.NumeroEconomico,
		RKM.KMInicial,
		-- RKM.KMFinal,
		RKM.KMFinal - RKM.KMInicial KMRecorrido,
		RKM.Mantenimientos,
		RKM.Recaudacion,
		RKM.UltimoKM,
		ISNULL(CONVERT(varchar,RKM.UltimaCaptura,103),'') UltimaCaptura
FROM	RegistroKilometrajesMantenimiento RKM
INNER JOIN	Unidades U
ON		RKM.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		U.Empresa_ID = E.Empresa_ID
WHERE	RKM.Fecha = dbo.udf_DateValue( @Fecha )

