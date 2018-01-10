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
    /// Formulario para visualizar los planes de renta
    /// </summary>
    public partial class PlanesDeRenta : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para visualizar los planes de renta
        /// </summary>
        public PlanesDeRenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            List<Entities.SelectEstaciones> estaciones = Sesion.Estaciones;
            int? estacion_id = null;

            selectModelosUnidadesBindingSource.DataSource = Entities.SelectModelosUnidades.Get();
            selectDiasDeCobrosBindingSource.DataSource = Entities.SelectDiasDeCobros.Get();
            selectEstacionesBindingSource.DataSource = estaciones;

            if (estaciones.Count == 1) estacion_id = estaciones[0].Estacion_ID;

            List<Entities.Vista_PlanesDeRenta> Planes = Entities.Vista_PlanesDeRenta.Get(null, null, null, null, estacion_id);
            Vista_PlanesDeRentaBindingSource.DataSource = Planes;

            base.BindData();
        }

        /// <summary>
        /// Busca la información en la base de datos
        /// </summary>
        private void DoQuery()
        {
            //  Declaramos las variables
            Int32? modelounidad_id;
            Int32? diasdecobro_id;
            String descripcion;
            Decimal? rentabase;
            Int32? estacion_id;

            //  Obtenemos su valor de los controles
            modelounidad_id = DB.GetNullableInt32(ModeloUnidad_IDComboBox.SelectedValue);
            diasdecobro_id = DB.GetNullableInt32(DiasDeCobro_IDComboBox.SelectedValue);
            descripcion = DescripcionTextBox.Text;
            rentabase = DB.GetNullableDecimal(RentaBaseTextBox.Text);
            estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);

            //  Buscamos los datos y los ligamos a los controles
            Vista_PlanesDeRentaBindingSource.DataSource = 
                Entities.Vista_PlanesDeRenta.Get(modelounidad_id, diasdecobro_id, descripcion, rentabase, estacion_id);
        }

        int row, col;

        /// <summary>
        /// Cambia de formulario actual, al de actualización de planes de renta
        /// </summary>
        private void DoNavigate()
        {
            if (Vista_PlanesDeRentaDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionPlanesDeRenta PlanesDeRentaForm = new ActualizacionPlanesDeRenta();
                Entities.Vista_PlanesDeRenta PlanesDeRentaLower = (Entities.Vista_PlanesDeRenta)Vista_PlanesDeRentaDataGridView.Rows[row].DataBoundItem;
                PlanesDeRentaForm.PlanDeRenta_ID = PlanesDeRentaLower.PlanDeRenta_ID.Value;

                Padre.SwitchForma("ActualizacionPlanesDeRenta", PlanesDeRentaForm);
            }
        }

        /// <summary>
        /// Solicita la busqueda de la información en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Despliega el formulario de actualización de información para el 
        /// plan de renta especificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vista_PlanesDeRentaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }


    }
}
