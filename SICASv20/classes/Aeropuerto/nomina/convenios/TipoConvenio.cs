using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SICASv20.classes.Aeropuerto.nomina.convenios
{
	public class TipoConvenio
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int TipoIncidencia { get; set; }
		public string Comentarios { get; set; }

		public TipoConvenio() { }

		public TipoConvenio(int id, string nombre, int tipoincidencia_id, string comentarios)
		{
			Id = id;
			Nombre = nombre;
			TipoIncidencia = tipoincidencia_id;
			Comentarios = comentarios;
		}

		public override string ToString()
		{
			return Nombre;
		}

		public static List<TipoConvenio> GetTiposConvenios(int? tipoconvenio)
		{
			List<TipoConvenio> le = new List<TipoConvenio>();
			string sqlstr = "dbo.usp_Nomina_Convenios_TiposConvenioConsulta";
			Hashtable m_params = new Hashtable();
			if(tipoconvenio != null)
				m_params.Add("@Nomina_TipoConvenio_ID", tipoconvenio);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			return GetTiposConveniosList(ds.Tables[0].Rows);
		}

		private static List<TipoConvenio> GetTiposConveniosList(DataRowCollection rows)
		{
			List<TipoConvenio> le = new List<TipoConvenio>();
			foreach (DataRow dr in rows)
			{
				le.Add(new TipoConvenio(Convert.ToInt32(dr["Nomina_TipoConvenio_ID"]), dr["Descripcion"].ToString(), Convert.ToInt32(dr["TipoIncidencia_ID"]), dr["Comentarios"].ToString()));
			}
			return le;
		}
	}
}
