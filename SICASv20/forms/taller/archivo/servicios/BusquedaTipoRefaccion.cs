using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BusquedaTipoRefaccion : Form
    {
        public BusquedaTipoRefaccion()
        {
            InitializeComponent();
            this.Model = new BusquedaTipoRefaccion_Model();
            AppHelper.SetStylish(this);
        }

        class BusquedaTipoRefaccion_Model
        {
            private List<Entities.TiposRefacciones> _TiposRefacciones;
            public List<Entities.TiposRefacciones> TiposRefacciones
            {
                get { return _TiposRefacciones; }
                set { _TiposRefacciones = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public void Consultar()
            {
                this.TiposRefacciones = Entities.TiposRefacciones.Read(this.Nombre);
            }
        }

        private BusquedaTipoRefaccion_Model Model;
        private Entities.TiposRefacciones _TipoRefaccion;
        public Entities.TiposRefacciones TipoRefaccion
        {
            get { return _TipoRefaccion; }
            set { _TipoRefaccion = value; }
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

        private void NombreTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        this.Model.Consultar();
                        this.tiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
                    }
                }
            );
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Consultar();
                    this.tiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
                }
            );
        }

        private void tiposRefaccionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.TipoRefaccion =
                        (Entities.TiposRefacciones)this.tiposRefaccionesDataGridView.Rows[e.RowIndex].DataBoundItem;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.NombreTextBox.Text = "";
                    this.tiposRefaccionesBindingSource.DataSource = null;
                    this.Close();
                }
            );
        }
    }
}
