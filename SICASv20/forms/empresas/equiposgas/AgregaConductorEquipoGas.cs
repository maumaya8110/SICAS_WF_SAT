using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SICASv20.Entities.EquipoGas;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class AgregaConductorEquipoGas : Form
	{
		private List<Conductor> lConductores = new List<Conductor>();
		private List<Equipo> lEquipos = new List<Equipo>();
		public ConductorEquipo Registro { get; set; }

		public AgregaConductorEquipoGas()
		{
			InitializeComponent();

			lConductores = Conductor.GetConductores();
			cmbConductor.DataSource = lConductores;

			lEquipos = Equipo.GetEquiposDisponibles();
			cmbEquipo.DataSource = lEquipos;
	
			dteFechaInicio.Value = DateTime.Now;
			dteFechaFin.Value = DateTime.Now;
		}

		private void cmdEquipo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			lblPrecio.Text = "";
			lblMontoDiario.Text = "";
			lblCantDias.Text = "";
			lblProveedor.Text = "";

			Entities.EquipoGas.Equipo eg = (Entities.EquipoGas.Equipo)cmbEquipo.SelectedItem;
			if (eg == null && Registro  != null && Registro.Equipo_Gas != null)
			{
				lEquipos = new List<Equipo>();
				lEquipos.Add(Registro.Equipo_Gas);
				cmbEquipo.DataSource = lEquipos;
				cmbEquipo.SelectedItem = Registro.Equipo_Gas;
				cmbEquipo.SelectedValue = Registro.Equipo_Gas.Id;
				cmbEquipo.Text = Registro.Equipo_Gas.NumeroSerieKit;
				eg = (Entities.EquipoGas.Equipo)cmbEquipo.SelectedItem;
			}

			if (eg == null || eg.Id == null)
			{
				MessageBox.Show("No hay equipos disponibles para asignar.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			lblPrecio.Text = eg.Precio.ToString("C");
			lblMontoDiario.Text = eg.MontoDiario.ToString("C");
			lblCantDias.Text = eg.CantidadDiasApagar.ToString();
			lblProveedor.Text = eg.proveedor.Nombre;
			dteFechaFin.Value = dteFechaInicio.Value.AddDays(eg.CantidadDiasApagar);
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AgregaConductorEquipoGas_Shown(object sender, EventArgs e)
		{
			if (Registro != null)
			{
				this.Text = "Edita - Conductor Equipo Gas";
				this.btnAgregar.Text = "Guardar";
				cmbConductor.SelectedValue = Registro.Conductor.Id;
				cmbConductor.Text = Registro.Conductor.Nombre;
				cmbEquipo.SelectedValue = Registro.Equipo_Gas.Id;
				cmbEquipo.Text = Registro.Equipo_Gas.Descripcion;
				dteFechaFin.Value = Registro.FechaFin;
				dteFechaInicio.Value = Registro.FechaInicio;
				chkCobroActivo.Checked = Registro.CobroActivo;
				cmbEquipo.Enabled = dteFechaInicio.Value.Date >= DateTime.Now.Date;
				dteFechaInicio.Enabled = dteFechaInicio.Value.Date >= DateTime.Now.Date;

				cmbConductor.Enabled = false;
				cmbEquipo.Enabled = false;

				btnAgregar.Enabled = Registro.Estatus == 1;
				btnBaja.Enabled = Registro.Estatus == 1;
			}
			cmdEquipo_SelectionChangeCommitted(null, null);
		}

		private void dteFechaInicio_ValueChanged(object sender, EventArgs e)
		{
			Equipo eg = (Equipo)cmbEquipo.SelectedItem;
			if (eg != null && eg.Id != null)
			{
				dteFechaFin.Value = dteFechaInicio.Value.AddDays(eg.CantidadDiasApagar);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (Registro == null)
			{
				Registro = new ConductorEquipo();
				Registro.Id = null;
				Registro.Conductor = (Conductor)cmbConductor.SelectedItem;
				Registro.Equipo_Gas = (Equipo)cmbEquipo.SelectedItem;
			}
			Registro.FechaInicio = dteFechaInicio.Value;
			Registro.FechaFin = dteFechaFin.Value;
			Registro.MontoDiario = Convert.ToDouble(Registro.Equipo_Gas.MontoDiario);
			Registro.CobroActivo = chkCobroActivo.Checked;
			if (!Entities.EquipoGas.ConductorEquipo.InsertaConductorEquipoGas(Registro))
			{
				MessageBox.Show("Ocurrió un error al realizar la operación.");
				return;
			}
			MessageBox.Show("El registro se guardo con éxito.");
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void btnBaja_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma la Baja del Equipo?" + Environment.NewLine +
				"Conductor: " + ((Entities.EquipoGas.Conductor)cmbConductor.SelectedItem).Nombre + Environment.NewLine +
				"Equipo: " + ((Entities.EquipoGas.Equipo)cmbEquipo.SelectedItem).NumeroSerieKit + Environment.NewLine
				+ "Al realizar la baja el equipo de Gas el mismo quedará disponible para ser asignado a otro conductor", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				if (Registro != null)
				{
					if (!Entities.EquipoGas.ConductorEquipo.BajaDeEquipo(Registro))
					{
						AppHelper.Error("Ocurrió un error al realizar la baja");
					}
				}
				AppHelper.Info("El proceso se realizó con éxito");
				Close();
			}
		}
	}
}
