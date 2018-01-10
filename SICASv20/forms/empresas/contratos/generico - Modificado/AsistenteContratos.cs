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
    /// Asistente para la creación de contratos
    /// </summary>
    public partial class AsistenteContratos : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del asistente de contratos
        /// </summary>
        public AsistenteContratos()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// El contrato a crear
        /// </summary>
        public Entities.Contratos Contrato = new Entities.Contratos();

        /// <summary>
        /// Listado de formularios que utiliza el asistente
        /// </summary>
        Dictionary<string, baseUserControl> UControls = new Dictionary<string, baseUserControl>();

        /// <summary>
        /// Resumen de datos del contrato
        /// </summary>
        public Dictionary<string, string> Summary = new Dictionary<string, string>();

        /// <summary>
        /// Formulario para datos del conductor
        /// </summary>
        public Contratos_DatosConductorUC datosConductorControl;

        /// <summary>
        /// Formulario para datos de fechas y de cuenta
        /// </summary>
        public Contratos_DatosCuentaFechasUC datosCuentaFechasControl;

        /// <summary>
        /// Formulario para datos de unidad
        /// </summary>
        public Contratos_DatosUnidad_UC datosUnidadControl;

        /// <summary>
        /// Formulario para el resumen del contrato
        /// </summary>
        public Contratos_ResumenUC resumenControl;

        /// <summary>
        /// Precarga los datos iniciales del contrato, para que
        /// se asignen y actualicen con facilidad
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
        /// Carga los formularios a utilizar dentro del asistente
        /// </summary>
        private void LoadUserControls()
        {
            //  Eliminamos los controles actuales
            UControls.Clear();
            InnerPanel.Controls.Clear();

            //  Configuramos el formulario de datos de conductor
            datosConductorControl = new Contratos_DatosConductorUC();
            datosConductorControl.Name = "DatosConductor";
            datosConductorControl.Padre = this;
            UControls.Add("DatosConductor", datosConductorControl);
            InnerPanel.Controls.Add(datosConductorControl);

            //  Configuramos el formulario de datos de cuenta y fechas
            datosCuentaFechasControl = new Contratos_DatosCuentaFechasUC();
            datosCuentaFechasControl.Name = "DatosCuentaFechas";
            datosCuentaFechasControl.Padre = this;
            UControls.Add("DatosCuentaFechas", datosCuentaFechasControl);
            InnerPanel.Controls.Add(datosCuentaFechasControl);

            //  Configuramos el formulario de datos de unidad
            datosUnidadControl = new Contratos_DatosUnidad_UC();
            datosUnidadControl.Name = "DatosUnidad";
            datosUnidadControl.Padre = this;
            UControls.Add("DatosUnidad", datosUnidadControl);
            InnerPanel.Controls.Add(datosUnidadControl);

            //  Configuramos el formulario de resumen
            resumenControl = new Contratos_ResumenUC();
            resumenControl.Name = "Resumen";
            resumenControl.Padre = this;
            UControls.Add("Resumen", resumenControl);
            InnerPanel.Controls.Add(resumenControl);
        }

        /// <summary>
        /// Cambia el formulario actual en el asistente al formulario especificado
        /// </summary>
        /// <param name="name">El formulario a mostrar</param>
        public void SwitchPanel(string name)
        {
            this.InnerPanel.Controls[name].BringToFront();
        }

        /// <summary>
        /// Liga los datos a los controles y prepara los datos a mostrar
        /// en el formulario
        /// </summary>
        public override void BindData()
        {
            //  Cargamos los formularios del asistente
            LoadUserControls();

            //  Precargamos los datos del resumen
            PreloadSummary();

            //  Cambiamos el formulario para mostrar los datos del conductor
            SwitchPanel("DatosConductor");

            base.BindData();
        }

        /// <summary>
        /// Ingresamos el contrato a la base de datos
        /// </summary>
        public void InsertarContrato()
        {
            //  Creamos el registro
            this.Contrato.Create();

            //  Volvemos a ligar los datos
            //  reiniciando el asistente
            BindData();

            //  Mostramos el mensaje de éxito
            AppHelper.Info("Contrato creado con éxito!");
        }

    } // end class

} // end namespace
