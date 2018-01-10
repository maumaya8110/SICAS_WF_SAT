using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Entities.caja
{
	public class DetalleVale
	{
		public int Empresa_ID { get; set; }
		public int TipoVale { get; set; }
		public string Serie { get; set; }
		public string Folio { get; set; }
		public double Monto { get; set; }
	}
}
