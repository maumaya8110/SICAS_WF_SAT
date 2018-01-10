using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class SICASTestLauncher : baseForm
    {
        public SICASTestLauncher()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            Sesion.EsPrueba = !Sesion.EsPrueba;
                        
            if (Sesion.EsPrueba)
            {
                Sesion.DB.Database = "SICASTest";
                AppHelper.SetConnStr();
                AppHelper.Info("Ha entrado al modo de pruebas"); 
                Padre.Text = "||**** APLICACION DE PRUEBA DE SICAS ****||";
                Padre.Color1 = Color.Green;
            }
            else
            {
                Sesion.DB.Database = "SICASSync";
                AppHelper.SetConnStr();
                AppHelper.Info("Ha salido del modo de pruebas");
                Padre.Text = ":: SICAS V2.0 ::";
                Padre.Color1 = Color.LightSteelBlue;
            }
            
            base.BindData();
        }
    }
}
