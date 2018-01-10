using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class TerminacionOrdenesTrabajo : baseForm
    {
        public TerminacionOrdenesTrabajo()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Propiedad privada del modelo en la forma
        /// </summary>
        private TerminacionOrdenesTrabajo_Model Model;

        #endregion

        #region Model

        /// <summary>
        /// Modelo de la operación TerminacionOrdenesTrabajo
        /// </summary>
        class TerminacionOrdenesTrabajo_Model
        {
            /// <summary>
            /// ID de la orden de trabajo a terminar
            /// </summary>
            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            /// <summary>
            /// Codigo de barras de la orden de trabajo
            /// </summary>
            private string _CodigoBarras;
            public string CodigoBarras
            {
                get { return _CodigoBarras; }
                set { _CodigoBarras = value; }
            }

            /// <summary>
            /// Datos de la orden de trabajo a terminar
            /// </summary>
            private Entities.Vista_OrdenesTrabajos _DatosOrden;
            public Entities.Vista_OrdenesTrabajos DatosOrden
            {
                get { return _DatosOrden; }
                set { _DatosOrden = value; }
            }

            /// <summary>
            /// La orden de trabajo a terminar
            /// </summary>
            private Entities.OrdenesTrabajos OrdenTrabajo;

            /// <summary>
            /// Consultar y verificar la orden de trabajo para terminación
            /// </summary>
            public void ConsultarOrdenTrabajo()
            { 
                //  Consultar la orden de trabajo
                this.OrdenTrabajo = Entities.OrdenesTrabajos.Read(this.OrdenTrabajo_ID);

                //  Que no este ya terminada
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 3)
                    AppHelper.ThrowException("La orden de trabajo {0} ya esta terminada", this.OrdenTrabajo_ID);

                //  Que no este pagada
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 4)
                    AppHelper.ThrowException("La orden de trabajo {0} ya esta terminada", this.OrdenTrabajo_ID);

                //  Que no este cancelada
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 5)
                    AppHelper.ThrowException("La orden de trabajo {0} ya esta terminada", this.OrdenTrabajo_ID);

                //  Que no tenga refacciones por surtir
                string sql = @"SELECT	ISNULL(SUM(OSR.Cantidad - OSR.RefSurtidas),0) cont
                FROM	OrdenesTrabajos OT
                INNER JOIN	OrdenesServicios OS
                ON		OT.OrdenTrabajo_ID = OS.OrdenTrabajo_ID
                INNER JOIN	OrdenesServiciosRefacciones OSR
                ON		OS.OrdenServicio_ID = OSR.OrdenServicio_ID
                WHERE	OT.OrdenTrabajo_ID = @OrdenTrabajo_ID";

                int cont = Convert.ToInt32(
                    DB.QueryScalar(
                        sql, 
                        DB.GetParams(
                            DB.Param("@OrdenTrabajo_ID",this.OrdenTrabajo_ID)
                        )
                    )
                );

                if (cont > 0)
                    AppHelper.ThrowException("La orden de trabajo {0} tiene refacciones por surtir", this.OrdenTrabajo_ID);

                //  Que pertenezca a la empresa y la estación
                if (this.OrdenTrabajo.Empresa_ID != Sesion.Empresa_ID.Value ||
                    this.OrdenTrabajo.Estacion_ID != Sesion.Estacion_ID.Value)
                    AppHelper.ThrowException("La orden de trabajo {0} no pertenece a la empresa y estacion del usuario", this.OrdenTrabajo_ID);

                //  Consultar los datos de la orden de trabajo
                this.DatosOrden = Entities.Vista_OrdenesTrabajos.Get(this.OrdenTrabajo_ID, this.OrdenTrabajo.Empresa_ID, this.OrdenTrabajo.Estacion_ID)[0];

            }

            private void UpdateOrdenesServicios()
            {
                string sql = @"UPDATE OrdenesServicios 
                SET EstatusOrdenServicio_ID = 3
                WHERE   OrdenTrabajo_ID = @OrdenTrabajo_ID";

                DB.Params = DB.GetParams(
                                DB.Param("@OrdenTrabajo_ID", this.OrdenTrabajo_ID)
                            );

                DB.ExecuteCommand(sql, DB.Params);
            }

            private void Validar()
            {
                if(this.OrdenTrabajo_ID == 0)
                    AppHelper.ThrowException("Debe capturar una orden de trabajo", this.OrdenTrabajo_ID);

                if(this.OrdenTrabajo == null)
                    AppHelper.ThrowException("La orden de trabajo {0} no tiene datos", this.OrdenTrabajo_ID);
            }

            /// <summary>
            /// Registra el movimiento como gasto en la cuenta de la unidad
            /// </summary>
            private void InsertCuentaUnidad()
            {
                Entities.Unidades unidad = Entities.Unidades.Read(this.OrdenTrabajo.Unidad_ID);

                Entities.CuentaUnidades cu = new Entities.CuentaUnidades();
                cu.Cargo = this.OrdenTrabajo.Total;
                cu.Caja_ID = null;
                cu.Comentarios = "GASTO POR ORDEN DE TRABAJO";
                cu.Concepto_ID = 3; // CARGO DE TALLER
                cu.Conductor_ID = unidad.ConductorOperativo_ID;
                cu.Cuenta_ID = 4; // TALLER
                cu.Empresa_ID = unidad.Empresa_ID;
                cu.Estacion_ID = Sesion.Estacion_ID.Value;
                cu.Fecha = DB.GetDate();
                cu.Saldo = 0; // Se calcula al insertar;
                cu.Ticket_ID = null;
                cu.Unidad_ID = this.OrdenTrabajo.Unidad_ID;
                cu.Usuario_ID = Sesion.Usuario_ID;
                cu.OrdenTrabajo_ID = this.OrdenTrabajo.OrdenTrabajo_ID;
                cu.Create();
            } // end void

            /// <summary>
            /// Registra el termino de la orden de trabajo en la base de datos
            /// </summary>
            public void TerminarOrdenTrabajo()
            {
                //  Cambiar el status, la fecha de terminación de la orden de trabajo
                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 3)
                {
                    AppHelper.ThrowException("La orden ya esta cerrada");
                }

                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 4)
                {
                    AppHelper.ThrowException("La orden ya esta pagada");
                }

                if (this.OrdenTrabajo.EstatusOrdenTrabajo_ID == 5)
                {
                    AppHelper.ThrowException("La orden esta cancelada");
                }

                this.OrdenTrabajo.EstatusOrdenTrabajo_ID = 3;
                this.OrdenTrabajo.FechaTerminacion = DB.GetDate();
                this.OrdenTrabajo.Update();

                //  Cambiar el status de las ordenes de servicio
                UpdateOrdenesServicios();

                //  Registrar el gasto en la cuenta de la unidad
                InsertCuentaUnidad();

                Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
                registro.Accion = "TERMINAR ORDEN TRABAJO";
                registro.Comentarios = "ORDEN ID: " + this.OrdenTrabajo_ID.ToString();
                registro.Fecha = DB.GetDate();
                registro.Formulario = "TerminacionOrdenesTrabajo";
                registro.Opcion_ID = null;
                registro.Usuario_ID = Sesion.Usuario_ID;
                registro.Create();
            }
        }

        #endregion

        public override void BindData()
        {
            Model = new TerminacionOrdenesTrabajo_Model();
            base.BindData();
        }

        private void OrdenCompraTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //  Validar y consultar los datos de la orden de trabajo

            AppHelper.Try(
                delegate
                {
                    //  Al presionar "Enter"
                    if (e.KeyData == Keys.Enter)
                    {
                        if (!string.IsNullOrEmpty(this.OrdenTrabajoTextBox.Text))
                        {
                            Model.OrdenTrabajo_ID =
                                Convert.ToInt32(this.OrdenTrabajoTextBox.Text);
                            Model.ConsultarOrdenTrabajo();
                            vista_OrdenesTrabajosBindingSource.DataSource = Model.DatosOrden;
                        }
                    }
                }
            );
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            //  Efectuar la terminación de la orden de trabajo
            AppHelper.DoMethod(
                delegate
                {
                    Model.TerminarOrdenTrabajo();
                    AppHelper.Info("Orden trabajo terminada!");
                    AppHelper.ClearControl(this);
                }
            , this);
        }

        #region Events
        #endregion
    }
}
