using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaTiposRefacciones : baseForm
    {
        public AltaTiposRefacciones()
        {
            InitializeComponent();
        }

        #region Model

        class AltaTiposRefacciones_Model
        {
            public AltaTiposRefacciones_Model()
            { 

            }

            private Entities.TiposRefacciones _TipoRefaccion;
            public Entities.TiposRefacciones TipoRefaccion
            {
                get { return _TipoRefaccion; }
                set { _TipoRefaccion = value; }
            }

            private List<Entities.Familias> _Familias;
            public List<Entities.Familias> Familias
            {
                get { return _Familias; }
                set { _Familias = value; }
            }

            public void Consultar()
            {
                this.Familias = Entities.Familias.Read();
            }

            public void Guardar()
            {                
                TipoRefaccion.Create();
            }
        }

        #endregion

        #region Properties

        AltaTiposRefacciones_Model Model;

        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new AltaTiposRefacciones_Model();
            this.Model.Consultar();
            this.familiasBindingSource.DataSource = this.Model.Familias;
            this.tiposRefaccionesBindingSource.AddNew();
            base.BindData();
        }       

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.TipoRefaccion = (Entities.TiposRefacciones)this.tiposRefaccionesBindingSource.Current;
                    this.Model.Guardar();
                    this.Model.TipoRefaccion = null;
                    this.tiposRefaccionesBindingSource.AddNew();
                    AppHelper.Info("Tipo de refaccion registrada");
                    this.FamiliaCombobox.Focus();
                },
                this
            );
        }

        #endregion
    } // end class
} // end namespace
