using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SICASv20.classes.Entities.Abastos
{
	public static class ManttoVehicular
	{
		public static DataTable ObtienePlantilla(int? modelounidad_id)
		{
			string sqlstr = "Abastos.usp_Obtiene_CartillaPorModeloUnidad";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ModeloUnidad_ID", modelounidad_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			if (ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}
	}
}
