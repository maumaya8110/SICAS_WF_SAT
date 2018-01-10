using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BuscarRefacciones : Form
    {
        public BuscarRefacciones()
        {
            InitializeComponent();
            Model = new BuscarRefacciones_Model();
            AppHelper.SetStylish(this);
        }
        
        class BuscarRefacciones_Model
        {
            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private List<Entities.Vista_Refacciones> _Refacciones;
            public List<Entities.Vista_Refacciones> Refacciones
            {
                get { return _Refacciones; }
                set { _Refacciones = value; }
            }

            public void ConsultarRefacciones()
            {
                this.Refacciones =
                    Entities.Vista_Refacciones.GetInventario(
                    null,
                    null,
                    null,
                    null,
                    null,
                    Descripcion,
                    null,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value
                    );
            }

        } // end class     BuscarRefacciones_Model

        private BuscarRefacciones_Model Model;
        public Entities.Vista_Refacciones Refaccion { get; set; }
        public int Cantidad { get; set; }
        public NuevaOrdenTrabajo Padre { get; set; }

        public void Buscar()
        {
            try
            {
                this.Model.Descripcion = this.RefaccionTextBox.Text;
                this.Model.ConsultarRefacciones();

                this.vista_RefaccionesBindingSource.DataSource = null;

                if (this.Model.Refacciones == null || this.Model.Refacciones.Count == 0)
                {
                    throw new Exception("No existe inventario para la refacción buscada");
                }

                this.vista_RefaccionesBindingSource.DataSource = this.Model.Refacciones;
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void RefaccionesDisponiblesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesDisponiblesDataGridView.Columns["SeleccionarRef"].Index == e.ColumnIndex)
                {
                    InputCantidad input = new InputCantidad();
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        this.Refaccion = (Entities.Vista_Refacciones)this.RefaccionesDisponiblesDataGridView.Rows[e.RowIndex].DataBoundItem;
                        this.Cantidad = input.Cantidad;
                        this.RefaccionTextBox.Text = "";
                        this.vista_RefaccionesBindingSource.DataSource = null;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    } // End if
                } // End if
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(delegate { Buscar(); });
        }
    } // end class
} // end namespace
