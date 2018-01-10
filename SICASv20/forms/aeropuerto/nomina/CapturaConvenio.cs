using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class CapturaConvenio : baseForm
	{
		private List<classes.Aeropuerto.nomina.convenios.Empresa> lEmpresas = new List<classes.Aeropuerto.nomina.convenios.Empresa>();
		private List<classes.Aeropuerto.nomina.convenios.Estacion> lEstaciones = new List<classes.Aeropuerto.nomina.convenios.Estacion>();
		private List<classes.Aeropuerto.nomina.convenios.Conductor> lConductores = new List<classes.Aeropuerto.nomina.convenios.Conductor>();
		private List<classes.Aeropuerto.nomina.convenios.TipoConvenio> lTiposConvenio = new List<classes.Aeropuerto.nomina.convenios.TipoConvenio>();
		classes.Aeropuerto.nomina.convenios.Convenio convenio = new classes.Aeropuerto.nomina.convenios.Convenio();

		public classes.Aeropuerto.nomina.convenios.Convenio Convenio {
			get { return convenio; }
			set { convenio = value; }
		}

		public CapturaConvenio()
		{
			InitializeComponent();
			BindingCombos();
			SetValues();
			dteFechaCaptura.Value = DateTime.Today;
			dteFechaPrimerDcto.Value = DateTime.Today;
		}

		private void SetValues()
		{
			cmbEmpresa.SelectedIndex = 0;
			cmbEstacion.SelectedIndex = 0;
			cmbConductor.SelectedIndex = 0;
			cmbTipoConvenio.SelectedIndex = 0;
			dteFechaCaptura.Value = DateTime.Today;
			txtMontoTotal.Value = 0;
			txtMontoParcialidad.Value = 0;
			txtSaldoActual.Text = "$0.00";
			txtDctos.Text = "0";
			txtDctosApl.Text = "0";
			txtDctosPend.Text = "0";
			dteFechaPrimerDcto.Value = DateTime.Today;
			txtFechaUltimoDescuento.Text = DateTime.Today.ToString("dd/MM/yyyy hh:mm");
			chkConvenioFirmado.Checked = false;
			txtObservaciones.Clear();
			txtMontoMinimoParaDescuento.Value = 0;

			if (convenio.ID > 0)
			{
				cmbEmpresa.SelectedValue = convenio.Empresa.Id;
				cmbEstacion.SelectedValue = convenio.Estacion.Id;
				cmbConductor.SelectedValue =  convenio.Conductor.Id;
				cmbTipoConvenio.SelectedValue = convenio.TipoConvenio.Id;
				dteFechaCaptura.Value = convenio.FechaElaboracion.Date;
				txtMontoTotal.Value = (decimal)convenio.MontoTotalAPagar;
				txtMontoParcialidad.Value = (decimal)convenio.MontoParcialidad;
				txtSaldoActual.Text = convenio.SaldoActual.ToString("C2");
				txtDctos.Text = convenio.CantidadDescuentos.ToString();
				txtDctosApl.Text = convenio.CantidadDescuentosAplicados.ToString();
				txtDctosPend.Text = convenio.CantidadDescuentosPendientes.ToString();
				dteFechaPrimerDcto.Value = convenio.FechaPrimerDescuento;
				txtFechaUltimoDescuento.Text = convenio.UltimaFechaDescuento.ToString("dd/MM/yyyy hh:mm");
				chkConvenioFirmado.Checked = convenio.TieneDocumentoFirmado;
				txtObservaciones.Text = convenio.Observaciones;
				txtMontoMinimoParaDescuento.Value = (decimal)convenio.MontoMinimoParaAplicarDescuento;
			}
		}

		private void GetValues()
		{
			convenio.Empresa = (classes.Aeropuerto.nomina.convenios.Empresa)cmbEmpresa.SelectedItem;
			convenio.Estacion = (classes.Aeropuerto.nomina.convenios.Estacion)cmbEstacion.SelectedItem;
			convenio.Conductor = (classes.Aeropuerto.nomina.convenios.Conductor)cmbConductor.SelectedItem;
			convenio.TipoConvenio = (classes.Aeropuerto.nomina.convenios.TipoConvenio)cmbTipoConvenio.SelectedItem;
			convenio.FechaElaboracion = dteFechaCaptura.Value;
			convenio.FechaPrimerDescuento = dteFechaPrimerDcto.Value;
			convenio.MontoTotalAPagar = (double)txtMontoTotal.Value;
			convenio.MontoParcialidad = (double)txtMontoParcialidad.Value;
			convenio.TieneDocumentoFirmado = chkConvenioFirmado.Checked;
			convenio.CantidadDescuentos = Convert.ToInt32(txtDctos.Text);
			convenio.CantidadDescuentosPendientes = Convert.ToInt32(txtDctosPend.Text);
			convenio.Observaciones = txtObservaciones.Text;
			convenio.MontoMinimoParaAplicarDescuento = (double)txtMontoMinimoParaDescuento.Value;
			if (convenio.ID <= 0)
				convenio.Usuario_ID = Sesion.Usuario_ID;
		}

		private void BindingCombos()
		{
			lEmpresas = classes.Aeropuerto.nomina.convenios.Empresa.GetEmpresas(Sesion.Usuario_ID);
			lEstaciones = classes.Aeropuerto.nomina.convenios.Estacion.GetEstaciones(Sesion.Usuario_ID);
			lTiposConvenio = classes.Aeropuerto.nomina.convenios.TipoConvenio.GetTiposConvenios(null);
			cmbEmpresa.DataSource = lEmpresas;
			cmbEstacion.DataSource = lEstaciones;
			cmbTipoConvenio.DataSource = lTiposConvenio;
			cmbEmpresa_SelectionChangeCommitted(null, null);
		}

		private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
		{
			SICASv20.classes.Aeropuerto.nomina.convenios.Empresa eaux = (SICASv20.classes.Aeropuerto.nomina.convenios.Empresa)cmbEmpresa.SelectedItem;
			lConductores = classes.Aeropuerto.nomina.convenios.Conductor.GetConductores(eaux.Id.ToString());
			lConductores.Insert(0, new classes.Aeropuerto.nomina.convenios.Conductor(0, "Todos"));
			cmbConductor.DataSource = lConductores;
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(GuardarConvenio,this);
		}

		private void GuardarConvenio()
		{
			GetValues();
			Validar();
			convenio.ID = classes.Aeropuerto.nomina.convenios.Convenio.InsertaConvenio(convenio);
			if (convenio.ID > 0)
			{
				AppHelper.Info("Convenio guardado con éxito");
				convenio = new classes.Aeropuerto.nomina.convenios.Convenio();
				SetValues();
			}
			else
			{
				AppHelper.Info("Ocurrió un error al guardar, verifique la información e inténtelo nuevamente.");
			}
		}

		private void Validar()
		{
			if (convenio.Conductor.Id <= 0)
				throw new Exception("Es necesario seleccionar un Conductor");
			if (convenio.MontoTotalAPagar <= 0)
				throw new Exception("El Monto Total debe ser mayor a 0");
			if (convenio.MontoParcialidad <= 0)
				throw new Exception("El Monto del Descuento debe ser mayor a 0");
			if (convenio.MontoTotalAPagar < convenio.SaldoActual)
				throw new Exception("El Monto Total a Pagar debe ser mayor al saldo Actual");
			if (convenio.MontoParcialidad > convenio.MontoTotalAPagar)
				throw new Exception("El Monto Total a Pagar debe ser mayor al Monto del descuento");
			if (convenio.FechaPrimerDescuento < DateTime.Today && convenio.ID <= 0)
				throw new Exception("La fecha del primer descuento debe ser mayor al día Actual");
		}

		private void CapturaConvenio_Shown(object sender, EventArgs e)
		{
			dteFechaPrimerDcto.Enabled = true;
			if (convenio.ID > 0)
			{
				dteFechaPrimerDcto.Enabled = false;
				SetValues();
			}
		}

		private void txtMontoParcialidad_ValueChanged(object sender, EventArgs e)
		{
			if (txtMontoParcialidad.Value > 0)
				txtDctos.Text = (Math.Ceiling(txtMontoTotal.Value / txtMontoParcialidad.Value)).ToString();
		}

		private void cmbConductor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			classes.Aeropuerto.nomina.convenios.Conductor conductor = (classes.Aeropuerto.nomina.convenios.Conductor)cmbConductor.SelectedItem;
			if (conductor.Id > 0)
			{
				double saldo = classes.Aeropuerto.nomina.convenios.Convenio.GetMontoAdeudoPorConveniosDelConductor(conductor.Id);
				if (saldo != 0)
				{
					if (AppHelper.Confirm(string.Format("El conductor {0}, actualmente tiene un saldo de {1:C2}. Desea generar otro convenio para este conductor?", conductor.Nombre, saldo)) == System.Windows.Forms.DialogResult.No)
					{
						cmbConductor.SelectedValue = 0;
					}
				}
			}
		}
	}
}
