using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class AgregaEquipo : Form
	{
		public Entities.EquipoGas.Equipo Modelo { get; set; }
		private List<Entities.EquipoGas.Proveedor> lProveedores = new List<Entities.EquipoGas.Proveedor>();
		private List<Entities.EquipoGas.EquipoGas> lEquiposGas = new List<Entities.EquipoGas.EquipoGas>();
		private List<Entities.EquipoGas.Empresa> lEmpresas = new List<Entities.EquipoGas.Empresa>();
		private List<Entities.EquipoGas.Estacion> lEstaciones = new List<Entities.EquipoGas.Estacion>();

		public AgregaEquipo()
		{
			InitializeComponent();
			BindingDatos();
		}

		private void BindingDatos()
		{
			lEmpresas = Entities.EquipoGas.Empresa.GetEmpresas();
			cmbEmpresa.DataSource = lEmpresas;
			cmbEmpresa.DisplayMember = "Descripcion";
			cmbEmpresa.ValueMember = "Id";

			lEstaciones = Entities.EquipoGas.Estacion.GetEstaciones();
			cmbEstacion.DataSource = lEstaciones;
			cmbEstacion.DisplayMember = "Descripcion";
			cmbEstacion.ValueMember = "Id";

			lProveedores = Entities.EquipoGas.Proveedor.GetProveedoresActivos();
			cmbProveedores.DataSource = lProveedores;
			cmbProveedores.DisplayMember = "Nombre";
			cmbProveedores.ValueMember = "Id";

			lEquiposGas = Entities.EquipoGas.EquipoGas.GetEquiposGasActivos();
			cmbEquiposGas.DataSource = lEquiposGas;
			cmbEquiposGas.DisplayMember = "Descripcion";
			cmbEquiposGas.ValueMember = "Id";
		}

		private void AgregaEquipo_Shown(object sender, EventArgs e)
		{
			if(Modelo != null){
				this.Text = "Edita Equipo";
				SetInfoToForm();
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(
				delegate {
					Valida();
					SetInfoToModel();
					Guardar();
				}, this);
		}

		private void Valida()
		{
			if(txtCosto.Text.Trim().Length <= 0)
				throw new Exception("Es requerida la captura del Costo del equipo");
			if (txtPrecio.Text.Trim().Length <= 0)
				throw new Exception("Es requerida la captura del Precio del equipo");
			if (txtMontoDiario.Text.Trim().Length <= 0)
				throw new Exception("Es requerida la captura del Monto diario a descontar por el equipo");
			if (txtSerieKit.Text.Trim().Length <= 0)
				throw new Exception("El Número de Serie del Kit es requerido");
			if (txtDiasAPagar.Text.Trim().Length <= 0)
				throw new Exception("Debe indicar la cantidad de días que debe pagar el conductor");
			
			double aux;
			if (!double.TryParse(txtCosto.Text.Trim(), out aux))
				throw new Exception("El costo debe ser númerico");
			if (!double.TryParse(txtPrecio.Text.Trim(), out aux))
				throw new Exception("El precio debe ser númerico");
			if (!double.TryParse(txtMontoDiario.Text.Trim(), out aux))
				throw new Exception("El Monto Diario debe ser númerico");
			if (!double.TryParse(txtDiasAPagar.Text.Trim(), out aux))
				throw new Exception("Debe indicar la cantidad de días que debe pagar el conductor");
		}

		private void SetInfoToModel()
		{
			if (Modelo == null)
			{
				Modelo = new Entities.EquipoGas.Equipo();
				Modelo.Usuario = Sesion.Usuario_ID;
			}
			Modelo.Equipo_Gas = (Entities.EquipoGas.EquipoGas)cmbEquiposGas.SelectedItem;
			Modelo.proveedor = (Entities.EquipoGas.Proveedor)cmbProveedores.SelectedItem;
			Modelo.Empresa_ID = (int)cmbEmpresa.SelectedValue;
			Modelo.Estacion_ID = (int)cmbEstacion.SelectedValue;
			Modelo.NumeroSerieTanque = txtSerieTanque.Text.Trim();
			Modelo.Costo = Convert.ToDouble(txtCosto.Text.Trim());
			Modelo.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
			Modelo.MontoDiario = Convert.ToDouble(txtMontoDiario.Text.Trim());
			Modelo.NumeroSerieKit = txtSerieKit.Text.Trim();
			Modelo.CantidadDiasApagar = Convert.ToInt32(txtDiasAPagar.Text.Trim());
		}

		private void SetInfoToForm()
		{
			cmbEquiposGas.SelectedValue = Modelo.Equipo_Gas.Id;
			cmbProveedores.SelectedValue = Modelo.proveedor.Id;
			cmbEmpresa.SelectedValue = Modelo.Empresa_ID;
			cmbEstacion.SelectedValue = Modelo.Estacion_ID;
			chkEstatus.Checked = Modelo.Estatus == 1;
			txtCosto.Text = Modelo.Costo.ToString();
			txtPrecio.Text = Modelo.Precio.ToString();
			txtMontoDiario.Text = Modelo.MontoDiario.ToString();
			txtSerieKit.Text = Modelo.NumeroSerieKit;
			txtSerieTanque.Text = Modelo.NumeroSerieTanque;
			txtDiasAPagar.Text = Modelo.CantidadDiasApagar.ToString();
		}

		private void Guardar()
		{
			if (!Entities.EquipoGas.Equipo.Inserta(Modelo))
				throw new Exception("No se pudo almacenar la información, revise los datos e intentelo nuevamente");
			
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void CalculaDiasAPagar()
		{
			txtMontoDiario.Text = "0";
			if (txtPrecio.Text.Trim().Length > 0 && txtDiasAPagar.Text.Trim().Length > 0)
			{
				double precio = 0;
				double totDias = 0;
				if (!double.TryParse(txtPrecio.Text.Trim(), out precio))
					throw new Exception("Debe introducir un precio valido");
				if (!double.TryParse(txtDiasAPagar.Text.Trim(), out totDias))
					throw new Exception("Debe introducir la cantidad de días a pagar");
				double monto_diario = Math.Ceiling(precio / totDias);
				txtMontoDiario.Text = monto_diario.ToString();
			}
		}

		private void txtPrecio_TextChanged(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate { CalculaDiasAPagar(); }, this);
		}

		private void txtDiasAPagar_TextChanged(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate { CalculaDiasAPagar(); }, this);
		}
	}
}
