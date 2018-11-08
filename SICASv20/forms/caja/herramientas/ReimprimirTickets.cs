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
    /// Formulario utilizado por las cajas para reimprimir tickets
    /// </summary>
    public partial class ReimprimirTickets : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario ReimprimirTickets
        /// </summary>
        public ReimprimirTickets()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de la lógica de negocios para la operación
        /// de reimpresión de tickets
        /// </summary>
        class ReimprimirTickets_Model
        {
            /// <summary>
            /// Crea una nueva instancia del modelo de reimpresión de tickets
            /// </summary>
            public ReimprimirTickets_Model()
            { 
            }

            /// <summary>
            /// Crea una nueva instancia del modelo de reimpresión de tickets
            /// a partir de un identificador de sesión de caja
            /// </summary>
            /// <param name="sesion_id"></param>
            public ReimprimirTickets_Model(int sesion_id)
            {
                this.Sesion_ID = sesion_id;
            }

            /// <summary>
            /// El identificador de Ticket a reimprimir
            /// </summary>
            public int Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }
            private int _Ticket_ID;

            /// <summary>
            /// El identificador de la sesión actual de caja
            /// </summary>
            public int Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }
            private int _Sesion_ID;

            /// <summary>
            /// La entidad Ticket a reimprimir
            /// </summary>
            private Entities.Tickets Ticket;

            /// <summary>
            /// Valida el ticket a reimprimir
            /// </summary>
            private void ValidarTicket()
            {
                //  Validamos que exista el ticket
                if (Ticket == null)
                {
                    AppHelper.ThrowException("El ticket {0} no existe", this.Ticket_ID);
                }

                //  Verificamos que pertenezca a la sesión
                //  de esta manera, solo los tickets emitidos por la caja
                //  pueden ser reimpresos
                //if (Ticket.Sesion_ID != this.Sesion_ID)
                //{
                //    AppHelper.ThrowException("El ticket {0} no pertenece a esta sesión {1}", this.Ticket_ID, this.Sesion_ID);
                //}
            }

            /// <summary>
            /// Consulta los datos del ticket a reimprimir
            /// </summary>
            public void ConsultarTicket()
            {
                //  Obtenemos los datos de la base de datos
                Ticket = Entities.Tickets.Read(this.Ticket_ID);

                //  Los validamos
                ValidarTicket();                
            }
        }

        /// <summary>
        /// El modelo de lógica de negocios a utilizar en el formulario
        /// </summary>
        private ReimprimirTickets_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo, a partir de la sesión actual
            Model = new ReimprimirTickets_Model(Sesion.Sesion_ID);
            base.BindData();
        }

        /// <summary>
        /// Reimprime el ticket consultado
        /// </summary>
        private void ReimprimirTicket()
        {
            //  Variable que nos indica si hemos enviado datos
            //  a imprimir, para incluir el pie de página
            bool HayImpresion = false;

            //  Instanciamos un nuevo ayudante de impresión
            PrintHelper printer = new PrintHelper();

            //  Obtenemos los datos dle ticket
            List<Entities.Get_DatosTicket> ticketdata = Entities.Get_DatosTicket.Get(this.Model.Ticket_ID);


            ////////////////////////////////

            //  Preparamos una tabla de datos para contener los movimientos
            DataTable dtable = new DataTable();
            dtable.Columns.Add("CIUD", typeof(System.String));
            dtable.Columns.Add("M", typeof(System.Decimal));
            dtable.Columns.Add("S", typeof(System.Decimal));

            Entities.Get_DatosTicket data = ticketdata[0];

            //  Si el ticket tiene información
            if (ticketdata.Count > 0)
            {
                //  Obtenemos el primer registro
                //  para los datos de encabezado
                //Entities.Get_DatosTicket data = ticketdata[0];

                //  Recorremos los registros
                foreach (Entities.Get_DatosTicket mov in ticketdata)
                {
                    //  Agregamos los registros a la tabla
                    dtable.Rows.Add(mov.Cuenta, mov.Abono, mov.Saldo);
                }

                //  Imprimimos los datos de encabezado
                //printer.PrintText(string.Format("TID:   {0}     EID:    {1}", data.Ticket_ID, data.Empresa_ID));
                //printer.PrintText(string.Format("CID:   {0}     ESTID:    {1}", data.Conductor_ID, data.Estacion_ID));
                //printer.PrintText(string.Format("UID:   {0}     CAID:    {1}", data.Unidad_ID, data.Caja_ID));
                //printer.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", data.Fecha));

                printer.PrintText(string.Format("TID:   {0}     EID:    {1}", data.FolioT, data.Empresa_ID));
                printer.PrintText(string.Format("CID:   {0}     ESTID:    {1}", data.Conductor_ID, data.Estacion_ID));
                printer.PrintText(string.Format("UID:   {0}     CAID:    {1}", data.Unidad_ID, data.Caja_ID));
                printer.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", data.Fecha));

                printer.PrintCLRF();

                if (chkUnidad.Checked == true)
                {
                    printer.PrintText(string.Format("U: {0}", data.NumeroEconomico));
                }
                

                if (chkNombre.Checked==true) 
                {
                  //  printer.PrintText(data.Conductor.Replace(data.NumeroEconomico.ToString(), "").Replace("(", "").Replace(")", ""));

                  //  printer.PrintText(string.Format("U: {0}", data.NumeroEconomico));
                    printer.PrintText(string.Format("RS: {0}", data.RazonSocial));
                    printer.PrintText(string.Format("RFC: {0}", data.RFC));
                    printer.PrintText(string.Format("CI: {0}", data.Ticket_ID));

                }
                
                
                
                printer.PrintCLRF();

                //  Imprimirmos la tabla
                printer.PrintTable(dtable);

                //  Configuramos la variable que indica si imprimimos datos
                HayImpresion = true;
            }
            
            //  Si hay datos enviado a imprimir
            if (HayImpresion)
            {
                //  Imprimimos el pie de página
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintText("-------------------------------");
                printer.PrintText("F CA");
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintText("-------------------------------");
                printer.PrintText("F CO");
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintLine();
                printer.PrintText("================================");


                printer.PrintText("=======SECCION PARA CONDUCTOR=========");

                printer.PrintCLRF();
                printer.PrintText(string.Format("TID:   {0}     EID:    {1}", data.FolioT, data.Empresa_ID));

                //printer.PrintText(string.Format("CID:   {0}     ESTID:    {1}", data.Conductor_ID, data.Estacion_ID));
                printer.PrintText(string.Format("UID:   {0}     CAID:    {1}", data.Unidad_ID, data.Caja_ID));
                printer.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", data.Fecha));

                printer.PrintCLRF();


                printer.PrintText(string.Format("U: {0}", data.NumeroEconomico));

                printer.PrintText(string.Format("C: {0}", data.Conductor));
                printer.PrintText(string.Format("CI: {0}", data.Ticket_ID));


                printer.PrintTable(dtable);

                printer.PrintCLRF();
                printer.PrintText("================================");
                printer.PrintText("================================");
                //printer.PrintLine();
                printer.Print();
            }
            ////////////////////////////////
        }   // end ReimprimirTicket  

        /// <summary>
        /// Realiza la consulta del ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicketIDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //  Si oprimirmos enter
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {
                    //  Actualizamos la variable de ticket en el modelo
                    Model.Ticket_ID = Convert.ToInt32(TicketIDTextBox.Text);

                    //  Consultamos los datos
                    Model.ConsultarTicket();

                    //  Reimprimimos el ticket
                    this.ReimprimirTicket();
                    
                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Ticket Reimpreso!");

                    //  Limpiamos la forma
                    AppHelper.ClearControl(this);

                    //  Le damos el foco a la caja de texto de ticket
                    TicketIDTextBox.Focus();

                }, this);
            } // end if

        }

        private void TicketIDTextBox_TextChanged(object sender, EventArgs e)
        {

        } // end KeyUp

    } // end class

} // end namespace