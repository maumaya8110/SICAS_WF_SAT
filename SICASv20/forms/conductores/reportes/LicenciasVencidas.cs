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
    /// Formulario que representa las licencias vencidas
    /// </summary>
    public partial class LicenciasVencidas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario
        /// de licencias vencidas
        /// </summary>
        public LicenciasVencidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.selectEstacionesBindingSource.DataSource =
                Sesion.EstacionesTodas;
            DoQuery();

            base.BindData();
        }

        /// <summary>
        /// Consula la información en la base de datos
        /// </summary>
        private void DoQuery()
        {
            try
            {
                //  Obtenemos la estación
                int? Estacion_ID = 
                    (Estacion_IDComboBox.SelectedValue == null || Convert.IsDBNull(Estacion_IDComboBox.SelectedValue))
                        ? null : (int?)Estacion_IDComboBox.SelectedValue;

                //  Consultamos la información y mostramos los resultados
                get_LicenciasVencidasTableAdapter.Fill(sICASCentralQuerysDataSet.Get_LicenciasVencidas, Estacion_ID);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Al cambiar la estación, volvemos a buscar la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Estacion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DoQuery();
        }

        /// <summary>
        /// Al hacer clic en una celda de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void get_LicenciasVencidasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  Si se hizo clic en actualizar
            if (get_LicenciasVencidasDataGridView.Rows[e.RowIndex].Cells["Actualizar"].ColumnIndex == e.ColumnIndex)
            {
                //  Obtenemos el conductor
                int _Conductor_ID = Convert.ToInt32(get_LicenciasVencidasDataGridView.Rows[e.RowIndex].Cells["Conductor_ID"].Value);

                //  Mostramos la ventana para actualizar conductor
                forms.ActualizacionConductor ac = new forms.ActualizacionConductor();
                ac.Conductor_ID = _Conductor_ID;
                ac.Tab = "Publicitario";
                Padre.SwitchForma("ActualizacionConductor", ac);
            }
        }

        /// <summary>
        /// Colorea los renglones, a partir de la fecha de vencimiento
        /// </summary>
        private void ColourRows()
        {
            //  Declaramos las variables

            //  Contendra el índice de las celdas
            int cellindex = 0;

            //  Indicará si la propiedad existe
            bool propExiste = false;

            //  El nombre de la propiedad buscada
            string datapropertyname = "VenceLicencia";

            //  El valor de la propiedad
            object val = null;

            //  Buscarmos la columna con el DataPropertyName referido
            foreach (DataGridViewColumn col in get_LicenciasVencidasDataGridView.Columns)
            {
                if (col.DataPropertyName == datapropertyname)
                {
                    //  Existe
                    //  Obtenemos el índice
                    cellindex = col.Index;
                    //  Pasamos "true" a la variable "propExiste"
                    propExiste = true;
                    //  Salimos del ciclo
                    break;
                }
            }

            //  Si existe el DataPropertName en la lista de columnas
            if (propExiste)
            {
                //  Recorremos la colección de "DataGridViewRows"
                foreach (DataGridViewRow row in get_LicenciasVencidasDataGridView.Rows)
                {
                    //  Obtenermos el valor de la celda
                    //  lo guardamos en la variable "val"
                    val = row.Cells[cellindex].Value;

                    if (((DateTime)val).Date < DateTime.Now.Date)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255,102,102); 
                    }
                }
            }
        }

        /// <summary>
        /// Al terminar de ligar los datos del reporte,
        /// se colorean los renglones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void get_LicenciasVencidasDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.ColourRows();
                }
            );
        }

    } // end class

} // end namespace
