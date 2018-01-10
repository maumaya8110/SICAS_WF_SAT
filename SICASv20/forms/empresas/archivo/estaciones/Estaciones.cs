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
    /// Formulario para la visualización de estaciones
    /// </summary>
    public partial class Estaciones : baseForm
    {
        public Estaciones()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.estacionesBindingSource.DataSource = Entities.Estaciones.Read();
            this.selectEmpresasInternasBindingSource.DataSource = Entities.SelectEmpresasInternas.GetAll();
            base.BindData();
        }

        /// <summary>
        /// Muestra el formulario para actualizar la información
        /// de la estación seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estacionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    if (this.estacionesDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                    {
                        forms.ActualizacionEstaciones ae = new forms.ActualizacionEstaciones();
                        Entities.Estaciones estacion = (Entities.Estaciones)this.estacionesDataGridView.Rows[e.RowIndex].DataBoundItem;
                        ae.Estacion_ID = estacion.Estacion_ID;
                        Padre.SwitchForma("ActualizacionEstaciones", ae);
                    }
                },
                this
            );
        }

        /// <summary>
        /// Busca las estaciones en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    estacionesBindingSource.DataSource =
                        Entities.Estaciones.Read(
                            @"(@Empresa_ID IS NULL OR Empresa_ID = @Empresa_ID)
                            AND (@Nombre IS NULL OR Nombre LIKE @Nombre + '%')",
                            null,
                            DB.Param("@Empresa_ID", this.EmpresaComboBox.SelectedValue),
                            DB.Param("@Nombre", this.NombreTextBox.Text)
                        );
                },
                this
            );
        }

        /// <summary>
        /// Elimina la relación de datos con los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Estaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.estacionesDataGridView.DataSource = null;
                }
            );
        }
    }
}
