using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Aeropuerto.nomina.convenios
{
	public class Convenio
	{
		public int ID { get; set; }
		private Empresa _empresa = new Empresa();
		public Empresa Empresa { get { return _empresa; } set { _empresa = value; } }
		private Estacion _estacion = new Estacion();
		public Estacion Estacion { get { return _estacion; } set { _estacion = value; } }
		private Conductor _conductor = new Conductor();
		public Conductor Conductor { get { return _conductor; } set { _conductor = value; } }
		private TipoConvenio _tipoConvenio = new TipoConvenio();
		public TipoConvenio TipoConvenio { get { return _tipoConvenio; } set { _tipoConvenio = value; } }
		public DateTime FechaElaboracion { get; set; }
		public double MontoTotalAPagar { get; set; }
		public double MontoParcialidad { get; set; }
		public double SaldoActual { get; set; }
		public int CantidadDescuentos { get; set; }
		public int CantidadDescuentosAplicados { get; set; }
		public int CantidadDescuentosPendientes { get; set; }
		public DateTime UltimaFechaDescuento { get; set; }
		public string Usuario_ID { get; set; }
		public bool TieneDocumentoFirmado { get; set; }
		public string Observaciones { get; set; }
		public DateTime FechaPrimerDescuento { get; set; }
		public double MontoMinimoParaAplicarDescuento { get; set; }

		public static List<Convenio> GetConvenios(int? empresa, int? estacion, int? conductor, int? tipoconvenio, bool consaldo)
		{
			List<Estacion> le = new List<Estacion>();
			string sqlstr = "dbo.usp_Nomina_Convenios_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Empresa_ID", empresa);
			m_params.Add("@Estacion_ID", estacion);
			m_params.Add("@Conductor_ID", conductor);
			m_params.Add("@Nomina_TipoConvenio_ID", tipoconvenio);
			m_params.Add("@ConSaldo", consaldo);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetConveniosList(ds.Tables[0].Rows);
		}

		private static List<Convenio> GetConveniosList(DataRowCollection rows)
		{
			List<Convenio> le = new List<Convenio>();
			foreach (DataRow dr in rows)
			{
				Convenio c = new Convenio();
				c.ID = Convert.ToInt32(dr["Nomina_Convenio_ID"]);
				c.Empresa.Id = Convert.ToInt32(dr["Empresa_ID"]);
				c.Empresa.Nombre = dr["Empresa"].ToString();
				c.Estacion.Id = Convert.ToInt32(dr["Estacion_ID"]);
				c.Estacion.Nombre = dr["Estacion"].ToString();
				c.Conductor.Id = Convert.ToInt32(dr["Conductor_ID"]);
				c.Conductor.Nombre = dr["Conductor"].ToString();
				c.TipoConvenio.Id = Convert.ToInt32(dr["Nomina_TipoConvenio_ID"]);
				c.TipoConvenio.Nombre = dr["TipoConvenio"].ToString();
				c.FechaElaboracion = Convert.ToDateTime(dr["FechaElaboracion"]);
				c.MontoTotalAPagar = Convert.ToDouble(dr["MontoTotalAPagar"]);
				c.MontoParcialidad = Convert.ToDouble(dr["MontoParcialidad"]);
				c.SaldoActual = Convert.ToDouble(dr["SaldoActual"]);
				c.CantidadDescuentos = Convert.ToInt32(dr["CantidadDescuentos"]);
				c.CantidadDescuentosAplicados = Convert.ToInt32(dr["CantidadDescuentosAplicados"]);
				c.CantidadDescuentosPendientes = Convert.ToInt32(dr["CantidadDescuentosPendientes"]);
				c.UltimaFechaDescuento = Convert.ToDateTime(dr["UltimaFechaDescuento"]);
				c.Usuario_ID = dr["Usuario_ID"].ToString();
				c.TieneDocumentoFirmado = Convert.ToBoolean(dr["TieneDocumentoFirmado"]);
				c.Observaciones = dr["Observaciones"].ToString();
				c.FechaPrimerDescuento = Convert.ToDateTime(dr["FechaPrimerDescuento"]);
				c.MontoMinimoParaAplicarDescuento = Convert.ToDouble(dr["MontoMinimoParaAplicarDescuento"]);
				le.Add(c);
			}
			return le;
		}

		public static int InsertaConvenio(Convenio convenio)
		{
			string sqlstr = "[dbo].[usp_Nomina_Convenios_Inserta]";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Convenio_ID", convenio.ID);
			m_params.Add("@Empresa_ID", convenio.Empresa.Id);
			m_params.Add("@Estacion_ID", convenio.Estacion.Id);
			m_params.Add("@Conductor_ID", convenio.Conductor.Id);
			m_params.Add("@TipoConvenio_ID", convenio.TipoConvenio.Id);
			m_params.Add("@FechaElaboracion", convenio.FechaElaboracion);
			m_params.Add("@MontoTotalAPagar", convenio.MontoTotalAPagar);
			m_params.Add("@MontoParcialidad", convenio.MontoParcialidad);
			m_params.Add("@CantidadDescuentos", convenio.CantidadDescuentos);
			m_params.Add("@Usuario_ID", convenio.Usuario_ID);
			m_params.Add("@TieneDocumentoFirmado", convenio.TieneDocumentoFirmado);
			m_params.Add("@Observaciones", convenio.Observaciones);
			m_params.Add("@MontoMinimoParaAplicarDescuento", convenio.MontoMinimoParaAplicarDescuento);
			m_params.Add("@FechaPrimerDescuento", convenio.FechaPrimerDescuento);
			object obj = DB.ExecuteCommandSP_With_Return(sqlstr, m_params);
			return (int)obj;
		}

		public static double GetMontoAdeudoPorConveniosDelConductor(int conductor_id)
		{
			string sqlstr = "[dbo].[usp_Nomina_Convenios_SaldoPorConductor]";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Conductor_ID", conductor_id);
			object obj = DB.ExecuteCommandSP_With_Return(sqlstr, m_params);
			return Convert.ToDouble(obj);
		}
	}
}
