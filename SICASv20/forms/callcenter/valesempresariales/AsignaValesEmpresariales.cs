using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.callcenter.valesempresariales
{
	public partial class AsignaValesEmpresariales : Form
	{
		private List<Entities.ValesEmpresarialesUsuarios> lUsuarios = new List<Entities.ValesEmpresarialesUsuarios>();
		private Entities.ValesEmpresarialesUsuarios usuario = new Entities.ValesEmpresarialesUsuarios();

		public AsignaValesEmpresariales()
		{
			InitializeComponent();
			lUsuarios = Entities.ValesEmpresarialesUsuarios.GetValesEmpresarialesUsuarios();
			cmbUsuarios.DataSource = lUsuarios;
		}

		private void cmdCerrar_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void cmdAsigna_Click(object sender, EventArgs e)
		{
			if (ValidaInformacion())
			{
				try
				{
					Entities.ValesEmpresariales.AsignaFolios(usuario.Usuario_ID, txtSerie.Text.Trim(), txtFolioInicial.Text.Trim(), txtFolioFinal.Text.Trim(), Sesion.Usuario_ID);
					MessageBox.Show("Folios Asignados con éxito.");
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
					Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private bool ValidaInformacion()
		{
			usuario = (Entities.ValesEmpresarialesUsuarios)cmbUsuarios.SelectedItem;
			if (usuario.Usuario_ID.Trim().Length <= 0)
			{
				MessageBox.Show("Es necesario seleccionar un usuario al que se asignaran los folios");
				cmbUsuarios.Focus();
				return false;
			}
			if (txtSerie.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Es necesario indicar la serie de los vales");
				txtSerie.Focus();
				return false;
			}
			if (txtFolioInicial.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Es necesario indicar el folio inicial");
				txtFolioInicial.Focus();
				return false;
			}
			if (!DB.IsNumeric(txtFolioInicial.Text.Trim()))
			{
				MessageBox.Show("El folio inicial debe contener solo números");
				txtFolioInicial.Focus();
				return false;
			}
			if (txtFolioFinal.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Es necesario indicar el folio final");
				txtFolioFinal.Focus();
				return false;
			}
			if (!DB.IsNumeric(txtFolioFinal.Text.Trim()))
			{
				MessageBox.Show("El folio final debe contener solo números");
				txtFolioFinal.Focus();
				return false;
			}
			return true;
		}

	}
}
