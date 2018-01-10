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
    /// Formulario para dar de alta una caja
    /// </summary>
    public partial class AltaCajas : baseForm
    {
        /// <summary>
        /// Crea una instancia del formulario para dar de alta una caja
        /// </summary>
        public AltaCajas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modela la lógica de negocios del alta de cajas
        /// </summary>
        class AltaCajas_Model
        {
            /// <summary>
            /// La caja a dar de alta
            /// </summary>
            public Entities.Cajas Caja { get; set; }

            /// <summary>
            /// La empresas disponibles
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas { get; set; }

            /// <summary>
            /// Las estaciones disponibles
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones { get; set; }

            /// <summary>
            /// Guarda los datos en la base de datos
            /// </summary>
            public void Guardar()
            {
                this.Caja.Activa = true;
                this.Caja.Create();
            }

            /// <summary>
            /// Consulta las empresas y las estaciones
            /// </summary>
            public void Consultar()
            {
                this.Empresas = Entities.SelectEmpresas.GetInternas();
                this.Estaciones = Entities.SelectEstaciones.GetAll(null);
            }
        }

        /// <summary>
        /// La variable del modelo de lógica de negocios
        /// </summary>
        private AltaCajas_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            Model = new AltaCajas_Model();
            
            //  Consultamos los datos del modelo
            this.Model.Consultar();

            //  Ligamos los datos a los controles
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;
            
            //  Preparamos la inserción de datos
            this.cajasBindingSource.AddNew();

            base.BindData();
        }

        /// <summary>
        /// Guarda los cambios e informa al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Actualizamos la caja en el modelo
                    this.Model.Caja = (Entities.Cajas)this.cajasBindingSource.Current;

                    //  Guardamos los datos
                    this.Model.Guardar();

                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Caja ingresada");

                    //  Navegamos al formulario de cajas
                    Padre.SwitchForma("Cajas");
                },
                this
            );
        } // end class
    } // end class
} // end namespace
