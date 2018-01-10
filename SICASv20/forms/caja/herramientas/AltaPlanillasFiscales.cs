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
    /// Formulario para ingresar planillas fiscales al sistema
    /// </summary>
    public partial class AltaPlanillasFiscales : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario AltaPlanillasFiscales
        /// </summary>
        public AltaPlanillasFiscales()
        {
            InitializeComponent();

            //  Agregamos validación de "solo números"
            //  a las cajas de texto necesarias
            AppHelper.AddTextBoxesOnlyNumbersValidation(
                this.FolioInicialTextBox, 
                this.FolioFinalTextBox, 
                this.PrecioTextBox, 
                this.DenominacionTextBox);

            //  Agregamos las validaciones al número de serie
            AppHelper.AddTextBoxOnlyCharsValidation(ref this.SerieTextBox);
            this.SerieTextBox.MaxLength = 1;
        }

        /// <summary>
        /// Clase que modela la lógica de negocios para llevar a cabo el registro
        /// nuevas planillas fiscales en el sistema
        /// </summary>
        class Model
        {
            
            /// <summary>
            /// La serie del conjunto de planillas fiscales a dar de alta
            /// </summary>
            public string Serie
            {
                get { return _Serie; }
                set { _Serie = value; }
            }
            private string _Serie;

            /// <summary>
            /// El folio inicial del conjunto de planillas fiscales a dar de alta
            /// </summary>
            public int FolioInicial
            {
                get { return _FolioInicial; }
                set { _FolioInicial = value; }
            }
            private int _FolioInicial;

            /// <summary>
            /// El folio final del conjunto de planillas fiscales a dar de alta
            /// </summary>
            public int FolioFinal
            {
                get { return _FolioFinal; }
                set { _FolioFinal = value; }
            }
            private int _FolioFinal;

            /// <summary>
            /// El precio de venta que tendrá cada planilla fiscal en el conjunto
            /// </summary>
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }
            private decimal _Precio;

            /// <summary>
            /// La denominación fiscal que tendrá cada planilla fiscal en el conjunto
            /// </summary>
            public decimal Denominacion
            {
                get { return _Denominacion; }
                set { _Denominacion = value; }
            }
            private decimal _Denominacion;

            /// <summary>
            /// La empresa a la que pertenecerá el
            /// conjunto de planillas fiscales
            /// </summary>
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }
            private int _Empresa_ID;

            /// <summary>
            /// La estación en la cual se darán de alta
            /// las planillas
            /// </summary>
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }
            private int _Estacion_ID;

            /// <summary>
            /// El listado de empresas a elegir, dependiendo
            /// de los permisos del usuario
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas
            {
                get { return _Empresas; }
                set { _Empresas = value; }
            }
            private List<Entities.SelectEmpresas> _Empresas;
            
            /// <summary>
            /// El listado de estaciones a elegir, dependiendo
            /// de los permisos del usuario
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones
            {
                get { return _Estaciones; }
                set { _Estaciones = value; }
            }
            private List<Entities.SelectEstaciones> _Estaciones;

            /// <summary>
            /// Consulta las estaciones de la base de datos
            /// </summary>
            public void ConsultarEstaciones()
            {
                this.Estaciones = Sesion.Estaciones;
            }

            /// <summary>
            /// Consulta la empresas de la base de datos
            /// </summary>
            public void ConsultarEmpresas()
            {
                this.Empresas = Sesion.Empresas;
            }
            
            /// <summary>
            /// Verifica que una planilla fiscal sea válidad
            /// </summary>
            /// <param name="planilla">El folio de la planilla</param>
            public void ValidarPlanilla(int planilla)
            {
                if (DB.Exists("PlanillasFiscales",
                        DB.Param("Empresa_ID", Empresa_ID),
                            DB.Param("Estacion_ID", Estacion_ID),
                                DB.Param("Serie", Serie), DB.
                                    Param("Folio", planilla)))
                {
                    AppHelper.ThrowException("Planilla fiscal {0}-{1} ya existe", Serie, planilla);
                }
            }

            /// <summary>
            /// Verifica que un conjunto de planillas fiscales sea válido, antes de darlo de alta
            /// </summary>
            /// <param name="serie">La serie fiscal</param>
            /// <param name="folioinicial">El folio inicial</param>
            /// <param name="foliofinal">El folio final</param>
            public void ValidarSeriePlanillas(string serie, int folioinicial, int foliofinal)
            {
                string sql = @"SELECT COUNT(*)
FROM PlanillasFiscales
WHERE Folio BETWEEN @FolioInicial AND @FolioFinal
AND     Estacion_ID = @Estacion_ID
AND     Empresa_ID = @Empresa_ID
AND     Serie = @Serie";

                //  Tiene que tener precio
                if (Precio == 0)
                {
                    AppHelper.ThrowException("Las planillas deben tener un precio");
                }

                //  Tiene que tener denominación
                if (Denominacion == 0)
                {
                    AppHelper.ThrowException("Las planillas deben tener una denominacion");
                }

                //  El folio final debe ser igual o mayor al folio inicial
                if (FolioInicial >= FolioFinal)
                {
                    AppHelper.ThrowException("El folio final debe ser mayor al folio inicial");
                }

                //  Debe contar con serie fiscal
                if (string.IsNullOrEmpty(Serie))
                {
                    AppHelper.ThrowException("Las planillas deben tener una serie");
                }

                //  No debe existir previamente en el sistema
                //  Obtenemos el número de registros con las características buscadas
                int count = Convert.ToInt32(
                        DB.QueryScalar(
                            sql,
                            DB.GetParams(
                                DB.Param("@FolioInicial", FolioInicial),
                                DB.Param("@FolioFinal", FolioFinal),
                                DB.Param("@Estacion_ID", Estacion_ID),
                                DB.Param("@Serie", Serie),
                                DB.Param("@Empresa_ID", Empresa_ID)
                            )
                        )
                    );

                //  Si existe al menos un registro
                if (count > 0)
                {
                    //  Enviamos un error
                    AppHelper.ThrowException("Ya existen planillas fiscales con la serie y folios especificados");
                }
            }

            /// <summary>
            /// Ingresa las planillas al sistema
            /// </summary>
            public void IngresarPlanillas()
            {
                //  El contador
                int i = 0;

                //  Obtenemos la fecha del servidor
                DateTime fecha = DB.GetDate();

                //  Preparamos una variable para contener el enunciado SQL
                string sql = "";

                //  Validar serie de planillas
                ValidarSeriePlanillas(Serie, FolioInicial, FolioFinal);

                //  Recorremos los folios
                for (i = this.FolioInicial; i <= this.FolioFinal; i++)
                {
                    //  Construimos una instrucción SQL de inserción
                    //  para cada registro
                    sql += string.Format(
                        "INSERT INTO PlanillasFiscales VALUES ({0}, 1, null, '{1}', {2}, {3}, {4}, '{5:yyyy-MM-dd HH:mm:ss}', {6});\r\n",
                        Estacion_ID,
                        Serie,
                        i,
                        Denominacion,
                        Precio,
                        fecha,
                        Empresa_ID
                    );
                }


                //  Si existe al menos una instrucción
                if (!string.IsNullOrEmpty(sql))
                {
                    //  La ejecutamos contra la base de datos
                    DB.ExecuteQuery(sql);

                } // end if

            } // end IngresarPlanillas

        } // end model

        /// <summary>
        /// La instancia del modelo de lógica de negocios
        /// </summary>
        private Model model;

        /// <summary>
        /// Liga los controles a la base de datos
        /// </summary>
        public override void BindData()
        {
            //  Crea una nueva instancia del modelo
            model = new Model();

            //  Consulta las empresas
            model.ConsultarEmpresas();

            //  Liga las empresas a los controles
            empresasBindingSource.DataSource = model.Empresas;

            //  Consulta las estaciones
            model.ConsultarEstaciones();

            //  Liga las estaciones a los controles
            estacionesBindingSource.DataSource = model.Estaciones;
            
            //  Valida los permisos del usuario actual
            ValidarPermisos();

            //  Si seleccionamos una empresa
            if (EmpresasComboBox.SelectedItem != null)
            {
                //  Obtenemos el valor
                Entities.SelectEmpresas empresa = (Entities.SelectEmpresas)EmpresasComboBox.SelectedItem;

                //  Actualizamos el modelo
                model.Empresa_ID = empresa.Empresa_ID.Value;
            } // end if

            //  Si seleccionamos una empresa
            if (EstacionesComboBox.SelectedItem != null)
            {
                //  Obtenemos el valor
                Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;

                //  Actualizamos el modelo
                model.Estacion_ID = estacion.Estacion_ID.Value;
            } // end if


            base.BindData();
        }

        /// <summary>
        /// Valida los permisos del usuario actual
        /// </summary>
        private void ValidarPermisos()
        {
            //  Habilidatmos los controles de empresas y estaciones
            EmpresasComboBox.Enabled = true;
            EstacionesComboBox.Enabled = true;

            //  Si tenemos configurada empresa fija
            if (Sesion.Empresa_ID != null)
            {
                //  Actualizamos el modelo
                model.Empresa_ID = Sesion.Empresa_ID.Value;

                //  Actualizamos el control
                EmpresasComboBox.SelectedValue = model.Empresa_ID;

                //  Consultamos las estaciones
                model.ConsultarEstaciones();

                //  Ligamos estaciones a los controles
                estacionesBindingSource.DataSource = model.Estaciones;

                //  Si tenemos una estación fija
                if (Sesion.Estacion_ID != null)
                {
                    //  Actualizamos el modelo y los controles
                    model.Estacion_ID = Sesion.Estacion_ID.Value;
                    EstacionesComboBox.SelectedValue = model.Estacion_ID;

                    // La fijamos inhabilitando el control
                    EstacionesComboBox.Enabled = false;
                }

                //  Fijamos la empresa inhabilitando el control
                EmpresasComboBox.Enabled = false;

                AppHelper.Try(delegate
                {
                    //  Si seleccionamos un valor
                    if (EstacionesComboBox.SelectedItem != null)
                    {
                        //  Obtenemos la estación
                        Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;

                        //  Actualizamos el modelo
                        model.Estacion_ID = estacion.Estacion_ID.Value;
                    }
                });

            } // end if

        } // end validar permisos

        /// <summary>
        /// Realiza el ingreso de planillas
        /// en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {                
                //  Realizamos la inserción
                model.IngresarPlanillas();

                //  Limpiamos la forma
                AppHelper.ClearControl(this);

                //  Ligamos los datos
                BindData();

                //  Enviamos mensaje de  éxito
                AppHelper.Info("Planillas ingresadas");
            }, this);
        }

        /// <summary>
        /// Actualiza el dato de empresa en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                //  Si seleccionamos una empresa
                if (EmpresasComboBox.SelectedItem != null)
                {
                    //  Obtenemos el valor
                    Entities.SelectEmpresas empresa = (Entities.SelectEmpresas)EmpresasComboBox.SelectedItem;

                    //  Actualizamos el modelo
                    model.Empresa_ID = empresa.Empresa_ID.Value;
                } // end if
            });
        } // end EmpresasComboBox_SelectionChangeCommitted

        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                //  Si seleccionamos un valor
                if (EstacionesComboBox.SelectedItem != null)
                {
                    //  Obtenemos la estación
                    Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;

                    //  Actualizamos el modelo
                    model.Estacion_ID = estacion.Estacion_ID.Value;
                }
            });

        } // EstacionesComboBox_SelectionChangeCommitted

        /// <summary>
        /// Actualiza la serie fiscal en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerieTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.model.Serie = SerieTextBox.Text;
            });

        } // end SerieTextBox_TextChanged     

        /// <summary>
        /// Actualiza el folio inicial en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolioInicialTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.model.FolioInicial = AppHelper.GetValue<int>(FolioInicialTextBox.Text);
            });

        } // end FolioInicialTextBox_TextChanged

        /// <summary>
        /// Actualiza el folio final en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolioFinalTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.model.FolioFinal = AppHelper.GetValue<int>(FolioFinalTextBox.Text);
            });

        } // end FolioFinalTextBox_TextChanged

        /// <summary>
        /// Actualiza el precio en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.model.Precio = AppHelper.GetValue<decimal>(PrecioTextBox.Text);
            }); 

        } // end PrecioTextBox_TextChanged 

        /// <summary>
        /// Actualiza la denominación en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DenominacionTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.model.Denominacion = AppHelper.GetValue<decimal>(DenominacionTextBox.Text);
            });

        } // end DenominacionTextBox_TextChanged
         
    } // end class
} // end namespace
