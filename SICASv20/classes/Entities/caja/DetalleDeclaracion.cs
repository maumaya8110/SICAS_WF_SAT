using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Entities.caja
{
	public class DetalleDeclaracion
	{
		public int Id { get; set; }
		public int Id_Denominacion { get; set; }
		public string Descripcion_Denominacion { get; set; }
		public double Valor_Denominacion { get; set; }
		public int Cantidad { get; set; }
		public double Monto { get { return Cantidad * Valor_Denominacion; } }
	}
}
