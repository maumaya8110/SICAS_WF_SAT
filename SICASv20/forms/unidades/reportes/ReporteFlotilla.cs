/*
 * **  HISTORIAL  **
 *      2012-10-30, Modificado por Luis Espino
 *          Se implementó el filtro por empresa
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteFlotilla : baseForm
    {
        public ReporteFlotilla()
        {
            InitializeComponent();
        }

        private int? _Estacion_ID;
        public int? Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        public override void BindData()
        {
            estacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            empresasBindingSource.DataSource = Sesion.EmpresasTodas;
            base.BindData();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                Estacion_ID = DB.GetNullableInt32(Estacion_IDComboBox.SelectedValue);
                int? Empresa_ID = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);

                this.reporteFlotillaPorEstacionBindingSource.DataSource = Entities.Vista_ReporteFlotilla.GetDataTable(Sesion.Usuario_ID, Empresa_ID, Estacion_ID);
                this.reportViewer1.RefreshReport();

                //  Si le pongo todas, va a traer todas las estaciones, no todas por empresa
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

    }
}
