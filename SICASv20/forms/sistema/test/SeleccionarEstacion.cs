using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class SeleccionarEstacion : baseForm
    {
        public SeleccionarEstacion()
        {
            InitializeComponent();
        }

        private List<Entities.SelectEstaciones> Estaciones;

        public override void BindData()
        {
            this.Estaciones = Entities.SelectEstaciones.GetUnionAllEmpresa();
            
            this.estacionesBindingSource.DataSource = this.Estaciones;

            base.BindData();
        }

        private void CambiarEstacionButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;                    
                    Sesion.Estacion_ID = estacion.Estacion_ID;
                    AppHelper.Info(string.Format("Estación actual {0}", estacion.Nombre));
                }
            );
        }
    }
}
