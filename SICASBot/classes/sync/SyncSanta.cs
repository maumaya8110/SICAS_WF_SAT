using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SICASBot.Sync
{
    public partial class Syncronization
    {
        public class SynSantaCatarina
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
                //SyncUnidadesInit();
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
                        Console.WriteLine("Comenzando con la sincronizacion. Estacion: SantaCatarina");
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

            private int Estacion = 9; // SantaCatarina
            private int Empresa = 2; // CAM

            private KeyValuePair<string, object> Param(string key, object value)
            {
                return new KeyValuePair<string, object>(key, value);
            }

            public void SyncHistorialCobranzaConductores()
            {
                List<SantaCatarina.Entities.HistorialConductor> historialcobranzaconductoresSantaCatarina =
                    SantaCatarina.Entities.HistorialConductor.Read();
                foreach (SantaCatarina.Entities.HistorialConductor HistorialCobranzaConductoresSantaCatarina in historialcobranzaconductoresSantaCatarina)
                {
                    Central.Entities.HistorialCobranzaConductores centralHistorialCobranzaConductores = new Central.Entities.HistorialCobranzaConductores();

                    centralHistorialCobranzaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", HistorialCobranzaConductoresSantaCatarina.Conductor)).Conductor_ID;
                    centralHistorialCobranzaConductores.Usuario_ID = HistorialCobranzaConductoresSantaCatarina.Usuario.Replace("+", "").Replace("%c3%b1", "ñ");
                    centralHistorialCobranzaConductores.Estacion_ID = Estacion;
                    centralHistorialCobranzaConductores.Accion = HistorialCobranzaConductoresSantaCatarina.Accion;
                    centralHistorialCobranzaConductores.Comentario = HistorialCobranzaConductoresSantaCatarina.Comentario;
                    centralHistorialCobranzaConductores.Referencia_ID = HistorialCobranzaConductoresSantaCatarina.Folio;
                    centralHistorialCobranzaConductores.Fecha = HistorialCobranzaConductoresSantaCatarina.Fecha;


                    if (Central.DB.Exists("HistorialCobranzaConductores",
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", HistorialCobranzaConductoresSantaCatarina.Folio)))
                    {
                        centralHistorialCobranzaConductores.Update();
                    }
                    else
                    {
                        centralHistorialCobranzaConductores.Create();
                    }

                    Console.WriteLine(string.Format("Historial conductor actualizado {0}", HistorialCobranzaConductoresSantaCatarina.Folio));
                }	//	End foreach

            }	//	End Method SyncHistorialCobranzaConductores

            public void SyncCuentaDepositosGarantia()
            {
                List<SantaCatarina.Entities.CuentaDepositosGarantia> Depositos =
                    SantaCatarina.Entities.CuentaDepositosGarantia.Read();

                foreach (SantaCatarina.Entities.CuentaDepositosGarantia Deposito in Depositos)
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


            public void SyncUpdateSesiones()
            {
                List<SantaCatarina.Entities.ControlCajas> Sesiones = SantaCatarina.Entities.ControlCajas.Read();
                foreach (SantaCatarina.Entities.ControlCajas SesionesSantaCatarina in Sesiones)
                {
                    int sesion = SesionesSantaCatarina.Sesion;

                    Central.Entities.Sesiones centralSesiones =
                        Central.Entities.Sesiones.Read(
                        Param("Referencia_ID", sesion),
                        Param("Estacion_ID", Estacion));

                    centralSesiones.FechaInicial = SesionesSantaCatarina.Inicio;
                    centralSesiones.FechaFinal = SesionesSantaCatarina.Corte;
                    centralSesiones.Activo = (SesionesSantaCatarina.Corte == null) ? true : false;

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

            public void SyncDetalleConductores()
            {
                //string filter = "Conductor > @Conductor AND MensajeACaja IS NOT NULL";

                //string sort = "Conductor ASC";

                //SantaCatarina.Entities.DetalleConductor ConductoresSantaCatarina;
                Console.WriteLine("Leyendo detalle conductores");
                int folio = 0;

                int count = SantaCatarina.DB.GetCount("DetalleConductor");
                int cont = 0;

                List<SantaCatarina.Entities.DetalleConductor> DetallesConductor = SantaCatarina.Entities.DetalleConductor.Read();
                foreach (SantaCatarina.Entities.DetalleConductor ConductoresSantaCatarina in DetallesConductor)
                {
                    cont++;
                    folio = ConductoresSantaCatarina.Conductor;

                    Central.Entities.Conductores centralConductor =
                        Central.Entities.Conductores.Read(
                        Param("Referencia_ID", folio),
                        Param("Estacion_ID", Estacion));

                    centralConductor.BloquearConductor = ConductoresSantaCatarina.BloquearConductor;
                    centralConductor.Cronocasco = ConductoresSantaCatarina.Cronocasco;
                    centralConductor.MensajeACaja = ConductoresSantaCatarina.MensajeACaja;
                    centralConductor.SaldoATratar = ConductoresSantaCatarina.SaldoATratar;
                    centralConductor.TerminalDatos = ConductoresSantaCatarina.TerminalDatos;
                    centralConductor.Update();

                    Console.WriteLine(String.Format("Registro actualizado DetalleConductor_ID: {0}, {1} de {2}",
                        centralConductor.Referencia_ID, cont, count));
                }

                //while (SantaCatarina.Entities.DetalleConductor.Read(out ConductoresSantaCatarina, 1, filter, sort, Param("Conductor", folio)))
                //{

                //}

            }   //  End Method

            public void SyncPlanesDeRenta()
            {
                List<SantaCatarina.Entities.Planes> planesderentaSantaCatarina = SantaCatarina.Entities.Planes.Read();
                foreach (SantaCatarina.Entities.Planes PlanesDeRentaSantaCatarina in planesderentaSantaCatarina)
                {
                    Central.Entities.PlanesDeRenta centralPlanesDeRenta = new Central.Entities.PlanesDeRenta();
                    centralPlanesDeRenta.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(
                        Param("Referencia_id",
                        (int)PlanesDeRentaSantaCatarina.Modelo),
                        Param("EmpresaReferencia", Estacion)
                        ).ModeloUnidad_ID;
                    centralPlanesDeRenta.Usuario_ID = PlanesDeRentaSantaCatarina.UsuarioAlta;
                    centralPlanesDeRenta.DiasDeCobro_ID = PlanesDeRentaSantaCatarina.DiasDeCobro.Value;
                    centralPlanesDeRenta.Descripcion = PlanesDeRentaSantaCatarina.Descripcion;
                    centralPlanesDeRenta.RentaBase = PlanesDeRentaSantaCatarina.RentaBase;
                    centralPlanesDeRenta.FondoResidual = PlanesDeRentaSantaCatarina.FondoResidual;
                    centralPlanesDeRenta.Fecha = PlanesDeRentaSantaCatarina.FechaAlta;
                    centralPlanesDeRenta.Activo = (PlanesDeRentaSantaCatarina.Status == 1);
                    centralPlanesDeRenta.Referencia_ID = PlanesDeRentaSantaCatarina.Folio;
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

                    Console.WriteLine(String.Format("Registro actualizado Plan de Renta: {0}", PlanesDeRentaSantaCatarina.Folio));

                }	//	End foreach

            }	//	End Method SyncPlanesDeRenta

            public void SyncUpdateContratos()
            {
                Console.WriteLine("Update Contratos");

                List<SantaCatarina.Entities.Contratos> ContratosSantaCatarina = SantaCatarina.Entities.Contratos.Read();
                foreach (SantaCatarina.Entities.Contratos contrato in ContratosSantaCatarina)
                {
                    Central.Entities.Contratos c =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", contrato.Folio));

                    c.FechaFinal = contrato.FechaFinal;
                    c.EstatusContrato_ID = (contrato.Status == 1) ? 1 : contrato.Status + 7;
                    c.MontoDiario = contrato.Planes.RentaBase;
                    c.Update("FechaFinal", "EstatusContrato_ID", "MontoDiario");
                    Console.WriteLine(string.Format("Actualizado contrato {0}:", contrato.Folio));
                }
            }

            //  Contratos Liquidados
            public void SyncContratosLiquidados()
            {
                Console.WriteLine("Leyendo contratos liquidados");
                List<SantaCatarina.Entities.ContratosLiquidados> contratosliquidadosSantaCatarina = SantaCatarina.Entities.ContratosLiquidados.Read();
                foreach (SantaCatarina.Entities.ContratosLiquidados ContratosLiquidadosSantaCatarina in contratosliquidadosSantaCatarina)
                {
                    Central.Entities.ContratosLiquidados centralContratosLiquidados = new Central.Entities.ContratosLiquidados();
                    centralContratosLiquidados.ContratoLiquidado_ID = ContratosLiquidadosSantaCatarina.Folio;

                    centralContratosLiquidados.Contrato_ID =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosSantaCatarina.Contrato)
                        ).Contrato_ID; // Consultar contrato

                    centralContratosLiquidados.Conductor_ID =
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosSantaCatarina.Conductor)
                        ).Conductor_ID;

                    centralContratosLiquidados.Unidad_ID =
                        Central.Entities.Unidades.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosSantaCatarina.Unidad)
                        ).Unidad_ID;

                    centralContratosLiquidados.LocacionUnidad_ID = LocacionCentral(ContratosLiquidadosSantaCatarina.LocacionUnidad);

                    centralContratosLiquidados.EstatusConductor_ID =
                        (ContratosLiquidadosSantaCatarina.StatusConductor == 1) ? 1 : ContratosLiquidadosSantaCatarina.StatusConductor + 4;

                    centralContratosLiquidados.EstatusContrato_ID =
                        (ContratosLiquidadosSantaCatarina.StatusContrato == 1) ? 1 : ContratosLiquidadosSantaCatarina.StatusContrato + 7;

                    centralContratosLiquidados.Comentarios = ContratosLiquidadosSantaCatarina.Comentario;
                    centralContratosLiquidados.Fecha = ContratosLiquidadosSantaCatarina.Fecha;
                    centralContratosLiquidados.Usuario_ID = ContratosLiquidadosSantaCatarina.Usuario.Trim();


                    if (Central.DB.Exists("ContratosLiquidados", Param("ContratoLiquidado_ID", centralContratosLiquidados.ContratoLiquidado_ID)))
                    {
                        centralContratosLiquidados.Update();
                    }
                    else
                    {
                        centralContratosLiquidados.Create();
                    }

                    Console.WriteLine(string.Format("Actualizado contrato liquidado {0}", ContratosLiquidadosSantaCatarina.Folio));
                }	//	End foreach

            }	//	End Method SyncContratosLiquidados					

            //  Estatus de ordenes de compras
            public void SyncEstatusOrdenesCompras()
            {
                List<SantaCatarina.Entities.StatusOrdenesCompra> estatusordenescomprasSantaCatarina = SantaCatarina.Entities.StatusOrdenesCompra.Read();
                foreach (SantaCatarina.Entities.StatusOrdenesCompra EstatusOrdenesComprasSantaCatarina in estatusordenescomprasSantaCatarina)
                {
                    Central.Entities.EstatusOrdenesCompras centralEstatusOrdenesCompras = new Central.Entities.EstatusOrdenesCompras();
                    centralEstatusOrdenesCompras.EstatusOrdenCompra_ID = EstatusOrdenesComprasSantaCatarina.Folio;
                    centralEstatusOrdenesCompras.Nombre = EstatusOrdenesComprasSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.StatusOrdenesServicio> estatusordenesserviciosSantaCatarina = SantaCatarina.Entities.StatusOrdenesServicio.Read();
                foreach (SantaCatarina.Entities.StatusOrdenesServicio EstatusOrdenesServiciosSantaCatarina in estatusordenesserviciosSantaCatarina)
                {
                    Central.Entities.EstatusOrdenesServicios centralEstatusOrdenesServicios = new Central.Entities.EstatusOrdenesServicios();
                    centralEstatusOrdenesServicios.EstatusOrdenServicio_ID = EstatusOrdenesServiciosSantaCatarina.Folio;
                    centralEstatusOrdenesServicios.Nombre = EstatusOrdenesServiciosSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.MovimientosDirectosAInventario> movsInventario = new List<SantaCatarina.Entities.MovimientosDirectosAInventario>();
                movsInventario = SantaCatarina.Entities.MovimientosDirectosAInventario.Read();

                foreach (SantaCatarina.Entities.MovimientosDirectosAInventario mov in movsInventario)
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
                List<SantaCatarina.Entities.OrdenesTrabajoCanceladas> ordenesCanceladas = SantaCatarina.Entities.OrdenesTrabajoCanceladas.Read();

                foreach (SantaCatarina.Entities.OrdenesTrabajoCanceladas ordenCancelada in ordenesCanceladas)
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
                List<SantaCatarina.Entities.CategoriasMecanicos> categoriasSantaCatarina = SantaCatarina.Entities.CategoriasMecanicos.Read();

                foreach (SantaCatarina.Entities.CategoriasMecanicos SantaCatarinacategoria in categoriasSantaCatarina)
                {
                    Central.Entities.CategoriasMecanicos centralCategoria = new Central.Entities.CategoriasMecanicos();
                    centralCategoria.CategoriaMecanico_ID = SantaCatarinacategoria.Folio;
                    centralCategoria.Familia_ID = SantaCatarinacategoria.Familia;
                    centralCategoria.Nombre = SantaCatarinacategoria.Descripcion;

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
                    List<SantaCatarina.Entities.Compras> comprasSantaCatarina = SantaCatarina.Entities.Compras.Read(Param("OrdenCompra", ordencompra));

                    foreach (SantaCatarina.Entities.Compras SantaCatarinacompra in comprasSantaCatarina)
                    {
                        Central.Entities.Compras centralCompra = new Central.Entities.Compras();
                        centralCompra.Cantidad = SantaCatarinacompra.Cantidad;
                        centralCompra.Compra_ID = 0;
                        centralCompra.CostoUnitario = SantaCatarinacompra.CostoUnitario;
                        centralCompra.Fecha = SantaCatarinacompra.FechaAlta;
                        centralCompra.MarcaRefaccion_ID = SantaCatarinacompra.Marca;
                        centralCompra.OrdenCompra_ID = SantaCatarinacompra.OrdenCompra;
                        centralCompra.Refaccion_ID = SantaCatarinacompra.Refaccion;
                        centralCompra.RefaccionesSurtidas = (int)Central.DB.GetNullableInt32(SantaCatarinacompra.RefSurtidas);
                        centralCompra.Usuario_ID = SantaCatarinacompra.UsuarioAlta;

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

                SantaCatarina.Entities.Concesiones ConcesionesSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.Concesiones.Read(out ConcesionesSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConcesionesSantaCatarina.Folio;

                    Central.Entities.Concesiones centralConcesion = new Central.Entities.Concesiones();
                    centralConcesion.Activo = (ConcesionesSantaCatarina.Status == 1) ? true : false;

                    centralConcesion.Placa = ConcesionesSantaCatarina.Placa;
                    centralConcesion.Referencia_ID = ConcesionesSantaCatarina.Folio;
                    centralConcesion.TipoConcesion_ID = ConcesionesSantaCatarina.Tipo;
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
                string sqlup = "UPDATE Conductores SET UsuarioAlta = 'cynthia.aviña' WHERE UsuarioAlta = 'cynthia.aviÃ±a'";
                SantaCatarina.DB.ExecuteQuery(sqlup);

                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Conductores WHERE Estacion_ID = @Estacion";

                SantaCatarina.Entities.Conductores ConductoresSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.Conductores.Read(out ConductoresSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConductoresSantaCatarina.Folio;

                    Central.Entities.Conductores centralConductor = new Central.Entities.Conductores();
                    centralConductor.ActaNacimiento = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.ActaNacimiento;
                    centralConductor.AñosExperiencia = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? null : (Int32?)(AppHelper.IsNull(ConductoresSantaCatarina.RegistroPublicitarioConductor.AñosExperiencia, 0));
                    centralConductor.Apellidos = ConductoresSantaCatarina.ApellidoPaterno + " " + ConductoresSantaCatarina.ApellidoMaterno;
                    centralConductor.Apellidos_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.ApellidoPaterno + " " + ConductoresSantaCatarina.AvalConductor.ApellidoMaterno;
                    centralConductor.BloquearConductor = (ConductoresSantaCatarina.Detalle == null) ? false : ConductoresSantaCatarina.Detalle.BloquearConductor;
                    centralConductor.CartaNoAntecedentes = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.CartaNoAntecedentes;
                    centralConductor.Ciudad = ConductoresSantaCatarina.Ciudad;
                    centralConductor.Ciudad_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Ciudad;
                    centralConductor.CodigoPostal = ConductoresSantaCatarina.CP.ToString();
                    centralConductor.CodigoPostal_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.CP.ToString();
                    centralConductor.Comentarios = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? "" : ConductoresSantaCatarina.RegistroPublicitarioConductor.Comentarios;
                    centralConductor.ComprobanteDomicilio = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.ComprobanteDomicilio;
                    centralConductor.ComprobanteDomicilio_Aval = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.ComprobanteDomicilioAval;
                    centralConductor.Conductor_ID = 0;
                    centralConductor.CredencialElector = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.CredencialElector;
                    centralConductor.CredencialElector_Aval = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.CredencialElectorAval;
                    centralConductor.Cronocasco = (ConductoresSantaCatarina.Detalle == null) ? false : ConductoresSantaCatarina.Detalle.Cronocasco;
                    centralConductor.CumplioPerfil = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? false : ConductoresSantaCatarina.RegistroPublicitarioConductor.CumplioPerfil;
                    centralConductor.CURP = ConductoresSantaCatarina.Curp;
                    centralConductor.Curp_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Curp;
                    centralConductor.Domicilio = ConductoresSantaCatarina.Calle + " No. " + ConductoresSantaCatarina.NumeroCasa + ", Col. " + ConductoresSantaCatarina.Colonia;
                    centralConductor.Domicilio_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Calle + " No. " + ConductoresSantaCatarina.AvalConductor.NumeroCasa + ", Col. " + ConductoresSantaCatarina.AvalConductor.Colonia;
                    centralConductor.Edad = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? null : (int?)(AppHelper.IsNull(ConductoresSantaCatarina.RegistroPublicitarioConductor.Edad, 0));
                    centralConductor.Email = ConductoresSantaCatarina.CorreoElectronico;
                    centralConductor.Email_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.CorreoElectronico;
                    centralConductor.Entidad = ConductoresSantaCatarina.Estado;
                    centralConductor.Estacion_ID = this.Estacion; // SantaCatarina
                    centralConductor.Estado_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Estado;
                    centralConductor.EstadoCivil = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? "" : ConductoresSantaCatarina.RegistroPublicitarioConductor.EstadoCivil;
                    centralConductor.EstatusConductor_ID = (ConductoresSantaCatarina.Status == 1) ? 1 : ConductoresSantaCatarina.Status + 4; // Convertir
                    centralConductor.Fecha = ConductoresSantaCatarina.FechaAlta;
                    centralConductor.FolioLicencia = (ConductoresSantaCatarina.Licencia == null) ? "" : ConductoresSantaCatarina.Licencia.Folio.ToString();
                    centralConductor.Fotografia = null; //    Esta no se lleva    // Hay que actualizar el proceso de creación y actualización
                    centralConductor.Genero = "M";
                    centralConductor.Interesado = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? false : ConductoresSantaCatarina.RegistroPublicitarioConductor.Interesado;
                    centralConductor.MedioPublicitario_ID = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresSantaCatarina.RegistroPublicitarioConductor.MedioPublicitario;
                    centralConductor.MensajeACaja = (ConductoresSantaCatarina.Detalle == null) ? "" : ConductoresSantaCatarina.Detalle.MensajeACaja;
                    centralConductor.Mercado_ID = (ConductoresSantaCatarina.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresSantaCatarina.RegistroPublicitarioConductor.PlanEmpresarial; // Hay que hacer el mapeo correcto
                    centralConductor.Movil = null;
                    centralConductor.Nombre = ConductoresSantaCatarina.Nombre;
                    centralConductor.Nombre_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Nombre;
                    centralConductor.Referencia_ID = ConductoresSantaCatarina.Folio;
                    centralConductor.RFC = ConductoresSantaCatarina.Rfc;
                    centralConductor.Rfc_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Rfc;
                    centralConductor.SaldoATratar = (ConductoresSantaCatarina.Detalle == null) ? 0 : ConductoresSantaCatarina.Detalle.SaldoATratar;
                    centralConductor.Solicitud = (ConductoresSantaCatarina.DocumentacionConductor == null) ? "" : ConductoresSantaCatarina.DocumentacionConductor.Solicitud;
                    centralConductor.Telefono = ConductoresSantaCatarina.Telefono;
                    centralConductor.Telefono_Aval = (ConductoresSantaCatarina.AvalConductor == null) ? "" : ConductoresSantaCatarina.AvalConductor.Telefono;
                    centralConductor.Telefono2 = null;
                    centralConductor.TerminalDatos = (ConductoresSantaCatarina.Detalle == null) ? false : ConductoresSantaCatarina.Detalle.TerminalDatos;
                    centralConductor.TipoLicencia_ID = (ConductoresSantaCatarina.Licencia == null) ? null : (int?)ConductoresSantaCatarina.Licencia.Tipo; // Revisar si entra directo
                    centralConductor.Usuario_ID = ConductoresSantaCatarina.UsuarioAlta;
                    centralConductor.VenceLicencia = (ConductoresSantaCatarina.Licencia == null) ? null : (DateTime?)ConductoresSantaCatarina.Licencia.FechaVencimiento;

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

                //List<SantaCatarina.Entities.Conductores> conductoresSantaCatarina = SantaCatarina.Entities.Conductores.Read();

                //foreach (SantaCatarina.Entities.Conductores SantaCatarinaconductor in conductoresSantaCatarina)
                //{

                //}   //  End foreach
            }   //  End Method

            //  Contratos
            public void SyncContratos()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Contratos WHERE Estacion_ID = @Estacion";

                SantaCatarina.Entities.Contratos ContratosSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.Contratos.Read(out ContratosSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ContratosSantaCatarina.Folio;

                    Central.Entities.Contratos centralContrato = new Central.Entities.Contratos();
                    centralContrato.CobroPermanente = (ContratosSantaCatarina.FechaFinal == null) ? true : false;
                    centralContrato.Comentarios = "";
                    centralContrato.Concepto_ID = 1;
                    centralContrato.Conductor_ID = Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", ContratosSantaCatarina.Conductor)).Conductor_ID;

                    // Si no existe el conductor copia, insertarlo y relacionarlo
                    if (ContratosSantaCatarina.Copia == null)
                    {
                        centralContrato.ConductorCopia_ID = null;
                    }
                    else
                    {
                        Central.Entities.Conductores cond = Central.Entities.Conductores.Read(Param("Rfc", ContratosSantaCatarina.Copia.Rfc));
                        if (cond == null)
                        {
                            //  Insertar conductor en Central
                            //  a partir de contratos copia
                            cond = new Central.Entities.Conductores();
                            cond.Apellidos = ContratosSantaCatarina.Copia.ApellidoPaterno + " " + ContratosSantaCatarina.Copia.ApellidoMaterno;
                            cond.Domicilio = ContratosSantaCatarina.Copia.Colonia + ", " + ContratosSantaCatarina.Copia.Calle + " No. " + ContratosSantaCatarina.Copia.NumeroCasa;
                            cond.Ciudad = ContratosSantaCatarina.Copia.Ciudad;
                            cond.Email = ContratosSantaCatarina.Copia.CorreoElectronico;
                            cond.CodigoPostal = ContratosSantaCatarina.Copia.CP.ToString();
                            cond.CURP = ContratosSantaCatarina.Copia.Curp;
                            cond.Entidad = ContratosSantaCatarina.Copia.Estado;
                            cond.Fecha = ContratosSantaCatarina.Copia.FechaAlta;
                            cond.Nombre = ContratosSantaCatarina.Copia.Nombre;
                            cond.RFC = ContratosSantaCatarina.Copia.Rfc;
                            cond.Telefono = ContratosSantaCatarina.Copia.Telefono;
                            cond.Usuario_ID = ContratosSantaCatarina.Copia.UsuarioAlta;
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
                    centralContrato.Descripcion = "Contrato de renta folio " + ContratosSantaCatarina.Folio.ToString();

                    //  Obtener los días de cobro
                    centralContrato.DiasDeCobro_ID = (int)ContratosSantaCatarina.Planes.DiasDeCobro;

                    if (ContratosSantaCatarina.Tipo == 3)
                    {
                        centralContrato.Empresa_ID = 5; // CCR
                    }
                    else
                    {
                        centralContrato.Empresa_ID = Empresa; // CAM
                    }
                    centralContrato.Estacion_ID = Estacion;
                    centralContrato.EstatusContrato_ID = (ContratosSantaCatarina.Status == 1) ? 1 : ContratosSantaCatarina.Status + 7;
                    centralContrato.FechaFinal = Central.DB.GetNullableDateTime(ContratosSantaCatarina.FechaFinal);
                    centralContrato.FechaInicial = ContratosSantaCatarina.FechaInicial;
                    centralContrato.FondoResidual = Convert.ToInt32(AppHelper.IsNull(ContratosSantaCatarina.Planes.FondoResidual, 0));
                    centralContrato.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(Param("referencia_id", (int)ContratosSantaCatarina.Planes.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralContrato.MontoDiario = ContratosSantaCatarina.Planes.RentaBase;
                    centralContrato.NumeroEconomico =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosSantaCatarina.Unidad)).NumeroEconomico;
                    centralContrato.TipoContrato_ID = (ContratosSantaCatarina.Tipo == 3) ? 2 : ContratosSantaCatarina.Tipo; // Si 3 entonces es CCR
                    centralContrato.Unidad_ID = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosSantaCatarina.Unidad)).Unidad_ID;
                    centralContrato.Referencia_ID = folio;
                    if (Central.DB.Exists("Contratos", Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosSantaCatarina.Folio)))
                    {
                        //  Obtener el contrato ID
                        centralContrato.Contrato_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Contratos", "Contrato_ID",
                                Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosSantaCatarina.Folio)));
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
                List<SantaCatarina.Entities.Usuarios> usuariosSantaCatarina = SantaCatarina.Entities.Usuarios.Read();
                foreach (SantaCatarina.Entities.Usuarios usuarioSantaCatarina in usuariosSantaCatarina)
                {
                    Central.Entities.Usuarios usuario = new Central.Entities.Usuarios();
                    usuario.Activo = (usuarioSantaCatarina.Status == 1) ? true : false;
                    usuario.Apellidos = usuarioSantaCatarina.ApellidoPaterno + " " + usuarioSantaCatarina.ApellidoMaterno;
                    usuario.Email = "";
                    usuario.Empresa_ID = Empresa; // CAM
                    usuario.Estacion_ID = Estacion; // SantaCatarina
                    usuario.Nombre = usuarioSantaCatarina.Nombre;
                    usuario.pwd = (byte[])Central.DB.QueryScalar(String.Format("SELECT PWDENCRYPT('{0}')", usuarioSantaCatarina.Pwd));
                    usuario.Usuario_ID = usuarioSantaCatarina.Clave;

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

                SantaCatarina.Entities.MovimientosCaja CuentaCajasSantaCatarina;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                maxfolio = Convert.ToInt32(SantaCatarina.DB.QueryScalar("SELECT MAX(Folio) MaxFolio FROM MovimientosCaja"));

                while (SantaCatarina.Entities.MovimientosCaja.Read(out CuentaCajasSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaCajasSantaCatarina.Folio;

                    Central.Entities.CuentaCajas centralCuentaCajas = new Central.Entities.CuentaCajas();
                    centralCuentaCajas.Referencia_ID = CuentaCajasSantaCatarina.Folio;
                    centralCuentaCajas.CuentaCaja_ID = 0;
                    if (CuentaCajasSantaCatarina.Sesion == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasSantaCatarina.Sesion),
                            Param("Estacion_ID", Estacion));
                        if (s == null) continue;
                        centralCuentaCajas.Sesion_ID = s.Sesion_ID;
                        centralCuentaCajas.Caja_ID = (int)Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasSantaCatarina.Sesion),
                            Param("Estacion_ID", Estacion)).Caja_ID;
                    }

                    //  La empresa tambien depende del fondo
                    centralCuentaCajas.Empresa_ID = EmpresaDeFondo(CuentaCajasSantaCatarina.Fondo);

                    centralCuentaCajas.Estacion_ID = Estacion;

                    centralCuentaCajas.Ticket_ID = null;    //  No esta supeditada a un ticket

                    centralCuentaCajas.Cuenta_ID = CuentaDeFondo(CuentaCajasSantaCatarina.Fondo); // De este dato obtener la cuenta

                    centralCuentaCajas.Concepto_ID = null; // No se lleva concepto

                    decimal abono, cargo;
                    if (CuentaCajasSantaCatarina.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaCajasSantaCatarina.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaCajasSantaCatarina.Monto);
                    }

                    centralCuentaCajas.Cargo = cargo; // De este dato depende
                    centralCuentaCajas.Abono = abono;
                    centralCuentaCajas.Saldo = 0; // Es calculado, meter dentro del create
                    centralCuentaCajas.Comentarios = "";
                    centralCuentaCajas.Fecha = CuentaCajasSantaCatarina.Fecha;
                    centralCuentaCajas.Usuario_ID = CuentaCajasSantaCatarina.Usuario;

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
                string sqlup = "UPDATE CuentaConductor SET UsuarioAlta = 'cynthia.aviña' WHERE UsuarioAlta = 'cynthia.aviÃ±a'";
                SantaCatarina.DB.ExecuteQuery(sqlup);

                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = string.Format(
                    "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaConductores WHERE Estacion_ID = {0}",
                    Estacion);

                SantaCatarina.Entities.CuentaConductor CuentaConductoresSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                int cont = SantaCatarina.DB.GetCount("CuentaConductor");

                while (SantaCatarina.Entities.CuentaConductor.Read(out CuentaConductoresSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaConductoresSantaCatarina.Folio;

                    Central.Entities.CuentaConductores centralCuentaConductores = new Central.Entities.CuentaConductores();
                    centralCuentaConductores.Referencia_ID = folio;
                    centralCuentaConductores.CuentaConductor_ID = 0;

                    //Obtener segun concepto
                    //Del concepto obtener la cuenta
                    int cuenta = SantaCatarina.Entities.Conceptos.Read(CuentaConductoresSantaCatarina.Concepto).Cuenta;
                    int fondo = SantaCatarina.Entities.Cuentas.Read(cuenta).FondoCaja;
                    //De la cuenta, obtener el fondo
                    //Del fondo, la empresa.
                    centralCuentaConductores.Empresa_ID = EmpresaDeFondo(fondo);

                    centralCuentaConductores.Estacion_ID = Estacion; // SantaCatarina

                    if (CuentaConductoresSantaCatarina.Unidad == 0)
                    {
                        centralCuentaConductores.Unidad_ID = null;
                    }
                    else
                    {
                        centralCuentaConductores.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresSantaCatarina.Unidad)).Unidad_ID;
                    }

                    centralCuentaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", CuentaConductoresSantaCatarina.Conductor)).Conductor_ID;

                    // Verificar la caja para obtener la estación
                    if (CuentaConductoresSantaCatarina.Caja == null)
                    {
                        centralCuentaConductores.Caja_ID = null;
                    }
                    else
                    {
                        centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresSantaCatarina.Caja)).Caja_ID;
                    }

                    //  Es posible que se pueda hacer referencia
                    //  Si folio tiene ticket local, buscar su ticket remoto
                    if (SantaCatarina.DB.Exists("RecibosMovimientos", Param("Movimiento", CuentaConductoresSantaCatarina.Folio)))
                    {
                        int recibo = (int)SantaCatarina.Entities.RecibosMovimientos.Read(Param("Movimiento", CuentaConductoresSantaCatarina.Folio)).Recibo;
                        int ticket_id = Central.Entities.Tickets.Read(Param("Referencia_ID", recibo), Param("Estacion_ID", Estacion)).Ticket_ID;
                        centralCuentaConductores.Ticket_ID = ticket_id;
                    }
                    else
                    {
                        centralCuentaConductores.Ticket_ID = null; // Ticket a null
                    }

                    centralCuentaConductores.Cuenta_ID = CuentaDeCuenta(cuenta);
                    centralCuentaConductores.Concepto_ID = ConceptoCentral(CuentaConductoresSantaCatarina.Concepto);

                    decimal abono, cargo;
                    if (CuentaConductoresSantaCatarina.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaConductoresSantaCatarina.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaConductoresSantaCatarina.Monto);
                    }

                    centralCuentaConductores.Cargo = cargo;
                    centralCuentaConductores.Abono = abono;
                    centralCuentaConductores.Saldo = 0; // Calculado
                    centralCuentaConductores.Comentarios = CuentaConductoresSantaCatarina.Comentarios;
                    centralCuentaConductores.Fecha = CuentaConductoresSantaCatarina.FechaAlta;
                    centralCuentaConductores.Usuario_ID = CuentaConductoresSantaCatarina.UsuarioAlta;

                    if (Central.DB.Exists("CuentaConductores", Param("CuentaConductor_ID", centralCuentaConductores.CuentaConductor_ID)))
                    {
                        //  Obtener la clave
                        centralCuentaConductores.Update();
                    }
                    else
                    {
                        centralCuentaConductores.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado CuentaConductor_ID: {0} de {1}",
                        centralCuentaConductores.Referencia_ID, cont));

                }
            }	//	End Method SyncCuentaConductores

            public void SyncFamilias()
            {
                List<SantaCatarina.Entities.Familias> familiasSantaCatarina = SantaCatarina.Entities.Familias.Read();
                foreach (SantaCatarina.Entities.Familias FamiliasSantaCatarina in familiasSantaCatarina)
                {
                    Central.Entities.Familias centralFamilias = new Central.Entities.Familias();
                    centralFamilias.Familia_ID = FamiliasSantaCatarina.Folio;
                    centralFamilias.Nombre = FamiliasSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.MarcasRefacciones> marcasrefaccionesSantaCatarina =
                    SantaCatarina.Entities.MarcasRefacciones.Read();
                foreach (SantaCatarina.Entities.MarcasRefacciones MarcasRefaccionesSantaCatarina in marcasrefaccionesSantaCatarina)
                {
                    Central.Entities.MarcasRefacciones centralMarcasRefacciones = new Central.Entities.MarcasRefacciones();
                    centralMarcasRefacciones.MarcaRefaccion_ID = MarcasRefaccionesSantaCatarina.Folio;
                    centralMarcasRefacciones.Nombre = MarcasRefaccionesSantaCatarina.Descripcion;

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
                List<SantaCatarina.Entities.StatusMecanicos> estatusmecanicosSantaCatarina = SantaCatarina.Entities.StatusMecanicos.Read();
                foreach (SantaCatarina.Entities.StatusMecanicos EstatusMecanicosSantaCatarina in estatusmecanicosSantaCatarina)
                {
                    Central.Entities.EstatusMecanicos centralEstatusMecanicos = new Central.Entities.EstatusMecanicos();
                    centralEstatusMecanicos.EstatusMecanico_ID = EstatusMecanicosSantaCatarina.Folio;
                    centralEstatusMecanicos.Nombre = EstatusMecanicosSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.Mecanicos> mecanicosSantaCatarina = SantaCatarina.Entities.Mecanicos.Read();
                foreach (SantaCatarina.Entities.Mecanicos MecanicosSantaCatarina in mecanicosSantaCatarina)
                {
                    Central.Entities.Mecanicos centralMecanicos = new Central.Entities.Mecanicos();
                    centralMecanicos.Mecanico_ID = MecanicosSantaCatarina.Folio;
                    centralMecanicos.CategoriaMecanico_ID = MecanicosSantaCatarina.Categoria;
                    centralMecanicos.EstatusMecanico_ID = MecanicosSantaCatarina.Status;
                    centralMecanicos.Usuario_ID = MecanicosSantaCatarina.UsuarioAlta;
                    centralMecanicos.Fecha = MecanicosSantaCatarina.FechaAlta;
                    centralMecanicos.CodigoBarras = MecanicosSantaCatarina.CodigoBarras;
                    centralMecanicos.Nombres = MecanicosSantaCatarina.Nombre;
                    centralMecanicos.Apellidos = MecanicosSantaCatarina.ApellidoPaterno + " " + MecanicosSantaCatarina.ApellidoMaterno;
                    centralMecanicos.Rfc = MecanicosSantaCatarina.Rfc;
                    centralMecanicos.Curp = MecanicosSantaCatarina.Curp;
                    centralMecanicos.NSS = MecanicosSantaCatarina.NumeroSeguroSocial;
                    centralMecanicos.Domicilio = MecanicosSantaCatarina.Calle + " No. " + MecanicosSantaCatarina.Numero + ", Col. " + MecanicosSantaCatarina.Colonia;
                    centralMecanicos.Ciudad = MecanicosSantaCatarina.Ciudad;
                    centralMecanicos.Entidad = MecanicosSantaCatarina.Estado;
                    centralMecanicos.CodigoPostal = MecanicosSantaCatarina.CodigoPostal.ToString();
                    centralMecanicos.Telefono = MecanicosSantaCatarina.Telefonos;
                    centralMecanicos.CorreoElectronico = MecanicosSantaCatarina.CorreoElectronico;
                    centralMecanicos.SalarioDiario = MecanicosSantaCatarina.SalarioDiario;
                    centralMecanicos.HorarioEntrada = MecanicosSantaCatarina.HorarioEntrada;
                    centralMecanicos.HorarioSalida = MecanicosSantaCatarina.HorarioSalida;


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
                List<SantaCatarina.Entities.ModelosTaller> modelosSantaCatarina = SantaCatarina.Entities.ModelosTaller.Read();
                foreach (SantaCatarina.Entities.ModelosTaller ModelosSantaCatarina in modelosSantaCatarina)
                {
                    Central.Entities.Modelos centralModelos = new Central.Entities.Modelos();
                    centralModelos.Modelo_ID = ModelosSantaCatarina.Folio;
                    centralModelos.Nombre = ModelosSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.Modelos> modelosunidadesSantaCatarina = SantaCatarina.Entities.Modelos.Read();
                foreach (SantaCatarina.Entities.Modelos ModelosUnidadesSantaCatarina in modelosunidadesSantaCatarina)
                {
                    Central.Entities.ModelosUnidades centralModelosUnidades = new Central.Entities.ModelosUnidades();
                    centralModelosUnidades.ModeloUnidad_ID = 0;

                    centralModelosUnidades.MarcaUnidad_ID = 1; // Actualizar posteriormente
                    centralModelosUnidades.Descripcion = ModelosUnidadesSantaCatarina.Descripcion;
                    centralModelosUnidades.PrecioLista = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesSantaCatarina.PrecioLista, 0));
                    centralModelosUnidades.Anio = ModelosUnidadesSantaCatarina.Año;
                    centralModelosUnidades.Deposito = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesSantaCatarina.Deposito, 0));
                    centralModelosUnidades.Activo = (ModelosUnidadesSantaCatarina.Status == 1) ? true : false;
                    centralModelosUnidades.referencia_id = ModelosUnidadesSantaCatarina.Folio;
                    centralModelosUnidades.EmpresaReferencia = Estacion; //    CAM


                    if (Central.DB.Exists(
                            "ModelosUnidades",
                            Param("Referencia_ID", ModelosUnidadesSantaCatarina.Folio),
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
                List<SantaCatarina.Entities.HistorialInventario> historialinventarioSantaCatarina = SantaCatarina.Entities.HistorialInventario.Read();
                foreach (SantaCatarina.Entities.HistorialInventario HistorialInventarioSantaCatarina in historialinventarioSantaCatarina)
                {
                    Central.Entities.MovimientosInventario centralMovimientosInventario = new Central.Entities.MovimientosInventario();
                    centralMovimientosInventario.MovimientoInventario_ID = 0;
                    int tipo = GetTipoMovimientoInventario(HistorialInventarioSantaCatarina.Tipo);
                    centralMovimientosInventario.TipoMovimientoInventario_ID = tipo;
                    centralMovimientosInventario.OrdenCompra_ID = (tipo == 2 || tipo == 4) ? Convert.ToInt32(HistorialInventarioSantaCatarina.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.OrdenTrabajo_ID = (tipo == 1 || tipo == 6) ? Convert.ToInt32(HistorialInventarioSantaCatarina.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.NotaAlmacen_ID = HistorialInventarioSantaCatarina.NotaAlmacen;
                    centralMovimientosInventario.AjusteInventario_ID = (tipo == 3) ? Convert.ToInt32(HistorialInventarioSantaCatarina.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.Usuario_ID = HistorialInventarioSantaCatarina.Usuario;
                    centralMovimientosInventario.Refaccion_ID = HistorialInventarioSantaCatarina.Refaccion;
                    centralMovimientosInventario.Fecha = HistorialInventarioSantaCatarina.Fecha;
                    centralMovimientosInventario.Cantidad = Convert.ToInt32(HistorialInventarioSantaCatarina.Cantidad);
                    centralMovimientosInventario.CostoUnitario = HistorialInventarioSantaCatarina.CostoUnitario;
                    centralMovimientosInventario.Valor = HistorialInventarioSantaCatarina.Valor;
                    centralMovimientosInventario.CantidadPrev = Convert.ToInt32(HistorialInventarioSantaCatarina.CantidadPrev);
                    centralMovimientosInventario.ValorPrev = HistorialInventarioSantaCatarina.ValorPrev;
                    centralMovimientosInventario.CantidadPost = Convert.ToInt32(HistorialInventarioSantaCatarina.CantidadPost);
                    centralMovimientosInventario.ValorPost = HistorialInventarioSantaCatarina.ValorPost;
                    centralMovimientosInventario.CantidadPrevProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPrevProm = 0; // Por calcular
                    centralMovimientosInventario.CantidadPostProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPostProm = 0; // Por calcular
                    centralMovimientosInventario.Referencia = HistorialInventarioSantaCatarina.Movimiento;


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
                List<SantaCatarina.Entities.NotasAlmacen> notasalmacenSantaCatarina = SantaCatarina.Entities.NotasAlmacen.Read();
                foreach (SantaCatarina.Entities.NotasAlmacen NotasAlmacenSantaCatarina in notasalmacenSantaCatarina)
                {
                    if (NotasAlmacenSantaCatarina.OrdenCompra != null && NotasAlmacenSantaCatarina.OrdenCompra == 0) continue;
                    if (NotasAlmacenSantaCatarina.OrdenTrabajo != null && NotasAlmacenSantaCatarina.OrdenTrabajo == 0) continue;

                    Central.Entities.NotasAlmacen centralNotasAlmacen = new Central.Entities.NotasAlmacen();
                    centralNotasAlmacen.NotaAlmacen_ID = NotasAlmacenSantaCatarina.NotaAlmacenID;
                    centralNotasAlmacen.Usuario_ID = NotasAlmacenSantaCatarina.Usuario;
                    centralNotasAlmacen.TipoMovimientoInventario_ID = (NotasAlmacenSantaCatarina.Tipo == "ENTRADA") ? 1 : 2;
                    centralNotasAlmacen.OrdenCompra_ID = NotasAlmacenSantaCatarina.OrdenCompra;
                    centralNotasAlmacen.OrdenTrabajo_ID = NotasAlmacenSantaCatarina.OrdenTrabajo;
                    centralNotasAlmacen.Fecha = NotasAlmacenSantaCatarina.Fecha;

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

                SantaCatarina.Entities.OrdenesCompras OrdenesComprasSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (SantaCatarina.Entities.OrdenesCompras.Read(out OrdenesComprasSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesComprasSantaCatarina.Folio;

                    Central.Entities.OrdenesCompras centralOrdenesCompras = new Central.Entities.OrdenesCompras();
                    centralOrdenesCompras.OrdenCompra_ID = OrdenesComprasSantaCatarina.Folio;

                    //  Obtener el proveedor
                    //  Los proveedores deben estar datos de alta en el sistema previamente
                    //  buscar por rfc
                    int proveedor = Central.Entities.Empresas.Read(Param("Rfc", OrdenesComprasSantaCatarina.Proveedores.Rfc))[0].Empresa_ID;
                    centralOrdenesCompras.Proveedor_ID = proveedor;
                    centralOrdenesCompras.EstatusOrdenCompra_ID = Convert.ToInt32(AppHelper.IsNull(OrdenesComprasSantaCatarina.Status, 1));
                    centralOrdenesCompras.Usuario_ID = OrdenesComprasSantaCatarina.UsuarioAlta;
                    centralOrdenesCompras.Fecha = OrdenesComprasSantaCatarina.FechaAlta;
                    centralOrdenesCompras.Factura = OrdenesComprasSantaCatarina.Factura;
                    centralOrdenesCompras.Subtotal = OrdenesComprasSantaCatarina.SubTotal;
                    centralOrdenesCompras.IVA = OrdenesComprasSantaCatarina.IVA;
                    centralOrdenesCompras.Total = OrdenesComprasSantaCatarina.Total;

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

                //List<SantaCatarina.Entities.OrdenesCompras> ordenescomprasSantaCatarina = SantaCatarina.Entities.OrdenesCompras.Read();
                //foreach (SantaCatarina.Entities.OrdenesCompras OrdenesComprasSantaCatarina in ordenescomprasSantaCatarina)
                //{                    


                //}	//	End foreach

            }	//	End Method SyncOrdenesCompras

            public void SyncOrdenesComprasCanceladas()
            {
                //  Ajustar con read
                List<SantaCatarina.Entities.OrdenesComprasCanceladas> ordenescomprascanceladasSantaCatarina = SantaCatarina.Entities.OrdenesComprasCanceladas.Read();
                foreach (SantaCatarina.Entities.OrdenesComprasCanceladas OrdenesComprasCanceladasSantaCatarina in ordenescomprascanceladasSantaCatarina)
                {
                    // si no tiene compra, no checar
                    if (!SantaCatarina.DB.Exists("OrdenesCompras", Param("Folio", OrdenesComprasCanceladasSantaCatarina.OrdenCompra))) continue;

                    Central.Entities.OrdenesComprasCanceladas centralOrdenesComprasCanceladas = new Central.Entities.OrdenesComprasCanceladas();
                    centralOrdenesComprasCanceladas.OrdenCompra_ID = OrdenesComprasCanceladasSantaCatarina.OrdenCompra;
                    centralOrdenesComprasCanceladas.Usuario_ID = OrdenesComprasCanceladasSantaCatarina.Usuario;
                    centralOrdenesComprasCanceladas.Fecha = OrdenesComprasCanceladasSantaCatarina.Fecha;
                    centralOrdenesComprasCanceladas.Comentarios = OrdenesComprasCanceladasSantaCatarina.Motivos;


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
                SantaCatarina.Entities.OrdenesServicio OrdenesServiciosSantaCatarina;
                string filter = "Folio > @Folio";
                string sort = "Folio ASC";
                int folio = Convert.ToInt32(Central.DB.QueryScalar("SELECT ISNULL(MAX(OrdenServicio_ID),0) folio FROM OrdenesServicios"));

                while (SantaCatarina.Entities.OrdenesServicio.Read(out OrdenesServiciosSantaCatarina, 1, filter, sort, Param("@Folio", folio)))
                {
                    try
                    {
                        Central.Entities.OrdenesTrabajos.Read(OrdenesServiciosSantaCatarina.OrdenTrabajo);
                    }
                    catch (SICASException sicasEx)
                    {
                        folio = OrdenesServiciosSantaCatarina.Folio;
                        continue;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    Central.Entities.OrdenesServicios centralOrdenesServicios = new Central.Entities.OrdenesServicios();
                    folio = OrdenesServiciosSantaCatarina.Folio;

                    centralOrdenesServicios.OrdenServicio_ID = OrdenesServiciosSantaCatarina.Folio;
                    centralOrdenesServicios.OrdenTrabajo_ID = OrdenesServiciosSantaCatarina.OrdenTrabajo;
                    centralOrdenesServicios.ServicioMantenimiento_ID = OrdenesServiciosSantaCatarina.Servicio;
                    centralOrdenesServicios.Mecanico_ID = OrdenesServiciosSantaCatarina.Mecanico;
                    centralOrdenesServicios.EstatusOrdenServicio_ID = OrdenesServiciosSantaCatarina.Status;
                    centralOrdenesServicios.Fecha = Central.DB.GetNullableDateTime(OrdenesServiciosSantaCatarina.FechaSurtida);
                    centralOrdenesServicios.Cantidad = Convert.ToInt32(OrdenesServiciosSantaCatarina.Cantidad);
                    centralOrdenesServicios.Precio = OrdenesServiciosSantaCatarina.PrecioUnitario;
                    centralOrdenesServicios.Total = OrdenesServiciosSantaCatarina.Total;


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
                List<SantaCatarina.Entities.OrdenesServicioRefacciones> ordenesserviciosrefaccionesSantaCatarina = SantaCatarina.Entities.OrdenesServicioRefacciones.Read();
                foreach (SantaCatarina.Entities.OrdenesServicioRefacciones OrdenesServiciosRefaccionesSantaCatarina in ordenesserviciosrefaccionesSantaCatarina)
                {
                    if (!Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", OrdenesServiciosRefaccionesSantaCatarina.OrdenServicio)))
                    {
                        continue;
                    }
                    Central.Entities.OrdenesServiciosRefacciones centralOrdenesServiciosRefacciones = new Central.Entities.OrdenesServiciosRefacciones();
                    centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID = 0;
                    centralOrdenesServiciosRefacciones.OrdenServicio_ID = OrdenesServiciosRefaccionesSantaCatarina.OrdenServicio;
                    centralOrdenesServiciosRefacciones.Refaccion_ID = OrdenesServiciosRefaccionesSantaCatarina.Refaccion;
                    centralOrdenesServiciosRefacciones.Cantidad = Convert.ToInt32(OrdenesServiciosRefaccionesSantaCatarina.Cantidad);
                    centralOrdenesServiciosRefacciones.PrecioUnitario = OrdenesServiciosRefaccionesSantaCatarina.PrecioUnitario;
                    centralOrdenesServiciosRefacciones.Total = OrdenesServiciosRefaccionesSantaCatarina.Total;
                    centralOrdenesServiciosRefacciones.CostoUnitario = (decimal)OrdenesServiciosRefaccionesSantaCatarina.CostoUnitario;
                    centralOrdenesServiciosRefacciones.RefSurtidas = Central.DB.GetNullableInt32(OrdenesServiciosRefaccionesSantaCatarina.RefSurtidas);


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
                List<SantaCatarina.Entities.StatusOrdenesTrabajo> estatusordenestrabajosSantaCatarina = SantaCatarina.Entities.StatusOrdenesTrabajo.Read();
                foreach (SantaCatarina.Entities.StatusOrdenesTrabajo EstatusOrdenesTrabajosSantaCatarina in estatusordenestrabajosSantaCatarina)
                {
                    Central.Entities.EstatusOrdenesTrabajos centralEstatusOrdenesTrabajos = new Central.Entities.EstatusOrdenesTrabajos();
                    centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID = EstatusOrdenesTrabajosSantaCatarina.Folio;
                    centralEstatusOrdenesTrabajos.Nombre = EstatusOrdenesTrabajosSantaCatarina.Descripcion;

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
                List<SantaCatarina.Entities.TiposMantenimientos> tiposmantenimientosSantaCatarina = SantaCatarina.Entities.TiposMantenimientos.Read();
                foreach (SantaCatarina.Entities.TiposMantenimientos TiposMantenimientosSantaCatarina in tiposmantenimientosSantaCatarina)
                {
                    Central.Entities.TiposMantenimientos centralTiposMantenimientos = new Central.Entities.TiposMantenimientos();
                    centralTiposMantenimientos.TipoMantenimiento_ID = TiposMantenimientosSantaCatarina.Folio;
                    centralTiposMantenimientos.Nombre = TiposMantenimientosSantaCatarina.Descripcion;


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

                SantaCatarina.Entities.OrdenesTrabajo OrdenesTrabajosSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (SantaCatarina.Entities.OrdenesTrabajo.Read(out OrdenesTrabajosSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesTrabajosSantaCatarina.Folio;
                    Central.Entities.OrdenesTrabajos centralOrdenesTrabajos = new Central.Entities.OrdenesTrabajos();
                    centralOrdenesTrabajos.OrdenTrabajo_ID = OrdenesTrabajosSantaCatarina.Folio;
                    centralOrdenesTrabajos.Empresa_ID = GetEmpresaClienteTaller(OrdenesTrabajosSantaCatarina.ClienteTaller.Tipo);
                    centralOrdenesTrabajos.TipoMantenimiento_ID = Convert.ToInt32(OrdenesTrabajosSantaCatarina.TipoMantenimiento);
                    centralOrdenesTrabajos.ClienteFacturar_ID = GetEmpresaClienteTaller(OrdenesTrabajosSantaCatarina.ClienteTaller.Tipo);

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", OrdenesTrabajosSantaCatarina.Unidad), Param("Estacion_ID", Estacion));
                    int unidad_id = 1;
                    if (unidad != null) unidad_id = unidad.Unidad_ID;

                    centralOrdenesTrabajos.Unidad_ID = unidad_id;
                    centralOrdenesTrabajos.EstatusOrdenTrabajo_ID = OrdenesTrabajosSantaCatarina.Status;
                    centralOrdenesTrabajos.Caja_ID = (OrdenesTrabajosSantaCatarina.Caja == 9) ? 2 : OrdenesTrabajosSantaCatarina.Caja;
                    centralOrdenesTrabajos.Usuario_ID = OrdenesTrabajosSantaCatarina.UsuarioAlta;
                    centralOrdenesTrabajos.Factura_ID = null;
                    centralOrdenesTrabajos.UsuarioFacturacion_ID = OrdenesTrabajosSantaCatarina.UsuarioFacturacion;
                    centralOrdenesTrabajos.CodigoBarras = OrdenesTrabajosSantaCatarina.CodigoBarras;
                    centralOrdenesTrabajos.Subtotal = OrdenesTrabajosSantaCatarina.Subtotal;
                    centralOrdenesTrabajos.IVA = OrdenesTrabajosSantaCatarina.IVA;
                    centralOrdenesTrabajos.Total = OrdenesTrabajosSantaCatarina.Total;
                    centralOrdenesTrabajos.FechaAlta = OrdenesTrabajosSantaCatarina.FechaAlta;
                    centralOrdenesTrabajos.FechaTerminacion = OrdenesTrabajosSantaCatarina.FechaTerminacion;
                    centralOrdenesTrabajos.FechaPago = OrdenesTrabajosSantaCatarina.FechaPago;
                    centralOrdenesTrabajos.NumeroEconomico = Convert.ToInt32(OrdenesTrabajosSantaCatarina.NumeroEconomico);
                    centralOrdenesTrabajos.FechaInicioReparacion = OrdenesTrabajosSantaCatarina.FechaInicioReparacion;
                    centralOrdenesTrabajos.ManoObra = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.ManoObra);
                    centralOrdenesTrabajos.IVAManoObra = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.IVAManoObra);
                    centralOrdenesTrabajos.Refacciones = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.Refacciones);
                    centralOrdenesTrabajos.IVARefacciones = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.IVARefacciones);
                    centralOrdenesTrabajos.FechaFacturacion = OrdenesTrabajosSantaCatarina.FechaFacturacion;
                    centralOrdenesTrabajos.Kilometraje = OrdenesTrabajosSantaCatarina.Kilometraje;
                    centralOrdenesTrabajos.Comentarios = OrdenesTrabajosSantaCatarina.Comentarios;
                    centralOrdenesTrabajos.CostoRefacciones = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.CostoRefacciones);
                    centralOrdenesTrabajos.CostoManoObra = Convert.ToDecimal(OrdenesTrabajosSantaCatarina.CostoManoObra);
                    centralOrdenesTrabajos.CargoAConductor = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosSantaCatarina.CargoCond, false));
                    centralOrdenesTrabajos.CB = OrdenesTrabajosSantaCatarina.CB;
                    centralOrdenesTrabajos.CB_Activo = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosSantaCatarina.CB_Activo, false));


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

                //List<SantaCatarina.Entities.OrdenesTrabajo> ordenestrabajosSantaCatarina = SantaCatarina.Entities.OrdenesTrabajo.Read();
                //foreach (SantaCatarina.Entities.OrdenesTrabajo OrdenesTrabajosSantaCatarina in ordenestrabajosSantaCatarina)
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

                SantaCatarina.Entities.Refacciones RefaccionesSantaCatarina;
                int folio = folioinicial;

                while (SantaCatarina.Entities.Refacciones.Read(out RefaccionesSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesSantaCatarina.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesSantaCatarina.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesSantaCatarina.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesSantaCatarina.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesSantaCatarina.Marca == null)
                    {
                        if (RefaccionesSantaCatarina.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesSantaCatarina.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesSantaCatarina.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesSantaCatarina.Año;
                    //centralRefacciones.Pasillo = RefaccionesSantaCatarina.Pasillo;
                    //centralRefacciones.Estante = RefaccionesSantaCatarina.Estante;
                    //centralRefacciones.Nivel = RefaccionesSantaCatarina.Nivel;
                    //centralRefacciones.Seccion = RefaccionesSantaCatarina.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesSantaCatarina.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesSantaCatarina.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenExt, 0));
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

                SantaCatarina.Entities.Refacciones RefaccionesSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (SantaCatarina.Entities.Refacciones.Read(out RefaccionesSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesSantaCatarina.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesSantaCatarina.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesSantaCatarina.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesSantaCatarina.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesSantaCatarina.Marca == null)
                    {
                        if (RefaccionesSantaCatarina.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesSantaCatarina.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesSantaCatarina.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesSantaCatarina.Año;
                    //centralRefacciones.Pasillo = RefaccionesSantaCatarina.Pasillo;
                    //centralRefacciones.Estante = RefaccionesSantaCatarina.Estante;
                    //centralRefacciones.Nivel = RefaccionesSantaCatarina.Nivel;
                    //centralRefacciones.Seccion = RefaccionesSantaCatarina.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesSantaCatarina.NumeroDeParte;

                    //  Obtener la descripción a partir las variables
                    centralRefacciones.Descripcion = RefaccionesSantaCatarina.Descripcion;

                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenExt, 0));

                    string sqlstr = "SELECT	SUM(Cantidad) Cantidad FROM Inventario WHERE	Refaccion = @Refaccion";
                    int cantidadInventario = Convert.ToInt32(SantaCatarina.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesSantaCatarina.Folio)));
                    //centralRefacciones.CantidadInventario = cantidadInventario;

                    sqlstr = "SELECT	SUM(Costo) Costo FROM Inventario WHERE	Refaccion = @Refaccion";
                    decimal valorInventario = Convert.ToDecimal(SantaCatarina.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesSantaCatarina.Folio)));
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

                List<SantaCatarina.Entities.Refacciones> refaccionesSantaCatarina = SantaCatarina.Entities.Refacciones.Read(filter, "");
                foreach (SantaCatarina.Entities.Refacciones RefaccionesSantaCatarina in refaccionesSantaCatarina)
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    centralRefacciones.Refaccion_ID = RefaccionesSantaCatarina.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesSantaCatarina.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesSantaCatarina.Modelo;
                    centralRefacciones.MarcaRefaccion_ID = Convert.ToInt32(AppHelper.IsNull(RefaccionesSantaCatarina.Marca, RefaccionesSantaCatarina.Inventario[0].Marca));
                    centralRefacciones.Anio = RefaccionesSantaCatarina.Año;
                    //centralRefacciones.Pasillo = RefaccionesSantaCatarina.Pasillo;
                    //centralRefacciones.Estante = RefaccionesSantaCatarina.Estante;
                    //centralRefacciones.Nivel = RefaccionesSantaCatarina.Nivel;
                    //centralRefacciones.Seccion = RefaccionesSantaCatarina.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesSantaCatarina.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesSantaCatarina.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesSantaCatarina.MargenExt, 0));
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
                List<SantaCatarina.Entities.Servicios> serviciosmantenimientosSantaCatarina = SantaCatarina.Entities.Servicios.Read();
                foreach (SantaCatarina.Entities.Servicios ServiciosMantenimientosSantaCatarina in serviciosmantenimientosSantaCatarina)
                {
                    Central.Entities.ServiciosMantenimientos centralServiciosMantenimientos = new Central.Entities.ServiciosMantenimientos();
                    centralServiciosMantenimientos.ServicioMantenimiento_ID = ServiciosMantenimientosSantaCatarina.Folio;
                    centralServiciosMantenimientos.TipoServicioMantenimiento_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Familia_ID = (ServiciosMantenimientosSantaCatarina.Familia == 0) ? 1 : ServiciosMantenimientosSantaCatarina.Familia;
                    centralServiciosMantenimientos.Modelo_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Nombre = ServiciosMantenimientosSantaCatarina.Descripcion;
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
                List<SantaCatarina.Entities.ServiciosTiposRefacciones> serviciosmantenimientos_tiposrefaccionesSantaCatarina = SantaCatarina.Entities.ServiciosTiposRefacciones.Read();
                foreach (SantaCatarina.Entities.ServiciosTiposRefacciones ServiciosMantenimientos_TiposRefaccionesSantaCatarina in serviciosmantenimientos_tiposrefaccionesSantaCatarina)
                {
                    Central.Entities.ServiciosMantenimientos_TiposRefacciones centralServiciosMantenimientos_TiposRefacciones = new Central.Entities.ServiciosMantenimientos_TiposRefacciones();
                    centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID = ServiciosMantenimientos_TiposRefaccionesSantaCatarina.Servicio;
                    centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID = ServiciosMantenimientos_TiposRefaccionesSantaCatarina.TipoRefaccion;
                    centralServiciosMantenimientos_TiposRefacciones.Cantidad = ServiciosMantenimientos_TiposRefaccionesSantaCatarina.Cantidad;

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

                SantaCatarina.Entities.ControlCajas SesionesSantaCatarina;
                int sesion;

                sesion = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.ControlCajas.Read(out SesionesSantaCatarina, 1, filter, sort, Param("Sesion", sesion)))
                {
                    sesion = SesionesSantaCatarina.Sesion;

                    Central.Entities.Sesiones centralSesiones = new Central.Entities.Sesiones();
                    centralSesiones.Sesion_ID = SesionesSantaCatarina.Sesion;
                    centralSesiones.Empresa_ID = Empresa; // CAM
                    centralSesiones.Estacion_ID = Estacion; // SantaCatarina

                    SesionesSantaCatarina.Caja = SesionesSantaCatarina.Caja.Trim();
                    centralSesiones.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Referencia_ID", SesionesSantaCatarina.Caja), Param("Estacion_ID", Estacion)).Caja_ID;
                    SantaCatarina.Entities.MovimientosCaja mc = SantaCatarina.Entities.MovimientosCaja.Read(Param("Sesion", SesionesSantaCatarina.Sesion));

                    centralSesiones.Usuario_ID = (mc == null) ? "SICAS" : mc.Usuario;

                    centralSesiones.FechaInicial = SesionesSantaCatarina.Inicio;
                    centralSesiones.FechaFinal = SesionesSantaCatarina.Corte;
                    centralSesiones.HostName = null;
                    centralSesiones.IPAddress = null;
                    centralSesiones.MACAddress = null;
                    centralSesiones.Activo = (SesionesSantaCatarina.Corte == null) ? true : false;
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

                SantaCatarina.Entities.Recibos TicketsSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.Recibos.Read(out TicketsSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TicketsSantaCatarina.Folio;

                    Central.Entities.Tickets centralTickets = new Central.Entities.Tickets();

                    centralTickets.Ticket_ID = 0;
                    centralTickets.Referencia_ID = folio;

                    //  Consultar la sesión por usuario y fecha
                    SantaCatarina.Entities.ControlCajas cc = SantaCatarina.Entities.ControlCajas.GetBy(TicketsSantaCatarina.Fecha, TicketsSantaCatarina.Caja);
                    if (cc == null) continue;
                    int sesionlocal = cc.Sesion;

                    Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(Param("Referencia_ID", sesionlocal), Param("Estacion_ID", Estacion));
                    if (s == null) continue;

                    int sesion_id = s.Sesion_ID;
                    centralTickets.Sesion_ID = sesion_id;

                    centralTickets.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsSantaCatarina.Caja)).Caja_ID;
                    centralTickets.Usuario_ID = TicketsSantaCatarina.UsuarioAlta;

                    //  Si existe en cancelados
                    if (SantaCatarina.DB.Exists("RecibosCancelados", Param("Estacion", Estacion), Param("Recibo", TicketsSantaCatarina.Folio)))
                    {
                        centralTickets.EstatusTicket_ID = 2;
                    }
                    else
                    {
                        centralTickets.EstatusTicket_ID = 1;
                    }

                    centralTickets.Empresa_ID = Empresa; // CAM
                    centralTickets.Estacion_ID = Estacion; // SantaCatarina

                    if (TicketsSantaCatarina.Unidad == 0)
                    {
                        centralTickets.Unidad_ID = null;
                    }
                    else
                    {
                        centralTickets.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsSantaCatarina.Unidad)).Unidad_ID;
                    }

                    centralTickets.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", TicketsSantaCatarina.Conductor)).Conductor_ID;


                    centralTickets.Fecha = TicketsSantaCatarina.Fecha;

                    if (Central.DB.Exists("Tickets", Param("Referencia_ID", folio), Param("Estacion_ID", Estacion)))
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
                List<SantaCatarina.Entities.RecibosCancelados> ticketscanceladosSantaCatarina = SantaCatarina.Entities.RecibosCancelados.Read();
                foreach (SantaCatarina.Entities.RecibosCancelados TicketsCanceladosSantaCatarina in ticketscanceladosSantaCatarina)
                {
                    Central.Entities.TicketsCancelados centralTicketsCancelados = new Central.Entities.TicketsCancelados();

                    Central.Entities.Tickets ticket = Central.Entities.Tickets.Read(Param("Referencia_ID", TicketsCanceladosSantaCatarina.Recibo), Param("Estacion_ID", Estacion));
                    if (ticket == null)
                    {
                        // Ticket no existe
                        continue;
                    }
                    centralTicketsCancelados.Ticket_ID = ticket.Ticket_ID;
                    centralTicketsCancelados.Motivo = TicketsCanceladosSantaCatarina.Motivo;
                    centralTicketsCancelados.Usuario_ID = TicketsCanceladosSantaCatarina.Usuario;
                    centralTicketsCancelados.Fecha = Convert.ToDateTime(TicketsCanceladosSantaCatarina.Fecha);


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
                List<SantaCatarina.Entities.TiposRefacciones> tiposrefaccionesSantaCatarina
                    = SantaCatarina.Entities.TiposRefacciones.Read();
                foreach (SantaCatarina.Entities.TiposRefacciones TiposRefaccionesSantaCatarina in tiposrefaccionesSantaCatarina)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesSantaCatarina.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesSantaCatarina.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesSantaCatarina.Descripcion;


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
                List<SantaCatarina.Entities.TiposRefacciones> tiposrefaccionesSantaCatarina = SantaCatarina.Entities.TiposRefacciones.Read();
                foreach (SantaCatarina.Entities.TiposRefacciones TiposRefaccionesSantaCatarina in tiposrefaccionesSantaCatarina)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesSantaCatarina.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesSantaCatarina.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesSantaCatarina.Descripcion;

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
                
                SantaCatarina.Entities.Unidades UnidadesSantaCatarina;
                int folio;

                folio = 0;

                while (SantaCatarina.Entities.Unidades.Read(out UnidadesSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesSantaCatarina.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesSantaCatarina.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // SantaCatarina
                    centralUnidades.NumeroEconomico = UnidadesSantaCatarina.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesSantaCatarina.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesSantaCatarina.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesSantaCatarina.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesSantaCatarina.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesSantaCatarina.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesSantaCatarina.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesSantaCatarina.Locacion);

                    centralUnidades.Placas = (UnidadesSantaCatarina.Concesion == null) ? "" : UnidadesSantaCatarina.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesSantaCatarina.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesSantaCatarina.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesSantaCatarina.Folio;


                    if (Central.DB.Exists("Unidades", Param("Referencia_ID", UnidadesSantaCatarina.Folio),
                        Param("Estacion_ID", Estacion)))
                    {
                        centralUnidades.Unidad_ID = Central.Entities.Unidades.Read(
                                Param("Estacion_ID", Estacion),
                                Param("Referencia_ID", centralUnidades.Referencia_ID)
                            ).Unidad_ID;

                        centralUnidades.Update();

                        Console.WriteLine(
                            String.Format(
                                "Registro actualizado Unidad_ID: {0}, NumeroEconomico {1}", 
                                centralUnidades.Unidad_ID,
                                centralUnidades.NumeroEconomico
                            )
                        );
                    }
                    else
                    {
                        centralUnidades.Create();

                        Console.WriteLine(
                            String.Format(
                                "Registro creado Unidad_ID: {0}, NumeroEconomico {1}",
                                centralUnidades.Unidad_ID,
                                centralUnidades.NumeroEconomico
                            )
                        );
                    }                    
                }
            }	//	End Method SyncUnidades


            public void SyncUnidades()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                SantaCatarina.Entities.Unidades UnidadesSantaCatarina;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.Unidades.Read(out UnidadesSantaCatarina, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesSantaCatarina.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesSantaCatarina.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // SantaCatarina
                    centralUnidades.NumeroEconomico = UnidadesSantaCatarina.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesSantaCatarina.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesSantaCatarina.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesSantaCatarina.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesSantaCatarina.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesSantaCatarina.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesSantaCatarina.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesSantaCatarina.Locacion);

                    centralUnidades.Placas = (UnidadesSantaCatarina.Concesion == null) ? "" : UnidadesSantaCatarina.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesSantaCatarina.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesSantaCatarina.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesSantaCatarina.Folio;


                    if (Central.DB.Exists("Unidades", Param("Referencia_ID", UnidadesSantaCatarina.Folio),
                        Param("Estacion_ID", Estacion)))
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

                SantaCatarina.Entities.RegistroKilometrajesUnidades Unidades_KilometrajesSantaCatarina;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.RegistroKilometrajesUnidades.Read(out Unidades_KilometrajesSantaCatarina, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_KilometrajesSantaCatarina.Fecha;

                    Central.Entities.Unidades_Kilometrajes centralUnidades_Kilometrajes = new Central.Entities.Unidades_Kilometrajes();

                    centralUnidades_Kilometrajes.Unidad_Kilometraje_ID = 0; // A determinar

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", Unidades_KilometrajesSantaCatarina.Unidad));
                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_KilometrajesSantaCatarina.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Kilometrajes.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesSantaCatarina.ConductorActual)).Conductor_ID;

                    Central.Entities.Conductores conductor =
                         Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesSantaCatarina.ConductorActual));

                    if (conductor == null)
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = null;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = conductor.Conductor_ID;
                    }

                    centralUnidades_Kilometrajes.Kilometraje = Unidades_KilometrajesSantaCatarina.Kilometraje;
                    centralUnidades_Kilometrajes.Fecha = Unidades_KilometrajesSantaCatarina.Fecha;

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

                SantaCatarina.Entities.RegistroLocacionesUnidades Unidades_LocacionesSantaCatarina;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (SantaCatarina.Entities.RegistroLocacionesUnidades.Read(out Unidades_LocacionesSantaCatarina, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_LocacionesSantaCatarina.Fecha;

                    Central.Entities.Unidades_Locaciones centralUnidades_Locaciones = new Central.Entities.Unidades_Locaciones();

                    Central.Entities.Unidades unidad =
                        Central.Entities.Unidades.Read(
                            Param("Estacion_ID", this.Estacion),
                                Param("Referencia_ID", Unidades_LocacionesSantaCatarina.Unidad));

                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_LocacionesSantaCatarina.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Locaciones.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Locaciones.LocacionUnidad_ID = LocacionCentral(Unidades_LocacionesSantaCatarina.Locacion); // A consultar

                    centralUnidades_Locaciones.Fecha = Unidades_LocacionesSantaCatarina.Fecha;


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

                SantaCatarina.Entities.ValesPrepagados ValesPrepagadosSantaCatarina;
                string vale;

                vale = Convert.ToString(Central.DB.QueryScalar(sqlQry));

                while (SantaCatarina.Entities.ValesPrepagados.Read(out ValesPrepagadosSantaCatarina, 1, filter, sort, Param("@Codigo", vale)))
                {
                    vale = ValesPrepagadosSantaCatarina.Codigo;

                    Central.Entities.ValesPrepagados centralValesPrepagados = new Central.Entities.ValesPrepagados();
                    centralValesPrepagados.ValePrepagado_ID = ValesPrepagadosSantaCatarina.Codigo;

                    if (ValesPrepagadosSantaCatarina.Cliente == 0) continue;

                    int empresacliente_id = Central.Entities.Empresas.Read(Param("Rfc", ValesPrepagadosSantaCatarina.Clientes.Rfc))[0].Empresa_ID;
                    centralValesPrepagados.EmpresaCliente_ID = empresacliente_id;

                    centralValesPrepagados.Usuario_ID = ValesPrepagadosSantaCatarina.UsuarioEmision;
                    centralValesPrepagados.EstatusValePrepagado_ID = ValesPrepagadosSantaCatarina.Status;
                    centralValesPrepagados.FolioDiario = ValesPrepagadosSantaCatarina.FolioDiario;
                    centralValesPrepagados.Denominacion = ValesPrepagadosSantaCatarina.Denominacion;
                    centralValesPrepagados.FechaEmision = ValesPrepagadosSantaCatarina.FechaEmision;
                    centralValesPrepagados.FechaExpiracion = ValesPrepagadosSantaCatarina.FechaExpiracion;

                    //  Se obtiene del recibo
                    if (ValesPrepagadosSantaCatarina.RecibosValesPrepagados != null)
                    {
                        Central.Entities.Tickets ticket =
                            Central.Entities.Tickets.Read(
                            Param("Referencia_ID", ValesPrepagadosSantaCatarina.Recibos.Folio),
                            Param("Estacion_ID", Estacion));

                        if (ticket != null)
                        {
                            centralValesPrepagados.Ticket_ID = ticket.Ticket_ID;
                        }
                        centralValesPrepagados.FechaCanje = ValesPrepagadosSantaCatarina.Recibos.Fecha;
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
                IEnumerable<int> estaciones = SantaCatarina.DB.QueryList<int>("SELECT DISTINCT Estacion FROM PlanillasFiscales", "Estacion");

                foreach (int estacion in estaciones)
                {
                    //  Obtener el ultimo folio de planilla fiscal para dicha estación y serie
                    //  Ejecutar el read
                    string filter = "Estacion = @Estacion AND Folio > @Folio";
                    string sort = "Folio ASC";
                    string sqlQry = "SELECT ISNULL(MAX(Folio),0) Folio FROM PlanillasFiscales WHERE Estacion_ID = @Estacion_ID";

                    SantaCatarina.Entities.PlanillasFiscales PlanillasFiscalesSantaCatarina;
                    int folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, SantaCatarina.DB.GetParams(Param("@Estacion_ID", estacion))));

                    while (SantaCatarina.Entities.PlanillasFiscales.Read(out PlanillasFiscalesSantaCatarina, 1, filter, sort,
                        Param("@Estacion", estacion), Param("@Folio", folio)))
                    {
                        Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();
                        folio = PlanillasFiscalesSantaCatarina.Folio;

                        if (PlanillasFiscalesSantaCatarina.RecibosPlanillas == null)
                        {
                            centralPlanillasFiscales.Ticket_ID = null;
                        }
                        else
                        {
                            centralPlanillasFiscales.Ticket_ID =
                                Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", PlanillasFiscalesSantaCatarina.RecibosPlanillas.Recibo),
                                        Param("Estacion_ID", Estacion)).Ticket_ID;
                        }

                        //  Mediante funcion
                        centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesSantaCatarina.Precio);
                        centralPlanillasFiscales.Estacion_ID = estacion; // SantaCatarina
                        centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesSantaCatarina.Status;
                        centralPlanillasFiscales.Serie = null;
                        centralPlanillasFiscales.Folio = folio;
                        centralPlanillasFiscales.Precio = PlanillasFiscalesSantaCatarina.Precio;
                        centralPlanillasFiscales.Fecha = PlanillasFiscalesSantaCatarina.FechaAlta;
                        centralPlanillasFiscales.Serie = "";

                        if (Central.DB.Exists("PlanillasFiscales", Param("Estacion_ID", estacion),
                            Param("Folio", folio)))
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

            }	//	End Method SyncPlanillasFiscales

            public void SyncPlanillasFiscalesSerie()
            {
                IEnumerable<int> estaciones = SantaCatarina.DB.QueryList<int>("SELECT DISTINCT Estacion FROM PlanillasFiscales", "Estacion");

                foreach (int estacion in estaciones)
                {
                    IEnumerable<string> series =
                        SantaCatarina.DB.QueryList<string>("SELECT DISTINCT Serie FROM PlanillasFiscales WHERE Estacion = " + estacion.ToString(), "Serie");

                    foreach (string serie in series)
                    {
                        //  Obtener el ultimo folio de planilla fiscal para dicha estación y serie
                        //  Ejecutar el read
                        string filter = "Estacion = @Estacion AND Serie = @Serie AND Folio > @Folio";
                        string sort = "Folio ASC";
                        string sqlQry = "SELECT ISNULL(MAX(Folio),0) Folio FROM PlanillasFiscales WHERE Estacion_ID = @Estacion_ID AND Serie = @Serie";

                        SantaCatarina.Entities.PlanillasFiscales PlanillasFiscalesSantaCatarina;
                        int folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, SantaCatarina.DB.GetParams(Param("@Estacion_ID", estacion), Param("@Serie", serie))));

                        while (SantaCatarina.Entities.PlanillasFiscales.Read(out PlanillasFiscalesSantaCatarina, 1, filter, sort,
                            Param("@Estacion", estacion), Param("@Serie", serie), Param("@Folio", folio)))
                        {
                            Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();
                            folio = PlanillasFiscalesSantaCatarina.Folio;

                            if (PlanillasFiscalesSantaCatarina.RecibosPlanillas == null)
                            {
                                centralPlanillasFiscales.Ticket_ID = null;
                            }
                            else
                            {
                                centralPlanillasFiscales.Ticket_ID =
                                    Central.Entities.Tickets.Read(
                                        Param("Referencia_ID", PlanillasFiscalesSantaCatarina.RecibosPlanillas.Recibo),
                                            Param("Estacion_ID", Estacion)).Ticket_ID;
                            }

                            //  Mediante funcion
                            centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesSantaCatarina.Precio);
                            centralPlanillasFiscales.Estacion_ID = estacion; // SantaCatarina
                            centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesSantaCatarina.Status;
                            centralPlanillasFiscales.Serie = serie;
                            centralPlanillasFiscales.Folio = folio;
                            centralPlanillasFiscales.Precio = PlanillasFiscalesSantaCatarina.Precio;
                            centralPlanillasFiscales.Fecha = PlanillasFiscalesSantaCatarina.FechaAlta;


                            if (Central.DB.Exists("PlanillasFiscales", Param("Estacion_ID", estacion),
                                Param("Serie", serie), Param("Folio", folio)))
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

            }	//	End Method SyncPlanillasFiscales
        }   //  End Class     

    }
}
