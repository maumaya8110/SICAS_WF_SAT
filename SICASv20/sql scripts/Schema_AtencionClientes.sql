/* Catalogo de tipos de Atenci�n a Clientes */
CREATE TABLE TiposAtencionClientes (
	TipoAtencionCliente_ID int identity not null, /* El ID*/
	Nombre varchar(30) not null, /* El Nombre */
	CONSTRAINT PK_TiposAtencionClientes
	PRIMARY KEY ( TipoAtencionCliente_ID )
)
GO

 /* Inserci�n de tipos de atenci�n a clientes 
	INCIDENCIA,
	CORTESIA,
	OBJETO EXTRAVIADO
	REEMBOLSO
	La l�gica de negocios depende de ellos,
	el cat�logo debe estar cerrado
 */
INSERT INTO TiposAtencionClientes VALUES 
( 'INCIDENCIA' ), ( 'CORTESIA' ), ( 'OBJETO EXTRAVIADO' ), ( 'REEMBOLSO' )
GO

/*
	El cat�logo de tipos de incidencias
*/
CREATE TABLE TiposIncidencias (
	TipoIncidencia_ID int identity not null, /* El ID, identidad */
	Nombre varchar(30) not null, /* El nombre */
	CONSTRAINT PK_TiposIncidencias
	PRIMARY KEY ( TipoIncidencia_ID )
)
GO

/* La inserci�n de los tipos de incidencias:
	El cat�logo debe estar abierto, por si necesitan m�s
*/
INSERT INTO TiposIncidencias VALUES
( 'CARRERA EN 4' ), ( 'CONDUCTOR DESCORTES' )
GO

/* El cat�logo de Atenci�n a Clientes */
CREATE TABLE AtencionClientes (
	AtencionCliente_ID int identity not null, -- El ID, Identidad, Folio Autonum�rico
	TipoAtencionCliente_ID int not null, -- EL tipo de la operaci�n
	TipoIncidencia_ID int null, -- El tipo de incidencia, en caso de que la atenci�n sea por incidencia
	Empresa_ID int not null, -- La empresa a la cual pertenece la unidad
	Estacion_ID int not null, -- La estaci�n a la cual pertenece la unidad
	Conductor_ID int not null, -- El conductor que tiene actualmente la unidad
	Unidad_ID int not null, -- El ID de la unidad
	Usuario_ID varchar(30) not null, -- El Usuario que captura
	NumeroConfirmacion varchar(10) not null, -- El N�mero de Confirmaci�n del TaxiMan
	FechaInicial datetime not null,	-- La fecha de captura
	FechaFinal datetime null, /* La fecha en que se termina la operaci�n
								puede ser de Cierre, de Entrega o de Ejecuci�n,
								dependiendo del tipo de la atenci�n a clientes,
								es lo mismos
								*/
	Motivo varchar(250) null, -- El motivo general (cortesia, reembolso)
	EsEntregado bit null, -- General, objeto extraviado, reembolso, cortesia
	
	/* EMPIEZA INCIDENCIAS */	
	Solucion varchar(250) null,	-- La soluci�n que se le d� al cliente	
	/* TERMINA INCIDENCIAS*/
	
	/* EMPIEZA CORTESIAS */	
	AtencionClienteIncidencia_ID int null,	-- El ID de la incidencia
											-- Debe estar relacionado con esta misma tabla
											-- En un registro que sea del tipo incidencia
	FolioCortesia varchar(10) null,	-- El fol�o de la cortes�a		
	FechaVencimiento datetime null, -- La fecha de vencimiento de la cortes�a
	/* TERMINA CORTESIAS */
	
	/* EMPIEZA OBJETOS EXTRAVIADOS */
	ObjetoExtraviado varchar(50) null, -- El objeto extraviado
	Observaciones varchar(250) null, -- Las soluciones
	/* TERMINA OBJETOS EXTRAVIADOS */
	
	/* EMPIEZA REEMBOLSOS */	
	MontoCargo money null, -- El monto de cargo	
	EsAutorizadoReembolso bit null, -- Si es o n� autorizado el reembolso	
	FechaAutorizacionReembolso datetime null, -- La recha de autorizaci�n del reembolso	
	/* TERMINA REEMBOLSOS */
	
	CONSTRAINT PK_AtencionClientes
	PRIMARY KEY ( AtencionCliente_ID ),
	CONSTRAINT FK_AtencionClientes_TiposAtencionClientes
	FOREIGN KEY ( TipoAtencionCliente_ID )
	REFERENCES TiposAtencionClientes ( TipoAtencionCliente_ID )
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_AtencionClientes_TiposIncidencias
	FOREIGN KEY ( TipoIncidencia_ID )
	REFERENCES TiposIncidencias ( TipoIncidencia_ID )
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_AtencionClientes_Usuarios
	FOREIGN KEY ( Usuario_ID )
	REFERENCES Usuarios ( Usuario_ID )
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	/* Autorelaci�n para las cortes�as - incidencias */
	CONSTRAINT FK_AtencionClientes_AtencionClientes
	FOREIGN KEY ( AtencionClienteIncidencia_ID )
	REFERENCES AtencionClientes ( AtencionCliente_ID )
)
GO

select * from atencionclientes

