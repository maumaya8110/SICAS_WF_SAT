using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaServiciosMantenimientos : baseForm
    {
        public AltaServiciosMantenimientos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            TiposServiciosMantenimientosBindingSource.DataSource = Entities.TiposServiciosMantenimientos.Read();
            FamiliasBindingSource.DataSource = Entities.Familias.Read();
            ModelosBindingSource.DataSource = Entities.Modelos.Read();
            ServiciosMantenimientosBindingSource.AddNew();
            base.BindData();
        }
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            ServiciosMantenimientosBindingSource.AddNew();
        }
        private void DoSave()
        {
            Entities.ServiciosMantenimientos serviciosmantenimientos = (Entities.ServiciosMantenimientos)ServiciosMantenimientosBindingSource.Current;
            serviciosmantenimientos.Create();
            DoClear();
            AppHelper.Info("¡ServiciosMantenimientos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
