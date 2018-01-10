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
    /// Formulario para actualizar planes de renta
    /// </summary>
    public partial class ActualizacionPlanesDeRenta : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para la actualización de planes de renta
        /// </summary>
        public ActualizacionPlanesDeRenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El ID del plan de renta a actualizar
        /// </summary>
        public Int32 PlanDeRenta_ID
        {
            get { return _PlanDeRenta_ID; }
            set { _PlanDeRenta_ID = value; }
        }
        private Int32 _PlanDeRenta_ID;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            ModelosUnidadesBindingSource.DataSource = Entities.ModelosUnidades.Read();
            UsuariosBindingSource.DataSource = Entities.Usuarios.Read();
            DiasDeCobrosBindingSource.DataSource = Entities.DiasDeCobros.Read();
            PlanesDeRentaBindingSource.DataSource = Entities.PlanesDeRenta.Read(this.PlanDeRenta_ID);
            estacionesBindingSource.DataSource = Sesion.Estaciones;
            base.BindData();
        }

        /// <summary>
        /// Regresa al formulario de listado de planes de renta
        /// </summary>
        private void DoBackToList()
        {
            forms.PlanesDeRenta PlanesDeRentaLower = new forms.PlanesDeRenta();
            Padre.SwitchForma("PlanesDeRenta", PlanesDeRentaLower);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            Entities.PlanesDeRenta planesderenta = (Entities.PlanesDeRenta)PlanesDeRentaBindingSource.Current;
            planesderenta.Descripcion = planesderenta.RentaBase.ToString("N2") + " | " + DiasDeCobro_IDComboBox.Text + " | " + ModeloUnidad_IDComboBox.Text;
            planesderenta.Update();
            DoBackToList();
            AppHelper.Info("¡Planes de Renta actualizado!");
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
