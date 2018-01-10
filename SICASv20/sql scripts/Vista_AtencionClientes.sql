/*
	Vista_AtencionClientes
	
	Debe incluir todos los datos de las atenciones a clientes
	además de sus relaciones
*/
DECLARE	@AtencionCliente_ID int, @TipoAtencionCliente_ID int, @Unidad_ID int,
		@FechaInicial datetime, @FechaFinal datetime, @NumeroConfirmacion varchar
		
SELECT	AC.AtencionCliente_ID,
		TAC.Nombre TipoAtencionCliente,
		TI.Nombre TipoIncidencia,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		COND.Apellidos + ' ' + COND.Nombre Conductor,
		U.NumeroEconomico Unidad,
		AC.Usuario_ID,
		AC.NumeroConfirmacion,
		AC.FechaInicial,
		AC.FechaFinal,
		AC.EsEntregado,
		AC.EsCerrado,
		AC.Motivo,
		AC.Solucion,
		AC.AtencionClienteIncidencia_ID,
		AC.FolioCortesia,
		AC.FechaVencimiento,
		AC.ObjetoExtraviado,
		AC.Observaciones,
		AC.MontoCargo,
		AC.EsAutorizadoReembolso,
		AC.FechaAutorizacionReembolso
FROM	AtencionClientes AC
INNER JOIN	TiposAtencionClientes TAC
ON		AC.TipoAtencionCliente_ID = TAC.TipoAtencionCliente_ID
LEFT JOIN	TiposIncidencias TI
ON		AC.TipoIncidencia_ID = TI.TipoIncidencia_ID
INNER JOIN	Empresas E
ON		AC.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		AC.Estacion_ID = EST.Estacion_ID
INNER JOIN	Conductores COND
ON		AC.Conductor_ID = COND.Conductor_ID
INNER JOIN	Unidades U
ON		AC.Unidad_ID = U.Unidad_ID
WHERE	( @AtencionCliente_ID IS NULL OR AC.AtencionCliente_ID = @AtencionCliente_ID )
AND		( @TipoAtencionCliente_ID IS NULL OR AC.TipoAtencionCliente_ID = @TipoAtencionCliente_ID )
AND		( @Unidad_ID IS NULL OR AC.Unidad_ID = @Unidad_ID )
AND		( @NumeroConfirmacion IS NULL OR AC.NumeroConfirmacion = @NumeroConfirmacion )
AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL ) OR ( AC.FechaInicial BETWEEN @FechaInicial AND @FechaFinal ) )


