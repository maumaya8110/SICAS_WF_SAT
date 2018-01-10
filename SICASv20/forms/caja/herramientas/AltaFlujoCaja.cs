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
    /// Formulario que registra un movimiento de flujo de caja
    /// en la sesión de caja actual en el sistema
    /// </summary>
    public partial class AltaFlujoCaja : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de AltaFlujoCaja
        /// </summary>
        public AltaFlujoCaja()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Representa el modelo de lógica de negocios
        /// de la operación  AltaFlujoCaja
        /// </summary>
        class AltaFlujoCaja_Model : Entities.CuentaFlujoCajas
        {
            /// <summary>
            /// Crea una instancia del modelo de negocios AltaFlujoCaja_Model
            /// a partir de una sesión
            /// </summary>
            /// <param name="sesion"></param>
            public AltaFlujoCaja_Model(Entities.Sesiones sesion)
            {
                this.Sesion = sesion;
                this.Caja_ID = this.Sesion.Caja_ID.Value;
                this.Sesion_ID = this.Sesion.Sesion_ID;
                this.Ticket_ID = null;
                this.Usuario_ID = this.Sesion.Usuario_ID;
            }

            /// <summary>
            /// La sesión actual de Caja
            /// </summary>
            public Entities.Sesiones Sesion
            {
                get { return _Sesion; }
                set { _Sesion = value; }
            }
            private Entities.Sesiones _Sesion;

            /// <summary>
            /// La lista de saldos de caja actuales
            /// </summary>
            public List<Entities.Vista_SaldosFlujoCajaSesion> Saldos
            {
                get { return _Saldos; }
                set { _Saldos = value; }
            }
            private List<Entities.Vista_SaldosFlujoCajaSesion> _Saldos;

            /// <summary>
            /// La lista de Monedas disponibles en el sistema
            /// </summary>
            public List<Entities.Monedas> Monedas
            {
                get { return _Monedas; }
                set { _Monedas = value; }
            }
            private List<Entities.Monedas> _Monedas;

            /// <summary>
            /// Consulta los saldos de caja actuales en la base de datos
            /// </summary>
            public void ConsultarSaldos()
            {
                this.Saldos = Entities.Vista_SaldosFlujoCajaSesion.Get(this.Sesion.Sesion_ID);
            }

            /// <summary>
            /// Consulta el listado de monedas en la base de datos
            /// </summary>
            public void ConsultarMonedas()
            {
                this.Monedas = Entities.Monedas.Read();
            }

            /// <summary>
            /// Contiene el listado de conceptos utilizados en la operación
            /// </summary>
            public List<string> Conceptos
            {
                get { return _Conceptos; }
                set { _Conceptos = value; }
            }
            private List<string> _Conceptos;

            /// <summary>
            /// Configura los conceptos a utilizar en el listado de conceptos
            /// </summary>
            public void ConsultarConceptos()
            {
                if (this.Conceptos == null)
                    this.Conceptos = new List<string>();

                this.Conceptos.Add("FONDO DE CAJA");
                this.Conceptos.Add("DEPOSITO");
                this.Conceptos.Add("RETIRO");
            }

            /// <summary>
            /// Realiza las validaciones necesarias para verificar
            /// que el registro este correcto
            /// </summary>
            public void Validar()
            {
                //  Verificar el tipo de movimiento
                if (this.Cargo > 0 && this.Abono > 0)
                {
                    AppHelper.ThrowException("Solamente puede efectuar un abono o un cargo, no ambos movimientos");
                }

                //  Si es un cargo, es decir, un retiro
                //  verificamos si la caja tiene el saldo suficiente
                //  de la moneda correspondiente
                //  para realizar el retiro
                if (this.Cargo > 0)
                {
                    if (this.Cargo > this.GetSaldo())
                    {
                        AppHelper.ThrowException("No se puede efectuar la operación, no se permiten saldos negativos");
                    }
                }
            }

            /// <summary>
            /// Consulta la base de datos para obtener el saldo de caja
            /// de la moneda actual en la sesión actual
            /// </summary>
            /// <returns></returns>
            private decimal GetSaldo()
            {
                string sql = "SELECT SUM(Abono - Cargo) FROM CuentaFlujoCajas WHERE Sesion_ID = @Sesion_ID AND Moneda_ID = @Moneda_ID";
                
                return Convert.ToDecimal(
                    DB.QueryScalar(
                        sql, 
                        DB.GetParams(
                            DB.Param("@Sesion_ID", this.Sesion_ID), 
                            DB.Param("@Moneda_ID", this.Moneda_ID)
                        )
                    )
                );
            }

            /// <summary>
            /// Guarda el registro en la base de datos
            /// </summary>
            public void Guardar()
            {
                //  Valida el registro
                this.Validar();
                //  Realiza la inserción
                this.Create();
            }
        }

        /// <summary>
        /// Instancia del modelo de lógica de negocios del formulario
        /// </summary>
        private AltaFlujoCaja_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new AltaFlujoCaja_Model(Sesion.GetSesion());

            //  Realizamos las consultas de los datos base
            //  saldos, conceptos y monedas
            this.Model.ConsultarSaldos();
            this.Model.ConsultarConceptos();
            this.Model.ConsultarMonedas(); 
           
            //  Ligamos los datos a los controles
            this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = this.Model.Saldos;
            this.monedasBindingSource.DataSource = this.Model.Monedas;
            this.ConceptosComboBox.DataSource = this.Model.Conceptos;

            SetDefaults();

            base.BindData();
        }

        /// <summary>
        /// Configura los valores por defecto de Moneda y Concepto
        /// </summary>
        private void SetDefaults()
        {
            this.Model.Moneda_ID =
                        ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Moneda_ID;
            this.Model.Concepto =
                        this.ConceptosComboBox.SelectedValue.ToString();
        }

        /// <summary>
        /// Realiza la impresión del registro
        /// </summary>
        private void Imprimir()
        {
            PrintHelper printer = new PrintHelper();

            printer.PrintText("TICKET DE MOVIMIENTO DE FLUJO DE CAJA");
            printer.PrintCLRF();
            printer.PrintText("FOLIO:       {0}", Model.CuentaFlujoCaja_ID);
            printer.PrintText("FECHA:       {0}", DB.GetDate());
            printer.PrintText("MONEDA:      {0}", ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Nombre);
            printer.PrintText("CONCEPTO:    {0}", this.Model.Concepto);
            printer.PrintText("MONTO:       {0:N2}", (Model.Cargo > 0) ? Model.Cargo : Model.Abono);
            printer.PrintText("SALDO:       {0:N2}", Model.Saldo);
            printer.PrintCLRF();
            printer.PrintCLRF();
            printer.PrintLine();
            printer.Print();
        }

        /// <summary>
        /// Actualiza el dato de Moneda_ID en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonedasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Moneda_ID = 
                        ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Moneda_ID;
                }
            );
        }

        /// <summary>
        /// Actualiza el dato de Concepto en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConceptosComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Concepto = 
                        this.ConceptosComboBox.SelectedValue.ToString();
                }
            );
        }

        /// <summary>
        /// Actualiza el dato de "Cargo" en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Cargo = this.CargoNumericUpDown.Value;
                }
            );
        }

        /// <summary>
        /// Actualiza el dato de "Abono" en el concepto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbonoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Abono = this.AbonoNumericUpDown.Value;
                }
            );
        }

        /// <summary>
        /// Manda guardar los datos en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(
                delegate
                {
                    //  Actualizamos la fecha
                    this.Model.Fecha = DB.GetDate();
                    //  Registramos el dato en la base de datos
                    this.Model.Guardar();                    
                },
                this
            );

            //  Mandámos a imprimir, separadamente
            //  por si hay un error de impresión
            //  no realice un "Rollback" a la transacción
            AppHelper.DoMethod(
                delegate
                {
                    //  Mandamos a imprimir 
                    Imprimir();

                    //  Actualizamos los saldos
                    this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = null;
                    this.Model.ConsultarSaldos();
                    this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = this.Model.Saldos;

                    //  Limpiamos la forma
                    AppHelper.ClearControl(this);

                    //  Establecemos los valores por defecto
                    SetDefaults();                    

                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Movimiento Realizado");
                },
                this
            );
        }
    } // end class
} // end namespace
