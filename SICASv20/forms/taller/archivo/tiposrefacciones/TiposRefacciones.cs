using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class TiposRefacciones : baseForm
    {
        public TiposRefacciones()
        {
            InitializeComponent();
        }

        #region Model

        class TiposRefacciones_Model
        {
            public TiposRefacciones_Model()
            { 
            }

            private List<Entities.SelectFamilias> _Familias;
            public List<Entities.SelectFamilias> Familias
            {
                get { return _Familias; }
                set { _Familias = value; }
            }

            private List<Entities.Vista_TiposRefacciones> _TiposRefacciones;
            public List<Entities.Vista_TiposRefacciones> TiposRefacciones
            {
                get { return _TiposRefacciones; }
                set { _TiposRefacciones = value; }
            }

            private Int32? _Familia_ID;
            public Int32? Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public void Consultar()
            {
                this.TiposRefacciones = Entities.Vista_TiposRefacciones.Get(this.Familia_ID, this.Nombre);
                this.Familias = Entities.SelectFamilias.Get();
            }
        }

        #endregion

        #region

        private TiposRefacciones_Model Model;

        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new TiposRefacciones_Model();
            this.Model.Consultar();
            this.selectFamiliasBindingSource.DataSource = this.Model.Familias;
            this.vista_TiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
            base.BindData();
        }
        private void FamiliasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Familia_ID = DB.GetNullableInt32(FamiliasComboBox.SelectedValue);
                }
            );
        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Nombre = this.NombreTextBox.Text;
                }
            );
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Consultar();
                    this.vista_TiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
                },
                this
            );
        }

        private void vista_TiposRefaccionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (vista_TiposRefaccionesDataGridView.Columns[e.ColumnIndex].Name == "ActualizarColumn")
                    {
                        Entities.Vista_TiposRefacciones tiporefaccion =
                            (Entities.Vista_TiposRefacciones)this.vista_TiposRefaccionesDataGridView.Rows[e.RowIndex].DataBoundItem;

                        forms.ActualizacionTiposRefacciones actualizacionForm =
                            new ActualizacionTiposRefacciones();

                        actualizacionForm.Set_TipoRefaccion(
                            Entities.TiposRefacciones.Read(tiporefaccion.TipoRefaccion_ID.Value)
                        );

                        Padre.SwitchForma("ActualizacionTiposRefacciones", actualizacionForm);

                        return;
                    }
                }
            );
        }
        #endregion
    }
}
