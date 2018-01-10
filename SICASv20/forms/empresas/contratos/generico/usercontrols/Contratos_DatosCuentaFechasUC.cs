using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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



        private void MostrarDiasDevengar()
        {
            this.diasDevengarTextBox.Visible = false;
            this.lblDiasRenta.Visible = false;
            this.FechaFinalDateTimePicker.Enabled = true;
            this.FechaFinalDateTimePicker.Value = DateTime.Now;

            if (this.Padre.Contrato.Empresa_ID > 0)
            //(this.Padre.Contrato.Empresa_ID == 601 || this.Padre.Contrato.Empresa_ID == 2) || this.Padre.Contrato.Empresa_ID == 1074)
            {
                Hashtable hparams = new Hashtable();
                hparams.Add("@Empresa_ID", this.Padre.Contrato.Empresa_ID);
                DataSet ds = DB.QueryDS("usp_Empresa_FechaFinAuto", hparams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 &&
                    Convert.ToInt32(ds.Tables[0].Rows[0]["FechaFinAuto"].ToString()) == 1)
                {
                    this.diasDevengarTextBox.Visible = true;
                    this.lblDiasRenta.Visible = true;
                    this.FechaFinalDateTimePicker.Enabled = false;
                }
            }
        }

        private bool CalcularFechaFinal()
        {
            int diasDev = 0;

            try
            {

                if (FechaInicialDataTimePicker.Value != null && !string.IsNullOrEmpty(diasDevengarTextBox.Text) && Padre.Contrato.DiasDeCobro_ID > 0)
                {
                    if (int.TryParse(diasDevengarTextBox.Text, out diasDev) == false) return false;
                    DataTable dt = DB.Query(string.Format("select dbo.udf_Calcular_Fecha_Final_Contrato('{0}',{1},{2})", FechaInicialDataTimePicker.Value.ToString("yyyyMMdd"),
                        diasDev,
                        Padre.Contrato.DiasDeCobro_ID));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        FechaFinalDateTimePicker.Value = DateTime.Parse(dt.Rows[0][0].ToString());
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
            return false;
        }

        private bool ValidarYEjecutarFechaFinal()
        {
            if ((this.Padre.Contrato.Empresa_ID == 601 || this.Padre.Contrato.Empresa_ID == 2 || this.Padre.Contrato.Empresa_ID == 1074) && this.CalcularFechaFinal() == false)
            {
                AppHelper.Error("No se pudo calcular la fecha final");
                return false;
            }

            if (Padre.Summary.ContainsKey("Dias a devengar"))
            {
                Padre.Summary["Dias a devengar"] = this.diasDevengarTextBox.Text;
            }
            else
            {
                if (Padre.Contrato.Empresa_ID == 601 || Padre.Contrato.Empresa_ID == 2 || this.Padre.Contrato.Empresa_ID == 1074)
                {
                    Padre.Summary.Add("Dias a devengar", this.diasDevengarTextBox.Text);
                    Padre.Contrato.DiasRentasDevengar = int.Parse(this.diasDevengarTextBox.Text);
                }
                else
                {
                    Padre.Contrato.DiasRentasDevengar = null;
                }
            }

            return true;
        }

        private void diasDevengarTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                ValidarYEjecutarFechaFinal();
            }
        }

        private void diasDevengarTextBox_Leave(object sender, EventArgs e)
        {
            ValidarYEjecutarFechaFinal();
        }



    } // end class

} // end namespace
