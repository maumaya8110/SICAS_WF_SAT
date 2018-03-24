using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.caja.herramientas
{
	public partial class ReimpresionDeclaracionCorteCaja : baseForm
	{
		public SICASv20.classes.Entities.caja.CorteCaja cortecaja = new classes.Entities.caja.CorteCaja();

		public ReimpresionDeclaracionCorteCaja()
		{
			InitializeComponent();
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(ImprimirTckets,this);
		}

		private void ImprimirTckets()
        {
            //Sesion.Sesion_ID = 37492;
            //Sesion.Caja_ID = 13;

			SICASv20.Entities.Sesiones UltimaSesionCerrada = Entities.Sesiones.GetUltimaSesionPorUsuarioCaja(Sesion.Usuario_ID, Sesion.Caja_ID);

            UltimaSesionCerrada.Sesion_ID = Sesion.Sesion_ID;
            ObtieneDeclaracionesCorteCaja(UltimaSesionCerrada.Sesion_ID);




			int idx = 1;
			foreach (classes.Entities.caja.DeclaracionValores dv in cortecaja.Declaraciones)
			{
				SICASv20.classes.Interfaces.DeclaracionValores.Imprimir(dv, idx);
				SICASv20.classes.Interfaces.DeclaracionValores.Imprimir(dv, idx);
				idx++;
			}
		}

		private void ObtieneDeclaracionesCorteCaja(int sesion)
		{
			cortecaja.Declaraciones.Clear();

          //  Sesion.Sesion_ID = 37492;

            classes.Entities.caja.DeclaracionValores dv = new classes.Entities.caja.DeclaracionValores();


            //dv = new classes.Entities.caja.DeclaracionValores();
            dv.Empresa_Id = 601;
            dv.Empresa = "COPASA";
            dv.Nombre = "DeclaracionCopasa";
            dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            cortecaja.Declaraciones.Add(dv);

            dv = new classes.Entities.caja.DeclaracionValores();
            dv.Empresa_Id = 2;
            dv.Empresa = "CAM";
            dv.Nombre = "DeclaracionCAM";
            dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            cortecaja.Declaraciones.Add(dv);

            dv = new classes.Entities.caja.DeclaracionValores();
            dv.Empresa_Id = 1080;
            dv.Empresa = "EQUIPAMIENTO";
            dv.Nombre = "DeclaracionEQUIPAMIENTO";
            dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            cortecaja.Declaraciones.Add(dv);

            //if (Sesion.Estacion_ID == 47)
            //{
            dv = new classes.Entities.caja.DeclaracionValores();
            dv.Empresa_Id = 1081;
            dv.Empresa = "CASCO CAR RENTAL";
            dv.Nombre = "DeclaracionCascoCarRental";
            dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            cortecaja.Declaraciones.Add(dv);
            //}

            //if (Sesion.Estacion_ID == 13 || Sesion.Estacion_ID == 25)
            //{
                dv = new classes.Entities.caja.DeclaracionValores();
                dv.Empresa_Id = 4;
                dv.Empresa = "CSC";
                dv.Nombre = "DeclaracionCSC";
                dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
                dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
                dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
                dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
                dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
                cortecaja.Declaraciones.Add(dv);
            //}

            dv = new classes.Entities.caja.DeclaracionValores();
            dv.Empresa_Id = 10000;
            dv.Empresa = "Otras Cuentas";
            dv.Nombre = "DeclaracionOtrasCuentas";
            dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            dv.EslaUltima = true;
            cortecaja.Declaraciones.Add(dv);


            //classes.Entities.caja.DeclaracionValores dv = new classes.Entities.caja.DeclaracionValores();
            //dv.Empresa_Id = 601;
            //dv.Empresa = "COPASA";
            //dv.Nombre = "DeclaracionCopasa";
            //dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            //dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            //dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            //dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            //dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            //cortecaja.Declaraciones.Add(dv);

            //dv = new classes.Entities.caja.DeclaracionValores();
            //dv.Empresa_Id = 2;
            //dv.Empresa = "CAM";
            //dv.Nombre = "DeclaracionCAM";
            //dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            //dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            //dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            //dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            //dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            //cortecaja.Declaraciones.Add(dv);

            ////dv = new classes.Entities.caja.DeclaracionValores();
            ////dv.Empresa_Id = 1074;
            ////dv.Empresa = "CRECIMIENTO";
            ////dv.Nombre = "DeclaracionCRECIMIENTO";
            ////dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            ////dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            ////dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            ////dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            ////dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            ////cortecaja.Declaraciones.Add(dv);

            //dv = new classes.Entities.caja.DeclaracionValores();
            //dv.Empresa_Id = 1080;
            //dv.Empresa = "EQUIPAMIENTO";
            //dv.Nombre = "DeclaracionEQUIPAMIENTO";
            //dv.ValesEmpresariales = SICASv20.classes.Interfaces.DeclaracionValores.GetValesEmpresariales(sesion, dv.Empresa_Id);
            //dv.ValesPrePagados = SICASv20.classes.Interfaces.DeclaracionValores.GetValesPrepagados(sesion, dv.Empresa_Id);
            //dv.EfectivoSesion = SICASv20.classes.Interfaces.DeclaracionValores.GetEfectivoPorSesion(sesion, dv.Empresa_Id);
            //dv.Billetes = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionBilletes(sesion, dv.Empresa_Id);
            //dv.Monedas = SICASv20.classes.Interfaces.DeclaracionValores.GetDeclaracionMonedas(sesion, dv.Empresa_Id);
            //dv.EslaUltima = true;
            //cortecaja.Declaraciones.Add(dv);
		}

	}
}
