using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionServiciosMantenimientos : baseForm
    {
        public ActualizacionServiciosMantenimientos()
        {
            InitializeComponent();
        }

        private Int32 _ServicioMantenimiento_ID;
        public Int32 ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }
        public override void BindData()
        {
            TiposServiciosMantenimientosBindingSource.DataSource = Entities.TiposServiciosMantenimientos.Read();
            FamiliasBindingSource.DataSource = Entities.Familias.Read();
            ModelosBindingSource.DataSource = Entities.Modelos.Read();
            ServiciosMantenimientosBindingSource.DataSource = Entities.ServiciosMantenimientos.Read(this.ServicioMantenimiento_ID);
            base.BindData();
        }
        private void DoBackToList()
        {
            forms.ServiciosMantenimientos ServiciosMantenimientosLower = new forms.ServiciosMantenimientos();
            Padre.SwitchForma("ServiciosMantenimientos", ServiciosMantenimientosLower);
        }
        private void DoSave()
        {
            Entities.ServiciosMantenimientos serviciosmantenimientos = (Entities.ServiciosMantenimientos)ServiciosMantenimientosBindingSource.Current;
            serviciosmantenimientos.Update();
            DoBackToList();
            AppHelper.Info("¡ServiciosMantenimientos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
        
    }
}
