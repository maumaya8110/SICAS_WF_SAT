using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class InventarioRefaccionesServicioMantenimiento : Form
    {
        public InventarioRefaccionesServicioMantenimiento()
        {
            InitializeComponent();
        }

        private string _NombreServicio;
        public string NombreServicio
        {
            get { return _NombreServicio; }
            set { _NombreServicio = value; }
        }

        private List<Entities.Vista_InventarioRefaccionesServicio> _Inventario;
        public List<Entities.Vista_InventarioRefaccionesServicio> Inventario
        {
            get { return _Inventario; }
            set { _Inventario = value; }
        }

        public void BindData()
        {
            AppHelper.SetStylish(this);
            this.ServicioLabel.Text = this.NombreServicio;
            this.vista_InventarioRefaccionesServicioBindingSource.DataSource = this.Inventario;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
