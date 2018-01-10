using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class EquipoGas
	{
		public int? Id { get; set; }
		public string Descripcion { get; set; }
		public double Capacidad { get; set; }
		public int EstatusEquipoGas_ID { get; set; }
		public string Usuario_ID { get; set; }

		public static List<EquipoGas> GetEquiposGas()
		{
			string sqlstr = "dbo.usp_EquiposGas_Equipos_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<EquipoGas> GetEquiposGasActivos()
		{
			string sqlstr = "dbo.usp_EquiposGas_Equipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EstatusEquipoGas_ID", 1);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<EquipoGas> GetEquiposGasPorEstatus(int estatus)
		{
			string sqlstr = "dbo.usp_EquiposGas_Equipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EstatusEquipoGas_ID", estatus);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<EquipoGas> GetEquiposGas(int? id)
		{
			string sqlstr = "dbo.usp_EquiposGas_Equipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGas_ID", id);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		private static List<EquipoGas> GetEquipoGasList(DataRowCollection rows)
		{
			List<EquipoGas> lEquipo = new List<EquipoGas>();
			foreach (DataRow dr in rows)
			{
				EquipoGas p = new EquipoGas();
				p.Id = Convert.ToInt32(dr["EquipoGas_ID"]);
				p.Descripcion = dr["Descripcion"].ToString();
				p.Capacidad = Convert.ToDouble(dr["Capacidad"]);
				p.EstatusEquipoGas_ID = Convert.ToInt32(dr["EstatusEquipoGas_ID"]);
				p.Usuario_ID = dr["Usuario_ID"].ToString();
				lEquipo.Add(p);
			}
			return lEquipo;
		}

		public static bool Inserta(EquipoGas eg)
		{
			string sqlstr = "usp_EquiposGas_Equipos_Inserta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGas_ID", eg.Id);
			m_params.Add("@Descripcion", eg.Descripcion);
			m_params.Add("@Capacidad", eg.Capacidad);
			m_params.Add("@EstatusEquipoGas_ID", eg.EstatusEquipoGas_ID);
			m_params.Add("@Usuario_ID", Sesion.Usuario_ID);
			return DB.ExecuteCommandSP(sqlstr, m_params);
		}

		public static bool Elimina(EquipoGas eg)
		{
			string sqlstr = "usp_EquiposGas_Equipos_Elimina";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGas_ID", eg.Id);
			return DB.ExecuteCommandSP(sqlstr, m_params);
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}",Descripcion, Capacidad);
		}
	}
}
