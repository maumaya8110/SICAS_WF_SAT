using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Entities.Abastos
{
	public class ItemPlantilla
	{
		public int ID { get; set; }
		private ModeloUnidad _modelo = new ModeloUnidad();
		public ModeloUnidad Modelo { get { return _modelo; } set { _modelo = value; } }
		private Servicio _servicio = new Servicio();
		public Servicio Servicio { get { return _servicio; } set { _servicio = value; } }
		public int Orden { get; set; }
		public int Km { get; set; }
		public double Precio { get; set; }
		public string Producto { get { return Servicio.NOMBREPRODUCTO; } }

		public ItemPlantilla() { }

		public override string ToString()
		{
			return Producto;
		}

		public static List<ItemPlantilla> GetServiciosPorModeloUnidad(int modelounidad)
		{
			List<ItemPlantilla> lp = new List<ItemPlantilla>();
			string sqlstr = "Abastos.usp_Cartilla_ServicioPlantilla_Consulta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@ModeloUnidad_ID", modelounidad);
			DataSet ds = DB.QueryDS(sqlstr, m_params);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				ItemPlantilla p = new ItemPlantilla();
				p.ID = Convert.ToInt32(dr["Plantilla_ID"]);
				p.Modelo.ID = Convert.ToInt32(dr["ModeloUnidadI_D"]);
				p.Modelo.Descripcion = dr["Descripcion_Modelo"].ToString();
				p.Modelo.Anio = Convert.ToInt32(dr["Anio_Modelo"]);
				p.Servicio.ID = Convert.ToInt32(dr["ID_Servicio"]);
				p.Servicio.GetServicioById();
				p.Orden = Convert.ToInt32(dr["Orden"]);
				p.Km = Convert.ToInt32(dr["Km"]);
				p.Precio = Convert.ToDouble(dr["Precio"]);
				lp.Add(p);
			}
			return lp;
		}

		public void InsertaServicioModeloUnidad()
		{
			string sqlstr = "Abastos.usp_Cartilla_ServicioPlantilla_Inserta";
			Hashtable m_params = new Hashtable();
			m_params.Add("@Plantilla_ID", this.ID);
			m_params.Add("@ModeloUnidad_ID", this.Modelo.ID);
			m_params.Add("@Servicio_ID", this.Servicio.ID);
			m_params.Add("@Orden", this.Orden);
			m_params.Add("@Km",this.Km);
			m_params.Add("@Precio", this.Precio);
			try
			{
				object obj = DB.ExecuteCommandSP_With_Return(sqlstr, m_params);
				this.ID = Convert.ToInt32(obj);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al insertar el registro en la Plantilla",ex);
			}
		}
	}
}
