using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ServiciosMantenimientosTiposRefacciones : baseForm
    {
        public ServiciosMantenimientosTiposRefacciones()
        {
            InitializeComponent();
        }

        public class ServiciosMantenimientosTiposRefacciones_Model
        {
            private Entities.ServiciosMantenimientos _ServicioMantenimiento;
            public Entities.ServiciosMantenimientos ServicioMantenimiento
            {
                get { return _ServicioMantenimiento; }
                set { _ServicioMantenimiento = value; }
            }

            private List<Entities.TiposRefacciones> _TiposRefacciones;
            public List<Entities.TiposRefacciones> TiposRefacciones
            {
                get { return _TiposRefacciones; }
                set { _TiposRefacciones = value; }
            }

            private List<Entities.Vista_ServiciosMantenimientos_TiposRefacciones> _ServiciosMantenimientosTiposRefacciones;
            public List<Entities.Vista_ServiciosMantenimientos_TiposRefacciones> ServiciosMantenimientosTiposRefacciones
            {
                get { return _ServiciosMantenimientosTiposRefacciones; }
                set { _ServiciosMantenimientosTiposRefacciones = value; }
            }

            public void Consultar(int serviciomantenimiento_id)
            {
                this.ServicioMantenimiento = Entities.ServiciosMantenimientos.Read(serviciomantenimiento_id);

                this.TiposRefacciones = Entities.TiposRefacciones.ReadList(
                        DB.Param("Familia_ID", this.ServicioMantenimiento.Familia_ID)
                    );

                this.ServiciosMantenimientosTiposRefacciones =
                    new List<Entities.Vista_ServiciosMantenimientos_TiposRefacciones>(
                            Entities.Vista_ServiciosMantenimientos_TiposRefacciones.Get(
                                this.ServicioMantenimiento.ServicioMantenimiento_ID
                            )
                        );
            }

            public bool ExisteTipoRefaccion(Entities.TiposRefacciones tiporefaccion)
            {
                return this.ServiciosMantenimientosTiposRefacciones.Exists(
                        delegate(Entities.Vista_ServiciosMantenimientos_TiposRefacciones smtr)
                        {
                            if (smtr.TipoRefaccion_ID == tiporefaccion.TipoRefaccion_ID)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
            }

            public void Agregar(Entities.TiposRefacciones tiporefaccion, int cantidad)
            {
                this.ServiciosMantenimientosTiposRefacciones.Add(
                    new Entities.Vista_ServiciosMantenimientos_TiposRefacciones(
                            this.ServicioMantenimiento.ServicioMantenimiento_ID,
                            this.ServicioMantenimiento.Nombre,
                            tiporefaccion.TipoRefaccion_ID,
                            tiporefaccion.Nombre,
                            cantidad
                        )
                    );
            }

            public void Eliminar(Entities.Vista_ServiciosMantenimientos_TiposRefacciones tiporefaccion)
            {                
                this.ServiciosMantenimientosTiposRefacciones.Remove(tiporefaccion);
            }

            public void Guardar()
            {
                DB.DeleteRow(
                    "ServiciosMantenimientos_TiposRefacciones",
                    DB.GetParams(
                        DB.Param("ServicioMantenimiento_ID", this.ServicioMantenimiento.ServicioMantenimiento_ID)
                    )
                );

                foreach (Entities.Vista_ServiciosMantenimientos_TiposRefacciones tiporefaccion in this.ServiciosMantenimientosTiposRefacciones)
                {                    
                    Entities.ServiciosMantenimientos_TiposRefacciones smtr = new Entities.ServiciosMantenimientos_TiposRefacciones();
                    smtr.Cantidad = tiporefaccion.Cantidad;
                    smtr.ServicioMantenimiento_ID = tiporefaccion.ServicioMantenimiento_ID;
                    smtr.TipoRefaccion_ID = tiporefaccion.TipoRefaccion_ID;

                    smtr.Create();
                }
            }
        } // end class

        ServiciosMantenimientosTiposRefacciones_Model Model;
        InputCantidad input = new InputCantidad();
        BusquedaTipoRefaccion BuscarTipoRefaccionForm = new BusquedaTipoRefaccion();

        private int _ServicioMantenimiento_ID;
        public int ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        public override void BindData()
        {
            this.Model = new ServiciosMantenimientosTiposRefacciones_Model();
            this.Model.Consultar(this.ServicioMantenimiento_ID);
            this.NombreServicioTextBox.Text = this.Model.ServicioMantenimiento.Nombre;
            this.tiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
            this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource = this.Model.ServiciosMantenimientosTiposRefacciones;

            base.BindData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (this.dataGridView1.Columns[e.ColumnIndex].Name == "EliminarCol")
                    {
                        Entities.Vista_ServiciosMantenimientos_TiposRefacciones tiporefaccion =
                            (Entities.Vista_ServiciosMantenimientos_TiposRefacciones)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;

                        this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource = null;

                        this.Model.Eliminar(tiporefaccion);

                        this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource = 
                            this.Model.ServiciosMantenimientosTiposRefacciones;
                    }
                }
            );
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Guardar();
                    AppHelper.Info("Servicio actualizado");
                }
            );
        }

        private void TipoRefaccionButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (BuscarTipoRefaccionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Entities.TiposRefacciones tiporefaccion =
                            (Entities.TiposRefacciones)BuscarTipoRefaccionForm.TipoRefaccion;

                        if (this.Model.ExisteTipoRefaccion(tiporefaccion))
                        {
                            throw new Exception("Tipo refacción ya se encuentra en la lista");
                        }
                        else
                        {
                            if (input.ShowDialog() == DialogResult.OK)
                            {
                                this.Model.Agregar(tiporefaccion, input.Cantidad);

                                this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource = null;
                                this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource =
                                    this.Model.ServiciosMantenimientosTiposRefacciones;

                                this.TipoRefaccionTextBox.Text = tiporefaccion.Nombre;
                            }
                        }
                    }                                       
                } // end delegate
            ); 
        } // end void
    } // end class
} // end namespace
