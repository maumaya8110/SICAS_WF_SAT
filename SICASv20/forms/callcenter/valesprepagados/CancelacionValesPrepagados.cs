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
    /// Formulario para la cancelación de vales prepagados
    /// </summary>
    public partial class CancelacionValesPrepagados : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de cancelación para vales prepagados
        /// </summary>
        public CancelacionValesPrepagados()
        {
            InitializeComponent();
        }        

        /// <summary>
        /// Al hacer clic en "Cancelar",
        /// actualiza los vales al estatus de "Cancelado"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(ActualizaEstatus);
        }

	   private void ActualizaEstatus()
	   {
		   Validar();
		   Actualizar();
	   }

	    private void Validar(){
		    if (string.IsNullOrEmpty(this.txtFolioInicial.Text) || Convert.ToInt32(this.txtFolioInicial.Text) == 0)
		    {
			    throw new Exception("Es necesario proporcionar el Folio Inicial");
		    }
		    if (string.IsNullOrEmpty(this.txtFolioFinal.Text) || Convert.ToInt32(this.txtFolioFinal.Text) == 0)
		    {
			    throw new Exception("Es necesario proporcionar el Folio Final");
		    }
	    }

	    private void Actualizar()
	    {
		    //  Obtenemos las variables de los controles
		    int empresaemite_id = Convert.ToInt32(this.cboEmpresa.SelectedValue);
		    int empresacliente_id = Convert.ToInt32(this.cboClientes.SelectedValue);
		    int folioinicial = Convert.ToInt32(this.txtFolioInicial.Text);
		    int foliofinal = Convert.ToInt32(this.txtFolioFinal.Text);
		    DateTime fechaemision = Convert.ToDateTime(this.dtpFechaEmision.Value);

		    //  Preparamos la sentencia SQL
		    string sql = @"UPDATE 	ValesPrepagados
SET		EstatusValePrepagado_ID = 3
WHERE	EmpresaCliente_ID = @EmpresaCliente_ID
AND		Empresa_ID = @EmpresaEmite_ID
AND		convert(date, FechaEmision) = convert(date, @FechaEmision)
AND		FolioDiario BETWEEN @FolioDiarioInicial AND @FolioDiarioFinal
AND		EstatusValePrepagado_ID = 1";

		    //  Ejecutamos la sentencia sql
		    DB.ExecuteCommand(
			   sql,
			   DB.GetParams(
				  DB.Param("@EmpresaCliente_ID", empresacliente_id),
				  DB.Param("@FechaEmision", fechaemision),
				  DB.Param("@FolioDiarioInicial", folioinicial),
				  DB.Param("@FolioDiarioFinal", foliofinal),
				  DB.Param("@EmpresaEmite_ID", empresaemite_id)
			   )
		    );

		    //  Limpiamos la forma
		    AppHelper.ClearControl(this);

		    //  Enviamos mensaje de éxito
		    AppHelper.Info("Vales Cancelados");
	    }

        /// <summary>
        /// Al cargar la ligamos las empresas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelacionValesPrepagados_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.empresasBindingSource.DataSource =
                        Entities.Empresas.ReadList(
                            DB.Param("TipoEmpresa_ID", 3)
                        );

				this.empresasCASCOBindingSource.DataSource =
				   Entities.Empresas.ReadList(
					  DB.Param("TipoEmpresa_ID", 2)
				   );
                }
            );
        } // end void
    } // end class
} // end namespace
