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
    /// Formulario para el reporte de registro de solicitantes
    /// </summary>
    public partial class ReporteRegistroSolicitantesForm : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de registro de solicitantes
        /// </summary>
        public ReporteRegistroSolicitantesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Configuramos empresas y estaciones
            this.selectEmpresasInternasBindingSource.DataSource = Sesion.Empresas;
            this.selectEstacionesBindingSource.DataSource = Sesion.Estaciones;

            base.BindData();
        }
        
        /// <summary>
        /// Consulta la información del reporte y la despliega en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Consulta la información
                    this.Reporte_RegistroPublicitarioBindingSource.DataSource =
                    Entities.Vista_RegistroPublicitario.GetDataTable(
                        DB.GetNullableInt32(this.EstacionesComboBox.SelectedValue),
                        AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value),
                        AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value)
                    );

                    //  Refresca el reporte
                    this.RegistroSolicitantesReportViewer.RefreshReport();
                },
                this
            );
        }
    } // end class
} // end namespace
