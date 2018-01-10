using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.Entities
{
	class ValesEmpresarialesUsuarios
	{
		private string _Usuario_ID;
		public string Usuario_ID { get { return _Usuario_ID; } set { _Usuario_ID = value; } }

		private string _Nombre;
		public string Nombre { get { return _Nombre; } set { _Nombre = value; } }

		private int _Estatus;
		public int Estatus { get { return _Estatus; } set { _Estatus = value; } }

		public static List<ValesEmpresarialesUsuarios> GetValesEmpresarialesUsuarios()
		{
			List<ValesEmpresarialesUsuarios> lu = new List<ValesEmpresarialesUsuarios>();
			string sqlstr = "[dbo].[usp_VE_ObtieneUsuarios]";
			Hashtable m_params = new Hashtable();
			m_params.Add("@EstatusValeEmpresarialUsuario_ID", 1);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				ValesEmpresarialesUsuarios u = new ValesEmpresarialesUsuarios();
				u.Usuario_ID = dr["UsuarioAsignado_ID"].ToString();
				u.Nombre = dr["Nombre"].ToString();
				u.Estatus = Convert.ToInt32(dr["EstatusValeEmpresarialUsuario_ID"]);
				lu.Add(u);
			}
			return lu;
		}
	}
}
