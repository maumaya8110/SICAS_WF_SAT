using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;

namespace SICASv20.forms
{
	public partial class AltaValesPrepagados : baseForm
	{
		#region Constructors

		public AltaValesPrepagados()
		{
			InitializeComponent();
			AppHelper.AddTextBoxesOnlyNumbersValidation(txtCantidad, txtDenominacion);
		}

		#endregion

		#region Properties

		private Model model;

		#endregion

		#region Model

		class Model
		{
			private BindingList<Entities.Empresas> _Empresas;
			public BindingList<Entities.Empresas> Empresas
			{
				get { return _Empresas; }
				set { _Empresas = value; }
			}

			private BindingList<Entities.Empresas> _EmpresasGrupo;
			public BindingList<Entities.Empresas> EmpresasGrupo
			{
				get { return _EmpresasGrupo; }
				set { _EmpresasGrupo = value; }
			}

			private List<Entities.ValesPrepagados> _Vales;
			public List<Entities.ValesPrepagados> Vales
			{
				get { return _Vales; }
				set { _Vales = value; }
			}

			private List<Entities.Vista_ValesPrepagados> _Vista_Vales1;
			public List<Entities.Vista_ValesPrepagados> Vista_Vales1
			{
				get { return _Vista_Vales1; }
				set { _Vista_Vales1 = value; }
			}

			private List<Entities.Vista_ValesPrepagados> _Vista_Vales2;
			public List<Entities.Vista_ValesPrepagados> Vista_Vales2
			{
				get { return _Vista_Vales2; }
				set { _Vista_Vales2 = value; }
			}

			private decimal _Denominacion;
			public decimal Denominacion
			{
				get { return _Denominacion; }
				set { _Denominacion = value; }
			}

			private int _Cantidad;
			public int Cantidad
			{
				get { return _Cantidad; }
				set { _Cantidad = value; }
			}

			private Entities.Empresas _EmpresaCliente;
			public Entities.Empresas EmpresaCliente
			{
				get { return _EmpresaCliente; }
				set { _EmpresaCliente = value; }
			}

			private Entities.Empresas _Empresa;
			public Entities.Empresas Empresa
			{
				get { return _Empresa; }
				set { _Empresa = value; }
			}

			private Entities.Empresas _EmpresaEmite;
			public Entities.Empresas EmpresaEmite
			{
				get { return _EmpresaEmite; }
				set { _EmpresaEmite = value; }
			}

			private int _Folio;
			public int Folio
			{
				get { return _Folio; }
				set { _Folio = value; }
			}

			private void Validar()
			{
				if (Empresa == null) throw new Exception("Debe seleccionar una Empresa");
				if (EmpresaCliente == null) throw new Exception("Debe seleccionar un cliente");
				if (Denominacion <= 0) throw new Exception("Debe capturar una denominación. Esta debe ser mayor a 0.");
				if (Cantidad <= 0) throw new Exception("Debe capturar una cantidad. Esta debe ser mayor que 0");
			}

			private string CrearCodigo()
			{
				string codigo = "", sqlstr = "";

				sqlstr = @"SELECT ISNULL(MAX(FolioDiario),0) + 1 
                            FROM ValesPrepagados 
                            WHERE FechaEmision > @FechaEmision 
                            AND EmpresaCliente_ID = @EmpresaCliente_ID
                            AND Empresa_ID = @EmpresaEmite_ID";

				Folio = Convert.ToInt32(
				    DB.QueryScalar(sqlstr,
					   DB.Param("@FechaEmision", DB.GetDate().Date),
						  DB.Param("@EmpresaCliente_ID", EmpresaCliente.Empresa_ID),
						  DB.Param("@EmpresaEmite_ID", EmpresaEmite.Empresa_ID)));

				codigo = String.Format("{0}{1:yyMMddHHmm}{2}{3}",
				    EmpresaCliente.Empresa_ID, DB.GetDate(), Strings.Right("0000" + Folio.ToString(), 4), EmpresaEmite.Empresa_ID);

				return codigo;
			}

			public void CrearVales()
			{
				Validar();

				Vales = new List<Entities.ValesPrepagados>();
				Vista_Vales1 = new List<Entities.Vista_ValesPrepagados>();
				Vista_Vales2 = new List<Entities.Vista_ValesPrepagados>();
				Entities.ValesPrepagados vale;
				int i = 0;

				for (i = 0; i < Cantidad; i++)
				{
					vale = new Entities.ValesPrepagados(CrearCodigo(), EmpresaCliente.Empresa_ID, Sesion.Usuario_ID, 1, null, Folio,
					    Denominacion, DB.GetDate(), DB.GetDate().AddMonths(3), null, EmpresaEmite.Empresa_ID);
					vale.Create();
					Vales.Add(vale);

					if ((Vales.Count % 2) == 0)
					{
						Vista_Vales1.Add(
							   Entities.Vista_ValesPrepagados.Get(vale.ValePrepagado_ID)
						    );
					}
					else
					{
						Vista_Vales2.Add(
							   Entities.Vista_ValesPrepagados.Get(vale.ValePrepagado_ID)
						    );
					}
				}
			}

			public void ConsultarEmpresas()
			{
				this.Empresas =
				    new BindingList<Entities.Empresas>(
					   Entities.Empresas.ReadList(DB.Param("TipoEmpresa_ID", 3)));
			}

			public void ConsultarEmpresasxTipo(int tipo)
			{
				this.EmpresasGrupo =
				    new BindingList<Entities.Empresas>(
					   Entities.Empresas.ReadList(DB.Param("TipoEmpresa_ID", tipo)));
			}
		}

		#endregion

		#region Events

		public override void BindData()
		{
			this.model = new Model();
			this.model.ConsultarEmpresas();
			this.empresasBindingSource.DataSource = this.model.Empresas;

			this.model.ConsultarEmpresasxTipo(2);
			this.empresasGrupoBindingSource.DataSource = this.model.EmpresasGrupo;
			base.BindData();
		}

		private void ImprimirVales()
		{
			ReportDataSource rds1 = new ReportDataSource("dsValesPrepagados_ValesPrepagados", this.model.Vista_Vales1);
			ReportDataSource rds2 = new ReportDataSource("dsValesPrepagadosDer_ValesPrepagadosDer", this.model.Vista_Vales2);

			LocalReport report = new LocalReport();
			report.ReportEmbeddedResource = "SICASv20.reports.callcenter.Template_ValesPrepagados.rdlc";
			report.DataSources.Add(rds1);
			report.DataSources.Add(rds2);
			report.Refresh();

			//AppHelper.PrintReport(report, "ValesPrepagados");
			PrintReportHelper IR = new PrintReportHelper();
			IR.Ancho = 11;
			IR.Alto = 8.5;
			IR.Export(report);
			IR.m_currentPageIndex = 0;
			IR.Print();
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (EmpresasClientesComboBox.SelectedItem != null)
				{
					Entities.Empresas empresa = (Entities.Empresas)EmpresasCASCOComboBox.SelectedItem;
					this.model.Empresa = empresa;
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void EmpresasCASCOComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (EmpresasCASCOComboBox.SelectedItem != null)
				{
					Entities.Empresas empresa = (Entities.Empresas)EmpresasCASCOComboBox.SelectedItem;
					this.model.EmpresaEmite = empresa;
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void EmpresasClientesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				if (EmpresasClientesComboBox.SelectedItem != null)
				{
					Entities.Empresas empresa = (Entities.Empresas)EmpresasClientesComboBox.SelectedItem;
					this.model.EmpresaCliente = empresa;
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void EmpresasCASCOComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				if (EmpresasClientesComboBox.SelectedItem != null)
				{
					Entities.Empresas empresa = (Entities.Empresas)EmpresasCASCOComboBox.SelectedItem;
					this.model.EmpresaEmite = empresa;
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void txtDenominacion_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.model.Denominacion = AppHelper.GetValue<decimal>(this.txtDenominacion.Text);
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void txtCantidad_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.model.Cantidad = AppHelper.GetValue<int>(this.txtCantidad.Text);
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		/// <summary>
		/// Imprime y crea los vales al clic del botón "Aceptar"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AceptarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate
			{
				//  Crear los vales
				model.CrearVales();

				List<Entities.Vista_ValesPrepagados> vales = new List<Entities.Vista_ValesPrepagados>();
				vales.AddRange(this.model.Vista_Vales1);

				if (this.model.Vista_Vales2 != null)
				{
					if (this.model.Vista_Vales2.Count > 0)
					{
						vales.AddRange(this.model.Vista_Vales2);
					}
				}

				this.vista_ValesPrepagadosBindingSource.DataSource = vales;

				//  Mensaje al usuario
				AppHelper.Info("Vales Creados");
			}, this);
		}

		private void ImprimirButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate
			{
				if (this.model.Vista_Vales1 == null ||
				    this.model.Vista_Vales1.Count == 0 ||
				    this.model.Vista_Vales2 == null)
				{
					AppHelper.ThrowException("Debe haber creado los vales antes de imprimirlos");
				}

				//  Imprimir vales
				this.ImprimirVales();

				//  Regresar a estado inicial
				//  Nuevo modelo
				model = new Model();

				//  Clear a controles
				this.txtCantidad.Text = "";
				this.txtDenominacion.Text = "";
				this.vista_ValesPrepagadosBindingSource.DataSource = null;

				//  Cargar datos iniciales volviendo a llamar a BindData
				BindData();

				//  Mensaje al usuario
				AppHelper.Info("Vales Impresos");
			}, this);
		}
		#endregion

	}
}
