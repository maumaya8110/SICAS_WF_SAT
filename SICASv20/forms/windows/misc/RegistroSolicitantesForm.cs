using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class RegistroSolicitantesForm : baseForm
    {
        public RegistroSolicitantesForm()
        {
            InitializeComponent();
        }

        private void conductoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.conductoresBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        public override void BindData()
        {
            this.estacionesTableAdapter.Fill(this.sICASCentralDataSet.Estaciones);            
            this.mercadosTableAdapter.Fill(this.sICASCentralDataSet.Mercados);            
            this.mediosPublicitariosTableAdapter.Fill(this.sICASCentralDataSet.MediosPublicitarios);
            this.conductoresTableAdapter.Fill(this.sICASCentralDataSet.Conductores, null);

            this.bindingNavigatorAddNewItem_Click(this.bindingNavigatorAddNewItem, new EventArgs());            
            base.BindData();
        }
        
        private void RegistroSolicitantesForm_Load(object sender, EventArgs e)
        {            

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.fechaDateTimePicker.Value = DateTime.Now;
            this.fotografiaTextBox.Text = "";
            this.estatusConductor_IDTextBox.Text = "1";
            this.usuario_IDTextBox.Text = Sesion.Usuario_ID;
        }
    }
}
