using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionTiposRefacciones : baseForm
    {
        public ActualizacionTiposRefacciones()
        {
            InitializeComponent();
        }

        #region Model

        class ActualizacionTiposRefacciones_Model
        {
            public ActualizacionTiposRefacciones_Model()
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
                TipoRefaccion.Update();
            }
        }

        #endregion

        #region Properties

        ActualizacionTiposRefacciones_Model Model;

        #endregion

        #region Events

        public override void BindData()
        {
            if(this.Model==null) this.Model = new ActualizacionTiposRefacciones_Model();

            this.Model.Consultar();
            this.familiasBindingSource.DataSource = this.Model.Familias;
            this.tiposRefaccionesBindingSource.DataSource = this.Model.TipoRefaccion;
            base.BindData();
        }

        public void Set_TipoRefaccion(Entities.TiposRefacciones tiporefaccion)
        {
            this.Model = new ActualizacionTiposRefacciones_Model();
            this.Model.TipoRefaccion = tiporefaccion;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Guardar();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Tipo de refaccion actualizada");
                    this.FamiliaCombobox.Focus();
                },
                this
            );
        }

        #endregion
    } // end class
} // end namespace
