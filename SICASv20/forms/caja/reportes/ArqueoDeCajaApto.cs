using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.caja.reportes
{
	public partial class ArqueoDeCajaApto : baseForm
	{
		Dictionary<string, baseUserControl> UControls = new Dictionary<string, baseUserControl>();
		public SICASv20.classes.Entities.caja.CorteCaja cortecaja = new classes.Entities.caja.CorteCaja();

		public ArqueoDeCajaApto()
		{
			InitializeComponent();
			if (!Sesion.Activo)
			{
				throw new Exception("No hay una sesión activa. No se puede realizar arqueo de Caja");
			}
		}

		public void GuardaCorte()
		{
            //if (cortecaja.Declaraciones.Count == 0)
            //{
            //    GeneraDeclaraciones();
            //}
			bool ok = false;
			AppHelper.DoTransactions(
						delegate
						{
							foreach (classes.Entities.caja.DeclaracionValores dv in cortecaja.Declaraciones)
							{
								ok = false;
								SICASv20.classes.Interfaces.DeclaracionValores.GuardaDeclaracion(dv);
								SICASv20.classes.Interfaces.DeclaracionValores.GuardaDetalleEfectivo(dv);
								SICASv20.classes.Interfaces.DeclaracionValores.GuardaDetalleVales(dv);
                                SICASv20.classes.Interfaces.DeclaracionValores.GuardaDetalleVouchers(dv);
								ok = true;
							}
						}
						, this);

			if (ok)
			{
				int idx = 1;
				foreach (classes.Entities.caja.DeclaracionValores dv in cortecaja.Declaraciones)
				{
					ok = false;
					SICASv20.classes.Interfaces.DeclaracionValores.Imprimir(dv, idx);
					SICASv20.classes.Interfaces.DeclaracionValores.Imprimir(dv, idx);
					ok = true;
					idx++;
				}
				// Cerrar la sesión
				Entities.Sesiones sesion = Entities.Sesiones.Read(Sesion.Sesion_ID);
				sesion.Activo = false;
				sesion.FechaFinal = DB.GetDate();
				sesion.Update();
				Sesion.Activo = false;
				SICASv20.forms.SICASForm fp = (SICASv20.forms.SICASForm)this.ParentForm;
				fp.SwitchForma("ReporteTicketsDeSesion");
				Application.Exit();
			}
		}

		private void GeneraDeclaraciones()
		{
			if (cortecaja.Declaraciones.Count == 0)
			{
				classes.Entities.caja.DeclaracionValores dv = new classes.Entities.caja.DeclaracionValores();
				dv.Empresa_Id = 3;
				dv.Empresa = "CAT";
				dv.Nombre = "DeclaracionCAT";
                dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoAptoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
                dv.Vouchers = SICASv20.classes.Interfaces.DeclaracionValores.GetVouchersApto(Sesion.Sesion_ID, dv.Empresa_Id);
                dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
                dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
                dv.ResumenZonasApto = SICASv20.classes.Interfaces.DeclaracionValores.GetResumenZonasApto(Sesion.Sesion_ID, dv.Empresa_Id);

				//dv.EslaPrimera = true;
				dv.EslaUltima = true;
				cortecaja.Declaraciones.Add(dv);


                //dv = new classes.Entities.caja.DeclaracionValores();
                //dv.Empresa_Id = 10000;
                //dv.Empresa = "Otras Cuentas";
                //dv.Nombre = "DeclaracionOtrasCuentas";
                //dv.ValesEmpresariales = new List<classes.Entities.caja.DetalleVale>();
                //dv.ValesPrePagados = new List<classes.Entities.caja.DetalleVale>();
                //dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoAptoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
                //dv.EslaUltima = true;
                //cortecaja.Declaraciones.Add(dv);
			}
		}

		private void LoadUserControls()
		{
			GeneraDeclaraciones();
			UControls.Clear();
			InnerPanel.Controls.Clear();
			int i = 1;
			foreach (classes.Entities.caja.DeclaracionValores dv in cortecaja.Declaraciones)
			{
				SICASv20.forms.caja.reportes.usercontrols.arqueodecaja.DeclaracionAptoUC _DeclaracionApto;
                _DeclaracionApto = new usercontrols.arqueodecaja.DeclaracionAptoUC(dv);
                _DeclaracionApto.Name = dv.Nombre;
				if (i < cortecaja.Declaraciones.Count)
                    _DeclaracionApto.Siguiente = cortecaja.Declaraciones[i].Nombre;
                _DeclaracionApto.Padre = this;
                UControls.Add(dv.Nombre, _DeclaracionApto);
                InnerPanel.Controls.Add(_DeclaracionApto);
                //_DeclaracionApto
				i++;
			}
		}

		public void SwitchPanel(string name)
		{
			Control c = InnerPanel.Controls[name];
			if (c != null)
				c.BringToFront();
		}

		public override void BindData()
		{
			LoadUserControls();
			SwitchPanel("DeclaracionGeneral");
			base.BindData();
		}
	}
}
