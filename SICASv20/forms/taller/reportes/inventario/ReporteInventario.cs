using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteInventario : baseForm
    {
        public ReporteInventario()
        {
            InitializeComponent();
        }

        #region Properties
        private ReporteInventario_Model Model;
        #endregion

        #region Model
        class ReporteInventario_Model
        {
            private List<Entities.Vista_Refacciones> _Refacciones;
            public List<Entities.Vista_Refacciones> Refacciones
            {
                get { return _Refacciones; }
                set { _Refacciones = value; }
            }

            private List<Entities.SelectFamilias> _Familias;
            public List<Entities.SelectFamilias> Familias
            {
                get { return _Familias; }
                set { _Familias = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int? _Familia_ID;
            public int? Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
            }

            private bool _IncluirInventarioCero;
            public bool IncluirInventarioCero
            {
                get { return _IncluirInventarioCero; }
                set { _IncluirInventarioCero = value; }
            }

            public void ConsultarFamilias()
            {
                this.Familias = Entities.SelectFamilias.Get();
            }

            public void Consultar()
            {
                if (this.IncluirInventarioCero)
                {
                    this.Refacciones =
                        Entities.Vista_Refacciones.Get(
                            null,
                            null,
                            Familia_ID,
                            null,
                            null,
                            this.Descripcion,
                            null,
                            Sesion.Empresa_ID.Value,
                            Sesion.Estacion_ID.Value
                        );
                }
                else
                {
                    this.Refacciones =
                        Entities.Vista_Refacciones.GetInventario(
                            null,
                            null,
                            Familia_ID,
                            null,
                            null,
                            this.Descripcion,
                            null,
                            Sesion.Empresa_ID.Value,
                            Sesion.Estacion_ID.Value
                        );
                }
            }
        }
        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new ReporteInventario_Model();
            this.Model.ConsultarFamilias();
            this.familiasBindingSource.DataSource = this.Model.Familias;
            base.BindData();
        }

        private void InventarioCeroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.IncluirInventarioCero = this.InventarioCeroCheckBox.Checked;
                }
            );
        }

        private void DescripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Descripcion = this.DescripcionTextBox.Text;
                }
            );
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Consultar();
                    this.refaccionesBindingSource.DataSource = Model.Refacciones;
                },
                this
            );
        }        

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.refaccionesDataGridView, this);
        }
        

        private void FamiliaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Familia_ID = DB.GetNullableInt32(this.FamiliaComboBox.SelectedValue);
                }
            );
        }
        #endregion
    }
}
