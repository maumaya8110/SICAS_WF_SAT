using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;

namespace SICASv20
{
	static class Program
	{


		[STAThread]
		static void Main()
		{
             

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			log4net.Config.XmlConfigurator.Configure();

			//  Verificar la conectividad con el servidor
			//  Dos veces
			try
			{
                //ConfigDS config = new ConfigDS();
                //config.ReadXml(CryptHelper.DecryptFile("sicas.dat"));

				//#if DEBUG

                //LogHelper.Logger.Info("Inicio de aplicación en modo Debug");
                //ConnStrForDebug();


				//#else
                LogHelper.Logger.Info("Inicio de aplicación en modo Release");
                AppHelper.ReadConfig();
				//#endif
			}
			catch (SICASException)
			{
				LogHelper.Logger.Error("Falló Conexión, intenta nuevamente desde configuración");
				try
				{
					//  Si existió un error,
					//  Intentar de nuevo
					AppHelper.ReadConfig();
				}
				catch (SICASException sicasex)
				{
					//  No se pudo conectar,
					//  Mostrar el error y salir
					AppHelper.Error(sicasex.Message);
					return;
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
				return;
			}
			Application.Run(new forms.LoginForm());
		}

		static void ConnStrForDebug()
		{
			//Sesion.DB.Server = "sicas.casco.com.mx,54903";
			//Sesion.DB.Server = "CSCO-COSW";
			//Sesion.DB.Server = @"192.168.0.74\SGC";
			Sesion.DB.Server = "192.168.0.251";

			//Sesion.DB.Database = "SICASSync";
			Sesion.DB.Database = "SICASTest";

			Sesion.DB.User = "SICASusr";
			Sesion.DB.Pwd = "oiuddvbh";

			string connectionString = "";
			connectionString = string.Format(
						 "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connection Timeout=30;",
						 Sesion.DB.Server,
						 Sesion.DB.Database,
						 Sesion.DB.User,
						 Sesion.DB.Pwd
					  );
			//global::SICASv20.Properties.Settings.Default.SICASCentralConnectionString = connectionString;
			DB.connStr = connectionString;
		}






	} // end class
} // end namespace 
