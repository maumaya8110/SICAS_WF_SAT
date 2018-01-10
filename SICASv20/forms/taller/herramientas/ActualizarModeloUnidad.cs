using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizarModeloUnidad : Form
    {
        #region Constructor
        public ActualizarModeloUnidad()
        {
            InitializeComponent();
            Model = new ActualizarModeloUnidad_Model();
            AppHelper.SetStylish(this);
        }
        #endregion

        #region Model
        class ActualizarModeloUnidad_Model
        {
            private Entities.DatosUnidadTaller _DatosUnidad;
            public Entities.DatosUnidadTaller DatosUnidad
            {
                get { return _DatosUnidad; }
                set { _DatosUnidad = value; }
            }

            private List<Entities.Modelos> _Modelos;
            public List<Entities.Modelos> Modelos
            {
                get { return _Modelos; }
                set { _Modelos = value; }
            }

            private int _Modelo_ID;
            public int Modelo_ID
            {
                get { return _Modelo_ID; }
                set { _Modelo_ID = value; }
            }

            public void ConsultarModelos()
            {
                this.Modelos = Entities.Modelos.Read();
            }

            public void ActualizarModelo()
            {
                Entities.ModelosUnidades modelounidad =
                    Entities.ModelosUnidades.Read(this.DatosUnidad.ModeloUnidad_ID.Value);

                modelounidad.Modelo_ID = this.Modelo_ID;
                modelounidad.Update();
            }
        }
        #endregion

        #region Properties
        private ActualizarModeloUnidad_Model Model;
        #endregion

        #region Methods

        public void Set_DatosUnidad(Entities.DatosUnidadTaller datosunidad)
        {
            this.Model.DatosUnidad = datosunidad;
            this.Model.ConsultarModelos();
            this.modelosBindingSource.DataSource = this.Model.Modelos;
            this.datosUnidadTallerBindingSource.DataSource = this.Model.DatosUnidad;
        }

        #endregion

        #region Events

        private void ModeloComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate 
                {
                    this.Model.Modelo_ID = Convert.ToInt32(this.ModeloComboBox.SelectedValue);
                }
            );
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.ActualizarModelo();
                    AppHelper.Info("Modelo de unidad actualizado");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                },
                this
            );
        }
        
        #endregion
    }
}
