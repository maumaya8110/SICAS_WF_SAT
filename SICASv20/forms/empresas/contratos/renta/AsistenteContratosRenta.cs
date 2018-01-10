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
	/// Formulario con asistente para dar de alta un nuevo contrato de renta
	/// </summary>
	public partial class AsistenteContratosRenta : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia de la clase <see cref="AsistenteContratosRenta"/>
		/// </summary>
		public AsistenteContratosRenta()
		{
			InitializeComponent();
		}

		/// <summary>
		/// La entidad <see cref="Contratos"/> a ingresar
		/// </summary>
		public Entities.Contratos Contrato = new Entities.Contratos();

		/// <summary>
		/// Los formularios del asistente
		/// </summary>
		Dictionary<string, baseUserControl> UControls = new Dictionary<string, baseUserControl>();

		/// <summary>
		/// El resumen de la operación de alta de contrato
		/// </summary>
		public Dictionary<string, string> Summary = new Dictionary<string, string>();

		/// <summary>
		/// El formulario de datos de conductor
		/// </summary>
		public Contratos_DatosConductorUCRenta datosConductorControl;

		/// <summary>
		/// El formulario de datos de cuenta del conductor
		/// </summary>
		public Contratos_DatosCuentaFechasUCRenta datosCuentaFechasControl;

		/// <summary>
		/// El formulario de datos de unidad
		/// </summary>
		public Contratos_DatosUnidad_UCRenta datosUnidadControl;

		/// <summary>
		/// El fomrulario de resumen de control
		/// </summary>
		public Contratos_ResumenUCRenta resumenControl;

		/// <summary>
		/// Prepara los datos del resumen.
		/// </summary>
		private void PreloadSummary()
		{
			Summary.Clear();

			Summary.Add("Empresa", "");
			Summary.Add("Estacion", "");
			Summary.Add("Conductor", "");
			Summary.Add("Tipo de contrato", "");
			Summary.Add("Unidad", "");
			Summary.Add("Cuenta", "");
			Summary.Add("Concepto", "");
			Summary.Add("Fecha inicial", "");
			Summary.Add("Fecha final", "");
			Summary.Add("Cobro permanente", "");
			Summary.Add("Monto diario", "");
			Summary.Add("Dias de Cobro", "");
		}

		/// <summary>
		/// Carga los formularios del asistente
		/// </summary>
		private void LoadUserControls()
		{
			UControls.Clear();
			InnerPanel.Controls.Clear();

			datosConductorControl = new Contratos_DatosConductorUCRenta();
			datosConductorControl.Name = "DatosConductor";
			datosConductorControl.Padre = this;
			UControls.Add("DatosConductor", datosConductorControl);
			InnerPanel.Controls.Add(datosConductorControl);

			datosCuentaFechasControl = new Contratos_DatosCuentaFechasUCRenta();
			datosCuentaFechasControl.Name = "DatosCuentaFechas";
			datosCuentaFechasControl.Padre = this;
			UControls.Add("DatosCuentaFechas", datosCuentaFechasControl);
			InnerPanel.Controls.Add(datosCuentaFechasControl);

			datosUnidadControl = new Contratos_DatosUnidad_UCRenta();
			datosUnidadControl.Name = "DatosUnidad";
			datosUnidadControl.Padre = this;
			UControls.Add("DatosUnidad", datosUnidadControl);
			InnerPanel.Controls.Add(datosUnidadControl);

			resumenControl = new Contratos_ResumenUCRenta();
			resumenControl.Name = "Resumen";
			resumenControl.Padre = this;
			UControls.Add("Resumen", resumenControl);
			InnerPanel.Controls.Add(resumenControl);
		}

		/// <summary>
		/// Navega entre formularios en el asistente
		/// </summary>
		/// <param name="name"></param>
		public void SwitchPanel(string name)
		{
			this.InnerPanel.Controls[name].BringToFront();
		}

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			LoadUserControls();
			PreloadSummary();
			SwitchPanel("DatosConductor");

			base.BindData();
		}

		/// <summary>
		/// Registra el contrato en la base de datos
		/// </summary>
		public void InsertarContrato()
		{
			//GMD - 2017-01-23 Se agrega Validación para asegurar que empresa de unidad es la misma a donde se genera el contrato
			Entities.Unidades unidad = Entities.Unidades.Read((int)this.Contrato.Unidad_ID);
			if (unidad != null && unidad.Empresa_ID != this.Contrato.Empresa_ID)
			{
				throw new SICASException(string.Format("La empresa del contrato ({0}) no corresponde a la empresa donde está asignada la unidad ({1}), Favor de Verificar.", this.Contrato.Empresa_ID, unidad.Empresa_ID));
			}

			// Insertar contrato
			this.Contrato.Create();

			// Actualiza unidad
			DB.UpdateRow(
			    "Unidades",
			    DB.GetParams(
				   DB.Param("EstatusUnidad_ID", 2),
				   DB.Param("LocacionUnidad_ID", 3),
				   DB.Param("ConductorOperativo_ID", this.Contrato.Conductor_ID)
			    ),
			    DB.GetParams(
				   DB.Param("Unidad_ID", this.Contrato.Unidad_ID)
			    )
			);

			BindData();
			AppHelper.Info("Contrato creado con éxito!");
		}

	} // end class

} // end namespace
