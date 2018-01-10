using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CambioContraseña : baseForm
    {
        public CambioContraseña()
        {
            InitializeComponent();
        }

        #region Model

        public void Set_Usuario(Entities.Usuarios usuario)
        {
            model.Usuario = usuario;
            model.NombreUsuario = usuario.Nombre + " " + usuario.Apellidos;
            model.Email = usuario.Email;
        }

        private Model model = new Model();
        public class Model
        {
            private Entities.Usuarios _Usuario;
            public Entities.Usuarios Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _NuevaContraseña;
            public string NuevaContraseña
            {
                get { return _NuevaContraseña; }
                set { _NuevaContraseña = value; }
            }

            private string _RepetirNuevaContraseña;
            public string RepetirNuevaContraseña
            {
                get { return _RepetirNuevaContraseña; }
                set { _RepetirNuevaContraseña = value; }
            }

            private string _Email;
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }

            private string _NombreUsuario;
            public string NombreUsuario
            {
                get { return _NombreUsuario; }
                set { _NombreUsuario = value; }
            }

            public void Validar()
            {
                if (!AppHelper.IsEmail(this.Email))
                {
                    throw new Exception("El email no es valido");
                }

                if (NuevaContraseña != RepetirNuevaContraseña)
                {
                    throw new Exception("Las contraseñas no corresponden");
                }
            }

            public void Guardar()
            {
                Usuario.pwd = DB.PwdEncrypt(this.NuevaContraseña);
                Usuario.Email = this.Email;
                Usuario.Update();
            }

            public void EnviarCorreo()
            {
                string body = "Hola, estimado {0}.\r\n\r\n" +
                    "Por este medio le informamos que su contraseña para el sistema SICAS v.2.0 ha sido actualizada.\r\n" +
                    "Su nueva contraseña es: {1}.\r\n\r\nApartir de este momento debe comenzar a utilizarla.\r\n" +
                    "Para cualquier duda u aclaración, comuniquese con el administrador del sistema." +
                    "Por favor, no responda este correo. De antemano, mil gracias.";
                body = string.Format(body, this.NombreUsuario, this.NuevaContraseña);

                AppHelper.SendEmail("sicas@casco.com.mx", this.Email, "Contraseña de SICAS actualizada", body, false);
            }
        }

        #endregion

        public override void BindData()
        {
            modelBindingSource.DataSource = this.model;
            base.BindData();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                modelBindingSource.ResetBindings(false);
                model.Validar();
                model.Guardar();
                model.EnviarCorreo();
                AppHelper.Info("Contraseña actualizada!");
                Padre.SwitchForma("Usuarios");
            }
            catch(Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            this.model.Email = EmailTextBox.Text;
        }

        private void NuevoPwdTextBox_TextChanged(object sender, EventArgs e)
        {
            this.model.NuevaContraseña = NuevoPwdTextBox.Text;
        }

        private void RepetirNuevoPwdTextBox_TextChanged(object sender, EventArgs e)
        {
            this.model.RepetirNuevaContraseña = RepetirNuevoPwdTextBox.Text;
        }
    }
}
