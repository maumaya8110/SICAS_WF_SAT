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
    /// Formulario del reporte "Cobranza Atención y Control", que muestra información
    /// relevante de cobranza de los conductores
    /// </summary>
    public partial class CobranzaAtencionYControl : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de Cobranza, Atención y Control
        /// </summary>
        public CobranzaAtencionYControl()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Formulario para actualizar los datos de cobranza
        /// </summary>
        private forms.ActualizarCobranzaConductor ActualizarCobranzaForm;

        /// <summary>
        /// Muestra el formulario para actualizar los datos
        /// de cobranza del conductor seleccionado
        /// </summary>
        /// <param name="conductor_id"></param>
        private void ShowDatosCobranza(int conductor_id)
        {
            if (this.ActualizarCobranzaForm == null)
                this.ActualizarCobranzaForm = new ActualizarCobranzaConductor();

            if (this.ActualizarCobranzaForm.IsDisposed)
                this.ActualizarCobranzaForm = new ActualizarCobranzaConductor();

            this.ActualizarCobranzaForm.Set_Conductor(conductor_id);

            //  Si regresa "OK", es decir, se actualizaron los datos
            if (this.ActualizarCobranzaForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //  Volvemos a cargar la información
                this.DoQuery();
            }            
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Asigna las empresas y las estaciones, a partir de la sesión
            // y los permisos del usuario
            empresasBindingSource.DataSource = Sesion.EmpresasTodas;
            estacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            base.BindData();
        }             

        /// <summary>
        /// Consulta el reporte en la base de datos
        /// </summary>
        private void DoQuery()
        {
            //  Obtenemos las variables de los controles
            int? numeroeconomico = DB.GetNullableInt32(UnidadTextBox.Text);
            string nombre = String.IsNullOrEmpty(ConductorTextBox.Text) ? null : ConductorTextBox.Text;
            int? empresa_id = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);
            int? estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);            

            //  Actualizamos la información del reporte
            //  buscando en la base de datos, a partir de los parámetros
            reporte_CobranzaAtencionYControlBindingSource.DataSource = 
                Entities.Vista_CobranzaAtencionYControl.GetDataTable(numeroeconomico, nombre, empresa_id, estacion_id, Sesion.Usuario_ID);
        }
        
        /// <summary>
        /// Al hacer clic en "Buscar", consultamos el reporte en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(DoQuery, this);
        }

        /// <summary>
        /// Al hacer clic en "Expotar", exportamos la información
        /// del reporte a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.reporte_CobranzaAtencionYControlDataGridView, this);
        }

        /// <summary>
        /// Al hacer clic en una celda,
        /// si el dato de la celda es de cobranza,
        /// muestra la ventana para actualizar la información
        /// de cobranza del conductor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reporte_CobranzaAtencionYControlDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //  El arreglo de columnas
                string[] cols = new string[] { "SaldoATratarCol", "CronoCascoCol", "TerminalDatosCol", 
                                                "BloquearConductorCol", "MensajeACajaCol" };

                //  Pasamos el arrego a lista
                List<string> ls = new List<string>(cols.Length);
                ls.AddRange(cols);

                //  Si la columna clickeada esta en la lista
                if (ls.Contains(this.reporte_CobranzaAtencionYControlDataGridView.Columns[e.ColumnIndex].Name))
                {
                    int conductor_id = Convert.ToInt32(reporte_CobranzaAtencionYControlDataGridView.Rows[e.RowIndex].Cells["Conductor_IDCol"].Value);
                    this.ShowDatosCobranza(conductor_id);
                }   //  End If 
                else if (this.reporte_CobranzaAtencionYControlDataGridView.Columns[e.ColumnIndex].Name.Equals("HistorialColumn"))
                {
                    forms.ReporteHistorialCobranzaConductor ac = new forms.ReporteHistorialCobranzaConductor();
                    ac.Conductor_ID = Convert.ToInt32(reporte_CobranzaAtencionYControlDataGridView.Rows[e.RowIndex].Cells["Conductor_IDCol"].Value);
                    Padre.SwitchForma("ReporteHistorialCobranzaConductor", ac);
                }
            }   //  End Try
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }   //  End Sub
    }   //  End Class
}   //  End Namespace