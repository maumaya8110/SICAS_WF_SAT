using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaRefacciones : baseForm
    {
        public AltaRefacciones()
        {
            InitializeComponent();
            AppHelper.AddTextBoxOnlyNumbersValidation(ref this.anioTextBox);
        }

        class AltaRefacciones_Model:Entities.Refacciones
        {
            private List<Entities.TiposRefacciones> _TiposRefacciones;
            public List<Entities.TiposRefacciones> TiposRefacciones
            {
                get { return _TiposRefacciones; }
                set { _TiposRefacciones = value; }
            }

            private List<Entities.Modelos> _Modelos;
            public List<Entities.Modelos> Modelos
            {
                get { return _Modelos; }
                set { _Modelos = value; }
            }

            private List<Entities.MarcasRefacciones> _MarcasRefacciones;
            public List<Entities.MarcasRefacciones> MarcasRefacciones
            {
                get { return _MarcasRefacciones; }
                set { _MarcasRefacciones = value; }
            }

            public void Consultar()
            {
                this.TiposRefacciones = Entities.TiposRefacciones.ReadOrderByNombre();
                this.Modelos = Entities.Modelos.Read();
                this.MarcasRefacciones = Entities.MarcasRefacciones.Read();
            }

            private void SetDescripcion()
            {
                string tipo, modelo, marca;
                tipo = 
                    this.TiposRefacciones.Find(
                        delegate(Entities.TiposRefacciones tp) 
                        { 
                            return tp.TipoRefaccion_ID == this.TipoRefaccion_ID; 
                        }
                    ).Nombre;

                modelo =
                    this.Modelos.Find(
                        delegate(Entities.Modelos m)
                        {
                            return m.Modelo_ID == this.Modelo_ID;
                        }
                    ).Nombre;

                marca =
                    this.MarcasRefacciones.Find(
                        delegate(Entities.MarcasRefacciones mr)
                        {
                            return mr.MarcaRefaccion_ID == this.MarcaRefaccion_ID;
                        }
                    ).Nombre;

                this.Descripcion = tipo + " " + modelo + " " + marca;
                
                if (this.Anio != null)
                {
                    this.Descripcion += " " + this.Anio.ToString();
                }
            }

            public void Guardar()
            {
                this.SetDescripcion();
                this.Validate();                
                this.Create();
            }
        } // End class Model

        private AltaRefacciones_Model Model;

        public override void BindData()
        {
            this.refaccionesBindingSource.AddNew();
            Model = new AltaRefacciones_Model();
            Model.Consultar();
            this.tiposRefaccionesBindingSource.DataSource = this.Model.TiposRefacciones;
            this.modelosBindingSource.DataSource = this.Model.Modelos;
            this.marcasRefaccionesBindingSource.DataSource = this.Model.MarcasRefacciones;
            base.BindData();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(
                delegate
                {
                    this.Model.Guardar();
                    this.refaccionesBindingSource.AddNew();
                    AppHelper.Info("Refacción guardada!");
                },
                this
            );
        }

        private void tipoRefaccion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.TipoRefaccion_ID = Convert.ToInt32(this.tipoRefaccion_IDComboBox.SelectedValue);
                }
            );
        }

        private void modelo_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Modelo_ID = Convert.ToInt32(this.modelo_IDComboBox.SelectedValue);
                }
            );
        }

        private void marcaRefaccion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.MarcaRefaccion_ID = Convert.ToInt32(this.marcaRefaccion_IDComboBox.SelectedValue);
                }
            );
        }

        private void anioTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (!string.IsNullOrEmpty(this.anioTextBox.Text))
                        this.Model.Anio = Convert.ToInt32(this.anioTextBox.Text);
                }
            );
        }

        private void numeroSerialTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NumeroSerial = this.numeroSerialTextBox.Text;
                }
            );
        }
    } // End Class Form
} // End Namespace
