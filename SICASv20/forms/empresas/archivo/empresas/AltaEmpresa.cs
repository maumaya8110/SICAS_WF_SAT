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
    /// Formulario para el alta de una empresa
    /// </summary>
    public partial class AltaEmpresa : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia para el formulario de alta de empresa
        /// </summary>
        public AltaEmpresa()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private AltaEmpresa_Model Model;

        #endregion

        #region Model

        /// <summary>
        /// Modela la lógica de negocios para el alte de empresas
        /// </summary>
        class AltaEmpresa_Model
        {
            /// <summary>
            /// La entidad empresa que se dará de alta en el sistema
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
                //  Activa la empresa por defecto
                Empresa.Activo = true;
                Empresa.Empresa_ID = 0;
                Empresa.Create();
            }

            /// <summary>
            /// Los tipos de empresas disponibles
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

            /// <summary>
            /// Consulta los datos de tipos de empresas y mercados
            /// </summary>
            public void Consultar()
            {
                this.TiposEmpresas = Entities.TiposEmpresas.Read();
                this.Mercados = Entities.SelectMercados.Get();
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controle
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new AltaEmpresa_Model();

            //  Consultamos los datos
            this.Model.Consultar();

            //  Ligamos los datos de tipos de empresas y mercados
            //  del modelo a los controles
            this.tiposEmpresasBindingSource.DataSource = this.Model.TiposEmpresas;
            this.selectMercadosBindingSource.DataSource = this.Model.Mercados;
            
            //  Aplicamos validaciones
            AppHelper.SetContainerDBValidations(this, "Empresas");
            
            //  Preparamos nuevo registro
            empresasBindingSource.AddNew();

            base.BindData();
        }
        
        /// <summary>
        /// Guarda la empresa en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Obtenemos la empresa y la asignamos al modelo
                    Model.Empresa = (Entities.Empresas)empresasBindingSource.Current;

                    //  Guardamos la información
                    Model.Guardar();

                    //  Preparamos una nuev inserción
                    empresasBindingSource.AddNew();

                    //  Limpiamos la forma
                    AppHelper.ClearControl(this);

                    //  Informamos al usuario
                    AppHelper.Info("Empresa creada");
                },
                this
            );
        }
        #endregion

    } // end clas

} // end namespace
