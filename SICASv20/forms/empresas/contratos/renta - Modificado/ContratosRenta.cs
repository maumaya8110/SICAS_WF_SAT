/*
 * ContratosRenta
 * 
 * Visualiza los contratos de renta en el sistema
 * 
 * Modificado el 17 de Octubre 
 * por Luis Espino
 * Se eliminó la consulta de Estaciones dependiendo de la empresa
 * en el método EmpresasComboBox_SelectionChangeCommitted
 * y basada en los contratos de las empresas
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario que muestra el listado de los contratos de renta
    /// </summary>
    public partial class ContratosRenta : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario <see cref="ContratosRenta"/>
        /// </summary>
        public ContratosRenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            selectEmpresasInternasBindingSource.DataSource = Sesion.EmpresasTodas;
            selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            base.BindData();
        }
        
        /// <summary>
        /// Consulta los datos en la base de datos
        /// </summary>
        private void DoQuery()
        {
            //  Declaramos las variables de los parámetros
            int? contrato_id = null, estacion_id = null, numeroeconomico = null, empresa_id = null;
            string descripcion = null;

            //  Obtenemos los parámetros
            if (!string.IsNullOrEmpty(Contrato_IDTextBox.Text))
            {
                if (!AppHelper.IsNumeric(Contrato_IDTextBox.Text))
                {
                    throw new Exception("Contrato ID debe ser numérico");
                }

                contrato_id = Convert.ToInt32(Contrato_IDTextBox.Text);
            }

            if (!string.IsNullOrEmpty(NumeroEconomicoTextBox.Text))
            {
                if (!AppHelper.IsNumeric(NumeroEconomicoTextBox.Text))
                {
                    throw new Exception("Numero Economico debe ser numérico");
                }

                numeroeconomico = Convert.ToInt32(NumeroEconomicoTextBox.Text);
            }

            if (!string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                descripcion = DescripcionTextBox.Text;
            }

            empresa_id = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);

            estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);

            bool incluirterminados = this.IncluirTerminadosCheckBox.Checked;

            //  Consultamos la información y la ligamos a los datos
            vista_ContratosBindingSource.DataSource = 
                Entities.Vista_Contratos.Get(
                    contrato_id, 
                    empresa_id, 
                    estacion_id, 
                    descripcion, 
                    numeroeconomico,
                    incluirterminados,
                    Sesion.Usuario_ID);
        }

        /// <summary>
        /// Muestra la pantalla para cancelar contratos
        /// </summary>
        /// <param name="contrato_id">El folio del contrato</param>
        private void CancelarContrato(int contrato_id)
        {
            AppHelper.DoMethod(delegate
            {
                forms.TerminacionContrato form = new TerminacionContrato();
                form.Contrato_ID = contrato_id;
                Padre.SwitchForma("TerminacionContrato", form);
            }, this);
        }

        /// <summary>
        /// Maneja el evento "Click" para el control "BuscarButton"
        /// </summary>
        /// <param name="sender">El control "BuscarButton"</param>
        /// <param name="e">Los datos del evento</param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Maneja el evento "CellContentClick" para el control "vistaContratosDataGridView"
        /// </summary>
        /// <param name="sender">El control "vistaContratosDataGridView"</param>
        /// <param name="e">Los datos del evento</param>
        private void vista_ContratosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //  El formulario de actualización de contratos
                ActualizacionContratoRenta ac = new ActualizacionContratoRenta();
                Entities.Vista_Contratos contrato =
                        (Entities.Vista_Contratos)vista_ContratosDataGridView.Rows[e.RowIndex].DataBoundItem;

                //  Obtenemos el estatus del contrato
                int estatuscontrato_id = Convert.ToInt32(
                    DB.QueryScalar(
                        "SELECT EstatusContrato_ID FROM Contratos WHERE Contrato_ID = @Contrato_ID",
                        DB.Param("@Contrato_ID", contrato.Contrato_ID)
                    )
                );                

                //  Si se oprimió la columna "EditColumn"
                if (vista_ContratosDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    //  Si el estatus no es activo
                    if (estatuscontrato_id != 1)
                    {
                        //  Enviamos excepción
                        AppHelper.ThrowException("El contrato {0} no esta activo, no puede ser actualizado", contrato.Contrato_ID);
                    }

                    //  Configuramos folio
                    ac.Contrato_ID = contrato.Contrato_ID;

                    //  Navegamos a la forma de actualización
                    Padre.SwitchForma("ActualizacionContratoRenta", ac);

                    //  Salimos de la función
                    return;
                }

                //  Si se oprmío la columna "CancelColumn"
                if (vista_ContratosDataGridView.Columns[e.ColumnIndex].Name == "CancelColumn")
                {
                    //  Si el estatus del contrato no es "Activo"
                    if (estatuscontrato_id != 1)
                    {
                        //  Enviamos excepción
                        AppHelper.ThrowException("El contrato {0} no esta activo, no puede ser terminado", contrato.Contrato_ID);
                    }

                    //  Solicitamos confirmación
                    if (AppHelper.Confirm("¿Realmente desea cancelar el contrato?") == System.Windows.Forms.DialogResult.Yes)
                    {                        
                        //  Navegamos a la cancelación del contrato
                        CancelarContrato(contrato.Contrato_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" para el control "EmpresasComboBox"
        /// </summary>
        /// <param name="sender">El control "EmpresasComboBox"</param>
        /// <param name="e">Los datos del evento</param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (EmpresasComboBox.SelectedItem != null)
            {
                Entities.SelectEmpresas empresa = (Entities.SelectEmpresas)EmpresasComboBox.SelectedItem;                
            }
        }

        /// <summary>
        /// Maneja el evento "Click" para el control "ExportarButton"
        /// </summary>
        /// <param name="sender">El control "ExportarButton"</param>
        /// <param name="e">Los datos del evento</param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_ContratosDataGridView, this);
        }

        /// <summary>
        /// Maneja el evento "DataBindingComplete" para el control "vista_ContratosDataGridView"
        /// </summary>
        /// <param name="sender">El control "vista_ContratosDataGridView"</param>
        /// <param name="e">Los datos del evento</param>
        private void vista_ContratosDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {                    
                    AppHelper.ColorDataGridViewRows(
                        ref this.vista_ContratosDataGridView, 
                        "Estatus", 
                        AppHelper.RelacionColoresEstatusContratos
                    );
                }
            );
        }

    } // end class ContratosRenta

} // end namespace SICASv20.forms
