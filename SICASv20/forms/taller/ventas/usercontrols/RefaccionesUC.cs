using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class RefaccionesUC : baseUserControl
    {
        public RefaccionesUC()
        {
            InitializeComponent();            
            AppHelper.SetStylish(this);
        }

        public NuevaOrdenTrabajo Padre;
        
        private void MostrarTotales()
        {            
            List<Entities.OrdenesServiciosRefacciones> ordenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();
            foreach (Entities.OrdenesServicios os in Padre.OrdenTrabajo.OrdenesServicios)
            {
                ordenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
            }

            //  DataBind a refacciones
            this.RefaccionesAgregadasDataGrdiView.DataSource = ordenesServiciosRefacciones;
            this.vista_RefaccionesBindingSource.DataSource = null;

            Padre.OrdenTrabajo.CalcularTotales();
            Padre.MostrarTotales();
        }

        private void AgregarRefaccion( Entities.Vista_Refacciones refaccion, int cantidad)
        {
            //  Verificar el inventario
            //  Obtener el tipo de cliente

            Entities.OrdenesServiciosRefacciones osr = new Entities.OrdenesServiciosRefacciones();
            osr.Cantidad = cantidad;
            osr.CostoUnitario = refaccion.CostoUnitario.Value;
            osr.PrecioUnitario = refaccion.PrecioInterno.Value; // Verificar
            osr.Refaccion_Descripcion = refaccion.Descripcion;
            osr.Refaccion_ID = refaccion.Refaccion_ID.Value;
            osr.RefSurtidas = 0;
            osr.Total = osr.PrecioUnitario * osr.Cantidad;

            this.Padre.OrdenTrabajo.OrdenesServicios[0].OrdenesServiciosRefacciones.Add(osr);

            MostrarTotales();
        }

        private void EliminarOrdenServicioRefaccion(Entities.OrdenesServiciosRefacciones osr)
        {
            this.Padre.OrdenTrabajo.OrdenesServicios[0].OrdenesServiciosRefacciones.Remove(osr);

            MostrarTotales();
        }

        private void RefaccionesDisponiblesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesDisponiblesDataGridView.Columns["SeleccionarRef"].Index == e.ColumnIndex)
                {
                    InputCantidad input = new InputCantidad();
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        Entities.Vista_Refacciones vistaRef =
                            (Entities.Vista_Refacciones)this.RefaccionesDisponiblesDataGridView.Rows[e.RowIndex].DataBoundItem;

                        AgregarRefaccion(vistaRef, input.Cantidad);               

                        this.RefaccionTextBox.Text = "";
                    } // End if
                } // End if
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void RefaccionesAgregadasDataGrdiView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.RefaccionesAgregadasDataGrdiView.Columns["EliminarRef"].Index == e.ColumnIndex)
                {
                    Entities.OrdenesServiciosRefacciones osr =
                        (Entities.OrdenesServiciosRefacciones)RefaccionesAgregadasDataGrdiView.Rows[e.RowIndex].DataBoundItem;
                    EliminarOrdenServicioRefaccion(osr);
                } // End if
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void DoValidate()
        {
            if (Padre.OrdenTrabajo.OrdenesServicios.Count == 0)
            {
                throw new Exception("Debe seleccionar al menos un servicio");
            }

            if (Padre.OrdenTrabajo.OrdenesServicios[0].OrdenesServiciosRefacciones.Count == 0)
            {
                throw new Exception("Debe seleccionar al menos una refacción");
            }
        } 

        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoValidate();
                Padre.SwitchPanel("Mecanico");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
