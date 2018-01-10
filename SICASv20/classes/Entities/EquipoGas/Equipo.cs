using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class Equipo
	{
		int? _id;
		EquipoGas _equipoGas = new EquipoGas();
		Proveedor _proveedor = new Proveedor();
		double _costo;
		double _precio;
		double _montoDiario;
		int _cantidadDiasApagar;
		string _numeroSeriekit;
		string _numeroSerieTanque;
		DateTime _fechaAlta;
		DateTime _fechaUltimaAsignacion;
		string _usuario_id;
		int _estatusCatEquipoGas_ID;
		int _empresa_ID;
		int _estacion_ID;

		public int? Id { get { return _id; } set { _id = value; } }
		public EquipoGas Equipo_Gas { get { return _equipoGas; } set { _equipoGas = value; } }
		public Proveedor proveedor { get { return _proveedor; } set { _proveedor = value; } }
		public double Costo { get { return _costo; } set { _costo = value; } }
		public double Precio { get { return _precio; } set { _precio = value; } }
		public double MontoDiario { get { return _montoDiario; } set { _montoDiario = value; } }
		public int CantidadDiasApagar { get { return _cantidadDiasApagar; } set { _cantidadDiasApagar = value; } }
		public string NumeroSerieKit { get { return _numeroSeriekit; } set { _numeroSeriekit = value; } }
		public string NumeroSerieTanque { get { return _numeroSerieTanque; } set { _numeroSerieTanque = value; } }
		public DateTime FechaAlta { get { return _fechaAlta; } set { _fechaAlta = value; } }
		public DateTime FechaUltimaAsignacion { get { return _fechaUltimaAsignacion; } set { _fechaUltimaAsignacion = value; } }
		public string Usuario { get { return _usuario_id; } set { _usuario_id = value; } }
		public int Estatus { get { return _estatusCatEquipoGas_ID; } set { _estatusCatEquipoGas_ID = value; } }
		public int Empresa_ID { get { return _empresa_ID; } set { _empresa_ID = value; } }
		public int Estacion_ID { get { return _estacion_ID; } set { _estacion_ID = value; } }
		public string Descripcion { get { return _equipoGas.Descripcion; } }
		public bool Asignado { get; set; }

		public static List<Equipo> GetEquipos()
		{
			string sqlstr = "dbo.usp_EquiposGas_CatEquipo_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<Equipo> GetEquipos(int? EquipoGas_ID)
		{
			List<Equipo> lEquipo = new List<Equipo>();
			string sqlstr = "dbo.usp_EquiposGas_Equipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGas_ID", EquipoGas_ID);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<Equipo> GetEquipos(string numeroSerie, double? capacidad, int? equipo, int? proveedor, int? empresa_id, int? estacion_id)
		{
			List<Equipo> lEquipo = new List<Equipo>();
			string sqlstr = "dbo.usp_EquiposGas_CatEquipo_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquipoGas_ID", equipo);
			m_params.Add("@EquipoGasProveedor_ID", proveedor);
			m_params.Add("@NumeroSerie", numeroSerie);
			m_params.Add("@Capacidad", capacidad);
			m_params.Add("@Empresa_ID", empresa_id);
			m_params.Add("@Estacion_ID", estacion_id);

			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		public static List<Equipo> GetEquiposDisponibles()
		{
			List<Equipo> lEquipo = new List<Equipo>();
			string sqlstr = "dbo.usp_EquiposGas_CatEquipo_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EquiposDisponibles", 1);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetEquipoGasList(ds.Tables[0].Rows);
		}

		private static List<Equipo> GetEquipoGasList(DataRowCollection rows)
		{
			List<Equipo> lEquipo = new List<Equipo>();
			foreach (DataRow dr in rows)
			{
				Equipo p = new Equipo();
				p.Id = Convert.ToInt32(dr["CatEquipoGas_ID"]);
				p.Equipo_Gas.Id = Convert.ToInt32(dr["EquipoGas_ID"]);
				p.Equipo_Gas.Descripcion = dr["Equipo"].ToString();
				p.Equipo_Gas.Capacidad = Convert.ToDouble(dr["Capacidad"]);
				p.Equipo_Gas.EstatusEquipoGas_ID = Convert.ToInt32(dr["EstatusEquipoGas_ID"]);
				p.proveedor.Id = Convert.ToInt32(dr["EquipoGasProveedor_ID"]);
				p.proveedor.Nombre = dr["Proveedor"].ToString();
				p.proveedor.Estatus = Convert.ToInt32(dr["EstatusProveedorEquipoGas_ID"]);
				p.Costo = Convert.ToDouble(dr["Costo"]);
				p.Precio = Convert.ToDouble(dr["Precio"]);
				p.MontoDiario = Convert.ToDouble(dr["MontoDiario"]);
				p.CantidadDiasApagar = Convert.ToInt32(dr["CantidadDiasApagar"]);
				p.NumeroSerieKit = dr["NumeroSerie"].ToString();
				if (dr["NumeroSerieTanque"] != DBNull.Value)
					p.NumeroSerieTanque = dr["NumeroSerieTanque"].ToString();
				p.FechaAlta = Convert.ToDateTime(dr["FechaAlta"]);
				p.FechaUltimaAsignacion = Convert.ToDateTime(dr["FechaUltimaAsignacion"]);
				p.Usuario = dr["Usuario"].ToString();
				p.Estatus = Convert.ToInt32(dr["Estatus"]);
				p.Empresa_ID = Convert.ToInt32(dr["Empresa_ID"]);
				p.Estacion_ID = Convert.ToInt32(dr["Estacion_ID"]);
				p.Asignado = Convert.ToBoolean(dr["Asignado"]);
				lEquipo.Add(p);
			}
			return lEquipo;
		}

		public static bool Inserta(Equipo modelo)
		{
			string sqlstr = "usp_EquiposGas_CatEquipo_Inserta";
			Hashtable m_params = new Hashtable();
			if (modelo.Id != null)
				m_params.Add("@CatEquipoGas_ID", modelo.Id);

			m_params.Add("@EquipoGas_ID", modelo.Equipo_Gas.Id);
			m_params.Add("@EquipoGasProveedor_ID", modelo.proveedor.Id);
			m_params.Add("@Costo", modelo.Costo);
			m_params.Add("@Precio", modelo.Precio);
			m_params.Add("@MontoDiario", modelo.MontoDiario);
			m_params.Add("@CantidadDiasApagar", modelo.CantidadDiasApagar);
			m_params.Add("@NumeroSerie", modelo.NumeroSerieKit);
			m_params.Add("@NumeroSerieTanque", modelo._numeroSerieTanque);
			m_params.Add("@Usuario_ID", modelo.Usuario);
			m_params.Add("@Estatus", modelo.Estatus);
			m_params.Add("@Empresa_ID", modelo.Empresa_ID);
			m_params.Add("@Estacion_ID", modelo.Estacion_ID);

			return DB.ExecuteCommandSP(sqlstr, m_params);
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", _numeroSeriekit, _equipoGas.Descripcion);
		}
	}
}
