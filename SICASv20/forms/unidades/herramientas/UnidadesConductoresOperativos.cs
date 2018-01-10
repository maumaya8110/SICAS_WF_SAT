using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class UnidadesConductoresOperativos : baseForm
    {
        public UnidadesConductoresOperativos()
        {
            InitializeComponent();
        }

        class UnidadesConductoresOperativos_Model
        {
            public UnidadesConductoresOperativos_Model()
            { 
            }

            private List<Entities.Vista_UnidadesConductoresOperativos> _UnidadesConductores;
            public List<Entities.Vista_UnidadesConductoresOperativos> UnidadesConductores
            {
                get { return _UnidadesConductores; }
                set { _UnidadesConductores = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }            

            public void Consultar()
            {
                this.UnidadesConductores = Entities.Vista_UnidadesConductoresOperativos.Get(this.Estacion_ID, null);
            }

            public void Consultar(int numeroeconomico)
            {
                this.UnidadesConductores = Entities.Vista_UnidadesConductoresOperativos.Get(this.Estacion_ID, numeroeconomico);
            }

            public void Actualizar(int unidad_id, int? conductor_id)
            {
                System.Collections.Hashtable m_params = new System.Collections.Hashtable();
                System.Collections.Hashtable w_params = new System.Collections.Hashtable();

                w_params.Add("Unidad_ID", unidad_id);
                m_params.Add("ConductorOperativo_ID", conductor_id);

                DB.UpdateRow("Unidades", m_params, w_params);
            }

            public void RegresarTitular(int unidad_id)
            {
                int? conductor_id;
                object result;
                string sql;
                System.Collections.Hashtable m_params;

                //  Consultar conductor titular
                sql = @"SELECT   Conductor_ID
FROM    Contratos
WHERE   Unidad_ID = @Unidad_ID
AND     EstatusContrato_ID = 1
AND     Estacion_ID = @Estacion_ID";

                m_params = new System.Collections.Hashtable();
                m_params.Add("@Unidad_ID", unidad_id);
                m_params.Add("@Estacion_ID", Estacion_ID);

                result = DB.QueryScalar(sql, m_params);

                if (result == null)
                {
                    conductor_id = null;
                }
                else
                {
                    conductor_id = Convert.ToInt32(result);
                }

                this.Actualizar(unidad_id, conductor_id);
            }
        }

        private UnidadesConductoresOperativos_Model Model;
        private BusquedaConductor BusquedaConductorForm;

        public override void BindData()
        {
            this.Model = new UnidadesConductoresOperativos_Model();
            this.Model.Estacion_ID = Sesion.Estacion_ID.Value;
            BusquedaConductorForm = new BusquedaConductor();
            BindUnidades();
            base.BindData();
        }

        private void BindUnidades()
        {
            if (!string.IsNullOrEmpty(UnidadTextBox.Text))
            {
                this.Model.Consultar(Convert.ToInt32(UnidadTextBox.Text));
            }
            else
            {
                this.Model.Consultar();
            }
            
            this.vista_UnidadesConductoresOperativosBindingSource.DataSource = this.Model.UnidadesConductores;
        }

        private void BindUnidades(int numeroeconomico)
        {
            this.Model.Consultar(numeroeconomico);
            this.vista_UnidadesConductoresOperativosBindingSource.DataSource = this.Model.UnidadesConductores;
        }

        private void vista_UnidadesConductoresOperativosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    string colname = vista_UnidadesConductoresOperativosDataGridView.Columns[e.ColumnIndex].Name;                    

                    Entities.Vista_UnidadesConductoresOperativos unidadconductor =
                               (Entities.Vista_UnidadesConductoresOperativos)vista_UnidadesConductoresOperativosDataGridView.Rows[e.RowIndex].DataBoundItem;

                    switch (colname)
                    {
                        case "ActualizarColumn":
                            
                            //  Show form, retrive conducto_id                                       
                            if (BusquedaConductorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                Model.Actualizar(unidadconductor.Unidad_ID.Value, BusquedaConductorForm.Conductor_ID);
                                AppHelper.Info("Unidad actualizada");
                                BindUnidades();
                            }                            
                            
                            break;
                        case "RegresarTitularColumn":
                            
                            Model.RegresarTitular(unidadconductor.Unidad_ID.Value);
                            AppHelper.Info("Unidad actualizada");
                            BindUnidades();
                            
                            break;
                    }
                }
            );
        }

        private void UnidadTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UnidadTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(
                    delegate
                    {
                        this.BindUnidades();
                    },
                    this
                );
            }
        } // end void
    } // end class
} // end namespace
