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
    /// Este formulario muestra el listado de las zonas de venta de servicios de
    /// transportación terrestre, en la estación de Aeropuerto
    /// </summary>
    public partial class Zonas : baseForm
    {
        /// <summary>
        /// Crea una instancia de Zonas
        /// </summary>
        public Zonas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Obtiene todas las zonas y las coloca en el objeto DataSource
            Vista_ZonasBindingSource.DataSource = Entities.Vista_Zonas.Get(null);
            base.BindData();
        }

        /// <summary>
        /// Realiza una consulta de zonas al sistema
        /// </summary>
        private void DoQuery()
        {
            //  El nombre de la zona
            String nombre;
            nombre = Convert.ToString(NombreTextBox.Text);
            //  Obtiene las zonas y las asigna al objeto DataSource
            Vista_ZonasBindingSource.DataSource = Entities.Vista_Zonas.Get(nombre);
        }

        /// <summary>
        /// Las variables para contener el numero de renglon (row) y columna (col)
        /// cuando el usuario hace clic en un renglón del objeto GridView
        /// </summary>
        int row, col;

        /// <summary>
        /// Navega al formulario de actualización de la zona, cuando el usuario
        /// hace clic en la columna "EditColumn"
        /// </summary>
        private void DoNavigate()
        {
            //  Si el usario hace clic en "EditColumn"
            if (Vista_ZonasDataGridView.Columns[col].Name == "EditColumn")
            {
                //  Declaramos el formulario de actualización de zonas
                forms.ActualizacionZonas ZonasForm = new ActualizacionZonas();

                //  Obtenemos el objeto Zonas del renglón que el usuario eligió
                Entities.Vista_Zonas ZonasLower = (Entities.Vista_Zonas)Vista_ZonasDataGridView.Rows[row].DataBoundItem;

                //  Configuramos el dato Zona_ID a partir del objeto Zonas obtenido
                ZonasForm.Zona_ID = ZonasLower.Zona_ID;

                //  Llamamos a "SwitchForma" para navegar
                Padre.SwitchForma("ActualizacionZonas", ZonasForm);

            } // end if

        } // end Navigate

        /// <summary>
        /// Al hacer clic en "Buscar", se realizará la busqueda en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            //  Llamamos a DoQuery
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Al hacer clic en el contenido de una celda de la GridView, 
        /// llamamos a "DoNavigate"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vista_ZonasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  Configuramos renglon y columna
            row = e.RowIndex;
            col = e.ColumnIndex;

            //  Llamamos a "DoNavigate"
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        } // end void

    } // end class

} // end namespace
