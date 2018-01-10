using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionRefacciones : baseForm
    {
        public ActualizacionRefacciones()
        {
            InitializeComponent();
            AppHelper.AddTextBoxesOnlyNumbersValidation(
                this.costoUnitarioTextBox,
                this.margenInternoTextBox,
                this.margenExternoTextBox
            );
        }

        private Int32 _Refaccion_ID;
        public Int32 Refaccion_ID
        {
            get { return _Refaccion_ID; }
            set { _Refaccion_ID = value; }
        }

        private Entities.Inventario Inventario;
        private bool IsDataBound = false;

        public override void BindData()
        {
            TiposRefaccionesBindingSource.DataSource = Entities.TiposRefacciones.ReadOrderByNombre();
            ModelosBindingSource.DataSource = Entities.Modelos.Read();
            MarcasRefaccionesBindingSource.DataSource = Entities.MarcasRefacciones.Read();
            RefaccionesBindingSource.DataSource = Entities.Refacciones.Read(this.Refaccion_ID);
            
            this.Inventario = 
                Entities.Inventario.Read(
                    this.Refaccion_ID, 
                    Sesion.Empresa_ID.Value, 
                    Sesion.Estacion_ID.Value
                );

            this.inventarioBindingSource.DataSource = Inventario;

            TiposRefaccionesBindingSource.Sort = "Nombre";
            ModelosBindingSource.Sort = "Nombre";
            MarcasRefaccionesBindingSource.Sort = "Nombre";

            AppHelper.SetContainerDBValidations(this, "Refacciones");

            IsDataBound = true;

            base.BindData();
        }

        private void DoBackToList()
        {
            forms.Refacciones RefaccionesLower = new forms.Refacciones();
            Padre.SwitchForma("Refacciones", RefaccionesLower);
        }

        private string set_Descripcion()
        {
            string descripcion = "";

            if (TipoRefaccion_IDComboBox.SelectedItem != null)
            {
                Entities.TiposRefacciones tipo = (Entities.TiposRefacciones)TipoRefaccion_IDComboBox.SelectedItem;
                descripcion += tipo.Nombre;
            }

            if (Modelo_IDComboBox.SelectedItem != null)
            {
                Entities.Modelos modelo = (Entities.Modelos)Modelo_IDComboBox.SelectedItem;
                descripcion += " " + modelo.Nombre;
            }

            descripcion += " " + AnioTextBox.Text;

            if (MarcaRefaccion_IDComboBox.SelectedItem != null)
            {
                Entities.MarcasRefacciones marca = (Entities.MarcasRefacciones)MarcaRefaccion_IDComboBox.SelectedItem;
                descripcion += " " + marca.Nombre;
            }

            DescripcionTextBox.Text = descripcion;

            return descripcion;
        }

        private void DoSave()
        {
            set_Descripcion();
            Entities.Refacciones refacciones = (Entities.Refacciones)RefaccionesBindingSource.Current;
            refacciones.Descripcion = set_Descripcion();
            refacciones.Update();
            this.Inventario.Update();
            DoBackToList();
            AppHelper.Info("¡Refaccion actualizada!");
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        }

        private void ActualizarDatosInventario()
        {
            if (IsDataBound)
            {
                this.Inventario.PrecioInterno = this.Inventario.CostoUnitario * (1 + (this.Inventario.MargenInterno / 100));
                this.Inventario.PrecioExterno = this.Inventario.CostoUnitario * (1 + (this.Inventario.MargenExterno / 100));

                this.inventarioBindingSource.DataSource = this.Inventario;
                this.inventarioBindingSource.ResetBindings(false);
            }
        }

        private void costoUnitarioTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (!string.IsNullOrEmpty(this.costoUnitarioTextBox.Text))
                    {
                        this.Inventario.CostoUnitario = Convert.ToDecimal(this.costoUnitarioTextBox.Text);
                        ActualizarDatosInventario();
                    }
                }
            );
        }

        private void margenExternoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (!string.IsNullOrEmpty(this.margenExternoTextBox.Text))
                    {
                        this.Inventario.MargenExterno = Convert.ToDecimal(this.margenExternoTextBox.Text);
                        ActualizarDatosInventario();
                    }
                }
            );
        }

        private void margenInternoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (!string.IsNullOrEmpty(this.margenInternoTextBox.Text))
                    {
                        this.Inventario.MargenInterno = Convert.ToDecimal(this.margenInternoTextBox.Text);
                        ActualizarDatosInventario();
                    }
                }
            );
        }

    }
}
