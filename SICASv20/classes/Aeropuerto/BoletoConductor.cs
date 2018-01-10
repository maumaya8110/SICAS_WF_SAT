using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class BoletoConductor
	{
		public int Conductor_ID { get; set; }
		public int Unidad_ID { get; set; }
		public string Numero_Economico { get; set; }
		public string Servicio { get; set; }
		public DateTime Fecha_Servicio { get; set; }
		public DateTime Fecha_Pago { get; set; }
		public DateTime Fecha_Captura { get; set; }
		public double Monto { get; set; }
	}
}
