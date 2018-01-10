using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para administrar las clases de publicidad
    /// </summary>
    public partial class ClasesPublicidad : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para administrar las clases de publicidad
        /// </summary>
        public ClasesPublicidad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            
            this.clasesPublicidadTableAdapter.Fill(this.sICASCentralDataSet.ClasesPublicidad);            
            base.BindData();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clasesPublicidadBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.clasesPublicidadBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

    }
}
