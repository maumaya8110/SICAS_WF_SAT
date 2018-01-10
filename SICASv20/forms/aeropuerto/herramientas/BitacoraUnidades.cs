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
    /// Muestra las unidades en la cola de bitácora de unidades y
    /// permite enviarlas a carrera, así como ingresarlas a la cola
    /// </summary>
    public partial class BitacoraUnidades : Form
    {
        public BitacoraUnidades()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        /// <summary>
        /// Los datos de la unidad
        /// </summary>
        Entities.DatosConductorUnidad datosUnidad;

        /// <summary>
        /// Obtiene los datos del conductor y la unidad
        /// a partir del número económico
        /// </summary>
        private void GetDatosConductorUnidad()
        {
            //  Realiza las validaciones

            //  Que se haya capturado información
            if (string.IsNullOrEmpty(this.NumeroEconomicoTextBox.Text))
            {
                throw new Exception("Debe capturar una unidad");
            }

            //  Que el número economico sea numérico
            if (!AppHelper.IsNumeric(this.NumeroEconomicoTextBox.Text))
            {
                throw new Exception("El número económico debe ser numérico");
            }

            //  Que el usuario tenga asignada una sola estación
            if (Sesion.Estacion_ID == null)
            {
                throw new Exception("Se debe tener asignada una estación para utilizar esta opción");
            }

            //  Obtenemos los datos de la unidad
            datosUnidad = Entities.DatosConductorUnidad.GetUnidad_ID(Convert.ToInt32(NumeroEconomicoTextBox.Text), Sesion.Estacion_ID.Value);

        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            this.vista_BitacoraUnidadesBindingSource.DataSource = Entities.Vista_BitacoraUnidades.Get(Sesion.Estacion_ID.Value);                        
        }
        
        /// <summary>
        /// Realiza la actualización de la bitácora, a patir de la columna seleccionada
        /// </summary>
        /// <param name="col">El índice de columna seleccionada por el usuario</param>
        /// <param name="row">El índice de renglón seleccionado por el usuario</param>
        private void ActualizarBitacora(int col, int row)
        {
            //  Si el usuario hizo clic en la columna 'StandBy'
            if (BitacoraUnidadesGridView.Columns[col].Name == "StandByColumn")
            {
                //  Obtenemos el dato del registro
                Entities.Vista_BitacoraUnidades bitacoraUnidades = (Entities.Vista_BitacoraUnidades)BitacoraUnidadesGridView.Rows[row].DataBoundItem;

                //  Actualizar a stand by
                Entities.Functions.ActualizarEstatusOperativoUnidad(bitacoraUnidades.Unidad_ID.Value, 2, Sesion.Usuario_ID); // Stand By

                //  Actualizamos el listado de la bitácora
                vista_BitacoraUnidadesBindingSource.DataSource = null;
                vista_BitacoraUnidadesBindingSource.DataSource = Entities.Vista_BitacoraUnidades.Get(Sesion.Estacion_ID.Value);
            } // end if
            else if (BitacoraUnidadesGridView.Columns[col].Name == "CirculandoColumn") // Si el usuario selecciono 'Circulando'
            {
                //  Obtenemos el dato del registro
                Entities.Vista_BitacoraUnidades bitacoraUnidades = (Entities.Vista_BitacoraUnidades)BitacoraUnidadesGridView.Rows[row].DataBoundItem;

                //  Actualizar a circulando
                Entities.Functions.ActualizarEstatusOperativoUnidad(bitacoraUnidades.Unidad_ID.Value, 1, Sesion.Usuario_ID); // En Carrera

                //  Actualizamos el listado de la bitácora
                vista_BitacoraUnidadesBindingSource.DataSource = null;
                vista_BitacoraUnidadesBindingSource.DataSource = Entities.Vista_BitacoraUnidades.Get(Sesion.Estacion_ID.Value);
            } // end else if
                
        } // end void ActualizarBitacora

        /// <summary>
        /// Cuando el usuario hace clic en el contenido de una celda de la GridView,
        /// se ejecuta el procedimiento 'ActualizarBitacora'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitacoraUnidadesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.DoTransactions(
                delegate
                {
                    ActualizarBitacora(e.ColumnIndex, e.RowIndex);
                },
                this
            );
        } // end CellContentClick

        /// <summary>
        /// Al completar el ligado de datos, colorea los registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitacoraUnidadesGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in BitacoraUnidadesGridView.Rows)
            {
                Entities.Vista_BitacoraUnidades unidad = (Entities.Vista_BitacoraUnidades)row.DataBoundItem;
                switch (unidad.EstatusOperativo)
                { 
                    case "EN CARRERA":
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "CIRCULANDO":
                        row.DefaultCellStyle.BackColor = Color.Blue;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "STAND BY":
                        row.DefaultCellStyle.BackColor = Color.Green;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                }
            }
        }

        /// <summary>
        /// Al teclear enter en NumeroEconomicoTextBox, consulta los datos de unidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoTransactions(
                    delegate
                    {
                        //  Obtener los datos del conductor
                        GetDatosConductorUnidad();

                        //  Actualizar el estatus operativo                        
                        Entities.Functions.ActualizarEstatusOperativoUnidad(this.datosUnidad.Unidad_ID.Value, 2, Sesion.Usuario_ID); // Stand By

                        //  Vaciar la caja de texto
                        this.NumeroEconomicoTextBox.Text = string.Empty;

                        //  Refrescar los datos de la tabla
                        vista_BitacoraUnidadesBindingSource.DataSource = null;
                        vista_BitacoraUnidadesBindingSource.DataSource = Entities.Vista_BitacoraUnidades.Get(Sesion.Estacion_ID.Value);
                    }, 
                    this
                );                
            } // end if Enter
        } // end void NumeroEconomicoTextBox_KeyUp

        /// <summary>
        /// Al cargar la forma, liga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitacoraUnidades_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    BindData();
                }
            );
        } // end void BitacoraUnidades_Load

    } // end class
} // end namespace
