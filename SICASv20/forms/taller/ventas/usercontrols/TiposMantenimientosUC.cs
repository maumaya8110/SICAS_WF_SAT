using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class TiposMantenimientosUC : baseUserControl
    {
        public TiposMantenimientosUC()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        public NuevaOrdenTrabajo Padre;

        private void TipoMantenimiento_ClickEvent(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Padre.OrdenTrabajo.TipoMantenimiento_ID = (int)btn.Tag;                

                Padre.SwitchPanel("Unidad");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        public void BindData()
        {
            DataTable dt = DB.Query("SELECT * FROM TiposMantenimientos WHERE Activo = 1");

            this.bindPanel1.LayoutType = BindPanel.BindPanelLayoutType.Matrix;
            this.bindPanel1.DisplayMember = "Nombre";
            this.bindPanel1.ValueMember = "TipoMantenimiento_ID";
            this.bindPanel1.B_Click = this.TipoMantenimiento_ClickEvent;
            this.bindPanel1.DataSource = dt;
            this.bindPanel1.Databind();
        }
    }
}
