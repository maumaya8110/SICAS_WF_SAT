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
    /// Formulario para cobrar ordenes de trabajo
    /// desde la caja
    /// </summary>
    public partial class CajaCobroOrdenesTrabajos : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario
        /// para cobrar ordenes de trabajo desde
        /// la caja
        /// </summary>
        public CajaCobroOrdenesTrabajos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clase que implementa la lógica de negocios
        /// para el cobro de ordenes de trabajos
        /// </summary>
        class CajaCobroOrdenesTrabajos_Model
        {
            /// <summary>
            /// El folio de la orden de trabajo
            /// </summary>
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }
            private int _OrdenTrabajo_ID;

            /// <summary>
            /// El código de barras de la órden de trabajo
            /// </summary>
            public string CodigoBarras
            {
                get { return _CodigoBarras; }
                set { _CodigoBarras = value; }
            }
            private string _CodigoBarras;

            /// <summary>
            /// El nombre del cliente de la orden de trabajo
            /// </summary>
            public string NombreCliente
            {
                get { return _NombreCliente; }
                set { _NombreCliente = value; }
            }
            private string _NombreCliente;

            /// <summary>
            /// El total a pagar de la orden
            /// </summary>
            public decimal TotalAPagar
            {
                get { return _TotalAPagar; }
                set { _TotalAPagar = value; }
            }
            private decimal _TotalAPagar;

            /// <summary>
            /// La cantidad con la que se paga
            /// </summary>
            public decimal Pagacon
            {
                get { return _Pagacon; }
                set { _Pagacon = value; }
            }
            private decimal _Pagacon;

            /// <summary>
            /// El cambio devuelto por la caja
            /// </summary>
            public decimal Cambio
            {
                get { return _Cambio; }
                set { _Cambio = value; }
            }
            private decimal _Cambio;

            /// <summary>
            /// La clase entidad de la orden de trabajo
            /// </summary>
            private Entities.OrdenesTrabajos OrdenTrabajo;

            /// <summary>
            /// La cuenta de Taller
            /// </summary>
            private const int CuentaTaller = 4;

            /// <summary>
            /// El concepto de Taller
            /// </summary>
            private const int ConceptoTaller = 4;

            /// <summary>
            /// La empresa de Taller
            /// </summary>
            private const int EmpresaTaller = 4;

            /// <summary>
            /// El estatus para las ordenes pagadas
            /// </summary>
            private const int EstatusOrdenTrabajoPagada = 4;

            /// <summary>
            /// Se asegura que la orden de trabajo sea valida
            /// </summary>
            private void ValidarOrdenTrabajo()
            {
                //  Verifica que exista o se haya capturado
                if (this.OrdenTrabajo == null)
                {
                    AppHelper.ThrowException("La orden de trabajo {0} no existe", this.OrdenTrabajo_ID);
                }

                //  Verifica que no haya sido pagada
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 4 &&
                    this.OrdenTrabajo.Caja_ID != null &&
                    this.OrdenTrabajo.FechaPago != null)
                {
                    AppHelper.ThrowException("La orden de trabajo {0} ya esta pagada", this.OrdenTrabajo_ID);
                }

                //  Verifica que no este cancelada
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 5)
                {
                    AppHelper.ThrowException("La orden de trabajo {0} esta cancelada", this.OrdenTrabajo_ID);
                }                
            }

            /// <summary>
            /// Establece los valores a partir de la entidad de orden de trabajo
            /// </summary>
            private void EstablecerValores()
            {
                this.CodigoBarras = this.OrdenTrabajo.CodigoBarras;
                this.OrdenTrabajo_ID = this.OrdenTrabajo.OrdenTrabajo_ID;
                this.NombreCliente = Entities.Empresas.Read(this.OrdenTrabajo.ClienteFacturar_ID).RazonSocial;
                this.TotalAPagar = OrdenTrabajo.Total;
            }

            /// <summary>
            /// Consulta una orden de trabajo por número de identificación
            /// o folio
            /// </summary>
            public void ConsultarOrdenTrabajo_ID()
            {
                this.OrdenTrabajo = Entities.OrdenesTrabajos.Read(this.OrdenTrabajo_ID);
                ValidarOrdenTrabajo();
                EstablecerValores();
                CalcularSaldos();
            }

            /// <summary>
            /// Consulta una orden de trabajo por su código de barras
            /// </summary>
            public void ConsultarCodigoBarras()
            {
                this.OrdenTrabajo = Entities.OrdenesTrabajos.Read(DB.Param("CodigoBarras", this.CodigoBarras));
                ValidarOrdenTrabajo();
                EstablecerValores();
                CalcularSaldos();
            }

            /// <summary>
            /// Realiza el proceso de pago de la orden de trabajo
            /// </summary>
            public void PagarOrdenTrabajo()
            {
                //  Validar
                if (this.TotalAPagar > this.Pagacon) AppHelper.ThrowException("La cantidad a pagar es mayor que el pago efectuado");

                //  Ingresar a cuenta de caja
                Entities.CuentaCajas cc = new Entities.CuentaCajas();
                cc.Abono = this.TotalAPagar;
                cc.Caja_ID = Sesion.Caja_ID.Value;
                cc.Cargo = 0;
                cc.Comentarios = "PAGO EN CAJA";
                cc.Concepto_ID = ConceptoTaller;
                cc.Cuenta_ID = CuentaTaller;                
                cc.Empresa_ID = EmpresaTaller;
                cc.Estacion_ID = Sesion.Estacion_ID.Value;
                cc.Fecha = DB.GetDate();
                cc.Saldo = 0;
                cc.Sesion_ID = Sesion.Sesion_ID;
                cc.Ticket_ID = null;
                cc.Usuario_ID = Sesion.Usuario_ID;
                cc.Create();

                //  Actualizar orden de trabajo
                this.OrdenTrabajo.EstatusOrdenTrabajo_ID = EstatusOrdenTrabajoPagada;
                this.OrdenTrabajo.Caja_ID = Sesion.Caja_ID;
                this.OrdenTrabajo.FechaPago = DB.GetDate();
                this.OrdenTrabajo.Update();                               
            }

            /// <summary>
            /// Calcula los saldos
            /// </summary>
            public void CalcularSaldos()
            {
                this.Cambio = this.Pagacon - this.TotalAPagar;
            }
            
        } // end class CajaCobroOrdenesTrabajos_Model

        /// <summary>
        /// El objeto de modelo de caja de cobro de ordenes
        /// de trabajo
        /// </summary>
        CajaCobroOrdenesTrabajos_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            Model = new CajaCobroOrdenesTrabajos_Model();
            base.BindData();
        }

        /// <summary>
        /// Imprime el recibo de pago
        /// </summary>
        private void ImprimirRecibo()
        {
            PrintHelper printer = new PrintHelper();
            DateTime FechaHora = DB.GetDate();

            printer.PrintText("*******************************************");
            printer.PrintLine();
            printer.PrintText("Estacion:    {0}", Sesion.Estacion_ID.Value);
            printer.PrintText("Caja:    {0}", Sesion.Caja_ID.Value);
            printer.PrintText("Fecha:    {0:yyyy-MM-dd}", FechaHora);
            printer.PrintText("Hora:    {0:HH:mm:ss}", FechaHora);
            printer.PrintLine();
            printer.PrintText("---");
            printer.PrintLine();
            printer.PrintText("Orden de trabajo:    {0}", Model.OrdenTrabajo_ID);
            printer.PrintText("Codigo:    {0}", Model.CodigoBarras);
            printer.PrintText("Cliente:    {0}", Model.NombreCliente);
            printer.PrintText("Total:    {0:c}", Model.TotalAPagar);
            printer.PrintLine();
            printer.PrintText("---");
            printer.PrintLine();            
            printer.PrintText("Cajero(a):    {0}", Sesion.Usuario_ID);
            printer.PrintLine();
            printer.PrintText("*******************************************");
            printer.PrintLine();
            printer.PrintLine();

            printer.Print();
        }

        /// <summary>
        /// Limpia la forma
        /// </summary>
        private void Clear()
        {
            AppHelper.ClearControl(this);
            this.OrdenTrabajoIDTextBox.Focus();
        }

        /// <summary>
        /// Al hacer enter en la caja de texto "OrdenTrabajoID",
        /// realiza el pago de la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdenTrabajoIDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {

                    //  Asignamos el folio ID al modelo
                    Model.OrdenTrabajo_ID = Convert.ToInt32(this.OrdenTrabajoIDTextBox.Text);

                    //  Consultamos los datos
                    Model.ConsultarOrdenTrabajo_ID();

                    //  Actualizamos los controles
                    this.CodigoBarrasTextBox.Text = Model.CodigoBarras;
                    this.ClienteTextBox.Text = Model.NombreCliente;
                    this.TotalAPagarTextBox.Text = AppHelper.N2(Model.TotalAPagar);
                    this.PagaConTextBox.Text = Model.Pagacon.ToString();
                    this.CambioTextBox.Text = Model.Cambio.ToString();
                    this.PagaConTextBox.SelectAll();
                    this.PagaConTextBox.Focus();


                }, this);
            }
        }

        /// <summary>
        /// Al hacer enter en la caja de texto "Código de barras",
        /// realiza el pago de la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodigoBarrasTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {
                    //  Asignamos el código de barras al modelo
                    Model.CodigoBarras = CodigoBarrasTextBox.Text;

                    //  Consultamos la orden de trabajo
                    Model.ConsultarCodigoBarras();

                    //  Actualizamos los controles
                    this.CodigoBarrasTextBox.Text = Model.CodigoBarras;
                    this.ClienteTextBox.Text = Model.NombreCliente;
                    this.TotalAPagarTextBox.Text = AppHelper.N2(Model.TotalAPagar);
                    this.PagaConTextBox.Text = Model.Pagacon.ToString();
                    this.CambioTextBox.Text = Model.Cambio.ToString();
                    this.PagaConTextBox.SelectAll();
                    this.PagaConTextBox.Focus();

                }, this);
            }
        }

        /// <summary>
        /// Al oprimir "Aceptar", se manda pagar la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                Model.PagarOrdenTrabajo();
                //  Imprimir recibo
                ImprimirRecibo();                
                //  Clear
                Clear();
                //  Mensaje
                AppHelper.Info("Orden de trabajo cobrada exitosamente");

            }, this);
        }

        /// <summary>
        /// Al dar enter en "Paga Con", se manda pagar
        /// la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagaConTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate 
                {
                    Model.PagarOrdenTrabajo();
                    //  Imprimir recibo
                    ImprimirRecibo();                    
                    //  Clear
                    Clear();
                    //  Mensaje
                    AppHelper.Info("Orden de trabajo cobrada exitosamente");

                }, this);
            }
            else
            {
                AppHelper.Try(delegate
                {
                    Model.Pagacon = Convert.ToDecimal(PagaConTextBox.Text);
                    Model.CalcularSaldos();
                    CambioTextBox.Text = AppHelper.N2(Model.Cambio);
                });
            }
        }

    } // end class

} // end namespace
