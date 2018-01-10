/*
 * AltaUsuario
 * 
 * Ultima modificación
 * 17 de Octubre de 2012
 * por Luis Espino
 * 
 * Se agrega la funcionalidad de elegir empresa por empresa y
 * estación por estación
 * 
 * 2012-10-17 // Luis Espino
 *      **  Se agregó el método "DoValidate" para validar los permisos
 *          de empresas y estaciones
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaUsuario : baseForm
    {
        public AltaUsuario()
        {
            InitializeComponent();

            Empresas = new List<Entities.SelectEmpresasInternas>();
            Estaciones = new List<Entities.Estaciones>();
        }

        /// <summary>
        /// El listado de empresas
        /// </summary>
        private List<Entities.SelectEmpresasInternas> Empresas { get; set; }

        /// <summary>
        /// El listado de estaciones
        /// </summary>
        private List<Entities.Estaciones> Estaciones { get; set; }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {                        
            this.Empresas = Entities.SelectEmpresasInternas.GetAll();            
            this.Estaciones = Entities.Estaciones.Read();
            this.BindEmpresasCheckList();
            this.BindEstacionesCheckList();

            base.BindData();
        }

        /// <summary>
        /// Liga los datos de las empresas al control
        /// </summary>
        private void BindEmpresasCheckList()
        {
            this.EmpresasCheckList.Items.Clear();

            foreach (Entities.SelectEmpresasInternas empresa in Empresas)
            {
                this.EmpresasCheckList.Items.Add(empresa);                
            } // end for
        } // end BindEmpresasCheckList

        /// <summary>
        /// Liga los datos de las estaciones al control
        /// </summary>
        private void BindEstacionesCheckList()
        {
            this.EstacionesCheckList.Items.Clear();

            foreach (Entities.Estaciones estacion in Estaciones)
            {
                if (estacion.Activo == true)
                {
                    this.EstacionesCheckList.Items.Add(estacion);
                }                
            } // end for
        } // end BindEmpresasCheckList

        private void AltaUsuario_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Valida los controles de la forma
        /// </summary>
        private void DoValidate()
        {
            if (EmpresasCheckList.CheckedItems.Count == 0)
            {
                throw new Exception("Debe seleccionar el menos una empresa");
            }

            if (EstacionesCheckList.CheckedItems.Count == 0)
            {
                throw new Exception("Debe seleccionar el menos una estacion");
            }

            if (this.apellidosTextBox.Text == string.Empty)
            {
                throw new Exception("Debe capturar el apellido");
            }

            if (this.nombreTextBox.Text == string.Empty)
            {
                throw new Exception("Debe capturar el nombre");
            }

            if (this.emailTextBox.Text == string.Empty)
            {
                throw new Exception("Debe capturar el email");
            }

            if (this.pwdTextBox.Text == string.Empty)
            {
                throw new Exception("Debe capturar el password");
            }

            if (this.usuario_IDTextBox.Text == string.Empty)
            {
                throw new Exception("Debe capturar el ID de usuario");
            }            
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            ////  Valida la forma          
            DoValidate();

            //  Realizar la inserción del registro
            SICASCentralQuerysIIDataSetTableAdapters.Functions fns =
                new SICASCentralQuerysIIDataSetTableAdapters.Functions();

            

            //  Ingresamos el usuario
            fns.InsertUsuario(this.usuario_IDTextBox.Text,
                this.nombreTextBox.Text, this.apellidosTextBox.Text,
                    this.emailTextBox.Text, true,
                        this.pwdTextBox.Text, null, null);

            //  Ingresamos los permisos del usuario
            //  Con respecto a las empresas
            foreach (object obj in EmpresasCheckList.CheckedItems)
            {
                Entities.SelectEmpresasInternas empresa =
                    (Entities.SelectEmpresasInternas)obj;

                Entities.Usuarios_Empresas usuario_empresa = new Entities.Usuarios_Empresas();
                usuario_empresa.Empresa_ID = empresa.Empresa_ID.Value;
                usuario_empresa.Usuario_ID = this.usuario_IDTextBox.Text;
                usuario_empresa.Create();
            }

            //  Ingresamos los permisos del usuario
            //  Con respecto a las estaciones
            foreach (object obj in this.EstacionesCheckList.CheckedItems)
            {
                Entities.Estaciones estacion =
                    (Entities.Estaciones)obj;

                Entities.Usuarios_Estaciones usuario_estacion = new Entities.Usuarios_Estaciones();
                usuario_estacion.Estacion_ID = estacion.Estacion_ID;
                usuario_estacion.Usuario_ID = this.usuario_IDTextBox.Text;
                usuario_estacion.Create();
            }

            //  Enviar el correo
            AppHelper.SendNewAccountMail(this.emailTextBox.Text,
                nombreTextBox.Text + " " + apellidosTextBox.Text,
                    usuario_IDTextBox.Text, pwdTextBox.Text);

            //  Mostrar mensaje
            AppHelper.Info("Usuario creado!");

            //  Navegar a usuarios
            this.Padre.SwitchForma("Usuarios");
        }
        
        //  Evento clic en boton de guardar
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(
                delegate {
                    DoSave();
                },
                this
            );
        }

        /// <summary>
        /// Al hacer clic en "Seleccionar todas" en el grupo de empresas
        /// selecciona todas las empresas disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresasLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int item = 0; item < this.EmpresasCheckList.Items.Count; item++)
            {
                EmpresasCheckList.SetItemChecked(item, true);
            }
        }

        /// <summary>
        /// Al hacer clic en "Seleccionar todas" en el grupo de estaciones
        /// selecciona todas las estaciones disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstacionesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int item = 0; item < this.EstacionesCheckList.Items.Count; item++)
            {
                EstacionesCheckList.SetItemChecked(item, true);
            }
        }
    }   //  End Class
}   //  End Namespace
