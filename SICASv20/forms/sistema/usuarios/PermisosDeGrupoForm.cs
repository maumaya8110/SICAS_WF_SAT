using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class PermisosDeGrupoForm : Form
    {
        public PermisosDeGrupoForm()
        {
            InitializeComponent();
        }

        public Entities.GruposUsuarios GrupoUsuario;

        private void PermisosDeGrupoForm_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.gruposUsuariosBindingSource.DataSource =
                        Entities.GruposUsuarios.Read();
                }
            );
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.GrupoUsuario = (Entities.GruposUsuarios)this.GruposComboBox.SelectedItem;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            );
        }
    }
}
