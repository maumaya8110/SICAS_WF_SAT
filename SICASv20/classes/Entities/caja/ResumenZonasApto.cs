using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Entities.caja
{
    public class ResumenZonasApto
    {
        public int Zona_ID { get; set; }
        public string Zona { get; set; }        
        public int TipoVenta { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
    }
}
