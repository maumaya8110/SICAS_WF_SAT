using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AjusteInventario : baseForm
    {
        public AjusteInventario()
        {
            InitializeComponent();
        }

        #region Properties
        private AjusteInventario_Model Model;
        #endregion

        #region Model
        class AjusteInventario_Model
        {                      

            private Entities.Vista_Refacciones _Refaccion;
            public Entities.Vista_Refacciones Refaccion
            {
                get { return _Refaccion; }
                set { _Refaccion = value; }
            }

            private List<Entities.Refacciones> _Refacciones;
            public List<Entities.Refacciones> Refacciones
            {
                get { return _Refacciones; }
                set { _Refacciones = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private List<Entities.TiposAjustesInventario> _TiposAjustes;
            public List<Entities.TiposAjustesInventario> TiposAjustes
            {
                get { return _TiposAjustes; }
                set { _TiposAjustes = value; }
            }

            private Entities.TiposAjustesInventario _TipoAjuste;
            public Entities.TiposAjustesInventario TipoAjuste
            {
                get { return _TipoAjuste; }
                set { _TipoAjuste = value; }
            }

            public void ConsultarTiposMovimientosInventarios()
            {
                this.TiposAjustes = Entities.TiposAjustesInventario.Read();
            }

            public void ConsultarRefacciones()
            {
                this.Refacciones = Entities.Refacciones.ReadOrderByDescripcion();
            }

            public void RegistrarAjuste()
            {
                Entities.AjustesInventario AjusteInventario = new Entities.AjustesInventario();
                
                AjusteInventario.Cantidad = this.Cantidad;
                AjusteInventario.Comentarios = this.Comentarios;
                AjusteInventario.CostoUnitario = this.Refaccion.CostoUnitario.Value;
                AjusteInventario.Fecha = DB.GetDate();
                AjusteInventario.Refaccion_ID = this.Refaccion.Refaccion_ID.Value;
                AjusteInventario.TipoAjusteInventario_ID = this.TipoAjuste.TipoAjusteInventario_ID;
                AjusteInventario.Total = AjusteInventario.CostoUnitario * AjusteInventario.Cantidad;
                AjusteInventario.Usuario_ID = Sesion.Usuario_ID;
                AjusteInventario.Empresa_ID = Sesion.Empresa_ID.Value;
                AjusteInventario.Estacion_ID = Sesion.Estacion_ID.Value;

                if (this.TipoAjuste.TipoAjusteInventario_ID == 2)
                {
                    AjusteInventario.Cantidad *= -1;
                }

                AjusteInventario.Create();
                
                Entities.NotasAlmacen NotaAlmacen = new Entities.NotasAlmacen();
                Entities.MovimientosInventario MovimientoInventario = new Entities.MovimientosInventario();

                //  Insertar Nota Almacen
                NotaAlmacen.Fecha = DB.GetDate();                
                NotaAlmacen.TipoMovimientoInventario_ID = 3; // Ajuste
                NotaAlmacen.Usuario_ID = Sesion.Usuario_ID;
                NotaAlmacen.Empresa_ID = Sesion.Empresa_ID.Value;
                NotaAlmacen.Estacion_ID = Sesion.Estacion_ID.Value;
                NotaAlmacen.Create();

                //  Insertar movimiento de inventario
                MovimientoInventario.Cantidad = AjusteInventario.Cantidad;
                MovimientoInventario.CostoUnitario = Refaccion.CostoUnitario.Value;
                MovimientoInventario.Fecha = NotaAlmacen.Fecha;
                MovimientoInventario.NotaAlmacen_ID = NotaAlmacen.NotaAlmacen_ID;
                MovimientoInventario.AjusteInventario_ID = AjusteInventario.AjusteInventario_ID;
                MovimientoInventario.Refaccion_ID = AjusteInventario.Refaccion_ID;
                MovimientoInventario.TipoMovimientoInventario_ID = NotaAlmacen.TipoMovimientoInventario_ID;
                MovimientoInventario.Usuario_ID = NotaAlmacen.Usuario_ID;
                MovimientoInventario.Valor = Refaccion.CostoUnitario.Value * AjusteInventario.Cantidad;
                MovimientoInventario.Empresa_ID = Sesion.Empresa_ID.Value;
                MovimientoInventario.Estacion_ID = Sesion.Estacion_ID.Value;
                MovimientoInventario.Calculate();
                MovimientoInventario.Create();
        
                //  Actualizar refaccion
                MovimientoInventario.UpdateRefaccion(false);
            }
        }
        #endregion

        #region Events
        public override void BindData()
        {
            this.Model = new AjusteInventario_Model();
            this.Model.ConsultarRefacciones();
            this.Model.ConsultarTiposMovimientosInventarios();
            this.refaccionesBindingSource.DataSource = this.Model.Refacciones;
            this.tiposAjustesInventarioBindingSource.DataSource = this.Model.TiposAjustes;
            this.Model.TipoAjuste = (Entities.TiposAjustesInventario)this.TiposMovimientosInventarioComboBox.SelectedItem;
            base.BindData();
        }

        private void TiposMovimientosInventarioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.TipoAjuste = (Entities.TiposAjustesInventario)this.TiposMovimientosInventarioComboBox.SelectedItem;
            });
        }

        private void RefaccionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                Entities.Refacciones refaccion = (Entities.Refacciones)this.RefaccionesComboBox.SelectedItem;

                this.Model.Refaccion = 
                    Entities.Vista_Refacciones.GetSingle(
                        refaccion.Refaccion_ID, 
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        Sesion.Empresa_ID.Value, 
                        Sesion.Estacion_ID.Value
                    );

                this.CantidadInventarioTextBox.Text = this.Model.Refaccion.CantidadInventario.ToString();
            });
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.Cantidad = Convert.ToInt32(this.CantidadNumericUpDown.Value);
            });
        }

        private void ComentariosTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.Comentarios = ComentariosTextBox.Text;
            });
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                this.Model.RegistrarAjuste();
                AppHelper.Info("Ajuste realizado");
                AppHelper.ClearControl(this);
            }, this);
        }
        #endregion
    }
}
