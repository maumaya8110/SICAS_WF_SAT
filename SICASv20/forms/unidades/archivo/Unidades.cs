/*
 * Unidades
 * 
 * Muestra el catalogo de unidades y permite operaciones sobre las misma
 * 
 * Ultima modificación: 2012-09-21
 * Codificado por Luis Espino
 *      Implementamos filtro de unidades, para que aparezcan solamente las activas
 *      y no las de baja. Se pueden consultar activando una casilla de verificacion.
 * 
 * Última modificación: 2012-10-16
 * Codificado por Luis Espino
 *      Se agregó el campo de GPS a la visualización de unidades
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 *      Se eliminó el evento "EmpresasComboBox_SelecitionChangeCommited"
 *      para que no se cargarán las estaciones después de seleccionar empresa
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Unidades : baseForm
    {
        public Unidades()
        {
            InitializeComponent();
        }

        private void Unidades_Load(object sender, EventArgs e)
        {
       
        }

        public override void BindData()
        {
            empresasBindingSource.DataSource = Sesion.EmpresasTodas;
            estacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            base.BindData();
        }

        private void SetAccesosEmpresasEstaciones()
        {
            if (Sesion.Empresa_ID != null)
            {
                this.EmpresasComboBox.SelectedValue = Sesion.Empresa_ID;
                this.EmpresasComboBox.Enabled = false;
            }

            if (this.EstacionesComboBox.Items.Count == 0)
            {
                estacionesBindingSource.DataSource =
                Entities.Estaciones.Read(
                    DB.Param(
                        "Empresa_ID",
                        this.EmpresasComboBox.SelectedValue
                    )
                );
            }

            if (Sesion.Estacion_ID != null)
            {
                this.EstacionesComboBox.SelectedValue = Sesion.Estacion_ID;
                this.EstacionesComboBox.Enabled = false;
            }
        }

        private void Validar()
        {
            if(!string.IsNullOrEmpty(Arrendamiento_IDTextBox.Text))
            {
                if(!AppHelper.IsNumeric(Arrendamiento_IDTextBox.Text))
                {
                    throw new Exception("Arrendamiento ID debe ser numérico");
                }
            }

            if(!string.IsNullOrEmpty(NumeroEconomicoTextBox.Text))
            {
                if (!AppHelper.IsNumeric(NumeroEconomicoTextBox.Text))
                {
                    throw new Exception("Numero Economico de Unidad debe ser numérico");
                }
            }
        }

        /// <summary>
        /// Consulta las unidades y las muestra al usuario
        /// </summary>
        private void ObtenerUnidades()
        {
            try
            {
                //  Mandamos llamar la validación
                Validar();


                // Obtenemos los parámetros
                int? unidad_id, numeroeconomico, empresa_id, estacion_id;
                unidad_id = DB.GetNullableInt32(Arrendamiento_IDTextBox.Text);
                numeroeconomico = DB.GetNullableInt32(NumeroEconomicoTextBox.Text);
                empresa_id = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);
                estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);
                bool EsInactivas = UnidadesBajaCheckBox.Checked;

                //  Si hay que consultar las inactivas
                if (EsInactivas)
                {
                    //  Consultamos todas las unidades
                    vista_UnidadesBindingSource.DataSource = Entities.Vista_Unidades.Get(unidad_id, numeroeconomico, empresa_id, estacion_id);
                } // end if
                else // Sino, consultar solo las activas
                {
                    vista_UnidadesBindingSource.DataSource = Entities.Vista_Unidades.GetActivas(unidad_id, numeroeconomico, empresa_id, estacion_id);
                } // end else
                
            } // end try
            catch (System.Exception ex)
            {
                AppHelper.Error(ex.Message);
            } // end catch
        } // end void ObtenerUnidades

        private void vista_UnidadesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vista_UnidadesDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    forms.ActualizacionUnidad au = new forms.ActualizacionUnidad();
                    Entities.Vista_Unidades unidad = (Entities.Vista_Unidades)vista_UnidadesDataGridView.Rows[e.RowIndex].DataBoundItem;
                    au.Unidad_ID = unidad.Unidad_ID.Value;

                    Padre.SwitchForma("ActualizacionUnidad", au);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(ObtenerUnidades, this);
        }

        private void vista_UnidadesDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.ColorDataGridViewRows(
                        ref this.vista_UnidadesDataGridView,
                        "EstatusUnidad_ID",
                        AppHelper.RelacionValoresColores
                    );
                }
            );
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    AppHelper.ExportDataGridViewExcel(this.vista_UnidadesDataGridView, this);
                },
                this
            );
        }
    } // End class
} // End namespace
