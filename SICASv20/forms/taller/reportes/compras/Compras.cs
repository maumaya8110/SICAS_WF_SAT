using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        private int _OrdenCompra_ID;
        public int OrdenCompra_ID
        {
            get { return _OrdenCompra_ID; }
            set { _OrdenCompra_ID = value; }
        }

        private List<Entities.Vista_Compras> _VistaCompras;
        public List<Entities.Vista_Compras> VistaCompras
        {
            get { return _VistaCompras; }
            set { _VistaCompras = value; }
        }

        public void SetOrdenCompra(int ordencompra_id)
        {
            this._OrdenCompra_ID = ordencompra_id;
            this.ConsultarOrdenCompra();
        }

        private void ConsultarOrdenCompra()
        {
            this.VistaCompras = Entities.Vista_Compras.Get(this.OrdenCompra_ID, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
            this.vista_ComprasBindingSource.DataSource = this.VistaCompras;
            this.vista_ComprasBindingSource.ResetBindings(false);
        }
    }
}
