/*
	**  HISTORIAL  **
	2012-10-23	-	Modificado	-	Luis Espino
		Se agrega la columna Empresa_ID a la tabla PlanillasFiscales
		con su restricci�n
*/

USE SICASSync
GO


ALTER TABLE Estaciones 
DROP CONSTRAINT FK_Estaciones_Empresas
GO

ALTER TABLE Estaciones
DROP COLUMN Empresa_ID
GO

ALTER TABLE Sesiones
DROP CONSTRAINT FK_Sesiones_Empresas
GO

ALTER TABLE Sesiones
DROP COLUMN Empresa_ID
GO

-- Las planillas fiscales

-- Agregamos la columna Empresa_ID
ALTER TABLE PlanillasFiscales
ADD Empresa_ID int
GO

-- Agregamos la restrucci�n
ALTER TABLE PlanillasFiscales
ADD CONSTRAINT FK_PlanillasFiscales
FOREIGN KEY ( Empresa_ID )
REFERENCES Empresas ( Empresa_ID )
ON UPDATE CASCADE
ON DELETE CASCADE
GO

-- Actualizamos todas a CAM
UPDATE	PlanillasFiscales
SET		Empresa_ID = 2
GO

-- Actualizamos la columna a "NOT NULL"
ALTER TABLE PlanillasFiscales
ALTER COLUMN Empresa_ID int not null
GO

--	Eliminamos la restricci�n principal
ALTER TABLE			PlanillasFiscales
DROP CONSTRAINT		PK_PlanillasFiscales
GO

--	Creamos de nuevo la restricci�n
--	con el campo de Empresa_ID
ALTER TABLE		PlanillasFiscales
ADD CONSTRAINT	PK_PlanillasFiscales
PRIMARY KEY		( Empresa_ID, Estacion_ID, Serie, Folio )
GO
