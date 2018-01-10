using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	public partial class AdendumAltaEdicion : Form
	{
		public int ContratoID { get; set; }
		public int AdendumID { get; set; }
		DateTime? FechaFinal { get; set; }
		bool EsEdicion { get; set; }
		public DataTable tablaAdendums { get; set; }
		internal DateTime FechaInicialContrato { get; set; }
		internal DateTime FechaFinalContrato { get; set; }

		public AdendumAltaEdicion()
		{
			InitializeComponent();
		}

		public AdendumAltaEdicion(int adendumID, int contratoID, int? ClasificacionID, DateTime? dtInicio, DateTime? dtFin, bool? esIndefinido, string observaciones, bool esEdicion)
		{
			InitializeComponent();
			ObtenerClasificaciones();
			Inicializar(adendumID, contratoID, ClasificacionID, dtInicio, dtFin, esIndefinido, observaciones, esEdicion);
		}

		public AdendumAltaEdicion(Entities.Vista_ContratosAdendumDetalle item, bool esEdicion)
		{
			InitializeComponent();
			ObtenerClasificaciones();
			Inicializar(item.Adendum_ID, item.Contrato_ID, item.ClasificacionAdendum_ID, item.FechaInicio, item.FechaFin, item.Indefinido, item.Observaciones, esEdicion);
		}

		private void Inicializar(int adendumID, int contratoID, int? ClasificacionID, DateTime? dtInicio, DateTime? dtFin, bool? esIndefinido, string observaciones, bool esEdicion)
		{
			this.ContratoID = contratoID;
			this.EsEdicion = esEdicion;
			this.AdendumID = adendumID;

			if (esEdicion)
			{
				this.txtObservaciones.Text = (string.IsNullOrEmpty(observaciones)) ? "" : observaciones;
				this.cmbConceptoClasificacion.SelectedValue = ClasificacionID.Value;
				this.cmbConceptoClasificacion.Enabled = false;

				if (dtInicio.HasValue)
					this.datePickInicio.Value = dtInicio.Value;
				if (dtFin.HasValue)
				{
					this.datePickFin.Value = dtFin.Value;
					FechaFinal = dtFin.Value.Date;
				}
				if (esIndefinido.HasValue)
				{
					this.chkIndefinido.Checked = esIndefinido.Value;

					//if (esIndefinido.Value)
					//{
					//    this.datePickFin.MinDate = DateTime.Now;
					//}
				}

				this.datePickInicio.Enabled = false;
				this.chkIndefinido.Enabled = false;

				this.Text = string.Format("Edicion de adendums -  Contrato {0}", contratoID);
			}
			else
			{
				this.Text = string.Format("Alta de adendums -  Contrato {0}", contratoID);
				this.datePickInicio.Value = DateTime.Now.Date;
				this.datePickFin.Value = DateTime.Now.Date.AddDays(1); ;
			}

		}

		private void ObtenerClasificaciones()
		{
			Entities.Vista_ClasificacionAdendum clasificaciones = new Entities.Vista_ClasificacionAdendum();
			this.cmbConceptoClasificacion.DataSource = new Entities.Vista_ClasificacionAdendum().GetDataTable();
			this.cmbConceptoClasificacion.DisplayMember = "ClasificacionAdendums_Descripcion";
			this.cmbConceptoClasificacion.ValueMember = "ClasificacionAdendum_ID";
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.FechaInicialContrato != null && this.FechaInicialContrato.Date >= this.datePickInicio.Value.Date)
				{
					AppHelper.Error("La fecha de inicial del adendum debe ser mayor a la fecha inicial del contrato");
					return;
				}

				if (this.FechaFinalContrato != null && this.FechaFinalContrato.Date < this.datePickInicio.Value.Date)
				{
					AppHelper.Error("La fecha de inicial del adendum debe ser menor a la fecha final del contrato");
					return;
				}

				if (this.datePickFin.Value.Date < this.datePickInicio.Value.Date)
				{
					AppHelper.Error("La fecha de vencimiento del adendum debe ser mayor o igual a la fecha inicial del adendum");
					return;
				}

				if (this.FechaFinal != null && this.datePickFin.Value > this.FechaFinal)
				{
					AppHelper.Error("La fecha de vencimiento del adendum no debe exceder a la fecha de vencimiento capturada originalmente");
					return;
				}

				System.Collections.Hashtable parametros = new System.Collections.Hashtable();
				string comandoSQL = string.Empty;

				if (this.EsEdicion)
				{
					parametros.Add("@Adendum_ID", this.AdendumID);
					parametros.Add("@FechaFin", this.datePickFin.Value.Date);
					parametros.Add("@Usuario_ID", Sesion.Usuario_ID);
					parametros.Add("@observaciones", this.txtObservaciones.Text.Trim());
					comandoSQL = "exec dbo.usp_Adendums_Actualizacion @Adendum_ID,@FechaFin,@Usuario_ID,@observaciones";
				}
				else
				{
					//antes de dar de alta se verifica si ya se tiene adendums y si ya se tiene se valida que la fecha del adendum a dar de alta
					// no exista previamente
					if (this.tablaAdendums != null && this.tablaAdendums.Rows.Count > 0)
					{
						if (this.tablaAdendums.Select(string.Format("FechaInicio <= '{0}' and FechaFin  >= '{0}'", this.datePickInicio.Value.Date)).Length > 0)
						{
							AppHelper.Error("Ya existe un adendum con las fechas indicadas.");
							return;
						}

						if (this.tablaAdendums.Select(string.Format("FechaInicio <= '{0}' and FechaFin  >= '{0}'", this.datePickFin.Value.Date)).Length > 0)
						{
							AppHelper.Error("Ya existe un adendum con las fechas indicadas.");
							return;
						}

						if (this.tablaAdendums.Select(string.Format("FechaInicio >= '{0}' and FechaFin  <= '{1}'", this.datePickInicio.Value.Date,
						    this.datePickFin.Value.Date)).Length > 0)
						{
							AppHelper.Error("Ya existe un adendum con las fechas indicadas.");
							return;
						}



                        // se cambio de 120 a 180
						if (DateTime.Now.Date.Subtract(new TimeSpan(180, 0, 0, 0)) >= this.datePickInicio.Value.Date)
						{
							AppHelper.Error("La fecha inicial del adendum no debe exceder mas de 180 dias");
							return;
						}
					}

					comandoSQL = string.Concat("exec dbo.usp_Adendums_Registro @Contrato_ID=@Contrato_ID,@ClasificacionAdendum_ID=@ClasificacionAdendum_ID,",
					"@Usuario_ID=@Usuario_ID,@FechaInicio=@FechaInicio,@FechaFin=@FechaFin,@Indefinido=@Indefinido,@Observaciones=@Observaciones");
					parametros.Add("@Contrato_ID", this.ContratoID);
					parametros.Add("@ClasificacionAdendum_ID", int.Parse(this.cmbConceptoClasificacion.SelectedValue.ToString()));
					parametros.Add("@Usuario_ID", Sesion.Usuario_ID);
					parametros.Add("@FechaInicio", this.datePickInicio.Value.Date);
					if (this.chkIndefinido.Checked)
					{
						comandoSQL = "exec dbo.usp_Adendums_Registro @Contrato_ID,@ClasificacionAdendum_ID,@Usuario_ID,@FechaInicio,@Indefinido,@Observaciones";
					}
					else
					{
						parametros.Add("@FechaFin", this.datePickFin.Value.Date.ToString("yyyyMMdd"));
					}
					parametros.Add("@Indefinido", this.chkIndefinido.Checked);

					if (txtObservaciones.Text.Trim().Length > 0)
					{
						parametros.Add("@Observaciones", this.txtObservaciones.Text);
					}
					else
					{
						parametros.Add("@Observaciones", DBNull.Value);
					}
				}
				DB.ExecuteCommand(comandoSQL, parametros);
				MessageBox.Show("Adendum guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void chkIndefinido_CheckedChanged(object sender, EventArgs e)
		{
			DataTable dtClasificacion = this.cmbConceptoClasificacion.DataSource as DataTable;
			DataRow[] drs = dtClasificacion.Select(string.Format("ClasificacionAdendum_ID = {0}", this.cmbConceptoClasificacion.SelectedValue));
			if (this.chkIndefinido.Checked && drs.Length > 0 && drs[0]["AplicaIndeterminado"].ToString() == "False")
			{
				this.chkIndefinido.Checked = false;
				AppHelper.Error("Este tipo de adendum no puede ser indeterminado");
				return;
			}

			if (!this.EsEdicion)
			{
				this.datePickFin.Enabled = !this.chkIndefinido.Checked;
			}
		}

		private void datePickInicio_ValueChanged(object sender, EventArgs e)
		{
			if (this.datePickInicio.Value.Date < DateTime.Now.Date)
			{
				this.datePickFin.Value = this.datePickInicio.Value.AddDays(DateTime.Now.Date.Subtract(this.datePickInicio.Value).Days);
			}
			else
			{
				this.datePickFin.Value = this.datePickInicio.Value.AddDays(1);
			}
		}

		private void cmbConceptoClasificacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataTable dtClasificacion = this.cmbConceptoClasificacion.DataSource as DataTable;
			if (dtClasificacion == null) return;
			if (this.cmbConceptoClasificacion.SelectedValue == null) return;

			DataRowView drv = this.cmbConceptoClasificacion.SelectedValue as DataRowView;
			string clasifId = string.Empty;
			if (drv != null)
			{
				clasifId = drv["ClasificacionAdendum_ID"].ToString();
			}
			else
			{
				clasifId = this.cmbConceptoClasificacion.SelectedValue.ToString();
			}

			DataRow[] drs = dtClasificacion.Select(string.Format("ClasificacionAdendum_ID = {0}", clasifId));
			if (this.chkIndefinido.Checked && drs.Length > 0 && drs[0]["AplicaIndeterminado"].ToString() == "False")
			{
				this.chkIndefinido.Checked = false;
				AppHelper.Error("Este tipo de adendum no puede ser indeterminado");
				return;
			}

			if (!this.EsEdicion)
			{
				this.datePickFin.Enabled = !this.chkIndefinido.Checked;
			}
		}
	}
}
