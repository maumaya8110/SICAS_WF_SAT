using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class OrdenesCompras : baseForm
    {
        public OrdenesCompras()
        {
            InitializeComponent();
        }

        #region Model
        forms.BuscarProveedor BusquedaProveedor;

        class Model
        {
            private int? _OrdenCompra_ID;
            public int? OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private int? _Proveedor_ID;
            public int? Proveedor_ID
            {
                get { return _Proveedor_ID; }
                set { _Proveedor_ID = value; }
            }

            private int? _EstatusOrdenCompra_ID;
            public int? EstatusOrdenCompra_ID
            {
                get { return _EstatusOrdenCompra_ID; }
                set { _EstatusOrdenCompra_ID = value; }
            }

            private DateTime? _FechaInicial;
            public DateTime? FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime? _FechaFinal;
            public DateTime? FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private BindingList<Entities.Vista_OrdenesCompras> _Compras;
            public BindingList<Entities.Vista_OrdenesCompras> Compras
            {
                get { return _Compras; }
                set { _Compras = value; }
            }

            public void GetOrdenes()
            {
                this.Compras = new BindingList<Entities.Vista_OrdenesCompras>(
                        Entities.Vista_OrdenesCompras.Get(
                            this.OrdenCompra_ID, 
                            this.Proveedor_ID, 
                            this.EstatusOrdenCompra_ID, 
                            this.FechaInicial, 
                            this.FechaFinal,
                            Sesion.Empresa_ID.Value,
                            Sesion.Estacion_ID.Value
                        )
                    );
            }

            public void CancelarOrden(int ordencompra_id, string comentarios)
            {
                DB.UpdateRow("OrdenesCompras", 
                    DB.GetParams(DB.Param("EstatusOrdenCompra_ID", 2)), 
                        DB.GetParams(DB.Param("OrdenCompra_ID", ordencompra_id)));

                Entities.OrdenesComprasCanceladas occ = new Entities.OrdenesComprasCanceladas();
                occ.Comentarios = comentarios;
                occ.Fecha = DB.GetDate();
                occ.OrdenCompra_ID = ordencompra_id;
                occ.Usuario_ID = Sesion.Usuario_ID;
                occ.Create();
            }
        }
        #endregion

        private Model model;
        private forms.Compras ComprasForm;

        public override void BindData()
        {
            this.model = new Model();
            this.model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            base.BindData();
        }

        private void ShowCompras(int ordencompra_id)
        {
            if (this.ComprasForm == null)
            {
                this.ComprasForm = new forms.Compras();
            }

            if (this.ComprasForm.IsDisposed)
            {
                this.ComprasForm = new forms.Compras();
            }

            this.ComprasForm.SetOrdenCompra(ordencompra_id);
            this.ComprasForm.Show();
        }

        #region Eventos

        private void BuscarProveedoresButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                if (this.BusquedaProveedor == null)
                {
                    this.BusquedaProveedor = new BuscarProveedor();
                }

                if (this.BusquedaProveedor.IsDisposed)
                {
                    this.BusquedaProveedor = new BuscarProveedor();
                }

                if (this.BusquedaProveedor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.model.Proveedor_ID = this.BusquedaProveedor.Proveedor.Empresa_ID;
                    this.Proveedor_IDTextBox.Text = model.Proveedor_ID.ToString();
                    this.NombreProveedorTextBox.Text = this.BusquedaProveedor.Proveedor.RazonSocial;
                }

            }, this);            
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                model.GetOrdenes();
                vista_OrdenesComprasBindingSource.DataSource = model.Compras;
                vista_OrdenesComprasBindingSource.ResetBindings(false);
            }, this);
        }

        private void OrdenesComprasGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                DataGridViewRow row = OrdenesComprasGridView.Rows[e.RowIndex];
                DataGridViewCellCollection cells = row.Cells;

                if (cells["CancelarColumn"].ColumnIndex == e.ColumnIndex)
                {
                    string result = "";
                    
                    if (AppHelper.Confirm("¿Realmente desea cancelar la orden de compra?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (AppHelper.InputBox(
                                "Capture el motivo de la cancelación",
                                "Cancelación de orden de compra", 
                                ref result) == System.Windows.Forms.DialogResult.OK
                            )
                        {
                            if (!string.IsNullOrEmpty(result))
                            {
                                Entities.Vista_OrdenesCompras orden = (Entities.Vista_OrdenesCompras)row.DataBoundItem;
                                model.CancelarOrden(orden.OrdenCompra_ID, result);
                            }
                        }
                    }
                }

                if (cells["VerColumn"].ColumnIndex == e.ColumnIndex)
                {
                    Entities.Vista_OrdenesCompras orden = 
                        (Entities.Vista_OrdenesCompras)row.DataBoundItem;
                    this.ShowCompras(orden.OrdenCompra_ID);
                }

                if (cells["ActualizarColumn"].ColumnIndex == e.ColumnIndex)
                {
                    forms.ActualizacionOrdenesCompras form = new ActualizacionOrdenesCompras();
                    Entities.Vista_OrdenesCompras oc =
                        (Entities.Vista_OrdenesCompras)row.DataBoundItem;
                    form.Set_OrdenCompra(oc.OrdenCompra_ID);

                    Padre.SwitchForma("ActualizacionOrdenesCompras", form);
                }

            }, this);
        }               

        private void OrdenCompra_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OrdenCompra_IDTextBox.Text)) { model.OrdenCompra_ID = null; return; }
            model.OrdenCompra_ID = Convert.ToInt32(OrdenCompra_IDTextBox.Text);
        }

        private void Proveedor_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Proveedor_IDTextBox.Text)) { model.Proveedor_ID = null; return; }
            model.Proveedor_ID = Convert.ToInt32(Proveedor_IDTextBox.Text);
        }

        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            model.FechaInicial = AppHelper.FechaInicial(FechaInicialDateTimePicker.Value);
        }

        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            model.FechaFinal = AppHelper.FechaFinal(FechaFinalDateTimePicker.Value);
        }
        
        #endregion
    }
}
