using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionCategoriasMecanicos : baseForm
    {
        public ActualizacionCategoriasMecanicos()
        {
            InitializeComponent();
        }


        private Int32 _CategoriaMecanico_ID;
        public Int32 CategoriaMecanico_ID
        {
            get { return _CategoriaMecanico_ID; }
            set { _CategoriaMecanico_ID = value; }
        }
        public override void BindData()
        {
            FamiliasBindingSource.DataSource = Entities.Familias.Read();
            CategoriasMecanicosBindingSource.DataSource = Entities.CategoriasMecanicos.Read(this.CategoriaMecanico_ID);
            base.BindData();
        }
        private void DoBackToList()
        {
            forms.CategoriasMecanicos CategoriasMecanicosLower = new forms.CategoriasMecanicos();
            Padre.SwitchForma("CategoriasMecanicos", CategoriasMecanicosLower);
        }
        private void DoSave()
        {
            Entities.CategoriasMecanicos categoriasmecanicos = (Entities.CategoriasMecanicos)CategoriasMecanicosBindingSource.Current;
            categoriasmecanicos.Update();
            DoBackToList();
            AppHelper.Info("¡CategoriasMecanicos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 

    }
}
