using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Conductores : baseForm
    {
        public Conductores()
        {
            InitializeComponent();
        }

        private int _Conductor_ID;
        
        public override void BindData()
        {
            this.selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            base.BindData();
        }

        private void Conductores_Load(object sender, EventArgs e)
        {                        

        }

        private void DoQuery()
        {
            int? conductor_id = null, estacion_id = null;
            string nombre = null;

            if (Conductor_IDTextBox.Text != "")
                if (AppHelper.IsNumeric(Conductor_IDTextBox.Text))
                    conductor_id = Convert.ToInt32(Conductor_IDTextBox.Text);

            if (NombreTextBox.Text != "") nombre = NombreTextBox.Text;

            if (EstacionComboBox.SelectedValue != null && !Convert.IsDBNull(EstacionComboBox.SelectedValue))
            {
                estacion_id = Convert.ToInt32(EstacionComboBox.SelectedValue);
            }
            
            //vista_ConductoresTableAdapter.Fill(sICASCentralQuerysDataSet.Vista_Conductores, conductor_id, nombre, estacion_id);
            this.vistaConductoresBindingSource.DataSource = Entities.Vista_Conductores.GetDataTable(conductor_id, nombre, estacion_id);
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void vista_ConductoresDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verEstadoDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Conductor_ID >= 0)
            {
                try
                {
                    forms.ReporteEstadoCuentaConductor ecc = new forms.ReporteEstadoCuentaConductor();
                    ecc.Conductor_ID = _Conductor_ID;
                    Padre.SwitchForma("ReporteEstadoCuentaConductor", ecc);
                }
                catch { }
            }
        }

        private void vista_ConductoresDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (e.RowIndex >= 0)
                    {
                        vista_ConductoresDataGridView.Rows[e.RowIndex].Selected = true;
                        _Conductor_ID = Convert.ToInt32(
                            vista_ConductoresDataGridView.Rows[e.RowIndex].Cells["Conductor_ID"].Value);
                    } 
                }
            );
        }

        private void reporteDeSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Conductor_ID >= 0)
            {
                try
                {
                    forms.ReporteSaldosCuentasConductores scc = new forms.ReporteSaldosCuentasConductores();
                    scc.Conductor_ID = _Conductor_ID;
                    Padre.SwitchForma("ReporteSaldosCuentasConductores", scc);
                }
                catch { }
            }
        }

        private void actualizarInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Conductor_ID >= 0)
            {
                try
                {
                    forms.ActualizacionConductor ac = new forms.ActualizacionConductor();
                    ac.Conductor_ID = Convert.ToInt32(_Conductor_ID);
                    Padre.SwitchForma("ActualizacionConductor", ac);
                }
                catch { }
            }
        }

        private void vista_ConductoresDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vista_ConductoresDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    forms.ActualizacionConductor ac = new forms.ActualizacionConductor();
                    DataRowView dr = (DataRowView)vista_ConductoresDataGridView.Rows[e.RowIndex].DataBoundItem;
                    int conductor_id = (int)dr["Conductor_ID"];
                    ac.Conductor_ID = Convert.ToInt32(conductor_id);
                    Padre.SwitchForma("ActualizacionConductor", ac);
                }
                else if (vista_ConductoresDataGridView.Columns[e.ColumnIndex].Name == "OptionsColumn")
                {
                    this.ConductoresContextMenu.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                this.ExportarSaveFileDialog.Title = "Guarde un archivo de excel";
                this.ExportarSaveFileDialog.Filter = "Excel Files|*.xls";
                if (this.ExportarSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ExportarSaveFileDialog.FileName != "")
                    {
                        string ruta = ExportarSaveFileDialog.FileName;
                        AppHelper.GridExport.GridToXls(ref this.vista_ConductoresDataGridView, ruta);
                    }
                }
            }, this);
        }

        private void verHistorialDeCobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    if (_Conductor_ID >= 0)
                    {
                        forms.ReporteHistorialCobranzaConductor ac = new forms.ReporteHistorialCobranzaConductor();
                        ac.Conductor_ID = Convert.ToInt32(_Conductor_ID);
                        Padre.SwitchForma("ReporteHistorialCobranzaConductor", ac);                       
                    }
                },
                this
            );
        }
    }
}
