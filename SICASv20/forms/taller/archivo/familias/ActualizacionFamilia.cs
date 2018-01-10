using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionFamilia : baseForm
    {
        public ActualizacionFamilia()
        {
            InitializeComponent();
        }

        private int _Familia_ID;

        public int Familia_ID
        {
            get { return _Familia_ID; }
            set { _Familia_ID = value; }
        }
        
        public override void BindData()
        {
            familiasBindingSource.DataSource = Entities.Familias.Read(this.Familia_ID);
            base.BindData();
        }

        private void DoSave()
        {
            Entities.Familias familia = (Entities.Familias)familiasBindingSource.Current;
            familia.Update();
            //  Navegar a catálogo
            DoBackToList();
            AppHelper.Info("¡Familia actualizada!");   
        }

        private void DoBackToList()
        {
            forms.Familias familias = new forms.Familias();
            Padre.SwitchForma("Familias", familias);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        }
    }
}
