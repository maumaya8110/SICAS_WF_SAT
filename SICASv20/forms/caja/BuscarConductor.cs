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
    /// Formulario para buscar un conductor
    /// </summary>
    public partial class BuscarConductor : Form
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para
        /// buscar conductores
        /// </summary>
        public BuscarConductor()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
            Clear();
        }

        /// <summary>
        /// Clase que representa el modelo de lógica de negocios
        /// para la búsqueda de conductores
        /// </summary>
        class Model
        {
            /// <summary>
            /// Crea una nueva instancia del modelo de lógica de negocios
            /// de búsqueda de conductores
            /// </summary>
            public Model()
            {
                this.Conductores = new List<Entities.Conductores>();
            }

            /// <summary>
            /// El nombre del conductor a buscar
            /// </summary>
            public string NombreConductor
            {
                get { return _NombreConductor; }
                set { _NombreConductor = value; }
            }
            private string _NombreConductor;

            /// <summary>
            /// El listado de conductores relevantes a la busqueda
            /// </summary>
            public List<Entities.Conductores> Conductores
            {
                get { return _Conductores; }
                set { _Conductores = value; }
            }
            private List<Entities.Conductores> _Conductores;

            /// <summary>
            /// Busca los conductores en la base de datos
            /// </summary>
            public void ConsultarConductores()
            {
                this.Conductores =
                     Entities.Conductores.Read(
                         @"Apellidos + ' ' + Nombre LIKE @Nombre + '%'",
                         null,
                         DB.Param("@Nombre", this.NombreConductor)
                     );
//          QUERY DE A CONDUCTORES AMARRADOS A LA ESTACION.
//                this.Conductores =
//                    Entities.Conductores.Read(
//                        @"Apellidos + ' ' + Nombre LIKE @Nombre + '%'
//                        AND ( @Estacion_ID IS NULL OR Estacion_ID = @Estacion_ID )",
//                        null,
//                        DB.Param("@Nombre", this.NombreConductor),
//                        DB.Param("@Estacion_ID", Sesion.Estacion_ID)
//                    );
            }
        }

        /// <summary>
        /// El ID del conductor encontrado
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }
        private int _Conductor_ID;

        /// <summary>
        /// El modelo de negocios a utilizar en la forma
        /// </summary>
        private Model model;

        /// <summary>
        /// Limpia la forma y reinicializa las variables
        /// </summary>
        public void Clear()
        {
            model = new Model();
            conductoresBindingSource.DataSource = null;            
            AppHelper.ClearControl(this);
            this.NombreTextBox.Focus();
        }

        /// <summary>
        /// Al hacer clic en el contenido de una celda,
        /// si la columna es "Seleccionar",
        /// el conductor se selecciona y se cierra la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConductoresGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(delegate 
            {
                if (ConductoresGridView.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    Entities.Conductores conductor = (Entities.Conductores)ConductoresGridView.Rows[e.RowIndex].DataBoundItem;
                    this.Conductor_ID = conductor.Conductor_ID;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Clear();
                    this.Close();
                }
            });
        }

        /// <summary>
        /// Si se teclea "Enter" en la caja de texto "Nombre"
        /// se busca al conductor por su nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NombreTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(delegate
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(NombreTextBox.Text))
                    {
                        model.NombreConductor = NombreTextBox.Text;
                        model.Conductores = null;
                    }
                    else
                    {
                        model.NombreConductor = NombreTextBox.Text;
                        model.ConsultarConductores();
                    }

                    conductoresBindingSource.DataSource = model.Conductores;
                    conductoresBindingSource.ResetBindings(false);
                }
            });
        }

        /// <summary>
        /// Al completarse el llenado de datos de conductores,
        /// colorea los renglones, dependiendo del estatus del conductor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConductoresGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.ColorDataGridViewRows(
                        ref this.ConductoresGridView, 
                        "EstatusConductor_ID", 
                        AppHelper.RelacionValoresColores
                    );
                }
            );
        }

    } // end class

} // end namespace
