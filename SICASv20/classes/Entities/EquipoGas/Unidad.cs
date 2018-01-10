using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.Entities.EquipoGas
{
	public class Unidad
	{
		public int Id { get; set; }
		public int NumeroEconomico { get; set; }

		public override string ToString()
		{
			return NumeroEconomico.ToString();
		}
	}
}
