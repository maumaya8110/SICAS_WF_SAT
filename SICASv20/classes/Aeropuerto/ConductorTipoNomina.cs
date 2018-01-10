using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class ConductorTipoNomina
	{
		private int _conductor_ID;
		private string _conductor;
		private DateTime _periodo;
		private SICASv20.Entities.TipoNominaVigente _tipoNominaVigente = new SICASv20.Entities.TipoNominaVigente();

		public int Conductor_ID { get { return _conductor_ID; } set { _conductor_ID = value; } }
		public string Conductor { get { return _conductor; } set { _conductor = value; } }
		public DateTime Periodo { get { return _periodo; } set { _periodo = value; } }
		public SICASv20.Entities.TipoNominaVigente TipoNomina { get { return _tipoNominaVigente; } set { _tipoNominaVigente = value; } }
		public string TipoNominaActual { get { return TipoNomina.Tiponomina.Nombre; } }
		public string Eliminar { get { return "Eliminar"; } }
		
	}
}
