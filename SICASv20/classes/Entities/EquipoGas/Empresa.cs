using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class Empresa
	{
		public int? Id { get; set; }
		public string Descripcion { get; set; }

		public Empresa() { }

		public Empresa(int id, string descripcion)
		{
			Id = id;
			Descripcion = descripcion;
		}

		public static List<Empresa> GetEmpresas()
		{
			string sqlstr = "dbo.usp_EquiposGas_Empresas_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEmpresaList(ds.Tables[0].Rows);
		}

		private static List<Empresa> GetEmpresaList(DataRowCollection rows)
		{
			List<Empresa> lEmpresa = new List<Empresa>();
			foreach (DataRow dr in rows)
			{
				Empresa e = new Empresa();
				e.Id = Convert.ToInt32(dr["Empresa_ID"]);
				e.Descripcion = dr["Nombre"].ToString();
				lEmpresa.Add(e);
			}
			return lEmpresa;
		}
	}
}
