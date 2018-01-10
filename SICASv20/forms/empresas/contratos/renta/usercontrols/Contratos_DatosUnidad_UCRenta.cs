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
    /// Formulario para configurar los datos de unidad para un contrato
    /// </summary>
    public partial class Contratos_DatosUnidad_UCRenta : baseUserControl
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Contratos_DatosUnidad_UCRenta"/>.
        /// </summary>
        public Contratos_DatosUnidad_UCRenta()
        {
            InitializeComponent();
            BindData();
        }

        /// <summary>
        /// Referencia al formulario "AsistenteContratos" que contiene al formulario Contratos_DatosUnidad_UC
        /// </summary>
        public AsistenteContratosRenta Padre;

        /// <summary>
        /// La unidad a ligar al contrato
        /// </summary>
        Entities.Unidades unidad;

        /// <summary>
        /// Busca las unidades en la base de datos, que concuerden con el número económico buscado
        /// </summary>
        /// <exception cref="System.Exception">El número económico debe tener valores numéricos</exception>
        private void DoQuery()
        {
            int? numeroeconomico = null; string placas = null;

            if (!string.IsNullOrEmpty(NumeroEconomicoTextBox.Text))
            {
                if (AppHelper.IsNumeric(NumeroEconomicoTextBox.Text))
                {
                    numeroeconomico = Convert.ToInt32(NumeroEconomicoTextBox.Text);
                }
                else
                {
                    throw new Exception("El número económico debe tener valores numéricos");
                }
            }

            //  Obtenemos las placas
            placas = string.IsNullOrEmpty(PlacasTextBox.Text) ? null : PlacasTextBox.Text;

            //  Variable para contener las unidades
            List<Entities.Unidades> unidades;

            //  Filtro de búsqueda de las unidades
            //  Buscar por Numeroeconómico o placas
            //  Las unidades deben no tener contrato activo
            //  y deben pertenecer a la estación seleccionada
            string filter = @"(@NumeroEconomico IS NULL OR NumeroEconomico = @NumeroEconomico) AND 
                (@Placas IS NULL OR Placas = @Placas) AND Unidad_ID NOT IN (SELECT Unidad_ID FROM Contratos
                WHERE EstatusContrato_ID = 1 AND Unidad_ID IS NOT NULL AND Empresa_ID = @Empresa_ID ) AND EstatusUnidad_ID = 1
                AND (@Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID)";

            //  Obtenemos las unidades
            unidades = Entities.Unidades.Read(
                        filter,
                        null,
                        DB.Param("@NumeroEconomico", numeroeconomico),
                        DB.Param("@Placas", placas),
                        DB.Param("@Estacion_ID", Padre.Contrato.Estacion_ID),
                        DB.Param("@Empresa_ID", Padre.Contrato.Empresa_ID)
                    );

            //  Las ligamos a los datos
            unidadesBindingSource.DataSource = unidades;
        }

        /// <summary>
        /// Liga los datos a los contoles
        /// </summary>
        public void BindData()
        {
            diasDeCobrosBindingSource.DataSource = Entities.DiasDeCobros.Read();
        }

        /// <summary>
        /// Realiza la validación de los datos de entrada
        /// </summary>
        /// <exception cref="System.Exception">
        /// Debe capturar una unidad
        /// o
        /// Debe capturar un dia de cobro
        /// o
        /// Debe capturar un monto diario
        /// o
        /// Debe capturar un fondo residual
        /// </exception>
        private void DoValidate()
        {

            if (unidad == null)
            {
                throw new Exception("Debe capturar una unidad");
            }

            //  Actualizamos los datos del contrato
            Padre.Contrato.Unidad_ID = unidad.Unidad_ID;
            Padre.Contrato.NumeroEconomico = unidad.NumeroEconomico;
            Padre.Contrato.ModeloUnidad_ID = unidad.ModeloUnidad_ID;

            //  Agregamos definiciones al resumen
            Padre.Summary["Unidad"] = unidad.NumeroEconomico.ToString();
            Padre.Summary["Monto diario"] = this.Padre.Contrato.MontoDiario.ToString("N2");
        }

        /// <summary>
        /// Selecciona la unidad a asignar el contrato
        /// </summary>
        /// <param name="rowindex">El índice de la unidad seleccionada</param>
        private void SelectUnidad(int rowindex)
        {
            //  Obtenemos la unidad
            unidad = (Entities.Unidades)UnidadesGridView.Rows[rowindex].DataBoundItem;

            //  Mostramos sus datos
            NumeroEconomicoTextBox.Text = unidad.NumeroEconomico.ToString();
            PlacasTextBox.Text = unidad.Placas;

            //  Liberamos los datos del control de listado de unidades
            unidadesBindingSource.DataSource = null;
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Atras"
        /// </summary>
        /// <param name="sender">El botón "Atras"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void AtrasButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("DatosConductor");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Siguiente"
        /// </summary>
        /// <param name="sender">El botón "Siguiente"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Validamos los datos de entrada
                DoValidate();

                //  Navegamos al panel de datos de cuenta y fechas
                Padre.datosCuentaFechasControl.BindData();
                Padre.SwitchPanel("DatosCuentaFechas");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Buscar"
        /// </summary>
        /// <param name="sender">El botón "Buscar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Maneja el evento "CellContentClick" del control UnidadesGridView
        /// </summary>
        /// <param name="sender">El botón "Buscar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void UnidadesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UnidadesGridView.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    SelectUnidad(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

    } // end class Contratos_DatosUnidad_UCRenta
} // SICASv20.forms