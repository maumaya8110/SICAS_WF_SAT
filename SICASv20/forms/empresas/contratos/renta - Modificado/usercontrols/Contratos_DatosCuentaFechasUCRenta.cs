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
    /// Formulario para especifica las fechas en un contrato de renta de unidad
    /// </summary>
    public partial class Contratos_DatosCuentaFechasUCRenta : baseUserControl
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para especificar
        /// las fechas en un contrato de renta de unidad
        /// </summary>
        public Contratos_DatosCuentaFechasUCRenta()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Referencia a la forma Padre, el "AsistenteContratos"
        /// </summary>
        public AsistenteContratosRenta Padre;

        /// <summary>
        /// La cuenta a asignar al contrato
        /// </summary>
        private const int Cuenta_ID = 1;

        /// <summary>
        /// El concepto por el cual se cobrará el contrato
        /// </summary>
        private const int Concepto_ID = 1;

        /// <summary>
        /// La descripcion de la cuenta a asignar al contrato
        /// </summary>
        private const string Cuenta_Nombre = "RENTAS";

        /// <summary>
        /// La descripcion de la cuenta a asignar al contrato
        /// </summary>
        private const string Concepto_Nombre = "RENTAS";

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            this.planesDeRentaBindingSource.DataSource =
                    Entities.PlanesDeRenta.ReadList(
                        DB.Param("Activo", true),
                        DB.Param("Estacion_ID", this.Padre.Contrato.Estacion_ID)
                    );

            this.FechaInicialDataTimePicker.Value = DB.GetDate().AddDays(1).Date;

            Select_PlanDeRenta();
        }

        /// <summary>
        /// Realiza las validaciones
        /// </summary>
        /// <exception cref="System.Exception">
        /// Debe seleccionar una cuenta
        /// o
        /// Debe seleccionar un concepto
        /// o
        /// La fecha inicial debe ser mayor al día de hoy
        /// o
        /// La fecha final debe ser mayor a la fecha inicial
        /// </exception>
        private void DoValidate()
        {            
            Padre.Contrato.Cuenta_ID = Cuenta_ID;
            Padre.Contrato.Concepto_ID = Concepto_ID;
            Padre.Contrato.FechaInicial = FechaInicialDataTimePicker.Value.Date;
            Padre.Contrato.CobroPermanente = CobroPermanenteCheckBox.Checked;
            Padre.Contrato.Descripcion = DescripcionTextBox.Text;

            if (Padre.Contrato.FechaInicial <= DateTime.Today)
            {
                throw new Exception("La fecha inicial debe ser mayor al día de hoy");
            }

            if(CobroPermanenteCheckBox.Checked)
            {
                Padre.Contrato.FechaFinal = null;                
            }
            else
            {
                Padre.Contrato.FechaFinal = FechaFinalDateTimePicker.Value.Date;
            }

            if (Padre.Contrato.FechaFinal <= Padre.Contrato.FechaInicial)
            {
                throw new Exception("La fecha final debe ser mayor a la fecha inicial");
            }

            Padre.Summary["Cuenta"] = Cuenta_Nombre;
            Padre.Summary["Concepto"] = Concepto_Nombre;
            Padre.Summary["Fecha inicial"] = string.Format("{0:yyyy-MM-dd}", FechaInicialDataTimePicker.Value);
            Padre.Summary["Fecha final"] = string.Format("{0:yyyy-MM-dd}", FechaFinalDateTimePicker.Value);
            Padre.Summary["Cobro permanente"] = (CobroPermanenteCheckBox.Checked) ? "SI" : "NO";
        }

        /// <summary>
        /// Asigna un plan de renta al contrato a generar
        /// </summary>
        private void Select_PlanDeRenta()
        {
            //  Obtenemos el plan de renta seleccionado
            Entities.PlanesDeRenta planDeRenta;
            planDeRenta = (Entities.PlanesDeRenta)PlanesDeRentaComboBox.SelectedItem;

            if (planDeRenta == null)
            {
                AppHelper.ThrowException("Debe seleccionar un plan de renta");
            }

            //  Asignamos los datos del plan al contrato actual
            Padre.Contrato.DiasDeCobro_ID = planDeRenta.DiasDeCobro_ID;
            Padre.Contrato.MontoDiario = planDeRenta.RentaBase;
            Padre.Contrato.FondoResidual = Convert.ToDecimal(AppHelper.IsNull(planDeRenta.FondoResidual, 0.0));

            //  Desplegamos la información en los controles de la forma
            this.DescripcionPlanTextBox.Text = planDeRenta.Descripcion;
            this.DiasDeCobroTextBox.Text = Padre.Summary["Dias de Cobro"] = Entities.DiasDeCobros.Read(planDeRenta.DiasDeCobro_ID).Nombre;
            this.MontoDiarioTextBox.Text = Padre.Summary["Monto diario"] = AppHelper.N2(planDeRenta.RentaBase);
            this.FondoResidualTextBox.Text = AppHelper.N2(planDeRenta.FondoResidual);
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
                Padre.SwitchPanel("DatosUnidad");
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

                //  Ligamos los datos del control "Resumen" del formulario "Padre"
                Padre.resumenControl.BindData();

                //  Navegamos al panel de "Resumen"
                Padre.SwitchPanel("Resumen");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" del control "PlanesDeRentaComboBox"
        /// </summary>
        /// <param name="sender">El control "PlanesDeRentaComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void PlanesDeRentaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate 
                {
                    Select_PlanDeRenta();
                }
            );
        }

    } // end class

} // end namespace
