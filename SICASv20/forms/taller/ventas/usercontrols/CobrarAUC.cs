using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CobrarAUC : baseUserControl
    {
        public CobrarAUC()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        public NuevaOrdenTrabajo Padre;

        public void BindData()
        {
            this.ClienteLabel.Text = Padre.OrdenTrabajo.Cliente_Nombre;
            EnableQuerying();
        }

        private void DoQuery()
        {
            List<Entities.Empresas> empresas = 
                Entities.Empresas.Read("Nombre LIKE @Nombre + '%'", null, 
                    DB.Param("@Nombre", this.BuscarClienteTextBox.Text));

            this.empresasBindingSource.DataSource = empresas;
        }

        private void DoValidate()
        {
            if (Padre.OrdenTrabajo.ClienteFacturar_ID == 0)
            {
                throw new Exception("Debe seleccionar un cliente");
            }
        }

        private void EnableQuerying()
        {
            if (ClienteRadioButton.Checked)
            {
                this.BuscarClienteTextBox.Enabled = false;
                this.ClientesDataGridView.Enabled = false;
                this.BuscarButton.Enabled = false;
            }
            else
            {
                this.BuscarClienteTextBox.Enabled = true;
                this.ClientesDataGridView.Enabled = true;
                this.BuscarButton.Enabled = true;

                this.BuscarClienteTextBox.SelectAll();
                this.BuscarClienteTextBox.Focus();
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoQuery();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void ClientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ClientesDataGridView.Columns["Seleccionar"].Index == e.ColumnIndex)
                {
                    Entities.Empresas empresa = (Entities.Empresas)ClientesDataGridView.Rows[e.RowIndex].DataBoundItem;
                    Padre.OrdenTrabajo.ClienteFacturar_ID = empresa.Empresa_ID;
                    Padre.OrdenTrabajo.Cliente_Nombre = empresa.Nombre;
                    this.BuscarClienteTextBox.Text = empresa.Nombre;
                    this.empresasBindingSource.DataSource = null;

                    DoValidate();
                    Padre.serviciosControl.BindData();
                    Padre.SwitchPanel("Servicios");
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }        

        private void AnteriorButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("Unidad");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }

        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoValidate();

                Padre.SwitchPanel("Servicios");              
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void ClienteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EnableQuerying();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void OtroRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EnableQuerying();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
    
}
