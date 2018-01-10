using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Entities.Abastos
{
	public class Servicio
	{
		public int ID { get; set; }
		public int CIDPRODUCTO { get; set; }
		public int CIDPROVEEDOR { get; set; }
		public string CODIGOPRODUCTO { get; set; }
		public string NOMBREPRODUCTO { get; set; }
		public double PRECIOCOMPRA { get; set; }
		public decimal? KILOMETRAJE { get; set; }

		public Servicio() { }

		public Servicio(int id, int cidproducto, int cidproveedor, string codigo, string nombre, double precio, decimal? kilometraje)
		{
			ID = id;
			CIDPRODUCTO = cidproducto;
			CIDPROVEEDOR = cidproveedor;
			CODIGOPRODUCTO = codigo;
			NOMBREPRODUCTO = nombre;
			PRECIOCOMPRA = precio;
			KILOMETRAJE = kilometraje;
		}

		public bool Actualiza()
		{
			string sql = "[Abastos].[usp_Servicios_Actualiza]";
			Hashtable m_params = new Hashtable();
			m_params.Add("@CIDPRODUCTO", this.CIDPRODUCTO);
			m_params.Add("@CIDPROVEEDOR", this.CIDPROVEEDOR);
			m_params.Add("@KILOMETRAJE_MILES", this.KILOMETRAJE);
			return DB.ExecuteCommandSP(sql, m_params);
		}

		public void GetServicioById()
		{
			string sqlstr = "Abastos.usp_Servicios_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Servicio_ID", this.ID);
			try
			{
				DataSet ds = DB.QueryDS(sqlstr, m_params);
				Servicio s = new Servicio();
				s = GetListServicios(ds.Tables[0])[0];
				this.CIDPRODUCTO = s.CIDPRODUCTO;
				this.CIDPROVEEDOR = s.CIDPROVEEDOR;
				this.CODIGOPRODUCTO = s.CODIGOPRODUCTO;
				this.NOMBREPRODUCTO = s.NOMBREPRODUCTO;
				this.PRECIOCOMPRA = s.PRECIOCOMPRA;
				this.KILOMETRAJE = s.KILOMETRAJE;
			}
			catch (Exception ex)
			{
				throw new Exception("Obteniendo información del Servicio", ex);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} Precio: {1:C2}", CODIGOPRODUCTO, NOMBREPRODUCTO, PRECIOCOMPRA);
		}

		public static List<Servicio> GetServicios()
		{
			string sqlstr = "Abastos.usp_Servicios_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetListServicios(ds.Tables[0]);
		}

		private static List<Servicio> GetListServicios(DataTable dt)
		{
			List<Servicio> ls = new List<Servicio>();
			foreach (DataRow dr in dt.Rows)
			{
				Servicio p = new Servicio(
									Convert.ToInt32(dr["SERVICIO_ID"]),
									Convert.ToInt32(dr["CIDPRODUCTO"]),
									Convert.ToInt32(dr["CIDPROVEEDOR"]),
									dr["CCODIGOPRODUCTO"].ToString(),
									dr["CNOMBREPRODUCTO"].ToString(),
									Convert.ToDouble(dr["CPRECIOCOMPRA"]),
									DB.GetNullableDecimal(dr["KILOMETRAJE_MILES"])
									);
				ls.Add(p);
			}
			return ls;
		}

		public static List<Servicio> GetServicios(int cidproveedor)
		{
			string sqlstr = "Abastos.usp_Servicios_ConsultaPorProveedor";
			Hashtable m_params = new Hashtable();
			m_params.Add("@CIDPROVEEDOR", cidproveedor);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetListServicios(ds.Tables[0]);
		}

		public static List<Servicio> GetServicios(int cidproveedor, string codigo)
		{
			string sqlstr = "Abastos.usp_Servicios_ConsultaPorProveedor";
			Hashtable m_params = new Hashtable();
			m_params.Add("@CIDPROVEEDOR", cidproveedor);
			m_params.Add("@CCODIGOPRODUCTO", codigo);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetListServicios(ds.Tables[0]);
		}
	}
}
