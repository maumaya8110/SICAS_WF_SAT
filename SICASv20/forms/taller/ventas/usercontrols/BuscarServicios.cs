using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BuscarServicios : Form
    {
        public BuscarServicios()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
            EsRefaccionesIncluidas = true;
        }

        public Entities.Vista_ServiciosMantenimientos Servicio { get; set; }
        public bool EsRefaccionesIncluidas { get; set; }
        public int Cantidad { get; set; }
        public NuevaOrdenTrabajo Padre { get; set; }
        public int TipoClienteTaller_ID { get; set; }
        private InventarioRefaccionesServicioMantenimiento InventarioRefaccionesForm { get; set; }

        public void ShowInventarioServicio(string servicio, List<Entities.Vista_InventarioRefaccionesServicio> inventario)
        {
            if (InventarioRefaccionesForm == null)
                this.InventarioRefaccionesForm = new InventarioRefaccionesServicioMantenimiento();

            if (InventarioRefaccionesForm.IsDisposed)
                this.InventarioRefaccionesForm = new InventarioRefaccionesServicioMantenimiento();

            this.InventarioRefaccionesForm.NombreServicio = servicio;
            this.InventarioRefaccionesForm.Inventario = inventario;
            this.InventarioRefaccionesForm.BindData();
            this.InventarioRefaccionesForm.Show();
        }

        public void Buscar()
        {
            List<Entities.Vista_ServiciosMantenimientos> servicios;
            
            if (!EsRefaccionesIncluidas)
            {
                //  Consultar sin importar inventario
                servicios =
                    Entities.Vista_ServiciosMantenimientos.GetServicios(
                    this.ServicioTextBox.Text,
                    this.Padre.Modelo_ID.Value,
                    this.TipoClienteTaller_ID,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value
                );
            }
            else
            {
                // Consultar y verificar el inventario
                servicios =
                    Entities.Vista_ServiciosMantenimientos.GetServicios(
                    this.ServicioTextBox.Text,
                    this.Padre.Modelo_ID.Value,
                    this.TipoClienteTaller_ID,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value
                );

                //  Verificar si trajo servicios
                if (servicios == null || servicios.Count == 0)
                {
                    //  No devolvió servicios
                    //  Verificar si tiene refacciones
                    //  para las cuales no se tengan inventario
                    List<Entities.Vista_InventarioRefaccionesServicio> inventario =
                        Entities.Vista_InventarioRefaccionesServicio.Get(
                            Sesion.Empresa_ID,
                            Sesion.Estacion_ID,
                            this.TipoClienteTaller_ID,
                            this.ServicioTextBox.Text,
                            this.Padre.Modelo_ID
                        );

                    if (inventario != null && inventario.Count > 0)
                    {
                        //  Mostrar mensaje de falta de inventario
                        //  Incluyendo las refacciones de las cuales hacen falta
                        AppHelper.Error("No hay inventario suficiente de las refacciones");
                        ShowInventarioServicio(this.ServicioTextBox.Text, inventario);
                        return;
                    }
                    else
                    {
                        inventario = Entities.Vista_InventarioRefaccionesServicio.Get(
                                Sesion.Empresa_ID,
                                Sesion.Estacion_ID,
                                this.TipoClienteTaller_ID,
                                this.ServicioTextBox.Text
                            );

                        if (inventario != null && inventario.Count > 0)
                        {
                            AppHelper.Error("No hay refacciones para el modelo de la unidad");
                            ShowInventarioServicio(this.ServicioTextBox.Text, inventario);
                            return;
                        }
                        else
                        {
                            AppHelper.ThrowException("No se encontraron refacciones para el servicio / servicio en el catalogo");
                        }
                    }
                }
            }

            this.vista_ServiciosMantenimientosBindingSource.DataSource = servicios;
        }

        private void ServiciosDisponiblesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ServiciosDisponiblesDataGridView.Columns["Seleccionar"].Index == e.ColumnIndex)
                {
                    InputCantidad input = new InputCantidad();
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        this.Servicio = (Entities.Vista_ServiciosMantenimientos)this.ServiciosDisponiblesDataGridView.Rows[e.RowIndex].DataBoundItem;
                        this.Cantidad = input.Cantidad;
                        this.ServicioTextBox.Text = "";
                        this.vista_ServiciosMantenimientosBindingSource.DataSource = null;
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

        private void ServicioRefaccionesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate { 
                    this.EsRefaccionesIncluidas = true; 
                }
            );
        }

        private void SoloServicioRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate { 
                    this.EsRefaccionesIncluidas = false;
                }
            );
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate { 
                    this.Buscar(); 
                }
            );
        }

        private void ServicioTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.Try(
                    delegate {
                        this.Buscar();
                    }
                );
            }
        } // end void ServicioTextBox_KeyUp

    } // end class
} // end namespace 
