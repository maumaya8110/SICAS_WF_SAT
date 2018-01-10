using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20.classes.Entities.caja
{
    public class DetalleVoucher
    {

        public int Empresa_ID { get; set; }
        public int TipoVenta { get; set; }
        public string Servicio_ID { get; set; }
        public string FolioDiario { get; set; }
        public double Monto { get; set; }

    }
}
