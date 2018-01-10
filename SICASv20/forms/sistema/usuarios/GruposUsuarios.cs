using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class GruposUsuarios : baseForm
    {
        public GruposUsuarios()
        {
            InitializeComponent();
        }

        class GruposUsuarios_Model
        {
            private List<Entities.GruposUsuarios> _GruposUsuarios;
            public List<Entities.GruposUsuarios> GruposUsuarios
            {
                get { return _GruposUsuarios; }
                set { _GruposUsuarios = value; }
            }

            public void Consultar()
            {
                this.GruposUsuarios = Entities.GruposUsuarios.Read();
            }
        }

        private GruposUsuarios_Model Model;
        public override void BindData()
        {
            this.Model = new GruposUsuarios_Model();
            this.Model.Consultar();
            this.gruposUsuariosBindingSource.DataSource = this.Model.GruposUsuarios;
            base.BindData();
        }

        private void gruposUsuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (e.ColumnIndex == gruposUsuariosDataGridView.Columns["EditPermisosColumn"].Index)
                    {
                        forms.ActualizacionPermisosGruposUsuarios au = new forms.ActualizacionPermisosGruposUsuarios();
                        Entities.GruposUsuarios grupo = 
                            (Entities.GruposUsuarios)gruposUsuariosDataGridView.Rows[e.RowIndex].DataBoundItem;

                        au.GrupoUsuario_ID = grupo.GrupoUsuario_ID;
                        Padre.SwitchForma("ActualizacionPermisosGruposUsuarios", au);
                    } // end if
                } // end delegate
            ); // end method
        } // end void
    } // end class
} // end namespace
