
USE [SICASSync]
GO
CREATE NONCLUSTERED INDEX IDX_CuentaConductores_Cuenta_Fecha
ON [dbo].[CuentaConductores] ([Cuenta_ID],[Fecha])
INCLUDE ([Unidad_ID],[Abono])
GO

USE [SICASSync]
GO
CREATE NONCLUSTERED INDEX IDX_OT_Estatus_Fecha
ON [dbo].[OrdenesTrabajos] ([EstatusOrdenTrabajo_ID],[FechaTerminacion])
INCLUDE ([Unidad_ID],[Subtotal])
GO