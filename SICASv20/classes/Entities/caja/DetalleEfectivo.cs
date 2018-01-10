using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Entities.caja
{
	public class DetalleEfectivo
	{
		public int Empresa_ID { get; set; }
		public double Monto { get; set; }

		public DetalleEfectivo()
		{

		}

		public DetalleEfectivo(int empresa_id, double monto)
		{
			Empresa_ID = empresa_id;
			Monto = monto;
		}
	}
}
