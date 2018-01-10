using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Linq;

namespace SICASv20.forms.caja
{
    public partial class ResguardoEfectivoParcial : Form
    {
        private Decimal montoSugerido = 0;
        private Decimal montoAcumulado = 0;
        private Decimal montoResguardado = 0;

        public ResguardoEfectivoParcial()
        {
            if (!Sesion.Activo)
            {
                throw new Exception("No hay una sesión activa. No se pueden realizar cobros");
            }
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ResguardoEfectivoParcial_Load(object sender, EventArgs e)
        {
            lbMontoEstacion.Text = "0";
            lblMontoResguardado.Text = "0";
            try
            {
               

                Decimal resguadoPendiente = Entities.Cajas_ResguardoEfectivoSesion.ReadMontoPendienteResguardoSesion(Sesion.Sesion_ID, Convert.ToInt32(Sesion.Estacion_ID));
                this.lblMontoPendiente.Text = String.Format("{0:C}", resguadoPendiente);
                this.montoAcumulado = resguadoPendiente;

                // Se obtiene el monto Sugerido para la estacion
                Entities.Cajas_ResguardoEfectivoEstaciones montoResguardo = Entities.Cajas_ResguardoEfectivoEstaciones.Read(Convert.ToInt16(Sesion.Estacion_ID));
                this.montoSugerido = montoResguardo.MontoResguardo;
                lbMontoEstacion.Text = String.Format("{0:C}", this.montoSugerido);

                // Se Obtiene y suma el monto resguardado
                DataTable dtresguardos = new DataTable();
                dtresguardos = Entities.Cajas_ResguardoEfectivoSesion.ReadList(Sesion.Sesion_ID);
                if (dtresguardos.Rows.Count > 0)                
                    this.montoResguardado = Convert.ToDecimal(dtresguardos.Compute("Sum(MontoResguardoParcial)", ""));
                
                lblMontoResguardado.Text = String.Format("{0:C}", this.montoResguardado);
                

                // Monto acumulado es la suma de cobros menos lo ya resguardado
                //this.montoAcumulado = 3000;
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                validamonto();
                string textMonto = txtMontoResguardoParcial.Text;
                //  Verifica que no se esten capturando decimales
                //  al momento del calculo
                if (!textMonto.EndsWith("."))
                {
                    if (this.montoAcumulado <= Convert.ToDecimal(textMonto))
                    {
                        //throw new Exception("El monto que intenta resguardar es menor al disponible.");
                        //MessageBox.Show("El monto que intenta resguardar es menor al disponible.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        AppHelper.ThrowException("El monto que intenta resguardar es menor al disponible.");
                        return;
                    }
                    // Inserta el monto parcial para resguardo.
                    Entities.Cajas_ResguardoEfectivoSesion montoResguardoSesion = new Entities.Cajas_ResguardoEfectivoSesion();
                    montoResguardoSesion.Sesion_ID = Sesion.Sesion_ID;
                    montoResguardoSesion.MontoResguardoParcial = Convert.ToDecimal(txtMontoResguardoParcial.Text);
                    montoResguardoSesion.Ticket_ID = null;
                    montoResguardoSesion.Create();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }

            this.Close();

        }



        private void txtMontoResguardoParcial_KeyPress(object sender, KeyPressEventArgs e)
        {
            validamonto();
        }

        //private void txtMontoResguardoParcial_Leave(object sender, EventArgs e)
        //{
        //    validamonto();

        //    string textMonto = txtMontoResguardoParcial.Text;
        //    if (this.montoAcumulado <= Convert.ToDecimal(textMonto))
        //    {
        //        //throw new Exception("El monto a resguardar, es mayor que lo acumulado al momento.");
        //        AppHelper.ThrowException("El monto a resguardar, es mayor que lo acumulado al momento.");
        //        txtMontoResguardoParcial.Focus();
        //    }
        //}


        private void validamonto()
        {
            string textMonto = txtMontoResguardoParcial.Text;
            if (textMonto.Length > 0)
            {
                if (!IsNumeric(textMonto))
                {
                    //throw new Exception("El monto debe ser un valor numerico.");
                    AppHelper.ThrowException("El monto a resguardar, es mayor que lo acumulado al momento.");
                    return;
                }
                if (this.montoAcumulado <= Convert.ToDecimal(textMonto))
                {
                    AppHelper.ThrowException("El monto a resguardar, es mayor que lo acumulado al momento.");
                    return;
                }
                txtMontoResguardoParcial.Focus();
            }

        }

        
        public bool IsNumeric(string input)
        {
            Decimal test;
            return Decimal.TryParse(input, out test);
        }

    }


}
