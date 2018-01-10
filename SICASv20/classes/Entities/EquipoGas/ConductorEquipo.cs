using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities.EquipoGas
{
	public class ConductorEquipo
	{
		private int? _id;
		private Conductor _conductor = new Conductor();
		private Equipo _equipo_Gas = new Equipo();
		private DateTime _fechaInicio;
		private DateTime _FechaFin;
		private double _montoDiario;
		private bool _cobroActivo;
		private int _totalDiasCargados;
		private double _montoCargosEquipoGas;
		private double _montoPagado;
		private double _saldo;
		private int _estatus;
		private Entities.EquipoGas.Unidad _unidad = new Unidad();

		public int? Id { get { return _id; } set { _id = value; } }
		public Conductor Conductor { get { return _conductor; } set { _conductor = value; } }
		public Equipo Equipo_Gas { get { return _equipo_Gas; } set { _equipo_Gas = value; } }
		public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
		public DateTime FechaFin { get { return _FechaFin; } set { _FechaFin = value; } }
		public double MontoDiario { get { return _montoDiario; } set { _montoDiario = value; } }
		public bool CobroActivo { get { return _cobroActivo; } set { _cobroActivo = value; } }
		public int TotalDiasCargados { get { return _totalDiasCargados; } set { _totalDiasCargados = value; } }
		public double MontoCargosEquipoGas { get { return _montoCargosEquipoGas; } set { _montoCargosEquipoGas = value; } }
		public double MontoPagado { get { return _montoPagado; } set { _montoPagado = value; } }
		public double Saldo { get { return _saldo; } set { _saldo = value; } }
		public int Estatus { get { return _estatus; } set { _estatus = value; } }
		public Unidad Unidad { get { return _unidad; } set { _unidad = value; } }

		public static List<ConductorEquipo> GetConductoresEquipos()
		{
			List<ConductorEquipo> lConductoresEquipos = new List<ConductorEquipo>();
			string sqlstr = "dbo.usp_EquiposGas_ConductoresEquipos_Consulta";
			Hashtable m_params = new Hashtable();
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorEquipoList(ds.Tables[0].Rows);
		}

		public static List<ConductorEquipo> GetConductorEquipo(int conductorEquipoGas_ID)
		{
			string sqlstr = "dbo.usp_EquiposGas_ConductoresEquipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ConductorEquipoGas_ID", conductorEquipoGas_ID);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorEquipoList(ds.Tables[0].Rows);
		}

		public static List<ConductorEquipo> GetConductoresEquipos(int? _conductor_ID, int? _equipoGas_ID, DateTime? _fechaInicio, DateTime? _fechaFin)
		{
			string sqlstr = "dbo.usp_EquiposGas_ConductoresEquipos_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Conductor_ID", _conductor_ID);
			m_params.Add("@EquipoGas_ID", _equipoGas_ID);
			m_params.Add("@FechaInicio", _fechaInicio);
			m_params.Add("@FechaFin", _fechaFin);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConductorEquipoList(ds.Tables[0].Rows);
		}

		private static List<ConductorEquipo> GetConductorEquipoList(DataRowCollection rows)
		{
			List<ConductorEquipo> lConductoresEquipos = new List<ConductorEquipo>();
			foreach (DataRow dr in rows)
			{
				ConductorEquipo p = new ConductorEquipo();
				p.Id = Convert.ToInt32(dr["ConductorEquipoGas_ID"]);
				p.Conductor.Id = Convert.ToInt32(dr["Conductor_ID"]);
				p.Conductor.Nombre = dr["Conductor"].ToString();
				p.Equipo_Gas.Id = Convert.ToInt32(dr["CatEquipoGas_ID"]);
				p.Equipo_Gas.Equipo_Gas.Id = Convert.ToInt32(dr["EquipoGas_ID"]);
				p.Equipo_Gas.Equipo_Gas.Descripcion = dr["Equipo"].ToString();
				p.Equipo_Gas.Equipo_Gas.Capacidad = Convert.ToDouble(dr["Capacidad"]);
				p.Equipo_Gas.Equipo_Gas.EstatusEquipoGas_ID = Convert.ToInt32(dr["EstatusEquipoGas_ID"]);
				p.Equipo_Gas.proveedor.Id = Convert.ToInt32(dr["EquipoGasProveedor_ID"]);
				p.Equipo_Gas.proveedor.Nombre = dr["Proveedor"].ToString();
				p.Equipo_Gas.proveedor.Estatus = Convert.ToInt32(dr["EstatusProveedorEquipoGas_ID"]);
				p.Equipo_Gas.MontoDiario = Convert.ToDouble(dr["Equipo_MontoDiario"]);
				p.Equipo_Gas.CantidadDiasApagar = Convert.ToInt32(dr["Equipo_CantidadDiasApagar"]);
				p.Equipo_Gas.NumeroSerieKit = dr["Equipo_NumeroSerie"].ToString();
				p.Equipo_Gas.FechaAlta = Convert.ToDateTime(dr["Equipo_FechaAlta"]);
				p.Equipo_Gas.FechaUltimaAsignacion = Convert.ToDateTime(dr["Equipo_FechaUltimaAsignacion"]);
				p.Equipo_Gas.Usuario = dr["Equipo_Usuario"].ToString();
				p.Equipo_Gas.Estatus = Convert.ToInt32(dr["Equipo_Estatus"]);
				p.Equipo_Gas.Empresa_ID = Convert.ToInt32(dr["Equipo_Empresa_ID"]);
				p.Equipo_Gas.Estacion_ID = Convert.ToInt32(dr["Equipo_Estacion_ID"]);
				p.Equipo_Gas.Precio = Convert.ToDouble(dr["Equipo_Precio"]);
				p.FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString());
				p.FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString());
				p.MontoDiario = Convert.ToDouble(dr["MontoDiario"].ToString());
				p.CobroActivo = Convert.ToBoolean(dr["CobroActivo"].ToString());
				p.TotalDiasCargados = Convert.ToInt32(dr["TotalDiasCargados"].ToString());
				p.MontoCargosEquipoGas = Convert.ToDouble(dr["MontoCargosEquipoGas"].ToString());
				p.MontoPagado = Convert.ToDouble(dr["MontoPagado"].ToString());
				p.Saldo = Convert.ToDouble(dr["Saldo"].ToString());
				p.Estatus = Convert.ToInt32(dr["EstatusConductorEquipoGas_ID"]);
				p.Unidad.Id = Convert.ToInt32(dr["Unidad_ID"]);
				p.Unidad.NumeroEconomico = Convert.ToInt32(dr["NumeroEconomico"]);
				lConductoresEquipos.Add(p);
			}
			return lConductoresEquipos;
		}

		public static bool InsertaConductorEquipoGas(Entities.EquipoGas.ConductorEquipo registro)
		{
			string sqlstr = "usp_EquiposGas_ConductoresEquipos_Inserta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ConductorEquipoGas_ID", registro.Id);
			m_params.Add("@Conductor_ID", registro.Conductor.Id);
			m_params.Add("@CatEquipoGas_ID", registro.Equipo_Gas.Id);
			m_params.Add("@FechaInicio", registro.FechaInicio);
			m_params.Add("@FechaFin", registro.FechaFin);
			m_params.Add("@MontoDiario", registro.MontoDiario);
			m_params.Add("@CobroActivo", registro.CobroActivo);

			bool r = false;
			try
			{
				r = DB.ExecuteCommandSP(sqlstr, m_params);
			}
			catch (Exception ex)
			{
				throw new Exception("Ocurrió un error al querer realizar la operación.", ex);
			}
			return r;
		}

		public static bool BajaDeEquipo(ConductorEquipo modelo)
		{
			string sqlstr = "dbo.usp_EquiposGas_ConductoresEquipos_Elimina";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ConductorEquipoGas_ID", modelo.Id);

			return DB.ExecuteCommandSP(sqlstr, m_params);
		}
	}
}
