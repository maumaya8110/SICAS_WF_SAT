using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para la actualización de empresas
    /// </summary>
    public partial class ActualizacionEmpresa : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para la actualización de empresas
        /// </summary>
        public ActualizacionEmpresa()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ActualizacionEmpresa_Model Model;

        /// <summary>
        /// El folio de la empresa a actualizar
        /// </summary>
        public int Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }
        private int _Empresa_ID;

        #endregion

        #region Model

        /// <summary>
        /// Modela la lógica de negocios para las actualizaciones de empresas
        /// </summary>
        class ActualizacionEmpresa_Model
        {
            /// <summary>
            /// La empresa a actualizar
            /// </summary>
            public Entities.Empresas Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }
            private Entities.Empresas _Empresa;

            /// <summary>
            /// Guarda los cambios en la base de datos
            /// </summary>
            public void Guardar()
            {
                this.Empresa.Update();
            }

            /// <summary>
            /// Consula a la empresa en la base de datos
            /// </summary>
            /// <param name="empresa_id">El folio de la empresa</param>
            public void Consultar(int empresa_id)
            {
                this.Empresa = Entities.Empresas.Read(empresa_id);
                this.TiposEmpresas = Entities.TiposEmpresas.Read();
                this.Mercados = Entities.SelectMercados.Get();
            }

            /// <summary>
            /// Los diferentes tipos de empresas disponibles
            /// </summary>
            public List<Entities.TiposEmpresas> TiposEmpresas
            {
                get { return _TiposEmpresas; }
                set { _TiposEmpresas = value; }
            }
            private List<Entities.TiposEmpresas> _TiposEmpresas;

            /// <summary>
            /// Los mercados disponibles para las empresas
            /// </summary>
            public List<Entities.SelectMercados> Mercados
            {
                get { return _Mercados; }
                set { _Mercados = value; }
            }
            private List<Entities.SelectMercados> _Mercados;
        }

        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ActualizacionEmpresa_Model();

            //  Consulta los datos
            this.Model.Consultar(this.Empresa_ID);

            //  Ligamos los datos del modelo a los controles
            this.tiposEmpresasBindingSource.DataSource = this.Model.TiposEmpresas;
            this.selectMercadosBindingSource.DataSource = this.Model.Mercados;
            this.empresasBindingSource.DataSource = this.Model.Empresa;
            base.BindData();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Obtenemos la empresa
                    //  la configuramos al modelo
                    Model.Empresa = (Entities.Empresas)empresasBindingSource.Current;

                    //  Guardamos los cambios
                    Model.Guardar();

                    //  Mensaje de éxito
                    AppHelper.Info("Empresa actualizada");

                    //  Navegamos a empresas
                    this.Padre.SwitchForma("Empresas");
                },
                this
            );
        }
        #endregion
    } // end class

} // end namespace
