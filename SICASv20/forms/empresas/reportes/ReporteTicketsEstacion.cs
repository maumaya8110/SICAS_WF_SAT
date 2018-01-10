using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	public partial class ReporteTicketsEstacion : baseForm
	{
		public ReporteTicketsEstacion()
		{
			InitializeComponent();
		}

		class ReporteTicketsEstacion_Model
		{
			public ReporteTicketsEstacion_Model()
			{

			}

			private List<Entities.SelectEstaciones> _Estaciones;
			public List<Entities.SelectEstaciones> Estaciones
			{
				get
				{
					return _Estaciones;
				}
			}

			private List<Entities.Vista_TicketsDeSesion> _Tickets;
			public List<Entities.Vista_TicketsDeSesion> Tickets
			{
				get
				{
					return _Tickets;
				}
			}

			private DateTime? _FechaInicial;
			public DateTime? FechaInicial
			{
				get { return _FechaInicial; }
				set { _FechaInicial = value; }
			}

			private DateTime? _FechaFinal;
			public DateTime? FechaFinal
			{
				get { return _FechaFinal; }
				set { _FechaFinal = value; }
			}

			private int? _Estacion_ID;
			public int? Estacion_ID
			{
				get { return _Estacion_ID; }
				set { _Estacion_ID = value; }
			}

			public string Usuario_ID { get; set; }

			public void ConsultarEstaciones()
			{
				this._Estaciones = Sesion.EstacionesTodas;
			}

			public void ConsultarTickets()
			{
				this._Tickets =
				    Entities.Vista_TicketsDeSesion.GetTicketsEstacion(
				    this.FechaInicial,
				    this.FechaFinal,
				    this.Estacion_ID,
				    this.Usuario_ID
				    );
			}
		}

		ReporteTicketsEstacion_Model Model;

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
			Model.Usuario_ID = Sesion.Usuario_ID;
			Model.ConsultarEstaciones();
			selectEstacionesBindingSource.DataSource = Model.Estaciones;
			base.BindData();
		}

		private void ConsultarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate
			{
				Model.Estacion_ID = DB.GetNullableInt32(this.EstacionesComboBox.SelectedValue);
				Model.FechaInicial = DB.GetNullableDateTime(AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value));
				Model.FechaFinal = DB.GetNullableDateTime(AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value));
				Model.ConsultarTickets();
				this.vista_TicketsDeSesionBindingSource.DataSource = Model.Tickets;
				this.reportViewer1.RefreshReport();
			}, this);
		}
	}
}