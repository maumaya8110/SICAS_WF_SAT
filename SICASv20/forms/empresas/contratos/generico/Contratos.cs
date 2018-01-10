/*
 * Contratos
 * 
 * Visualiza los contratos del sistema
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 * Se eliminó la consulta de estaciones
 * al elegir la empresa
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SICASv20.forms
{
	/// <summary>
	/// Muestra el listado de contratos
	/// </summary>
	public partial class Contratos : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia del formulario de contratos
		/// </summary>
		public Contratos()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			//  Carga las empresas
			selectEmpresasInternasBindingSource.DataSource = Sesion.Empresas;

			//  Carga las estaciones
			selectEstacionesBindingSource.DataSource = Sesion.Estaciones;

			base.BindData();
		}

		/// <summary>
		/// Devuelve un valor entero nulable
		/// </summary>
		/// <param name="expression">El valor a devolver</param>
		/// <param name="campo">La descripción del valor</param>
		/// <returns></returns>
		private int? GetNullInt32(object expression, string campo)
		{
			if (AppHelper.IsNumeric(expression))
			{
				return DB.GetNullableInt32(expression);
			}
			else
			{
				throw new Exception(string.Format("{0} debe ser numerico.", campo));
			}
		}

		/// <summary>
		/// Consulta los contratos en la base de datos y los muestra en pantalla
		/// </summary>
		private void DoQuery()
		{
			//  Las variables de búsqueda:
			//  Contrato, estacion, numeroeconomico, empresa y descripcion
			int? contrato_id = null, estacion_id = null, numeroeconomico = null, empresa_id = null;
			string descripcion = null;

			//  Obtenemos el valor del contrato
			if (!string.IsNullOrEmpty(Contrato_IDTextBox.Text))
			{
				if (!AppHelper.IsNumeric(Contrato_IDTextBox.Text))
				{
					throw new Exception("Contrato ID debe ser numérico");
				}

				contrato_id = Convert.ToInt32(Contrato_IDTextBox.Text);
			}

			//  Obtenemos el valor del numero economico
			if (!string.IsNullOrEmpty(NumeroEconomicoTextBox.Text))
			{
				if (!AppHelper.IsNumeric(NumeroEconomicoTextBox.Text))
				{
					throw new Exception("Numero Economico debe ser numérico");
				}

				numeroeconomico = Convert.ToInt32(NumeroEconomicoTextBox.Text);
			}

			//  Obtenemos el valor de la descripcion
			if (!string.IsNullOrEmpty(DescripcionTextBox.Text))
			{
				descripcion = DescripcionTextBox.Text;
			}

			//  Obtenemos el valor de la empresa
			if (EmpresasComboBox.SelectedItem != null)
			{
				empresa_id = GetNullInt32(EmpresasComboBox.SelectedValue, "Empresa");
			}
			//  Obtenemos el valor de la estacion
			if (EstacionesComboBox.SelectedItem != null)
			{
				estacion_id = GetNullInt32(EstacionesComboBox.SelectedValue, "Estacion");
			}

			//  Ligamos los contratos
			vista_ContratosBindingSource.DataSource =
			    Entities.Vista_Contratos.Get(contrato_id, empresa_id, estacion_id, descripcion, numeroeconomico);
		}

		/// <summary>
		/// Realiza la cancelación de un contrato
		/// </summary>
		/// <param name="contrato_id"></param>
		private void CancelarContrato(int contrato_id)
		{
			//  El motivo por el cual se cancela el contrato
			string motivo = "Motivo";

			//  Solicitamos el motivo de cancelación
			if (AppHelper.InputBox("Cancelación de contrato", "Escriba el motivo de cancelación", ref motivo) == DialogResult.OK)
			{
				//  Actualizamos la base de datos
				//  con la cancelación
				Hashtable m_params, w_params;
				m_params = new Hashtable(); w_params = new Hashtable();

				m_params["EstatusContrato_ID"] = 9;
				w_params["Contrato_ID"] = contrato_id;

				DB.UpdateRow("Contratos", m_params, w_params);
			}
		}

		/// <summary>
		/// Maneja el evento "Click" del botón "Buscar"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuscarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
		}

		/// <summary>
		/// Maneja el evento "CellContentClick" del control "Vista_ContratosDataGridView"
		/// </summary>
		/// <param name="sender">La celda seleccionada</param>
		/// <param name="e">Los argumentos del evento</param>
		private void vista_ContratosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				Entities.Vista_Contratos contrato =
						  (Entities.Vista_Contratos)vista_ContratosDataGridView.Rows[e.RowIndex].DataBoundItem;

				//  Si se hizo click en la columna "Actualizar"
				if (vista_ContratosDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
				{
					//  Mostramos la pantalla de actualización de contrato
					ActualizacionContrato ac = new ActualizacionContrato();
					ac.Contrato_ID = contrato.Contrato_ID;

					Padre.SwitchForma("ActualizacionContrato", ac);
				}

				//  Si se hizo click en la columna "Cancelar"
				if (vista_ContratosDataGridView.Columns[e.ColumnIndex].Name == "CancelColumn")
				{
					//Se verifica si hay adendums vigentes
					DataTable dt = SICASv20.Entities.Vista_ContratosAdendumDetalle.GetDataTable(contrato.Contrato_ID);

					//La query de la bd esta ordenado por la fecha de inicio en forma descendete, es decir, trae la fecha de inicio mas reciente
					DataRow[] drs = dt.Select(string.Format("FechaInicio <= '{0}' and FechaFin >= '{0}'", DateTime.Now.Date));

					//si hay adendums viegentes al dia de hoy
					if (dt != null && dt.Rows.Count > 0 && drs.Length > 0)
					{
						AppHelper.Error("El contrato tiene adendum vigentes, favor de finalizarlo.");
						return;
					}

					//si tiene asignado equipo de gas
					if (Entities.Vista_EquipoGas.UnidadConEquipoGas(contrato.Contrato_ID))
					{
						AppHelper.Error(string.Format("El conductor {0} del contrato {1} tiene un Equipo de Gas asignado, para cancelar el contrato favor de dar de baja la asignación del equipo de gas.", contrato.Conductor, contrato.Contrato_ID));
						return;
					}

					//  Solicitamos confirmación
					if (AppHelper.Confirm("¿Realmente desea cancelar el contrato?") == System.Windows.Forms.DialogResult.Yes)
					{
						// Cancelar el contrato
						//Entities.Vista_Contratos contrato =
						//    (Entities.Vista_Contratos)vista_ContratosDataGridView.Rows[e.RowIndex].DataBoundItem;
						CancelarContrato(contrato.Contrato_ID);
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}
	} // end namespace
} // end class