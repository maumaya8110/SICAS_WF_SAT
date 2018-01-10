using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.callcenter.valesempresariales
{
	public partial class ValesEmpresariales : baseForm
	{
		private List<Entities.ValesEmpresarialesUsuarios> lUsuarios = new List<Entities.ValesEmpresarialesUsuarios>();
		private Entities.ValesEmpresarialesUsuarios usuario = new Entities.ValesEmpresarialesUsuarios();
		private Entities.SelectEstatusValesPrepagados estatusvp = new Entities.SelectEstatusValesPrepagados();
		private List<Entities.SelectEstatusValesPrepagados> svp = new List<Entities.SelectEstatusValesPrepagados>();
		private List<Entities.ValesEmpresariales> Vales = new List<Entities.ValesEmpresariales>();

		public ValesEmpresariales()
		{
			InitializeComponent();
			lUsuarios = Entities.ValesEmpresarialesUsuarios.GetValesEmpresarialesUsuarios();
			lUsuarios.Insert(0, new Entities.ValesEmpresarialesUsuarios() { Usuario_ID = "", Nombre = "Todos", Estatus = 0 });
			cmbUsuarios.DataSource = lUsuarios;

			cmbEstatus.DataSource = Entities.SelectEstatusValesPrepagados.Get();
			dgvValesEmpresariales.AutoGenerateColumns = false;
			dgvValesEmpresariales.DataSource = Vales;
		}

		private void cmdAsignar_Click(object sender, EventArgs e)
		{
			forms.callcenter.valesempresariales.AsignaValesEmpresariales ve = new AsignaValesEmpresariales();
			ve.ShowDialog();
		}

		private void cmrConsultar_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(ConsultaVales,this);
		}

		private void ConsultaVales()
		{
			usuario = (Entities.ValesEmpresarialesUsuarios)cmbUsuarios.SelectedItem;
			estatusvp = (Entities.SelectEstatusValesPrepagados)cmbEstatus.SelectedItem;
			Vales = Entities.ValesEmpresariales.ConsultaFolios(usuario.Usuario_ID, estatusvp.EstatusValePrepagado_ID, txtSerie.Text.Trim(), txtFolio.Text.Trim());
			dgvValesEmpresariales.DataSource = Vales;
			dgvValesEmpresariales.Refresh();
		}
	}
}
