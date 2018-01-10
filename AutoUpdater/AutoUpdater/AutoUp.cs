using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Ionic.Zip;

namespace AutoUpdater
{
    public partial class AutoUp : Form
    {
        public AutoUp()
        {
            InitializeComponent();
        }

        private volatile bool _Stop;

        private void CreateConfigFiles()
        {
            ConfigDS config = new ConfigDS();

            config.Tables["LocalConfig"].Rows.Add("SICAS", "SICAS", "SICAS.exe", "2.0.0.0", "SICAS Versión 2.0", "images\\SICASSplash,jpg", "v2.0.0.0");
            config.Tables["LocalConfig"].AcceptChanges();

            config.Tables["FTPSettings"].Rows.Add(1, "SICAS", "SICASftp", "ibdibnnesems", "/AppRepository");
            config.Tables["FTPSettings"].AcceptChanges();

            config.Tables["HttpSettings"].Rows.Add(1, "http://SICAS:88/", "SICAS", "nhtccuag");
            config.Tables["HttpSettings"].AcceptChanges();

            config.Tables["WebServiceSettings"].Rows.Add(1, "http://SICAS/ws.asmx", "SICASws", "nhtccuag");
            config.Tables["WebServiceSettings"].AcceptChanges();

            config.Tables["EmailSettings"].Rows.Add(1, "mail.casco.com.mx", "sicas@casco.com.mx", "casco1", 2525);
            config.Tables["EmailSettings"].AcceptChanges();

            DataSet ds = new DataSet();
            ds.ReadXml(System.Environment.CurrentDirectory + "\\Config.xml");
            ds.WriteXml(System.Environment.CurrentDirectory + "\\dsCfg.xml");

            config.WriteXml(System.Environment.CurrentDirectory + "\\Config.xml");
            MessageBox.Show("Done!");            
        }

        /// <summary>
        /// Encrypta archivos
        /// </summary>
        private void DoCrypt()
        {
            //cryp files
            string xmlFile = System.Environment.CurrentDirectory + "\\Config.xml";
            string cryptFile = System.Environment.CurrentDirectory + "\\CryptConfig.xml";
            string decryptFile = System.Environment.CurrentDirectory + "\\DecryptConfig.xml";
            string decryptXmlFile = System.Environment.CurrentDirectory + "\\DecryptedXMLFile.xml";

            //CryptHelper.EncryptFile(xmlFile, cryptFile);
            //CryptHelper.DecryptFile(cryptFile, decryptFile);

            ConfigDS config = new ConfigDS();
            config.ReadXml(CryptHelper.DecryptFile(cryptFile));
            config.WriteXml(decryptXmlFile);

            MemoryStream ms = CryptHelper.EncryptFile(xmlFile);
            StreamReader sr = new StreamReader(ms);
            string text = sr.ReadToEnd();

            MessageBox.Show(text);
            this.Close();            
        }

        /// <summary>
        /// Ejecuta la actualización de la aplicación
        /// No necesita parametros, todo lo toma de los archivos de configuración
        /// </summary>
        public void AppUpdate()
        {
            ConfigDS config = new ConfigDS();
            config.ReadXml(System.Environment.CurrentDirectory + "\\Config.xml");
            
            ConfigDS.LocalConfigDataTable localConfig = config.LocalConfig;
            ConfigDS.WebServiceSettingsDataTable webService = config.WebServiceSettings;
            ConfigDS.FTPSettingsDataTable FTPSettings = config.FTPSettings;
            ConfigDS.HttpSettingsDataTable HttpSettings = config.HttpSettings;
            ConfigDS.VersionControlDataTable VersionControl = config.VersionControl;

            Utils.WSUrl = webService.Rows[0]["Url"].ToString();

            AutoUpWebService.AutoUpdaterWS ws = new AutoUpWebService.AutoUpdaterWS();

            int app_ID = Convert.ToInt32(localConfig.Rows[0]["App_ID"].ToString());
            string user = webService.Rows[0]["User"].ToString();
            string pwd = webService.Rows[0]["Pwd"].ToString();

            string currentVersion = ws.CurrentVersion(app_ID, user, pwd);

            string localVersion = localConfig.Rows[0]["CurrentVersion"].ToString();

            // Si current mayor que local
            if (String.Compare(currentVersion, localVersion) > 0)
            {
                // Hay actualización
                // Informar a la UI

                // Obtener la información de la actualización
                // AppInfo                
                DataSet ds = ws.AppInfo(app_ID, currentVersion, user, pwd);
                
                // Get Table
                DataTable dt = ds.Tables[0];

                //  Set vars
                string packageLocation = dt.Rows[0]["PackageLocation"].ToString();
                string packageDestination = System.Environment.CurrentDirectory + "\\" + currentVersion + ".zip";
                string packageFolder = System.Environment.CurrentDirectory + "\\" + currentVersion;

                if (packageLocation.Contains("ftp://"))
                {
                    // Es FTP
                    // Descargar
                    Utils.FTPDownload(
                        packageLocation,
                            packageDestination, 
                                FTPSettings.Rows[0]["User"].ToString(), 
                                    FTPSettings.Rows[0]["Pwd"].ToString());

                }
                else if (packageLocation.Contains("http://"))
                {
                    // Es HTTP
                    // Descargar
                    Utils.HTTPDownload(
                        packageLocation,
                            packageDestination,
                                HttpSettings.Rows[0]["User"].ToString(), 
                                    HttpSettings.Rows[0]["Pwd"].ToString());
                }

                //  Crear directorio
                if (!Directory.Exists(packageFolder)) 
                {
                    Directory.CreateDirectory(packageFolder);
                }

                //  Extraer archivos
                ZipFile zip = ZipFile.Read(System.Environment.CurrentDirectory + "\\" + currentVersion + ".zip");
                
                foreach(ZipEntry ze in zip)
                {
                    ze.Extract(packageFolder, 
                        ExtractExistingFileAction.OverwriteSilently);
                }

                //  Guardar los cambios de control de versiones
                config.VersionControl.Rows.Add(
                    dt.Rows[0]["App_ID"].ToString(),
                        currentVersion,
                            currentVersion,
                                dt.Rows[0]["MainFile"].ToString(),
                                    dt.Rows[0]["Comments"].ToString());
                config.VersionControl.AcceptChanges();

                //  Guardar los cambios de configuración local
                config.LocalConfig.Rows[0]["MainFile"] = dt.Rows[0]["MainFile"].ToString();
                config.LocalConfig.Rows[0]["CurrentVersion"] = currentVersion;
                config.LocalConfig.Rows[0]["AppPath"] = currentVersion;
                config.LocalConfig.AcceptChanges();

                config.WriteXml("Config.xml");                

                //Borrar el zip
                zip.Dispose();

                if (File.Exists(System.Environment.CurrentDirectory + "\\" + currentVersion + ".zip"))
                {
                    File.Delete(System.Environment.CurrentDirectory + "\\" + currentVersion + ".zip");
                }                

                // Iniciar programa principal
                Process.Start(packageFolder + "\\" +
                        localConfig.Rows[0]["MainFile"].ToString());

                // Salir              
                this.Close();
            }
            else
            {
                // No hay actualización
                // Iniciar programa principal
                Process.Start(System.Environment.CurrentDirectory + "\\" +
                    localConfig.Rows[0]["AppPath"].ToString() + "\\" +
                        localConfig.Rows[0]["MainFile"].ToString());

                // Salir                
                this.Close();
            }            
        }

        private void AutoUp_Load(object sender, EventArgs e)
        {                        
        }
    }
}
