/*
 * CancelacionOrdenesTrabajos
 * 
 * Fecha de última modificación: 2012-09-21
 * Codificado por Luis Espino
 * 
 * El evento AceptarButton_Click ha sido modificado para que contenga
 * un "DoTransactions" en lugar de un "DoMethod", para el caso en que
 * una transacción tenga un error, este se corrija automáticamente
 * en la base de datos y no queden operaciones pendientes
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CancelacionOrdenesTrabajos : baseForm
    {
        public CancelacionOrdenesTrabajos()
        {
            InitializeComponent();
        }

        #region Propierties
        private CancelacionOrdenesTrabajos_Model Model;
        #endregion

        #region Model

        /// <summary>
        /// Modelo de la operación de cancelación de ordenes de trabajos
        /// </summary>
        class CancelacionOrdenesTrabajos_Model
        {
            /// <summary>
            /// ID de la orden de  trabajo a efectuar cancelacion
            /// </summary>            
            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
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
            /// Datos de la Orden de trabajo a cancelar
            /// </summary>
            private Entities.Vista_OrdenesTrabajos _OrdenTrabajo;
            public Entities.Vista_OrdenesTrabajos OrdenTrabajo
            {
                get { return _OrdenTrabajo; }
                set { _OrdenTrabajo = value; }
            }

            /// <summary>
            /// Consultar los datos de la orden de trabajo
            /// </summary>
            public void ConsultarOrdenTrabajo()
            {
                if(!DB.Exists("OrdenesTrabajos",DB.Param("OrdenTrabajo_ID", this.OrdenTrabajo_ID)))
                    AppHelper.ThrowException("La orden de trabajo {0} no existe", this.OrdenTrabajo_ID);

                if(DB.Exists("CancelacionesOrdenesTrabajos", DB.Param("OrdenTrabajo_ID", this.OrdenTrabajo_ID)))
                    AppHelper.ThrowException("La orden de trabajo {0} ya está cancelada", this.OrdenTrabajo_ID);

                this.OrdenTrabajo = Entities.Vista_OrdenesTrabajos.Get(this.OrdenTrabajo_ID,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value)[0];                
            } // end void

            /// <summary>
            /// Registra el movimiento como gasto en la cuenta de la unidad
            /// </summary>
            private void InsertCuentaUnidad(Entities.OrdenesTrabajos ordentrabajo)
            {                
                if (ordentrabajo.EstatusOrdenTrabajo_ID == 3 || ordentrabajo.EstatusOrdenTrabajo_ID == 4)
                {
                    Entities.Unidades unidad = Entities.Unidades.Read(ordentrabajo.Unidad_ID);

                    Entities.CuentaUnidades cu = new Entities.CuentaUnidades();
                    cu.Abono = this.OrdenTrabajo.Total;
                    cu.Caja_ID = null;
                    cu.Comentarios = "AJUSTE POR CANCELACION DE ORDEN DE TRABAJO";
                    cu.Concepto_ID = 3; // CARGO DE TALLER
                    cu.Conductor_ID = unidad.ConductorOperativo_ID;
                    cu.Cuenta_ID = 4; // TALLER
                    cu.Empresa_ID = unidad.Empresa_ID;
                    cu.Estacion_ID = Sesion.Estacion_ID.Value;
                    cu.Fecha = DB.GetDate();
                    cu.Saldo = 0; // Se calcula al insertar;
                    cu.Ticket_ID = null;
                    cu.Unidad_ID = ordentrabajo.Unidad_ID;
                    cu.Usuario_ID = Sesion.Usuario_ID;
                    cu.OrdenTrabajo_ID = ordentrabajo.OrdenTrabajo_ID;
                    cu.Create();
                }
                
            } // end void

            /// <summary>
            /// Efectua la cancelación de la orden de trabajo
            /// </summary>
            public void CancelarOrdenTrabajo()
            {
                Entities.CancelacionesOrdenesTrabajos cancelacion = new Entities.CancelacionesOrdenesTrabajos();
                cancelacion.Comentarios = this.Comentarios;
                cancelacion.Fecha = DB.GetDate();
                cancelacion.OrdenTrabajo_ID = this.OrdenTrabajo_ID;
                cancelacion.Usuario_ID = Sesion.Usuario_ID;                
                cancelacion.Create();

                //  Consultamos la orden de trabajo
                Entities.OrdenesTrabajos ot = Entities.OrdenesTrabajos.Read(this.OrdenTrabajo_ID);

                //  Realizamos el ajuste, en caso de haber
                this.InsertCuentaUnidad(ot);

                //  Cambiamos el estatus de la orden
                ot.EstatusOrdenTrabajo_ID = 5;
                ot.Update();
            }
        }
        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new CancelacionOrdenesTrabajos_Model();
            base.BindData();
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
            AppHelper.DoTransactions(delegate
            {
                Model.CancelarOrdenTrabajo();
                AppHelper.Info("La orden de trabajo ha sido concelada");
                AppHelper.ClearControl(this);
            }, this);
        }

        private void OrdenTrabajoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        if (!String.IsNullOrEmpty(this.OrdenTrabajoTextBox.Text))
                        {
                            Model.OrdenTrabajo_ID = Convert.ToInt32(this.OrdenTrabajoTextBox.Text);
                            Model.ConsultarOrdenTrabajo();
                            this.vista_OrdenesTrabajosBindingSource.DataSource = Model.OrdenTrabajo;
                        } // end if
                    } // end if
                } // end delegate
            ); // end Try
        } // end void OrdenTrabajoTextBox_KeyUp

        #endregion
    } // end class
} // end namespace
