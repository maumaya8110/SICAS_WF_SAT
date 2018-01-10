using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Especifica los datos de conductor de un contrato
    /// </summary>
    public partial class Contratos_DatosConductorUCRenta : baseUserControl
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para especificar 
        /// los datos de conductor a un contrato
        /// </summary>
        public Contratos_DatosConductorUCRenta()
        {
            InitializeComponent();
            BindData();
        }

        /// <summary>
        /// La forma padre, una referencia al formulario "AsistenteContratos"
        /// </summary>
        public AsistenteContratosRenta Padre;

        /// <summary>
        /// La entidad del conductor que ligaremos al contrato
        /// </summary>
        Entities.Conductores conductor;

        /// <summary>
        /// Realiza las validaciones de los datos de entrada
        /// </summary>
        /// <exception cref="System.Exception">
        /// Debe seleccionar un conductor
        /// o
        /// Debe seleccionar una empresa
        /// o
        /// Debe seleccionar una estacion
        /// o
        /// Debe seleccionar un tipo contrato
        /// </exception>
        private void DoValidate()
        {
            Entities.SelectEmpresas empresa = (Entities.SelectEmpresas)EmpresasComboBox.SelectedItem;
            Entities.TiposContratos tipocontrato = (Entities.TiposContratos)TiposContratosComboBox.SelectedItem;
            Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;

            if (this.conductor == null)
            {
                throw new Exception("Debe seleccionar un conductor");
            }

            if (empresa == null)
            {
                throw new Exception("Debe seleccionar una empresa");
            }

            if (estacion == null)
            {
                if (this.EstacionesComboBox.Items.Count > 0)
                {
                    throw new Exception("Debe seleccionar una estacion");
                }
                else 
                {
                    AppHelper.ThrowException("Debe tener acceso a al menos una estacion");
                }            
            }

            if (tipocontrato == null)
            {
                throw new Exception("Debe seleccionar un tipo contrato");
            }

            Padre.Contrato.EstatusContrato_ID = 1;
            Padre.Contrato.Empresa_ID = (int)empresa.Empresa_ID;
            Padre.Contrato.Estacion_ID = estacion.Estacion_ID.Value;
            Padre.Contrato.TipoContrato_ID = tipocontrato.TipoContrato_ID;
            Padre.Contrato.Conductor_ID = conductor.Conductor_ID;

            Padre.Summary["Empresa"] = empresa.Nombre;
            Padre.Summary["Estacion"] = estacion.Nombre;
            Padre.Summary["Tipo de contrato"] = tipocontrato.Nombre;
            Padre.Summary["Conductor"] = conductor.Apellidos + " " + conductor.Nombre;
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            //  Los tipos de contratos
            tiposContratosBindingSource.DataSource = Entities.TiposContratos.Read();

            //  Las empresas
            selectEmpresasInternasBindingSource.DataSource = Sesion.Empresas;

            //  Las estaciones
            estacionesBindingSource.DataSource = Sesion.Estaciones;
        }

        /// <summary>
        /// Busca los conductores en la base de datos y los despliega en el formulario
        /// </summary>
        private void GetConductores()
        {
            int estacion_id;

            Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;
            if (estacion == null)
            {
                if (Sesion.Estacion_ID == null)
                {
                    AppHelper.ThrowException("Debe tener acceso a al menos una estacion");
                }

                estacion_id = Sesion.Estacion_ID.Value;
            }
            else
            {
                estacion_id = estacion.Estacion_ID.Value;
            }

            int? conductor_id = null;

            string filter = @"(@Conductor_ID IS NULL OR Conductor_ID = @Conductor_ID) AND
                (@Nombre IS NULL OR Nombre LIKE @Nombre + '%' OR Apellidos LIKE @Nombre + '%')
                AND EstatusConductor_ID NOT IN (10,12)
                AND Estacion_ID = @Estacion_ID";            

            if (!string.IsNullOrEmpty(this.Conductor_IDTextBox.Text))
            {
                if (AppHelper.IsNumeric(this.Conductor_IDTextBox.Text))
                {
                    conductor_id = Convert.ToInt32(this.Conductor_IDTextBox.Text);
                }
            }
            
            string nombre = this.NombreConductorTextBox.Text;

            conductoresBindingSource.DataSource = 
                Entities.Conductores.Read(
                    filter, 
                    null, 
                    DB.Param("@Conductor_ID", conductor_id),
                    DB.Param("@Nombre", nombre),
                    DB.Param("@Estacion_ID", estacion_id)
                );
        }

        /// <summary>
        /// Selecciona el conductor a ligar al contrato
        /// </summary>
        /// <param name="rowindex">El índice del renglon seleccionado.</param>
        private void SelectConductor(int rowindex)
        {
            conductor = (Entities.Conductores)ConductoresDataGridView.Rows[rowindex].DataBoundItem;
            this.Conductor_IDTextBox.Text = conductor.Conductor_ID.ToString();
            this.NombreConductorTextBox.Text = conductor.Apellidos + " " + conductor.Nombre;
            this.conductoresBindingSource.DataSource = null;
        }

        /// <summary>
        /// Maneja el evento "Click" para el botón "Buscar"
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(GetConductores), this);
        }

        /// <summary>
        /// Maneja el evento "CellContentClick" del control "ConductoresDataGridView"
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void ConductoresDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ConductoresDataGridView.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    SelectConductor(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Siguiente"
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoValidate();                
                Padre.SwitchPanel("DatosUnidad");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }
    } // end class Contratos_DatosConductorUCRenta

} // end namespace
