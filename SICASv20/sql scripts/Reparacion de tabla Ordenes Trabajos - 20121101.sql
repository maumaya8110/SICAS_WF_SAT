select top 1  * from ordenestrabajos
order by ordentrabajo_id desc

DBCC DBREINDEX ('OrdenesTrabajos' , ' ', 70);

dbcc checktable ( 'OrdenesTrabajos' )

DECLARE	@OrdenTrabajo_ID int,
		@ClienteFacturar_ID int,
		@NumeroEconomico int,
		@CB int,
		@FechaAltaInicial datetime = '2012-11-01',
		@FechaAltaFinal datetime = '2012-11-01 23:59:59',
		@FechaTerminacionInicial datetime,
		@FechaTerminacionFinal datetime,
		@Empresa_ID int = 4,
		@Estacion_ID int = 1
		
SELECT	OT.OrdenTrabajo_ID,    
		E.Nombre Empresa,    
		TM.Nombre TipoMantenimiento,    
		EC.Nombre ClienteFactura,    
		EOT.Nombre Estatus,    
		F.FolioFiscal FolioFactura,    
		OT.NumeroEconomico,    
		OT.Usuario_ID UsuarioCaptura,    
		OT.CodigoBarras,    
		OT.Subtotal,    
		OT.IVA,    
		OT.Total,    
		OT.FechaAlta,    
		OT.FechaInicioReparacion,    
		OT.FechaTerminacion,    
		OT.FechaPago,    
		OT.FechaFacturacion,    
		OT.ManoObra,    
		OT.IVAManoObra,    
		OT.IVARefacciones,    
		OT.Kilometraje,    
		OT.CostoRefacciones,    
		OT.CostoManoObra,    
		OT.CargoAConductor,    
		OT.CB,    
		OT.CB_Activo,    
		OT.Comentarios	    
FROM	OrdenesTrabajos OT    
INNER JOIN	Empresas E    
ON		OT.Empresa_ID = E.Empresa_ID    
INNER JOIN	TiposMantenimientos TM    
ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID    
INNER JOIN	Empresas EC    
ON		OT.ClienteFacturar_ID = EC.Empresa_ID    
INNER JOIN	Unidades U    
ON		OT.Unidad_ID = U.Unidad_ID    
INNER JOIN	EstatusOrdenesTrabajo EOT    
ON		OT.EstatusOrdenTrabajo_ID = EOT.EstatusOrdenTrabajo_ID    
LEFT JOIN	Cajas C    
ON		OT.Caja_ID = C.Caja_ID    
LEFT JOIN	Facturas F    
ON		OT.Factura_ID = F.Factura_ID    
WHERE	( @OrdenTrabajo_ID IS NULL OR OT.OrdenTrabajo_ID = @OrdenTrabajo_ID )     
AND	( @ClienteFacturar_ID IS NULL OR OT.ClienteFacturar_ID = @ClienteFacturar_ID )      
AND	( @NumeroEconomico IS NULL OR OT.NumeroEconomico = @NumeroEconomico )    
AND	( @CB IS NULL OR OT.CB = @CB )
AND	( ( @FechaAltaInicial IS NULL AND @FechaAltaFinal IS NULL ) OR ( OT.FechaAlta BETWEEN @FechaAltaInicial AND @FechaAltaFinal ) )
AND	( ( @FechaTerminacionInicial IS NULL AND @FechaTerminacionFinal IS NULL ) OR ( OT.FechaTerminacion BETWEEN @FechaTerminacionInicial AND @FechaTerminacionFinal ) )
AND ( OT.Empresa_ID = @Empresa_ID )
AND ( @Estacion_ID IS NULL OR OT.Estacion_ID = @Estacion_ID ) AND OT.TipoMantenimiento_ID IN (1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19)

