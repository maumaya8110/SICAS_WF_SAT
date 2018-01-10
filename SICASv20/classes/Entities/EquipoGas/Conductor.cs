using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class Conductor
	{
		public int? Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get { return string.Format("{0} - {1}", Id, Nombre); } }

		public static List<Conductor> GetConductores()
		{
			List<Conductor> lConductores = new List<Conductor>();
			string sqlstr = "dbo.usp_EquiposGas_ConductoresConsulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorList(ds.Tables[0].Rows);
		}

		public static List<Conductor> GetConductoresDisponibles()
		{
			List<Conductor> lConductores = new List<Conductor>();
			string sqlstr = "dbo.usp_EquiposGas_ConductoresConsulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Disponibles",1);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorList(ds.Tables[0].Rows);
		}

		public static List<Conductor> GetConductorByConductorID(int conductor_id)
		{
			string sqlstr = "dbo.usp_EquiposGas_ConductoresConsulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Conductor_ID", conductor_id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorList(ds.Tables[0].Rows);
		}

		private static List<Conductor> GetConductorList(DataRowCollection rows)
		{
			List<Conductor> lConductores = new List<Conductor>();
			foreach (DataRow dr in rows)
			{
				Conductor c = new Conductor();
				c.Id = Convert.ToInt32(dr["Conductor_ID"].ToString());
				c.Nombre = dr["Conductor"].ToString();
				lConductores.Add(c);
			}
			return lConductores;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Id, Nombre);
		}
	}
}
