using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class PermisosCajasUsuarios : baseForm
    {
        public PermisosCajasUsuarios()
        {
            InitializeComponent();
        }

        class PermisosCajasUsuarios_Model
        {
            public Entities.Usuarios Usuario { get; set; }
            public Entities.Vista_Usuarios VistaUsuario { get; set; }
            public List<Entities.Vista_Usuarios_Cajas> CajasUsuario { get; set; }
            public List<Entities.Cajas> Cajas { get; set; }
            public Entities.Cajas CajaActual { get; set; }

            public void Consultar()
            {
                this.ConsultarCajas();
                this.ConsultarCajasUsuarios();
            }

            public void ConsultarUsuario(string usuario_id)
            {
                this.Usuario = Entities.Usuarios.Read(usuario_id);

                //  Consultar la estación del usuario
                //  Asignarla si tiene solo una
                //  Si tiene más de una, error
                List<Entities.Usuarios_Estaciones> ue = 
                    Entities.Usuarios_Estaciones.Read(usuario_id);

                if (ue.Count == 1)
                {
                    this.Usuario.Estacion_ID = ue[0].Estacion_ID;
                }
                else
                {
                    throw new Exception("El usuario debe tener configurado una y solo una estación");
                }

                this.VistaUsuario = Entities.Vista_Usuarios.Get(usuario_id);
            }

            private void ConsultarCajasUsuarios()
            {
                this.CajasUsuario = Entities.Vista_Usuarios_Cajas.Get(this.Usuario.Usuario_ID);
            }

            private void ConsultarCajas()
            {
                this.Cajas = Entities.Cajas.ReadList(
                        @"Estacion_ID = @Estacion_ID
AND Activa = 1
AND Caja_ID NOT IN
(
    SELECT  Caja_ID
    FROM    Usuarios_Cajas
    WHERE   Usuario_ID = @Usuario_ID
)",
                        null,
                        DB.Param("@Estacion_ID", this.Usuario.Estacion_ID),
                        DB.Param("@Usuario_ID", this.Usuario.Usuario_ID)
                    );
            }

            public void AgregarCaja()
            {
                Entities.Usuarios_Cajas uc = new Entities.Usuarios_Cajas();
                uc.Usuario_ID = this.Usuario.Usuario_ID;
                uc.Caja_ID = this.CajaActual.Caja_ID;
                uc.Create();
            }

            public void EliminarCaja(int caja_id)
            {
                Entities.Usuarios_Cajas uc = new Entities.Usuarios_Cajas();
                uc.Usuario_ID = this.Usuario.Usuario_ID;
                uc.Caja_ID = caja_id;
                uc.Delete();
            }

        } // end class

        private PermisosCajasUsuarios_Model Model;

        public string Usuario_ID { get; set; }

        public override void BindData()
        {
            this.Model = new PermisosCajasUsuarios_Model();
            this.Model.ConsultarUsuario(this.Usuario_ID);
            this.Model.Consultar();
            RefrescarDatos();
            base.BindData();
        }

        private void RefrescarDatos()
        {
            this.vista_UsuariosBindingSource.DataSource = this.Model.VistaUsuario;
            this.vista_Usuarios_CajasBindingSource.DataSource = this.Model.CajasUsuario;
            this.cajasBindingSource.DataSource = this.Model.Cajas;
            this.Model.CajaActual = (Entities.Cajas)CajasComboBox.SelectedItem;
        }

        private void CajasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Debe cambiar la caja activa en el modelo
                    if (this.CajasComboBox.SelectedItem != null)
                    {
                        this.Model.CajaActual = (Entities.Cajas)CajasComboBox.SelectedItem;
                    }
                }
            );
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            //  Debe agregar la caja a los permisos de caja del usuario
            //  Debe refrescar los datos de cajas y cajas de usuario
            AppHelper.Try(
                delegate
                {
                    this.Model.AgregarCaja();
                    this.Model.Consultar();
                    this.RefrescarDatos();
                }
            );
        }

        private void vista_Usuarios_CajasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  Si es eliminar
            //  Debe eliminar la caja de los permisos de caja del usuario
            //  Debe refresacar los datos
            AppHelper.Try(
                delegate
                {
                    if (vista_Usuarios_CajasDataGridView.Columns[e.ColumnIndex].Name.Equals("EliminarColumn"))
                    {
                        Entities.Vista_Usuarios_Cajas vuc = new Entities.Vista_Usuarios_Cajas();
                        vuc = (Entities.Vista_Usuarios_Cajas)vista_Usuarios_CajasDataGridView.Rows[e.RowIndex].DataBoundItem;
                        
                        this.Model.EliminarCaja(vuc.Caja_ID.Value);
                        this.Model.Consultar();
                        this.RefrescarDatos();

                    } // end if        
                } // end delegate
            ); // end Try
        } // end void
    } // end class
} // end namespace
