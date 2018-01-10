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
    /// Formulario para actualizar información de una caja en particular
    /// </summary>
    public partial class ActualizacionCajas : baseForm
    {
        public ActualizacionCajas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modela la lógica de negocios de cajas
        /// </summary>
        class ActualizacionCajas_Model
        {
            /// <summary>
            /// La caja a actualizar
            /// </summary>
            public Entities.Cajas Caja { get; set; }

            /// <summary>
            /// Listado de empresas disponibles
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas { get; set; }

            /// <summary>
            /// Listado de actualizaciones disponibles
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones { get; set; }

            /// <summary>
            /// Guarda los datos
            /// </summary>
            public void Guardar()
            {
                this.Caja.Update();
            }

            /// <summary>
            /// Consulta la base de datos y trae la caja
            /// </summary>
            /// <param name="caja_id"></param>
            public void Consultar(int caja_id)
            {
                this.Caja = Entities.Cajas.Read(caja_id);
                this.Empresas = Entities.SelectEmpresas.GetInternas();
                this.Estaciones = Entities.SelectEstaciones.GetAll(null);
            }
        }

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        private ActualizacionCajas_Model Model;

        /// <summary>
        /// El folio ID de la caja a modificar
        /// </summary>
        public int Caja_ID { get; set; }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instancia el modelo
            this.Model = new ActualizacionCajas_Model();

            //  Consula la caja
            this.Model.Consultar(this.Caja_ID);

            //   Liga los datos del modelo a los controles
            this.cajasBindingSource.DataSource = this.Model.Caja;
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;

            base.BindData();
        }

        /// <summary>
        /// Guarda los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Guardar();
                    AppHelper.Info("Caja actualizada");
                    Padre.SwitchForma("Cajas");
                },
                this
            );
        } // end class
    } // end class
} // end namespace
