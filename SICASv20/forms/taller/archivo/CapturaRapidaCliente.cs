using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CapturaRapidaCliente : Form
    {
        public CapturaRapidaCliente()
        {
            InitializeComponent();
        }

        class CapturaRapidaCliente_Model
        {
            #region properties

            private Entities.Empresas _Cliente;
            public Entities.Empresas Cliente
            {
                get { return _Cliente; }
                set { _Cliente = value; }
            }

            private Entities.Unidades _Unidad;
            public Entities.Unidades Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }
           
            private List<Entities.Modelos> _Modelos;
            public List<Entities.Modelos> Modelos
            {
                get { return _Modelos; }
                set { _Modelos = value; }
            }

            private string _RFC;
            public string RFC
            {
                get { return _RFC; }
                set { _RFC = value; }
            }

            private string _RazonSocial;
            public string RazonSocial
            {
                get { return _RazonSocial; }
                set { _RazonSocial = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private string _Placas;
            public string Placas
            {
                get { return _Placas; }
                set { _Placas = value; }
            }

            private Entities.Modelos _Modelo;
            public Entities.Modelos Modelo
            {
                get { return _Modelo; }
                set { _Modelo = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            #endregion

            #region Methods

            public void Validar()
            {
                if (string.IsNullOrEmpty(this.RFC))
                {
                    throw new Exception("Debe capturar el RFC");
                }

                if (string.IsNullOrEmpty(this.RazonSocial))
                {
                    throw new Exception("Debe capturar la razon social");
                }

                if (string.IsNullOrEmpty(this.Placas))
                {
                    throw new Exception("Debe capturar las placas");
                }

                if (this.Modelo == null)
                {
                    throw new Exception("Debe capturar el modelo");
                }

                if (this.NumeroEconomico == 0)
                {
                    throw new Exception("Debe capturar el numero economico");
                }

                if (string.IsNullOrEmpty(this.Telefono))
                {
                    throw new Exception("Debe capturar el telefono");
                }
            }

            public void Guardar()
            {
                Cliente = new Entities.Empresas();
                Unidad = new Entities.Unidades();

                Cliente.Activo = true;
                Cliente.Mercado_ID = null;
                Cliente.Nombre = StringHelper.Left(this.RazonSocial, 50);
                Cliente.RazonSocial = this.RazonSocial;
                Cliente.RFC = this.RFC;
                Cliente.Telefono1 = this.Telefono;
                Cliente.TipoEmpresa_ID = 3;
                Cliente.Domicilio = "PENDIENTE";
                Cliente.CodigoPostal = "PENDIENTE";
                Cliente.Ciudad = "Monterrey";
                Cliente.Estado = "Nuevo León";
                Cliente.Create();

                Unidad.Arrendamiento_ID = null;
                Unidad.Concesion_ID = null;
                Unidad.Empresa_ID = Cliente.Empresa_ID;
                Unidad.Estacion_ID = Sesion.Estacion_ID.Value;
                Unidad.EstatusUnidad_ID = 1;
                Unidad.Kilometraje = null;
                Unidad.LocacionUnidad_ID = 1;
                Unidad.ModeloUnidad_ID = ObtenerModeloUnidad_ID();
                Unidad.NumeroEconomico = this.NumeroEconomico;
                Unidad.Placas = this.Placas;
                Unidad.PrecioLista = 0;
                Unidad.Propietario_ID = Cliente.Empresa_ID;
                Unidad.NumeroSerie = "PENDIENTE";
                Unidad.NumeroSerieMotor = "PENDIENTE";
                Unidad.TarjetaCirculacion = "PENDIENTE";                
                Unidad.Create();
            }

            public void ConsultarModelos()
            {
                this.Modelos = Entities.Modelos.Read();
            }

            public void ObtenerNumeroEconomico()
            {
                string sql = @"SELECT ISNULL(MAX(NumeroEconomico),10000) + 1 NumeroEconomico FROM Unidades
                    WHERE NumeroEconomico >= 10000 AND NumeroEconomico <= 20000";

                this.NumeroEconomico = Convert.ToInt32(
                        DB.QueryScalar(sql)
                    );
            }

            public int ObtenerModeloUnidad_ID()
            {
                string sql = @"SELECT TOP 1 ModeloUnidad_ID
FROM    ModelosUnidades
WHERE   Modelo_ID = {0}";
                sql = string.Format(sql, this.Modelo.Modelo_ID);

                object result = DB.QueryScalar(sql);

                if(result == null)
                {
                    //  No existen modelos de unidad para el modelo de taller
                    //  Crear uno
                    Entities.ModelosUnidades mu = new Entities.ModelosUnidades();
                    mu.Activo = false;
                    mu.Anio = 0;
                    mu.Deposito = 0;
                    mu.Descripcion = this.Modelo.Nombre;
                    mu.EmpresaReferencia = null;
                    mu.MarcaUnidad_ID = 1;
                    mu.Modelo_ID = this.Modelo.Modelo_ID;
                    mu.PrecioLista = 0;
                    mu.Create();

                    return mu.ModeloUnidad_ID;
                }
                else
                {
                    return Convert.ToInt32(
                        result
                    );
                }                
            }

            #endregion
        }

        #region Properties

        private CapturaRapidaCliente_Model Model;

        private int _NumeroEconomico;
        public int NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }

        private string _Placas;
        public string Placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }
        #endregion

        #region Methods

        private void Clear()
        {
            AppHelper.ClearControl(this);
        }
        #endregion

        #region Events

        private void CapturaRapidaCliente_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model = new CapturaRapidaCliente_Model();
                    Model.ConsultarModelos();
                    Model.ObtenerNumeroEconomico();
                    this.NumeroEconomicoTextBox.Text = Model.NumeroEconomico.ToString();
                    this.NumeroEconomicoTextBox.ReadOnly = true;

                    if (!string.IsNullOrEmpty(this.Placas))
                    {
                        this.Model.Placas = this.Placas;
                        this.PlacasTextBox.Text = this.Placas;
                        this.PlacasTextBox.ReadOnly = true;
                    }

                    this.modelosBindingSource.DataSource = Model.Modelos;                    
                }
            );
        }        

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    Model.Validar();
                    Model.Guardar();
                    this.NumeroEconomico = Model.NumeroEconomico;
                    this.Placas = Model.Placas;
                    this.Clear();
                    AppHelper.Info("Cliente registrado");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                },
                this
            );
        }             

        private void RFCTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model.RFC = this.RFCTextBox.Text;
                }
            );
        }

        private void RazonSocialTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model.RazonSocial = this.RazonSocialTextBox.Text;
                }
            );
        }

        private void PlacasTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model.Placas = this.PlacasTextBox.Text;
                }
            );
        }

        private void ModeloComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model.Modelo = (Entities.Modelos)this.ModeloComboBox.SelectedItem;
                }
            );
        }

        private void TelefonoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Model.Telefono = this.TelefonoTextBox.Text;
                }
            );
        }

        #endregion
    }
}
