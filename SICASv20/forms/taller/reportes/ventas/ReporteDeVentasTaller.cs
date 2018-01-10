using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteDeVentasTaller : baseForm
    {
        public ReporteDeVentasTaller()
        {
            InitializeComponent();
        }

        string sqlqry = "SELECT @GroupSelect, SUM(ManoObra) ManoObra, SUM(Refacciones) Refacciones, SUM(Subtotal) Subtotal, SUM(IVA) IVA, SUM(Total) Total \r\n" +
            "FROM	OrdenesTrabajos OT \r\n" +
            "INNER JOIN	TiposMantenimientos TM \r\n" +
            "ON		OT.TipoMantenimiento_ID = TM.TipoMantenimiento_ID \r\n" +
            "INNER JOIN	Empresas EC \r\n" +
            "ON		OT.ClienteFacturar_ID = EC.Empresa_ID \r\n" +
            "WHERE @Filter GROUP BY @Group ORDER BY @Group";
        
        string filter = "( @Estacion_ID IS NULL OR OT.Estacion_ID = @Estacion_ID )" +
            "AND    ( @Empresa_ID IS NULL OR OT.ClienteFacturar_ID = @Empresa_ID ) " +
            "AND    ( @TipoMantenimiento_ID IS NULL OR OT.TipoMantenimiento_ID = @TipoMantenimiento_ID ) " +
            "AND    ( (@FechaInicial IS NULL OR @FechaFinal IS NULL) OR OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal ) " +
            "AND    OT.EstatusOrdenTrabajo_ID <> 5 AND OT.FechaTerminacion IS NOT NULL";

        public override void BindData()
        {
            selectEmpresasBindingSource.DataSource = Entities.SelectEmpresas.Get();
            selectTiposMantenimientosBindingSource.DataSource = Entities.SelectTiposMantenimientos.Get();
            base.BindData();
        }

        private string GetGroupSelect()
        {
            List<string> group = new List<string>();
            if (FechaCheckBox.Checked) { group.Add("dbo.udf_DateValue(OT.FechaTerminacion) Fecha"); }
            if (this.EmpresaCheckBox.Checked) { group.Add("EC.Nombre Cliente"); }
            if (this.TipoMantenimientoCheckBox.Checked) { group.Add("TM.Nombre TipoMantenimiento"); }
            if (this.UnidadCheckBox.Checked) { group.Add("OT.NumeroEconomico Unidad"); }
            if (this.OrdenTrabajoCheckBox.Checked) { group.Add("OT.OrdenTrabajo_ID OrdenTrabajo"); }

            return String.Join(", ", group.ToArray());
        }

        private string GetGroup()
        {
            List<string> group = new List<string>();
            if (FechaCheckBox.Checked) { group.Add("dbo.udf_DateValue(OT.FechaTerminacion)"); }
            if (this.EmpresaCheckBox.Checked) { group.Add("EC.Nombre"); }
            if (this.TipoMantenimientoCheckBox.Checked) { group.Add("TM.Nombre"); }
            if (this.UnidadCheckBox.Checked) { group.Add("OT.NumeroEconomico"); }
            if (this.OrdenTrabajoCheckBox.Checked) { group.Add("OT.OrdenTrabajo_ID"); }

            return String.Join(", ", group.ToArray());
        }

        private void DoQuery()
        {
            string group, groupselect;
            group = GetGroup();
            groupselect = GetGroupSelect();

            if (string.IsNullOrEmpty(group) || string.IsNullOrEmpty(groupselect))
            {
                throw new Exception("Debe seleccionar al menos una casilla");
            }

            string statement = sqlqry.Replace("@GroupSelect", groupselect).
                Replace("@Group", group).
                    Replace("@Filter", filter);

            // Get filters
            Int32? empresa_id;
            Int32? tipomantenimiento_id;
            DateTime? fechainicial = null;
            DateTime? fechafinal = null;
            Int32? estacion_id;

            estacion_id = Sesion.Estacion_ID;
            empresa_id = DB.GetNullableInt32(Empresa_IDComboBox.SelectedValue);
            tipomantenimiento_id = DB.GetNullableInt32(TipoMantenimiento_IDComboBox.SelectedValue);
            fechainicial = FechaTerminacionInicialDateTimePicker.Checked ? (DateTime?)AppHelper.FechaInicial(FechaTerminacionInicialDateTimePicker.Value) : null;
            fechafinal = FechaTerminacionFinalDateTimePicker.Checked ? (DateTime?)AppHelper.FechaFinal(FechaTerminacionFinalDateTimePicker.Value) : null;
            

            DataTable dtQuery = DB.QueryCommand(statement, 
                DB.GetParams(
                    DB.Param("@Empresa_ID",empresa_id),
                        DB.Param("@TipoMantenimiento_ID", tipomantenimiento_id),
                            DB.Param("@FechaInicial", fechainicial),
                                DB.Param("@FechaFinal", fechafinal),
                                    DB.Param("@Estacion_ID", estacion_id)));            

            this.ReporteVentasDataGridView.DataSource = null;
            this.ReporteVentasDataGridView.AutoGenerateColumns = true;
            this.ReporteVentasDataGridView.DataSource = dtQuery;

            foreach (DataGridViewColumn col in ReporteVentasDataGridView.Columns)
            {
                if (col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.ReporteVentasDataGridView, this);
        }
    }
}
