using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.herramientas
{
	public partial class ActualizaKilometrajeNomina : Form
	{
		Entities.DatosConductorUnidad conductor = new Entities.DatosConductorUnidad();

		public ActualizaKilometrajeNomina()
		{
			InitializeComponent();
		}

		public ActualizaKilometrajeNomina(Entities.DatosConductorUnidad conductor)
		{
			InitializeComponent();
			this.conductor = conductor;
			UnidadTextBox.Text = conductor.NumeroEconomico.ToString();
			ConductorTextBox.Text = conductor.Conductor;
			KilometrajeAnteriorTextBox.Text = conductor.Kilometraje.ToString();
		}

		private void ActualizarKilometraje()
		{
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text))
			{
				//  Si los datos son numéricos
				if (AppHelper.IsNumeric(KilometrajeActualTextBox.Text))
				{
					//  Ingresamos el registro de kilometraje
					Entities.Unidades_Kilometrajes uk = new Entities.Unidades_Kilometrajes();
					uk.Unidad_ID = conductor.Unidad_ID.Value;
					uk.Kilometraje = Convert.ToInt32(this.KilometrajeActualTextBox.Text);
					uk.Conductor_ID = this.conductor.Conductor_ID;
					uk.Fecha = DB.GetDate();
					uk.Create();

					//  Actualizamos el kilometraje en la unidad
					DB.UpdateRow(
					    "Unidades",
					    DB.GetParams(
						   DB.Param("Kilometraje", uk.Kilometraje)
					    ),
					    DB.GetParams(
						   DB.Param("Unidad_ID", uk.Unidad_ID)
					    )
					);
					AppHelper.Info("Kilometraje actualizado");
				} // end if
			} // end if
		} // end void ActualizarKilometraje

		private void ActualizarConsumoCombustible()
		{
			if (!string.IsNullOrEmpty(txtLitros.Text))
			{
				//  Si los datos son numéricos
				if (AppHelper.IsNumeric(txtLitros.Text))
				{
					//  Ingresamos el registro de kilometraje
					Entities.Unidades_ConsumoCombustible uc = new Entities.Unidades_ConsumoCombustible();
					uc.Unidad_ID = conductor.Unidad_ID.Value;
					uc.ConsumoEnLitros = Convert.ToDouble(this.txtLitros.Text);
					uc.Conductor_ID = this.conductor.Conductor_ID;
					uc.FechaConsumo = DB.GetDate();

					uc.Validate();
					uc.InsertaConsumo();
					AppHelper.Info("Consumo Almacenado");
				} // end if
			} // end if
		} // end void ActualizarConsumoCombustible

		private void KilometrajeActualTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				btnActualiza_Click(null, null);
			}
		}

		private void KilometrajeActualTextBox_Leave(object sender, EventArgs e)
		{
			AppHelper.Try(
				 delegate
				 { ValidaKilometrajeRecorrido(); }
		    );
		}

		private void ValidaKilometrajeRecorrido()
		{
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text) && !string.IsNullOrEmpty(KilometrajeAnteriorTextBox.Text))
			{
				if (AppHelper.IsNumeric(KilometrajeActualTextBox.Text) && AppHelper.IsNumeric(KilometrajeAnteriorTextBox.Text))
				{
					int kmActual = Convert.ToInt32(this.KilometrajeActualTextBox.Text);
					int kmAnterior = Convert.ToInt32(this.KilometrajeAnteriorTextBox.Text.Replace(",", ""));
					if ((kmActual - kmAnterior) >= 400)
					{
						string msg = string.Format("Los Kilómetros recorridos desde el último pago son: {0} km", (kmActual - kmAnterior));
						MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}

		private void btnCancela_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnActualiza_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(KilometrajeActualTextBox.Text))
			{
				AppHelper.Try(delegate { ActualizarKilometraje(); });
			}
			if (!string.IsNullOrEmpty(txtLitros.Text))
			{
				AppHelper.Try(delegate { ActualizarConsumoCombustible(); });
			}
			Close();
		}

		private void ActualizaKilometrajeNomina_Shown(object sender, EventArgs e)
		{
			KilometrajeActualTextBox.Focus();
		}
	}
}
