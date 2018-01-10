using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Aeropuerto.nomina.convenios
{
	public class Conductor
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public Conductor() { }

		public Conductor(int id, string nombre)
		{
			Id = id;
			Nombre = nombre;
		}

		public override string ToString()
		{
			return Nombre;
		}

		public static List<Conductor> GetConductores(string empresa_id)
		{
			List<Conductor> le = new List<Conductor>();
			string sqlstr = "dbo.usp_Nomina_Convenios_ConductoresEmpresa_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Empresa_ID", empresa_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductoresList(ds.Tables[0].Rows);
		}

		private static List<Conductor> GetConductoresList(DataRowCollection rows)
		{
			List<Conductor> le = new List<Conductor>();
			foreach (DataRow dr in rows)
			{
				le.Add(new Conductor(Convert.ToInt32(dr["Conductor_ID"]), dr["Conductor"].ToString()));
			}
			return le;
		}

	}
}
