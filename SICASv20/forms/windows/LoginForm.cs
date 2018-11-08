/*
 * 
 * SICAS v2.0.forms.LoginForm
 * 
 * Formulario para ingresar al sistema
 * 
 * Codificado por Luis Espino
 * Ultima revisión 2012-08-08
 * 
 * 
 * Modificado el 17 de Octubre de 2012
 * Se ha modificado el comportamiento de sesión
 * para empresa y estación
*/

//  Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	/// <summary>
	/// LoginForm, Clase Principal del Formulario
	/// Basado en BaseFormGradient para el efecto de gradiente en el fondo,
	/// </summary>
	public partial class LoginForm : GradientForms.BaseFormGradient
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LoginForm()
		{
			InitializeComponent();
			//  Centra el GroupBox que contiene los controles del formualario
			CenterGroupBox();


            this.Text= "version: "+AppHelper.Version;

            //AppHelper.SendEmail("sicas@casco.com.mx", "lespino@prosyss.com", "Prueba", "Prueba", false);
        }

		/// <summary>
		/// Formulario utilizado para seleccionar una caja,
		/// se utiliza cuando una estación tiene varias cajas
		/// </summary>
		private SeleccionarCajaSesion SeleccionarCajaForm;

		/// <summary>
		/// Manda a llamar al formulario SeleccionarCaja
		/// y devuelve un código de resultado DialogResult
		/// </summary>
		/// <returns></returns>
		private DialogResult ShowSeleccionarCaja()
		{
			if (this.SeleccionarCajaForm == null)
				this.SeleccionarCajaForm = new SeleccionarCajaSesion();

			if (this.SeleccionarCajaForm.IsDisposed)
				this.SeleccionarCajaForm = new SeleccionarCajaSesion();

			return this.SeleccionarCajaForm.ShowDialog();
		}

		/// <summary>
		/// Manda a llamar al formulario SeleccionarCaja
		/// lo muestra en Modal
		/// a partir del usuario y
		/// devuelve un DialogResult
		/// </summary>
		/// <param name="usuario_id"></param>
		/// <returns></returns>
		private DialogResult ShowSeleccionarCaja(string usuario_id)
		{
			if (this.SeleccionarCajaForm == null)
				this.SeleccionarCajaForm = new SeleccionarCajaSesion();

			if (this.SeleccionarCajaForm.IsDisposed)
				this.SeleccionarCajaForm = new SeleccionarCajaSesion();

			this.SeleccionarCajaForm.Usuario_ID = usuario_id;

			return this.SeleccionarCajaForm.ShowDialog();
		}

		/// <summary>
		/// Centra en el formulario el control
		/// GroupBox que contiene los controles
		/// para validación de los usuarios
		/// (Textbox, Buttons)
		/// </summary>
		private void CenterGroupBox()
		{
			int x, y;
			x = (this.Width - this.groupBox1.Width) / 2;
			y = (this.Height - this.groupBox1.Height) / 2;

			this.groupBox1.Location = new Point(x, y);
		}

		/// <summary>
		/// Realiza el procedimiento de validación
		/// registro y carga de la pantalla principal del sistema
		/// </summary>
		private void LogIn()
		{
			try
			{
				//  Obtenemos las variables a partir de los controles
				string usuario_id = Usuario_IDTextBox.Text;
				string pwd = PasswordTextBox.Text;

				//  Verificamos que no esten vacias
				if (usuario_id != "" &&
				PasswordTextBox.Text != "")
				{
					//  Instanciamos un objeto Functions
					SICASCentralQuerysDataSetTableAdapters.Functions fns = new SICASCentralQuerysDataSetTableAdapters.Functions();

					//  Validamos la relación usuario y contraseña contra la base de datos
					//  mediante el Método AuthUser del objeto Functios fns
					if ((int)fns.AuthUser(usuario_id, pwd) > 0)
					{
						//usuario_id = "gestor.decobranza3";
						//  Si los datos de usuario y contraseña son válidos
						Sesion.Usuario_ID = usuario_id;

						//  Cargamos sus datos de Emprea y Estacion
						Sesion.Set_Empresa_Estacion();

						//  Verificar si el usuario tiene permisos a una caja,                        
						List<Entities.Usuarios_Cajas> UsuariosCajas = Entities.Usuarios_Cajas.Read(usuario_id);

						//  Obtenemos un objeto Usuario a partir del dato usuario_ir
						Entities.Usuarios usuario = Entities.Usuarios.Read(usuario_id);

						//  Verificamos los permisos de caja
						//  Si el usuario tiene permisos de caja y además no tiene estación fija
						if (UsuariosCajas.Count > 0 && Sesion.Estacion_ID != null)
						{
							//  Si el usuario no tiene estacion fija
							//  lanzamos una excepción
							if (Sesion.Estacion_ID == null) throw new Exception("El usuario debe tener configurada una estacion");

							//  Obtenemos las sesiones del usuario que esten activas
							//  y las colocamos la variable sesiones
							List<Entities.Sesiones> sesiones =
							    Entities.Sesiones.Read("Usuario_ID = @Usuario_ID AND Activo = 1 AND FechaFinal IS NULL", null, DB.Param("@Usuario_ID", usuario_id));

							//  Verificamos si tiene sesiones activas
							if (sesiones.Count == 0)
							{
								// No tiene sesiones activas
								// Crear sesion
								int? caja = null;
								//  Selecccionar una caja
								//  Verificar que estacion tenga cajas activas
								if (!DB.Exists(
								    "Cajas",
								    DB.Param("Estacion_ID", Sesion.Estacion_ID),
								    DB.Param("Activa", true)
								    )
								)
								{
									throw new Exception("No existen cajas activas para la estación");
								}

								//  Verificar el número de cajas por usuario
								if (UsuariosCajas.Count == 1)
								{
									//  Aqui solo tiene una caja, se obtiene la default
									caja = UsuariosCajas[0].Caja_ID;
								}
								else
								{
									//  Aquí tiene más de una caja el usuario
									//  En caso de haber más de una caja
									//  El usuario debe seleccionar su caja
									if (this.ShowSeleccionarCaja(usuario_id) == System.Windows.Forms.DialogResult.OK)
									{
										//  Obtener la caja seleccionada
										caja = this.SeleccionarCajaForm.Caja_ID;
									}
									else
									{
										AppHelper.ThrowException("Debe seleccionar una caja");
									} // end else
								} // end else

								//  Verificar que la caja seleccionada no tenga sesión activa
								//  Obtener las sessiones activas de la caja
								List<Entities.Sesiones> sesionesCaja = Entities.Sesiones.Read(
								    "Caja_ID = @Caja_ID AND Activo = 1 AND FechaFinal IS NULL",
								    null, DB.Param("@Caja_ID", caja)
								);

								//  Verificar el numero de registros
								if (sesionesCaja.Count > 0)
								{
									//  Si tiene sesiones activas
									//  Enviar mensaje de error
									AppHelper.ThrowException(
									    @"El usuario {0} ya ha iniciado sesión en la caja seleccionada o predeterminada
No puedes iniciar sesión hasta que el usuario {0} la termine realizando el corte correspondiente.",
									    sesionesCaja[0].Usuario_ID
									);
								} // end if

								//  Crear una nueva sesión y registrarla
								Entities.Sesiones sesion = new Entities.Sesiones();
								sesion.Activo = true;
								sesion.Caja_ID = caja; // falta poner la caja
								sesion.Estacion_ID = Sesion.Estacion_ID.Value; // Espera no nulo
								sesion.FechaFinal = null;
								sesion.FechaInicial = DB.GetDate();
								sesion.HostName = null;
								sesion.IPAddress = null;
								sesion.MACAddress = null;
								sesion.Usuario_ID = usuario_id;
								sesion.Create();

								//  Pasar los datos a la sesión global
								Sesion.Sesion_ID = sesion.Sesion_ID;
								Sesion.Caja_ID = sesion.Caja_ID;
								Sesion.Estacion_ID = sesion.Estacion_ID;
								Sesion.FechaInicial = sesion.FechaInicial;
							}
							else
							{
								//  Ya tiene sesión activa
								//  Pasar los datos a la sesión global
								Sesion.Sesion_ID = sesiones[0].Sesion_ID;
								Sesion.Caja_ID = sesiones[0].Caja_ID;
								Sesion.Estacion_ID = sesiones[0].Estacion_ID;
								Sesion.FechaInicial = sesiones[0].FechaInicial;
							}
						}
						else if (UsuariosCajas.Count > 0 & Sesion.Estacion_ID == null)
						{
							throw new Exception("Los usuarios de caja solo deben tener acceso a una estación");
						}
						Sesion.Activo = true;
						//  Mostrar el formulario principal del sistema
						forms.SICASForm sicasForm = new forms.SICASForm();
						this.Hide();
						sicasForm.Show();
						RegistrarEntrada();
						this.Hide();

						//  Registramos que se ha actualizado el sistema
						//  llamando al procedimiento AutoUpdater de la clase estática AutoUpdate
						AutoUpdate.AutoUpdater();
					}
					else
					{
						//  Enviar error de autenticación
						throw new Exception("Usuario o contraseña erroneas!");
					}
				}
			}
			catch (Exception ex)
			{
				//  Mostramos el mensaje de error
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Registra la entrada al sistema en la base de datos
		/// </summary>
		public void RegistrarEntrada()
		{
			Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
			registro.Accion = "INGRESO";
			registro.Comentarios = "Version " + AppHelper.Version;
			registro.Fecha = DB.GetDate();
			registro.Formulario = this.Name;
			registro.Opcion_ID = null;
			registro.Usuario_ID = Sesion.Usuario_ID;
			registro.Create();
		}

		/// <summary>
		/// Evento "Click" del botón "Ingresar"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IngresarButton_Click(object sender, EventArgs e)
		{
			LogIn();
		}


		/// <summary>
		/// Se efectuará al hacer "Enter" en la caja de texto de Password
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				LogIn();
			}
		}
	} // end class
} // end namespace