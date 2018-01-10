using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Aeropuerto.nomina.convenios
{
	public class Estacion
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public Estacion() { }

		public Estacion(int id, string nombre)
		{
			Id = id;
			Nombre = nombre;
		}

		public override string ToString()
		{
			return Nombre;
		}

		public static List<Estacion> GetEstaciones(string usuario_id)
		{
			List<Estacion> le = new List<Estacion>();
			string sqlstr = "dbo.usp_Nomina_Convenios_Estaciones_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Usuario_ID", usuario_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEstacionesList(ds.Tables[0].Rows);
		}

		private static List<Estacion> GetEstacionesList(DataRowCollection rows)
		{
			List<Estacion> le = new List<Estacion>();
			foreach (DataRow dr in rows)
			{
				le.Add(new Estacion(Convert.ToInt32(dr["Estacion_ID"]), dr["Estacion"].ToString()));
			}
			return le;
		}
	}
}
