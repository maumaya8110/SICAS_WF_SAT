using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Entities.Abastos
{
	public class ModeloUnidad
	{
		public int ID { get; set; }
		public string Descripcion { get; set; }
		public int Anio { get; set; }

		public ModeloUnidad() { }

		public ModeloUnidad(int id, string descripcion, int anio)
		{
			ID = id;
			Descripcion = descripcion;
			Anio = anio;
		}

		public static List<ModeloUnidad> GetModelosUnidades()
		{
			List<ModeloUnidad> la = new List<ModeloUnidad>();
			string sqlstr = "Abastos.usp_Obtiene_ModelosUnidades";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				ModeloUnidad a = new ModeloUnidad(Convert.ToInt32(dr["ModeloUnidad_ID"]), dr["Descripcion"].ToString(), Convert.ToInt32(dr["Anio"]));
				la.Add(a);
			}
			return la;
		}

		public static List<ModeloUnidad> GetModelosUnidades(int modelounidad_id)
		{
			List<ModeloUnidad> la = new List<ModeloUnidad>();
			string sqlstr = "Abastos.usp_Obtiene_ModelosUnidades";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ModeloUnidad_ID", modelounidad_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				ModeloUnidad a = new ModeloUnidad(Convert.ToInt32(dr["ModeloUnidad_ID"]), dr["Descripcion"].ToString(), Convert.ToInt32(dr["Anio"]));
				la.Add(a);
			}
			return la;
		}
	}
}
