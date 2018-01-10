using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Aeropuerto
{
	public class IncidenciaConductor
	{
		public int IncidenciaConductor_ID { get; set; }
		public ConductorNomina Conductor { get; set; }
		public TipoIncidenciaConductor TipoIncidencia { get; set; }
		public string Observaciones { get; set; }
		public string Usuario_ID { get; set; }
		public DateTime FechaCaptura { get; set; }
		public EstatusIncidenciaConductor EstatusIncidencia_Conductor { get; set; }
		public DateTime PeriodoAplicacionIncidencia { get; set; }
		public double Monto { get; set; }

		public void Validate()
		{
			if (this.Conductor == null || this.Conductor.Conductor_ID <= 0)
				throw new Exception("Es necesario indicar un Conductor.");
			if (this.TipoIncidencia == null || this.TipoIncidencia.TipoIncidenciaConductor_ID <= 0)
				throw new Exception("Es necesario indicar un Tipo de Incidencia");
			if (string.IsNullOrEmpty(this.Observaciones))
				throw new Exception("Es necesario indicar el motivo de la incidencia");
		}
	}

	public class ConductorNomina
	{
		public int Conductor_ID { get; set; }
		public string Conductor { get; set; }
		public string DisplayConductor { get { return string.Format("{0} - {1}", Conductor_ID, Conductor); } }

		public ConductorNomina() { }
		public ConductorNomina(int id, string nombre)
		{
			this.Conductor_ID = id;
			this.Conductor = nombre;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Conductor_ID, Conductor); 
		}
	}

	public class TipoIncidenciaConductor
	{
		public int TipoIncidenciaConductor_ID { get; set; }
		public string Nombre { get; set; }
		public bool AnulaMontoVariable { get; set; }
		public int ClasificacionIncidencia { get; set; }

		public TipoIncidenciaConductor() { }

		public TipoIncidenciaConductor(int id, string nombre, bool anulamontovariable, int clasificacionincidencia)
		{
			this.TipoIncidenciaConductor_ID = id;
			this.Nombre = nombre;
			this.AnulaMontoVariable = anulamontovariable;
			this.ClasificacionIncidencia = clasificacionincidencia;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", TipoIncidenciaConductor_ID, Nombre);
		}
	}

	public class EstatusIncidenciaConductor
	{
		public int EstatusIncidenciaConductor_ID { get; set; }
		public string Nombre { get; set; }

		public EstatusIncidenciaConductor() { }

		public EstatusIncidenciaConductor(int id, string nombre)
		{
			this.EstatusIncidenciaConductor_ID = id;
			this.Nombre = nombre;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", EstatusIncidenciaConductor_ID, Nombre);
		}
	}
}
