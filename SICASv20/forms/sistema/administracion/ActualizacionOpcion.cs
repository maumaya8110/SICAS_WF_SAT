using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionOpcion : baseForm
    {
        public ActualizacionOpcion()
        {
            InitializeComponent();
        }

        private int _Opcion_ID;
        public int Opcion_ID
        {
            get { return _Opcion_ID; }
            set { _Opcion_ID = value; }
        }

        public override void BindData()
        {                  
            //  Cargas los menues
            this.get_SelectMenuesTableAdapter1.Fill(this.sICASCentralQuerysIIDataSet.Get_SelectMenues);

            //  Cargar la opcion
            this.opcionesTableAdapter.Fill(this.sICASCentralDataSet.Opciones, Opcion_ID);
                        
            //  Seleccionar el menu
            base.BindData();
        }        

        private void DoSave()
        {
            try
            {
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

        private void ActualizacionOpcion_Load(object sender, EventArgs e)
        {            
            
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            DoSave();
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

    }   //  Class ActualizacionOpcion
}   //  Namespace
