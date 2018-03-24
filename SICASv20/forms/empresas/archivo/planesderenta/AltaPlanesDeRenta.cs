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
    /// Formulario para el alta de planes de renta
    /// </summary>
    public partial class AltaPlanesDeRenta : baseForm
    {
        public AltaPlanesDeRenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            ModelosUnidadesBindingSource.DataSource = Entities.ModelosUnidades.Read();
         //   UsuariosBindingSource.DataSource = Entities.Usuarios.Read();
            DiasDeCobrosBindingSource.DataSource = Entities.DiasDeCobros.Read();
            estacionesBindingSource.DataSource = Sesion.Estaciones;
            PlanesDeRentaBindingSource.AddNew();
            AppHelper.SetContainerDBValidations(this, "PlanesDeRenta");
            base.BindData();
        }

        /// <summary>
        /// Limpia la forma
        /// </summary>
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            PlanesDeRentaBindingSource.AddNew();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            Entities.PlanesDeRenta planesderenta = (Entities.PlanesDeRenta)PlanesDeRentaBindingSource.Current;
            planesderenta.Activo = true;
            planesderenta.Referencia_ID = null;
            planesderenta.Fecha = DB.GetDate();
            planesderenta.Usuario_ID = Sesion.Usuario_ID;
            planesderenta.Descripcion = planesderenta.RentaBase.ToString("N2") + " | " + DiasDeCobro_IDComboBox.Text + " | " + ModeloUnidad_IDComboBox.Text;
            planesderenta.Create();
            DoClear();
            AppHelper.Info("¡Planes de Renta ingresado!");
        }

        /// <summary>
        /// Manda guardar los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
