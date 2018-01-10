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
	/// Formulario para mostrar el reporte de tickets por empresa
	/// </summary>
	public partial class ReporteTicketsEmpresa : baseForm
	{
		public ReporteTicketsEmpresa()
		{
			InitializeComponent();
		}

		/// <summary>
		/// El modelo de logia de negocios que contiene las funciones
		/// para llevar a cabo el reporte de tickets de estación
		/// </summary>
		class ReporteTicketsEstacion_Model
		{
			/// <summary>
			/// El listado de tickets
			/// </summary>
			public List<Entities.Vista_TicketsDeSesion> Tickets
			{
				get
				{
					return _Tickets;
				}
			}
			private List<Entities.Vista_TicketsDeSesion> _Tickets;

			/// <summary>
			/// La fecha inicial del reporte
			/// </summary>
			public DateTime? FechaInicial
			{
				get { return _FechaInicial; }
				set { _FechaInicial = value; }
			}
			private DateTime? _FechaInicial;

			/// <summary>
			/// La fecha final del reporte
			/// </summary>
			public DateTime? FechaFinal
			{
				get { return _FechaFinal; }
				set { _FechaFinal = value; }
			}
			private DateTime? _FechaFinal;

			/// <summary>
			/// La empresa seleccionada
			/// </summary>
			public int? Empresa_ID
			{
				get { return _Empresa_ID; }
				set { _Empresa_ID = value; }
			}
			private int? _Empresa_ID;

			/// <summary>
			/// Consulta el listado de tickets en la base de datos
			/// </summary>
			public void ConsultarTickets()
			{
				this._Tickets =
				    Entities.Vista_TicketsDeSesion.GetTicketsEmpresa(
				    this.FechaInicial,
				    this.FechaFinal,
				    this.Empresa_ID
				    );
			}
		}

		/// <summary>
		/// Modelo de lógica de negocios a utilizar en la forma
		/// </summary>
		ReporteTicketsEstacion_Model Model;

		/// <summary>
		/// Proceso llevado a cabo para cargar datos y preparar la forma
		/// </summary>
		public override void BindData()
		{
			List<Entities.SelectCajasActivas> cajas = Sesion.CajasActivasPorUsuario;
			if (cajas.Count <= 2)
			{
				FechaInicialDateTimePicker.Value = DateTime.Now.Date.AddDays(-1);
				FechaFinalDateTimePicker.Value = FechaInicialDateTimePicker.Value;

				FechaInicialDateTimePicker.MaxDate = FechaInicialDateTimePicker.Value;
				FechaFinalDateTimePicker.MaxDate = FechaInicialDateTimePicker.Value;
			}

			Model = new ReporteTicketsEstacion_Model();
			base.BindData();
		}

		/// <summary>
		/// Maneja el evento "Click" del control "ConsultarButton"
		/// </summary>
		/// <param name="sender">El control "ConsultarButton"</param>
		/// <param name="e">Los argumentos del evento</param>
		private void ConsultarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate
			{
				Model.FechaInicial = DB.GetNullableDateTime(AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value));
				Model.FechaFinal = DB.GetNullableDateTime(AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value));
				Model.Empresa_ID = Sesion.Empresa_ID;
				Model.ConsultarTickets();
				this.vista_TicketsDeSesionBindingSource.DataSource = Model.Tickets;
				this.reportViewer1.RefreshReport();
			}, this);
		}
	} // end class ReporteTicketsEmpresa
}// end namespace SICASv20.forms
