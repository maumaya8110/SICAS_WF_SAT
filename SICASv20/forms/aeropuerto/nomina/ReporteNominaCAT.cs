using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
    public partial class ReporteNominaCAT : baseForm
    {
        private BindingSource bsConductores = new BindingSource();
        private BindingSource bsAños = new BindingSource();
        private BindingSource bsPeriodos = new BindingSource();
        private int PermisosUsuario = Entities.Vista_NominaCAT.GetPermisosUsuario(Sesion.Usuario_ID);
        private int MaxEstatusNomina_ID = Entities.Vista_NominaCAT.GetMaxEstatusNomina_ID();

        private int Año
        {
            get
            {
                int a;


                string anio = cmbAño.SelectedValue.ToString();

                try
                {
                    a = (int)int.Parse(anio);
                }
                catch
                {
                    Entities.Año aux = (Entities.Año)cmbAño.SelectedValue;
                    a = aux.ID;
                }
                return a;
            }
        }

        private DateTime Periodo
        {
            get
            {
                DateTime p;
                try
                {
                    p = (DateTime)cmbPeriodo.SelectedValue;
                }
                catch
                {
                    Entities.PeriodoNomina pn = (Entities.PeriodoNomina)cmbPeriodo.SelectedValue;
                    p = pn.Periodo;
                }
                return p;
            }
        }

        private DateTime PeriodoActual
        {
            get
            {
                DateTime dt = DateTime.Today;
                if ((int)dt.DayOfWeek < 5)
                {
                    int dw = (int)dt.DayOfWeek + 2;
                    dt = dt.AddDays(dw * -1);
                }
                else if ((int)dt.DayOfWeek > 5)
                {
                    dt = dt.AddDays(-1);
                }
                return dt;
            }
        }

        public ReporteNominaCAT()
        {
            InitializeComponent();
            BindingCombos();
            dgvConductores.AutoGenerateColumns = false;
            dgvDetalleIncidencias.AutoGenerateColumns = false;
            dgvConductores.ScrollBars = ScrollBars.Both;
            

        }





        private void BindingCombos()
        {
            bsAños.DataSource = Entities.Año.GetAñosNomina();
            cmbAño.DataSource = bsAños;
            cmbAño.DisplayMember = "sAño";
            cmbAño.ValueMember = "ID";
            cmbAño.SelectedValue = DateTime.Now.Year;
            cmbAño_SelectedValueChanged(null, null);
        }

        void cmbAño_SelectedValueChanged(object sender, EventArgs e)
        {

            bsPeriodos.DataSource = Entities.PeriodoNomina.GetPeriodosNominaAño(Año);
            cmbPeriodo.DataSource = bsPeriodos;
            cmbPeriodo.DisplayMember = "Semana";
            cmbPeriodo.ValueMember = "Periodo";

            if (Año == DateTime.Now.Year)
            {
                cmbPeriodo.SelectedValue = PeriodoActual;
            }
            cmbPeriodo_SelectedValueChanged(null, null);
        }

        void cmbPeriodo_SelectedValueChanged(object sender, EventArgs e)
        {
            bsConductores.DataSource = Entities.Vista_NominaCAT.GetReporteNomina(Periodo);
            dgvConductores.DataSource = bsConductores;
            dgvConductores.Refresh();
         dgvConductores.ScrollBars = ScrollBars.Both;

            dgvDetalleIncidencias.DataSource = Entities.Vista_NominaCAT.GetDetalleIncidenciasNomina(Periodo);
           
            dgvDetalleIncidencias.Refresh();
         

            classes.Aeropuerto.EstatusNomina en = Entities.Vista_NominaCAT.GetEstatusNominaPorPeriodo(Periodo);
            lblStatus.Text = en.Nombre;
            btnAutorizaNomina.Visible = (PermisosUsuario == en.EstatusNomina_ID && en.EstatusNomina_ID < MaxEstatusNomina_ID);
            btnReiniciaNomina.Visible = (PermisosUsuario == en.EstatusNomina_ID && en.EstatusNomina_ID < MaxEstatusNomina_ID && en.EstatusNomina_ID > 1);
        }

        private void btnExpNomina_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.dgvConductores, this);
        }

        private void btnExpDetalle_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.dgvDetalleIncidencias, this);
        }

        private void btnAutorizaNomina_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma la Autorización de la Nómina para el período " + Periodo.ToString("dd/MM/yyyy") + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                AppHelper.Try(Autorizacion);
        }

        private void Autorizacion()
        {
            Entities.Vista_NominaCAT.AutorizaNominaPeriodo(Periodo, Sesion.Usuario_ID);
            cmbPeriodo_SelectedValueChanged(null, null);
            AppHelper.Info("El proceso de Autorización se completo exitosamente.");
        }

        private void btnReiniciaNomina_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma el Reinicio del Flujo de Autorización de la Nómina para el período " + Periodo.ToString("dd/MM/yyyy") + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                AppHelper.Try(ReiniciaFlujoAutorizacionNomina);
        }

        private void ReiniciaFlujoAutorizacionNomina()
        {
            Entities.Vista_NominaCAT.ReiniciaFlujoAutorizacionNomina(Periodo, Sesion.Usuario_ID);
            cmbPeriodo_SelectedValueChanged(null, null);
            AppHelper.Info("El Reinicio del Flujo de Autorización se completo exitosamente.");
        }

    }
}
