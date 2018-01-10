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
    /// Formulario que muestra la información de las rentas cobradas,
    /// así como información relevante a la cobranza y recaudación
    /// </summary>
    public partial class RentasCobradasDiarias : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de rentas
        /// cobradas diarias
        /// </summary>
        public RentasCobradasDiarias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// La clase que modela la lógica de negocios
        /// del reporte de rentas cobradas diarias
        /// </summary>
        class RentasCobradasDiarias_Model
        {
            /// <summary>
            /// La fecha actual
            /// </summary>
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }
            private DateTime _Fecha;

            /// <summary>
            /// La cantidad de cobros efectuados
            /// </summary>
            public int CantidadRentas
            {
                get { return _CantidadRentas; }
                set { _CantidadRentas = value; }
            }
            private int _CantidadRentas;

            /// <summary>
            /// El total cobrado
            /// </summary>
            public decimal MontoRentas
            {
                get { return _MontoRentas; }
                set { _MontoRentas = value; }
            }
            private decimal _MontoRentas;

            /// <summary>
            /// La estación actual
            /// </summary>
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }
            private int _Estacion_ID;

            /// <summary>
            /// El listado de cobros efectuados
            /// </summary>
            public List<Entities.Vista_CuentaConductores> CuentaConductores
            {
                get { return _CuentaConductores; }
                set { _CuentaConductores = value; }
            }
            private List<Entities.Vista_CuentaConductores> _CuentaConductores;

            /// <summary>
            /// Consulta los cobros efectuados en el sistema
            /// </summary>
            public void Consultar()
            {
                //  Actualiza la los parámetros
                this.Fecha = DB.GetDate().Date;

                //  Consulta la información
                this.CuentaConductores = Entities.Vista_CuentaConductores.Get(this.Estacion_ID, this.Fecha);

                //  Actualiza los totales
                this.CantidadRentas = this.CuentaConductores.Count;

                this.MontoRentas = 0;

                foreach (Entities.Vista_CuentaConductores cc in this.CuentaConductores)
                {
                    this.MontoRentas += cc.Cargo.Value;
                }

                this.MontoRentas = Math.Abs(this.MontoRentas);
            } // end void
        } // end class model

        /// <summary>
        /// La variable que representa el modelo de la lógica de negocios
        /// </summary>
        private RentasCobradasDiarias_Model Model;
        
        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new RentasCobradasDiarias_Model();

            //  Verificamos que la estación esté configurada
            if (Sesion.Estacion_ID == null)
            {
                AppHelper.ThrowException("Debe tener configurada una sola estación para visualizar esta opción");
            }

            //  Actualizamos la estación
            this.Model.Estacion_ID = Sesion.Estacion_ID.Value;

            //  Consultamos los datos
            this.Model.Consultar();

            //  Actualizamos los controles
            this.FechaTextBox.Text = string.Format("{0:yyyy-MM-dd}", this.Model.Fecha);
            this.RentasTextBox.Text = string.Format("{0:N0}", this.Model.CantidadRentas);
            this.MontoTextBox.Text = string.Format("{0:C}", this.Model.MontoRentas);
            this.vista_CuentaConductoresBindingSource.DataSource = this.Model.CuentaConductores;

            //  Variable que contendrá un mensaje a mostrar al usuario
            string Mensaje = null;

            //  Si las rentas NO han sido cobranas
            if (this.Model.CantidadRentas == 0)
            {
                //  Informamos al usuario
                Mensaje = string.Format("No se cargaron rentas en la fecha {0:yyyy-MM-dd}.", this.Model.Fecha);
                this.MensajeLabel.Text = Mensaje;
                this.MensajeLabel.ForeColor = Color.Red;
            }
            else // Si han sido cobradas
            {
                //  El mensaje es de éxito
                Mensaje = string.Format("Las rentas del día {0:yyyy-MM-dd} fueron cargadas exitosamente.", this.Model.Fecha);
                this.MensajeLabel.Text = Mensaje;
                this.MensajeLabel.ForeColor = Color.Green;
            }
            
            base.BindData();
        }
    } // end class form
} // end namespace
