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
    public partial class ActualizacionConductor : baseForm
    {
        public ActualizacionConductor()
        {
            InitializeComponent();
        }

        private void conductoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
        }

        private int _Conductor_ID;
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private string _Tab;
        public string Tab
        {
            get { return _Tab; }
            set { _Tab = value; }
        }

        private string _mensajeACaja_Old, _mensajeACaja_New;

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

        private void DoValidate()
        {
            AppHelper.ValidateControl(this.MedioPublicitario_IDComboBox, AppHelper.ValidateRule.Required);
            AppHelper.ValidateControl(this.cumplioPerfilCheckBox, AppHelper.ValidateRule.Required);
            //AppHelper.ValidateControl(this.Mercado_IDComboBox, AppHelper.ValidateRule.Required);
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
            _mensajeACaja_New = this.mensajeACajaTextBox.Text;
            
            this.fechaDateTimePicker.Value = DB.GetDate();
            this.usuario_IDTextBox.Text = Sesion.Usuario_ID;
            DoValidate();

            Entities.Conductores conductor = (Entities.Conductores)conductoresBindingSource.Current;
            if (conductor.BloquearConductor == null)
                conductor.BloquearConductor = false;
            conductor.Validate();
            bool validaCURP = true;
            conductor.Update(validaCURP);

            SaveImage(this.Conductor_ID);

            if (!_mensajeACaja_New.Equals(_mensajeACaja_Old))
            {
                Entities.HistorialCobranzaConductores historial =
                    new Entities.HistorialCobranzaConductores();
                historial.Accion = "Ingreso de mensaje a caja";
                historial.Comentario = _mensajeACaja_New;
                historial.Conductor_ID = this.Conductor_ID;
                historial.Estacion_ID = Convert.ToInt32(this.Estacion_IDComboBox.SelectedValue);
                historial.Fecha = DB.GetDate();
                historial.Usuario_ID = Sesion.Usuario_ID;
                historial.Create();
            }

            AppHelper.Info("Conductor actualizado!");
            Padre.SwitchForma("Conductores");
        }

        public override void BindData()
        {
            this.tiposLicenciasTableAdapter.Fill(this.sICASCentralDataSet.TiposLicencias);
            
            this.mercadosTableAdapter.Fill(this.sICASCentralDataSet.Mercados);
            
            this.mediosPublicitariosTableAdapter.Fill(this.sICASCentralDataSet.MediosPublicitarios);
            
            //this.estacionesTableAdapter.Fill(this.sICASCentralDataSet.Estaciones);
            this.estacionesBindingSource.DataSource = Sesion.Estaciones;

            this.estatusConductoresTableAdapter.Fill(this.sICASCentralDataSet.EstatusConductores);

            //  Cargamos los datos del conductor
            Entities.Conductores conductor = Entities.Conductores.Read(Conductor_ID);
            this.conductoresBindingSource.DataSource = conductor;

            if (!string.IsNullOrEmpty(conductor.Fotografia))
            {
                this.FotoPictureBox.ImageLocation = (string)conductor.Fotografia;
            }

            if (Tab != "")
            {
                ConductoresTabControl.SelectedTab = ConductoresTabControl.TabPages[Tab];
            }

            AppHelper.SetContainerDBValidations(this, "Conductores");

            this.coloniaTextBox.TabIndex = 5; // Parche para ordenar el tabIndex de la Colonia que se agregó al final

            _mensajeACaja_Old = this.mensajeACajaTextBox.Text;

            base.BindData();
        }

        private void AltaConductor_Load(object sender, EventArgs e)
        {
            
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(DoSave, this);
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
            catch(Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
