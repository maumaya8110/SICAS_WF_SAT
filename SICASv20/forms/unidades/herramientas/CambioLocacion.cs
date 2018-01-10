/*
 * CambioLocacion
 * 
 * Cambia la locación de una unidad en el sistema
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 *      Se eliminó el método Get_Estaciones
 *      que obtenía las estaciones a partir de los 
 *      contratos que se tuviera con la empresa
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
    public partial class CambioLocacion : baseForm
    {
        public CambioLocacion()
        {
            InitializeComponent();
        }

        private Model model;

        public override void BindData()
        {
            this.model = new Model();
            this.model.ConsultarLocaciones();
            this.model.ConsultarEstaciones();
            this.estacionesBindingSource.DataSource = this.model.Estaciones;
            if (Sesion.Estacion_ID != null)
            {
                this.EstacionesComboBox.SelectedValue = Sesion.Estacion_ID.Value;
                this.EstacionesComboBox.Enabled = false;
            }
            this.locacionesUnidadesBindingSource.DataSource = this.model.Locaciones;
            base.BindData();
        }

        class Model
        {
            private Entities.LocacionesUnidades _Locacion;
            public Entities.LocacionesUnidades Locacion
            {
                get { return _Locacion; }
                set { _Locacion = value; }
            }

            private Entities.Unidades _Unidad;
            public Entities.Unidades Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private string _NombreConductor;
            public string NombreConductor
            {
                get { return _NombreConductor; }
                set { _NombreConductor = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private int _Estacion;
            public int Estacion
            {
                get { return _Estacion; }
                set { _Estacion = value; }
            }

            public string Comentarios { get; set; }

            private BindingList<Entities.LocacionesUnidades> _Locaciones;
            public BindingList<Entities.LocacionesUnidades> Locaciones
            {
                get { return _Locaciones; }
                set { _Locaciones = value; }
            }

            private List<Entities.SelectEstaciones> _Estaciones;
            public List<Entities.SelectEstaciones> Estaciones
            {
                get { return _Estaciones; }
                set { _Estaciones = value; }
            }
            
            public void ConsultarLocaciones()
            {
                this.Locaciones =
                    new BindingList<Entities.LocacionesUnidades>(Entities.LocacionesUnidades.Read());
            }

            public void ConsultarEstaciones()
            {
                this.Estaciones = Sesion.EstacionesTodas;                
            }

            public void ConsultarUnidad()
            {
                this.Unidad = Entities.Unidades.Read(
                    DB.Param("NumeroEconomico", this.NumeroEconomico),
                    DB.Param("Estacion_ID", this.Estacion)
                );

                this.Locacion = Entities.LocacionesUnidades.Read(this.Unidad.LocacionUnidad_ID);

                Entities.Contratos contrato =
                    Entities.Contratos.Read(
                        DB.Param("Unidad_ID", this.Unidad.Unidad_ID),
                        DB.Param("EstatusContrato_ID", 1)
                    );

                if (contrato != null)
                {
                    Entities.Conductores conductor = 
                        Entities.Conductores.Read(contrato.Conductor_ID);
                    this.NombreConductor = conductor.Apellidos + " " + conductor.Nombre;
                }
                else
                { 
                    this.NombreConductor = "";
                }
            }

            public void Guardar()
            {                
                //  Actualizamos locación y estatus
                Entities.Functions.ActualizarLocacionUnidad(
                    Unidad.Unidad_ID, 
                    Unidad.LocacionUnidad_ID, 
                    DB.GetDate(), 
                    Sesion.Usuario_ID, 
                    this.Comentarios);
            }
        }

        private void GuerdarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(delegate 
            {
                if (model.Unidad == null) throw new Exception("Debe capturar una unidad!");

                if (EstacionesComboBox.SelectedValue == null)
                {
                    throw new Exception("Debe capturar una estación");
                }

                model.Estacion = Convert.ToInt32(EstacionesComboBox.SelectedValue);
                model.Unidad.LocacionUnidad_ID = Convert.ToInt32(LocacionComboBox.SelectedValue);
                model.Comentarios = this.ComentariosTextBox.Text.ToUpper();

                //  Actualizamos la unidad
                model.Guardar();

                //  Mensaje de éxito
                AppHelper.Info("Registro actualizado");
                            
                AppHelper.ClearControl(this);

                BindData();

                this.UnidadTextBox.Focus();

            }, this);
        }

        private void UnidadTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {
                    model.Estacion = Convert.ToInt32(this.EstacionesComboBox.SelectedValue);
                    model.NumeroEconomico = DB.GetNullableInt32(this.UnidadTextBox.Text).Value;
                    model.ConsultarUnidad();
                    this.PlacasTextBox.Text = model.Locacion.Nombre;
                    this.ConductorTextBox.Text = model.NombreConductor;
                }, this);
            }
        }
    } // end class
} // end namespace
