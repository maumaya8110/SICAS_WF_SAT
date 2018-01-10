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
    /// Formulario que muestra el reporte de estado de cuenta del conductor
    /// </summary>
    public partial class ReporteEstadoCuentaConductor : baseForm
    {
        /// <summary>
        /// Crea una instancia del formulario Reporte Estado de Cuenta
        /// </summary>
        public ReporteEstadoCuentaConductor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El folio del conductor del cual se mostrará el estado de cuenta
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }
        private int _Conductor_ID;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            getSelectEmpresasBindingSource.DataSource = Sesion.Empresas;

            this.getAniosCuentaConductoresBindingSource.DataSource = Entities.Functions.GetAniosCuentaConductores();

            this.reportViewer1.RefreshReport();            

            DoQuery();

            base.BindData();
        }

        /// <summary>
        /// Consulta las cuentas de la empresa y las muestra en la caja
        /// desplegable de "Cuentas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.EmpresaComboBox.SelectedValue != null && !Convert.IsDBNull(this.EmpresaComboBox.SelectedValue))
            {
                this.get_SelectCuentasDeEmpresaTableAdapter.Fill(
                    this.sICASCentralQuerysDataSet.Get_SelectCuentasDeEmpresa, 
                        (int)this.EmpresaComboBox.SelectedValue);
            }
            DoQuery();
        }

        /// <summary>
        /// Selecciona el año y obtiene los meses del mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.AnioComboBox.SelectedValue != null && !Convert.IsDBNull(this.AnioComboBox.SelectedValue))
            {
                this.getMesDeAnioCuentaConductoresBindingSource.DataSource =
                    Entities.Functions.GetMesesFromAnio(Convert.ToInt32(this.AnioComboBox.SelectedValue));
            }
            DoQuery();
        }

        /// <summary>
        /// Realiza la consulta a la base de datos
        /// y obtiene los resultados del reporte
        /// </summary>
        private void DoQuery()
        {
            try
            {
                //  Declaraamos las variables necesarias
                //  empresa, cuenta, anño y mes
                //  para obtener el reporte
                int? Empresa_ID = null, Cuenta_ID = null, Anio = null, Mes = null;

                //  Obtenemos la empresa
                if (EmpresaComboBox.SelectedValue != null && !Convert.IsDBNull(EmpresaComboBox.SelectedValue))
                    Empresa_ID = (int)EmpresaComboBox.SelectedValue;

                //  Obtenemos la cuenta
                if (CuentaComboBox.SelectedValue != null && !Convert.IsDBNull(CuentaComboBox.SelectedValue))
                    Cuenta_ID = (int)CuentaComboBox.SelectedValue;

                //  Obtenemos el año
                if (AnioComboBox.SelectedValue != null && !Convert.IsDBNull(AnioComboBox.SelectedValue))
                    Anio = (int)AnioComboBox.SelectedValue;

                //  Obtenemos el mes
                if (MesComboBox.SelectedValue != null && !Convert.IsDBNull(MesComboBox.SelectedValue))
                    Mes = (int)MesComboBox.SelectedValue;

                //  Consultamos la base de datos
                reporte_CuentaConductoresTableAdapter.Fill(
                    sICASCentralQuerysDataSet.Reporte_CuentaConductores, Conductor_ID, Empresa_ID, Cuenta_ID, Anio, Mes);

                //  Actualizamos el control de reporte
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Cambia la cuenta a consultar y actualiza la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CuentaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DoQuery();
        }

        /// <summary>
        /// Cambia el mes a consulta y actualiza la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DoQuery();
        }

    } // end class

} // end namespace
