/*
 * 2013-01-03, Modificado por Luis Espino
 *      Se cambia la construcción de la cadena de conexión,
 *      para que incluya el puerto dinámicamente, 1433 si es local,
 *      54093 si es externo
 *      Versión 2.1.7.6
 * 
 * 2013-01-04, Modificado por Luis Espino
 *      Correción de error en funcion Entities.Functions.GetInventarioDiferido,
 *      ya que arrojaba un valor nulo cuando no existía la refacción en 
 *      inventario.
 *      Versión 2.1.7.7
 * 
 * 2013-01-22, Modificado por Luis Espino
 *      Corrección de la función AuthUser, para que valide usuarios solamente activos
 * 
 * 2013-02-15, Modificado por Luis Espino
 *      Cambio en clases de venta de servicios para módulo Aeropuerto
 *      Se retiró la restricción de impresión a Puerto LPT1
 *      Versión 2.1.7.8
 * 
 * 2013-02-21, Modificado por Luis Espino
 *      Cambio en Alta de Planillas, selección de Estaciones
 *      Versión 2.1.7.9
 *      
 * 2013-03-21, Modificado por Luis Espino
 *      Implementación de validaciones en kilometrajes
 *      Versión 2.1.8.0
 *      
 * 2013-03-22, Modificado por Luis Espino
 *      Implementación de reporte comparativo de Kilometrajes - Unidades
 *      Versión 2.1.8.1
 *      
 * 2013-04-01, Modificado por Luis Espino
 *      Eliminamos validaciones de kilometrajes en captura de ordenes de trabajo
 *      Versión 2.1.8.2
 *      
 * 2013-05-11, Modificado por Luis Espino
 *      Modificaciones solicitadas por CASCO: Estatus y Locaciomes, Conductor Operativo de unidades,
 *      Reporte de Licencias Vencidas
 *      Versión 2.1.8.3
 *      
 * 2013-05-11, Modificado por Luis Espino
 *      Ajuste por error de dedo en deployment
 *      Versión 2.1.8.4
 *      
 * 2013-05-13, Modificado por Ricardo Ponce
 *      Modificaciones a Licencias por Vencer y a Adeudos Conductor
 *      Versión 2.1.8.5
 *      
 * 2013-05-22, Modificado por Ricardo Ponce
 *      Corrección de Bug en el Orden de Impresión de Ticket en Caja Aeropuerto para que muestre 
 *      Total de Adeudos y calcule correctamente el TPC
 *      Versión 2.1.8.6
 *      
 * 2013-07-03, Modificado por Ricardo Ponce
 *      Se agregan validaciones a la Alta y Actualización de Condutor para hacer obligatorios y 
 *      validar RFC y CURP. También se deshabilita el checkbox de bloqueo a conductor.
 *      Adicionalmente se remueve del combo de locaciones el valor de Circulando cuando se hace
 *      una liquidación de contrato.
 *      Versión 2.1.8.7
 *      
 * 2013-07-15, Modificado por Ricardo Ponce
 *      Se separa la funcionalidad de compras, permitiendo a un usuario hacer la orden de compra
 *      y al almacenista ingresar la entrada al inventario.
 *      En la validación de CURP, muestra si existe otro conductor con el mismo CURP.
 *      Se valida que no se puedan poner en ciertos estatus las unidades cuando estan en contrato
 *      Permitimos a la caja cobrar aun cuando la unidad este inactiva.
 *      Versión 2.1.8.8
 *
 * 2013-07-25, Modificado por Ricardo Ponce
 *     Se extiende el Profile del Conductor agregando información Socioeconómica y Psicométirca
 *     Versión 2.1.8.9
 *
 * 2013-08-09, Modificado por Ricardo Ponce
 *     Se agrega el campo de Activo a la clase de TiposMantenimiento y a Vista_TiposMantenimientos
 *     para permitir activar y desactivar los tipos de Mantenimientos a seleccionar durante la
 *     creación de una Orden de Trabajo.
 *     Se realizaron ajustes en la clase Unidades para validar el número de Serie que no se repita
 *     y que se ajuste al formato definido por la expresion regular.
 *     Versión 2.1.9.0
 *     
 *2015-09-01, Modificado por Galdino Melchor Díaz
 *     Se agrega opción para buscar Regresos Vendidos en Aeropuerto.
 *     Se agrega validación para evitar división entre 0 para los casos en que los conductores tengan
 *     un contrato con monto diario = 0 pesos. (conductores de nomina)
 *     Se agrega leyenda a la impresión del boleto de regreso para indicar al cliente que debe programar
 *     su regreso pra obtener el beneficio de 0 filas.
 *     
 * 2016-08-29, MOdificado por Galdino Melchor Díaz
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Net.NetworkInformation;
using log4net;

namespace SICASv20
{
	class AppHelper
	{
        public static string Version = Application.ProductVersion;//"2.2.0.2";

		/// <summary>
		/// Máximo kilometraje que una unidad puede recorrer en un día
		/// </summary>
		public const int MAX_KM_DIARIO = 2400;

		private static string _ImagePath = System.Environment.CurrentDirectory + "\\images\\";
		public static string ImagePath
		{
			get { return _ImagePath; }
		}

		private static string _IconFile = System.Environment.CurrentDirectory + "\\sicas.ico";
		public static string IconFile
		{
			get { return _IconFile; }
		}

		private static decimal _IVA = 16;

		public static decimal IVA
		{
			get { return _IVA; }
			set { _IVA = value; }
		}

		public static decimal CalcularIVA(decimal Cantidad)
		{
			return Cantidad * (IVA / 100);
		}

		private static Entities.RegistroAccionesSistema registro;
		public static void LogDB(string accion, string comentarios, string formulario, int? opcion_id)
		{
			registro = new Entities.RegistroAccionesSistema();
			registro.Accion = accion;
			registro.Comentarios = comentarios;
			registro.Fecha = DB.GetDate();
			registro.Formulario = formulario;
			registro.Opcion_ID = opcion_id;
			registro.Usuario_ID = Sesion.Usuario_ID;
			registro.Create();
		}

		#region Ping

		public static bool Ping(string address)
		{
			Ping pingSender = new Ping();
			PingOptions options = new PingOptions();

			// Use the default Ttl value which is 128,
			// but change the fragmentation behavior.
			options.DontFragment = true;

			// Create a buffer of 32 bytes of data to be transmitted.
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			byte[] buffer = Encoding.ASCII.GetBytes(data);
			int timeout = 120;
			PingReply reply = pingSender.Send(address, timeout, buffer, options);
			if (reply.Status == IPStatus.Success)
			{
				return true;
			}

			return false;
		}

		#endregion

		#region Regex

		public const string MatchEmailPattern =
				@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
		   + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
		   + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
		   + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

		public static bool IsEmail(string email)
		{
			if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
			else return false;
		}

		#endregion

		#region Config

		public static void VerificarPruebaForzada()
		{
			bool EsPruebaForzada = false;
			EsPruebaForzada = Convert.ToBoolean(DB.QueryScalar("SELECT Valor FROM VariablesNegocio WHERE VariableNegocio_ID = 'PruebaForzada'"));

			if (EsPruebaForzada)
			{
				Sesion.EsPrueba = true;
			}
		}

		
		/// <summary>
		/// Crea el archivo de configuracion
		/// </summary>
		public static void SetConfigFile()
		{
		    //  Hay que ponerle un server tres, con la nueva dirección 38.124.197.5
		    ConfigDS config = new ConfigDS();
            config.DB.AddDBRow("Produccion", "38.124.197.5", "SICASSync", "SICASusr", "oiuddvbh", 2);
		    config.DB.AddDBRow("Produccion", "192.168.0.251", "SICASSync", "SICASusr", "oiuddvbh", 1);		    
		    config.DB.AddDBRow("Produccion", "201.159.98.194", "SICASSync", "SICASusr", "oiuddvbh", 3);
		    config.DB.AddDBRow("Pruebas", "192.168.0.251", "SICASTest", "SICASusr", "oiuddvbh", 1);
		    config.DB.AddDBRow("Pruebas", "38.124.197.5", "SICASTest", "SICASusr", "oiuddvbh", 2);
		    config.DB.AddDBRow("Pruebas", "201.159.98.194", "SICASTest", "SICASusr", "oiuddvbh", 3);

		    config.FTP.AddFTPRow("Produccion", "192.168.0.251", "sicasftp", "ibdibnnesems", "", 1);
		    config.FTP.AddFTPRow("Produccion", "38.124.197.5", "sicasftp", "ibdibnnesems", "", 2);
		    config.FTP.AddFTPRow("Produccion", "201.159.98.194", "sicasftp", "ibdibnnesems", "", 3);
		    config.FTP.AddFTPRow("Pruebas", "192.168.0.251", "sicasftp", "ibdibnnesems", "/Pruebas", 1);
		    config.FTP.AddFTPRow("Pruebas", "38.124.197.5", "sicasftp", "ibdibnnesems", "/Pruebas", 2);
		    config.FTP.AddFTPRow("Pruebas", "201.159.98.194", "sicasftp", "ibdibnnesems", "/Pruebas", 3);

		    CryptHelper.EncryptDataSet(config, "sicas.dat");
		}


		/// <summary>
		/// Determina si una dirección IP es local o externa
		/// </summary>
		/// <param name="ipaddress">La dirección IP</param>
		/// <returns></returns>
		private static bool IsIPAddressLocal(string ipaddress)
		{

          
                return ipaddress.StartsWith("192.168");
            
		}

		public static void ReadConfig()
		{
			ConfigDS config = new ConfigDS();
			config.ReadXml(CryptHelper.DecryptFile("sicas.dat"));
			// CryptHelper.DecryptFile("sicas.dat", "sicas_decrypted.dat");

			Sesion.DB.Database = string.Empty;
			Sesion.DB.Pwd = string.Empty;
			Sesion.DB.User = string.Empty;
			Sesion.DB.Server = string.Empty;

			string filter = "";

			if (Sesion.EsPrueba)
			{
				filter = "Key = 'Pruebas'";
			}
			else
			{
				filter = "Key = 'Produccion'";
			}

			DataRow[] rowsDB = config.DB.Select(filter, "Order");
			DataRow[] rowsFTP = config.FTP.Select(filter, "Order");

			foreach (DataRow drDB in rowsDB)
			{
				//  Contenedor temporal de la dirección de servidor
                string dbServer = "";// drDB["Server"].ToString();


                int prueba =0;

                if (prueba == 0)
                {
                    dbServer = drDB["Server"].ToString();
                }
                else
                {
                    dbServer = "sicas.casco.com.mx";
                }


				//  Verificamos que el servidor esté disponible
				if (Ping(dbServer))
				{
					Sesion.DB.Database = drDB["DataBase"].ToString();
					Sesion.DB.Pwd = drDB["Pwd"].ToString();
					Sesion.DB.User = drDB["UserID"].ToString();
                    //Sesion.DB.Server = drDB["Server"].ToString();


                    if (prueba == 0)
                    {
                        Sesion.DB.Server = drDB["Server"].ToString();
                    }
                    else
                    {
                        Sesion.DB.Server = "sicas.casco.com.mx";
                    }




					// Aqui, si es local dirigir al puerto 1433, si no al 54903
					// Agregarlo al servidor 
					if (!IsIPAddressLocal(dbServer))
						Sesion.DB.Server += ",54903";
					//else
					//	Sesion.DB.Server += ",1433";


					//  Configuramos la cadena de conexión
					SetConnStr();

					//  Intentamos conectarnos al servidor
					if (DB.TryConnect(DB.connStr))
					{
						//  Si el intento es exitoso, salimos del ciclo
						break;
					} // end if
					else
					{
						LogHelper.Logger.Error(string.Format("Fallo Conexión {0}", DB.connStr));
						//  Si no nos pudimos conectar
						//  limpiamos las variables
						Sesion.DB.Database = string.Empty;
						Sesion.DB.Pwd = string.Empty;
						Sesion.DB.User = string.Empty;
						Sesion.DB.Server = string.Empty;
						DB.connStr = string.Empty;
					} // end else
				} // end if
			} // end foreach

			foreach (DataRow drFTP in rowsFTP)
			{
				if (Ping(drFTP["Server"].ToString()))
				{
					Sesion.FTP.Path = drFTP["Path"].ToString();
					Sesion.FTP.Pwd = drFTP["Pwd"].ToString();
					Sesion.FTP.User = drFTP["UserID"].ToString();
					Sesion.FTP.Server = drFTP["Server"].ToString();
					LogHelper.Logger.Error(string.Format("FTP Server {0}", Sesion.FTP.Server));
					break;
				} // end if

			}  // end foreach

			if (string.IsNullOrEmpty(DB.connStr))
			{
				throw new Exception("No se ha podido conectar con ningun servidor");
			}
		} // end ReadConfig

		public static void SetConnStr()
		{
			string connectionString = "";
			connectionString = string.Format(
						 "Data Source={0};Network Library=DBMSSOCN;Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connection Timeout=30;",
						 Sesion.DB.Server,
						 Sesion.DB.Database,
						 Sesion.DB.User,
						 Sesion.DB.Pwd
					  );

			//global::SICASv20.Properties.Settings.Default.SICASCentralConnectionString = connectionString;
			DB.connStr = connectionString;
		}

		#endregion

		#region Delegate

		public delegate void HelperDelegate();

		public static void DoMethod(HelperDelegate method, Control ucontrol)
		{
			try
			{
				ucontrol.Enabled = false;
				ucontrol.Cursor = Cursors.WaitCursor;

				method();
			}
			catch (Exception ex)
			{
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
			finally
			{
				ucontrol.Enabled = true;
				ucontrol.Cursor = Cursors.Default;
			}
		}

		public static void DoMethod(HelperDelegate method, Control ucontrol, HelperDelegate finallymethod)
		{
			try
			{
				ucontrol.Enabled = false;
				ucontrol.Cursor = Cursors.WaitCursor;

				method();
			}
			catch (Exception ex)
			{
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
			finally
			{
				ucontrol.Enabled = true;
				ucontrol.Cursor = Cursors.Default;

				finallymethod();
			}
		}

		public static void Try(HelperDelegate todo)
		{
			try
			{
				todo();
			}
			catch (Exception ex)
			{
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
		}

		public static void DoMethod(HelperDelegate method, forms.baseForm bForm)
		{
			try
			{
				bForm.Enabled = false;
				bForm.Cursor = Cursors.WaitCursor;
				method();
			}
			catch (Exception ex)
			{
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
			finally
			{
				bForm.Enabled = true;
				bForm.Cursor = Cursors.Default;
			}
		}

		public static void DoTransactions(HelperDelegate method, Form bForm)
		{
			try
			{
				DB.BeginTransaction();

				bForm.Enabled = false;
				bForm.Cursor = Cursors.WaitCursor;

				method();

				DB.CommitTransaction();
			}
			catch (Exception ex)
			{
				DB.RollBackTransaction();
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
			finally
			{
				bForm.Enabled = true;
				bForm.Cursor = Cursors.Default;
			}
		}

		public static void DoTransactions(HelperDelegate method, UserControl ucontrol)
		{
			try
			{
				DB.BeginTransaction();

				ucontrol.Enabled = false;
				ucontrol.Cursor = Cursors.WaitCursor;

				method();

				DB.CommitTransaction();
			}
			catch (Exception ex)
			{
				DB.RollBackTransaction();
				LogHelper.Logger.Error(ex.Message, ex);
				Error(ex.Message);
			}
			finally
			{
				ucontrol.Enabled = true;
				ucontrol.Cursor = Cursors.Default;
			}
		}

		public static void ThrowException(string message, params object[] args)
		{
			LogHelper.Logger.ErrorFormat(message, args);
			throw new Exception(string.Format(message, args));
		}

		#endregion

		public static void ValidInputOnlyNumbers_Keypress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		public static void ValidInputOnlyIntegers_Keypress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		public static void ValidInputOnlyChars_Keypress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		public static void AddTextBoxOnlyNumbersValidation(ref TextBox txt)
		{
			txt.KeyPress += ValidInputOnlyNumbers_Keypress;
		}

		public static void AddTextBoxesOnlyNumbersValidation(params TextBox[] textboxes)
		{
			foreach (TextBox txt in textboxes)
			{
				txt.KeyPress += ValidInputOnlyNumbers_Keypress;
			}
		}

		public static void AddTextBoxOnlyCharsValidation(ref TextBox txt)
		{
			txt.KeyPress += ValidInputOnlyChars_Keypress;
		}

		public static void AddTextBoxesOnlyCharsValidation(params TextBox[] textboxes)
		{
			foreach (TextBox txt in textboxes)
			{
				txt.KeyPress += ValidInputOnlyChars_Keypress;
			}
		}

		public static T GetValue<T>(object val)
		{
			try
			{
				if (val == null) return default(T);

				if (val.GetType() == typeof(String))
				{
					if ((string.IsNullOrEmpty((string)val)))
					{
						return default(T);
					}
				}


				object num = null;
				if (IsNumeric(val))
				{
					switch (typeof(T).ToString())
					{
						case "System.Int32":
							num = Convert.ToInt32(val);
							break;
						case "System.Decimal":
							num = Convert.ToDecimal(val);
							break;
						case "System.Double":
							num = Convert.ToDouble(val);
							break;
						case "System.Single":
							num = Convert.ToSingle(val);
							break;
						default:
							num = Convert.ToInt32(val);
							break;
					}

					return (T)num;
				}

				return (T)val;
			}
			catch (Exception ex)
			{
				ThrowException("El valor {0} no puede ser convertido en el tipo {1}\r\n\r\n" + ex.Message, val, typeof(T).ToString());
				return default(T);
			}
		}

		/// <summary>
		/// Enumeracion de reglas de validacion para controles
		/// </summary>
		public enum ValidateRule
		{
			Required = 1,
			Numeric = 2
		}

		/// <summary>
		/// Aplica opciones de validación a un control
		/// </summary>
		/// <param name="ctrl">El control a validar</param>
		/// <param name="args">Los argumentos de validacion</param>
		public static void ValidateControl(Control ctrl, params ValidateRule[] args)
		{
			if (ctrl.GetType() == typeof(TextBox))
			{
				TextBox txt = (TextBox)ctrl;

				foreach (ValidateRule rule in args)
				{
					switch (rule)
					{
						case ValidateRule.Numeric:
							if (!IsNumeric(txt.Text))
							{
								throw new Exception("El valor debe ser numérico!");
							}
							break;
						case ValidateRule.Required:
							if (txt.Text == "")
							{
								throw new Exception(String.Format("Debe capturar un valor para el control {0}", txt.Name));
							}
							break;
					}
				}
			}
			else if (ctrl.GetType() == typeof(ComboBox))
			{
				ComboBox cbo = (ComboBox)ctrl;

				foreach (ValidateRule rule in args)
				{
					switch (rule)
					{
						case ValidateRule.Required:
							if (cbo.SelectedItem == null)
							{
								throw new Exception(String.Format("Debe capturar un valor para el control {0}", cbo.Name));
							}

							if (cbo.SelectedIndex < 0)
							{
								throw new Exception(String.Format("Debe capturar un valor para el control {0}", cbo.Name));
							}
							break;
					}
				}
			}
			else if (ctrl.GetType() == typeof(CheckBox))
			{
				CheckBox check = (CheckBox)ctrl;

				foreach (ValidateRule rule in args)
				{
					switch (rule)
					{
						case ValidateRule.Required:
							if (check.CheckState == CheckState.Indeterminate)
							{
								throw new Exception(String.Format("Debe capturar un valor para el control {0}", check.Name));
							}
							break;
					}
				}
			}
			else if (ctrl.GetType() == typeof(DateTimePicker))
			{
				DateTimePicker dtpick = (DateTimePicker)ctrl;

				foreach (ValidateRule rule in args)
				{
					switch (rule)
					{
						case ValidateRule.Required:
							if (!dtpick.Checked)
							{
								throw new Exception(String.Format("Debe capturar un valor para el control {0}", dtpick.Name));
							}
							break;
					}
				}
			}
		}


		/// <summary>
		/// Devuelde la fecha y hora actual del servidor
		/// </summary>
		/// <returns>Datetime</returns>
		public static DateTime GetDate()
		{
			SICASCentralQuerysDataSetTableAdapters.Functions functions = new SICASCentralQuerysDataSetTableAdapters.Functions();
			return (DateTime)functions.GetDate();
		}

		/// <summary>
		/// Muestra un cuadro de dialogo de error
		/// </summary>
		/// <param name="msg">El mensaje a desplegar</param>
		public static void Error(string msg)
		{
			LogHelper.Logger.Error(msg);
			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Muestra un cuadro de dialogo informativo
		/// </summary>
		/// <param name="msg">El mensaje a desplegar</param>
		public static void Info(string msg)
		{
			LogHelper.Logger.Info(msg);
			MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Devuelve un cuadro de dialogo de confirmacion
		/// </summary>
		/// <param name="msg">El mensaje a desplegar</param>
		/// <returns>DialogResult</returns>
		public static DialogResult Confirm(string msg)
		{
			LogHelper.Logger.Info(msg);
			return MessageBox.Show(msg, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		/// <summary>
		/// Agrega espaciones en blanco al final de una cadena
		/// </summary>
		/// <param name="str">La cadena a modificar</param>
		/// <param name="spaces">La cantidad de espacios en blanco a agregar</param>
		/// <returns>string</returns>
		public static string AddSpaces(string str, int spaces)
		{
			string blankspaces = "";
			int i;
			for (i = 0; i <= spaces; i++)
			{
				blankspaces += " ";
			}
			return blankspaces + str + blankspaces;
		}

		/// <summary>
		/// Realiza la sumatoria de todos los valores de una columna en un DataGridView
		/// </summary>
		/// <param name="dgv">El DataGridView sobre el cual se realizará la operación</param>
		/// <param name="column">La columna a sumar</param>
		/// <returns></returns>
		public static decimal DGVSum(DataGridView dgv, string column)
		{
			decimal ret = 0;

			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.Cells[column].Value != null &&
					   !Convert.IsDBNull(row.Cells[column]))
				{
					ret += Convert.ToDecimal(row.Cells[column].Value);
				}
			}

			return ret;
		}

		/// <summary>
		/// Pone en blanco los controles de tipo TextBox pertenecientes al control especificado
		/// </summary>
		/// <param name="ctrl">El control al que se le limpiaran las cajas de texto</param>
		public static void ClearControl(Control ctrl)
		{
			foreach (Control c in ctrl.Controls)
			{
				if (c.GetType() == typeof(System.Windows.Forms.TextBox))
				{
					c.Text = "";
				}

				if (c.GetType() == typeof(System.Windows.Forms.ComboBox))
				{
					ComboBox cbo = (ComboBox)c;
					try
					{
						cbo.SelectedIndex = 0;
					}
					catch
					{
						cbo.SelectedIndex = -1;
					}
				}

				if (c.GetType() == typeof(System.Windows.Forms.ListBox))
				{
					ListBox list = (ListBox)c;
					if (!IsNullOrEmpty(list.DataSource))
					{
						if (list.DataSource.GetType() != typeof(System.Windows.Forms.BindingSource))
						{
							list.DataSource = null;
							list.Items.Clear();
						}
					}
				}

				if (c.GetType() == typeof(System.Windows.Forms.NumericUpDown))
				{
					NumericUpDown nud = (NumericUpDown)c;
					nud.Value = nud.Minimum;
				}

				//if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
				//{
				//    DataGridView dgv = (DataGridView)c;
				//    if (!IsNullOrEmpty(dgv.DataSource))
				//    {
				//        dgv.DataSource = null;
				//    }
				//}

				ClearControl(c);
			}
		}

		/// <summary>
		/// Pone en blanco los controles de tipo TextBox pertenecientes al control especificado
		/// </summary>
		/// <param name="ctrl">El control al que se le limpiaran las cajas de texto</param>
		public static void ClearControlExcept(Control ctrl, string nameexcept)
		{
			foreach (Control c in ctrl.Controls)
			{
				if (c.Name == nameexcept)
				{
					continue;
				}

				if (c.GetType() == typeof(System.Windows.Forms.TextBox))
				{
					c.Text = "";
				}

				if (c.GetType() == typeof(System.Windows.Forms.ComboBox))
				{
					ComboBox cbo = (ComboBox)c;
					cbo.SelectedIndex = 0;
				}

				if (c.GetType() == typeof(System.Windows.Forms.ListBox))
				{
					ListBox list = (ListBox)c;
					if (!IsNullOrEmpty(list.DataSource))
					{
						if (list.DataSource.GetType() != typeof(System.Windows.Forms.BindingSource))
						{
							list.DataSource = null;
							list.Items.Clear();
						}
					}
				}

				//if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
				//{
				//    DataGridView dgv = (DataGridView)c;
				//    if (!IsNullOrEmpty(dgv.DataSource))
				//    {
				//        dgv.DataSource = null;
				//    }
				//}

				ClearControl(c);
			}
		}

		public static void ClearDataSources(Control ctrl)
		{
			foreach (Control c in ctrl.Controls)
			{
				if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
				{
					DataGridView dgv = (DataGridView)c;
					if (!IsNullOrEmpty(dgv.DataSource))
					{
						dgv.DataSource = null;
					}
				}

				ClearDataSources(c);
			}
		}

		/// <summary>
		/// Establece validaciones correspondientes con la base de datos,
		/// para los controles pertenecientes a un control contenedor,
		/// con respecto a una tabla especifica en la base de datos
		/// </summary>
		/// <param name="container">El control contenedor</param>
		/// <param name="tableName">El nombre de la tabla en la base de datos</param>
		public static void SetContainerDBValidations(Control container, string tableName)
		{
			List<Entities.InformationSchemaColumns> cols = Entities.InformationSchemaColumns.Get(tableName);

			foreach (Control ctrl in container.Controls)
			{
				SetControlValidations(ctrl, cols);
			}
		}

		public static void SetControlValidations(Control control, List<Entities.InformationSchemaColumns> cols)
		{
			SetValidationProperties(control, cols);

			foreach (Control ctrl in control.Controls)
			{
				SetControlValidations(ctrl, cols);
			}
		}

		public static void SetValidationProperties(Control ctrl, List<Entities.InformationSchemaColumns> cols)
		{
			if (ctrl.DataBindings.Count > 0)
			{
				foreach (Entities.InformationSchemaColumns colInfo in cols)
				{
					if (ctrl.DataBindings[0].BindingMemberInfo.BindingField == colInfo.COLUMN_NAME)
					{
						ctrl.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
						ctrl.TabIndex = colInfo.ORDINAL_POSITION;

						if (colInfo.DATA_TYPE.Contains("char"))
						{
							if (ctrl.GetType() == typeof(TextBox))
							{
								((TextBox)ctrl).MaxLength = colInfo.CHARACTER_MAXIMUM_LENGTH.Value;
								//((TextBox)ctrl).Width = colInfo.CHARACTER_MAXIMUM_LENGTH.Value * 9;
							}
						}

						if (colInfo.DATA_TYPE.Contains("int"))
						{
							if (ctrl.GetType() == typeof(TextBox))
							{
								((TextBox)ctrl).KeyPress += AppHelper.ValidInputOnlyIntegers_Keypress;
								((TextBox)ctrl).MaxLength = 11;
							}
						}

						if (colInfo.DATA_TYPE.Contains("money"))
						{
							if (ctrl.GetType() == typeof(TextBox))
							{
								((TextBox)ctrl).KeyPress += AppHelper.ValidInputOnlyNumbers_Keypress;
							}
						}

						//if (colInfo.IS_NULLABLE.ToUpper().Trim() == "NO")
						//{
						//    AppHelper.ValidateControl(ctrl, ValidateRule.Required);
						//}
					}
				}
			}
		}

		private static void SetIcon(Form form)
		{
			form.Icon = new Icon(AppHelper.IconFile);
		}

		/// <summary>
		/// Aplica estilos a los controles, de manera recursiva
		/// </summary>
		/// <param name="ctrl">El control al que se aplicaran los estilos</param>
		public static void SetStylish(Control ctrl)
		{
			if (ctrl.GetType() == typeof(System.Windows.Forms.Form))
			{
				SetIcon((Form)ctrl);
			}

			if (ctrl.GetType() == typeof(System.Windows.Forms.DataGridView))
			{
				SetDataGridViewProperties((DataGridView)ctrl);
			}

			if (ctrl.GetType() == typeof(System.Windows.Forms.Label))
			{
				Strip_IDLabel((Label)ctrl);
			}

			//if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
			//{
			//    GroupBox gbox = (GroupBox)c;
			//    gbox.Paint += GroupBox_OnPaint;
			//}

			if (ctrl.GetType() == typeof(System.Windows.Forms.TextBox))
			{
				SetTextBoxProperties((TextBox)ctrl);
			}

			foreach (Control c in ctrl.Controls)
			{
				SetStylish(c);
			}
		}

		/// <summary>
		/// Elimina la cadena " ID" del texto de un control Label
		/// </summary>
		/// <param name="lbl">El control label que será modificado</param>
		public static void Strip_IDLabel(Label lbl)
		{
			lbl.Text = lbl.Text.Replace(" ID", "");
		}

		/// <summary>
		/// Configura las propiedades estandar de la aplicación a un control DataGridView
		/// </summary>
		/// <param name="dgv">Control <remarks>DataGridView</remarks> que será configurado</param>
		public static void SetDataGridViewProperties(DataGridView dgv)
		{
			dgv.AutoGenerateColumns = false;
			dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.GridColor = System.Drawing.Color.Gainsboro;
			dgv.RowHeadersVisible = false;
			dgv.AllowUserToResizeRows = false;
		}

		public static void SetTextBoxProperties(TextBox txt)
		{
			txt.CharacterCasing = CharacterCasing.Upper;
		}

		//groupBox1.Paint += PaintBorderlessGroupBox;

		public static Color GBoxColor = Color.Navy;

		public static void GroupBox_OnPaint(object sender, PaintEventArgs e)
		{
			GroupBox box = (GroupBox)sender;
			//e.Graphics.Clear(Color.Transparent);
			//e.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
			Size tSize = TextRenderer.MeasureText(box.Text, box.Font);

			Rectangle borderRect = e.ClipRectangle;

			borderRect.Y += tSize.Height / 2;

			borderRect.Height -= tSize.Height / 2;

			ControlPaint.DrawBorder(e.Graphics, borderRect, GBoxColor, ButtonBorderStyle.Solid);

			Rectangle textRect = e.ClipRectangle;

			textRect.X += 6;

			textRect.Width = tSize.Width;

			textRect.Height = tSize.Height;

			e.Graphics.FillRectangle(new SolidBrush(box.BackColor), textRect);

			e.Graphics.DrawString(box.Text, box.Font, new SolidBrush(box.ForeColor), textRect);
		}


		/// <summary>
		/// Regresa una cadena con formato "N2"
		/// </summary>
		/// <param name="valor">Valor a aplicar el formato</param>
		/// <returns>string</returns>
		public static string N2(object valor)
		{
			return string.Format("{0:N2}", valor);
		}


		/// <summary>
		/// Determina si una cadena es numerica
		/// </summary>
		/// <param name="valor">El valor a evaluar</param>
		/// <returns>bool</returns>
		public static bool IsNumeric(object valor)
		{
			Decimal d;
			return Decimal.TryParse(valor.ToString(), out d);
		}

		/// <summary>
		/// Evalua una expresion y si esta es nula, regresa un reemplazo
		/// </summary>
		/// <param name="expression">La expresion a evaluar</param>
		/// <param name="replacement">El reemplazo a retornar</param>
		/// <returns>object</returns>
		public static object IsNull(object expression, object replacement)
		{
			if (expression == null || Convert.IsDBNull(expression))
			{
				return replacement;
			}
			else
			{
				if (expression.GetType() == typeof(string))
				{
					if ((string)expression == "" || (string)expression == string.Empty)
					{
						return replacement;
					}
				}
				return expression;
			}
		}

		public static bool IsNullOrEmpty(object expression)
		{
			if (expression == null || Convert.IsDBNull(expression))
			{
				return true;
			}
			else
			{
				if (expression.GetType() == typeof(string))
				{
					if ((string)expression == "" || (string)expression == string.Empty)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Regresa un entero nulable a partir de una expresión evaluada
		/// </summary>
		/// <param name="expression">La expresión a evaluar</param>
		/// <returns>int?</returns>
		public static int? GetNullable(object expression)
		{
			if (expression == null || Convert.IsDBNull(expression))
			{
				return null;
			}
			else
			{
				if (expression.GetType() == typeof(string))
				{
					if (string.IsNullOrEmpty((string)expression))
					{
						return null;
					}
				}
				return Convert.ToInt32(expression);
			}
		}

		public static string NewAccountMailTemplate = "Estimado {0}:\r\n" +
		"\r\n" +
		"Se ha creado una cuenta para su uso personal en el sistema \"SICAS\".\r\n" +
		"Su nombre de usuario es: {1}\r\n" +
		"Su contraseña es: {2}\r\n" +
		"\r\n" +
		"Si aun no tiene instalado el sistema o no tiene acceso, favor de \r\n" +
		"comunicarse con el administrador del sistema.\r\n" +
		"\r\n" +
		"Este mensaje a sido generado automáticamente. Por favor, no lo responda.\r\n" +
		"Gracias.";

		/// <summary>
		/// Envia un mensaje a nuevos usuarios
		/// </summary>
		/// <param name="to">A quien va dirijido</param>
		/// <param name="name">Nombre</param>
		/// <param name="username">Nombre de usuario</param>
		/// <param name="pwd">Constraseña</param>
		public static void SendNewAccountMail(string to, string name, string username, string pwd)
		{
			//  Pasar los parámetros al template
			string body = string.Format(NewAccountMailTemplate, name, username, pwd);

			//  Enviar el correo
			SendEmail("sicas@casco.com.mx", to, "Nueva cuenta de SICAS", body, false);
		}

		/// <summary>
		/// Realiza el envio de un email
		/// </summary>
		/// <param name="from">Remitente</param>
		/// <param name="to">A quien va dirijido</param>
		/// <param name="title">Titulo del mensaje</param>
		/// <param name="body">Cuerpo del mensaje</param>
		/// <param name="isHTML">Especifica si es HTML</param>
		public static void SendEmail(string from, string to,
		    string title, string body, bool isHTML)
		{
			System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

			correo.From = new System.Net.Mail.MailAddress(from);
			correo.To.Add(to);
			correo.Subject = title;
			correo.Body = body;
			correo.IsBodyHtml = isHTML;
			correo.Priority = System.Net.Mail.MailPriority.Normal;

			System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.casco.com.mx");
			smtp.Port = 587;
			smtp.Credentials = new System.Net.NetworkCredential("sicas@casco.com.mx", "Tr1nyt1?");

			smtp.Send(correo);
		}

		/// <summary>
		/// Realiza el envio de un email
		/// </summary>
		/// <param name="from">Remitente</param>
		/// <param name="to">A quien va dirijido</param>
		/// <param name="title">Titulo del mensaje</param>
		/// <param name="body">Cuerpo del mensaje</param>
		/// <param name="attach">Datos adjuntos</param>
		public static void SendEmail(string from, string to,
		    string title, string body, string attach)
		{
			System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

			correo.From = new System.Net.Mail.MailAddress(from);
			correo.To.Add(to);
			correo.Subject = title;
			correo.Body = body;
			correo.IsBodyHtml = true;
			correo.Priority = System.Net.Mail.MailPriority.Normal;
			correo.Attachments.Add(new System.Net.Mail.Attachment(attach));

			System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.casco.com.mx");
			smtp.Port = 587;
			smtp.Credentials = new System.Net.NetworkCredential("sicas@casco.com.mx", "casco");

			smtp.Send(correo);
		}

		/// <summary>
		/// Realiza la carga de un archivo a una ubicación remota por medio del protocolo FTP
		/// </summary>
		/// <param name="filename">El nombre del archivo</param>
		/// <param name="destination">El destino del archivo</param>
		/// <param name="ftpUserID">ID de usuario FTP</param>
		/// <param name="ftpPassword">La contraseña del usuario</param>
		public static void FTPUpload(string filename, string destination, string ftpUserID, string ftpPassword)
		{
			FileInfo fileInf = new FileInfo(filename);
			string uri = "ftp://" + destination;
			FtpWebRequest reqFTP;

			reqFTP = (FtpWebRequest)FtpWebRequest.Create
				    (new Uri(uri));
			reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
			reqFTP.KeepAlive = false;
			reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
			reqFTP.UseBinary = true;
			reqFTP.ContentLength = fileInf.Length;
			reqFTP.UsePassive = false;
			int buffLength = 2048;
			byte[] buff = new byte[buffLength];
			int contentLen;

			FileStream fs = fileInf.OpenRead();

			try
			{
				Stream strm = reqFTP.GetRequestStream();
				contentLen = fs.Read(buff, 0, buffLength);

				while (contentLen != 0)
				{
					strm.Write(buff, 0, contentLen);
					contentLen = fs.Read(buff, 0, buffLength);
				}

				strm.Close();
				fs.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Upload Error");
			}
		}

		public static long FTP_FILESIZE = 0;
		public static int FTP_PERCENT = 0;
		public static bool FTP_ISBUSY = false;

		public static void FTPDownload(string ftpSource, string localDest, string ftpUserID, string ftpPassword)
		{
			FTP_ISBUSY = true;
			try
			{
				FtpWebRequest reqFTP;
				FileStream outputStream = new FileStream(localDest, FileMode.Create);

				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpSource));
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(ftpUserID,
												    ftpPassword);
				reqFTP.UsePassive = false;

				reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				FTP_FILESIZE = response.ContentLength;

				//  Volver a crear
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpSource));
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(ftpUserID,
												    ftpPassword);
				reqFTP.UsePassive = false;

				reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
				response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();

				int bufferSize = 2048;
				int readCount;
				byte[] buffer = new byte[bufferSize];

				readCount = ftpStream.Read(buffer, 0, bufferSize);

				long cont = readCount;

				while (readCount > 0)
				{
					outputStream.Write(buffer, 0, readCount);
					readCount = ftpStream.Read(buffer, 0, bufferSize);

					FTP_PERCENT = Convert.ToInt32((cont * 100) / Math.Abs(FTP_FILESIZE));
					cont += readCount;

					if (FTP_PERCENT > 0)
					{
						Console.WriteLine(String.Format("{0} * 100 / {1} = {2}", cont, FTP_FILESIZE, FTP_PERCENT));
					}
					else
					{
						Console.WriteLine("MENOR QUE 0");
					}
				}

				ftpStream.Close();
				outputStream.Close();
				response.Close();
			}
			finally
			{
				FTP_ISBUSY = false;
				FTP_FILESIZE = 0;
				FTP_PERCENT = 0;
			}
		}

		public static string HTTPDownload(string url, string user, string pwd)
		{
			WebClient wc = new WebClient();

			if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pwd)) wc.Credentials = new NetworkCredential(user, pwd);

			return wc.DownloadString(url);
		}

		public static void HTTPDownload(string url, string destination, string user, string pwd)
		{
			WebClient wc = new WebClient();

			wc.Credentials = new NetworkCredential(user, pwd);
			wc.DownloadFile(url, destination);
		}

		public static void HTTPUpload(string filePath, string urlDest, string user, string pwd)
		{
			WebClient wc = new WebClient();

			wc.Credentials = new NetworkCredential(user, pwd);
			wc.UploadFile(urlDest, filePath);
		}

		/// <summary>
		/// Exporta un reporte local a una ubicación en el archivo
		/// </summary>
		/// <param name="localReport">EL reporte a exportar</param>
		/// <returns>string</returns>
		public static string ExportReport(LocalReport localReport)
		{
			Warning[] warnings;
			string[] streamids;
			string mimeType;
			string encoding;
			string filenameExtension;

			//"Excel" or "Image" or "PDF"
			byte[] bytes = localReport.Render(
			    "Image", null, out mimeType, out encoding, out filenameExtension,
				out streamids, out warnings);

			string filename = Path.Combine(Path.GetTempPath(), "report.emf");

			using (FileStream fs = new FileStream(filename, FileMode.Create))
			{
				fs.Write(bytes, 0, bytes.Length);
			}

			return filename;
		}

		public static void PrintReport(LocalReport report)
		{
			fileToPrint = ExportReport(report);

			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(PrintPage);
			pd.Print();
		}

		public static void PrintReport(LocalReport report, string docname)
		{
			fileToPrint = ExportReport(report);

			PrintDocument pd = new PrintDocument();
			pd.DocumentName = docname;
			pd.PrintPage += new PrintPageEventHandler(PrintPage);
			pd.Print();
		}

		private static string fileToPrint;
		private static LocalReport _TicketReport;
		public static LocalReport TicketReport
		{
			get { return _TicketReport; }
			set { _TicketReport = value; }
		}

		public static void PrintTicket()
		{
			Warning[] warnings;
			string[] streamids;
			string mimeType;
			string encoding;
			string filenameExtension;
			string deviceInfo = "<DeviceInfo>" +
			"  <OutputFormat>Image</OutputFormat>" +
			"  <PageWidth>" + TicketReport.GetDefaultPageSettings().PaperSize.Width.ToString() + "cm</PageWidth>" +
			"  <PageHeight>" + TicketReport.GetDefaultPageSettings().PaperSize.Height.ToString() + "cm</PageHeight>" +
			"  <MarginTop>" + TicketReport.GetDefaultPageSettings().Margins.Top.ToString() + "cm</MarginTop>" +
			"  <MarginLeft>" + TicketReport.GetDefaultPageSettings().Margins.Left.ToString() + "cm</MarginLeft>" +
			"  <MarginRight>" + TicketReport.GetDefaultPageSettings().Margins.Right.ToString() + "cm</MarginRight>" +
			"  <MarginBottom>" + TicketReport.GetDefaultPageSettings().Margins.Bottom.ToString() + "cm</MarginBottom>" +
			"</DeviceInfo>";

			// "Excel" or "Image" or "PDF"
			byte[] bytes = TicketReport.Render(
			    "Image", null, out mimeType, out encoding, out filenameExtension,
				   out streamids, out warnings);

			fileToPrint = Path.Combine(Path.GetTempPath(), "ticket.tiff");

			using (FileStream fs = new FileStream(fileToPrint, FileMode.Create))
			{
				fs.Write(bytes, 0, bytes.Length);
			}

			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(PrintPage);
			pd.Print();
		}

		public static void PrintTicketPort(string port)
		{
			Warning[] warnings;
			string[] streamids;
			string mimeType;
			string encoding;
			string filenameExtension;
			string deviceInfo = "<DeviceInfo>" +
			"  <OutputFormat>Image</OutputFormat>" +
			"  <PageWidth>" + TicketReport.GetDefaultPageSettings().PaperSize.Width.ToString() + "cm</PageWidth>" +
			"  <PageHeight>" + TicketReport.GetDefaultPageSettings().PaperSize.Height.ToString() + "cm</PageHeight>" +
			"  <MarginTop>" + TicketReport.GetDefaultPageSettings().Margins.Top.ToString() + "cm</MarginTop>" +
			"  <MarginLeft>" + TicketReport.GetDefaultPageSettings().Margins.Left.ToString() + "cm</MarginLeft>" +
			"  <MarginRight>" + TicketReport.GetDefaultPageSettings().Margins.Right.ToString() + "cm</MarginRight>" +
			"  <MarginBottom>" + TicketReport.GetDefaultPageSettings().Margins.Bottom.ToString() + "cm</MarginBottom>" +
			"</DeviceInfo>";

			// "Excel" or "Image" or "PDF"
			byte[] bytes = TicketReport.Render(
			    "Image", null, out mimeType, out encoding, out filenameExtension,
				   out streamids, out warnings);

			fileToPrint = Path.Combine(Path.GetTempPath(), "ticket.tiff");

			using (FileStream fs = new FileStream(fileToPrint, FileMode.Create))
			{
				fs.Write(bytes, 0, bytes.Length);
			}

			string filename = System.IO.Path.GetTempFileName();

			PrintDocument pd = new PrintDocument();
			pd.PrinterSettings.PrintToFile = true;
			pd.PrinterSettings.PrintFileName = filename;
			pd.PrintPage += new PrintPageEventHandler(PrintPage);
			pd.Print();

			File.Copy(filename, port);
		}

		private static void PrintPage(object sender, PrintPageEventArgs ev)
		{
			//Metafile pageImage = new Metafile(fileToPrint);
			Bitmap pageImage = new Bitmap(fileToPrint);
			ev.Graphics.DrawImage(pageImage, ev.PageBounds);
		}

		/// <summary>
		/// Clase que permite exportar el contenido de un DataGridView
		/// </summary>
		public class GridExport
		{

			private const string TAB = "    ";
			private const string BR = Constants.vbCrLf;

			public static object IfNull(object obj, object ret)
			{
				if ((obj == null) | Information.IsDBNull(obj))
				{
					return ret;
				}
				else
				{
					return obj;
				}
			}

			public static void GridToXls(ref DataGridView dgv, string ruta)
			{

				StringBuilder sb = new StringBuilder();

				sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"1\" rules=\"rows\">" + BR);

				string cols = string.Empty;

				foreach (DataGridViewColumn col in dgv.Columns)
				{
					if (col.Visible == true && col.IsDataBound)
					{
						cols += Th(col.HeaderText);
					}
				}

				sb.Append(Tr(cols));

				foreach (DataGridViewRow row in dgv.Rows)
				{
					cols = string.Empty;
					foreach (DataGridViewCell cel in row.Cells)
					{
						if (dgv.Columns[cel.ColumnIndex].Visible == true && dgv.Columns[cel.ColumnIndex].IsDataBound)
						{
							cols += Td(AppHelper.IsNull(cel.Value, "").ToString(), cel.Style.ForeColor);
						}
					}
					sb.Append(Tr(cols));
				}

				sb.Append(BR + "</table>");

				StreamWriter sw = new StreamWriter(ruta, false);
				sw.Write(sb.ToString());
				sw.Flush();
				sw.Close();

				//Info("Archivo creado");
				Process.Start(ruta);
			}

			private static string Th(object dato)
			{
				return "<th>" + Convert.ToString(dato) + "</th>";
			}

			private static string Td(object dato)
			{
				return "<td>" + Convert.ToString(dato) + "</td>";
			}

			private static string Td(object dato, Color color)
			{
				return "<td style='color: " + System.Drawing.ColorTranslator.ToHtml(color) + "'>" + Convert.ToString(dato) + "</td>";
			}

			private static string Tr(string celdas)
			{
				return "<tr>" + celdas + "</tr>";
			}

		}

		public static DateTime FechaFinal(DateTime fecha)
		{
			return fecha.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
		}

		public static DateTime FechaInicial(DateTime fecha)
		{
			return fecha.Date;
		}

		public static SaveFileDialog ExportSaveFileDialog;

		public static void ExportDataGridViewExcel(DataGridView dgv, Control controlparent)
		{
			if (ExportSaveFileDialog == null)
			{
				ExportSaveFileDialog = new SaveFileDialog();
			}

			DoMethod(delegate
			{
				ExportSaveFileDialog.Title = "Guarde un archivo de excel";
				ExportSaveFileDialog.Filter = "Excel Files|*.xls";
				if (ExportSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					if (ExportSaveFileDialog.FileName != "")
					{
						string ruta = ExportSaveFileDialog.FileName;
						GridExport.GridToXls(ref dgv, ruta);
					}
				}
			}, controlparent);
		}

		#region RelacionDeValoresYColores
		public static Dictionary<object, Color> RelacionValoresColores
		    = new Dictionary<object, Color>() 
            {
                { 1, Color.FromArgb(255,153,153) },
                { 2, Color.FromArgb(255,204,153) },
                { 3, Color.FromArgb(255,255,153) },
                { 4, Color.FromArgb(204,255,153) },
                { 5, Color.FromArgb(153,204,255) },
                { 6, Color.FromArgb(153,153,255) },
                { 7, Color.FromArgb(153,255,204) },
                { 8, Color.FromArgb(153,255,255) },
                { 9, Color.FromArgb(228,255,148) },
                { 10, Color.FromArgb(255,223,128) }
            };

		public static Dictionary<object, Color> RelacionColoresEstatusConductores
		    = new Dictionary<object, Color>() 
            {
                { "ACTIVO", Color.FromArgb(255,255,255) },
                { "TERMINADO EN FECHA SIN ADEUDO", Color.FromArgb(255,153,153) },
                { 7, Color.FromArgb(255,204,153) },
                { 8, Color.FromArgb(255,255,153) },
                { 9, Color.FromArgb(204,255,153) },
                { 10, Color.FromArgb(153,204,255) },
                { 11, Color.FromArgb(153,153,255) },
                { 12, Color.FromArgb(153,255,204) }
            };

		public static Dictionary<object, Color> RelacionColoresEstatusContratos
		    = new Dictionary<object, Color>() 
            {
                { "ACTIVO", Color.FromArgb(255,255,255) },
                { "TERMINADO EN FECHA SIN ADEUDO", Color.FromArgb(255,153,153) },
                { "TERMINADO EN FECHA CON ADEUDO", Color.FromArgb(255,204,153) },
                { "TERMINADO PREMATURAMENTE SIN ADEUDO", Color.FromArgb(255,255,153) },
                { "TERMINADO PREMATURAMENTE CON ADEUDO", Color.FromArgb(204,255,153) }
            };
		#endregion

		/// <summary>
		/// Cambia de color los renglones de un control DataGridView ligado a datos,
		/// a partir de un nombre de propiedad de datos enlazados y una relación de 
		/// valores y colores
		/// </summary>
		/// <param name="datagridview">El control datagridview a modificar</param>
		/// <param name="datapropertyname">El nombre de la propiedad de datos objetivo</param>
		/// <param name="colors">La relación de valores y colores</param>        
		public static void ColorDataGridViewRows(ref DataGridView datagridview, string datapropertyname, Dictionary<object, Color> colors)
		{
			//  Si no está ligado a datos, salir del procedimiento
			if (datagridview.DataSource == null) return;
			if (datagridview.Rows.Count == 0) return;

			//  Variable "cellindex", el indice de celdas de la columna objetivo
			int cellindex = 0;

			//  Variable "val", el valor contra el que será comparado el listado
			//  de valores y colores referido
			object val = null;

			//  Variable "propExiste", usada para referir si existe la propiedad ligada
			//  a datos buscada
			bool propExiste = false;

			//  Buscarmos la columna con el DataPropertyName referido
			foreach (DataGridViewColumn col in datagridview.Columns)
			{
				if (col.DataPropertyName == datapropertyname)
				{
					//  Existe
					//  Obtenemos el índice
					cellindex = col.Index;
					//  Pasamos "true" a la variable "propExiste"
					propExiste = true;
					//  Salimos del ciclo
					break;
				}
			}

			//  Si existe el DataPropertName en la lista de columnas
			if (propExiste)
			{
				//  Recorremos la colección de "DataGridViewRows"
				foreach (DataGridViewRow row in datagridview.Rows)
				{
					//  Obtenermos el valor de la celda
					//  lo guardamos en la variable "val"
					val = row.Cells[cellindex].Value;

					//  Recorremos la relación de valores y colores
					foreach (KeyValuePair<object, Color> par in colors)
					{
						//  Comparamos el valor obtenido con el valor del listado
						//  en este caso es "Key"
						if (val.Equals(par.Key))
						{
							//  Si son iguales
							//  asignamos el color a la propiedad "BackColor"
							//  para todas las celdas del renglon
							row.DefaultCellStyle.BackColor = par.Value;
							//  Salimos del ciclo
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Cambia de color los renglones de un control DataGridView ligado a datos,
		/// a partir de un nombre de propiedad de datos enlazados, determinando los colores
		/// de forma automática
		/// </summary>
		/// <param name="datagridview">El control datagridview a modificar</param>
		/// <param name="datapropertyname">El nombre de la propiedad de datos objetivo</param> 
		public static void AutoColorDataGridViewRows(ref DataGridView datagridview, string datapropertyname)
		{
			//  Si no está ligado a datos, salir del procedimiento
			if (datagridview.DataSource == null) return;

			//  Variable "cellindex", el indice de celdas de la columna objetivo
			int cellindex = 0;

			//  Variable "val", el valor contra el que será comparado el listado
			//  de valores y colores referido
			object val = null;

			//  Variable "propExiste", usada para referir si existe la propiedad ligada
			//  a datos buscada
			bool propExiste = false;

			//  El listado de valores
			Dictionary<object, Color> valorescolores
			= new Dictionary<object, Color>();

			//  Variable dinámica para contener el color
			//  para asignar al DataGridViewRow
			Color color;

			//  Buscarmos la columna con el DataPropertyName referido
			foreach (DataGridViewColumn col in datagridview.Columns)
			{
				if (col.DataPropertyName == datapropertyname)
				{
					//  Existe
					//  Obtenemos el índice
					cellindex = col.Index;
					//  Pasamos "true" a la variable "propExiste"
					propExiste = true;
					//  Salimos del ciclo
					break;
				}
			}

			//  Si existe el DataPropertName en la lista de columnas
			if (propExiste)
			{
				//  Recorremos la colección de "DataGridViewRows"
				foreach (DataGridViewRow row in datagridview.Rows)
				{
					//  Obtenermos el valor de la celda
					//  lo guardamos en la variable "val"
					val = row.Cells[cellindex].Value;

					// Si se encuentra en la lista, obtenemos su color
					if (valorescolores.ContainsKey(val))
					{
						color = valorescolores[val];
					}
					else
					{
						// Si no, lo agregamos y obtenemos su color
						color = RelacionValoresColores[(valorescolores.Count + 1)];
						valorescolores[val] = color;
					}

					//  asignamos el color a la propiedad "BackColor"
					//  para todas las celdas del renglon
					row.DefaultCellStyle.BackColor = color;
				}
			}
		}

		/// <summary>
		/// Asistente para auditar performance de operaciones
		/// midiendo el tiempo que se necesita para realizarlas
		/// </summary>
		public static class Audit
		{
			#region Variables
			private static DateTime FechaInicial;
			private static DateTime FechaFinal;
			private static TimeSpan Tiempo;
			private static string NombreProcedimiento;
			private static string LogFile =
			    System.IO.Path.Combine(System.Environment.CurrentDirectory, "auditlog.log");
			#endregion

			#region Methodos
			/// <summary>
			/// Calcula el tiempo que tomó llevar a cabo la operación auditada
			/// </summary>
			private static void Calcular()
			{
				Tiempo = FechaFinal.Subtract(FechaInicial);
			}

			/// <summary>
			/// Inicia el conteo de tiempo para la operación
			/// </summary>
			public static void Inicia()
			{
				FechaInicial = DateTime.Now;
			}

			/// <summary>
			/// Inicia el conteo de tiempo para la operación
			/// </summary>
			/// <param name="nombreProc">El nombre del procedimiento a auditar</param>
			public static void Inicia(string nombreProc)
			{
				NombreProcedimiento = nombreProc;
				FechaInicial = DateTime.Now;
			}

			/// <summary>
			/// Indica que termina la operación, se calcula el tiempo
			/// y se guardan los datos
			/// </summary>
			public static void Finaliza()
			{
				FechaFinal = DateTime.Now;
				Calcular();
				Log();
			}

			/// <summary>
			/// Registra la operación en un archivo de registro
			/// </summary>
			private static void Log()
			{
				StreamWriter sw =
				    new StreamWriter(
					   LogFile,
					   true
				    );

				sw.WriteLine("-----------------------");
				sw.WriteLine("Proc:\t" + NombreProcedimiento);
				sw.WriteLine("Ms:\t" + Math.Round(Tiempo.TotalMilliseconds, 0).ToString());
				sw.Flush();
				sw.Close();
			}
			#endregion
		}

		public class Formulario
		{
			private string _key;
			public string Key
			{
				get { return _key; }
				set { _key = value; }
			}

			private forms.baseForm _forma;
			public forms.baseForm Forma
			{
				get { return _forma; }
				set { _forma = value; }
			}

			private string _formClass;
			public string FormClass
			{
				get { return _formClass; }
				set { _formClass = value; }
			}

			public Formulario(string key, forms.baseForm forma, string formClass)
			{
				Key = key;
				Forma = forma;
				FormClass = formClass;
			}
		}

		public class Formularios : IEnumerable
		{
			private Collection c = new Collection();

			public void Add(Formulario formulario)
			{
				c.Add(formulario);
			}

			public void Remove(Formulario formulario)
			{
				int itemCount = 0;
				for (itemCount = 1; itemCount <= c.Count; itemCount++)
				{
					if (object.ReferenceEquals(formulario, c[itemCount]))
					{
						c.Remove(itemCount);
						break;
					}
				}
			}

			public void Clear()
			{
				c.Clear();
			}

			public Formulario Item(int index)
			{
				return (Formulario)c[index];
			}

			public int IndexOf(Formulario formulario)
			{
				int itemCount = 0;
				for (itemCount = 1; itemCount <= c.Count; itemCount++)
				{
					if (object.ReferenceEquals(formulario, c[itemCount]))
					{
						return itemCount;
					}
				}
				return -1;
			}

			public Formulario Find(string key)
			{
				int itemCount = 0;
				for (itemCount = 1; itemCount <= c.Count; itemCount++)
				{
					Formulario f = (Formulario)c[itemCount];
					if (f.Key == key)
					{
						return f;
					}
				}
				return null;
			}

			public int Count
			{
				get { return c.Count; }
			}

			public System.Collections.IEnumerator GetEnumerator()
			{
				return c.GetEnumerator();
			}

		}

		public class NumeroALetra
		{

			//Dim ObjNomNum As New ClsNomNum

			bool PrintNum;
			private string Unidad(int Numero)
			{
				string p_Unidad = "";
				switch (Numero)
				{
					case 1:
						p_Unidad = "Uno";
						break;
					case 2:
						p_Unidad = "Dos";
						break;
					case 3:
						p_Unidad = "Tres";
						break;
					case 4:
						p_Unidad = "Cuatro";
						break;
					case 5:
						p_Unidad = "Cinco";
						break;
					case 6:
						p_Unidad = "Seis";
						break;
					case 7:
						p_Unidad = "Siete";
						break;
					case 8:
						p_Unidad = "Ocho";
						break;
					case 9:
						p_Unidad = "Nueve";
						break;
					case 0:
						p_Unidad = "Cero";
						break;
				}
				return Strings.UCase(p_Unidad);
			}

			private string Decena(int Numero, int p_Unidad)
			{
				string functionReturnValue = null;
				string Descena = "";
				PrintNum = false;

				switch (Numero)
				{
					case 1:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Diez";
								break;
							case 1:
								Descena = "Once";
								break;
							case 2:
								Descena = "Doce";
								break;
							case 3:
								Descena = "Trece";
								break;
							case 4:
								Descena = "Catorce";
								break;
							case 5:
								Descena = "Quince";
								break;
							default:
								Descena = "Diez y ";
								PrintNum = true;

								break;
						}
						break;
					case 2:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Veinte ";
								break;
							default:
								Descena = "Veinti";
								PrintNum = true;

								break;
						}
						break;
					case 3:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Treinta ";
								break;
							default:
								Descena = "Treinta y ";
								PrintNum = true;
								break;
						}
						break;
					case 4:

						switch (p_Unidad)
						{
							case 0:
								Descena = "Cuarenta ";
								break;
							default:
								Descena = "Cuarenta y ";
								PrintNum = true;
								break;
						}

						break;
					case 5:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Cincuenta ";
								break;
							default:
								Descena = "Cincuenta y ";
								PrintNum = true;
								break;
						}
						break;
					case 6:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Secenta ";
								break;
							default:
								Descena = "Secenta y ";
								PrintNum = true;

								break;
						}
						break;
					case 7:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Setenta ";
								break;
							default:
								Descena = "Setenta y ";
								PrintNum = true;

								break;
						}
						break;
					case 8:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Ochenta ";
								break;
							default:
								Descena = "Ochenta y ";
								PrintNum = true;

								break;
						}
						break;
					case 9:
						switch (p_Unidad)
						{
							case 0:
								Descena = "Noventa ";
								break;
							default:
								Descena = "Noventa y ";
								PrintNum = true;

								break;
						}
						break;
					case 0:
						Descena = "";
						PrintNum = true;
						break;
				}
				if (PrintNum == true)
				{
					functionReturnValue = Strings.UCase(Descena + Unidad(p_Unidad));
				}
				else
				{
					functionReturnValue = Strings.UCase(Descena);
				}
				return functionReturnValue;
			}

			public string Millar(int p_Numero, int p_Centena, int p_Decena, int p_Unidad)
			{
				string p_Millar = "";
				switch (p_Numero)
				{
					case 1:
						p_Millar = "Mil ";
						break;
					case 2:
						p_Millar = "Dos Mil ";
						break;
					case 3:
						p_Millar = "tres mil ";
						break;
					case 4:
						p_Millar = "cuatro mil ";
						break;
					case 5:
						p_Millar = "cinco mil ";
						break;
					case 6:
						p_Millar = "seis mil ";
						break;
					case 7:
						p_Millar = "siete mil ";
						break;
					case 8:
						p_Millar = "ocho mil ";
						break;
					case 9:
						p_Millar = "nueve mil ";
						break;
				}
				return Strings.UCase(p_Millar + Centena(p_Centena, p_Decena, p_Unidad));
			}

			private string Centena(int Numero, int p_Decena, int p_Unidad)
			{
				string functionReturnValue = null;
				string p_Centena = "";
				PrintNum = false;

				switch (Numero)
				{
					case 1:
						if (Conversion.Val(p_Decena) == 0 & Conversion.Val(p_Unidad) == 0)
						{
							p_Centena = "Cien ";
						}
						else
						{
							p_Centena = "Ciento ";
							PrintNum = true;
						}
						break;
					default:
						if (Conversion.Val(p_Decena) != 0 | Conversion.Val(p_Unidad) != 0)
						{
							PrintNum = true;
						}
						switch (Numero)
						{
							case 2:
								p_Centena = "Doscientos ";
								break;
							case 3:
								p_Centena = "Trescientos ";
								break;
							case 4:
								p_Centena = "Cuatrocientos ";
								break;
							case 5:
								p_Centena = "Quinientos ";
								break;
							case 6:
								p_Centena = "Seiscientos ";
								break;
							case 7:
								p_Centena = "Setecientos ";
								break;
							case 8:
								p_Centena = "Ochocientos ";
								break;
							case 9:
								p_Centena = "Novecientos ";
								break;
							case 0:
								p_Centena = "";
								PrintNum = true;
								break;
						}
						break;
				}
				if (PrintNum == true)
				{
					functionReturnValue = Strings.UCase(p_Centena + this.Decena(p_Decena, p_Unidad));
				}
				else
				{
					functionReturnValue = Strings.UCase(p_Centena);
				}
				return functionReturnValue;
			}

			public string NumEnLetras(string Numero)
			{
				string functionReturnValue = null;

				int p_Decena = 0;
				int p_Unidad = 0;
				int p_Centena = 0;
				int p_Millar = 0;

				int TamañoNum = 0;

				TamañoNum = Strings.Len(Numero);

				switch (TamañoNum)
				{
					case 1:
						//unidades
						p_Unidad = Convert.ToInt32(Strings.Mid(Numero, 1, 1));

						functionReturnValue = this.Unidad(p_Unidad);

						break;
					case 2:
						//Decenas

						p_Decena = Convert.ToInt32(Strings.Mid(Numero, 1, 1));
						p_Unidad = Convert.ToInt32(Strings.Mid(Numero, 2, 1));

						functionReturnValue = this.Decena(p_Decena, p_Unidad);
						break;
					case 3:
						p_Centena = Convert.ToInt32(Strings.Mid(Numero, 1, 1));
						p_Decena = Convert.ToInt32(Strings.Mid(Numero, 2, 1));
						p_Unidad = Convert.ToInt32(Strings.Mid(Numero, 3, 1));

						functionReturnValue = this.Centena(p_Centena, p_Decena, p_Unidad);

						break;
					case 4:
						p_Millar = Convert.ToInt32(Strings.Mid(Numero, 1, 1));
						p_Centena = Convert.ToInt32(Strings.Mid(Numero, 2, 1));
						p_Decena = Convert.ToInt32(Strings.Mid(Numero, 3, 1));
						p_Unidad = Convert.ToInt32(Strings.Mid(Numero, 4, 1));

						functionReturnValue = this.Millar(p_Millar, p_Centena, p_Decena, p_Unidad);

						break;
				}
				return functionReturnValue;
			}

			public string ConvertirNumero(double p_Numero)
			{

				try
				{
					string ret = null;
					double Val = Math.Round(p_Numero, 2);

					string ValStr = Val.ToString();

					string[] Arr = null;
					Arr = Strings.Split(ValStr, ".");

					if (Arr.Length > 1)
					{
						ret = this.NumEnLetras(Arr[0]);
						ret += " PESOS " + Strings.Left(Arr[1] + "00", 2) + "/100 M.N.";
					}
					else
					{
						ret = this.NumEnLetras(Arr[0]) + " PESOS 00/100 M.N.";
					}

					return ret;

				}
				catch
				{
					throw;
				}
			} // end class

		}

	} //    end class AppHelper

	public static class StringHelper
	{
		public static string Left(string str, int len)
		{
			if (str.Length < len)
			{
				return str;
			}
			return str.Substring(0, len);
		}

		public static string Right(string str, int len)
		{
			if (str.Length < len)
			{
				return str;
			}
			return str.Substring(str.Length - len);
		}

		public static string Mid(string str, int start, int len)
		{
			if (str.Length < start)
			{
				return str;
			}

			if (str.Length < (start + len))
			{
				return str;
			}

			return str.Substring(start, len);
		}

		public static string Reverse(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}

		public static int CountStringOccurrences(string text, string pattern)
		{
			// Loop through all instances of the string 'text'.
			int count = 0;
			int i = 0;
			while ((i = text.IndexOf(pattern, i)) != -1)
			{
				i += pattern.Length;
				count++;
			}
			return count;
		}

	} // public class Strings

	class SICASException : Exception
	{
		public SICASException()
		{
		}

		public SICASException(string message)
			: base(message)
		{
		}

		public SICASException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

	}

	/// <summary>
	/// Contiene toda la información global de sesión en el sistema
	/// </summary>
	public static class Sesion
	{
		public static Entities.Sesiones GetSesion()
		{
			Entities.Sesiones sesion = new Entities.Sesiones();
			sesion.Activo = Sesion.Activo;
			sesion.Caja_ID = Sesion.Caja_ID;
			sesion.Estacion_ID = Sesion.Estacion_ID.Value;
			sesion.FechaFinal = Sesion.FechaFinal;
			sesion.FechaInicial = Sesion.FechaInicial;
			sesion.HostName = Sesion.HostName;
			sesion.IPAddress = Sesion.IPAddress;
			sesion.MACAddress = Sesion.MACAddress;
			sesion.Referencia_ID = null;
			sesion.Sesion_ID = Sesion.Sesion_ID;
			sesion.Usuario_ID = Sesion.Usuario_ID;
			return sesion;
		}
		
		private static int _Sesion_ID;
		public static int Sesion_ID
		{
			get { return _Sesion_ID; }
			set { _Sesion_ID = value; }
		}

		private static int? _Empresa_ID;
		public static int? Empresa_ID
		{
			get { return _Empresa_ID; }
			set { _Empresa_ID = value; }
		}

		private static int? _Estacion_ID;
		public static int? Estacion_ID
		{
			get { return _Estacion_ID; }
			set { _Estacion_ID = value; }
		}

		private static int? _Caja_ID;
		public static int? Caja_ID
		{
			get { return _Caja_ID; }
			set { _Caja_ID = value; }
		}

		private static string _Usuario_ID;
		public static string Usuario_ID
		{
			get { return _Usuario_ID; }
			set { _Usuario_ID = value; }
		}

		private static DateTime _FechaInicial;
		public static DateTime FechaInicial
		{
			get { return _FechaInicial; }
			set { _FechaInicial = value; }
		}

		private static DateTime _FechaFinal;
		public static DateTime FechaFinal
		{
			get { return _FechaFinal; }
			set { _FechaFinal = value; }
		}

		private static string _HostName;
		public static string HostName
		{
			get { return _HostName; }
			set { _HostName = value; }
		}

		private static string _IPAddress;
		public static string IPAddress
		{
			get { return _IPAddress; }
			set { _IPAddress = value; }
		}

		private static string _MACAddress;
		public static string MACAddress
		{
			get { return _MACAddress; }
			set { _MACAddress = value; }
		}

		private static bool _Activo;
		public static bool Activo
		{
			get { return _Activo; }
			set { _Activo = value; }
		}

		private static bool _EsPrueba;
		public static bool EsPrueba
		{
			get { return _EsPrueba; }
			set { _EsPrueba = value; }
		}

		public static List<Entities.SelectEmpresas> Empresas
		{
			get
			{
				return Entities.SelectEmpresas.GetEmpresasX(Sesion.Usuario_ID);
			}
		}

		public static List<Entities.SelectEstaciones> Estaciones
		{
			get
			{
				return Entities.SelectEstaciones.GetEstaciones(Sesion.Usuario_ID);
			}
		}

		public static List<Entities.SelectEmpresas> EmpresasTodas
		{
			get
			{
				return Entities.SelectEmpresas.GetAllEmpresas(Sesion.Usuario_ID);
			}
		}

		public static List<Entities.SelectEstaciones> EstacionesTodas
		{
			get
			{
				return Entities.SelectEstaciones.GetAllEstaciones(Sesion.Usuario_ID);
			}
		}

		public static List<Entities.SelectCajasActivas> Cajas
		{
			get
			{
				return Entities.SelectCajasActivas.Get(Sesion.Usuario_ID);
			}
		}

		public static List<Entities.SelectCajasActivas> CajasActivasPorUsuario
		{
			get
			{
				return Entities.SelectCajasActivas.GetActivasPorUsuario(Sesion.Usuario_ID);
			}
		}

		public static int GetUltimaSesionCerrada()
		{
			string sqlstr = @"dbo.usp_Obtiene_UltimaSesionPorUsuarioCaja";
			Hashtable hparams = new Hashtable();
			hparams.Add("@Usuario_ID",Sesion.Usuario_ID);
			hparams.Add("@Caja_ID", Sesion.Caja_ID);
			object ret = SICASv20.DB.ExecuteCommandSP_With_Return(sqlstr, hparams);
			return Convert.ToInt32(ret);
		}
		
		/// <summary>
		/// Configura la empresa y la estación del usuario
		/// Si tiene más de una empresa o estación,
		/// las asigna como nula
		/// </summary>
		public static void Set_Empresa_Estacion()
		{
			// Inicializamos las variables
			// el contador
			int cont = 0;

			//  El parámetro
			Hashtable m_params = new Hashtable();
			m_params.Add("Usuario_ID", Usuario_ID);

			//  Obtenemos el número de empresas configuradas para el usuario
			cont = SICASv20.DB.GetCount("Usuarios_Empresas", m_params);

			//  Si es una, la configuramos globalmente
			if (cont == 1)
			{
				Entities.Usuarios_Empresas ue = Entities.Usuarios_Empresas.Read(Usuario_ID)[0];
				Empresa_ID = ue.Empresa_ID;
			} // end if
			else // Si no
			{
				//  La configuramos como nula
				Empresa_ID = null;
			} // end else

			//  Obtenemos el número de estaciones configuradas para el usuario
			cont = SICASv20.DB.GetCount("Usuarios_Estaciones", m_params);

			//  Si es una
			if (cont == 1)
			{
				//  La establecemos globalmente
				Entities.Usuarios_Estaciones ue = Entities.Usuarios_Estaciones.Read(Usuario_ID)[0];
				Estacion_ID = ue.Estacion_ID;
			} // end if
			else // Si no
			{
				//  La establecemos como nula
				Estacion_ID = null;
			} // end else
		} // end Set_Empresa_Estacion

		public static class FTP
		{
			private static string _User;
			public static string User
			{
				get { return _User; }
				set { _User = value; }
			}

			private static string _Pwd;
			public static string Pwd
			{
				get { return _Pwd; }
				set { _Pwd = value; }
			}

			private static string _Server;
			public static string Server
			{
				get { return _Server; }
				set { _Server = value; }
			}

			private static string _Path;
			public static string Path
			{
				get { return _Path; }
				set { _Path = value; }
			}
		}

		public static class DB
		{
			private static string _User;
			public static string User
			{
				get { return _User; }
				set { _User = value; }
			}

			private static string _Pwd;
			public static string Pwd
			{
				get { return _Pwd; }
				set { _Pwd = value; }
			}

			private static string _Server;
			public static string Server
			{
				get { return _Server; }
				set { _Server = value; }
			}

			private static string _Database;
			public static string Database
			{
				get { return _Database; }
				set { _Database = value; }
			}
		}

	} // End class Sesion    

	public static class AutoUpdate
	{
		private static string LogFile =
			   System.IO.Path.Combine(System.Environment.CurrentDirectory, "auditlog.log");

		/// <summary>
		/// Registra la operación en un archivo de registro
		/// </summary>
		private static void Log(string entry)
		{
			StreamWriter sw =
			    new StreamWriter(
				   LogFile,
				   true
			    );

			sw.WriteLine(DateTime.Now.ToString() + "\t" + entry);
			sw.Flush();
			sw.Close();
		}

		private static string ProgramFilesx86()
		{
			if (8 == IntPtr.Size
			    || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
			{
				return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
			}

			return Environment.GetEnvironmentVariable("ProgramFiles");
		}


		public static void AutoUpdater()
		{
			string fileAutoupdater;
			string fileConfig;
			string fileImage;
			string fileConfig2 = "";
			string localAutoupdater;
			string localConfig;
			string localConfig2 = "";
			string localImage;

			fileAutoupdater = Environment.CurrentDirectory + "\\Autoupdater.exe";
			fileImage = Environment.CurrentDirectory + "\\AppImage.jpg";
			localAutoupdater = ProgramFilesx86() + "\\SICAS\\AutoUpdater.exe";
			localImage = ProgramFilesx86() + "\\SICAS\\AppImage.jpg";

			localConfig = ProgramFilesx86() + "\\SICAS\\aupcfg.xml";
			fileConfig = Environment.CurrentDirectory + "\\aupcfg.xml";

			if (!File.Exists(localConfig))
			{
				localConfig = ProgramFilesx86() + "\\SICAS\\aupcfg";
				fileConfig = Environment.CurrentDirectory + "\\aupcfg";
				fileConfig2 = Environment.CurrentDirectory + "\\aupcfg.xml";
				localConfig2 = ProgramFilesx86() + "\\SICAS\\aupcfg.xml";
			}

			Log(
			    string.Format(
				   "Files in: {0},{1},{2}\r\nFiles out: {3},{4},{5}",
				   fileAutoupdater,
				   fileConfig,
				   fileConfig2,
				   fileImage,
				   localAutoupdater,
				   localConfig,
				   localConfig2,
				   localImage
			    )
			);

			if (File.Exists(fileAutoupdater) &&
			    File.Exists(fileConfig) &&
			    File.Exists(localAutoupdater) &&
			    File.Exists(localConfig) &&
			    File.Exists(fileImage) &&
			    File.Exists(localImage))
			{
				try
				{
					File.Delete(localAutoupdater);
					File.Delete(localConfig);
					File.Delete(localImage);
					File.Copy(fileImage, localImage);
					File.Copy(fileAutoupdater, localAutoupdater);
					File.Copy(fileConfig, localConfig);

					if (!localConfig.Contains(".xml") &&
					    !string.IsNullOrEmpty(fileConfig2) &&
					    !string.IsNullOrEmpty(localConfig2))
					{
						File.Copy(fileConfig2, localConfig2);
					}

					Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
					registro.Accion = "EXITO AUTOUPDATER";
					registro.Comentarios = "AUTOUPDATER SE HA ACTUALIZADO CORRECTAMENTE";
					registro.Fecha = DateTime.Now;
					registro.Formulario = "LoginForm";
					registro.Opcion_ID = null;
					registro.Usuario_ID = Sesion.Usuario_ID;
					registro.Create();

				}
				catch (Exception ex)
				{
					Log(ex.Message);

					Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
					registro.Accion = "FALLO AUTOUPDATER";
					registro.Comentarios = ex.Message;
					registro.Fecha = DateTime.Now;
					registro.Formulario = "LoginForm";
					registro.Opcion_ID = null;
					registro.Usuario_ID = Sesion.Usuario_ID;
					registro.Create();
				}
			}
			else
			{
				string comment = "Missing file: ";
				if (!File.Exists(fileAutoupdater)) comment += fileAutoupdater + "; ";
				if (!File.Exists(fileConfig)) comment += fileConfig + "; ";
				if (!File.Exists(fileImage)) comment += fileImage + "; ";
				if (!File.Exists(localAutoupdater)) comment += localAutoupdater + "; ";
				if (!File.Exists(localConfig)) comment += localConfig + "; ";
				if (!File.Exists(localImage)) comment += localImage + "; ";

				Log(comment);

				Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
				registro.Accion = "FALLO AUTOUPDATER";
				registro.Comentarios = Strings.Left(comment, 250);
				registro.Fecha = DateTime.Now;
				registro.Formulario = "LoginForm";
				registro.Opcion_ID = null;
				registro.Usuario_ID = Sesion.Usuario_ID;
				registro.Create();
			}
		}
	}

	public static class LogHelper
	{
		public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}