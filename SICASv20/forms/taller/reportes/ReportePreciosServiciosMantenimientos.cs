using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReportePreciosServiciosMantenimientos : baseForm
    {
        public ReportePreciosServiciosMantenimientos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {            
            this.tiposClientesTallerBindingSource.DataSource = Entities.TiposClientesTaller.Read();
            base.BindData();
        }

        private void TiposEmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {                
                this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource.DataSource =
                    Entities.Vista_PreciosServicioMantenimiento_TiposClientes.Get(
                    this.TiposEmpresasComboBox.SelectedValue,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value);
            }, this);         
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_PreciosServiciosTiposEmpresasDataGridView, this);
        }
    }
}
