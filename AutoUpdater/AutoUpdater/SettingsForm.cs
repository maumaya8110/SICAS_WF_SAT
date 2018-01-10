using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoUpdater
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadData();
            Utils.SetStylish(this);
        }

        private string ConfigFile = System.Environment.CurrentDirectory + "\\aupcfg.xml";

        private void LoadData()
        {
            //FileStream fs = new FileStream(ConfigFile, FileMode.Open, FileAccess.Read);
            //this.configDS.ReadXml(fs);
            //fs.Flush();
            //fs.Close();            
            //fs.Dispose();

            this.configDS.ReadXml(CryptHelper.DecryptFile(ConfigFile));
            configDS.WriteXml("testconfig.xml");
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            
            CryptHelper.EncryptFile(CryptHelper.DataSetAsStream(configDS), "aupcfg.xml");
            
            MessageBox.Show("Datos actualizados!");

            this.Close();
        }
    }
}
