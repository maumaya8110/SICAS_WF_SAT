/* Catalogo de tipos de Atención a Clientes */
CREATE TABLE TiposAtencionClientes (
	TipoAtencionCliente_ID int identity not null, /* El ID*/
	Nombre varchar(30) not null, /* El Nombre */
	CONSTRAINT PK_TiposAtencionClientes
	PRIMARY KEY ( TipoAtencionCliente_ID )
)
GO

 /* Inserción de tipos de atención a clientes 
	INCIDENCIA,
	CORTESIA,
	OBJETO EXTRAVIADO
	REEMBOLSO
	La lógica de negocios depende de ellos,
	el catálogo debe estar cerrado
 */
INSERT INTO TiposAtencionClientes VALUES 
( 'INCIDENCIA' ), ( 'CORTESIA' ), ( 'OBJETO EXTRAVIADO' ), ( 'REEMBOLSO' )
GO

/*
	El catálogo de tipos de incidencias
*/
CREATE TABLE TiposIncidencias (
	TipoIncidencia_ID int identity not null, /* El ID, identidad */
	Nombre varchar(30) not null, /* El nombre */
	CONSTRAINT PK_TiposIncidencias
	PRIMARY KEY ( TipoIncidencia_ID )
)
GO

/* La inserción de los tipos de incidencias:
	El catálogo debe estar abierto, por si necesitan más
*/
INSERT INTO TiposIncidencias VALUES
( 'CARRERA EN 4' ), ( 'CONDUCTOR DESCORTES' )
GO

/* El catálogo de Atención a Clientes */
CREATE TABLE AtencionClientes (
	AtencionCliente_ID int identity not null, -- El ID, Identidad, Folio Autonumérico
	TipoAtencionCliente_ID int not null, -- EL tipo de la operación
	TipoIncidencia_ID int null, -- El tipo de incidencia, en caso de que la atención sea por incidencia
	Empresa_ID int not null, -- La empresa a la cual pertenece la unidad
	Estacion_ID int not null, -- La estación a la cual pertenece la unidad
	Conductor_ID int not null, -- El conductor que tiene actualmente la unidad
	Unidad_ID int not null, -- El ID de la unidad
	Usuario_ID varchar(30) not null, -- El Usuario que captura
	NumeroConfirmacion varchar(10) not null, -- El Número de Confirmación del TaxiMan
	FechaInicial datetime not null,	-- La fecha de captura
	FechaFinal datetime null, /* La fecha en que se termina la operación
								puede ser de Cierre, de Entrega o de Ejecución,
								dependiendo del tipo de la atención a clientes,
								es lo mismos
								*/
	Motivo varchar(250) null, -- El motivo general (cortesia, reembolso)
	EsEntregado bit null, -- General, objeto extraviado, reembolso, cortesia
	
	/* EMPIEZA INCIDENCIAS */	
	Solucion varchar(250) null,	-- La solución que se le dá al cliente	
	/* TERMINA INCIDENCIAS*/
	
	/* EMPIEZA CORTESIAS */	
	AtencionClienteIncidencia_ID int null,	-- El ID de la incidencia
											-- Debe estar relacionado con esta misma tabla
											-- En un registro que sea del tipo incidencia
	FolioCortesia varchar(10) null,	-- El folío de la cortesía		
	FechaVencimiento datetime null, -- La fecha de vencimiento de la cortesía
	/* TERMINA CORTESIAS */
	
	/* EMPIEZA OBJETOS EXTRAVIADOS */
	ObjetoExtraviado varchar(50) null, -- El objeto extraviado
	Observaciones varchar(250) null, -- Las soluciones
	/* TERMINA OBJETOS EXTRAVIADOS */
	
	/* EMPIEZA REEMBOLSOS */	
	MontoCargo money null, -- El monto de cargo	
	EsAutorizadoReembolso bit null, -- Si es o nó autorizado el reembolso	
	FechaAutorizacionReembolso datetime null, -- La recha de autorización del reembolso	
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
	/* Autorelación para las cortesías - incidencias */
	CONSTRAINT FK_AtencionClientes_AtencionClientes
	FOREIGN KEY ( AtencionClienteIncidencia_ID )
	REFERENCES AtencionClientes ( AtencionCliente_ID )
)
GO

select * from atencionclientes

