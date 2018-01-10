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
            }
        }

        private void cuenta_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cuenta_IDComboBox.SelectedValue != null)
            {
                get_ConceptosDeCuentaTableAdapter.Fill(
                    sICASCentralQuerysDataSet.Get_ConceptosDeCuenta,
                        (int)cuenta_IDComboBox.SelectedValue);
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
    }
}
