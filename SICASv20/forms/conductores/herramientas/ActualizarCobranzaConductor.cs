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
    /// Formulario para actualizar los datos de cobranza de un conductor
    /// </summary>
    public partial class ActualizarCobranzaConductor : Form
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de datos de cobranza
        /// de un conductor
        /// </summary>
        public ActualizarCobranzaConductor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios
        /// para actualizar los datos de cobranza
        /// de un conductor
        /// </summary>
        class ActualizarCobranzaConductor_Model
        {
            /// <summary>
            /// El ID del conductor a actualiar
            /// </summary>
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }
            private int _Conductor_ID;

            /// <summary>
            /// La entidad Conductor a actualizar
            /// </summary>
            public Entities.Conductores Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }
            private Entities.Conductores _Conductor;

            /// <summary>
            /// El historial del conductor a ingresar por motivo de la actualización
            /// </summary>
            public Entities.HistorialCobranzaConductores Historial
            {
                get { return _Historial; }
                set { _Historial = value; }
            }
            private Entities.HistorialCobranzaConductores _Historial;

            /// <summary>
            /// Los comentarios de la actualización
            /// </summary>
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }
            private string _Comentarios;

            /// <summary>
            /// Consulta al conductor en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.Conductor = Entities.Conductores.Read(this.Conductor_ID);
            }

            /// <summary>
            /// Actualiza los datos de cobranza del conductor
            /// y registra el historial de cobranza
            /// </summary>
            public void Guardar()
            {
                //  Actualiza los datos del conductor
                bool validaCURP = false;
                this.Conductor.Update(validaCURP);

                //  Si hay comentarios, registra el historial
                if (!string.IsNullOrEmpty(this.Comentarios))
                {
                    this.Historial = new Entities.HistorialCobranzaConductores();
                    this.Historial.Accion = "CAPTURA DE COMENTARIO";
                    this.Historial.Comentario = this.Comentarios;
                    this.Historial.Conductor_ID = this.Conductor_ID;
                    this.Historial.Estacion_ID = this.Conductor.Estacion_ID;
                    this.Historial.Fecha = DB.GetDate();
                    this.Historial.Usuario_ID = Sesion.Usuario_ID;
                    this.Historial.Create();

                } // end if

            } // end void Guardar

        } // end class Model

        /// <summary>
        /// El modelo de lógica de negocios de la forma
        /// </summary>
        private ActualizarCobranzaConductor_Model Model;

        /// <summary>
        /// Configura un conductor para actualizar sus datos de cobranza,
        /// a partir de su ID
        /// </summary>
        /// <param name="conductor_id"></param>
        public void Set_Conductor(int conductor_id)
        {
            //  Si el modelo es nulo, lo instanciamos
            if (this.Model == null)
            {
                this.Model = new ActualizarCobranzaConductor_Model();
            }

            //  Actualizamos los datos del modelo
            this.Model.Conductor_ID = conductor_id;

            //  Consultamos la información
            this.Model.Consultar();

            //  Ligamos el resultado a los controles
            this.conductoresBindingSource.DataSource = this.Model.Conductor;
        }

        /// <summary>
        /// Al hacer clic en "Actualizar", guardamos los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Actualizamos el modelo a partir de los controles
                    this.Model.Conductor.SaldoATratar = DB.GetNullableDecimal(saldoATratarTextBox.Text);
                    this.Model.Conductor.Cronocasco = Convert.ToBoolean(cronocascoCheckBox.Checked);
                    this.Model.Conductor.TerminalDatos = Convert.ToBoolean(terminalDatosCheckBox.Checked);
                    this.Model.Conductor.BloquearConductor = Convert.ToBoolean(bloquearConductorCheckBox.Checked);
                    this.Model.Conductor.MensajeACaja = mensajeACajaTextBox.Text;
                    this.Model.Comentarios = this.ComentariosTextBox.Text;

                    //  Guardamos los registros
                    Model.Guardar();

                    //  Informamos al usuario
                    AppHelper.Info("Conductor actualizado");

                    //  Devolvemos OK
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    //  Cerramos la forma
                    this.Close();
                },
                this
            );
        }
        
    } // end class

} // end namespace
