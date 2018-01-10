using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SICASv20.forms
{
    /// <summary>
    /// Da de alta un arrendamiento en el sistema
    /// </summary>
    public partial class AltaArrendamiento : baseForm
    {
        public AltaArrendamiento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <exception cref="System.Exception">
        /// La fecha final no puede ser menor a la fecha inicial
        /// or
        /// La fecha inicial no puede ser el día de hoy
        /// </exception>
        private void DoValidate()
        {
            if (fechaFinalDateTimePicker.Value < fechaInicialDateTimePicker.Value)
            {
                throw new Exception("La fecha final no puede ser menor a la fecha inicial");
            }

            if (fechaInicialDateTimePicker.Value.Date == DateTime.Today)
            {
                throw new Exception("La fecha inicial no puede ser el día de hoy");
            }
        }

        /// <summary>
        /// Does the save.
        /// </summary>
        private void DoSave()
        {
            try
            {
                DoValidate();
                this.Validate();
                this.arrendamientosBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                AppHelper.Info("Arrendamiento creado!");
                Padre.SwitchForma("Arrendamientos");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            arrendamientosBindingSource.AddNew();
            Application.DoEvents();

            this.estatusFinancierosTableAdapter.Fill(this.sICASCentralDataSet.EstatusFinancieros);

            this.get_EmpresasInternasTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_EmpresasInternas);

            this.empresasTableAdapter.Fill(this.sICASCentralDataSet.Empresas);            

            activoCheckBox.Checked = true;

            base.BindData();
        }

        /// <summary>
        /// The plazos
        /// </summary>
        private int plazos;

        /// <summary>
        /// The mensualidad, valorfactura, residual, amortizacionResidual, montoAFinanciar
        /// </summary>
        private Single mensualidad, valorfactura, residual, amortizacionResidual, montoAFinanciar;


        /// <summary>
        /// Tries the calculate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void TryCalculate(object sender)
        {
            try
            {
                string name;
                Control ctl;

                ctl = (Control)sender;
                name = ctl.Name;

                switch (name)
                {
                    case "PlazosNumericUpDown":
                        CalcularTasa();
                        CalcularAmortizacionResidual();
                        CalcularMontoAFinanciar();
                        CalcularFechaFinal();
                        break;
                    case "valorFacturaTextBox":
                        CalcularTasa();
                        break;
                    case "mensualidadTextBox":
                        CalcularTasa();
                        CalcularMontoAFinanciar();
                        CalcularAmortizacionResidual();
                        break;
                    case "residualTextBox":
                        CalcularTasa();
                        CalcularAmortizacionResidual();
                        CalcularMontoAFinanciar();
                        break;
                    case "fechaInicialTextBox":
                        CalcularFechaFinal();
                        break;
                }
            }
            catch {}
        }

        /// <summary>
        /// Calculars the mensualidad.
        /// </summary>
        private void CalcularMensualidad()
        {            
            montoAFinanciar = Convert.ToSingle(montoAFinanciarTextBox.Text);
            plazos = Convert.ToInt32(PlazosNumericUpDown.Value);
            mensualidad = (montoAFinanciar / Convert.ToSingle(plazos));
            mensualidadTextBox.Text = Math.Round(mensualidad, 2).ToString();
        }

        /// <summary>
        /// Calculars the monto A financiar.
        /// </summary>
        private void CalcularMontoAFinanciar()
        {            
            mensualidad = Convert.ToSingle(mensualidadTextBox.Text);
            plazos = Convert.ToInt32(PlazosNumericUpDown.Value);
            residual = Convert.ToSingle(residualTextBox.Text);
            montoAFinanciar = (mensualidad * Convert.ToSingle(plazos)) + residual;

            montoAFinanciarTextBox.Text = Math.Round(montoAFinanciar, 2).ToString();
            saldoTextBox.Text = Math.Round(montoAFinanciar, 2).ToString();
            plazosRestantesTextBox.Text = plazos.ToString();
            proximaFechaTextBox.Text = fechaInicialDateTimePicker.Value.AddMonths(1).ToShortDateString();
        }

        /// <summary>
        /// Calculars the amortizacion residual.
        /// </summary>
        private void CalcularAmortizacionResidual()
        {            
            plazos = Convert.ToInt32(PlazosNumericUpDown.Value);
            residual = Convert.ToSingle(residualTextBox.Text);
            amortizacionResidual = residual / Convert.ToSingle(plazos);

            amortizacionResidualTextBox.Text = Math.Round(amortizacionResidual, 2).ToString();
        }

        /// <summary>
        /// Calculars the tasa.
        /// </summary>
        private void CalcularTasa()
        {            
            mensualidad = Convert.ToSingle(mensualidadTextBox.Text);
            plazos = Convert.ToInt32(PlazosNumericUpDown.Value);
            residual = Convert.ToSingle(residualTextBox.Text);
            valorfactura = Convert.ToSingle(valorFacturaTextBox.Text);

            double periodos, pago, VA, VF, rate;

            periodos = Convert.ToDouble(plazos);
            pago = Convert.ToDouble(mensualidad);
            VA = Convert.ToDouble(valorfactura);
            VF = Convert.ToDouble(residual);
            rate = Financial.Rate(periodos, pago * -1, VA, VF * -1, DueDate.EndOfPeriod, 0.1);
            rate *= 12;

            tasaTextBox.Text = Convert.ToString(Math.Round(rate, 2));            
        }

        /// <summary>
        /// Calculars the fecha final.
        /// </summary>
        private void CalcularFechaFinal()
        {
            plazos = Convert.ToInt32(PlazosNumericUpDown.Value);

            DateTime fechafinal = fechaInicialDateTimePicker.Value.AddMonths(plazos);
            fechaFinalDateTimePicker.Value = fechafinal;

            proximaFechaTextBox.Text = fechaInicialDateTimePicker.Value.AddMonths(1).ToShortDateString();
        }

        /// <summary>
        /// Handles the TextChanged event of the montoAFinanciarTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void montoAFinanciarTextBox_TextChanged(object sender, EventArgs e)
        {
            TryCalculate(sender);
        }

        /// <summary>
        /// Handles the ValueChanged event of the PlazosNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PlazosNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TryCalculate(sender);
        }

        /// <summary>
        /// Handles the Click event of the GuardarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        /// <summary>
        /// Handles the ValueChanged event of the fechaInicialDateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void fechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularFechaFinal();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

    }
}
