using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.caja.herramientas
{
	public partial class CanjeDeVales : baseForm
	{
		public CanjeDeVales()
		{
			InitializeComponent();
		}

		class CanjeVale_Model : Entities.CuentaFlujoCajas
		{
			public CanjeVale_Model(Entities.Sesiones sesion)
			{
				this.Sesion = sesion;
				this.Caja_ID = this.Sesion.Caja_ID.Value;
				this.Sesion_ID = this.Sesion.Sesion_ID;
				this.Ticket_ID = null;
				this.Usuario_ID = this.Sesion.Usuario_ID;
			}

			public Entities.Sesiones Sesion { get; set; }
			public List<Entities.Vista_SaldosFlujoCajaSesion> Saldos { get; set; }
			public List<Entities.Monedas> Monedas { get; set; }
			public Entities.ValesPrepagados ValePrepagado { get; set; }
			public Entities.ValesEmpresariales ValeEmpresarial { get; set; }

			public void ConsultarSaldos()
			{
				this.Saldos = Entities.Vista_SaldosFlujoCajaSesion.Get(this.Sesion.Sesion_ID);
			}

			public void ConsultarMonedas()
			{
				this.Monedas = Entities.Monedas.GetVales();
			}

			public void Validar()
			{
				if (this.Moneda_ID == 3 && this.ValePrepagado == null)
				{
					AppHelper.ThrowException("Debe indicar el vale prepagado a canjear");
				}
				if (this.Moneda_ID == 4 && this.ValeEmpresarial == null)
				{
					AppHelper.ThrowException("Debe indicar el vale empresarial a canjear");
				}
				if (this.Cargo <= 0)
				{
					AppHelper.ThrowException("Debe indicar el monto del vale");
				}
				if (this.Cargo > this.GetSaldo())
				{
					AppHelper.ThrowException("La caja no cuenta con el suficiente efectivo para realizar el canje del Vale");
				}
			}

			private decimal GetSaldo()
			{
				string sql = "SELECT SUM(Abono - Cargo) FROM CuentaFlujoCajas WHERE Sesion_ID = @Sesion_ID AND Moneda_ID = @Moneda_ID";

				object saldo = DB.QueryScalar(
					   sql,
					   DB.GetParams(
						  DB.Param("@Sesion_ID", this.Sesion_ID),
						  DB.Param("@Moneda_ID", 1) //this.Moneda_ID
						  ));
				if (saldo != DBNull.Value)
					return Convert.ToDecimal(saldo);
				else
					return 0;
			}

			public void Guardar()
			{
				this.Validar();

				DateTime getDate = DB.GetDate();
				Entities.CuentaFlujoCajas CuentaFlujo = new Entities.CuentaFlujoCajas();

				if (this.ValePrepagado != null && this.ValePrepagado.Denominacion > 0)
				{
					this.ValePrepagado.FechaCanje = getDate;

					//  Creamos un cargo en la cuenta de cajas - Es la referencia del dinero que se retiró de caja
					Entities.CuentaCajas ccs = new Entities.CuentaCajas();
					ccs.Cargo = Math.Abs(this.ValePrepagado.Denominacion);
					ccs.Caja_ID = Sesion.Caja_ID.Value;
					ccs.Abono = 0;
					ccs.Comentarios = "RETIRO DE EFECTIVO EN CAJA - VALES PREPAGADOS -";
					ccs.Concepto_ID = 148;
					ccs.Cuenta_ID = 5;
					ccs.Empresa_ID = 601;//adeudo.Empresa_ID;
					ccs.Estacion_ID = Sesion.Estacion_ID;
					ccs.Fecha = getDate;
					ccs.Saldo = 0; 
					ccs.Sesion_ID = Sesion.Sesion_ID;
					ccs.Usuario_ID = Sesion.Usuario_ID;
					ccs.Create();

					//  Creamos un abono en la cuenta de flujo de caja
					CuentaFlujo = new Entities.CuentaFlujoCajas();
					CuentaFlujo.Abono = Math.Abs(this.ValePrepagado.Denominacion);
					CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
					CuentaFlujo.Cargo = 0;
					CuentaFlujo.Concepto = "PAGO CON VALES - CANJE";
					CuentaFlujo.Fecha = getDate;
					CuentaFlujo.Moneda_ID = 3; 
					CuentaFlujo.Saldo = 0; 
					CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
					CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
					CuentaFlujo.Create();

					CuentaFlujo = new Entities.CuentaFlujoCajas();
					CuentaFlujo.Abono = 0;
					CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
					CuentaFlujo.Cargo = Math.Abs(this.ValePrepagado.Denominacion);
					CuentaFlujo.Concepto = "PAGO CON VALES - CANJE";
					CuentaFlujo.Fecha = getDate;
					CuentaFlujo.Moneda_ID = 1; 
					CuentaFlujo.Saldo = 0; // Se calcula solo
					CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
					CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
					CuentaFlujo.Create();

					MarcarVale(this.ValePrepagado);
				}

				if (this.ValeEmpresarial != null && this.Cargo > 0)
				{
					this.ValeEmpresarial.Monto = this.Cargo;
					this.ValeEmpresarial.Caja_ID = Sesion.Caja_ID.Value;
					this.ValeEmpresarial.UsuarioCaja_ID = Sesion.Usuario_ID;
					this.ValeEmpresarial.FechaCanje = getDate;
					
					//  Creamos un cargo en la cuenta de cajas - Es la referencia del dinero que se retiró de caja
					Entities.CuentaCajas ccs = new Entities.CuentaCajas();
					ccs.Cargo = Math.Abs((decimal)this.ValeEmpresarial.Monto);
					ccs.Caja_ID = Sesion.Caja_ID.Value;
					ccs.Abono = 0;
					ccs.Comentarios = "RETIRO DE EFECTIVO EN CAJA - VALES EMPRESARIALES -";
					ccs.Concepto_ID = 148;
					ccs.Cuenta_ID = 5;
					ccs.Empresa_ID = 601;
					ccs.Estacion_ID = Sesion.Estacion_ID;
					ccs.Fecha = getDate;
					ccs.Saldo = 0;
					ccs.Sesion_ID = Sesion.Sesion_ID;
					ccs.Usuario_ID = Sesion.Usuario_ID;
					ccs.Create();

					//  Creamos un abono en la cuenta de flujo de caja
					CuentaFlujo = new Entities.CuentaFlujoCajas();
					CuentaFlujo.Abono = Math.Abs((decimal)this.ValeEmpresarial.Monto);
					CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
					CuentaFlujo.Cargo = 0;
					CuentaFlujo.Concepto = "PAGO CON VALES EMPRESARIALES - CANJE";
					CuentaFlujo.Fecha = getDate;
					CuentaFlujo.Moneda_ID = 4; // Servicios Empresariales
					CuentaFlujo.Saldo = 0; // Se calcula solo
					CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
					CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
					CuentaFlujo.Create();

					CuentaFlujo = new Entities.CuentaFlujoCajas();
					CuentaFlujo.Abono = 0;
					CuentaFlujo.Caja_ID = Sesion.Caja_ID.Value;
					CuentaFlujo.Cargo = Math.Abs((decimal)this.ValeEmpresarial.Monto);
					CuentaFlujo.Concepto = "PAGO CON VALES EMPRESARIALES - CANJE";
					CuentaFlujo.Fecha = getDate;
					CuentaFlujo.Moneda_ID = 1; // efectivo
					CuentaFlujo.Saldo = 0; // Se calcula solo
					CuentaFlujo.Sesion_ID = Sesion.Sesion_ID;
					CuentaFlujo.Usuario_ID = Sesion.Usuario_ID;
					CuentaFlujo.Create();

					MarcarValeEmpresarial(this.ValeEmpresarial);
				}
			}

			private void MarcarValeEmpresarial(Entities.ValesEmpresariales vale)
			{
				vale.EstatusValeEmpresarial_ID = 2;
				vale.Update();
			}

			private void MarcarVale(Entities.ValesPrepagados vale)
			{
				vale.EstatusValePrepagado_ID = 2;
				vale.Update();
			}
		}

		private CanjeVale_Model Model;

		public override void BindData()
		{
			this.Model = new CanjeVale_Model(Sesion.GetSesion());

			this.Model.ConsultarSaldos();
			this.Model.ConsultarMonedas();

			this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = this.Model.Saldos;
			this.monedasBindingSource.DataSource = this.Model.Monedas;
			HabilitaControles();
			SetDefaults();
			base.BindData();
			
		}

		private void SetDefaults()
		{
			this.Model.Moneda_ID = ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Moneda_ID;
			if (this.Model.Moneda_ID == 3)
				this.Model.Concepto = "Canje de Vale Prepagado";
			if (this.Model.Moneda_ID == 4)
				this.Model.Concepto = "Canje de Vale Empresarial";
		}

		private void Imprimir()
		{
			PrintHelper printer = new PrintHelper();

			printer.PrintText("TICKET DE MOVIMIENTO DE FLUJO DE CAJA");
			printer.PrintCLRF();
			printer.PrintText("FOLIO:       {0}", Model.CuentaFlujoCaja_ID);
			printer.PrintText("FECHA:       {0}", DB.GetDate());
			printer.PrintText("MONEDA:      {0}", ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Nombre);
			printer.PrintText("CONCEPTO:    {0}", this.Model.Concepto);
			printer.PrintText("MONTO:       {0:N2}", this.Model.Cargo);
			printer.PrintText("SALDO:       {0:N2}", Model.Saldo);
			printer.PrintCLRF();
			printer.PrintCLRF();
			printer.PrintLine();
			printer.Print();
		}

		private void MonedasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			AppHelper.Try(
			 delegate
			 {
				 this.Model.Moneda_ID = ((Entities.Monedas)this.MonedasComboBox.SelectedItem).Moneda_ID;
				 HabilitaControles();
			 }
		  );
		}

		private void HabilitaControles()
		{
			this.Model.ValePrepagado = null;
			this.Model.ValeEmpresarial = null;
			txtSerie.Clear();
			txtFolio.Clear();
			txtSerie.Enabled = false;
			CargoNumericUpDown.Value = 0;
			CargoNumericUpDown.Enabled = this.Model.Moneda_ID == 4;

			txtSerie.Enabled = this.Model.Moneda_ID == 4;
			if (txtSerie.Enabled) 
				txtSerie.Focus();
			else 
				txtFolio.Focus();
		}

		private void CargoNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			AppHelper.Try(
			 delegate
			 {
				 this.Model.Cargo = this.CargoNumericUpDown.Value;
			 }
		  );
		}

		private void GuardarButton_Click(object sender, EventArgs e)
		{
			bool b = false;
			AppHelper.DoTransactions(
			 delegate
			 {
				 this.Model.Fecha = DB.GetDate();
				 this.Model.Guardar();
				 b = true;
			 },
			 this
		  );
			if (b)
			{
				AppHelper.DoMethod(
				    delegate
				    {
					    Imprimir();
					    this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = null;
					    this.Model.ConsultarSaldos();
					    this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = this.Model.Saldos;
					    AppHelper.ClearControl(this);
					    SetDefaults();
					    AppHelper.Info("Movimiento Realizado");
					    MonedasComboBox_SelectionChangeCommitted(null,null);
				    },
				    this
				);
			}
		}

		private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == (char)Keys.Enter)
				{
					if (string.IsNullOrEmpty(txtSerie.Text) && txtSerie.Enabled)//vale 
					{
						throw new Exception("Se debe Indicar la Serie del Vale");
					}
					if (string.IsNullOrEmpty(txtFolio.Text))
					{
						throw new Exception("Se requiere un Folio del Vale");
					}
					if (!AppHelper.IsNumeric(txtFolio.Text))
					{
						throw new Exception("Debe teclar datos numéricos");
					}
					if (this.Model.Moneda_ID == 3)
					{
						AgregarValePrepagado(txtFolio.Text.Trim());
					}
					else
					{
						AgregarValeEmpresarial(txtSerie.Text.Trim(), txtFolio.Text.Trim());
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void AgregarValeEmpresarial(string serie, string folio)
		{
			Entities.ValesEmpresariales.Validar(serie, Convert.ToInt32(folio));
			KeyValuePair<string, object> a1 = new KeyValuePair<string, object>("serie", serie);
			KeyValuePair<string, object> a2 = new KeyValuePair<string, object>("folio", folio);
			this.Model.ValeEmpresarial = Entities.ValesEmpresariales.Read(a1, a2);
			CargoNumericUpDown.Focus();
		}

		private void AgregarValePrepagado(string valeprepagado)
		{
			Entities.ValesPrepagados.Validar(valeprepagado);
			this.Model.ValePrepagado = Entities.ValesPrepagados.Read(valeprepagado);
			CargoNumericUpDown.Value = this.Model.ValePrepagado.Denominacion;
			GuardarButton.Focus();
		}
	}
}