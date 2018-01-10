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
    /// Formulario para la cancelación de tickets
    /// </summary>
    public partial class CancelacionTickets : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para cancelación de tickets
        /// </summary>
        public CancelacionTickets()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El estatus del ticket a cancelar
        /// </summary>
        private int EstatusTicket_ID;
        
        /// <summary>
        /// Valida los datos de entrada
        /// </summary>
        private void DoValidate()
        {
            //  Validar si hay datos en las cajas
            if (Ticket_IDTextBox.Text == "" || MotivoTextBox.Text == "")
            {
                throw new Exception("Debe capturar ticket y motivo.");
            }

            //  Si el ticket esta ya cancelado
            //  Impedir "Re-Cancelación"
            if (EstatusTicket_ID == 2)
            {
                throw new Exception("Ticket ya esta cancelado");
            }
        }

        /// <summary>
        /// Al hacer clic en "Cancelar",
        /// cancela el ticket capturado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            //  Realiza las transacciones en la base de datos
            AppHelper.DoTransactions(
                delegate
                {
                    //  Validar
                    DoValidate();

                    //  Declaraciones
                    int ticket_ID; string motivo;
                    SICASCentralQuerysDataSetTableAdapters.Functions functions =
                        new SICASCentralQuerysDataSetTableAdapters.Functions();

                    //  Asignar los valores
                    ticket_ID = Convert.ToInt32(Ticket_IDTextBox.Text);
                    motivo = MotivoTextBox.Text;

                    //  Ejecutar la cancelación
                    //functions.CancelarTicket(ticket_ID, motivo, Sesion.Usuario_ID, DB.GetDate());
                    Entities.Functions.CancelarTicket(ticket_ID, motivo, Sesion.Usuario_ID, DB.GetDate());

                    //  Limpiar la forma
                    sICASCentralQuerysDataSet.Vista_Tickets.Clear();
                    AppHelper.ClearControl(this);

                    //  Comunicar éxito
                    AppHelper.Info("Ticket Cancelado");
                },
                this
            );
        }

        /// <summary>
        /// Al hacer enter en la caja de texto "Ticket ID"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ticket_IDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //  Validar que existan datos en las cajas
            if (e.KeyData == Keys.Enter && Ticket_IDTextBox.Text != "")
            {
                try
                {
                    //  Consultar la información y ligar los datos
                    this.vista_TicketsTableAdapter.Fill(
                        this.sICASCentralQuerysDataSet.Vista_Tickets, 
                            Convert.ToInt32(Ticket_IDTextBox.Text));

                    EstatusTicket_ID = (int)sICASCentralQuerysDataSet.Tables["Vista_Tickets"].Rows[0]["EstatusTicket_ID"];

                    //  Si el ticket esta ya cancelado
                    //  Impedir "Re-Cancelación"
                    if (EstatusTicket_ID == 2)
                    {
                        throw new Exception("Ticket ya esta cancelado.");
                    }
                }
                catch (System.Exception ex)
                {
                    AppHelper.Error(ex.Message);
                }
            }
        }

    } // end class

} // end namespace
