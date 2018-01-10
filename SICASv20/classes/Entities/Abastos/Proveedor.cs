using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Entities.Abastos
{
	public class Proveedor
	{
		public int ID { get; set; }
		public int CID { get; set; }
		public string Nombre { get; set; }

		public Proveedor() { }

		public Proveedor(int id, int cid, string nombre) {
			ID = id;
			CID = cid;
			Nombre = nombre;
		}

		public static List<Proveedor> GetProveedores()
		{
			List<Proveedor> lp = new List<Proveedor>();
			string sqlstr = "Abastos.usp_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				Proveedor p = new Proveedor(Convert.ToInt32(dr["Proveedor_ID"]), Convert.ToInt32(dr["CIDPROVEEDOR"]), dr["Nombre"].ToString());
				lp.Add(p);
			}
			return lp;
		}

		public static List<Proveedor> GetProveedores(int id)
		{
			List<Proveedor> lp = new List<Proveedor>();
			string sqlstr = "Abastos.usp_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Proveedor_ID",id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				Proveedor p = new Proveedor(Convert.ToInt32(dr["Proveedor_ID"]), Convert.ToInt32(dr["CIDPROVEEDOR"]), dr["Nombre"].ToString());
				lp.Add(p);
			}
			return lp;
		}
	}
}
