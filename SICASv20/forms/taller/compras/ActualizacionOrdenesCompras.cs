using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionOrdenesCompras : baseForm
    {
        public ActualizacionOrdenesCompras()
        {
            InitializeComponent();
            Model = new ActualizacionOrdenesCompras_Model();
        }

        #region Properties
        ActualizacionOrdenesCompras_Model Model;
        #endregion

        public override void BindData()
        {
            base.BindData();
        }

        #region Model

        /// <summary>
        /// Clase modelo de la operación de actualizacion de ordenes de compras
        /// </summary>
        class ActualizacionOrdenesCompras_Model
        {
            /// <summary>
            /// Id de la orden de compra a actualizar
            /// </summary>
            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private Entities.OrdenesCompras _OrdenCompra;
            public Entities.OrdenesCompras OrdenCompra
            {
                get { return _OrdenCompra; }
                set { _OrdenCompra = value; }
            }

            private List<Entities.EstatusOrdenesCompras> _Estatus;
            public List<Entities.EstatusOrdenesCompras> Estatus
            {
                get { return _Estatus; }
                set { _Estatus = value; }
            }

            public void ConsultarEstatus()
            {
                this.Estatus = Entities.EstatusOrdenesCompras.Read();
            }

            public void ConsultarOrdenCompra()
            {
                if (OrdenCompra_ID == 0) AppHelper.ThrowException("Debe capturar una orden de compra");
                this.OrdenCompra = Entities.OrdenesCompras.Read(this.OrdenCompra_ID);
            }

            public void ActualizarOrdenCompra()
            {
                if (OrdenCompra == null) AppHelper.ThrowException("Debe capturar una orden de compra");
                this.OrdenCompra.Empresa_ID = Sesion.Empresa_ID.Value;
                this.OrdenCompra.Estacion_ID = Sesion.Estacion_ID.Value;
                this.OrdenCompra.Update();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Configura una orden de compra para ser utilizada por la forma
        /// </summary>
        /// <param name="ordencompra_id">El id de la orden de compra</param>
        public void Set_OrdenCompra(int ordencompra_id)
        {
            //  Asigna el ide de la orden de compra
            this.Model.OrdenCompra_ID = ordencompra_id;

            //  Consulta los estados de ordenes de compras y 
            //  realiza el databinding
            this.Model.ConsultarEstatus();
            this.estatusOrdenesComprasBindingSource.DataSource = Model.Estatus;

            //  Consulta la orden de compra y realiza
            //  el databinding
            this.Model.ConsultarOrdenCompra();
            this.ordenesComprasBindingSource.DataSource = this.Model.OrdenCompra;
        }
                
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            //  Actualiza la orden de compra
            //  Limpia ls forma y manda un mensaje
            AppHelper.DoMethod(
                delegate
                {
                    Model.ActualizarOrdenCompra();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Orden de compra actualizada");
                },
                this
            );
        }

        #endregion
    }
}
