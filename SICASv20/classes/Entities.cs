using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace SICASv20.Entities
{

	#region InformationSchema

	public class InformationSchemaColumns
	{

		#region Constructors
		public InformationSchemaColumns()
		{
		}

		public InformationSchemaColumns(
		    System.String table_catalog,
		    System.String table_schema,
		    System.String table_name,
		    System.String column_name,
		    System.Int32 ordinal_position,
		    System.String column_default,
		    System.String is_nullable,
		    System.String data_type,
		    System.Int32? character_maximum_length,
		    System.Int32? character_octet_length,
		    System.Int32? numeric_precision,
		    System.Int32? numeric_precision_radix,
		    System.Int32? numeric_scale,
		    System.Int32? datetime_precision,
		    System.String character_set_catalog,
		    System.String character_set_schema,
		    System.String character_set_name,
		    System.String collation_catalog,
		    System.String collation_schema,
		    System.String collation_name,
		    System.String domain_catalog,
		    System.String domain_schema,
		    System.String domain_name
		    )
		{
			this.TABLE_CATALOG = table_catalog;
			this.TABLE_SCHEMA = table_schema;
			this.TABLE_NAME = table_name;
			this.COLUMN_NAME = column_name;
			this.ORDINAL_POSITION = ordinal_position;
			this.COLUMN_DEFAULT = column_default;
			this.IS_NULLABLE = is_nullable;
			this.DATA_TYPE = data_type;
			this.CHARACTER_MAXIMUM_LENGTH = character_maximum_length;
			this.CHARACTER_OCTET_LENGTH = character_octet_length;
			this.NUMERIC_PRECISION = numeric_precision;
			this.NUMERIC_PRECISION_RADIX = numeric_precision_radix;
			this.NUMERIC_SCALE = numeric_scale;
			this.DATETIME_PRECISION = datetime_precision;
			this.CHARACTER_SET_CATALOG = character_set_catalog;
			this.CHARACTER_SET_SCHEMA = character_set_schema;
			this.CHARACTER_SET_NAME = character_set_name;
			this.COLLATION_CATALOG = collation_catalog;
			this.COLLATION_SCHEMA = collation_schema;
			this.COLLATION_NAME = collation_name;
			this.DOMAIN_CATALOG = domain_catalog;
			this.DOMAIN_SCHEMA = domain_schema;
			this.DOMAIN_NAME = domain_name;
		}

		#endregion

		#region Properties
		private System.String _TABLE_CATALOG;
		public System.String TABLE_CATALOG
		{
			get { return _TABLE_CATALOG; }
			set { _TABLE_CATALOG = value; }
		}

		private System.String _TABLE_SCHEMA;
		public System.String TABLE_SCHEMA
		{
			get { return _TABLE_SCHEMA; }
			set { _TABLE_SCHEMA = value; }
		}

		private System.String _TABLE_NAME;
		public System.String TABLE_NAME
		{
			get { return _TABLE_NAME; }
			set { _TABLE_NAME = value; }
		}

		private System.String _COLUMN_NAME;
		public System.String COLUMN_NAME
		{
			get { return _COLUMN_NAME; }
			set { _COLUMN_NAME = value; }
		}

		private System.Int32 _ORDINAL_POSITION;
		public System.Int32 ORDINAL_POSITION
		{
			get { return _ORDINAL_POSITION; }
			set { _ORDINAL_POSITION = value; }
		}

		private System.String _COLUMN_DEFAULT;
		public System.String COLUMN_DEFAULT
		{
			get { return _COLUMN_DEFAULT; }
			set { _COLUMN_DEFAULT = value; }
		}

		private System.String _IS_NULLABLE;
		public System.String IS_NULLABLE
		{
			get { return _IS_NULLABLE; }
			set { _IS_NULLABLE = value; }
		}

		private System.String _DATA_TYPE;
		public System.String DATA_TYPE
		{
			get { return _DATA_TYPE; }
			set { _DATA_TYPE = value; }
		}

		private System.Int32? _CHARACTER_MAXIMUM_LENGTH;
		public System.Int32? CHARACTER_MAXIMUM_LENGTH
		{
			get { return _CHARACTER_MAXIMUM_LENGTH; }
			set { _CHARACTER_MAXIMUM_LENGTH = value; }
		}

		private System.Int32? _CHARACTER_OCTET_LENGTH;
		public System.Int32? CHARACTER_OCTET_LENGTH
		{
			get { return _CHARACTER_OCTET_LENGTH; }
			set { _CHARACTER_OCTET_LENGTH = value; }
		}

		private System.Int32? _NUMERIC_PRECISION;
		public System.Int32? NUMERIC_PRECISION
		{
			get { return _NUMERIC_PRECISION; }
			set { _NUMERIC_PRECISION = value; }
		}

		private System.Int32? _NUMERIC_PRECISION_RADIX;
		public System.Int32? NUMERIC_PRECISION_RADIX
		{
			get { return _NUMERIC_PRECISION_RADIX; }
			set { _NUMERIC_PRECISION_RADIX = value; }
		}

		private System.Int32? _NUMERIC_SCALE;
		public System.Int32? NUMERIC_SCALE
		{
			get { return _NUMERIC_SCALE; }
			set { _NUMERIC_SCALE = value; }
		}

		private System.Int32? _DATETIME_PRECISION;
		public System.Int32? DATETIME_PRECISION
		{
			get { return _DATETIME_PRECISION; }
			set { _DATETIME_PRECISION = value; }
		}

		private System.String _CHARACTER_SET_CATALOG;
		public System.String CHARACTER_SET_CATALOG
		{
			get { return _CHARACTER_SET_CATALOG; }
			set { _CHARACTER_SET_CATALOG = value; }
		}

		private System.String _CHARACTER_SET_SCHEMA;
		public System.String CHARACTER_SET_SCHEMA
		{
			get { return _CHARACTER_SET_SCHEMA; }
			set { _CHARACTER_SET_SCHEMA = value; }
		}

		private System.String _CHARACTER_SET_NAME;
		public System.String CHARACTER_SET_NAME
		{
			get { return _CHARACTER_SET_NAME; }
			set { _CHARACTER_SET_NAME = value; }
		}

		private System.String _COLLATION_CATALOG;
		public System.String COLLATION_CATALOG
		{
			get { return _COLLATION_CATALOG; }
			set { _COLLATION_CATALOG = value; }
		}

		private System.String _COLLATION_SCHEMA;
		public System.String COLLATION_SCHEMA
		{
			get { return _COLLATION_SCHEMA; }
			set { _COLLATION_SCHEMA = value; }
		}

		private System.String _COLLATION_NAME;
		public System.String COLLATION_NAME
		{
			get { return _COLLATION_NAME; }
			set { _COLLATION_NAME = value; }
		}

		private System.String _DOMAIN_CATALOG;
		public System.String DOMAIN_CATALOG
		{
			get { return _DOMAIN_CATALOG; }
			set { _DOMAIN_CATALOG = value; }
		}

		private System.String _DOMAIN_SCHEMA;
		public System.String DOMAIN_SCHEMA
		{
			get { return _DOMAIN_SCHEMA; }
			set { _DOMAIN_SCHEMA = value; }
		}

		private System.String _DOMAIN_NAME;
		public System.String DOMAIN_NAME
		{
			get { return _DOMAIN_NAME; }
			set { _DOMAIN_NAME = value; }
		}

		#endregion

		#region Methods

		public static List<InformationSchemaColumns> Get(string tableName)
		{
			string sqlstr = @"SELECT * FROM Information_Schema.Columns WHERE TABLE_NAME = @TABLE_NAME";

			List<InformationSchemaColumns> list = new List<InformationSchemaColumns>();
			DataTable dt =
			    DB.QueryCommand(
				   sqlstr,
				   DB.GetParams(
				   DB.Param("@TABLE_NAME", tableName)
			    )
			);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new InformationSchemaColumns(
					   Convert.ToString(dr["TABLE_CATALOG"]),
					   Convert.ToString(dr["TABLE_SCHEMA"]),
					   Convert.ToString(dr["TABLE_NAME"]),
					   Convert.ToString(dr["COLUMN_NAME"]),
					   Convert.ToInt32(dr["ORDINAL_POSITION"]),
					   Convert.ToString(dr["COLUMN_DEFAULT"]),
					   Convert.ToString(dr["IS_NULLABLE"]),
					   Convert.ToString(dr["DATA_TYPE"]),
					   DB.GetNullableInt32(dr["CHARACTER_MAXIMUM_LENGTH"]),
					   DB.GetNullableInt32(dr["CHARACTER_OCTET_LENGTH"]),
					   DB.GetNullableInt32(dr["NUMERIC_PRECISION"]),
					   DB.GetNullableInt32(dr["NUMERIC_PRECISION_RADIX"]),
					   DB.GetNullableInt32(dr["NUMERIC_SCALE"]),
					   DB.GetNullableInt32(dr["DATETIME_PRECISION"]),
					   Convert.ToString(dr["CHARACTER_SET_CATALOG"]),
					   Convert.ToString(dr["CHARACTER_SET_SCHEMA"]),
					   Convert.ToString(dr["CHARACTER_SET_NAME"]),
					   Convert.ToString(dr["COLLATION_CATALOG"]),
					   Convert.ToString(dr["COLLATION_SCHEMA"]),
					   Convert.ToString(dr["COLLATION_NAME"]),
					   Convert.ToString(dr["DOMAIN_CATALOG"]),
					   Convert.ToString(dr["DOMAIN_SCHEMA"]),
					   Convert.ToString(dr["DOMAIN_NAME"])
					   )
				    );
			}
			return list;
		} // End GetData

		public static List<InformationSchemaColumns> Get()
		{
			string sqlstr = @"SELECT * FROM Information_Schema.Columns";

			List<InformationSchemaColumns> list = new List<InformationSchemaColumns>();
			DataTable dt = DB.Query(sqlstr);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new InformationSchemaColumns(
					   Convert.ToString(dr["TABLE_CATALOG"]),
					   Convert.ToString(dr["TABLE_SCHEMA"]),
					   Convert.ToString(dr["TABLE_NAME"]),
					   Convert.ToString(dr["COLUMN_NAME"]),
					   Convert.ToInt32(dr["ORDINAL_POSITION"]),
					   Convert.ToString(dr["COLUMN_DEFAULT"]),
					   Convert.ToString(dr["IS_NULLABLE"]),
					   Convert.ToString(dr["DATA_TYPE"]),
					   DB.GetNullableInt32(dr["CHARACTER_MAXIMUM_LENGTH"]),
					   DB.GetNullableInt32(dr["CHARACTER_OCTET_LENGTH"]),
					   DB.GetNullableInt32(dr["NUMERIC_PRECISION"]),
					   DB.GetNullableInt32(dr["NUMERIC_PRECISION_RADIX"]),
					   DB.GetNullableInt32(dr["NUMERIC_SCALE"]),
					   DB.GetNullableInt32(dr["DATETIME_PRECISION"]),
					   Convert.ToString(dr["CHARACTER_SET_CATALOG"]),
					   Convert.ToString(dr["CHARACTER_SET_SCHEMA"]),
					   Convert.ToString(dr["CHARACTER_SET_NAME"]),
					   Convert.ToString(dr["COLLATION_CATALOG"]),
					   Convert.ToString(dr["COLLATION_SCHEMA"]),
					   Convert.ToString(dr["COLLATION_NAME"]),
					   Convert.ToString(dr["DOMAIN_CATALOG"]),
					   Convert.ToString(dr["DOMAIN_SCHEMA"]),
					   Convert.ToString(dr["DOMAIN_NAME"])
					   )
				    );
			}
			return list;
		} // End GetData

		public static DataTable GetDataTable()
		{
			string sqlstr = @"SELECT * FROM Information_Schema.Columns";

			return DB.Query(sqlstr);
		} // End GetDataTable


		#endregion
	} // End Class InformationSchemaColumns

	#endregion

	public class AjustesInventario
	{

		#region Constructors

		public AjustesInventario()
		{
		}

		public AjustesInventario(
		    int ajusteinventario_id,
		    int tipoajusteinventario_id,
		    int refaccion_id,
		    string usuario_id,
		    int cantidad,
		    decimal costounitario,
		    decimal total,
		    DateTime fecha,
		    string comentarios,
		    int empresa_id,
		    int estacion_id)
		{
			this.AjusteInventario_ID = ajusteinventario_id;
			this.TipoAjusteInventario_ID = tipoajusteinventario_id;
			this.Refaccion_ID = refaccion_id;
			this.Usuario_ID = usuario_id;
			this.Cantidad = cantidad;
			this.CostoUnitario = costounitario;
			this.Total = total;
			this.Fecha = fecha;
			this.Comentarios = comentarios;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _AjusteInventario_ID;
		public int AjusteInventario_ID
		{
			get { return _AjusteInventario_ID; }
			set { _AjusteInventario_ID = value; }
		}

		private int _TipoAjusteInventario_ID;
		public int TipoAjusteInventario_ID
		{
			get { return _TipoAjusteInventario_ID; }
			set { _TipoAjusteInventario_ID = value; }
		}

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		private decimal _CostoUnitario;
		public decimal CostoUnitario
		{
			get { return _CostoUnitario; }
			set { _CostoUnitario = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.TipoAjusteInventario_ID == 0) throw new Exception("TipoAjusteInventario_ID no puede ser nulo.");

			if (this.Refaccion_ID == 0) throw new Exception("Refaccion_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Cantidad == 0) throw new Exception("Cantidad no puede ser nulo.");

			if (this.CostoUnitario == 0) throw new Exception("CostoUnitario no puede ser nulo.");

			if (this.Total == 0) throw new Exception("Total no puede ser nulo.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Comentarios == null) throw new Exception("Comentarios no puede ser nulo.");

			if (this.Comentarios.Length > 255)
			{
				throw new Exception("Comentarios debe tener máximo 255 carateres.");
			}

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			int result = DB.InsertRow("AjustesInventario", m_params);
			this.AjusteInventario_ID = Convert.ToInt32(DB.Ident_Current("AjustesInventario"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
			m_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("AjustesInventario", m_params);
		} // End Create

		public static List<AjustesInventario> Read()
		{
			List<AjustesInventario> list = new List<AjustesInventario>();
			DataTable dt = DB.Select("AjustesInventario");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new AjustesInventario(
					   Convert.ToInt32(dr["AjusteInventario_ID"]),
					   Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Cantidad"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToDecimal(dr["Total"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Comentarios"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static AjustesInventario Read(int ajusteinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AjusteInventario_ID", ajusteinventario_id);
			DataTable dt = DB.Select("AjustesInventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe AjustesInventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new AjustesInventario(
			    Convert.ToInt32(dr["AjusteInventario_ID"]),
					  Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static AjustesInventario Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("AjustesInventario", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new AjustesInventario(
			    Convert.ToInt32(dr["AjusteInventario_ID"]),
					  Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out AjustesInventario ajustesinventario,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("AjustesInventario", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				ajustesinventario = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			ajustesinventario = new AjustesInventario(
			    Convert.ToInt32(dr["AjusteInventario_ID"]),
					  Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("AjustesInventario");
		} // End Read

		public static DataTable ReadDataTable(int ajusteinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AjusteInventario_ID", ajusteinventario_id);
			return DB.Select("AjustesInventario", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
			m_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("AjustesInventario", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);

			return DB.DeleteRow("AjustesInventario", w_params);
		} // End Delete


		#endregion
	} //End Class AjustesInventario

	public class Arrendamientos
	{
		public Arrendamientos()
		{

		}

		public Arrendamientos(int arrendamiento_id, string descripcion, int referencia, string catalogoreferencia, int arrendador_id, int arrendatario_id, decimal montoafinanciar, decimal valorfactura, int plazos, decimal mensualidad, decimal residual, decimal tasa, decimal amortizacionresidual, int estatusfinanciero_id, decimal montopagado, decimal saldo, int plazosrestantes, DateTime fechainicial, DateTime fechafinal, DateTime ultimafecha, DateTime proximafecha, bool activo, string comentarios)
		{
			this.Arrendamiento_ID = arrendamiento_id;
			this.Descripcion = descripcion;
			this.Referencia = referencia;
			this.CatalogoReferencia = catalogoreferencia;
			this.Arrendador_ID = arrendador_id;
			this.Arrendatario_ID = arrendatario_id;
			this.MontoAFinanciar = montoafinanciar;
			this.ValorFactura = valorfactura;
			this.Plazos = plazos;
			this.Mensualidad = mensualidad;
			this.Residual = residual;
			this.Tasa = tasa;
			this.AmortizacionResidual = amortizacionresidual;
			this.EstatusFinanciero_ID = estatusfinanciero_id;
			this.MontoPagado = montopagado;
			this.Saldo = saldo;
			this.PlazosRestantes = plazosrestantes;
			this.FechaInicial = fechainicial;
			this.FechaFinal = fechafinal;
			this.UltimaFecha = ultimafecha;
			this.ProximaFecha = proximafecha;
			this.Activo = activo;
			this.Comentarios = comentarios;
		}

		private int _Arrendamiento_ID;
		public int Arrendamiento_ID
		{
			get { return _Arrendamiento_ID; }
			set { _Arrendamiento_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private int _Referencia;
		public int Referencia
		{
			get { return _Referencia; }
			set { _Referencia = value; }
		}

		private string _CatalogoReferencia;
		public string CatalogoReferencia
		{
			get { return _CatalogoReferencia; }
			set { _CatalogoReferencia = value; }
		}

		private int _Arrendador_ID;
		public int Arrendador_ID
		{
			get { return _Arrendador_ID; }
			set { _Arrendador_ID = value; }
		}

		private int _Arrendatario_ID;
		public int Arrendatario_ID
		{
			get { return _Arrendatario_ID; }
			set { _Arrendatario_ID = value; }
		}

		private decimal _MontoAFinanciar;
		public decimal MontoAFinanciar
		{
			get { return _MontoAFinanciar; }
			set { _MontoAFinanciar = value; }
		}

		private decimal _ValorFactura;
		public decimal ValorFactura
		{
			get { return _ValorFactura; }
			set { _ValorFactura = value; }
		}

		private int _Plazos;
		public int Plazos
		{
			get { return _Plazos; }
			set { _Plazos = value; }
		}

		private decimal _Mensualidad;
		public decimal Mensualidad
		{
			get { return _Mensualidad; }
			set { _Mensualidad = value; }
		}

		private decimal _Residual;
		public decimal Residual
		{
			get { return _Residual; }
			set { _Residual = value; }
		}

		private decimal _Tasa;
		public decimal Tasa
		{
			get { return _Tasa; }
			set { _Tasa = value; }
		}

		private decimal _AmortizacionResidual;
		public decimal AmortizacionResidual
		{
			get { return _AmortizacionResidual; }
			set { _AmortizacionResidual = value; }
		}

		private int _EstatusFinanciero_ID;
		public int EstatusFinanciero_ID
		{
			get { return _EstatusFinanciero_ID; }
			set { _EstatusFinanciero_ID = value; }
		}

		private decimal _MontoPagado;
		public decimal MontoPagado
		{
			get { return _MontoPagado; }
			set { _MontoPagado = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private int _PlazosRestantes;
		public int PlazosRestantes
		{
			get { return _PlazosRestantes; }
			set { _PlazosRestantes = value; }
		}

		private DateTime _FechaInicial;
		public DateTime FechaInicial
		{
			get { return _FechaInicial; }
			set { _FechaInicial = value; }
		}

		private DateTime _FechaFinal;
		public DateTime FechaFinal
		{
			get { return _FechaFinal; }
			set { _FechaFinal = value; }
		}

		private DateTime _UltimaFecha;
		public DateTime UltimaFecha
		{
			get { return _UltimaFecha; }
			set { _UltimaFecha = value; }
		}

		private DateTime _ProximaFecha;
		public DateTime ProximaFecha
		{
			get { return _ProximaFecha; }
			set { _ProximaFecha = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Referencia", this.Referencia);
			m_params.Add("CatalogoReferencia", this.CatalogoReferencia);
			m_params.Add("Arrendador_ID", this.Arrendador_ID);
			m_params.Add("Arrendatario_ID", this.Arrendatario_ID);
			m_params.Add("MontoAFinanciar", this.MontoAFinanciar);
			m_params.Add("ValorFactura", this.ValorFactura);
			m_params.Add("Plazos", this.Plazos);
			m_params.Add("Mensualidad", this.Mensualidad);
			m_params.Add("Residual", this.Residual);
			m_params.Add("Tasa", this.Tasa);
			m_params.Add("AmortizacionResidual", this.AmortizacionResidual);
			m_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
			m_params.Add("MontoPagado", this.MontoPagado);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("PlazosRestantes", this.PlazosRestantes);
			m_params.Add("FechaInicial", this.FechaInicial);
			m_params.Add("FechaFinal", this.FechaFinal);
			m_params.Add("UltimaFecha", this.UltimaFecha);
			m_params.Add("ProximaFecha", this.ProximaFecha);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("Arrendamientos", m_params);
		} // End Create

		public static List<Arrendamientos> Read()
		{
			List<Arrendamientos> list = new List<Arrendamientos>();
			DataTable dt = DB.Select("Arrendamientos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Arrendamientos(Convert.ToInt32(dr["Arrendamiento_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Referencia"]), Convert.ToString(dr["CatalogoReferencia"]), Convert.ToInt32(dr["Arrendador_ID"]), Convert.ToInt32(dr["Arrendatario_ID"]), Convert.ToDecimal(dr["MontoAFinanciar"]), Convert.ToDecimal(dr["ValorFactura"]), Convert.ToInt32(dr["Plazos"]), Convert.ToDecimal(dr["Mensualidad"]), Convert.ToDecimal(dr["Residual"]), Convert.ToDecimal(dr["Tasa"]), Convert.ToDecimal(dr["AmortizacionResidual"]), Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToDecimal(dr["MontoPagado"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToInt32(dr["PlazosRestantes"]), Convert.ToDateTime(dr["FechaInicial"]), Convert.ToDateTime(dr["FechaFinal"]), Convert.ToDateTime(dr["UltimaFecha"]), Convert.ToDateTime(dr["ProximaFecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static List<Arrendamientos> Read(int arrendamiento_id)
		{
			List<Arrendamientos> list = new List<Arrendamientos>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Arrendamiento_ID", arrendamiento_id);
			DataTable dt = DB.Select("Arrendamientos", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Arrendamientos(Convert.ToInt32(dr["Arrendamiento_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Referencia"]), Convert.ToString(dr["CatalogoReferencia"]), Convert.ToInt32(dr["Arrendador_ID"]), Convert.ToInt32(dr["Arrendatario_ID"]), Convert.ToDecimal(dr["MontoAFinanciar"]), Convert.ToDecimal(dr["ValorFactura"]), Convert.ToInt32(dr["Plazos"]), Convert.ToDecimal(dr["Mensualidad"]), Convert.ToDecimal(dr["Residual"]), Convert.ToDecimal(dr["Tasa"]), Convert.ToDecimal(dr["AmortizacionResidual"]), Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToDecimal(dr["MontoPagado"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToInt32(dr["PlazosRestantes"]), Convert.ToDateTime(dr["FechaInicial"]), Convert.ToDateTime(dr["FechaFinal"]), Convert.ToDateTime(dr["UltimaFecha"]), Convert.ToDateTime(dr["ProximaFecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Referencia", this.Referencia);
			m_params.Add("CatalogoReferencia", this.CatalogoReferencia);
			m_params.Add("Arrendador_ID", this.Arrendador_ID);
			m_params.Add("Arrendatario_ID", this.Arrendatario_ID);
			m_params.Add("MontoAFinanciar", this.MontoAFinanciar);
			m_params.Add("ValorFactura", this.ValorFactura);
			m_params.Add("Plazos", this.Plazos);
			m_params.Add("Mensualidad", this.Mensualidad);
			m_params.Add("Residual", this.Residual);
			m_params.Add("Tasa", this.Tasa);
			m_params.Add("AmortizacionResidual", this.AmortizacionResidual);
			m_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
			m_params.Add("MontoPagado", this.MontoPagado);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("PlazosRestantes", this.PlazosRestantes);
			m_params.Add("FechaInicial", this.FechaInicial);
			m_params.Add("FechaFinal", this.FechaFinal);
			m_params.Add("UltimaFecha", this.UltimaFecha);
			m_params.Add("ProximaFecha", this.ProximaFecha);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("Arrendamientos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);

			return DB.DeleteRow("Arrendamientos", w_params);
		}

	} //End Class Arrendamientos

	public class AtencionClientes
	{

		#region Constructors

		public AtencionClientes()
		{
		}

		public AtencionClientes(
		    int atencioncliente_id,
		    int tipoatencioncliente_id,
		    int? tipoincidencia_id,
		    int empresa_id,
		    int estacion_id,
		    int conductor_id,
		    int unidad_id,
		    string usuario_id,
		    string numeroconfirmacion,
		    DateTime fechainicial,
		    DateTime? fechafinal,
		    string motivo,
		    bool? esentregado,
		    bool escerrado,
		    string solucion,
		    int? atencionclienteincidencia_id,
		    string foliocortesia,
		    DateTime? fechavencimiento,
		    string objetoextraviado,
		    string observaciones,
		    decimal? montocargo,
		    bool? esautorizadoreembolso,
		    DateTime? fechaautorizacionreembolso)
		{
			this.AtencionCliente_ID = atencioncliente_id;
			this.TipoAtencionCliente_ID = tipoatencioncliente_id;
			this.TipoIncidencia_ID = tipoincidencia_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Conductor_ID = conductor_id;
			this.Unidad_ID = unidad_id;
			this.Usuario_ID = usuario_id;
			this.NumeroConfirmacion = numeroconfirmacion;
			this.FechaInicial = fechainicial;
			this.FechaFinal = fechafinal;
			this.Motivo = motivo;
			this.EsEntregado = esentregado;
			this.EsCerrado = escerrado;
			this.Solucion = solucion;
			this.AtencionClienteIncidencia_ID = atencionclienteincidencia_id;
			this.FolioCortesia = foliocortesia;
			this.FechaVencimiento = fechavencimiento;
			this.ObjetoExtraviado = objetoextraviado;
			this.Observaciones = observaciones;
			this.MontoCargo = montocargo;
			this.EsAutorizadoReembolso = esautorizadoreembolso;
			this.FechaAutorizacionReembolso = fechaautorizacionreembolso;
		}

		#endregion

		#region Properties

		private int _AtencionCliente_ID;
		public int AtencionCliente_ID
		{
			get { return _AtencionCliente_ID; }
			set { _AtencionCliente_ID = value; }
		}

		private int _TipoAtencionCliente_ID;
		public int TipoAtencionCliente_ID
		{
			get { return _TipoAtencionCliente_ID; }
			set { _TipoAtencionCliente_ID = value; }
		}

		private int? _TipoIncidencia_ID;
		public int? TipoIncidencia_ID
		{
			get { return _TipoIncidencia_ID; }
			set { _TipoIncidencia_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private string _NumeroConfirmacion;
		public string NumeroConfirmacion
		{
			get { return _NumeroConfirmacion; }
			set { _NumeroConfirmacion = value; }
		}

		private DateTime _FechaInicial;
		public DateTime FechaInicial
		{
			get { return _FechaInicial; }
			set { _FechaInicial = value; }
		}

		private DateTime? _FechaFinal;
		public DateTime? FechaFinal
		{
			get { return _FechaFinal; }
			set { _FechaFinal = value; }
		}

		private string _Motivo;
		public string Motivo
		{
			get { return _Motivo; }
			set { _Motivo = value; }
		}

		private bool? _EsEntregado;
		public bool? EsEntregado
		{
			get { return _EsEntregado; }
			set { _EsEntregado = value; }
		}

		private bool _EsCerrado;
		public bool EsCerrado
		{
			get { return _EsCerrado; }
			set { _EsCerrado = value; }
		}

		private string _Solucion;
		public string Solucion
		{
			get { return _Solucion; }
			set { _Solucion = value; }
		}

		private int? _AtencionClienteIncidencia_ID;
		public int? AtencionClienteIncidencia_ID
		{
			get { return _AtencionClienteIncidencia_ID; }
			set { _AtencionClienteIncidencia_ID = value; }
		}

		private string _FolioCortesia;
		public string FolioCortesia
		{
			get { return _FolioCortesia; }
			set { _FolioCortesia = value; }
		}

		private DateTime? _FechaVencimiento;
		public DateTime? FechaVencimiento
		{
			get { return _FechaVencimiento; }
			set { _FechaVencimiento = value; }
		}

		private string _ObjetoExtraviado;
		public string ObjetoExtraviado
		{
			get { return _ObjetoExtraviado; }
			set { _ObjetoExtraviado = value; }
		}

		private string _Observaciones;
		public string Observaciones
		{
			get { return _Observaciones; }
			set { _Observaciones = value; }
		}

		private decimal? _MontoCargo;
		public decimal? MontoCargo
		{
			get { return _MontoCargo; }
			set { _MontoCargo = value; }
		}

		private bool? _EsAutorizadoReembolso;
		public bool? EsAutorizadoReembolso
		{
			get { return _EsAutorizadoReembolso; }
			set { _EsAutorizadoReembolso = value; }
		}

		private DateTime? _FechaAutorizacionReembolso;
		public DateTime? FechaAutorizacionReembolso
		{
			get { return _FechaAutorizacionReembolso; }
			set { _FechaAutorizacionReembolso = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.TipoAtencionCliente_ID == 0) throw new Exception("TipoAtencionCliente_ID no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.Conductor_ID == 0) throw new Exception("Conductor_ID no puede ser nulo.");

			if (this.Unidad_ID == 0) throw new Exception("Unidad_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.NumeroConfirmacion == null) throw new Exception("NumeroConfirmacion no puede ser nulo.");

			if (this.NumeroConfirmacion.Length > 10)
			{
				throw new Exception("NumeroConfirmacion debe tener máximo 10 carateres.");
			}

			if (this.FechaInicial == null) throw new Exception("FechaInicial no puede ser nulo.");

			if (this.Motivo.Length > 250)
			{
				throw new Exception("Motivo debe tener máximo 250 carateres.");
			}

			if (this.Solucion.Length > 250)
			{
				throw new Exception("Solucion debe tener máximo 250 carateres.");
			}

			if (this.FolioCortesia.Length > 10)
			{
				throw new Exception("FolioCortesia debe tener máximo 10 carateres.");
			}

			if (this.ObjetoExtraviado.Length > 50)
			{
				throw new Exception("ObjetoExtraviado debe tener máximo 50 carateres.");
			}

			if (this.Observaciones.Length > 250)
			{
				throw new Exception("Observaciones debe tener máximo 250 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);
			if (!DB.IsNullOrEmpty(this.TipoIncidencia_ID)) m_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("NumeroConfirmacion", this.NumeroConfirmacion);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.Motivo)) m_params.Add("Motivo", this.Motivo);
			if (!DB.IsNullOrEmpty(this.EsEntregado)) m_params.Add("EsEntregado", this.EsEntregado);
			m_params.Add("EsCerrado", this.EsCerrado);
			if (!DB.IsNullOrEmpty(this.Solucion)) m_params.Add("Solucion", this.Solucion);
			if (!DB.IsNullOrEmpty(this.AtencionClienteIncidencia_ID)) m_params.Add("AtencionClienteIncidencia_ID", this.AtencionClienteIncidencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioCortesia)) m_params.Add("FolioCortesia", this.FolioCortesia);
			if (!DB.IsNullOrEmpty(this.FechaVencimiento)) m_params.Add("FechaVencimiento", this.FechaVencimiento);
			if (!DB.IsNullOrEmpty(this.ObjetoExtraviado)) m_params.Add("ObjetoExtraviado", this.ObjetoExtraviado);
			if (!DB.IsNullOrEmpty(this.Observaciones)) m_params.Add("Observaciones", this.Observaciones);
			if (!DB.IsNullOrEmpty(this.MontoCargo)) m_params.Add("MontoCargo", this.MontoCargo);
			if (!DB.IsNullOrEmpty(this.EsAutorizadoReembolso)) m_params.Add("EsAutorizadoReembolso", this.EsAutorizadoReembolso);
			if (!DB.IsNullOrEmpty(this.FechaAutorizacionReembolso)) m_params.Add("FechaAutorizacionReembolso", this.FechaAutorizacionReembolso);

			return DB.InsertRow("AtencionClientes", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("AtencionCliente_ID", this.AtencionCliente_ID);
			m_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);
			if (!DB.IsNullOrEmpty(this.TipoIncidencia_ID)) m_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("NumeroConfirmacion", this.NumeroConfirmacion);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.Motivo)) m_params.Add("Motivo", this.Motivo);
			if (!DB.IsNullOrEmpty(this.EsEntregado)) m_params.Add("EsEntregado", this.EsEntregado);
			m_params.Add("EsCerrado", this.EsCerrado);
			if (!DB.IsNullOrEmpty(this.Solucion)) m_params.Add("Solucion", this.Solucion);
			if (!DB.IsNullOrEmpty(this.AtencionClienteIncidencia_ID)) m_params.Add("AtencionClienteIncidencia_ID", this.AtencionClienteIncidencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioCortesia)) m_params.Add("FolioCortesia", this.FolioCortesia);
			if (!DB.IsNullOrEmpty(this.FechaVencimiento)) m_params.Add("FechaVencimiento", this.FechaVencimiento);
			if (!DB.IsNullOrEmpty(this.ObjetoExtraviado)) m_params.Add("ObjetoExtraviado", this.ObjetoExtraviado);
			if (!DB.IsNullOrEmpty(this.Observaciones)) m_params.Add("Observaciones", this.Observaciones);
			if (!DB.IsNullOrEmpty(this.MontoCargo)) m_params.Add("MontoCargo", this.MontoCargo);
			if (!DB.IsNullOrEmpty(this.EsAutorizadoReembolso)) m_params.Add("EsAutorizadoReembolso", this.EsAutorizadoReembolso);
			if (!DB.IsNullOrEmpty(this.FechaAutorizacionReembolso)) m_params.Add("FechaAutorizacionReembolso", this.FechaAutorizacionReembolso);

			return DB.IdentityInsertRow("AtencionClientes", m_params);
		} // End Create

		public static List<AtencionClientes> Read()
		{
			List<AtencionClientes> list = new List<AtencionClientes>();
			DataTable dt = DB.Select("AtencionClientes");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new AtencionClientes(
					   Convert.ToInt32(dr["AtencionCliente_ID"]),
					   Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					   DB.GetNullableInt32(dr["TipoIncidencia_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["Conductor_ID"]),
					   Convert.ToInt32(dr["Unidad_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToString(dr["NumeroConfirmacion"]),
					   Convert.ToDateTime(dr["FechaInicial"]),
					   DB.GetNullableDateTime(dr["FechaFinal"]),
					   Convert.ToString(dr["Motivo"]),
					   DB.GetNullableBoolean(dr["EsEntregado"]),
					   Convert.ToBoolean(dr["EsCerrado"]),
					   Convert.ToString(dr["Solucion"]),
					   DB.GetNullableInt32(dr["AtencionClienteIncidencia_ID"]),
					   Convert.ToString(dr["FolioCortesia"]),
					   DB.GetNullableDateTime(dr["FechaVencimiento"]),
					   Convert.ToString(dr["ObjetoExtraviado"]),
					   Convert.ToString(dr["Observaciones"]),
					   DB.GetNullableDecimal(dr["MontoCargo"]),
					   DB.GetNullableBoolean(dr["EsAutorizadoReembolso"]),
					   DB.GetNullableDateTime(dr["FechaAutorizacionReembolso"])
				    )
				);
			}

			return list;
		} // End Read

		public static AtencionClientes Read(int atencioncliente_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AtencionCliente_ID", atencioncliente_id);
			DataTable dt = DB.Select("AtencionClientes", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe AtencionClientes con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new AtencionClientes(
			    Convert.ToInt32(dr["AtencionCliente_ID"]),
					  Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  DB.GetNullableInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["NumeroConfirmacion"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["Motivo"]),
					  DB.GetNullableBoolean(dr["EsEntregado"]),
					  Convert.ToBoolean(dr["EsCerrado"]),
					  Convert.ToString(dr["Solucion"]),
					  DB.GetNullableInt32(dr["AtencionClienteIncidencia_ID"]),
					  Convert.ToString(dr["FolioCortesia"]),
					  DB.GetNullableDateTime(dr["FechaVencimiento"]),
					  Convert.ToString(dr["ObjetoExtraviado"]),
					  Convert.ToString(dr["Observaciones"]),
					  DB.GetNullableDecimal(dr["MontoCargo"]),
					  DB.GetNullableBoolean(dr["EsAutorizadoReembolso"]),
					  DB.GetNullableDateTime(dr["FechaAutorizacionReembolso"])
				   );
		} // End Read

		public static AtencionClientes Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("AtencionClientes", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new AtencionClientes(
			    Convert.ToInt32(dr["AtencionCliente_ID"]),
					  Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  DB.GetNullableInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["NumeroConfirmacion"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["Motivo"]),
					  DB.GetNullableBoolean(dr["EsEntregado"]),
					  Convert.ToBoolean(dr["EsCerrado"]),
					  Convert.ToString(dr["Solucion"]),
					  DB.GetNullableInt32(dr["AtencionClienteIncidencia_ID"]),
					  Convert.ToString(dr["FolioCortesia"]),
					  DB.GetNullableDateTime(dr["FechaVencimiento"]),
					  Convert.ToString(dr["ObjetoExtraviado"]),
					  Convert.ToString(dr["Observaciones"]),
					  DB.GetNullableDecimal(dr["MontoCargo"]),
					  DB.GetNullableBoolean(dr["EsAutorizadoReembolso"]),
					  DB.GetNullableDateTime(dr["FechaAutorizacionReembolso"])
				   );
		} // End Read

		public static bool Read(
		    out AtencionClientes atencionclientes,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("AtencionClientes", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				atencionclientes = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			atencionclientes = new AtencionClientes(
			    Convert.ToInt32(dr["AtencionCliente_ID"]),
					  Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  DB.GetNullableInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["NumeroConfirmacion"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["Motivo"]),
					  DB.GetNullableBoolean(dr["EsEntregado"]),
					  Convert.ToBoolean(dr["EsCerrado"]),
					  Convert.ToString(dr["Solucion"]),
					  DB.GetNullableInt32(dr["AtencionClienteIncidencia_ID"]),
					  Convert.ToString(dr["FolioCortesia"]),
					  DB.GetNullableDateTime(dr["FechaVencimiento"]),
					  Convert.ToString(dr["ObjetoExtraviado"]),
					  Convert.ToString(dr["Observaciones"]),
					  DB.GetNullableDecimal(dr["MontoCargo"]),
					  DB.GetNullableBoolean(dr["EsAutorizadoReembolso"]),
					  DB.GetNullableDateTime(dr["FechaAutorizacionReembolso"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("AtencionClientes");
		} // End Read

		public static DataTable ReadDataTable(int atencioncliente_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AtencionCliente_ID", atencioncliente_id);
			return DB.Select("AtencionClientes", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("AtencionCliente_ID", this.AtencionCliente_ID);
			m_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);
			if (!DB.IsNullOrEmpty(this.TipoIncidencia_ID)) m_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("NumeroConfirmacion", this.NumeroConfirmacion);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.Motivo)) m_params.Add("Motivo", this.Motivo);
			if (!DB.IsNullOrEmpty(this.EsEntregado)) m_params.Add("EsEntregado", this.EsEntregado);
			m_params.Add("EsCerrado", this.EsCerrado);
			if (!DB.IsNullOrEmpty(this.Solucion)) m_params.Add("Solucion", this.Solucion);
			if (!DB.IsNullOrEmpty(this.AtencionClienteIncidencia_ID)) m_params.Add("AtencionClienteIncidencia_ID", this.AtencionClienteIncidencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioCortesia)) m_params.Add("FolioCortesia", this.FolioCortesia);
			if (!DB.IsNullOrEmpty(this.FechaVencimiento)) m_params.Add("FechaVencimiento", this.FechaVencimiento);
			if (!DB.IsNullOrEmpty(this.ObjetoExtraviado)) m_params.Add("ObjetoExtraviado", this.ObjetoExtraviado);
			if (!DB.IsNullOrEmpty(this.Observaciones)) m_params.Add("Observaciones", this.Observaciones);
			if (!DB.IsNullOrEmpty(this.MontoCargo)) m_params.Add("MontoCargo", this.MontoCargo);
			if (!DB.IsNullOrEmpty(this.EsAutorizadoReembolso)) m_params.Add("EsAutorizadoReembolso", this.EsAutorizadoReembolso);
			if (!DB.IsNullOrEmpty(this.FechaAutorizacionReembolso)) m_params.Add("FechaAutorizacionReembolso", this.FechaAutorizacionReembolso);

			return DB.UpdateRow("AtencionClientes", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AtencionCliente_ID", this.AtencionCliente_ID);

			return DB.DeleteRow("AtencionClientes", w_params);
		} // End Delete


		#endregion
	} //End Class AtencionClientes

	public class AyudasOpciones
	{

		public AyudasOpciones()
		{
		}

		public AyudasOpciones(int ayudaopcion_id, string opcion, string url)
		{
			this.AyudaOpcion_ID = ayudaopcion_id;
			this.Opcion = opcion;
			this.Url = url;
		}

		private int _AyudaOpcion_ID;
		public int AyudaOpcion_ID
		{
			get { return _AyudaOpcion_ID; }
			set { _AyudaOpcion_ID = value; }
		}

		private string _Opcion;
		public string Opcion
		{
			get { return _Opcion; }
			set { _Opcion = value; }
		}

		private string _Url;
		public string Url
		{
			get { return _Url; }
			set { _Url = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Opcion", this.Opcion);
			m_params.Add("Url", this.Url);

			return DB.InsertRow("AyudasOpciones", m_params);
		} // End Create

		public static List<AyudasOpciones> Read()
		{
			List<AyudasOpciones> list = new List<AyudasOpciones>();
			DataTable dt = DB.Select("AyudasOpciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new AyudasOpciones(Convert.ToInt32(dr["AyudaOpcion_ID"]), Convert.ToString(dr["Opcion"]), Convert.ToString(dr["Url"])));
			}

			return list;
		} // End Read

		public static List<AyudasOpciones> Read(int ayudaopcion_id)
		{
			List<AyudasOpciones> list = new List<AyudasOpciones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("AyudaOpcion_ID", ayudaopcion_id);
			DataTable dt = DB.Select("AyudasOpciones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new AyudasOpciones(Convert.ToInt32(dr["AyudaOpcion_ID"]), Convert.ToString(dr["Opcion"]), Convert.ToString(dr["Url"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("AyudaOpcion_ID", this.AyudaOpcion_ID);
			m_params.Add("Opcion", this.Opcion);
			m_params.Add("Url", this.Url);

			return DB.UpdateRow("AyudasOpciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("AyudaOpcion_ID", this.AyudaOpcion_ID);

			return DB.DeleteRow("AyudasOpciones", w_params);
		}

		public static string GetUrlByOpcion(string opcion)
		{
			int cont = DB.GetCount(
				   "AyudasOpciones",
				   DB.GetParams(
					  DB.Param(
						 "Opcion",
						 opcion
					  )
				   )
			    );

			if (cont > 0)
			{
				string sqlstr = "SELECT Url FROM AyudasOpciones WHERE Opcion = @Opcion";
				return DB.QueryScalar(sqlstr,
				    new KeyValuePair<string, object>("@Opcion", opcion)).ToString();
			}

			return "";
		}

	} //End Class AyudasOpciones

	public class Cajas
	{

		#region Constructors

		public Cajas()
		{
		}

		public Cajas(
			int caja_id,
			int empresa_id,
			int estacion_id,
			string nombre,
			bool? activa,
			int? referencia_id,
			bool? impresiondoble,
			bool? enclave,
			bool imprimirfirmas)
		{
			this.Caja_ID = caja_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Nombre = nombre;
			this.Activa = activa;
			this.Referencia_ID = referencia_id;
			this.ImpresionDoble = impresiondoble;
			this.EnClave = enclave;
			this.ImprimirFirmas = imprimirfirmas;
		}

		#endregion

		#region Properties

		private int _Caja_ID;
		public int Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private bool? _Activa;
		public bool? Activa
		{
			get { return _Activa; }
			set { _Activa = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		private bool? _ImpresionDoble;
		public bool? ImpresionDoble
		{
			get { return _ImpresionDoble; }
			set { _ImpresionDoble = value; }
		}

		private bool? _EnClave;
		public bool? EnClave
		{
			get { return _EnClave; }
			set { _EnClave = value; }
		}

		private bool _ImprimirFirmas;
		public bool ImprimirFirmas
		{
			get { return _ImprimirFirmas; }
			set { _ImprimirFirmas = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Activa)) m_params.Add("Activa", this.Activa);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ImpresionDoble)) m_params.Add("ImpresionDoble", this.ImpresionDoble);
			if (!DB.IsNullOrEmpty(this.EnClave)) m_params.Add("EnClave", this.EnClave);
			m_params.Add("ImprimirFirmas", this.ImprimirFirmas);

			return DB.InsertRow("Cajas", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Activa)) m_params.Add("Activa", this.Activa);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ImpresionDoble)) m_params.Add("ImpresionDoble", this.ImpresionDoble);
			if (!DB.IsNullOrEmpty(this.EnClave)) m_params.Add("EnClave", this.EnClave);
			m_params.Add("ImprimirFirmas", this.ImprimirFirmas);

			return DB.IdentityInsertRow("Cajas", m_params);
		} // End Create

		public static List<Cajas> Read()
		{
			List<Cajas> list = new List<Cajas>();
			DataTable dt = DB.Select("Cajas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
					new Cajas(
						Convert.ToInt32(dr["Caja_ID"]),
						Convert.ToInt32(dr["Empresa_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Nombre"]),
						DB.GetNullableBoolean(dr["Activa"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableBoolean(dr["ImpresionDoble"]),
						DB.GetNullableBoolean(dr["EnClave"]),
						Convert.ToBoolean(dr["ImprimirFirmas"])
					)
				);
			}

			return list;
		} // End Read

		public static List<Cajas> ReadPorUsuario(string usuario_id)
		{
			List<Cajas> list = new List<Cajas>();
			string sql = @"SELECT *
FROM    Cajas C
INNER JOIN  Usuarios_Cajas UC
ON      C.Caja_ID = UC.Caja_ID
WHERE   UC.Usuario_ID = @Usuario_ID";

			DataTable dt =
			    DB.QueryCommand(
				   sql,
				   DB.GetParams(
					  DB.Param("@Usuario_ID", usuario_id)
				   )
			    );

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Cajas(
					   Convert.ToInt32(dr["Caja_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   DB.GetNullableBoolean(dr["Activa"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["ImpresionDoble"]),
					   DB.GetNullableBoolean(dr["EnClave"]),
					   Convert.ToBoolean(dr["ImprimirFirmas"])
				    )
				);
			}

			return list;
		} // End Read

		public static Cajas Read(int caja_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Caja_ID", caja_id);
			DataTable dt = DB.Select("Cajas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Cajas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Cajas(
				Convert.ToInt32(dr["Caja_ID"]),
						Convert.ToInt32(dr["Empresa_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Nombre"]),
						DB.GetNullableBoolean(dr["Activa"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableBoolean(dr["ImpresionDoble"]),
						DB.GetNullableBoolean(dr["EnClave"]),
						Convert.ToBoolean(dr["ImprimirFirmas"])
					);
		} // End Read

		public static Cajas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Cajas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Cajas(
				Convert.ToInt32(dr["Caja_ID"]),
						Convert.ToInt32(dr["Empresa_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Nombre"]),
						DB.GetNullableBoolean(dr["Activa"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableBoolean(dr["ImpresionDoble"]),
						DB.GetNullableBoolean(dr["EnClave"]),
						Convert.ToBoolean(dr["ImprimirFirmas"])
					);
		} // End Read

		public static List<Cajas> ReadList(params KeyValuePair<string, object>[] args)
		{
			List<Cajas> list = new List<Cajas>();
			DataTable dt = DB.Read("Cajas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Cajas(
					   Convert.ToInt32(dr["Caja_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   DB.GetNullableBoolean(dr["Activa"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["ImpresionDoble"]),
					   DB.GetNullableBoolean(dr["EnClave"]),
					   Convert.ToBoolean(dr["ImprimirFirmas"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Cajas> ReadList(string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			List<Cajas> list = new List<Cajas>();
			DataTable dt = DB.Read("Cajas", filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Cajas(
					   Convert.ToInt32(dr["Caja_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   DB.GetNullableBoolean(dr["Activa"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["ImpresionDoble"]),
					   DB.GetNullableBoolean(dr["EnClave"]),
					   Convert.ToBoolean(dr["ImprimirFirmas"])
				    )
				);
			}

			return list;
		} // End Read

		public static bool Read(
			out Cajas cajas,
			int top,
			string filter,
			string sort,
			params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Cajas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				cajas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			cajas = new Cajas(
				Convert.ToInt32(dr["Caja_ID"]),
						Convert.ToInt32(dr["Empresa_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Nombre"]),
						DB.GetNullableBoolean(dr["Activa"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableBoolean(dr["ImpresionDoble"]),
						DB.GetNullableBoolean(dr["EnClave"]),
						Convert.ToBoolean(dr["ImprimirFirmas"])
					);
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Cajas");
		} // End Read

		public static DataTable ReadDataTable(int caja_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Caja_ID", caja_id);
			return DB.Select("Cajas", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Activa)) m_params.Add("Activa", this.Activa);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ImpresionDoble)) m_params.Add("ImpresionDoble", this.ImpresionDoble);
			if (!DB.IsNullOrEmpty(this.EnClave)) m_params.Add("EnClave", this.EnClave);
			m_params.Add("ImprimirFirmas", this.ImprimirFirmas);

			return DB.UpdateRow("Cajas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Caja_ID", this.Caja_ID);

			return DB.DeleteRow("Cajas", w_params);
		} // End Delete


		#endregion
	} //End Class Cajas


	public class CancelacionesOrdenesTrabajos
	{

		public CancelacionesOrdenesTrabajos()
		{
		}

		public CancelacionesOrdenesTrabajos(int ordentrabajo_id, string usuario_id, DateTime fecha, string comentarios)
		{
			this.OrdenTrabajo_ID = ordentrabajo_id;
			this.Usuario_ID = usuario_id;
			this.Fecha = fecha;
			this.Comentarios = comentarios;
		}

		private int _OrdenTrabajo_ID;
		public int OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("CancelacionesOrdenesTrabajos", m_params);
		} // End Create

		public static List<CancelacionesOrdenesTrabajos> Read()
		{
			List<CancelacionesOrdenesTrabajos> list = new List<CancelacionesOrdenesTrabajos>();
			DataTable dt = DB.Select("CancelacionesOrdenesTrabajos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CancelacionesOrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static CancelacionesOrdenesTrabajos Read(int ordentrabajo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
			DataTable dt = DB.Select("CancelacionesOrdenesTrabajos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe CancelacionesOrdenesTrabajos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new CancelacionesOrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("CancelacionesOrdenesTrabajos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

			return DB.DeleteRow("CancelacionesOrdenesTrabajos", w_params);
		} // End Delete

	} //End Class CancelacionesOrdenesTrabajos

	public class CategoriasMecanicos
	{

		public CategoriasMecanicos()
		{
		}

		public CategoriasMecanicos(int categoriamecanico_id, int familia_id, string nombre)
		{
			this.CategoriaMecanico_ID = categoriamecanico_id;
			this.Familia_ID = familia_id;
			this.Nombre = nombre;
		}

		private int _CategoriaMecanico_ID;
		public int CategoriaMecanico_ID
		{
			get { return _CategoriaMecanico_ID; }
			set { _CategoriaMecanico_ID = value; }
		}

		private int _Familia_ID;
		public int Familia_ID
		{
			get { return _Familia_ID; }
			set { _Familia_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("CategoriasMecanicos", m_params);
		} // End Create

		public static List<CategoriasMecanicos> Read()
		{
			List<CategoriasMecanicos> list = new List<CategoriasMecanicos>();
			DataTable dt = DB.Select("CategoriasMecanicos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CategoriasMecanicos(Convert.ToInt32(dr["CategoriaMecanico_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static CategoriasMecanicos Read(int categoriamecanico_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CategoriaMecanico_ID", categoriamecanico_id);
			DataTable dt = DB.Select("CategoriasMecanicos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe CategoriasMecanicos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new CategoriasMecanicos(Convert.ToInt32(dr["CategoriaMecanico_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("CategoriasMecanicos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);

			return DB.DeleteRow("CategoriasMecanicos", w_params);
		} // End Delete

	} //End Class CategoriasMecanicos

	public class ClasesPublicidad
	{

		public ClasesPublicidad()
		{
		}

		public ClasesPublicidad(int clasepublicidad_id, string nombre)
		{
			this.ClasePublicidad_ID = clasepublicidad_id;
			this.Nombre = nombre;
		}

		private int _ClasePublicidad_ID;
		public int ClasePublicidad_ID
		{
			get { return _ClasePublicidad_ID; }
			set { _ClasePublicidad_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("ClasesPublicidad", m_params);
		} // End Create

		public static List<ClasesPublicidad> Read()
		{
			List<ClasesPublicidad> list = new List<ClasesPublicidad>();
			DataTable dt = DB.Select("ClasesPublicidad");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ClasesPublicidad(Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<ClasesPublicidad> Read(int clasepublicidad_id)
		{
			List<ClasesPublicidad> list = new List<ClasesPublicidad>();
			Hashtable w_params = new Hashtable();
			w_params.Add("ClasePublicidad_ID", clasepublicidad_id);
			DataTable dt = DB.Select("ClasesPublicidad", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ClasesPublicidad(Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("ClasesPublicidad", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);

			return DB.DeleteRow("ClasesPublicidad", w_params);
		}

	} //End Class ClasesPublicidad

	public class ClasesServicios
	{

		public ClasesServicios()
		{
		}

		public ClasesServicios(int claseservicio_id, string nombre)
		{
			this.ClaseServicio_ID = claseservicio_id;
			this.Nombre = nombre;
		}

		private int _ClaseServicio_ID;
		public int ClaseServicio_ID
		{
			get { return _ClaseServicio_ID; }
			set { _ClaseServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("ClasesServicios", m_params);
		} // End Create

		public static List<ClasesServicios> Read()
		{
			List<ClasesServicios> list = new List<ClasesServicios>();
			DataTable dt = DB.Select("ClasesServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ClasesServicios(Convert.ToInt32(dr["ClaseServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<ClasesServicios> Read(int claseservicio_id)
		{
			List<ClasesServicios> list = new List<ClasesServicios>();
			Hashtable w_params = new Hashtable();
			w_params.Add("ClaseServicio_ID", claseservicio_id);
			DataTable dt = DB.Select("ClasesServicios", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ClasesServicios(Convert.ToInt32(dr["ClaseServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("ClasesServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);

			return DB.DeleteRow("ClasesServicios", w_params);
		}

	} //End Class ClasesServicios

	public class ComisionesServicios
	{

		#region Constructors

		public ComisionesServicios()
		{
		}

		public ComisionesServicios(
		    int comisionservicio_id,
		    int comisionista_id,
		    int tipocomision_id,
		    decimal monto,
		    string nombre,
		    bool esgeneral,
		    bool activo)
		{
			this.ComisionServicio_ID = comisionservicio_id;
			this.Comisionista_ID = comisionista_id;
			this.TipoComision_ID = tipocomision_id;
			this.Monto = monto;
			this.Nombre = nombre;
			this.EsGeneral = esgeneral;
			this.Activo = activo;
		}

		#endregion

		#region Properties

		private int _ComisionServicio_ID;
		public int ComisionServicio_ID
		{
			get { return _ComisionServicio_ID; }
			set { _ComisionServicio_ID = value; }
		}

		private int _Comisionista_ID;
		public int Comisionista_ID
		{
			get { return _Comisionista_ID; }
			set { _Comisionista_ID = value; }
		}

		private int _TipoComision_ID;
		public int TipoComision_ID
		{
			get { return _TipoComision_ID; }
			set { _TipoComision_ID = value; }
		}

		private decimal _Monto;
		public decimal Monto
		{
			get { return _Monto; }
			set { _Monto = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private bool _EsGeneral;
		public bool EsGeneral
		{
			get { return _EsGeneral; }
			set { _EsGeneral = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Comisionista_ID == 0) throw new Exception("Comisionista_ID no puede ser nulo.");

			if (this.TipoComision_ID == 0) throw new Exception("TipoComision_ID no puede ser nulo.");

			if (this.Monto == 0) throw new Exception("Monto no puede ser 0.");

			if (this.Nombre.Length > 50)
			{
				throw new Exception("Nombre debe tener máximo 50 carateres.");
			}
		} // End Validate

		public List<Zonas> Zonas
		{
			get
			{
				List<Zonas> list = new List<Zonas>();
				Hashtable w_params = new Hashtable();
				w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
				DataTable dt = DB.Select("Zonas", w_params);
				foreach (DataRow dr in dt.Rows)
				{
					list.Add(new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]),
					    Convert.ToString(dr["Nombre"])));
				}

				return list;
			}
		}

		public List<TiposVenta> TiposVenta
		{
			get
			{
				List<TiposVenta> list = new List<TiposVenta>();
				Hashtable w_params = new Hashtable();
				w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
				DataTable dt = DB.Select("TiposVenta", w_params);
				foreach (DataRow dr in dt.Rows)
				{
					list.Add(new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
				}

				return list;
			}
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Comisionista_ID", this.Comisionista_ID);
			m_params.Add("TipoComision_ID", this.TipoComision_ID);
			m_params.Add("Monto", this.Monto);
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("EsGeneral", this.EsGeneral);
			m_params.Add("Activo", this.Activo);

			return DB.InsertRow("ComisionesServicios", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Comisionista_ID", this.Comisionista_ID);
			m_params.Add("TipoComision_ID", this.TipoComision_ID);
			m_params.Add("Monto", this.Monto);
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("EsGeneral", this.EsGeneral);
			m_params.Add("Activo", this.Activo);

			return DB.IdentityInsertRow("ComisionesServicios", m_params);
		} // End Create

		public static List<ComisionesServicios> Read()
		{
			List<ComisionesServicios> list = new List<ComisionesServicios>();
			DataTable dt = DB.Select("ComisionesServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new ComisionesServicios(
					   Convert.ToInt32(dr["ComisionServicio_ID"]),
					   Convert.ToInt32(dr["Comisionista_ID"]),
					   Convert.ToInt32(dr["TipoComision_ID"]),
					   Convert.ToDecimal(dr["Monto"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToBoolean(dr["EsGeneral"]),
					   Convert.ToBoolean(dr["Activo"])
				    )
				);
			}

			return list;
		} // End Read

		public static ComisionesServicios Read(int comisionservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ComisionServicio_ID", comisionservicio_id);
			DataTable dt = DB.Select("ComisionesServicios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ComisionesServicios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ComisionesServicios(
			    Convert.ToInt32(dr["ComisionServicio_ID"]),
					  Convert.ToInt32(dr["Comisionista_ID"]),
					  Convert.ToInt32(dr["TipoComision_ID"]),
					  Convert.ToDecimal(dr["Monto"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToBoolean(dr["EsGeneral"]),
					  Convert.ToBoolean(dr["Activo"])
				   );
		} // End Read

		public static ComisionesServicios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ComisionesServicios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ComisionesServicios(
			    Convert.ToInt32(dr["ComisionServicio_ID"]),
					  Convert.ToInt32(dr["Comisionista_ID"]),
					  Convert.ToInt32(dr["TipoComision_ID"]),
					  Convert.ToDecimal(dr["Monto"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToBoolean(dr["EsGeneral"]),
					  Convert.ToBoolean(dr["Activo"])
				   );
		} // End Read

		public static bool Read(
		    out ComisionesServicios comisionesservicios,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ComisionesServicios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				comisionesservicios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			comisionesservicios = new ComisionesServicios(
			    Convert.ToInt32(dr["ComisionServicio_ID"]),
					  Convert.ToInt32(dr["Comisionista_ID"]),
					  Convert.ToInt32(dr["TipoComision_ID"]),
					  Convert.ToDecimal(dr["Monto"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToBoolean(dr["EsGeneral"]),
					  Convert.ToBoolean(dr["Activo"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ComisionesServicios");
		} // End Read

		public static DataTable ReadDataTable(int comisionservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ComisionServicio_ID", comisionservicio_id);
			return DB.Select("ComisionesServicios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Comisionista_ID", this.Comisionista_ID);
			m_params.Add("TipoComision_ID", this.TipoComision_ID);
			m_params.Add("Monto", this.Monto);
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("EsGeneral", this.EsGeneral);
			m_params.Add("Activo", this.Activo);

			return DB.UpdateRow("ComisionesServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);

			return DB.DeleteRow("ComisionesServicios", w_params);
		} // End Delete


		#endregion
	} //End Class ComisionesServicios

	public class Compras
	{

		#region Constructors

		public Compras()
		{
		}

		public Compras(
		    int compra_id,
		    int ordencompra_id,
		    int refaccion_id,
		    int marcarefaccion_id,
		    string usuario_id,
		    decimal costounitario,
		    int cantidad,
		    DateTime fecha,
		    int refaccionessurtidas,
		    int empresa_id,
		    int estacion_id)
		{
			this.Compra_ID = compra_id;
			this.OrdenCompra_ID = ordencompra_id;
			this.Refaccion_ID = refaccion_id;
			this.MarcaRefaccion_ID = marcarefaccion_id;
			this.Usuario_ID = usuario_id;
			this.CostoUnitario = costounitario;
			this.Cantidad = cantidad;
			this.Fecha = fecha;
			this.RefaccionesSurtidas = refaccionessurtidas;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _Compra_ID;
		public int Compra_ID
		{
			get { return _Compra_ID; }
			set { _Compra_ID = value; }
		}

		private int _OrdenCompra_ID;
		public int OrdenCompra_ID
		{
			get { return _OrdenCompra_ID; }
			set { _OrdenCompra_ID = value; }
		}

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private int _MarcaRefaccion_ID;
		public int MarcaRefaccion_ID
		{
			get { return _MarcaRefaccion_ID; }
			set { _MarcaRefaccion_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private decimal _CostoUnitario;
		public decimal CostoUnitario
		{
			get { return _CostoUnitario; }
			set { _CostoUnitario = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _RefaccionesSurtidas;
		public int RefaccionesSurtidas
		{
			get { return _RefaccionesSurtidas; }
			set { _RefaccionesSurtidas = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		/// <summary>
		/// No relacionada con la base de datos, de uso exclusivo de la lógica de negocios
		/// </summary>
		private string _Refaccion_Descripcion;
		public string Refaccion_Descripcion
		{
			get { return _Refaccion_Descripcion; }
			set { _Refaccion_Descripcion = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.OrdenCompra_ID == 0) throw new Exception("OrdenCompra_ID no puede ser nulo.");

			if (this.Refaccion_ID == 0) throw new Exception("Refaccion_ID no puede ser nulo.");

			if (this.MarcaRefaccion_ID == 0) throw new Exception("MarcaRefaccion_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.CostoUnitario == 0) throw new Exception("CostoUnitario no puede ser 0.");

			if (this.Cantidad == 0) throw new Exception("Cantidad no puede ser 0.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			int result = DB.InsertRow("Compras", m_params);

			string sql;

			//  Obtener el dato de refacción en inventario

			m_params.Clear();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);

			int cont = DB.GetCount("Inventario", m_params);

			//  Si hay inventario, actualizar inventario.            
			if (cont == 0)
			//            {
			//                  Actualizar el catalogo de inventario, costo y precios            

			//                sql = @"UPDATE   Inventario
			//SET PrecioInterno = @CostoUnitario * ( 1 + ( MargenInterno / 100.00 ) ),
			//PrecioExterno = @CostoUnitario * ( 1 + ( MargenExterno / 100.00 ) ),
			//CostoUnitario = @CostoUnitario
			//WHERE   Refaccion_ID = @Refaccion_ID
			//AND     Empresa_ID = @Empresa_ID
			//AND     Estacion_ID = @Estacion_ID";

			//                m_params.Clear();

			//                m_params.Add("@CostoUnitario", this.CostoUnitario);
			//                m_params.Add("@Refaccion_ID", this.Refaccion_ID);
			//                m_params.Add("@Empresa_ID", this.Empresa_ID);
			//                m_params.Add("@Estacion_ID", this.Estacion_ID);

			//                DB.ExecuteCommand(sql, m_params);
			//            }
			//            else //  Si no hay inventario, insertar el inventario
			{
				sql = @"INSERT  Inventario
SELECT	@Empresa_ID,
		@Estacion_ID,
		@Refaccion_ID,
		NULL,
		NULL,
		NULL,
		NULL,
		@CostoUnitario,
		@CostoUnitario * (@MargenInterno / 100),
		@CostoUnitario * (@MargenExterno / 100),
		@MargenInterno,
		@MargenExterno,
		@Cantidad,
		@CostoUnitario * @Cantidad,
		0";

				m_params.Clear();
				m_params.Add("@Refaccion_ID", this.Refaccion_ID);
				m_params.Add("@MargenInterno", 30);
				m_params.Add("@MargenExterno", 40);
				m_params.Add("@Empresa_ID", this.Empresa_ID);
				m_params.Add("@Estacion_ID", this.Estacion_ID);
				m_params.Add("@CostoUnitario", this.CostoUnitario);
				m_params.Add("@Cantidad", this.Cantidad);

				DB.ExecuteCommand(
				    sql,
				    m_params
				);
			}

			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Compra_ID", this.Compra_ID);
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("Compras", m_params);
		} // End Create

		public static List<Compras> Read()
		{
			List<Compras> list = new List<Compras>();
			DataTable dt = DB.Select("Compras");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Compras(
					   Convert.ToInt32(dr["Compra_ID"]),
					   Convert.ToInt32(dr["OrdenCompra_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToInt32(dr["Cantidad"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["RefaccionesSurtidas"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Compras> ReadList(int ordencompra_id)
		{
			List<Compras> list = new List<Compras>();
			Hashtable w_params = new Hashtable();

			w_params.Add("OrdenCompra_ID", ordencompra_id);

			DataTable dt = DB.Select("Compras", w_params);

			if (dt.Rows.Count == 0) return null;

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Compras(
					   Convert.ToInt32(dr["Compra_ID"]),
					   Convert.ToInt32(dr["OrdenCompra_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToInt32(dr["Cantidad"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["RefaccionesSurtidas"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Compras Read(int compra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Compra_ID", compra_id);
			DataTable dt = DB.Select("Compras", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Compras con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Compras(
			    Convert.ToInt32(dr["Compra_ID"]),
					  Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["RefaccionesSurtidas"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static Compras Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Compras", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Compras(
			    Convert.ToInt32(dr["Compra_ID"]),
					  Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["RefaccionesSurtidas"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Compras compras,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Compras", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				compras = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			compras = new Compras(
			    Convert.ToInt32(dr["Compra_ID"]),
					  Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["RefaccionesSurtidas"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Compras");
		} // End Read

		public static DataTable ReadDataTable(int compra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Compra_ID", compra_id);
			return DB.Select("Compras", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Compra_ID", this.Compra_ID);
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("Compras", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Compra_ID", this.Compra_ID);

			return DB.DeleteRow("Compras", w_params);
		} // End Delete


		#endregion
	} //End Class Compras

	public class Conceptos
	{

		public Conceptos()
		{
		}

		public Conceptos(int concepto_id, int cuenta_id, string nombre, bool enrecibo, bool visiblerecibo, bool activo)
		{
			this.Concepto_ID = concepto_id;
			this.Cuenta_ID = cuenta_id;
			this.Nombre = nombre;
			this.EnRecibo = enrecibo;
			this.VisibleRecibo = visiblerecibo;
			this.Activo = activo;
		}

		private int _Concepto_ID;
		public int Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private bool _EnRecibo;
		public bool EnRecibo
		{
			get { return _EnRecibo; }
			set { _EnRecibo = value; }
		}

		private bool _VisibleRecibo;
		public bool VisibleRecibo
		{
			get { return _VisibleRecibo; }
			set { _VisibleRecibo = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EnRecibo", this.EnRecibo);
			m_params.Add("VisibleRecibo", this.VisibleRecibo);
			m_params.Add("Activo", this.Activo);

			return DB.InsertRow("Conceptos", m_params);
		} // End Create

		public static List<Conceptos> Read()
		{
			List<Conceptos> list = new List<Conceptos>();
			DataTable dt = DB.Select("Conceptos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Conceptos(Convert.ToInt32(dr["Concepto_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EnRecibo"]), Convert.ToBoolean(dr["VisibleRecibo"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static List<Conceptos> Read(params KeyValuePair<string, object>[] args)
		{
			List<Conceptos> list = new List<Conceptos>();
			DataTable dt = DB.Read("Conceptos", args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Conceptos(Convert.ToInt32(dr["Concepto_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EnRecibo"]), Convert.ToBoolean(dr["VisibleRecibo"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static List<Conceptos> Read(int concepto_id)
		{
			List<Conceptos> list = new List<Conceptos>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Concepto_ID", concepto_id);
			DataTable dt = DB.Select("Conceptos", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Conceptos(Convert.ToInt32(dr["Concepto_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EnRecibo"]), Convert.ToBoolean(dr["VisibleRecibo"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EnRecibo", this.EnRecibo);
			m_params.Add("VisibleRecibo", this.VisibleRecibo);
			m_params.Add("Activo", this.Activo);

			return DB.UpdateRow("Conceptos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Concepto_ID", this.Concepto_ID);

			return DB.DeleteRow("Conceptos", w_params);
		}

	} //End Class Conceptos

	public class Concesiones
	{

		public Concesiones()
		{
		}

		public Concesiones(int concesion_id, int empresa_id, int tipoconcesion_id, string placa, string numeroconcesion, bool activo, int referencia_id)
		{
			this.Concesion_ID = concesion_id;
			this.Empresa_ID = empresa_id;
			this.TipoConcesion_ID = tipoconcesion_id;
			this.Placa = placa;
			this.NumeroConcesion = numeroconcesion;
			this.Activo = activo;
			this.Referencia_ID = referencia_id;
		}

		private int _Concesion_ID;
		public int Concesion_ID
		{
			get { return _Concesion_ID; }
			set { _Concesion_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _TipoConcesion_ID;
		public int TipoConcesion_ID
		{
			get { return _TipoConcesion_ID; }
			set { _TipoConcesion_ID = value; }
		}

		private string _Placa;
		public string Placa
		{
			get { return _Placa; }
			set { _Placa = value; }
		}

		private string _NumeroConcesion;
		public string NumeroConcesion
		{
			get { return _NumeroConcesion; }
			set { _NumeroConcesion = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private int _Referencia_ID;
		public int Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
			m_params.Add("Placa", this.Placa);
			m_params.Add("NumeroConcesion", this.NumeroConcesion);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.InsertRow("Concesiones", m_params);
		} // End Create

		public static List<Concesiones> Read()
		{
			List<Concesiones> list = new List<Concesiones>();
			DataTable dt = DB.Select("Concesiones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public static List<Concesiones> Read(int concesion_id)
		{
			List<Concesiones> list = new List<Concesiones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Concesion_ID", concesion_id);
			DataTable dt = DB.Select("Concesiones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Concesion_ID", this.Concesion_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
			m_params.Add("Placa", this.Placa);
			m_params.Add("NumeroConcesion", this.NumeroConcesion);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.UpdateRow("Concesiones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Concesion_ID", this.Concesion_ID);

			return DB.DeleteRow("Concesiones", w_params);
		}

	} //End Class Concesiones

	public class Conductores
	{

		#region Constructors

		public Conductores()
		{
		}

		public Conductores(
		    int conductor_id,
		    string nombre,
		    string apellidos,
		    string domicilio,
		    string ciudad,
		    string entidad,
		    string telefono,
		    string telefono2,
		    string movil,
		    string email,
		    string rfc,
		    int estacion_id,
		    string curp,
		    string codigopostal,
		    string fotografia,
		    int estatusconductor_id,
		    int? mediopublicitario_id,
		    bool? cumplioperfil,
		    bool? interesado,
		    int? mercado_id,
		    string comentarios,
		    int? edad,
		    string estadocivil,
		    int? añosexperiencia,
		    string genero,
		    int? tipolicencia_id,
		    string foliolicencia,
		    DateTime? vencelicencia,
		    string rfc_aval,
		    string apellidos_aval,
		    string nombre_aval,
		    string curp_aval,
		    string domicilio_aval,
		    string ciudad_aval,
		    string estado_aval,
		    string codigopostal_aval,
		    string telefono_aval,
		    string email_aval,
		    string solicitud,
		    string actanacimiento,
		    string credencialelector,
		    string cartanoantecedentes,
		    string comprobantedomicilio,
		    string credencialelector_aval,
		    string comprobantedomicilio_aval,
		    decimal? saldoatratar,
		    bool? cronocasco,
		    bool? terminaldatos,
		    bool? bloquearconductor,
		    string mensajeacaja,
		    DateTime fecha,
		    string usuario_id,
		    int? referencia_id,
		    bool? primercursolicencia,
		    bool? segundocursolicencia,
		    bool? examenmedico,
		    bool? nomina,
		    string colonia,
		    int? dependientes,
		    string ocupacionesposa,
		    string tipovivienda,
		    int? gastosmensualesfijos,
		    int? cleaverd,
		    int? cleaveri,
		    int? cleavers,
		    int? cleaverc
		    )
		{
			this.Conductor_ID = conductor_id;
			this.Nombre = nombre;
			this.Apellidos = apellidos;
			this.Domicilio = domicilio;
			this.Ciudad = ciudad;
			this.Entidad = entidad;
			this.Telefono = telefono;
			this.Telefono2 = telefono2;
			this.Movil = movil;
			this.Email = email;
			this.RFC = rfc;
			this.Estacion_ID = estacion_id;
			this.CURP = curp;
			this.CodigoPostal = codigopostal;
			this.Fotografia = fotografia;
			this.EstatusConductor_ID = estatusconductor_id;
			this.MedioPublicitario_ID = mediopublicitario_id;
			this.CumplioPerfil = cumplioperfil;
			this.Interesado = interesado;
			this.Mercado_ID = mercado_id;
			this.Comentarios = comentarios;
			this.Edad = edad;
			this.EstadoCivil = estadocivil;
			this.AñosExperiencia = añosexperiencia;
			this.Genero = genero;
			this.TipoLicencia_ID = tipolicencia_id;
			this.FolioLicencia = foliolicencia;
			this.VenceLicencia = vencelicencia;
			this.Rfc_Aval = rfc_aval;
			this.Apellidos_Aval = apellidos_aval;
			this.Nombre_Aval = nombre_aval;
			this.Curp_Aval = curp_aval;
			this.Domicilio_Aval = domicilio_aval;
			this.Ciudad_Aval = ciudad_aval;
			this.Estado_Aval = estado_aval;
			this.CodigoPostal_Aval = codigopostal_aval;
			this.Telefono_Aval = telefono_aval;
			this.Email_Aval = email_aval;
			this.Solicitud = solicitud;
			this.ActaNacimiento = actanacimiento;
			this.CredencialElector = credencialelector;
			this.CartaNoAntecedentes = cartanoantecedentes;
			this.ComprobanteDomicilio = comprobantedomicilio;
			this.CredencialElector_Aval = credencialelector_aval;
			this.ComprobanteDomicilio_Aval = comprobantedomicilio_aval;
			this.SaldoATratar = saldoatratar;
			this.Cronocasco = cronocasco;
			this.TerminalDatos = terminaldatos;
			this.BloquearConductor = bloquearconductor;
			this.MensajeACaja = mensajeacaja;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
			this.Referencia_ID = referencia_id;
			this.PrimerCursoLicencia = primercursolicencia;
			this.SegundoCursoLicencia = segundocursolicencia;
			this.ExamenMedico = examenmedico;
			this.Nomina = nomina;
			this.Colonia = colonia;
			this.Dependientes = dependientes;
			this.OcupacionEsposa = ocupacionesposa;
			this.TipoVivienda = tipovivienda;
			this.GastosMensualesFijos = gastosmensualesfijos;
			this.CleaverD = cleaverd;
			this.CleaverI = cleaveri;
			this.CleaverS = cleavers;
			this.CleaverC = cleaverc;
		}

		#endregion

		#region Properties

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Apellidos;
		public string Apellidos
		{
			get { return _Apellidos; }
			set { _Apellidos = value; }
		}

		private string _Domicilio;
		public string Domicilio
		{
			get { return _Domicilio; }
			set { _Domicilio = value; }
		}

		private string _Ciudad;
		public string Ciudad
		{
			get { return _Ciudad; }
			set { _Ciudad = value; }
		}

		private string _Entidad;
		public string Entidad
		{
			get { return _Entidad; }
			set { _Entidad = value; }
		}

		private string _Telefono;
		public string Telefono
		{
			get { return _Telefono; }
			set { _Telefono = value; }
		}

		private string _Telefono2;
		public string Telefono2
		{
			get { return _Telefono2; }
			set { _Telefono2 = value; }
		}

		private string _Movil;
		public string Movil
		{
			get { return _Movil; }
			set { _Movil = value; }
		}

		private string _Email;
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private string _RFC;
		public string RFC
		{
			get { return _RFC; }
			set { _RFC = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _CURP;
		public string CURP
		{
			get { return _CURP; }
			set { _CURP = value; }
		}

		private string _CodigoPostal;
		public string CodigoPostal
		{
			get { return _CodigoPostal; }
			set { _CodigoPostal = value; }
		}

		private string _Fotografia;
		public string Fotografia
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}

		private int _EstatusConductor_ID;
		public int EstatusConductor_ID
		{
			get { return _EstatusConductor_ID; }
			set { _EstatusConductor_ID = value; }
		}

		private int? _MedioPublicitario_ID;
		public int? MedioPublicitario_ID
		{
			get { return _MedioPublicitario_ID; }
			set { _MedioPublicitario_ID = value; }
		}

		private bool? _CumplioPerfil;
		public bool? CumplioPerfil
		{
			get { return _CumplioPerfil; }
			set { _CumplioPerfil = value; }
		}

		private bool? _Interesado;
		public bool? Interesado
		{
			get { return _Interesado; }
			set { _Interesado = value; }
		}

		private int? _Mercado_ID;
		public int? Mercado_ID
		{
			get { return _Mercado_ID; }
			set { _Mercado_ID = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private int? _Edad;
		public int? Edad
		{
			get { return _Edad; }
			set { _Edad = value; }
		}

		private string _EstadoCivil;
		public string EstadoCivil
		{
			get { return _EstadoCivil; }
			set { _EstadoCivil = value; }
		}

		private int? _AñosExperiencia;
		public int? AñosExperiencia
		{
			get { return _AñosExperiencia; }
			set { _AñosExperiencia = value; }
		}

		private string _Genero;
		public string Genero
		{
			get { return _Genero; }
			set { _Genero = value; }
		}

		private int? _TipoLicencia_ID;
		public int? TipoLicencia_ID
		{
			get { return _TipoLicencia_ID; }
			set { _TipoLicencia_ID = value; }
		}

		private string _FolioLicencia;
		public string FolioLicencia
		{
			get { return _FolioLicencia; }
			set { _FolioLicencia = value; }
		}

		private DateTime? _VenceLicencia;
		public DateTime? VenceLicencia
		{
			get { return _VenceLicencia; }
			set { _VenceLicencia = value; }
		}

		private string _Rfc_Aval;
		public string Rfc_Aval
		{
			get { return _Rfc_Aval; }
			set { _Rfc_Aval = value; }
		}

		private string _Apellidos_Aval;
		public string Apellidos_Aval
		{
			get { return _Apellidos_Aval; }
			set { _Apellidos_Aval = value; }
		}

		private string _Nombre_Aval;
		public string Nombre_Aval
		{
			get { return _Nombre_Aval; }
			set { _Nombre_Aval = value; }
		}

		private string _Curp_Aval;
		public string Curp_Aval
		{
			get { return _Curp_Aval; }
			set { _Curp_Aval = value; }
		}

		private string _Domicilio_Aval;
		public string Domicilio_Aval
		{
			get { return _Domicilio_Aval; }
			set { _Domicilio_Aval = value; }
		}

		private string _Ciudad_Aval;
		public string Ciudad_Aval
		{
			get { return _Ciudad_Aval; }
			set { _Ciudad_Aval = value; }
		}

		private string _Estado_Aval;
		public string Estado_Aval
		{
			get { return _Estado_Aval; }
			set { _Estado_Aval = value; }
		}

		private string _CodigoPostal_Aval;
		public string CodigoPostal_Aval
		{
			get { return _CodigoPostal_Aval; }
			set { _CodigoPostal_Aval = value; }
		}

		private string _Telefono_Aval;
		public string Telefono_Aval
		{
			get { return _Telefono_Aval; }
			set { _Telefono_Aval = value; }
		}

		private string _Email_Aval;
		public string Email_Aval
		{
			get { return _Email_Aval; }
			set { _Email_Aval = value; }
		}

		private string _Solicitud;
		public string Solicitud
		{
			get { return _Solicitud; }
			set { _Solicitud = value; }
		}

		private string _ActaNacimiento;
		public string ActaNacimiento
		{
			get { return _ActaNacimiento; }
			set { _ActaNacimiento = value; }
		}

		private string _CredencialElector;
		public string CredencialElector
		{
			get { return _CredencialElector; }
			set { _CredencialElector = value; }
		}

		private string _CartaNoAntecedentes;
		public string CartaNoAntecedentes
		{
			get { return _CartaNoAntecedentes; }
			set { _CartaNoAntecedentes = value; }
		}

		private string _ComprobanteDomicilio;
		public string ComprobanteDomicilio
		{
			get { return _ComprobanteDomicilio; }
			set { _ComprobanteDomicilio = value; }
		}

		private string _CredencialElector_Aval;
		public string CredencialElector_Aval
		{
			get { return _CredencialElector_Aval; }
			set { _CredencialElector_Aval = value; }
		}

		private string _ComprobanteDomicilio_Aval;
		public string ComprobanteDomicilio_Aval
		{
			get { return _ComprobanteDomicilio_Aval; }
			set { _ComprobanteDomicilio_Aval = value; }
		}

		private decimal? _SaldoATratar;
		public decimal? SaldoATratar
		{
			get { return _SaldoATratar; }
			set { _SaldoATratar = value; }
		}

		private bool? _Cronocasco;
		public bool? Cronocasco
		{
			get { return _Cronocasco; }
			set { _Cronocasco = value; }
		}

		private bool? _TerminalDatos;
		public bool? TerminalDatos
		{
			get { return _TerminalDatos; }
			set { _TerminalDatos = value; }
		}

		private bool? _BloquearConductor;
		public bool? BloquearConductor
		{
			get { return _BloquearConductor; }
			set { _BloquearConductor = value; }
		}

		private string _MensajeACaja;
		public string MensajeACaja
		{
			get { return _MensajeACaja; }
			set { _MensajeACaja = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		private bool? _PrimerCursoLicencia;
		public bool? PrimerCursoLicencia
		{
			get { return _PrimerCursoLicencia; }
			set { _PrimerCursoLicencia = value; }
		}

		private bool? _SegundoCursoLicencia;
		public bool? SegundoCursoLicencia
		{
			get { return _SegundoCursoLicencia; }
			set { _SegundoCursoLicencia = value; }
		}

		private bool? _ExamenMedico;
		public bool? ExamenMedico
		{
			get { return _ExamenMedico; }
			set { _ExamenMedico = value; }
		}

		private bool? _Nomina;
		public bool? Nomina
		{
			get { return _Nomina; }
			set { _Nomina = value; }
		}

		private string _Colonia;
		public string Colonia
		{
			get { return _Colonia; }
			set { _Colonia = value; }
		}

		private int? _Dependientes;
		public int? Dependientes
		{
			get { return _Dependientes; }
			set { _Dependientes = value; }
		}

		private string _OcupacionEsposa;
		public string OcupacionEsposa
		{
			get { return _OcupacionEsposa; }
			set { _OcupacionEsposa = value; }
		}

		private string _TipoVivienda;
		public string TipoVivienda
		{
			get { return _TipoVivienda; }
			set { _TipoVivienda = value; }
		}

		private int? _GastosMensualesFijos;
		public int? GastosMensualesFijos
		{
			get { return _GastosMensualesFijos; }
			set { _GastosMensualesFijos = value; }
		}

		private int? _CleaverD;
		public int? CleaverD
		{
			get { return _CleaverD; }
			set { _CleaverD = value; }
		}

		private int? _CleaverI;
		public int? CleaverI
		{
			get { return _CleaverI; }
			set { _CleaverI = value; }
		}

		private int? _CleaverS;
		public int? CleaverS
		{
			get { return _CleaverS; }
			set { _CleaverS = value; }
		}

		private int? _CleaverC;
		public int? CleaverC
		{
			get { return _CleaverC; }
			set { _CleaverC = value; }
		}
		#endregion

		#region Methods
		public void Validate()
		{
			if (String.IsNullOrEmpty(this.Nombre)) throw new Exception("Nombre no puede estar vacío.");
			if (this.Nombre.Length > 50) throw new Exception("Nombre debe tener máximo 50 carateres.");

			if (String.IsNullOrEmpty(this.Apellidos)) throw new Exception("Apellidos no pueden estar vacío.");
			if (this.Apellidos.Length > 100) throw new Exception("Apellidos debe tener máximo 100 carateres.");

			if (String.IsNullOrEmpty(this.Domicilio)) throw new Exception("Domicilio no puede estar vacío.");
			if (this.Domicilio.Length > 150) throw new Exception("Domicilio debe tener máximo 150 carateres.");

			if (!String.IsNullOrEmpty(this.Colonia))
				if (this.Colonia.Length > 50) throw new Exception("Colonia debe tener máximo 50 carateres.");

			if (String.IsNullOrEmpty(this.Ciudad)) throw new Exception("Municipio no puede estar vacía.");
			if (this.Ciudad.Length > 50) throw new Exception("Municipio debe tener máximo 50 carateres.");

			if (String.IsNullOrEmpty(this.Entidad)) throw new Exception("Entidad no puede estar vacía.");
			if (this.Entidad.Length > 50) throw new Exception("Entidad debe tener máximo 50 carateres.");

			if (String.IsNullOrEmpty(this.Telefono)) throw new Exception("Teléfono no puede estar vacío.");
			if (!Regex.IsMatch(this.Telefono.ToUpper().Trim(), @"^([0-9]{8})([0-9]{2})?$")) throw new Exception("Debe teclear un teléfono válido de 8 o 10 dígitos.");

			if (!String.IsNullOrEmpty(this.Telefono2))
				if (this.Telefono2.Length > 30) throw new Exception("Telefono2 debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.Movil))
				if (this.Movil.Length > 30) throw new Exception("Movil debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.Email))
				if (this.Email.Length > 100) throw new Exception("Email debe tener máximo 100 carateres.");

			if (String.IsNullOrEmpty(this.RFC)) throw new Exception("RFC no puede estar vacío.");
			if (!Regex.IsMatch(this.RFC.ToUpper().Trim(), @"^[A-Z,Ñ]{4}[0-9]{2}[0-1][0-9][0-3][0-9]([A-Z,0-9][A-Z,0-9][0-9,A-Z])?$")) throw new Exception("RFC Inválido, el formato debe ser XXXX999999 sin homoclave o XXXX999999ZZZ con homoclave.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede estar vacío.");

			if (String.IsNullOrEmpty(this.CURP)) throw new Exception("CURP no puede estar vacío.");
			if (!Regex.IsMatch(this.CURP.ToUpper().Trim(), @"^[A-Z][A,E,I,O,U,X][A-Z]{2}[0-9]{2}[0-1][0-9][0-3][0-9][M,H][A-Z]{2}[B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3}[0-9,A-Z][0-9]$")) throw new Exception("CURP Inválido, favor de revisar el formato y asegurarse que no incluya guiones ni espacios.");

			if (String.IsNullOrEmpty(this.CodigoPostal)) throw new Exception("CodigoPostal no puede estar vacío.");
			if (!Regex.IsMatch(this.CodigoPostal.ToUpper().Trim(), @"^[0-9]{5}$")) throw new Exception("CodigoPostal debe contener 5 dígitos.");

			if (!String.IsNullOrEmpty(this.Fotografia))
				if (this.Fotografia.Length > 250) throw new Exception("Fotografia debe tener máximo 250 carateres.");

			if (this.EstatusConductor_ID == 0) throw new Exception("EstatusConductor_ID no puede estar vacío.");

			if (!String.IsNullOrEmpty(this.Comentarios))
				if (this.Comentarios.Length > 1073741823) throw new Exception("Comentarios debe tener máximo 1073741823 carateres.");

			if (this.Edad == null) throw new Exception("Edad no puede estar vacía.");
			if (this.Edad < 18 || this.Edad > 65) throw new Exception("La Edad debe ser entre 18 y 65 años.");

			if (String.IsNullOrEmpty(this.EstadoCivil)) throw new Exception("Estado Civil no puede estar vacío.");
			if (!Regex.IsMatch(this.EstadoCivil.ToUpper().Trim(), @"^(DIVORCIADO|SOLTERO|CASADO|VIUDO|SEPARADO|UNIÓN LIBRE|UNION LIBRE)$")) throw new Exception("Estado Civil de ser SOLTERO o CASADO o DIVORCIADO o VIUDO o SEPARADO o UNION LIBRE."); //  @(SOLTERO|CASADO|VIUDO|SEPARADO|UNION LIBRE)@"

			if (!String.IsNullOrEmpty(this.Genero))
				if (!Regex.IsMatch(this.Genero.ToUpper().Trim(), @"^[M,F]{1}$")) throw new Exception("Genero debe ser M o F.");

			if (!String.IsNullOrEmpty(this.FolioLicencia))
				if (this.FolioLicencia.Length > 30) throw new Exception("FolioLicencia debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.Rfc_Aval))
				if (!Regex.IsMatch(this.Rfc_Aval.ToUpper().Trim(), @"^[A-Z,Ñ]{4}[0-9]{2}[0-1][0-9][0-3][0-9]([A-Z,0-9][A-Z,0-9][0-9,A-Z])?$")) throw new Exception("RFC Aval Inválido, el formato debe ser XXXX999999 sin homoclave o XXXX999999ZZZ con homoclave.");

			if (!String.IsNullOrEmpty(this.Apellidos_Aval))
				if (this.Apellidos_Aval.Length > 100) throw new Exception("Apellidos_Aval debe tener máximo 100 carateres.");

			if (!String.IsNullOrEmpty(this.Nombre_Aval))
				if (this.Nombre_Aval.Length > 50) throw new Exception("Nombre_Aval debe tener máximo 50 carateres.");

			if (!String.IsNullOrEmpty(this.Curp_Aval))
				if (!Regex.IsMatch(this.Curp_Aval.ToUpper().Trim(), @"^[A-Z][A,E,I,O,U,X][A-Z]{2}[0-9]{2}[0-1][0-9][0-3][0-9][M,H][A-Z]{2}[B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3}[0-9,A-Z][0-9]$")) throw new Exception("CURP Aval Inválido, favor de revisar el formato y asegurarse que no incluya guiones ni espacios.");

			if (!String.IsNullOrEmpty(this.Domicilio_Aval))
				if (this.Domicilio_Aval.Length > 150) throw new Exception("Domicilio_Aval debe tener máximo 150 carateres.");

			if (!String.IsNullOrEmpty(this.Ciudad_Aval))
				if (this.Ciudad_Aval.Length > 50) throw new Exception("Ciudad_Aval debe tener máximo 50 carateres.");

			if (!String.IsNullOrEmpty(this.Estado_Aval))
				if (this.Estado_Aval.Length > 50) throw new Exception("Estado_Aval debe tener máximo 50 carateres.");

			if (!String.IsNullOrEmpty(this.CodigoPostal_Aval))
				if (!Regex.IsMatch(this.CodigoPostal_Aval.ToUpper().Trim(), @"^[0-9]{5}$")) throw new Exception("CodigoPostal Aval debe contener 5 dígitos.");

			if (!String.IsNullOrEmpty(this.Telefono_Aval))
				if (!Regex.IsMatch(this.Telefono_Aval.ToUpper().Trim(), @"^([0-9]{8})([0-9]{2})?$")) throw new Exception("Debe teclear un teléfono válido de 8 o 10 dígitos.");

			if (!String.IsNullOrEmpty(this.Email_Aval))
				if (this.Email_Aval.Length > 100) throw new Exception("Email_Aval debe tener máximo 100 carateres.");

			if (!String.IsNullOrEmpty(this.Solicitud))
				if (this.Solicitud.Length > 30) throw new Exception("Solicitud debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.ActaNacimiento))
				if (this.ActaNacimiento.Length > 30) throw new Exception("ActaNacimiento debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.CredencialElector))
				if (!Regex.IsMatch(this.CredencialElector.ToUpper().Trim(), @"^[0-9]{13}$")) throw new Exception("CredencialElector debe tener 13 dígitos.");

			if (!String.IsNullOrEmpty(this.CartaNoAntecedentes))
				if (this.CartaNoAntecedentes.Length > 30) throw new Exception("CartaNoAntecedentes debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.ComprobanteDomicilio))
				if (this.ComprobanteDomicilio.Length > 30) throw new Exception("ComprobanteDomicilio debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.CredencialElector_Aval))
				if (!Regex.IsMatch(this.CredencialElector_Aval.ToUpper().Trim(), @"^[0-9]{13}$")) throw new Exception("CredencialElector debe tener 13 dígitos.");

			if (!String.IsNullOrEmpty(this.ComprobanteDomicilio_Aval))
				if (this.ComprobanteDomicilio_Aval.Length > 50) throw new Exception("ComprobanteDomicilio_Aval debe tener máximo 50 carateres.");

			if (!String.IsNullOrEmpty(this.MensajeACaja))
				if (this.MensajeACaja.Length > 200) throw new Exception("MensajeACaja debe tener máximo 200 carateres.");

			if (this.Fecha == null) throw new Exception("Fecha no puede estar vacía.");

			if (!String.IsNullOrEmpty(this.Usuario_ID))
				if (this.Usuario_ID.Length > 30) throw new Exception("Usuario_ID debe tener máximo 30 carateres.");

			if (!String.IsNullOrEmpty(this.OcupacionEsposa))
				if (this.OcupacionEsposa.Length > 50) throw new Exception("OcupacionEsposa debe tener máximo 50 carateres.");

			if (!String.IsNullOrEmpty(this.TipoVivienda))
				if (!Regex.IsMatch(this.TipoVivienda.ToUpper().Trim(), @"^(RENTA|PROPIA|PRESTADA)$")) throw new Exception("Tipo de Vivienda de ser RENTA o PROPIA o PRESTADA");

		} // End Validate

		public int Create()
		{
			DataTable dt = DB.Read("Conductores", DB.Param("CURP", this.CURP.ToUpper().Trim()));
			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				throw new Exception("Favor de verificar el CURP porque el conductor No. " + dr["Conductor_ID"] + " tiene el mismo CURP en la Base de Datos.");
			}

			Hashtable m_params = new Hashtable();
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos)) m_params.Add("Apellidos", this.Apellidos.ToUpper().Trim());
			m_params.Add("Domicilio", this.Domicilio);
			if (!DB.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			if (!DB.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!DB.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!DB.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!DB.IsNullOrEmpty(this.RFC)) m_params.Add("RFC", this.RFC.ToUpper().Trim());
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.CURP)) m_params.Add("CURP", this.CURP.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.CodigoPostal)) m_params.Add("CodigoPostal", this.CodigoPostal);
			if (!DB.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			if (!DB.IsNullOrEmpty(this.MedioPublicitario_ID)) m_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
			if (!DB.IsNullOrEmpty(this.CumplioPerfil)) m_params.Add("CumplioPerfil", this.CumplioPerfil);
			if (!DB.IsNullOrEmpty(this.Interesado)) m_params.Add("Interesado", this.Interesado);
			if (!DB.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!DB.IsNullOrEmpty(this.Edad)) m_params.Add("Edad", this.Edad);
			if (!DB.IsNullOrEmpty(this.EstadoCivil)) m_params.Add("EstadoCivil", this.EstadoCivil.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.AñosExperiencia)) m_params.Add("AñosExperiencia", this.AñosExperiencia);
			if (!DB.IsNullOrEmpty(this.Genero)) m_params.Add("Genero", this.Genero.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.TipoLicencia_ID)) m_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioLicencia)) m_params.Add("FolioLicencia", this.FolioLicencia);
			if (!DB.IsNullOrEmpty(this.VenceLicencia)) m_params.Add("VenceLicencia", this.VenceLicencia);
			if (!DB.IsNullOrEmpty(this.Rfc_Aval)) m_params.Add("Rfc_Aval", this.Rfc_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos_Aval)) m_params.Add("Apellidos_Aval", this.Apellidos_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Nombre_Aval)) m_params.Add("Nombre_Aval", this.Nombre_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Curp_Aval)) m_params.Add("Curp_Aval", this.Curp_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Domicilio_Aval)) m_params.Add("Domicilio_Aval", this.Domicilio_Aval);
			if (!DB.IsNullOrEmpty(this.Ciudad_Aval)) m_params.Add("Ciudad_Aval", this.Ciudad_Aval);
			if (!DB.IsNullOrEmpty(this.Estado_Aval)) m_params.Add("Estado_Aval", this.Estado_Aval);
			if (!DB.IsNullOrEmpty(this.CodigoPostal_Aval)) m_params.Add("CodigoPostal_Aval", this.CodigoPostal_Aval);
			if (!DB.IsNullOrEmpty(this.Telefono_Aval)) m_params.Add("Telefono_Aval", this.Telefono_Aval);
			if (!DB.IsNullOrEmpty(this.Email_Aval)) m_params.Add("Email_Aval", this.Email_Aval);
			if (!DB.IsNullOrEmpty(this.Solicitud)) m_params.Add("Solicitud", this.Solicitud);
			if (!DB.IsNullOrEmpty(this.ActaNacimiento)) m_params.Add("ActaNacimiento", this.ActaNacimiento);
			if (!DB.IsNullOrEmpty(this.CredencialElector)) m_params.Add("CredencialElector", this.CredencialElector);
			if (!DB.IsNullOrEmpty(this.CartaNoAntecedentes)) m_params.Add("CartaNoAntecedentes", this.CartaNoAntecedentes);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio)) m_params.Add("ComprobanteDomicilio", this.ComprobanteDomicilio);
			if (!DB.IsNullOrEmpty(this.CredencialElector_Aval)) m_params.Add("CredencialElector_Aval", this.CredencialElector_Aval);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio_Aval)) m_params.Add("ComprobanteDomicilio_Aval", this.ComprobanteDomicilio_Aval);
			if (!DB.IsNullOrEmpty(this.SaldoATratar)) m_params.Add("SaldoATratar", this.SaldoATratar);
			if (!DB.IsNullOrEmpty(this.Cronocasco)) m_params.Add("Cronocasco", this.Cronocasco);
			if (!DB.IsNullOrEmpty(this.TerminalDatos)) m_params.Add("TerminalDatos", this.TerminalDatos);
			if (!DB.IsNullOrEmpty(this.BloquearConductor)) m_params.Add("BloquearConductor", this.BloquearConductor);
			if (!DB.IsNullOrEmpty(this.MensajeACaja)) m_params.Add("MensajeACaja", this.MensajeACaja);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.PrimerCursoLicencia)) m_params.Add("PrimerCursoLicencia", this.PrimerCursoLicencia);
			if (!DB.IsNullOrEmpty(this.SegundoCursoLicencia)) m_params.Add("SegundoCursoLicencia", this.SegundoCursoLicencia);
			if (!DB.IsNullOrEmpty(this.ExamenMedico)) m_params.Add("ExamenMedico", this.ExamenMedico);
			if (!DB.IsNullOrEmpty(this.Nomina)) m_params.Add("Nomina", this.Nomina);
			if (!DB.IsNullOrEmpty(this.Dependientes)) m_params.Add("Dependientes", this.Dependientes);
			if (!DB.IsNullOrEmpty(this.OcupacionEsposa)) m_params.Add("OcupacionEsposa", this.OcupacionEsposa);
			if (!DB.IsNullOrEmpty(this.TipoVivienda)) m_params.Add("TipoVivienda", this.TipoVivienda);
			if (!DB.IsNullOrEmpty(this.GastosMensualesFijos)) m_params.Add("GastosMensualesFijos", this.GastosMensualesFijos);
			if (!DB.IsNullOrEmpty(this.CleaverD)) m_params.Add("CleaverD", this.CleaverD);
			if (!DB.IsNullOrEmpty(this.CleaverI)) m_params.Add("CleaverI", this.CleaverI);
			if (!DB.IsNullOrEmpty(this.CleaverS)) m_params.Add("CleaverS", this.CleaverS);
			if (!DB.IsNullOrEmpty(this.CleaverC)) m_params.Add("CleaverC", this.CleaverC);


			return DB.InsertRow("Conductores", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();

			DataTable dt = DB.Read("Conductores", DB.Param("CURP", this.CURP.ToUpper().Trim()));
			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				throw new Exception("Favor de verificar el CURP porque el conductor No. " + dr["Conductor_ID"] + " tiene el mismo CURP en la Base de Datos.");
			}

			Hashtable m_params = new Hashtable();
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos)) m_params.Add("Apellidos", this.Apellidos.ToUpper().Trim());
			m_params.Add("Domicilio", this.Domicilio);
			if (!DB.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			if (!DB.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!DB.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!DB.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!DB.IsNullOrEmpty(this.RFC)) m_params.Add("RFC", this.RFC.ToUpper().Trim());
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.CURP)) m_params.Add("CURP", this.CURP.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.CodigoPostal)) m_params.Add("CodigoPostal", this.CodigoPostal);
			if (!DB.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			if (!DB.IsNullOrEmpty(this.MedioPublicitario_ID)) m_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
			if (!DB.IsNullOrEmpty(this.CumplioPerfil)) m_params.Add("CumplioPerfil", this.CumplioPerfil);
			if (!DB.IsNullOrEmpty(this.Interesado)) m_params.Add("Interesado", this.Interesado);
			if (!DB.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!DB.IsNullOrEmpty(this.Edad)) m_params.Add("Edad", this.Edad);
			if (!DB.IsNullOrEmpty(this.EstadoCivil)) m_params.Add("EstadoCivil", this.EstadoCivil.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.AñosExperiencia)) m_params.Add("AñosExperiencia", this.AñosExperiencia);
			if (!DB.IsNullOrEmpty(this.Genero)) m_params.Add("Genero", this.Genero.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.TipoLicencia_ID)) m_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioLicencia)) m_params.Add("FolioLicencia", this.FolioLicencia);
			if (!DB.IsNullOrEmpty(this.VenceLicencia)) m_params.Add("VenceLicencia", this.VenceLicencia);
			if (!DB.IsNullOrEmpty(this.Rfc_Aval)) m_params.Add("Rfc_Aval", this.Rfc_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos_Aval)) m_params.Add("Apellidos_Aval", this.Apellidos_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Nombre_Aval)) m_params.Add("Nombre_Aval", this.Nombre_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Curp_Aval)) m_params.Add("Curp_Aval", this.Curp_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Domicilio_Aval)) m_params.Add("Domicilio_Aval", this.Domicilio_Aval);
			if (!DB.IsNullOrEmpty(this.Ciudad_Aval)) m_params.Add("Ciudad_Aval", this.Ciudad_Aval);
			if (!DB.IsNullOrEmpty(this.Estado_Aval)) m_params.Add("Estado_Aval", this.Estado_Aval);
			if (!DB.IsNullOrEmpty(this.CodigoPostal_Aval)) m_params.Add("CodigoPostal_Aval", this.CodigoPostal_Aval);
			if (!DB.IsNullOrEmpty(this.Telefono_Aval)) m_params.Add("Telefono_Aval", this.Telefono_Aval);
			if (!DB.IsNullOrEmpty(this.Email_Aval)) m_params.Add("Email_Aval", this.Email_Aval);
			if (!DB.IsNullOrEmpty(this.Solicitud)) m_params.Add("Solicitud", this.Solicitud);
			if (!DB.IsNullOrEmpty(this.ActaNacimiento)) m_params.Add("ActaNacimiento", this.ActaNacimiento);
			if (!DB.IsNullOrEmpty(this.CredencialElector)) m_params.Add("CredencialElector", this.CredencialElector);
			if (!DB.IsNullOrEmpty(this.CartaNoAntecedentes)) m_params.Add("CartaNoAntecedentes", this.CartaNoAntecedentes);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio)) m_params.Add("ComprobanteDomicilio", this.ComprobanteDomicilio);
			if (!DB.IsNullOrEmpty(this.CredencialElector_Aval)) m_params.Add("CredencialElector_Aval", this.CredencialElector_Aval);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio_Aval)) m_params.Add("ComprobanteDomicilio_Aval", this.ComprobanteDomicilio_Aval);
			if (!DB.IsNullOrEmpty(this.SaldoATratar)) m_params.Add("SaldoATratar", this.SaldoATratar);
			if (!DB.IsNullOrEmpty(this.Cronocasco)) m_params.Add("Cronocasco", this.Cronocasco);
			if (!DB.IsNullOrEmpty(this.TerminalDatos)) m_params.Add("TerminalDatos", this.TerminalDatos);
			if (!DB.IsNullOrEmpty(this.BloquearConductor)) m_params.Add("BloquearConductor", this.BloquearConductor);
			if (!DB.IsNullOrEmpty(this.MensajeACaja)) m_params.Add("MensajeACaja", this.MensajeACaja);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.PrimerCursoLicencia)) m_params.Add("PrimerCursoLicencia", this.PrimerCursoLicencia);
			if (!DB.IsNullOrEmpty(this.SegundoCursoLicencia)) m_params.Add("SegundoCursoLicencia", this.SegundoCursoLicencia);
			if (!DB.IsNullOrEmpty(this.ExamenMedico)) m_params.Add("ExamenMedico", this.ExamenMedico);
			if (!DB.IsNullOrEmpty(this.Nomina)) m_params.Add("Nomina", this.Nomina);
			if (!DB.IsNullOrEmpty(this.Dependientes)) m_params.Add("Dependientes", this.Dependientes);
			if (!DB.IsNullOrEmpty(this.OcupacionEsposa)) m_params.Add("OcupacionEsposa", this.OcupacionEsposa);
			if (!DB.IsNullOrEmpty(this.TipoVivienda)) m_params.Add("TipoVivienda", this.TipoVivienda);
			if (!DB.IsNullOrEmpty(this.GastosMensualesFijos)) m_params.Add("GastosMensualesFijos", this.GastosMensualesFijos);
			if (!DB.IsNullOrEmpty(this.CleaverD)) m_params.Add("CleaverD", this.CleaverD);
			if (!DB.IsNullOrEmpty(this.CleaverI)) m_params.Add("CleaverI", this.CleaverI);
			if (!DB.IsNullOrEmpty(this.CleaverS)) m_params.Add("CleaverS", this.CleaverS);
			if (!DB.IsNullOrEmpty(this.CleaverC)) m_params.Add("CleaverC", this.CleaverC);

			return DB.IdentityInsertRow("Conductores", m_params);
		} // End Create

		public static List<Conductores> Read()
		{
			List<Conductores> list = new List<Conductores>();
			DataTable dt = DB.Select("Conductores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Conductores(
					   Convert.ToInt32(dr["Conductor_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Apellidos"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Ciudad"]),
					   Convert.ToString(dr["Entidad"]),
					   Convert.ToString(dr["Telefono"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToString(dr["Movil"]),
					   Convert.ToString(dr["Email"]),
					   Convert.ToString(dr["RFC"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["CURP"]),
					   Convert.ToString(dr["CodigoPostal"]),
					   Convert.ToString(dr["Fotografia"]),
					   Convert.ToInt32(dr["EstatusConductor_ID"]),
					   DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					   DB.GetNullableBoolean(dr["CumplioPerfil"]),
					   DB.GetNullableBoolean(dr["Interesado"]),
					   DB.GetNullableInt32(dr["Mercado_ID"]),
					   Convert.ToString(dr["Comentarios"]),
					   DB.GetNullableInt32(dr["Edad"]),
					   Convert.ToString(dr["EstadoCivil"]),
					   DB.GetNullableInt32(dr["AñosExperiencia"]),
					   Convert.ToString(dr["Genero"]),
					   DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					   Convert.ToString(dr["FolioLicencia"]),
					   DB.GetNullableDateTime(dr["VenceLicencia"]),
					   Convert.ToString(dr["Rfc_Aval"]),
					   Convert.ToString(dr["Apellidos_Aval"]),
					   Convert.ToString(dr["Nombre_Aval"]),
					   Convert.ToString(dr["Curp_Aval"]),
					   Convert.ToString(dr["Domicilio_Aval"]),
					   Convert.ToString(dr["Ciudad_Aval"]),
					   Convert.ToString(dr["Estado_Aval"]),
					   Convert.ToString(dr["CodigoPostal_Aval"]),
					   Convert.ToString(dr["Telefono_Aval"]),
					   Convert.ToString(dr["Email_Aval"]),
					   Convert.ToString(dr["Solicitud"]),
					   Convert.ToString(dr["ActaNacimiento"]),
					   Convert.ToString(dr["CredencialElector"]),
					   Convert.ToString(dr["CartaNoAntecedentes"]),
					   Convert.ToString(dr["ComprobanteDomicilio"]),
					   Convert.ToString(dr["CredencialElector_Aval"]),
					   Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					   DB.GetNullableDecimal(dr["SaldoATratar"]),
					   DB.GetNullableBoolean(dr["Cronocasco"]),
					   DB.GetNullableBoolean(dr["TerminalDatos"]),
					   DB.GetNullableBoolean(dr["BloquearConductor"]),
					   Convert.ToString(dr["MensajeACaja"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					   DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					   DB.GetNullableBoolean(dr["ExamenMedico"]),
					   DB.GetNullableBoolean(dr["Nomina"]),
					   Convert.ToString(dr["Colonia"]),
					   DB.GetNullableInt32(dr["Dependientes"]),
					   Convert.ToString(dr["OcupacionEsposa"]),
					   Convert.ToString(dr["TipoVivienda"]),
					   DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					   DB.GetNullableInt32(dr["CleaverD"]),
					   DB.GetNullableInt32(dr["CleaverI"]),
					   DB.GetNullableInt32(dr["CleaverS"]),
					   DB.GetNullableInt32(dr["CleaverC"])
				    )
				);
			}

			return list;
		} // End Read

		public static Conductores Read(DataRowView dr)
		{
			DateTime fecha;
			if (AppHelper.IsNullOrEmpty(dr["Fecha"]))
			{
				fecha = DateTime.Now;
			}
			else
			{
				fecha = Convert.ToDateTime(dr["Fecha"]);
			}

			return new Conductores(
			    Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToString(dr["Movil"]),
					  Convert.ToString(dr["Email"]),
					  Convert.ToString(dr["RFC"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["CURP"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Fotografia"]),
					  Convert.ToInt32(dr["EstatusConductor_ID"]),
					  DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					  DB.GetNullableBoolean(dr["CumplioPerfil"]),
					  DB.GetNullableBoolean(dr["Interesado"]),
					  DB.GetNullableInt32(dr["Mercado_ID"]),
					  Convert.ToString(dr["Comentarios"]),
					  DB.GetNullableInt32(dr["Edad"]),
					  Convert.ToString(dr["EstadoCivil"]),
					  DB.GetNullableInt32(dr["AñosExperiencia"]),
					  Convert.ToString(dr["Genero"]),
					  DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					  Convert.ToString(dr["FolioLicencia"]),
					  DB.GetNullableDateTime(dr["VenceLicencia"]),
					  Convert.ToString(dr["Rfc_Aval"]),
					  Convert.ToString(dr["Apellidos_Aval"]),
					  Convert.ToString(dr["Nombre_Aval"]),
					  Convert.ToString(dr["Curp_Aval"]),
					  Convert.ToString(dr["Domicilio_Aval"]),
					  Convert.ToString(dr["Ciudad_Aval"]),
					  Convert.ToString(dr["Estado_Aval"]),
					  Convert.ToString(dr["CodigoPostal_Aval"]),
					  Convert.ToString(dr["Telefono_Aval"]),
					  Convert.ToString(dr["Email_Aval"]),
					  Convert.ToString(dr["Solicitud"]),
					  Convert.ToString(dr["ActaNacimiento"]),
					  Convert.ToString(dr["CredencialElector"]),
					  Convert.ToString(dr["CartaNoAntecedentes"]),
					  Convert.ToString(dr["ComprobanteDomicilio"]),
					  Convert.ToString(dr["CredencialElector_Aval"]),
					  Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					  DB.GetNullableDecimal(dr["SaldoATratar"]),
					  DB.GetNullableBoolean(dr["Cronocasco"]),
					  DB.GetNullableBoolean(dr["TerminalDatos"]),
					  DB.GetNullableBoolean(dr["BloquearConductor"]),
					  Convert.ToString(dr["MensajeACaja"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					  DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					  DB.GetNullableBoolean(dr["ExamenMedico"]),
					  DB.GetNullableBoolean(dr["Nomina"]),
					  Convert.ToString(dr["Colonia"]),
					  DB.GetNullableInt32(dr["Dependientes"]),
					  Convert.ToString(dr["OcupacionEsposa"]),
					  Convert.ToString(dr["TipoVivienda"]),
					  DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					  DB.GetNullableInt32(dr["CleaverD"]),
					  DB.GetNullableInt32(dr["CleaverI"]),
					  DB.GetNullableInt32(dr["CleaverS"]),
					  DB.GetNullableInt32(dr["CleaverC"])
				   );
		}

		public static Conductores Read(int conductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Conductor_ID", conductor_id);
			DataTable dt = DB.Select("Conductores", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Conductores con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Conductores(
			    Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToString(dr["Movil"]),
					  Convert.ToString(dr["Email"]),
					  Convert.ToString(dr["RFC"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["CURP"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Fotografia"]),
					  Convert.ToInt32(dr["EstatusConductor_ID"]),
					  DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					  DB.GetNullableBoolean(dr["CumplioPerfil"]),
					  DB.GetNullableBoolean(dr["Interesado"]),
					  DB.GetNullableInt32(dr["Mercado_ID"]),
					  Convert.ToString(dr["Comentarios"]),
					  DB.GetNullableInt32(dr["Edad"]),
					  Convert.ToString(dr["EstadoCivil"]),
					  DB.GetNullableInt32(dr["AñosExperiencia"]),
					  Convert.ToString(dr["Genero"]),
					  DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					  Convert.ToString(dr["FolioLicencia"]),
					  DB.GetNullableDateTime(dr["VenceLicencia"]),
					  Convert.ToString(dr["Rfc_Aval"]),
					  Convert.ToString(dr["Apellidos_Aval"]),
					  Convert.ToString(dr["Nombre_Aval"]),
					  Convert.ToString(dr["Curp_Aval"]),
					  Convert.ToString(dr["Domicilio_Aval"]),
					  Convert.ToString(dr["Ciudad_Aval"]),
					  Convert.ToString(dr["Estado_Aval"]),
					  Convert.ToString(dr["CodigoPostal_Aval"]),
					  Convert.ToString(dr["Telefono_Aval"]),
					  Convert.ToString(dr["Email_Aval"]),
					  Convert.ToString(dr["Solicitud"]),
					  Convert.ToString(dr["ActaNacimiento"]),
					  Convert.ToString(dr["CredencialElector"]),
					  Convert.ToString(dr["CartaNoAntecedentes"]),
					  Convert.ToString(dr["ComprobanteDomicilio"]),
					  Convert.ToString(dr["CredencialElector_Aval"]),
					  Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					  DB.GetNullableDecimal(dr["SaldoATratar"]),
					  DB.GetNullableBoolean(dr["Cronocasco"]),
					  DB.GetNullableBoolean(dr["TerminalDatos"]),
					  DB.GetNullableBoolean(dr["BloquearConductor"]),
					  Convert.ToString(dr["MensajeACaja"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					  DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					  DB.GetNullableBoolean(dr["ExamenMedico"]),
					  DB.GetNullableBoolean(dr["Nomina"]),
					  Convert.ToString(dr["Colonia"]),
					  DB.GetNullableInt32(dr["Dependientes"]),
					  Convert.ToString(dr["OcupacionEsposa"]),
					  Convert.ToString(dr["TipoVivienda"]),
					  DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					  DB.GetNullableInt32(dr["CleaverD"]),
					  DB.GetNullableInt32(dr["CleaverI"]),
					  DB.GetNullableInt32(dr["CleaverS"]),
					  DB.GetNullableInt32(dr["CleaverC"])
				   );
		} // End Read

		public static List<Conductores> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Conductores> list = new List<Conductores>();
			DataTable dt = DB.Read("Conductores", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Conductores(
					   Convert.ToInt32(dr["Conductor_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Apellidos"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Ciudad"]),
					   Convert.ToString(dr["Entidad"]),
					   Convert.ToString(dr["Telefono"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToString(dr["Movil"]),
					   Convert.ToString(dr["Email"]),
					   Convert.ToString(dr["RFC"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["CURP"]),
					   Convert.ToString(dr["CodigoPostal"]),
					   Convert.ToString(dr["Fotografia"]),
					   Convert.ToInt32(dr["EstatusConductor_ID"]),
					   DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					   DB.GetNullableBoolean(dr["CumplioPerfil"]),
					   DB.GetNullableBoolean(dr["Interesado"]),
					   DB.GetNullableInt32(dr["Mercado_ID"]),
					   Convert.ToString(dr["Comentarios"]),
					   DB.GetNullableInt32(dr["Edad"]),
					   Convert.ToString(dr["EstadoCivil"]),
					   DB.GetNullableInt32(dr["AñosExperiencia"]),
					   Convert.ToString(dr["Genero"]),
					   DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					   Convert.ToString(dr["FolioLicencia"]),
					   DB.GetNullableDateTime(dr["VenceLicencia"]),
					   Convert.ToString(dr["Rfc_Aval"]),
					   Convert.ToString(dr["Apellidos_Aval"]),
					   Convert.ToString(dr["Nombre_Aval"]),
					   Convert.ToString(dr["Curp_Aval"]),
					   Convert.ToString(dr["Domicilio_Aval"]),
					   Convert.ToString(dr["Ciudad_Aval"]),
					   Convert.ToString(dr["Estado_Aval"]),
					   Convert.ToString(dr["CodigoPostal_Aval"]),
					   Convert.ToString(dr["Telefono_Aval"]),
					   Convert.ToString(dr["Email_Aval"]),
					   Convert.ToString(dr["Solicitud"]),
					   Convert.ToString(dr["ActaNacimiento"]),
					   Convert.ToString(dr["CredencialElector"]),
					   Convert.ToString(dr["CartaNoAntecedentes"]),
					   Convert.ToString(dr["ComprobanteDomicilio"]),
					   Convert.ToString(dr["CredencialElector_Aval"]),
					   Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					   DB.GetNullableDecimal(dr["SaldoATratar"]),
					   DB.GetNullableBoolean(dr["Cronocasco"]),
					   DB.GetNullableBoolean(dr["TerminalDatos"]),
					   DB.GetNullableBoolean(dr["BloquearConductor"]),
					   Convert.ToString(dr["MensajeACaja"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					   DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					   DB.GetNullableBoolean(dr["ExamenMedico"]),
					   DB.GetNullableBoolean(dr["Nomina"]),
					   Convert.ToString(dr["Colonia"]),
					   DB.GetNullableInt32(dr["Dependientes"]),
					   Convert.ToString(dr["OcupacionEsposa"]),
					   Convert.ToString(dr["TipoVivienda"]),
					   DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					   DB.GetNullableInt32(dr["CleaverD"]),
					   DB.GetNullableInt32(dr["CleaverI"]),
					   DB.GetNullableInt32(dr["CleaverS"]),
					   DB.GetNullableInt32(dr["CleaverC"])
				    )
				);
			}
			return list;
		} // End Read

		public static List<Conductores> Read(params KeyValuePair<string, object>[] args)
		{
			List<Conductores> list = new List<Conductores>();
			DataTable dt = DB.Read("Conductores", args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Conductores(
					   Convert.ToInt32(dr["Conductor_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Apellidos"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Ciudad"]),
					   Convert.ToString(dr["Entidad"]),
					   Convert.ToString(dr["Telefono"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToString(dr["Movil"]),
					   Convert.ToString(dr["Email"]),
					   Convert.ToString(dr["RFC"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["CURP"]),
					   Convert.ToString(dr["CodigoPostal"]),
					   Convert.ToString(dr["Fotografia"]),
					   Convert.ToInt32(dr["EstatusConductor_ID"]),
					   DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					   DB.GetNullableBoolean(dr["CumplioPerfil"]),
					   DB.GetNullableBoolean(dr["Interesado"]),
					   DB.GetNullableInt32(dr["Mercado_ID"]),
					   Convert.ToString(dr["Comentarios"]),
					   DB.GetNullableInt32(dr["Edad"]),
					   Convert.ToString(dr["EstadoCivil"]),
					   DB.GetNullableInt32(dr["AñosExperiencia"]),
					   Convert.ToString(dr["Genero"]),
					   DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					   Convert.ToString(dr["FolioLicencia"]),
					   DB.GetNullableDateTime(dr["VenceLicencia"]),
					   Convert.ToString(dr["Rfc_Aval"]),
					   Convert.ToString(dr["Apellidos_Aval"]),
					   Convert.ToString(dr["Nombre_Aval"]),
					   Convert.ToString(dr["Curp_Aval"]),
					   Convert.ToString(dr["Domicilio_Aval"]),
					   Convert.ToString(dr["Ciudad_Aval"]),
					   Convert.ToString(dr["Estado_Aval"]),
					   Convert.ToString(dr["CodigoPostal_Aval"]),
					   Convert.ToString(dr["Telefono_Aval"]),
					   Convert.ToString(dr["Email_Aval"]),
					   Convert.ToString(dr["Solicitud"]),
					   Convert.ToString(dr["ActaNacimiento"]),
					   Convert.ToString(dr["CredencialElector"]),
					   Convert.ToString(dr["CartaNoAntecedentes"]),
					   Convert.ToString(dr["ComprobanteDomicilio"]),
					   Convert.ToString(dr["CredencialElector_Aval"]),
					   Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					   DB.GetNullableDecimal(dr["SaldoATratar"]),
					   DB.GetNullableBoolean(dr["Cronocasco"]),
					   DB.GetNullableBoolean(dr["TerminalDatos"]),
					   DB.GetNullableBoolean(dr["BloquearConductor"]),
					   Convert.ToString(dr["MensajeACaja"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					   DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					   DB.GetNullableBoolean(dr["ExamenMedico"]),
					   DB.GetNullableBoolean(dr["Nomina"]),
					   Convert.ToString(dr["Colonia"]),
					   DB.GetNullableInt32(dr["Dependientes"]),
					   Convert.ToString(dr["OcupacionEsposa"]),
					   Convert.ToString(dr["TipoVivienda"]),
					   DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					   DB.GetNullableInt32(dr["CleaverD"]),
					   DB.GetNullableInt32(dr["CleaverI"]),
					   DB.GetNullableInt32(dr["CleaverS"]),
					   DB.GetNullableInt32(dr["CleaverC"])
				    )
				);
			}
			return list;
		} // End Read


		public static bool Read(
		    out Conductores conductores,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Conductores", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				conductores = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			conductores = new Conductores(
			    Convert.ToInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToString(dr["Movil"]),
					  Convert.ToString(dr["Email"]),
					  Convert.ToString(dr["RFC"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["CURP"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Fotografia"]),
					  Convert.ToInt32(dr["EstatusConductor_ID"]),
					  DB.GetNullableInt32(dr["MedioPublicitario_ID"]),
					  DB.GetNullableBoolean(dr["CumplioPerfil"]),
					  DB.GetNullableBoolean(dr["Interesado"]),
					  DB.GetNullableInt32(dr["Mercado_ID"]),
					  Convert.ToString(dr["Comentarios"]),
					  DB.GetNullableInt32(dr["Edad"]),
					  Convert.ToString(dr["EstadoCivil"]),
					  DB.GetNullableInt32(dr["AñosExperiencia"]),
					  Convert.ToString(dr["Genero"]),
					  DB.GetNullableInt32(dr["TipoLicencia_ID"]),
					  Convert.ToString(dr["FolioLicencia"]),
					  DB.GetNullableDateTime(dr["VenceLicencia"]),
					  Convert.ToString(dr["Rfc_Aval"]),
					  Convert.ToString(dr["Apellidos_Aval"]),
					  Convert.ToString(dr["Nombre_Aval"]),
					  Convert.ToString(dr["Curp_Aval"]),
					  Convert.ToString(dr["Domicilio_Aval"]),
					  Convert.ToString(dr["Ciudad_Aval"]),
					  Convert.ToString(dr["Estado_Aval"]),
					  Convert.ToString(dr["CodigoPostal_Aval"]),
					  Convert.ToString(dr["Telefono_Aval"]),
					  Convert.ToString(dr["Email_Aval"]),
					  Convert.ToString(dr["Solicitud"]),
					  Convert.ToString(dr["ActaNacimiento"]),
					  Convert.ToString(dr["CredencialElector"]),
					  Convert.ToString(dr["CartaNoAntecedentes"]),
					  Convert.ToString(dr["ComprobanteDomicilio"]),
					  Convert.ToString(dr["CredencialElector_Aval"]),
					  Convert.ToString(dr["ComprobanteDomicilio_Aval"]),
					  DB.GetNullableDecimal(dr["SaldoATratar"]),
					  DB.GetNullableBoolean(dr["Cronocasco"]),
					  DB.GetNullableBoolean(dr["TerminalDatos"]),
					  DB.GetNullableBoolean(dr["BloquearConductor"]),
					  Convert.ToString(dr["MensajeACaja"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableBoolean(dr["PrimerCursoLicencia"]),
					  DB.GetNullableBoolean(dr["SegundoCursoLicencia"]),
					  DB.GetNullableBoolean(dr["ExamenMedico"]),
					  DB.GetNullableBoolean(dr["Nomina"]),
					  Convert.ToString(dr["Colonia"]),
					  DB.GetNullableInt32(dr["Dependientes"]),
					  Convert.ToString(dr["OcupacionEsposa"]),
					  Convert.ToString(dr["TipoVivienda"]),
					  DB.GetNullableInt32(dr["GastosMensualesFijos"]),
					  DB.GetNullableInt32(dr["CleaverD"]),
					  DB.GetNullableInt32(dr["CleaverI"]),
					  DB.GetNullableInt32(dr["CleaverS"]),
					  DB.GetNullableInt32(dr["CleaverC"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Conductores");
		} // End Read

		public static DataTable ReadDataTable(int conductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Conductor_ID", conductor_id);
			return DB.Select("Conductores", w_params);
		} // End Read

		public int Update(bool validaCurp)
		{
			if (!DB.IsNullOrEmpty(this.CURP) && validaCurp)
			{
				string filter = "CURP = '" + this.CURP.ToUpper().Trim() + "' AND Conductor_ID <> " + this.Conductor_ID.ToString();
				if (DB.GetCount("Conductores", filter) > 0) throw new Exception("Favor de verificar el CURP porque ya existe en la Base de Datos para otro conductor. Es necesario reportar este caso a Soporte para proceder a la integración de conductores.");
			}

			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Conductor_ID", this.Conductor_ID);
			if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos)) m_params.Add("Apellidos", this.Apellidos.ToUpper().Trim());
			m_params.Add("Domicilio", this.Domicilio);
			if (!DB.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			if (!DB.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!DB.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!DB.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!DB.IsNullOrEmpty(this.RFC)) m_params.Add("RFC", this.RFC.ToUpper().Trim());
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.CURP)) m_params.Add("CURP", this.CURP.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.CodigoPostal)) m_params.Add("CodigoPostal", this.CodigoPostal);
			if (!DB.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			if (!DB.IsNullOrEmpty(this.MedioPublicitario_ID)) m_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
			if (!DB.IsNullOrEmpty(this.CumplioPerfil)) m_params.Add("CumplioPerfil", this.CumplioPerfil);
			if (!DB.IsNullOrEmpty(this.Interesado)) m_params.Add("Interesado", this.Interesado);
			if (!DB.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!DB.IsNullOrEmpty(this.Edad)) m_params.Add("Edad", this.Edad);
			if (!DB.IsNullOrEmpty(this.EstadoCivil)) m_params.Add("EstadoCivil", this.EstadoCivil.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.AñosExperiencia)) m_params.Add("AñosExperiencia", this.AñosExperiencia);
			if (!DB.IsNullOrEmpty(this.Genero)) m_params.Add("Genero", this.Genero.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.TipoLicencia_ID)) m_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
			if (!DB.IsNullOrEmpty(this.FolioLicencia)) m_params.Add("FolioLicencia", this.FolioLicencia);
			if (!DB.IsNullOrEmpty(this.VenceLicencia)) m_params.Add("VenceLicencia", this.VenceLicencia);
			if (!DB.IsNullOrEmpty(this.Rfc_Aval)) m_params.Add("Rfc_Aval", this.Rfc_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Apellidos_Aval)) m_params.Add("Apellidos_Aval", this.Apellidos_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Nombre_Aval)) m_params.Add("Nombre_Aval", this.Nombre_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Curp_Aval)) m_params.Add("Curp_Aval", this.Curp_Aval.ToUpper().Trim());
			if (!DB.IsNullOrEmpty(this.Domicilio_Aval)) m_params.Add("Domicilio_Aval", this.Domicilio_Aval);
			if (!DB.IsNullOrEmpty(this.Ciudad_Aval)) m_params.Add("Ciudad_Aval", this.Ciudad_Aval);
			if (!DB.IsNullOrEmpty(this.Estado_Aval)) m_params.Add("Estado_Aval", this.Estado_Aval);
			if (!DB.IsNullOrEmpty(this.CodigoPostal_Aval)) m_params.Add("CodigoPostal_Aval", this.CodigoPostal_Aval);
			if (!DB.IsNullOrEmpty(this.Telefono_Aval)) m_params.Add("Telefono_Aval", this.Telefono_Aval);
			if (!DB.IsNullOrEmpty(this.Email_Aval)) m_params.Add("Email_Aval", this.Email_Aval);
			if (!DB.IsNullOrEmpty(this.Solicitud)) m_params.Add("Solicitud", this.Solicitud);
			if (!DB.IsNullOrEmpty(this.ActaNacimiento)) m_params.Add("ActaNacimiento", this.ActaNacimiento);
			if (!DB.IsNullOrEmpty(this.CredencialElector)) m_params.Add("CredencialElector", this.CredencialElector);
			if (!DB.IsNullOrEmpty(this.CartaNoAntecedentes)) m_params.Add("CartaNoAntecedentes", this.CartaNoAntecedentes);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio)) m_params.Add("ComprobanteDomicilio", this.ComprobanteDomicilio);
			if (!DB.IsNullOrEmpty(this.CredencialElector_Aval)) m_params.Add("CredencialElector_Aval", this.CredencialElector_Aval);
			if (!DB.IsNullOrEmpty(this.ComprobanteDomicilio_Aval)) m_params.Add("ComprobanteDomicilio_Aval", this.ComprobanteDomicilio_Aval);
			if (!DB.IsNullOrEmpty(this.SaldoATratar)) m_params.Add("SaldoATratar", this.SaldoATratar);
			if (!DB.IsNullOrEmpty(this.Cronocasco)) m_params.Add("Cronocasco", this.Cronocasco);
			if (!DB.IsNullOrEmpty(this.TerminalDatos)) m_params.Add("TerminalDatos", this.TerminalDatos);
			if (!DB.IsNullOrEmpty(this.BloquearConductor)) m_params.Add("BloquearConductor", this.BloquearConductor);
			if (!DB.IsNullOrEmpty(this.MensajeACaja)) m_params.Add("MensajeACaja", this.MensajeACaja);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.PrimerCursoLicencia)) m_params.Add("PrimerCursoLicencia", this.PrimerCursoLicencia);
			if (!DB.IsNullOrEmpty(this.SegundoCursoLicencia)) m_params.Add("SegundoCursoLicencia", this.SegundoCursoLicencia);
			if (!DB.IsNullOrEmpty(this.ExamenMedico)) m_params.Add("ExamenMedico", this.ExamenMedico);
			if (!DB.IsNullOrEmpty(this.Nomina)) m_params.Add("Nomina", this.Nomina);
			if (!DB.IsNullOrEmpty(this.Dependientes)) m_params.Add("Dependientes", this.Dependientes);
			if (!DB.IsNullOrEmpty(this.OcupacionEsposa)) m_params.Add("OcupacionEsposa", this.OcupacionEsposa);
			if (!DB.IsNullOrEmpty(this.TipoVivienda)) m_params.Add("TipoVivienda", this.TipoVivienda);
			if (!DB.IsNullOrEmpty(this.GastosMensualesFijos)) m_params.Add("GastosMensualesFijos", this.GastosMensualesFijos);
			if (!DB.IsNullOrEmpty(this.CleaverD)) m_params.Add("CleaverD", this.CleaverD);
			if (!DB.IsNullOrEmpty(this.CleaverI)) m_params.Add("CleaverI", this.CleaverI);
			if (!DB.IsNullOrEmpty(this.CleaverS)) m_params.Add("CleaverS", this.CleaverS);
			if (!DB.IsNullOrEmpty(this.CleaverC)) m_params.Add("CleaverC", this.CleaverC);

			return DB.UpdateRow("Conductores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Conductor_ID", this.Conductor_ID);

			return DB.DeleteRow("Conductores", w_params);
		} // End Delete


		#endregion
	} //End Class Conductores

	public class Contratos
	{

		public Contratos()
		{
		}

		public Contratos(int contrato_id, int empresa_id, int estacion_id, int tipocontrato_id, string descripcion, int? modelounidad_id, decimal montodiario, int diasdecobro_id, decimal fondoresidual, int conductor_id, int? unidad_id, int? numeroeconomico, int cuenta_id, int concepto_id, DateTime fechainicial, DateTime? fechafinal, int estatuscontrato_id, string comentarios, int? conductorcopia_id, bool cobropermanente, int? referencia_id)
		{
			this.Contrato_ID = contrato_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.TipoContrato_ID = tipocontrato_id;
			this.Descripcion = descripcion;
			this.ModeloUnidad_ID = modelounidad_id;
			this.MontoDiario = montodiario;
			this.DiasDeCobro_ID = diasdecobro_id;
			this.FondoResidual = fondoresidual;
			this.Conductor_ID = conductor_id;
			this.Unidad_ID = unidad_id;
			this.NumeroEconomico = numeroeconomico;
			this.Cuenta_ID = cuenta_id;
			this.Concepto_ID = concepto_id;
			this.FechaInicial = fechainicial;
			this.FechaFinal = fechafinal;
			this.EstatusContrato_ID = estatuscontrato_id;
			this.Comentarios = comentarios;
			this.ConductorCopia_ID = conductorcopia_id;
			this.CobroPermanente = cobropermanente;
			this.Referencia_ID = referencia_id;
		}

		private int _Contrato_ID;
		public int Contrato_ID
		{
			get { return _Contrato_ID; }
			set { _Contrato_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _TipoContrato_ID;
		public int TipoContrato_ID
		{
			get { return _TipoContrato_ID; }
			set { _TipoContrato_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private int? _ModeloUnidad_ID;
		public int? ModeloUnidad_ID
		{
			get { return _ModeloUnidad_ID; }
			set { _ModeloUnidad_ID = value; }
		}

		private decimal _MontoDiario;
		public decimal MontoDiario
		{
			get { return _MontoDiario; }
			set { _MontoDiario = value; }
		}

		private int _DiasDeCobro_ID;
		public int DiasDeCobro_ID
		{
			get { return _DiasDeCobro_ID; }
			set { _DiasDeCobro_ID = value; }
		}

		private decimal _FondoResidual;
		public decimal FondoResidual
		{
			get { return _FondoResidual; }
			set { _FondoResidual = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int? _Unidad_ID;
		public int? Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int? _NumeroEconomico;
		public int? NumeroEconomico
		{
			get { return _NumeroEconomico; }
			set { _NumeroEconomico = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int _Concepto_ID;
		public int Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private DateTime _FechaInicial;
		public DateTime FechaInicial
		{
			get { return _FechaInicial; }
			set { _FechaInicial = value; }
		}

		private DateTime? _FechaFinal;
		public DateTime? FechaFinal
		{
			get { return _FechaFinal; }
			set { _FechaFinal = value; }
		}

		private int _EstatusContrato_ID;
		public int EstatusContrato_ID
		{
			get { return _EstatusContrato_ID; }
			set { _EstatusContrato_ID = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private int? _ConductorCopia_ID;
		public int? ConductorCopia_ID
		{
			get { return _ConductorCopia_ID; }
			set { _ConductorCopia_ID = value; }
		}

		private bool _CobroPermanente;
		public bool CobroPermanente
		{
			get { return _CobroPermanente; }
			set { _CobroPermanente = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		public int? DiasRentasDevengar { get; set; }

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			m_params.Add("Descripcion", this.Descripcion);
			if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("MontoDiario", this.MontoDiario);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			m_params.Add("CobroPermanente", this.CobroPermanente);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!AppHelper.IsNullOrEmpty(this.DiasRentasDevengar)) m_params.Add("DiasRentasDevengar", this.DiasRentasDevengar);
            
			int result = DB.InsertRow("Contratos", m_params);

			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Contrato_ID", this.Contrato_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			m_params.Add("Descripcion", this.Descripcion);
			if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("MontoDiario", this.MontoDiario);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			m_params.Add("CobroPermanente", this.CobroPermanente);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.IdentityInsertRow("Contratos", m_params);
		} // End Create

		public static List<Contratos> Read()
		{
			List<Contratos> list = new List<Contratos>();
			DataTable dt = DB.Select("Contratos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public static Contratos Read(int contrato_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Contrato_ID", contrato_id);
			DataTable dt = DB.Select("Contratos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Contratos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		} // End Read

		public static Contratos Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Contratos", args);

			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Contratos(
				Convert.ToInt32(dr["Contrato_ID"])
				, Convert.ToInt32(dr["Empresa_ID"])
				, Convert.ToInt32(dr["Estacion_ID"])
				, Convert.ToInt32(dr["TipoContrato_ID"])
				, Convert.ToString(dr["Descripcion"])
				, DB.GetNullableInt32(dr["ModeloUnidad_ID"])
				, Convert.ToDecimal(dr["MontoDiario"])
				, Convert.ToInt32(dr["DiasDeCobro_ID"])
				, Convert.ToDecimal(dr["FondoResidual"])
				, Convert.ToInt32(dr["Conductor_ID"])
				, DB.GetNullableInt32(dr["Unidad_ID"])
				, DB.GetNullableInt32(dr["NumeroEconomico"])
				, Convert.ToInt32(dr["Cuenta_ID"])
				, Convert.ToInt32(dr["Concepto_ID"])
				, Convert.ToDateTime(dr["FechaInicial"])
				, DB.GetNullableDateTime(dr["FechaFinal"])
				, Convert.ToInt32(dr["EstatusContrato_ID"])
				, Convert.ToString(dr["Comentarios"])
				, DB.GetNullableInt32(dr["ConductorCopia_ID"])
				, Convert.ToBoolean(dr["CobroPermanente"])
				, DB.GetNullableInt32(dr["Referencia_ID"])
				);
		} // End Read

		public static Contratos ReadConductorOperativo(params KeyValuePair<string, object>[] args)
		{
			Hashtable data = new Hashtable();
			foreach (KeyValuePair<string, object> kp in args)
			{
				data.Add(kp.Key, kp.Value);
			}
			DataSet ds = DB.QueryDS("usp_Obtiene_InfoContrato_ConductorOperativo", data);
			DataTable dt = ds.Tables[0];

			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Contratos(
				Convert.ToInt32(dr["Contrato_ID"])
				, Convert.ToInt32(dr["Empresa_ID"])
				, Convert.ToInt32(dr["Estacion_ID"])
				, Convert.ToInt32(dr["TipoContrato_ID"])
				, Convert.ToString(dr["Descripcion"])
				, DB.GetNullableInt32(dr["ModeloUnidad_ID"])
				, Convert.ToDecimal(dr["MontoDiario"])
				, Convert.ToInt32(dr["DiasDeCobro_ID"])
				, Convert.ToDecimal(dr["FondoResidual"])
				, Convert.ToInt32(dr["Conductor_ID"])
				, DB.GetNullableInt32(dr["Unidad_ID"])
				, DB.GetNullableInt32(dr["NumeroEconomico"])
				, Convert.ToInt32(dr["Cuenta_ID"])
				, Convert.ToInt32(dr["Concepto_ID"])
				, Convert.ToDateTime(dr["FechaInicial"])
				, DB.GetNullableDateTime(dr["FechaFinal"])
				, Convert.ToInt32(dr["EstatusContrato_ID"])
				, Convert.ToString(dr["Comentarios"])
				, DB.GetNullableInt32(dr["ConductorCopia_ID"])
				, Convert.ToBoolean(dr["CobroPermanente"])
				, DB.GetNullableInt32(dr["Referencia_ID"])
				);
		} // End ReadConductorOperativo

		public static bool Read(out Contratos contratos, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Contratos", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				contratos = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			contratos = new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Contratos");
		} // End Read

		public static DataTable ReadDataTable(int contrato_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Contrato_ID", contrato_id);
			return DB.Select("Contratos", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Contrato_ID", this.Contrato_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			m_params.Add("Descripcion", this.Descripcion);
			if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("MontoDiario", this.MontoDiario);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			m_params.Add("FechaFinal", this.FechaFinal);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			m_params.Add("CobroPermanente", this.CobroPermanente);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.UpdateRow("Contratos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Contrato_ID", this.Contrato_ID);

			return DB.DeleteRow("Contratos", w_params);
		} // End Delete

	} //End Class Contratos

	public class ContratosLiquidados
	{

		public ContratosLiquidados()
		{
		}

		public ContratosLiquidados(int contratoliquidado_id, int contrato_id, int conductor_id, int unidad_id, int locacionunidad_id, int estatusconductor_id, int estatuscontrato_id, string comentarios, DateTime fecha, string usuario_id)
		{
			this.ContratoLiquidado_ID = contratoliquidado_id;
			this.Contrato_ID = contrato_id;
			this.Conductor_ID = conductor_id;
			this.Unidad_ID = unidad_id;
			this.LocacionUnidad_ID = locacionunidad_id;
			this.EstatusConductor_ID = estatusconductor_id;
			this.EstatusContrato_ID = estatuscontrato_id;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
		}

		private int _ContratoLiquidado_ID;
		public int ContratoLiquidado_ID
		{
			get { return _ContratoLiquidado_ID; }
			set { _ContratoLiquidado_ID = value; }
		}

		private int _Contrato_ID;
		public int Contrato_ID
		{
			get { return _Contrato_ID; }
			set { _Contrato_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int _LocacionUnidad_ID;
		public int LocacionUnidad_ID
		{
			get { return _LocacionUnidad_ID; }
			set { _LocacionUnidad_ID = value; }
		}

		private int _EstatusConductor_ID;
		public int EstatusConductor_ID
		{
			get { return _EstatusConductor_ID; }
			set { _EstatusConductor_ID = value; }
		}

		private int _EstatusContrato_ID;
		public int EstatusContrato_ID
		{
			get { return _EstatusContrato_ID; }
			set { _EstatusContrato_ID = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Contrato_ID", this.Contrato_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.InsertRow("ContratosLiquidados", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);
			m_params.Add("Contrato_ID", this.Contrato_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.IdentityInsertRow("ContratosLiquidados", m_params);
		} // End Create

		public static List<ContratosLiquidados> Read()
		{
			List<ContratosLiquidados> list = new List<ContratosLiquidados>();
			DataTable dt = DB.Select("ContratosLiquidados");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
			}

			return list;
		} // End Read

		public static ContratosLiquidados Read(int contratoliquidado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ContratoLiquidado_ID", contratoliquidado_id);
			DataTable dt = DB.Select("ContratosLiquidados", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ContratosLiquidados con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
		} // End Read

		public static ContratosLiquidados Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ContratosLiquidados", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
		} // End Read

		public static bool Read(out ContratosLiquidados contratosliquidados, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ContratosLiquidados", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				contratosliquidados = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			contratosliquidados = new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ContratosLiquidados");
		} // End Read

		public static DataTable ReadDataTable(int contratoliquidado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ContratoLiquidado_ID", contratoliquidado_id);
			return DB.Select("ContratosLiquidados", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);
			m_params.Add("Contrato_ID", this.Contrato_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.UpdateRow("ContratosLiquidados", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);

			return DB.DeleteRow("ContratosLiquidados", w_params);
		} // End Delete

	} //End Class ContratosLiquidados

	public class CuentaCajas
	{

		public CuentaCajas()
		{
		}

		public CuentaCajas(int cuentacaja_id, int sesion_id, int empresa_id, int estacion_id, int caja_id, int? ticket_id,
		  int cuenta_id, int? concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id)
		{
			this.CuentaCaja_ID = cuentacaja_id;
			this.Sesion_ID = sesion_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Caja_ID = caja_id;
			this.Ticket_ID = ticket_id;
			this.Cuenta_ID = cuenta_id;
			this.Concepto_ID = concepto_id;
			this.Cargo = cargo;
			this.Abono = abono;
			this.Saldo = saldo;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
		}

		private int _CuentaCaja_ID;
		public int CuentaCaja_ID
		{
			get { return _CuentaCaja_ID; }
			set { _CuentaCaja_ID = value; }
		}

		private int _Sesion_ID;
		public int Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Caja_ID;
		public int Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int? _Concepto_ID;
		public int? Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private decimal _Cargo;
		public decimal Cargo
		{
			get { return _Cargo; }
			set { _Cargo = value; }
		}

		private decimal _Abono;
		public decimal Abono
		{
			get { return _Abono; }
			set { _Abono = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private void CalcularSaldo()
		{
			string sqlQry = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaCajas WHERE Sesion_ID = @Sesion_ID " +
			    "AND Empresa_ID = @Empresa_ID AND Cuenta_ID = @Cuenta_ID";

			this.Saldo =
			    Convert.ToDecimal(DB.ReadScalar(sqlQry, DB.Param("@Sesion_ID", this.Sesion_ID),
				   DB.Param("@Empresa_ID", this.Empresa_ID), DB.Param("@Cuenta_ID", this.Cuenta_ID))) +
					  this.Abono - this.Cargo;
		}

		public int Create()
		{
			CalcularSaldo();

			Hashtable m_params = new Hashtable();
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.InsertRow("CuentaCajas", m_params);
		} // End Create

		public static List<CuentaCajas> Read()
		{
			List<CuentaCajas> list = new List<CuentaCajas>();
			DataTable dt = DB.Select("CuentaCajas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), Convert.ToInt32(dr["Sesion_ID"]),
				Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]),
				DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]),
				Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]),
				Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
			}

			return list;
		} // End Read

		public static List<CuentaCajas> Read(int cuentacaja_id)
		{
			List<CuentaCajas> list = new List<CuentaCajas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaCaja_ID", cuentacaja_id);
			DataTable dt = DB.Select("CuentaCajas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), Convert.ToInt32(dr["Sesion_ID"]),
				    Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]),
				    DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]),
				    Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]),
				    Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaCaja_ID", this.CuentaCaja_ID);
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.UpdateRow("CuentaCajas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaCaja_ID", this.CuentaCaja_ID);

			return DB.DeleteRow("CuentaCajas", w_params);
		}

	} //End Class CuentaCajas

	public class CuentaConductores
	{

		public CuentaConductores()
		{
		}

		public CuentaConductores(int cuentaconductor_id, int empresa_id, int? estacion_id, int conductor_id, int? unidad_id, int? caja_id, int? ticket_id, int cuenta_id, int? concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id, int? referencia_id)
		{
			this.CuentaConductor_ID = cuentaconductor_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Conductor_ID = conductor_id;
			this.Unidad_ID = unidad_id;
			this.Caja_ID = caja_id;
			this.Ticket_ID = ticket_id;
			this.Cuenta_ID = cuenta_id;
			this.Concepto_ID = concepto_id;
			this.Cargo = cargo;
			this.Abono = abono;
			this.Saldo = saldo;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
			this.Referencia_ID = referencia_id;
		}

		private int _CuentaConductor_ID;
		public int CuentaConductor_ID
		{
			get { return _CuentaConductor_ID; }
			set { _CuentaConductor_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int? _Estacion_ID;
		public int? Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int? _Unidad_ID;
		public int? Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int? _Concepto_ID;
		public int? Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private decimal _Cargo;
		public decimal Cargo
		{
			get { return _Cargo; }
			set { _Cargo = value; }
		}

		private decimal _Abono;
		public decimal Abono
		{
			get { return _Abono; }
			set { _Abono = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		private void CalcularSaldo()
		{
			string sqlQry = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaConductores WHERE Conductor_ID = @Conductor_ID " +
			    "AND Empresa_ID = @Empresa_ID AND Cuenta_ID = @Cuenta_ID";

			this.Saldo =
			    Convert.ToDecimal(DB.ReadScalar(sqlQry, DB.Param("@Conductor_ID", this.Conductor_ID),
				   DB.Param("@Empresa_ID", this.Empresa_ID), DB.Param("@Cuenta_ID", this.Cuenta_ID))) +
					  this.Abono - this.Cargo;
		}

		public int Create()
		{
			CalcularSaldo();

			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.InsertRow("CuentaConductores", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.IdentityInsertRow("CuentaConductores", m_params);
		} // End Create

		public static List<CuentaConductores> Read()
		{
			List<CuentaConductores> list = new List<CuentaConductores>();
			DataTable dt = DB.Select("CuentaConductores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public static CuentaConductores Read(int cuentaconductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaConductor_ID", cuentaconductor_id);
			DataTable dt = DB.Select("CuentaConductores", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe CuentaConductores con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		} // End Read

		public static CuentaConductores Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("CuentaConductores", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		} // End Read

		public static bool Read(out CuentaConductores cuentaconductores, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("CuentaConductores", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				cuentaconductores = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			cuentaconductores = new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("CuentaConductores");
		} // End Read

		public static DataTable ReadDataTable(int cuentaconductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaConductor_ID", cuentaconductor_id);
			return DB.Select("CuentaConductores", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.UpdateRow("CuentaConductores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);

			return DB.DeleteRow("CuentaConductores", w_params);
		} // End Delete

	} //End Class CuentaConductores

	public class CuentaEmpresas
	{

		public CuentaEmpresas()
		{
		}

		public CuentaEmpresas(int cuentaempresa_id, int empresa_id, int cuenta_id, int concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id)
		{
			this.CuentaEmpresa_ID = cuentaempresa_id;
			this.Empresa_ID = empresa_id;
			this.Cuenta_ID = cuenta_id;
			this.Concepto_ID = concepto_id;
			this.Cargo = cargo;
			this.Abono = abono;
			this.Saldo = saldo;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
		}

		private int _CuentaEmpresa_ID;
		public int CuentaEmpresa_ID
		{
			get { return _CuentaEmpresa_ID; }
			set { _CuentaEmpresa_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int _Concepto_ID;
		public int Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private decimal _Cargo;
		public decimal Cargo
		{
			get { return _Cargo; }
			set { _Cargo = value; }
		}

		private decimal _Abono;
		public decimal Abono
		{
			get { return _Abono; }
			set { _Abono = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.InsertRow("CuentaEmpresas", m_params);
		} // End Create

		public static List<CuentaEmpresas> Read()
		{
			List<CuentaEmpresas> list = new List<CuentaEmpresas>();
			DataTable dt = DB.Select("CuentaEmpresas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaEmpresas(Convert.ToInt32(dr["CuentaEmpresa_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
			}

			return list;
		} // End Read

		public static List<CuentaEmpresas> Read(int cuentaempresa_id)
		{
			List<CuentaEmpresas> list = new List<CuentaEmpresas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaEmpresa_ID", cuentaempresa_id);
			DataTable dt = DB.Select("CuentaEmpresas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaEmpresas(Convert.ToInt32(dr["CuentaEmpresa_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaEmpresa_ID", this.CuentaEmpresa_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.UpdateRow("CuentaEmpresas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaEmpresa_ID", this.CuentaEmpresa_ID);

			return DB.DeleteRow("CuentaEmpresas", w_params);
		}

	} //End Class CuentaEmpresas

	public class CuentaFlujoCajas
	{

		public CuentaFlujoCajas()
		{
		}

		public CuentaFlujoCajas(int cuentaflujocaja_id, int sesion_id, int caja_id, int moneda_id, int? ticket_id, string concepto, decimal cargo, decimal abono, decimal saldo, DateTime fecha, string usuario_id)
		{
			this.CuentaFlujoCaja_ID = cuentaflujocaja_id;
			this.Sesion_ID = sesion_id;
			this.Caja_ID = caja_id;
			this.Moneda_ID = moneda_id;
			this.Ticket_ID = ticket_id;
			this.Concepto = concepto;
			this.Cargo = cargo;
			this.Abono = abono;
			this.Saldo = saldo;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
		}

		private int _CuentaFlujoCaja_ID;
		public int CuentaFlujoCaja_ID
		{
			get { return _CuentaFlujoCaja_ID; }
			set { _CuentaFlujoCaja_ID = value; }
		}

		private int _Sesion_ID;
		public int Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private int _Caja_ID;
		public int Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int _Moneda_ID;
		public int Moneda_ID
		{
			get { return _Moneda_ID; }
			set { _Moneda_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private string _Concepto;
		public string Concepto
		{
			get { return _Concepto; }
			set { _Concepto = value; }
		}

		private decimal _Cargo;
		public decimal Cargo
		{
			get { return _Cargo; }
			set { _Cargo = value; }
		}

		private decimal _Abono;
		public decimal Abono
		{
			get { return _Abono; }
			set { _Abono = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private void CalcularSaldo()
		{
			string sqlQry = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaFlujoCajas WHERE Sesion_ID = @Sesion_ID " +
			    "AND Moneda_ID = @Moneda_ID ";

			this.Saldo =
			    Convert.ToDecimal(DB.ReadScalar(sqlQry, DB.Param("@Sesion_ID", this.Sesion_ID),
				   DB.Param("@Moneda_ID", this.Moneda_ID))) +
					  this.Abono - this.Cargo;
		}

		public int Create()
		{
			CalcularSaldo();

			Hashtable m_params = new Hashtable();
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Moneda_ID", this.Moneda_ID);
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Concepto", this.Concepto);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			int result = DB.InsertRow("CuentaFlujoCajas", m_params);
			this.CuentaFlujoCaja_ID = Convert.ToInt32(DB.Ident_Current("CuentaFlujoCajas"));
			return result;
		} // End Create

		public static List<CuentaFlujoCajas> Read()
		{
			List<CuentaFlujoCajas> list = new List<CuentaFlujoCajas>();
			DataTable dt = DB.Select("CuentaFlujoCajas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				new CuentaFlujoCajas(
				    Convert.ToInt32(dr["CuentaFlujoCaja_ID"]),
				    Convert.ToInt32(dr["Sesion_ID"]),
				    Convert.ToInt32(dr["Caja_ID"]),
				    Convert.ToInt32(dr["Moneda_ID"]),
				    DB.GetNullableInt32(dr["Ticket_ID"]),
				    Convert.ToString(dr["Concepto"]),
				    Convert.ToDecimal(dr["Cargo"]),
				    Convert.ToDecimal(dr["Abono"]),
				    Convert.ToDecimal(dr["Saldo"]),
				    Convert.ToDateTime(dr["Fecha"]),
				    Convert.ToString(dr["Usuario_ID"])
				)
			 );
			}

			return list;
		} // End Read

		public static List<CuentaFlujoCajas> Read(int cuentaflujocaja_id)
		{
			List<CuentaFlujoCajas> list = new List<CuentaFlujoCajas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaFlujoCaja_ID", cuentaflujocaja_id);
			DataTable dt = DB.Select("CuentaFlujoCajas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new CuentaFlujoCajas(
					   Convert.ToInt32(dr["CuentaFlujoCaja_ID"]),
					   Convert.ToInt32(dr["Sesion_ID"]),
					   Convert.ToInt32(dr["Caja_ID"]),
					   Convert.ToInt32(dr["Moneda_ID"]),
					   DB.GetNullableInt32(dr["Ticket_ID"]),
					   Convert.ToString(dr["Concepto"]),
					   Convert.ToDecimal(dr["Cargo"]),
					   Convert.ToDecimal(dr["Abono"]),
					   Convert.ToDecimal(dr["Saldo"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"])
				    ));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaFlujoCaja_ID", this.CuentaFlujoCaja_ID);
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Moneda_ID", this.Moneda_ID);
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Concepto", this.Concepto);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.UpdateRow("CuentaFlujoCajas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaFlujoCaja_ID", this.CuentaFlujoCaja_ID);

			return DB.DeleteRow("CuentaFlujoCajas", w_params);
		}

	} //End Class CuentaFlujoCajas

	public class Cuentas
	{

		public Cuentas()
		{
		}

		public Cuentas(int cuenta_id, string nombre)
		{
			this.Cuenta_ID = cuenta_id;
			this.Nombre = nombre;
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Cuentas", m_params);
		} // End Create

		public static List<Cuentas> Read()
		{
			List<Cuentas> list = new List<Cuentas>();
			DataTable dt = DB.Select("Cuentas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Cuentas(Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<Cuentas> Read(int cuenta_id)
		{
			List<Cuentas> list = new List<Cuentas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Cuenta_ID", cuenta_id);
			DataTable dt = DB.Select("Cuentas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Cuentas(Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Cuentas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Cuenta_ID", this.Cuenta_ID);

			return DB.DeleteRow("Cuentas", w_params);
		}

	} //End Class Cuentas

	public class CuentaUnidades
	{

		#region Constructors

		public CuentaUnidades()
		{
		}

		public CuentaUnidades(
		    int cuentaunidad_id,
		    int empresa_id,
		    int? estacion_id,
		    int unidad_id,
		    int? conductor_id,
		    int? caja_id,
		    int? ticket_id,
		    int cuenta_id,
		    int concepto_id,
		    decimal cargo,
		    decimal abono,
		    decimal saldo,
		    string comentarios,
		    DateTime fecha,
		    string usuario_id,
		    int? ordentrabajo_id)
		{
			this.CuentaUnidad_ID = cuentaunidad_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Unidad_ID = unidad_id;
			this.Conductor_ID = conductor_id;
			this.Caja_ID = caja_id;
			this.Ticket_ID = ticket_id;
			this.Cuenta_ID = cuenta_id;
			this.Concepto_ID = concepto_id;
			this.Cargo = cargo;
			this.Abono = abono;
			this.Saldo = saldo;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
			this.OrdenTrabajo_ID = ordentrabajo_id;
		}

		#endregion

		#region Properties

		private int _CuentaUnidad_ID;
		public int CuentaUnidad_ID
		{
			get { return _CuentaUnidad_ID; }
			set { _CuentaUnidad_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int? _Estacion_ID;
		public int? Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int? _Conductor_ID;
		public int? Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int _Concepto_ID;
		public int Concepto_ID
		{
			get { return _Concepto_ID; }
			set { _Concepto_ID = value; }
		}

		private decimal _Cargo;
		public decimal Cargo
		{
			get { return _Cargo; }
			set { _Cargo = value; }
		}

		private decimal _Abono;
		public decimal Abono
		{
			get { return _Abono; }
			set { _Abono = value; }
		}

		private decimal _Saldo;
		public decimal Saldo
		{
			get { return _Saldo; }
			set { _Saldo = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _OrdenTrabajo_ID;
		public int? OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Unidad_ID == 0) throw new Exception("Unidad_ID no puede ser nulo.");

			if (this.Cuenta_ID == 0) throw new Exception("Cuenta_ID no puede ser nulo.");

			if (this.Concepto_ID == 0) throw new Exception("Concepto_ID no puede ser nulo.");

			if (this.Cargo == 0 && this.Abono == 0) throw new Exception("El Cargo o Abono debe ser mayor a 0");

			if (this.Comentarios.Length > 250)
			{
				throw new Exception("Comentarios debe tener máximo 250 carateres.");
			}

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}


		} // End Validate

		private void CalcularSaldo()
		{
			string sqlQry = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaUnidades WHERE Unidad_ID = @Unidad_ID " +
			    "AND Empresa_ID = @Empresa_ID AND Cuenta_ID = @Cuenta_ID";

			this.Saldo =
			    Convert.ToDecimal(DB.ReadScalar(sqlQry, DB.Param("@Unidad_ID", this.Unidad_ID),
				   DB.Param("@Empresa_ID", this.Empresa_ID), DB.Param("@Cuenta_ID", this.Cuenta_ID))) +
					  this.Abono - this.Cargo;
		}

		public int Create()
		{
			this.CalcularSaldo();

			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!DB.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!DB.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

			return DB.InsertRow("CuentaUnidades", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("CuentaUnidad_ID", this.CuentaUnidad_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!DB.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!DB.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

			return DB.IdentityInsertRow("CuentaUnidades", m_params);
		} // End Create

		public static List<CuentaUnidades> Read()
		{
			List<CuentaUnidades> list = new List<CuentaUnidades>();
			DataTable dt = DB.Select("CuentaUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new CuentaUnidades(
					   Convert.ToInt32(dr["CuentaUnidad_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   DB.GetNullableInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["Unidad_ID"]),
					   DB.GetNullableInt32(dr["Conductor_ID"]),
					   DB.GetNullableInt32(dr["Caja_ID"]),
					   DB.GetNullableInt32(dr["Ticket_ID"]),
					   Convert.ToInt32(dr["Cuenta_ID"]),
					   Convert.ToInt32(dr["Concepto_ID"]),
					   Convert.ToDecimal(dr["Cargo"]),
					   Convert.ToDecimal(dr["Abono"]),
					   Convert.ToDecimal(dr["Saldo"]),
					   Convert.ToString(dr["Comentarios"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["OrdenTrabajo_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static CuentaUnidades Read(int cuentaunidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaUnidad_ID", cuentaunidad_id);
			DataTable dt = DB.Select("CuentaUnidades", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe CuentaUnidades con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new CuentaUnidades(
			    Convert.ToInt32(dr["CuentaUnidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  Convert.ToInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["Concepto_ID"]),
					  Convert.ToDecimal(dr["Cargo"]),
					  Convert.ToDecimal(dr["Abono"]),
					  Convert.ToDecimal(dr["Saldo"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"])
				   );
		} // End Read

		public static CuentaUnidades Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("CuentaUnidades", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new CuentaUnidades(
			    Convert.ToInt32(dr["CuentaUnidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  Convert.ToInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["Concepto_ID"]),
					  Convert.ToDecimal(dr["Cargo"]),
					  Convert.ToDecimal(dr["Abono"]),
					  Convert.ToDecimal(dr["Saldo"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"])
				   );
		} // End Read

		public static bool Read(
		    out CuentaUnidades cuentaunidades,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("CuentaUnidades", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				cuentaunidades = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			cuentaunidades = new CuentaUnidades(
			    Convert.ToInt32(dr["CuentaUnidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  Convert.ToInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["Concepto_ID"]),
					  Convert.ToDecimal(dr["Cargo"]),
					  Convert.ToDecimal(dr["Abono"]),
					  Convert.ToDecimal(dr["Saldo"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("CuentaUnidades");
		} // End Read

		public static DataTable ReadDataTable(int cuentaunidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaUnidad_ID", cuentaunidad_id);
			return DB.Select("CuentaUnidades", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaUnidad_ID", this.CuentaUnidad_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!DB.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!DB.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Concepto_ID", this.Concepto_ID);
			m_params.Add("Cargo", this.Cargo);
			m_params.Add("Abono", this.Abono);
			m_params.Add("Saldo", this.Saldo);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

			return DB.UpdateRow("CuentaUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("CuentaUnidad_ID", this.CuentaUnidad_ID);

			return DB.DeleteRow("CuentaUnidades", w_params);
		} // End Delete


		#endregion
	} //End Class CuentaUnidades

	public class DiasDeCobros
	{

		public DiasDeCobros()
		{
		}

		public DiasDeCobros(int diasdecobro_id, string nombre)
		{
			this.DiasDeCobro_ID = diasdecobro_id;
			this.Nombre = nombre;
		}

		private int _DiasDeCobro_ID;
		public int DiasDeCobro_ID
		{
			get { return _DiasDeCobro_ID; }
			set { _DiasDeCobro_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("DiasDeCobros", m_params);
		} // End Create

		public static List<DiasDeCobros> Read()
		{
			List<DiasDeCobros> list = new List<DiasDeCobros>();
			DataTable dt = DB.Select("DiasDeCobros");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new DiasDeCobros(Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static DiasDeCobros Read(int diasdecobro_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("DiasDeCobro_ID", diasdecobro_id);
			DataTable dt = DB.Select("DiasDeCobros", w_params);
			DataRow dr = dt.Rows[0];
			return new DiasDeCobros(Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("DiasDeCobros", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);

			return DB.DeleteRow("DiasDeCobros", w_params);
		}

	} //End Class DiasDeCobros

	public class Empresas
	{

		public Empresas()
		{
		}

		public Empresas(int empresa_id, int tipoempresa_id, int? mercado_id, string rfc, string razonsocial, string nombre, string domicilio, string codigopostal, string ciudad, string estado, string telefono1, string telefono2, string movil, string email, string representantelegal, bool activo)
		{
			this.Empresa_ID = empresa_id;
			this.TipoEmpresa_ID = tipoempresa_id;
			this.Mercado_ID = mercado_id;
			this.RFC = rfc;
			this.RazonSocial = razonsocial;
			this.Nombre = nombre;
			this.Domicilio = domicilio;
			this.CodigoPostal = codigopostal;
			this.Ciudad = ciudad;
			this.Estado = estado;
			this.Telefono1 = telefono1;
			this.Telefono2 = telefono2;
			this.Movil = movil;
			this.Email = email;
			this.RepresentanteLegal = representantelegal;
			this.Activo = activo;
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _TipoEmpresa_ID;
		public int TipoEmpresa_ID
		{
			get { return _TipoEmpresa_ID; }
			set { _TipoEmpresa_ID = value; }
		}

		private int? _Mercado_ID;
		public int? Mercado_ID
		{
			get { return _Mercado_ID; }
			set { _Mercado_ID = value; }
		}

		private string _RFC;
		public string RFC
		{
			get { return _RFC; }
			set { _RFC = value; }
		}

		private string _RazonSocial;
		public string RazonSocial
		{
			get { return _RazonSocial; }
			set { _RazonSocial = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Domicilio;
		public string Domicilio
		{
			get { return _Domicilio; }
			set { _Domicilio = value; }
		}

		private string _CodigoPostal;
		public string CodigoPostal
		{
			get { return _CodigoPostal; }
			set { _CodigoPostal = value; }
		}

		private string _Ciudad;
		public string Ciudad
		{
			get { return _Ciudad; }
			set { _Ciudad = value; }
		}

		private string _Estado;
		public string Estado
		{
			get { return _Estado; }
			set { _Estado = value; }
		}

		private string _Telefono1;
		public string Telefono1
		{
			get { return _Telefono1; }
			set { _Telefono1 = value; }
		}

		private string _Telefono2;
		public string Telefono2
		{
			get { return _Telefono2; }
			set { _Telefono2 = value; }
		}

		private string _Movil;
		public string Movil
		{
			get { return _Movil; }
			set { _Movil = value; }
		}

		private string _Email;
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private string _RepresentanteLegal;
		public string RepresentanteLegal
		{
			get { return _RepresentanteLegal; }
			set { _RepresentanteLegal = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		public void Validate()
		{
			if (this.TipoEmpresa_ID == 0) throw new Exception("TipoEmpresa_ID no puede ser nulo.");

			if (this.RFC == null) throw new Exception("RFC no puede ser nulo.");

			if (this.RFC.Length > 18)
			{
				throw new Exception("RFC debe tener máximo 18 carateres.");
			}

			if (this.RazonSocial == null) throw new Exception("RazonSocial no puede ser nulo.");

			if (this.RazonSocial.Length > 150)
			{
				throw new Exception("RazonSocial debe tener máximo 150 carateres.");
			}

			if (this.Nombre.Length > 50)
			{
				throw new Exception("Nombre debe tener máximo 50 carateres.");
			}

			if (this.Domicilio == null) throw new Exception("Domicilio no puede ser nulo.");

			if (this.Domicilio.Length > 150)
			{
				throw new Exception("Domicilio debe tener máximo 150 carateres.");
			}

			if (this.CodigoPostal == null) throw new Exception("CodigoPostal no puede ser nulo.");

			if (this.CodigoPostal.Length > 10)
			{
				throw new Exception("CodigoPostal debe tener máximo 10 carateres.");
			}

			if (this.Ciudad == null) throw new Exception("Ciudad no puede ser nulo.");

			if (this.Ciudad.Length > 50)
			{
				throw new Exception("Ciudad debe tener máximo 50 carateres.");
			}

			if (this.Estado == null) throw new Exception("Estado no puede ser nulo.");

			if (this.Estado.Length > 50)
			{
				throw new Exception("Estado debe tener máximo 50 carateres.");
			}

			if (this.Telefono1 == null) throw new Exception("Telefono1 no puede ser nulo.");

			if (this.Telefono1.Length > 50)
			{
				throw new Exception("Telefono1 debe tener máximo 50 carateres.");
			}

			if (this.Telefono2 != null)
			{
				if (this.Telefono2.Length > 30)
				{
					throw new Exception("Telefono2 debe tener máximo 30 carateres.");
				}
			}

			if (this.Movil != null)
			{
				if (this.Movil.Length > 30)
				{
					throw new Exception("Movil debe tener máximo 30 carateres.");
				}
			}

			if (this.Email != null)
			{
				if (this.Email.Length > 100)
				{
					throw new Exception("Email debe tener máximo 100 carateres.");
				}
			}

			if (this.RepresentanteLegal != null)
			{
				if (this.RepresentanteLegal.Length > 150)
				{
					throw new Exception("RepresentanteLegal debe tener máximo 150 carateres.");
				}
			}

		} // End Validate

		public int Create()
		{
			this.Validate();

			Hashtable m_params = new Hashtable();
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("RFC", this.RFC);
			m_params.Add("RazonSocial", this.RazonSocial);
			if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!AppHelper.IsNullOrEmpty(this.RepresentanteLegal)) m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
			m_params.Add("Activo", this.Activo);

			int result = DB.InsertRow("Empresas", m_params);
			this.Empresa_ID = Convert.ToInt32(DB.Ident_Current("Empresas"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			this.Validate();

			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("RFC", this.RFC);
			m_params.Add("RazonSocial", this.RazonSocial);
			if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!AppHelper.IsNullOrEmpty(this.RepresentanteLegal)) m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
			m_params.Add("Activo", this.Activo);

			return DB.IdentityInsertRow("Empresas", m_params);
		} // End Create

		public static List<Empresas> Read()
		{
			List<Empresas> list = new List<Empresas>();
			DataTable dt = DB.Select("Empresas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static List<Empresas> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Empresas> list = new List<Empresas>();
			DataTable dt = DB.Read("Empresas", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static Empresas ReadSingle(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Empresas> list = new List<Empresas>();
			DataTable dt = DB.Read("Empresas", filter, sort, args);

			if (dt.Rows.Count == 0)
			{
				return null;
			}

			DataRow dr = dt.Rows[0];

			return new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]),
			    DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]),
				   Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]),
						 Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]),
							Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"]));
		} // End Read

		public static Empresas Read(int empresa_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", empresa_id);
			DataTable dt = DB.Select("Empresas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Empresas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"]));
		} // End Read

		public static Empresas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Empresas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"]));
		} // End Read

		public static List<Empresas> ReadList(params KeyValuePair<string, object>[] args)
		{
			List<Empresas> list = new List<Empresas>();
			DataTable dt = DB.Read("Empresas", args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]),
				    Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]),
						  Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]),
							 Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static bool Read(out Empresas empresas, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Empresas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				empresas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			empresas = new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Empresas");
		} // End Read

		public static DataTable ReadDataTable(int empresa_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", empresa_id);
			return DB.Select("Empresas", w_params);
		} // End Read

		public int Update()
		{
			this.Validate();

			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("RFC", this.RFC);
			m_params.Add("RazonSocial", this.RazonSocial);
			if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
			if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
			if (!AppHelper.IsNullOrEmpty(this.RepresentanteLegal)) m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
			m_params.Add("Activo", this.Activo);

			return DB.UpdateRow("Empresas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", this.Empresa_ID);

			return DB.DeleteRow("Empresas", w_params);
		} // End Delete


		internal static string GetCuentaBancariaPorEmpresaCuenta(int p, int p_2)
		{
			throw new NotImplementedException();
		}
	} //End Class Empresas

	public class Empresas_Cuentas
	{

		public Empresas_Cuentas()
		{
		}

		public Empresas_Cuentas(int empresa_id, int cuenta_id, string banco, string cuentabancaria, string referencia, string comentarios)
		{
			this.Empresa_ID = empresa_id;
			this.Cuenta_ID = cuenta_id;
			this.Banco = banco;
			this.CuentaBancaria = cuentabancaria;
			this.Referencia = referencia;
			this.Comentarios = comentarios;
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Cuenta_ID;
		public int Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private string _Banco;
		public string Banco
		{
			get { return _Banco; }
			set { _Banco = value; }
		}

		private string _CuentaBancaria;
		public string CuentaBancaria
		{
			get { return _CuentaBancaria; }
			set { _CuentaBancaria = value; }
		}

		private string _Referencia;
		public string Referencia
		{
			get { return _Referencia; }
			set { _Referencia = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Banco", this.Banco);
			m_params.Add("CuentaBancaria", this.CuentaBancaria);
			m_params.Add("Referencia", this.Referencia);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("Empresas_Cuentas", m_params);
		} // End Create

		public static List<Empresas_Cuentas> Read()
		{
			List<Empresas_Cuentas> list = new List<Empresas_Cuentas>();
			DataTable dt = DB.Select("Empresas_Cuentas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas_Cuentas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Banco"]), Convert.ToString(dr["CuentaBancaria"]), Convert.ToString(dr["Referencia"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static List<Empresas_Cuentas> Read(int empresa_id, int cuenta_id)
		{
			List<Empresas_Cuentas> list = new List<Empresas_Cuentas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", empresa_id);
			w_params.Add("Cuenta_ID", cuenta_id);
			DataTable dt = DB.Select("Empresas_Cuentas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas_Cuentas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Banco"]), Convert.ToString(dr["CuentaBancaria"]), Convert.ToString(dr["Referencia"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static List<Empresas_Cuentas> Read(int empresa_id, bool EsRenta)
		{
			string sql = "usp_EmpresasCuentas_GetCuentaBancariaPorEmpresaCuenta";
			List<Empresas_Cuentas> list = new List<Empresas_Cuentas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("@Empresa_ID", empresa_id);
			w_params.Add("@EsRenta", EsRenta);
			DataTable dt = DB.QueryDS(sql, w_params).Tables[0];
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Empresas_Cuentas(
					Convert.ToInt32(dr["Empresa_ID"])
					, Convert.ToInt32(dr["Cuenta_ID"])
					, Convert.ToString(dr["Banco"])
					, Convert.ToString(dr["CuentaBancaria"])
					, Convert.ToString(dr["Referencia"])
					, Convert.ToString(dr["Comentarios"])
					)
				);
			}
			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			w_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("Banco", this.Banco);
			m_params.Add("CuentaBancaria", this.CuentaBancaria);
			m_params.Add("Referencia", this.Referencia);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("Empresas_Cuentas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", this.Empresa_ID);
			w_params.Add("Cuenta_ID", this.Cuenta_ID);

			return DB.DeleteRow("Empresas_Cuentas", w_params);
		}

	} //End Class Empresas_Cuentas

	public class Estaciones
	{
		public override string ToString()
		{
			return this.Nombre;
		}

		#region Constructors

		public Estaciones()
		{
		}

		public Estaciones(
		    int estacion_id,
		    string nombre,
		    string descripcion,
		    string domicilio,
		    string municipio,
		    string estado,
		    string telefono1,
		    string telefono2,
		    bool activo,
			bool esFranquicia)
		{
			this.Estacion_ID = estacion_id;
			this.Nombre = nombre;
			this.Descripcion = descripcion;
			this.Domicilio = domicilio;
			this.Municipio = municipio;
			this.Estado = estado;
			this.Telefono1 = telefono1;
			this.Telefono2 = telefono2;
			this.Activo = activo;
			this.EsFranquicia = esFranquicia;
		}

		#endregion

		#region Properties

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private string _Domicilio;
		public string Domicilio
		{
			get { return _Domicilio; }
			set { _Domicilio = value; }
		}

		private string _Municipio;
		public string Municipio
		{
			get { return _Municipio; }
			set { _Municipio = value; }
		}

		private string _Estado;
		public string Estado
		{
			get { return _Estado; }
			set { _Estado = value; }
		}

		private string _Telefono1;
		public string Telefono1
		{
			get { return _Telefono1; }
			set { _Telefono1 = value; }
		}

		private string _Telefono2;
		public string Telefono2
		{
			get { return _Telefono2; }
			set { _Telefono2 = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private bool _EsFranquicia;
		public bool EsFranquicia { get { return _EsFranquicia; } set { _EsFranquicia = value; } }
		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 20)
			{
				throw new Exception("Nombre debe tener máximo 20 carateres.");
			}

			if (this.Descripcion.Length > 50)
			{
				throw new Exception("Descripcion debe tener máximo 50 carateres.");
			}

			if (this.Domicilio == null) throw new Exception("Domicilio no puede ser nulo.");

			if (this.Domicilio.Length > 150)
			{
				throw new Exception("Domicilio debe tener máximo 150 carateres.");
			}

			if (this.Municipio == null) throw new Exception("Municipio no puede ser nulo.");

			if (this.Municipio.Length > 50)
			{
				throw new Exception("Municipio debe tener máximo 50 carateres.");
			}

			if (this.Estado == null) throw new Exception("Estado no puede ser nulo.");

			if (this.Estado.Length > 50)
			{
				throw new Exception("Estado debe tener máximo 50 carateres.");
			}

			if (this.Telefono1 == null) throw new Exception("Telefono1 no puede ser nulo.");

			if (this.Telefono1.Length > 30)
			{
				throw new Exception("Telefono1 debe tener máximo 30 carateres.");
			}

			if (this.Telefono2.Length > 30)
			{
				throw new Exception("Telefono2 debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Municipio", this.Municipio);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			m_params.Add("Activo", this.Activo);
			m_params.Add("EsFranquicia", this.EsFranquicia);

			int result = DB.InsertRow("Estaciones", m_params);
			this.Estacion_ID = Convert.ToInt32(DB.Ident_Current("Estaciones"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Municipio", this.Municipio);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			m_params.Add("Activo", this.Activo);
			m_params.Add("EsFranquicia", this.EsFranquicia);

			return DB.IdentityInsertRow("Estaciones", m_params);
		} // End Create

		public static List<Estaciones> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Estaciones> list = new List<Estaciones>();
			DataTable dt = DB.Read("Estaciones", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Estaciones(
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Descripcion"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Municipio"]),
					   Convert.ToString(dr["Estado"]),
					   Convert.ToString(dr["Telefono1"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				    )
				);
			}

			return list;
		} // End Read

		public static bool GetEsFranquicia(int? estacion_id)
		{
			Hashtable m_params = new Hashtable();
			if (estacion_id != null)
			{
				m_params.Add("Estacion_ID", estacion_id);
			}
			DataTable dt = DB.Select("Estaciones", m_params);
			bool b = false;
			foreach (DataRow dr in dt.Rows)
			{
				b = Convert.ToBoolean(dr["EsFranquicia"]);
			}
			return b;
		} // End EsFranquicia

		public static List<Estaciones> ReadEstacion(int? estacion_id)
		{
			List<Estaciones> list = new List<Estaciones>();

			Hashtable m_params = new Hashtable();

			if (estacion_id != null)
			{
				m_params.Add("Estacion_ID", estacion_id);
			}

			DataTable dt = DB.Select("Estaciones", m_params);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Estaciones(
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Descripcion"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Municipio"]),
					   Convert.ToString(dr["Estado"]),
					   Convert.ToString(dr["Telefono1"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Estaciones> Read()
		{
			List<Estaciones> list = new List<Estaciones>();
			DataTable dt = DB.Select("Estaciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Estaciones(
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToString(dr["Descripcion"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Municipio"]),
					   Convert.ToString(dr["Estado"]),
					   Convert.ToString(dr["Telefono1"]),
					   Convert.ToString(dr["Telefono2"]),
					   Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				    )
				);
			}

			return list;
		} // End Read

		public static Estaciones Read(int estacion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Estacion_ID", estacion_id);
			DataTable dt = DB.Select("Estaciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Estaciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Estaciones(
			    Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Descripcion"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Municipio"]),
					  Convert.ToString(dr["Estado"]),
					  Convert.ToString(dr["Telefono1"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				   );
		} // End Read

		public static Estaciones Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Estaciones", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Estaciones(
			    Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Descripcion"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Municipio"]),
					  Convert.ToString(dr["Estado"]),
					  Convert.ToString(dr["Telefono1"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				   );
		} // End Read

		public static bool Read(
		    out Estaciones estaciones,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Estaciones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				estaciones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			estaciones = new Estaciones(
			    Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToString(dr["Descripcion"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Municipio"]),
					  Convert.ToString(dr["Estado"]),
					  Convert.ToString(dr["Telefono1"]),
					  Convert.ToString(dr["Telefono2"]),
					  Convert.ToBoolean(dr["Activo"]),
					   Convert.ToBoolean(dr["EsFranquicia"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Estaciones");
		} // End Read

		public static DataTable ReadDataTable(int estacion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Estacion_ID", estacion_id);
			return DB.Select("Estaciones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Municipio", this.Municipio);
			m_params.Add("Estado", this.Estado);
			m_params.Add("Telefono1", this.Telefono1);
			if (!DB.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
			m_params.Add("Activo", this.Activo);
			m_params.Add("EsFranquicia", this.EsFranquicia);

			return DB.UpdateRow("Estaciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.DeleteRow("Estaciones", w_params);
		} // End Delete


		#endregion
	} //End Class Estaciones

	public class EstatusConductores
	{

		public EstatusConductores()
		{
		}

		public EstatusConductores(int estatusconductor_id, string nombre)
		{
			this.EstatusConductor_ID = estatusconductor_id;
			this.Nombre = nombre;
		}

		private int _EstatusConductor_ID;
		public int EstatusConductor_ID
		{
			get { return _EstatusConductor_ID; }
			set { _EstatusConductor_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusConductores", m_params);
		} // End Create

		public static List<EstatusConductores> Read()
		{
			List<EstatusConductores> list = new List<EstatusConductores>();
			DataTable dt = DB.Select("EstatusConductores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusConductores(Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusConductores> Read(int estatusconductor_id)
		{
			List<EstatusConductores> list = new List<EstatusConductores>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusConductor_ID", estatusconductor_id);
			DataTable dt = DB.Select("EstatusConductores", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusConductores(Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusConductores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);

			return DB.DeleteRow("EstatusConductores", w_params);
		}

	} //End Class EstatusConductores

	public class EstatusContratos
	{

		public EstatusContratos()
		{
		}

		public EstatusContratos(int estatuscontrato_id, string nombre)
		{
			this.EstatusContrato_ID = estatuscontrato_id;
			this.Nombre = nombre;
		}

		private int _EstatusContrato_ID;
		public int EstatusContrato_ID
		{
			get { return _EstatusContrato_ID; }
			set { _EstatusContrato_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusContratos", m_params);
		} // End Create

		public static List<EstatusContratos> Read()
		{
			List<EstatusContratos> list = new List<EstatusContratos>();
			DataTable dt = DB.Select("EstatusContratos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusContratos(Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusContratos> Read(int estatuscontrato_id)
		{
			List<EstatusContratos> list = new List<EstatusContratos>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusContrato_ID", estatuscontrato_id);
			DataTable dt = DB.Select("EstatusContratos", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusContratos(Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusContratos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);

			return DB.DeleteRow("EstatusContratos", w_params);
		}

	} //End Class EstatusContratos

	public class EstatusFacturas
	{

		public EstatusFacturas()
		{
		}

		public EstatusFacturas(int estatusfactura_id, string nombre)
		{
			this.EstatusFactura_ID = estatusfactura_id;
			this.Nombre = nombre;
		}

		private int _EstatusFactura_ID;
		public int EstatusFactura_ID
		{
			get { return _EstatusFactura_ID; }
			set { _EstatusFactura_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusFacturas", m_params);
		} // End Create

		public static List<EstatusFacturas> Read()
		{
			List<EstatusFacturas> list = new List<EstatusFacturas>();
			DataTable dt = DB.Select("EstatusFacturas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusFacturas(Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static EstatusFacturas Read(int estatusfactura_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFactura_ID", estatusfactura_id);
			DataTable dt = DB.Select("EstatusFacturas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusFacturas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusFacturas(Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusFacturas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);

			return DB.DeleteRow("EstatusFacturas", w_params);
		} // End Delete

	} //End Class EstatusFacturas

	public class EstatusFinancieros
	{

		public EstatusFinancieros()
		{
		}

		public EstatusFinancieros(int estatusfinanciero_id, string nombre)
		{
			this.EstatusFinanciero_ID = estatusfinanciero_id;
			this.Nombre = nombre;
		}

		private int _EstatusFinanciero_ID;
		public int EstatusFinanciero_ID
		{
			get { return _EstatusFinanciero_ID; }
			set { _EstatusFinanciero_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusFinancieros", m_params);
		} // End Create

		public static List<EstatusFinancieros> Read()
		{
			List<EstatusFinancieros> list = new List<EstatusFinancieros>();
			DataTable dt = DB.Select("EstatusFinancieros");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusFinancieros(Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusFinancieros> Read(int estatusfinanciero_id)
		{
			List<EstatusFinancieros> list = new List<EstatusFinancieros>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFinanciero_ID", estatusfinanciero_id);
			DataTable dt = DB.Select("EstatusFinancieros", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusFinancieros(Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusFinancieros", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);

			return DB.DeleteRow("EstatusFinancieros", w_params);
		}

	} //End Class EstatusFinancieros

	public class EstatusMecanicos
	{

		public EstatusMecanicos()
		{
		}

		public EstatusMecanicos(int estatusmecanico_id, string nombre)
		{
			this.EstatusMecanico_ID = estatusmecanico_id;
			this.Nombre = nombre;
		}

		private int _EstatusMecanico_ID;
		public int EstatusMecanico_ID
		{
			get { return _EstatusMecanico_ID; }
			set { _EstatusMecanico_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusMecanicos", m_params);
		} // End Create

		public static List<EstatusMecanicos> Read()
		{
			List<EstatusMecanicos> list = new List<EstatusMecanicos>();
			DataTable dt = DB.Select("EstatusMecanicos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusMecanicos(Convert.ToInt32(dr["EstatusMecanico_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static EstatusMecanicos Read(int estatusmecanico_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusMecanico_ID", estatusmecanico_id);
			DataTable dt = DB.Select("EstatusMecanicos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusMecanicos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusMecanicos(Convert.ToInt32(dr["EstatusMecanico_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusMecanicos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);

			return DB.DeleteRow("EstatusMecanicos", w_params);
		} // End Delete

	} //End Class EstatusMecanicos

	public class EstatusOperativosUnidades
	{

		#region Constructors

		public EstatusOperativosUnidades()
		{
		}

		public EstatusOperativosUnidades(
		    int estatusoperativounidad_id,
		    string nombre)
		{
			this.EstatusOperativoUnidad_ID = estatusoperativounidad_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _EstatusOperativoUnidad_ID;
		public int EstatusOperativoUnidad_ID
		{
			get { return _EstatusOperativoUnidad_ID; }
			set { _EstatusOperativoUnidad_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusOperativosUnidades", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("EstatusOperativosUnidades", m_params);
		} // End Create

		public static List<EstatusOperativosUnidades> Read()
		{
			List<EstatusOperativosUnidades> list = new List<EstatusOperativosUnidades>();
			DataTable dt = DB.Select("EstatusOperativosUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new EstatusOperativosUnidades(
					   Convert.ToInt32(dr["EstatusOperativoUnidad_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static EstatusOperativosUnidades Read(int estatusoperativounidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOperativoUnidad_ID", estatusoperativounidad_id);
			DataTable dt = DB.Select("EstatusOperativosUnidades", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusOperativosUnidades con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusOperativosUnidades(
			    Convert.ToInt32(dr["EstatusOperativoUnidad_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static EstatusOperativosUnidades Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("EstatusOperativosUnidades", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new EstatusOperativosUnidades(
			    Convert.ToInt32(dr["EstatusOperativoUnidad_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out EstatusOperativosUnidades estatusoperativosunidades,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("EstatusOperativosUnidades", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				estatusoperativosunidades = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			estatusoperativosunidades = new EstatusOperativosUnidades(
			    Convert.ToInt32(dr["EstatusOperativoUnidad_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("EstatusOperativosUnidades");
		} // End Read

		public static DataTable ReadDataTable(int estatusoperativounidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOperativoUnidad_ID", estatusoperativounidad_id);
			return DB.Select("EstatusOperativosUnidades", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusOperativosUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);

			return DB.DeleteRow("EstatusOperativosUnidades", w_params);
		} // End Delete


		#endregion
	} //End Class EstatusOperativosUnidades

	public class EstatusOrdenesCompras
	{

		public EstatusOrdenesCompras()
		{
		}

		public EstatusOrdenesCompras(int estatusordencompra_id, string nombre)
		{
			this.EstatusOrdenCompra_ID = estatusordencompra_id;
			this.Nombre = nombre;
		}

		private int _EstatusOrdenCompra_ID;
		public int EstatusOrdenCompra_ID
		{
			get { return _EstatusOrdenCompra_ID; }
			set { _EstatusOrdenCompra_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusOrdenesCompras", m_params);
		} // End Create

		public static List<EstatusOrdenesCompras> Read()
		{
			List<EstatusOrdenesCompras> list = new List<EstatusOrdenesCompras>();
			DataTable dt = DB.Select("EstatusOrdenesCompras");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusOrdenesCompras(Convert.ToInt32(dr["EstatusOrdenCompra_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static EstatusOrdenesCompras Read(int estatusordencompra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenCompra_ID", estatusordencompra_id);
			DataTable dt = DB.Select("EstatusOrdenesCompras", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusOrdenesCompras con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusOrdenesCompras(Convert.ToInt32(dr["EstatusOrdenCompra_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusOrdenesCompras", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);

			return DB.DeleteRow("EstatusOrdenesCompras", w_params);
		} // End Delete

	} //End Class EstatusOrdenesCompras

	public class EstatusOrdenesServicios
	{

		public EstatusOrdenesServicios()
		{
		}

		public EstatusOrdenesServicios(int estatusordenservicio_id, string nombre)
		{
			this.EstatusOrdenServicio_ID = estatusordenservicio_id;
			this.Nombre = nombre;
		}

		private int _EstatusOrdenServicio_ID;
		public int EstatusOrdenServicio_ID
		{
			get { return _EstatusOrdenServicio_ID; }
			set { _EstatusOrdenServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusOrdenesServicios", m_params);
		} // End Create

		public static List<EstatusOrdenesServicios> Read()
		{
			List<EstatusOrdenesServicios> list = new List<EstatusOrdenesServicios>();
			DataTable dt = DB.Select("EstatusOrdenesServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusOrdenesServicios(Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static EstatusOrdenesServicios Read(int estatusordenservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenServicio_ID", estatusordenservicio_id);
			DataTable dt = DB.Select("EstatusOrdenesServicios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusOrdenesServicios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusOrdenesServicios(Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusOrdenesServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);

			return DB.DeleteRow("EstatusOrdenesServicios", w_params);
		} // End Delete

	} //End Class EstatusOrdenesServicios

	public class EstatusOrdenesTrabajos
	{

		public EstatusOrdenesTrabajos()
		{
		}

		public EstatusOrdenesTrabajos(int estatusordentrabajo_id, string nombre)
		{
			this.EstatusOrdenTrabajo_ID = estatusordentrabajo_id;
			this.Nombre = nombre;
		}

		private int _EstatusOrdenTrabajo_ID;
		public int EstatusOrdenTrabajo_ID
		{
			get { return _EstatusOrdenTrabajo_ID; }
			set { _EstatusOrdenTrabajo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusOrdenesTrabajos", m_params);
		} // End Create

		public static List<EstatusOrdenesTrabajos> Read()
		{
			List<EstatusOrdenesTrabajos> list = new List<EstatusOrdenesTrabajos>();
			DataTable dt = DB.Select("EstatusOrdenesTrabajos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusOrdenesTrabajos(Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static EstatusOrdenesTrabajos Read(int estatusordentrabajo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenTrabajo_ID", estatusordentrabajo_id);
			DataTable dt = DB.Select("EstatusOrdenesTrabajos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusOrdenesTrabajos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusOrdenesTrabajos(Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusOrdenesTrabajos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);

			return DB.DeleteRow("EstatusOrdenesTrabajos", w_params);
		} // End Delete

	} //End Class EstatusOrdenesTrabajos

	public class EstatusServicios
	{

		public EstatusServicios()
		{
		}

		public EstatusServicios(int estatusservicio_id, string nombre)
		{
			this.EstatusServicio_ID = estatusservicio_id;
			this.Nombre = nombre;
		}

		private int _EstatusServicio_ID;
		public int EstatusServicio_ID
		{
			get { return _EstatusServicio_ID; }
			set { _EstatusServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusServicios", m_params);
		} // End Create

		public static List<EstatusServicios> Read()
		{
			List<EstatusServicios> list = new List<EstatusServicios>();
			DataTable dt = DB.Select("EstatusServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusServicios(Convert.ToInt32(dr["EstatusServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusServicios> Read(int estatusservicio_id)
		{
			List<EstatusServicios> list = new List<EstatusServicios>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusServicio_ID", estatusservicio_id);
			DataTable dt = DB.Select("EstatusServicios", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusServicios(Convert.ToInt32(dr["EstatusServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);

			return DB.DeleteRow("EstatusServicios", w_params);
		}

	} //End Class EstatusServicios

	public class EstatusTickets
	{

		public EstatusTickets()
		{
		}

		public EstatusTickets(int estatusticket_id, string nombre)
		{
			this.EstatusTicket_ID = estatusticket_id;
			this.Nombre = nombre;
		}

		private int _EstatusTicket_ID;
		public int EstatusTicket_ID
		{
			get { return _EstatusTicket_ID; }
			set { _EstatusTicket_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusTickets", m_params);
		} // End Create

		public static List<EstatusTickets> Read()
		{
			List<EstatusTickets> list = new List<EstatusTickets>();
			DataTable dt = DB.Select("EstatusTickets");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusTickets(Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusTickets> Read(int estatusticket_id)
		{
			List<EstatusTickets> list = new List<EstatusTickets>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusTicket_ID", estatusticket_id);
			DataTable dt = DB.Select("EstatusTickets", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusTickets(Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusTickets", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);

			return DB.DeleteRow("EstatusTickets", w_params);
		}

	} //End Class EstatusTickets

	public class EstatusUnidades
	{

		public EstatusUnidades()
		{
		}

		public EstatusUnidades(int estatusunidad_id, string nombre)
		{
			this.EstatusUnidad_ID = estatusunidad_id;
			this.Nombre = nombre;
		}

		private int _EstatusUnidad_ID;
		public int EstatusUnidad_ID
		{
			get { return _EstatusUnidad_ID; }
			set { _EstatusUnidad_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusUnidades", m_params);
		} // End Create

		public static List<EstatusUnidades> Read()
		{
			List<EstatusUnidades> list = new List<EstatusUnidades>();
			DataTable dt = DB.Select("EstatusUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusUnidades(Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<EstatusUnidades> Read(int estatusunidad_id)
		{
			List<EstatusUnidades> list = new List<EstatusUnidades>();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusUnidad_ID", estatusunidad_id);
			DataTable dt = DB.Select("EstatusUnidades", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new EstatusUnidades(Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);

			return DB.DeleteRow("EstatusUnidades", w_params);
		}

	} //End Class EstatusUnidades

	public class EstatusValesPrepagados
	{

		#region Constructors

		public EstatusValesPrepagados()
		{
		}

		public EstatusValesPrepagados(
		    int estatusvaleprepagado_id,
		    string nombre)
		{
			this.EstatusValePrepagado_ID = estatusvaleprepagado_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _EstatusValePrepagado_ID;
		public int EstatusValePrepagado_ID
		{
			get { return _EstatusValePrepagado_ID; }
			set { _EstatusValePrepagado_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("EstatusValesPrepagados", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("EstatusValesPrepagados", m_params);
		} // End Create

		public static List<EstatusValesPrepagados> Read()
		{
			List<EstatusValesPrepagados> list = new List<EstatusValesPrepagados>();
			DataTable dt = DB.Select("EstatusValesPrepagados");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new EstatusValesPrepagados(
					   Convert.ToInt32(dr["EstatusValePrepagado_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static EstatusValesPrepagados Read(int estatusvaleprepagado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusValePrepagado_ID", estatusvaleprepagado_id);
			DataTable dt = DB.Select("EstatusValesPrepagados", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe EstatusValesPrepagados con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new EstatusValesPrepagados(
			    Convert.ToInt32(dr["EstatusValePrepagado_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static EstatusValesPrepagados Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("EstatusValesPrepagados", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new EstatusValesPrepagados(
			    Convert.ToInt32(dr["EstatusValePrepagado_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out EstatusValesPrepagados estatusvalesprepagados,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("EstatusValesPrepagados", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				estatusvalesprepagados = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			estatusvalesprepagados = new EstatusValesPrepagados(
			    Convert.ToInt32(dr["EstatusValePrepagado_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("EstatusValesPrepagados");
		} // End Read

		public static DataTable ReadDataTable(int estatusvaleprepagado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusValePrepagado_ID", estatusvaleprepagado_id);
			return DB.Select("EstatusValesPrepagados", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("EstatusValesPrepagados", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);

			return DB.DeleteRow("EstatusValesPrepagados", w_params);
		} // End Delete


		#endregion
	} //End Class EstatusValesPrepagados

	public class Facturas
	{

		public Facturas()
		{
		}

		public Facturas(int factura_id, string foliofiscal, int empresaemisora_id, int empresareceptora_id, int estatusfactura_id, decimal subtotal, decimal impuestos, decimal total, DateTime fechaemision)
		{
			this.Factura_ID = factura_id;
			this.FolioFiscal = foliofiscal;
			this.EmpresaEmisora_ID = empresaemisora_id;
			this.EmpresaReceptora_ID = empresareceptora_id;
			this.EstatusFactura_ID = estatusfactura_id;
			this.Subtotal = subtotal;
			this.Impuestos = impuestos;
			this.Total = total;
			this.FechaEmision = fechaemision;
		}

		private int _Factura_ID;
		public int Factura_ID
		{
			get { return _Factura_ID; }
			set { _Factura_ID = value; }
		}

		private string _FolioFiscal;
		public string FolioFiscal
		{
			get { return _FolioFiscal; }
			set { _FolioFiscal = value; }
		}

		private int _EmpresaEmisora_ID;
		public int EmpresaEmisora_ID
		{
			get { return _EmpresaEmisora_ID; }
			set { _EmpresaEmisora_ID = value; }
		}

		private int _EmpresaReceptora_ID;
		public int EmpresaReceptora_ID
		{
			get { return _EmpresaReceptora_ID; }
			set { _EmpresaReceptora_ID = value; }
		}

		private int _EstatusFactura_ID;
		public int EstatusFactura_ID
		{
			get { return _EstatusFactura_ID; }
			set { _EstatusFactura_ID = value; }
		}

		private decimal _Subtotal;
		public decimal Subtotal
		{
			get { return _Subtotal; }
			set { _Subtotal = value; }
		}

		private decimal _Impuestos;
		public decimal Impuestos
		{
			get { return _Impuestos; }
			set { _Impuestos = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private DateTime _FechaEmision;
		public DateTime FechaEmision
		{
			get { return _FechaEmision; }
			set { _FechaEmision = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("FolioFiscal", this.FolioFiscal);
			m_params.Add("EmpresaEmisora_ID", this.EmpresaEmisora_ID);
			m_params.Add("EmpresaReceptora_ID", this.EmpresaReceptora_ID);
			m_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("Impuestos", this.Impuestos);
			m_params.Add("Total", this.Total);
			m_params.Add("FechaEmision", this.FechaEmision);

			return DB.InsertRow("Facturas", m_params);
		} // End Create

		public static List<Facturas> Read()
		{
			List<Facturas> list = new List<Facturas>();
			DataTable dt = DB.Select("Facturas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Facturas(Convert.ToInt32(dr["Factura_ID"]), Convert.ToString(dr["FolioFiscal"]), Convert.ToInt32(dr["EmpresaEmisora_ID"]), Convert.ToInt32(dr["EmpresaReceptora_ID"]), Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["Impuestos"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaEmision"])));
			}

			return list;
		} // End Read

		public static Facturas Read(int factura_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Factura_ID", factura_id);
			DataTable dt = DB.Select("Facturas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Facturas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Facturas(Convert.ToInt32(dr["Factura_ID"]), Convert.ToString(dr["FolioFiscal"]), Convert.ToInt32(dr["EmpresaEmisora_ID"]), Convert.ToInt32(dr["EmpresaReceptora_ID"]), Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["Impuestos"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaEmision"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Factura_ID", this.Factura_ID);
			m_params.Add("FolioFiscal", this.FolioFiscal);
			m_params.Add("EmpresaEmisora_ID", this.EmpresaEmisora_ID);
			m_params.Add("EmpresaReceptora_ID", this.EmpresaReceptora_ID);
			m_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("Impuestos", this.Impuestos);
			m_params.Add("Total", this.Total);
			m_params.Add("FechaEmision", this.FechaEmision);

			return DB.UpdateRow("Facturas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Factura_ID", this.Factura_ID);

			return DB.DeleteRow("Facturas", w_params);
		} // End Delete

	} //End Class Facturas

	public class Familias
	{

		public Familias()
		{
		}

		public Familias(int familia_id, string nombre)
		{
			this.Familia_ID = familia_id;
			this.Nombre = nombre;
		}

		private int _Familia_ID;
		public int Familia_ID
		{
			get { return _Familia_ID; }
			set { _Familia_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private void Validate()
		{
			if (AppHelper.IsNullOrEmpty(this.Nombre))
			{
				throw new Exception("Debe capturar un nombre");
			}

			if (this.Nombre.Length > 30)
			{
				throw new Exception("El nombre no puede tener más de 30 caracteres");
			}
		}

		public int Create()
		{
			Validate();

			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Familias", m_params);
		} // End Create

		public static List<Familias> Read()
		{
			List<Familias> list = new List<Familias>();
			DataTable dt = DB.Select("Familias");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Familias(Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static Familias Read(int familia_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Familia_ID", familia_id);
			DataTable dt = DB.Select("Familias", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Familias con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Familias(Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Validate();

			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Familias", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Familia_ID", this.Familia_ID);

			return DB.DeleteRow("Familias", w_params);
		} // End Delete

	} //End Class Familias

	public class FuncionesAgregado
	{

		public FuncionesAgregado()
		{
		}

		public FuncionesAgregado(int funcionagregado_id, string nombre, string descripcion)
		{
			this.FuncionAgregado_ID = funcionagregado_id;
			this.Nombre = nombre;
			this.Descripcion = descripcion;
		}

		private int _FuncionAgregado_ID;
		public int FuncionAgregado_ID
		{
			get { return _FuncionAgregado_ID; }
			set { _FuncionAgregado_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.InsertRow("FuncionesAgregado", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.IdentityInsertRow("FuncionesAgregado", m_params);
		} // End Create

		public static List<FuncionesAgregado> Read()
		{
			List<FuncionesAgregado> list = new List<FuncionesAgregado>();
			DataTable dt = DB.Select("FuncionesAgregado");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new FuncionesAgregado(Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"])));
			}

			return list;
		} // End Read

		public static FuncionesAgregado Read(int funcionagregado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("FuncionAgregado_ID", funcionagregado_id);
			DataTable dt = DB.Select("FuncionesAgregado", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe FuncionesAgregado con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new FuncionesAgregado(Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"]));
		} // End Read

		public static FuncionesAgregado Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("FuncionesAgregado", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new FuncionesAgregado(Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"]));
		} // End Read

		public static bool Read(out FuncionesAgregado funcionesagregado, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("FuncionesAgregado", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				funcionesagregado = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			funcionesagregado = new FuncionesAgregado(Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("FuncionesAgregado");
		} // End Read

		public static DataTable ReadDataTable(int funcionagregado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("FuncionAgregado_ID", funcionagregado_id);
			return DB.Select("FuncionesAgregado", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.UpdateRow("FuncionesAgregado", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);

			return DB.DeleteRow("FuncionesAgregado", w_params);
		} // End Delete

	} //End Class FuncionesAgregado

	public class GruposUsuarios
	{

		#region Constructors

		public GruposUsuarios()
		{
		}

		public GruposUsuarios(
			int grupousuario_id,
			string nombre,
			string descripcion)
		{
			this.GrupoUsuario_ID = grupousuario_id;
			this.Nombre = nombre;
			this.Descripcion = descripcion;
		}

		#endregion

		#region Properties

		private int _GrupoUsuario_ID;
		public int GrupoUsuario_ID
		{
			get { return _GrupoUsuario_ID; }
			set { _GrupoUsuario_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}

			if (this.Descripcion.Length > 250)
			{
				throw new Exception("Descripcion debe tener máximo 250 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

			return DB.InsertRow("GruposUsuarios", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("GrupoUsuario_ID", this.GrupoUsuario_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

			return DB.IdentityInsertRow("GruposUsuarios", m_params);
		} // End Create

		public static List<GruposUsuarios> Read()
		{
			List<GruposUsuarios> list = new List<GruposUsuarios>();
			DataTable dt = DB.Select("GruposUsuarios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
					new GruposUsuarios(
						Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToString(dr["Nombre"]),
						Convert.ToString(dr["Descripcion"])
					)
				);
			}

			return list;
		} // End Read

		public static GruposUsuarios Read(int grupousuario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("GrupoUsuario_ID", grupousuario_id);
			DataTable dt = DB.Select("GruposUsuarios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe GruposUsuarios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new GruposUsuarios(
				Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToString(dr["Nombre"]),
						Convert.ToString(dr["Descripcion"])
					);
		} // End Read

		public static GruposUsuarios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("GruposUsuarios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new GruposUsuarios(
				Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToString(dr["Nombre"]),
						Convert.ToString(dr["Descripcion"])
					);
		} // End Read

		public static bool Read(
			out GruposUsuarios gruposusuarios,
			int top,
			string filter,
			string sort,
			params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("GruposUsuarios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				gruposusuarios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			gruposusuarios = new GruposUsuarios(
				Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToString(dr["Nombre"]),
						Convert.ToString(dr["Descripcion"])
					);
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("GruposUsuarios");
		} // End Read

		public static DataTable ReadDataTable(int grupousuario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("GrupoUsuario_ID", grupousuario_id);
			return DB.Select("GruposUsuarios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("GrupoUsuario_ID", this.GrupoUsuario_ID);
			m_params.Add("Nombre", this.Nombre);
			if (!DB.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

			return DB.UpdateRow("GruposUsuarios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("GrupoUsuario_ID", this.GrupoUsuario_ID);

			return DB.DeleteRow("GruposUsuarios", w_params);
		} // End Delete


		#endregion
	} //End Class GruposUsuarios

	public class HistorialCobranzaConductores
	{

		#region Constructors

		public HistorialCobranzaConductores()
		{
		}

		public HistorialCobranzaConductores(
			int historialcobranzaconductor_id,
			int conductor_id,
			string usuario_id,
			int estacion_id,
			string accion,
			string comentario,
			int? referencia_id,
			DateTime? fecha)
		{
			this.HistorialCobranzaConductor_ID = historialcobranzaconductor_id;
			this.Conductor_ID = conductor_id;
			this.Usuario_ID = usuario_id;
			this.Estacion_ID = estacion_id;
			this.Accion = accion;
			this.Comentario = comentario;
			this.Referencia_ID = referencia_id;
			this.Fecha = fecha;
		}

		#endregion

		#region Properties

		private int _HistorialCobranzaConductor_ID;
		public int HistorialCobranzaConductor_ID
		{
			get { return _HistorialCobranzaConductor_ID; }
			set { _HistorialCobranzaConductor_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _Accion;
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}

		private string _Comentario;
		public string Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		private DateTime? _Fecha;
		public DateTime? Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Conductor_ID == 0) throw new Exception("Conductor_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.Accion == null) throw new Exception("Accion no puede ser nulo.");

			if (this.Accion.Length > 50)
			{
				throw new Exception("Accion debe tener máximo 50 carateres.");
			}

			if (this.Comentario == null) throw new Exception("Comentario no puede ser nulo.");

			if (this.Comentario.Length > 1073741823)
			{
				throw new Exception("Comentario debe tener máximo 1073741823 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Accion", this.Accion);
			m_params.Add("Comentario", this.Comentario);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			return DB.InsertRow("HistorialCobranzaConductores", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Accion", this.Accion);
			m_params.Add("Comentario", this.Comentario);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			return DB.IdentityInsertRow("HistorialCobranzaConductores", m_params);
		} // End Create

		public static List<HistorialCobranzaConductores> Read()
		{
			List<HistorialCobranzaConductores> list = new List<HistorialCobranzaConductores>();
			DataTable dt = DB.Select("HistorialCobranzaConductores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
					new HistorialCobranzaConductores(
						Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]),
						Convert.ToInt32(dr["Conductor_ID"]),
						Convert.ToString(dr["Usuario_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Accion"]),
						Convert.ToString(dr["Comentario"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableDateTime(dr["Fecha"])
					)
				);
			}

			return list;
		} // End Read

		public static HistorialCobranzaConductores Read(int historialcobranzaconductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("HistorialCobranzaConductor_ID", historialcobranzaconductor_id);
			DataTable dt = DB.Select("HistorialCobranzaConductores", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe HistorialCobranzaConductores con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new HistorialCobranzaConductores(
				Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]),
						Convert.ToInt32(dr["Conductor_ID"]),
						Convert.ToString(dr["Usuario_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Accion"]),
						Convert.ToString(dr["Comentario"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableDateTime(dr["Fecha"])
					);
		} // End Read

		public static HistorialCobranzaConductores Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("HistorialCobranzaConductores", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new HistorialCobranzaConductores(
				Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]),
						Convert.ToInt32(dr["Conductor_ID"]),
						Convert.ToString(dr["Usuario_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Accion"]),
						Convert.ToString(dr["Comentario"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableDateTime(dr["Fecha"])
					);
		} // End Read

		public static bool Read(
			out HistorialCobranzaConductores historialcobranzaconductores,
			int top,
			string filter,
			string sort,
			params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("HistorialCobranzaConductores", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				historialcobranzaconductores = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			historialcobranzaconductores = new HistorialCobranzaConductores(
				Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]),
						Convert.ToInt32(dr["Conductor_ID"]),
						Convert.ToString(dr["Usuario_ID"]),
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToString(dr["Accion"]),
						Convert.ToString(dr["Comentario"]),
						DB.GetNullableInt32(dr["Referencia_ID"]),
						DB.GetNullableDateTime(dr["Fecha"])
					);
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("HistorialCobranzaConductores");
		} // End Read

		public static DataTable ReadDataTable(int historialcobranzaconductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("HistorialCobranzaConductor_ID", historialcobranzaconductor_id);
			return DB.Select("HistorialCobranzaConductores", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Accion", this.Accion);
			m_params.Add("Comentario", this.Comentario);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			return DB.UpdateRow("HistorialCobranzaConductores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);

			return DB.DeleteRow("HistorialCobranzaConductores", w_params);
		} // End Delete


		#endregion
	} //End Class HistorialCobranzaConductores

	public class Indicadores
	{

		public Indicadores()
		{
		}

		public Indicadores(int indicador_id, string nombre)
		{
			this.Indicador_ID = indicador_id;
			this.Nombre = nombre;
		}

		private int _Indicador_ID;
		public int Indicador_ID
		{
			get { return _Indicador_ID; }
			set { _Indicador_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Indicadores", m_params);
		} // End Create

		public static List<Indicadores> Read()
		{
			List<Indicadores> list = new List<Indicadores>();
			DataTable dt = DB.Select("Indicadores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Indicadores(Convert.ToInt32(dr["Indicador_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<Indicadores> Read(int indicador_id)
		{
			List<Indicadores> list = new List<Indicadores>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Indicador_ID", indicador_id);
			DataTable dt = DB.Select("Indicadores", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Indicadores(Convert.ToInt32(dr["Indicador_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Indicadores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Indicador_ID", this.Indicador_ID);

			return DB.DeleteRow("Indicadores", w_params);
		}

	} //End Class Indicadores

	public class Inventario
	{

		#region Constructors

		public Inventario()
		{
		}

		public Inventario(
		    int empresa_id,
		    int estacion_id,
		    int refaccion_id,
		    string pasillo,
		    string estante,
		    string nivel,
		    string seccion,
		    decimal costounitario,
		    decimal preciointerno,
		    decimal precioexterno,
		    decimal margeninterno,
		    decimal margenexterno,
		    int cantidadinventario,
		    decimal valorinventario,
		    int puntodereorden)
		{
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Refaccion_ID = refaccion_id;
			this.Pasillo = pasillo;
			this.Estante = estante;
			this.Nivel = nivel;
			this.Seccion = seccion;
			this.CostoUnitario = costounitario;
			this.PrecioInterno = preciointerno;
			this.PrecioExterno = precioexterno;
			this.MargenInterno = margeninterno;
			this.MargenExterno = margenexterno;
			this.CantidadInventario = cantidadinventario;
			this.ValorInventario = valorinventario;
			this.PuntoDeReOrden = puntodereorden;
		}

		#endregion

		#region Properties

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private string _Pasillo;
		public string Pasillo
		{
			get { return _Pasillo; }
			set { _Pasillo = value; }
		}

		private string _Estante;
		public string Estante
		{
			get { return _Estante; }
			set { _Estante = value; }
		}

		private string _Nivel;
		public string Nivel
		{
			get { return _Nivel; }
			set { _Nivel = value; }
		}

		private string _Seccion;
		public string Seccion
		{
			get { return _Seccion; }
			set { _Seccion = value; }
		}

		private decimal _CostoUnitario;
		public decimal CostoUnitario
		{
			get { return _CostoUnitario; }
			set { _CostoUnitario = value; }
		}

		private decimal _PrecioInterno;
		public decimal PrecioInterno
		{
			get { return _PrecioInterno; }
			set { _PrecioInterno = value; }
		}

		private decimal _PrecioExterno;
		public decimal PrecioExterno
		{
			get { return _PrecioExterno; }
			set { _PrecioExterno = value; }
		}

		private decimal _MargenInterno;
		public decimal MargenInterno
		{
			get { return _MargenInterno; }
			set { _MargenInterno = value; }
		}

		private decimal _MargenExterno;
		public decimal MargenExterno
		{
			get { return _MargenExterno; }
			set { _MargenExterno = value; }
		}

		private int _CantidadInventario;
		public int CantidadInventario
		{
			get { return _CantidadInventario; }
			set { _CantidadInventario = value; }
		}

		private decimal _ValorInventario;
		public decimal ValorInventario
		{
			get { return _ValorInventario; }
			set { _ValorInventario = value; }
		}

		private int _PuntoDeReOrden;
		public int PuntoDeReOrden
		{
			get { return _PuntoDeReOrden; }
			set { _PuntoDeReOrden = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.Refaccion_ID == 0) throw new Exception("Refaccion_ID no puede ser nulo.");

			if (this.Pasillo.Length > 30)
			{
				throw new Exception("Pasillo debe tener máximo 30 carateres.");
			}

			if (this.Estante.Length > 30)
			{
				throw new Exception("Estante debe tener máximo 30 carateres.");
			}

			if (this.Nivel.Length > 30)
			{
				throw new Exception("Nivel debe tener máximo 30 carateres.");
			}

			if (this.Seccion.Length > 30)
			{
				throw new Exception("Seccion debe tener máximo 30 carateres.");
			}

			if (this.CostoUnitario == 0) throw new Exception("CostoUnitario no puede ser 0.");

			if (this.PrecioInterno == 0) throw new Exception("PrecioInterno no puede ser 0.");

			if (this.PrecioExterno == 0) throw new Exception("PrecioExterno no puede ser 0.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			if (!DB.IsNullOrEmpty(this.Pasillo)) m_params.Add("Pasillo", this.Pasillo);
			if (!DB.IsNullOrEmpty(this.Estante)) m_params.Add("Estante", this.Estante);
			if (!DB.IsNullOrEmpty(this.Nivel)) m_params.Add("Nivel", this.Nivel);
			if (!DB.IsNullOrEmpty(this.Seccion)) m_params.Add("Seccion", this.Seccion);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("PrecioInterno", this.PrecioInterno);
			m_params.Add("PrecioExterno", this.PrecioExterno);
			m_params.Add("MargenInterno", this.MargenInterno);
			m_params.Add("MargenExterno", this.MargenExterno);
			m_params.Add("CantidadInventario", this.CantidadInventario);
			m_params.Add("ValorInventario", this.ValorInventario);
			m_params.Add("PuntoDeReOrden", this.PuntoDeReOrden);

			return DB.InsertRow("Inventario", m_params);
		} // End Create

		public static List<Inventario> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Inventario> list = new List<Inventario>();
			DataTable dt = DB.Read("Inventario", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Inventario(
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToString(dr["Pasillo"]),
					   Convert.ToString(dr["Estante"]),
					   Convert.ToString(dr["Nivel"]),
					   Convert.ToString(dr["Seccion"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToDecimal(dr["PrecioInterno"]),
					   Convert.ToDecimal(dr["PrecioExterno"]),
					   Convert.ToDecimal(dr["MargenInterno"]),
					   Convert.ToDecimal(dr["MargenExterno"]),
					   Convert.ToInt32(dr["CantidadInventario"]),
					   Convert.ToDecimal(dr["ValorInventario"]),
					   Convert.ToInt32(dr["PuntoDeReOrden"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Inventario> Read()
		{
			List<Inventario> list = new List<Inventario>();
			DataTable dt = DB.Select("Inventario");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Inventario(
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToString(dr["Pasillo"]),
					   Convert.ToString(dr["Estante"]),
					   Convert.ToString(dr["Nivel"]),
					   Convert.ToString(dr["Seccion"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToDecimal(dr["PrecioInterno"]),
					   Convert.ToDecimal(dr["PrecioExterno"]),
					   Convert.ToDecimal(dr["MargenInterno"]),
					   Convert.ToDecimal(dr["MargenExterno"]),
					   Convert.ToInt32(dr["CantidadInventario"]),
					   Convert.ToDecimal(dr["ValorInventario"]),
					   Convert.ToInt32(dr["PuntoDeReOrden"])
				    )
				);
			}

			return list;
		} // End Read
		public static Inventario Read(int Refaccion_ID, int Empresa_ID, int Estacion_ID)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", Refaccion_ID);
			w_params.Add("Empresa_ID", Empresa_ID);
			w_params.Add("Estacion_ID", Estacion_ID);

			DataTable dt = DB.Select("Inventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Inventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Inventario(
			    Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Pasillo"]),
					  Convert.ToString(dr["Estante"]),
					  Convert.ToString(dr["Nivel"]),
					  Convert.ToString(dr["Seccion"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["PrecioInterno"]),
					  Convert.ToDecimal(dr["PrecioExterno"]),
					  Convert.ToDecimal(dr["MargenInterno"]),
					  Convert.ToDecimal(dr["MargenExterno"]),
					  Convert.ToInt32(dr["CantidadInventario"]),
					  Convert.ToDecimal(dr["ValorInventario"]),
					  Convert.ToInt32(dr["PuntoDeReOrden"])
				   );
		} // End Read


		public static Inventario Read(int Refaccion_ID)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", Refaccion_ID);

			DataTable dt = DB.Select("Inventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Inventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Inventario(
			    Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Pasillo"]),
					  Convert.ToString(dr["Estante"]),
					  Convert.ToString(dr["Nivel"]),
					  Convert.ToString(dr["Seccion"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["PrecioInterno"]),
					  Convert.ToDecimal(dr["PrecioExterno"]),
					  Convert.ToDecimal(dr["MargenInterno"]),
					  Convert.ToDecimal(dr["MargenExterno"]),
					  Convert.ToInt32(dr["CantidadInventario"]),
					  Convert.ToDecimal(dr["ValorInventario"]),
					  Convert.ToInt32(dr["PuntoDeReOrden"])
				   );
		} // End Read

		public static Inventario Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Inventario", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Inventario(
			    Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Pasillo"]),
					  Convert.ToString(dr["Estante"]),
					  Convert.ToString(dr["Nivel"]),
					  Convert.ToString(dr["Seccion"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["PrecioInterno"]),
					  Convert.ToDecimal(dr["PrecioExterno"]),
					  Convert.ToDecimal(dr["MargenInterno"]),
					  Convert.ToDecimal(dr["MargenExterno"]),
					  Convert.ToInt32(dr["CantidadInventario"]),
					  Convert.ToDecimal(dr["ValorInventario"]),
					  Convert.ToInt32(dr["PuntoDeReOrden"])
				   );
		} // End Read

		public static bool Read(
		    out Inventario inventario,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Inventario", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				inventario = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			inventario = new Inventario(
			    Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToString(dr["Pasillo"]),
					  Convert.ToString(dr["Estante"]),
					  Convert.ToString(dr["Nivel"]),
					  Convert.ToString(dr["Seccion"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["PrecioInterno"]),
					  Convert.ToDecimal(dr["PrecioExterno"]),
					  Convert.ToDecimal(dr["MargenInterno"]),
					  Convert.ToDecimal(dr["MargenExterno"]),
					  Convert.ToInt32(dr["CantidadInventario"]),
					  Convert.ToDecimal(dr["ValorInventario"]),
					  Convert.ToInt32(dr["PuntoDeReOrden"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Inventario");
		} // End Read

		public static DataTable ReadDataTable(int Refaccion_ID)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", Refaccion_ID);
			return DB.Select("Inventario", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", this.Empresa_ID);
			w_params.Add("Estacion_ID", this.Estacion_ID);
			w_params.Add("Refaccion_ID", this.Refaccion_ID);

			if (!DB.IsNullOrEmpty(this.Pasillo)) m_params.Add("Pasillo", this.Pasillo);
			if (!DB.IsNullOrEmpty(this.Estante)) m_params.Add("Estante", this.Estante);
			if (!DB.IsNullOrEmpty(this.Nivel)) m_params.Add("Nivel", this.Nivel);
			if (!DB.IsNullOrEmpty(this.Seccion)) m_params.Add("Seccion", this.Seccion);

			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("PrecioInterno", this.PrecioInterno);
			m_params.Add("PrecioExterno", this.PrecioExterno);
			m_params.Add("MargenInterno", this.MargenInterno);
			m_params.Add("MargenExterno", this.MargenExterno);
			m_params.Add("CantidadInventario", this.CantidadInventario);
			m_params.Add("ValorInventario", this.ValorInventario);
			m_params.Add("PuntoDeReOrden", this.PuntoDeReOrden);

			return DB.UpdateRow("Inventario", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();

			return DB.DeleteRow("Inventario", w_params);
		} // End Delete


		#endregion
	} //End Class Inventario

	public class LocacionesUnidades
	{

		#region Constructors

		public LocacionesUnidades()
		{
		}

		public LocacionesUnidades(
		    int locacionunidad_id,
		    string nombre,
		    int estatusunidad_id)
		{
			this.LocacionUnidad_ID = locacionunidad_id;
			this.Nombre = nombre;
			this.EstatusUnidad_ID = estatusunidad_id;
		}

		#endregion

		#region Properties

		private int _LocacionUnidad_ID;
		public int LocacionUnidad_ID
		{
			get { return _LocacionUnidad_ID; }
			set { _LocacionUnidad_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private int _EstatusUnidad_ID;
		public int EstatusUnidad_ID
		{
			get { return _EstatusUnidad_ID; }
			set { _EstatusUnidad_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{

			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}

			if (this.EstatusUnidad_ID == 0) throw new Exception("EstatusUnidad_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);

			return DB.InsertRow("LocacionesUnidades", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);

			return DB.IdentityInsertRow("LocacionesUnidades", m_params);
		} // End Create

		public static List<LocacionesUnidades> ReadButCirculando()
		{
			List<LocacionesUnidades> list = new List<LocacionesUnidades>();
			DataTable dt = DB.Select("LocacionesUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				if (Convert.ToInt32(dr["LocacionUnidad_ID"]) != 3)
				{
					list.Add(
					    new LocacionesUnidades(
						   Convert.ToInt32(dr["LocacionUnidad_ID"]),
						   Convert.ToString(dr["Nombre"]),
						   Convert.ToInt32(dr["EstatusUnidad_ID"])
					    )
					);
				}
			}

			return list;
		} // End ReadButCirculando

		public static List<LocacionesUnidades> Read()
		{
			List<LocacionesUnidades> list = new List<LocacionesUnidades>();
			DataTable dt = DB.Select("LocacionesUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new LocacionesUnidades(
					   Convert.ToInt32(dr["LocacionUnidad_ID"]),
					   Convert.ToString(dr["Nombre"]),
					   Convert.ToInt32(dr["EstatusUnidad_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static LocacionesUnidades Read(int locacionunidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("LocacionUnidad_ID", locacionunidad_id);
			DataTable dt = DB.Select("LocacionesUnidades", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe LocacionesUnidades con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new LocacionesUnidades(
			    Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"])
				   );
		} // End Read

		public static LocacionesUnidades Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("LocacionesUnidades", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new LocacionesUnidades(
			    Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"])
				   );
		} // End Read

		public static bool Read(
		    out LocacionesUnidades locacionesunidades,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("LocacionesUnidades", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				locacionesunidades = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			locacionesunidades = new LocacionesUnidades(
			    Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Nombre"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("LocacionesUnidades");
		} // End Read

		public static DataTable ReadDataTable(int locacionunidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("LocacionUnidad_ID", locacionunidad_id);
			return DB.Select("LocacionesUnidades", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);

			return DB.UpdateRow("LocacionesUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);

			return DB.DeleteRow("LocacionesUnidades", w_params);
		} // End Delete


		#endregion
	} //End Class LocacionesUnidades


	public class MarcasRefacciones
	{

		public MarcasRefacciones()
		{
		}

		public MarcasRefacciones(int marcarefaccion_id, string nombre)
		{
			this.MarcaRefaccion_ID = marcarefaccion_id;
			this.Nombre = nombre;
		}

		private int _MarcaRefaccion_ID;
		public int MarcaRefaccion_ID
		{
			get { return _MarcaRefaccion_ID; }
			set { _MarcaRefaccion_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("MarcasRefacciones", m_params);
		} // End Create

		public static List<MarcasRefacciones> Read()
		{
			List<MarcasRefacciones> list = new List<MarcasRefacciones>();
			DataTable dt = DB.Select("MarcasRefacciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new MarcasRefacciones(Convert.ToInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static MarcasRefacciones Read(int marcarefaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaRefaccion_ID", marcarefaccion_id);
			DataTable dt = DB.Select("MarcasRefacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe MarcasRefacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new MarcasRefacciones(Convert.ToInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("MarcasRefacciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);

			return DB.DeleteRow("MarcasRefacciones", w_params);
		} // End Delete

	} //End Class MarcasRefacciones

	public class MarcasUnidades
	{

		public MarcasUnidades()
		{
		}

		public MarcasUnidades(int marcaunidad_id, string descripcion)
		{
			this.MarcaUnidad_ID = marcaunidad_id;
			this.Descripcion = descripcion;
		}

		private int _MarcaUnidad_ID;
		public int MarcaUnidad_ID
		{
			get { return _MarcaUnidad_ID; }
			set { _MarcaUnidad_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Descripcion", this.Descripcion);

			return DB.InsertRow("MarcasUnidades", m_params);
		} // End Create

		public static List<MarcasUnidades> Read()
		{
			List<MarcasUnidades> list = new List<MarcasUnidades>();
			DataTable dt = DB.Select("MarcasUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"])));
			}

			return list;
		} // End Read

		public static List<MarcasUnidades> Read(int marcaunidad_id)
		{
			List<MarcasUnidades> list = new List<MarcasUnidades>();
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaUnidad_ID", marcaunidad_id);
			DataTable dt = DB.Select("MarcasUnidades", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.UpdateRow("MarcasUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);

			return DB.DeleteRow("MarcasUnidades", w_params);
		}

	} //End Class MarcasUnidades

	public class Mecanicos
	{

		#region Constructors

		public Mecanicos()
		{
		}

		public Mecanicos(
		    int mecanico_id,
		    int categoriamecanico_id,
		    int estatusmecanico_id,
		    string usuario_id,
		    DateTime fecha,
		    string codigobarras,
		    string nombres,
		    string apellidos,
		    string rfc,
		    string curp,
		    string nss,
		    string domicilio,
		    string ciudad,
		    string entidad,
		    string codigopostal,
		    string telefono,
		    string correoelectronico,
		    decimal salariodiario,
		    string horarioentrada,
		    string horariosalida,
		    int empresa_id,
		    int estacion_id)
		{
			this.Mecanico_ID = mecanico_id;
			this.CategoriaMecanico_ID = categoriamecanico_id;
			this.EstatusMecanico_ID = estatusmecanico_id;
			this.Usuario_ID = usuario_id;
			this.Fecha = fecha;
			this.CodigoBarras = codigobarras;
			this.Nombres = nombres;
			this.Apellidos = apellidos;
			this.Rfc = rfc;
			this.Curp = curp;
			this.NSS = nss;
			this.Domicilio = domicilio;
			this.Ciudad = ciudad;
			this.Entidad = entidad;
			this.CodigoPostal = codigopostal;
			this.Telefono = telefono;
			this.CorreoElectronico = correoelectronico;
			this.SalarioDiario = salariodiario;
			this.HorarioEntrada = horarioentrada;
			this.HorarioSalida = horariosalida;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _Mecanico_ID;
		public int Mecanico_ID
		{
			get { return _Mecanico_ID; }
			set { _Mecanico_ID = value; }
		}

		private int _CategoriaMecanico_ID;
		public int CategoriaMecanico_ID
		{
			get { return _CategoriaMecanico_ID; }
			set { _CategoriaMecanico_ID = value; }
		}

		private int _EstatusMecanico_ID;
		public int EstatusMecanico_ID
		{
			get { return _EstatusMecanico_ID; }
			set { _EstatusMecanico_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _CodigoBarras;
		public string CodigoBarras
		{
			get { return _CodigoBarras; }
			set { _CodigoBarras = value; }
		}

		private string _Nombres;
		public string Nombres
		{
			get { return _Nombres; }
			set { _Nombres = value; }
		}

		private string _Apellidos;
		public string Apellidos
		{
			get { return _Apellidos; }
			set { _Apellidos = value; }
		}

		private string _Rfc;
		public string Rfc
		{
			get { return _Rfc; }
			set { _Rfc = value; }
		}

		private string _Curp;
		public string Curp
		{
			get { return _Curp; }
			set { _Curp = value; }
		}

		private string _NSS;
		public string NSS
		{
			get { return _NSS; }
			set { _NSS = value; }
		}

		private string _Domicilio;
		public string Domicilio
		{
			get { return _Domicilio; }
			set { _Domicilio = value; }
		}

		private string _Ciudad;
		public string Ciudad
		{
			get { return _Ciudad; }
			set { _Ciudad = value; }
		}

		private string _Entidad;
		public string Entidad
		{
			get { return _Entidad; }
			set { _Entidad = value; }
		}

		private string _CodigoPostal;
		public string CodigoPostal
		{
			get { return _CodigoPostal; }
			set { _CodigoPostal = value; }
		}

		private string _Telefono;
		public string Telefono
		{
			get { return _Telefono; }
			set { _Telefono = value; }
		}

		private string _CorreoElectronico;
		public string CorreoElectronico
		{
			get { return _CorreoElectronico; }
			set { _CorreoElectronico = value; }
		}

		private decimal _SalarioDiario;
		public decimal SalarioDiario
		{
			get { return _SalarioDiario; }
			set { _SalarioDiario = value; }
		}

		private string _HorarioEntrada;
		public string HorarioEntrada
		{
			get { return _HorarioEntrada; }
			set { _HorarioEntrada = value; }
		}

		private string _HorarioSalida;
		public string HorarioSalida
		{
			get { return _HorarioSalida; }
			set { _HorarioSalida = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.CategoriaMecanico_ID == 0) throw new Exception("CategoriaMecanico_ID no puede ser nulo.");

			if (this.EstatusMecanico_ID == 0) throw new Exception("EstatusMecanico_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.CodigoBarras == null) throw new Exception("CodigoBarras no puede ser nulo.");

			if (this.CodigoBarras.Length > 50)
			{
				throw new Exception("CodigoBarras debe tener máximo 50 carateres.");
			}

			if (this.Nombres == null) throw new Exception("Nombres no puede ser nulo.");

			if (this.Nombres.Length > 50)
			{
				throw new Exception("Nombres debe tener máximo 50 carateres.");
			}

			if (this.Apellidos == null) throw new Exception("Apellidos no puede ser nulo.");

			if (this.Apellidos.Length > 100)
			{
				throw new Exception("Apellidos debe tener máximo 100 carateres.");
			}

			if (this.Rfc == null) throw new Exception("Rfc no puede ser nulo.");

			if (this.Rfc.Length > 20)
			{
				throw new Exception("Rfc debe tener máximo 20 carateres.");
			}

			if (this.Curp == null) throw new Exception("Curp no puede ser nulo.");

			if (this.Curp.Length > 50)
			{
				throw new Exception("Curp debe tener máximo 50 carateres.");
			}

			if (this.NSS == null) throw new Exception("NSS no puede ser nulo.");

			if (this.NSS.Length > 50)
			{
				throw new Exception("NSS debe tener máximo 50 carateres.");
			}

			if (this.Domicilio == null) throw new Exception("Domicilio no puede ser nulo.");

			if (this.Domicilio.Length > 150)
			{
				throw new Exception("Domicilio debe tener máximo 150 carateres.");
			}

			if (this.Ciudad == null) throw new Exception("Ciudad no puede ser nulo.");

			if (this.Ciudad.Length > 50)
			{
				throw new Exception("Ciudad debe tener máximo 50 carateres.");
			}

			if (this.Entidad == null) throw new Exception("Entidad no puede ser nulo.");

			if (this.Entidad.Length > 50)
			{
				throw new Exception("Entidad debe tener máximo 50 carateres.");
			}

			if (this.CodigoPostal == null) throw new Exception("CodigoPostal no puede ser nulo.");

			if (this.CodigoPostal.Length > 10)
			{
				throw new Exception("CodigoPostal debe tener máximo 10 carateres.");
			}

			if (this.Telefono == null) throw new Exception("Telefono no puede ser nulo.");

			if (this.Telefono.Length > 100)
			{
				throw new Exception("Telefono debe tener máximo 100 carateres.");
			}

			if (this.CorreoElectronico == null) throw new Exception("CorreoElectronico no puede ser nulo.");

			if (this.CorreoElectronico.Length > 100)
			{
				throw new Exception("CorreoElectronico debe tener máximo 100 carateres.");
			}

			if (this.SalarioDiario == 0) throw new Exception("SalarioDiario no puede ser 0.");

			if (this.HorarioEntrada == null) throw new Exception("HorarioEntrada no puede ser nulo.");

			if (this.HorarioEntrada.Length > 8)
			{
				throw new Exception("HorarioEntrada debe tener máximo 8 carateres.");
			}

			if (this.HorarioSalida == null) throw new Exception("HorarioSalida no puede ser nulo.");

			if (this.HorarioSalida.Length > 8)
			{
				throw new Exception("HorarioSalida debe tener máximo 8 carateres.");
			}

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
			m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Nombres", this.Nombres);
			m_params.Add("Apellidos", this.Apellidos);
			m_params.Add("Rfc", this.Rfc);
			m_params.Add("Curp", this.Curp);
			m_params.Add("NSS", this.NSS);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Telefono", this.Telefono);
			m_params.Add("CorreoElectronico", this.CorreoElectronico);
			m_params.Add("SalarioDiario", this.SalarioDiario);
			m_params.Add("HorarioEntrada", this.HorarioEntrada);
			m_params.Add("HorarioSalida", this.HorarioSalida);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.InsertRow("Mecanicos", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Mecanico_ID", this.Mecanico_ID);
			m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
			m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Nombres", this.Nombres);
			m_params.Add("Apellidos", this.Apellidos);
			m_params.Add("Rfc", this.Rfc);
			m_params.Add("Curp", this.Curp);
			m_params.Add("NSS", this.NSS);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Telefono", this.Telefono);
			m_params.Add("CorreoElectronico", this.CorreoElectronico);
			m_params.Add("SalarioDiario", this.SalarioDiario);
			m_params.Add("HorarioEntrada", this.HorarioEntrada);
			m_params.Add("HorarioSalida", this.HorarioSalida);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("Mecanicos", m_params);
		} // End Create

		public static List<Mecanicos> Read()
		{
			List<Mecanicos> list = new List<Mecanicos>();
			DataTable dt = DB.Select("Mecanicos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Mecanicos(
					   Convert.ToInt32(dr["Mecanico_ID"]),
					   Convert.ToInt32(dr["CategoriaMecanico_ID"]),
					   Convert.ToInt32(dr["EstatusMecanico_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["CodigoBarras"]),
					   Convert.ToString(dr["Nombres"]),
					   Convert.ToString(dr["Apellidos"]),
					   Convert.ToString(dr["Rfc"]),
					   Convert.ToString(dr["Curp"]),
					   Convert.ToString(dr["NSS"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Ciudad"]),
					   Convert.ToString(dr["Entidad"]),
					   Convert.ToString(dr["CodigoPostal"]),
					   Convert.ToString(dr["Telefono"]),
					   Convert.ToString(dr["CorreoElectronico"]),
					   Convert.ToDecimal(dr["SalarioDiario"]),
					   Convert.ToString(dr["HorarioEntrada"]),
					   Convert.ToString(dr["HorarioSalida"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Mecanicos> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Mecanicos> list = new List<Mecanicos>();
			DataTable dt = DB.Read("Mecanicos", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Mecanicos(
					   Convert.ToInt32(dr["Mecanico_ID"]),
					   Convert.ToInt32(dr["CategoriaMecanico_ID"]),
					   Convert.ToInt32(dr["EstatusMecanico_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["CodigoBarras"]),
					   Convert.ToString(dr["Nombres"]),
					   Convert.ToString(dr["Apellidos"]),
					   Convert.ToString(dr["Rfc"]),
					   Convert.ToString(dr["Curp"]),
					   Convert.ToString(dr["NSS"]),
					   Convert.ToString(dr["Domicilio"]),
					   Convert.ToString(dr["Ciudad"]),
					   Convert.ToString(dr["Entidad"]),
					   Convert.ToString(dr["CodigoPostal"]),
					   Convert.ToString(dr["Telefono"]),
					   Convert.ToString(dr["CorreoElectronico"]),
					   Convert.ToDecimal(dr["SalarioDiario"]),
					   Convert.ToString(dr["HorarioEntrada"]),
					   Convert.ToString(dr["HorarioSalida"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Mecanicos Read(int mecanico_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Mecanico_ID", mecanico_id);
			DataTable dt = DB.Select("Mecanicos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Mecanicos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Mecanicos(
			    Convert.ToInt32(dr["Mecanico_ID"]),
					  Convert.ToInt32(dr["CategoriaMecanico_ID"]),
					  Convert.ToInt32(dr["EstatusMecanico_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToString(dr["Nombres"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Rfc"]),
					  Convert.ToString(dr["Curp"]),
					  Convert.ToString(dr["NSS"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["CorreoElectronico"]),
					  Convert.ToDecimal(dr["SalarioDiario"]),
					  Convert.ToString(dr["HorarioEntrada"]),
					  Convert.ToString(dr["HorarioSalida"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static Mecanicos Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Mecanicos", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Mecanicos(
			    Convert.ToInt32(dr["Mecanico_ID"]),
					  Convert.ToInt32(dr["CategoriaMecanico_ID"]),
					  Convert.ToInt32(dr["EstatusMecanico_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToString(dr["Nombres"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Rfc"]),
					  Convert.ToString(dr["Curp"]),
					  Convert.ToString(dr["NSS"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["CorreoElectronico"]),
					  Convert.ToDecimal(dr["SalarioDiario"]),
					  Convert.ToString(dr["HorarioEntrada"]),
					  Convert.ToString(dr["HorarioSalida"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Mecanicos mecanicos,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Mecanicos", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				mecanicos = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			mecanicos = new Mecanicos(
			    Convert.ToInt32(dr["Mecanico_ID"]),
					  Convert.ToInt32(dr["CategoriaMecanico_ID"]),
					  Convert.ToInt32(dr["EstatusMecanico_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToString(dr["Nombres"]),
					  Convert.ToString(dr["Apellidos"]),
					  Convert.ToString(dr["Rfc"]),
					  Convert.ToString(dr["Curp"]),
					  Convert.ToString(dr["NSS"]),
					  Convert.ToString(dr["Domicilio"]),
					  Convert.ToString(dr["Ciudad"]),
					  Convert.ToString(dr["Entidad"]),
					  Convert.ToString(dr["CodigoPostal"]),
					  Convert.ToString(dr["Telefono"]),
					  Convert.ToString(dr["CorreoElectronico"]),
					  Convert.ToDecimal(dr["SalarioDiario"]),
					  Convert.ToString(dr["HorarioEntrada"]),
					  Convert.ToString(dr["HorarioSalida"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Mecanicos");
		} // End Read

		public static DataTable ReadDataTable(int mecanico_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Mecanico_ID", mecanico_id);
			return DB.Select("Mecanicos", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Mecanico_ID", this.Mecanico_ID);
			m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
			m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Nombres", this.Nombres);
			m_params.Add("Apellidos", this.Apellidos);
			m_params.Add("Rfc", this.Rfc);
			m_params.Add("Curp", this.Curp);
			m_params.Add("NSS", this.NSS);
			m_params.Add("Domicilio", this.Domicilio);
			m_params.Add("Ciudad", this.Ciudad);
			m_params.Add("Entidad", this.Entidad);
			m_params.Add("CodigoPostal", this.CodigoPostal);
			m_params.Add("Telefono", this.Telefono);
			m_params.Add("CorreoElectronico", this.CorreoElectronico);
			m_params.Add("SalarioDiario", this.SalarioDiario);
			m_params.Add("HorarioEntrada", this.HorarioEntrada);
			m_params.Add("HorarioSalida", this.HorarioSalida);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("Mecanicos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Mecanico_ID", this.Mecanico_ID);

			return DB.DeleteRow("Mecanicos", w_params);
		} // End Delete


		#endregion
	} //End Class Mecanicos

	public class MediosPublicitarios
	{

		public MediosPublicitarios()
		{
		}

		public MediosPublicitarios(int mediopublicitario_id, int clasepublicidad_id, string nombre)
		{
			this.MedioPublicitario_ID = mediopublicitario_id;
			this.ClasePublicidad_ID = clasepublicidad_id;
			this.Nombre = nombre;
		}

		private int _MedioPublicitario_ID;
		public int MedioPublicitario_ID
		{
			get { return _MedioPublicitario_ID; }
			set { _MedioPublicitario_ID = value; }
		}

		private int _ClasePublicidad_ID;
		public int ClasePublicidad_ID
		{
			get { return _ClasePublicidad_ID; }
			set { _ClasePublicidad_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("MediosPublicitarios", m_params);
		} // End Create

		public static List<MediosPublicitarios> Read()
		{
			List<MediosPublicitarios> list = new List<MediosPublicitarios>();
			DataTable dt = DB.Select("MediosPublicitarios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new MediosPublicitarios(Convert.ToInt32(dr["MedioPublicitario_ID"]), Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<MediosPublicitarios> Read(int mediopublicitario_id)
		{
			List<MediosPublicitarios> list = new List<MediosPublicitarios>();
			Hashtable w_params = new Hashtable();
			w_params.Add("MedioPublicitario_ID", mediopublicitario_id);
			DataTable dt = DB.Select("MediosPublicitarios", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new MediosPublicitarios(Convert.ToInt32(dr["MedioPublicitario_ID"]), Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
			m_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("MediosPublicitarios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);

			return DB.DeleteRow("MediosPublicitarios", w_params);
		}

	} //End Class MediosPublicitarios

	public class Menues
	{

		public Menues()
		{
		}

		public Menues(int menu_id, int modulo_id, string nombre, string imagen)
		{
			this.Menu_ID = menu_id;
			this.Modulo_ID = modulo_id;
			this.Nombre = nombre;
			this.Imagen = imagen;
		}

		private int _Menu_ID;
		public int Menu_ID
		{
			get { return _Menu_ID; }
			set { _Menu_ID = value; }
		}

		private int _Modulo_ID;
		public int Modulo_ID
		{
			get { return _Modulo_ID; }
			set { _Modulo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Imagen;
		public string Imagen
		{
			get { return _Imagen; }
			set { _Imagen = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Modulo_ID", this.Modulo_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Imagen", this.Imagen);

			return DB.InsertRow("Menues", m_params);
		} // End Create

		public static List<Menues> Read()
		{
			List<Menues> list = new List<Menues>();
			DataTable dt = DB.Select("Menues");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Menues(Convert.ToInt32(dr["Menu_ID"]), Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Imagen"])));
			}

			return list;
		} // End Read

		public static List<Menues> Read(params KeyValuePair<string, object>[] args)
		{
			List<Menues> list = new List<Menues>();
			DataTable dt = DB.Read("Menues", args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Menues(Convert.ToInt32(dr["Menu_ID"]), Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Imagen"])));
			}

			return list;
		} // End Read

		public static Menues Read(int menu_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Menu_ID", menu_id);
			DataTable dt = DB.Select("Menues", w_params);

			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				return new Menues(Convert.ToInt32(dr["Menu_ID"]), Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Imagen"]));
			}

			return null;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Menu_ID", this.Menu_ID);
			m_params.Add("Modulo_ID", this.Modulo_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Imagen", this.Imagen);

			return DB.UpdateRow("Menues", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Menu_ID", this.Menu_ID);

			return DB.DeleteRow("Menues", w_params);
		}

	} //End Class Menues

	public class Mercados
	{

		public Mercados()
		{
		}

		public Mercados(int mercado_id, string nombre)
		{
			this.Mercado_ID = mercado_id;
			this.Nombre = nombre;
		}

		private int _Mercado_ID;
		public int Mercado_ID
		{
			get { return _Mercado_ID; }
			set { _Mercado_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Mercados", m_params);
		} // End Create

		public static List<Mercados> Read()
		{
			List<Mercados> list = new List<Mercados>();
			DataTable dt = DB.Select("Mercados");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Mercados(Convert.ToInt32(dr["Mercado_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<Mercados> Read(int mercado_id)
		{
			List<Mercados> list = new List<Mercados>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Mercado_ID", mercado_id);
			DataTable dt = DB.Select("Mercados", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Mercados(Convert.ToInt32(dr["Mercado_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Mercados", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Mercado_ID", this.Mercado_ID);

			return DB.DeleteRow("Mercados", w_params);
		}

	} //End Class Mercados

	public class Modelos
	{

		public Modelos()
		{
		}

		public Modelos(int modelo_id, string nombre)
		{
			this.Modelo_ID = modelo_id;
			this.Nombre = nombre;
		}

		private int _Modelo_ID;
		public int Modelo_ID
		{
			get { return _Modelo_ID; }
			set { _Modelo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Modelos", m_params);
		} // End Create

		public static List<Modelos> Read()
		{
			List<Modelos> list = new List<Modelos>();
			DataTable dt = DB.Select("Modelos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Modelos(Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static Modelos Read(int modelo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Modelo_ID", modelo_id);
			DataTable dt = DB.Select("Modelos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Modelos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Modelos(Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Modelos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Modelo_ID", this.Modelo_ID);

			return DB.DeleteRow("Modelos", w_params);
		} // End Delete

	} //End Class Modelos

	public class ModelosUnidades
	{

		public ModelosUnidades()
		{

		}

		public ModelosUnidades(int modelounidad_id, int marcaunidad_id, string descripcion, decimal preciolista, int anio, decimal deposito, bool activo, int? referencia_id, int? empresareferencia, int? modelo_id)
		{
			this.ModeloUnidad_ID = modelounidad_id;
			this.MarcaUnidad_ID = marcaunidad_id;
			this.Descripcion = descripcion;
			this.PrecioLista = preciolista;
			this.Anio = anio;
			this.Deposito = deposito;
			this.Activo = activo;
			this.referencia_id = referencia_id;
			this.EmpresaReferencia = empresareferencia;
			this.Modelo_ID = modelo_id;
		}

		private int _ModeloUnidad_ID;
		public int ModeloUnidad_ID
		{
			get { return _ModeloUnidad_ID; }
			set { _ModeloUnidad_ID = value; }
		}

		private int _MarcaUnidad_ID;
		public int MarcaUnidad_ID
		{
			get { return _MarcaUnidad_ID; }
			set { _MarcaUnidad_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private decimal _PrecioLista;
		public decimal PrecioLista
		{
			get { return _PrecioLista; }
			set { _PrecioLista = value; }
		}

		private int _Anio;
		public int Anio
		{
			get { return _Anio; }
			set { _Anio = value; }
		}

		private decimal _Deposito;
		public decimal Deposito
		{
			get { return _Deposito; }
			set { _Deposito = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private int? _referencia_id;
		public int? referencia_id
		{
			get { return _referencia_id; }
			set { _referencia_id = value; }
		}

		private int? _EmpresaReferencia;
		public int? EmpresaReferencia
		{
			get { return _EmpresaReferencia; }
			set { _EmpresaReferencia = value; }
		}

		private int? _Modelo_ID;
		public int? Modelo_ID
		{
			get { return _Modelo_ID; }
			set { _Modelo_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("Anio", this.Anio);
			m_params.Add("Deposito", this.Deposito);
			m_params.Add("Activo", this.Activo);
			if (!AppHelper.IsNullOrEmpty(this.referencia_id)) m_params.Add("referencia_id", this.referencia_id);
			if (!AppHelper.IsNullOrEmpty(this.EmpresaReferencia)) m_params.Add("EmpresaReferencia", this.EmpresaReferencia);
			if (!AppHelper.IsNullOrEmpty(this.Modelo_ID)) m_params.Add("Modelo_ID", this.Modelo_ID);

			int result = DB.InsertRow("ModelosUnidades", m_params);
			this.ModeloUnidad_ID = Convert.ToInt32(
			    DB.Ident_Current("ModelosUnidades")
			);
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("Anio", this.Anio);
			m_params.Add("Deposito", this.Deposito);
			m_params.Add("Activo", this.Activo);
			if (!AppHelper.IsNullOrEmpty(this.referencia_id)) m_params.Add("referencia_id", this.referencia_id);
			if (!AppHelper.IsNullOrEmpty(this.EmpresaReferencia)) m_params.Add("EmpresaReferencia", this.EmpresaReferencia);
			if (!AppHelper.IsNullOrEmpty(this.Modelo_ID)) m_params.Add("Modelo_ID", this.Modelo_ID);

			return DB.IdentityInsertRow("ModelosUnidades", m_params);
		} // End Create

		public static List<ModelosUnidades> Read()
		{
			List<ModelosUnidades> list = new List<ModelosUnidades>();
			DataTable dt = DB.Select("ModelosUnidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["referencia_id"]), DB.GetNullableInt32(dr["EmpresaReferencia"]), DB.GetNullableInt32(dr["Modelo_ID"])));
			}

			return list;
		} // End Read

		public static ModelosUnidades Read(int modelounidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ModeloUnidad_ID", modelounidad_id);
			DataTable dt = DB.Select("ModelosUnidades", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ModelosUnidades con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["referencia_id"]), DB.GetNullableInt32(dr["EmpresaReferencia"]), DB.GetNullableInt32(dr["Modelo_ID"]));
		} // End Read

		public static ModelosUnidades Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ModelosUnidades", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["referencia_id"]), DB.GetNullableInt32(dr["EmpresaReferencia"]), DB.GetNullableInt32(dr["Modelo_ID"]));
		} // End Read

		public static bool Read(out ModelosUnidades modelosunidades, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ModelosUnidades", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				modelosunidades = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			modelosunidades = new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["referencia_id"]), DB.GetNullableInt32(dr["EmpresaReferencia"]), DB.GetNullableInt32(dr["Modelo_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ModelosUnidades");
		} // End Read

		public static DataTable ReadDataTable(int modelounidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ModeloUnidad_ID", modelounidad_id);
			return DB.Select("ModelosUnidades", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("Anio", this.Anio);
			m_params.Add("Deposito", this.Deposito);
			m_params.Add("Activo", this.Activo);
			if (!AppHelper.IsNullOrEmpty(this.referencia_id)) m_params.Add("referencia_id", this.referencia_id);
			if (!AppHelper.IsNullOrEmpty(this.EmpresaReferencia)) m_params.Add("EmpresaReferencia", this.EmpresaReferencia);
			if (!AppHelper.IsNullOrEmpty(this.Modelo_ID)) m_params.Add("Modelo_ID", this.Modelo_ID);

			return DB.UpdateRow("ModelosUnidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);

			return DB.DeleteRow("ModelosUnidades", w_params);
		} // End Delete

	} //End Class ModelosUnidades

	public class Modulos
	{

		public Modulos()
		{
		}

		public Modulos(int modulo_id, string nombre)
		{
			this.Modulo_ID = modulo_id;
			this.Nombre = nombre;
		}

		private int _Modulo_ID;
		public int Modulo_ID
		{
			get { return _Modulo_ID; }
			set { _Modulo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Modulos", m_params);
		} // End Create

		public static List<Modulos> Read()
		{
			List<Modulos> list = new List<Modulos>();
			DataTable dt = DB.Select("Modulos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<Modulos> Read(int modulo_id)
		{
			List<Modulos> list = new List<Modulos>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Modulo_ID", modulo_id);
			DataTable dt = DB.Select("Modulos", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Modulo_ID", this.Modulo_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Modulos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Modulo_ID", this.Modulo_ID);

			return DB.DeleteRow("Modulos", w_params);
		}

	} //End Class Modulos

	public class Monedas
	{

		public Monedas()
		{
		}

		public Monedas(int moneda_id, string nombre, decimal tipocambio)
		{
			this.Moneda_ID = moneda_id;
			this.Nombre = nombre;
			this.TipoCambio = tipocambio;
		}

		public Monedas(int moneda_id, string nombre, decimal tipocambio, int tipotarjeta, string tipotarjeta_desc, string tipotarjeta_abr)
		{
			this.Moneda_ID = moneda_id;
			this.Nombre = nombre;
			this.TipoCambio = tipocambio;
			this.TipoTarjeta_ID = tipotarjeta;
			this.TipoTarjeta_Descripcion = tipotarjeta_desc;
			this.TipoTarjeta_Abreviatura = tipotarjeta_abr;
		}

		private int _Moneda_ID;
		public int Moneda_ID
		{
			get { return _Moneda_ID; }
			set { _Moneda_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private decimal _TipoCambio;
		public decimal TipoCambio
		{
			get { return _TipoCambio; }
			set { _TipoCambio = value; }
		}

		private int _tipoTarjeta_ID;
		public int TipoTarjeta_ID { get { return _tipoTarjeta_ID; } set { _tipoTarjeta_ID = value; } }

		private string _tipoTarjeta_Descripcion;
		public string TipoTarjeta_Descripcion { get { return _tipoTarjeta_Descripcion; } set { _tipoTarjeta_Descripcion = value; } }

		private string _tipoTarjeta_Abreviatura;
		public string TipoTarjeta_Abreviatura { get { return _tipoTarjeta_Abreviatura; } set { _tipoTarjeta_Abreviatura = value; } }

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("TipoCambio", this.TipoCambio);

			return DB.InsertRow("Monedas", m_params);
		} // End Create

		public static List<Monedas> Read()
		{
			List<Monedas> list = new List<Monedas>();
			Hashtable hparams = new Hashtable();
			DataSet ds = DB.QueryDS("usp_Obtiene_Monedas_Cat", hparams);
			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					list.Add(new Monedas(
							Convert.ToInt32(dr["Moneda_ID"])
							, Convert.ToString(dr["Nombre"])
							, Convert.ToDecimal(dr["TipoCambio"])
							, Convert.ToInt32(dr["TipoTarjeta_ID"])
							, dr["TipoTarjeta_Desc"].ToString()
							, dr["TipoTarjeta_Abr"].ToString()
							));
				}
			}
			return list;
		} // End Read

		public static List<Monedas> GetVales()
		{
			List<Monedas> list = new List<Monedas>();
			Hashtable hparams = new Hashtable();
			DataSet ds = DB.QueryDS("usp_Obtiene_Monedas_Vales", hparams);
			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					list.Add(new Monedas(
							Convert.ToInt32(dr["Moneda_ID"])
							, Convert.ToString(dr["Nombre"])
							, Convert.ToDecimal(dr["TipoCambio"])
							, Convert.ToInt32(dr["TipoTarjeta_ID"])
							, dr["TipoTarjeta_Desc"].ToString()
							, dr["TipoTarjeta_Abr"].ToString()
							));
				}
			}
			return list;
		}

		public static List<Monedas> Read(int moneda_id)
		{
			List<Monedas> list = new List<Monedas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Moneda_ID", moneda_id);
			DataSet ds = DB.QueryDS("usp_Obtiene_Monedas_Cat", w_params);
			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					list.Add(new Monedas(
						Convert.ToInt32(dr["Moneda_ID"])
						, Convert.ToString(dr["Nombre"])
						, Convert.ToDecimal(dr["TipoCambio"])
						, Convert.ToInt32(dr["TipoTarjeta_ID"])
						, dr["TipoTarjeta_Desc"].ToString()
						, dr["TipoTarjeta_Abr"].ToString()
						));
				}
			}
			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Moneda_ID", this.Moneda_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("TipoCambio", this.TipoCambio);
			m_params.Add("TipoTarjeta_ID", this.TipoTarjeta_ID);
			return DB.UpdateRow("Monedas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Moneda_ID", this.Moneda_ID);

			return DB.DeleteRow("Monedas", w_params);
		}

	} //End Class Monedas

	public class MovimientosInventario
	{

		#region Constructors

		public MovimientosInventario()
		{
		}

		public MovimientosInventario(
		    int movimientoinventario_id,
		    int tipomovimientoinventario_id,
		    int? ordencompra_id,
		    int? ordentrabajo_id,
		    int? notaalmacen_id,
		    int? ajusteinventario_id,
		    string usuario_id,
		    int refaccion_id,
		    DateTime fecha,
		    int cantidad,
		    decimal costounitario,
		    decimal valor,
		    int cantidadprev,
		    decimal valorprev,
		    int cantidadpost,
		    decimal valorpost,
		    int cantidadprevprom,
		    decimal valorprevprom,
		    int cantidadpostprom,
		    decimal valorpostprom,
		    string referencia,
		    decimal costounitarioprom,
		    int empresa_id,
		    int estacion_id)
		{
			this.MovimientoInventario_ID = movimientoinventario_id;
			this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
			this.OrdenCompra_ID = ordencompra_id;
			this.OrdenTrabajo_ID = ordentrabajo_id;
			this.NotaAlmacen_ID = notaalmacen_id;
			this.AjusteInventario_ID = ajusteinventario_id;
			this.Usuario_ID = usuario_id;
			this.Refaccion_ID = refaccion_id;
			this.Fecha = fecha;
			this.Cantidad = cantidad;
			this.CostoUnitario = costounitario;
			this.Valor = valor;
			this.CantidadPrev = cantidadprev;
			this.ValorPrev = valorprev;
			this.CantidadPost = cantidadpost;
			this.ValorPost = valorpost;
			this.CantidadPrevProm = cantidadprevprom;
			this.ValorPrevProm = valorprevprom;
			this.CantidadPostProm = cantidadpostprom;
			this.ValorPostProm = valorpostprom;
			this.Referencia = referencia;
			this.CostoUnitarioProm = costounitarioprom;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _MovimientoInventario_ID;
		public int MovimientoInventario_ID
		{
			get { return _MovimientoInventario_ID; }
			set { _MovimientoInventario_ID = value; }
		}

		private int _TipoMovimientoInventario_ID;
		public int TipoMovimientoInventario_ID
		{
			get { return _TipoMovimientoInventario_ID; }
			set { _TipoMovimientoInventario_ID = value; }
		}

		private int? _OrdenCompra_ID;
		public int? OrdenCompra_ID
		{
			get { return _OrdenCompra_ID; }
			set { _OrdenCompra_ID = value; }
		}

		private int? _OrdenTrabajo_ID;
		public int? OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		private int? _NotaAlmacen_ID;
		public int? NotaAlmacen_ID
		{
			get { return _NotaAlmacen_ID; }
			set { _NotaAlmacen_ID = value; }
		}

		private int? _AjusteInventario_ID;
		public int? AjusteInventario_ID
		{
			get { return _AjusteInventario_ID; }
			set { _AjusteInventario_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		private decimal _CostoUnitario;
		public decimal CostoUnitario
		{
			get { return _CostoUnitario; }
			set { _CostoUnitario = value; }
		}

		private decimal _Valor;
		public decimal Valor
		{
			get { return _Valor; }
			set { _Valor = value; }
		}

		private int _CantidadPrev;
		public int CantidadPrev
		{
			get { return _CantidadPrev; }
			set { _CantidadPrev = value; }
		}

		private decimal _ValorPrev;
		public decimal ValorPrev
		{
			get { return _ValorPrev; }
			set { _ValorPrev = value; }
		}

		private int _CantidadPost;
		public int CantidadPost
		{
			get { return _CantidadPost; }
			set { _CantidadPost = value; }
		}

		private decimal _ValorPost;
		public decimal ValorPost
		{
			get { return _ValorPost; }
			set { _ValorPost = value; }
		}

		private int _CantidadPrevProm;
		public int CantidadPrevProm
		{
			get { return _CantidadPrevProm; }
			set { _CantidadPrevProm = value; }
		}

		private decimal _ValorPrevProm;
		public decimal ValorPrevProm
		{
			get { return _ValorPrevProm; }
			set { _ValorPrevProm = value; }
		}

		private int _CantidadPostProm;
		public int CantidadPostProm
		{
			get { return _CantidadPostProm; }
			set { _CantidadPostProm = value; }
		}

		private decimal _ValorPostProm;
		public decimal ValorPostProm
		{
			get { return _ValorPostProm; }
			set { _ValorPostProm = value; }
		}

		private string _Referencia;
		public string Referencia
		{
			get { return _Referencia; }
			set { _Referencia = value; }
		}

		private decimal _CostoUnitarioProm;
		public decimal CostoUnitarioProm
		{
			get { return _CostoUnitarioProm; }
			set { _CostoUnitarioProm = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.TipoMovimientoInventario_ID == 0) throw new Exception("TipoMovimientoInventario_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Refaccion_ID == 0) throw new Exception("Refaccion_ID no puede ser nulo.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Cantidad == 0) throw new Exception("Cantidad no puede ser 0.");

			if (this.CostoUnitario == 0) throw new Exception("CostoUnitario no puede ser 0.");

			if (this.Valor == 0) throw new Exception("Valor no puede ser 0.");

			if (this.Referencia.Length > 8)
			{
				throw new Exception("Referencia debe tener máximo 8 carateres.");
			}

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
			if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Valor", this.Valor);
			m_params.Add("CantidadPrev", this.CantidadPrev);
			m_params.Add("ValorPrev", this.ValorPrev);
			m_params.Add("CantidadPost", this.CantidadPost);
			m_params.Add("ValorPost", this.ValorPost);
			m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
			m_params.Add("ValorPrevProm", this.ValorPrevProm);
			m_params.Add("CantidadPostProm", this.CantidadPostProm);
			m_params.Add("ValorPostProm", this.ValorPostProm);
			if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
			m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			int result = DB.InsertRow("MovimientosInventario", m_params);
			this.MovimientoInventario_ID = Convert.ToInt32(DB.Ident_Current("MovimientosInventario"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
			if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Valor", this.Valor);
			m_params.Add("CantidadPrev", this.CantidadPrev);
			m_params.Add("ValorPrev", this.ValorPrev);
			m_params.Add("CantidadPost", this.CantidadPost);
			m_params.Add("ValorPost", this.ValorPost);
			m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
			m_params.Add("ValorPrevProm", this.ValorPrevProm);
			m_params.Add("CantidadPostProm", this.CantidadPostProm);
			m_params.Add("ValorPostProm", this.ValorPostProm);
			if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
			m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("MovimientosInventario", m_params);
		} // End Create

		public static List<MovimientosInventario> Read()
		{
			List<MovimientosInventario> list = new List<MovimientosInventario>();
			DataTable dt = DB.Select("MovimientosInventario");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new MovimientosInventario(
					   Convert.ToInt32(dr["MovimientoInventario_ID"]),
					   Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					   DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					   DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					   DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					   DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["Cantidad"]),
					   Convert.ToDecimal(dr["CostoUnitario"]),
					   Convert.ToDecimal(dr["Valor"]),
					   Convert.ToInt32(dr["CantidadPrev"]),
					   Convert.ToDecimal(dr["ValorPrev"]),
					   Convert.ToInt32(dr["CantidadPost"]),
					   Convert.ToDecimal(dr["ValorPost"]),
					   Convert.ToInt32(dr["CantidadPrevProm"]),
					   Convert.ToDecimal(dr["ValorPrevProm"]),
					   Convert.ToInt32(dr["CantidadPostProm"]),
					   Convert.ToDecimal(dr["ValorPostProm"]),
					   Convert.ToString(dr["Referencia"]),
					   Convert.ToDecimal(dr["CostoUnitarioProm"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static MovimientosInventario Read(int movimientoinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MovimientoInventario_ID", movimientoinventario_id);
			DataTable dt = DB.Select("MovimientosInventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe MovimientosInventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new MovimientosInventario(
			    Convert.ToInt32(dr["MovimientoInventario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					  DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Valor"]),
					  Convert.ToInt32(dr["CantidadPrev"]),
					  Convert.ToDecimal(dr["ValorPrev"]),
					  Convert.ToInt32(dr["CantidadPost"]),
					  Convert.ToDecimal(dr["ValorPost"]),
					  Convert.ToInt32(dr["CantidadPrevProm"]),
					  Convert.ToDecimal(dr["ValorPrevProm"]),
					  Convert.ToInt32(dr["CantidadPostProm"]),
					  Convert.ToDecimal(dr["ValorPostProm"]),
					  Convert.ToString(dr["Referencia"]),
					  Convert.ToDecimal(dr["CostoUnitarioProm"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static MovimientosInventario Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("MovimientosInventario", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new MovimientosInventario(
			    Convert.ToInt32(dr["MovimientoInventario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					  DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Valor"]),
					  Convert.ToInt32(dr["CantidadPrev"]),
					  Convert.ToDecimal(dr["ValorPrev"]),
					  Convert.ToInt32(dr["CantidadPost"]),
					  Convert.ToDecimal(dr["ValorPost"]),
					  Convert.ToInt32(dr["CantidadPrevProm"]),
					  Convert.ToDecimal(dr["ValorPrevProm"]),
					  Convert.ToInt32(dr["CantidadPostProm"]),
					  Convert.ToDecimal(dr["ValorPostProm"]),
					  Convert.ToString(dr["Referencia"]),
					  Convert.ToDecimal(dr["CostoUnitarioProm"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out MovimientosInventario movimientosinventario,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("MovimientosInventario", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				movimientosinventario = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			movimientosinventario = new MovimientosInventario(
			    Convert.ToInt32(dr["MovimientoInventario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					  DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Valor"]),
					  Convert.ToInt32(dr["CantidadPrev"]),
					  Convert.ToDecimal(dr["ValorPrev"]),
					  Convert.ToInt32(dr["CantidadPost"]),
					  Convert.ToDecimal(dr["ValorPost"]),
					  Convert.ToInt32(dr["CantidadPrevProm"]),
					  Convert.ToDecimal(dr["ValorPrevProm"]),
					  Convert.ToInt32(dr["CantidadPostProm"]),
					  Convert.ToDecimal(dr["ValorPostProm"]),
					  Convert.ToString(dr["Referencia"]),
					  Convert.ToDecimal(dr["CostoUnitarioProm"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("MovimientosInventario");
		} // End Read

		public static DataTable ReadDataTable(int movimientoinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MovimientoInventario_ID", movimientoinventario_id);
			return DB.Select("MovimientosInventario", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
			if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			m_params.Add("Valor", this.Valor);
			m_params.Add("CantidadPrev", this.CantidadPrev);
			m_params.Add("ValorPrev", this.ValorPrev);
			m_params.Add("CantidadPost", this.CantidadPost);
			m_params.Add("ValorPost", this.ValorPost);
			m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
			m_params.Add("ValorPrevProm", this.ValorPrevProm);
			m_params.Add("CantidadPostProm", this.CantidadPostProm);
			m_params.Add("ValorPostProm", this.ValorPostProm);
			if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
			m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("MovimientosInventario", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);

			return DB.DeleteRow("MovimientosInventario", w_params);
		} // End Delete

		public int UpdateRefaccion(bool ActualizaPrecio)
		{
			if (ActualizaPrecio)
			{
				decimal MargenInterno = 0;
				decimal MargenExterno = 0;
				//buscar MargenInterno y Margen Externo
				DataTable dt = DB.Read("Inventario",
					   DB.Param("Refaccion_ID", this.Refaccion_ID),
					   DB.Param("Empresa_ID", this.Empresa_ID),
					   DB.Param("Estacion_ID", this.Estacion_ID)
				    );

				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					MargenInterno = Convert.ToDecimal(dr["MargenInterno"]);
					MargenExterno = Convert.ToDecimal(dr["MargenExterno"]);
				}
				return DB.UpdateRow(
				    "Inventario",
				    DB.GetParams(
					   DB.Param("CantidadInventario", this.CantidadPost),
					   DB.Param("CostoUnitario", this.CostoUnitario),
					   DB.Param("PrecioInterno", this.CostoUnitario * (1 + (MargenInterno / Convert.ToDecimal(100.00)))),
					   DB.Param("PrecioExterno", this.CostoUnitario * (1 + (MargenExterno / Convert.ToDecimal(100.00))))

				    ),
				    DB.GetParams(
					   DB.Param("Refaccion_ID", this.Refaccion_ID),
					   DB.Param("Empresa_ID", this.Empresa_ID),
					   DB.Param("Estacion_ID", this.Estacion_ID)
				    )
				);
			}
			else
			{
				return DB.UpdateRow(
				    "Inventario",
				    DB.GetParams(
					   DB.Param("CantidadInventario", this.CantidadPost)
				    ),
				    DB.GetParams(
					   DB.Param("Refaccion_ID", this.Refaccion_ID),
					   DB.Param("Empresa_ID", this.Empresa_ID),
					   DB.Param("Estacion_ID", this.Estacion_ID)
				    )
				);
			}
		}

		public static MovimientosInventario GetLastByRefaccion(int refaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("MovimientoInventario_ID", refaccion_id);
			DataTable dt = DB.Read("MovimientosInventario", 1, "Refaccion_ID = @Refaccion_ID", "MovimientoInventario_ID DESC", DB.Param("@Refaccion_ID", refaccion_id));
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new MovimientosInventario(
			    Convert.ToInt32(dr["MovimientoInventario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					  DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Valor"]),
					  Convert.ToInt32(dr["CantidadPrev"]),
					  Convert.ToDecimal(dr["ValorPrev"]),
					  Convert.ToInt32(dr["CantidadPost"]),
					  Convert.ToDecimal(dr["ValorPost"]),
					  Convert.ToInt32(dr["CantidadPrevProm"]),
					  Convert.ToDecimal(dr["ValorPrevProm"]),
					  Convert.ToInt32(dr["CantidadPostProm"]),
					  Convert.ToDecimal(dr["ValorPostProm"]),
					  Convert.ToString(dr["Referencia"]),
					  Convert.ToDecimal(dr["CostoUnitarioProm"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static MovimientosInventario GetLastByRefaccion(int refaccion_id, int empresa_id, int estacion_id)
		{
			DataTable dt = DB.Read(
			    "MovimientosInventario",
			    1,
			    "Refaccion_ID = @Refaccion_ID AND Empresa_ID = @Empresa_ID AND Estacion_ID = @Estacion_ID",
			    "MovimientoInventario_ID DESC",
			    DB.Param("@Refaccion_ID", refaccion_id),
			    DB.Param("@Empresa_ID", empresa_id),
			    DB.Param("@Estacion_ID", estacion_id)
			);

			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new MovimientosInventario(
			    Convert.ToInt32(dr["MovimientoInventario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
					  DB.GetNullableInt32(dr["AjusteInventario_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Cantidad"]),
					  Convert.ToDecimal(dr["CostoUnitario"]),
					  Convert.ToDecimal(dr["Valor"]),
					  Convert.ToInt32(dr["CantidadPrev"]),
					  Convert.ToDecimal(dr["ValorPrev"]),
					  Convert.ToInt32(dr["CantidadPost"]),
					  Convert.ToDecimal(dr["ValorPost"]),
					  Convert.ToInt32(dr["CantidadPrevProm"]),
					  Convert.ToDecimal(dr["ValorPrevProm"]),
					  Convert.ToInt32(dr["CantidadPostProm"]),
					  Convert.ToDecimal(dr["ValorPostProm"]),
					  Convert.ToString(dr["Referencia"]),
					  Convert.ToDecimal(dr["CostoUnitarioProm"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public void Calculate()
		{
			MovimientosInventario mi = MovimientosInventario.GetLastByRefaccion(this.Refaccion_ID, this.Empresa_ID, this.Estacion_ID);
			if (mi == null)
			{
				this.ValorPrevProm = 0;
				this.ValorPrev = 0;
				this.ValorPost = this.Valor;
				this.ValorPostProm = this.Valor;
				this.CantidadPrev = 0;
				this.CantidadPrevProm = 0;
				this.CantidadPost = this.Cantidad;
				this.CantidadPostProm = this.Cantidad;
			}
			else
			{
				this.ValorPrevProm = mi.ValorPostProm;
				this.ValorPrev = mi.ValorPost;
				this.ValorPost = mi.ValorPrev + this.Valor;
				this.CantidadPrev = mi.CantidadPost;
				this.CantidadPrevProm = mi.CantidadPostProm;
				this.CantidadPost = this.Cantidad + this.CantidadPrev;
				this.CantidadPostProm = this.Cantidad + this.CantidadPrevProm;
				this.ValorPostProm = this.ValorPrevProm + this.Valor;
				if (this.CantidadPostProm == 0)
				{
					this.CostoUnitarioProm = this.ValorPostProm / 1;
				}
				else
				{
					this.CostoUnitarioProm = this.ValorPostProm / this.CantidadPostProm;
				}
			}
		}
		#endregion
	} //End Class MovimientosInventario

	public class NotasAlmacen
	{

		#region Constructors

		public NotasAlmacen()
		{
		}

		public NotasAlmacen(
		    int notaalmacen_id,
		    string usuario_id,
		    int tipomovimientoinventario_id,
		    int? ordencompra_id,
		    int? ordentrabajo_id,
		    DateTime fecha,
		    int empresa_id,
		    int estacion_id,
		    string factura)
		{
			this.NotaAlmacen_ID = notaalmacen_id;
			this.Usuario_ID = usuario_id;
			this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
			this.OrdenCompra_ID = ordencompra_id;
			this.OrdenTrabajo_ID = ordentrabajo_id;
			this.Fecha = fecha;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Factura = factura;
		}

		#endregion

		#region Properties

		private int _NotaAlmacen_ID;
		public int NotaAlmacen_ID
		{
			get { return _NotaAlmacen_ID; }
			set { _NotaAlmacen_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _TipoMovimientoInventario_ID;
		public int TipoMovimientoInventario_ID
		{
			get { return _TipoMovimientoInventario_ID; }
			set { _TipoMovimientoInventario_ID = value; }
		}

		private int? _OrdenCompra_ID;
		public int? OrdenCompra_ID
		{
			get { return _OrdenCompra_ID; }
			set { _OrdenCompra_ID = value; }
		}

		private int? _OrdenTrabajo_ID;
		public int? OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _Factura;
		public string Factura
		{
			get { return _Factura; }
			set { _Factura = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.TipoMovimientoInventario_ID == 0) throw new Exception("TipoMovimientoInventario_ID no puede ser nulo.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (String.IsNullOrEmpty(this.Factura)) throw new Exception("Factura no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Factura)) m_params.Add("Factura", this.Factura);

			int result = DB.InsertRow("NotasAlmacen", m_params);
			this.NotaAlmacen_ID = Convert.ToInt32(DB.Ident_Current("NotasAlmacen"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Factura)) m_params.Add("Factura", this.Factura);

			return DB.IdentityInsertRow("NotasAlmacen", m_params);
		} // End Create

		public static List<NotasAlmacen> Read()
		{
			List<NotasAlmacen> list = new List<NotasAlmacen>();
			DataTable dt = DB.Select("NotasAlmacen");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new NotasAlmacen(
					   Convert.ToInt32(dr["NotaAlmacen_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					   DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					   DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToString(dr["Factura"])
				    )
				);
			}

			return list;
		} // End Read

		public static NotasAlmacen Read(int notaalmacen_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("NotaAlmacen_ID", notaalmacen_id);
			DataTable dt = DB.Select("NotasAlmacen", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe NotasAlmacen con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new NotasAlmacen(
			    Convert.ToInt32(dr["NotaAlmacen_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Factura"])
				   );
		} // End Read

		public static NotasAlmacen Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("NotasAlmacen", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new NotasAlmacen(
			    Convert.ToInt32(dr["NotaAlmacen_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Factura"])
				   );
		} // End Read

		public static bool Read(
		    out NotasAlmacen notasalmacen,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("NotasAlmacen", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				notasalmacen = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			notasalmacen = new NotasAlmacen(
			    Convert.ToInt32(dr["NotaAlmacen_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
					  DB.GetNullableInt32(dr["OrdenCompra_ID"]),
					  DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToString(dr["Factura"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("NotasAlmacen");
		} // End Read

		public static DataTable ReadDataTable(int notaalmacen_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("NotaAlmacen_ID", notaalmacen_id);
			return DB.Select("NotasAlmacen", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Factura)) m_params.Add("Factura", this.Factura);

			return DB.UpdateRow("NotasAlmacen", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);

			return DB.DeleteRow("NotasAlmacen", w_params);
		} // End Delete


		#endregion
	} //End Class NotasAlmacen

	public class Opciones
	{

		public Opciones()
		{
		}

		public Opciones(int opcion_id, int menu_id, string nombre, string texto, string imagen, bool esherramienta)
		{
			this.Opcion_ID = opcion_id;
			this.Menu_ID = menu_id;
			this.Nombre = nombre;
			this.Texto = texto;
			this.Imagen = imagen;
			this.EsHerramienta = esherramienta;
		}

		private int _Opcion_ID;
		public int Opcion_ID
		{
			get { return _Opcion_ID; }
			set { _Opcion_ID = value; }
		}

		private int _Menu_ID;
		public int Menu_ID
		{
			get { return _Menu_ID; }
			set { _Menu_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Texto;
		public string Texto
		{
			get { return _Texto; }
			set { _Texto = value; }
		}

		private string _Imagen;
		public string Imagen
		{
			get { return _Imagen; }
			set { _Imagen = value; }
		}

		private bool _EsHerramienta;
		public bool EsHerramienta
		{
			get { return _EsHerramienta; }
			set { _EsHerramienta = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Menu_ID", this.Menu_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Texto", this.Texto);
			m_params.Add("Imagen", this.Imagen);
			m_params.Add("EsHerramienta", this.EsHerramienta);

			return DB.InsertRow("Opciones", m_params);
		} // End Create

		public static List<Opciones> Read()
		{
			List<Opciones> list = new List<Opciones>();
			DataTable dt = DB.Select("Opciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Opciones(Convert.ToInt32(dr["Opcion_ID"]), Convert.ToInt32(dr["Menu_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Texto"]), Convert.ToString(dr["Imagen"]), Convert.ToBoolean(dr["EsHerramienta"])));
			}

			return list;
		} // End Read

		public static List<Opciones> Read(int opcion_id)
		{
			List<Opciones> list = new List<Opciones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Opcion_ID", opcion_id);
			DataTable dt = DB.Select("Opciones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Opciones(Convert.ToInt32(dr["Opcion_ID"]), Convert.ToInt32(dr["Menu_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Texto"]), Convert.ToString(dr["Imagen"]), Convert.ToBoolean(dr["EsHerramienta"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("Menu_ID", this.Menu_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Texto", this.Texto);
			m_params.Add("Imagen", this.Imagen);
			m_params.Add("EsHerramienta", this.EsHerramienta);

			return DB.UpdateRow("Opciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Opcion_ID", this.Opcion_ID);

			return DB.DeleteRow("Opciones", w_params);
		}

	} //End Class Opciones

	public class OrdenesCompras
	{

		#region Constructors

		public OrdenesCompras()
		{
			this.Compras = new List<Compras>();
		}

		public OrdenesCompras(
		    int ordencompra_id,
		    int proveedor_id,
		    int estatusordencompra_id,
		    string usuario_id,
		    DateTime fecha,
		    string factura,
		    decimal subtotal,
		    decimal iva,
		    decimal total,
		    int empresa_id,
		    int estacion_id)
		{
			this.OrdenCompra_ID = ordencompra_id;
			this.Proveedor_ID = proveedor_id;
			this.EstatusOrdenCompra_ID = estatusordencompra_id;
			this.Usuario_ID = usuario_id;
			this.Fecha = fecha;
			this.Factura = factura;
			this.Subtotal = subtotal;
			this.IVA = iva;
			this.Total = total;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _OrdenCompra_ID;
		public int OrdenCompra_ID
		{
			get { return _OrdenCompra_ID; }
			set { _OrdenCompra_ID = value; }
		}

		private int _Proveedor_ID;
		public int Proveedor_ID
		{
			get { return _Proveedor_ID; }
			set { _Proveedor_ID = value; }
		}

		private int _EstatusOrdenCompra_ID;
		public int EstatusOrdenCompra_ID
		{
			get { return _EstatusOrdenCompra_ID; }
			set { _EstatusOrdenCompra_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Factura;
		public string Factura
		{
			get { return _Factura; }
			set { _Factura = value; }
		}

		private decimal _Subtotal;
		public decimal Subtotal
		{
			get { return _Subtotal; }
			set { _Subtotal = value; }
		}

		private decimal _IVA;
		public decimal IVA
		{
			get { return _IVA; }
			set { _IVA = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private List<Compras> _Compras;
		public List<Compras> Compras
		{
			get { return _Compras; }
			set { _Compras = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Proveedor_ID == 0) throw new Exception("Proveedor_ID no puede ser nulo.");

			if (this.EstatusOrdenCompra_ID == 0) throw new Exception("EstatusOrdenCompra_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Factura == null) throw new Exception("Factura no puede ser nulo.");

			if (this.Factura.Length > 50)
			{
				throw new Exception("Factura debe tener máximo 50 carateres.");
			}

			if (this.Subtotal == 0) throw new Exception("Subtotal no puede ser nulo.");

			if (this.IVA == 0) throw new Exception("IVA no puede ser nulo.");

			if (this.Total == 0) throw new Exception("Total no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public void LoadRelations()
		{
			this.Compras = Entities.Compras.ReadList(this.OrdenCompra_ID);
			foreach (Entities.Compras compra in this.Compras)
			{
				Entities.Refacciones refaccion = Entities.Refacciones.Read(compra.Refaccion_ID);
				compra.Refaccion_Descripcion = refaccion.Descripcion;
			}
		}

		public int Create()
		{
			this.Validate();

			Hashtable m_params = new Hashtable();
			m_params.Add("Proveedor_ID", this.Proveedor_ID);
			m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Factura", this.Factura);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			int result = DB.InsertRow("OrdenesCompras", m_params);
			this.OrdenCompra_ID = Convert.ToInt32(DB.Ident_Current("OrdenesCompras"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Proveedor_ID", this.Proveedor_ID);
			m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Factura", this.Factura);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("OrdenesCompras", m_params);
		} // End Create

		public static List<OrdenesCompras> Read()
		{
			List<OrdenesCompras> list = new List<OrdenesCompras>();
			DataTable dt = DB.Select("OrdenesCompras");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new OrdenesCompras(
					   Convert.ToInt32(dr["OrdenCompra_ID"]),
					   Convert.ToInt32(dr["Proveedor_ID"]),
					   Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Factura"]),
					   Convert.ToDecimal(dr["Subtotal"]),
					   Convert.ToDecimal(dr["IVA"]),
					   Convert.ToDecimal(dr["Total"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static OrdenesCompras Read(int ordencompra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", ordencompra_id);
			DataTable dt = DB.Select("OrdenesCompras", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe OrdenesCompras con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesCompras(
			    Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Proveedor_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Factura"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static OrdenesCompras Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesCompras", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesCompras(
			    Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Proveedor_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Factura"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out OrdenesCompras ordenescompras,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesCompras", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				ordenescompras = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			ordenescompras = new OrdenesCompras(
			    Convert.ToInt32(dr["OrdenCompra_ID"]),
					  Convert.ToInt32(dr["Proveedor_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Factura"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("OrdenesCompras");
		} // End Read

		public static DataTable ReadDataTable(int ordencompra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", ordencompra_id);
			return DB.Select("OrdenesCompras", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Proveedor_ID", this.Proveedor_ID);
			m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Factura", this.Factura);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("OrdenesCompras", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);

			return DB.DeleteRow("OrdenesCompras", w_params);
		} // End Delete


		#endregion
	} //End Class OrdenesCompras

	public class OrdenesComprasCanceladas
	{

		public OrdenesComprasCanceladas()
		{
		}

		public OrdenesComprasCanceladas(int ordencompra_id, string usuario_id, DateTime fecha, string comentarios)
		{
			this.OrdenCompra_ID = ordencompra_id;
			this.Usuario_ID = usuario_id;
			this.Fecha = fecha;
			this.Comentarios = comentarios;
		}

		private int _OrdenCompra_ID;
		public int OrdenCompra_ID
		{
			get { return _OrdenCompra_ID; }
			set { _OrdenCompra_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("OrdenesComprasCanceladas", m_params);
		} // End Create

		public static List<OrdenesComprasCanceladas> Read()
		{
			List<OrdenesComprasCanceladas> list = new List<OrdenesComprasCanceladas>();
			DataTable dt = DB.Select("OrdenesComprasCanceladas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new OrdenesComprasCanceladas(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static OrdenesComprasCanceladas Read(int ordencompra_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", ordencompra_id);
			DataTable dt = DB.Select("OrdenesComprasCanceladas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe OrdenesComprasCanceladas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesComprasCanceladas(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("OrdenesComprasCanceladas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);

			return DB.DeleteRow("OrdenesComprasCanceladas", w_params);
		} // End Delete

	} //End Class OrdenesComprasCanceladas

	public class OrdenesServicios
	{

		public OrdenesServicios()
		{
			this.OrdenesServiciosRefacciones = new List<OrdenesServiciosRefacciones>();
		}

		public OrdenesServicios(
		  int ordenservicio_id,
		  int ordentrabajo_id,
		  int serviciomantenimiento_id,
		  int mecanico_id,
		  int estatusordenservicio_id,
		  DateTime? fecha,
		  int cantidad,
		  decimal precio,
		  decimal total
		  )
		{
			this.OrdenServicio_ID = ordenservicio_id;
			this.OrdenTrabajo_ID = ordentrabajo_id;
			this.ServicioMantenimiento_ID = serviciomantenimiento_id;
			this.Mecanico_ID = mecanico_id;
			this.EstatusOrdenServicio_ID = estatusordenservicio_id;
			this.Fecha = fecha;
			this.Cantidad = cantidad;
			this.Precio = precio;
			this.Total = total;

			this.LoadRelations();
		}

		private void LoadRelations()
		{
			this.ServicioMantenimiento_Descripcion =
			    Entities.ServiciosMantenimientos.Read(this.ServicioMantenimiento_ID).Nombre;

			Entities.Mecanicos mecanico =
			    Entities.Mecanicos.Read(this.Mecanico_ID);

			this.Mecanico_Nombre = mecanico.Apellidos + " " + mecanico.Nombres;

			this.OrdenesServiciosRefacciones =
			    Entities.OrdenesServiciosRefacciones.Read(DB.Param("OrdenServicio_ID", this.OrdenServicio_ID));
		}

		private int _OrdenServicio_ID;
		public int OrdenServicio_ID
		{
			get { return _OrdenServicio_ID; }
			set { _OrdenServicio_ID = value; }
		}

		private int _OrdenTrabajo_ID;
		public int OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		private int _ServicioMantenimiento_ID;
		public int ServicioMantenimiento_ID
		{
			get { return _ServicioMantenimiento_ID; }
			set { _ServicioMantenimiento_ID = value; }
		}

		private int _Mecanico_ID;
		public int Mecanico_ID
		{
			get { return _Mecanico_ID; }
			set { _Mecanico_ID = value; }
		}

		private int _EstatusOrdenServicio_ID;
		public int EstatusOrdenServicio_ID
		{
			get { return _EstatusOrdenServicio_ID; }
			set { _EstatusOrdenServicio_ID = value; }
		}

		private DateTime? _Fecha;
		public DateTime? Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		private decimal _Precio;
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private string _ServicioMantenimiento_Descripcion;

		public string ServicioMantenimiento_Descripcion
		{
			get { return _ServicioMantenimiento_Descripcion; }
			set { _ServicioMantenimiento_Descripcion = value; }
		}

		private string _Mecanico_Nombre;

		public string Mecanico_Nombre
		{
			get { return _Mecanico_Nombre; }
			set { _Mecanico_Nombre = value; }
		}

		private List<OrdenesServiciosRefacciones> _OrdenesServiciosRefacciones;

		public List<OrdenesServiciosRefacciones> OrdenesServiciosRefacciones
		{
			get { return _OrdenesServiciosRefacciones; }
			set { _OrdenesServiciosRefacciones = value; }
		}


		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("Mecanico_ID", this.Mecanico_ID);
			m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Total", this.Total);

			int result = DB.InsertRow("OrdenesServicios", m_params);
			this.OrdenServicio_ID = Convert.ToInt32(DB.Ident_Current("OrdenesServicios"));
			return result;
		} // End Create

		public static List<OrdenesServicios> Read()
		{
			List<OrdenesServicios> list = new List<OrdenesServicios>();
			DataTable dt = DB.Select("OrdenesServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new OrdenesServicios(Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["Total"])));
			}

			return list;
		} // End Read

		public static OrdenesServicios Read(int ordenservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicio_ID", ordenservicio_id);
			DataTable dt = DB.Select("OrdenesServicios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe OrdenesServicios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesServicios(Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["Total"]));
		} // End Read

		public static List<OrdenesServicios> Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesServicios", args);
			List<OrdenesServicios> list = new List<OrdenesServicios>();
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new OrdenesServicios(
					   Convert.ToInt32(dr["OrdenServicio_ID"]),
					   Convert.ToInt32(dr["OrdenTrabajo_ID"]),
					   Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
					   Convert.ToInt32(dr["Mecanico_ID"]),
					   Convert.ToInt32(dr["EstatusOrdenServicio_ID"]),
					   DB.GetNullableDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["Cantidad"]),
					   Convert.ToDecimal(dr["Precio"]),
					   Convert.ToDecimal(dr["Total"])
					   )
				);
			}

			return list;
		} // End Read

		public static bool Read(out OrdenesServicios ordenesservicios, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesServicios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				ordenesservicios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			ordenesservicios = new OrdenesServicios(Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["Total"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("OrdenesServicios");
		} // End Read

		public static DataTable ReadDataTable(int ordenservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicio_ID", ordenservicio_id);
			return DB.Select("OrdenesServicios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
			m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("Mecanico_ID", this.Mecanico_ID);
			m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Total", this.Total);

			return DB.UpdateRow("OrdenesServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);

			return DB.DeleteRow("OrdenesServicios", w_params);
		} // End Delete

	} //End Class OrdenesServicios

	public class OrdenesServiciosRefacciones
	{

		public OrdenesServiciosRefacciones()
		{
		}

		public OrdenesServiciosRefacciones(int ordenserviciorefaccion_id, int ordenservicio_id, int refaccion_id, int cantidad, decimal preciounitario, decimal total, decimal costounitario, int? refsurtidas)
		{
			this.OrdenServicioRefaccion_ID = ordenserviciorefaccion_id;
			this.OrdenServicio_ID = ordenservicio_id;
			this.Refaccion_ID = refaccion_id;
			this.Cantidad = cantidad;
			this.PrecioUnitario = preciounitario;
			this.Total = total;
			this.CostoUnitario = costounitario;
			this.RefSurtidas = refsurtidas;

			this.Refaccion_Descripcion = Entities.Refacciones.Read(this.Refaccion_ID).Descripcion;
		}

		private int _OrdenServicioRefaccion_ID;
		public int OrdenServicioRefaccion_ID
		{
			get { return _OrdenServicioRefaccion_ID; }
			set { _OrdenServicioRefaccion_ID = value; }
		}

		private int _OrdenServicio_ID;
		public int OrdenServicio_ID
		{
			get { return _OrdenServicio_ID; }
			set { _OrdenServicio_ID = value; }
		}

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		private decimal _PrecioUnitario;
		public decimal PrecioUnitario
		{
			get { return _PrecioUnitario; }
			set { _PrecioUnitario = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private decimal _CostoUnitario;
		public decimal CostoUnitario
		{
			get { return _CostoUnitario; }
			set { _CostoUnitario = value; }
		}

		private int? _RefSurtidas;
		public int? RefSurtidas
		{
			get { return _RefSurtidas; }
			set { _RefSurtidas = value; }
		}

		private string _Refaccion_Descripcion;

		public string Refaccion_Descripcion
		{
			get { return _Refaccion_Descripcion; }
			set { _Refaccion_Descripcion = value; }
		}


		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("PrecioUnitario", this.PrecioUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			if (!AppHelper.IsNullOrEmpty(this.RefSurtidas)) m_params.Add("RefSurtidas", this.RefSurtidas);

			int result = DB.InsertRow("OrdenesServiciosRefacciones", m_params);
			this.OrdenServicioRefaccion_ID = Convert.ToInt32(DB.Ident_Current("OrdenesServiciosRefacciones"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenServicioRefaccion_ID", this.OrdenServicioRefaccion_ID);
			m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("PrecioUnitario", this.PrecioUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			if (!AppHelper.IsNullOrEmpty(this.RefSurtidas)) m_params.Add("RefSurtidas", this.RefSurtidas);

			return DB.IdentityInsertRow("OrdenesServiciosRefacciones", m_params);
		} // End Create

		public static List<OrdenesServiciosRefacciones> Read()
		{
			List<OrdenesServiciosRefacciones> list = new List<OrdenesServiciosRefacciones>();
			DataTable dt = DB.Select("OrdenesServiciosRefacciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"])));
			}

			return list;
		} // End Read

		public static OrdenesServiciosRefacciones Read(int ordenserviciorefaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicioRefaccion_ID", ordenserviciorefaccion_id);
			DataTable dt = DB.Select("OrdenesServiciosRefacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe OrdenesServiciosRefacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"]));
		} // End Read

		public static List<OrdenesServiciosRefacciones> Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesServiciosRefacciones", args);
			List<OrdenesServiciosRefacciones> list = new List<OrdenesServiciosRefacciones>();
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"])));
			}

			return list;
		} // End Read

		public static bool Read(out OrdenesServiciosRefacciones ordenesserviciosrefacciones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesServiciosRefacciones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				ordenesserviciosrefacciones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			ordenesserviciosrefacciones = new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("OrdenesServiciosRefacciones");
		} // End Read

		public static DataTable ReadDataTable(int ordenserviciorefaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicioRefaccion_ID", ordenserviciorefaccion_id);
			return DB.Select("OrdenesServiciosRefacciones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicioRefaccion_ID", this.OrdenServicioRefaccion_ID);
			m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("Cantidad", this.Cantidad);
			m_params.Add("PrecioUnitario", this.PrecioUnitario);
			m_params.Add("Total", this.Total);
			m_params.Add("CostoUnitario", this.CostoUnitario);
			if (!AppHelper.IsNullOrEmpty(this.RefSurtidas)) m_params.Add("RefSurtidas", this.RefSurtidas);

			return DB.UpdateRow("OrdenesServiciosRefacciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenServicioRefaccion_ID", this.OrdenServicioRefaccion_ID);

			return DB.DeleteRow("OrdenesServiciosRefacciones", w_params);
		} // End Delete

	} //End Class OrdenesServiciosRefacciones

	public class OrdenesTrabajos
	{

		#region Constructors

		public OrdenesTrabajos()
		{
			this.OrdenesServicios = new List<OrdenesServicios>();
		}

		public OrdenesTrabajos(
		    int ordentrabajo_id,
		    int empresa_id,
		    int tipomantenimiento_id,
		    int clientefacturar_id,
		    int unidad_id,
		    int estatusordentrabajo_id,
		    int? caja_id,
		    string usuario_id,
		    int? factura_id,
		    string usuariofacturacion_id,
		    string codigobarras,
		    decimal subtotal,
		    decimal iva,
		    decimal total,
		    DateTime fechaalta,
		    DateTime? fechaterminacion,
		    DateTime? fechapago,
		    int numeroeconomico,
		    DateTime? fechainicioreparacion,
		    decimal manoobra,
		    decimal ivamanoobra,
		    decimal refacciones,
		    decimal ivarefacciones,
		    DateTime? fechafacturacion,
		    int? kilometraje,
		    string comentarios,
		    decimal costorefacciones,
		    decimal costomanoobra,
		    bool cargoaconductor,
		    string cb,
		    bool cb_activo,
		    int estacion_id)
		{
			this.OrdenTrabajo_ID = ordentrabajo_id;
			this.Empresa_ID = empresa_id;
			this.TipoMantenimiento_ID = tipomantenimiento_id;
			this.ClienteFacturar_ID = clientefacturar_id;
			this.Unidad_ID = unidad_id;
			this.EstatusOrdenTrabajo_ID = estatusordentrabajo_id;
			this.Caja_ID = caja_id;
			this.Usuario_ID = usuario_id;
			this.Factura_ID = factura_id;
			this.UsuarioFacturacion_ID = usuariofacturacion_id;
			this.CodigoBarras = codigobarras;
			this.Subtotal = subtotal;
			this.IVA = iva;
			this.Total = total;
			this.FechaAlta = fechaalta;
			this.FechaTerminacion = fechaterminacion;
			this.FechaPago = fechapago;
			this.NumeroEconomico = numeroeconomico;
			this.FechaInicioReparacion = fechainicioreparacion;
			this.ManoObra = manoobra;
			this.IVAManoObra = ivamanoobra;
			this.Refacciones = refacciones;
			this.IVARefacciones = ivarefacciones;
			this.FechaFacturacion = fechafacturacion;
			this.Kilometraje = kilometraje;
			this.Comentarios = comentarios;
			this.CostoRefacciones = costorefacciones;
			this.CostoManoObra = costomanoobra;
			this.CargoAConductor = cargoaconductor;
			this.CB = cb;
			this.CB_Activo = cb_activo;
			this.Estacion_ID = estacion_id;
			this.LoadRelations();
		}

		private void LoadRelations()
		{
			this.Cliente_Nombre = Entities.Empresas.Read(this.ClienteFacturar_ID).RazonSocial;
			this.OrdenesServicios = Entities.OrdenesServicios.Read(DB.Param("OrdenTrabajo_ID", this.OrdenTrabajo_ID));
		}

		#endregion

		#region Properties

		private int _OrdenTrabajo_ID;
		public int OrdenTrabajo_ID
		{
			get { return _OrdenTrabajo_ID; }
			set { _OrdenTrabajo_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _TipoMantenimiento_ID;
		public int TipoMantenimiento_ID
		{
			get { return _TipoMantenimiento_ID; }
			set { _TipoMantenimiento_ID = value; }
		}

		private int _ClienteFacturar_ID;
		public int ClienteFacturar_ID
		{
			get { return _ClienteFacturar_ID; }
			set { _ClienteFacturar_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int _EstatusOrdenTrabajo_ID;
		public int EstatusOrdenTrabajo_ID
		{
			get { return _EstatusOrdenTrabajo_ID; }
			set { _EstatusOrdenTrabajo_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _Factura_ID;
		public int? Factura_ID
		{
			get { return _Factura_ID; }
			set { _Factura_ID = value; }
		}

		private string _UsuarioFacturacion_ID;
		public string UsuarioFacturacion_ID
		{
			get { return _UsuarioFacturacion_ID; }
			set { _UsuarioFacturacion_ID = value; }
		}

		private string _CodigoBarras;
		public string CodigoBarras
		{
			get { return _CodigoBarras; }
			set { _CodigoBarras = value; }
		}

		private decimal _Subtotal;
		public decimal Subtotal
		{
			get { return _Subtotal; }
			set { _Subtotal = value; }
		}

		private decimal _IVA;
		public decimal IVA
		{
			get { return _IVA; }
			set { _IVA = value; }
		}

		private decimal _Total;
		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		private DateTime _FechaAlta;
		public DateTime FechaAlta
		{
			get { return _FechaAlta; }
			set { _FechaAlta = value; }
		}

		private DateTime? _FechaTerminacion;
		public DateTime? FechaTerminacion
		{
			get { return _FechaTerminacion; }
			set { _FechaTerminacion = value; }
		}

		private DateTime? _FechaPago;
		public DateTime? FechaPago
		{
			get { return _FechaPago; }
			set { _FechaPago = value; }
		}

		private int _NumeroEconomico;
		public int NumeroEconomico
		{
			get { return _NumeroEconomico; }
			set { _NumeroEconomico = value; }
		}

		private DateTime? _FechaInicioReparacion;
		public DateTime? FechaInicioReparacion
		{
			get { return _FechaInicioReparacion; }
			set { _FechaInicioReparacion = value; }
		}

		private decimal _ManoObra;
		public decimal ManoObra
		{
			get { return _ManoObra; }
			set { _ManoObra = value; }
		}

		private decimal _IVAManoObra;
		public decimal IVAManoObra
		{
			get { return _IVAManoObra; }
			set { _IVAManoObra = value; }
		}

		private decimal _Refacciones;
		public decimal Refacciones
		{
			get { return _Refacciones; }
			set { _Refacciones = value; }
		}

		private decimal _IVARefacciones;
		public decimal IVARefacciones
		{
			get { return _IVARefacciones; }
			set { _IVARefacciones = value; }
		}

		private DateTime? _FechaFacturacion;
		public DateTime? FechaFacturacion
		{
			get { return _FechaFacturacion; }
			set { _FechaFacturacion = value; }
		}

		private int? _Kilometraje;
		public int? Kilometraje
		{
			get { return _Kilometraje; }
			set { _Kilometraje = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private decimal _CostoRefacciones;
		public decimal CostoRefacciones
		{
			get { return _CostoRefacciones; }
			set { _CostoRefacciones = value; }
		}

		private decimal _CostoManoObra;
		public decimal CostoManoObra
		{
			get { return _CostoManoObra; }
			set { _CostoManoObra = value; }
		}

		private bool _CargoAConductor;
		public bool CargoAConductor
		{
			get { return _CargoAConductor; }
			set { _CargoAConductor = value; }
		}

		private string _CB;
		public string CB
		{
			get { return _CB; }
			set { _CB = value; }
		}

		private bool _CB_Activo;
		public bool CB_Activo
		{
			get { return _CB_Activo; }
			set { _CB_Activo = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private string _Cliente_Nombre;

		public string Cliente_Nombre
		{
			get { return _Cliente_Nombre; }
			set { _Cliente_Nombre = value; }
		}

		private string _Conductor_Nombre;

		public string Conductor_Nombre
		{
			get { return _Conductor_Nombre; }
			set { _Conductor_Nombre = value; }
		}

		private string _Unidad_Placas;

		public string Unidad_Placas
		{
			get { return _Unidad_Placas; }
			set { _Unidad_Placas = value; }
		}


		private List<OrdenesServicios> _OrdenesServicios;

		public List<OrdenesServicios> OrdenesServicios
		{
			get { return _OrdenesServicios; }
			set { _OrdenesServicios = value; }
		}

		private void SetCodigoBarras()
		{
			this.CodigoBarras = String.Format("{0:yyMMddHHmm}{1}{2}{3}", DB.GetDate(),
			    this.ClienteFacturar_ID, this.Unidad_ID,
				   (Convert.ToInt32(DB.Ident_Current("OrdenesTrabajos")) + 1));
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.TipoMantenimiento_ID == 0) throw new Exception("TipoMantenimiento_ID no puede ser nulo.");

			if (this.ClienteFacturar_ID == 0) throw new Exception("ClienteFacturar_ID no puede ser nulo.");

			if (this.Unidad_ID == 0) throw new Exception("Unidad_ID no puede ser nulo.");

			if (this.EstatusOrdenTrabajo_ID == 0) throw new Exception("EstatusOrdenTrabajo_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.UsuarioFacturacion_ID.Length > 30)
			{
				throw new Exception("UsuarioFacturacion_ID debe tener máximo 30 carateres.");
			}

			if (this.CodigoBarras == null) throw new Exception("CodigoBarras no puede ser nulo.");

			if (this.CodigoBarras.Length > 50)
			{
				throw new Exception("CodigoBarras debe tener máximo 50 carateres.");
			}

			if (this.Subtotal == 0) throw new Exception("Subtotal no puede ser nulo.");

			if (this.IVA == 0) throw new Exception("IVA no puede ser nulo.");

			if (this.Total == 0) throw new Exception("Total no puede ser nulo.");

			if (this.FechaAlta == null) throw new Exception("FechaAlta no puede ser nulo.");

			if (this.Comentarios.Length > 250)
			{
				throw new Exception("Comentarios debe tener máximo 250 carateres.");
			}

			if (this.CB == null) throw new Exception("CB no puede ser nulo.");

			if (this.CB.Length > 20)
			{
				throw new Exception("CB debe tener máximo 20 carateres.");
			}

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			SetCodigoBarras();

			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
			m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
			if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("FechaAlta", this.FechaAlta);
			if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
			if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
			m_params.Add("ManoObra", this.ManoObra);
			m_params.Add("IVAManoObra", this.IVAManoObra);
			m_params.Add("Refacciones", this.Refacciones);
			m_params.Add("IVARefacciones", this.IVARefacciones);
			if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("CostoRefacciones", this.CostoRefacciones);
			m_params.Add("CostoManoObra", this.CostoManoObra);
			m_params.Add("CargoAConductor", this.CargoAConductor);
			m_params.Add("CB", this.CB);
			m_params.Add("CB_Activo", this.CB_Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			int result = DB.InsertRow("OrdenesTrabajos", m_params);
			this.OrdenTrabajo_ID = Convert.ToInt32(DB.Ident_Current("OrdenesTrabajos"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
			m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
			if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("FechaAlta", this.FechaAlta);
			if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
			if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
			m_params.Add("ManoObra", this.ManoObra);
			m_params.Add("IVAManoObra", this.IVAManoObra);
			m_params.Add("Refacciones", this.Refacciones);
			m_params.Add("IVARefacciones", this.IVARefacciones);
			if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("CostoRefacciones", this.CostoRefacciones);
			m_params.Add("CostoManoObra", this.CostoManoObra);
			m_params.Add("CargoAConductor", this.CargoAConductor);
			m_params.Add("CB", this.CB);
			m_params.Add("CB_Activo", this.CB_Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.IdentityInsertRow("OrdenesTrabajos", m_params);
		} // End Create

		public static List<OrdenesTrabajos> Read()
		{
			List<OrdenesTrabajos> list = new List<OrdenesTrabajos>();
			DataTable dt = DB.Select("OrdenesTrabajos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new OrdenesTrabajos(
					   Convert.ToInt32(dr["OrdenTrabajo_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["TipoMantenimiento_ID"]),
					   Convert.ToInt32(dr["ClienteFacturar_ID"]),
					   Convert.ToInt32(dr["Unidad_ID"]),
					   Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
					   DB.GetNullableInt32(dr["Caja_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Factura_ID"]),
					   Convert.ToString(dr["UsuarioFacturacion_ID"]),
					   Convert.ToString(dr["CodigoBarras"]),
					   Convert.ToDecimal(dr["Subtotal"]),
					   Convert.ToDecimal(dr["IVA"]),
					   Convert.ToDecimal(dr["Total"]),
					   Convert.ToDateTime(dr["FechaAlta"]),
					   DB.GetNullableDateTime(dr["FechaTerminacion"]),
					   DB.GetNullableDateTime(dr["FechaPago"]),
					   Convert.ToInt32(dr["NumeroEconomico"]),
					   DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
					   Convert.ToDecimal(dr["ManoObra"]),
					   Convert.ToDecimal(dr["IVAManoObra"]),
					   Convert.ToDecimal(dr["Refacciones"]),
					   Convert.ToDecimal(dr["IVARefacciones"]),
					   DB.GetNullableDateTime(dr["FechaFacturacion"]),
					   DB.GetNullableInt32(dr["Kilometraje"]),
					   Convert.ToString(dr["Comentarios"]),
					   Convert.ToDecimal(dr["CostoRefacciones"]),
					   Convert.ToDecimal(dr["CostoManoObra"]),
					   Convert.ToBoolean(dr["CargoAConductor"]),
					   Convert.ToString(dr["CB"]),
					   Convert.ToBoolean(dr["CB_Activo"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static OrdenesTrabajos Read(int ordentrabajo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
			DataTable dt = DB.Select("OrdenesTrabajos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe OrdenesTrabajos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesTrabajos(
			    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["TipoMantenimiento_ID"]),
					  Convert.ToInt32(dr["ClienteFacturar_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Factura_ID"]),
					  Convert.ToString(dr["UsuarioFacturacion_ID"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["FechaAlta"]),
					  DB.GetNullableDateTime(dr["FechaTerminacion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
					  Convert.ToDecimal(dr["ManoObra"]),
					  Convert.ToDecimal(dr["IVAManoObra"]),
					  Convert.ToDecimal(dr["Refacciones"]),
					  Convert.ToDecimal(dr["IVARefacciones"]),
					  DB.GetNullableDateTime(dr["FechaFacturacion"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDecimal(dr["CostoRefacciones"]),
					  Convert.ToDecimal(dr["CostoManoObra"]),
					  Convert.ToBoolean(dr["CargoAConductor"]),
					  Convert.ToString(dr["CB"]),
					  Convert.ToBoolean(dr["CB_Activo"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static OrdenesTrabajos Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesTrabajos", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new OrdenesTrabajos(
			    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["TipoMantenimiento_ID"]),
					  Convert.ToInt32(dr["ClienteFacturar_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Factura_ID"]),
					  Convert.ToString(dr["UsuarioFacturacion_ID"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["FechaAlta"]),
					  DB.GetNullableDateTime(dr["FechaTerminacion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
					  Convert.ToDecimal(dr["ManoObra"]),
					  Convert.ToDecimal(dr["IVAManoObra"]),
					  Convert.ToDecimal(dr["Refacciones"]),
					  Convert.ToDecimal(dr["IVARefacciones"]),
					  DB.GetNullableDateTime(dr["FechaFacturacion"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDecimal(dr["CostoRefacciones"]),
					  Convert.ToDecimal(dr["CostoManoObra"]),
					  Convert.ToBoolean(dr["CargoAConductor"]),
					  Convert.ToString(dr["CB"]),
					  Convert.ToBoolean(dr["CB_Activo"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out OrdenesTrabajos ordenestrabajos,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("OrdenesTrabajos", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				ordenestrabajos = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			ordenestrabajos = new OrdenesTrabajos(
			    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["TipoMantenimiento_ID"]),
					  Convert.ToInt32(dr["ClienteFacturar_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Factura_ID"]),
					  Convert.ToString(dr["UsuarioFacturacion_ID"]),
					  Convert.ToString(dr["CodigoBarras"]),
					  Convert.ToDecimal(dr["Subtotal"]),
					  Convert.ToDecimal(dr["IVA"]),
					  Convert.ToDecimal(dr["Total"]),
					  Convert.ToDateTime(dr["FechaAlta"]),
					  DB.GetNullableDateTime(dr["FechaTerminacion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
					  Convert.ToDecimal(dr["ManoObra"]),
					  Convert.ToDecimal(dr["IVAManoObra"]),
					  Convert.ToDecimal(dr["Refacciones"]),
					  Convert.ToDecimal(dr["IVARefacciones"]),
					  DB.GetNullableDateTime(dr["FechaFacturacion"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDecimal(dr["CostoRefacciones"]),
					  Convert.ToDecimal(dr["CostoManoObra"]),
					  Convert.ToBoolean(dr["CargoAConductor"]),
					  Convert.ToString(dr["CB"]),
					  Convert.ToBoolean(dr["CB_Activo"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("OrdenesTrabajos");
		} // End Read

		public static DataTable ReadDataTable(int ordentrabajo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
			return DB.Select("OrdenesTrabajos", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
			m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
			if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
			m_params.Add("CodigoBarras", this.CodigoBarras);
			m_params.Add("Subtotal", this.Subtotal);
			m_params.Add("IVA", this.IVA);
			m_params.Add("Total", this.Total);
			m_params.Add("FechaAlta", this.FechaAlta);
			if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
			if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
			m_params.Add("ManoObra", this.ManoObra);
			m_params.Add("IVAManoObra", this.IVAManoObra);
			m_params.Add("Refacciones", this.Refacciones);
			m_params.Add("IVARefacciones", this.IVARefacciones);
			if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("CostoRefacciones", this.CostoRefacciones);
			m_params.Add("CostoManoObra", this.CostoManoObra);
			m_params.Add("CargoAConductor", this.CargoAConductor);
			m_params.Add("CB", this.CB);
			m_params.Add("CB_Activo", this.CB_Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("OrdenesTrabajos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

			return DB.DeleteRow("OrdenesTrabajos", w_params);
		} // End Delete


		#endregion


		#region ExtraMethods

		public void CalcularTotales()
		{
			this.ManoObra = 0;
			this.Refacciones = 0;
			this.Subtotal = 0;
			this.IVA = 0;
			this.Total = 0;
			this.IVAManoObra = 0;
			this.IVARefacciones = 0;

			foreach (Entities.OrdenesServicios os in this.OrdenesServicios)
			{
				this.ManoObra += os.Total;

				foreach (Entities.OrdenesServiciosRefacciones osr in os.OrdenesServiciosRefacciones)
				{
					this.Refacciones += osr.Total;
				}
			}

			this.Subtotal = this.ManoObra + this.Refacciones;
			this.IVA = AppHelper.CalcularIVA(this.Subtotal);
			this.Total = this.Subtotal + this.IVA;
			this.IVARefacciones = AppHelper.CalcularIVA(this.Refacciones);
			this.IVAManoObra = AppHelper.CalcularIVA(this.ManoObra);
		}

		#endregion

	} //End Class OrdenesTrabajos


	public class Periodos
	{

		public Periodos()
		{
		}

		public Periodos(int periodo_id, string nombre)
		{
			this.Periodo_ID = periodo_id;
			this.Nombre = nombre;
		}

		private int _Periodo_ID;
		public int Periodo_ID
		{
			get { return _Periodo_ID; }
			set { _Periodo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Periodos", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Periodo_ID", this.Periodo_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("Periodos", m_params);
		} // End Create

		public static List<Periodos> Read()
		{
			List<Periodos> list = new List<Periodos>();
			DataTable dt = DB.Select("Periodos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Periodos(Convert.ToInt32(dr["Periodo_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static Periodos Read(int periodo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Periodo_ID", periodo_id);
			DataTable dt = DB.Select("Periodos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Periodos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Periodos(Convert.ToInt32(dr["Periodo_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static Periodos Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Periodos", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Periodos(Convert.ToInt32(dr["Periodo_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static bool Read(out Periodos periodos, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Periodos", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				periodos = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			periodos = new Periodos(Convert.ToInt32(dr["Periodo_ID"]), Convert.ToString(dr["Nombre"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Periodos");
		} // End Read

		public static DataTable ReadDataTable(int periodo_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Periodo_ID", periodo_id);
			return DB.Select("Periodos", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Periodo_ID", this.Periodo_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Periodos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Periodo_ID", this.Periodo_ID);

			return DB.DeleteRow("Periodos", w_params);
		} // End Delete

	} //End Class Periodos


	public class PermisosGruposUsuarios
	{

		#region Constructors

		public PermisosGruposUsuarios()
		{
		}

		public PermisosGruposUsuarios(
			int grupousuario_id,
			int opcion_id,
			bool espermitido)
		{
			this.GrupoUsuario_ID = grupousuario_id;
			this.Opcion_ID = opcion_id;
			this.EsPermitido = espermitido;
		}

		#endregion

		#region Properties

		private int _GrupoUsuario_ID;
		public int GrupoUsuario_ID
		{
			get { return _GrupoUsuario_ID; }
			set { _GrupoUsuario_ID = value; }
		}

		private int _Opcion_ID;
		public int Opcion_ID
		{
			get { return _Opcion_ID; }
			set { _Opcion_ID = value; }
		}

		private bool _EsPermitido;
		public bool EsPermitido
		{
			get { return _EsPermitido; }
			set { _EsPermitido = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.GrupoUsuario_ID == 0) throw new Exception("GrupoUsuario_ID no puede ser nulo.");

			if (this.Opcion_ID == 0) throw new Exception("Opcion_ID no puede ser nulo.");

		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("GrupoUsuario_ID", this.GrupoUsuario_ID);
			m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("EsPermitido", this.EsPermitido);

			return DB.InsertRow("PermisosGruposUsuarios", m_params);
		} // End Create

		public static List<PermisosGruposUsuarios> Read()
		{
			List<PermisosGruposUsuarios> list = new List<PermisosGruposUsuarios>();
			DataTable dt = DB.Select("PermisosGruposUsuarios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
					new PermisosGruposUsuarios(
						Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToInt32(dr["Opcion_ID"]),
						Convert.ToBoolean(dr["EsPermitido"])
					)
				);
			}

			return list;
		} // End Read

		public static PermisosGruposUsuarios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PermisosGruposUsuarios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new PermisosGruposUsuarios(
				Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToInt32(dr["Opcion_ID"]),
						Convert.ToBoolean(dr["EsPermitido"])
					);
		} // End Read

		public static bool Read(
			out PermisosGruposUsuarios permisosgruposusuarios,
			int top,
			string filter,
			string sort,
			params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PermisosGruposUsuarios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				permisosgruposusuarios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			permisosgruposusuarios = new PermisosGruposUsuarios(
				Convert.ToInt32(dr["GrupoUsuario_ID"]),
						Convert.ToInt32(dr["Opcion_ID"]),
						Convert.ToBoolean(dr["EsPermitido"])
					);
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("PermisosGruposUsuarios");
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("GrupoUsuario_ID", this.GrupoUsuario_ID);
			m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("EsPermitido", this.EsPermitido);

			return DB.UpdateRow("PermisosGruposUsuarios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();

			return DB.DeleteRow("PermisosGruposUsuarios", w_params);
		} // End Delete


		#endregion
	} //End Class PermisosGruposUsuarios


	public class PermisosUsuarios
	{

		public PermisosUsuarios()
		{
		}

		public PermisosUsuarios(string usuario_id, int opcion_id, bool espermitido)
		{
			this.Usuario_ID = usuario_id;
			this.Opcion_ID = opcion_id;
			this.EsPermitido = espermitido;
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Opcion_ID;
		public int Opcion_ID
		{
			get { return _Opcion_ID; }
			set { _Opcion_ID = value; }
		}

		private bool _EsPermitido;
		public bool EsPermitido
		{
			get { return _EsPermitido; }
			set { _EsPermitido = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("EsPermitido", this.EsPermitido);

			return DB.InsertRow("PermisosUsuarios", m_params);
		} // End Create

		public static List<PermisosUsuarios> Read()
		{
			List<PermisosUsuarios> list = new List<PermisosUsuarios>();
			DataTable dt = DB.Select("PermisosUsuarios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"])));
			}

			return list;
		} // End Read

		public static List<PermisosUsuarios> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<PermisosUsuarios> list = new List<PermisosUsuarios>();
			DataTable dt = DB.Read("PermisosUsuarios", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"])));
			}

			return list;
		} // End Read

		public static PermisosUsuarios Read(string usuario_id, int opcion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", usuario_id);
			w_params.Add("Opcion_ID", opcion_id);
			DataTable dt = DB.Select("PermisosUsuarios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe PermisosUsuarios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"]));
		} // End Read

		public static PermisosUsuarios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PermisosUsuarios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"]));
		} // End Read

		public static bool Read(out PermisosUsuarios permisosusuarios, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PermisosUsuarios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				permisosusuarios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			permisosusuarios = new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("PermisosUsuarios");
		} // End Read

		public static DataTable ReadDataTable(string usuario_id, int opcion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", usuario_id);
			w_params.Add("Opcion_ID", opcion_id);
			return DB.Select("PermisosUsuarios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", this.Usuario_ID);
			w_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("EsPermitido", this.EsPermitido);

			return DB.UpdateRow("PermisosUsuarios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", this.Usuario_ID);
			w_params.Add("Opcion_ID", this.Opcion_ID);

			return DB.DeleteRow("PermisosUsuarios", w_params);
		} // End Delete

	} //End Class PermisosUsuarios

	public class PlanesDeRenta
	{
		#region Constructors
		public PlanesDeRenta()
		{
		}

		public PlanesDeRenta(int planderenta_id, int modelounidad_id, string usuario_id, int diasdecobro_id, string descripcion, decimal rentabase, decimal? fondoresidual, DateTime fecha, bool activo, int estacion_id, int? referencia_id)
		{
			this.PlanDeRenta_ID = planderenta_id;
			this.ModeloUnidad_ID = modelounidad_id;
			this.Usuario_ID = usuario_id;
			this.DiasDeCobro_ID = diasdecobro_id;
			this.Descripcion = descripcion;
			this.RentaBase = rentabase;
			this.FondoResidual = fondoresidual;
			this.Fecha = fecha;
			this.Activo = activo;
			this.Estacion_ID = estacion_id;
			this.Referencia_ID = referencia_id;
		}
		#endregion


		#region Properties

		private int _PlanDeRenta_ID;
		public int PlanDeRenta_ID
		{
			get { return _PlanDeRenta_ID; }
			set { _PlanDeRenta_ID = value; }
		}

		private int _ModeloUnidad_ID;
		public int ModeloUnidad_ID
		{
			get { return _ModeloUnidad_ID; }
			set { _ModeloUnidad_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _DiasDeCobro_ID;
		public int DiasDeCobro_ID
		{
			get { return _DiasDeCobro_ID; }
			set { _DiasDeCobro_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private decimal _RentaBase;
		public decimal RentaBase
		{
			get { return _RentaBase; }
			set { _RentaBase = value; }
		}

		private decimal? _FondoResidual;
		public decimal? FondoResidual
		{
			get { return _FondoResidual; }
			set { _FondoResidual = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		#endregion

		#region Methods

		public void Validate()
		{
			if (this.ModeloUnidad_ID == 0) throw new Exception("ModeloUnidad_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.DiasDeCobro_ID == 0) throw new Exception("DiasDeCobro_ID no puede ser nulo.");

			if (this.Descripcion == null) throw new Exception("Descripcion no puede ser nulo.");

			if (this.Descripcion.Length > 50)
			{
				throw new Exception("Descripcion debe tener máximo 50 carateres.");
			}

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.RentaBase <= 0) throw new Exception("La renta base debe ser mayor que cero");


		} // End Validate


		public int Create()
		{
			Validate();

			Hashtable m_params = new Hashtable();
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("RentaBase", this.RentaBase);
			if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.InsertRow("PlanesDeRenta", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();

			Validate();

			Hashtable m_params = new Hashtable();
			m_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("RentaBase", this.RentaBase);
			if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.IdentityInsertRow("PlanesDeRenta", m_params);
		} // End Create

		public static List<PlanesDeRenta> Read()
		{
			List<PlanesDeRenta> list = new List<PlanesDeRenta>();
			DataTable dt = DB.Select("PlanesDeRenta");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public static PlanesDeRenta Read(int planderenta_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("PlanDeRenta_ID", planderenta_id);
			DataTable dt = DB.Select("PlanesDeRenta", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe PlanesDeRenta con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		} // End Read

		public static PlanesDeRenta Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PlanesDeRenta", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		} // End Read

		public static List<PlanesDeRenta> ReadList(params KeyValuePair<string, object>[] args)
		{
			List<PlanesDeRenta> list = new List<PlanesDeRenta>();
			DataTable dt = DB.Read("PlanesDeRenta", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
			}

			return list;
		} // End Read

		public static bool Read(out PlanesDeRenta planesderenta, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PlanesDeRenta", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				planesderenta = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			planesderenta = new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("PlanesDeRenta");
		} // End Read

		public static DataTable ReadDataTable(int planderenta_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("PlanDeRenta_ID", planderenta_id);
			return DB.Select("PlanesDeRenta", w_params);
		} // End Read

		public int Update()
		{
			Validate();

			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("RentaBase", this.RentaBase);
			if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Activo", this.Activo);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.UpdateRow("PlanesDeRenta", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);

			return DB.DeleteRow("PlanesDeRenta", w_params);
		} // End Delete

		#endregion


	} //End Class PlanesDeRenta

	public class PlanillasFiscales
	{

		#region Constructors

		public PlanillasFiscales()
		{
		}

		public PlanillasFiscales(
			int estacion_id,
			int estatusplanillafiscal_id,
			int? ticket_id,
			string serie,
			int folio,
			decimal denominacion,
			decimal precio,
			DateTime fecha,
			int empresa_id)
		{
			this.Estacion_ID = estacion_id;
			this.EstatusPlanillaFiscal_ID = estatusplanillafiscal_id;
			this.Ticket_ID = ticket_id;
			this.Serie = serie;
			this.Folio = folio;
			this.Denominacion = denominacion;
			this.Precio = precio;
			this.Fecha = fecha;
			this.Empresa_ID = empresa_id;
		}

		#endregion

		#region Properties

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _EstatusPlanillaFiscal_ID;
		public int EstatusPlanillaFiscal_ID
		{
			get { return _EstatusPlanillaFiscal_ID; }
			set { _EstatusPlanillaFiscal_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private string _Serie;
		public string Serie
		{
			get { return _Serie; }
			set { _Serie = value; }
		}

		private int _Folio;
		public int Folio
		{
			get { return _Folio; }
			set { _Folio = value; }
		}

		private decimal _Denominacion;
		public decimal Denominacion
		{
			get { return _Denominacion; }
			set { _Denominacion = value; }
		}

		private decimal _Precio;
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.EstatusPlanillaFiscal_ID == 0) throw new Exception("EstatusPlanillaFiscal_ID no puede ser nulo.");

			if (this.Serie == null) throw new Exception("Serie no puede ser nulo.");

			if (this.Serie.Length > 30)
			{
				throw new Exception("Serie debe tener máximo 30 carateres.");
			}

			if (this.Folio == 0) throw new Exception("Folio no puede ser nulo.");

			if (this.Denominacion == 0) throw new Exception("Denominacion no puede ser 0.");

			if (this.Precio == 0) throw new Exception("Precio no puede ser 0.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("EstatusPlanillaFiscal_ID", this.EstatusPlanillaFiscal_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Serie", this.Serie);
			m_params.Add("Folio", this.Folio);
			m_params.Add("Denominacion", this.Denominacion);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Empresa_ID", this.Empresa_ID);

			return DB.InsertRow("PlanillasFiscales", m_params);
		} // End Create

		public static List<PlanillasFiscales> Read()
		{
			List<PlanillasFiscales> list = new List<PlanillasFiscales>();
			DataTable dt = DB.Select("PlanillasFiscales");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
					new PlanillasFiscales(
						Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]),
						DB.GetNullableInt32(dr["Ticket_ID"]),
						Convert.ToString(dr["Serie"]),
						Convert.ToInt32(dr["Folio"]),
						Convert.ToDecimal(dr["Denominacion"]),
						Convert.ToDecimal(dr["Precio"]),
						Convert.ToDateTime(dr["Fecha"]),
						Convert.ToInt32(dr["Empresa_ID"])
					)
				);
			}

			return list;
		} // End Read

		public static PlanillasFiscales Read(int empresa_id, int estacion_id, string serie, int folio)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Empresa_ID", empresa_id);
			w_params.Add("Estacion_ID", estacion_id);
			w_params.Add("Serie", serie);
			w_params.Add("Folio", folio);

			DataTable dt = DB.Select("PlanillasFiscales", w_params);

			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe PlanillasFiscales con los criterios de búsqueda especificados.");
			}

			DataRow dr = dt.Rows[0];

			return new PlanillasFiscales(
				Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]),
						DB.GetNullableInt32(dr["Ticket_ID"]),
						Convert.ToString(dr["Serie"]),
						Convert.ToInt32(dr["Folio"]),
						Convert.ToDecimal(dr["Denominacion"]),
						Convert.ToDecimal(dr["Precio"]),
						Convert.ToDateTime(dr["Fecha"]),
						Convert.ToInt32(dr["Empresa_ID"])
					);
		} // End Read

		public static PlanillasFiscales Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PlanillasFiscales", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new PlanillasFiscales(
				Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]),
						DB.GetNullableInt32(dr["Ticket_ID"]),
						Convert.ToString(dr["Serie"]),
						Convert.ToInt32(dr["Folio"]),
						Convert.ToDecimal(dr["Denominacion"]),
						Convert.ToDecimal(dr["Precio"]),
						Convert.ToDateTime(dr["Fecha"]),
						Convert.ToInt32(dr["Empresa_ID"])
					);
		} // End Read

		public static bool Read(
			out PlanillasFiscales planillasfiscales,
			int top,
			string filter,
			string sort,
			params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("PlanillasFiscales", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				planillasfiscales = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			planillasfiscales = new PlanillasFiscales(
				Convert.ToInt32(dr["Estacion_ID"]),
						Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]),
						DB.GetNullableInt32(dr["Ticket_ID"]),
						Convert.ToString(dr["Serie"]),
						Convert.ToInt32(dr["Folio"]),
						Convert.ToDecimal(dr["Denominacion"]),
						Convert.ToDecimal(dr["Precio"]),
						Convert.ToDateTime(dr["Fecha"]),
						Convert.ToInt32(dr["Empresa_ID"])
					);
			return true;
		} // End Read

		public static List<PlanillasFiscales> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<PlanillasFiscales> list = new List<PlanillasFiscales>();

			DataTable dt = DB.Read("PlanillasFiscales", filter, sort, args);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new PlanillasFiscales(
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]),
					   DB.GetNullableInt32(dr["Ticket_ID"]),
					   Convert.ToString(dr["Serie"]),
					   Convert.ToInt32(dr["Folio"]),
					   Convert.ToDecimal(dr["Denominacion"]),
					   Convert.ToDecimal(dr["Precio"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToInt32(dr["Empresa_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("PlanillasFiscales");
		} // End Read

		public static DataTable ReadDataTable(int empresa_id, int estacion_id, string serie, int folio)
		{
			Hashtable w_params = new Hashtable();

			w_params.Add("Empresa_ID", empresa_id);
			w_params.Add("Estacion_ID", estacion_id);
			w_params.Add("Serie", serie);
			w_params.Add("Folio", folio);

			return DB.Select("PlanillasFiscales", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("EstatusPlanillaFiscal_ID", this.EstatusPlanillaFiscal_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			w_params.Add("Serie", this.Serie);
			w_params.Add("Folio", this.Folio);
			m_params.Add("Denominacion", this.Denominacion);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Fecha", this.Fecha);
			w_params.Add("Empresa_ID", this.Empresa_ID);

			return DB.UpdateRow("PlanillasFiscales", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Serie", this.Serie);
			w_params.Add("Folio", this.Folio);
			w_params.Add("Empresa_ID", this.Empresa_ID);
			w_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.DeleteRow("PlanillasFiscales", w_params);
		} // End Delete


		#endregion
	} //End Class PlanillasFiscales

	public class Refacciones
	{

		#region Constructors

		public Refacciones()
		{
		}

		public Refacciones(
		    int refaccion_id,
		    int tiporefaccion_id,
		    int modelo_id,
		    int marcarefaccion_id,
		    int? anio,
		    string numeroserial,
		    string descripcion)
		{
			this.Refaccion_ID = refaccion_id;
			this.TipoRefaccion_ID = tiporefaccion_id;
			this.Modelo_ID = modelo_id;
			this.MarcaRefaccion_ID = marcarefaccion_id;
			this.Anio = anio;
			this.NumeroSerial = numeroserial;
			this.Descripcion = descripcion;
		}

		#endregion

		#region Properties

		private int _Refaccion_ID;
		public int Refaccion_ID
		{
			get { return _Refaccion_ID; }
			set { _Refaccion_ID = value; }
		}

		private int _TipoRefaccion_ID;
		public int TipoRefaccion_ID
		{
			get { return _TipoRefaccion_ID; }
			set { _TipoRefaccion_ID = value; }
		}

		private int _Modelo_ID;
		public int Modelo_ID
		{
			get { return _Modelo_ID; }
			set { _Modelo_ID = value; }
		}

		private int _MarcaRefaccion_ID;
		public int MarcaRefaccion_ID
		{
			get { return _MarcaRefaccion_ID; }
			set { _MarcaRefaccion_ID = value; }
		}

		private int? _Anio;
		public int? Anio
		{
			get { return _Anio; }
			set { _Anio = value; }
		}

		private string _NumeroSerial;
		public string NumeroSerial
		{
			get { return _NumeroSerial; }
			set { _NumeroSerial = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.TipoRefaccion_ID == 0) throw new Exception("TipoRefaccion_ID no puede ser nulo.");

			if (this.Modelo_ID == 0) throw new Exception("Modelo_ID no puede ser nulo.");

			if (this.MarcaRefaccion_ID == 0) throw new Exception("MarcaRefaccion_ID no puede ser nulo.");

			if (this.NumeroSerial.Length > 50)
			{
				throw new Exception("NumeroSerial debe tener máximo 50 carateres.");
			}

			if (this.Descripcion == null) throw new Exception("Descripcion no puede ser nulo.");

			if (this.Descripcion.Length > 200)
			{
				throw new Exception("Descripcion debe tener máximo 200 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("Anio", this.Anio);
			m_params.Add("NumeroSerial", this.NumeroSerial);
			m_params.Add("Descripcion", this.Descripcion);

			int result = DB.InsertRow("Refacciones", m_params);

			//  Obtener la refaccion
			m_params.Clear();
			m_params.Add("@TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("@Modelo_ID", this.Modelo_ID);
			m_params.Add("@MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			m_params.Add("@Anio", this.Anio);
			m_params.Add("@NumeroSerial", this.NumeroSerial);
			m_params.Add("@Descripcion", this.Descripcion);

			string sql = @"SELECT MAX(Refaccion_ID)
FROM    Refacciones
WHERE   TipoRefaccion_ID = @TipoRefaccion_ID
AND     Modelo_ID = @Modelo_ID
AND     MarcaRefaccion_ID = @MarcaRefaccion_ID
AND     Anio = @Anio
AND     NumeroSerial = @NumeroSerial
AND     Descripcion = @Descripcion";

			this.Refaccion_ID =
			    Convert.ToInt32(
				   DB.QueryScalar(
					  sql,
					  m_params
				   )
			    );

			//  Alta en inventarios 
			sql = @"INSERT  Inventario
SELECT	Empresa_ID,
		Estacion_ID,
		@Refaccion_ID,
		NULL,
		NULL,
		NULL,
		NULL,
		0,
		0,
		0,
		@MargenInterno,
		@MargenExterno,
		0,
		0,
		0
FROM	Inventario
GROUP BY	Empresa_ID, Estacion_ID";

			m_params.Clear();
			m_params.Add("@Refaccion_ID", this.Refaccion_ID);
			m_params.Add("@MargenInterno", 30);
			m_params.Add("@MargenExterno", 40);

			DB.ExecuteCommand(
			    sql,
			    m_params
			);

			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			if (!DB.IsNullOrEmpty(this.Anio)) m_params.Add("Anio", this.Anio);
			if (!DB.IsNullOrEmpty(this.NumeroSerial)) m_params.Add("NumeroSerial", this.NumeroSerial);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.IdentityInsertRow("Refacciones", m_params);
		} // End Create

		public static List<Refacciones> Read()
		{
			List<Refacciones> list = new List<Refacciones>();
			DataTable dt = DB.Select("Refacciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Refacciones(
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["TipoRefaccion_ID"]),
					   Convert.ToInt32(dr["Modelo_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   DB.GetNullableInt32(dr["Anio"]),
					   Convert.ToString(dr["NumeroSerial"]),
					   Convert.ToString(dr["Descripcion"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Refacciones> ReadOrderByDescripcion()
		{
			List<Refacciones> list = new List<Refacciones>();
			DataTable dt = DB.Read("Refacciones", null, "Descripcion");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Refacciones(
					   Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["TipoRefaccion_ID"]),
					   Convert.ToInt32(dr["Modelo_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   DB.GetNullableInt32(dr["Anio"]),
					   Convert.ToString(dr["NumeroSerial"]),
					   Convert.ToString(dr["Descripcion"])
				    )
				);
			}

			return list;
		} // End Read

		public static Refacciones Read(int refaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", refaccion_id);
			DataTable dt = DB.Select("Refacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Refacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Refacciones(
			    Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["TipoRefaccion_ID"]),
					  Convert.ToInt32(dr["Modelo_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  DB.GetNullableInt32(dr["Anio"]),
					  Convert.ToString(dr["NumeroSerial"]),
					  Convert.ToString(dr["Descripcion"])
				   );
		} // End Read

		public static Refacciones ReadSingle(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Refacciones", filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Refacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Refacciones(
			    Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["TipoRefaccion_ID"]),
					  Convert.ToInt32(dr["Modelo_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  DB.GetNullableInt32(dr["Anio"]),
					  Convert.ToString(dr["NumeroSerial"]),
					  Convert.ToString(dr["Descripcion"])
				   );
		} // End Read

		public static int GetCantidadInventario(int refaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", refaccion_id);
			DataTable dt = DB.Select("Refacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				return 0;
			}
			DataRow dr = dt.Rows[0];
			return Convert.ToInt32(dr["CantidadInventario"]);
		} // End Read


		public static List<Refacciones> Read(params KeyValuePair<string, object>[] args)
		{
			List<Refacciones> list = new List<Refacciones>();
			DataTable dt = DB.Read("Refacciones", args);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Refacciones(
				Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["TipoRefaccion_ID"]),
					   Convert.ToInt32(dr["Modelo_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   DB.GetNullableInt32(dr["Anio"]),
					   Convert.ToString(dr["NumeroSerial"]),
					   Convert.ToString(dr["Descripcion"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Refacciones> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Refacciones> list = new List<Refacciones>();
			DataTable dt = DB.Read("Refacciones", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Refacciones(
				Convert.ToInt32(dr["Refaccion_ID"]),
					   Convert.ToInt32(dr["TipoRefaccion_ID"]),
					   Convert.ToInt32(dr["Modelo_ID"]),
					   Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					   DB.GetNullableInt32(dr["Anio"]),
					   Convert.ToString(dr["NumeroSerial"]),
					   Convert.ToString(dr["Descripcion"])
				    ));
			}

			return list;
		} // End Read

		public static bool Read(
		    out Refacciones refacciones,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Refacciones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				refacciones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			refacciones = new Refacciones(
			    Convert.ToInt32(dr["Refaccion_ID"]),
					  Convert.ToInt32(dr["TipoRefaccion_ID"]),
					  Convert.ToInt32(dr["Modelo_ID"]),
					  Convert.ToInt32(dr["MarcaRefaccion_ID"]),
					  DB.GetNullableInt32(dr["Anio"]),
					  Convert.ToString(dr["NumeroSerial"]),
					  Convert.ToString(dr["Descripcion"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Refacciones");
		} // End Read

		public static DataTable ReadDataTable(int refaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", refaccion_id);
			return DB.Select("Refacciones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", this.Refaccion_ID);
			m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
			if (!DB.IsNullOrEmpty(this.Anio)) m_params.Add("Anio", this.Anio);
			if (!DB.IsNullOrEmpty(this.NumeroSerial)) m_params.Add("NumeroSerial", this.NumeroSerial);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.UpdateRow("Refacciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Refaccion_ID", this.Refaccion_ID);

			return DB.DeleteRow("Refacciones", w_params);
		} // End Delete


		#endregion
	} //End Class Refacciones

	public class RegistroAccionesSistema
	{

		#region Constructors

		public RegistroAccionesSistema()
		{
		}

		public RegistroAccionesSistema(
		    int registroaccionsistema_id,
		    string usuario_id,
		    int? opcion_id,
		    string formulario,
		    string accion,
		    string comentarios,
		    DateTime fecha)
		{
			this.RegistroAccionSistema_ID = registroaccionsistema_id;
			this.Usuario_ID = usuario_id;
			this.Opcion_ID = opcion_id;
			this.Formulario = formulario;
			this.Accion = accion;
			this.Comentarios = comentarios;
			this.Fecha = fecha;
		}

		#endregion

		#region Properties

		private int _RegistroAccionSistema_ID;
		public int RegistroAccionSistema_ID
		{
			get { return _RegistroAccionSistema_ID; }
			set { _RegistroAccionSistema_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _Opcion_ID;
		public int? Opcion_ID
		{
			get { return _Opcion_ID; }
			set { _Opcion_ID = value; }
		}

		private string _Formulario;
		public string Formulario
		{
			get { return _Formulario; }
			set { _Formulario = value; }
		}

		private string _Accion;
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		#endregion

		#region Methods
		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Opcion_ID)) m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("Formulario", this.Formulario);
			m_params.Add("Accion", this.Accion);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);

			return DB.InsertRow("RegistroAccionesSistema", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("RegistroAccionSistema_ID", this.RegistroAccionSistema_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Opcion_ID)) m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("Formulario", this.Formulario);
			m_params.Add("Accion", this.Accion);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);

			return DB.IdentityInsertRow("RegistroAccionesSistema", m_params);
		} // End Create

		public static List<RegistroAccionesSistema> Read()
		{
			List<RegistroAccionesSistema> list = new List<RegistroAccionesSistema>();
			DataTable dt = DB.Select("RegistroAccionesSistema");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new RegistroAccionesSistema(
					   Convert.ToInt32(dr["RegistroAccionSistema_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Opcion_ID"]),
					   Convert.ToString(dr["Formulario"]),
					   Convert.ToString(dr["Accion"]),
					   Convert.ToString(dr["Comentarios"]),
					   Convert.ToDateTime(dr["Fecha"])
				    )
				);
			}

			return list;
		} // End Read

		public static RegistroAccionesSistema Read(int registroaccionsistema_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("RegistroAccionSistema_ID", registroaccionsistema_id);
			DataTable dt = DB.Select("RegistroAccionesSistema", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe RegistroAccionesSistema con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new RegistroAccionesSistema(
			    Convert.ToInt32(dr["RegistroAccionSistema_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Opcion_ID"]),
					  Convert.ToString(dr["Formulario"]),
					  Convert.ToString(dr["Accion"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"])
				   );
		} // End Read

		public static RegistroAccionesSistema Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("RegistroAccionesSistema", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new RegistroAccionesSistema(
			    Convert.ToInt32(dr["RegistroAccionSistema_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Opcion_ID"]),
					  Convert.ToString(dr["Formulario"]),
					  Convert.ToString(dr["Accion"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"])
				   );
		} // End Read

		public static bool Read(
		    out RegistroAccionesSistema registroaccionessistema,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("RegistroAccionesSistema", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				registroaccionessistema = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			registroaccionessistema = new RegistroAccionesSistema(
			    Convert.ToInt32(dr["RegistroAccionSistema_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Opcion_ID"]),
					  Convert.ToString(dr["Formulario"]),
					  Convert.ToString(dr["Accion"]),
					  Convert.ToString(dr["Comentarios"]),
					  Convert.ToDateTime(dr["Fecha"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("RegistroAccionesSistema");
		} // End Read

		public static DataTable ReadDataTable(int registroaccionsistema_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("RegistroAccionSistema_ID", registroaccionsistema_id);
			return DB.Select("RegistroAccionesSistema", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("RegistroAccionSistema_ID", this.RegistroAccionSistema_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Opcion_ID)) m_params.Add("Opcion_ID", this.Opcion_ID);
			m_params.Add("Formulario", this.Formulario);
			m_params.Add("Accion", this.Accion);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			m_params.Add("Fecha", this.Fecha);

			return DB.UpdateRow("RegistroAccionesSistema", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("RegistroAccionSistema_ID", this.RegistroAccionSistema_ID);

			return DB.DeleteRow("RegistroAccionesSistema", w_params);
		} // End Delete


		#endregion
	} //End Class RegistroAccionesSistema

	public class RegistroIndicadores
	{

		public RegistroIndicadores()
		{
		}

		public RegistroIndicadores(int empresa_id, int estacion_id, int anio, int mes, int semana, int dia, DateTime fecha, int indicador_id, object valor, object estrato)
		{
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Anio = anio;
			this.Mes = mes;
			this.Semana = semana;
			this.Dia = dia;
			this.Fecha = fecha;
			this.Indicador_ID = indicador_id;
			this.Valor = valor;
			this.Estrato = estrato;
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Anio;
		public int Anio
		{
			get { return _Anio; }
			set { _Anio = value; }
		}

		private int _Mes;
		public int Mes
		{
			get { return _Mes; }
			set { _Mes = value; }
		}

		private int _Semana;
		public int Semana
		{
			get { return _Semana; }
			set { _Semana = value; }
		}

		private int _Dia;
		public int Dia
		{
			get { return _Dia; }
			set { _Dia = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _Indicador_ID;
		public int Indicador_ID
		{
			get { return _Indicador_ID; }
			set { _Indicador_ID = value; }
		}

		private object _Valor;
		public object Valor
		{
			get { return _Valor; }
			set { _Valor = value; }
		}

		private object _Estrato;
		public object Estrato
		{
			get { return _Estrato; }
			set { _Estrato = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Anio", this.Anio);
			m_params.Add("Mes", this.Mes);
			m_params.Add("Semana", this.Semana);
			m_params.Add("Dia", this.Dia);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Valor", this.Valor);
			m_params.Add("Estrato", this.Estrato);

			return DB.InsertRow("RegistroIndicadores", m_params);
		} // End Create

		public static List<RegistroIndicadores> Read()
		{
			List<RegistroIndicadores> list = new List<RegistroIndicadores>();
			DataTable dt = DB.Select("RegistroIndicadores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new RegistroIndicadores(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Anio"]), Convert.ToInt32(dr["Mes"]), Convert.ToInt32(dr["Semana"]), Convert.ToInt32(dr["Dia"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Indicador_ID"]), (object)(dr["Valor"]), (object)(dr["Estrato"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Anio", this.Anio);
			m_params.Add("Mes", this.Mes);
			m_params.Add("Semana", this.Semana);
			m_params.Add("Dia", this.Dia);
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Valor", this.Valor);
			m_params.Add("Estrato", this.Estrato);

			return DB.UpdateRow("RegistroIndicadores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();

			return DB.DeleteRow("RegistroIndicadores", w_params);
		}

	} //End Class RegistroIndicadores

	public class ReportesIndicadores
	{

		public ReportesIndicadores()
		{
		}

		public ReportesIndicadores(int reporteindicador_id, int indicador_id, int periodo_id, int tiporeporte_id, int funcionagregado_id, string nombre, int cantidadperiodos)
		{
			this.ReporteIndicador_ID = reporteindicador_id;
			this.Indicador_ID = indicador_id;
			this.Periodo_ID = periodo_id;
			this.TipoReporte_ID = tiporeporte_id;
			this.FuncionAgregado_ID = funcionagregado_id;
			this.Nombre = nombre;
			this.CantidadPeriodos = cantidadperiodos;
		}

		private int _ReporteIndicador_ID;
		public int ReporteIndicador_ID
		{
			get { return _ReporteIndicador_ID; }
			set { _ReporteIndicador_ID = value; }
		}

		private int _Indicador_ID;
		public int Indicador_ID
		{
			get { return _Indicador_ID; }
			set { _Indicador_ID = value; }
		}

		private int _Periodo_ID;
		public int Periodo_ID
		{
			get { return _Periodo_ID; }
			set { _Periodo_ID = value; }
		}

		private int _TipoReporte_ID;
		public int TipoReporte_ID
		{
			get { return _TipoReporte_ID; }
			set { _TipoReporte_ID = value; }
		}

		private int _FuncionAgregado_ID;
		public int FuncionAgregado_ID
		{
			get { return _FuncionAgregado_ID; }
			set { _FuncionAgregado_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private int _CantidadPeriodos;
		public int CantidadPeriodos
		{
			get { return _CantidadPeriodos; }
			set { _CantidadPeriodos = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Periodo_ID", this.Periodo_ID);
			m_params.Add("TipoReporte_ID", this.TipoReporte_ID);
			m_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("CantidadPeriodos", this.CantidadPeriodos);

			return DB.InsertRow("ReportesIndicadores", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("ReporteIndicador_ID", this.ReporteIndicador_ID);
			m_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Periodo_ID", this.Periodo_ID);
			m_params.Add("TipoReporte_ID", this.TipoReporte_ID);
			m_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("CantidadPeriodos", this.CantidadPeriodos);

			return DB.IdentityInsertRow("ReportesIndicadores", m_params);
		} // End Create

		public static List<ReportesIndicadores> Read()
		{
			List<ReportesIndicadores> list = new List<ReportesIndicadores>();
			DataTable dt = DB.Select("ReportesIndicadores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ReportesIndicadores(Convert.ToInt32(dr["ReporteIndicador_ID"]), Convert.ToInt32(dr["Indicador_ID"]), Convert.ToInt32(dr["Periodo_ID"]), Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["CantidadPeriodos"])));
			}

			return list;
		} // End Read

		public static ReportesIndicadores Read(int reporteindicador_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ReporteIndicador_ID", reporteindicador_id);
			DataTable dt = DB.Select("ReportesIndicadores", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ReportesIndicadores con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ReportesIndicadores(Convert.ToInt32(dr["ReporteIndicador_ID"]), Convert.ToInt32(dr["Indicador_ID"]), Convert.ToInt32(dr["Periodo_ID"]), Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["CantidadPeriodos"]));
		} // End Read

		public static ReportesIndicadores Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ReportesIndicadores", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ReportesIndicadores(Convert.ToInt32(dr["ReporteIndicador_ID"]), Convert.ToInt32(dr["Indicador_ID"]), Convert.ToInt32(dr["Periodo_ID"]), Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["CantidadPeriodos"]));
		} // End Read

		public static bool Read(out ReportesIndicadores reportesindicadores, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ReportesIndicadores", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				reportesindicadores = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			reportesindicadores = new ReportesIndicadores(Convert.ToInt32(dr["ReporteIndicador_ID"]), Convert.ToInt32(dr["Indicador_ID"]), Convert.ToInt32(dr["Periodo_ID"]), Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToInt32(dr["FuncionAgregado_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["CantidadPeriodos"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ReportesIndicadores");
		} // End Read

		public static DataTable ReadDataTable(int reporteindicador_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ReporteIndicador_ID", reporteindicador_id);
			return DB.Select("ReportesIndicadores", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ReporteIndicador_ID", this.ReporteIndicador_ID);
			m_params.Add("Indicador_ID", this.Indicador_ID);
			m_params.Add("Periodo_ID", this.Periodo_ID);
			m_params.Add("TipoReporte_ID", this.TipoReporte_ID);
			m_params.Add("FuncionAgregado_ID", this.FuncionAgregado_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("CantidadPeriodos", this.CantidadPeriodos);

			return DB.UpdateRow("ReportesIndicadores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ReporteIndicador_ID", this.ReporteIndicador_ID);

			return DB.DeleteRow("ReportesIndicadores", w_params);
		} // End Delete

	} //End Class ReportesIndicadores

	public class Servicios
	{

		#region Constructors

		public Servicios()
		{
		}

		public Servicios(
		    string servicio_id,
		    int mercado_id,
		    int empresa_id,
		    int? estacion_id,
		    int? caja_id,
		    int? sesion_id,
		    int? zona_id,
		    int? claseservicio_id,
		    int? tiposervicio_id,
		    int? tiposervicioconductor_id,
		    int moneda_id,
		    int estatusservicio_id,
		    int? unidad_id,
		    int? conductor_id,
		    string usuario_id,
		    int? cliente_id,
		    int? ticket_id,
		    int? tipoventa_id,
		    int? cuenta_id,
		    int foliodiario,
		    decimal precio,
		    DateTime fecha,
		    DateTime? fechaservicio,
		    DateTime? fechaexpiracion,
		    DateTime? fechapago,
		    decimal? productividad,
		    decimal? pagoconductor,
		    decimal? pagocomisiones,
		    int? conductorregreso_id,
		    decimal? porcentajeregreso,
		    decimal? comisionregreso,
		    int? unidadregreso_id,
		    string reservacion_id,
			string referencia_payback,
			string ctaBanco,
            string Voucher)
		{
			this.Servicio_ID = servicio_id;
			this.Mercado_ID = mercado_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Caja_ID = caja_id;
			this.Sesion_ID = sesion_id;
			this.Zona_ID = zona_id;
			this.ClaseServicio_ID = claseservicio_id;
			this.TipoServicio_ID = tiposervicio_id;
			this.TipoServicioConductor_ID = tiposervicioconductor_id;
			this.Moneda_ID = moneda_id;
			this.EstatusServicio_ID = estatusservicio_id;
			this.Unidad_ID = unidad_id;
			this.Conductor_ID = conductor_id;
			this.Usuario_ID = usuario_id;
			this.Cliente_ID = cliente_id;
			this.Ticket_ID = ticket_id;
			this.TipoVenta_ID = tipoventa_id;
			this.Cuenta_ID = cuenta_id;
			this.FolioDiario = foliodiario;
			this.Precio = precio;
			this.Fecha = fecha;
			this.FechaServicio = fechaservicio;
			this.FechaExpiracion = fechaexpiracion;
			this.FechaPago = fechapago;
			this.Productividad = productividad;
			this.PagoConductor = pagoconductor;
			this.PagoComisiones = pagocomisiones;
			this.ConductorRegreso_ID = conductorregreso_id;
			this.PorcentajeRegreso = porcentajeregreso;
			this.ComisionRegreso = comisionregreso;
			this.UnidadRegreso_ID = unidadregreso_id;
			this.Reservacion_ID = reservacion_id;
			this.Referencia_PayBack = referencia_payback;
			this.CtaBanco = ctaBanco;
            this.Voucher = Voucher;
		}

		#endregion

		#region Properties

		private string _Servicio_ID;
		public string Servicio_ID
		{
			get { return _Servicio_ID; }
			set { _Servicio_ID = value; }
		}

		private int _Mercado_ID;
		public int Mercado_ID
		{
			get { return _Mercado_ID; }
			set { _Mercado_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int? _Estacion_ID;
		public int? Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private int? _Sesion_ID;
		public int? Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private int? _Zona_ID;
		public int? Zona_ID
		{
			get { return _Zona_ID; }
			set { _Zona_ID = value; }
		}

		private int? _ClaseServicio_ID;
		public int? ClaseServicio_ID
		{
			get { return _ClaseServicio_ID; }
			set { _ClaseServicio_ID = value; }
		}

		private int? _TipoServicio_ID;
		public int? TipoServicio_ID
		{
			get { return _TipoServicio_ID; }
			set { _TipoServicio_ID = value; }
		}

		private int? _TipoServicioConductor_ID;
		public int? TipoServicioConductor_ID
		{
			get { return _TipoServicioConductor_ID; }
			set { _TipoServicioConductor_ID = value; }
		}

		private int _Moneda_ID;
		public int Moneda_ID
		{
			get { return _Moneda_ID; }
			set { _Moneda_ID = value; }
		}

		private int _EstatusServicio_ID;
		public int EstatusServicio_ID
		{
			get { return _EstatusServicio_ID; }
			set { _EstatusServicio_ID = value; }
		}

		private int? _Unidad_ID;
		public int? Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int? _Conductor_ID;
		public int? Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int? _Cliente_ID;
		public int? Cliente_ID
		{
			get { return _Cliente_ID; }
			set { _Cliente_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int? _TipoVenta_ID;
		public int? TipoVenta_ID
		{
			get { return _TipoVenta_ID; }
			set { _TipoVenta_ID = value; }
		}

		private int? _Cuenta_ID;
		public int? Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int _FolioDiario;
		public int FolioDiario
		{
			get { return _FolioDiario; }
			set { _FolioDiario = value; }
		}

		private decimal _Precio;
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private DateTime? _FechaServicio;
		public DateTime? FechaServicio
		{
			get { return _FechaServicio; }
			set { _FechaServicio = value; }
		}

		private DateTime? _FechaExpiracion;
		public DateTime? FechaExpiracion
		{
			get { return _FechaExpiracion; }
			set { _FechaExpiracion = value; }
		}

		private DateTime? _FechaPago;
		public DateTime? FechaPago
		{
			get { return _FechaPago; }
			set { _FechaPago = value; }
		}

		private decimal? _Productividad;
		public decimal? Productividad
		{
			get { return _Productividad; }
			set { _Productividad = value; }
		}

		private decimal? _PagoConductor;
		public decimal? PagoConductor
		{
			get { return _PagoConductor; }
			set { _PagoConductor = value; }
		}

		private decimal? _PagoComisiones;
		public decimal? PagoComisiones
		{
			get { return _PagoComisiones; }
			set { _PagoComisiones = value; }
		}

		private int? _ConductorRegreso_ID;
		public int? ConductorRegreso_ID
		{
			get { return _ConductorRegreso_ID; }
			set { _ConductorRegreso_ID = value; }
		}

		private decimal? _PorcentajeRegreso;
		public decimal? PorcentajeRegreso
		{
			get { return _PorcentajeRegreso; }
			set { _PorcentajeRegreso = value; }
		}

		private decimal? _ComisionRegreso;
		public decimal? ComisionRegreso
		{
			get { return _ComisionRegreso; }
			set { _ComisionRegreso = value; }
		}

		private int? _UnidadRegreso_ID;
		public int? UnidadRegreso_ID
		{
			get { return _UnidadRegreso_ID; }
			set { _UnidadRegreso_ID = value; }
		}

		private string _Reservacion_ID;
		public string Reservacion_ID
		{
			get { return _Reservacion_ID; }
			set { _Reservacion_ID = value; }
		}
		public bool IsValid_Reservation_ID
		{
			get
			{
				Hashtable m_params = new Hashtable();
				m_params.Add("Reservacion", this.Reservacion_ID);
				return DB.ExecuteCommandSP("dbo.usp_Valida_Numero_Reservacion", m_params);
			}
		}

		private string _Referencia_PayBack = "";
		public string Referencia_PayBack
		{
			get
			{
				string sref = _Referencia_PayBack;
				if (sref.Length == 10)
					return "308681" + this._Referencia_PayBack;
				else
					return this._Referencia_PayBack;
			}
			set { _Referencia_PayBack = value; }
		}

		public int IsValid_Referencia_PayBack
		{
			get
			{
				if (this.Referencia_PayBack.Length == 13)
					return Valida_Num_EAN13(this.Referencia_PayBack);
				else
					return Valida_Luhn(this.Referencia_PayBack);
			}
		}

		private string _ctaBanco = "";
		public string CtaBanco
		{
			get { return _ctaBanco; }
			set { _ctaBanco = value; }
		}

        private string _Voucher = "";
        public string Voucher
        {
            get { return _Voucher; }
            set { _Voucher = value; }
        }

		#endregion

		#region Methods

		public static string GenerarCodigoVenta()
		{
			string codigo = "";

			Random rand = new Random();

			codigo += rand.Next(100, 999).ToString();
			codigo += string.Format("{0:yyMMddHHmm}", DB.GetDate());
			codigo += Strings.Right("0000" + GetFolioDiario().ToString(), 4);

			return codigo;
		}

		public static string GenerarCodigoVenta(int folioDiario)
		{
			string codigo = "";

			Random rand = new Random();

			codigo += rand.Next(100, 999).ToString();
			codigo += string.Format("{0:yyMMddHHmm}", DB.GetDate());
			codigo += Strings.Right("0000" + folioDiario.ToString(), 4);

			return codigo;
		}

		public static string GenerarCodigoVenta(int folioDiario, DateTime fecha)
		{
			string codigo = "";

			Random rand = new Random();

			codigo += rand.Next(100, 999).ToString();
			codigo += string.Format("{0:yyMMddHHmm}", fecha);
			codigo += Strings.Right("0000" + folioDiario.ToString(), 4);

			return codigo;
		}

		public static int GetFolioDiario()
		{
			string sqlstr = @"SELECT COUNT(Servicio_ID) + 1 
FROM Servicios 
WHERE convert(date,Fecha) = convert(date,GETDATE())";

			return Convert.ToInt32(DB.QueryScalar(sqlstr));
		}

		public void Validate()
		{
			if (this.Servicio_ID == null) throw new Exception("Servicio_ID no puede ser nulo.");

			if (this.Servicio_ID.Length > 30)
			{
				throw new Exception("Servicio_ID debe tener máximo 30 carateres.");
			}

			if (this.Mercado_ID == 0) throw new Exception("Mercado_ID no puede ser nulo.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Moneda_ID == 0) throw new Exception("Moneda_ID no puede ser nulo.");

			if (this.EstatusServicio_ID == 0) throw new Exception("EstatusServicio_ID no puede ser nulo.");

			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.FolioDiario == 0) throw new Exception("FolioDiario no puede ser nulo.");

			if (this.Precio == 0) throw new Exception("Precio no puede ser 0.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Servicio_ID", this.Servicio_ID);
			m_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!DB.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
			if (!DB.IsNullOrEmpty(this.Zona_ID)) m_params.Add("Zona_ID", this.Zona_ID);
			if (!DB.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
			if (!DB.IsNullOrEmpty(this.TipoServicio_ID)) m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			if (!DB.IsNullOrEmpty(this.TipoServicioConductor_ID)) m_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
			m_params.Add("Moneda_ID", this.Moneda_ID);
			m_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
			if (!DB.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!DB.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Cliente_ID)) m_params.Add("Cliente_ID", this.Cliente_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			if (!DB.IsNullOrEmpty(this.TipoVenta_ID)) m_params.Add("TipoVenta_ID", this.TipoVenta_ID);
			if (!DB.IsNullOrEmpty(this.Cuenta_ID)) m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("FolioDiario", this.FolioDiario);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.FechaServicio)) m_params.Add("FechaServicio", this.FechaServicio);
			if (!DB.IsNullOrEmpty(this.FechaExpiracion)) m_params.Add("FechaExpiracion", this.FechaExpiracion);
			if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
			if (!DB.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
			if (!DB.IsNullOrEmpty(this.PagoConductor)) m_params.Add("PagoConductor", this.PagoConductor);
			if (!DB.IsNullOrEmpty(this.PagoComisiones)) m_params.Add("PagoComisiones", this.PagoComisiones);
			if (!DB.IsNullOrEmpty(this.ConductorRegreso_ID)) m_params.Add("ConductorRegreso_ID", this.ConductorRegreso_ID);
			if (!DB.IsNullOrEmpty(this.PorcentajeRegreso)) m_params.Add("PorcentajeRegreso", this.PorcentajeRegreso);
			if (!DB.IsNullOrEmpty(this.ComisionRegreso)) m_params.Add("ComisionRegreso", this.ComisionRegreso);
			if (!DB.IsNullOrEmpty(this.UnidadRegreso_ID)) m_params.Add("UnidadRegreso_ID", this.UnidadRegreso_ID);
			if (!DB.IsNullOrEmpty(this.Reservacion_ID)) m_params.Add("Reservacion_ID", this.Reservacion_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_PayBack)) m_params.Add("Referencia_PayBack", this.Referencia_PayBack);
			if (!DB.IsNullOrEmpty(this.CtaBanco)) m_params.Add("CtaBanco", this.CtaBanco);
            if (!DB.IsNullOrEmpty(this.Voucher)) m_params.Add("Voucher", this.Voucher);
			return DB.InsertRow("Servicios", m_params);
		} // End Create

		public static List<Servicios> Read()
		{
			List<Servicios> list = new List<Servicios>();
			DataTable dt = DB.Select("Servicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Servicios(
					   Convert.ToString(dr["Servicio_ID"]),
					   Convert.ToInt32(dr["Mercado_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   DB.GetNullableInt32(dr["Estacion_ID"]),
					   DB.GetNullableInt32(dr["Caja_ID"]),
					   DB.GetNullableInt32(dr["Sesion_ID"]),
					   DB.GetNullableInt32(dr["Zona_ID"]),
					   DB.GetNullableInt32(dr["ClaseServicio_ID"]),
					   DB.GetNullableInt32(dr["TipoServicio_ID"]),
					   DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
					   Convert.ToInt32(dr["Moneda_ID"]),
					   Convert.ToInt32(dr["EstatusServicio_ID"]),
					   DB.GetNullableInt32(dr["Unidad_ID"]),
					   DB.GetNullableInt32(dr["Conductor_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   DB.GetNullableInt32(dr["Cliente_ID"]),
					   DB.GetNullableInt32(dr["Ticket_ID"]),
					   DB.GetNullableInt32(dr["TipoVenta_ID"]),
					   DB.GetNullableInt32(dr["Cuenta_ID"]),
					   Convert.ToInt32(dr["FolioDiario"]),
					   Convert.ToDecimal(dr["Precio"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   DB.GetNullableDateTime(dr["FechaServicio"]),
					   DB.GetNullableDateTime(dr["FechaExpiracion"]),
					   DB.GetNullableDateTime(dr["FechaPago"]),
					   DB.GetNullableDecimal(dr["Productividad"]),
					   DB.GetNullableDecimal(dr["PagoConductor"]),
					   DB.GetNullableDecimal(dr["PagoComisiones"]),
					   DB.GetNullableInt32(dr["ConductorRegreso_ID"]),
					   DB.GetNullableDecimal(dr["PorcentajeRegreso"]),
					   DB.GetNullableDecimal(dr["ComisionRegreso"]),
					   DB.GetNullableInt32(dr["UnidadRegreso_ID"]),
					   Convert.ToString(dr["Reservacion_ID"]),
					   Convert.ToString(dr["Referencia_PayBack"]),
					   Convert.ToString(dr["CtaBanco"]),
                       Convert.ToString(dr["Voucher"])
				    )
				);
			}

			return list;
		} // End Read

		public static Servicios Read(string servicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", servicio_id);
			DataTable dt = DB.Select("Servicios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Servicios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Servicios(
			    Convert.ToString(dr["Servicio_ID"]),
					  Convert.ToInt32(dr["Mercado_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Sesion_ID"]),
					  DB.GetNullableInt32(dr["Zona_ID"]),
					  DB.GetNullableInt32(dr["ClaseServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
					  Convert.ToInt32(dr["Moneda_ID"]),
					  Convert.ToInt32(dr["EstatusServicio_ID"]),
					  DB.GetNullableInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Cliente_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  DB.GetNullableInt32(dr["TipoVenta_ID"]),
					  DB.GetNullableInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["FolioDiario"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  DB.GetNullableDateTime(dr["FechaServicio"]),
					  DB.GetNullableDateTime(dr["FechaExpiracion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  DB.GetNullableDecimal(dr["Productividad"]),
					  DB.GetNullableDecimal(dr["PagoConductor"]),
					  DB.GetNullableDecimal(dr["PagoComisiones"]),
					  DB.GetNullableInt32(dr["ConductorRegreso_ID"]),
					  DB.GetNullableDecimal(dr["PorcentajeRegreso"]),
					  DB.GetNullableDecimal(dr["ComisionRegreso"]),
					  DB.GetNullableInt32(dr["UnidadRegreso_ID"]),
					  Convert.ToString(dr["Reservacion_ID"]),
					 Convert.ToString(dr["Referencia_PayBack"]),
					 Convert.ToString(dr["CtaBanco"]),
                     Convert.ToString(dr["Voucher"])
				   );
		} // End Read

		public static Servicios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Servicios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Servicios(
			    Convert.ToString(dr["Servicio_ID"]),
					  Convert.ToInt32(dr["Mercado_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Sesion_ID"]),
					  DB.GetNullableInt32(dr["Zona_ID"]),
					  DB.GetNullableInt32(dr["ClaseServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
					  Convert.ToInt32(dr["Moneda_ID"]),
					  Convert.ToInt32(dr["EstatusServicio_ID"]),
					  DB.GetNullableInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Cliente_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  DB.GetNullableInt32(dr["TipoVenta_ID"]),
					  DB.GetNullableInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["FolioDiario"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  DB.GetNullableDateTime(dr["FechaServicio"]),
					  DB.GetNullableDateTime(dr["FechaExpiracion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  DB.GetNullableDecimal(dr["Productividad"]),
					  DB.GetNullableDecimal(dr["PagoConductor"]),
					  DB.GetNullableDecimal(dr["PagoComisiones"]),
					  DB.GetNullableInt32(dr["ConductorRegreso_ID"]),
					  DB.GetNullableDecimal(dr["PorcentajeRegreso"]),
					  DB.GetNullableDecimal(dr["ComisionRegreso"]),
					  DB.GetNullableInt32(dr["UnidadRegreso_ID"]),
					  Convert.ToString(dr["Reservacion_ID"]),
					  Convert.ToString(dr["Referencia_PayBack"]),
					  Convert.ToString(dr["CtaBanco"]),
                      Convert.ToString(dr["Voucher"])
				   );
		} // End Read

		public static bool Read(
		    out Servicios servicios,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Servicios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				servicios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			servicios = new Servicios(
			    Convert.ToString(dr["Servicio_ID"]),
					  Convert.ToInt32(dr["Mercado_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  DB.GetNullableInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  DB.GetNullableInt32(dr["Sesion_ID"]),
					  DB.GetNullableInt32(dr["Zona_ID"]),
					  DB.GetNullableInt32(dr["ClaseServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicio_ID"]),
					  DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
					  Convert.ToInt32(dr["Moneda_ID"]),
					  Convert.ToInt32(dr["EstatusServicio_ID"]),
					  DB.GetNullableInt32(dr["Unidad_ID"]),
					  DB.GetNullableInt32(dr["Conductor_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  DB.GetNullableInt32(dr["Cliente_ID"]),
					  DB.GetNullableInt32(dr["Ticket_ID"]),
					  DB.GetNullableInt32(dr["TipoVenta_ID"]),
					  DB.GetNullableInt32(dr["Cuenta_ID"]),
					  Convert.ToInt32(dr["FolioDiario"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  DB.GetNullableDateTime(dr["FechaServicio"]),
					  DB.GetNullableDateTime(dr["FechaExpiracion"]),
					  DB.GetNullableDateTime(dr["FechaPago"]),
					  DB.GetNullableDecimal(dr["Productividad"]),
					  DB.GetNullableDecimal(dr["PagoConductor"]),
					  DB.GetNullableDecimal(dr["PagoComisiones"]),
					  DB.GetNullableInt32(dr["ConductorRegreso_ID"]),
					  DB.GetNullableDecimal(dr["PorcentajeRegreso"]),
					  DB.GetNullableDecimal(dr["ComisionRegreso"]),
					  DB.GetNullableInt32(dr["UnidadRegreso_ID"]),
					  Convert.ToString(dr["Reservacion_ID"]),
					  Convert.ToString(dr["Referencia_PayBack"]),
					  Convert.ToString(dr["CtaBanco"]),
                      Convert.ToString(dr["Voucher"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Servicios");
		} // End Read

		public static DataTable ReadDataTable(string servicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", servicio_id);
			return DB.Select("Servicios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", this.Servicio_ID);
			m_params.Add("Mercado_ID", this.Mercado_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			if (!DB.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
			if (!DB.IsNullOrEmpty(this.Zona_ID)) m_params.Add("Zona_ID", this.Zona_ID);
			if (!DB.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
			if (!DB.IsNullOrEmpty(this.TipoServicio_ID)) m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			if (!DB.IsNullOrEmpty(this.TipoServicioConductor_ID)) m_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
			m_params.Add("Moneda_ID", this.Moneda_ID);
			m_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
			if (!DB.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			if (!DB.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Cliente_ID)) m_params.Add("Cliente_ID", this.Cliente_ID);
			if (!DB.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			if (!DB.IsNullOrEmpty(this.TipoVenta_ID)) m_params.Add("TipoVenta_ID", this.TipoVenta_ID);
			if (!DB.IsNullOrEmpty(this.Cuenta_ID)) m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("FolioDiario", this.FolioDiario);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.FechaServicio)) m_params.Add("FechaServicio", this.FechaServicio);
			if (!DB.IsNullOrEmpty(this.FechaExpiracion)) m_params.Add("FechaExpiracion", this.FechaExpiracion);
			if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
			if (!DB.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
			if (!DB.IsNullOrEmpty(this.PagoConductor)) m_params.Add("PagoConductor", this.PagoConductor);
			if (!DB.IsNullOrEmpty(this.PagoComisiones)) m_params.Add("PagoComisiones", this.PagoComisiones);
			if (!DB.IsNullOrEmpty(this.ConductorRegreso_ID)) m_params.Add("ConductorRegreso_ID", this.ConductorRegreso_ID);
			if (!DB.IsNullOrEmpty(this.PorcentajeRegreso)) m_params.Add("PorcentajeRegreso", this.PorcentajeRegreso);
			if (!DB.IsNullOrEmpty(this.ComisionRegreso)) m_params.Add("ComisionRegreso", this.ComisionRegreso);
			if (!DB.IsNullOrEmpty(this.UnidadRegreso_ID)) m_params.Add("UnidadRegreso_ID", this.UnidadRegreso_ID);
			if (!DB.IsNullOrEmpty(this.Reservacion_ID)) m_params.Add("Reservacion_ID", this.Reservacion_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_PayBack)) m_params.Add("Referencia_PayBack", this.Referencia_PayBack);
			if (!DB.IsNullOrEmpty(this.CtaBanco)) m_params.Add("CtaBanco", this.CtaBanco);
            if (!DB.IsNullOrEmpty(this.Voucher)) m_params.Add("Voucher", this.Voucher);
			return DB.UpdateRow("Servicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", this.Servicio_ID);

			return DB.DeleteRow("Servicios", w_params);
		} // End Delete

		private int Valida_Num_EAN13(string referencia)
		{
			if (referencia.Length == 13)
			{
				string referencia_sin_digito_verificador = referencia.Substring(0, referencia.Length - 1);
				int NumerosPares = 0;
				int NumerosImpares = 0;
				for (int idx = 0; idx < referencia_sin_digito_verificador.Length; idx++)
				{
					if ((idx % 2) == 0)
						NumerosPares += Convert.ToInt32(referencia_sin_digito_verificador.Substring(idx, 1));
					else
						NumerosImpares += Convert.ToInt32(referencia_sin_digito_verificador.Substring(idx, 1));
				}
				NumerosImpares *= 3;
				int verificador = NumerosPares + NumerosImpares;
				verificador %= 10;
				if (verificador > 0)
					verificador = 10 - verificador;

				if (verificador == Convert.ToInt32(referencia.Substring(referencia.Length - 1, 1)))
					return 0;//Número Válido
				else
					return 2;//Número de Tarjeta Inválido
			}
			else
			{
				return 1; //Error de Longitud
			}
		}

		//private int Valida_Luhn(string referencia)
		//{
		//     int sumOfDigits = referencia.Where((e) => e >= '0' && e <= '9')
		//                                 .Reverse()
		//                                .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
		//                                .Sum((e) => e / 10 + e % 10);
		//     return (sumOfDigits % 10) == 0 ? 0 : 2;
		//}

		private int Valida_Luhn(string referencia)
		{
			int ultimo_digito = Convert.ToInt32(referencia[referencia.Length - 1].ToString());
			string referencia_aux = referencia.Substring(0, referencia.Length - 1);
			List<string> numeros = new List<string>();
			List<int> multiplicacion = new List<int>();
			int suma = 0;
			int resultado = 0;
			int numero_final;

			for (int i = 0; i < referencia_aux.Length; i++)
			{
				numeros.Add(referencia_aux[i].ToString());
			}
			numeros.Reverse();

			for (int i = 0; i < numeros.Count; i++)
			{
				switch (i % 2)
				{
					case 1: multiplicacion.Add(Convert.ToInt32(numeros[i]) * 1); break;
					case 0: multiplicacion.Add(Convert.ToInt32(numeros[i]) * 2); break;
				}
				foreach (char c in multiplicacion[i].ToString())
				{
					suma += Convert.ToInt32(c.ToString());
				}
			}
			resultado = suma % 10;
			if (resultado == 0) numero_final = 0;
			else numero_final = 10 - resultado;
			return (numero_final == ultimo_digito) ? 0 : 1;
		}

		#endregion
	} //End Class Servicios

	public class Servicios_Comisiones
	{

		public Servicios_Comisiones()
		{
		}

		public Servicios_Comisiones(string servicio_id, int comisionservicio_id, int? ticket_id, decimal monto)
		{
			this.Servicio_ID = servicio_id;
			this.ComisionServicio_ID = comisionservicio_id;
			this.Ticket_ID = ticket_id;
			this.Monto = monto;
		}

		private string _Servicio_ID;
		public string Servicio_ID
		{
			get { return _Servicio_ID; }
			set { _Servicio_ID = value; }
		}

		private int _ComisionServicio_ID;
		public int ComisionServicio_ID
		{
			get { return _ComisionServicio_ID; }
			set { _ComisionServicio_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private decimal _Monto;
		public decimal Monto
		{
			get { return _Monto; }
			set { _Monto = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Servicio_ID", this.Servicio_ID);
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Monto", this.Monto);

			return DB.InsertRow("Servicios_Comisiones", m_params);
		} // End Create

		public static List<Servicios_Comisiones> Read()
		{
			List<Servicios_Comisiones> list = new List<Servicios_Comisiones>();
			DataTable dt = DB.Select("Servicios_Comisiones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]),
				Convert.ToInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"])));
			}

			return list;
		} // End Read

		public static Servicios_Comisiones Read(string servicio_id, int comisionservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", servicio_id);
			w_params.Add("ComisionServicio_ID", comisionservicio_id);
			DataTable dt = DB.Select("Servicios_Comisiones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Servicios_Comisiones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
			 DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
		} // End Read

		public static Servicios_Comisiones Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Servicios_Comisiones", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
			 DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
		} // End Read

		public static bool Read(out Servicios_Comisiones servicios_comisiones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Servicios_Comisiones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				servicios_comisiones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			servicios_comisiones = new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
			 DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Servicios_Comisiones");
		} // End Read

		public static DataTable ReadDataTable(string servicio_id, int comisionservicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", servicio_id);
			w_params.Add("ComisionServicio_ID", comisionservicio_id);
			return DB.Select("Servicios_Comisiones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", this.Servicio_ID);
			w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Monto", this.Monto);

			return DB.UpdateRow("Servicios_Comisiones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Servicio_ID", this.Servicio_ID);
			w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);

			return DB.DeleteRow("Servicios_Comisiones", w_params);
		} // End Delete

	} //End Class Servicios_Comisiones

	public class ServiciosMantenimientos
	{

		public ServiciosMantenimientos()
		{
		}

		public ServiciosMantenimientos(int serviciomantenimiento_id, int tiposerviciomantenimiento_id, int familia_id, int modelo_id, string nombre, int tiempoaplicado, decimal costomanoobraareaminuto, decimal preciominuto, decimal costo, decimal precio, decimal porcentajeutilidad, decimal cuotamanoobra)
		{
			this.ServicioMantenimiento_ID = serviciomantenimiento_id;
			this.TipoServicioMantenimiento_ID = tiposerviciomantenimiento_id;
			this.Familia_ID = familia_id;
			this.Modelo_ID = modelo_id;
			this.Nombre = nombre;
			this.TiempoAplicado = tiempoaplicado;
			this.CostoManoObraAreaMinuto = costomanoobraareaminuto;
			this.PrecioMinuto = preciominuto;
			this.Costo = costo;
			this.Precio = precio;
			this.PorcentajeUtilidad = porcentajeutilidad;
			this.CuotaManoObra = cuotamanoobra;
		}

		private int _ServicioMantenimiento_ID;
		public int ServicioMantenimiento_ID
		{
			get { return _ServicioMantenimiento_ID; }
			set { _ServicioMantenimiento_ID = value; }
		}

		private int _TipoServicioMantenimiento_ID;
		public int TipoServicioMantenimiento_ID
		{
			get { return _TipoServicioMantenimiento_ID; }
			set { _TipoServicioMantenimiento_ID = value; }
		}

		private int _Familia_ID;
		public int Familia_ID
		{
			get { return _Familia_ID; }
			set { _Familia_ID = value; }
		}

		private int _Modelo_ID;
		public int Modelo_ID
		{
			get { return _Modelo_ID; }
			set { _Modelo_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private int _TiempoAplicado;
		public int TiempoAplicado
		{
			get { return _TiempoAplicado; }
			set { _TiempoAplicado = value; }
		}

		private decimal _CostoManoObraAreaMinuto;
		public decimal CostoManoObraAreaMinuto
		{
			get { return _CostoManoObraAreaMinuto; }
			set { _CostoManoObraAreaMinuto = value; }
		}

		private decimal _PrecioMinuto;
		public decimal PrecioMinuto
		{
			get { return _PrecioMinuto; }
			set { _PrecioMinuto = value; }
		}

		private decimal _Costo;
		public decimal Costo
		{
			get { return _Costo; }
			set { _Costo = value; }
		}

		private decimal _Precio;
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private decimal _PorcentajeUtilidad;
		public decimal PorcentajeUtilidad
		{
			get { return _PorcentajeUtilidad; }
			set { _PorcentajeUtilidad = value; }
		}

		private decimal _CuotaManoObra;
		public decimal CuotaManoObra
		{
			get { return _CuotaManoObra; }
			set { _CuotaManoObra = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("TiempoAplicado", this.TiempoAplicado);
			m_params.Add("CostoManoObraAreaMinuto", this.CostoManoObraAreaMinuto);
			m_params.Add("PrecioMinuto", this.PrecioMinuto);
			m_params.Add("Costo", this.Costo);
			m_params.Add("Precio", this.Precio);
			m_params.Add("PorcentajeUtilidad", this.PorcentajeUtilidad);
			m_params.Add("CuotaManoObra", this.CuotaManoObra);

			return DB.InsertRow("ServiciosMantenimientos", m_params);
		} // End Create

		public static List<ServiciosMantenimientos> Read()
		{
			List<ServiciosMantenimientos> list = new List<ServiciosMantenimientos>();
			DataTable dt = DB.Select("ServiciosMantenimientos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
			}

			return list;
		} // End Read

		public static ServiciosMantenimientos Read(int serviciomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			DataTable dt = DB.Select("ServiciosMantenimientos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ServiciosMantenimientos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"]));
		} // End Read

		public static ServiciosMantenimientos Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ServiciosMantenimientos", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"]));
		} // End Read

		public static bool Read(out ServiciosMantenimientos serviciosmantenimientos, int top,
		    string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ServiciosMantenimientos", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				serviciosmantenimientos = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			serviciosmantenimientos = new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"]));
			return true;
		} // End Read

		public static List<ServiciosMantenimientos> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<ServiciosMantenimientos> list = new List<ServiciosMantenimientos>();
			DataTable dt = DB.Read("ServiciosMantenimientos", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
			}

			return list;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ServiciosMantenimientos");
		} // End Read

		public static DataTable ReadDataTable(int serviciomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			return DB.Select("ServiciosMantenimientos", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Modelo_ID", this.Modelo_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("TiempoAplicado", this.TiempoAplicado);
			m_params.Add("CostoManoObraAreaMinuto", this.CostoManoObraAreaMinuto);
			m_params.Add("PrecioMinuto", this.PrecioMinuto);
			m_params.Add("Costo", this.Costo);
			m_params.Add("Precio", this.Precio);
			m_params.Add("PorcentajeUtilidad", this.PorcentajeUtilidad);
			m_params.Add("CuotaManoObra", this.CuotaManoObra);

			return DB.UpdateRow("ServiciosMantenimientos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);

			return DB.DeleteRow("ServiciosMantenimientos", w_params);
		} // End Delete

	} //End Class ServiciosMantenimientos

	public class ServiciosMantenimientos_TiposRefacciones
	{

		public ServiciosMantenimientos_TiposRefacciones()
		{
		}

		public ServiciosMantenimientos_TiposRefacciones(int serviciomantenimiento_id, int tiporefaccion_id, int cantidad)
		{
			this.ServicioMantenimiento_ID = serviciomantenimiento_id;
			this.TipoRefaccion_ID = tiporefaccion_id;
			this.Cantidad = cantidad;
		}

		private int _ServicioMantenimiento_ID;
		public int ServicioMantenimiento_ID
		{
			get { return _ServicioMantenimiento_ID; }
			set { _ServicioMantenimiento_ID = value; }
		}

		private int _TipoRefaccion_ID;
		public int TipoRefaccion_ID
		{
			get { return _TipoRefaccion_ID; }
			set { _TipoRefaccion_ID = value; }
		}

		private int _Cantidad;
		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Cantidad", this.Cantidad);

			return DB.InsertRow("ServiciosMantenimientos_TiposRefacciones", m_params);
		} // End Create

		public static List<ServiciosMantenimientos_TiposRefacciones> Read()
		{
			List<ServiciosMantenimientos_TiposRefacciones> list = new List<ServiciosMantenimientos_TiposRefacciones>();
			DataTable dt = DB.Select("ServiciosMantenimientos_TiposRefacciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ServiciosMantenimientos_TiposRefacciones(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Cantidad"])));
			}

			return list;
		} // End Read

		public static List<ServiciosMantenimientos_TiposRefacciones> Read(int serviciomantenimiento_id)
		{
			List<ServiciosMantenimientos_TiposRefacciones> list = new List<ServiciosMantenimientos_TiposRefacciones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			DataTable dt = DB.Select("ServiciosMantenimientos_TiposRefacciones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ServiciosMantenimientos_TiposRefacciones(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Cantidad"])));
			}

			return list;
		} // End Read

		public static ServiciosMantenimientos_TiposRefacciones Read(int serviciomantenimiento_id, int tiporefaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			w_params.Add("TipoRefaccion_ID", tiporefaccion_id);
			DataTable dt = DB.Select("ServiciosMantenimientos_TiposRefacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ServiciosMantenimientos_TiposRefacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ServiciosMantenimientos_TiposRefacciones(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Cantidad"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Cantidad", this.Cantidad);

			return DB.UpdateRow("ServiciosMantenimientos_TiposRefacciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);

			return DB.DeleteRow("ServiciosMantenimientos_TiposRefacciones", w_params);
		} // End Delete

	} //End Class ServiciosMantenimientos_TiposRefacciones

	public class ServiciosMantenimientosPrecios
	{

		#region Constructors

		public ServiciosMantenimientosPrecios()
		{
		}

		public ServiciosMantenimientosPrecios(
		    int serviciomantenimiento_id,
		    int tipoclientetaller_id,
		    decimal precio,
		    int empresa_id,
		    int estacion_id)
		{
			this.ServicioMantenimiento_ID = serviciomantenimiento_id;
			this.TipoClienteTaller_ID = tipoclientetaller_id;
			this.Precio = precio;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private int _ServicioMantenimiento_ID;
		public int ServicioMantenimiento_ID
		{
			get { return _ServicioMantenimiento_ID; }
			set { _ServicioMantenimiento_ID = value; }
		}

		private int _TipoClienteTaller_ID;
		public int TipoClienteTaller_ID
		{
			get { return _TipoClienteTaller_ID; }
			set { _TipoClienteTaller_ID = value; }
		}

		private decimal _Precio;
		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.ServicioMantenimiento_ID == 0) throw new Exception("ServicioMantenimiento_ID no puede ser nulo.");

			if (this.TipoClienteTaller_ID == 0) throw new Exception("TipoClienteTaller_ID no puede ser nulo.");

			if (this.Precio == 0) throw new Exception("Precio no puede ser 0.");

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.InsertRow("ServiciosMantenimientosPrecios", m_params);
		} // End Create

		public static List<ServiciosMantenimientosPrecios> Read()
		{
			List<ServiciosMantenimientosPrecios> list = new List<ServiciosMantenimientosPrecios>();
			DataTable dt = DB.Select("ServiciosMantenimientosPrecios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new ServiciosMantenimientosPrecios(
					   Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
					   Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					   Convert.ToDecimal(dr["Precio"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static ServiciosMantenimientosPrecios Read(int serviciomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			DataTable dt = DB.Select("ServiciosMantenimientosPrecios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe ServiciosMantenimientosPrecios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new ServiciosMantenimientosPrecios(
			    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
					  Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static ServiciosMantenimientosPrecios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ServiciosMantenimientosPrecios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ServiciosMantenimientosPrecios(
			    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
					  Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out ServiciosMantenimientosPrecios serviciosmantenimientosprecios,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ServiciosMantenimientosPrecios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				serviciosmantenimientosprecios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			serviciosmantenimientosprecios = new ServiciosMantenimientosPrecios(
			    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
					  Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToDecimal(dr["Precio"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ServiciosMantenimientosPrecios");
		} // End Read

		public static DataTable ReadDataTable(int serviciomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
			return DB.Select("ServiciosMantenimientosPrecios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
			m_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
			m_params.Add("Precio", this.Precio);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("ServiciosMantenimientosPrecios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);

			return DB.DeleteRow("ServiciosMantenimientosPrecios", w_params);
		} // End Delete


		#endregion
	} //End Class ServiciosMantenimientosPrecio

	public class Sesiones
	{

		#region Constructors

		public Sesiones()
		{
		}

		public Sesiones(
		    int sesion_id,
		    int estacion_id,
		    int? caja_id,
		    string usuario_id,
		    DateTime fechainicial,
		    DateTime? fechafinal,
		    string hostname,
		    string ipaddress,
		    string macaddress,
		    bool activo,
		    int? referencia_id)
		{
			this.Sesion_ID = sesion_id;
			this.Estacion_ID = estacion_id;
			this.Caja_ID = caja_id;
			this.Usuario_ID = usuario_id;
			this.FechaInicial = fechainicial;
			this.FechaFinal = fechafinal;
			this.HostName = hostname;
			this.IPAddress = ipaddress;
			this.MACAddress = macaddress;
			this.Activo = activo;
			this.Referencia_ID = referencia_id;
		}

		#endregion

		#region Properties

		private int _Sesion_ID;
		public int Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _FechaInicial;
		public DateTime FechaInicial
		{
			get { return _FechaInicial; }
			set { _FechaInicial = value; }
		}

		private DateTime? _FechaFinal;
		public DateTime? FechaFinal
		{
			get { return _FechaFinal; }
			set { _FechaFinal = value; }
		}

		private string _HostName;
		public string HostName
		{
			get { return _HostName; }
			set { _HostName = value; }
		}

		private string _IPAddress;
		public string IPAddress
		{
			get { return _IPAddress; }
			set { _IPAddress = value; }
		}

		private string _MACAddress;
		public string MACAddress
		{
			get { return _MACAddress; }
			set { _MACAddress = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}
 
		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.FechaInicial == null) throw new Exception("FechaInicial no puede ser nulo.");

			if (this.HostName.Length > 50)
			{
				throw new Exception("HostName debe tener máximo 50 carateres.");
			}

			if (this.IPAddress.Length > 50)
			{
				throw new Exception("IPAddress debe tener máximo 50 carateres.");
			}

			if (this.MACAddress.Length > 50)
			{
				throw new Exception("MACAddress debe tener máximo 50 carateres.");
			}

		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
			if (!DB.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
			if (!DB.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
			m_params.Add("Activo", this.Activo);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			int result = DB.InsertRow("Sesiones", m_params);

			this.Sesion_ID = Convert.ToInt32(DB.Ident_Current("Sesiones"));

			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
			if (!DB.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
			if (!DB.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
			m_params.Add("Activo", this.Activo);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.IdentityInsertRow("Sesiones", m_params);
		} // End Create

		public static List<Sesiones> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Sesiones> list = new List<Sesiones>();
			DataTable dt = DB.Read("Sesiones", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Sesiones(
					   Convert.ToInt32(dr["Sesion_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   DB.GetNullableInt32(dr["Caja_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDateTime(dr["FechaInicial"]),
					   DB.GetNullableDateTime(dr["FechaFinal"]),
					   Convert.ToString(dr["HostName"]),
					   Convert.ToString(dr["IPAddress"]),
					   Convert.ToString(dr["MACAddress"]),
					   Convert.ToBoolean(dr["Activo"]),
					   DB.GetNullableInt32(dr["Referencia_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Sesiones> Read()
		{
			List<Sesiones> list = new List<Sesiones>();
			DataTable dt = DB.Select("Sesiones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Sesiones(
					   Convert.ToInt32(dr["Sesion_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   DB.GetNullableInt32(dr["Caja_ID"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToDateTime(dr["FechaInicial"]),
					   DB.GetNullableDateTime(dr["FechaFinal"]),
					   Convert.ToString(dr["HostName"]),
					   Convert.ToString(dr["IPAddress"]),
					   Convert.ToString(dr["MACAddress"]),
					   Convert.ToBoolean(dr["Activo"]),
					   DB.GetNullableInt32(dr["Referencia_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Sesiones Read(int sesion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Sesion_ID", sesion_id);
			DataTable dt = DB.Select("Sesiones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Sesiones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Sesiones(
			    Convert.ToInt32(dr["Sesion_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["HostName"]),
					  Convert.ToString(dr["IPAddress"]),
					  Convert.ToString(dr["MACAddress"]),
					  Convert.ToBoolean(dr["Activo"]),
					  DB.GetNullableInt32(dr["Referencia_ID"])
				   );
		} // End Read

		public static Sesiones GetUltimaSesionPorUsuarioCaja(string usuario_id,int? caja_id)
		{
			Sesiones s = null;
			string sqlstr = "dbo.usp_Obtiene_UltimaSesionPorUsuarioCaja";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Caja_ID", caja_id);
			m_params.Add("@Usuario_ID", usuario_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				s = new Sesiones(
					Convert.ToInt32(dr["Sesion_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["HostName"]),
					  Convert.ToString(dr["IPAddress"]),
					  Convert.ToString(dr["MACAddress"]),
					  Convert.ToBoolean(dr["Activo"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]));
			}
			return s;
		}

		public static Sesiones Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Sesiones", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Sesiones(
			    Convert.ToInt32(dr["Sesion_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["HostName"]),
					  Convert.ToString(dr["IPAddress"]),
					  Convert.ToString(dr["MACAddress"]),
					  Convert.ToBoolean(dr["Activo"]),
					  DB.GetNullableInt32(dr["Referencia_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Sesiones sesiones,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Sesiones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				sesiones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			sesiones = new Sesiones(
			    Convert.ToInt32(dr["Sesion_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  DB.GetNullableInt32(dr["Caja_ID"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToDateTime(dr["FechaInicial"]),
					  DB.GetNullableDateTime(dr["FechaFinal"]),
					  Convert.ToString(dr["HostName"]),
					  Convert.ToString(dr["IPAddress"]),
					  Convert.ToString(dr["MACAddress"]),
					  Convert.ToBoolean(dr["Activo"]),
					  DB.GetNullableInt32(dr["Referencia_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Sesiones");
		} // End Read

		public static DataTable ReadDataTable(int sesion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Sesion_ID", sesion_id);
			return DB.Select("Sesiones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("FechaInicial", this.FechaInicial);
			if (!DB.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			if (!DB.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
			if (!DB.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
			if (!DB.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
			m_params.Add("Activo", this.Activo);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			return DB.UpdateRow("Sesiones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Sesion_ID", this.Sesion_ID);

			return DB.DeleteRow("Sesiones", w_params);
		} // End Delete


		#endregion
	} //End Class Sesiones

	public class StatusFinancieros
	{

		public StatusFinancieros()
		{
		}

		public StatusFinancieros(DateTime fecha, string usuario, string statusfinanciero_id, string descripcion)
		{
			this.Fecha = fecha;
			this.Usuario = usuario;
			this.StatusFinanciero_ID = statusfinanciero_id;
			this.Descripcion = descripcion;
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario;
		public string Usuario
		{
			get { return _Usuario; }
			set { _Usuario = value; }
		}

		private string _StatusFinanciero_ID;
		public string StatusFinanciero_ID
		{
			get { return _StatusFinanciero_ID; }
			set { _StatusFinanciero_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario", this.Usuario);
			m_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.InsertRow("StatusFinancieros", m_params);
		} // End Create

		public static List<StatusFinancieros> Read()
		{
			List<StatusFinancieros> list = new List<StatusFinancieros>();
			DataTable dt = DB.Select("StatusFinancieros");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new StatusFinancieros(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["StatusFinanciero_ID"]), Convert.ToString(dr["Descripcion"])));
			}

			return list;
		} // End Read

		public static List<StatusFinancieros> Read(string statusfinanciero_id)
		{
			List<StatusFinancieros> list = new List<StatusFinancieros>();
			Hashtable w_params = new Hashtable();
			w_params.Add("StatusFinanciero_ID", statusfinanciero_id);
			DataTable dt = DB.Select("StatusFinancieros", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new StatusFinancieros(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["StatusFinanciero_ID"]), Convert.ToString(dr["Descripcion"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Fecha", this.Fecha);
			m_params.Add("Usuario", this.Usuario);
			w_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);
			m_params.Add("Descripcion", this.Descripcion);

			return DB.UpdateRow("StatusFinancieros", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);

			return DB.DeleteRow("StatusFinancieros", w_params);
		}

	} //End Class StatusFinancieros

	public class SuperProductividad
	{

		#region Constructors

		public SuperProductividad()
		{
		}

		public SuperProductividad(
		    decimal productividad,
		    decimal tarifa)
		{
			this.Productividad = productividad;
			this.Tarifa = tarifa;
		}

		#endregion

		#region Properties

		private decimal _Productividad;
		public decimal Productividad
		{
			get { return _Productividad; }
			set { _Productividad = value; }
		}

		private decimal _Tarifa;
		public decimal Tarifa
		{
			get { return _Tarifa; }
			set { _Tarifa = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Productividad == 0) throw new Exception("Productividad no puede ser 0.");

			if (this.Tarifa == 0) throw new Exception("Tarifa no puede ser 0.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Productividad", this.Productividad);
			m_params.Add("Tarifa", this.Tarifa);

			return DB.InsertRow("SuperProductividad", m_params);
		} // End Create

		public static List<SuperProductividad> Read()
		{
			List<SuperProductividad> list = new List<SuperProductividad>();
			DataTable dt = DB.Select("SuperProductividad");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new SuperProductividad(
					   Convert.ToDecimal(dr["Productividad"]),
					   Convert.ToDecimal(dr["Tarifa"])
				    )
				);
			}

			return list;
		} // End Read

		public static SuperProductividad Read(decimal productividad)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Productividad", productividad);

			string sql = @"SELECT TOP 1 * FROM SuperProductividad WHERE Productividad <= @Productividad
ORDER BY	Productividad DESC";

			DataTable dt = DB.QueryCommand(sql, w_params);

			if (dt.Rows.Count == 0)
			{
				return null;
			}

			DataRow dr = dt.Rows[0];
			return new SuperProductividad(
			    Convert.ToDecimal(dr["Productividad"]),
					  Convert.ToDecimal(dr["Tarifa"])
				   );
		} // End Read

		public static SuperProductividad Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("SuperProductividad", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new SuperProductividad(
			    Convert.ToDecimal(dr["Productividad"]),
					  Convert.ToDecimal(dr["Tarifa"])
				   );
		} // End Read

		public static bool Read(
		    out SuperProductividad superproductividad,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("SuperProductividad", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				superproductividad = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			superproductividad = new SuperProductividad(
			    Convert.ToDecimal(dr["Productividad"]),
					  Convert.ToDecimal(dr["Tarifa"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("SuperProductividad");
		} // End Read

		public static DataTable ReadDataTable(decimal productividad)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Productividad", productividad);
			return DB.Select("SuperProductividad", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Productividad", this.Productividad);
			m_params.Add("Tarifa", this.Tarifa);

			return DB.UpdateRow("SuperProductividad", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Productividad", this.Productividad);

			return DB.DeleteRow("SuperProductividad", w_params);
		} // End Delete


		#endregion
	} //End Class SuperProductividad

	public class Tarifas
	{

		public Tarifas()
		{
		}

		public Tarifas(int zona_id, int tiposervicio_id, decimal tarifa)
		{
			this.Zona_ID = zona_id;
			this.TipoServicio_ID = tiposervicio_id;
			this.Tarifa = tarifa;
		}

		private int _Zona_ID;
		public int Zona_ID
		{
			get { return _Zona_ID; }
			set { _Zona_ID = value; }
		}


		private int _TipoServicio_ID;
		public int TipoServicio_ID
		{
			get { return _TipoServicio_ID; }
			set { _TipoServicio_ID = value; }
		}

		private decimal _Tarifa;
		public decimal Tarifa
		{
			get { return _Tarifa; }
			set { _Tarifa = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Zona_ID", this.Zona_ID);
			m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			m_params.Add("Tarifa", this.Tarifa);

			return DB.InsertRow("Tarifas", m_params);
		} // End Create

		public static List<Tarifas> Read()
		{
			List<Tarifas> list = new List<Tarifas>();
			DataTable dt = DB.Select("Tarifas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"])));
			}

			return list;
		} // End Read

		public static Tarifas Read(int zona_id, int tiposervicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", zona_id);
			w_params.Add("TipoServicio_ID", tiposervicio_id);
			DataTable dt = DB.Select("Tarifas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Tarifas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"]));
		} // End Read

		public static Tarifas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Tarifas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"]));
		} // End Read

		public static bool Read(out Tarifas tarifas, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Tarifas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tarifas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tarifas = new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Tarifas");
		} // End Read

		public static DataTable ReadDataTable(int zona_id, int tiposervicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", zona_id);
			w_params.Add("TipoServicio_ID", tiposervicio_id);
			return DB.Select("Tarifas", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", this.Zona_ID);
			w_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			m_params.Add("Tarifa", this.Tarifa);

			return DB.UpdateRow("Tarifas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", this.Zona_ID);
			w_params.Add("TipoServicio_ID", this.TipoServicio_ID);

			return DB.DeleteRow("Tarifas", w_params);
		} // End Delete

	} //End Class Tarifas

	public class Tickets
	{
		public Tickets() { }

		public Tickets(
		  int ticket_id,
		  int sesion_id,
		  int caja_id,
		  string usuario_id,
		  int estatusticket_id,
		  int empresa_id,
		  int estacion_id,
		  int conductor_id,
		  int? unidad_id,
		  DateTime fecha)
		{
			this.Ticket_ID = ticket_id;
			this.Sesion_ID = sesion_id;
			this.Caja_ID = caja_id;
			this.Usuario_ID = usuario_id;
			this.EstatusTicket_ID = estatusticket_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.Conductor_ID = conductor_id;
			this.Unidad_ID = unidad_id;
			this.Fecha = fecha;
		}

		private int _Ticket_ID;
		public int Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int _Sesion_ID;
		public int Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private int _Caja_ID;
		public int Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _EstatusTicket_ID;
		public int EstatusTicket_ID
		{
			get { return _EstatusTicket_ID; }
			set { _EstatusTicket_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int? _Unidad_ID;
		public int? Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private int _folioSesion;
		public int FolioSesion
		{
			get { return _folioSesion; }
			set { _folioSesion = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Fecha", this.Fecha);

			int ret = DB.InsertRow("Tickets", m_params);

			if (ret == 0) throw new Exception("No se realizó la inserción del registro en la tabla Tickets");

			string sql = @"SELECT MAX(Ticket_ID) Ticket_ID FROM Tickets WHERE   Sesion_ID = @Sesion_ID";

			this.Ticket_ID = Convert.ToInt32(
			    DB.QueryScalar(
				   sql,
				   DB.GetParams(
					  DB.Param("@Sesion_ID", this.Sesion_ID)
				   )
			    )
			);

			return ret;
		} // End Create

		public static List<Tickets> Read()
		{
			List<Tickets> list = new List<Tickets>();
			DataTable dt = DB.Select("Tickets");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				new Tickets(
				    Convert.ToInt32(dr["Ticket_ID"]),
				    Convert.ToInt32(dr["Sesion_ID"]),
				    Convert.ToInt32(dr["Caja_ID"]),
				    Convert.ToString(dr["Usuario_ID"]),
				    Convert.ToInt32(dr["EstatusTicket_ID"]),
				    Convert.ToInt32(dr["Empresa_ID"]),
				    Convert.ToInt32(dr["Estacion_ID"]),
				    Convert.ToInt32(dr["Conductor_ID"]),
				    DB.GetNullableInt32(dr["Unidad_ID"]),
				    Convert.ToDateTime(dr["Fecha"])));
			}

			return list;
		} // End Read

		public static Tickets Read(int ticket_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", ticket_id);
			DataTable dt = DB.Select("Tickets", w_params);

			if (dt.Rows.Count == 0) return null;

			DataRow dr = dt.Rows[0];
			return new Tickets(
			    Convert.ToInt32(dr["Ticket_ID"]),
			    Convert.ToInt32(dr["Sesion_ID"]),
			    Convert.ToInt32(dr["Caja_ID"]),
			    Convert.ToString(dr["Usuario_ID"]),
			    Convert.ToInt32(dr["EstatusTicket_ID"]),
			    Convert.ToInt32(dr["Empresa_ID"]),
			    Convert.ToInt32(dr["Estacion_ID"]),
			    Convert.ToInt32(dr["Conductor_ID"]),
			    DB.GetNullableInt32(dr["Unidad_ID"]),
			    Convert.ToDateTime(dr["Fecha"])
			    );
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Caja_ID", this.Caja_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Fecha", this.Fecha);

			return DB.UpdateRow("Tickets", m_params, w_params);
		} // End Update

		public static void InsertaBitacoraTicket(Tickets t, int ncopia)
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Ticket_ID", t.Ticket_ID);
			m_params.Add("Sesion_ID", t.Sesion_ID);
			m_params.Add("Caja_ID", t.Caja_ID);
			m_params.Add("Usuario_ID", t.Usuario_ID);
			m_params.Add("EstatusTicket_ID", t.EstatusTicket_ID);
			m_params.Add("Empresa_ID", t.Empresa_ID);
			m_params.Add("Estacion_ID", t.Estacion_ID);
			m_params.Add("Conductor_ID", t.Conductor_ID);
			m_params.Add("Unidad_ID", t.Unidad_ID);
			m_params.Add("Fecha", t.Fecha);
			m_params.Add("NumCopia", ncopia);
			int ret = DB.InsertRow("TicketsBitacora", m_params);
			if (ret == 0) throw new Exception("No se realizó la inserción del registro en la tabla TicketsBitacora");
		}

		public static bool ExisteTicketEnDB(int ticket_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", ticket_id);
			int iCount = DB.GetCount("Tickets", w_params);
			return iCount > 0;
		}
		//public int Delete()
		//{
		//     Hashtable w_params = new Hashtable();
		//     w_params.Add("Ticket_ID", this.Ticket_ID);

		//     return DB.DeleteRow("Tickets", w_params);
		//}

	} //End Class Tickets

	public class TicketsCancelados
	{

		public TicketsCancelados()
		{
		}

		public TicketsCancelados(int ticket_id, string motivo, string usuario_id, DateTime fecha)
		{
			this.Ticket_ID = ticket_id;
			this.Motivo = motivo;
			this.Usuario_ID = usuario_id;
			this.Fecha = fecha;
		}

		private int _Ticket_ID;
		public int Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private string _Motivo;
		public string Motivo
		{
			get { return _Motivo; }
			set { _Motivo = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Motivo", this.Motivo);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);

			return DB.InsertRow("TicketsCancelados", m_params);
		} // End Create

		public static List<TicketsCancelados> Read()
		{
			List<TicketsCancelados> list = new List<TicketsCancelados>();
			DataTable dt = DB.Select("TicketsCancelados");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TicketsCancelados(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Motivo"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"])));
			}

			return list;
		} // End Read

		public static List<TicketsCancelados> Read(int ticket_id)
		{
			List<TicketsCancelados> list = new List<TicketsCancelados>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", ticket_id);
			DataTable dt = DB.Select("TicketsCancelados", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TicketsCancelados(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Motivo"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Motivo", this.Motivo);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Fecha", this.Fecha);

			return DB.UpdateRow("TicketsCancelados", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Ticket_ID", this.Ticket_ID);

			return DB.DeleteRow("TicketsCancelados", w_params);
		}

	} //End Class TicketsCancelados

	public class TiposAjustesInventario
	{

		#region Constructors

		public TiposAjustesInventario()
		{
		}

		public TiposAjustesInventario(
		    int tipoajusteinventario_id,
		    string nombre)
		{
			this.TipoAjusteInventario_ID = tipoajusteinventario_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _TipoAjusteInventario_ID;
		public int TipoAjusteInventario_ID
		{
			get { return _TipoAjusteInventario_ID; }
			set { _TipoAjusteInventario_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 10)
			{
				throw new Exception("Nombre debe tener máximo 10 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposAjustesInventario", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("TiposAjustesInventario", m_params);
		} // End Create

		public static List<TiposAjustesInventario> Read()
		{
			List<TiposAjustesInventario> list = new List<TiposAjustesInventario>();
			DataTable dt = DB.Select("TiposAjustesInventario");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new TiposAjustesInventario(
					   Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static TiposAjustesInventario Read(int tipoajusteinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAjusteInventario_ID", tipoajusteinventario_id);
			DataTable dt = DB.Select("TiposAjustesInventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposAjustesInventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposAjustesInventario(
			    Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static TiposAjustesInventario Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposAjustesInventario", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new TiposAjustesInventario(
			    Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out TiposAjustesInventario tiposajustesinventario,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposAjustesInventario", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tiposajustesinventario = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tiposajustesinventario = new TiposAjustesInventario(
			    Convert.ToInt32(dr["TipoAjusteInventario_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("TiposAjustesInventario");
		} // End Read

		public static DataTable ReadDataTable(int tipoajusteinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAjusteInventario_ID", tipoajusteinventario_id);
			return DB.Select("TiposAjustesInventario", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposAjustesInventario", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAjusteInventario_ID", this.TipoAjusteInventario_ID);

			return DB.DeleteRow("TiposAjustesInventario", w_params);
		} // End Delete


		#endregion
	} //End Class TiposAjustesInventario

	public class TiposAtencionClientes
	{

		#region Constructors

		public TiposAtencionClientes()
		{
		}

		public TiposAtencionClientes(
		    int tipoatencioncliente_id,
		    string nombre)
		{
			this.TipoAtencionCliente_ID = tipoatencioncliente_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _TipoAtencionCliente_ID;
		public int TipoAtencionCliente_ID
		{
			get { return _TipoAtencionCliente_ID; }
			set { _TipoAtencionCliente_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposAtencionClientes", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("TiposAtencionClientes", m_params);
		} // End Create

		public static List<TiposAtencionClientes> Read()
		{
			List<TiposAtencionClientes> list = new List<TiposAtencionClientes>();
			DataTable dt = DB.Select("TiposAtencionClientes");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new TiposAtencionClientes(
					   Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static TiposAtencionClientes Read(int tipoatencioncliente_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAtencionCliente_ID", tipoatencioncliente_id);
			DataTable dt = DB.Select("TiposAtencionClientes", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposAtencionClientes con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposAtencionClientes(
			    Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static TiposAtencionClientes Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposAtencionClientes", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new TiposAtencionClientes(
			    Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out TiposAtencionClientes tiposatencionclientes,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposAtencionClientes", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tiposatencionclientes = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tiposatencionclientes = new TiposAtencionClientes(
			    Convert.ToInt32(dr["TipoAtencionCliente_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("TiposAtencionClientes");
		} // End Read

		public static DataTable ReadDataTable(int tipoatencioncliente_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAtencionCliente_ID", tipoatencioncliente_id);
			return DB.Select("TiposAtencionClientes", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposAtencionClientes", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoAtencionCliente_ID", this.TipoAtencionCliente_ID);

			return DB.DeleteRow("TiposAtencionClientes", w_params);
		} // End Delete


		#endregion
	} //End Class TiposAtencionClientes

	public class TiposClientesTaller
	{

		#region Constructors

		public TiposClientesTaller()
		{
		}

		public TiposClientesTaller(
		    int tipoclientetaller_id,
		    int tipoempresa_id,
		    int? empresa_id,
		    string nombre)
		{
			this.TipoClienteTaller_ID = tipoclientetaller_id;
			this.TipoEmpresa_ID = tipoempresa_id;
			this.Empresa_ID = empresa_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _TipoClienteTaller_ID;
		public int TipoClienteTaller_ID
		{
			get { return _TipoClienteTaller_ID; }
			set { _TipoClienteTaller_ID = value; }
		}

		private int _TipoEmpresa_ID;
		public int TipoEmpresa_ID
		{
			get { return _TipoEmpresa_ID; }
			set { _TipoEmpresa_ID = value; }
		}

		private int? _Empresa_ID;
		public int? Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.TipoEmpresa_ID == 0) throw new Exception("TipoEmpresa_ID no puede ser nulo.");

			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!DB.IsNullOrEmpty(this.Empresa_ID)) m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposClientesTaller", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!DB.IsNullOrEmpty(this.Empresa_ID)) m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("TiposClientesTaller", m_params);
		} // End Create

		public static List<TiposClientesTaller> Read()
		{
			List<TiposClientesTaller> list = new List<TiposClientesTaller>();
			DataTable dt = DB.Select("TiposClientesTaller");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new TiposClientesTaller(
					   Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					   Convert.ToInt32(dr["TipoEmpresa_ID"]),
					   DB.GetNullableInt32(dr["Empresa_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static TiposClientesTaller Read(int tipoclientetaller_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoClienteTaller_ID", tipoclientetaller_id);
			DataTable dt = DB.Select("TiposClientesTaller", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposClientesTaller con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposClientesTaller(
			    Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToInt32(dr["TipoEmpresa_ID"]),
					  DB.GetNullableInt32(dr["Empresa_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static TiposClientesTaller Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposClientesTaller", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new TiposClientesTaller(
			    Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToInt32(dr["TipoEmpresa_ID"]),
					  DB.GetNullableInt32(dr["Empresa_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out TiposClientesTaller tiposclientestaller,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposClientesTaller", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tiposclientestaller = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tiposclientestaller = new TiposClientesTaller(
			    Convert.ToInt32(dr["TipoClienteTaller_ID"]),
					  Convert.ToInt32(dr["TipoEmpresa_ID"]),
					  DB.GetNullableInt32(dr["Empresa_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("TiposClientesTaller");
		} // End Read

		public static DataTable ReadDataTable(int tipoclientetaller_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoClienteTaller_ID", tipoclientetaller_id);
			return DB.Select("TiposClientesTaller", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
			m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			if (!DB.IsNullOrEmpty(this.Empresa_ID)) m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposClientesTaller", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);

			return DB.DeleteRow("TiposClientesTaller", w_params);
		} // End Delete


		#endregion
	} //End Class TiposClientesTaller

	public class TiposComisiones
	{

		public TiposComisiones()
		{
		}

		public TiposComisiones(int tipocomision_id, string nombre)
		{
			this.TipoComision_ID = tipocomision_id;
			this.Nombre = nombre;
		}

		private int _TipoComision_ID;
		public int TipoComision_ID
		{
			get { return _TipoComision_ID; }
			set { _TipoComision_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposComisiones", m_params);
		} // End Create

		public static List<TiposComisiones> Read()
		{
			List<TiposComisiones> list = new List<TiposComisiones>();
			DataTable dt = DB.Select("TiposComisiones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposComisiones(Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposComisiones> Read(int tipocomision_id)
		{
			List<TiposComisiones> list = new List<TiposComisiones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoComision_ID", tipocomision_id);
			DataTable dt = DB.Select("TiposComisiones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposComisiones(Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoComision_ID", this.TipoComision_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposComisiones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoComision_ID", this.TipoComision_ID);

			return DB.DeleteRow("TiposComisiones", w_params);
		}

	} //End Class TiposComisiones

	public class TiposConcesiones
	{

		public TiposConcesiones()
		{
		}

		public TiposConcesiones(int tipoconcesion_id, string nombre)
		{
			this.TipoConcesion_ID = tipoconcesion_id;
			this.Nombre = nombre;
		}

		private int _TipoConcesion_ID;
		public int TipoConcesion_ID
		{
			get { return _TipoConcesion_ID; }
			set { _TipoConcesion_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposConcesiones", m_params);
		} // End Create

		public static List<TiposConcesiones> Read()
		{
			List<TiposConcesiones> list = new List<TiposConcesiones>();
			DataTable dt = DB.Select("TiposConcesiones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposConcesiones(Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposConcesiones> Read(int tipoconcesion_id)
		{
			List<TiposConcesiones> list = new List<TiposConcesiones>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoConcesion_ID", tipoconcesion_id);
			DataTable dt = DB.Select("TiposConcesiones", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposConcesiones(Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposConcesiones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);

			return DB.DeleteRow("TiposConcesiones", w_params);
		}

	} //End Class TiposConcesiones

	public class TiposContratos
	{

		public TiposContratos()
		{
		}

		public TiposContratos(int tipocontrato_id, string nombre)
		{
			this.TipoContrato_ID = tipocontrato_id;
			this.Nombre = nombre;
		}

		private int _TipoContrato_ID;
		public int TipoContrato_ID
		{
			get { return _TipoContrato_ID; }
			set { _TipoContrato_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposContratos", m_params);
		} // End Create

		public static List<TiposContratos> Read()
		{
			List<TiposContratos> list = new List<TiposContratos>();
			DataTable dt = DB.Select("TiposContratos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposContratos(Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposContratos> Read(int tipocontrato_id)
		{
			List<TiposContratos> list = new List<TiposContratos>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoContrato_ID", tipocontrato_id);
			DataTable dt = DB.Select("TiposContratos", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposContratos(Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposContratos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoContrato_ID", this.TipoContrato_ID);

			return DB.DeleteRow("TiposContratos", w_params);
		}

	} //End Class TiposContratos

	public class TiposCuentas
	{

		public TiposCuentas()
		{
		}

		public TiposCuentas(string tipocuenta_id, string descripcion, string comentarios)
		{
			this.TipoCuenta_ID = tipocuenta_id;
			this.Descripcion = descripcion;
			this.Comentarios = comentarios;
		}

		private string _TipoCuenta_ID;
		public string TipoCuenta_ID
		{
			get { return _TipoCuenta_ID; }
			set { _TipoCuenta_ID = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("TiposCuentas", m_params);
		} // End Create

		public static List<TiposCuentas> Read()
		{
			List<TiposCuentas> list = new List<TiposCuentas>();
			DataTable dt = DB.Select("TiposCuentas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposCuentas(Convert.ToString(dr["TipoCuenta_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public static List<TiposCuentas> Read(string tipocuenta_id)
		{
			List<TiposCuentas> list = new List<TiposCuentas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoCuenta_ID", tipocuenta_id);
			DataTable dt = DB.Select("TiposCuentas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposCuentas(Convert.ToString(dr["TipoCuenta_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Comentarios"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);
			m_params.Add("Descripcion", this.Descripcion);
			m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("TiposCuentas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);

			return DB.DeleteRow("TiposCuentas", w_params);
		}

	} //End Class TiposCuentas

	public class TiposEmpresas
	{

		public TiposEmpresas()
		{
		}

		public TiposEmpresas(int tipoempresa_id, string nombre)
		{
			this.TipoEmpresa_ID = tipoempresa_id;
			this.Nombre = nombre;
		}

		private int _TipoEmpresa_ID;
		public int TipoEmpresa_ID
		{
			get { return _TipoEmpresa_ID; }
			set { _TipoEmpresa_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposEmpresas", m_params);
		} // End Create

		public static List<TiposEmpresas> Read()
		{
			List<TiposEmpresas> list = new List<TiposEmpresas>();
			DataTable dt = DB.Select("TiposEmpresas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposEmpresas(Convert.ToInt32(dr["TipoEmpresa_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposEmpresas> Read(int tipoempresa_id)
		{
			List<TiposEmpresas> list = new List<TiposEmpresas>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoEmpresa_ID", tipoempresa_id);
			DataTable dt = DB.Select("TiposEmpresas", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposEmpresas(Convert.ToInt32(dr["TipoEmpresa_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposEmpresas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);

			return DB.DeleteRow("TiposEmpresas", w_params);
		}

	} //End Class TiposEmpresas

	public class TiposIncidencias
	{

		#region Constructors

		public TiposIncidencias()
		{
		}

		public TiposIncidencias(
		    int tipoincidencia_id,
		    string nombre)
		{
			this.TipoIncidencia_ID = tipoincidencia_id;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties

		private int _TipoIncidencia_ID;
		public int TipoIncidencia_ID
		{
			get { return _TipoIncidencia_ID; }
			set { _TipoIncidencia_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Nombre == null) throw new Exception("Nombre no puede ser nulo.");

			if (this.Nombre.Length > 30)
			{
				throw new Exception("Nombre debe tener máximo 30 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposIncidencias", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("TiposIncidencias", m_params);
		} // End Create

		public static List<TiposIncidencias> Read()
		{
			List<TiposIncidencias> list = new List<TiposIncidencias>();
			DataTable dt = DB.Select("TiposIncidencias");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new TiposIncidencias(
					   Convert.ToInt32(dr["TipoIncidencia_ID"]),
					   Convert.ToString(dr["Nombre"])
				    )
				);
			}

			return list;
		} // End Read

		public static TiposIncidencias Read(int tipoincidencia_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoIncidencia_ID", tipoincidencia_id);
			DataTable dt = DB.Select("TiposIncidencias", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposIncidencias con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposIncidencias(
			    Convert.ToInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static TiposIncidencias Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposIncidencias", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new TiposIncidencias(
			    Convert.ToInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
		} // End Read

		public static bool Read(
		    out TiposIncidencias tiposincidencias,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposIncidencias", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tiposincidencias = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tiposincidencias = new TiposIncidencias(
			    Convert.ToInt32(dr["TipoIncidencia_ID"]),
					  Convert.ToString(dr["Nombre"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("TiposIncidencias");
		} // End Read

		public static DataTable ReadDataTable(int tipoincidencia_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoIncidencia_ID", tipoincidencia_id);
			return DB.Select("TiposIncidencias", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposIncidencias", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoIncidencia_ID", this.TipoIncidencia_ID);

			return DB.DeleteRow("TiposIncidencias", w_params);
		} // End Delete


		#endregion
	} //End Class TiposIncidencias

	public class TiposLicencias
	{

		public TiposLicencias()
		{
		}

		public TiposLicencias(int tipolicencia_id, string nombre)
		{
			this.TipoLicencia_ID = tipolicencia_id;
			this.Nombre = nombre;
		}

		private int _TipoLicencia_ID;
		public int TipoLicencia_ID
		{
			get { return _TipoLicencia_ID; }
			set { _TipoLicencia_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposLicencias", m_params);
		} // End Create

		public static List<TiposLicencias> Read()
		{
			List<TiposLicencias> list = new List<TiposLicencias>();
			DataTable dt = DB.Select("TiposLicencias");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposLicencias(Convert.ToInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposLicencias> Read(int tipolicencia_id)
		{
			List<TiposLicencias> list = new List<TiposLicencias>();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoLicencia_ID", tipolicencia_id);
			DataTable dt = DB.Select("TiposLicencias", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposLicencias(Convert.ToInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposLicencias", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);

			return DB.DeleteRow("TiposLicencias", w_params);
		}

	} //End Class TiposLicencias

	public class TiposMantenimientos
	{

		public TiposMantenimientos()
		{
		}

		public TiposMantenimientos(int tipomantenimiento_id, string nombre, bool activo)
		{
			this.TipoMantenimiento_ID = tipomantenimiento_id;
			this.Nombre = nombre;
			this.Activo = activo;
		}

		private int _TipoMantenimiento_ID;
		public int TipoMantenimiento_ID
		{
			get { return _TipoMantenimiento_ID; }
			set { _TipoMantenimiento_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Activo", this.Activo);

			return DB.InsertRow("TiposMantenimientos", m_params);
		} // End Create

		public static List<TiposMantenimientos> Read()
		{
			List<TiposMantenimientos> list = new List<TiposMantenimientos>();
			DataTable dt = DB.Select("TiposMantenimientos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposMantenimientos(Convert.ToInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activo"])));
			}

			return list;
		} // End Read

		public static TiposMantenimientos Read(int tipomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMantenimiento_ID", tipomantenimiento_id);
			DataTable dt = DB.Select("TiposMantenimientos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposMantenimientos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposMantenimientos(Convert.ToInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activo"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Activo", this.Activo);

			return DB.UpdateRow("TiposMantenimientos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);

			return DB.DeleteRow("TiposMantenimientos", w_params);
		} // End Delete

	} //End Class TiposMantenimientos

	public class TiposMovimientosInventario
	{

		public TiposMovimientosInventario()
		{
		}

		public TiposMovimientosInventario(int tipomovimientoinventario_id, string nombre)
		{
			this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
			this.Nombre = nombre;
		}

		private int _TipoMovimientoInventario_ID;
		public int TipoMovimientoInventario_ID
		{
			get { return _TipoMovimientoInventario_ID; }
			set { _TipoMovimientoInventario_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposMovimientosInventario", m_params);
		} // End Create

		public static List<TiposMovimientosInventario> Read()
		{
			List<TiposMovimientosInventario> list = new List<TiposMovimientosInventario>();
			DataTable dt = DB.Select("TiposMovimientosInventario");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposMovimientosInventario(Convert.ToInt32(dr["TipoMovimientoInventario_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static TiposMovimientosInventario Read(int tipomovimientoinventario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMovimientoInventario_ID", tipomovimientoinventario_id);
			DataTable dt = DB.Select("TiposMovimientosInventario", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposMovimientosInventario con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposMovimientosInventario(Convert.ToInt32(dr["TipoMovimientoInventario_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposMovimientosInventario", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);

			return DB.DeleteRow("TiposMovimientosInventario", w_params);
		} // End Delete

	} //End Class TiposMovimientosInventario

	public class TiposRefacciones
	{

		public TiposRefacciones()
		{
		}

		public TiposRefacciones(int tiporefaccion_id, int familia_id, string nombre)
		{
			this.TipoRefaccion_ID = tiporefaccion_id;
			this.Familia_ID = familia_id;
			this.Nombre = nombre;
		}

		private int _TipoRefaccion_ID;
		public int TipoRefaccion_ID
		{
			get { return _TipoRefaccion_ID; }
			set { _TipoRefaccion_ID = value; }
		}

		private int _Familia_ID;
		public int Familia_ID
		{
			get { return _Familia_ID; }
			set { _Familia_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposRefacciones", m_params);
		} // End Create

		public static List<TiposRefacciones> ReadList(params KeyValuePair<string, object>[] args)
		{
			List<TiposRefacciones> list = new List<TiposRefacciones>();
			DataTable dt = DB.Read("TiposRefacciones", args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposRefacciones> Read()
		{
			List<TiposRefacciones> list = new List<TiposRefacciones>();
			DataTable dt = DB.Select("TiposRefacciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposRefacciones> ReadOrderByNombre()
		{
			List<TiposRefacciones> list = new List<TiposRefacciones>();
			DataTable dt = DB.Read("TiposRefacciones", "", "Nombre");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<TiposRefacciones> Read(string nombre)
		{
			List<TiposRefacciones> list = new List<TiposRefacciones>();

			DataTable dt =
			    DB.QueryCommand(
				   "SELECT * FROM TiposRefacciones WHERE ( @Nombre IS NULL OR Nombre LIKE @Nombre + '%' )",
				   DB.GetParams(
					  DB.Param("@Nombre", nombre)
				   )
			    );

			if (dt.Rows.Count == 0) return null;

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static TiposRefacciones Read(int tiporefaccion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoRefaccion_ID", tiporefaccion_id);
			DataTable dt = DB.Select("TiposRefacciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposRefacciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
			m_params.Add("Familia_ID", this.Familia_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposRefacciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);

			return DB.DeleteRow("TiposRefacciones", w_params);
		} // End Delete

	} //End Class TiposRefacciones

	public class TiposReportes
	{

		public TiposReportes()
		{
		}

		public TiposReportes(int tiporeporte_id, string nombre)
		{
			this.TipoReporte_ID = tiporeporte_id;
			this.Nombre = nombre;
		}

		private int _TipoReporte_ID;
		public int TipoReporte_ID
		{
			get { return _TipoReporte_ID; }
			set { _TipoReporte_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposReportes", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoReporte_ID", this.TipoReporte_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.IdentityInsertRow("TiposReportes", m_params);
		} // End Create

		public static List<TiposReportes> Read()
		{
			List<TiposReportes> list = new List<TiposReportes>();
			DataTable dt = DB.Select("TiposReportes");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposReportes(Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static TiposReportes Read(int tiporeporte_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoReporte_ID", tiporeporte_id);
			DataTable dt = DB.Select("TiposReportes", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposReportes con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposReportes(Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static TiposReportes Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposReportes", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new TiposReportes(Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static bool Read(out TiposReportes tiposreportes, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("TiposReportes", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				tiposreportes = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			tiposreportes = new TiposReportes(Convert.ToInt32(dr["TipoReporte_ID"]), Convert.ToString(dr["Nombre"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("TiposReportes");
		} // End Read

		public static DataTable ReadDataTable(int tiporeporte_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoReporte_ID", tiporeporte_id);
			return DB.Select("TiposReportes", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoReporte_ID", this.TipoReporte_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposReportes", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoReporte_ID", this.TipoReporte_ID);

			return DB.DeleteRow("TiposReportes", w_params);
		} // End Delete

	} //End Class TiposReportes

	public class TiposServicios
	{

		public TiposServicios()
		{
		}

		public TiposServicios(int tiposervicio_id, string nombre, int? cuenta_id)
		{
			this.TipoServicio_ID = tiposervicio_id;
			this.Nombre = nombre;
			this.Cuenta_ID = cuenta_id;
		}

		private int _TipoServicio_ID;
		public int TipoServicio_ID
		{
			get { return _TipoServicio_ID; }
			set { _TipoServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private int? _Cuenta_ID;
		public int? Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);

			return DB.InsertRow("TiposServicios", m_params);
		} // End Create

		public static List<TiposServicios> Read()
		{
			List<TiposServicios> list = new List<TiposServicios>();
			DataTable dt = DB.Select("TiposServicios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposServicios(Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableInt32(dr["Cuenta_ID"])));
			}

			return list;
		} // End Read

		public static TiposServicios Read(int tiposervicio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicio_ID", tiposervicio_id);
			DataTable dt = DB.Select("TiposServicios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposServicios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposServicios(Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableInt32(dr["Cuenta_ID"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);

			return DB.UpdateRow("TiposServicios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicio_ID", this.TipoServicio_ID);

			return DB.DeleteRow("TiposServicios", w_params);
		} // End Delete

	} //End Class TiposServicios

	public class TiposServiciosConductores
	{

		public TiposServiciosConductores()
		{
		}

		public TiposServiciosConductores(int tiposervicioconductor_id, int? comisionservicio_id, int? cuenta_id, int estatustiposervicioconductor_id, string nombre, decimal? precio, bool esvalidocarrera, bool esexclusivoconductor, bool esesquemaporcentual)
		{
			this.TipoServicioConductor_ID = tiposervicioconductor_id;
			this.ComisionServicio_ID = comisionservicio_id;
			this.Cuenta_ID = cuenta_id;
			this.EstatusTipoServicioConductor_ID = estatustiposervicioconductor_id;
			this.Nombre = nombre;
			this.Precio = precio;
			this.EsValidoCarrera = esvalidocarrera;
			this.EsExclusivoConductor = esexclusivoconductor;
			this.EsEsquemaPorcentual = esesquemaporcentual;
		}

		private int _TipoServicioConductor_ID;
		public int TipoServicioConductor_ID
		{
			get { return _TipoServicioConductor_ID; }
			set { _TipoServicioConductor_ID = value; }
		}

		private int? _ComisionServicio_ID;
		public int? ComisionServicio_ID
		{
			get { return _ComisionServicio_ID; }
			set { _ComisionServicio_ID = value; }
		}

		private int? _Cuenta_ID;
		public int? Cuenta_ID
		{
			get { return _Cuenta_ID; }
			set { _Cuenta_ID = value; }
		}

		private int _EstatusTipoServicioConductor_ID;
		public int EstatusTipoServicioConductor_ID
		{
			get { return _EstatusTipoServicioConductor_ID; }
			set { _EstatusTipoServicioConductor_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private decimal? _Precio;
		public decimal? Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private bool _EsValidoCarrera;
		public bool EsValidoCarrera
		{
			get { return _EsValidoCarrera; }
			set { _EsValidoCarrera = value; }
		}

		private bool _EsExclusivoConductor;
		public bool EsExclusivoConductor
		{
			get { return _EsExclusivoConductor; }
			set { _EsExclusivoConductor = value; }
		}

		private bool _EsEsquemaPorcentual;
		public bool EsEsquemaPorcentual
		{
			get { return _EsEsquemaPorcentual; }
			set { _EsEsquemaPorcentual = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("EstatusTipoServicioConductor_ID", this.EstatusTipoServicioConductor_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Precio", this.Precio);
			m_params.Add("EsValidoCarrera", this.EsValidoCarrera);
			m_params.Add("EsExclusivoConductor", this.EsExclusivoConductor);
			m_params.Add("EsEsquemaPorcentual", this.EsEsquemaPorcentual);

			return DB.InsertRow("TiposServiciosConductores", m_params);
		} // End Create

		public static List<TiposServiciosConductores> Read()
		{
			List<TiposServiciosConductores> list = new List<TiposServiciosConductores>();
			DataTable dt = DB.Select("TiposServiciosConductores");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposServiciosConductores(Convert.ToInt32(dr["TipoServicioConductor_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["EstatusTipoServicioConductor_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToBoolean(dr["EsValidoCarrera"]), Convert.ToBoolean(dr["EsExclusivoConductor"]), Convert.ToBoolean(dr["EsEsquemaPorcentual"])));
			}

			return list;
		} // End Read

		public static TiposServiciosConductores Read(int tiposervicioconductor_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioConductor_ID", tiposervicioconductor_id);
			DataTable dt = DB.Select("TiposServiciosConductores", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposServiciosConductores con id = los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposServiciosConductores(Convert.ToInt32(dr["TipoServicioConductor_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["EstatusTipoServicioConductor_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToBoolean(dr["EsValidoCarrera"]), Convert.ToBoolean(dr["EsExclusivoConductor"]), Convert.ToBoolean(dr["EsEsquemaPorcentual"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Cuenta_ID", this.Cuenta_ID);
			m_params.Add("EstatusTipoServicioConductor_ID", this.EstatusTipoServicioConductor_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Precio", this.Precio);
			m_params.Add("EsValidoCarrera", this.EsValidoCarrera);
			m_params.Add("EsExclusivoConductor", this.EsExclusivoConductor);
			m_params.Add("EsEsquemaPorcentual", this.EsEsquemaPorcentual);

			return DB.UpdateRow("TiposServiciosConductores", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);

			return DB.DeleteRow("TiposServiciosConductores", w_params);
		} // End Delete

	} //End Class TiposServiciosConductores

	public class TiposServiciosMantenimientos
	{

		public TiposServiciosMantenimientos()
		{
		}

		public TiposServiciosMantenimientos(int tiposerviciomantenimiento_id, string nombre)
		{
			this.TipoServicioMantenimiento_ID = tiposerviciomantenimiento_id;
			this.Nombre = nombre;
		}

		private int _TipoServicioMantenimiento_ID;
		public int TipoServicioMantenimiento_ID
		{
			get { return _TipoServicioMantenimiento_ID; }
			set { _TipoServicioMantenimiento_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposServiciosMantenimientos", m_params);
		} // End Create

		public static List<TiposServiciosMantenimientos> Read()
		{
			List<TiposServiciosMantenimientos> list = new List<TiposServiciosMantenimientos>();
			DataTable dt = DB.Select("TiposServiciosMantenimientos");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposServiciosMantenimientos(Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static TiposServiciosMantenimientos Read(int tiposerviciomantenimiento_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioMantenimiento_ID", tiposerviciomantenimiento_id);
			DataTable dt = DB.Select("TiposServiciosMantenimientos", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposServiciosMantenimientos con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposServiciosMantenimientos(Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposServiciosMantenimientos", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);

			return DB.DeleteRow("TiposServiciosMantenimientos", w_params);
		} // End Delete

	} //End Class TiposServiciosMantenimientos

	public class TiposVenta
	{
		public TiposVenta()
		{
		}

		public TiposVenta(int tipoventa_id, int? comisionservicio_id, string nombre)
		{
		}

		private int _TipoVenta_ID;
		public int TipoVenta_ID
		{
			get { return _TipoVenta_ID; }
			set { _TipoVenta_ID = value; }
		}

		private int? _ComisionServicio_ID;
		public int? ComisionServicio_ID
		{
			get { return _ComisionServicio_ID; }
			set { _ComisionServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		//private ComisionesServicios _ComisionesServicios;
		//public ComisionesServicios ComisionesServicios
		//{
		//    get 
		//    {
		//        List<ComisionesServicios> list = new List<ComisionesServicios>();
		//        Hashtable w_params = new Hashtable();
		//        w_params.Add("ComisionServicio_ID", comisionservicio_id);
		//        DataTable dt = DB.Select("ComisionesServicios", w_params);
		//        foreach (DataRow dr in dt.Rows)
		//        {
		//            list.Add(new ComisionesServicios(Convert.ToInt32(dr["ComisionServicio_ID"]), Convert.ToInt32(dr["Comisionista_ID"]), Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToDecimal(dr["Monto"])));
		//        }

		//        return list;
		//    }
		//}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("TiposZonas", m_params);
		} // End Create

		public static List<TiposVenta> Read()
		{
			List<TiposVenta> list = new List<TiposVenta>();
			DataTable dt = DB.Select("TiposVenta");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static TiposVenta Read(int tipoventa_id)
		{
			List<TiposVenta> list = new List<TiposVenta>();

			Hashtable w_params = new Hashtable();
			w_params.Add("TipoVenta_ID", tipoventa_id);
			DataTable dt = DB.Select("TiposVenta", w_params);

			if (dt.Rows.Count == 0)
			{
				throw new Exception(String.Format("No existen tipos de venta con el TipoVenta_ID = {0}", tipoventa_id));
			}

			DataRow dr = dt.Rows[0];
			return new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]));

		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoVenta_ID", this.TipoVenta_ID);
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("TiposVenta", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoVenta_ID", this.TipoVenta_ID);

			return DB.DeleteRow("TiposVenta", w_params);
		} // End Delete

	} //End Class TiposVenta

	public class TiposZonas
	{

		public TiposZonas()
		{
		}

		public TiposZonas(int tipozona_id, string nombre, bool esacreditable)
		{
			this.TipoZona_ID = tipozona_id;
			this.Nombre = nombre;
			this.EsAcreditable = esacreditable;
		}

		private int _TipoZona_ID;
		public int TipoZona_ID
		{
			get { return _TipoZona_ID; }
			set { _TipoZona_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private bool _EsAcreditable;
		public bool EsAcreditable
		{
			get { return _EsAcreditable; }
			set { _EsAcreditable = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EsAcreditable", this.EsAcreditable);

			return DB.InsertRow("TiposZonas", m_params);
		} // End Create

		public static List<TiposZonas> Read()
		{
			List<TiposZonas> list = new List<TiposZonas>();
			DataTable dt = DB.Select("TiposZonas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new TiposZonas(Convert.ToInt32(dr["TipoZona_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EsAcreditable"])));
			}

			return list;
		} // End Read

		public static TiposZonas Read(int tipozona_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoZona_ID", tipozona_id);
			DataTable dt = DB.Select("TiposZonas", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe TiposZonas con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new TiposZonas(Convert.ToInt32(dr["TipoZona_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EsAcreditable"]));
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoZona_ID", this.TipoZona_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("EsAcreditable", this.EsAcreditable);

			return DB.UpdateRow("TiposZonas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("TipoZona_ID", this.TipoZona_ID);

			return DB.DeleteRow("TiposZonas", w_params);
		} // End Delete

	} //End Class TiposZonas

	public class Unidades
	{

		#region Constructors

		public Unidades()
		{
		}

		public Unidades(
		    int unidad_id,
		    int empresa_id,
		    int estacion_id,
		    int numeroeconomico,
		    int modelounidad_id,
		    decimal preciolista,
		    string numeroserie,
		    string numeroseriemotor,
		    string tarjetacirculacion,
		    int estatusunidad_id,
		    int locacionunidad_id,
		    string placas,
		    int? kilometraje,
		    int propietario_id,
		    int? arrendamiento_id,
		    int? concesion_id,
		    int? referencia_id,
		    int? conductoroperativo_id,
		    string gps,
		    int? estatusoperativounidad_id,
		    DateTime? ultimaactualizacion,
			DateTime? fechacompra)
		{
			this.Unidad_ID = unidad_id;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
			this.NumeroEconomico = numeroeconomico;
			this.ModeloUnidad_ID = modelounidad_id;
			this.PrecioLista = preciolista;
			this.NumeroSerie = numeroserie;
			this.NumeroSerieMotor = numeroseriemotor;
			this.TarjetaCirculacion = tarjetacirculacion;
			this.EstatusUnidad_ID = estatusunidad_id;
			this.LocacionUnidad_ID = locacionunidad_id;
			this.Placas = placas;
			this.Kilometraje = kilometraje;
			this.Propietario_ID = propietario_id;
			this.Arrendamiento_ID = arrendamiento_id;
			this.Concesion_ID = concesion_id;
			this.Referencia_ID = referencia_id;
			this.ConductorOperativo_ID = conductoroperativo_id;
			this.GPS = gps;
			this.EstatusOperativoUnidad_ID = estatusoperativounidad_id;
			this.UltimaActualizacion = ultimaactualizacion;
			this.FechaCompra = fechacompra;
		}

		#endregion

		#region Properties

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private int _NumeroEconomico;
		public int NumeroEconomico
		{
			get { return _NumeroEconomico; }
			set { _NumeroEconomico = value; }
		}

		private int _ModeloUnidad_ID;
		public int ModeloUnidad_ID
		{
			get { return _ModeloUnidad_ID; }
			set { _ModeloUnidad_ID = value; }
		}

		private decimal _PrecioLista;
		public decimal PrecioLista
		{
			get { return _PrecioLista; }
			set { _PrecioLista = value; }
		}

		private string _NumeroSerie;
		public string NumeroSerie
		{
			get { return _NumeroSerie; }
			set { _NumeroSerie = value; }
		}

		private string _NumeroSerieMotor;
		public string NumeroSerieMotor
		{
			get { return _NumeroSerieMotor; }
			set { _NumeroSerieMotor = value; }
		}

		private string _TarjetaCirculacion;
		public string TarjetaCirculacion
		{
			get { return _TarjetaCirculacion; }
			set { _TarjetaCirculacion = value; }
		}

		private int _EstatusUnidad_ID;
		public int EstatusUnidad_ID
		{
			get { return _EstatusUnidad_ID; }
			set { _EstatusUnidad_ID = value; }
		}

		private int _LocacionUnidad_ID;
		public int LocacionUnidad_ID
		{
			get { return _LocacionUnidad_ID; }
			set { _LocacionUnidad_ID = value; }
		}

		private string _Placas;
		public string Placas
		{
			get { return _Placas; }
			set { _Placas = value; }
		}

		private int? _Kilometraje;
		public int? Kilometraje
		{
			get { return _Kilometraje; }
			set { _Kilometraje = value; }
		}

		private int _Propietario_ID;
		public int Propietario_ID
		{
			get { return _Propietario_ID; }
			set { _Propietario_ID = value; }
		}

		private int? _Arrendamiento_ID;
		public int? Arrendamiento_ID
		{
			get { return _Arrendamiento_ID; }
			set { _Arrendamiento_ID = value; }
		}

		private int? _Concesion_ID;
		public int? Concesion_ID
		{
			get { return _Concesion_ID; }
			set { _Concesion_ID = value; }
		}

		private int? _Referencia_ID;
		public int? Referencia_ID
		{
			get { return _Referencia_ID; }
			set { _Referencia_ID = value; }
		}

		private int? _ConductorOperativo_ID;
		public int? ConductorOperativo_ID
		{
			get { return _ConductorOperativo_ID; }
			set { _ConductorOperativo_ID = value; }
		}

		private string _GPS;
		public string GPS
		{
			get { return _GPS; }
			set { _GPS = value; }
		}

		private int? _EstatusOperativoUnidad_ID;
		public int? EstatusOperativoUnidad_ID
		{
			get { return _EstatusOperativoUnidad_ID; }
			set { _EstatusOperativoUnidad_ID = value; }
		}

		private DateTime? _UltimaActualizacion;
		public DateTime? UltimaActualizacion
		{
			get { return _UltimaActualizacion; }
			set { _UltimaActualizacion = value; }
		}

		private DateTime? _FechaCompra;
		public DateTime? FechaCompra
		{
			get { return _FechaCompra; }
			set { _FechaCompra = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");

			if (this.NumeroEconomico == 0) throw new Exception("NumeroEconomico no puede ser 0.");

			if (this.ModeloUnidad_ID == 0) throw new Exception("ModeloUnidad_ID no puede ser nulo.");

			if (this.PrecioLista == 0) throw new Exception("PrecioLista no puede ser 0.");

			if (String.IsNullOrEmpty(this.NumeroSerie)) throw new Exception("NumeroSerie no puede estar vacío.");
			if (!Regex.IsMatch(this.NumeroSerie.ToUpper().Trim(), @"^[A-H,J-N,P,R-Z,0-9]{9}[A-H,J-N,P,R-T,V-Y,1-9][A-H,J-N,P,R-Z,0-9][0-9]{6}$")) throw new Exception("Número de Serie Inválido, favor de revisar el formato.");

			//if (this.NumeroSerie.Length > 50) throw new Exception("NumeroSerie debe tener máximo 50 carateres.");

			if (this.NumeroSerieMotor == null) throw new Exception("NumeroSerieMotor no puede ser nulo.");

			if (this.NumeroSerieMotor.Length > 50)
			{
				throw new Exception("NumeroSerieMotor debe tener máximo 50 carateres.");
			}

			if (this.TarjetaCirculacion == null) throw new Exception("TarjetaCirculacion no puede ser nulo.");

			if (this.TarjetaCirculacion.Length > 50)
			{
				throw new Exception("TarjetaCirculacion debe tener máximo 50 carateres.");
			}

			if (this.EstatusUnidad_ID == 0) throw new Exception("EstatusUnidad_ID no puede ser nulo.");

			if (this.LocacionUnidad_ID == 0) throw new Exception("LocacionUnidad_ID no puede ser nulo.");

			if (this.Placas == null) throw new Exception("Placas no puede ser nulo.");

			if (this.Placas.Length > 30)
			{
				throw new Exception("Placas debe tener máximo 30 carateres.");
			}

			if (this.Propietario_ID == 0) throw new Exception("Propietario_ID no puede ser nulo.");

			if (!string.IsNullOrEmpty(this.GPS))
			{
				if (this.GPS.Length > 30)
				{
					throw new Exception("GPS debe tener máximo 30 carateres.");
				}
			}
		} // End Validate

		private void Validate_Keys()
		{
			//  Verificamos que no exista el número de serie
			if (DB.Exists("Unidades", DB.Param("NumeroSerie", this.NumeroSerie.ToUpper().Trim())))
			{
				throw new Exception("El número de serie ya existe");
			}

			//  Verificamos que no exista el número economico por empresa
			string sql = @"SELECT Unidad_ID
FROM    Unidades
WHERE   NumeroEconomico = @NumeroEconomico
AND     Empresa_ID = @Empresa_ID
AND     EstatusUnidad_ID <> 5";

			Hashtable m_params = new Hashtable();
			m_params.Add("@NumeroEconomico", this.NumeroEconomico);
			m_params.Add("@Empresa_ID", this.Empresa_ID);

			DataTable dt = DB.QueryCommand(sql, m_params);

			if (dt.Rows.Count > 0)
			{
				throw new Exception(string.Format("El número economico '{0}' ya existe", this.NumeroEconomico));
			}
		}

		public int Create()
		{
			this.Validate();
			this.Validate_Keys();

			Hashtable m_params = new Hashtable();
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("NumeroSerie", this.NumeroSerie.ToUpper().Trim());
			m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
			m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Placas", this.Placas);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			m_params.Add("Propietario_ID", this.Propietario_ID);
			if (!DB.IsNullOrEmpty(this.Arrendamiento_ID)) m_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
			if (!DB.IsNullOrEmpty(this.Concesion_ID)) m_params.Add("Concesion_ID", this.Concesion_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ConductorOperativo_ID)) m_params.Add("ConductorOperativo_ID", this.ConductorOperativo_ID);
			if (!DB.IsNullOrEmpty(this.GPS)) m_params.Add("GPS", this.GPS);
			if (!DB.IsNullOrEmpty(this.EstatusOperativoUnidad_ID)) m_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);
			if (!DB.IsNullOrEmpty(this.UltimaActualizacion)) m_params.Add("UltimaActualizacion", this.UltimaActualizacion);
			if (!DB.IsNullOrEmpty(this.FechaCompra)) m_params.Add("FechaCompra", this.FechaCompra);
			int result = DB.InsertRow("Unidades", m_params);
			this.Unidad_ID = Convert.ToInt32(DB.Ident_Current("Unidades"));
			return result;
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			this.Validate();
			this.Validate_Keys();

			if (!IsIdentityInsert) return Create();

			Hashtable m_params = new Hashtable();
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("NumeroSerie", this.NumeroSerie.ToUpper().Trim());
			m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
			m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Placas", this.Placas);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			m_params.Add("Propietario_ID", this.Propietario_ID);
			if (!DB.IsNullOrEmpty(this.Arrendamiento_ID)) m_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
			if (!DB.IsNullOrEmpty(this.Concesion_ID)) m_params.Add("Concesion_ID", this.Concesion_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ConductorOperativo_ID)) m_params.Add("ConductorOperativo_ID", this.ConductorOperativo_ID);
			if (!DB.IsNullOrEmpty(this.GPS)) m_params.Add("GPS", this.GPS);
			if (!DB.IsNullOrEmpty(this.EstatusOperativoUnidad_ID)) m_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);
			if (!DB.IsNullOrEmpty(this.UltimaActualizacion)) m_params.Add("UltimaActualizacion", this.UltimaActualizacion);
			if (!DB.IsNullOrEmpty(this.FechaCompra)) m_params.Add("FechaCompra", this.FechaCompra);
			
			int result = DB.IdentityInsertRow("Unidades", m_params);
			this.Unidad_ID = Convert.ToInt32(DB.Ident_Current("Unidades"));
			return result;
		} // End Create

		public static List<Unidades> Read()
		{
			List<Unidades> list = new List<Unidades>();
			DataTable dt = DB.Select("Unidades");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Unidades(
					   Convert.ToInt32(dr["Unidad_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["NumeroEconomico"]),
					   Convert.ToInt32(dr["ModeloUnidad_ID"]),
					   Convert.ToDecimal(dr["PrecioLista"]),
					   Convert.ToString(dr["NumeroSerie"]),
					   Convert.ToString(dr["NumeroSerieMotor"]),
					   Convert.ToString(dr["TarjetaCirculacion"]),
					   Convert.ToInt32(dr["EstatusUnidad_ID"]),
					   Convert.ToInt32(dr["LocacionUnidad_ID"]),
					   Convert.ToString(dr["Placas"]),
					   DB.GetNullableInt32(dr["Kilometraje"]),
					   Convert.ToInt32(dr["Propietario_ID"]),
					   DB.GetNullableInt32(dr["Arrendamiento_ID"]),
					   DB.GetNullableInt32(dr["Concesion_ID"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
					   Convert.ToString(dr["GPS"]),
					   DB.GetNullableInt32(dr["EstatusOperativoUnidad_ID"]),
					   DB.GetNullableDateTime(dr["UltimaActualizacion"]),
					   DB.GetNullableDateTime(dr["FechaCompra"])
				    )
				);
			}

			return list;
		} // End Read

		public static Unidades Read(int unidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_ID", unidad_id);
			DataTable dt = DB.Select("Unidades", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Unidades con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Unidades(
			    Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  Convert.ToInt32(dr["ModeloUnidad_ID"]),
					  Convert.ToDecimal(dr["PrecioLista"]),
					  Convert.ToString(dr["NumeroSerie"]),
					  Convert.ToString(dr["NumeroSerieMotor"]),
					  Convert.ToString(dr["TarjetaCirculacion"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Placas"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToInt32(dr["Propietario_ID"]),
					  DB.GetNullableInt32(dr["Arrendamiento_ID"]),
					  DB.GetNullableInt32(dr["Concesion_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
					  Convert.ToString(dr["GPS"]),
					  DB.GetNullableInt32(dr["EstatusOperativoUnidad_ID"]),
					  DB.GetNullableDateTime(dr["UltimaActualizacion"]),
					  DB.GetNullableDateTime(dr["FechaCompra"])
				   );
		} // End Read

		public static Unidades Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Unidades", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Unidades(
			    Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  Convert.ToInt32(dr["ModeloUnidad_ID"]),
					  Convert.ToDecimal(dr["PrecioLista"]),
					  Convert.ToString(dr["NumeroSerie"]),
					  Convert.ToString(dr["NumeroSerieMotor"]),
					  Convert.ToString(dr["TarjetaCirculacion"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Placas"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToInt32(dr["Propietario_ID"]),
					  DB.GetNullableInt32(dr["Arrendamiento_ID"]),
					  DB.GetNullableInt32(dr["Concesion_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
					  Convert.ToString(dr["GPS"]),
					  DB.GetNullableInt32(dr["EstatusOperativoUnidad_ID"]),
					  DB.GetNullableDateTime(dr["UltimaActualizacion"]),
					  DB.GetNullableDateTime(dr["FechaCompra"])
				   );
		} // End Read

		public static bool Read(
		    out Unidades unidades,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Unidades", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				unidades = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			unidades = new Unidades(
			    Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"]),
					  Convert.ToInt32(dr["NumeroEconomico"]),
					  Convert.ToInt32(dr["ModeloUnidad_ID"]),
					  Convert.ToDecimal(dr["PrecioLista"]),
					  Convert.ToString(dr["NumeroSerie"]),
					  Convert.ToString(dr["NumeroSerieMotor"]),
					  Convert.ToString(dr["TarjetaCirculacion"]),
					  Convert.ToInt32(dr["EstatusUnidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToString(dr["Placas"]),
					  DB.GetNullableInt32(dr["Kilometraje"]),
					  Convert.ToInt32(dr["Propietario_ID"]),
					  DB.GetNullableInt32(dr["Arrendamiento_ID"]),
					  DB.GetNullableInt32(dr["Concesion_ID"]),
					  DB.GetNullableInt32(dr["Referencia_ID"]),
					  DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
					  Convert.ToString(dr["GPS"]),
					  DB.GetNullableInt32(dr["EstatusOperativoUnidad_ID"]),
					  DB.GetNullableDateTime(dr["UltimaActualizacion"]),
					  DB.GetNullableDateTime(dr["FechaCompra"])
				   );
			return true;
		} // End Read

		public static List<Unidades> Read(string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			List<Unidades> list = new List<Unidades>();
			DataTable dt = DB.Read("Unidades", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Unidades(
					   Convert.ToInt32(dr["Unidad_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"]),
					   Convert.ToInt32(dr["NumeroEconomico"]),
					   Convert.ToInt32(dr["ModeloUnidad_ID"]),
					   Convert.ToDecimal(dr["PrecioLista"]),
					   Convert.ToString(dr["NumeroSerie"]),
					   Convert.ToString(dr["NumeroSerieMotor"]),
					   Convert.ToString(dr["TarjetaCirculacion"]),
					   Convert.ToInt32(dr["EstatusUnidad_ID"]),
					   Convert.ToInt32(dr["LocacionUnidad_ID"]),
					   Convert.ToString(dr["Placas"]),
					   DB.GetNullableInt32(dr["Kilometraje"]),
					   Convert.ToInt32(dr["Propietario_ID"]),
					   DB.GetNullableInt32(dr["Arrendamiento_ID"]),
					   DB.GetNullableInt32(dr["Concesion_ID"]),
					   DB.GetNullableInt32(dr["Referencia_ID"]),
					   DB.GetNullableInt32(dr["ConductorOperativo_ID"]),
					   Convert.ToString(dr["GPS"]),
					   DB.GetNullableInt32(dr["EstatusOperativoUnidad_ID"]),
					   DB.GetNullableDateTime(dr["UltimaActualizacion"]),
					   DB.GetNullableDateTime(dr["FechaCompra"])
				    )
				);
			}

			return list;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Unidades");
		} // End Read

		public static DataTable ReadDataTable(int unidad_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_ID", unidad_id);
			return DB.Select("Unidades", w_params);
		} // End Read

		public int Update()
		{
			this.Validate();

			// Validamos que el cambio pueda proceder a menos que la unidad esté en contrato.
			if (this.LocacionUnidad_ID == 5 || this.LocacionUnidad_ID == 14 || this.LocacionUnidad_ID == 22 || this.LocacionUnidad_ID == 28 || this.LocacionUnidad_ID == 29 || this.LocacionUnidad_ID == 30 || this.LocacionUnidad_ID == 31)
			{
				string filter = "Unidad_ID = " + this.Unidad_ID.ToString() + " AND EstatusContrato_ID = 1";
				if (DB.GetCount("Contratos", filter) > 0) throw new Exception("Esa unidad se encuentra en contrato y no puede ser movida a la locación especificada. Primero se debe liquidar el contrato");
			}
			if (!DB.IsNullOrEmpty(this.NumeroSerie))
			{
				string filter = "NumeroSerie = '" + this.NumeroSerie.ToUpper().Trim() + "' AND Unidad_ID <> " + this.Unidad_ID.ToString();
				if (DB.GetCount("Unidades", filter) > 0) throw new Exception("Favor de verificar el Numero de Serie porque ya existe en la Base de Datos para otra unidad. Es necesario reportar este caso a Soporte para proceder a la integración de Unidades.");
			}

			if (this.NumeroEconomico >= 0)
			{
				string filter = "NumeroEconomico = " + this.NumeroEconomico.ToString() + " AND Unidad_ID <> " + this.Unidad_ID.ToString() + " AND Empresa_ID = " + this.Empresa_ID.ToString() + " AND EstatusUnidad_ID <> 5";
				if (DB.GetCount("Unidades", filter) > 0) throw new Exception("Favor de verificar el Numero Economico de la unidad porque ya existe en la Base de Datos para otra unidad. Es necesario reportar este caso a Soporte para proceder a la integración de Unidades.");
			}

			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);
			m_params.Add("NumeroEconomico", this.NumeroEconomico);
			m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			m_params.Add("PrecioLista", this.PrecioLista);
			m_params.Add("NumeroSerie", this.NumeroSerie.ToUpper().Trim());
			m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
			m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
			m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Placas", this.Placas);
			if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
			m_params.Add("Propietario_ID", this.Propietario_ID);
			if (!DB.IsNullOrEmpty(this.Arrendamiento_ID)) m_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
			if (!DB.IsNullOrEmpty(this.Concesion_ID)) m_params.Add("Concesion_ID", this.Concesion_ID);
			if (!DB.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			if (!DB.IsNullOrEmpty(this.ConductorOperativo_ID)) m_params.Add("ConductorOperativo_ID", this.ConductorOperativo_ID);
			if (!DB.IsNullOrEmpty(this.GPS)) m_params.Add("GPS", this.GPS);
			if (!DB.IsNullOrEmpty(this.EstatusOperativoUnidad_ID)) m_params.Add("EstatusOperativoUnidad_ID", this.EstatusOperativoUnidad_ID);
			if (!DB.IsNullOrEmpty(this.UltimaActualizacion)) m_params.Add("UltimaActualizacion", this.UltimaActualizacion);
			if (!DB.IsNullOrEmpty(this.FechaCompra)) m_params.Add("FechaCompra", this.FechaCompra);
			return DB.UpdateRow("Unidades", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_ID", this.Unidad_ID);

			return DB.DeleteRow("Unidades", w_params);
		} // End Delete


		#endregion
	} //End Class Unidades

	public class Unidades_ConsumoCombustible
	{
		public Unidades_ConsumoCombustible() { }

		public int Unidad_ConsumoCombustible_ID { get; set; }
		public int Unidad_ID { get; set; }
		public int Conductor_ID { get; set; }
		public DateTime FechaConsumo { get; set; }
		public double ConsumoEnLitros { get; set; }

		public void Validate()
		{
			if (Unidad_ID <= 0)
				throw new Exception("Es necesario indicar la unidad que realiza el consumo");

			if (Conductor_ID <= 0)
				throw new Exception("Es necesario indicar el conductor que realiza el consumo");

			if (ConsumoEnLitros < 0)
				throw new Exception(string.Format("El consumo no debe ser negativo. Consumo: {0}", this.ConsumoEnLitros));
		}

		public bool InsertaConsumo()
		{
			bool b = false;

			Hashtable m_params = new Hashtable();
			m_params.Add("@Unidad_ID", this.Unidad_ID);
			m_params.Add("@Conductor_ID", this.Conductor_ID);
			m_params.Add("@FechaConsumo", this.FechaConsumo);
			m_params.Add("@ConsumoLts", this.ConsumoEnLitros);

			string sp = "usp_Unidades_ConsumoCombustible";
			b = DB.ExecuteCommandSP(sp, m_params);

			return b;
		}

		public bool ActualizaConsumo()
		{
			bool b = false;

			Hashtable m_params = new Hashtable();
			m_params.Add("@Unidad_ConsumoCombustible_ID", this.Unidad_ConsumoCombustible_ID);
			m_params.Add("@Unidad_ID", this.Unidad_ID);
			m_params.Add("@Conductor_ID", this.Conductor_ID);
			m_params.Add("@FechaConsumo", this.FechaConsumo);
			m_params.Add("@ConsumoLts", this.ConsumoEnLitros);

			string sp = "usp_Unidades_ConsumoCombustible";
			b = DB.ExecuteCommandSP(sp, m_params);

			return b;
		}

		public List<Unidades_ConsumoCombustible> ReadConsumoPorUnidad()
		{
			List<Unidades_ConsumoCombustible> lu = new List<Unidades_ConsumoCombustible>();
			Hashtable m_params = new Hashtable();
			m_params.Add("@Unidad_ID", this.Unidad_ID);
			string sp = "usp_Unidades_ConsumoCombustible_PorUnidad";
			DataSet ds = DB.QueryDS(sp, m_params);
			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				DataTable dt = ds.Tables[0];
				foreach (DataRow dr in dt.Rows)
				{
					Unidades_ConsumoCombustible u = new Unidades_ConsumoCombustible();
					u.Unidad_ConsumoCombustible_ID = Convert.ToInt32(dr["Unidad_ConsumoCombustible_ID"]);
					u.Unidad_ID = Convert.ToInt32(dr["Unidad__ID"]);
					u.Conductor_ID = Convert.ToInt32(dr["Conductor_ID"]);
					u.FechaConsumo = Convert.ToDateTime(dr["FechaConsumo"]);
					u.ConsumoEnLitros = Convert.ToDouble(dr["ConsumoEnLitros"]);
					lu.Add(u);
				}
			}

			return lu;
		}

	} // FIN Unidades_ConsumoCombustible

	public class Unidades_Kilometrajes
	{

		public Unidades_Kilometrajes()
		{
		}

		public Unidades_Kilometrajes(int unidad_kilometraje_id, int unidad_id, int conductor_id, int kilometraje, DateTime fecha)
		{
			this.Unidad_Kilometraje_ID = unidad_kilometraje_id;
			this.Unidad_ID = unidad_id;
			this.Conductor_ID = conductor_id;
			this.Kilometraje = kilometraje;
			this.Fecha = fecha;
		}

		private int _Unidad_Kilometraje_ID;
		public int Unidad_Kilometraje_ID
		{
			get { return _Unidad_Kilometraje_ID; }
			set { _Unidad_Kilometraje_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int _Conductor_ID;
		public int Conductor_ID
		{
			get { return _Conductor_ID; }
			set { _Conductor_ID = value; }
		}

		private int _Kilometraje;
		public int Kilometraje
		{
			get { return _Kilometraje; }
			set { _Kilometraje = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		public void Validate()
		{
			//  Obtenemos el último kilometraje ingresado
			Unidades_Kilometrajes uk = this.ReadLast();

			//  Si es el primer Km entra directo
			if (uk == null)
				return;

			//  Debe ser mayor que el último Kilometraje capturado
			if (this.Kilometraje < uk.Kilometraje)
			{
				throw new Exception(
				    string.Format(
					   "El kilometraje [{0:N0}]es menor que el último kilometraje capturado [{1:N0}]",
					   this.Kilometraje,
					   uk.Kilometraje
				    )
				);
			}

			//  No debe ser mayor a 900km por día            
			int dias = (this.Fecha - uk.Fecha).Days;

			if (dias == 0)
				dias = 1;

			int kmMaximo = (dias * AppHelper.MAX_KM_DIARIO) + uk.Kilometraje;

			if (this.Kilometraje > kmMaximo)
			{
				throw new Exception(
				    string.Format(
					   "EL kilometraje capturado [{0:N0}] es mayor que el kilometraje máximo que pudo haber recorrido la unidad [{1:N0}]",
					   this.Kilometraje,
					   kmMaximo
				    )
				);
			}
		}

		public int Create()
		{
			//this.Validate();
			Hashtable m_params = new Hashtable();
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Kilometraje", this.Kilometraje);
			m_params.Add("Fecha", this.Fecha);

			return DB.InsertRow("Unidades_Kilometrajes", m_params);
		} // End Create

		public static List<Unidades_Kilometrajes> Read()
		{
			List<Unidades_Kilometrajes> list = new List<Unidades_Kilometrajes>();
			DataTable dt = DB.Select("Unidades_Kilometrajes");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Unidades_Kilometrajes(Convert.ToInt32(dr["Unidad_Kilometraje_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
			}

			return list;
		} // End Read

		public static List<Unidades_Kilometrajes> Read(int unidad_kilometraje_id)
		{
			List<Unidades_Kilometrajes> list = new List<Unidades_Kilometrajes>();
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Kilometraje_ID", unidad_kilometraje_id);
			DataTable dt = DB.Select("Unidades_Kilometrajes", w_params);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Unidades_Kilometrajes(Convert.ToInt32(dr["Unidad_Kilometraje_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
			}

			return list;
		} // End Read

		/// <summary>
		/// Devuelve el último registro efectuado,
		/// en caso de existir
		/// </summary>        
		/// <returns></returns>
		private Unidades_Kilometrajes ReadLast()
		{
			DataTable dt = DB.Read(
			    "Unidades_Kilometrajes",
			    "Unidad_ID = @Unidad_ID",
			    "Fecha DESC",
			    DB.Param("@Unidad_ID", this.Unidad_ID)
			);

			if (dt.Rows.Count == 0)
				return null;

			DataRow dr = dt.Rows[0];

			return new Unidades_Kilometrajes(
			    Convert.ToInt32(dr["Unidad_Kilometraje_ID"]),
			    Convert.ToInt32(dr["Unidad_ID"]),
			    Convert.ToInt32(dr["Conductor_ID"]),
			    Convert.ToInt32(dr["Kilometraje"]),
			    Convert.ToDateTime(dr["Fecha"])
			);

		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Kilometraje_ID", this.Unidad_Kilometraje_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("Conductor_ID", this.Conductor_ID);
			m_params.Add("Kilometraje", this.Kilometraje);
			m_params.Add("Fecha", this.Fecha);

			return DB.UpdateRow("Unidades_Kilometrajes", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Kilometraje_ID", this.Unidad_Kilometraje_ID);

			return DB.DeleteRow("Unidades_Kilometrajes", w_params);
		}

	} //End Class Unidades_Kilometrajes

	public class Unidades_Locaciones
	{

		#region Constructors

		public Unidades_Locaciones()
		{
		}

		public Unidades_Locaciones(
		    int unidad_locacion_id,
		    int unidad_id,
		    int locacionunidad_id,
		    DateTime fecha,
		    string usuario_id,
		    string comentarios)
		{
			this.Unidad_Locacion_ID = unidad_locacion_id;
			this.Unidad_ID = unidad_id;
			this.LocacionUnidad_ID = locacionunidad_id;
			this.Fecha = fecha;
			this.Usuario_ID = usuario_id;
			this.Comentarios = comentarios;
		}

		#endregion

		#region Properties

		private int _Unidad_Locacion_ID;
		public int Unidad_Locacion_ID
		{
			get { return _Unidad_Locacion_ID; }
			set { _Unidad_Locacion_ID = value; }
		}

		private int _Unidad_ID;
		public int Unidad_ID
		{
			get { return _Unidad_ID; }
			set { _Unidad_ID = value; }
		}

		private int _LocacionUnidad_ID;
		public int LocacionUnidad_ID
		{
			get { return _LocacionUnidad_ID; }
			set { _LocacionUnidad_ID = value; }
		}

		private DateTime _Fecha;
		public DateTime Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private string _Comentarios;
		public string Comentarios
		{
			get { return _Comentarios; }
			set { _Comentarios = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Unidad_ID == 0) throw new Exception("Unidad_ID no puede ser nulo.");

			if (this.LocacionUnidad_ID == 0) throw new Exception("LocacionUnidad_ID no puede ser nulo.");

			if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Comentarios.Length > 255)
			{
				throw new Exception("Comentarios debe tener máximo 255 carateres.");
			}


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);

			return DB.InsertRow("Unidades_Locaciones", m_params);
		} // End Create

		public int Create(bool IsIdentityInsert)
		{
			if (!IsIdentityInsert) return Create();
			Hashtable m_params = new Hashtable();
			m_params.Add("Unidad_Locacion_ID", this.Unidad_Locacion_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);

			return DB.IdentityInsertRow("Unidades_Locaciones", m_params);
		} // End Create

		public static List<Unidades_Locaciones> Read()
		{
			List<Unidades_Locaciones> list = new List<Unidades_Locaciones>();
			DataTable dt = DB.Select("Unidades_Locaciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Unidades_Locaciones(
					   Convert.ToInt32(dr["Unidad_Locacion_ID"]),
					   Convert.ToInt32(dr["Unidad_ID"]),
					   Convert.ToInt32(dr["LocacionUnidad_ID"]),
					   Convert.ToDateTime(dr["Fecha"]),
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToString(dr["Comentarios"])
				    )
				);
			}

			return list;
		} // End Read

		public static Unidades_Locaciones Read(int unidad_locacion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Locacion_ID", unidad_locacion_id);
			DataTable dt = DB.Select("Unidades_Locaciones", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Unidades_Locaciones con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Unidades_Locaciones(
			    Convert.ToInt32(dr["Unidad_Locacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["Comentarios"])
				   );
		} // End Read

		public static Unidades_Locaciones Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Unidades_Locaciones", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Unidades_Locaciones(
			    Convert.ToInt32(dr["Unidad_Locacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["Comentarios"])
				   );
		} // End Read

		public static bool Read(
		    out Unidades_Locaciones unidades_locaciones,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Unidades_Locaciones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				unidades_locaciones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			unidades_locaciones = new Unidades_Locaciones(
			    Convert.ToInt32(dr["Unidad_Locacion_ID"]),
					  Convert.ToInt32(dr["Unidad_ID"]),
					  Convert.ToInt32(dr["LocacionUnidad_ID"]),
					  Convert.ToDateTime(dr["Fecha"]),
					  Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToString(dr["Comentarios"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Unidades_Locaciones");
		} // End Read

		public static DataTable ReadDataTable(int unidad_locacion_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Locacion_ID", unidad_locacion_id);
			return DB.Select("Unidades_Locaciones", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Locacion_ID", this.Unidad_Locacion_ID);
			m_params.Add("Unidad_ID", this.Unidad_ID);
			m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
			m_params.Add("Fecha", this.Fecha);
			if (!DB.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
			if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);

			return DB.UpdateRow("Unidades_Locaciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Unidad_Locacion_ID", this.Unidad_Locacion_ID);

			return DB.DeleteRow("Unidades_Locaciones", w_params);
		} // End Delete


		#endregion
	} //End Class Unidades_Locaciones


	public class Usuarios
	{

		public Usuarios()
		{
		}

		public Usuarios(string usuario_id, string nombre, string apellidos, string email, bool activo, byte[] pwd, int? empresa_id, int? estacion_id)
		{
			this.Usuario_ID = usuario_id;
			this.Nombre = nombre;
			this.Apellidos = apellidos;
			this.Email = email;
			this.Activo = activo;
			this.pwd = pwd;
			this.Empresa_ID = empresa_id;
			this.Estacion_ID = estacion_id;
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Apellidos;
		public string Apellidos
		{
			get { return _Apellidos; }
			set { _Apellidos = value; }
		}

		private string _Email;
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private bool _Activo;
		public bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private byte[] _pwd;
		public byte[] pwd
		{
			get { return _pwd; }
			set { _pwd = value; }
		}

		private int? _Empresa_ID;
		public int? Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private int? _Estacion_ID;
		public int? Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Apellidos", this.Apellidos);
			m_params.Add("Email", this.Email);
			m_params.Add("Activo", this.Activo);
			m_params.Add("pwd", this.pwd);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.InsertRow("Usuarios", m_params);
		} // End Create

		public static List<Usuarios> Read()
		{
			List<Usuarios> list = new List<Usuarios>();
			DataTable dt = DB.Select("Usuarios");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]), DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"])));
			}

			return list;
		} // End Read

		public static Usuarios Read(string usuario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", usuario_id);
			DataTable dt = DB.Select("Usuarios", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe Usuarios con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]), DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]));
		} // End Read

		public static Usuarios Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]), DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]));
		} // End Read

		public static bool Read(out Usuarios usuarios, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				usuarios = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			usuarios = new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]), DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Usuarios");
		} // End Read

		public static DataTable ReadDataTable(string usuario_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", usuario_id);
			return DB.Select("Usuarios", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Nombre", this.Nombre);
			m_params.Add("Apellidos", this.Apellidos);
			m_params.Add("Email", this.Email);
			m_params.Add("Activo", this.Activo);
			m_params.Add("pwd", this.pwd);
			m_params.Add("Empresa_ID", this.Empresa_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("Usuarios", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", this.Usuario_ID);

			return DB.DeleteRow("Usuarios", w_params);
		} // End Delete

	} //End Class Usuarios

	public class Usuarios_Cajas
	{

		#region Constructors

		public Usuarios_Cajas()
		{
		}

		public Usuarios_Cajas(
		    string usuario_id,
		    int caja_id)
		{
			this.Usuario_ID = usuario_id;
			this.Caja_ID = caja_id;
		}

		#endregion

		#region Properties

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Caja_ID;
		public int Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Caja_ID == 0) throw new Exception("Caja_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Caja_ID", this.Caja_ID);

			return DB.InsertRow("Usuarios_Cajas", m_params);
		} // End Create

		public static List<Usuarios_Cajas> Read()
		{
			List<Usuarios_Cajas> list = new List<Usuarios_Cajas>();
			DataTable dt = DB.Select("Usuarios_Cajas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Cajas(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Caja_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Usuarios_Cajas> Read(string usuario_id)
		{
			List<Usuarios_Cajas> list = new List<Usuarios_Cajas>();
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", usuario_id);
			DataTable dt = DB.Select("Usuarios_Cajas", m_params);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Cajas(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Caja_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Usuarios_Cajas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Cajas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Usuarios_Cajas(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Caja_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Usuarios_Cajas usuarios_cajas,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Cajas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				usuarios_cajas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			usuarios_cajas = new Usuarios_Cajas(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Caja_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Usuarios_Cajas");
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Caja_ID", this.Caja_ID);

			return DB.UpdateRow("Usuarios_Cajas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Usuario_ID", this.Usuario_ID);
			w_params.Add("Caja_ID", this.Caja_ID);
			return DB.DeleteRow("Usuarios_Cajas", w_params);
		} // End Delete


		#endregion
	} //End Class Usuarios_Cajas

	public class Usuarios_Empresas
	{

		#region Constructors

		public Usuarios_Empresas()
		{
		}

		public Usuarios_Empresas(
		    string usuario_id,
		    int empresa_id)
		{
			this.Usuario_ID = usuario_id;
			this.Empresa_ID = empresa_id;
		}

		#endregion

		#region Properties

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Empresa_ID;
		public int Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Empresa_ID == 0) throw new Exception("Empresa_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);

			return DB.InsertRow("Usuarios_Empresas", m_params);
		} // End Create

		public static List<Usuarios_Empresas> Read()
		{
			List<Usuarios_Empresas> list = new List<Usuarios_Empresas>();
			DataTable dt = DB.Select("Usuarios_Empresas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Empresas(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Usuarios_Empresas> Read(string usuario_id)
		{
			List<Usuarios_Empresas> list = new List<Usuarios_Empresas>();
			DataTable dt = DB.Select("Usuarios_Empresas", DB.GetParams(DB.Param("Usuario_ID", usuario_id)));
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Empresas(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Empresa_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Usuarios_Empresas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Empresas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Usuarios_Empresas(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Usuarios_Empresas usuarios_empresas,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Empresas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				usuarios_empresas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			usuarios_empresas = new Usuarios_Empresas(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Empresa_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Usuarios_Empresas");
		} // End Read


		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Empresa_ID", this.Empresa_ID);

			return DB.UpdateRow("Usuarios_Empresas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();

			return DB.DeleteRow("Usuarios_Empresas", w_params);
		} // End Delete


		#endregion
	} //End Class Usuarios_Empresas

	public class Usuarios_Estaciones
	{

		#region Constructors

		public Usuarios_Estaciones()
		{
		}

		public Usuarios_Estaciones(
		    string usuario_id,
		    int estacion_id)
		{
			this.Usuario_ID = usuario_id;
			this.Estacion_ID = estacion_id;
		}

		#endregion

		#region Properties

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _Estacion_ID;
		public int Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		#endregion

		#region Methods
		public void Validate()
		{
			if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

			if (this.Usuario_ID.Length > 30)
			{
				throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
			}

			if (this.Estacion_ID == 0) throw new Exception("Estacion_ID no puede ser nulo.");


		} // End Validate

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.InsertRow("Usuarios_Estaciones", m_params);
		} // End Create

		public static List<Usuarios_Estaciones> Read()
		{
			List<Usuarios_Estaciones> list = new List<Usuarios_Estaciones>();
			DataTable dt = DB.Select("Usuarios_Estaciones");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Estaciones(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static List<Usuarios_Estaciones> Read(string usuario_id)
		{
			List<Usuarios_Estaciones> list = new List<Usuarios_Estaciones>();
			DataTable dt = DB.Select("Usuarios_Estaciones", DB.GetParams(DB.Param("Usuario_ID", usuario_id)));
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(
				    new Usuarios_Estaciones(
					   Convert.ToString(dr["Usuario_ID"]),
					   Convert.ToInt32(dr["Estacion_ID"])
				    )
				);
			}

			return list;
		} // End Read

		public static Usuarios_Estaciones Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Estaciones", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Usuarios_Estaciones(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
		} // End Read

		public static bool Read(
		    out Usuarios_Estaciones usuarios_estaciones,
		    int top,
		    string filter,
		    string sort,
		    params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Usuarios_Estaciones", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				usuarios_estaciones = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			usuarios_estaciones = new Usuarios_Estaciones(
			    Convert.ToString(dr["Usuario_ID"]),
					  Convert.ToInt32(dr["Estacion_ID"])
				   );
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("Usuarios_Estaciones");
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("Estacion_ID", this.Estacion_ID);

			return DB.UpdateRow("Usuarios_Estaciones", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();

			return DB.DeleteRow("Usuarios_Estaciones", w_params);
		} // End Delete


		#endregion
	} //End Class Usuarios_Estaciones

	public class ValesPrepagados
	{

		public ValesPrepagados()
		{
		}

		public ValesPrepagados(string valeprepagado_id, int empresacliente_id, string usuario_id, int estatusvaleprepagado_id, int? ticket_id, int foliodiario, decimal denominacion, DateTime fechaemision, DateTime fechaexpiracion, DateTime? fechacanje, int empresaEmite_id)
		{
			this.ValePrepagado_ID = valeprepagado_id;
			this.EmpresaCliente_ID = empresacliente_id;
			this.Usuario_ID = usuario_id;
			this.EstatusValePrepagado_ID = estatusvaleprepagado_id;
			this.Ticket_ID = ticket_id;
			this.FolioDiario = foliodiario;
			this.Denominacion = denominacion;
			this.FechaEmision = fechaemision;
			this.FechaExpiracion = fechaexpiracion;
			this.FechaCanje = fechacanje;
			this.EmpresaEmite_ID = (int)empresaEmite_id;
		}

		private string _ValePrepagado_ID;
		public string ValePrepagado_ID
		{
			get { return _ValePrepagado_ID; }
			set { _ValePrepagado_ID = value; }
		}

		private int _EmpresaCliente_ID;
		public int EmpresaCliente_ID
		{
			get { return _EmpresaCliente_ID; }
			set { _EmpresaCliente_ID = value; }
		}

		private int _EmpresaEmite_ID;
		public int EmpresaEmite_ID
		{
			get { return _EmpresaEmite_ID; }
			set { _EmpresaEmite_ID = value; }
		}

		private string _Usuario_ID;
		public string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private int _EstatusValePrepagado_ID;
		public int EstatusValePrepagado_ID
		{
			get { return _EstatusValePrepagado_ID; }
			set { _EstatusValePrepagado_ID = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int _FolioDiario;
		public int FolioDiario
		{
			get { return _FolioDiario; }
			set { _FolioDiario = value; }
		}

		private decimal _Denominacion;
		public decimal Denominacion
		{
			get { return _Denominacion; }
			set { _Denominacion = value; }
		}

		private DateTime _FechaEmision;
		public DateTime FechaEmision
		{
			get { return _FechaEmision; }
			set { _FechaEmision = value; }
		}

		private DateTime _FechaExpiracion;
		public DateTime FechaExpiracion
		{
			get { return _FechaExpiracion; }
			set { _FechaExpiracion = value; }
		}

		private DateTime? _FechaCanje;
		public DateTime? FechaCanje
		{
			get { return _FechaCanje; }
			set { _FechaCanje = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);
			m_params.Add("EmpresaCliente_ID", this.EmpresaCliente_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
			if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("FolioDiario", this.FolioDiario);
			m_params.Add("Denominacion", this.Denominacion);
			m_params.Add("FechaEmision", this.FechaEmision);
			m_params.Add("FechaExpiracion", this.FechaExpiracion);
			if (!AppHelper.IsNullOrEmpty(this.FechaCanje)) m_params.Add("FechaCanje", this.FechaCanje);
			m_params.Add("Empresa_ID", this.EmpresaEmite_ID);

			return DB.InsertRow("ValesPrepagados", m_params);
		} // End Create

		public static List<ValesPrepagados> Read()
		{
			List<ValesPrepagados> list = new List<ValesPrepagados>();
			DataTable dt = DB.Select("ValesPrepagados");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ValesPrepagados(
					Convert.ToString(dr["ValePrepagado_ID"])
					, Convert.ToInt32(dr["EmpresaCliente_ID"])
					, Convert.ToString(dr["Usuario_ID"])
					, Convert.ToInt32(dr["EstatusValePrepagado_ID"])
					, DB.GetNullableInt32(dr["Ticket_ID"])
					, Convert.ToInt32(dr["FolioDiario"])
					, Convert.ToDecimal(dr["Denominacion"])
					, Convert.ToDateTime(dr["FechaEmision"])
					, Convert.ToDateTime(dr["FechaExpiracion"])
					, DB.GetNullableDateTime(dr["FechaCanje"])
					, Convert.ToInt32(dr["Empresa_ID"])));
			}

			return list;
		} // End Read

		public static ValesPrepagados Read(string valeprepagado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValePrepagado_ID", valeprepagado_id);
			DataTable dt = DB.Select("ValesPrepagados", w_params);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]), Convert.ToInt32(dr["Empresa_ID"]));
		} // End Read

		public static ValesPrepagados Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ValesPrepagados", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]), Convert.ToInt32(dr["Empresa_ID"]));
		} // End Read

		public static List<ValesPrepagados> ReadList(params KeyValuePair<string, object>[] args)
		{
			List<ValesPrepagados> lvp = new List<ValesPrepagados>();
			DataTable dt = DB.Read("ValesPrepagados", args);
			if (dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ValesPrepagados vp = new ValesPrepagados(
						Convert.ToString(dr["ValePrepagado_ID"])
						, Convert.ToInt32(dr["EmpresaCliente_ID"])
						, Convert.ToString(dr["Usuario_ID"])
						, Convert.ToInt32(dr["EstatusValePrepagado_ID"])
						, DB.GetNullableInt32(dr["Ticket_ID"])
						, Convert.ToInt32(dr["FolioDiario"])
						, Convert.ToDecimal(dr["Denominacion"])
						, Convert.ToDateTime(dr["FechaEmision"])
						, Convert.ToDateTime(dr["FechaExpiracion"])
						, DB.GetNullableDateTime(dr["FechaCanje"])
						, Convert.ToInt32(dr["Empresa_ID"]));
					lvp.Add(vp);
				}
			}
			return lvp;
		} // End Read

		public static bool Read(out ValesPrepagados valesprepagados, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ValesPrepagados", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				valesprepagados = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			valesprepagados = new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]), Convert.ToInt32(dr["Empresa_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ValesPrepagados");
		} // End Read

		public static DataTable ReadDataTable(string valeprepagado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValePrepagado_ID", valeprepagado_id);
			return DB.Select("ValesPrepagados", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);
			m_params.Add("EmpresaCliente_ID", this.EmpresaCliente_ID);
			m_params.Add("Usuario_ID", this.Usuario_ID);
			m_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
			//if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) 
			m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("FolioDiario", this.FolioDiario);
			m_params.Add("Denominacion", this.Denominacion);
			m_params.Add("FechaEmision", this.FechaEmision);
			m_params.Add("FechaExpiracion", this.FechaExpiracion);
			if (!AppHelper.IsNullOrEmpty(this.FechaCanje)) m_params.Add("FechaCanje", this.FechaCanje);

			return DB.UpdateRow("ValesPrepagados", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);

			return DB.DeleteRow("ValesPrepagados", w_params);
		} // End Delete

		/// <summary>
		/// Verifica la validez de un vale prepagado
		/// </summary>
		/// <param name="valeprepagado_id"></param>
		/// <returns>void</returns>
		public static void Validar(string valeprepagado_id)
		{
			ValesPrepagados vale = ValesPrepagados.Read(valeprepagado_id);

			if (vale == null) throw new Exception("Vale no existe");

			if (vale.EstatusValePrepagado_ID == 2)
			{
				throw new Exception("El vale ya fue cobrado");
			}

			if (vale.EstatusValePrepagado_ID == 3)
			{
				throw new Exception("El vale ya fue cancelado");
			}

			if (vale.FechaExpiracion <= DB.GetDate())
			{
				throw new Exception("EL vale ya expiró");
			}
		}

	} //End Class ValesPrepagados

	public class ValesEmpresariales
	{

		public ValesEmpresariales()
		{
		}

		public ValesEmpresariales(int? valeempresarial_id, string serie, string folio, int estatusvaleempresarial_id, string usuarioasigna_id, string usuarioasignado_id, DateTime fechaasignacion, DateTime? fechacanje, decimal? monto, string usuariocaja_id, int? caja_id, int? ticket_id, int? sesion_id)
		{
			this.ValeEmpresarial_ID = valeempresarial_id;
			this.Serie = serie;
			this.Folio = folio;
			this.EstatusValeEmpresarial_ID = estatusvaleempresarial_id;
			this.UsuarioAsigna_ID = usuarioasigna_id;
			this.UsuarioAsignado_ID = usuarioasignado_id;
			this.FechaAsignacion = fechaasignacion;

			this.FechaCanje = FechaCanje;
			this.Monto = monto;
			this.UsuarioCaja_ID = usuariocaja_id;
			this.Caja_ID = caja_id;
			this.Ticket_ID = ticket_id;
			this.Sesion_ID = sesion_id;
		}

		private int? _ValeEmpresarial_ID;
		public int? ValeEmpresarial_ID
		{
			get { return _ValeEmpresarial_ID; }
			set { _ValeEmpresarial_ID = value; }
		}

		private string _serie;
		public string Serie {
			get { return _serie; }
			set { _serie = value; }
		}

		private string _Folio;
		public string Folio
		{
			get { return _Folio; }
			set { _Folio = value; }
		}

		private int _EstatusValeEmpresarial_ID;
		public int EstatusValeEmpresarial_ID
		{
			get { return _EstatusValeEmpresarial_ID; }
			set { _EstatusValeEmpresarial_ID = value; }
		}

		private string _Estatus;
		public string Estatus
		{
			get { return _Estatus; }
			set { _Estatus = value; }
		}

		private string _UsuarioAsignado_ID;
		public string UsuarioAsignado_ID
		{
			get { return _UsuarioAsignado_ID; }
			set { _UsuarioAsignado_ID = value; }
		}

		private string _UsuarioAsignado;
		public string UsuarioAsignado
		{
			get { return _UsuarioAsignado; }
			set { _UsuarioAsignado = value; }
		}

		private string _UsuarioAsigna_ID;
		public string UsuarioAsigna_ID
		{
			get { return _UsuarioAsigna_ID; }
			set { _UsuarioAsigna_ID = value; }
		}

		private DateTime _FechaAsignacion;
		public DateTime FechaAsignacion
		{
			get { return _FechaAsignacion; }
			set { _FechaAsignacion = value; }
		}

		private DateTime? _FechaCanje;
		public DateTime? FechaCanje
		{
			get { return _FechaCanje; }
			set { _FechaCanje = value; }
		}

		private decimal? _Monto;
		public decimal? Monto
		{
			get { return _Monto; }
			set { _Monto = value; }
		}

		private string _UsuarioCaja_ID;
		public string UsuarioCaja_ID
		{
			get { return _UsuarioCaja_ID; }
			set { _UsuarioCaja_ID = value; }
		}

		private int? _Caja_ID;
		public int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private string _Caja;
		public string Caja
		{
			get { return _Caja; }
			set { _Caja = value; }
		}

		private int? _Ticket_ID;
		public int? Ticket_ID
		{
			get { return _Ticket_ID; }
			set { _Ticket_ID = value; }
		}

		private int? _Sesion_ID;
		public int? Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("ValeEmpresarial_ID", this.ValeEmpresarial_ID);
			m_params.Add("Serie", this.Serie);
			m_params.Add("Folio", this.Folio);
			m_params.Add("EstatusValeEmpresarial_ID", this.EstatusValeEmpresarial_ID);
			m_params.Add("UsuarioAsigna_ID", this.UsuarioAsigna_ID);
			m_params.Add("UsuarioAsignado_ID", this.UsuarioAsignado_ID);
			m_params.Add("FechaAsignacion", this.FechaAsignacion);
			return DB.InsertRow("ValesEmpresariales", m_params);
		} // End Create

		public static List<ValesEmpresariales> Read()
		{
			List<ValesEmpresariales> list = new List<ValesEmpresariales>();
			DataTable dt = DB.Select("ValesEmpresariales");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ValesEmpresariales(
					Convert.ToInt32(dr["ValeEmpresarial_ID"])
					, dr["Serie"].ToString()
					, dr["Folio"].ToString()
					, Convert.ToInt32(dr["EstatusValeEmpresarial_ID"])
					, dr["UsuarioAsignado_ID"].ToString()
					, dr["UsuarioAsigna_ID"].ToString()
					, Convert.ToDateTime(dr["FechaAsignacion"])
					, DB.GetNullableDateTime(dr["FechaCanje"])
					, DB.GetNullableDecimal(dr["Monto"])
					, dr["UsuarioCaja_ID"].ToString()
					, DB.GetNullableInt32(dr["Caja_ID"])
					, DB.GetNullableInt32(dr["Ticket_ID"])
					, DB.GetNullableInt32(dr["Sesion_ID"])
					));
			}
			return list;
		} // End Read

		public static ValesEmpresariales Read(string valeempresarial_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValeEmpresarial_ID", valeempresarial_id);
			DataTable dt = DB.Select("ValesEmpresariales", w_params);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ValesEmpresariales(
					Convert.ToInt32(dr["ValeEmpresarial_ID"])
					, dr["Serie"].ToString()
					, dr["Folio"].ToString()
					, Convert.ToInt32(dr["EstatusValeEmpresarial_ID"])
					, dr["UsuarioAsignado_ID"].ToString()
					, dr["UsuarioAsigna_ID"].ToString()
					, Convert.ToDateTime(dr["FechaAsignacion"])
					, DB.GetNullableDateTime(dr["FechaCanje"])
					, DB.GetNullableDecimal(dr["Monto"])
					, dr["UsuarioCaja_ID"].ToString()
					, DB.GetNullableInt32(dr["Caja_ID"])
					, DB.GetNullableInt32(dr["Ticket_ID"])
					, DB.GetNullableInt32(dr["Sesion_ID"])
					);
		} // End Read

		public static ValesEmpresariales Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ValesEmpresariales", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new ValesEmpresariales(
					Convert.ToInt32(dr["ValeEmpresarial_ID"])
					, dr["Serie"].ToString()
					, dr["Folio"].ToString()
					, Convert.ToInt32(dr["EstatusValeEmpresarial_ID"])
					, dr["UsuarioAsignado_ID"].ToString()
					, dr["UsuarioAsigna_ID"].ToString()
					, Convert.ToDateTime(dr["FechaAsignacion"])
					, DB.GetNullableDateTime(dr["FechaCanje"])
					, DB.GetNullableDecimal(dr["Monto"])
					, dr["UsuarioCaja_ID"].ToString()
					, DB.GetNullableInt32(dr["Caja_ID"])
					, DB.GetNullableInt32(dr["Ticket_ID"])
					, DB.GetNullableInt32(dr["Sesion_ID"]));
		} // End Read

		public static bool Read(out ValesEmpresariales valesempresariales, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ValesEmpresariales", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				valesempresariales = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			valesempresariales = new ValesEmpresariales(
					Convert.ToInt32(dr["ValeEmpresarial_ID"])
					, dr["Serie"].ToString()
					, dr["Folio"].ToString()
					, Convert.ToInt32(dr["EstatusValeEmpresarial_ID"])
					, dr["UsuarioAsignado_ID"].ToString()
					, dr["UsuarioAsigna_ID"].ToString()
					, Convert.ToDateTime(dr["FechaAsignacion"])
					, DB.GetNullableDateTime(dr["FechaCanje"])
					, DB.GetNullableDecimal(dr["Monto"])
					, dr["UsuarioCaja_ID"].ToString()
					, DB.GetNullableInt32(dr["Caja_ID"])
					, DB.GetNullableInt32(dr["Ticket_ID"])
					, DB.GetNullableInt32(dr["Sesion_ID"]));
			return true;
		} // End Read

		public static DataTable ReadDataTable()
		{
			return DB.Select("ValesEmpresariales");
		} // End Read

		public static DataTable ReadDataTable(string valeprepagado_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValeEmpresarial_ID", valeprepagado_id);
			return DB.Select("ValesEmpresariales", w_params);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("ValeEmpresarial_ID", this.ValeEmpresarial_ID);
			m_params.Add("UsuarioAsigna_ID", this.UsuarioAsigna_ID);
			m_params.Add("UsuarioAsignado_ID", this.UsuarioAsignado_ID);
			m_params.Add("EstatusValeEmpresarial_ID", this.EstatusValeEmpresarial_ID);
			//if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			m_params.Add("Ticket_ID", this.Ticket_ID);
			if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
			if (!AppHelper.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
			m_params.Add("Folio", this.Folio);
			m_params.Add("Monto", this.Monto);
			m_params.Add("FechaAsignacion", this.FechaAsignacion);
			if (!AppHelper.IsNullOrEmpty(this.FechaCanje)) m_params.Add("FechaCanje", this.FechaCanje);

			return DB.UpdateRow("ValesEmpresariales", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("ValeEmpresarial_ID", this.ValeEmpresarial_ID);

			return DB.DeleteRow("ValesEmpresariales", w_params);
		} // End Delete

		/// <summary>
		/// Verifica la validez de un vale empresarial
		/// </summary>
		/// <param name="valeempresarial_id"></param>
		/// <returns>void</returns>
		public static void Validar(string valeempresarial_id)
		{
			ValesEmpresariales vale = ValesEmpresariales.Read(valeempresarial_id);

			if (vale == null) throw new Exception("Vale no existe");

			if (vale.EstatusValeEmpresarial_ID == 2)
			{
				throw new Exception("El vale ya fue cobrado");
			}

			if (vale.EstatusValeEmpresarial_ID == 3)
			{
				throw new Exception("El vale ya fue cancelado");
			}
		}

		public static void Validar(string serie, int folio)
		{
			KeyValuePair<string, object> a1 = new KeyValuePair<string, object>("serie",serie);
			KeyValuePair<string, object> a2 = new KeyValuePair<string, object>("folio", folio);
			ValesEmpresariales vale = ValesEmpresariales.Read(a1, a2);

			if (vale == null) throw new Exception("Vale Empresarial no existe");

			if (vale.EstatusValeEmpresarial_ID == 2)
			{
				throw new Exception("El vale empresarial ya fue cobrado");
			}

			if (vale.EstatusValeEmpresarial_ID == 3)
			{
				throw new Exception("El vale empresarial ya fue cancelado");
			}
		}

		public static bool AsignaFolios(string usuarioasignado_id, string serie, string folioinicial, string foliofinal, string usuarioasigna_id)
		{
			string sqlstr = "usp_VE_AsignaFolios";
			Hashtable m_params = new Hashtable();
			m_params.Add("@UsuarioAsignado_ID", usuarioasignado_id);
			m_params.Add("@Serie", serie);
			m_params.Add("@FolioInicial", folioinicial);
			m_params.Add("@FolioFinal", foliofinal);
			m_params.Add("@UsuarioAsigna_ID", usuarioasigna_id);
			return DB.ExecuteCommandSP(sqlstr, m_params);
		}

		internal static List<Entities.ValesEmpresariales> ConsultaFolios(string usuarioasignado_id, int? estatus, string serie, string folio)
		{
			string sqlstr = "usp_VE_ConsultaVales";
			Hashtable m_params = new Hashtable();
			if (serie.Length > 0)
				m_params.Add("@Serie", serie);
			if (folio.Length > 0)
				m_params.Add("@Folio", folio);
			if (estatus != null)
				m_params.Add("@EstatusValeEmpresarial_ID", estatus);
			if (usuarioasignado_id.Length > 0)
				m_params.Add("@UsuarioAsignado_ID", usuarioasignado_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			List<Entities.ValesEmpresariales> lve = new List<ValesEmpresariales>();
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				Entities.ValesEmpresariales ve = new ValesEmpresariales();
				ve.Serie = dr["Serie"].ToString();
				ve.Folio = dr["Folio"].ToString();
				ve.FechaAsignacion = Convert.ToDateTime(dr["FechaAsignacion"]);
				ve.UsuarioAsignado_ID = dr["UsuarioAsignado_ID"].ToString();
				ve.UsuarioAsignado = dr["UsuarioAsignado"].ToString();
				ve.EstatusValeEmpresarial_ID = Convert.ToInt32(dr["EstatusValeEmpresarial_ID"]);
				ve.Estatus = dr["Estatus"].ToString();
				ve.FechaCanje = DB.GetNullableDateTime(dr["FechaCanje"]);
				ve.Caja_ID = DB.GetNullableInt32(dr["Caja_ID"]);
				ve.Caja = dr["Caja"].ToString();
				ve.Monto = DB.GetNullableDecimal(dr["Monto"]);
				lve.Add(ve);
			}
			return lve;
		}

		internal static List<ValesEmpresariales> ReadList(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("ValesEmpresariales", args);
			List<ValesEmpresariales> lve = new List<ValesEmpresariales>();
			if (dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					lve.Add(new ValesEmpresariales(
						    Convert.ToInt32(dr["ValeEmpresarial_ID"])
						    , dr["Serie"].ToString()
						    , dr["Folio"].ToString()
						    , Convert.ToInt32(dr["EstatusValeEmpresarial_ID"])
						    , dr["UsuarioAsignado_ID"].ToString()
						    , dr["UsuarioAsigna_ID"].ToString()
						    , Convert.ToDateTime(dr["FechaAsignacion"])
						    , DB.GetNullableDateTime(dr["FechaCanje"])
						    , DB.GetNullableDecimal(dr["Monto"])
						    , dr["UsuarioCaja_ID"].ToString()
						    , DB.GetNullableInt32(dr["Caja_ID"])
						    , DB.GetNullableInt32(dr["Ticket_ID"])
						    , DB.GetNullableInt32(dr["Sesion_ID"])));
				}
			}
			return lve;
		}
	} //End Class ValesEmpresariales

	public class VariablesNegocio
	{

		public VariablesNegocio()
		{
		}

		public VariablesNegocio(string variablenegocio_id, object valor)
		{
			this.VariableNegocio_ID = variablenegocio_id;
			this.Valor = valor;
		}

		private string _VariableNegocio_ID;
		public string VariableNegocio_ID
		{
			get { return _VariableNegocio_ID; }
			set { _VariableNegocio_ID = value; }
		}

		private object _Valor;
		public object Valor
		{
			get { return _Valor; }
			set { _Valor = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);
			m_params.Add("Valor", this.Valor);

			return DB.InsertRow("VariablesNegocio", m_params);
		} // End Create

		public static List<VariablesNegocio> Read()
		{
			List<VariablesNegocio> list = new List<VariablesNegocio>();
			DataTable dt = DB.Select("VariablesNegocio");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new VariablesNegocio(Convert.ToString(dr["VariableNegocio_ID"]), dr["Valor"]));
			}

			return list;
		} // End Read

		public static VariablesNegocio Read(string variablenegocio_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("VariableNegocio_ID", variablenegocio_id);
			DataTable dt = DB.Select("VariablesNegocio", w_params);
			if (dt.Rows.Count == 0)
			{
				throw new Exception("No existe VariablesNegocio con los criterios de búsqueda especificados.");
			}
			DataRow dr = dt.Rows[0];
			return new VariablesNegocio(Convert.ToString(dr["VariableNegocio_ID"]), dr["Valor"]);
		} // End Read

		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);
			m_params.Add("Valor", this.Valor);

			return DB.UpdateRow("VariablesNegocio", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);

			return DB.DeleteRow("VariablesNegocio", w_params);
		} // End Delete

	} //End Class VariablesNegocio

	public class Zonas
	{
		public Zonas()
		{
		}

		public Zonas(int zona_id, int tipozona_id, int? comisionservicio_id, string nombre)
		{
			this.Zona_ID = zona_id;
			this.TipoZona_ID = tipozona_id;
			this.ComisionServicio_ID = comisionservicio_id;
			this.Nombre = nombre;
		}

		private int _Zona_ID;
		public int Zona_ID
		{
			get { return _Zona_ID; }
			set { _Zona_ID = value; }
		}

		private int _TipoZona_ID;
		public int TipoZona_ID
		{
			get { return _TipoZona_ID; }
			set { _TipoZona_ID = value; }
		}

		private int? _ComisionServicio_ID;
		public int? ComisionServicio_ID
		{
			get { return _ComisionServicio_ID; }
			set { _ComisionServicio_ID = value; }
		}

		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		public int Create()
		{
			Hashtable m_params = new Hashtable();
			m_params.Add("TipoZona_ID", this.TipoZona_ID);
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.InsertRow("Zonas", m_params);
		} // End Create

		public static List<Zonas> Read()
		{
			List<Zonas> list = new List<Zonas>();
			DataTable dt = DB.Select("Zonas");
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static List<Zonas> Read(string filter, string sort, KeyValuePair<string, object>[] args)
		{
			List<Zonas> list = new List<Zonas>();
			DataTable dt = DB.Read("Zonas", filter, sort, args);
			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
			}

			return list;
		} // End Read

		public static Zonas Read(int zona_id)
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", zona_id);

			DataTable dt = DB.Select("Zonas", w_params);

			if (dt.Rows.Count == 0)
			{
				throw new Exception(String.Format("No existe zona con ID = {0}", zona_id));
			}

			DataRow dr = dt.Rows[0];

			return new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]),
						 DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static Zonas Read(params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Zonas", args);
			if (dt.Rows.Count == 0)
			{
				return null;
			}
			DataRow dr = dt.Rows[0];
			return new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]));
		} // End Read

		public static bool Read(out Zonas zonas, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
		{
			DataTable dt = DB.Read("Zonas", top, filter, sort, args);
			if (dt.Rows.Count == 0)
			{
				zonas = null;
				return false;
			}
			DataRow dr = dt.Rows[0];
			zonas = new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]));
			return true;
		} // End Read


		public int Update()
		{
			Hashtable m_params = new Hashtable();
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", this.Zona_ID);
			m_params.Add("TipoZona_ID", this.TipoZona_ID);
			m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
			m_params.Add("Nombre", this.Nombre);

			return DB.UpdateRow("Zonas", m_params, w_params);
		} // End Update

		public int Delete()
		{
			Hashtable w_params = new Hashtable();
			w_params.Add("Zona_ID", this.Zona_ID);

			return DB.DeleteRow("Zonas", w_params);
		}

	} //End Class Zonas


    /// <summary>
    /// Configuracion de montos para resguardo por Estacion
    /// </summary>
    public class Cajas_ResguardoEfectivoEstaciones
    {
        public int ResguardoEfectivoEstacion_ID { get; set; }
        public int Estacion_ID { get; set; }
        public decimal MontoResguardo { get; set; }
        public DateTime FechaCaptura { get; set; }
        public int Activo { get; set; }

        public Cajas_ResguardoEfectivoEstaciones()
        {
            this.ResguardoEfectivoEstacion_ID = 0;
            this.Estacion_ID = 0;
            this.MontoResguardo = 0;
            this.FechaCaptura = DateTime.Now;
            this.Activo = 0;
        }

        public Cajas_ResguardoEfectivoEstaciones(int resguardoEfectivoEstacion_ID, int estacion_ID, decimal montoResguardo, DateTime fechaCaptura, int activo)
		{
            this.ResguardoEfectivoEstacion_ID = resguardoEfectivoEstacion_ID;
            this.Estacion_ID = estacion_ID;
            this.MontoResguardo = montoResguardo;
            this.FechaCaptura = fechaCaptura;
            this.Activo = activo;
		}

        public static Cajas_ResguardoEfectivoEstaciones Read(int estacion_ID)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Estacion_ID", estacion_ID);

            DataTable dt = DB.Select("Cajas_ResguardoEfectivoEstaciones", w_params);

            if (dt.Rows.Count == 0)
            {
                //throw new Exception(String.Format("Sin Monto para Estacion_ID = {0}", estacion_ID));
                return new Cajas_ResguardoEfectivoEstaciones();
            }

            DataRow dr = dt.Rows[0];
            return new Cajas_ResguardoEfectivoEstaciones(Convert.ToInt32(dr["ResguardoEfectivoEstacion_ID"]),
                        Convert.ToInt32(dr["Estacion_ID"]),
                        Convert.ToDecimal(dr["MontoResguardo"]),
                        Convert.ToDateTime(dr["FechaCaptura"]),
                        Convert.ToInt32(dr["Activo"]));
        } // End Read
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class Cajas_ResguardoEfectivoSesion
    {
        public int ResguardoEfectivoSesion_ID { get; set; }
        public int Sesion_ID { get; set; }
        public decimal MontoResguardoParcial { get; set; }
        public int? Ticket_ID { get; set; }
        public DateTime FechaCaptura { get; set; }
        public int Activo { get; set; }

        public Cajas_ResguardoEfectivoSesion()
        {
        }

        public int Create()
        {
            Hashtable m_params = new Hashtable();
            m_params.Add("Sesion_ID", this.Sesion_ID);
            m_params.Add("MontoResguardoParcial", this.MontoResguardoParcial);
            m_params.Add("Ticket_ID", this.Ticket_ID);            
            //m_params.Add("FechaCaptura", this.FechaCaptura);
            //m_params.Add("Activo", this.FechaCaptura);

            return DB.InsertRow("Cajas_ResguardoEfectivoSesion", m_params);
        } // End Create

        public Cajas_ResguardoEfectivoSesion(int resguardoEfectivoSesion_ID, int sesion_ID, decimal montoResguardoParcial, int? ticket_ID, DateTime fechaCaptura, int activo)
		{
            this.ResguardoEfectivoSesion_ID = resguardoEfectivoSesion_ID;
            this.Sesion_ID = sesion_ID;
            this.MontoResguardoParcial = montoResguardoParcial;
            this.Ticket_ID = ticket_ID;
            this.FechaCaptura = fechaCaptura;
            this.Activo = activo;
		}

        public static DataTable ReadList(int sesion_ID)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Sesion_ID", sesion_ID);
            DataTable dt = DB.Select("Cajas_ResguardoEfectivoSesion", w_params);
                
            return dt;
                //List<Cajas_ResguardoEfectivoSesion> listaResguardos = new List<Cajas_ResguardoEfectivoSesion>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    listaResguardos.Add(new Cajas_ResguardoEfectivoSesion { Convert.ToInt32(dr["ResguardoEfectivoSesion_ID"]),
                //        Convert.ToInt32(dr["Sesion_ID"]),
                //        Convert.ToDecimal(dr["MontoResguardoParcial"]),
                //        Convert.ToInt32(dr["Ticket_ID"].ToString()),
                //        Convert.ToDateTime(dr["FechaCaptura"]),
                //        Convert.ToInt32(dr["Activo"])});
                //}
      

        } // End Read

        public static Decimal ReadMontoPendienteResguardoSesion(int sesion_ID, int estacion_ID)
        {
            Decimal montoPendiente = 0;
            string sql = "dbo.usp_ObtieneMontoPendienteResguardo";
            Hashtable w_params = new Hashtable();
            w_params.Add("@Sesion_ID", sesion_ID);
            w_params.Add("@Estacion_ID", estacion_ID);

            DataTable dt = DB.QueryDS(sql, w_params).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
               montoPendiente += Convert.ToDecimal(dr["ResguadoPendiente"]);
            }
            return montoPendiente;
        } // End Read

    }


	#region Nomina Aeropuerto

	public class TipoNominaVigente
	{
		int _tipoNominaVigente_ID;
		double _sueldoFijo;
		double _cargaSocial;
		DateTime _vigenciaInicio;
		DateTime _vigenciaFin;
		bool _vigente;
		TipoNomina _tiponomina = new TipoNomina();

		public int TipoNominaVigente_ID { get { return _tipoNominaVigente_ID; } set { _tipoNominaVigente_ID = value; } }
		public double SueldoFijo { get { return _sueldoFijo; } set { _sueldoFijo = value; } }
		public double CargaSocial { get { return _cargaSocial; } set { _cargaSocial = value; } }
		public DateTime VigenciaInicio { get { return _vigenciaInicio; } set { _vigenciaInicio = value; } }
		public DateTime VigenciaFin { get { return _vigenciaFin; } set { _vigenciaFin = value; } }
		public bool Vigente { get { return _vigente; } set { _vigente = value; } }
		public TipoNomina Tiponomina { get { return _tiponomina; } set { _tiponomina = value; } }

		public static List<TipoNominaVigente> GetTiposNominaVigente()
		{
			List<TipoNominaVigente> lt = new List<TipoNominaVigente>();
			string sqlstr = "dbo.usp_Nomina_Obtiene_TiposNominaVigente";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				TipoNominaVigente t = new TipoNominaVigente();

				t.TipoNominaVigente_ID = Convert.ToInt32(dr["TipoNominaVigente_ID"].ToString());
				t.SueldoFijo = Convert.ToDouble(dr["SueldoFijo"]);
				t.CargaSocial = Convert.ToDouble(dr["CargaSocial"]);
				t.VigenciaInicio = Convert.ToDateTime(dr["VigenciaInicio"]);
				t.VigenciaFin = Convert.ToDateTime(dr["VigenciaFin"]);
				t.Vigente = true;
				t.Tiponomina = new TipoNomina();
				t.Tiponomina.TipoNomina_ID = Convert.ToInt32(dr["TipoNomina_ID"].ToString());
				t.Tiponomina.Nombre = dr["TipoNomina"].ToString();
				lt.Add(t);
			}
			return lt;
		}
	}

	public class TipoNomina
	{
		public int TipoNomina_ID { get; set; }
		public string Nombre { get; set; }

		public TipoNomina() { }

		public TipoNomina(int id, string tipo)
		{
			this.TipoNomina_ID = id;
			this.Nombre = tipo;
		}

		public static List<TipoNomina> GetTiposNomina()
		{
			List<TipoNomina> lt = new List<TipoNomina>();
			string sqlstr = "dbo.usp_Nomina_Obtiene_TiposNomina";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				TipoNomina t = new TipoNomina();
				t.TipoNomina_ID = Convert.ToInt32(dr["TipoNomina_ID"].ToString());
				t.Nombre = dr["Nombre"].ToString();
				lt.Add(t);
			}
			return lt;
		}

		public override string ToString()
		{
			return Nombre;
		}
	}

	public class PeriodoNomina
	{
		public DateTime Periodo { get; set; }
		public int iSemana { get; set; }
		public string Semana { get { return string.Format("{0}", Periodo.ToShortDateString()); } }
		public int EstatusNomina { get; set; }

		public PeriodoNomina() { }

		public PeriodoNomina(DateTime periodo, int semana)
		{
			this.Periodo = periodo;
			this.iSemana = semana;
		}

		public static List<PeriodoNomina> GetPeriodosNominaAño(int año)
		{
			List<PeriodoNomina> lt = new List<PeriodoNomina>();
			string sqlstr = "dbo.usp_Nomina_Obtiene_PeriodosNomina_por_Anio";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Anio", año);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				PeriodoNomina t = new PeriodoNomina();
				t.Periodo = Convert.ToDateTime(dr["Periodo"]);
				t.iSemana = Convert.ToInt32(dr["Semana"]);
				t.EstatusNomina = Convert.ToInt32(dr["EstatusNomina_ID"]);
				lt.Add(t);
			}
			return lt;
		}
	}

	public class Año
	{
		public int ID { get; set; }
		public string sAño { get { return ID.ToString(); } }

		public Año() { }

		public Año(int año)
		{
			this.ID = año;
		}

		public static List<Año> GetAñosNomina()
		{
			List<Año> la = new List<Año>();
			string sqlstr = "dbo.usp_Nomina_Obtiene_Anios";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				Año a = new Año(Convert.ToInt32(dr["ID"]));
				la.Add(a);
			}
			return la;
		}
	}

	#endregion
} // End namespace