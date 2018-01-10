using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace SICASv20.classes.Entities.caja
{
	public class CorteCaja
	{
		public int Sesion { get; set; }
		public DateTime Fecha { get; set; }
		private List<DeclaracionValores> _Declaraciones = new List<DeclaracionValores>();
		public List<DeclaracionValores> Declaraciones
		{
			get { return _Declaraciones; }
			set { _Declaraciones = value; }
		}
	}
}
