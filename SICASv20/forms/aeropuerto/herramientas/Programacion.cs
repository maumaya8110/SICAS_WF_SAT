using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.herramientas
{
	public partial class Programacion : baseForm
	{
		DataTable dtPistasXSemana = new DataTable();
		Entities.Vista_ProgramacionPista Programaciones = new Entities.Vista_ProgramacionPista();
		bool Editado = false;
		private string NombrePrimerColumna = "Periodo";
		private int ColumnIdx = 0;
		private int RowIdx = 0;
		private bool b = false;
		private Color FilaSeleccionada { get { return Color.LightSkyBlue; } }
		private Color CeldaEditable { get { return Color.White; } }
		private Color CeldaBloqueada { get { return Color.DarkGray; } }

		public Programacion()
		{
			InitializeComponent();
			dgvProgramacion.AutoGenerateColumns = false;
			AppHelper.Try(DoSetInfo);
		}

		private void DoSetInfo()
		{
			Programaciones.ActualizaProgramaciones(DateTime.Now);
			SetInfoPistas(Programaciones.SemanaActualAñoActual);
			dgvProgramacion.Rows[0].Cells[3].Selected = true;
			b = true;
			SetInfoCharts(DateTime.Today.AddDays(1),2);
		}

		private void SetInfoCharts(DateTime fecha, int num)
		{
			if (dgvProgramacion.SelectedCells.Count > 0)
			{
				string nombre_dia = Application.CurrentCulture.DateTimeFormat.GetDayName(fecha.DayOfWeek).ToUpper();
				Dictionary<string, List<classes.Aeropuerto.ProgramacionPistas>> SeriesPistas = new Dictionary<string, List<classes.Aeropuerto.ProgramacionPistas>>();
				List<classes.Aeropuerto.ProgramacionPistas> pistasSemanaActualAñoActual = Programaciones.SemanaActualAñoActual.FindAll(n => n.Dia_Semana.ToUpper() == nombre_dia.ToUpper());

				List<classes.Aeropuerto.ProgramacionPistas> pistasAñoActual = Programaciones.UltimasSemanasAñoActual.FindAll(n => n.Dia_Semana.ToUpper() == nombre_dia.ToUpper() && n.HPeriodo.TimeOfDay == pistasSemanaActualAñoActual[RowIdx].HPeriodo.TimeOfDay);
				List<classes.Aeropuerto.ProgramacionPistas> pistasAñoAnterior = Programaciones.UltimasSemanasAñoAnterior.FindAll(n => n.Dia_Semana.ToUpper() == nombre_dia.ToUpper() && n.HPeriodo.TimeOfDay == pistasSemanaActualAñoActual[RowIdx].HPeriodo.TimeOfDay);
				SeriesPistas = new Dictionary<string, List<classes.Aeropuerto.ProgramacionPistas>>();
				SeriesPistas.Add("Año Anterior", pistasAñoAnterior);
				SeriesPistas.Add("Año Actual", pistasAñoActual);
				string stitulo = (nombre_dia.EndsWith("S")) ? nombre_dia : nombre_dia + "S";
				stitulo += " - A las " + pistasSemanaActualAñoActual[RowIdx].HPeriodo.TimeOfDay.ToString();

				if (num > 1)
				{
					List<classes.Aeropuerto.ProgramacionPistas> pistasSemanaAnteriorAñoActual = Programaciones.SemanaAnteriorAñoActual.FindAll(n => n.Dia_Semana.ToUpper() == nombre_dia.ToUpper());
					List<classes.Aeropuerto.ProgramacionPistas> pistasSemanaActualAñoAnterior = Programaciones.SemanaActualAñoAnterior.FindAll(n => n.Dia_Semana.ToUpper() == nombre_dia.ToUpper());
					SeriesPistas.Clear();
					SeriesPistas.Add("Sem. Act. Año Anterior", pistasSemanaActualAñoAnterior);
					SeriesPistas.Add("Sem. Ant. Año Actual", pistasSemanaAnteriorAñoActual);
					SeriesPistas.Add("Sem. Act. Año Actual", pistasSemanaActualAñoActual);
				}				
			}
		}

		private void SetInfoPistas(List<classes.Aeropuerto.ProgramacionPistas> list)
		{
			List<List<object>> filas = new List<List<object>>();
			string sDia = list[0].Dia_Semana;
			
			//Obtiene los Periodos y datos del primer día
			foreach (classes.Aeropuerto.ProgramacionPistas pp in list)
			{
				if (pp.Dia_Semana == sDia)
				{
					List<object> fila = new List<object>();
					fila.Add(pp.HPeriodo); 
					fila.Add(pp.Id);
					fila.Add(pp.Dia);
					fila.Add(pp.Dia_Semana);
					fila.Add(pp.Servicios_Disponibles);
					fila.Add(pp.Servicios_Programados);
					filas.Add(fila);
				}
			}

			//Obtiene Datos del Resto de los dias
			int idx_c = 1;
			while (idx_c < (list.Count / filas.Count))
			{
				int idx_f = 0;
				while (idx_f < filas.Count)
				{
					filas[idx_f].Add(list[(filas.Count * idx_c) + idx_f].Id);
					filas[idx_f].Add(list[(filas.Count * idx_c) + idx_f].Dia);
					filas[idx_f].Add(list[(filas.Count * idx_c) + idx_f].Dia_Semana);
					filas[idx_f].Add(list[(filas.Count * idx_c) + idx_f].Servicios_Disponibles);
					filas[idx_f].Add(list[(filas.Count * idx_c) + idx_f].Servicios_Programados);
					idx_f++;
				}
				idx_c++;
			}

			//Crea la definicion de Columnas
			dtPistasXSemana.Clear();
			dtPistasXSemana.Columns.Clear();
			dtPistasXSemana.Rows.Clear();
			dgvProgramacion.Columns.Clear();

			DataColumn dc = new DataColumn(NombrePrimerColumna, typeof(string));
			dc.Caption = NombrePrimerColumna;
			dtPistasXSemana.Columns.Add(dc);

			DataGridViewColumn dgvc = new DataGridViewColumn();
			dgvc.DataPropertyName = dc.ColumnName;
			dgvc.Frozen = true;
			dgvc.HeaderText = dc.Caption;
			dgvc.Name = "gdvc" + dc.ColumnName;
			dgvc.ReadOnly = true;
			dgvc.Resizable = DataGridViewTriState.False;
			dgvc.ValueType = typeof(string);
			dgvc.Visible = true;
			dgvc.Width = 70;
			DataGridViewCell celda = new DataGridViewTextBoxCell();
			dgvc.CellTemplate = celda;
			dgvProgramacion.Columns.Add(dgvc);

			int i = 1;
			List<object> f = filas[0];
			while (i < f.Count)
			{
				DateTime aux = Convert.ToDateTime(f[i + 1].ToString());
				string nombre_dia = Application.CurrentCulture.DateTimeFormat.GetDayName(aux.DayOfWeek).ToUpper();
				celda = new DataGridViewTextBoxCell();
				celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				celda.Style.Format = "G";

				dc = new DataColumn("Id_" + f[i].ToString(), typeof(Int32));
				dc.Caption = "";
				dtPistasXSemana.Columns.Add(dc);

				dc = new DataColumn("Dia_" + aux.ToShortDateString(), typeof(DateTime));
				dc.Caption = "";
				dtPistasXSemana.Columns.Add(dc);

				dc = new DataColumn("Dia_Semana_" + aux.ToShortDateString(), typeof(String));
				dc.Caption = "";
				dtPistasXSemana.Columns.Add(dc);

				dc = new DataColumn("DiaDisponibles_" + aux.ToShortDateString(), typeof(Int32));
				dc.Caption = nombre_dia + " \n\r Disponibles";
				dtPistasXSemana.Columns.Add(dc);

				dgvc = new DataGridViewColumn();
				dgvc.DataPropertyName = dc.ColumnName;
				dgvc.Frozen = false;
				dgvc.HeaderText = dc.Caption;
				dgvc.Name = "gdvc" + dc.ColumnName;
				
				dgvc.ReadOnly = (nombre_dia == Application.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek).ToUpper());
				if (i == 1)
				{
					dgvc.DefaultCellStyle.BackColor = CeldaBloqueada;
				}
				dgvc.Resizable = DataGridViewTriState.False;
				dgvc.ValueType = typeof(int);
				dgvc.Visible = true;
				dgvc.Width = 80;				
				dgvc.CellTemplate = celda;
				dgvProgramacion.Columns.Add(dgvc);

				dc = new DataColumn("DiaProgramado_" + aux.ToShortDateString(), typeof(Int32));
				dc.Caption = nombre_dia + " \n\r Programado";
				dtPistasXSemana.Columns.Add(dc);

				dgvc = new DataGridViewColumn();
				dgvc.DataPropertyName = dc.ColumnName;
				dgvc.Frozen = false;
				dgvc.HeaderText = dc.Caption;
				dgvc.Name = "gdvc" + dc.ColumnName;
				dgvc.ReadOnly = true;
				dgvc.Resizable = DataGridViewTriState.False;
				dgvc.ValueType = typeof(int);
				dgvc.Visible = true;
				dgvc.Width = 80;
				dgvc.DefaultCellStyle.BackColor = CeldaBloqueada;
				dgvc.CellTemplate = celda;

				dgvProgramacion.Columns.Add(dgvc);

				i += 5;
			}

			foreach (List<object> fila in filas)
			{
				DataRow dr = dtPistasXSemana.NewRow();
				dr[0] = Convert.ToDateTime(fila[0].ToString()).ToShortTimeString();
				for (int ix = 1; ix < fila.Count; ix++)
				{
					dr[ix] = fila[ix];
				}
				dtPistasXSemana.Rows.Add(dr);
			}
			dtPistasXSemana.AcceptChanges();

			dgvProgramacion.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvProgramacion.BorderStyle = BorderStyle.FixedSingle;
			dgvProgramacion.GridColor = Color.Black;
			dgvProgramacion.DataSource = dtPistasXSemana;

			
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			AppHelper.Try(DoSave);
		}

		private void DoSave()
		{
			//DoValidate();
			
			DoUpdate();
			
			Editado = false;
			btnActualizar_Click(null, null);
		}

		private void DoUpdate()
		{
			bool b = false;	
			foreach (DataRow fila in dtPistasXSemana.Rows)
			{
				if (fila.RowState == DataRowState.Modified)
				{
					int ix = 1;
					while (ix < dtPistasXSemana.Columns.Count)
					{
						Entities.Vista_ProgramacionPista.ActualizaPista(Convert.ToInt32(fila[ix]), Convert.ToInt32(fila[ix + 3]), Sesion.Usuario_ID);
						ix += 5;
					}
					fila.AcceptChanges();
					b = true;
				}
			}
			if (b)
			{
				SendMailProgramacionesUpdate();
			}
		}

		private void SendMailProgramacionesUpdate()
		{
			string body = "Por este medio se les informa que el usuario {0} realizó una actualización a la programación de Pistas de Aeropuerto desde el sistema SICAS.\r\n" +
				"Favor de considerar este mensaje para la programación de futuros servicios.\r\n" +
				"Por favor, no responda este correo. De antemano, mil gracias.";
			body = string.Format(body, SICASv20.Sesion.Usuario_ID);
			string title = "Actualización en la Programación de Pistas de Aeropuerto";
			string from = "sicas@casco.com.mx";
			string to = "galdino.melchor@casco.com.mx;samuel.maldonado@axertis.com";
			AppHelper.SendEmail(from, to, title, body, false);
		}

		private void dgvProgramacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Editado = true;
			dgvProgramacion.Rows[e.RowIndex].ErrorText = String.Empty;
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			if (Editado)
			{
				if (MessageBox.Show("Los cambios realizados en la Programación no han sido guardados.\n\rAún así desea Continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
					return;
			}
			AppHelper.Try(DoSetInfo);
		}

		private void dgvProgramacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (dgvProgramacion.Columns[e.ColumnIndex].HeaderText != NombrePrimerColumna)
			{
				string Msg;
				int ivalue;
				if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
				{
					Msg = "Debe Ingresar un Valor";
					MessageBox.Show(Msg,"Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
					dgvProgramacion.Rows[e.RowIndex].ErrorText = Msg;
					e.Cancel = true;
				}

				if (!e.Cancel && !int.TryParse(e.FormattedValue.ToString(), out ivalue))
				{
					Msg = "Debe Ingresar un Valor Númerico";
					MessageBox.Show(Msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
					dgvProgramacion.Rows[e.RowIndex].ErrorText = Msg;
					e.Cancel = true;
				}
				
			}
		}

		private void dgvProgramacion_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex > -1 && b)
			{
				int cidx = e.ColumnIndex;
				cidx = (cidx % 2) == 0 ? e.ColumnIndex - 1 : e.ColumnIndex;

				if (cidx != ColumnIdx && cidx > -1)
				{
					ColumnIdx = cidx;
					RowIdx = e.RowIndex;
					int col_Idx=(((ColumnIdx - 1) / 2) * 5) + 2;
					SetInfoCharts(Convert.ToDateTime(dtPistasXSemana.Rows[0][col_Idx]), 2);
				}
				else if (e.RowIndex != RowIdx)
				{
					RowIdx = e.RowIndex;
					int col_Idx = (((ColumnIdx - 1) / 2) * 5) + 2;
					SetInfoCharts(Convert.ToDateTime(dtPistasXSemana.Rows[0][col_Idx]), 1);
				}
			}
			if (e.ColumnIndex >= 3 && e.RowIndex > 0)
			{
				dgvProgramacion[0, e.RowIndex].Style.BackColor = FilaSeleccionada;
				for (int i = 3; i < dgvProgramacion.Columns.Count; i++)
				{
					if (i % 2 != 0)
					{
						dgvProgramacion[i, e.RowIndex].Style.BackColor = FilaSeleccionada;
					}
				}
			}
		}

		private void dgvProgramacion_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				dgvProgramacion[0, e.RowIndex].Style.BackColor = CeldaEditable;
				for (int i = 3; i < dgvProgramacion.Columns.Count; i++)
				{
					if (i % 2 != 0)
					{
						dgvProgramacion[i, e.RowIndex].Style.BackColor = CeldaEditable;
					}
				}
			}
		}

	}
}
