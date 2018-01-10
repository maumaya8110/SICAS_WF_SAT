using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BuscarProveedor : Form
    {
        public BuscarProveedor()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        private Entities.Empresas _Proveedor;
        public Entities.Empresas Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        private void BuscarEmpresas()
        {
            string filter = "TipoEmpresa_ID = 4 AND (Nombre LIKE @Nombre + '%' OR RazonSocial LIKE @Nombre + '%')";
            empresasBindingSource.DataSource = Entities.Empresas.Read(filter, "Nombre ASC", DB.Param("@Nombre",ProveedorTextBox.Text));
        }


        private void ProveedoresGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ProveedoresGridView.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    Entities.Empresas proveedor = (Entities.Empresas)ProveedoresGridView.Rows[e.RowIndex].DataBoundItem;
                    this.Proveedor = proveedor;
                    this.empresasBindingSource.DataSource = null;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarEmpresas();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
