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
    /// Formulario para la visualización y consulta de empresas
    /// </summary>
    public partial class Empresas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de empresas
        /// </summary>
        public Empresas()
        {
            InitializeComponent();
            this.empresasDataGridView.DataBindingComplete += this.ColorDataGrid;            
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empresasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.empresasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
	   public override void BindData()
	   {
		   this.empresasBindingSource.DataSource = Entities.Empresas.ReadDataTable();
		   this.mercadosBindingSource.DataSource = Entities.SelectMercados.Get();
		   this.tiposEmpresasBindingSource.DataSource = Entities.TiposEmpresas.Read();
		   base.BindData();
	   }

        /// <summary>
        /// Colorea la tabla de empresas, dependiendo de su tipo de empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorDataGrid(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.ColorDataGridViewRows(
                        ref this.empresasDataGridView,
                        "TipoEmpresa_ID",
                        AppHelper.RelacionValoresColores
                    );                
                }
            );
        }

        /// <summary>
        /// Consulta la base de datos en busca de empresas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Aplica la búsqueda y actualiza los datos
                    empresasBindingSource.Filter =
                        string.Format(
                            @"TipoEmpresa_ID = {0}
                            AND ( Nombre LIKE '{1}%'
                            OR RazonSocial LIKE '{1}%' )",
                            this.TiposEmpresasComboBox.SelectedValue,
                            this.NombreEmpresaTexBox.Text
                        );                    
                }
            );
        }

        /// <summary>
        /// Muestra el formulario para actualizar datos de la empresa seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empresasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Si la columna es editar
                    if (this.empresasDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                    {
                        //  Creamos un nuevo formulario de actualización
                        forms.ActualizacionEmpresa ac = new forms.ActualizacionEmpresa();

                        //  Obtenemos el ID de la empresa
                        DataRowView dr = (DataRowView)empresasDataGridView.Rows[e.RowIndex].DataBoundItem;
                        int conductor_id = (int)dr["Empresa_ID"];

                        //  Lo asignamos al formulario
                        ac.Empresa_ID = Convert.ToInt32(conductor_id);

                        //  Navegamos a él
                        Padre.SwitchForma("ActualizacionEmpresa", ac);
                    }
                },
                this
            );
        }

        /// <summary>
        /// Al cerrarse la forma, cierra las fuentes de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Empresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.empresasBindingSource.DataSource = null;
                    this.tiposEmpresasBindingSource.DataSource = null;
                    this.mercadosBindingSource.DataSource = null;
                }
            );
        }
    } // end class

} // end namespace
