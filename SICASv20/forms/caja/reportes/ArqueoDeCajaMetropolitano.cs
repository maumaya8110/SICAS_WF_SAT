using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.caja.reportes
{
	public partial class ArqueoDeCajaMetropolitano : baseForm
	{
		Dictionary<string, baseUserControl> UControls = new Dictionary<string, baseUserControl>();
		public SICASv20.classes.Entities.caja.CorteCaja cortecaja = new classes.Entities.caja.CorteCaja();

		public ArqueoDeCajaMetropolitano()
		{
			InitializeComponent();
			if (!Sesion.Activo)
			{
				throw new Exception("No hay una sesión activa. No se puede realizar arqueo de Caja");
			}
		}

		public void GuardaCorte()
		{
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

                                // vouchers
								ok = true;
							}
						}
						, this);

			if (ok)
			{
				//Una vez guardado el detalle, imprime los tickets
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
				//Application.Exit();
			}
		}

		private void GeneraDeclaraciones()
		{

            //Sesion.Sesion_ID = 37492;
            //Sesion.Estacion_ID = 13;
            //Sesion.Empresa_ID = 5;


			if (cortecaja.Declaraciones.Count == 0)
			{
				classes.Entities.caja.DeclaracionValores dv = new classes.Entities.caja.DeclaracionValores();


                //dv = new classes.Entities.caja.DeclaracionValores();
				dv.Empresa_Id = 601;
				dv.Empresa = "COPASA";
				dv.Nombre = "DeclaracionCopasa";
				dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
				cortecaja.Declaraciones.Add(dv);

				dv = new classes.Entities.caja.DeclaracionValores();
				dv.Empresa_Id = 2;
				dv.Empresa = "CAM";
				dv.Nombre = "DeclaracionCAM";
				dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
				cortecaja.Declaraciones.Add(dv);

				dv = new classes.Entities.caja.DeclaracionValores();
				dv.Empresa_Id = 1080;
				dv.Empresa = "EQUIPAMIENTO";
				dv.Nombre = "DeclaracionEQUIPAMIENTO";
				dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
				cortecaja.Declaraciones.Add(dv);

                //if (Sesion.Estacion_ID == 47)
                //{
                    dv = new classes.Entities.caja.DeclaracionValores();
                    dv.Empresa_Id = 1081;
                    dv.Empresa = "CASCO CAR RENTAL"; 
                    dv.Nombre = "DeclaracionCascoCarRental";
                    dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
                    dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
                    dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
                    cortecaja.Declaraciones.Add(dv);
                //}

                    //if (Sesion.Estacion_ID == 13 || Sesion.Estacion_ID == 25)
                    //{
                        dv = new classes.Entities.caja.DeclaracionValores();
                        dv.Empresa_Id = 4;
                        dv.Empresa = "CSC";
                        dv.Nombre = "DeclaracionCSC";
                        dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(Sesion.Sesion_ID, dv.Empresa_Id);
                        dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(Sesion.Sesion_ID, dv.Empresa_Id);
                        dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
                        cortecaja.Declaraciones.Add(dv);
                    //}

				dv = new classes.Entities.caja.DeclaracionValores();
				dv.Empresa_Id = 10000;
				dv.Empresa = "Otras Cuentas";
				dv.Nombre = "DeclaracionOtrasCuentas";
				dv.ValesEmpresariales = new List<classes.Entities.caja.DetalleVale>(); 
				dv.ValesPrePagados = new List<classes.Entities.caja.DetalleVale>(); 
				dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(Sesion.Sesion_ID, dv.Empresa_Id);
				dv.EslaUltima = true;
				cortecaja.Declaraciones.Add(dv);


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
				SICASv20.forms.caja.reportes.usercontrols.arqueodecaja.DeclaracionGeneralUC _DeclaracionGeneral;
				_DeclaracionGeneral = new usercontrols.arqueodecaja.DeclaracionGeneralUC(dv);
				_DeclaracionGeneral.Name = dv.Nombre;
				if (i < cortecaja.Declaraciones.Count)
					_DeclaracionGeneral.Siguiente = cortecaja.Declaraciones[i].Nombre;
				_DeclaracionGeneral.Padre = this;
				UControls.Add(dv.Nombre, _DeclaracionGeneral);
				InnerPanel.Controls.Add(_DeclaracionGeneral);
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
