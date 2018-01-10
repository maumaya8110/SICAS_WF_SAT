using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.caja.reportes.usercontrols.arqueodecaja
{
	public partial class DeclaracionAptoUC : baseUserControl
	{
		public SICASv20.classes.Entities.caja.DeclaracionValores Declaracion;
		private BindingSource bsBilletes = new BindingSource();
		private BindingSource bsMonedas = new BindingSource();
        public SICASv20.forms.caja.reportes.ArqueoDeCajaApto Padre = new ArqueoDeCajaApto();
		//public SICASv20.forms.caja.reportes.ArqueoDeCajaApto PadreApto = new ArqueoDeCajaApto();
		public string Siguiente { get; set; }

        public DeclaracionAptoUC(SICASv20.classes.Entities.caja.DeclaracionValores dv)
		{
			InitializeComponent();
			Declaracion = dv;
			lblTitle.Text = Declaracion.Empresa;
			if(dv.EslaUltima)
				btnSiguiente.Text = "Guardar";
            if (dv.EslaPrimera || dv.EslaUltima)
            {
                lblTotSesion.Visible = false;
                lblDiferencia.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
			dgvBilletes.AutoGenerateColumns = false;
			dgvMonedas.AutoGenerateColumns = false;
			bsBilletes.CurrentItemChanged += new EventHandler(bsBilletes_CurrentItemChanged);
			bsMonedas.CurrentItemChanged += new EventHandler(bsMonedas_CurrentItemChanged);
			BindingFields();
		}

		void bsMonedas_CurrentItemChanged(object sender, EventArgs e)
		{
			SetTotales();
		}

		void bsBilletes_CurrentItemChanged(object sender, EventArgs e)
		{
			SetTotales();
		}

		private void SetTotales()
		{
			lblTotBilletes.Text = Declaracion.TotalBilletes;
			lblMonedas.Text = Declaracion.TotalMonedas;
			lblTotEfectivo.Text = Declaracion.TotalEfectivo;

			lblTotVp.Text = Declaracion.TotalValesPrepagados;
            lblNumPrepago.Text = Declaracion.ValesPrePagados.Count.ToString();
			lblTotVE.Text = Declaracion.TotalValesEmpresariales;
            lblNumEmpresarial.Text = Declaracion.ValesEmpresariales.Count.ToString();

			lblTotGeneral.Text = Declaracion.TotalIngresosDeclarados;
			lblTotSesion.Text = Declaracion.TotalIngresosSesion;
			lblDiferencia.Text = string.Format("{0:C2}", Declaracion.Diferencia);

            lblTotalVouchers.Text = Declaracion.TotalVouchers;
            lblNumVouchers.Text = Declaracion.Vouchers.Count.ToString();

			lblDiferencia.BackColor = Color.White;
			lblDiferencia.ForeColor = Color.Black;
			if (Declaracion.Diferencia != 0)
			{
				lblDiferencia.BackColor = Color.Red;
				lblDiferencia.ForeColor = Color.White;
			}
		}

		private void BindingFields()
		{
			BindingBilletes();
			BindingMonedas();
		}

		private void BindingMonedas()
		{
			Declaracion.Monedas = new List<classes.Entities.caja.DetalleDeclaracion>();
			SICASv20.classes.Entities.caja.DetalleDeclaracion det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 7;
			det.Descripcion_Denominacion = "$20.00";
			det.Valor_Denominacion = 20;
			Declaracion.Monedas.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 8;
			det.Descripcion_Denominacion = "$10.00";
			det.Valor_Denominacion = 10;
			Declaracion.Monedas.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 9;
			det.Descripcion_Denominacion = "$5.00";
			det.Valor_Denominacion = 5;
			Declaracion.Monedas.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 10;
			det.Descripcion_Denominacion = "$2.00";
			det.Valor_Denominacion = 2;
			Declaracion.Monedas.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 11;
			det.Descripcion_Denominacion = "$1.00";
			det.Valor_Denominacion = 1;
			Declaracion.Monedas.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 12;
			det.Descripcion_Denominacion = "$0.50";
			det.Valor_Denominacion = .5;
			Declaracion.Monedas.Add(det);
			bsMonedas.DataSource = Declaracion.Monedas;
			dgvMonedas.DataSource = bsMonedas;
		}

		private void BindingBilletes()
		{
			Declaracion.Billetes = new List<classes.Entities.caja.DetalleDeclaracion>();
			SICASv20.classes.Entities.caja.DetalleDeclaracion det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 1;
			det.Descripcion_Denominacion = "$1000.00";
			det.Valor_Denominacion = 1000;
			Declaracion.Billetes.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 2;
			det.Descripcion_Denominacion = "$500.00";
			det.Valor_Denominacion = 500;
			Declaracion.Billetes.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 3;
			det.Descripcion_Denominacion = "$200.00";
			det.Valor_Denominacion = 200;
			Declaracion.Billetes.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 4;
			det.Descripcion_Denominacion = "$100.00";
			det.Valor_Denominacion = 100;
			Declaracion.Billetes.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 5;
			det.Descripcion_Denominacion = "$50.00";
			det.Valor_Denominacion = 50;
			Declaracion.Billetes.Add(det);

			det = new classes.Entities.caja.DetalleDeclaracion();
			det.Id_Denominacion = 6;
			det.Descripcion_Denominacion = "$20.00";
			det.Valor_Denominacion = 20;
			Declaracion.Billetes.Add(det);
			bsBilletes.DataSource = Declaracion.Billetes;

			dgvBilletes.DataSource = bsBilletes;
		}

		private void btnSiguiente_Click(object sender, EventArgs e)
		{
			try
			{
				DoValidate();
				if (MessageBox.Show("Es correcta la información?","Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					Declaracion.Observaciones = txtObservaciones.Text;
					if (!Declaracion.EslaUltima)
					{
						Padre.SwitchPanel(Siguiente);
					}
					else
					{
						Padre.GuardaCorte();
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void DoValidate()
		{

		}

		private void dgvBilletes_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("El valor debe ser un número entero");
			e.Cancel = true;
		}

        private void label9_Click(object sender, EventArgs e)
        {

        }
	}
}
