using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SICASBot.Sync
{
    public partial class Syncronization
    {
        public class SyncAztlan
        {
            private void DoLog(string entry)
            {
                entry = String.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1}", DateTime.Now, entry);
                Console.WriteLine(entry);
                System.IO.StreamWriter sw = new System.IO.StreamWriter("log.txt", true);
                sw.WriteLine(entry);
                sw.Flush();
                sw.Close();
            }

            private void _DoSyncMetro()
            {
                SyncUsuarios();
                SyncSesiones();
                SyncUpdateSesiones();
                SyncModelosUnidades();
                SyncConcesiones();
                SyncUnidadesInit();
                SyncConductores();
                SyncDetalleConductores();
                SyncHistorialCobranzaConductores();
                SyncPlanesDeRenta();
                SyncContratos();
                SyncUpdateContratos();
                SyncContratosLiquidados();
                SyncCuentaCajas();
                SyncPlanillasFiscales();
                SyncTickets();
                SyncCuentaConductores();
                SyncCuentaDepositosGarantia();
                SyncTicketsCancelados();
                SyncUnidades_Kilometrajes();
                SyncUnidades_Locaciones();
                SyncValesPrepagados();
            }

            public void DoSyncMetro()
            {
                DateTime dt = new DateTime(2011, 11, 1, 5, 0, 0);
                if (DateTime.Now >= dt)
                {
                    return;
                }

                bool IsDebug = false;
                if (IsDebug)
                {
                    _DoSyncMetro();
                }
                else
                {
                    try
                    {                        
                        Console.WriteLine("Comenzando con la sincronizacion. Estacion: Aztlan");
                        DateTime fechaInicial = DateTime.Now;

                        DateTime ini, fin;
                        ini = DateTime.Now;

                        _DoSyncMetro();

                        fin = DateTime.Now;
                        TimeSpan diff;
                        diff = fin.Subtract(ini);
                        DoLog(string.Format("Fin: Tiempo: {0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds));
                        DateTime fechaFinal = DateTime.Now;
                        TimeSpan t = fechaFinal.Subtract(fechaInicial);
                        DoLog(String.Format("Tiempo total: {0} dias, {1} horas, {2} minutos y {3} segundos.",
                            t.Days, t.Hours, t.Minutes, t.Seconds));

                    }
                    catch (Exception ex)
                    {
                        DoLog(ex.Message);
                        DoLog(ex.StackTrace);
                        AppHelper.SendEmail("sicas@casco.com.mx", "lespino@prosyss.com", "Error en sincronización de SICAS",
                            DateTime.Now.ToString() + "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace, false);
                    }
                }
            }

            public void SyncHistorialCobranzaConductores()
            {
                List<Aztlan.Entities.HistorialConductor> historialcobranzaconductoresAztlan =
                    Aztlan.Entities.HistorialConductor.Read();
                foreach (Aztlan.Entities.HistorialConductor HistorialCobranzaConductoresAztlan in historialcobranzaconductoresAztlan)
                {
                    Central.Entities.HistorialCobranzaConductores centralHistorialCobranzaConductores = new Central.Entities.HistorialCobranzaConductores();

                    centralHistorialCobranzaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", HistorialCobranzaConductoresAztlan.Conductor)).Conductor_ID;
                    centralHistorialCobranzaConductores.Usuario_ID = HistorialCobranzaConductoresAztlan.Usuario.Replace("+", "").Replace("%c3%b1", "ñ");
                    centralHistorialCobranzaConductores.Estacion_ID = Estacion;
                    centralHistorialCobranzaConductores.Accion = HistorialCobranzaConductoresAztlan.Accion;
                    centralHistorialCobranzaConductores.Comentario = HistorialCobranzaConductoresAztlan.Comentario;
                    centralHistorialCobranzaConductores.Referencia_ID = HistorialCobranzaConductoresAztlan.Folio;
                    centralHistorialCobranzaConductores.Fecha = HistorialCobranzaConductoresAztlan.Fecha;


                    if (Central.DB.Exists("HistorialCobranzaConductores",
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", HistorialCobranzaConductoresAztlan.Folio)))
                    {
                        centralHistorialCobranzaConductores.Update();
                    }
                    else
                    {
                        centralHistorialCobranzaConductores.Create();
                    }

                    Console.WriteLine(string.Format("Historial conductor actualizado {0}", HistorialCobranzaConductoresAztlan.Folio));
                }	//	End foreach

            }	//	End Method SyncHistorialCobranzaConductores

            public void SyncCuentaDepositosGarantia()
            {
                List<Aztlan.Entities.CuentaDepositosGarantia> Depositos =
                    Aztlan.Entities.CuentaDepositosGarantia.Read();

                foreach (Aztlan.Entities.CuentaDepositosGarantia Deposito in Depositos)
                {
                    DateTime fecha = Deposito.FechaAlta;
                    Central.Entities.Conductores conductor = Central.Entities.Conductores.Read(
                            Param("Referencia_ID", Deposito.Conductor),
                            Param("Estacion_ID", Estacion)
                        );

                    if (conductor == null)
                    {
                        DoLog(
                            string.Format(
                                "Cuenta Depositos en Garantia, Conductor {0} no existe. Estacion {1}",
                                Deposito.Conductor,
                                Estacion
                            )
                        );
                        break;
                    }

                    if (!Central.DB.Exists(
                        "CuentaConductores",
                        Param("Cuenta_ID", 3),
                        Param("Concepto_ID", 6),
                        Param("Conductor_ID", conductor.Conductor_ID),
                        Param("Fecha", fecha)
                        ))
                    {
                        Central.Entities.CuentaConductores cc = new Central.Entities.CuentaConductores();
                        cc.Abono = Deposito.Monto;
                        cc.Caja_ID = Deposito.Caja;
                        cc.Cargo = 0;
                        cc.Comentarios = "#Ref = " + Deposito.Folio.ToString();
                        cc.Concepto_ID = 6;
                        cc.Conductor_ID = conductor.Conductor_ID;
                        cc.Cuenta_ID = 3;
                        cc.Empresa_ID = Empresa;
                        cc.Estacion_ID = Estacion;
                        cc.Fecha = fecha;
                        cc.Usuario_ID = Deposito.UsuarioAlta;
                        cc.Create();

                        Console.WriteLine(String.Format("Cuenta depositos en garantia {0} actualizado", Deposito.Folio));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Cuenta depositos en garantia {0} ya existe", Deposito.Folio));
                    }
                }
            }

            //  Contratos Liquidados
            public void SyncContratosLiquidados()
            {
                Console.WriteLine("Leyendo contratos liquidados");
                List<Aztlan.Entities.ContratosLiquidados> contratosliquidadosAztlan = Aztlan.Entities.ContratosLiquidados.Read();
                foreach (Aztlan.Entities.ContratosLiquidados ContratosLiquidadosAztlan in contratosliquidadosAztlan)
                {
                    Central.Entities.ContratosLiquidados centralContratosLiquidados = new Central.Entities.ContratosLiquidados();
                    centralContratosLiquidados.ContratoLiquidado_ID = ContratosLiquidadosAztlan.Folio;

                    centralContratosLiquidados.Contrato_ID =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosAztlan.Contrato)
                        ).Contrato_ID; // Consultar contrato

                    centralContratosLiquidados.Conductor_ID =
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosAztlan.Conductor)
                        ).Conductor_ID;

                    centralContratosLiquidados.Unidad_ID =
                        Central.Entities.Unidades.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosAztlan.Unidad)
                        ).Unidad_ID;

                    centralContratosLiquidados.LocacionUnidad_ID = LocacionCentral(ContratosLiquidadosAztlan.LocacionUnidad);

                    centralContratosLiquidados.EstatusConductor_ID =
                        (ContratosLiquidadosAztlan.StatusConductor == 1) ? 1 : ContratosLiquidadosAztlan.StatusConductor + 4;

                    centralContratosLiquidados.EstatusContrato_ID =
                        (ContratosLiquidadosAztlan.StatusContrato == 1) ? 1 : ContratosLiquidadosAztlan.StatusContrato + 7;

                    centralContratosLiquidados.Comentarios = ContratosLiquidadosAztlan.Comentario;
                    centralContratosLiquidados.Fecha = ContratosLiquidadosAztlan.Fecha;
                    centralContratosLiquidados.Usuario_ID = ContratosLiquidadosAztlan.Usuario.Trim();


                    if (Central.DB.Exists("ContratosLiquidados", Param("ContratoLiquidado_ID", centralContratosLiquidados.ContratoLiquidado_ID)))
                    {
                        centralContratosLiquidados.Update();
                    }
                    else
                    {
                        centralContratosLiquidados.Create();
                    }

                    Console.WriteLine(string.Format("Actualizado contrato liquidado {0}", ContratosLiquidadosAztlan.Folio));
                }	//	End foreach

            }	//	End Method SyncContratosLiquidados

            //  Actualizar contratos
            public void SyncUpdateContratos()
            {
                Console.WriteLine("Update Contratos");

                List<Aztlan.Entities.Contratos> ContratosLA = Aztlan.Entities.Contratos.Read();
                foreach (Aztlan.Entities.Contratos contrato in ContratosLA)
                {
                    Central.Entities.Contratos c =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", contrato.Folio));

                    c.FechaFinal = contrato.FechaFinal;
                    c.EstatusContrato_ID = (contrato.Status == 1) ? 1 : contrato.Status + 7;
                    c.Update("FechaFinal", "EstatusContrato_ID", "MontoDiario");
                    c.MontoDiario = contrato.Planes.RentaBase;
                    Console.WriteLine(string.Format("Actualizado contrato {0}:", contrato.Folio));
                }
            }


            public void SyncPlanesDeRenta()
            {
                List<Aztlan.Entities.Planes> planesderentaAztlan = Aztlan.Entities.Planes.Read();
                foreach (Aztlan.Entities.Planes PlanesDeRentaAztlan in planesderentaAztlan)
                {
                    Central.Entities.PlanesDeRenta centralPlanesDeRenta = new Central.Entities.PlanesDeRenta();
                    centralPlanesDeRenta.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(
                        Param("Referencia_id",
                        (int)PlanesDeRentaAztlan.Modelo),
                        Param("EmpresaReferencia", Estacion)
                        ).ModeloUnidad_ID;
                    centralPlanesDeRenta.Usuario_ID = PlanesDeRentaAztlan.UsuarioAlta;
                    centralPlanesDeRenta.DiasDeCobro_ID = PlanesDeRentaAztlan.DiasDeCobro.Value;
                    centralPlanesDeRenta.Descripcion = PlanesDeRentaAztlan.Descripcion;
                    centralPlanesDeRenta.RentaBase = PlanesDeRentaAztlan.RentaBase;
                    centralPlanesDeRenta.FondoResidual = PlanesDeRentaAztlan.FondoResidual;
                    centralPlanesDeRenta.Fecha = PlanesDeRentaAztlan.FechaAlta;
                    centralPlanesDeRenta.Activo = (PlanesDeRentaAztlan.Status == 1);
                    centralPlanesDeRenta.Referencia_ID = PlanesDeRentaAztlan.Folio;
                    centralPlanesDeRenta.Estacion_ID = Estacion;


                    if (Central.DB.Exists(
                        "PlanesDeRenta",
                        Param("Referencia_ID", centralPlanesDeRenta.Referencia_ID),
                        Param("Estacion_ID", Estacion)
                        )
                        )
                    {
                        centralPlanesDeRenta.Update();
                    }
                    else
                    {
                        centralPlanesDeRenta.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Plan de Renta: {0}", PlanesDeRentaAztlan.Folio));

                }	//	End foreach

            }	//	End Method SyncPlanesDeRenta

            public void SyncDetalleConductores()
            {
                //string filter = "Conductor > @Conductor AND MensajeACaja IS NOT NULL";

                //string sort = "Conductor ASC";

                //Aztlan.Entities.DetalleConductor ConductoresAztlan;
                Console.WriteLine("Leyendo detalle conductores");
                int folio = 0;

                int count = Aztlan.DB.GetCount("DetalleConductor");
                int cont = 0;

                List<Aztlan.Entities.DetalleConductor> DetallesConductor = Aztlan.Entities.DetalleConductor.Read();
                foreach (Aztlan.Entities.DetalleConductor ConductoresAztlan in DetallesConductor)
                {
                    cont++;
                    folio = ConductoresAztlan.Conductor;

                    Central.Entities.Conductores centralConductor =
                        Central.Entities.Conductores.Read(
                        Param("Referencia_ID", folio),
                        Param("Estacion_ID", Estacion));

                    centralConductor.BloquearConductor = ConductoresAztlan.BloquearConductor;
                    centralConductor.Cronocasco = ConductoresAztlan.Cronocasco;
                    centralConductor.MensajeACaja = ConductoresAztlan.MensajeACaja;
                    centralConductor.SaldoATratar = ConductoresAztlan.SaldoATratar;
                    centralConductor.TerminalDatos = ConductoresAztlan.TerminalDatos;
                    centralConductor.Update();

                    Console.WriteLine(String.Format("Registro actualizado DetalleConductor_ID: {0}, {1} de {2}",
                        centralConductor.Referencia_ID, cont, count));
                }

                //while (Aztlan.Entities.DetalleConductor.Read(out ConductoresAztlan, 1, filter, sort, Param("Conductor", folio)))
                //{

                //}

            }   //  End Method

            public void SyncUpdateSesiones()
            {
                List<Aztlan.Entities.ControlCajas> Sesiones = Aztlan.Entities.ControlCajas.Read();
                foreach (Aztlan.Entities.ControlCajas SesionesAztlan in Sesiones)
                {
                    int sesion = SesionesAztlan.Sesion;

                    Central.Entities.Sesiones centralSesiones =
                        Central.Entities.Sesiones.Read(
                        Param("Referencia_ID", sesion),
                        Param("Estacion_ID", Estacion));

                    centralSesiones.FechaInicial = SesionesAztlan.Inicio;
                    centralSesiones.FechaFinal = SesionesAztlan.Corte;
                    centralSesiones.Activo = (SesionesAztlan.Corte == null) ? true : false;

                    if (Central.DB.Exists("Sesiones", Param("Sesion_ID", centralSesiones.Sesion_ID)))
                    {
                        centralSesiones.Update();
                    }
                    else
                    {
                        centralSesiones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Sesion_ID: {0}", centralSesiones.Sesion_ID));
                }
            }

            public void DoSyncTaller()
            {
                try
                {
                    //DateTime fechaInicial = DateTime.Now;
                    while (true)
                    {
                        //  Usuarios
                        SyncUsuarios();

                        //  Familias
                        SyncFamilias();

                        //  Tipos de refacciones
                        SyncTiposRefacciones();

                        //  Marcas de refacciones
                        SyncMarcasRefacciones();

                        //  Modelos
                        SyncModelos();

                        //  Refacciones
                        SyncRefacciones();

                        //  Servicios
                        SyncServiciosMantenimientos();

                        //  Servicios tipos de refacciones
                        SyncServiciosMantenimientos_TiposRefacciones();

                        //  Categorias de Mecánicos                
                        SyncCategoriasMecanicos();

                        //Estatus de Mecánicos
                        SyncEstatusMecanicos();

                        //  Mecanicos
                        SyncMecanicos();

                        // Estatus Ordenes Trabajo
                        SyncEstatusOrdenesTrabajos();

                        //  Tipos Mantenimientos
                        SyncTiposMantenimientos();

                        //  Ordenes de trabajo
                        SyncOrdenesTrabajos();

                        // Estatus ordenes compras
                        SyncEstatusOrdenesCompras();

                        // Estatus ordenes servicios
                        SyncEstatusOrdenesServicios();

                        //  Ordenes de servicio
                        SyncOrdenesServicios();

                        //  refacciones int
                        //SyncRefacciones(0);

                        //  Ordenes de servicio refacciones
                        SyncOrdenesServiciosRefacciones();

                        //  Cancelaciones de ordenes de trabajo
                        SyncCancelacionesOrdenesTrabajos();

                        //  Proveedores
                        //  donde proveedor sea 0, obtener el de mayor porcentaje y pasarlo al mismo
                        //  Ordenes de compras
                        SyncOrdenesCompras();

                        //  Compras
                        SyncCompras();

                        //  Cancelaciones de compras
                        SyncOrdenesComprasCanceladas();

                        //  Notas de almacen
                        SyncNotasAlmacen();

                        //  Ajustes de inventario
                        SyncAjustesInventario();

                        //  Movimientos de inventario
                        SyncMovimientosInventario();
                    }

                    //DateTime fechaFinal = DateTime.Now;
                    //TimeSpan t = fechaFinal.Subtract(fechaInicial);
                    //DoLog(String.Format("Tiempo total: {0} dias, {1} horas, {2} minutos y {3} segundos.", 
                    //    t.Days, t.Hours, t.Minutes, t.Seconds));

                    //Console.Read();

                }
                catch (Exception ex)
                {
                    DoLog(ex.Message);
                    DoLog(ex.StackTrace);
                    //Console.ReadLine();
                    AppHelper.SendEmail("sicas@casco.com.mx", "lespino@prosyss.com", "Error en sincronización de SICAS",
                        DateTime.Now.ToString() + "\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace, false);
                }
            }

            private int Estacion = 10; // Aztlan
            private int Empresa = 2; // CAM

            private KeyValuePair<string, object> Param(string key, object value)
            {
                return new KeyValuePair<string, object>(key, value);
            }

            //  Estatus de ordenes de compras
            public void SyncEstatusOrdenesCompras()
            {
                List<Aztlan.Entities.StatusOrdenesCompra> estatusordenescomprasAztlan = Aztlan.Entities.StatusOrdenesCompra.Read();
                foreach (Aztlan.Entities.StatusOrdenesCompra EstatusOrdenesComprasAztlan in estatusordenescomprasAztlan)
                {
                    Central.Entities.EstatusOrdenesCompras centralEstatusOrdenesCompras = new Central.Entities.EstatusOrdenesCompras();
                    centralEstatusOrdenesCompras.EstatusOrdenCompra_ID = EstatusOrdenesComprasAztlan.Folio;
                    centralEstatusOrdenesCompras.Nombre = EstatusOrdenesComprasAztlan.Descripcion;


                    if (Central.DB.Exists("EstatusOrdenesCompras", Param("EstatusOrdenCompra_ID", centralEstatusOrdenesCompras.EstatusOrdenCompra_ID)))
                    {
                        centralEstatusOrdenesCompras.Update();
                    }
                    else
                    {
                        centralEstatusOrdenesCompras.Create(true);
                    }
                }	//	End foreach

            }	//	End Method SyncEstatusOrdenesCompras

            public void SyncEstatusOrdenesServicios()
            {
                List<Aztlan.Entities.StatusOrdenesServicio> estatusordenesserviciosAztlan = Aztlan.Entities.StatusOrdenesServicio.Read();
                foreach (Aztlan.Entities.StatusOrdenesServicio EstatusOrdenesServiciosAztlan in estatusordenesserviciosAztlan)
                {
                    Central.Entities.EstatusOrdenesServicios centralEstatusOrdenesServicios = new Central.Entities.EstatusOrdenesServicios();
                    centralEstatusOrdenesServicios.EstatusOrdenServicio_ID = EstatusOrdenesServiciosAztlan.Folio;
                    centralEstatusOrdenesServicios.Nombre = EstatusOrdenesServiciosAztlan.Descripcion;


                    if (Central.DB.Exists("EstatusOrdenesServicios", Param("EstatusOrdenServicio_ID", centralEstatusOrdenesServicios.EstatusOrdenServicio_ID)))
                    {
                        centralEstatusOrdenesServicios.Update();
                    }
                    else
                    {
                        centralEstatusOrdenesServicios.Create(true);
                    }
                }	//	End foreach

            }	//	End Method SyncEstatusOrdenesServicios

            //  AjustesInventario
            public void SyncAjustesInventario()
            {
                /*
                 * Tiene folio, pasar a read
                 */
                List<Aztlan.Entities.MovimientosDirectosAInventario> movsInventario = new List<Aztlan.Entities.MovimientosDirectosAInventario>();
                movsInventario = Aztlan.Entities.MovimientosDirectosAInventario.Read();

                foreach (Aztlan.Entities.MovimientosDirectosAInventario mov in movsInventario)
                {
                    Central.Entities.AjustesInventario ajuste = new Central.Entities.AjustesInventario();
                    ajuste.Cantidad = Convert.ToInt32(mov.Cantidad);
                    ajuste.Comentarios = mov.Comentarios;
                    ajuste.CostoUnitario = (decimal)mov.CostoUnitario;
                    ajuste.Fecha = (DateTime)mov.Fecha;
                    ajuste.Refaccion_ID = (int)mov.Refaccion;
                    ajuste.TipoMovimientoInventario_ID = (mov.TipoMovimiento == 'E') ? 1 : 2;
                    ajuste.Total = (decimal)mov.Total;
                    ajuste.Usuario_ID = mov.Usuario;
                    ajuste.AjusteInventario_ID = mov.Folio;

                    if (Central.DB.Exists("AjustesInventario", Param("AjusteInventario_ID", ajuste.AjusteInventario_ID)))
                    {
                        ajuste.Update();
                    }
                    else
                    {
                        ajuste.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado AjusteInventario_ID: {0}", ajuste.AjusteInventario_ID));
                }
            }

            //  CancelacionesOrdenesTrabajos
            public void SyncCancelacionesOrdenesTrabajos()
            {
                /*
                 * Tiene folio, pasar a read
                 */
                List<Aztlan.Entities.OrdenesTrabajoCanceladas> ordenesCanceladas = Aztlan.Entities.OrdenesTrabajoCanceladas.Read();

                foreach (Aztlan.Entities.OrdenesTrabajoCanceladas ordenCancelada in ordenesCanceladas)
                {
                    Central.Entities.CancelacionesOrdenesTrabajos cancelacion = new Central.Entities.CancelacionesOrdenesTrabajos();
                    cancelacion.Comentarios = ordenCancelada.Motivos;
                    cancelacion.Fecha = ordenCancelada.Fecha;
                    cancelacion.OrdenTrabajo_ID = ordenCancelada.OrdenTrabajo;
                    cancelacion.Usuario_ID = ordenCancelada.Usuario;

                    if (Central.DB.Exists("CancelacionesOrdenesTrabajos", Param("OrdenTrabajo_ID", cancelacion.OrdenTrabajo_ID)))
                    {
                        cancelacion.Update();
                    }
                    else
                    {
                        cancelacion.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenTrabajo_ID Cancelacion: {0}", cancelacion.OrdenTrabajo_ID));
                }
            }

            //  CategoriasMecanicos
            public void SyncCategoriasMecanicos()
            {
                List<Aztlan.Entities.CategoriasMecanicos> categoriasAztlan = Aztlan.Entities.CategoriasMecanicos.Read();

                foreach (Aztlan.Entities.CategoriasMecanicos Aztlancategoria in categoriasAztlan)
                {
                    Central.Entities.CategoriasMecanicos centralCategoria = new Central.Entities.CategoriasMecanicos();
                    centralCategoria.CategoriaMecanico_ID = Aztlancategoria.Folio;
                    centralCategoria.Familia_ID = Aztlancategoria.Familia;
                    centralCategoria.Nombre = Aztlancategoria.Descripcion;

                    if (Central.DB.Exists("CategoriasMecanicos", Param("CategoriaMecanico_ID", centralCategoria.CategoriaMecanico_ID)))
                    {
                        centralCategoria.Update();
                    }
                    else
                    {
                        centralCategoria.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado CategoriaMecanico_ID: {0}", centralCategoria.CategoriaMecanico_ID));
                }
            }

            //  Compras
            public void SyncCompras()
            {
                //  Obtener el listado de ordenes de compras faltantes
                //  Donde hay ordenes de compra que no hay en compras
                //  Para cada una de ellas
                string strSQL = "SELECT	DISTINCT OrdenCompra_ID \r\n " +
                    "FROM	OrdenesCompras \r\n " +
                    "WHERE	OrdenCompra_ID \r\n " +
                    "NOT IN	(SELECT DISTINCT OrdenCompra_ID FROM Compras) \r\n " +
                    "AND		OrdenCompra_ID NOT IN (SELECT OrdenCompra_ID FROM OrdenesComprasCanceladas)";

                System.Data.DataTable dt = Central.DB.Query(strSQL);
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    int ordencompra = Convert.ToInt32(dr["OrdenCompra_ID"]);
                    List<Aztlan.Entities.Compras> comprasAztlan = Aztlan.Entities.Compras.Read(Param("OrdenCompra", ordencompra));

                    foreach (Aztlan.Entities.Compras Aztlancompra in comprasAztlan)
                    {
                        Central.Entities.Compras centralCompra = new Central.Entities.Compras();
                        centralCompra.Cantidad = Aztlancompra.Cantidad;
                        centralCompra.Compra_ID = 0;
                        centralCompra.CostoUnitario = Aztlancompra.CostoUnitario;
                        centralCompra.Fecha = Aztlancompra.FechaAlta;
                        centralCompra.MarcaRefaccion_ID = Aztlancompra.Marca;
                        centralCompra.OrdenCompra_ID = Aztlancompra.OrdenCompra;
                        centralCompra.Refaccion_ID = Aztlancompra.Refaccion;
                        centralCompra.RefaccionesSurtidas = (int)Central.DB.GetNullableInt32(Aztlancompra.RefSurtidas);
                        centralCompra.Usuario_ID = Aztlancompra.UsuarioAlta;

                        if (Central.DB.Exists("Compras", Param("OrdenCompra_ID", centralCompra.OrdenCompra_ID),
                                Param("Refaccion_ID", centralCompra.Refaccion_ID),
                                    Param("MarcaRefaccion_ID", centralCompra.MarcaRefaccion_ID)))
                        {
                            //  Consulta la compra ID
                            centralCompra.Compra_ID =
                                Convert.ToInt32(Central.DB.ReadScalar("Compras", "Compra_ID",
                                    Param("OrdenCompra_ID", centralCompra.OrdenCompra_ID),
                                        Param("Refaccion_ID", centralCompra.Refaccion_ID),
                                            Param("MarcaRefaccion_ID", centralCompra.MarcaRefaccion_ID)));

                            centralCompra.Update();
                        }
                        else
                        {
                            centralCompra.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado OrdenCompra_ID: {0}", centralCompra.OrdenCompra_ID));
                    }
                }
            }

            //  Concesiones            
            public void SyncConcesiones()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Concesion_ID),0) folio FROM Concesiones WHERE EstacionReferencia_ID = @Estacion";

                Aztlan.Entities.Concesiones ConcesionesAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.Concesiones.Read(out ConcesionesAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConcesionesAztlan.Folio;

                    Central.Entities.Concesiones centralConcesion = new Central.Entities.Concesiones();
                    centralConcesion.Activo = (ConcesionesAztlan.Status == 1) ? true : false;

                    centralConcesion.Placa = ConcesionesAztlan.Placa;
                    centralConcesion.Referencia_ID = ConcesionesAztlan.Folio;
                    centralConcesion.TipoConcesion_ID = ConcesionesAztlan.Tipo;
                    centralConcesion.EstacionReferencia_ID = Estacion;
                    centralConcesion.NumeroConcesion = "";
                    centralConcesion.Empresa_ID = Empresa;

                    if (Central.DB.Exists("Concesiones",
                                Param("Placa", centralConcesion.Placa),
                                    Param("Referencia_ID", centralConcesion.Referencia_ID),
                                        Param("EstacionReferencia_ID", Estacion)))
                    {
                        //  Consulta la concesion_ID
                        centralConcesion.Concesion_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Concesiones", "Concesion_ID",
                                    Param("Placa", centralConcesion.Placa),
                                        Param("Referencia_ID", centralConcesion.Referencia_ID),
                                            Param("EstacionReferencia_ID", Estacion)));

                        centralConcesion.Update();
                    }
                    else
                    {
                        centralConcesion.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Concesion_ID: {0}", centralConcesion.Concesion_ID));
                }
            }   //  End method

            //  Conductores
            public void SyncConductores()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Conductores WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.Conductores ConductoresAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.Conductores.Read(out ConductoresAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConductoresAztlan.Folio;

                    Central.Entities.Conductores centralConductor = new Central.Entities.Conductores();
                    centralConductor.ActaNacimiento = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.ActaNacimiento;
                    centralConductor.AñosExperiencia = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? null : (Int32?)(AppHelper.IsNull(ConductoresAztlan.RegistroPublicitarioConductor.AñosExperiencia, 0));
                    centralConductor.Apellidos = ConductoresAztlan.ApellidoPaterno + " " + ConductoresAztlan.ApellidoMaterno;
                    centralConductor.Apellidos_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.ApellidoPaterno + " " + ConductoresAztlan.AvalConductor.ApellidoMaterno;
                    centralConductor.BloquearConductor = (ConductoresAztlan.Detalle == null) ? false : ConductoresAztlan.Detalle.BloquearConductor;
                    centralConductor.CartaNoAntecedentes = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.CartaNoAntecedentes;
                    centralConductor.Ciudad = ConductoresAztlan.Ciudad;
                    centralConductor.Ciudad_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Ciudad;
                    centralConductor.CodigoPostal = ConductoresAztlan.CP.ToString();
                    centralConductor.CodigoPostal_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.CP.ToString();
                    centralConductor.Comentarios = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? "" : ConductoresAztlan.RegistroPublicitarioConductor.Comentarios;
                    centralConductor.ComprobanteDomicilio = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.ComprobanteDomicilio;
                    centralConductor.ComprobanteDomicilio_Aval = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.ComprobanteDomicilioAval;
                    centralConductor.Conductor_ID = 0;
                    centralConductor.CredencialElector = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.CredencialElector;
                    centralConductor.CredencialElector_Aval = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.CredencialElectorAval;
                    centralConductor.Cronocasco = (ConductoresAztlan.Detalle == null) ? false : ConductoresAztlan.Detalle.Cronocasco;
                    centralConductor.CumplioPerfil = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? false : ConductoresAztlan.RegistroPublicitarioConductor.CumplioPerfil;
                    centralConductor.CURP = ConductoresAztlan.Curp;
                    centralConductor.Curp_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Curp;
                    centralConductor.Domicilio = ConductoresAztlan.Calle + " No. " + ConductoresAztlan.NumeroCasa + ", Col. " + ConductoresAztlan.Colonia;
                    centralConductor.Domicilio_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Calle + " No. " + ConductoresAztlan.AvalConductor.NumeroCasa + ", Col. " + ConductoresAztlan.AvalConductor.Colonia;
                    centralConductor.Edad = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? null : (int?)(AppHelper.IsNull(ConductoresAztlan.RegistroPublicitarioConductor.Edad, 0));
                    centralConductor.Email = ConductoresAztlan.CorreoElectronico;
                    centralConductor.Email_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.CorreoElectronico;
                    centralConductor.Entidad = ConductoresAztlan.Estado;
                    centralConductor.Estacion_ID = this.Estacion; // Aztlan
                    centralConductor.Estado_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Estado;
                    centralConductor.EstadoCivil = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? "" : ConductoresAztlan.RegistroPublicitarioConductor.EstadoCivil;
                    centralConductor.EstatusConductor_ID = (ConductoresAztlan.Status == 1) ? 1 : ConductoresAztlan.Status + 4; // Convertir
                    centralConductor.Fecha = ConductoresAztlan.FechaAlta;
                    centralConductor.FolioLicencia = (ConductoresAztlan.Licencia == null) ? "" : ConductoresAztlan.Licencia.Folio.ToString();
                    centralConductor.Fotografia = null; //    Esta no se lleva    // Hay que actualizar el proceso de creación y actualización
                    centralConductor.Genero = "M";
                    centralConductor.Interesado = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? false : ConductoresAztlan.RegistroPublicitarioConductor.Interesado;
                    centralConductor.MedioPublicitario_ID = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresAztlan.RegistroPublicitarioConductor.MedioPublicitario;
                    centralConductor.MensajeACaja = (ConductoresAztlan.Detalle == null) ? "" : ConductoresAztlan.Detalle.MensajeACaja;
                    centralConductor.Mercado_ID = (ConductoresAztlan.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresAztlan.RegistroPublicitarioConductor.PlanEmpresarial; // Hay que hacer el mapeo correcto
                    centralConductor.Movil = null;
                    centralConductor.Nombre = ConductoresAztlan.Nombre;
                    centralConductor.Nombre_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Nombre;
                    centralConductor.Referencia_ID = ConductoresAztlan.Folio;
                    centralConductor.RFC = ConductoresAztlan.Rfc;
                    centralConductor.Rfc_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Rfc;
                    centralConductor.SaldoATratar = (ConductoresAztlan.Detalle == null) ? 0 : ConductoresAztlan.Detalle.SaldoATratar;
                    centralConductor.Solicitud = (ConductoresAztlan.DocumentacionConductor == null) ? "" : ConductoresAztlan.DocumentacionConductor.Solicitud;
                    centralConductor.Telefono = ConductoresAztlan.Telefono;
                    centralConductor.Telefono_Aval = (ConductoresAztlan.AvalConductor == null) ? "" : ConductoresAztlan.AvalConductor.Telefono;
                    centralConductor.Telefono2 = null;
                    centralConductor.TerminalDatos = (ConductoresAztlan.Detalle == null) ? false : ConductoresAztlan.Detalle.TerminalDatos;
                    centralConductor.TipoLicencia_ID = (ConductoresAztlan.Licencia == null) ? null : (int?)ConductoresAztlan.Licencia.Tipo; // Revisar si entra directo
                    centralConductor.Usuario_ID = ConductoresAztlan.UsuarioAlta;
                    centralConductor.VenceLicencia = (ConductoresAztlan.Licencia == null) ? null : (DateTime?)ConductoresAztlan.Licencia.FechaVencimiento;

                    if (Central.DB.Exists("Conductores", Param("Estacion_ID", Estacion), Param("Referencia_ID", centralConductor.Referencia_ID)))
                    {
                        //  Get Conductor_ID
                        centralConductor.Conductor_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Conductores", "Conductor_ID",
                                Param("Estacion_ID", Estacion),
                                    Param("Referencia_ID", centralConductor.Referencia_ID)));
                        centralConductor.Update();
                    }
                    else
                    {
                        centralConductor.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Conductor_ID: {0}", centralConductor.Conductor_ID));
                }

                //List<Aztlan.Entities.Conductores> conductoresAztlan = Aztlan.Entities.Conductores.Read();

                //foreach (Aztlan.Entities.Conductores Aztlanconductor in conductoresAztlan)
                //{

                //}   //  End foreach
            }   //  End Method

            //  Contratos
            public void SyncContratos()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Contratos WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.Contratos ContratosAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.Contratos.Read(out ContratosAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ContratosAztlan.Folio;

                    Central.Entities.Contratos centralContrato = new Central.Entities.Contratos();
                    centralContrato.CobroPermanente = (ContratosAztlan.FechaFinal == null) ? true : false;
                    centralContrato.Comentarios = "";
                    centralContrato.Concepto_ID = 1;
                    centralContrato.Conductor_ID = Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", ContratosAztlan.Conductor)).Conductor_ID;

                    // Si no existe el conductor copia, insertarlo y relacionarlo
                    if (ContratosAztlan.Copia == null)
                    {
                        centralContrato.ConductorCopia_ID = null;
                    }
                    else
                    {
                        Central.Entities.Conductores cond = Central.Entities.Conductores.Read(Param("Rfc", ContratosAztlan.Copia.Rfc));
                        if (cond == null)
                        {
                            //  Insertar conductor en Central
                            //  a partir de contratos copia
                            cond = new Central.Entities.Conductores();
                            cond.Apellidos = ContratosAztlan.Copia.ApellidoPaterno + " " + ContratosAztlan.Copia.ApellidoMaterno;
                            cond.Domicilio = ContratosAztlan.Copia.Colonia + ", " + ContratosAztlan.Copia.Calle + " No. " + ContratosAztlan.Copia.NumeroCasa;
                            cond.Ciudad = ContratosAztlan.Copia.Ciudad;
                            cond.Email = ContratosAztlan.Copia.CorreoElectronico;
                            cond.CodigoPostal = ContratosAztlan.Copia.CP.ToString();
                            cond.CURP = ContratosAztlan.Copia.Curp;
                            cond.Entidad = ContratosAztlan.Copia.Estado;
                            cond.Fecha = ContratosAztlan.Copia.FechaAlta;
                            cond.Nombre = ContratosAztlan.Copia.Nombre;
                            cond.RFC = ContratosAztlan.Copia.Rfc;
                            cond.Telefono = ContratosAztlan.Copia.Telefono;
                            cond.Usuario_ID = ContratosAztlan.Copia.UsuarioAlta;
                            cond.Estacion_ID = Estacion;
                            cond.EstatusConductor_ID = 1;
                            cond.Create();
                            centralContrato.ConductorCopia_ID = cond.Conductor_ID;
                        }
                        else
                        {
                            centralContrato.ConductorCopia_ID = cond.Conductor_ID;
                        }
                    }

                    centralContrato.Contrato_ID = 0; // A actualizar si es update
                    centralContrato.Cuenta_ID = 1;
                    centralContrato.Descripcion = "Contrato de renta folio " + ContratosAztlan.Folio.ToString();

                    //  Obtener los días de cobro
                    centralContrato.DiasDeCobro_ID = (int)ContratosAztlan.Planes.DiasDeCobro;

                    if (ContratosAztlan.Tipo == 3)
                    {
                        centralContrato.Empresa_ID = 5; // CCR
                    }
                    else
                    {
                        centralContrato.Empresa_ID = Empresa; // CAM
                    }
                    centralContrato.Estacion_ID = Estacion;
                    centralContrato.EstatusContrato_ID = (ContratosAztlan.Status == 1) ? 1 : ContratosAztlan.Status + 7;
                    centralContrato.FechaFinal = Central.DB.GetNullableDateTime(ContratosAztlan.FechaFinal);
                    centralContrato.FechaInicial = ContratosAztlan.FechaInicial;
                    centralContrato.FondoResidual = Convert.ToInt32(AppHelper.IsNull(ContratosAztlan.Planes.FondoResidual, 0));
                    centralContrato.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(Param("referencia_id", (int)ContratosAztlan.Planes.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralContrato.MontoDiario = ContratosAztlan.Planes.RentaBase;
                    centralContrato.NumeroEconomico =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosAztlan.Unidad)).NumeroEconomico;
                    centralContrato.TipoContrato_ID = (ContratosAztlan.Tipo == 3) ? 2 : ContratosAztlan.Tipo; // Si 3 entonces es CCR
                    centralContrato.Unidad_ID = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosAztlan.Unidad)).Unidad_ID;
                    centralContrato.Referencia_ID = folio;
                    if (Central.DB.Exists("Contratos", Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosAztlan.Folio)))
                    {
                        //  Obtener el contrato ID
                        centralContrato.Contrato_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Contratos", "Contrato_ID",
                                Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosAztlan.Folio)));
                        centralContrato.Update();
                    }
                    else
                    {
                        centralContrato.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Contrato_ID: {0}", centralContrato.Contrato_ID));
                }

            }   //  End Method

            //  Usuarios
            public void SyncUsuarios()
            {
                List<Aztlan.Entities.Usuarios> usuariosAztlan = Aztlan.Entities.Usuarios.Read();
                foreach (Aztlan.Entities.Usuarios usuarioAztlan in usuariosAztlan)
                {
                    Central.Entities.Usuarios usuario = new Central.Entities.Usuarios();
                    usuario.Activo = (usuarioAztlan.Status == 1) ? true : false;
                    usuario.Apellidos = usuarioAztlan.ApellidoPaterno + " " + usuarioAztlan.ApellidoMaterno;
                    usuario.Email = "";
                    usuario.Empresa_ID = Empresa; // CAM
                    usuario.Estacion_ID = Estacion; // Aztlan
                    usuario.Nombre = usuarioAztlan.Nombre;
                    usuario.pwd = (byte[])Central.DB.QueryScalar(String.Format("SELECT PWDENCRYPT('{0}')", usuarioAztlan.Pwd));
                    usuario.Usuario_ID = usuarioAztlan.Clave;

                    // if exists update else insert
                    if (Central.DB.Exists("Usuarios", Param("Usuario_ID", usuario.Usuario_ID)))
                    {
                        usuario.Update();
                    }
                    else
                    {
                        usuario.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Usuario: {0}", usuario.Usuario_ID));
                    AppHelper.ReconfigureUsuarios();
                }
            }

            private int CuentaDeFondo(int fondo)
            {
                int cuenta = 0;

                switch (fondo)
                {
                    case 1: cuenta = 1; break;
                    case 2: cuenta = 2; break;
                    case 3: cuenta = 3; break;
                    case 5: cuenta = 4; break;
                    case 11: cuenta = 5; break;
                    case 12: cuenta = 6; break;
                    case 13: cuenta = 7; break;
                    case 14: cuenta = 1; break;
                    case 15: cuenta = 8; break;
                    case 16: cuenta = 32; break; // BOTON DE PANICO
                }

                return cuenta;
            }

            private int EmpresaDeFondo(int fondo)
            {
                int empresa = 0;

                switch (fondo)
                {
                    case 1: empresa = 2; break;
                    case 2: empresa = 2; break;
                    case 3: empresa = 2; break;
                    case 5: empresa = 4; break;
                    case 11: empresa = 6; break;
                    case 12: empresa = 2; break;
                    case 13: empresa = 2; break;
                    case 14: empresa = 5; break;
                    case 15: empresa = 6; break;
                    case 16: empresa = 2; break;
                }

                return empresa;
            }

            //  CuentaCajas
            public void SyncCuentaCajas()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaCajas WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.MovimientosCaja CuentaCajasAztlan;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                maxfolio = Convert.ToInt32(Aztlan.DB.QueryScalar("SELECT MAX(Folio) MaxFolio FROM MovimientosCaja"));

                while (Aztlan.Entities.MovimientosCaja.Read(out CuentaCajasAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaCajasAztlan.Folio;

                    Central.Entities.CuentaCajas centralCuentaCajas = new Central.Entities.CuentaCajas();
                    centralCuentaCajas.Referencia_ID = CuentaCajasAztlan.Folio;
                    centralCuentaCajas.CuentaCaja_ID = 0;
                    if (CuentaCajasAztlan.Sesion == 0)
                    {
                        continue;
                    }
                    else
                    {
                        centralCuentaCajas.Sesion_ID = Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasAztlan.Sesion),
                            Param("Estacion_ID", Estacion)).Sesion_ID; // Verificar correspondencia
                        centralCuentaCajas.Caja_ID = (int)Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasAztlan.Sesion),
                            Param("Estacion_ID", Estacion)).Caja_ID; // Se obtiene de la sesion
                    }

                    //  La empresa tambien depende del fondo
                    centralCuentaCajas.Empresa_ID = EmpresaDeFondo(CuentaCajasAztlan.Fondo);

                    centralCuentaCajas.Estacion_ID = Estacion;

                    centralCuentaCajas.Ticket_ID = null;    //  No esta supeditada a un ticket

                    centralCuentaCajas.Cuenta_ID = CuentaDeFondo(CuentaCajasAztlan.Fondo); // De este dato obtener la cuenta

                    centralCuentaCajas.Concepto_ID = null; // No se lleva concepto

                    decimal abono, cargo;
                    if (CuentaCajasAztlan.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaCajasAztlan.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaCajasAztlan.Monto);
                    }

                    centralCuentaCajas.Cargo = cargo; // De este dato depende
                    centralCuentaCajas.Abono = abono;
                    centralCuentaCajas.Saldo = 0; // Es calculado, meter dentro del create
                    centralCuentaCajas.Comentarios = "";
                    centralCuentaCajas.Fecha = CuentaCajasAztlan.Fecha;
                    centralCuentaCajas.Usuario_ID = CuentaCajasAztlan.Usuario;

                    if (Central.DB.Exists("CuentaCajas", Param("Referencia_ID", centralCuentaCajas.Referencia_ID),
                            Param("Estacion_ID", Estacion)))
                    {
                        //  Obtener el id
                        centralCuentaCajas.Update();
                    }
                    else
                    {
                        centralCuentaCajas.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado CuentaCajas: {0} de {1}", folio, maxfolio));
                }

            }	//	End Method SyncCuentaCajas

            private int CuentaDeCuenta(int cuentalocal)
            {
                int cuenta = 0;
                switch (cuentalocal)
                {
                    case 1: cuenta = 1; break;
                    case 2: cuenta = 4; break;
                    case 3: cuenta = 3; break;
                    case 4: cuenta = 2; break;
                    case 9: cuenta = 2; break;
                    case 10: cuenta = 8; break;
                    case 11: cuenta = 32; break;
                }
                return cuenta;
            }

            private int ConceptoCentral(int conceptolocal)
            {
                int concepto = 0;
                switch (conceptolocal)
                {
                    case 88: concepto = 92; break;
                    case 89: concepto = 93; break;
                    default: concepto = conceptolocal; break;
                }
                return concepto;
            }

            public void SyncCuentaConductores()
            {
                string sqlup = "UPDATE CuentaConductor SET UsuarioAlta = 'luis.escareño' WHERE UsuarioAlta = 'luis.escare%c3%b1o'";
                Aztlan.DB.ExecuteQuery(sqlup);
                sqlup = "UPDATE CuentaConductor SET UsuarioAlta = 'luis.escareño' WHERE UsuarioAlta = 'LUIS.ESCARE%c3%91O'";
                Aztlan.DB.ExecuteQuery(sqlup);

                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = string.Format(
                    "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaConductores WHERE Estacion_ID = {0}",
                    Estacion);

                Aztlan.Entities.CuentaConductor CuentaConductoresAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                int cont = Aztlan.DB.GetCount("CuentaConductor");

                while (Aztlan.Entities.CuentaConductor.Read(out CuentaConductoresAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaConductoresAztlan.Folio;

                    Central.Entities.CuentaConductores centralCuentaConductores = new Central.Entities.CuentaConductores();
                    centralCuentaConductores.Referencia_ID = folio;
                    centralCuentaConductores.CuentaConductor_ID = 0;

                    //Obtener segun concepto
                    //Del concepto obtener la cuenta
                    int cuenta = Aztlan.Entities.Conceptos.Read(CuentaConductoresAztlan.Concepto).Cuenta;
                    int fondo = Aztlan.Entities.Cuentas.Read(cuenta).FondoCaja;
                    //De la cuenta, obtener el fondo
                    //Del fondo, la empresa.
                    centralCuentaConductores.Empresa_ID = EmpresaDeFondo(fondo);

                    centralCuentaConductores.Estacion_ID = Estacion; // Aztlan

                    if (CuentaConductoresAztlan.Unidad == 0)
                    {
                        centralCuentaConductores.Unidad_ID = null;
                    }
                    else
                    {
                        centralCuentaConductores.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresAztlan.Unidad)).Unidad_ID;
                    }

                    centralCuentaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", CuentaConductoresAztlan.Conductor)).Conductor_ID;

                    // Verificar la caja para obtener la estación
                    if (CuentaConductoresAztlan.Caja == null)
                    {
                        centralCuentaConductores.Caja_ID = null;
                    }
                    else
                    {
                        if (CuentaConductoresAztlan.Caja == 1 || CuentaConductoresAztlan.Caja == 9)
                        {
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresAztlan.Caja)).Caja_ID;
                        }
                        else
                        {
                            centralCuentaConductores.Estacion_ID = CuentaConductoresAztlan.Caja; // Otra estacion
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", CuentaConductoresAztlan.Caja), Param("Referencia_ID", CuentaConductoresAztlan.Caja)).Caja_ID;
                        }
                    }

                    //  Es posible que se pueda hacer referencia
                    //  Si folio tiene ticket local, buscar su ticket remoto
                    if (Aztlan.DB.Exists("RecibosMovimientos", Param("Movimiento", CuentaConductoresAztlan.Folio)))
                    {
                        int recibo = (int)Aztlan.Entities.RecibosMovimientos.Read(Param("Movimiento", CuentaConductoresAztlan.Folio)).Recibo;
                        int ticket_id = Central.Entities.Tickets.Read(Param("Referencia_ID", recibo), Param("Estacion_ID", Estacion)).Ticket_ID;
                        centralCuentaConductores.Ticket_ID = ticket_id;
                    }
                    else
                    {
                        centralCuentaConductores.Ticket_ID = null; // Ticket a null
                    }

                    centralCuentaConductores.Cuenta_ID = CuentaDeCuenta(cuenta);
                    centralCuentaConductores.Concepto_ID = ConceptoCentral(CuentaConductoresAztlan.Concepto);

                    decimal abono, cargo;
                    if (CuentaConductoresAztlan.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaConductoresAztlan.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaConductoresAztlan.Monto);
                    }

                    centralCuentaConductores.Cargo = cargo;
                    centralCuentaConductores.Abono = abono;
                    centralCuentaConductores.Saldo = 0; // Calculado
                    centralCuentaConductores.Comentarios = CuentaConductoresAztlan.Comentarios;
                    centralCuentaConductores.Fecha = CuentaConductoresAztlan.FechaAlta;
                    centralCuentaConductores.Usuario_ID = CuentaConductoresAztlan.UsuarioAlta;

                    if (Central.DB.Exists("CuentaConductores", Param("CuentaConductor_ID", centralCuentaConductores.CuentaConductor_ID)))
                    {
                        //  Obtener la clave
                        centralCuentaConductores.Update();
                    }
                    else
                    {
                        centralCuentaConductores.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado CuentaConductor_ID: {0} de {1}", centralCuentaConductores.Referencia_ID, cont));

                }
            }	//	End Method SyncCuentaConductores

            public void SyncFamilias()
            {
                List<Aztlan.Entities.Familias> familiasAztlan = Aztlan.Entities.Familias.Read();
                foreach (Aztlan.Entities.Familias FamiliasAztlan in familiasAztlan)
                {
                    Central.Entities.Familias centralFamilias = new Central.Entities.Familias();
                    centralFamilias.Familia_ID = FamiliasAztlan.Folio;
                    centralFamilias.Nombre = FamiliasAztlan.Descripcion;


                    if (Central.DB.Exists("Familias", Param("Familia_ID", centralFamilias.Familia_ID)))
                    {
                        centralFamilias.Update();
                    }
                    else
                    {
                        centralFamilias.Create(true);
                    }
                    Console.WriteLine(String.Format("Registro actualizado Familia: {0}", centralFamilias.Familia_ID));
                }	//	End foreach

            }	//	End Method SyncFamilias

            public void SyncMarcasRefacciones()
            {
                List<Aztlan.Entities.MarcasRefacciones> marcasrefaccionesAztlan =
                    Aztlan.Entities.MarcasRefacciones.Read();
                foreach (Aztlan.Entities.MarcasRefacciones MarcasRefaccionesAztlan in marcasrefaccionesAztlan)
                {
                    Central.Entities.MarcasRefacciones centralMarcasRefacciones = new Central.Entities.MarcasRefacciones();
                    centralMarcasRefacciones.MarcaRefaccion_ID = MarcasRefaccionesAztlan.Folio;
                    centralMarcasRefacciones.Nombre = MarcasRefaccionesAztlan.Descripcion;

                    if (Central.DB.Exists("MarcasRefacciones", Param("MarcaRefaccion_ID", centralMarcasRefacciones.MarcaRefaccion_ID)))
                    {
                        centralMarcasRefacciones.Update();
                    }
                    else
                    {
                        centralMarcasRefacciones.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado MarcaRefaccion_ID: {0}", centralMarcasRefacciones.MarcaRefaccion_ID));
                }	//	End foreach

            }	//	End Method SyncMarcasRefacciones

            public void SyncEstatusMecanicos()
            {
                List<Aztlan.Entities.StatusMecanicos> estatusmecanicosAztlan = Aztlan.Entities.StatusMecanicos.Read();
                foreach (Aztlan.Entities.StatusMecanicos EstatusMecanicosAztlan in estatusmecanicosAztlan)
                {
                    Central.Entities.EstatusMecanicos centralEstatusMecanicos = new Central.Entities.EstatusMecanicos();
                    centralEstatusMecanicos.EstatusMecanico_ID = EstatusMecanicosAztlan.Folio;
                    centralEstatusMecanicos.Nombre = EstatusMecanicosAztlan.Descripcion;


                    if (Central.DB.Exists("EstatusMecanicos", Param("EstatusMecanico_ID", centralEstatusMecanicos.EstatusMecanico_ID)))
                    {
                        centralEstatusMecanicos.Update();
                    }
                    else
                    {
                        centralEstatusMecanicos.Create(true);
                    }
                }	//	End foreach

            }	//	End Method SyncEstatusMecanicos

            public void SyncMecanicos()
            {
                //  Ajustar con read
                List<Aztlan.Entities.Mecanicos> mecanicosAztlan = Aztlan.Entities.Mecanicos.Read();
                foreach (Aztlan.Entities.Mecanicos MecanicosAztlan in mecanicosAztlan)
                {
                    Central.Entities.Mecanicos centralMecanicos = new Central.Entities.Mecanicos();
                    centralMecanicos.Mecanico_ID = MecanicosAztlan.Folio;
                    centralMecanicos.CategoriaMecanico_ID = MecanicosAztlan.Categoria;
                    centralMecanicos.EstatusMecanico_ID = MecanicosAztlan.Status;
                    centralMecanicos.Usuario_ID = MecanicosAztlan.UsuarioAlta;
                    centralMecanicos.Fecha = MecanicosAztlan.FechaAlta;
                    centralMecanicos.CodigoBarras = MecanicosAztlan.CodigoBarras;
                    centralMecanicos.Nombres = MecanicosAztlan.Nombre;
                    centralMecanicos.Apellidos = MecanicosAztlan.ApellidoPaterno + " " + MecanicosAztlan.ApellidoMaterno;
                    centralMecanicos.Rfc = MecanicosAztlan.Rfc;
                    centralMecanicos.Curp = MecanicosAztlan.Curp;
                    centralMecanicos.NSS = MecanicosAztlan.NumeroSeguroSocial;
                    centralMecanicos.Domicilio = MecanicosAztlan.Calle + " No. " + MecanicosAztlan.Numero + ", Col. " + MecanicosAztlan.Colonia;
                    centralMecanicos.Ciudad = MecanicosAztlan.Ciudad;
                    centralMecanicos.Entidad = MecanicosAztlan.Estado;
                    centralMecanicos.CodigoPostal = MecanicosAztlan.CodigoPostal.ToString();
                    centralMecanicos.Telefono = MecanicosAztlan.Telefonos;
                    centralMecanicos.CorreoElectronico = MecanicosAztlan.CorreoElectronico;
                    centralMecanicos.SalarioDiario = MecanicosAztlan.SalarioDiario;
                    centralMecanicos.HorarioEntrada = MecanicosAztlan.HorarioEntrada;
                    centralMecanicos.HorarioSalida = MecanicosAztlan.HorarioSalida;


                    if (Central.DB.Exists("Mecanicos", Param("Mecanico_ID", centralMecanicos.Mecanico_ID)))
                    {
                        centralMecanicos.Update();
                    }
                    else
                    {
                        centralMecanicos.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado Mecanico_ID: {0}", centralMecanicos.Mecanico_ID));

                }	//	End foreach

            }	//	End Method SyncMecanicos

            public void SyncModelos()
            {
                List<Aztlan.Entities.ModelosTaller> modelosAztlan = Aztlan.Entities.ModelosTaller.Read();
                foreach (Aztlan.Entities.ModelosTaller ModelosAztlan in modelosAztlan)
                {
                    Central.Entities.Modelos centralModelos = new Central.Entities.Modelos();
                    centralModelos.Modelo_ID = ModelosAztlan.Folio;
                    centralModelos.Nombre = ModelosAztlan.Descripcion;


                    if (Central.DB.Exists("Modelos", Param("Modelo_ID", centralModelos.Modelo_ID)))
                    {
                        centralModelos.Update();
                    }
                    else
                    {
                        centralModelos.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Modelo_ID: {0}", centralModelos.Modelo_ID));
                }	//	End foreach

            }	//	End Method SyncModelos

            public void SyncModelosUnidades()
            {
                List<Aztlan.Entities.Modelos> modelosunidadesAztlan = Aztlan.Entities.Modelos.Read();
                foreach (Aztlan.Entities.Modelos ModelosUnidadesAztlan in modelosunidadesAztlan)
                {
                    Central.Entities.ModelosUnidades centralModelosUnidades = new Central.Entities.ModelosUnidades();
                    centralModelosUnidades.ModeloUnidad_ID = 0;

                    centralModelosUnidades.MarcaUnidad_ID = 1; // Actualizar posteriormente
                    centralModelosUnidades.Descripcion = ModelosUnidadesAztlan.Descripcion;
                    centralModelosUnidades.PrecioLista = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesAztlan.PrecioLista, 0));
                    centralModelosUnidades.Anio = ModelosUnidadesAztlan.Año;
                    centralModelosUnidades.Deposito = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesAztlan.Deposito, 0));
                    centralModelosUnidades.Activo = (ModelosUnidadesAztlan.Status == 1) ? true : false;
                    centralModelosUnidades.referencia_id = ModelosUnidadesAztlan.Folio;
                    centralModelosUnidades.EmpresaReferencia = Estacion; //    CAM

                    if (Central.DB.Exists(
                        "ModelosUnidades",
                        Param("Referencia_ID", ModelosUnidadesAztlan.Folio),
                        Param("EmpresaReferencia", Estacion)
                        )
                        )
                    {
                        centralModelosUnidades.Update();
                    }
                    else
                    {
                        centralModelosUnidades.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado ModeloUnidad_ID: {0}", centralModelosUnidades.ModeloUnidad_ID));

                }	//	End foreach

            }	//	End Method SyncModelosUnidades

            private int GetTipoMovimientoInventario(string tipo)
            {
                int result = 0;

                switch (tipo)
                {
                    case "O.T.":
                        result = 1;
                        break;
                    case "Compra":
                        result = 2;
                        break;
                    case "Ajuste":
                        result = 3;
                        break;
                    case "CancelO.C.":
                        result = 4;
                        break;
                    case "Inicial":
                        result = 5;
                        break;
                    case "CancelO.T.":
                        result = 6;
                        break;
                }

                return result;
            }

            public void SyncMovimientosInventario()
            {
                //  Ajustar con read
                List<Aztlan.Entities.HistorialInventario> historialinventarioAztlan = Aztlan.Entities.HistorialInventario.Read();
                foreach (Aztlan.Entities.HistorialInventario HistorialInventarioAztlan in historialinventarioAztlan)
                {
                    Central.Entities.MovimientosInventario centralMovimientosInventario = new Central.Entities.MovimientosInventario();
                    centralMovimientosInventario.MovimientoInventario_ID = 0;
                    int tipo = GetTipoMovimientoInventario(HistorialInventarioAztlan.Tipo);
                    centralMovimientosInventario.TipoMovimientoInventario_ID = tipo;
                    centralMovimientosInventario.OrdenCompra_ID = (tipo == 2 || tipo == 4) ? Convert.ToInt32(HistorialInventarioAztlan.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.OrdenTrabajo_ID = (tipo == 1 || tipo == 6) ? Convert.ToInt32(HistorialInventarioAztlan.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.NotaAlmacen_ID = HistorialInventarioAztlan.NotaAlmacen;
                    centralMovimientosInventario.AjusteInventario_ID = (tipo == 3) ? Convert.ToInt32(HistorialInventarioAztlan.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.Usuario_ID = HistorialInventarioAztlan.Usuario;
                    centralMovimientosInventario.Refaccion_ID = HistorialInventarioAztlan.Refaccion;
                    centralMovimientosInventario.Fecha = HistorialInventarioAztlan.Fecha;
                    centralMovimientosInventario.Cantidad = Convert.ToInt32(HistorialInventarioAztlan.Cantidad);
                    centralMovimientosInventario.CostoUnitario = HistorialInventarioAztlan.CostoUnitario;
                    centralMovimientosInventario.Valor = HistorialInventarioAztlan.Valor;
                    centralMovimientosInventario.CantidadPrev = Convert.ToInt32(HistorialInventarioAztlan.CantidadPrev);
                    centralMovimientosInventario.ValorPrev = HistorialInventarioAztlan.ValorPrev;
                    centralMovimientosInventario.CantidadPost = Convert.ToInt32(HistorialInventarioAztlan.CantidadPost);
                    centralMovimientosInventario.ValorPost = HistorialInventarioAztlan.ValorPost;
                    centralMovimientosInventario.CantidadPrevProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPrevProm = 0; // Por calcular
                    centralMovimientosInventario.CantidadPostProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPostProm = 0; // Por calcular
                    centralMovimientosInventario.Referencia = HistorialInventarioAztlan.Movimiento;


                    if (Central.DB.Exists("MovimientosInventario", Param("Referencia", centralMovimientosInventario.Referencia)))
                    {
                        //  Get
                        centralMovimientosInventario.Update();
                    }
                    else
                    {
                        centralMovimientosInventario.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado MovimientoInventario_ID: {0}", centralMovimientosInventario.MovimientoInventario_ID));
                }	//	End foreach

            }	//	End Method SyncMovimientosInventario

            public void SyncNotasAlmacen()
            {
                //  Ajustar con read
                List<Aztlan.Entities.NotasAlmacen> notasalmacenAztlan = Aztlan.Entities.NotasAlmacen.Read();
                foreach (Aztlan.Entities.NotasAlmacen NotasAlmacenAztlan in notasalmacenAztlan)
                {
                    if (NotasAlmacenAztlan.OrdenCompra != null && NotasAlmacenAztlan.OrdenCompra == 0) continue;
                    if (NotasAlmacenAztlan.OrdenTrabajo != null && NotasAlmacenAztlan.OrdenTrabajo == 0) continue;

                    Central.Entities.NotasAlmacen centralNotasAlmacen = new Central.Entities.NotasAlmacen();
                    centralNotasAlmacen.NotaAlmacen_ID = NotasAlmacenAztlan.NotaAlmacenID;
                    centralNotasAlmacen.Usuario_ID = NotasAlmacenAztlan.Usuario;
                    centralNotasAlmacen.TipoMovimientoInventario_ID = (NotasAlmacenAztlan.Tipo == "ENTRADA") ? 1 : 2;
                    centralNotasAlmacen.OrdenCompra_ID = NotasAlmacenAztlan.OrdenCompra;
                    centralNotasAlmacen.OrdenTrabajo_ID = NotasAlmacenAztlan.OrdenTrabajo;
                    centralNotasAlmacen.Fecha = NotasAlmacenAztlan.Fecha;

                    if (Central.DB.Exists("NotasAlmacen", Param("NotaAlmacen_ID", centralNotasAlmacen.NotaAlmacen_ID)))
                    {
                        centralNotasAlmacen.Update();
                    }
                    else
                    {
                        centralNotasAlmacen.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado NotaAlmacen_ID: {0}", centralNotasAlmacen.NotaAlmacen_ID));

                }	//	End foreach

            }	//	End Method SyncNotasAlmacen

            public void SyncOrdenesCompras()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenCompra_ID),0) folio FROM OrdenesCompra";

                Aztlan.Entities.OrdenesCompras OrdenesComprasAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (Aztlan.Entities.OrdenesCompras.Read(out OrdenesComprasAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesComprasAztlan.Folio;

                    Central.Entities.OrdenesCompras centralOrdenesCompras = new Central.Entities.OrdenesCompras();
                    centralOrdenesCompras.OrdenCompra_ID = OrdenesComprasAztlan.Folio;

                    //  Obtener el proveedor
                    //  Los proveedores deben estar datos de alta en el sistema previamente
                    //  buscar por rfc
                    int proveedor = Central.Entities.Empresas.Read(Param("Rfc", OrdenesComprasAztlan.Proveedores.Rfc))[0].Empresa_ID;
                    centralOrdenesCompras.Proveedor_ID = proveedor;
                    centralOrdenesCompras.EstatusOrdenCompra_ID = Convert.ToInt32(AppHelper.IsNull(OrdenesComprasAztlan.Status, 1));
                    centralOrdenesCompras.Usuario_ID = OrdenesComprasAztlan.UsuarioAlta;
                    centralOrdenesCompras.Fecha = OrdenesComprasAztlan.FechaAlta;
                    centralOrdenesCompras.Factura = OrdenesComprasAztlan.Factura;
                    centralOrdenesCompras.Subtotal = OrdenesComprasAztlan.SubTotal;
                    centralOrdenesCompras.IVA = OrdenesComprasAztlan.IVA;
                    centralOrdenesCompras.Total = OrdenesComprasAztlan.Total;

                    if (Central.DB.Exists("OrdenesCompras", Param("OrdenCompra_ID", centralOrdenesCompras.OrdenCompra_ID)))
                    {
                        centralOrdenesCompras.Update();
                    }
                    else
                    {
                        centralOrdenesCompras.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenCompra_ID: {0}", centralOrdenesCompras.OrdenCompra_ID));
                }

                //List<Aztlan.Entities.OrdenesCompras> ordenescomprasAztlan = Aztlan.Entities.OrdenesCompras.Read();
                //foreach (Aztlan.Entities.OrdenesCompras OrdenesComprasAztlan in ordenescomprasAztlan)
                //{                    


                //}	//	End foreach

            }	//	End Method SyncOrdenesCompras

            public void SyncOrdenesComprasCanceladas()
            {
                //  Ajustar con read
                List<Aztlan.Entities.OrdenesComprasCanceladas> ordenescomprascanceladasAztlan = Aztlan.Entities.OrdenesComprasCanceladas.Read();
                foreach (Aztlan.Entities.OrdenesComprasCanceladas OrdenesComprasCanceladasAztlan in ordenescomprascanceladasAztlan)
                {
                    // si no tiene compra, no checar
                    if (!Aztlan.DB.Exists("OrdenesCompras", Param("Folio", OrdenesComprasCanceladasAztlan.OrdenCompra))) continue;

                    Central.Entities.OrdenesComprasCanceladas centralOrdenesComprasCanceladas = new Central.Entities.OrdenesComprasCanceladas();
                    centralOrdenesComprasCanceladas.OrdenCompra_ID = OrdenesComprasCanceladasAztlan.OrdenCompra;
                    centralOrdenesComprasCanceladas.Usuario_ID = OrdenesComprasCanceladasAztlan.Usuario;
                    centralOrdenesComprasCanceladas.Fecha = OrdenesComprasCanceladasAztlan.Fecha;
                    centralOrdenesComprasCanceladas.Comentarios = OrdenesComprasCanceladasAztlan.Motivos;


                    if (Central.DB.Exists("OrdenesComprasCanceladas", Param("OrdenCompra_ID", centralOrdenesComprasCanceladas.OrdenCompra_ID)))
                    {
                        centralOrdenesComprasCanceladas.Update();
                    }
                    else
                    {
                        centralOrdenesComprasCanceladas.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenCompraCancelada_ID: {0}", centralOrdenesComprasCanceladas.OrdenCompra_ID));
                }	//	End foreach

            }	//	End Method SyncOrdenesComprasCanceladas

            public void SyncOrdenesServicios()
            {
                Aztlan.Entities.OrdenesServicio OrdenesServiciosAztlan;
                string filter = "Folio > @Folio";
                string sort = "Folio ASC";
                int folio = Convert.ToInt32(Central.DB.QueryScalar("SELECT ISNULL(MAX(OrdenServicio_ID),0) folio FROM OrdenesServicios"));

                while (Aztlan.Entities.OrdenesServicio.Read(out OrdenesServiciosAztlan, 1, filter, sort, Param("@Folio", folio)))
                {
                    try
                    {
                        Central.Entities.OrdenesTrabajos.Read(OrdenesServiciosAztlan.OrdenTrabajo);
                    }
                    catch (SICASException sicasEx)
                    {
                        folio = OrdenesServiciosAztlan.Folio;
                        continue;
                    }
                    catch 
                    {
                        throw;
                    }

                    Central.Entities.OrdenesServicios centralOrdenesServicios = new Central.Entities.OrdenesServicios();
                    folio = OrdenesServiciosAztlan.Folio;

                    centralOrdenesServicios.OrdenServicio_ID = OrdenesServiciosAztlan.Folio;
                    centralOrdenesServicios.OrdenTrabajo_ID = OrdenesServiciosAztlan.OrdenTrabajo;
                    centralOrdenesServicios.ServicioMantenimiento_ID = OrdenesServiciosAztlan.Servicio;
                    centralOrdenesServicios.Mecanico_ID = OrdenesServiciosAztlan.Mecanico;
                    centralOrdenesServicios.EstatusOrdenServicio_ID = OrdenesServiciosAztlan.Status;
                    centralOrdenesServicios.Fecha = Central.DB.GetNullableDateTime(OrdenesServiciosAztlan.FechaSurtida);
                    centralOrdenesServicios.Cantidad = Convert.ToInt32(OrdenesServiciosAztlan.Cantidad);
                    centralOrdenesServicios.Precio = OrdenesServiciosAztlan.PrecioUnitario;
                    centralOrdenesServicios.Total = OrdenesServiciosAztlan.Total;


                    if (Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", centralOrdenesServicios.OrdenServicio_ID)))
                    {
                        centralOrdenesServicios.Update();
                    }
                    else
                    {
                        centralOrdenesServicios.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenServicio_ID: {0}", centralOrdenesServicios.OrdenServicio_ID));
                }

            }	//	End Method SyncOrdenesServicios

            public void SyncOrdenesServiciosRefacciones()
            {
                //  Ajustar como con compras
                List<Aztlan.Entities.OrdenesServicioRefacciones> ordenesserviciosrefaccionesAztlan = Aztlan.Entities.OrdenesServicioRefacciones.Read();
                foreach (Aztlan.Entities.OrdenesServicioRefacciones OrdenesServiciosRefaccionesAztlan in ordenesserviciosrefaccionesAztlan)
                {
                    if (!Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", OrdenesServiciosRefaccionesAztlan.OrdenServicio)))
                    {
                        continue;
                    }
                    Central.Entities.OrdenesServiciosRefacciones centralOrdenesServiciosRefacciones = new Central.Entities.OrdenesServiciosRefacciones();
                    centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID = 0;
                    centralOrdenesServiciosRefacciones.OrdenServicio_ID = OrdenesServiciosRefaccionesAztlan.OrdenServicio;
                    centralOrdenesServiciosRefacciones.Refaccion_ID = OrdenesServiciosRefaccionesAztlan.Refaccion;
                    centralOrdenesServiciosRefacciones.Cantidad = Convert.ToInt32(OrdenesServiciosRefaccionesAztlan.Cantidad);
                    centralOrdenesServiciosRefacciones.PrecioUnitario = OrdenesServiciosRefaccionesAztlan.PrecioUnitario;
                    centralOrdenesServiciosRefacciones.Total = OrdenesServiciosRefaccionesAztlan.Total;
                    centralOrdenesServiciosRefacciones.CostoUnitario = (decimal)OrdenesServiciosRefaccionesAztlan.CostoUnitario;
                    centralOrdenesServiciosRefacciones.RefSurtidas = Central.DB.GetNullableInt32(OrdenesServiciosRefaccionesAztlan.RefSurtidas);


                    if (Central.DB.Exists("OrdenesServiciosRefacciones",
                            Param("OrdenServicio_ID", centralOrdenesServiciosRefacciones.OrdenServicio_ID),
                                Param("Refaccion_ID", centralOrdenesServiciosRefacciones.Refaccion_ID)))
                    {
                        //  Obtener OrdenServicioRefaccion_ID
                        centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("OrdenesServiciosRefacciones", "OrdenServicioRefaccion_ID",
                                Param("OrdenServicio_ID", centralOrdenesServiciosRefacciones.OrdenServicio_ID),
                                    Param("Refaccion_ID", centralOrdenesServiciosRefacciones.Refaccion_ID)));

                        centralOrdenesServiciosRefacciones.Update();
                    }
                    else
                    {
                        centralOrdenesServiciosRefacciones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenServicio: {0} Refaccion {1}",
                        centralOrdenesServiciosRefacciones.OrdenServicio_ID, centralOrdenesServiciosRefacciones.Refaccion_ID));
                }	//	End foreach

            }	//	End Method SyncOrdenesServiciosRefacciones

            private int GetEmpresaClienteTaller(int clientetaller)
            {
                Dictionary<int, int> clientes = new Dictionary<int, int>();

                clientes.Add(7, 5);
                clientes.Add(5, 585);
                clientes.Add(4, 586);
                clientes.Add(2, 3);
                clientes.Add(1, 2);

                return clientes[clientetaller];
            }

            public void SyncEstatusOrdenesTrabajos()
            {
                List<Aztlan.Entities.StatusOrdenesTrabajo> estatusordenestrabajosAztlan = Aztlan.Entities.StatusOrdenesTrabajo.Read();
                foreach (Aztlan.Entities.StatusOrdenesTrabajo EstatusOrdenesTrabajosAztlan in estatusordenestrabajosAztlan)
                {
                    Central.Entities.EstatusOrdenesTrabajos centralEstatusOrdenesTrabajos = new Central.Entities.EstatusOrdenesTrabajos();
                    centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID = EstatusOrdenesTrabajosAztlan.Folio;
                    centralEstatusOrdenesTrabajos.Nombre = EstatusOrdenesTrabajosAztlan.Descripcion;

                    if (Central.DB.Exists("EstatusOrdenesTrabajos", Param("EstatusOrdenTrabajo_ID", centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID)))
                    {
                        centralEstatusOrdenesTrabajos.Update();
                    }
                    else
                    {
                        centralEstatusOrdenesTrabajos.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado EstatusOrdenTrabajo_ID: {0}", centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID));

                }	//	End foreach

            }	//	End Method SyncEstatusOrdenesTrabajos

            public void SyncTiposMantenimientos()
            {
                List<Aztlan.Entities.TiposMantenimientos> tiposmantenimientosAztlan = Aztlan.Entities.TiposMantenimientos.Read();
                foreach (Aztlan.Entities.TiposMantenimientos TiposMantenimientosAztlan in tiposmantenimientosAztlan)
                {
                    Central.Entities.TiposMantenimientos centralTiposMantenimientos = new Central.Entities.TiposMantenimientos();
                    centralTiposMantenimientos.TipoMantenimiento_ID = TiposMantenimientosAztlan.Folio;
                    centralTiposMantenimientos.Nombre = TiposMantenimientosAztlan.Descripcion;


                    if (Central.DB.Exists("TiposMantenimientos", Param("TipoMantenimiento_ID", centralTiposMantenimientos.TipoMantenimiento_ID)))
                    {
                        centralTiposMantenimientos.Update();
                    }
                    else
                    {
                        centralTiposMantenimientos.Create(true);
                    }
                    Console.WriteLine(String.Format("Registro actualizado TipoMantenimiento_ID: {0}", centralTiposMantenimientos.TipoMantenimiento_ID));
                }	//	End foreach

            }	//	End Method SyncTiposMantenimientos

            public void SyncOrdenesTrabajos()
            {
                string filter = "Cliente <> 0 AND Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenTrabajo_ID),0) folio FROM OrdenesTrabajos";

                Aztlan.Entities.OrdenesTrabajo OrdenesTrabajosAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (Aztlan.Entities.OrdenesTrabajo.Read(out OrdenesTrabajosAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesTrabajosAztlan.Folio;
                    Central.Entities.OrdenesTrabajos centralOrdenesTrabajos = new Central.Entities.OrdenesTrabajos();
                    centralOrdenesTrabajos.OrdenTrabajo_ID = OrdenesTrabajosAztlan.Folio;
                    centralOrdenesTrabajos.Empresa_ID = GetEmpresaClienteTaller(OrdenesTrabajosAztlan.ClienteTaller.Tipo);
                    centralOrdenesTrabajos.TipoMantenimiento_ID = Convert.ToInt32(OrdenesTrabajosAztlan.TipoMantenimiento);
                    centralOrdenesTrabajos.ClienteFacturar_ID = GetEmpresaClienteTaller(OrdenesTrabajosAztlan.ClienteTaller.Tipo);

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", OrdenesTrabajosAztlan.Unidad), Param("Estacion_ID", Estacion));
                    int unidad_id = 1;
                    if (unidad != null) unidad_id = unidad.Unidad_ID;

                    centralOrdenesTrabajos.Unidad_ID = unidad_id;
                    centralOrdenesTrabajos.EstatusOrdenTrabajo_ID = OrdenesTrabajosAztlan.Status;
                    centralOrdenesTrabajos.Caja_ID = (OrdenesTrabajosAztlan.Caja == 9) ? 2 : OrdenesTrabajosAztlan.Caja;
                    centralOrdenesTrabajos.Usuario_ID = OrdenesTrabajosAztlan.UsuarioAlta;
                    centralOrdenesTrabajos.Factura_ID = null;
                    centralOrdenesTrabajos.UsuarioFacturacion_ID = OrdenesTrabajosAztlan.UsuarioFacturacion;
                    centralOrdenesTrabajos.CodigoBarras = OrdenesTrabajosAztlan.CodigoBarras;
                    centralOrdenesTrabajos.Subtotal = OrdenesTrabajosAztlan.Subtotal;
                    centralOrdenesTrabajos.IVA = OrdenesTrabajosAztlan.IVA;
                    centralOrdenesTrabajos.Total = OrdenesTrabajosAztlan.Total;
                    centralOrdenesTrabajos.FechaAlta = OrdenesTrabajosAztlan.FechaAlta;
                    centralOrdenesTrabajos.FechaTerminacion = OrdenesTrabajosAztlan.FechaTerminacion;
                    centralOrdenesTrabajos.FechaPago = OrdenesTrabajosAztlan.FechaPago;
                    centralOrdenesTrabajos.NumeroEconomico = Convert.ToInt32(OrdenesTrabajosAztlan.NumeroEconomico);
                    centralOrdenesTrabajos.FechaInicioReparacion = OrdenesTrabajosAztlan.FechaInicioReparacion;
                    centralOrdenesTrabajos.ManoObra = Convert.ToDecimal(OrdenesTrabajosAztlan.ManoObra);
                    centralOrdenesTrabajos.IVAManoObra = Convert.ToDecimal(OrdenesTrabajosAztlan.IVAManoObra);
                    centralOrdenesTrabajos.Refacciones = Convert.ToDecimal(OrdenesTrabajosAztlan.Refacciones);
                    centralOrdenesTrabajos.IVARefacciones = Convert.ToDecimal(OrdenesTrabajosAztlan.IVARefacciones);
                    centralOrdenesTrabajos.FechaFacturacion = OrdenesTrabajosAztlan.FechaFacturacion;
                    centralOrdenesTrabajos.Kilometraje = OrdenesTrabajosAztlan.Kilometraje;
                    centralOrdenesTrabajos.Comentarios = OrdenesTrabajosAztlan.Comentarios;
                    centralOrdenesTrabajos.CostoRefacciones = Convert.ToDecimal(OrdenesTrabajosAztlan.CostoRefacciones);
                    centralOrdenesTrabajos.CostoManoObra = Convert.ToDecimal(OrdenesTrabajosAztlan.CostoManoObra);
                    centralOrdenesTrabajos.CargoAConductor = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosAztlan.CargoCond, false));
                    centralOrdenesTrabajos.CB = OrdenesTrabajosAztlan.CB;
                    centralOrdenesTrabajos.CB_Activo = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosAztlan.CB_Activo, false));


                    if (Central.DB.Exists("OrdenesTrabajos", Param("OrdenTrabajo_ID", centralOrdenesTrabajos.OrdenTrabajo_ID)))
                    {
                        centralOrdenesTrabajos.Update();
                    }
                    else
                    {
                        centralOrdenesTrabajos.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenTrabajo_ID: {0}", centralOrdenesTrabajos.OrdenTrabajo_ID));
                }

                //List<Aztlan.Entities.OrdenesTrabajo> ordenestrabajosAztlan = Aztlan.Entities.OrdenesTrabajo.Read();
                //foreach (Aztlan.Entities.OrdenesTrabajo OrdenesTrabajosAztlan in ordenestrabajosAztlan)
                //{                    
                //}	//	End foreach

            }	//	End Method SyncOrdenesTrabajos

            public void SyncRefacciones(int folioinicial)
            {
                string filter = "(Folio IN " +
                    "(SELECT Refaccion FROM Compras) " +
                    "OR Folio IN " +
                    "(SELECT Refaccion FROM OrdenesServicioRefacciones) " +
                    "OR Folio IN (SELECT Refaccion FROM MovimientosDirectosAInventario)) " +
                    "AND Folio > @Folio";

                string sort = "Folio ASC";

                Aztlan.Entities.Refacciones RefaccionesAztlan;
                int folio = folioinicial;

                while (Aztlan.Entities.Refacciones.Read(out RefaccionesAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesAztlan.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesAztlan.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesAztlan.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesAztlan.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesAztlan.Marca == null)
                    {
                        if (RefaccionesAztlan.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesAztlan.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesAztlan.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesAztlan.Año;
                    //centralRefacciones.Pasillo = RefaccionesAztlan.Pasillo;
                    //centralRefacciones.Estante = RefaccionesAztlan.Estante;
                    //centralRefacciones.Nivel = RefaccionesAztlan.Nivel;
                    //centralRefacciones.Seccion = RefaccionesAztlan.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesAztlan.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesAztlan.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenExt, 0));
                    //centralRefacciones.CantidadInventario = 0; // Obtener de inventario
                    //centralRefacciones.ValorInventario = 0; // Obtener de inventario
                    //centralRefacciones.PuntoDeReOrden = 0; // Obtener de inventario


                    if (Central.DB.Exists("Refacciones", Param("Refaccion_ID", centralRefacciones.Refaccion_ID)))
                    {
                        centralRefacciones.Update();
                    }
                    else
                    {
                        centralRefacciones.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado Refaccion_ID: {0}", centralRefacciones.Refaccion_ID));
                }

            }	//	End Method SyncRefacciones

            public void SyncRefacciones()
            {
                string filter = "(Folio IN " +
                    "(SELECT Refaccion FROM Compras) " +
                    "OR Folio IN " +
                    "(SELECT Refaccion FROM OrdenesServicioRefacciones) " +
                    "OR Folio IN (SELECT Refaccion FROM MovimientosDirectosAInventario)) " +
                    "AND Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Refaccion_ID),0) folio FROM Refacciones";

                Aztlan.Entities.Refacciones RefaccionesAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (Aztlan.Entities.Refacciones.Read(out RefaccionesAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesAztlan.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesAztlan.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesAztlan.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesAztlan.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesAztlan.Marca == null)
                    {
                        if (RefaccionesAztlan.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesAztlan.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesAztlan.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesAztlan.Año;
                    //centralRefacciones.Pasillo = RefaccionesAztlan.Pasillo;
                    //centralRefacciones.Estante = RefaccionesAztlan.Estante;
                    //centralRefacciones.Nivel = RefaccionesAztlan.Nivel;
                    //centralRefacciones.Seccion = RefaccionesAztlan.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesAztlan.NumeroDeParte;

                    //  Obtener la descripción a partir las variables
                    centralRefacciones.Descripcion = RefaccionesAztlan.Descripcion;

                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenExt, 0));

                    string sqlstr = "SELECT	SUM(Cantidad) Cantidad FROM Inventario WHERE	Refaccion = @Refaccion";
                    int cantidadInventario = Convert.ToInt32(Aztlan.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesAztlan.Folio)));
                    //centralRefacciones.CantidadInventario = cantidadInventario;

                    sqlstr = "SELECT	SUM(Costo) Costo FROM Inventario WHERE	Refaccion = @Refaccion";
                    decimal valorInventario = Convert.ToDecimal(Aztlan.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesAztlan.Folio)));
                    //centralRefacciones.ValorInventario = valorInventario;

                    //centralRefacciones.PuntoDeReOrden = cantidadInventario;


                    if (Central.DB.Exists("Refacciones", Param("Refaccion_ID", centralRefacciones.Refaccion_ID)))
                    {
                        centralRefacciones.Update();
                    }
                    else
                    {
                        centralRefacciones.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado Refaccion_ID: {0}", centralRefacciones.Refaccion_ID));
                }

            }	//	End Method SyncRefacciones

            public void SyncRefaccionesPre()
            {
                string filter = "Folio IN " +
                    "(SELECT Refaccion FROM Compras) " +
                    "AND Folio IN " +
                    "(SELECT Refaccion FROM OrdenesServicioRefacciones)";

                List<Aztlan.Entities.Refacciones> refaccionesAztlan = Aztlan.Entities.Refacciones.Read(filter, "");
                foreach (Aztlan.Entities.Refacciones RefaccionesAztlan in refaccionesAztlan)
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    centralRefacciones.Refaccion_ID = RefaccionesAztlan.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesAztlan.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesAztlan.Modelo;
                    centralRefacciones.MarcaRefaccion_ID = Convert.ToInt32(AppHelper.IsNull(RefaccionesAztlan.Marca, RefaccionesAztlan.Inventario[0].Marca));
                    centralRefacciones.Anio = RefaccionesAztlan.Año;
                    //centralRefacciones.Pasillo = RefaccionesAztlan.Pasillo;
                    //centralRefacciones.Estante = RefaccionesAztlan.Estante;
                    //centralRefacciones.Nivel = RefaccionesAztlan.Nivel;
                    //centralRefacciones.Seccion = RefaccionesAztlan.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesAztlan.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesAztlan.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesAztlan.MargenExt, 0));
                    //centralRefacciones.CantidadInventario = 0; // Obtener de inventario
                    //centralRefacciones.ValorInventario = 0; // Obtener de inventario
                    //centralRefacciones.PuntoDeReOrden = 0; // Obtener de inventario


                    if (Central.DB.Exists("Refacciones", Param("Refaccion_ID", centralRefacciones.Refaccion_ID)))
                    {
                        centralRefacciones.Update();
                    }
                    else
                    {
                        centralRefacciones.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado Refaccion_ID: {0}", centralRefacciones.Refaccion_ID));
                }	//	End foreach

            }	//	End Method SyncRefacciones

            public void SyncServiciosMantenimientos()
            {
                //  Ajustar con read
                List<Aztlan.Entities.Servicios> serviciosmantenimientosAztlan = Aztlan.Entities.Servicios.Read();
                foreach (Aztlan.Entities.Servicios ServiciosMantenimientosAztlan in serviciosmantenimientosAztlan)
                {
                    Central.Entities.ServiciosMantenimientos centralServiciosMantenimientos = new Central.Entities.ServiciosMantenimientos();
                    centralServiciosMantenimientos.ServicioMantenimiento_ID = ServiciosMantenimientosAztlan.Folio;
                    centralServiciosMantenimientos.TipoServicioMantenimiento_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Familia_ID = (ServiciosMantenimientosAztlan.Familia == 0) ? 1 : ServiciosMantenimientosAztlan.Familia;
                    centralServiciosMantenimientos.Modelo_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Nombre = ServiciosMantenimientosAztlan.Descripcion;
                    centralServiciosMantenimientos.TiempoAplicado = 0;
                    centralServiciosMantenimientos.CostoManoObraAreaMinuto = 0;
                    centralServiciosMantenimientos.PrecioMinuto = 0;
                    centralServiciosMantenimientos.Costo = 0;
                    centralServiciosMantenimientos.Precio = 0;
                    centralServiciosMantenimientos.PorcentajeUtilidad = 0;
                    centralServiciosMantenimientos.CuotaManoObra = 0;

                    if (Central.DB.Exists("ServiciosMantenimientos", Param("ServicioMantenimiento_ID", centralServiciosMantenimientos.ServicioMantenimiento_ID)))
                    {
                        centralServiciosMantenimientos.Update();
                    }
                    else
                    {
                        centralServiciosMantenimientos.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado ServicioMantenimiento_ID: {0}", centralServiciosMantenimientos.ServicioMantenimiento_ID));

                }	//	End foreach

            }	//	End Method SyncServiciosMantenimientos

            public void SyncServiciosMantenimientos_TiposRefacciones()
            {
                //  Ajustar con read
                List<Aztlan.Entities.ServiciosTiposRefacciones> serviciosmantenimientos_tiposrefaccionesAztlan = Aztlan.Entities.ServiciosTiposRefacciones.Read();
                foreach (Aztlan.Entities.ServiciosTiposRefacciones ServiciosMantenimientos_TiposRefaccionesAztlan in serviciosmantenimientos_tiposrefaccionesAztlan)
                {
                    Central.Entities.ServiciosMantenimientos_TiposRefacciones centralServiciosMantenimientos_TiposRefacciones = new Central.Entities.ServiciosMantenimientos_TiposRefacciones();
                    centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID = ServiciosMantenimientos_TiposRefaccionesAztlan.Servicio;
                    centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID = ServiciosMantenimientos_TiposRefaccionesAztlan.TipoRefaccion;
                    centralServiciosMantenimientos_TiposRefacciones.Cantidad = ServiciosMantenimientos_TiposRefaccionesAztlan.Cantidad;

                    if (Central.DB.Exists("ServiciosMantenimientos_TiposRefacciones",
                            Param("ServicioMantenimiento_ID", centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID),
                                Param("TipoRefaccion_ID", centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID)))
                    {
                        centralServiciosMantenimientos_TiposRefacciones.Update();
                    }
                    else
                    {
                        centralServiciosMantenimientos_TiposRefacciones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Servicio: {0} TipoRefaccion: {1}",
                        centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID, centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID));
                }	//	End foreach

            }	//	End Method SyncServiciosMantenimientos_TiposRefacciones

            public void SyncSesiones()
            {
                string filter = "Sesion > @Sesion";

                string sort = "Sesion ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Sesiones WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.ControlCajas SesionesAztlan;
                int sesion;

                sesion = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.ControlCajas.Read(out SesionesAztlan, 1, filter, sort, Param("Sesion", sesion)))
                {
                    sesion = SesionesAztlan.Sesion;

                    Central.Entities.Sesiones centralSesiones = new Central.Entities.Sesiones();
                    centralSesiones.Sesion_ID = SesionesAztlan.Sesion;
                    centralSesiones.Empresa_ID = Empresa; // CAM
                    centralSesiones.Estacion_ID = Estacion; // Aztlan

                    SesionesAztlan.Caja = SesionesAztlan.Caja.Trim();
                    centralSesiones.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Referencia_ID", SesionesAztlan.Caja), Param("Estacion_ID", Estacion)).Caja_ID;
                    Aztlan.Entities.MovimientosCaja mc = Aztlan.Entities.MovimientosCaja.Read(Param("Sesion", SesionesAztlan.Sesion));

                    centralSesiones.Usuario_ID = (mc == null) ? "SICAS" : mc.Usuario;

                    centralSesiones.FechaInicial = SesionesAztlan.Inicio;
                    centralSesiones.FechaFinal = SesionesAztlan.Corte;
                    centralSesiones.HostName = null;
                    centralSesiones.IPAddress = null;
                    centralSesiones.MACAddress = null;
                    centralSesiones.Activo = (SesionesAztlan.Corte == null) ? true : false;
                    centralSesiones.Referencia_ID = sesion;

                    if (Central.DB.Exists("Sesiones", Param("Sesion_ID", centralSesiones.Sesion_ID)))
                    {
                        centralSesiones.Update();
                    }
                    else
                    {
                        centralSesiones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Sesion_ID: {0}", centralSesiones.Sesion_ID));
                }

            }	//	End Method SyncSesiones

            public void SyncTickets()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Tickets WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.Recibos TicketsAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                //folio = 36;
                while (Aztlan.Entities.Recibos.Read(out TicketsAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TicketsAztlan.Folio;

                    Central.Entities.Tickets centralTickets = new Central.Entities.Tickets();

                    centralTickets.Ticket_ID = 0;
                    centralTickets.Referencia_ID = folio;

                    //  Consultar la sesión por usuario y fecha
                    Aztlan.Entities.ControlCajas cc = Aztlan.Entities.ControlCajas.GetBy(TicketsAztlan.Fecha, TicketsAztlan.Caja);
                    if (cc == null) continue;
                    int sesionlocal = cc.Sesion;

                    Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(Param("Referencia_ID", sesionlocal), Param("Estacion_ID", Estacion));
                    if (s == null) continue;

                    int sesion_id = s.Sesion_ID;
                    centralTickets.Sesion_ID = sesion_id;

                    centralTickets.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsAztlan.Caja)).Caja_ID;
                    centralTickets.Usuario_ID = TicketsAztlan.UsuarioAlta;

                    //  Si existe en cancelados
                    if (Aztlan.DB.Exists("RecibosCancelados", Param("Estacion", Estacion), Param("Recibo", TicketsAztlan.Folio)))
                    {
                        centralTickets.EstatusTicket_ID = 2;
                    }
                    else
                    {
                        centralTickets.EstatusTicket_ID = 1;
                    }

                    centralTickets.Empresa_ID = Empresa; // CAM
                    centralTickets.Estacion_ID = Estacion; // Aztlan

                    if (TicketsAztlan.Unidad == 0)
                    {
                        centralTickets.Unidad_ID = null;
                    }
                    else
                    {
                        centralTickets.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsAztlan.Unidad)).Unidad_ID;
                    }

                    centralTickets.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", TicketsAztlan.Conductor)).Conductor_ID;


                    centralTickets.Fecha = TicketsAztlan.Fecha;

                    if (Central.DB.Exists("Tickets", Param("Ticket_ID", centralTickets.Ticket_ID)))
                    {
                        centralTickets.Update();
                    }
                    else
                    {
                        centralTickets.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Ticket_ID: {0}", folio));
                }
            }	//	End Method SyncTickets

            public void SyncTicketsCancelados()
            {
                //  Ajustar con read
                List<Aztlan.Entities.RecibosCancelados> ticketscanceladosAztlan = Aztlan.Entities.RecibosCancelados.Read();
                foreach (Aztlan.Entities.RecibosCancelados TicketsCanceladosAztlan in ticketscanceladosAztlan)
                {
                    Central.Entities.TicketsCancelados centralTicketsCancelados = new Central.Entities.TicketsCancelados();

                    Central.Entities.Tickets ticket = Central.Entities.Tickets.Read(Param("Referencia_ID", TicketsCanceladosAztlan.Recibo), Param("Estacion_ID", Estacion));
                    if (ticket == null)
                    {
                        // Ticket no existe
                        continue;
                    }
                    centralTicketsCancelados.Ticket_ID = ticket.Ticket_ID;
                    centralTicketsCancelados.Motivo = TicketsCanceladosAztlan.Motivo;
                    centralTicketsCancelados.Usuario_ID = TicketsCanceladosAztlan.Usuario;
                    centralTicketsCancelados.Fecha = Convert.ToDateTime(TicketsCanceladosAztlan.Fecha);


                    if (Central.DB.Exists("TicketsCancelados", Param("Ticket_ID", centralTicketsCancelados.Ticket_ID)))
                    {
                        centralTicketsCancelados.Update();
                    }
                    else
                    {
                        centralTicketsCancelados.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Ticket_ID (Cancelacion): {0}", centralTicketsCancelados.Ticket_ID));
                }	//	End foreach

            }	//	End Method SyncTicketsCancelados

            public void SyncTiposRefacciones()
            {
                //  Ajustar con read
                List<Aztlan.Entities.TiposRefacciones> tiposrefaccionesAztlan
                    = Aztlan.Entities.TiposRefacciones.Read();
                foreach (Aztlan.Entities.TiposRefacciones TiposRefaccionesAztlan in tiposrefaccionesAztlan)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesAztlan.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesAztlan.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesAztlan.Descripcion;


                    if (Central.DB.Exists("TiposRefacciones", Param("TipoRefaccion_ID", centralTiposRefacciones.TipoRefaccion_ID)))
                    {
                        //  Compara
                        //  Si difiere
                        //  Actualiza
                        centralTiposRefacciones.Update();
                    }
                    else
                    {
                        centralTiposRefacciones.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado TipoRefaccion_ID: {0}", centralTiposRefacciones.TipoRefaccion_ID));

                }	//	End foreach

            }	//	End Method SyncTiposRefacciones

            public void ImportTiposRefacciones()
            {
                List<Aztlan.Entities.TiposRefacciones> tiposrefaccionesAztlan = Aztlan.Entities.TiposRefacciones.Read();
                foreach (Aztlan.Entities.TiposRefacciones TiposRefaccionesAztlan in tiposrefaccionesAztlan)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesAztlan.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesAztlan.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesAztlan.Descripcion;

                    centralTiposRefacciones.Create(true);

                    Console.WriteLine(String.Format("Registro actualizado TipoRefaccion_ID: {0}", centralTiposRefacciones.TipoRefaccion_ID));
                }	//	End foreach

            }	//	End Method SyncTiposRefacciones

            private int LocacionCentral(int locacionlocal)
            {
                int locacion = 0;
                switch (locacionlocal)
                {
                    case 1: locacion = 3; break;
                    case 2: locacion = 15; break;
                    case 3: locacion = 13; break;
                    case 4: locacion = 12; break;
                    case 5: locacion = 18; break;
                    case 6: locacion = 8; break;
                    case 7: locacion = 11; break;
                    case 8: locacion = 4; break;
                    case 9: locacion = 10; break;
                    case 10: locacion = 2; break;
                    case 11: locacion = 14; break;
                    case 12: locacion = 22; break;
                    case 13: locacion = 5; break;
                    case 14: locacion = 17; break;
                    case 15: locacion = 20; break;
                    case 16: locacion = 16; break;
                    case 17: locacion = 10; break;
                    case 18: locacion = 19; break;
                    case 19: locacion = 1; break;
                    case 20: locacion = 7; break;
                    case 21: locacion = 6; break;
                    case 22: locacion = 21; break;
                    case 23: locacion = 3; break;
                    case 24: locacion = 3; break;
                    case 25: locacion = 3; break;
                }

                return locacion;
            }

            public void SyncUnidadesInit()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.Unidades UnidadesAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                folio = 0;
                while (Aztlan.Entities.Unidades.Read(out UnidadesAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesAztlan.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesAztlan.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // Aztlan
                    centralUnidades.NumeroEconomico = UnidadesAztlan.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesAztlan.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesAztlan.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesAztlan.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesAztlan.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesAztlan.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesAztlan.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesAztlan.Locacion);

                    centralUnidades.Placas = (UnidadesAztlan.Concesion == null) ? "" : UnidadesAztlan.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesAztlan.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesAztlan.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesAztlan.Folio;
                    
                    if (Central.DB.Exists(
                            "Unidades", 
                            Param("Estacion_ID", Estacion),
                            Param("Referencia_ID", centralUnidades.Referencia_ID)
                        )
                    )
                    {
                        centralUnidades.Unidad_ID = Central.Entities.Unidades.Read(
                                Param("Estacion_ID", Estacion),
                                Param("Referencia_ID", centralUnidades.Referencia_ID)
                            ).Unidad_ID;

                        centralUnidades.Update();
                        Console.WriteLine(String.Format("Registro actualizado Unidad_ID: {0}, Num Eco {1}",
                            centralUnidades.Unidad_ID, centralUnidades.NumeroEconomico));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Registro creado Unidad_ID: {0}, Num Eco {1}",
                            centralUnidades.Unidad_ID, centralUnidades.NumeroEconomico));
                        centralUnidades.Create();
                    }                    
                }
            }	//	End Method SyncUnidades


            public void SyncUnidades()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                Aztlan.Entities.Unidades UnidadesAztlan;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.Unidades.Read(out UnidadesAztlan, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesAztlan.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesAztlan.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // Aztlan
                    centralUnidades.NumeroEconomico = UnidadesAztlan.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesAztlan.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesAztlan.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesAztlan.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesAztlan.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesAztlan.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesAztlan.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesAztlan.Locacion);

                    centralUnidades.Placas = (UnidadesAztlan.Concesion == null) ? "" : UnidadesAztlan.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesAztlan.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesAztlan.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesAztlan.Folio;


                    if (Central.DB.Exists("Unidades", Param("Unidad_ID", centralUnidades.Unidad_ID)))
                    {
                        centralUnidades.Update();
                    }
                    else
                    {
                        centralUnidades.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Unidad_ID: {0}", centralUnidades.Unidad_ID));
                }
            }	//	End Method SyncUnidades

            public void SyncUnidades_Kilometrajes()
            {
                string filter = "Fecha > @Fecha";

                string sort = "Fecha ASC";

                string sqlQry = "SELECT ISNULL(MAX(UK.Fecha),0) Fecha FROM Unidades_Kilometrajes UK " +
                    "INNER JOIN Unidades U ON UK.Unidad_ID = U.Unidad_ID WHERE U.Estacion_ID = @Estacion";

                Aztlan.Entities.RegistroKilometrajesUnidades Unidades_KilometrajesAztlan;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.RegistroKilometrajesUnidades.Read(out Unidades_KilometrajesAztlan, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_KilometrajesAztlan.Fecha;

                    Central.Entities.Unidades_Kilometrajes centralUnidades_Kilometrajes = new Central.Entities.Unidades_Kilometrajes();

                    centralUnidades_Kilometrajes.Unidad_Kilometraje_ID = 0; // A determinar

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", Unidades_KilometrajesAztlan.Unidad));
                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_KilometrajesAztlan.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Kilometrajes.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesAztlan.ConductorActual)).Conductor_ID;

                    Central.Entities.Conductores conductor =
                         Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesAztlan.ConductorActual));

                    if (conductor == null)
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = null;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = conductor.Conductor_ID;
                    }

                    centralUnidades_Kilometrajes.Kilometraje = Unidades_KilometrajesAztlan.Kilometraje;
                    centralUnidades_Kilometrajes.Fecha = Unidades_KilometrajesAztlan.Fecha;

                    if (Central.DB.Exists("Unidades_Kilometrajes", Param("Unidad_Kilometraje_ID", centralUnidades_Kilometrajes.Unidad_Kilometraje_ID)))
                    {
                        centralUnidades_Kilometrajes.Update();
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Unidad_Kilometraje_ID: {0}", centralUnidades_Kilometrajes.Unidad_Kilometraje_ID));
                }
            }	//	End Method SyncUnidades_Kilometrajes

            //  Unidades Locaciones
            public void SyncUnidades_Locaciones()
            {
                string filter = "Fecha > @Fecha";

                string sort = "Fecha ASC";

                string sqlQry = "SELECT ISNULL(MAX(UL.Fecha),0) Fecha FROM Unidades_Locaciones UL " +
                    "INNER JOIN Unidades U ON UL.Unidad_ID = U.Unidad_ID WHERE U.Estacion_ID = @Estacion";

                Aztlan.Entities.RegistroLocacionesUnidades Unidades_LocacionesAztlan;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Aztlan.Entities.RegistroLocacionesUnidades.Read(out Unidades_LocacionesAztlan, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_LocacionesAztlan.Fecha;

                    Central.Entities.Unidades_Locaciones centralUnidades_Locaciones = new Central.Entities.Unidades_Locaciones();

                    Central.Entities.Unidades unidad =
                        Central.Entities.Unidades.Read(
                            Param("Estacion_ID", this.Estacion),
                                Param("Referencia_ID", Unidades_LocacionesAztlan.Unidad));

                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_LocacionesAztlan.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Locaciones.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Locaciones.LocacionUnidad_ID = LocacionCentral(Unidades_LocacionesAztlan.Locacion); // A consultar

                    centralUnidades_Locaciones.Fecha = Unidades_LocacionesAztlan.Fecha;


                    if (Central.DB.Exists("Unidades_Locaciones", Param("Unidad_Locacion_ID", centralUnidades_Locaciones.Unidad_Locacion_ID)))
                    {
                        centralUnidades_Locaciones.Update();
                    }
                    else
                    {
                        centralUnidades_Locaciones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Unidad_Locacion_ID: {0}", centralUnidades_Locaciones.Unidad_Locacion_ID));
                }

            }	//	End Method SyncUnidades_Locaciones

            //  ValesPrepagados
            public void SyncValesPrepagados()
            {
                string filter = "Codigo > @Codigo";

                string sort = "Codigo ASC";

                string sqlQry = "SELECT ISNULL(MAX(ValePrepagado_ID),'') ValePrepagado_ID FROM ValesPrepagados";

                Aztlan.Entities.ValesPrepagados ValesPrepagadosAztlan;
                string vale;

                vale = Convert.ToString(Central.DB.QueryScalar(sqlQry));

                while (Aztlan.Entities.ValesPrepagados.Read(out ValesPrepagadosAztlan, 1, filter, sort, Param("@Codigo", vale)))
                {
                    vale = ValesPrepagadosAztlan.Codigo;

                    Central.Entities.ValesPrepagados centralValesPrepagados = new Central.Entities.ValesPrepagados();
                    centralValesPrepagados.ValePrepagado_ID = ValesPrepagadosAztlan.Codigo;

                    if (ValesPrepagadosAztlan.Cliente == 0) continue;

                    int empresacliente_id = Central.Entities.Empresas.Read(Param("Rfc", ValesPrepagadosAztlan.Clientes.Rfc))[0].Empresa_ID;
                    centralValesPrepagados.EmpresaCliente_ID = empresacliente_id;

                    centralValesPrepagados.Usuario_ID = ValesPrepagadosAztlan.UsuarioEmision;
                    centralValesPrepagados.EstatusValePrepagado_ID = ValesPrepagadosAztlan.Status;
                    centralValesPrepagados.FolioDiario = ValesPrepagadosAztlan.FolioDiario;
                    centralValesPrepagados.Denominacion = ValesPrepagadosAztlan.Denominacion;
                    centralValesPrepagados.FechaEmision = ValesPrepagadosAztlan.FechaEmision;
                    centralValesPrepagados.FechaExpiracion = ValesPrepagadosAztlan.FechaExpiracion;

                    //  Se obtiene del recibo
                    if (ValesPrepagadosAztlan.RecibosValesPrepagados != null)
                    {
                        Central.Entities.Tickets ticket =
                            Central.Entities.Tickets.Read(
                            Param("Referencia_ID", ValesPrepagadosAztlan.Recibos.Folio),
                            Param("Estacion_ID", Estacion));

                        if (ticket != null)
                        {
                            centralValesPrepagados.Ticket_ID = ticket.Ticket_ID;
                        }
                        centralValesPrepagados.FechaCanje = ValesPrepagadosAztlan.Recibos.Fecha;
                    }
                    else
                    {
                        centralValesPrepagados.Ticket_ID = null;
                        centralValesPrepagados.FechaCanje = null;
                    }

                    centralValesPrepagados.Usuario_ID = centralValesPrepagados.Usuario_ID.Trim();

                    if (string.IsNullOrEmpty(centralValesPrepagados.Usuario_ID))
                    {
                        centralValesPrepagados.Usuario_ID = "SICAS";
                    }

                    //  Si usuario no existe
                    if (!Central.DB.Exists("Usuarios", Param("Usuario_ID", centralValesPrepagados.Usuario_ID)))
                    {
                        //  Crearlo dinámicamente
                        string usuario_id = centralValesPrepagados.Usuario_ID;
                        Central.Entities.Usuarios usuario = new Central.Entities.Usuarios();
                        usuario.Activo = false;
                        usuario.Apellidos = usuario_id;
                        usuario.Email = "";
                        usuario.Empresa_ID = null;
                        usuario.Estacion_ID = null;
                        usuario.Nombre = usuario_id;
                        usuario.pwd = Central.DB.PwdEncrypt(usuario_id);
                        usuario.Usuario_ID = usuario_id;
                        usuario.Create();
                    }

                    if (Central.DB.Exists("ValesPrepagados", Param("ValePrepagado_ID", centralValesPrepagados.ValePrepagado_ID)))
                    {
                        centralValesPrepagados.Update();
                    }
                    else
                    {
                        centralValesPrepagados.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado vales: {0}", centralValesPrepagados.ValePrepagado_ID));

                } // End While

            }	//	End Method SyncValesPrepagados

            private decimal DenominacionPlanillas(decimal precio)
            {
                decimal denominacion = 0;
                switch ((int)precio)
                {
                    case 1: denominacion = 10; break;
                    case 5: denominacion = 50; break;
                }

                return denominacion;
            }

            //  Planillas Fiscales
            public void SyncPlanillasFiscales()
            {
                string sqlQry = "SELECT ISNULL(MAX(Fecha),'') Fecha FROM PlanillasFiscales WHERE Estacion_ID = @Estacion_ID";
                DateTime fecha;
                fecha = Convert.ToDateTime(
                    Central.DB.QueryScalar(
                    sqlQry,
                    Param("@Estacion_ID", Estacion)
                    )
                    );

                List<Aztlan.Entities.PlanillasFiscales> Planillas;

                List<DateTime> fechas =
                    (List<DateTime>)Aztlan.DB.QueryList<DateTime>(
                    "SELECT DISTINCT FechaAlta FROM PlanillasFiscales WHERE FechaAlta >= @Fecha",
                    "FechaAlta",
                    Param("@Fecha", fecha));

                int cont = fechas.Count;

                foreach (DateTime f in fechas)
                {
                    Planillas = Aztlan.Entities.PlanillasFiscales.ReadList(Param("FechaAlta", f));

                    foreach (Aztlan.Entities.PlanillasFiscales PlanillasFiscalesAztlan in Planillas)
                    {
                        Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();

                        if (PlanillasFiscalesAztlan.RecibosPlanillas == null)
                        {
                            centralPlanillasFiscales.Ticket_ID = null;
                        }
                        else
                        {
                            centralPlanillasFiscales.Ticket_ID =
                                Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", PlanillasFiscalesAztlan.RecibosPlanillas.Recibo),
                                        Param("Estacion_ID", Estacion)).Ticket_ID;
                        }

                        //  Mediante funcion
                        centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesAztlan.Precio);
                        centralPlanillasFiscales.Estacion_ID = PlanillasFiscalesAztlan.Estacion; // Aztlan
                        centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesAztlan.Status;
                        centralPlanillasFiscales.Serie = PlanillasFiscalesAztlan.Serie;
                        centralPlanillasFiscales.Folio = PlanillasFiscalesAztlan.Folio;
                        centralPlanillasFiscales.Precio = PlanillasFiscalesAztlan.Precio;
                        centralPlanillasFiscales.Fecha = PlanillasFiscalesAztlan.FechaAlta;


                        if (Central.DB.Exists("PlanillasFiscales", Param("Estacion_ID", PlanillasFiscalesAztlan.Estacion),
                            Param("Serie", PlanillasFiscalesAztlan.Serie), Param("Folio", PlanillasFiscalesAztlan.Folio)))
                        {
                            centralPlanillasFiscales.Update();
                        }
                        else
                        {
                            centralPlanillasFiscales.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado planillas: {0}", centralPlanillasFiscales.Folio));
                    }
                }
            }

        }   //  End Class     

    }
}
