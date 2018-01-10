using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class ProgramacionPistas
	{
		public int Id { get; set; }
		public int Año { get; set; }
		public string Mes { get; set; }
		public int Semana { get; set; }
		public string Dia_Semana { get; set; }
		public int Num_Dia { get; set; }
		public DateTime Dia { get; set; }
		public DateTime HPeriodo { get; set; }
		public int Servicios_Disponibles { get; set; }
		public int Servicios_Programados { get; set; }
	}
}
