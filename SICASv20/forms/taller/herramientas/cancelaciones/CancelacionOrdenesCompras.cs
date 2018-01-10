using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CancelacionOrdenesCompras : baseForm
    {
        public CancelacionOrdenesCompras()
        {
            InitializeComponent();
        }

        #region Propierties
        private CancelacionOrdenesCompras_Model Model;
        #endregion

        #region Model

        /// <summary>
        /// Modelo de la operación de cancelación de ordenes de compras
        /// </summary>
        class CancelacionOrdenesCompras_Model
        {
            /// <summary>
            /// ID de la orden de compra a efectuar cancelacion
            /// </summary>            
            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            /// <summary>
            /// Comentarios o motivo de la cancelación
            /// </summary>            
            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            /// <summary>
            /// Datos de la Orden de compra a cancelar
            /// </summary>
            private Entities.Vista_OrdenesCompras _OrdenCompra;
            public Entities.Vista_OrdenesCompras OrdenCompra
            {
                get { return _OrdenCompra; }
                set { _OrdenCompra = value; }
            }

            /// <summary>
            /// Consultar los datos de la orden de compra
            /// </summary>
            public void ConsultarOrdenCompra()
            {
                if(!DB.Exists("OrdenesCompras",DB.Param("OrdenCompra_ID", this.OrdenCompra_ID)))
                    AppHelper.ThrowException("La orden de compra {0} no existe", this.OrdenCompra_ID);

                if(DB.Exists("OrdenesComprasCanceladas", DB.Param("OrdenCompra_ID", this.OrdenCompra_ID)))
                    AppHelper.ThrowException("La orden de compra {0} ya está cancelada", this.OrdenCompra_ID);

                this.OrdenCompra = Entities.Vista_OrdenesCompras.Get(this.OrdenCompra_ID, null, null, null, null,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value)[0];                
            }

            /// <summary>
            /// Efectua la cancelación de la orden de compra
            /// </summary>
            public void CancelarOrdenCompra()
            {
                Entities.OrdenesComprasCanceladas occ = new Entities.OrdenesComprasCanceladas();
                occ.Comentarios = this.Comentarios;
                occ.Fecha = DB.GetDate();
                occ.OrdenCompra_ID = this.OrdenCompra_ID;
                occ.Usuario_ID = Sesion.Usuario_ID;
                occ.Create();

                Entities.OrdenesCompras oc = Entities.OrdenesCompras.Read(this.OrdenCompra_ID);
                oc.EstatusOrdenCompra_ID = 2;
                oc.Update();
            }
        }
        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new CancelacionOrdenesCompras_Model();
            base.BindData();
        }

        private void OrdenCompraTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(delegate 
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(OrdenCompraTextBox.Text))
                    {
                        Model.OrdenCompra_ID = Convert.ToInt32(this.OrdenCompraTextBox.Text);
                        Model.ConsultarOrdenCompra();
                        this.vista_OrdenesComprasBindingSource.DataSource = Model.OrdenCompra;
                    }
                }
            });
        }

        private void ComentariosTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                Model.Comentarios = ComentariosTextBox.Text;
            });
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                Model.CancelarOrdenCompra();
                AppHelper.Info("La orden de compra ha sido concelada");
                AppHelper.ClearControl(this);
            }, this);
        }

        #endregion
    }
}
