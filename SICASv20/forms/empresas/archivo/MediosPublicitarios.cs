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
    /// Administra las altas, bajas y cambios de los medios publicitarios en el sistema
    /// </summary>
    public partial class MediosPublicitarios : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase<see cref="MediosPublicitarios"/>.
        /// </summary>
        public MediosPublicitarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Guardar" del control "Navegador"
        /// </summary>
        /// <param name="sender">La fuente del evento, el botón "Guardar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void mediosPublicitariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();

                    //  Guardamos los datos
                    this.mediosPublicitariosBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            //  Cargamos los datos de clases de publicidas y medios publicitarios
            this.clasesPublicidadTableAdapter.Fill(this.sICASCentralDataSet.ClasesPublicidad);            
            this.mediosPublicitariosTableAdapter.Fill(this.sICASCentralDataSet.MediosPublicitarios);            
            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Load" del formulario "MediosPublicitarios"
        /// </summary>
        /// <param name="sender">La fuente del evento, el formulario "MediosPublicitarios"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void MediosPublicitarios_Load(object sender, EventArgs e)
        {
            BindData();
        }

    } // end class

} // end namespace
