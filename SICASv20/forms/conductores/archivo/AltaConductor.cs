/*
 * AltaConductor
 * Codificado por Luis Espino
 * 
 * **  HISTORIAL  **
 *      2012-10-25  -   Modificado  -   Luis Espino
 *          Se modificó el comportamiento para soportar los nuevos campos:
 *              -   PrimerCursoLicencia
 *              -   SegundoCursoLicencia
 *              -   ExamenMedico
 *              -   Nomina
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SICASv20.forms
{
    public partial class AltaConductor : baseForm
    {
        public AltaConductor()
        {
            InitializeComponent();
        }

        private void conductoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void DoValidate()
        {
            AppHelper.ValidateControl(this.MedioPublicitario_IDComboBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.cumplioPerfilCheckBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.Mercado_IDComboBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.comentariosTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.edadTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.estadoCivilTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.añosExperienciaTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.generoTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.TipoLicencia_IDComboBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.folioLicenciaTextBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.venceLicenciaDateTimePicker, AppHelper.ValidateRule.Required);
        }

        private void DoSave()
        {






            DoValidate();

            Entities.Conductores conductor =
                (Entities.Conductores)this.conductoresBindingSource.Current;

            if (conductor.BloquearConductor == null)
                conductor.BloquearConductor = false;
            conductor.EstatusConductor_ID = 1;
            conductor.Fecha = DB.GetDate();
            conductor.Usuario_ID = Sesion.Usuario_ID;
            conductor.Validate();


            //int repet = 0;

            int _txtrept = int.Parse(txtRepet.Text);

            for (int repet = 1; repet <= _txtrept; repet++)
            {

                conductor.Create();
                SaveImage(conductor.Conductor_ID);
            }



            AppHelper.Info("Conductor registrado!");


            ConductoresIdGNV var = new ConductoresIdGNV();
            var._topvar = txtRepet.Text;
            var._conductorid = conductor_IDTextBox.Text;
            var.ShowDialog();

            Padre.SwitchForma("Conductores");



        }





        private void SaveImage(int conductor)
        {
            if (FotoPictureBox.Image != null)
            {
                AppHelper.FTPUpload(
                    FotoPictureBox.ImageLocation,
                    Sesion.FTP.Server + Sesion.FTP.Path + "/FotosConductores/" + conductor + ".jpg",
                    Sesion.FTP.User,
                    Sesion.FTP.Pwd);
            }
        }

        public override void BindData()
        {
            this.tiposLicenciasTableAdapter.Fill(this.sICASCentralDataSet.TiposLicencias);

            this.mercadosTableAdapter.Fill(this.sICASCentralDataSet.Mercados);

            this.mediosPublicitariosTableAdapter.Fill(this.sICASCentralDataSet.MediosPublicitarios);

            this.estacionesBindingSource.DataSource = Sesion.Estaciones;

            conductoresBindingSource.AddNew();

            AppHelper.SetContainerDBValidations(this, "Conductores");

            this.coloniaTextBox.TabIndex = 5; // Parche para ordenar el tabIndex de la Colonia que se agregó al final

            base.BindData();
        }

        private void AltaConductor_Load(object sender, EventArgs e)
        {


        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (txtRepet.Text != "")
            {
                int _rep = int.Parse(txtRepet.Text);
                if (_rep > 0)
                {
                    AppHelper.DoMethod(DoSave, this);
                }
                else
                {
                    AppHelper.Info("Favor de Capturar un Numero Valido");
                    txtRepet.Focus();
                }

            }
            else
            {
                AppHelper.Info("Favor de Capturar un Numero Valido");
                txtRepet.Focus();
            }


        }

        private void FotoButton_Click(object sender, EventArgs e)
        {
            FotoOpenFileDialog.ShowDialog();
        }

        private void FotoOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                FotoPictureBox.ImageLocation = FotoOpenFileDialog.FileName;
                fotografiaTextBox.Text = FotoOpenFileDialog.FileName;
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void txtRepet_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            ////Para obligar a que sólo se introduzcan números 
            //if (Char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //    if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            //    {
            //        e.Handled = false;
            //    }
            //    else
            //    {
            //        //el resto de teclas pulsadas se desactivan 
            //        e.Handled = true;
            //    } 
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {

            //ConductoresIdGNV var = new ConductoresIdGNV();
            //var._topvar = txtRepet.Text;
            //var._conductorid = conductor_IDTextBox.Text;
            //var.ShowDialog();
        }
    }
}
