using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SICASv20.Entities;
using Sicas.Utils;

namespace SICASv20.forms
{
    public partial class ReporteAdendums: baseForm
    {
        private bool EnCarga { get; set; }
        private DataTable dtAdendums { get; set; }
        public bool EsllamadoDesdeAdendums { get; set; }
        public ReporteAdendums()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            base.BindData();
        }

        private void CargarReporteAdendums(string dtIni, string dtFin)
        {   
            if (dtIni != null)
            {
                dtAdendums = new Vista_ReporteAdendums().GetDataTable(dtIni, dtFin);
            }
            else
            {
                dtAdendums = new Vista_ReporteAdendums().GetDataTable();
            }

            if (dtAdendums != null && dtAdendums.Rows.Count > 0)
            {
                this.AdendumReportBindingSource.DataSource = dtAdendums;
                this.LlenarCombosFiltradoDinamico(dtAdendums);
                
            }       
        }

        private void LimpiarCombos()
        {
            this.cboxConcepto.Items.Clear();
            this.cboxCond.Items.Clear();
            this.cboxContrato.Items.Clear();
            this.cboxUnidad.Items.Clear();
        }

        private void LlenarCombosFiltradoDinamico(DataTable tableSource)
        {
            DataSetGroupByHelper groupBy = new DataSetGroupByHelper();
            DataTable dtConcepto = groupBy.SelectGroupByInto("Adendums", tableSource, "ClasificacionAdendums_Descripcion", "", "ClasificacionAdendums_Descripcion", true);
            DataTable dtUnidad = groupBy.SelectGroupByInto("Adendums", tableSource, "NumeroEconomico", "", "NumeroEconomico", true);
            DataTable dtConductor = groupBy.SelectGroupByInto("Adendums", tableSource, "Conductor", "", "Conductor", true);
            DataTable dtContrato = groupBy.SelectGroupByInto("Adendums", tableSource, "Contrato_ID", "", "Contrato_ID", true);

            LimpiarCombos();
            //Concepto
            CargaCombo(dtConcepto, "ClasificacionAdendums_Descripcion", this.cboxConcepto);
            
            //Unidad
            CargaCombo(dtUnidad, "NumeroEconomico", this.cboxUnidad);            

            //Condcutor            
            CargaCombo(dtConductor, "Conductor", this.cboxCond);                        
            
            //Contrato
            CargaCombo(dtContrato, "Contrato_ID", this.cboxContrato);            
        }

        private void CargaCombo(DataTable dtSource, string ColNameValue, ComboBox cb)
        {
            cb.Items.Add("Todos");

            string filtroDefault = "Todos";

            foreach (DataRow row in dtSource.Rows)
            {
                cb.Items.Add(row[ColNameValue].ToString());
                cb.ValueMember = ColNameValue;
                cb.SelectedValue = filtroDefault;
            }
            cb.SelectedItem = filtroDefault;
        }
        
        private void ReporteAdendums_Load(object sender, EventArgs e)
        {
            //Carga inicial, de 7 meses hacia atras
            this.btnRegresar.Visible = false;
            EnCarga = true;
            if (this.EsllamadoDesdeAdendums) this.btnRegresar.Visible = true;
            this.dtpickFechaIni.Value = DateTime.Now.Date.AddMonths(-4);
            this.dtPickFin.Value = DateTime.Now.Date.AddMonths(3);;
            CargarReporteAdendums(this.dtpickFechaIni.Value.ToString("yyyyMMdd"), this.dtPickFin.Value.ToString("yyyyMMdd"));
            EnCarga = false;
        }

        private void cboxUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnCarga) return;
            string Concepto = string.Empty;
            string Cond = string.Empty;
            string Unidad = string.Empty;
            string Contrato = string.Empty;

            StringBuilder sb = new StringBuilder();
            
            if (this.cboxConcepto.SelectedItem != null && this.cboxConcepto.SelectedItem.ToString() != "Todos")
            {
                Concepto = this.cboxConcepto.SelectedItem.ToString();
                sb.AppendFormat("ClasificacionAdendums_Descripcion = '{0}' AND ", Concepto);
            }
            if (this.cboxCond.SelectedItem != null && this.cboxCond.SelectedItem.ToString() != "Todos")
            {
                Cond = this.cboxCond.SelectedItem.ToString();
                sb.AppendFormat("Conductor = '{0}' AND ", Cond);
            }
            if (this.cboxUnidad.SelectedItem != null && this.cboxUnidad.SelectedItem.ToString() != "Todos")
            {
                Unidad = this.cboxUnidad.SelectedItem.ToString();
                sb.AppendFormat("NumeroEconomico = '{0}' AND ", Unidad);
            }
            if (this.cboxContrato.SelectedItem != null && this.cboxContrato.SelectedItem.ToString() != "Todos")
            {
                Contrato = this.cboxContrato.SelectedItem.ToString();
                sb.AppendFormat("Contrato_ID = '{0}' AND ", Contrato);
            }

            if (sb.ToString().Length > 0)
            {
                DataRow[] drs = this.dtAdendums.Select(sb.ToString(0, sb.ToString().Length - 5));
                DataTable dt = this.dtAdendums.Clone();
                foreach (DataRow item in drs)
                {
                    dt.ImportRow(item);                    
                }
                this.AdendumReportBindingSource.DataSource = dt;
            }
            else
            {
                //Deberia mandarse un mensaje aqui???                
                this.AdendumReportBindingSource.DataSource = this.dtAdendums;
            }
        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (this.dtPickFin.Value.Date < this.dtpickFechaIni.Value.Date)
            {
                AppHelper.Error("La fecha inicial debe ser mayor a la fecha final");
                return;
            }
            CargarReporteAdendums(this.dtpickFechaIni.Value.Date.ToString("yyyyMMdd"), this.dtPickFin.Value.Date.ToString("yyyyMMdd"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Default = "Todos";
            this.cboxConcepto.SelectedItem = Default;
            this.cboxCond.SelectedItem = Default;
            this.cboxContrato.SelectedItem = Default;
            this.cboxUnidad.SelectedItem = Default;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Adendums rep = new Adendums();            
            Padre.SwitchForma("Adendums", rep);
        }
    }
}

