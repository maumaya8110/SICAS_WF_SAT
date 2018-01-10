/*
	VistaCuentaCajas
	Creado el 31 de Octubre por Luis Espino
*/

DECLARE	@Empresa_ID int,
		@Estacion_ID int,
		@Usuario_ID varchar(30) = 'luis.escareño',
		@FechaInicial datetime = '2012-10-30',
		@FechaFinal datetime = '2012-10-31'

SELECT	CC.CuentaCaja_ID,
		T.Ticket_ID,
		CC.Sesion_ID,
		E.Nombre Empresa,
		EST.Nombre Estacion,
		CA.Nombre Caja,
		C.Nombre Cuenta,
		CON.Nombre Concepto,
		CC.Cargo,
		CC.Abono,
		CC.Saldo,
		CC.Comentarios,		
		CC.Fecha,
		CC.Usuario_ID
FROM	CuentaCajas CC
INNER JOIN	Tickets T
ON		CC.Ticket_ID = T.Ticket_ID
INNER JOIN	Cuentas C
ON		CC.Cuenta_ID = C.Cuenta_ID
INNER JOIN	Empresas E
ON		CC.Empresa_ID = E.Empresa_ID
INNER JOIN	Estaciones EST
ON		CC.Estacion_ID = EST.Estacion_ID
INNER JOIN	Cajas CA
ON		CC.Caja_ID = CA.Caja_ID
LEFT JOIN	Conceptos CON
ON		CC.Concepto_ID = CON.Concepto_ID
WHERE	( CC.Empresa_ID IN ( SELECT Empresa_ID FROM Usuarios_Empresas WHERE Usuario_ID = @Usuario_ID ) )
AND		( CC.Estacion_ID IN ( SELECT Estacion_ID FROM Usuarios_Estaciones WHERE Usuario_ID = @Usuario_ID ) )
AND		( @Empresa_ID IS NULL OR CC.Empresa_ID = @Empresa_ID )
AND     ( @Estacion_ID IS NULL OR CC.Estacion_ID = @Estacion_ID )
AND		( CC.Fecha BETWEEN @FechaInicial AND @FechaFinal )