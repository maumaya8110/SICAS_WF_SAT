using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaFamilia : baseForm
    {
        public AltaFamilia()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            familiasBindingSource.AddNew();
            base.BindData();
        }

        private void DoClear()
        {
            AppHelper.ClearControl(this);
            familiasBindingSource.AddNew();
        }

        private void DoSave()
        {
            Entities.Familias familia = (Entities.Familias)familiasBindingSource.Current;
            familia.Create();
            DoClear();
            AppHelper.Info("¡Familia insertada!");            
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        }
    }
}
