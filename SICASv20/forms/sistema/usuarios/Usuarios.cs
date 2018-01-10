using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Usuarios : baseForm
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        public override void BindData()
        {            
            empresasBindingSource.DataSource = Entities.SelectEmpresasInternas.GetUnionALL();
            selectEstacionesBindingSource.DataSource = Entities.SelectEstaciones.GetUnionAll();
            DoQueryEstacion();
            base.BindData();
        }

        private void DoQuery()
        {
            string nombre, apellidos;
            int? empresa_id, estacion_id;

            if (NombreTextBox.Text != "")
            {
                nombre = NombreTextBox.Text;
            }
            else
            {
                nombre = null;
            }

            if (ApellidosTextBox.Text != "")
            {
                apellidos = ApellidosTextBox.Text;
            }
            else
            {
                apellidos = null;
            }

            if (EmpresaComboBox.SelectedValue == null || 
                    Convert.IsDBNull(this.EmpresaComboBox.SelectedValue))
            {
                empresa_id = null;
            }
            else
            {
                empresa_id = Convert.ToInt32(EmpresaComboBox.SelectedValue);
            }

            if (EstacionComboBox.SelectedValue == null ||
                    Convert.IsDBNull(this.EstacionComboBox.SelectedValue))
            {
                estacion_id = null;
            }
            else
            {
                estacion_id = Convert.ToInt32(EstacionComboBox.SelectedValue);
            }

            vista_UsuariosTableAdapter.Fill(sICASCentralQuerysDataSet.Vista_Usuarios,
                nombre, apellidos, empresa_id, estacion_id);

            vista_UsuariosBindingSource.Filter = "Activo = 1";
        }

        private void DoExport()
        {
            //if (ExportarSaveFileDialog.FileName != "")
            //{
            //    string ruta = ExportarSaveFileDialog.FileName;
            //    AppHelper.GridExport.GridToXls(ref this.vista_UsuariosDataGridView, ruta);
            //}
            Random rand = new Random(102938);
            string pathfile = string.Format("{0}\\{1:yyyyMMddHHmmss}.xls", System.IO.Path.GetTempPath(), DateTime.Now);
            AppHelper.GridExport.GridToXls(ref this.vista_UsuariosDataGridView, pathfile);
        }
        
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoQuery();
            }
            catch (System.Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void vista_UsuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                forms.ActualizacionUsuario au = new forms.ActualizacionUsuario();
                au.Usuario_ID = Convert.ToString(vista_UsuariosDataGridView.Rows[e.RowIndex].Cells["Usuario_ID"].Value);
                Padre.SwitchForma("ActualizacionUsuario", au);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void DoQueryEstacion()
        {
            if (EmpresaComboBox.SelectedItem != null)
            {
                Entities.SelectEmpresasInternas empresa = (Entities.SelectEmpresasInternas)EmpresaComboBox.SelectedItem;
                if (!AppHelper.IsNullOrEmpty(empresa.Empresa_ID))
                {
                    selectEstacionesBindingSource.DataSource = Entities.SelectEstaciones.GetAll(empresa.Empresa_ID);
                }
                else
                {
                    selectEstacionesBindingSource.DataSource = Entities.SelectEstaciones.GetUnionAll();
                }
            }
        }

        private void EmpresaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    DoQueryEstacion();
                },
                this
            );
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            //this.ExportarSaveFileDialog.Title = "Guarde un archivo de excel";
            //this.ExportarSaveFileDialog.Filter = "Excel Files|*.xls";
            //this.ExportarSaveFileDialog.ShowDialog();
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoExport), this);
        }

        private void ExportarSaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoExport), this);
        }
    }
}
