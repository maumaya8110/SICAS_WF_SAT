using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class UnidadUC : baseUserControl
    {
        public UnidadUC()
        {
            InitializeComponent();            
            AppHelper.SetStylish(this);
        }
        
        public NuevaOrdenTrabajo Padre;
        Entities.DatosUnidadTaller datosUnidad;
        private forms.ActualizarModeloUnidad ActualizarModeloForm;

        private void SetActualizarModeloForm()
        {
            if (this.ActualizarModeloForm == null)
                this.ActualizarModeloForm = new ActualizarModeloUnidad();

            if (this.ActualizarModeloForm.IsDisposed)
                this.ActualizarModeloForm = new ActualizarModeloUnidad();
        }

        private void SetDatosUnidad()
        {            
            Padre.OrdenTrabajo.Unidad_ID = datosUnidad.Unidad_ID.Value;
            Padre.OrdenTrabajo.ClienteFacturar_ID = datosUnidad.Empresa_ID.Value;
            Padre.OrdenTrabajo.Empresa_ID = Sesion.Empresa_ID.Value;
            Padre.OrdenTrabajo.NumeroEconomico = datosUnidad.NumeroEconomico.Value;
            Padre.OrdenTrabajo.Cliente_Nombre = datosUnidad.Empresa;
            Padre.OrdenTrabajo.Conductor_Nombre = datosUnidad.Conductor;
            Padre.OrdenTrabajo.Unidad_Placas = datosUnidad.Placas;
            Padre.ModeloUnidad_ID = datosUnidad.ModeloUnidad_ID;
            Padre.Modelo_ID = datosUnidad.Modelo_ID;

            this.NumeroEconomicoTextBox.Text = datosUnidad.NumeroEconomico.ToString();
            this.ConductorHabitualTextBox.Text = datosUnidad.Conductor;
            this.ClienteTextBox.Text = datosUnidad.Empresa;
            this.PlacasTextBox.Text = datosUnidad.Placas;
            this.ModeloTextBox.Text = datosUnidad.Modelo;
        }

        private void DoQuery()
        {
            int? numeroeconomico = null; string cliente, placas;

            if (!string.IsNullOrEmpty(this.NumeroEconomicoTextBox.Text))
            {
                if (AppHelper.IsNumeric(this.NumeroEconomicoTextBox.Text))
                {
                    numeroeconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);
                }
                else
                {
                    throw new Exception("El numero económico deben ser solamente números");
                }
            }

            cliente = (string.IsNullOrEmpty(ClienteTextBox.Text)) ? null : ClienteTextBox.Text;
            placas = (string.IsNullOrEmpty(PlacasTextBox.Text)) ? null : PlacasTextBox.Text;

            List<Entities.DatosUnidadTaller> unidades = Entities.DatosUnidadTaller.Get(numeroeconomico, cliente, placas);

            if (unidades.Count == 0  )
            {
                if (numeroeconomico != null)
                {
                    unidades = Entities.DatosUnidadTaller.Get(numeroeconomico.Value);
                }
                else
                {
                    AppHelper.ThrowException("No existen unidades con los parámtros especificados");
                }
            }

            if (unidades.Count == 1)
            {
                datosUnidad = unidades[0];
                SetDatosUnidad();
            }
            else
            {
                this.datosUnidadTallerBindingSource.DataSource = unidades;
            }
        }

        private void DoQueryPlacas()
        {
            this.ClienteTextBox.Text = string.Empty;

            if (!DB.Exists("Unidades", DB.Param("Placas", this.PlacasTextBox.Text)))
            {
                CapturaRapidaCliente capturaForm = new CapturaRapidaCliente();
                capturaForm.Placas = this.PlacasTextBox.Text;

                AppHelper.Info("Unidad no existe, debe capturar un nuevo cliente");
                if (capturaForm.ShowDialog() == DialogResult.OK)
                {
                    this.NumeroEconomicoTextBox.Text = capturaForm.NumeroEconomico.ToString();
                    this.PlacasTextBox.Text = capturaForm.Placas;
                    DoQuery();
                }
            }
            else
            {
                DoQuery();
            }
        }

        private void DoValidate()
        {
            if (Padre.OrdenTrabajo.Unidad_ID == 0)
            {
                throw new Exception("Debe capturar una unidad");
            }
        }

        private void AnteriorButton_Click(object sender, EventArgs e)
        {            
            try
            {
                Padre.SwitchPanel("TiposMantenimientos");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void NavSiguiente()
        {
            DoValidate();
            Padre.cobrarAControl.BindData();
            Padre.SwitchPanel("CobrarA");
        }

        private void ValidarCB()
        {
            string cb = "";
            if (AppHelper.InputBox("Número de CB", "Capture el número de CB, por favor", ref cb) == DialogResult.OK)
            {
                // Si cb es activo
                string sqlqry = @"IF EXISTS ( SELECT * FROM OrdenesTrabajos WHERE CB = @CB ) 
                        BEGIN SELECT TOP 1 CB_Activo FROM OrdenesTrabajos WHERE CB = @CB END 
                        ELSE BEGIN SELECT 1 END";

                if (!Convert.ToBoolean(DB.QueryScalar(sqlqry, DB.Param("@CB", cb))))
                {
                    AppHelper.ThrowException("El CB {0} ya ha sido cerrado. Por favor intente de nuevo", cb);
                }

                // Corresponde el número económico con el CB
                sqlqry = @"IF EXISTS ( SELECT * FROM OrdenesTrabajos WHERE CB = @CB ) 
                        BEGIN 
                            SELECT COUNT(OrdenTrabajo_ID) FROM OrdenesTrabajos 
                            WHERE CB = @CB AND NumeroEconomico = @NumEco 
                        END 
                        ELSE 
                        BEGIN 
                            SELECT 1 
                        END";

                if (!Convert.ToBoolean(
                        DB.QueryScalar(
                            sqlqry, 
                            DB.Param("@CB", cb), 
                            DB.Param("@NumEco", this.Padre.OrdenTrabajo.NumeroEconomico)
                            )
                        )
                    )
                {
                    AppHelper.ThrowException("El numero economico {0} no corresponde con el CB {1}.",
                        this.Padre.OrdenTrabajo.NumeroEconomico, cb);
                }

                this.Padre.OrdenTrabajo.CB = cb;
            }
        }

        private void DoQueryNumeroEconomico()
        {
            List<Entities.DatosUnidadTaller> unidades = Entities.DatosUnidadTaller.Get(Convert.ToInt32(this.NumeroEconomicoTextBox.Text));
            if (unidades.Count == 1)
            {
                datosUnidad = unidades[0];
                SetDatosUnidad();
                //ValidarCB();
                //NavSiguiente();
            }
            else
            {
                if (unidades.Count == 0) AppHelper.ThrowException("No existen unidades con número economico {0}", NumeroEconomicoTextBox.Text);

                this.datosUnidadTallerBindingSource.DataSource = unidades;
            }
        }

        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCB();
                NavSiguiente();
            }
            catch(Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(
                    delegate
                    {
                        DoQueryNumeroEconomico();
                    },
                    this
                );                
            }            
        }
        
        private void PlacasTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    DoQueryPlacas();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void ClienteTextBox_KeyUp(object sender, KeyEventArgs e)
        {            
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    DoQuery();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void UnidadesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UnidadesDataGridView.Columns["Seleccionar"].Index == e.ColumnIndex)
                {
                    datosUnidad = (Entities.DatosUnidadTaller)UnidadesDataGridView.CurrentRow.DataBoundItem;
                    SetDatosUnidad();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }            
        }

        private void ActualizarModeloButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    SetActualizarModeloForm();
                    this.ActualizarModeloForm.Set_DatosUnidad(this.datosUnidad);
                    if (ActualizarModeloForm.ShowDialog() == DialogResult.OK)
                    {
                        DoQueryNumeroEconomico();
                    }
                }
            );
        } //    end void
    } //    end class form
} //    end namespace
