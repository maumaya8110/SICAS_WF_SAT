/*
 * LicenciasPorVencer
 * Muestra las licencias por vencer
 * 
 * **  HISTORIAL  **
 *      2012-10-27, Creado por Luis Espino
 *      
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
    /// <summary>
    /// Muestra las licencias por vencer
    /// </summary>
    public partial class LicenciasPorVencer : Form
    {
        #region Model

        /// <summary>
        /// Modelo para las licencias por vencer
        /// </summary>
        class LicenciasPorVencer_Model
        {

            #region Constructors

            /// <summary>
            /// Crea una instacia de la clase
            /// </summary>
            public LicenciasPorVencer_Model()
            {
                //  TODO
            }

            #endregion


            #region Properties

            /// <summary>
            /// El listado de licencias
            /// </summary>
            public List<Entities.Vista_LicenciasPorVencer> LicenciasPorVencer { get; set; }

            /// <summary>
            /// La estación sobre la cual se consulta la información
            /// </summary>
            public int Estacion_ID { get; set; }

            #endregion


            #region Methods

            public void Consultar()
            {
                this.LicenciasPorVencer =
                    Entities.Vista_LicenciasPorVencer.Get(this.Estacion_ID);
            }

            #endregion				
				
        }

        #endregion

        #region Constructors

        #region Properties

        /// <summary>
        /// El modelo de la forma
        /// </summary>
        private LicenciasPorVencer_Model Model;

        #endregion

        /// <summary>
        /// Muestra las licencias por vencer
        /// </summary>
        public LicenciasPorVencer()
        {
            InitializeComponent();

            //  Le aplicamos estilo
            AppHelper.SetStylish(this);

            //  Instanciamos el modelo
            this.Model = new LicenciasPorVencer_Model();
        }

        #endregion

        #region Events

        /// <summary>
        /// Consulta la información y valida los permisos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicenciasPorVencer_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (Sesion.Estacion_ID == null)
                    {
                        throw new Exception("Debe tener permisos de una sola estación para solicitar esta información");
                    } // end if

                    this.Model.Estacion_ID = Sesion.Estacion_ID.Value;
                    this.Model.Consultar();
                    this.vista_LicenciasPorVencerBindingSource.DataSource = this.Model.LicenciasPorVencer;

                } // end delegate

            ); // end try

        }

        /// <summary>
        /// Colorea los renglones según su fecha de vencimiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vista_LicenciasPorVencerDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    int cellindex = 0;
                    bool propExiste = false;
                    string datapropertyname = "VenceLicencia";
                    object val = null;

                    //  Buscarmos la columna con el DataPropertyName referido
                    foreach (DataGridViewColumn col in vista_LicenciasPorVencerDataGridView.Columns)
                    {
                        if (col.DataPropertyName == datapropertyname)
                        {
                            //  Existe
                            //  Obtenemos el índice
                            cellindex = col.Index;
                            //  Pasamos "true" a la variable "propExiste"
                            propExiste = true;
                            //  Salimos del ciclo
                            break;
                        }
                    }

                    //  Si existe el DataPropertName en la lista de columnas
                    if (propExiste)
                    {
                        //  Recorremos la colección de "DataGridViewRows"
                        foreach (DataGridViewRow row in vista_LicenciasPorVencerDataGridView.Rows)
                        {
                            //  Obtenermos el valor de la celda
                            //  lo guardamos en la variable "val"
                            val = row.Cells[cellindex].Value;

                            //  Si tiene valor
                            if (val != null)
                            {
                                //  Si ya esta vencida
                                if (((DateTime)val).Date < DateTime.Now.Date)
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 102);
                                } // end if

                                //  Si vence dentro de los próximos seis meses
                                if ((((DateTime)val).Date >= DateTime.Now.Date) &&
                                    (((DateTime)val).Date < DateTime.Now.Date.AddMonths(6)))
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 219, 112);
                                } // end if

                            } // end if val not null

                        } // end foreach

                    } // end if propExiste

                } // end delegate

            ); // end Try

        } // end BindingComplete

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end event Load

        #endregion Events

    } // end class

} // end namespace
