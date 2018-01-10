using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario para dar de alta contratos
	/// </summary>
	public partial class AltaContratoRenta : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia del formulario <see cref="AltaContratoRenta"/>
		/// </summary>
		public AltaContratoRenta()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Guarda la información en la base de datos
		/// </summary>
		private void DoSave()
		{
			try
			{
				//  Guardar
				this.Validate();
				this.ValidaEmpresaUnidad();
				this.contratosBindingSource.EndEdit();
				this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

				//  Enviamos mensaje
				AppHelper.Info("Contrato ingresado");

				//  Navegamos a la pantalla de contrato
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

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
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

		/// <summary>
		/// Maneja el evento "Click" del control "Guardar"
		/// </summary>
		/// <param name="sender">El control "GuardarButton"</param>
		/// <param name="e">Los datos del evento</param>
		private void GuardarButton_Click(object sender, EventArgs e)
		{
			DoSave();
		}

		/// <summary>
		/// Maneja el evento "SelectionChangeCommitted" del control "empresa_IDComboBox"
		/// </summary>
		/// <param name="sender">El control "empresa_IDComboBox"</param>
		/// <param name="e">Los datos del evento</param>
		private void empresa_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (empresa_IDComboBox.SelectedValue != null)
			{
				get_CuentasDeEmpresaTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_CuentasDeEmpresa,
					   (int)empresa_IDComboBox.SelectedValue);
			}
		}

		/// <summary>
		/// Maneja el evento "SelectionChangeCommitted" del control "cuenta_IDComboBox"
		/// </summary>
		/// <param name="sender">El control "cuenta_IDComboBox"</param>
		/// <param name="e">Los datos del evento</param>
		private void cuenta_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cuenta_IDComboBox.SelectedValue != null)
			{
				get_ConceptosDeCuentaTableAdapter.Fill(
				    sICASCentralQuerysDataSet.Get_ConceptosDeCuenta,
					   (int)cuenta_IDComboBox.SelectedValue);
			}
		}

		/// <summary>
		/// Maneja el evento "SelectionChangeCommitted" del control "estacion_IDComboBox"
		/// </summary>
		/// <param name="sender">El control "estacion_IDComboBox"</param>
		/// <param name="e">Los datos del evento</param>
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

	} // end class AltaContratoRenta
} // end namespace SICASv20.form.AltaContratoRenta
