using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaCategoriasMecanicos : baseForm
    {
        public AltaCategoriasMecanicos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            FamiliasBindingSource.DataSource = Entities.Familias.Read();
            CategoriasMecanicosBindingSource.AddNew();
            base.BindData();
        }
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            CategoriasMecanicosBindingSource.AddNew();
        }
        private void DoSave()
        {
            Entities.CategoriasMecanicos categoriasmecanicos = (Entities.CategoriasMecanicos)CategoriasMecanicosBindingSource.Current;
            categoriasmecanicos.Create();
            DoClear();
            AppHelper.Info("¡CategoriasMecanicos actualizados!");
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 

    }
}
