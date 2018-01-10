USE [SICASTest]
GO

/****** Object:  Table [dbo].[Unidades_Kilometrajes]    Script Date: 03/22/2013 12:09:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Temp_Unidades_Kilometrajes](
	[Unidad_Kilometraje_ID] [int] NOT NULL,
	[Unidad_ID] [int] NOT NULL,
	[Conductor_ID] [int] NULL,
	[Kilometraje] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Temp_Unidades_Kilometrajes] PRIMARY KEY CLUSTERED 
(
	[Unidad_Kilometraje_ID] ASC
) 
)

GO

INSERT [Temp_Unidades_Kilometrajes]
SELECT	*
FROM	Unidades_Kilometrajes

GO


select top 100 * from unidades_kilometrajes
order by fecha desc

select * from unidades_kilometrajes
where unidad_id = 32426
