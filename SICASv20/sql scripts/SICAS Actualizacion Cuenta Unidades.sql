ALTER TABLE CuentaUnidades ALTER COLUMN Caja_ID int null
GO

ALTER TABLE CuentaUnidades ALTER COLUMN Conductor_ID int null
GO

ALTER TABLE CuentaUnidades ALTER COLUMN Ticket_ID int null
GO

INSERT	CuentaUnidades
SELECT	Empresa_ID, 
		Estacion_ID, 
		Unidad_ID, 
		Conductor_ID, 
		Caja_ID,
		Ticket_ID, 
		Cuenta_ID, 
		Concepto_ID,
		Cargo,
		Abono,
		0 Saldo,
		Comentarios,
		Fecha,
		Usuario_ID
FROM	CuentaConductores
WHERE	Unidad_ID IS NOT NULL
AND		Abono > 0
ORDER BY	Fecha
GO

ALTER TABLE CuentaUnidades ADD OrdenTrabajo_ID int null
GO

ALTER TABLE CuentaUnidades 
ADD CONSTRAINT FK_CuentaUnidades_OrdenesTrabajo
FOREIGN KEY ( OrdenTrabajo_ID )
REFERENCES OrdenesTrabajos ( OrdenTrabajo_ID )
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE CuentaUnidades ALTER COLUMN Comentarios varchar(250) null
GO

--	FALTAN LOS CONDUCTORES,
--	PODEMOS OBTENERLOS DEL UNIDADES KILOMETRAJES
--	FALTARIA ACTUALIZAR LAS UNIDADES KILOMETRAJES

INSERT	CuentaUnidades
SELECT	U.Empresa_ID,
		U.Estacion_ID,
		U.Unidad_ID,
		NULL Conductor_ID,
		NULL Caja_ID,
		NULL Ticket_ID,
		4 Cuenta_ID,
		3 Concepto_ID,
		OT.Total Cargo,
		0 Abono,
		0 Saldo, 
		OT.Comentarios,
		OT.FechaTerminacion,
		OT.Usuario_ID,
		OT.OrdenTrabajo_ID
FROM	OrdenesTrabajos OT
INNER JOIN	Unidades U
ON		OT.Unidad_ID = U.Unidad_ID
WHERE	OT.Unidad_ID IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID IN (3,4)
AND		OT.FechaTerminacion IS NOT NULL
GO

-- Agregar OrdenTrabajo_ID como referencia
--	Actualizar Saldo
-- Consultar el saldo
UPDATE	CuentaUnidades
SET		Saldo = 
		(	SELECT	ISNULL(SUM(Abono - Cargo),0)
			FROM	CuentaUnidades CU
			WHERE	CU.Unidad_ID = CUC.Unidad_ID
			AND		CU.Empresa_ID = CUC.Empresa_ID
			AND		CU.Cuenta_ID = CUC.Cuenta_ID
			AND		CU.CuentaUnidad_ID <= CUC.CuentaUnidad_ID
		)
FROM	CuentaUnidades CUC
GO

select * from cuentaunidades
where unidad_id = 2532
order by fecha
/*
SELECT	DISTINCT U.Empresa_ID		
FROM	OrdenesTrabajos OT
INNER JOIN	Unidades U
ON		OT.Unidad_ID = U.Unidad_ID
WHERE	OT.Unidad_ID IS NOT NULL
AND		OT.EstatusOrdenTrabajo_ID IN (3,4)
AND		OT.FechaTerminacion IS NOT NULL

-- actualizar correctamente las empresas en las ordenes de trabajo
*/

DECLARE	@Unidad_ID int, @Empresa_ID int, @Cuenta_ID int, @FechaInicial datetime, @FechaFinal datetime
SET	@Unidad_ID = 2532

SELECT	CU.CuentaUnidad_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		U.Unidad_ID,
		U.NumeroEconomico Unidad,
		CO.Apellidos + ' ' + CO.Nombre Conductor,
		CA.Nombre Caja,
		CU.Ticket_ID,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CU.Cargo,
		CU.Abono,
		CU.Saldo,
		CU.Comentarios,
		CU.Fecha,
		CU.Usuario_ID,
		CU.OrdenTrabajo_ID
FROM	CuentaUnidades CU
INNER JOIN	Unidades U
ON		CU.Unidad_ID = U.Unidad_ID
INNER JOIN	Empresas E
ON		CU.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		CU.Estacion_ID = EST.Estacion_ID
LEFT JOIN	Conductores CO
ON		CU.Conductor_ID = CO.Conductor_ID
LEFT JOIN	Cajas CA
ON		CU.Caja_ID = CA.Caja_ID
INNER JOIN	Cuentas C
ON		CU.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Conceptos CON
ON		CU.Concepto_ID = CON.Concepto_ID
WHERE	( @Unidad_ID IS NULL OR CU.Unidad_ID = @Unidad_ID )
AND		( @Empresa_ID IS NULL OR CU.Empresa_ID = @Empresa_ID )
AND		( @Cuenta_ID IS NULL OR CU.Cuenta_ID = @Cuenta_ID )
AND		( ( @FechaInicial IS NULL OR @FechaFinal IS NULL )
			OR	( CU.Fecha BETWEEN @FechaInicial AND @FechaFinal ) )


		
		select * from opciones
		where nombre like '%unidad%'
		select * from modulos
		select * from menues
		
		select * from conceptos
		
select top 10 * from cuentaunidades
order by fecha desc

select top 10 * from ordenestrabajos
order by fechaalta desc