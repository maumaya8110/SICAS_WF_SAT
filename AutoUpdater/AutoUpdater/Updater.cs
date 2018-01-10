using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Diagnostics;
using Ionic.Zip;

namespace AutoUpdater
{
    public class Updater
    {
        private volatile bool _Stop = false;        
        /// <summary>
        /// Llamada para detener el proceso
        /// </summary>
        public void RequestStop()
        {
            _Stop = true;
        }

        /// <summary>
        /// Ejecuta la actualización de la aplicación
        /// No necesita parametros, todo lo toma de los archivos de configuración
        /// </summary>
        public void AppUpdate()
        {
            string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SICAS\\";
            //  Cargar el archivo de configuracion encriptado en un DataSet
            ConfigDS config = new ConfigDS();            
            config.ReadXml(CryptHelper.DecryptFile(System.Environment.CurrentDirectory + "\\aupcfg.xml"));
            
            //  Obtener las tablas del DataSet
            ConfigDS.LocalConfigDataTable localConfig = config.LocalConfig;
            ConfigDS.WebServiceSettingsDataTable webService = config.WebServiceSettings;
            ConfigDS.FTPSettingsDataTable FTPSettings = config.FTPSettings;
            ConfigDS.HttpSettingsDataTable HttpSettings = config.HttpSettings;
            ConfigDS.VersionControlDataTable VersionControl = config.VersionControl;

            //  Directorio y aplicacion
            string currentdirectory = AppFolder + "\\" + localConfig.Rows[0]["AppPath"].ToString();
            string mainFile = currentdirectory + "\\" +
                        localConfig.Rows[0]["MainFile"].ToString();

            //  Obtener el ID de la aplicación
            int app_ID = Convert.ToInt32(localConfig.Rows[0]["App_ID"].ToString());

            AutoUpWebService.AutoUpdaterWS ws = null;
            string currentVersion = "", user = "", pwd = "";

            bool IsOK = false;

            foreach (DataRow dr in webService.Rows)
            {
                try
                {
                    //  Configurar la dirección remota del servicio web
                    Utils.WSUrl = dr["Url"].ToString();

                    //  Obtener las credencianciales del servicio web
                    user = dr["User"].ToString();
                    pwd = dr["Pwd"].ToString();

                    ws = new AutoUpWebService.AutoUpdaterWS();

                    //  Obtener la versión actual del servidor 
                    currentVersion = ws.CurrentVersion(app_ID, user, pwd);
                    IsOK = true;
                    break;
                }
                catch
                {
                    continue;
                }
            }

            if (!IsOK)
            {
                Utils.Log("No se puede resolver servicio web");
                Directory.SetCurrentDirectory(currentdirectory);
                Process.Start(mainFile);
                return;
            }

            //  Obtener la versión local actual
            string localVersion = localConfig.Rows[0]["CurrentVersion"].ToString();

            // Si current mayor que local
            if (String.Compare(currentVersion, localVersion) > 0)
            {
                // Hay actualización
                
                // Obtener la información de la actualización
                // AppInfo                
                DataSet ds = ws.AppInfo(app_ID, currentVersion, user, pwd);

                // Get Table
                DataTable dt = ds.Tables[0];

                //  Set vars
                string packageLocation = dt.Rows[0]["PackageLocation"].ToString();
                string packageDestination = AppFolder + "\\" + currentVersion + ".zip";
                string packageFolder = AppFolder + "\\" + currentVersion;
                string imageUrl = dt.Rows[0]["ImageUrl"].ToString();

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

                ////  Descargar la imagen
                //Utils.HTTPDownload(imageUrl, "AppImage",
                //    HttpSettings.Rows[0]["User"].ToString(),
                //        HttpSettings.Rows[0]["Pwd"].ToString());

                //  Crear directorio
                if (!Directory.Exists(packageFolder))
                {
                    Directory.CreateDirectory(packageFolder);
                }

                //  Extraer archivos
                ZipFile zip = ZipFile.Read(AppFolder + "\\" + currentVersion + ".zip");

                foreach (ZipEntry ze in zip)
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

                CryptHelper.EncryptFile(CryptHelper.DataSetAsStream(config), "aupcfg.xml");


                //Borrar el zip
                zip.Dispose();

                if (File.Exists(AppFolder + "\\" + currentVersion + ".zip"))
                {
                    File.Delete(AppFolder + "\\" + currentVersion + ".zip");
                }

                // Iniciar programa principal
                Directory.SetCurrentDirectory(AppFolder + "\\" +
                    localConfig.Rows[0]["AppPath"].ToString());

                Process.Start(packageFolder + "\\" +
                        localConfig.Rows[0]["MainFile"].ToString());
            }
            else
            {
                // No hay actualización
                // Iniciar programa principal
                Directory.SetCurrentDirectory(currentdirectory);                
                Process.Start(mainFile);
            }            
        }
    }
}
