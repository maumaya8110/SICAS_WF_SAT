using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class MecanicoUC : baseUserControl
    {
        public MecanicoUC()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        public NuevaOrdenTrabajo Padre;

        private void DoQuery()
        {
            List<Entities.Mecanicos> mecanicos =
                Entities.Mecanicos.Read("Apellidos + ' ' + Nombres LIKE @Nombre + '%'", 
                    "Nombres, Apellidos", 
                        DB.Param("@Nombre", this.MecanicoTextBox.Text));

            mecanicosBindingSource.DataSource = mecanicos;
        }

        private void DoValidate()
        {
            if (String.IsNullOrEmpty(KilometrajeTextBox.Text))
            {
                throw new Exception("Debe capturar el kilometraje");
            }

            if (!AppHelper.IsNumeric(KilometrajeTextBox.Text))
            {
                throw new Exception("El kilometraje debe ser numérico");
            }

            if (Padre.OrdenTrabajo.OrdenesServicios[0].Mecanico_ID == 0)
            {
                throw new Exception("Debe seleccionar un mecánico");
            }

            /* Eliminamos temporalmente las validaciones
             * debido a falta de confianza en los datos
             * 2013 - 04 - 01
            //  Validamos el kilometraje
            //  Solamente para empresas internas
            if (Entities.Functions.EsEmpresaInterna(this.Padre.OrdenTrabajo.ClienteFacturar_ID))
            {
                Entities.SelectEmpresasInternas.Get();
                Entities.Unidades_Kilometrajes uk =
                    new Entities.Unidades_Kilometrajes();

                uk.Unidad_ID = Padre.OrdenTrabajo.Unidad_ID;
                uk.Kilometraje = Convert.ToInt32(this.KilometrajeTextBox.Text);
                uk.Fecha = DB.GetDate();
                uk.Validate();
            }
            */

            Entities.Unidades_Kilometrajes uk =
                    new Entities.Unidades_Kilometrajes();

            uk.Unidad_ID = Padre.OrdenTrabajo.Unidad_ID;
            uk.Kilometraje = Convert.ToInt32(this.KilometrajeTextBox.Text);
            uk.Fecha = DB.GetDate();
            uk.Create();

            Padre.OrdenTrabajo.Kilometraje = Convert.ToInt32(this.KilometrajeTextBox.Text);
            Padre.OrdenTrabajo.Comentarios = this.ComentariosTextBox.Text;
            Padre.OrdenTrabajo.CargoAConductor = this.CargoAConductorCheckBox.Checked;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoQuery();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void MecanicossDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MecanicossDataGridView.Columns["Seleccionar"].Index == e.ColumnIndex)
                {
                    Entities.Mecanicos mecanico = (Entities.Mecanicos)MecanicossDataGridView.Rows[e.RowIndex].DataBoundItem;
                    int i;
                    for (i = 0; i < Padre.OrdenTrabajo.OrdenesServicios.Count; i++)
                    {
                        Padre.OrdenTrabajo.OrdenesServicios[i].Mecanico_ID = mecanico.Mecanico_ID;
                        Padre.OrdenTrabajo.OrdenesServicios[i].Mecanico_Nombre = mecanico.Apellidos + " " + mecanico.Nombres;
                    }

                    this.MecanicoTextBox.Text = mecanico.Apellidos + " " + mecanico.Nombres;

                    mecanicosBindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                DoValidate();
                Padre.resumenControl.DisplayReport();
                Padre.SwitchPanel("Resumen");
            }, this);
        }

        private void AnteriorButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("Servicios");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }
    }
}
