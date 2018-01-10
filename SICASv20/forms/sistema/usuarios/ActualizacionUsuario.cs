/*
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 * 
 * Cambio de paradigma:
 * Multiempresas, multiestación
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SICASv20.forms
{
    public partial class ActualizacionUsuario : baseForm
    {
        public ActualizacionUsuario()
        {
            InitializeComponent();
        }


        private string _Usuario_ID;
        /// <summary>
        /// El ID de usuario a modificar
        /// </summary>
        public string Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        /// <summary>
        /// El listado de empresas
        /// </summary>
        private List<Entities.Vista_Usuarios_Empresas> Empresas { get; set; }

        /// <summary>
        /// El listado de estaciones
        /// </summary>
        private List<Entities.Vista_Usuarios_Estaciones> Estaciones { get; set; }

        public override void BindData()
        {   
            //  Comboboxes
            this.get_SelectEstacionesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_SelectEstaciones);            
            this.get_SelectEmpresasTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_SelectEmpresas);

            //  BindingSource de tabla principal de la forma
            this.usuariosTableAdapter.Fill(this.sICASCentralDataSet.Usuarios, this.Usuario_ID);

            //  Obtenemos las empresas y los permisos del usuario
            this.Empresas = Entities.Vista_Usuarios_Empresas.Get(this.Usuario_ID);

            //  Obtenemos las estaciones y los permisos del usuario
            this.Estaciones = Entities.Vista_Usuarios_Estaciones.Get(this.Usuario_ID);

            //  Cargar los datos
            PopulateControls();

            base.BindData();
        }

        private void PopulateControls()
        {
            PopulatePermissions();
            BindEmpresasCheckList();
            BindEstacionesCheckList();
        }

        /// <summary>
        /// Liga los datos de las empresas al control
        /// </summary>
        private void BindEmpresasCheckList()
        {
            this.EmpresasCheckList.Items.Clear();

            foreach (Entities.Vista_Usuarios_Empresas empresa in Empresas)
            {
                this.EmpresasCheckList.Items.Add(
                    empresa, 
                    empresa.EsPermitido.Value
                );
            } // end for
        } // end BindEmpresasCheckList

        /// <summary>
        /// Liga los datos de las estaciones al control
        /// </summary>
        private void BindEstacionesCheckList()
        {
            this.EstacionesCheckList.Items.Clear();

            foreach (Entities.Vista_Usuarios_Estaciones estacion in Estaciones)
            {
                this.EstacionesCheckList.Items.Add(
                    estacion,
                    estacion.EsPermitido.Value
                );
            } // end for
        } // end BindEmpresasCheckList        

        private void DoSave()
        {
            //  Actualizar el dataset
            //this.Validate();
            //this.usuariosBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
            Entities.Usuarios usuario = Entities.Usuarios.Read(this.usuario_IDTextBox.Text);
            usuario.Activo = activoCheckBox.Checked;
            usuario.Apellidos = apellidosTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.Empresa_ID = null;
            usuario.Estacion_ID = null;
            usuario.Nombre = nombreTextBox.Text;

            // if usuario.activo = 0
            // usuario.password = NewID()

            usuario.Update();

            //  Guardar los permisos
            SavePermissions();

            //if (Sesion.Usuario_ID == this.Usuario_ID)
            //{
            //    ((SICASForm)this.Padre).SetMenuOptions();
            //}

            AppHelper.Info("Usuario actualizado!");

            this.Padre.SwitchForma("Usuarios");
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);            
        }

        private DataTable OpcionesDeUsuarioMenu(string usuario_id, int menu_id)
        {
            string sql = @"SELECT	O.*, ISNULL(PU.EsPermitido,0) EsPermitido
                            FROM	Opciones O
                            LEFT JOIN	PermisosUsuarios PU
                            ON		(O.Opcion_ID = PU.Opcion_ID
                            AND		PU.Usuario_ID = @Usuario_ID)
                            WHERE	O.Menu_ID = @Menu_ID";

            return DB.QueryCommand(
                sql,
                DB.GetParams(
                    DB.Param("@Usuario_ID", usuario_id),
                    DB.Param("@Menu_ID", menu_id)
                    )
                );
        }

        /// <summary>
        /// Llena el árbol de permisos
        /// </summary>
        private void PopulatePermissions()
        {            
            //  Declaración de variables
            DataTable dtModulos, dtMenues, dtOpciones;
            
            SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter getModulosTA =
                new SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter();

            SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter getMenuesTA =
                new SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter();

            //  Consultar los modulos
            dtModulos = (DataTable)getModulosTA.GetData();

            //  Para cada modulo
            foreach (DataRow modrow in dtModulos.Rows)
            {
                //  Obtener los datos del "row"
                int modulo_id = Convert.ToInt32(modrow["Modulo_ID"]);
                string modulo_nombre = Convert.ToString(modrow["Nombre"]);

                //  Crear un nodo
                TreeNode modnode = new TreeNode();

                //  Asignarle las propiedades
                modnode.Text = modulo_nombre;
                modnode.Tag = modulo_id;

                //  Consultar los menues
                dtMenues = (DataTable)getMenuesTA.GetData(modulo_id);

                //  Para cada menu
                foreach (DataRow mnurow in dtMenues.Rows)
                {
                    //  Obtener los datos del row
                    int menu_id = Convert.ToInt32(mnurow["Menu_ID"]);
                    string menu_nombre = Convert.ToString(mnurow["Nombre"]);

                    //  Crear un nodo
                    TreeNode mnunode = new TreeNode();

                    //  Asignarle las propiedades            
                    mnunode.Text = menu_nombre;
                    mnunode.Tag = menu_id;
                   
                    //  Consultar las opciones                    
                    dtOpciones = this.OpcionesDeUsuarioMenu(this.Usuario_ID, menu_id);

                    //  Para cada opcion
                    foreach (DataRow oprow in dtOpciones.Rows)
                    {
                        //  Obtener los datos del "row"
                        int opcion_id = Convert.ToInt32(oprow["Opcion_ID"]);
                        string opcion_texto = Convert.ToString(oprow["Texto"]);

                        //  Crear un nodo
                        TreeNode opnode = new TreeNode();                        

                        //  Asignarle las propiedades
                        opnode.Text = opcion_texto;
                        opnode.Tag = opcion_id;
                        opnode.Name = opcion_id.ToString();
                        opnode.Checked = Convert.ToBoolean(oprow["EsPermitido"]);
                        
                        //  Agregar al nodo de menu
                        mnunode.Nodes.Add(opnode);
                    }                    
                    
                    //  Agregar el nodo menu al de modulo
                    modnode.Nodes.Add(mnunode);                                        
                }

                //  Agregar el nodo modulo al arbol                
                PermisosTreeView.Nodes.Add(modnode);
            }
            
            //  Si un node se configura a "check", lo mismo para con todos sus nodos
            //  y el mismo comportamiento para "unchek"

            PermisosTreeView.ExpandAll();           
        }

        private string PrepareStatement(string usuario_id, int opcion_id, bool EsPermitido)
        {
            string sql;
            sql = @"IF EXISTS(SELECT * FROM PermisosUsuarios WHERE Opcion_ID = @Opcion_ID AND Usuario_ID = @Usuario_ID)
            BEGIN
                UPDATE  PermisosUsuarios SET EsPermitido = @EsPermitido
                WHERE   Usuario_ID = @Usuario_ID
                AND     Opcion_ID = @Opcion_ID
            END
            ELSE
            BEGIN
                INSERT INTO PermisosUsuarios VALUES (@Usuario_ID, @Opcion_ID, @EsPermitido)
            END
            ";

            int _EsPermitido = (EsPermitido) ? 1 : 0;

            string result = sql.Replace(
                            "@Usuario_ID", 
                            "'" + usuario_id + "'"
                        );
            
            result = result.Replace(
                            "@Opcion_ID", 
                            opcion_id.ToString()
                        );

            result = result.Replace(
                            "@EsPermitido", 
                            _EsPermitido.ToString()
                        );

            return result;
        }

        /// <summary>
        /// Actualiza los permisos de las empresas
        /// y las estaciones para el usuario
        /// </summary>
        private void SavePermissions_Empresas_Estaciones()
        {
            //  Preparamos el parametro
            Hashtable m_params = new Hashtable();
            m_params.Add("Usuario_ID", this.Usuario_ID);

            //  Borramos los permisos de empresas
            DB.DeleteRow("Usuarios_Empresas", m_params);

            //  Borramos los permisos de estaciones
            DB.DeleteRow("Usuarios_Estaciones", m_params);

            //  Ingresamos los permisos del usuario
            //  Con respecto a las empresas
            foreach (object obj in EmpresasCheckList.CheckedItems)
            {
                Entities.Vista_Usuarios_Empresas empresa =
                    (Entities.Vista_Usuarios_Empresas)obj;

                Entities.Usuarios_Empresas usuario_empresa = new Entities.Usuarios_Empresas();
                usuario_empresa.Empresa_ID = empresa.Empresa_ID.Value;
                usuario_empresa.Usuario_ID = this.usuario_IDTextBox.Text;
                usuario_empresa.Create();
            }

            //  Ingresamos los permisos del usuario
            //  Con respecto a las estaciones
            foreach (object obj in this.EstacionesCheckList.CheckedItems)
            {
                Entities.Vista_Usuarios_Estaciones estacion =
                    (Entities.Vista_Usuarios_Estaciones)obj;

                Entities.Usuarios_Estaciones usuario_estacion = new Entities.Usuarios_Estaciones();
                usuario_estacion.Estacion_ID = estacion.Estacion_ID.Value;
                usuario_estacion.Usuario_ID = this.usuario_IDTextBox.Text;
                usuario_estacion.Create();
            } // end foreach

        } // end SavePermissions_Empresas_Estaciones

        /// <summary>
        /// Actualiza a la base de datos los permisos
        /// a partir de las configuraciones de árbol
        /// </summary>
        private void SavePermissions()
        {
            //  Guaramos los permisos de las empresas y las estaciones
            SavePermissions_Empresas_Estaciones();

            string sqlStatements = "";

            foreach (TreeNode modnode in PermisosTreeView.Nodes)
            {
                foreach (TreeNode mnunode in modnode.Nodes)
                {
                    foreach (TreeNode opnode in mnunode.Nodes)
                    {                    
                        sqlStatements += PrepareStatement(this.Usuario_ID,
                            Convert.ToInt32(opnode.Tag),
                                Convert.ToBoolean(opnode.Checked));                        
                    }
                }
            }

            DB.ExecuteQuery(sqlStatements);
            
        }

        private void CheckAllNodes(TreeNode node)
        {
            node.Checked = true;
            foreach (TreeNode childnode in node.Nodes)
            {
                CheckAllNodes(childnode);
            }
        }

        private void UnCheckAllNodes(TreeNode node)
        {
            node.Checked = false;
            foreach (TreeNode childnode in node.Nodes)
            {
                UnCheckAllNodes(childnode);
            }
        }

        private void SelectAll()
        {
            foreach (TreeNode node in PermisosTreeView.Nodes)
            {
                CheckAllNodes(node);
            }
        }

        private void UnSelectAll()
        {
            foreach (TreeNode node in PermisosTreeView.Nodes)
            {
                UnCheckAllNodes(node);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectNoneButton_Click(object sender, EventArgs e)
        {
            UnSelectAll();
        }

        private void CambioPwdButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.Usuarios usuario = Entities.Usuarios.Read(this.Usuario_ID);
                forms.CambioContraseña cambio = new forms.CambioContraseña();
                cambio.Set_Usuario(usuario);
                Padre.SwitchForma("CambioContraseña", cambio);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private PermisosDeGrupoForm PermisosGrupoForm;

        private void PermisosDeGrupoButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    if (PermisosGrupoForm == null) PermisosGrupoForm = new PermisosDeGrupoForm();
                    if (PermisosGrupoForm.IsDisposed) PermisosGrupoForm = new PermisosDeGrupoForm();
                    
                    if (PermisosGrupoForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DialogResult result = AppHelper.Confirm("¿Desea sustituir los permisos actuales por los permisos del grupo?");
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            UnSelectAll();

                            List<Entities.Vista_PermisosGruposUsuarios> permisos =
                                Entities.Vista_PermisosGruposUsuarios.Get(PermisosGrupoForm.GrupoUsuario.GrupoUsuario_ID);

                            foreach (Entities.Vista_PermisosGruposUsuarios permiso in permisos)
                            {
                                PermisosTreeView.Nodes.Find(permiso.Opcion_ID.ToString(), true)[0].Checked = permiso.EsPermitido.Value;
                            }

                            //permisos.Find(delegate(Entities.Vista_PermisosGruposUsuarios p) { return p.Opcion_ID == 1; });
                        }
                        else if (result == System.Windows.Forms.DialogResult.No)
                        {
                            List<Entities.Vista_PermisosGruposUsuarios> permisos =
                                Entities.Vista_PermisosGruposUsuarios.Get(PermisosGrupoForm.GrupoUsuario.GrupoUsuario_ID);

                            foreach (Entities.Vista_PermisosGruposUsuarios permiso in permisos)
                            {
                                PermisosTreeView.Nodes.Find(permiso.Opcion_ID.ToString(), true)[0].Checked = permiso.EsPermitido.Value;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                },
                this
            );
        }

        private void PerisosCajaButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    forms.PermisosCajasUsuarios pcu = new PermisosCajasUsuarios();
                    pcu.Usuario_ID = this.Usuario_ID;
                    Padre.SwitchForma("PermisosCajasUsuarios", pcu);
                }
            );
        } // end void

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
    } // end class
} // end namespace
