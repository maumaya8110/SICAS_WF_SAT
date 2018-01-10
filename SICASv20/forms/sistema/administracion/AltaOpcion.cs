using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaOpcion : baseForm
    {
        public AltaOpcion()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            this.get_ModulosTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_Modulos);                        
            this.opcionesBindingSource.AddNew();            
            SelectMenues();            
            base.BindData();
        }

        private void DoSave()
        {
            try
            {
                string x = imagenTextBox.Text;

                this.Validate();
                this.opcionesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

                AppHelper.Info("Registro actualizado");
                Padre.SwitchForma("Opciones");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void AltaOpcion_Load(object sender, EventArgs e)
        {                        

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void modulo_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectMenues();
        }

        private void SelectMenues()
        {
            try
            {
                if (modulo_IDComboBox.SelectedValue != null &&
                    !Convert.IsDBNull(modulo_IDComboBox.SelectedValue))
                {
                    int menuid = Convert.ToInt32(modulo_IDComboBox.SelectedValue);

                    this.get_MenuesTableAdapter.Fill(
                        this.sICASCentralQuerysDataSet.Get_Menues,
                            menuid);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void SelectImagenButton_Click(object sender, EventArgs e)
        {
            ImagenOpenDialog.InitialDirectory = System.Environment.CurrentDirectory + "\\images";
            ImagenOpenDialog.Filter = "Imagen PNG|*.png";
            ImagenOpenDialog.ShowDialog();
        }

        private void ImagenOpenDialog_FileOk(object sender, CancelEventArgs e)
        {
            imagenTextBox.Text = ImagenOpenDialog.SafeFileName;
        }
    }
}
