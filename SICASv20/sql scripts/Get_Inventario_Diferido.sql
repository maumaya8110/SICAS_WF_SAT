DECLARE @InventarioTotal int,
		@Refaccion_ID int = 4290,
		@Empresa_ID int = 4,
		@Estacion_ID int = 13
		
SELECT	@InventarioTotal = CantidadInventario
FROM	Inventario
WHERE	Refaccion_ID = @Refaccion_ID
AND		Empresa_ID = @Empresa_ID
AND		Estacion_ID = @Estacion_ID

SET	@InventarioTotal = ISNULL(@InventarioTotal,0)

SELECT	@InventarioTotal = @InventarioTotal - ISNULL(SUM(OSR.Cantidad - OSR.RefSurtidas),0)
FROM	OrdenesServiciosRefacciones OSR
INNER JOIN	OrdenesServicios OS
ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID
INNER JOIN	OrdenesTrabajos OT
ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID
WHERE	OSR.Cantidad > OSR.RefSurtidas
AND	OT.EstatusOrdenTrabajo_ID NOT IN (3,4,5)
AND		OSR.Refaccion_ID = @Refaccion_ID
AND		OT.Empresa_ID = @Empresa_ID
AND		OT.Estacion_ID = @Estacion_ID

SELECT	@InventarioTotal as InventarioTotal