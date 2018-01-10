using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class ConductorNominaCAT
	{
		private SICASv20.Entities.TipoNomina _tiponomina = new SICASv20.Entities.TipoNomina();

		public int Conductor_ID { get; set; }
		public string Conductor { get; set; }
		public DateTime Periodo { get; set; }
		public int DiasLaborados { get; set; }
		public SICASv20.Entities.TipoNomina Tiponomina { get { return _tiponomina; } set { _tiponomina = value; } }
		public int ServiciosRealizados { get; set; }
		public double IngresoXBoletos { get; set; }
		public double Comision_Porc { get; set; }
		public double Comision_Monto { get; set; }
		public double SueldoFijo { get; set; }
		public double TiempoExtra { get; set; }
		public double PagoExtra { get; set; }
		public double Descuento { get; set; }
		public double CargaSocial { get; set; }
		public double SueldoVariable { get; set; }
		public double Sueldo { get; set; }
	}
}
