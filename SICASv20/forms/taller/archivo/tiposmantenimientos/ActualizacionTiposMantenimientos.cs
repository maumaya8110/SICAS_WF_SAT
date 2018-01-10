using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionTiposMantenimientos : baseForm
    {
        public ActualizacionTiposMantenimientos()
        {
            InitializeComponent();
        }

        private Int32 _TipoMantenimiento_ID;
        public Int32 TipoMantenimiento_ID
        {
            get { return _TipoMantenimiento_ID; }
            set { _TipoMantenimiento_ID = value; }
        }
        public override void BindData()
        {
            TiposMantenimientosBindingSource.DataSource = Entities.TiposMantenimientos.Read(this.TipoMantenimiento_ID);
            base.BindData();
        }
        private void DoBackToList()
        {
            forms.TiposMantenimientos TiposMantenimientosLower = new forms.TiposMantenimientos();
            Padre.SwitchForma("TiposMantenimientos", TiposMantenimientosLower);
        }
        private void DoSave()
        {
            Entities.TiposMantenimientos tiposmantenimientos = (Entities.TiposMantenimientos)TiposMantenimientosBindingSource.Current;
            tiposmantenimientos.Update();
            DoBackToList();
            AppHelper.Info("¡TiposMantenimientos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
