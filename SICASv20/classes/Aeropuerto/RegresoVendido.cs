using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class RegresoVendido
	{
		public string Boleto { get; set; }
		public int Folio { get; set; }
		public double Precio { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime Fecha_Expiracion { get; set; }
		public DateTime Fecha_Servicio { get; set; }
		public string Zona { get; set; }
		public string Forma_Pago { get; set; }
		public string Estatus { get; set; }
		public string Tipo_Servicio { get; set; }
		public string Numero_Confirmacion { get; set; }
		public string Payback { get; set; }
		public string Unidad { get; set; }
		public string Conductor { get; set; }
		public string Unidad_Vende { get; set; }
		public string Conductor_Vende { get; set; }

		public RegresoVendido()
		{

		}

		public RegresoVendido(
				string boleto,
				int folio,
				double precio,
				DateTime fecha,
				DateTime fecha_Expiracion,
				DateTime fecha_Servicio,
				string zona,
				string forma_Pago,
				string estatus,
				string tipo_Servicio,
				string numero_Confirmacion,
				string payback,
				string unidad,
				string conductor,
				string unidad_vende,
				string conductor_vende
			)
		{
			Boleto = boleto;
			Folio = folio;
			Precio = precio;
			Fecha = fecha;
			Fecha_Expiracion = fecha_Expiracion;
			Fecha_Servicio = fecha_Servicio;
			Zona = zona;
			Forma_Pago = forma_Pago;
			Estatus = estatus;
			Tipo_Servicio = tipo_Servicio;
			Numero_Confirmacion = numero_Confirmacion;
			Payback = payback;
			Unidad = unidad;
			Conductor = conductor;
			Unidad_Vende = unidad_vende;
			Conductor_Vende = conductor_vende;
		}
	}
}
