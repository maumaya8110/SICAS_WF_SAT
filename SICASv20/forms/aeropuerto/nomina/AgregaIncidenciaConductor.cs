using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class AgregaIncidenciaConductor : Form
	{
		private BindingSource bsConductores = new BindingSource();
		private BindingSource bsTiposIncidencias = new BindingSource();
		private BindingSource bsPeriodo = new BindingSource();

		private classes.Aeropuerto.IncidenciaConductor modelo = new classes.Aeropuerto.IncidenciaConductor();
		public classes.Aeropuerto.IncidenciaConductor Incidencia { get { return modelo; } set { modelo = value; } }

		private DateTime Periodo
		{
			get
			{
				DateTime p;
				try
				{
					p = (DateTime)cmbPeriodos.SelectedValue;
				}
				catch
				{
					Entities.PeriodoNomina pn = (Entities.PeriodoNomina)cmbPeriodos.SelectedValue;
					p = pn.Periodo;
				}
				return p;
			}
		}

		private DateTime PeriodoActual
		{
			get
			{
				DateTime dt = DateTime.Today;
				if ((int)dt.DayOfWeek < 5)
				{
					int dw = (int)dt.DayOfWeek + 2;
					dt = dt.AddDays(dw * -1);
				}
				else if ((int)dt.DayOfWeek > 5)
				{
					dt = dt.AddDays(-1);
				}

				if (dt.Date == DateTime.Now.Date && dt.DayOfWeek == DayOfWeek.Friday)
					dt = dt.AddDays(-7);
				return dt;
			}
		}

		public AgregaIncidenciaConductor()
		{
			InitializeComponent();
			bsPeriodo.DataSource = Entities.PeriodoNomina.GetPeriodosNominaAño(DateTime.Today.Year);
			cmbPeriodos.DataSource = bsPeriodo;
			cmbPeriodos.DisplayMember = "Semana";
			cmbPeriodos.ValueMember = "Periodo";
			cmbPeriodos.SelectedValue = PeriodoActual;

			bsConductores.DataSource = Entities.Vista_NominaCAT.GetConductoresAeropuerto();
			cmbConductores.DataSource = bsConductores;
			cmbConductores.ValueMember = "Conductor_ID";
			cmbConductores.DisplayMember = "DisplayConductor";

			bsTiposIncidencias.DataSource = Entities.Vista_NominaCAT.GetTiposIncidenciasConductor();
			cmbTiposIncidencias.DataSource = bsTiposIncidencias;
			cmbTiposIncidencias.DisplayMember = "Nombre";
			cmbTiposIncidencias.ValueMember = "TipoIncidenciaConductor_ID";

			SetInfoControles();
			cmbPeriodos.SelectedValue = PeriodoActual;
		}

		private void SetInfoControles()
		{
			gbDescuento.Visible = false;
			gbDescuento.Left = 8;
			gbDescuento.Top = 75;
			gbPago.Visible = false;
			gbPago.Left = 8;
			gbPago.Top = 75;
			btnGuardar.Tag = 1;
			gbAnula.Left = 8;
			gbAnula.Top = 75;
			gbAnula.Tag = 1;

			if (modelo != null && modelo.IncidenciaConductor_ID > 0)
			{
				btnGuardar.Text = "Actualizar Incidencia";
				btnGuardar.Tag = 1;
			}
			cmbTiposIncidencias_SelectedIndexChanged(null, null);
		}

		private void cmbTiposIncidencias_SelectedIndexChanged(object sender, EventArgs e)
		{
			gbPago.Visible = false;
			gbDescuento.Visible = false;
			gbAnula.Visible = false;

			switch (
				((classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem).ClasificacionIncidencia
				)
			{
				case 1: gbPago.Visible = true; break;
				case 2: gbDescuento.Visible = true; break;
				default: gbAnula.Visible = true; break;
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
		}

		private void DoSave()
		{
			if (modelo == null)
				modelo = new classes.Aeropuerto.IncidenciaConductor();
			modelo.Conductor = (classes.Aeropuerto.ConductorNomina)cmbConductores.SelectedItem;
			modelo.TipoIncidencia = (classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem;
			modelo.Usuario_ID = Sesion.Usuario_ID;
			if (modelo.EstatusIncidencia_Conductor == null)
				modelo.EstatusIncidencia_Conductor = new classes.Aeropuerto.EstatusIncidenciaConductor();
			modelo.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID = 3;
			modelo.EstatusIncidencia_Conductor.Nombre = "Autorizada";
			modelo.FechaCaptura = DateTime.Now;
			AppHelper.Try(ValidaDatos);
			
			modelo.PeriodoAplicacionIncidencia = Periodo;
			modelo.Validate();
			GuardaIncidencia();
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void ValidaDatos()
		{
			double r;
			switch (((classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem).ClasificacionIncidencia)
			{
				case 1:
					if (txtMontoPE.Text.Trim().Length <= 0)
					{
						throw new Exception("Es necesario introducir un monto.");
					}
					if (!double.TryParse(txtMontoPE.Text, out r))
					{
						throw new Exception("El monto debe ser numerico.");
					}
					if (r <= 0)
					{
						throw new Exception("El monto debe ser mayor a 0.");
					}
					if (txtObservacionesPE.Text.Trim().Length <= 0)
					{
						throw new Exception("Es necesario introducir una observación.");
					}
					modelo.Monto = r;
					modelo.Observaciones = txtObservacionesPE.Text;
					break;
				case 2:
					if (txtMontoDesc.Text.Trim().Length <= 0 && !modelo.TipoIncidencia.AnulaMontoVariable)
					{
						throw new Exception("Es necesario introducir un monto.");
					}
					if (!double.TryParse(txtMontoDesc.Text, out r))
					{
						throw new Exception("El monto debe ser numerico.");
					}
					if (r <= 0)
					{
						throw new Exception("El monto debe ser mayor a 0.");
					}
					if (txtObservaciones.Text.Trim().Length <= 0)
					{
						throw new Exception("Es necesario introducir una observación.");
					}
					modelo.Monto = r;
					modelo.Observaciones = txtObservaciones.Text;
					break;
				default:
					if (txtObservacionGral.Text.Trim().Length <= 0)
					{
						throw new Exception("Es necesario introducir una observación.");
					}
					modelo.Observaciones = txtObservacionGral.Text;
					break;
			}
		}

		private void GuardaIncidencia()
		{
			Entities.Vista_NominaCAT.AgregaIncidenciaConductor(modelo);
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			modelo.Conductor = (classes.Aeropuerto.ConductorNomina)cmbConductores.SelectedItem;
			modelo.TipoIncidencia = (classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem;

			switch (
				((classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem).ClasificacionIncidencia
				)
			{
				case 1: modelo.Monto = Convert.ToDouble(txtMontoPE.Text);
					modelo.Observaciones = txtObservacionesPE.Text;
					break;
				case 2: modelo.Monto = Convert.ToDouble(txtMontoDesc.Text);
					modelo.Observaciones = txtObservaciones.Text;
					break;
				default: modelo.Observaciones = txtObservacionGral.Text;
					break;
			}
			modelo.Usuario_ID = Sesion.Usuario_ID;
			AppHelper.Try(CancelaIncidencia);
		}

		private void CancelaIncidencia()
		{
			modelo.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID = 2;
			modelo.EstatusIncidencia_Conductor.Nombre = "Eliminada";
			Entities.Vista_NominaCAT.AgregaIncidenciaConductor(modelo);
			Close();
		}

		private void AgregaIncidenciaConductor_Shown(object sender, EventArgs e)
		{
			if (modelo != null)
			{
				cmbConductores.Enabled = false;
				cmbConductores.SelectedValue = modelo.Conductor.Conductor_ID;

				cmbTiposIncidencias.Enabled = false;
				cmbTiposIncidencias.SelectedValue = modelo.TipoIncidencia.TipoIncidenciaConductor_ID;
				cmbPeriodos.SelectedValue = modelo.PeriodoAplicacionIncidencia;
				
				btnCancelar.Visible = modelo.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID == 3;
				btnGuardar.Visible = modelo.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID != 2 && modelo.EstatusIncidencia_Conductor.EstatusIncidenciaConductor_ID != 5;

				switch (
				((classes.Aeropuerto.TipoIncidenciaConductor)cmbTiposIncidencias.SelectedItem).ClasificacionIncidencia
				)
				{
					case 1: txtMontoPE.Text = modelo.Monto.ToString();
						txtObservacionesPE.Text = modelo.Observaciones;
						break;
					case 2: txtMontoDesc.Text = Math.Abs(modelo.Monto).ToString();
						txtObservaciones.Text = modelo.Observaciones;
						break;
					default:
						txtObservacionGral.Text = modelo.Observaciones;
						break;
				}
			}
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void dteFecha_ValueChanged(object sender, EventArgs e)
		{
			btnGuardar.Enabled = Entities.Vista_NominaCAT.EsPeriodoAbierto(Periodo, Sesion.Usuario_ID);
			btnCancelar.Enabled = btnGuardar.Enabled;
		}
	}
}
