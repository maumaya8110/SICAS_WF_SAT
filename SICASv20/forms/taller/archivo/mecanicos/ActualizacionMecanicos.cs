using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionMecanicos : baseForm
    {
        public ActualizacionMecanicos()
        {
            InitializeComponent();
        }

        private Int32 _Mecanico_ID;
        public Int32 Mecanico_ID
        {
            get { return _Mecanico_ID; }
            set { _Mecanico_ID = value; }
        }
        public override void BindData()
        {
            CategoriasMecanicosBindingSource.DataSource = Entities.CategoriasMecanicos.Read();
            EstatusMecanicosBindingSource.DataSource = Entities.EstatusMecanicos.Read();
            UsuariosBindingSource.DataSource = Entities.Usuarios.Read();
            MecanicosBindingSource.DataSource = Entities.Mecanicos.Read(this.Mecanico_ID);
            AppHelper.SetContainerDBValidations(this, "Mecanicos");
            base.BindData();
        }
        private void DoBackToList()
        {
            forms.Mecanicos MecanicosLower = new forms.Mecanicos();
            Padre.SwitchForma("Mecanicos", MecanicosLower);
        }
        private void DoSave()
        {
            Entities.Mecanicos MecanicosLower = (Entities.Mecanicos)MecanicosBindingSource.Current;
            MecanicosLower.Empresa_ID = Sesion.Empresa_ID.Value;
            MecanicosLower.Estacion_ID = Sesion.Estacion_ID.Value;
            MecanicosLower.Update();
            DoBackToList();
            AppHelper.Info("¡Mecanico guardado!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
