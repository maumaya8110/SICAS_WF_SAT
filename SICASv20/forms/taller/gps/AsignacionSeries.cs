using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AsignacionSeries : baseForm
    {
        public AsignacionSeries()
        {
            InitializeComponent();
        }

        private int _Unidad_ID;
        public int Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private Model unidadOrigen;

        private Model unidadDestino;

        class Model
        {
            private Entities.LocacionesUnidades _Locacion;
            public Entities.LocacionesUnidades Locacion
            {
                get { return _Locacion; }
                set { _Locacion = value; }
            }

            private Entities.Empresas _Empresa;
            public Entities.Empresas Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private Entities.ModelosUnidades _ModeloUnidad;
            public Entities.ModelosUnidades ModeloUnidad
            {
                get { return _ModeloUnidad; }
                set { _ModeloUnidad = value; }
            }

            private Entities.Unidades _Unidad;
            public Entities.Unidades Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            public void ConsultarUnidad()
            {
                this.Unidad = Entities.Unidades.Read(
                    DB.Param("NumeroEconomico", this.NumeroEconomico)
                );
                this.Locacion = Entities.LocacionesUnidades.Read(this.Unidad.LocacionUnidad_ID);
                this.Empresa = Entities.Empresas.Read(this.Unidad.Empresa_ID);
                this.ModeloUnidad = Entities.ModelosUnidades.Read(this.Unidad.ModeloUnidad_ID);
            }

            public void Guardar()
            {
                //  Actualizamos locación y estatus
                //Entities.Functions.ActualizarLocacionUnidad(
                //    Unidad.Unidad_ID,
                //    Unidad.LocacionUnidad_ID,
                //    DB.GetDate(),
                //    Sesion.Usuario_ID,
                //    this.Comentarios);
            }
        }

        public override void BindData()
        {
            this.unidadOrigen = new Model();
            this.unidadDestino = new Model();
            base.BindData();
        }

        private void AsignarRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AsignarRadioButton.Checked)
            {
                this.unidadDestino = new Model();
                OrigenGroupBox.Visible = true;
                OrigenGroupBox.Text = "Datos de Unidad";
                kilometrajeOrigenTextBox.Enabled = true;
                gpsOrigenTextBox.Enabled = true;
                AceptarButton.Text = "Asignar";
                AceptarButton.Visible = true;
                DestinoGroupBox.Visible = false;
            }
        }

        private void RemoverRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RemoverRadioButton.Checked)
            {
                this.unidadDestino = new Model();
                OrigenGroupBox.Visible = true;
                OrigenGroupBox.Text = "Datos de Unidad";
                kilometrajeOrigenTextBox.Enabled = false;
                gpsOrigenTextBox.Enabled = false;
                AceptarButton.Text = "Remover";
                AceptarButton.Visible = true;
                DestinoGroupBox.Visible = false;
            }
        }

        private void TransferirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TransferirRadioButton.Checked)
            {
                this.unidadOrigen = new Model();
                this.unidadDestino = new Model();
                OrigenGroupBox.Visible = true;
                OrigenGroupBox.Text = "Datos de Unidad Origen";
                kilometrajeOrigenTextBox.Enabled = false;
                gpsOrigenTextBox.Enabled = false;
                kilometrajeDestinoTextBox.Enabled = true;
                gpsDestinoTextBox.Enabled = true;
                AceptarButton.Text = "--->";
                DestinoGroupBox.Visible = true;
            }
        }

        private void numeroEconomicoOrigenTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {
                    unidadOrigen.NumeroEconomico = DB.GetNullableInt32(this.numeroEconomicoOrigenTextBox.Text).Value;
                    unidadOrigen.ConsultarUnidad();
                    this.numeroSerieOrigenTextBox.Text = unidadOrigen.Unidad.NumeroSerie;
                    this.numeroSerieMotorOrigenTextBox.Text = unidadOrigen.Unidad.NumeroSerieMotor;
                    this.placasOrigenTextBox.Text = unidadOrigen.Unidad.Placas;
                    this.kilometrajeOrigenTextBox.Text = unidadOrigen.Unidad.Kilometraje.ToString();
                    this.gpsOrigenTextBox.Text = unidadOrigen.Unidad.GPS;
                    this.locacionOrigenTextBox.Text = unidadOrigen.Locacion.Nombre;
                    this.empresaOrigenTextBox.Text = unidadOrigen.Empresa.Nombre;
                    this.modeloUnidadOrigenTextBox.Text = unidadOrigen.ModeloUnidad.Descripcion;
                }, this);
            }
        }

        private void numeroEconomicoDestinoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(delegate
                {
                    unidadDestino.NumeroEconomico = DB.GetNullableInt32(this.numeroEconomicoDestinoTextBox.Text).Value;
                    unidadDestino.ConsultarUnidad();
                    this.numeroSerieDestinoTextBox.Text = unidadDestino.Unidad.NumeroSerie;
                    this.numeroSerieMotorDestinoTextBox.Text = unidadDestino.Unidad.NumeroSerieMotor;
                    this.placasDestinoTextBox.Text = unidadDestino.Unidad.Placas;
                    this.kilometrajeDestinoTextBox.Text = unidadDestino.Unidad.Kilometraje.ToString();
                    this.gpsDestinoTextBox.Text = unidadDestino.Unidad.GPS;
                    this.locacionDestinoTextBox.Text = unidadDestino.Locacion.Nombre;
                    this.empresaDestinoTextBox.Text = unidadDestino.Empresa.Nombre;
                    this.modeloUnidadDestinoTextBox.Text = unidadDestino.ModeloUnidad.Descripcion;
                }, this);
            }
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {

        }

    }
}
