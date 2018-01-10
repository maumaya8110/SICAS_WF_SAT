using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class Estacion
	{
		public int? Id { get; set; }
		public string Descripcion { get; set; }

		public Estacion() { }

		public Estacion(int id, string descripcion)
		{
			Id = id;
			Descripcion = descripcion;
		}

		public static List<Estacion> GetEstaciones()
		{
			string sqlstr = "dbo.usp_EquiposGas_Estaciones_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEstacionesList(ds.Tables[0].Rows);
		}

		private static List<Estacion> GetEstacionesList(DataRowCollection rows)
		{
			List<Estacion> lEstaciones = new List<Estacion>();
			foreach (DataRow dr in rows)
			{
				Estacion e = new Estacion();
				e.Id = Convert.ToInt32(dr["Estacion_ID"]);
				e.Descripcion = dr["Nombre"].ToString();
				lEstaciones.Add(e);
			}
			return lEstaciones;
		}
	}
}
