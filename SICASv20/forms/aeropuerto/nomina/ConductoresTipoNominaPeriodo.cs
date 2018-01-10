using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class ConductoresTipoNominaPeriodo : baseForm
	{
		private BindingSource bsConductores = new BindingSource();
		private BindingSource bsAños = new BindingSource();
		private BindingSource bsPeriodos = new BindingSource();

		private DateTime periodo_ori;
		private int año_ori;

		private bool cambios = false;

		public ConductoresTipoNominaPeriodo()
		{
			InitializeComponent();
			bsConductores.AllowNew = true;
			dgvConductoresTipoNomina.AutoGenerateColumns = false;
			BindingCombos();
		}

		private void BindingCombos()
		{
			bsAños.DataSource = Entities.Año.GetAñosNomina();
			cmbAño.DataSource = bsAños;
			cmbAño.DisplayMember = "Año";
			cmbAño.ValueMember = "ID";
			cmbAño.SelectedValue = DateTime.Now.Year;
			cmbAño_SelectedValueChanged(null, null);
		}

		void cmbAño_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cambios && MessageBox.Show("Existe información sin actualizar, si continua se perderá la información modificada para este periodo. Desea Continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
			{
				cmbAño.SelectedValue = año_ori;
				return;
			}

			int año;
			try
			{
				año = (int)cmbAño.SelectedValue;
			}
			catch
			{
				Entities.Año tmpAño = (Entities.Año)cmbAño.SelectedValue;
				año = tmpAño.ID;
			}

			bsPeriodos.DataSource = Entities.PeriodoNomina.GetPeriodosNominaAño(año);
			cmbPeriodo.DataSource = bsPeriodos;
			cmbPeriodo.DisplayMember = "Semana";
			cmbPeriodo.ValueMember = "Periodo";
			if (año == DateTime.Now.Year)
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
				cmbPeriodo.SelectedValue = dt;
			}
			año_ori = año;
			cmbPeriodo_SelectedValueChanged(null, null);
			cambios = false;
		}

		void cmbPeriodo_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cambios && MessageBox.Show("Existe información sin actualizar, si continua se perderá la información modificada para este periodo. Desea Continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes)
			{
				cmbPeriodo.SelectedValue = periodo_ori;
				return;
			}

			DateTime periodo;
			try
			{
				periodo = (DateTime)cmbPeriodo.SelectedValue;
			}
			catch
			{
				Entities.PeriodoNomina per = (Entities.PeriodoNomina)cmbPeriodo.SelectedValue;
				periodo = per.Periodo;
			}
			periodo_ori = periodo;
			bsConductores.DataSource = Entities.Vista_NominaCAT.GetConductoresEnContratoPorPeriodo(periodo);
			dgvConductoresTipoNomina.DataSource = bsConductores;
			dgvConductoresTipoNomina.Refresh();
			cambios = false;

			btnAdd.Enabled = Entities.Vista_NominaCAT.EsPeriodoAbierto(periodo, Sesion.Usuario_ID);
			btnGuardar.Enabled = btnAdd.Enabled;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			classes.Aeropuerto.ConductorTipoNomina cond = new classes.Aeropuerto.ConductorTipoNomina();
			AgregaConductor frm = new AgregaConductor();
			frm.Conductor = cond;
			frm.SelectConductor = true;
			DialogResult dr = frm.ShowDialog();
			if (cond.Conductor_ID > 0)
			{
				int i = -1, j = -1;
				foreach (classes.Aeropuerto.ConductorTipoNomina con in bsConductores)
				{
					j++;
					if (con.Conductor_ID == cond.Conductor_ID)
					{
						i = j;
						break;
					}
				}

				if (i < 0)
					bsConductores.Add(cond);
				else
				{
					classes.Aeropuerto.ConductorTipoNomina c = (classes.Aeropuerto.ConductorTipoNomina)bsConductores[i];
					c.TipoNomina = cond.TipoNomina;
				}
			}
			bsConductores.EndEdit();
			dgvConductoresTipoNomina.Refresh();
			cambios = true;
		}

		private void dgvConductoresTipoNomina_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (btnGuardar.Enabled)
			{
				classes.Aeropuerto.ConductorTipoNomina cond_sel = (classes.Aeropuerto.ConductorTipoNomina)bsConductores.Current;
				AgregaConductor frm = new AgregaConductor();
				frm.Conductor = cond_sel;
				frm.SelectConductor = false;
				DialogResult dr = frm.ShowDialog();
				bsConductores.EndEdit();
				dgvConductoresTipoNomina.Refresh();
				cambios = true;
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma el almacenamiento de la información?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
			{
				foreach (classes.Aeropuerto.ConductorTipoNomina conductor in bsConductores)
				{
					Entities.Vista_NominaCAT.InsertaConductorTipoNominaPeriodo(conductor.Conductor_ID, conductor.TipoNomina.Tiponomina.TipoNomina_ID, (DateTime)cmbPeriodo.SelectedValue);
				}
			}
			cambios = false;
			MessageBox.Show("La información se almacenó con Éxito.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
			cmbPeriodo_SelectedValueChanged(null, null);
		}

		private void cmbPeriodo_Enter(object sender, EventArgs e)
		{
			periodo_ori = (DateTime)cmbPeriodo.SelectedValue;
		}

		private void cmbAño_Enter(object sender, EventArgs e)
		{
			año_ori = (int)cmbAño.SelectedValue;
		}

		private void dgvConductoresTipoNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (dgvConductoresTipoNomina.Columns[e.ColumnIndex].Name == "Eliminar")
				{
					if (btnGuardar.Enabled)
					{
						classes.Aeropuerto.ConductorTipoNomina row = (classes.Aeropuerto.ConductorTipoNomina)dgvConductoresTipoNomina.Rows[e.RowIndex].DataBoundItem;
						if (AppHelper.Confirm("¿Realmente desea eliminar al conductor de la plantilla para el periodo " + ((DateTime)cmbPeriodo.SelectedValue).ToString("dd-MM-yyyy") + "?") == System.Windows.Forms.DialogResult.Yes)
						{
							Entities.Vista_NominaCAT.QuitaConductorPeriodoNomina(row);
							cmbPeriodo_SelectedValueChanged(null, null);
						}
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}
	}
}
