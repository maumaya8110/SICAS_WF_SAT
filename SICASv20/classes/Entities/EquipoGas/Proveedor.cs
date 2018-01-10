using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class Proveedor
	{

		public int? Id { get; set; }
		public string Nombre { get; set; }
		public int Estatus { get; set; }

		public Proveedor() { }

		public Proveedor(int id, string nombre)
		{
			Id = id;
			Nombre = nombre;
		}

		public Proveedor(int id, string nombre, int estatus)
		{
			Id = id;
			Nombre = nombre;
			Estatus = estatus;
		}

		public static List<Proveedor> GetProveedores()
		{
			string sqlstr = "dbo.usp_EquiposGas_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetProveedorList(ds.Tables[0].Rows);
		}

		public static List<Proveedor> GetProveedoresActivos()
		{
			string sqlstr = "dbo.usp_EquiposGas_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EstatusProveedorEquipoGas_ID", 1);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetProveedorList(ds.Tables[0].Rows);
		}

		public static List<Proveedor> GetProveedoresPorEstatus(int estatus)
		{
			string sqlstr = "dbo.usp_EquiposGas_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EstatusProveedorEquipoGas_ID", estatus);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetProveedorList(ds.Tables[0].Rows);
		}

		public static List<Proveedor> GetProveedores(int EquipoGasProveedor_ID)
		{
			string sqlstr = "dbo.usp_EquiposGas_Proveedores_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGasProveedor_ID", EquipoGasProveedor_ID);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetProveedorList(ds.Tables[0].Rows);
		}

		private static List<Proveedor> GetProveedorList(DataRowCollection rows)
		{
			List<Proveedor> lProveedores = new List<Proveedor>();
			foreach (DataRow dr in rows)
			{
				Proveedor p = new Proveedor(Convert.ToInt32(dr["EquipoGasProveedor_ID"].ToString()), dr["Nombre"].ToString(), Convert.ToInt32(dr["EstatusProveedorEquipoGas_ID"]));
				lProveedores.Add(p);
			}
			return lProveedores;
		}

		public static bool Inserta(Proveedor p)
		{
			string sqlstr = "usp_EquiposGas_Proveedores_Inserta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGasProveedor_ID", p.Id);
			m_params.Add("@NombreProveedor", p.Nombre);
			m_params.Add("@EstatusProveedorEquipoGas_ID", p.Estatus);
			return DB.ExecuteCommandSP(sqlstr, m_params);
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}",Id, Nombre);
		}
	}
}
