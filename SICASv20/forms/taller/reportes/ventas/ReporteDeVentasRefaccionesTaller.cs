using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteDeVentasRefaccionesTaller : baseForm
    {
        public ReporteDeVentasRefaccionesTaller()
        {
            InitializeComponent();
        }

        string sqlqry = "SELECT	@GroupSelect, \r\n" +
            "SUM(OSR.Cantidad * OSR.CostoUnitario) Costo, \r\n" +
            "SUM(OSR.Total) Precio, \r\n" +
            "SUM(OSR.Total - (OSR.Cantidad * OSR.CostoUnitario)) Utilidad \r\n" +
            "FROM	OrdenesServiciosRefacciones OSR \r\n" +
            "INNER JOIN	OrdenesServicios OS \r\n" +
            "ON		OSR.OrdenServicio_ID = OS.OrdenServicio_ID \r\n" +
            "INNER JOIN	OrdenesTrabajos OT \r\n" +
            "ON		OS.OrdenTrabajo_ID = OT.OrdenTrabajo_ID \r\n" +
            "INNER JOIN	ServiciosMantenimientos SM \r\n" +
            "ON		OS.ServicioMantenimiento_ID = SM.ServicioMantenimiento_ID \r\n" +
            "INNER JOIN	Refacciones R \r\n" +
            "ON		OSR.Refaccion_ID = R.Refaccion_ID \r\n" +
            "INNER JOIN	TiposRefacciones TR \r\n" +
            "ON		R.TipoRefaccion_ID = TR.TipoRefaccion_ID \r\n" +
            "INNER JOIN	Familias F \r\n" +
            "ON		TR.Familia_ID = F.Familia_ID  \r\n" +
            "WHERE @Filter GROUP BY @Group ORDER BY @Group";

        string filter = "( @Estacion_ID IS NULL OR OT.Estacion_ID = @Estacion_ID ) \r\n" + 
            "AND    ( @Empresa_ID IS NULL OR OT.Empresa_ID = @Empresa_ID ) \r\n" +
            "AND    ( @Familia_ID IS NULL OR TR.Familia_ID = @Familia_ID ) \r\n" +
            "AND		( @TipoRefaccion_ID IS NULL OR R.TipoRefaccion_ID = @TipoRefaccion_ID ) \r\n" +
            "AND		( @ServicioMantenimiento_ID IS NULL OR OS.ServicioMantenimiento_ID = @ServicioMantenimiento_ID ) \r\n" +
            "AND		( (@FechaInicial IS NULL OR @FechaFinal IS NULL) OR OT.FechaTerminacion BETWEEN @FechaInicial AND @FechaFinal ) \r\n" +
            "AND		OT.FechaTerminacion IS NOT NULL \r\n" +
            "AND		OT.EstatusOrdenTrabajo_ID <> 5";

        public override void BindData()
        {
            selectTiposRefaccionesBindingSource.DataSource = Entities.SelectTiposRefacciones.Get();
            selectServiciosMantenimientosBindingSource.DataSource = Entities.SelectServiciosMantenimientos.Get();
            selectFamiliasBindingSource.DataSource = Entities.SelectFamilias.Get();
            base.BindData();
        }
        private string GetGroupSelect()
        {
            List<string> group = new List<string>();
            if (FechaCheckBox.Checked) { group.Add("dbo.udf_DateValue(OT.FechaTerminacion) Fecha"); }
            if (this.FamiliaCheckBox.Checked) { group.Add("F.Nombre Familia"); }
            if (this.ServicioMantenimientoCheckBox.Checked) { group.Add("SM.Nombre ServicioMantenimiento"); }
            if (this.TipoRefaccionCheckBox.Checked) { group.Add("TR.Nombre TipoRefaccion"); }
            if (this.RefaccionCheckBox.Checked) { group.Add("R.Descripcion Refaccion"); }            

            return String.Join(", ", group.ToArray());
        }

        private string GetGroup()
        {
            List<string> group = new List<string>();
            if (FechaCheckBox.Checked) { group.Add("dbo.udf_DateValue(OT.FechaTerminacion)"); }
            if (this.FamiliaCheckBox.Checked) { group.Add("F.Nombre"); }
            if (this.ServicioMantenimientoCheckBox.Checked) { group.Add("SM.Nombre"); }
            if (this.TipoRefaccionCheckBox.Checked) { group.Add("TR.Nombre"); }
            if (this.RefaccionCheckBox.Checked) { group.Add("R.Descripcion"); }            

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
            Int32? familia_id;
            Int32? tiporefaccion_id;
            Int32? serviciomantenimiento_id;
            DateTime? fechainicial = null;
            DateTime? fechafinal = null;
            Int32? empresa_id;
            Int32? estacion_id;

            empresa_id = Sesion.Empresa_ID;
            estacion_id = Sesion.Estacion_ID;
            familia_id = DB.GetNullableInt32(Familia_IDComboBox.SelectedValue);
            tiporefaccion_id = DB.GetNullableInt32(TipoRefaccion_IDComboBox.SelectedValue);
            serviciomantenimiento_id = DB.GetNullableInt32(ServicioMantenimiento_IDComboBox.SelectedValue);
            fechainicial = AppHelper.FechaInicial(FechaTerminacionInicialDateTimePicker.Value);
            fechafinal = AppHelper.FechaFinal(FechaTerminacionFinalDateTimePicker.Value);

            DataTable dtQuery = DB.QueryCommand(statement,
                DB.GetParams(
                    DB.Param("@Familia_ID", familia_id),
                        DB.Param("@TipoRefaccion_ID", tiporefaccion_id),
                            DB.Param("@ServicioMantenimiento_ID", serviciomantenimiento_id),
                                DB.Param("@FechaInicial", fechainicial),
                                    DB.Param("@FechaFinal", fechafinal),
                                        DB.Param("@Empresa_ID", empresa_id),
                                            DB.Param("@Estacion_ID", estacion_id)
                                            )
                                        );

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
