using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaMecanicos : baseForm
    {
        public AltaMecanicos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            CategoriasMecanicosBindingSource.DataSource = Entities.CategoriasMecanicos.Read();
            EstatusMecanicosBindingSource.DataSource = Entities.EstatusMecanicos.Read();
            UsuariosBindingSource.DataSource = Entities.Usuarios.Read();
            MecanicosBindingSource.AddNew();
            AppHelper.SetContainerDBValidations(this, "Mecanicos");
            base.BindData();
        }
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            MecanicosBindingSource.AddNew();
        }
        private void DoSave()
        {
            Entities.Mecanicos MecanicosLower = (Entities.Mecanicos)MecanicosBindingSource.Current;
            MecanicosLower.Usuario_ID = Sesion.Usuario_ID;
            MecanicosLower.Fecha = DB.GetDate();
            MecanicosLower.Empresa_ID = Sesion.Empresa_ID.Value;
            MecanicosLower.Estacion_ID = Sesion.Estacion_ID.Value;
            MecanicosLower.Create();
            DoClear();
            AppHelper.Info("¡Mecanico guardado!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
