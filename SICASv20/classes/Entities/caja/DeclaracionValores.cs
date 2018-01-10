using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Entities.caja
{
	public class DeclaracionValores
	{
		public int Empresa_Id { get; set; }
		public string Empresa { get; set; }
		public List<int> Tickets { get; set; }
		public string Nombre { get; set; }
		private bool _eslaUltima = false;
		public bool EslaUltima { get { return _eslaUltima; } set { _eslaUltima = value; } }
		private bool _eslaPrimera = false;
		public bool EslaPrimera { get { return _eslaPrimera; } set { _eslaPrimera = value; } }
		public List<DetalleDeclaracion> Billetes { get; set; }
		public List<DetalleDeclaracion> Monedas { get; set; }
		public List<DetalleVale> ValesPrePagados { get; set; }
		public List<DetalleVale> ValesEmpresariales { get; set; }
		public List<DetalleEfectivo> EfectivoSesion { get; set; }

        public List<DetalleVoucher> Vouchers { get; set; }
        public List<ResumenZonasApto> ResumenZonasApto { get; set; }

		public string Observaciones { get; set; }

		public string Incidencia
		{
			get
			{
				string msg = "";
				if (Diferencia != 0)
				{
					if (Diferencia < 0)
						msg = "Sobrante en Caja de {0:C2}";
					else
						msg = "Faltante en Caja de {0:C2}";
				}
				return string.Format(msg, Diferencia);
			}
		}

		public double Diferencia
		{
			get
			{
				return dTotalEfectivoSesion - dTotalEfectivo;
			}
		}

		public string TotalIngresosSesion
		{
			get
			{
				return string.Format("{0:C2}", dTotalIngresosSesion);
			}
		}

		public double dTotalIngresosSesion
		{
			get
			{
				double total = dTotalEfectivoSesion + dTotalValesEmpresariales + dTotalValesPrePagados + dTotalVouchers;
				return total;
			}
		}

		public string TotalIngresosDeclarados
		{
			get
			{
				return string.Format("{0:C2}", dTotalIngresosDeclarados);
			}
		}

		private double dTotalIngresosDeclarados
		{
			get
			{
                double total = dTotalEfectivo + dTotalValesEmpresariales + dTotalValesPrePagados + dTotalVouchers;
				return total;
			}
		}

		public string TotalEfectivo
		{
			get
			{
				return string.Format("{0:C2}", dTotalEfectivo);
			}
		}

		public double dTotalEfectivo
		{
			get
			{
				return dTotalBilletes + dTotalMonedas;
			}
		}

		public string TotalBilletes
		{
			get
			{
				return string.Format("{0:C2}", dTotalBilletes);
			}
		}

		public string TotalMonedas
		{
			get
			{
				return string.Format("{0:C2}", dTotalMonedas);
			}
		}

		public string TotalValesPrepagados
		{
			get
			{
				return string.Format("{0:C2}", dTotalValesPrePagados);
			}
		}

		public string TotalValesEmpresariales
		{
			get
			{
				return string.Format("{0:C2}", dTotalValesEmpresariales);
			}
		}

        public string TotalVouchers
        {
            get
            {
                return string.Format("{0:C2}", dTotalVouchers);
            }
        }

		public double dTotalBilletes
		{
			get
			{
				double total = 0;
				if (Billetes != null)
				{
					foreach (DetalleDeclaracion d in Billetes)
					{
						total += d.Monto;
					}
				}
				return total;
			}
		}

		public double dTotalMonedas
		{
			get
			{
				double total = 0;
				if (Monedas != null)
				{
					foreach (DetalleDeclaracion d in Monedas)
					{
						total += d.Monto;
					}
				}
				return total;
			}
		}

		public double dTotalValesPrePagados
		{
			get
			{
				double total = 0;
				if (ValesPrePagados != null)
				{
					foreach (DetalleVale d in ValesPrePagados)
					{
						//if (Empresa_Id > 0 && Empresa_Id == d.Empresa_ID)
						total += d.Monto;
					}
				}
				return total;
			}
		}

		public double dTotalValesEmpresariales
		{
			get
			{
				double total = 0;
				if (ValesEmpresariales != null)
				{
					foreach (DetalleVale d in ValesEmpresariales)
					{
						//if (Empresa_Id > 0 && Empresa_Id == d.Empresa_ID)
						total += d.Monto;
					}
				}
				return total;
			}
		}

        public double dTotalVouchers
        {
            get
            {
                double total = 0;
                if (Vouchers != null)
                {
                    foreach (DetalleVoucher d in Vouchers)
                    {
                        //if (Empresa_Id > 0 && Empresa_Id == d.Empresa_ID)
                        total += d.Monto;
                    }
                }
                return total;
            }
        }

		public string TotalEfectivoSesion
		{
			get
			{
				return string.Format("{0:C2}", dTotalEfectivoSesion);
			}
		}

		public double dTotalEfectivoSesion
		{
			get
			{
				double tot = 0;
				if (EfectivoSesion != null)
				{
					foreach (DetalleEfectivo de in EfectivoSesion)
					{
						tot += de.Monto;
					}
				}
				return tot;
			}
		}
	}
}
