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

			this.diasDevengarTextBox.Text = string.Empty;
			this.FechaInicialDataTimePicker.Value = DB.GetDate().AddDays(1).Date;

			Select_PlanDeRenta();

			this.MostrarDiasDevengar();

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
			Padre.Contrato.Comentarios = ComentariosTextBox.Text;

			if (Padre.Contrato.FechaInicial <= DateTime.Today)
			{
				throw new Exception("La fecha inicial debe ser mayor al día de hoy");
			}

			//if(CobroPermanenteCheckBox.Checked)
			//{
			//    Padre.Contrato.FechaFinal = null;                
			//}
			//else
			//{
			Padre.Contrato.FechaFinal = FechaFinalDateTimePicker.Value.Date;
			//}

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

			this.CalcularFechaFinal();
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

				//Se valida y calcula la fecha final
				if (ValidarYEjecutarFechaFinal() == false) return;

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

		private void diasDevengarTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
			{

				ValidarYEjecutarFechaFinal();
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

		private void diasDevengarTextBox_Leave(object sender, EventArgs e)
		{
			ValidarYEjecutarFechaFinal();
		}

		private void FechaInicialDataTimePicker_ValueChanged(object sender, EventArgs e)
		{
			CalcularFechaFinal();
		}

	} // end class

} // end namespace
