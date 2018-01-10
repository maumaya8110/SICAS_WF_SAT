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
    /// Formulario para dar de alta una comisión de servicio
    /// </summary>
    public partial class AltaComisionServicio : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para dar de alta
        /// una comisión de servicio
        /// </summary>
        public AltaComisionServicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.empresasTableAdapter.Fill(this.sICASCentralDataSet.Empresas);
            this.tiposComisionesBindingSource.DataSource = Entities.TiposComisiones.Read();
            comisionesServiciosBindingSource.AddNew();
            base.BindData();
        }

        /// <summary>
        /// Valida los datos de entrada
        /// </summary>
        private void DoValidate()
        {
            if (AppHelper.IsNullOrEmpty(this.comisionista_IDComboBox.SelectedItem))
            {
                throw new Exception("!Debe seleccionar una empresa comisionista!");
            }

            if (AppHelper.IsNullOrEmpty(this.tipoComision_IDComboBox.SelectedItem))
            {
                throw new Exception("!Debe seleccionar un tipo de comisión!");
            }

            AppHelper.ValidateControl(this.nombreTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.montoTextBox, AppHelper.ValidateRule.Required, AppHelper.ValidateRule.Numeric);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            //  Validamos los datos de entrada
            DoValidate();

            //  Configuramos un registro de Comisiones Servicios
            Entities.ComisionesServicios comisionesServicios =
                new Entities.ComisionesServicios(Convert.ToInt32(this.comisionServicio_IDTextBox.Text),
                    Convert.ToInt32(this.comisionista_IDComboBox.SelectedValue),
                    Convert.ToInt32(this.tipoComision_IDComboBox.SelectedValue),
                    Convert.ToDecimal(this.montoTextBox.Text),
                    this.nombreTextBox.Text,
                    false,
                    true
                );

            //  Realizamos la inserción a la base de datos
            comisionesServicios.Create();

            //  Enviamos mensaje
            AppHelper.Info("!Comisión registrada!");

            //  Navegamos a comisiones servicios
            Padre.SwitchForma("ComisionesServicios");
        }

        /// <summary>
        /// Solicita guardar los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        }

    }
}
