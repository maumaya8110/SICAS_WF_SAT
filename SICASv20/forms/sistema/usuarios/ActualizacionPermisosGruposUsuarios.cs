using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ActualizacionPermisosGruposUsuarios : baseForm
    {
        public ActualizacionPermisosGruposUsuarios()
        {
            InitializeComponent();
        }

        class ActualizacionPermisosGruposUsuarios_Model
        {
            private List<Entities.Vista_PermisosGruposUsuarios> _Permisos;
            public List<Entities.Vista_PermisosGruposUsuarios> Permisos
            {
                get { return _Permisos; }
                set { _Permisos = value; }
            }

            private DataTable _PermisosTable;

            private int _GrupoUsuario_ID;
            public int GrupoUsuario_ID
            {
                get { return _GrupoUsuario_ID; }
                set { _GrupoUsuario_ID = value; }
            }

            private Entities.GruposUsuarios _GrupoUsuario;
            public Entities.GruposUsuarios GrupoUsuario
            {
                get { return _GrupoUsuario; }
                set { _GrupoUsuario = value; }
            }

            private int _Modulo_ID;
            public int Modulo_ID
            {
                get { return _Modulo_ID; }
                set { _Modulo_ID = value; }
            }

            private int _Menu_ID;
            public int Menu_ID
            {
                get { return _Menu_ID; }
                set { _Menu_ID = value; }
            }

            public void ConsultarPermisos()
            {
                this._PermisosTable = Entities.Vista_PermisosGruposUsuarios.GetDataTable(this.GrupoUsuario_ID);
            }

            public void ConsultarGrupoUsuario()
            {
                this.GrupoUsuario = Entities.GruposUsuarios.Read(this.GrupoUsuario_ID);
            }

            public void ConsultarModulos()
            {
                this.Modulos = new List<Entities.Modulos>();

                DataTable distinctDataTable = 
                    _PermisosTable.DefaultView.ToTable(
                        true, 
                        "Modulo_ID", 
                        "Modulo"
                    );

                foreach(DataRow dr in distinctDataTable.Rows)
                {
                    this.Modulos.Add(
                        new Entities.Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Modulo"]))
                    );
                }
            }

            public void ConsultarMenues()
            {
                this.Menues = new List<Entities.Menues>();

                DataRow[] drMenues = 
                    _PermisosTable.DefaultView.ToTable(
                        true,
                        "Modulo_ID",
                        "Menu_ID",
                        "Menu").Select(
                            string.Format(
                                "Modulo_ID = {0}", 
                                this.Modulo_ID
                            )
                        );                

                foreach (DataRow dr in drMenues)
                {
                    this.Menues.Add(
                        new Entities.Menues(
                            Convert.ToInt32(dr["Menu_ID"]), 
                            this.Modulo_ID, 
                            Convert.ToString(dr["Menu"]), 
                            ""
                        )
                    );
                }
            }

            public void ConsultarPermisosOpciones()
            {
                this.Permisos = new List<Entities.Vista_PermisosGruposUsuarios>();

                DataRow[] drPermisos = 
                    _PermisosTable.Select(
                        string.Format(
                            "Menu_ID = {0}", 
                            this.Menu_ID
                        )
                    );

                foreach (DataRow dr in drPermisos)
                {
                    this.Permisos.Add(
                        new Entities.Vista_PermisosGruposUsuarios(
                            DB.GetNullableInt32(dr["Modulo_ID"]),
                            Convert.ToString(dr["Modulo"]),
                            DB.GetNullableInt32(dr["Menu_ID"]),
                            Convert.ToString(dr["Menu"]),
                            DB.GetNullableInt32(dr["Opcion_ID"]),
                            Convert.ToString(dr["Opcion"]),
                            DB.GetNullableInt32(dr["GrupoUsuario_ID"]),
                            Convert.ToString(dr["GrupoUsuario"]),
                            DB.GetNullableBoolean(dr["EsPermitido"])
                        )
                    );
                }
            }

            private List<Entities.Modulos> _Modulos;
            public List<Entities.Modulos> Modulos
            {
                get { return _Modulos; }
                set { _Modulos = value; }
            }

            private List<Entities.Menues> _Menues;
            public List<Entities.Menues> Menues
            {
                get { return _Menues; }
                set { _Menues = value; }
            }

            public void Guardar()
            {
                this.SavePermissions();
            }

            private TreeNodeCollection _Nodos;
            public TreeNodeCollection Nodos
            {
                get { return _Nodos; }
                set { _Nodos = value; }
            }

            private string PrepareStatement(int grupousuario_id, int opcion_id, bool EsPermitido)
            {
                string sql;
                sql = @"IF EXISTS(SELECT * FROM PermisosGruposUsuarios WHERE Opcion_ID = @Opcion_ID AND GrupoUsuario_ID = @GrupoUsuario_ID)
            BEGIN
                UPDATE  PermisosGruposUsuarios SET EsPermitido = @EsPermitido
                WHERE   GrupoUsuario_ID = @GrupoUsuario_ID
                AND     Opcion_ID = @Opcion_ID
            END
            ELSE
            BEGIN
                INSERT INTO PermisosGruposUsuarios VALUES (@GrupoUsuario_ID, @Opcion_ID, @EsPermitido)
            END
            ";

                int _EsPermitido = (EsPermitido) ? 1 : 0;

                string result = sql.Replace(
                                "@GrupoUsuario_ID",
                                "'" + grupousuario_id + "'"
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
            /// Actualiza a la base de datos los permisos
            /// a partir de las configuraciones de árbol
            /// </summary>
            private void SavePermissions()
            {                
                string sqlStatements = "";

                foreach (TreeNode modnode in this.Nodos)
                {
                    foreach (TreeNode mnunode in modnode.Nodes)
                    {
                        foreach (TreeNode opnode in mnunode.Nodes)
                        {
                            sqlStatements += PrepareStatement(this.GrupoUsuario_ID,
                                Convert.ToInt32(opnode.Tag),
                                    Convert.ToBoolean(opnode.Checked));
                        }
                    }
                }

                DB.ExecuteQuery(sqlStatements);
            }
        }

        #region Properties
        private ActualizacionPermisosGruposUsuarios_Model Model;
        private int _GrupoUsuario_ID;
        public int GrupoUsuario_ID
        {
            get { return _GrupoUsuario_ID; }
            set { _GrupoUsuario_ID = value; }
        }
        #endregion

        #region Events

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

        public override void BindData()
        {
            this.Model = new ActualizacionPermisosGruposUsuarios_Model();
            this.Model.GrupoUsuario_ID = this.GrupoUsuario_ID;            
            this.Model.ConsultarGrupoUsuario();
            this.Model.ConsultarPermisos();
            this.Model.ConsultarModulos();
            this.NombreGrupoUsuarioTextBox.Text = this.Model.GrupoUsuario.Nombre;
            this.PopulatePermissions();
            base.BindData();
        }

        private void PopulatePermissions()
        {
            this.Model.ConsultarModulos();

            foreach (Entities.Modulos modulo in this.Model.Modulos)
            {
                TreeNode modNode = new TreeNode();
                modNode.Text = modulo.Nombre;
                modNode.Tag = modulo.Modulo_ID;

                this.Model.Modulo_ID = modulo.Modulo_ID;
                this.Model.ConsultarMenues();

                foreach (Entities.Menues menu in this.Model.Menues)
                {
                    TreeNode menuNode = new TreeNode();
                    menuNode.Text = menu.Nombre;
                    menuNode.Tag = menu.Menu_ID;
                    this.Model.Menu_ID = menu.Menu_ID;
                    this.Model.ConsultarPermisosOpciones();

                    foreach (Entities.Vista_PermisosGruposUsuarios permiso in this.Model.Permisos)
                    {
                        TreeNode permisoNode = new TreeNode();
                        permisoNode.Tag = permiso.Opcion_ID;
                        permisoNode.Text = permiso.Opcion;
                        permisoNode.Checked = permiso.EsPermitido.Value;

                        menuNode.Nodes.Add(permisoNode);
                    }

                    modNode.Nodes.Add(menuNode);
                }

                PermisosTreeView.Nodes.Add(modNode);
            }

            PermisosTreeView.ExpandAll();
        }
        #endregion

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectNoneButton_Click(object sender, EventArgs e)
        {
            UnSelectAll();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Nodos = this.PermisosTreeView.Nodes;
                    this.Model.Guardar();
                    AppHelper.Info("Información guardada!");
                },
                this
            );
        }

    }
}
