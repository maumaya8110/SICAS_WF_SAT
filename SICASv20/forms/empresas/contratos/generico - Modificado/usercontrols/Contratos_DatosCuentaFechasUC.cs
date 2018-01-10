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
    /// Formulario para especifica las fechas en un contrato
    /// </summary>
    public partial class Contratos_DatosCuentaFechasUC : baseUserControl
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para especificar
        /// las fechas en un contrato
        /// </summary>
        public Contratos_DatosCuentaFechasUC()
        {
            InitializeComponent();
            BindData();
        }

        /// <summary>
        /// Referencia a la forma Padre, el "AsistenteContratos"
        /// </summary>
        public AsistenteContratos Padre;

        /// <summary>
        /// La cuenta a asignar al contrato
        /// </summary>
        Entities.Cuentas cuenta;

        /// <summary>
        /// El concepto por el cual se cobrará el contrato
        /// </summary>
        Entities.Conceptos concepto;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            cuentasBindingSource.DataSource = Entities.Cuentas.Read();
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
            concepto = (Entities.Conceptos)ConceptoComboBox.SelectedItem;

            if (cuenta == null)
            {
                throw new Exception("Debe seleccionar una cuenta");
            }

            if (concepto == null)
            {
                throw new Exception("Debe seleccionar un concepto");
            }            

            //  Los datos válidados los asignamos al contrato
            Padre.Contrato.Cuenta_ID = cuenta.Cuenta_ID;
            Padre.Contrato.Concepto_ID = concepto.Concepto_ID;
            Padre.Contrato.FechaInicial = FechaInicialDataTimePicker.Value;
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
                Padre.Contrato.FechaFinal = FechaFinalDateTimePicker.Value;
            }

            if (Padre.Contrato.FechaFinal <= Padre.Contrato.FechaInicial)
            {
                throw new Exception("La fecha final debe ser mayor a la fecha inicial");
            }

            //  Conjuntamos las descripciones para el resumen del contrato
            Padre.Summary["Cuenta"] = cuenta.Nombre;
            Padre.Summary["Concepto"] = concepto.Nombre;
            Padre.Summary["Fecha inicial"] = string.Format("{0:yyyy-MM-dd}", FechaInicialDataTimePicker.Value);
            Padre.Summary["Fecha final"] = string.Format("{0:yyyy-MM-dd}", FechaFinalDateTimePicker.Value);
            Padre.Summary["Cobro permanente"] = (CobroPermanenteCheckBox.Checked) ? "SI" : "NO";
        }

        /// <summary>
        /// Obtene los conceptos a partir de la cuenta seleccionada
        /// </summary>
        private void GetConcepto()
        {
            //  Obtenemos la cuenta seleccionada
            cuenta = (Entities.Cuentas)CuentasComboBox.SelectedItem;

            //  Consultamos los conceptos de la cuenta
            conceptosBindingSource.DataSource = Entities.Conceptos.Read(DB.Param("Cuenta_ID", cuenta.Cuenta_ID));
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" del control CuentaComboBox
        /// </summary>
        /// <param name="sender">La fuente del evento, el control "CuentasComboBox"</param>
        /// <param name="e">los argumentos del evento</param>
        private void CuentasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //  Obtenemos el concepto
                GetConcepto();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
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
                //  Navegamos a los datos de unidad
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

    } // end class

} // end namespace
