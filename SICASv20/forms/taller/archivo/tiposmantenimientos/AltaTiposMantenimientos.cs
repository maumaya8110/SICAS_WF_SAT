using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaTiposMantenimientos : baseForm
    {
        public AltaTiposMantenimientos()
        {
            InitializeComponent();
        }


        public override void BindData()
        {
            TiposMantenimientosBindingSource.AddNew();
            base.BindData();
        }
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            TiposMantenimientosBindingSource.AddNew();
        }
        private void DoSave()
        {
            Entities.TiposMantenimientos tiposmantenimientos = (Entities.TiposMantenimientos)TiposMantenimientosBindingSource.Current;
            tiposmantenimientos.Create();
            DoClear();
            AppHelper.Info("¡TiposMantenimientos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 

    }
}
