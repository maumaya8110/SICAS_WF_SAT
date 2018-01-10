using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SICASv20.classes.Aeropuerto.nomina.convenios
{
	public class Empresa
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public Empresa(){}

		public Empresa(int id, string nombre)
		{
			Id = id;
			Nombre = nombre;
		}

		public override string ToString()
		{
			return Nombre;
		}

		public static List<Empresa> GetEmpresas(string usuario_id)
		{
			List<Empresa> le = new List<Empresa>();
			string sqlstr = "dbo.usp_Nomina_Convenios_Empresas_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Usuario_ID", usuario_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEmpresasList(ds.Tables[0].Rows);
		}

		private static List<Empresa> GetEmpresasList(DataRowCollection rows)
		{
			List<Empresa> le = new List<Empresa>();
			foreach (DataRow dr in rows)
			{
				le.Add(new Empresa(Convert.ToInt32(dr["Empresa_ID"]), dr["Empresa"].ToString()));
			}
			return le;
		}
	}
}
