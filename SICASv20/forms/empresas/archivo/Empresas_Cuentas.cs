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
    /// Administra las cuentas y su relación con empresas en el sistema
    /// </summary>
    public partial class Empresas_Cuentas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="Empresas_Cuentas"/>.
        /// </summary>
        public Empresas_Cuentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Guardar" del control "Navegador"
        /// </summary>
        /// <param name="sender">La fuente del evento, el botón "Guardar".</param>
        /// <param name="e">El contenedor de los argumentos del evento</param>
        private void empresas_CuentasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();

                    //  Guardamos la información
                    this.empresas_CuentasBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    
                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Load" del formulario "Empresas_Cuentas"
        /// </summary>
        /// <param name="sender">La fuente del evento, el formulario "Empresas_Cuentas"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void Empresas_Cuentas_Load(object sender, EventArgs e)
        {
            //  Cargamos los datos de cuentas, empresas y empresa_cuentas

            this.cuentasTableAdapter.Fill(this.sICASCentralDataSet.Cuentas);
            
            this.empresasTableAdapter.Fill(this.sICASCentralDataSet.Empresas);
            
            this.empresas_CuentasTableAdapter.Fill(this.sICASCentralDataSet.Empresas_Cuentas);

        }

    } // end class

} // end namespace
