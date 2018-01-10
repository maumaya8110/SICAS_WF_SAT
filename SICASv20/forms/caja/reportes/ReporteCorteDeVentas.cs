using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SICASv20.forms
{
    /// <summary>
    /// Muestra el formulario de Reporte de Corte de Ventas
    /// </summary>
    public partial class ReporteCorteDeVentas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de Reporte
        /// de corte de ventas
        /// </summary>
        public ReporteCorteDeVentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tablas de datos de sesión, de flujo de caja,
        /// de servicios, de venta y comisiones
        /// </summary>
        private DataTable dtsesion, dtflujo, dtservicios, dtventa, dtcomisiones;

        /// <summary>
        /// Contadores de boletos, de venta y de servicios de conductores
        /// </summary>
        private int cantidadventa = 0, cantidadservicios = 0;

        /// <summary>
        /// Totales de venta y de servicios de conductores
        /// </summary>
        private decimal totalventa = 0, totalservicios = 0;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {            
            //  Obtenemos los datos de la sesión
            dtsesion = Entities.Vista_DatosDeSesion.GetDataTable(Sesion.Sesion_ID);

            //  Ligamos los datos de la sesióna los controles
            this.Vista_DatosDeSesionBindingSource.DataSource = dtsesion;


            //  Obtenemos la tabla de flujo de caja
            dtflujo = Entities.Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado.GetDataTable(Sesion.Sesion_ID);

            //  Ligamos el flujo de caja a los controles
            this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource.DataSource = dtflujo;


            //  Obtenemos la tabla de servicios de conductores
            dtservicios = Entities.Vista_ServiciosConductorDeSesion_Consolidado.GetDataTable(Sesion.Sesion_ID);

            //  Ligamos los servicios de conductores a los controles
            this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource.DataSource = dtservicios;


            //  Obtenemos la tabla de servicios vendidos
            dtventa = Entities.Vista_VentasServiciosDeSesion_Consolidado.GetDataTable(Sesion.Sesion_ID);

            //  Ligamos los servicios vendidos a los controles
            this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource.DataSource = dtventa;


            //  Obtenemos la tabla de comisiones
            dtcomisiones = Entities.Vista_ComisionesVentaSesion.GetDataTable(Sesion.Sesion_ID);

            //  Ligamos las comusiones a los controles
            this.Vista_ComisionesVentaSesionBindingSource.DataSource = dtcomisiones;


            //  Recorremos la venta
            foreach (DataRow dr in dtventa.Rows)
            {
                //  Sumamos la cantidad para totalizar la sesión
                cantidadventa += Convert.ToInt32(dr["Cantidad"]);

                //  Sumamos el total para totalizar la sesión
                totalventa += Convert.ToDecimal(dr["Total"]);
            }

            //  Recorremos los servicios de conductor
            foreach (DataRow dr in dtservicios.Rows)
            {
                //  Sumamos la cantidad para totalizar la sesión
                cantidadservicios += Convert.ToInt32(dr["Cantidad"]);

                //  Sumamos el total para totalizar la sesión
                totalservicios += Convert.ToDecimal(dr["Total"]);
            }

            //  Refresamos el reporte
            this.ReporteCorteDeVentasReportViewer.RefreshReport();
            
            base.BindData();
        }

        /// <summary>
        /// Al cargar la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReporteCorteDeVentas_Load(object sender, EventArgs e)
        {
            // TODO
        }

        /// <summary>
        /// Imprime el reporte de corte directamente al puerto serial de impresión
        /// </summary>
        private void Imprimir()
        {
            //  Instanciamos un nuevo ayudante de impresión
            PrintHelper printer = new PrintHelper();

            //  Configuramos la impresión a archivo
            //printer.PrintToFile = true;

            ////  Configuramos la impresión al puerto
            //printer.PrintToPort = true;

            ////  Configuramos el puerto de impresión
            //printer.Port = "LPT1";

            //  Imprimimos los encabezados
            printer.PrintText("REPORTE DE CORTE DE VENTAS");
            printer.PrintCLRF();
            printer.PrintText("DATOS DE LA SESION");

            //  Imprimimos los datos de la sesión
            DataRow drsesion = dtsesion.Rows[0];

            printer.PrintText("CAJA:    {0}", drsesion["Caja"]);
            printer.PrintText("SESION:    {0}", drsesion["Sesion_ID"]);
            printer.PrintText("VENDEDOR:    {0}", drsesion["Vendedor"]);
            printer.PrintText("FECHAINICIAL:    {0}", drsesion["FechaInicial"]);
            printer.PrintText("FECHAFINAL:    {0}", drsesion["FechaFinal"]);

            printer.PrintCLRF();
            printer.PrintCLRF();
            printer.PrintLine();  
          
            //  Imprimimos la venta de servicios
            printer.PrintText("VENTA DE BOLETOS DE ZONAS");
            printer.PrintTable(dtventa);
            printer.PrintText("CANTIDAD:    {0}", cantidadventa);
            printer.PrintText("TOTAL:    {0:N2}", totalventa);

            printer.PrintCLRF();
            printer.PrintCLRF();
            printer.PrintLine();

            //  Imprimimos los servicios de conductores (boletos especiales)
            printer.PrintText("BOLETOS ESPECIALES");
            printer.PrintTable(dtservicios);
            printer.PrintText("CANTIDAD:    {0}", cantidadservicios);
            printer.PrintText("TOTAL:    {0:N2}", totalservicios);

            printer.PrintCLRF();
            printer.PrintCLRF();
            printer.PrintLine();

            //  Imprimimos el flujo de caja (por tipo de pago)
            printer.PrintText("RECAUDACION POR TIPO DE PAGO");
            printer.PrintTable(dtflujo);

            printer.PrintCLRF();
            printer.PrintCLRF();
            printer.PrintLine();

            //  Imprimimos las comisiones de la sesión
            printer.PrintText("COMISIONES");
            printer.PrintTable(dtcomisiones);

            //  Mandamos realizar la impresión
            printer.Print();

        } // end Imprimir

        /// <summary>
        /// Imprime el corte, cierra la sesión y sale del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CerrarSesionButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {                
                //  Solicitamos confirmación del cierre de sesión
                if (AppHelper.Confirm("¿Realmente desea cerrar la sesión?") == System.Windows.Forms.DialogResult.Yes)
                {
                    //  Mandamos imprimir el corte
                    Imprimir();


                    // Cerrar la sesión

                    //  Obtenemos el registro de la sesión actual
                    Entities.Sesiones sesion = Entities.Sesiones.Read(Sesion.Sesion_ID);

                    //  Desactivamos
                    sesion.Activo = false;

                    //  Configuramos fecha final
                    sesion.FechaFinal = DB.GetDate();

                    //  Actualizamos la base de datos
                    sesion.Update();

                    //  Cerramos el sistema
                    Padre.Close();

                } // end if

            }, this);

        } // end Click

    } // end class

} // end namespace
