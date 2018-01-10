select	table_name
from information_schema.tables
where table_type = 'BASE TABLE'
and	table_name not like 'Temp%'
and	table_name not like 'sysdiagrams'
order by table_name

select * from ComisionesServicios


select	TABLE_NAME Tabla, 
		COLUMN_NAME Columna, 
		CASE IS_NULLABLE 
		WHEN 'YES' THEN 'Si'
		ELSE 'No'
		END AS Permite_Nulos, 
		case DATA_TYPE
		WHEN 'int' THEN 'Entero'
		WHEN 'varchar' THEN 'Texto'
		WHEN 'money' THEN 'Decimal'
		WHEN 'bit' THEN 'Si/No'
		WHEN 'datetime' THEN 'Fecha'
		WHEN 'ntext' THEN 'Texto Extenso'
		WHEN 'char' THEN 'Texto Fijo'
		WHEN 'varbinary' THEN 'Binario'
		else DATA_TYPE
		END Tipo_Dato,
		CHARACTER_MAXIMUM_LENGTH Longitud,
		'' Descripcion
from information_schema.columns
where table_name not like 'Temp%'
and	table_name not like 'sysdiagrams'
and table_name not in
(
'Arrendamientos',
'AyudasOpciones',
'Boletines',
'Boletines_Usuarios',
'CuentaEmpresas',
'CuentaUnidades',
'EstatusFacturas',
'EstatusFinancieros',
'Facturas',
'FlotillaDiaria',
'FlotillaInactivaDiaria',
'FuncionesAgregado',
'Indicadores',
'Periodos',
'RegistroIndicadores',
'ReportesIndicadores',
'SQLErrorLog',
'StatusFinancieros',
'TiposClientesTaller',
'TiposCuentas',
'TiposReportes',
'VariablesNegocio'
)
order by table_name, ordinal_position

SELECT
K_Table = FK.TABLE_NAME,
FK_Column = CU.COLUMN_NAME,
PK_Table = PK.TABLE_NAME,
PK_Column = PT.COLUMN_NAME,
Constraint_Name = C.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
INNER JOIN (
SELECT i1.TABLE_NAME, i2.COLUMN_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
) PT ON PT.TABLE_NAME = PK.TABLE_NAME
AND FK.TABLE_NAME not like 'Temp%'
and	FK.TABLE_NAME not like 'sysdiagrams'
and FK.TABLE_NAME not in
(
'Arrendamientos',
'AyudasOpciones',
'Boletines',
'Boletines_Usuarios',
'CuentaEmpresas',
'CuentaUnidades',
'EstatusFacturas',
'EstatusFinancieros',
'Facturas',
'FlotillaDiaria',
'FlotillaInactivaDiaria',
'FuncionesAgregado',
'Indicadores',
'Periodos',
'RegistroIndicadores',
'ReportesIndicadores',
'SQLErrorLog',
'StatusFinancieros',
'TiposClientesTaller',
'TiposCuentas',
'TiposReportes',
'VariablesNegocio'
)
ORDER BY K_Table, PK_Table
