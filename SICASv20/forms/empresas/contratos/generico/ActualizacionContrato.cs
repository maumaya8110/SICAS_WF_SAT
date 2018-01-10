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
    /// Formulario para actualizar la información de un contrato
    /// </summary>
    public partial class ActualizacionContrato : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de actualización de un contrato
        /// </summary>
        public ActualizacionContrato()
        {
            InitializeComponent();
        }


        /// <summary>
        /// El número de contrato a actualizar
        /// </summary>
        public int Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }
        private int _Contrato_ID;

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            try
            {
                this.Validate();

                //  Guardar los cambios
                this.contratosBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);                

                //  Mensaje de éxito
                AppHelper.Info("Contrato actualizado");

                //  Nagevamos a listado de contratos
                Padre.SwitchForma("Contratos");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Cargamos los datos de
            //  Dias de cobro
            this.diasDeCobrosTableAdapter.Fill(this.sICASCentralDataSet.DiasDeCobros);

            //  Dias de cobro modelos de unidades
            this.get_ModelosUnidadesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_ModelosUnidades);            
            
            //  Tipos de contrato
            this.tiposContratosTableAdapter.Fill(this.sICASCentralDataSet.TiposContratos);            

            //  Estatus de contrato
            this.estatusContratosTableAdapter.Fill(this.sICASCentralDataSet.EstatusContratos);
            
            //  Contratos (el contrato a actualizar)
            this.contratosTableAdapter.Fill(this.sICASCentralDataSet.Contratos, Contrato_ID);

            //  La vista del contrato
            this.vista_ContratosTableAdapter.Fill(this.sICASCentralQuerysDataSet.Vista_Contratos, Contrato_ID);

            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Guardar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            DoSave();
        }

    } // end class ActualizacionContrato

} // end namespace SICASv20.forms
