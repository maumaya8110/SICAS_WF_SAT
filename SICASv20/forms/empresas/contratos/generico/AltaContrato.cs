using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	public partial class AltaContrato : baseForm
	{
		public AltaContrato()
		{
			InitializeComponent();
		}

		private void contratosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{

		}

		private void DoSave()
		{
			try
			{
				this.Validate();
				this.ValidaEmpresaUnidad();
				this.ValidarYEjecutarFechaFinal();
				this.contratosBindingSource.EndEdit();
				this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

				AppHelper.Info("Contrato ingresado");
				Padre.SwitchForma("Contratos");
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void ValidaEmpresaUnidad()
		{
			Entities.SelectEmpresas objEmpresa = (Entities.SelectEmpresas)getEmpresasInternasBindingSource.Current;
			object objUnidad = getSelectUnidadesDeEmpresaEstacionBindingSource.Current;
			Entities.Unidades unidad = Entities.Unidades.Read((int)((DataRowView)objUnidad).Row.ItemArray[0]);
			if (objEmpresa.Empresa_ID != unidad.Empresa_ID)
			{
				throw new SICASException(string.Format("La empresa del contrato ({0}) no corresponde a la empresa donde está asignada la unidad ({1}), Favor de Verificar.", objEmpresa.Empresa_ID, unidad.Empresa_ID));
			}
		}

		public override void BindData()
		{
			contratosBindingSource.AddNew();

			this.diasDeCobrosTableAdapter.Fill(this.sICASCentralDataSet.DiasDeCobros);

			this.get_ModelosUnidadesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_ModelosUnidades);

			this.tiposContratosTableAdapter.Fill(this.sICASCentralDataSet.TiposContratos);

			estacionesBindingSource.DataSource = Sesion.Estaciones;

			getEmpresasInternasBindingSource.DataSource = Sesion.Empresas;

			this.cobroPermanenteCheckBox.Checked = true;

			base.BindData();
		}

		private void AltaContrato_Load(object sender, EventArgs e)
		{
			MostrarDiasDevengar();
		}

		private void GuardarButton_Click(object sender, EventArgs e)
		{
			DoSave();
		}

		private void empresa_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (empresa_IDComboBox.SelectedValue != null)
			{
				get_CuentasDeEmpresaTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_CuentasDeEmpresa,
					   (int)empresa_IDComboBox.SelectedValue);

				MostrarDiasDevengar();
			}
		}

		private void cuenta_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cuenta_IDComboBox.SelectedValue != null)
			{
				get_ConceptosDeCuentaTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_ConceptosDeCuenta,
					   (int)cuenta_IDComboBox.SelectedValue);

				MostrarDiasDevengar();
			}
		}

		private void estacion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (estacion_IDComboBox.SelectedValue != null)
			{
				get_SelectUnidadesDeEmpresaEstacionTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_SelectUnidadesDeEmpresaEstacion,
					   (int)empresa_IDComboBox.SelectedValue,
					   (int)estacion_IDComboBox.SelectedValue);

				get_ConductoresDeEstacionTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_ConductoresDeEstacion,
				    (int)estacion_IDComboBox.SelectedValue);

				get_SelectConductoresDeEstacionTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_SelectConductoresDeEstacion,
				    (int)estacion_IDComboBox.SelectedValue);
			}
		}

		private void diasDevengarTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
			{

				CalcularFechaFinal();
			}
		}

		private void MostrarDiasDevengar()
		{
			this.diasDevengarTextBox.Visible = false;
            //this.lblDiaDevengar.Visible = false;
            
			this.fechaFinalDateTimePicker.Enabled = true;
			this.fechaFinalDateTimePicker.Value = DateTime.Now;

			if (cuenta_IDComboBox.SelectedValue != null && !string.IsNullOrEmpty(empresa_IDComboBox.SelectedValue.ToString()) &&
			    empresa_IDComboBox.SelectedValue.ToString() != "3" && cuenta_IDComboBox.SelectedValue.ToString() == "1")
			{
				this.diasDevengarTextBox.Visible = true;
                //this.lblDiaDevengar.Visible = true;
				this.fechaFinalDateTimePicker.Enabled = false;
			}
		}

		private bool CalcularFechaFinal()
		{
			int diasDev = 0;

			try
			{

				if (fechaInicialDateTimePicker.Value != null && !string.IsNullOrEmpty(diasDevengarTextBox.Text) && diasDeCobro_IDComboBox.SelectedValue != null)
				{
					if (int.TryParse(diasDevengarTextBox.Text, out diasDev) == false) return false;
					DataTable dt = DB.Query(string.Format("select dbo.udf_Calcular_Fecha_Final_Contrato('{0}',{1},{2})", fechaInicialDateTimePicker.Value.ToString("yyyyMMdd"),
					    diasDev,
					    diasDeCobro_IDComboBox.SelectedValue.ToString()));
					if (dt != null && dt.Rows.Count > 0)
					{
						fechaFinalDateTimePicker.Value = DateTime.Parse(dt.Rows[0][0].ToString());
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
			return false;
		}

		private void ValidarYEjecutarFechaFinal()
		{
			if (empresa_IDComboBox.SelectedValue.ToString() != "3" && this.CalcularFechaFinal() == false)
			{
				AppHelper.Error("No se pudo calcular la fecha final");
				return;
			}

			if (empresa_IDComboBox.SelectedValue.ToString() == "3")
			{
				this.diasDevengarTextBox.Text = "0";
			}
		}

	}

}
