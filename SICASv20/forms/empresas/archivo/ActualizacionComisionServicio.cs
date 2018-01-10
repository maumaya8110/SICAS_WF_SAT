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
    /// Formulario para la actualización de comisiones de servicio
    /// </summary>
    public partial class ActualizacionComisionServicio : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de actualización
        /// de comisiones de servicios
        /// </summary>
        public ActualizacionComisionServicio()
        {
            InitializeComponent();
        }

        private int _ComisionServicio_ID;

        /// <summary>
        /// El numero de identificación de la comisión a actualizar
        /// </summary>
        public int ComisionServicio_ID
        {
            get { return _ComisionServicio_ID; }
            set { _ComisionServicio_ID = value; }
        }
        
        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.empresasTableAdapter.Fill(this.sICASCentralDataSet.Empresas);
            this.tiposComisionesBindingSource.DataSource = Entities.TiposComisiones.Read();
            comisionesServiciosBindingSource.DataSource = Entities.ComisionesServicios.Read(this.ComisionServicio_ID);
            base.BindData();
        }

        /// <summary>
        /// Valida la información de datos de entrada
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

            //  Configuramos los datos en una objeto ComisionesServicios
            Entities.ComisionesServicios comisionesServicios =
                new Entities.ComisionesServicios(Convert.ToInt32(this.comisionServicio_IDTextBox.Text),
                    Convert.ToInt32(this.comisionista_IDComboBox.SelectedValue),
                    Convert.ToInt32(this.tipoComision_IDComboBox.SelectedValue),
                    Convert.ToDecimal(this.montoTextBox.Text),
                    this.nombreTextBox.Text,
                    false,
                    true
                );

            //  Actualizamos la información en la base de datos
            comisionesServicios.Update();

            //  Enviamos mensaje
            AppHelper.Info("!Comisión actualizada!");

            //  Navegamos a "Comisiones Servicios"
            Padre.SwitchForma("ComisionesServicios");
        }

        /// <summary>
        /// Solicita se guarden los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        }

    } // end class ActualizacionComisionServicio

} // end namespace SICASv20.forms
