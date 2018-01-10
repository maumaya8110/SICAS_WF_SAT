using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para la impresión en lote de boletos de servicios
    /// </summary>
    public partial class ImpresionVentaLoteServicios : baseForm
    {
        #region Properties

        /// <summary>
        /// La instancia de la clase de servicio a utilizar
        /// para ingresar los servicios a la base de datos
        /// </summary>
        Entities.Servicios Servicio; 
       
        /// <summary>
        /// El listado de comisiones del servicio
        /// </summary>
        List<Entities.Servicios_Comisiones> Comisiones;

        /// <summary>
        /// El listado de boletos, a utilizar para la impresió
        /// </summary>
        List<Entities.BoletoVenta> Boletos;

        /// <summary>
        /// La cantidad de boletos a imprimir
        /// </summary>
        Int32 Cantidad = 0;


        /// <summary>
        /// El concepto de comisión de regresos
        /// </summary>
        private const int COMISIONREGRESOS_ID = 18;

        /// <summary>
        /// El concepto de comisión "PRONATURA"
        /// </summary>
        private const int COMISIONPRONATURA_ID = 38;

        #endregion

        #region Constructors

        /// <summary>
        /// Crea una nueva instancia del formulario de impresión
        /// de boletos de servicios en lote
        /// </summary>
        public ImpresionVentaLoteServicios()
        {
            InitializeComponent();

            //  Agregamos validación numérica
            //  a la cantidad. Permitimos solo números
            AppHelper.AddTextBoxOnlyNumbersValidation(ref this.CantidadTextBox);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Creamos una nueva instancia del servicio
            Servicio = new Entities.Servicios();

            //  Asignamos las fuente de datos
            //  para zonas y tipos de servicios
            this.buscarZonasBindingSource.DataSource = Entities.BuscarZonas.Get("");
            this.tiposServiciosBindingSource.DataSource = Entities.TiposServicios.Read();

            base.BindData();
        }

        /// <summary>
        /// Asigna las comisiones correspondientes al servicio a partir de la configuración por zona
        /// </summary>
        private void GetComisiones()
        {
            //  Un servicio puede contener cualquier cantidad
            //  de comisiones
            //  El total a pagar al conductor es el precio del boleto
            //  menos las comisiones

            //  Instanciamos las comisiones
            Comisiones = new List<Entities.Servicios_Comisiones>();

            //  Inicializamos a cero el pago de comisiones
            Servicio.PagoComisiones = 0;

            //  Inicializamos el pago del conductor como el precio
            //  del servicio
            Servicio.PagoConductor = Servicio.Precio;            

            //  Obtenemos la zona del servicio
            Entities.Zonas zona = Entities.Zonas.Read((int)Servicio.Zona_ID);

            //  Si la zona es comisionada
            if (!AppHelper.IsNullOrEmpty(zona.ComisionServicio_ID))
            {
                //  Instanciamos una comisión, a partir de la zona
                Entities.ComisionesServicios comisionServicio = Entities.ComisionesServicios.Read((int)zona.ComisionServicio_ID);

                //  Calculamos la comision
                CalcularComision(comisionServicio);
            }

            //  Comision pronatura
            //  esta comisión es permamente
            //  La instanciamos y calculamos
            Entities.ComisionesServicios comisionPronatura =
                Entities.ComisionesServicios.Read(COMISIONPRONATURA_ID);

            CalcularComision(comisionPronatura);
        }

        /// <summary>
        /// Calcula la comisión a cobrar por el servicio
        /// </summary>
        /// <param name="comisionServicio">La comisión del serivcio</param>
        private void CalcularComision(Entities.ComisionesServicios comisionServicio)
        {
            //  Inicializamos la comisión 0
            decimal comision = 0;
            
            //  Determinamos el monto a partir del tipo de comisión
            //  y del precio

            //  Si el tipo es uno
            if (comisionServicio.TipoComision_ID == 1)
            {
                //  Es absoluto
                comision = comisionServicio.Monto;
            }
            else if (comisionServicio.TipoComision_ID == 2) // si el tipo es dos
            {
                //  Es porcentaje
                //  Lo calculamos
                comision = Servicio.Precio * (comisionServicio.Monto / (decimal)100);
            }

            //  Agregamos la comisión al paogo
            Servicio.PagoComisiones += comision;

            //  Reducimos el pago del conductor
            Servicio.PagoConductor = Servicio.Precio - Servicio.PagoComisiones;

            //  Agregamos la comisión a la lista
            Comisiones.Add(new Entities.Servicios_Comisiones(
                                            Servicio.Servicio_ID, comisionServicio.ComisionServicio_ID, Servicio.Ticket_ID, comision));
        }

        /// <summary>
        /// Asigna la productividad al servicio
        /// </summary>
        private void GetProductividad()
        { 
            //  Si el servicio es Tipo servicio conductor
            if (!AppHelper.IsNullOrEmpty(Servicio.TipoServicioConductor_ID))
            {
                //  Obtenemos el tipo de servicio
                Entities.TiposServiciosConductores tipoServicioConductor = Entities.TiposServiciosConductores.Read((int)Servicio.TipoServicioConductor_ID);
                
                //  Verificar si es valido como carrera
                //  Si es, productividad = 1
                if (tipoServicioConductor.EsValidoCarrera)
                {
                    Servicio.Productividad = 1;
                }
            }
            else // Si no
            {
                //  Tipo de Zona
                Entities.Zonas zona = Entities.Zonas.Read((int)Servicio.Zona_ID);
                Entities.TiposZonas tipoZona = Entities.TiposZonas.Read(zona.TipoZona_ID);

                //  Verificamos si la zona es acreditable
                if (tipoZona.EsAcreditable)
                {
                    //  Obtener la base de acreditación
                    decimal baseAcreditación = Convert.ToDecimal(Entities.VariablesNegocio.Read("BaseAcreditacion").Valor);

                    //  Dividir el precio entre la misma
                    decimal productividad = Servicio.Precio / baseAcreditación;

                    //  Si es menor que 1, entonces 1
                    if (productividad < 0) productividad = 1;

                    //  Caso contrario, el cociente es la productividad
                    Servicio.Productividad = productividad;
                }
                else // Si no, vale solo por uno
                {
                    Servicio.Productividad = 1;
                } // end else

            } // end else
         
        } // end void GetProductividad

        /// <summary>
        /// Obtiene el precio del servicio, 
        /// a partir de la zona y tipo de servicio
        /// </summary>
        private void GetPrecio()
        {
            Servicio.Precio = Entities.PrecioServicio.Get((int)Servicio.Zona_ID, Servicio.TipoServicio_ID, true).Precio;            
        }

        /// <summary>
        /// Obtiene la cuenta a la cual se cargará el servicio,
        /// a partir del tipo de servicio
        /// </summary>
        private void GetCuenta()
        {
            Entities.TiposServicios tipoServicio = Entities.TiposServicios.Read((int)Servicio.TipoServicio_ID);
            Servicio.Cuenta_ID = (int)tipoServicio.Cuenta_ID;
        }

        /// <summary>
        /// Ingresa los datos a la base de datos
        /// </summary>
	   private void DoInsert()
	   {
		   //  El listado de servicios
		   List<string> Servicios = new List<string>();

		   //  Contador
		   int i;

		   //  Obtenemos la productividad
		   GetProductividad();

		   //  Obtenemos la cuenta
		   GetCuenta();

		   //  Obtenemos las comisiones
		   GetComisiones();

		   //  Configuramos el servicio
		   Servicio.FolioDiario = Entities.Servicios.GetFolioDiario();
		   Servicio.Caja_ID = 4;
		   Servicio.ClaseServicio_ID = 1; // Aeropuerto - Ciudad
		   Servicio.Cliente_ID = null;
		   Servicio.Empresa_ID = Sesion.Empresa_ID.Value;
		   Servicio.Estacion_ID = Sesion.Estacion_ID;
		   Servicio.EstatusServicio_ID = 1; // Venta + Asignacion
		   Servicio.Fecha = DB.GetDate();
		   Servicio.FechaExpiracion = null;
		   Servicio.FechaPago = null;
		   Servicio.FechaServicio = null;
		   Servicio.Mercado_ID = 2; // Aeropuerto            
		   Servicio.Sesion_ID = null;
		   Servicio.Ticket_ID = null;
		   Servicio.TipoVenta_ID = GetTipoVenta();
		   Servicio.TipoServicioConductor_ID = null; // venta directa es de tipo cliente
		   Servicio.Usuario_ID = Sesion.Usuario_ID;
		   Servicio.Moneda_ID = 1;
		   Servicio.Unidad_ID = null;
		   Servicio.Conductor_ID = null;

		   //  Recorremos el contador, desde 1 hasta la cantidad de boletos deseada
		   for (i = 1; i <= Cantidad; i++)
		   {
			   //  Obtenemos el código
			   Servicio.Servicio_ID = Entities.Servicios.GenerarCodigoVenta();

			   //  Creamos el boleto en la base de datos
			   Servicio.Create();

			   //  Creamos las comisiones en la base de datos
			   foreach (Entities.Servicios_Comisiones sc in Comisiones)
			   {
				   sc.Servicio_ID = Servicio.Servicio_ID;
				   sc.Create();
			   }

			   //  Agregamos el servicio a la lista
			   Servicios.Add("'" + Servicio.Servicio_ID + "'");

			   //  Incrementamos el contador de folios diarios
			   Servicio.FolioDiario++;
		   }

		   this.Boletos = Entities.BoletoVenta.GetList(Servicios);
	   }
        
        /// <summary>
        /// El tipo de venta siempre es uno
        /// </summary>
        /// <returns></returns>
        private int? GetTipoVenta()
        {
            return 1;
        }

        /// <summary>
        /// Imprime el boleto utilizando el asistente de impresión
        /// </summary>
        private void DoPrint()
        {
            PrintHelper printer;

            foreach (Entities.BoletoVenta boleto in this.Boletos)
            {
                printer = new PrintHelper();

                printer.MeasureType = PrintHelper.MeasureTypes.Centimeters;
                printer.PrintDoc.DefaultPageSettings.PaperSize = new PaperSize("Boleto", 354, 799);
                
                //  Los folios
                printer.PrintText(boleto.FolioDiario.ToString(), 5.5f, 0.7f);
                printer.PrintText(boleto.FolioDiario.ToString(), 5.5f, 6.1f);
                printer.PrintText(boleto.FolioDiario.ToString(), 5.5f, 11.2f);

                //  La fecha
                printer.PrintText(boleto.Fecha.ToString("yyyy-MM-dd"), 2f, 1.6f);
                printer.PrintText(boleto.Fecha.ToString("yyyy-MM-dd"), 2f, 6.9f);
                printer.PrintText(boleto.Fecha.ToString("yyyy-MM-dd"), 2f, 12f);

                //  La vigencia
                printer.PrintText(boleto.Fecha.AddYears(1).ToString("yyyy-MM-dd"), 2f, 2f);
                printer.PrintText(boleto.Fecha.AddYears(1).ToString("yyyy-MM-dd"), 2f, 7.3f);
                printer.PrintText(boleto.Fecha.AddYears(1).ToString("yyyy-MM-dd"), 2f, 12.5f);

                //  La zona
                printer.PrintText(boleto.Zona, 2f, 2.6f);
                printer.PrintText(boleto.Zona, 2f, 7.8f);
                printer.PrintText(boleto.Zona, 2f, 12.9f);

                //  El precio
                printer.PrintText(boleto.Precio.ToString("c"), 2f, 3.1f);
                printer.PrintText(boleto.Precio.ToString("c"), 2f, 8.3f);
                printer.PrintText(boleto.Precio.ToString("c"), 2f, 13.4f);

                //  Los codigos de barras
                printer.PrintText("*" + boleto.Servicio_ID + "*", "Code 39", 3f, 4.1f);
                printer.PrintText(boleto.Servicio_ID, 3f, 4.7f);

                printer.PrintText("*" + boleto.Servicio_ID + "*", "Code 39", 3f, 9.1f);
                printer.PrintText(boleto.Servicio_ID, 3f, 9.7f);

                printer.Print();
            }               
        }
        
        /// <summary>
        /// Limpia la forma
        /// </summary>
        private void DoClear()
        {            
            buscarZonasBindingSource.Clear();
            AppHelper.ClearControl(this);
            Servicio = new Entities.Servicios();
            Servicio.TipoServicio_ID = DB.GetNullableInt32(this.TiposServiciosComboBox.SelectedValue);
        }

        /// <summary>
        /// Guarda los registros y manda e imprimir
        /// </summary>
        private void DoSave()
        {
            //  Efectuamos validaciones
            if (string.IsNullOrEmpty(CantidadTextBox.Text)) AppHelper.ThrowException("Debe capturar una cantidad");
            if (Sesion.Empresa_ID == null) throw new Exception("Debe tener configurada una empresa fija para utilizar esta opcion");
            
            //  Obtenemos la cantidad
            this.Cantidad = Convert.ToInt32(this.CantidadTextBox.Text);

            //  Insertamos
            DoInsert();

            //  Imprimimos
            DoPrint();

            //  Limpiamos
            DoClear();
        }

        #endregion

        /*
         * Esta region contiene los eventos
         * de los controles de la forma
         */
        #region Eventos

        /// <summary>
        /// Al teclear el nombre de la zona,
        /// buscamos sus coincidencias y las
        /// desplegamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NombreZonaTextBox_TextChanged(object sender, EventArgs e)
        {
            this.buscarZonasBindingSource.DataSource = Entities.BuscarZonas.Get(AppHelper.IsNull(this.NombreZonaTextBox.Text, "").ToString());
        }
        
        /// <summary>
        /// Al hacer clic en una zona:
        /// Obtenemos los datos de la misma y
        /// calculamos precio,
        /// actualizamos controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZonasListBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que tenga valor el objeto seleccionado
                if (this.ZonasListBox.SelectedItem != null && !Convert.IsDBNull(this.ZonasListBox.SelectedItem))
                {
                    //  Obtenemos la zona
                    Entities.BuscarZonas zona = (Entities.BuscarZonas)this.ZonasListBox.SelectedItem;
                    Servicio.Zona_ID = zona.Zona_ID;

                    //  Obtenemos el precio
                    GetPrecio();
         
                    //  Actualizamos los controles
                    Zona_IDTextBox.Text = zona.Zona_ID.ToString();
                    NombreZonaTextBox.Text = zona.Nombre;
                    PrecioTextBox.Text = AppHelper.N2(Servicio.Precio);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Al hacer clic en el botón, crear los servicios,
        /// agregarlos a la lista,
        /// mandarlos a imprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(
                new AppHelper.HelperDelegate(DoSave), 
                this
            );
        }

        /// <summary>
        /// Al seleccionar un tipo de servicio,
        /// actualizamos el objeto servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiposServiciosComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    if (!AppHelper.IsNullOrEmpty(TiposServiciosComboBox.SelectedItem))
                    {
                        Servicio.TipoServicio_ID = ((Entities.TiposServicios)TiposServiciosComboBox.SelectedItem).TipoServicio_ID;
                    }
                }
            );
        }

        /// <summary>
        /// Si oprimimos enter en la caja de texto del
        /// folio de la zona:
        /// Obtenemos la zona a partir del folio
        /// Obtenemos el precio
        /// Actualizamos la información de los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zona_IDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.Try(
                    delegate
                    {
                        //  Obtenemos el folio (ID) de zona
                        Servicio.Zona_ID = Convert.ToInt32(this.Zona_IDTextBox.Text);

                        //  Obtenemos la zona
                        Entities.Zonas zona = Entities.Zonas.Read(Servicio.Zona_ID.Value);

                        //  Obtenemos el precio
                        GetPrecio();

                        //  Actualizamos los controles
                        NombreZonaTextBox.Text = zona.Nombre;
                        PrecioTextBox.Text = AppHelper.N2(Servicio.Precio);
                    }
                ); // end AppHelper.Try
            } // end if Enter
        } // end KeyUp

        #endregion
    } // End Class
} // End Namespace
