using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SICASBot.Sync
{
    public partial class Syncronization
    {
        public class SyncPabloLivas
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
                SyncUnidades();
                SyncConductores();
                SyncDetalleConductores();
                SyncPlanesDeRenta();
                SyncContratos();
                SyncUpdateContratos();
                SyncContratosLiquidados();
                SyncCuentaCajas();
                SyncPlanillasFiscales();
                SyncTickets();
                SyncCuentaConductores();
                SyncTicketsCancelados();
                SyncUnidades_Kilometrajes();
                SyncUnidades_Locaciones();
                SyncValesPrepagados();
                UpdateUnidadesKilometrajes();
            }

            public void DoSyncMetro()
            {
                DateTime endSyncDateTime = new DateTime(2011, 10, 3, 11, 0, 0);
                if (DateTime.Now >= endSyncDateTime)
                {
                    return;
                }

                bool IsDebug = true;
                if (IsDebug)
                {
                    _DoSyncMetro();
                }
                else
                {
                    try
                    {                        
                        Console.WriteLine("Comenzando con la sincronizacion. Estacion: PabloLivas");
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

            private int Estacion = 11; // PabloLivas
            private int Empresa = 2; // CAM

            private KeyValuePair<string, object> Param(string key, object value)
            {
                return new KeyValuePair<string, object>(key, value);
            }

            public void SyncHistorialCobranzaConductores()
            {
                List<PabloLivas.Entities.HistorialConductor> historialcobranzaconductoresPabloLivas =
                    PabloLivas.Entities.HistorialConductor.Read();
                foreach (PabloLivas.Entities.HistorialConductor HistorialCobranzaConductoresPabloLivas in historialcobranzaconductoresPabloLivas)
                {
                    Central.Entities.HistorialCobranzaConductores centralHistorialCobranzaConductores = new Central.Entities.HistorialCobranzaConductores();
                    
                    centralHistorialCobranzaConductores.Conductor_ID = 
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion), 
                        Param("Referencia_ID", HistorialCobranzaConductoresPabloLivas.Conductor)).Conductor_ID;
                    centralHistorialCobranzaConductores.Usuario_ID = HistorialCobranzaConductoresPabloLivas.Usuario.Replace("+","").Replace("%c3%b1","ñ");
                    centralHistorialCobranzaConductores.Estacion_ID = Estacion;
                    centralHistorialCobranzaConductores.Accion = HistorialCobranzaConductoresPabloLivas.Accion;
                    centralHistorialCobranzaConductores.Comentario = HistorialCobranzaConductoresPabloLivas.Comentario;
                    centralHistorialCobranzaConductores.Referencia_ID = HistorialCobranzaConductoresPabloLivas.Folio;
                    centralHistorialCobranzaConductores.Fecha = HistorialCobranzaConductoresPabloLivas.Fecha;


                    if (Central.DB.Exists("HistorialCobranzaConductores", 
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", HistorialCobranzaConductoresPabloLivas.Folio)))
                    {
                        centralHistorialCobranzaConductores.Update();
                    }
                    else
                    {
                        centralHistorialCobranzaConductores.Create();
                    }

                    Console.WriteLine(string.Format("Historial conductor actualizado {0}", HistorialCobranzaConductoresPabloLivas.Folio));
                }	//	End foreach

            }	//	End Method SyncHistorialCobranzaConductores

            public void SyncCuentaDepositosGarantia()
            {
                List<PabloLivas.Entities.CuentaDepositosGarantia> Depositos =
                    PabloLivas.Entities.CuentaDepositosGarantia.Read();

                foreach (PabloLivas.Entities.CuentaDepositosGarantia Deposito in Depositos)
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
                List<PabloLivas.Entities.ControlCajas> Sesiones = PabloLivas.Entities.ControlCajas.Read();
                foreach (PabloLivas.Entities.ControlCajas SesionesPabloLivas in Sesiones)
                {
                    int sesion = SesionesPabloLivas.Sesion;

                    Central.Entities.Sesiones centralSesiones =
                        Central.Entities.Sesiones.Read(
                        Param("Referencia_ID", sesion),
                        Param("Estacion_ID", Estacion));

                    centralSesiones.FechaInicial = SesionesPabloLivas.Inicio;
                    centralSesiones.FechaFinal = SesionesPabloLivas.Corte;
                    centralSesiones.Activo = (SesionesPabloLivas.Corte == null) ? true : false;

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

                //PabloLivas.Entities.DetalleConductor ConductoresPabloLivas;
                Console.WriteLine("Leyendo detalle conductores");
                int folio = 0;

                int count = PabloLivas.DB.GetCount("DetalleConductor");
                int cont = 0;

                List<PabloLivas.Entities.DetalleConductor> DetallesConductor = PabloLivas.Entities.DetalleConductor.Read();
                foreach (PabloLivas.Entities.DetalleConductor ConductoresPabloLivas in DetallesConductor)
                {
                    cont++;
                    folio = ConductoresPabloLivas.Conductor;

                    Central.Entities.Conductores centralConductor =
                        Central.Entities.Conductores.Read(
                        Param("Referencia_ID", folio),
                        Param("Estacion_ID", Estacion));

                    centralConductor.BloquearConductor = ConductoresPabloLivas.BloquearConductor;
                    centralConductor.Cronocasco = ConductoresPabloLivas.Cronocasco;
                    centralConductor.MensajeACaja = ConductoresPabloLivas.MensajeACaja;
                    centralConductor.SaldoATratar = ConductoresPabloLivas.SaldoATratar;
                    centralConductor.TerminalDatos = ConductoresPabloLivas.TerminalDatos;
                    centralConductor.Update();

                    Console.WriteLine(String.Format("Registro actualizado DetalleConductor_ID: {0}, {1} de {2}",
                        centralConductor.Referencia_ID, cont, count));
                }

                //while (PabloLivas.Entities.DetalleConductor.Read(out ConductoresPabloLivas, 1, filter, sort, Param("Conductor", folio)))
                //{

                //}

            }   //  End Method

            public void SyncPlanesDeRenta()
            {
                List<PabloLivas.Entities.Planes> planesderentaPabloLivas = PabloLivas.Entities.Planes.Read();
                foreach (PabloLivas.Entities.Planes PlanesDeRentaPabloLivas in planesderentaPabloLivas)
                {
                    Central.Entities.PlanesDeRenta centralPlanesDeRenta = new Central.Entities.PlanesDeRenta();
                    centralPlanesDeRenta.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(
                        Param("Referencia_id",
                        (int)PlanesDeRentaPabloLivas.Modelo),
                        Param("EmpresaReferencia", Estacion)
                        ).ModeloUnidad_ID;
                    centralPlanesDeRenta.Usuario_ID = PlanesDeRentaPabloLivas.UsuarioAlta;
                    centralPlanesDeRenta.DiasDeCobro_ID = PlanesDeRentaPabloLivas.DiasDeCobro.Value;
                    centralPlanesDeRenta.Descripcion = PlanesDeRentaPabloLivas.Descripcion;
                    centralPlanesDeRenta.RentaBase = PlanesDeRentaPabloLivas.RentaBase;
                    centralPlanesDeRenta.FondoResidual = PlanesDeRentaPabloLivas.FondoResidual;
                    centralPlanesDeRenta.Fecha = PlanesDeRentaPabloLivas.FechaAlta;
                    centralPlanesDeRenta.Activo = (PlanesDeRentaPabloLivas.Status == 1);
                    centralPlanesDeRenta.Referencia_ID = PlanesDeRentaPabloLivas.Folio;
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

                    Console.WriteLine(String.Format("Registro actualizado Plan de Renta: {0}", PlanesDeRentaPabloLivas.Folio));

                }	//	End foreach

            }	//	End Method SyncPlanesDeRenta

            //  Actualizar contratos
            public void SyncUpdateContratos()
            {
                Console.WriteLine("Update Contratos");

                List<PabloLivas.Entities.Contratos> ContratosPabloLivas = PabloLivas.Entities.Contratos.Read();
                foreach (PabloLivas.Entities.Contratos contrato in ContratosPabloLivas)
                {
                    Central.Entities.Contratos c =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", contrato.Folio));

                    c.FechaFinal = contrato.FechaFinal;
                    c.EstatusContrato_ID = (contrato.Status == 1) ? 1 : contrato.Status + 7;
                    c.Update("FechaFinal", "EstatusContrato_ID");
                    Console.WriteLine(string.Format("Actualizado contrato {0}:", contrato.Folio));
                }
            } // end void

            //  Contratos Liquidados
            public void SyncContratosLiquidados()
            {
                Console.WriteLine("Leyendo contratos liquidados");
                List<PabloLivas.Entities.ContratosLiquidados> contratosliquidadosPabloLivas = PabloLivas.Entities.ContratosLiquidados.Read();
                foreach (PabloLivas.Entities.ContratosLiquidados ContratosLiquidadosPabloLivas in contratosliquidadosPabloLivas)
                {
                    Central.Entities.ContratosLiquidados centralContratosLiquidados = new Central.Entities.ContratosLiquidados();
                    centralContratosLiquidados.ContratoLiquidado_ID = ContratosLiquidadosPabloLivas.Folio;

                    centralContratosLiquidados.Contrato_ID =
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosPabloLivas.Contrato)
                        ).Contrato_ID; // Consultar contrato

                    centralContratosLiquidados.Conductor_ID =
                        Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosPabloLivas.Conductor)
                        ).Conductor_ID;

                    centralContratosLiquidados.Unidad_ID =
                        Central.Entities.Unidades.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosPabloLivas.Unidad)
                        ).Unidad_ID;

                    centralContratosLiquidados.LocacionUnidad_ID = LocacionCentral(ContratosLiquidadosPabloLivas.LocacionUnidad);

                    centralContratosLiquidados.EstatusConductor_ID =
                        (ContratosLiquidadosPabloLivas.StatusConductor == 1) ? 1 : ContratosLiquidadosPabloLivas.StatusConductor + 4;

                    centralContratosLiquidados.EstatusContrato_ID =
                        (ContratosLiquidadosPabloLivas.StatusContrato == 1) ? 1 : ContratosLiquidadosPabloLivas.StatusContrato + 7;

                    centralContratosLiquidados.Comentarios = ContratosLiquidadosPabloLivas.Comentario;
                    centralContratosLiquidados.Fecha = ContratosLiquidadosPabloLivas.Fecha;
                    centralContratosLiquidados.Usuario_ID = ContratosLiquidadosPabloLivas.Usuario.Trim();

                    if (Central.DB.Exists("ContratosLiquidados", Param("ContratoLiquidado_ID", centralContratosLiquidados.ContratoLiquidado_ID)))
                    {
                        centralContratosLiquidados.Update();
                    }
                    else
                    {
                        centralContratosLiquidados.Create();
                    }

                    Console.WriteLine(string.Format("Actualizado contrato liquidado {0}", ContratosLiquidadosPabloLivas.Folio));
                }	//	End foreach

            }	//	End Method SyncContratosLiquidados


            //  Estatus de ordenes de compras
            public void SyncEstatusOrdenesCompras()
            {
                List<PabloLivas.Entities.StatusOrdenesCompra> estatusordenescomprasPabloLivas = PabloLivas.Entities.StatusOrdenesCompra.Read();
                foreach (PabloLivas.Entities.StatusOrdenesCompra EstatusOrdenesComprasPabloLivas in estatusordenescomprasPabloLivas)
                {
                    Central.Entities.EstatusOrdenesCompras centralEstatusOrdenesCompras = new Central.Entities.EstatusOrdenesCompras();
                    centralEstatusOrdenesCompras.EstatusOrdenCompra_ID = EstatusOrdenesComprasPabloLivas.Folio;
                    centralEstatusOrdenesCompras.Nombre = EstatusOrdenesComprasPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.StatusOrdenesServicio> estatusordenesserviciosPabloLivas = PabloLivas.Entities.StatusOrdenesServicio.Read();
                foreach (PabloLivas.Entities.StatusOrdenesServicio EstatusOrdenesServiciosPabloLivas in estatusordenesserviciosPabloLivas)
                {
                    Central.Entities.EstatusOrdenesServicios centralEstatusOrdenesServicios = new Central.Entities.EstatusOrdenesServicios();
                    centralEstatusOrdenesServicios.EstatusOrdenServicio_ID = EstatusOrdenesServiciosPabloLivas.Folio;
                    centralEstatusOrdenesServicios.Nombre = EstatusOrdenesServiciosPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.MovimientosDirectosAInventario> movsInventario = new List<PabloLivas.Entities.MovimientosDirectosAInventario>();
                movsInventario = PabloLivas.Entities.MovimientosDirectosAInventario.Read();

                foreach (PabloLivas.Entities.MovimientosDirectosAInventario mov in movsInventario)
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
                List<PabloLivas.Entities.OrdenesTrabajoCanceladas> ordenesCanceladas = PabloLivas.Entities.OrdenesTrabajoCanceladas.Read();

                foreach (PabloLivas.Entities.OrdenesTrabajoCanceladas ordenCancelada in ordenesCanceladas)
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
                List<PabloLivas.Entities.CategoriasMecanicos> categoriasPabloLivas = PabloLivas.Entities.CategoriasMecanicos.Read();

                foreach (PabloLivas.Entities.CategoriasMecanicos PabloLivascategoria in categoriasPabloLivas)
                {
                    Central.Entities.CategoriasMecanicos centralCategoria = new Central.Entities.CategoriasMecanicos();
                    centralCategoria.CategoriaMecanico_ID = PabloLivascategoria.Folio;
                    centralCategoria.Familia_ID = PabloLivascategoria.Familia;
                    centralCategoria.Nombre = PabloLivascategoria.Descripcion;

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
                    List<PabloLivas.Entities.Compras> comprasPabloLivas = PabloLivas.Entities.Compras.Read(Param("OrdenCompra", ordencompra));

                    foreach (PabloLivas.Entities.Compras PabloLivascompra in comprasPabloLivas)
                    {
                        Central.Entities.Compras centralCompra = new Central.Entities.Compras();
                        centralCompra.Cantidad = PabloLivascompra.Cantidad;
                        centralCompra.Compra_ID = 0;
                        centralCompra.CostoUnitario = PabloLivascompra.CostoUnitario;
                        centralCompra.Fecha = PabloLivascompra.FechaAlta;
                        centralCompra.MarcaRefaccion_ID = PabloLivascompra.Marca;
                        centralCompra.OrdenCompra_ID = PabloLivascompra.OrdenCompra;
                        centralCompra.Refaccion_ID = PabloLivascompra.Refaccion;
                        centralCompra.RefaccionesSurtidas = (int)Central.DB.GetNullableInt32(PabloLivascompra.RefSurtidas);
                        centralCompra.Usuario_ID = PabloLivascompra.UsuarioAlta;

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

                PabloLivas.Entities.Concesiones ConcesionesPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.Concesiones.Read(out ConcesionesPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConcesionesPabloLivas.Folio;

                    Central.Entities.Concesiones centralConcesion = new Central.Entities.Concesiones();
                    centralConcesion.Activo = (ConcesionesPabloLivas.Status == 1) ? true : false;

                    centralConcesion.Placa = ConcesionesPabloLivas.Placa;
                    centralConcesion.Referencia_ID = ConcesionesPabloLivas.Folio;
                    centralConcesion.TipoConcesion_ID = ConcesionesPabloLivas.Tipo;
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

                PabloLivas.Entities.Conductores ConductoresPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.Conductores.Read(out ConductoresPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConductoresPabloLivas.Folio;

                    Central.Entities.Conductores centralConductor = new Central.Entities.Conductores();
                    centralConductor.ActaNacimiento = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.ActaNacimiento;
                    centralConductor.AñosExperiencia = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? null : (Int32?)(AppHelper.IsNull(ConductoresPabloLivas.RegistroPublicitarioConductor.AñosExperiencia, 0));
                    centralConductor.Apellidos = ConductoresPabloLivas.ApellidoPaterno + " " + ConductoresPabloLivas.ApellidoMaterno;
                    centralConductor.Apellidos_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.ApellidoPaterno + " " + ConductoresPabloLivas.AvalConductor.ApellidoMaterno;
                    centralConductor.BloquearConductor = (ConductoresPabloLivas.Detalle == null) ? false : ConductoresPabloLivas.Detalle.BloquearConductor;
                    centralConductor.CartaNoAntecedentes = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.CartaNoAntecedentes;
                    centralConductor.Ciudad = ConductoresPabloLivas.Ciudad;
                    centralConductor.Ciudad_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Ciudad;
                    centralConductor.CodigoPostal = ConductoresPabloLivas.CP.ToString();
                    centralConductor.CodigoPostal_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.CP.ToString();
                    centralConductor.Comentarios = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? "" : ConductoresPabloLivas.RegistroPublicitarioConductor.Comentarios;
                    centralConductor.ComprobanteDomicilio = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.ComprobanteDomicilio;
                    centralConductor.ComprobanteDomicilio_Aval = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.ComprobanteDomicilioAval;
                    centralConductor.Conductor_ID = 0;
                    centralConductor.CredencialElector = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.CredencialElector;
                    centralConductor.CredencialElector_Aval = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.CredencialElectorAval;
                    centralConductor.Cronocasco = (ConductoresPabloLivas.Detalle == null) ? false : ConductoresPabloLivas.Detalle.Cronocasco;
                    centralConductor.CumplioPerfil = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? false : ConductoresPabloLivas.RegistroPublicitarioConductor.CumplioPerfil;
                    centralConductor.CURP = ConductoresPabloLivas.Curp;
                    centralConductor.Curp_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Curp;
                    centralConductor.Domicilio = ConductoresPabloLivas.Calle + " No. " + ConductoresPabloLivas.NumeroCasa + ", Col. " + ConductoresPabloLivas.Colonia;
                    centralConductor.Domicilio_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Calle + " No. " + ConductoresPabloLivas.AvalConductor.NumeroCasa + ", Col. " + ConductoresPabloLivas.AvalConductor.Colonia;
                    centralConductor.Edad = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? null : (int?)(AppHelper.IsNull(ConductoresPabloLivas.RegistroPublicitarioConductor.Edad, 0));
                    centralConductor.Email = ConductoresPabloLivas.CorreoElectronico;
                    centralConductor.Email_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.CorreoElectronico;
                    centralConductor.Entidad = ConductoresPabloLivas.Estado;
                    centralConductor.Estacion_ID = this.Estacion; // PabloLivas
                    centralConductor.Estado_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Estado;
                    centralConductor.EstadoCivil = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? "" : ConductoresPabloLivas.RegistroPublicitarioConductor.EstadoCivil;
                    centralConductor.EstatusConductor_ID = (ConductoresPabloLivas.Status == 1) ? 1 : ConductoresPabloLivas.Status + 4; // Convertir
                    centralConductor.Fecha = ConductoresPabloLivas.FechaAlta;
                    centralConductor.FolioLicencia = (ConductoresPabloLivas.Licencia == null) ? "" : ConductoresPabloLivas.Licencia.Folio.ToString();
                    centralConductor.Fotografia = null; //    Esta no se lleva    // Hay que actualizar el proceso de creación y actualización
                    centralConductor.Genero = "M";
                    centralConductor.Interesado = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? false : ConductoresPabloLivas.RegistroPublicitarioConductor.Interesado;
                    centralConductor.MedioPublicitario_ID = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresPabloLivas.RegistroPublicitarioConductor.MedioPublicitario;
                    centralConductor.MensajeACaja = (ConductoresPabloLivas.Detalle == null) ? "" : ConductoresPabloLivas.Detalle.MensajeACaja;
                    centralConductor.Mercado_ID = (ConductoresPabloLivas.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresPabloLivas.RegistroPublicitarioConductor.PlanEmpresarial; // Hay que hacer el mapeo correcto
                    centralConductor.Movil = null;
                    centralConductor.Nombre = ConductoresPabloLivas.Nombre;
                    centralConductor.Nombre_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Nombre;
                    centralConductor.Referencia_ID = ConductoresPabloLivas.Folio;
                    centralConductor.RFC = ConductoresPabloLivas.Rfc;
                    centralConductor.Rfc_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Rfc;
                    centralConductor.SaldoATratar = (ConductoresPabloLivas.Detalle == null) ? 0 : ConductoresPabloLivas.Detalle.SaldoATratar;
                    centralConductor.Solicitud = (ConductoresPabloLivas.DocumentacionConductor == null) ? "" : ConductoresPabloLivas.DocumentacionConductor.Solicitud;
                    centralConductor.Telefono = ConductoresPabloLivas.Telefono;
                    centralConductor.Telefono_Aval = (ConductoresPabloLivas.AvalConductor == null) ? "" : ConductoresPabloLivas.AvalConductor.Telefono;
                    centralConductor.Telefono2 = null;
                    centralConductor.TerminalDatos = (ConductoresPabloLivas.Detalle == null) ? false : ConductoresPabloLivas.Detalle.TerminalDatos;
                    centralConductor.TipoLicencia_ID = (ConductoresPabloLivas.Licencia == null) ? null : (int?)ConductoresPabloLivas.Licencia.Tipo; // Revisar si entra directo
                    centralConductor.Usuario_ID = ConductoresPabloLivas.UsuarioAlta;
                    centralConductor.VenceLicencia = (ConductoresPabloLivas.Licencia == null) ? null : (DateTime?)ConductoresPabloLivas.Licencia.FechaVencimiento;

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

                //List<PabloLivas.Entities.Conductores> conductoresPabloLivas = PabloLivas.Entities.Conductores.Read();

                //foreach (PabloLivas.Entities.Conductores PabloLivasconductor in conductoresPabloLivas)
                //{

                //}   //  End foreach
            }   //  End Method

            //  Contratos
            public void SyncContratos()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Contratos WHERE Estacion_ID = @Estacion";

                PabloLivas.Entities.Contratos ContratosPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.Contratos.Read(out ContratosPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ContratosPabloLivas.Folio;

                    Central.Entities.Contratos centralContrato = new Central.Entities.Contratos();
                    centralContrato.CobroPermanente = (ContratosPabloLivas.FechaFinal == null) ? true : false;
                    centralContrato.Comentarios = "";
                    centralContrato.Concepto_ID = 1;
                    centralContrato.Conductor_ID = Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", ContratosPabloLivas.Conductor)).Conductor_ID;

                    // Si no existe el conductor copia, insertarlo y relacionarlo
                    if (ContratosPabloLivas.Copia == null)
                    {
                        centralContrato.ConductorCopia_ID = null;
                    }
                    else
                    {
                        Central.Entities.Conductores cond = Central.Entities.Conductores.Read(Param("Rfc", ContratosPabloLivas.Copia.Rfc));
                        if (cond == null)
                        {
                            //  Insertar conductor en Central
                            //  a partir de contratos copia
                            cond = new Central.Entities.Conductores();
                            cond.Apellidos = ContratosPabloLivas.Copia.ApellidoPaterno + " " + ContratosPabloLivas.Copia.ApellidoMaterno;
                            cond.Domicilio = ContratosPabloLivas.Copia.Colonia + ", " + ContratosPabloLivas.Copia.Calle + " No. " + ContratosPabloLivas.Copia.NumeroCasa;
                            cond.Ciudad = ContratosPabloLivas.Copia.Ciudad;
                            cond.Email = ContratosPabloLivas.Copia.CorreoElectronico;
                            cond.CodigoPostal = ContratosPabloLivas.Copia.CP.ToString();
                            cond.CURP = ContratosPabloLivas.Copia.Curp;
                            cond.Entidad = ContratosPabloLivas.Copia.Estado;
                            cond.Fecha = ContratosPabloLivas.Copia.FechaAlta;
                            cond.Nombre = ContratosPabloLivas.Copia.Nombre;
                            cond.RFC = ContratosPabloLivas.Copia.Rfc;
                            cond.Telefono = ContratosPabloLivas.Copia.Telefono;
                            cond.Usuario_ID = ContratosPabloLivas.Copia.UsuarioAlta;
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
                    centralContrato.Descripcion = "Contrato de renta folio " + ContratosPabloLivas.Folio.ToString();

                    //  Obtener los días de cobro
                    centralContrato.DiasDeCobro_ID = (int)ContratosPabloLivas.Planes.DiasDeCobro;

                    if (ContratosPabloLivas.Tipo == 3)
                    {
                        centralContrato.Empresa_ID = 5; // CCR
                    }
                    else
                    {
                        centralContrato.Empresa_ID = Empresa; // CAM
                    }
                    centralContrato.Estacion_ID = Estacion;
                    centralContrato.EstatusContrato_ID = (ContratosPabloLivas.Status == 1) ? 1 : ContratosPabloLivas.Status + 7;
                    centralContrato.FechaFinal = Central.DB.GetNullableDateTime(ContratosPabloLivas.FechaFinal);
                    centralContrato.FechaInicial = ContratosPabloLivas.FechaInicial;
                    centralContrato.FondoResidual = Convert.ToInt32(AppHelper.IsNull(ContratosPabloLivas.Planes.FondoResidual, 0));
                    centralContrato.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(Param("referencia_id", (int)ContratosPabloLivas.Planes.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralContrato.MontoDiario = ContratosPabloLivas.Planes.RentaBase;
                    centralContrato.NumeroEconomico =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosPabloLivas.Unidad)).NumeroEconomico;
                    centralContrato.TipoContrato_ID = (ContratosPabloLivas.Tipo == 3) ? 2 : ContratosPabloLivas.Tipo; // Si 3 entonces es CCR
                    centralContrato.Unidad_ID = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosPabloLivas.Unidad)).Unidad_ID;
                    centralContrato.Referencia_ID = folio;
                    if (Central.DB.Exists("Contratos", Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosPabloLivas.Folio)))
                    {
                        //  Obtener el contrato ID
                        centralContrato.Contrato_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Contratos", "Contrato_ID",
                                Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosPabloLivas.Folio)));
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
                List<PabloLivas.Entities.Usuarios> usuariosPabloLivas = PabloLivas.Entities.Usuarios.Read();
                foreach (PabloLivas.Entities.Usuarios usuarioPabloLivas in usuariosPabloLivas)
                {
                    Central.Entities.Usuarios usuario = new Central.Entities.Usuarios();
                    usuario.Activo = (usuarioPabloLivas.Status == 1) ? true : false;
                    usuario.Apellidos = usuarioPabloLivas.ApellidoPaterno + " " + usuarioPabloLivas.ApellidoMaterno;
                    usuario.Email = "";
                    usuario.Empresa_ID = Empresa; // CAM
                    usuario.Estacion_ID = Estacion; // PabloLivas
                    usuario.Nombre = usuarioPabloLivas.Nombre;
                    usuario.pwd = (byte[])Central.DB.QueryScalar(String.Format("SELECT PWDENCRYPT('{0}')", usuarioPabloLivas.Pwd));
                    usuario.Usuario_ID = usuarioPabloLivas.Clave;

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

                PabloLivas.Entities.MovimientosCaja CuentaCajasPabloLivas;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                maxfolio = Convert.ToInt32(PabloLivas.DB.QueryScalar("SELECT MAX(Folio) MaxFolio FROM MovimientosCaja"));

                while (PabloLivas.Entities.MovimientosCaja.Read(out CuentaCajasPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaCajasPabloLivas.Folio;

                    Central.Entities.CuentaCajas centralCuentaCajas = new Central.Entities.CuentaCajas();
                    centralCuentaCajas.Referencia_ID = CuentaCajasPabloLivas.Folio;
                    centralCuentaCajas.CuentaCaja_ID = 0;
                    if (CuentaCajasPabloLivas.Sesion == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasPabloLivas.Sesion),
                            Param("Estacion_ID", Estacion));
                        if (s == null) continue;
                        centralCuentaCajas.Sesion_ID = s.Sesion_ID;
                        centralCuentaCajas.Caja_ID = (int)Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasPabloLivas.Sesion),
                            Param("Estacion_ID", Estacion)).Caja_ID;
                    }

                    //  La empresa tambien depende del fondo
                    centralCuentaCajas.Empresa_ID = EmpresaDeFondo(CuentaCajasPabloLivas.Fondo);

                    centralCuentaCajas.Estacion_ID = Estacion;

                    centralCuentaCajas.Ticket_ID = null;    //  No esta supeditada a un ticket

                    centralCuentaCajas.Cuenta_ID = CuentaDeFondo(CuentaCajasPabloLivas.Fondo); // De este dato obtener la cuenta

                    centralCuentaCajas.Concepto_ID = null; // No se lleva concepto

                    decimal abono, cargo;
                    if (CuentaCajasPabloLivas.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaCajasPabloLivas.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaCajasPabloLivas.Monto);
                    }

                    centralCuentaCajas.Cargo = cargo; // De este dato depende
                    centralCuentaCajas.Abono = abono;
                    centralCuentaCajas.Saldo = 0; // Es calculado, meter dentro del create
                    centralCuentaCajas.Comentarios = "";
                    centralCuentaCajas.Fecha = CuentaCajasPabloLivas.Fecha;
                    centralCuentaCajas.Usuario_ID = CuentaCajasPabloLivas.Usuario;

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
                PabloLivas.DB.ExecuteQuery(sqlup);

                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = string.Format(
                    "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaConductores WHERE Estacion_ID = {0}",
                    Estacion);

                PabloLivas.Entities.CuentaConductor CuentaConductoresPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                int cont = PabloLivas.DB.GetCount("CuentaConductor");

                while (PabloLivas.Entities.CuentaConductor.Read(out CuentaConductoresPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaConductoresPabloLivas.Folio;

                    Central.Entities.CuentaConductores centralCuentaConductores = new Central.Entities.CuentaConductores();
                    centralCuentaConductores.Referencia_ID = folio;
                    centralCuentaConductores.CuentaConductor_ID = 0;

                    //Obtener segun concepto
                    //Del concepto obtener la cuenta
                    int cuenta = PabloLivas.Entities.Conceptos.Read(CuentaConductoresPabloLivas.Concepto).Cuenta;
                    int fondo = PabloLivas.Entities.Cuentas.Read(cuenta).FondoCaja;
                    //De la cuenta, obtener el fondo
                    //Del fondo, la empresa.
                    centralCuentaConductores.Empresa_ID = EmpresaDeFondo(fondo);

                    centralCuentaConductores.Estacion_ID = Estacion; // PabloLivas

                    if (CuentaConductoresPabloLivas.Unidad == 0)
                    {
                        centralCuentaConductores.Unidad_ID = null;
                    }
                    else
                    {
                        centralCuentaConductores.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresPabloLivas.Unidad)).Unidad_ID;
                    }

                    centralCuentaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", CuentaConductoresPabloLivas.Conductor)).Conductor_ID;

                    // Verificar la caja para obtener la estación
                    if (CuentaConductoresPabloLivas.Caja == null)
                    {
                        centralCuentaConductores.Caja_ID = null;
                    }
                    else
                    {
                        if (CuentaConductoresPabloLivas.Caja == 1 || CuentaConductoresPabloLivas.Caja == 9)
                        {
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresPabloLivas.Caja)).Caja_ID;
                        }
                        else
                        {
                            centralCuentaConductores.Estacion_ID = CuentaConductoresPabloLivas.Caja; // Otra estacion
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", CuentaConductoresPabloLivas.Caja), Param("Referencia_ID", CuentaConductoresPabloLivas.Caja)).Caja_ID;
                        }
                    }

                    //  Es posible que se pueda hacer referencia
                    //  Si folio tiene ticket local, buscar su ticket remoto
                    if (PabloLivas.DB.Exists("RecibosMovimientos", Param("Movimiento", CuentaConductoresPabloLivas.Folio)))
                    {
                        int recibo = (int)PabloLivas.Entities.RecibosMovimientos.Read(Param("Movimiento", CuentaConductoresPabloLivas.Folio)).Recibo;
                        int ticket_id = Central.Entities.Tickets.Read(Param("Referencia_ID", recibo), Param("Estacion_ID", Estacion)).Ticket_ID;
                        centralCuentaConductores.Ticket_ID = ticket_id;
                    }
                    else
                    {
                        centralCuentaConductores.Ticket_ID = null; // Ticket a null
                    }

                    centralCuentaConductores.Cuenta_ID = CuentaDeCuenta(cuenta);
                    centralCuentaConductores.Concepto_ID = ConceptoCentral(CuentaConductoresPabloLivas.Concepto);

                    decimal abono, cargo;
                    if (CuentaConductoresPabloLivas.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaConductoresPabloLivas.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaConductoresPabloLivas.Monto);
                    }

                    centralCuentaConductores.Cargo = cargo;
                    centralCuentaConductores.Abono = abono;
                    centralCuentaConductores.Saldo = 0; // Calculado
                    centralCuentaConductores.Comentarios = CuentaConductoresPabloLivas.Comentarios;
                    centralCuentaConductores.Fecha = CuentaConductoresPabloLivas.FechaAlta;
                    centralCuentaConductores.Usuario_ID = CuentaConductoresPabloLivas.UsuarioAlta;

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
                List<PabloLivas.Entities.Familias> familiasPabloLivas = PabloLivas.Entities.Familias.Read();
                foreach (PabloLivas.Entities.Familias FamiliasPabloLivas in familiasPabloLivas)
                {
                    Central.Entities.Familias centralFamilias = new Central.Entities.Familias();
                    centralFamilias.Familia_ID = FamiliasPabloLivas.Folio;
                    centralFamilias.Nombre = FamiliasPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.MarcasRefacciones> marcasrefaccionesPabloLivas =
                    PabloLivas.Entities.MarcasRefacciones.Read();
                foreach (PabloLivas.Entities.MarcasRefacciones MarcasRefaccionesPabloLivas in marcasrefaccionesPabloLivas)
                {
                    Central.Entities.MarcasRefacciones centralMarcasRefacciones = new Central.Entities.MarcasRefacciones();
                    centralMarcasRefacciones.MarcaRefaccion_ID = MarcasRefaccionesPabloLivas.Folio;
                    centralMarcasRefacciones.Nombre = MarcasRefaccionesPabloLivas.Descripcion;

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
                List<PabloLivas.Entities.StatusMecanicos> estatusmecanicosPabloLivas = PabloLivas.Entities.StatusMecanicos.Read();
                foreach (PabloLivas.Entities.StatusMecanicos EstatusMecanicosPabloLivas in estatusmecanicosPabloLivas)
                {
                    Central.Entities.EstatusMecanicos centralEstatusMecanicos = new Central.Entities.EstatusMecanicos();
                    centralEstatusMecanicos.EstatusMecanico_ID = EstatusMecanicosPabloLivas.Folio;
                    centralEstatusMecanicos.Nombre = EstatusMecanicosPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.Mecanicos> mecanicosPabloLivas = PabloLivas.Entities.Mecanicos.Read();
                foreach (PabloLivas.Entities.Mecanicos MecanicosPabloLivas in mecanicosPabloLivas)
                {
                    Central.Entities.Mecanicos centralMecanicos = new Central.Entities.Mecanicos();
                    centralMecanicos.Mecanico_ID = MecanicosPabloLivas.Folio;
                    centralMecanicos.CategoriaMecanico_ID = MecanicosPabloLivas.Categoria;
                    centralMecanicos.EstatusMecanico_ID = MecanicosPabloLivas.Status;
                    centralMecanicos.Usuario_ID = MecanicosPabloLivas.UsuarioAlta;
                    centralMecanicos.Fecha = MecanicosPabloLivas.FechaAlta;
                    centralMecanicos.CodigoBarras = MecanicosPabloLivas.CodigoBarras;
                    centralMecanicos.Nombres = MecanicosPabloLivas.Nombre;
                    centralMecanicos.Apellidos = MecanicosPabloLivas.ApellidoPaterno + " " + MecanicosPabloLivas.ApellidoMaterno;
                    centralMecanicos.Rfc = MecanicosPabloLivas.Rfc;
                    centralMecanicos.Curp = MecanicosPabloLivas.Curp;
                    centralMecanicos.NSS = MecanicosPabloLivas.NumeroSeguroSocial;
                    centralMecanicos.Domicilio = MecanicosPabloLivas.Calle + " No. " + MecanicosPabloLivas.Numero + ", Col. " + MecanicosPabloLivas.Colonia;
                    centralMecanicos.Ciudad = MecanicosPabloLivas.Ciudad;
                    centralMecanicos.Entidad = MecanicosPabloLivas.Estado;
                    centralMecanicos.CodigoPostal = MecanicosPabloLivas.CodigoPostal.ToString();
                    centralMecanicos.Telefono = MecanicosPabloLivas.Telefonos;
                    centralMecanicos.CorreoElectronico = MecanicosPabloLivas.CorreoElectronico;
                    centralMecanicos.SalarioDiario = MecanicosPabloLivas.SalarioDiario;
                    centralMecanicos.HorarioEntrada = MecanicosPabloLivas.HorarioEntrada;
                    centralMecanicos.HorarioSalida = MecanicosPabloLivas.HorarioSalida;


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
                List<PabloLivas.Entities.ModelosTaller> modelosPabloLivas = PabloLivas.Entities.ModelosTaller.Read();
                foreach (PabloLivas.Entities.ModelosTaller ModelosPabloLivas in modelosPabloLivas)
                {
                    Central.Entities.Modelos centralModelos = new Central.Entities.Modelos();
                    centralModelos.Modelo_ID = ModelosPabloLivas.Folio;
                    centralModelos.Nombre = ModelosPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.Modelos> modelosunidadesPabloLivas = PabloLivas.Entities.Modelos.Read();
                foreach (PabloLivas.Entities.Modelos ModelosUnidadesPabloLivas in modelosunidadesPabloLivas)
                {
                    Central.Entities.ModelosUnidades centralModelosUnidades = new Central.Entities.ModelosUnidades();
                    centralModelosUnidades.ModeloUnidad_ID = 0;

                    centralModelosUnidades.MarcaUnidad_ID = 1; // Actualizar posteriormente
                    centralModelosUnidades.Descripcion = ModelosUnidadesPabloLivas.Descripcion;
                    centralModelosUnidades.PrecioLista = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesPabloLivas.PrecioLista, 0));
                    centralModelosUnidades.Anio = ModelosUnidadesPabloLivas.Año;
                    centralModelosUnidades.Deposito = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesPabloLivas.Deposito, 0));
                    centralModelosUnidades.Activo = (ModelosUnidadesPabloLivas.Status == 1) ? true : false;
                    centralModelosUnidades.referencia_id = ModelosUnidadesPabloLivas.Folio;
                    centralModelosUnidades.EmpresaReferencia = Estacion; //    CAM


                    if (Central.DB.Exists(
                        "ModelosUnidades",
                        Param("Referencia_ID", ModelosUnidadesPabloLivas.Folio),
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
                List<PabloLivas.Entities.HistorialInventario> historialinventarioPabloLivas = PabloLivas.Entities.HistorialInventario.Read();
                foreach (PabloLivas.Entities.HistorialInventario HistorialInventarioPabloLivas in historialinventarioPabloLivas)
                {
                    Central.Entities.MovimientosInventario centralMovimientosInventario = new Central.Entities.MovimientosInventario();
                    centralMovimientosInventario.MovimientoInventario_ID = 0;
                    int tipo = GetTipoMovimientoInventario(HistorialInventarioPabloLivas.Tipo);
                    centralMovimientosInventario.TipoMovimientoInventario_ID = tipo;
                    centralMovimientosInventario.OrdenCompra_ID = (tipo == 2 || tipo == 4) ? Convert.ToInt32(HistorialInventarioPabloLivas.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.OrdenTrabajo_ID = (tipo == 1 || tipo == 6) ? Convert.ToInt32(HistorialInventarioPabloLivas.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.NotaAlmacen_ID = HistorialInventarioPabloLivas.NotaAlmacen;
                    centralMovimientosInventario.AjusteInventario_ID = (tipo == 3) ? Convert.ToInt32(HistorialInventarioPabloLivas.Folio) : Central.DB.GetNullableInt32(null);
                    centralMovimientosInventario.Usuario_ID = HistorialInventarioPabloLivas.Usuario;
                    centralMovimientosInventario.Refaccion_ID = HistorialInventarioPabloLivas.Refaccion;
                    centralMovimientosInventario.Fecha = HistorialInventarioPabloLivas.Fecha;
                    centralMovimientosInventario.Cantidad = Convert.ToInt32(HistorialInventarioPabloLivas.Cantidad);
                    centralMovimientosInventario.CostoUnitario = HistorialInventarioPabloLivas.CostoUnitario;
                    centralMovimientosInventario.Valor = HistorialInventarioPabloLivas.Valor;
                    centralMovimientosInventario.CantidadPrev = Convert.ToInt32(HistorialInventarioPabloLivas.CantidadPrev);
                    centralMovimientosInventario.ValorPrev = HistorialInventarioPabloLivas.ValorPrev;
                    centralMovimientosInventario.CantidadPost = Convert.ToInt32(HistorialInventarioPabloLivas.CantidadPost);
                    centralMovimientosInventario.ValorPost = HistorialInventarioPabloLivas.ValorPost;
                    centralMovimientosInventario.CantidadPrevProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPrevProm = 0; // Por calcular
                    centralMovimientosInventario.CantidadPostProm = 0; // Por calcular
                    centralMovimientosInventario.ValorPostProm = 0; // Por calcular
                    centralMovimientosInventario.Referencia = HistorialInventarioPabloLivas.Movimiento;


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
                List<PabloLivas.Entities.NotasAlmacen> notasalmacenPabloLivas = PabloLivas.Entities.NotasAlmacen.Read();
                foreach (PabloLivas.Entities.NotasAlmacen NotasAlmacenPabloLivas in notasalmacenPabloLivas)
                {
                    if (NotasAlmacenPabloLivas.OrdenCompra != null && NotasAlmacenPabloLivas.OrdenCompra == 0) continue;
                    if (NotasAlmacenPabloLivas.OrdenTrabajo != null && NotasAlmacenPabloLivas.OrdenTrabajo == 0) continue;

                    Central.Entities.NotasAlmacen centralNotasAlmacen = new Central.Entities.NotasAlmacen();
                    centralNotasAlmacen.NotaAlmacen_ID = NotasAlmacenPabloLivas.NotaAlmacenID;
                    centralNotasAlmacen.Usuario_ID = NotasAlmacenPabloLivas.Usuario;
                    centralNotasAlmacen.TipoMovimientoInventario_ID = (NotasAlmacenPabloLivas.Tipo == "ENTRADA") ? 1 : 2;
                    centralNotasAlmacen.OrdenCompra_ID = NotasAlmacenPabloLivas.OrdenCompra;
                    centralNotasAlmacen.OrdenTrabajo_ID = NotasAlmacenPabloLivas.OrdenTrabajo;
                    centralNotasAlmacen.Fecha = NotasAlmacenPabloLivas.Fecha;

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

                PabloLivas.Entities.OrdenesCompras OrdenesComprasPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (PabloLivas.Entities.OrdenesCompras.Read(out OrdenesComprasPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesComprasPabloLivas.Folio;

                    Central.Entities.OrdenesCompras centralOrdenesCompras = new Central.Entities.OrdenesCompras();
                    centralOrdenesCompras.OrdenCompra_ID = OrdenesComprasPabloLivas.Folio;

                    //  Obtener el proveedor
                    //  Los proveedores deben estar datos de alta en el sistema previamente
                    //  buscar por rfc
                    int proveedor = Central.Entities.Empresas.Read(Param("Rfc", OrdenesComprasPabloLivas.Proveedores.Rfc))[0].Empresa_ID;
                    centralOrdenesCompras.Proveedor_ID = proveedor;
                    centralOrdenesCompras.EstatusOrdenCompra_ID = Convert.ToInt32(AppHelper.IsNull(OrdenesComprasPabloLivas.Status, 1));
                    centralOrdenesCompras.Usuario_ID = OrdenesComprasPabloLivas.UsuarioAlta;
                    centralOrdenesCompras.Fecha = OrdenesComprasPabloLivas.FechaAlta;
                    centralOrdenesCompras.Factura = OrdenesComprasPabloLivas.Factura;
                    centralOrdenesCompras.Subtotal = OrdenesComprasPabloLivas.SubTotal;
                    centralOrdenesCompras.IVA = OrdenesComprasPabloLivas.IVA;
                    centralOrdenesCompras.Total = OrdenesComprasPabloLivas.Total;

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

                //List<PabloLivas.Entities.OrdenesCompras> ordenescomprasPabloLivas = PabloLivas.Entities.OrdenesCompras.Read();
                //foreach (PabloLivas.Entities.OrdenesCompras OrdenesComprasPabloLivas in ordenescomprasPabloLivas)
                //{                    


                //}	//	End foreach

            }	//	End Method SyncOrdenesCompras

            public void SyncOrdenesComprasCanceladas()
            {
                //  Ajustar con read
                List<PabloLivas.Entities.OrdenesComprasCanceladas> ordenescomprascanceladasPabloLivas = PabloLivas.Entities.OrdenesComprasCanceladas.Read();
                foreach (PabloLivas.Entities.OrdenesComprasCanceladas OrdenesComprasCanceladasPabloLivas in ordenescomprascanceladasPabloLivas)
                {
                    // si no tiene compra, no checar
                    if (!PabloLivas.DB.Exists("OrdenesCompras", Param("Folio", OrdenesComprasCanceladasPabloLivas.OrdenCompra))) continue;

                    Central.Entities.OrdenesComprasCanceladas centralOrdenesComprasCanceladas = new Central.Entities.OrdenesComprasCanceladas();
                    centralOrdenesComprasCanceladas.OrdenCompra_ID = OrdenesComprasCanceladasPabloLivas.OrdenCompra;
                    centralOrdenesComprasCanceladas.Usuario_ID = OrdenesComprasCanceladasPabloLivas.Usuario;
                    centralOrdenesComprasCanceladas.Fecha = OrdenesComprasCanceladasPabloLivas.Fecha;
                    centralOrdenesComprasCanceladas.Comentarios = OrdenesComprasCanceladasPabloLivas.Motivos;


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
                PabloLivas.Entities.OrdenesServicio OrdenesServiciosPabloLivas;
                string filter = "Folio > @Folio";
                string sort = "Folio ASC";
                int folio = Convert.ToInt32(Central.DB.QueryScalar("SELECT ISNULL(MAX(OrdenServicio_ID),0) folio FROM OrdenesServicios"));

                while (PabloLivas.Entities.OrdenesServicio.Read(out OrdenesServiciosPabloLivas, 1, filter, sort, Param("@Folio", folio)))
                {
                    try
                    {
                        Central.Entities.OrdenesTrabajos.Read(OrdenesServiciosPabloLivas.OrdenTrabajo);
                    }
                    catch (SICASException sicasEx)
                    {
                        folio = OrdenesServiciosPabloLivas.Folio;
                        continue;
                    }
                    catch 
                    {
                        throw;
                    }

                    Central.Entities.OrdenesServicios centralOrdenesServicios = new Central.Entities.OrdenesServicios();
                    folio = OrdenesServiciosPabloLivas.Folio;

                    centralOrdenesServicios.OrdenServicio_ID = OrdenesServiciosPabloLivas.Folio;
                    centralOrdenesServicios.OrdenTrabajo_ID = OrdenesServiciosPabloLivas.OrdenTrabajo;
                    centralOrdenesServicios.ServicioMantenimiento_ID = OrdenesServiciosPabloLivas.Servicio;
                    centralOrdenesServicios.Mecanico_ID = OrdenesServiciosPabloLivas.Mecanico;
                    centralOrdenesServicios.EstatusOrdenServicio_ID = OrdenesServiciosPabloLivas.Status;
                    centralOrdenesServicios.Fecha = Central.DB.GetNullableDateTime(OrdenesServiciosPabloLivas.FechaSurtida);
                    centralOrdenesServicios.Cantidad = Convert.ToInt32(OrdenesServiciosPabloLivas.Cantidad);
                    centralOrdenesServicios.Precio = OrdenesServiciosPabloLivas.PrecioUnitario;
                    centralOrdenesServicios.Total = OrdenesServiciosPabloLivas.Total;


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
                List<PabloLivas.Entities.OrdenesServicioRefacciones> ordenesserviciosrefaccionesPabloLivas = PabloLivas.Entities.OrdenesServicioRefacciones.Read();
                foreach (PabloLivas.Entities.OrdenesServicioRefacciones OrdenesServiciosRefaccionesPabloLivas in ordenesserviciosrefaccionesPabloLivas)
                {
                    if (!Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", OrdenesServiciosRefaccionesPabloLivas.OrdenServicio)))
                    {
                        continue;
                    }
                    Central.Entities.OrdenesServiciosRefacciones centralOrdenesServiciosRefacciones = new Central.Entities.OrdenesServiciosRefacciones();
                    centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID = 0;
                    centralOrdenesServiciosRefacciones.OrdenServicio_ID = OrdenesServiciosRefaccionesPabloLivas.OrdenServicio;
                    centralOrdenesServiciosRefacciones.Refaccion_ID = OrdenesServiciosRefaccionesPabloLivas.Refaccion;
                    centralOrdenesServiciosRefacciones.Cantidad = Convert.ToInt32(OrdenesServiciosRefaccionesPabloLivas.Cantidad);
                    centralOrdenesServiciosRefacciones.PrecioUnitario = OrdenesServiciosRefaccionesPabloLivas.PrecioUnitario;
                    centralOrdenesServiciosRefacciones.Total = OrdenesServiciosRefaccionesPabloLivas.Total;
                    centralOrdenesServiciosRefacciones.CostoUnitario = (decimal)OrdenesServiciosRefaccionesPabloLivas.CostoUnitario;
                    centralOrdenesServiciosRefacciones.RefSurtidas = Central.DB.GetNullableInt32(OrdenesServiciosRefaccionesPabloLivas.RefSurtidas);


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
                List<PabloLivas.Entities.StatusOrdenesTrabajo> estatusordenestrabajosPabloLivas = PabloLivas.Entities.StatusOrdenesTrabajo.Read();
                foreach (PabloLivas.Entities.StatusOrdenesTrabajo EstatusOrdenesTrabajosPabloLivas in estatusordenestrabajosPabloLivas)
                {
                    Central.Entities.EstatusOrdenesTrabajos centralEstatusOrdenesTrabajos = new Central.Entities.EstatusOrdenesTrabajos();
                    centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID = EstatusOrdenesTrabajosPabloLivas.Folio;
                    centralEstatusOrdenesTrabajos.Nombre = EstatusOrdenesTrabajosPabloLivas.Descripcion;

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
                List<PabloLivas.Entities.TiposMantenimientos> tiposmantenimientosPabloLivas = PabloLivas.Entities.TiposMantenimientos.Read();
                foreach (PabloLivas.Entities.TiposMantenimientos TiposMantenimientosPabloLivas in tiposmantenimientosPabloLivas)
                {
                    Central.Entities.TiposMantenimientos centralTiposMantenimientos = new Central.Entities.TiposMantenimientos();
                    centralTiposMantenimientos.TipoMantenimiento_ID = TiposMantenimientosPabloLivas.Folio;
                    centralTiposMantenimientos.Nombre = TiposMantenimientosPabloLivas.Descripcion;


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

                PabloLivas.Entities.OrdenesTrabajo OrdenesTrabajosPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (PabloLivas.Entities.OrdenesTrabajo.Read(out OrdenesTrabajosPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesTrabajosPabloLivas.Folio;
                    Central.Entities.OrdenesTrabajos centralOrdenesTrabajos = new Central.Entities.OrdenesTrabajos();
                    centralOrdenesTrabajos.OrdenTrabajo_ID = OrdenesTrabajosPabloLivas.Folio;
                    centralOrdenesTrabajos.Empresa_ID = GetEmpresaClienteTaller(OrdenesTrabajosPabloLivas.ClienteTaller.Tipo);
                    centralOrdenesTrabajos.TipoMantenimiento_ID = Convert.ToInt32(OrdenesTrabajosPabloLivas.TipoMantenimiento);
                    centralOrdenesTrabajos.ClienteFacturar_ID = GetEmpresaClienteTaller(OrdenesTrabajosPabloLivas.ClienteTaller.Tipo);

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", OrdenesTrabajosPabloLivas.Unidad), Param("Estacion_ID", Estacion));
                    int unidad_id = 1;
                    if (unidad != null) unidad_id = unidad.Unidad_ID;

                    centralOrdenesTrabajos.Unidad_ID = unidad_id;
                    centralOrdenesTrabajos.EstatusOrdenTrabajo_ID = OrdenesTrabajosPabloLivas.Status;
                    centralOrdenesTrabajos.Caja_ID = (OrdenesTrabajosPabloLivas.Caja == 9) ? 2 : OrdenesTrabajosPabloLivas.Caja;
                    centralOrdenesTrabajos.Usuario_ID = OrdenesTrabajosPabloLivas.UsuarioAlta;
                    centralOrdenesTrabajos.Factura_ID = null;
                    centralOrdenesTrabajos.UsuarioFacturacion_ID = OrdenesTrabajosPabloLivas.UsuarioFacturacion;
                    centralOrdenesTrabajos.CodigoBarras = OrdenesTrabajosPabloLivas.CodigoBarras;
                    centralOrdenesTrabajos.Subtotal = OrdenesTrabajosPabloLivas.Subtotal;
                    centralOrdenesTrabajos.IVA = OrdenesTrabajosPabloLivas.IVA;
                    centralOrdenesTrabajos.Total = OrdenesTrabajosPabloLivas.Total;
                    centralOrdenesTrabajos.FechaAlta = OrdenesTrabajosPabloLivas.FechaAlta;
                    centralOrdenesTrabajos.FechaTerminacion = OrdenesTrabajosPabloLivas.FechaTerminacion;
                    centralOrdenesTrabajos.FechaPago = OrdenesTrabajosPabloLivas.FechaPago;
                    centralOrdenesTrabajos.NumeroEconomico = Convert.ToInt32(OrdenesTrabajosPabloLivas.NumeroEconomico);
                    centralOrdenesTrabajos.FechaInicioReparacion = OrdenesTrabajosPabloLivas.FechaInicioReparacion;
                    centralOrdenesTrabajos.ManoObra = Convert.ToDecimal(OrdenesTrabajosPabloLivas.ManoObra);
                    centralOrdenesTrabajos.IVAManoObra = Convert.ToDecimal(OrdenesTrabajosPabloLivas.IVAManoObra);
                    centralOrdenesTrabajos.Refacciones = Convert.ToDecimal(OrdenesTrabajosPabloLivas.Refacciones);
                    centralOrdenesTrabajos.IVARefacciones = Convert.ToDecimal(OrdenesTrabajosPabloLivas.IVARefacciones);
                    centralOrdenesTrabajos.FechaFacturacion = OrdenesTrabajosPabloLivas.FechaFacturacion;
                    centralOrdenesTrabajos.Kilometraje = OrdenesTrabajosPabloLivas.Kilometraje;
                    centralOrdenesTrabajos.Comentarios = OrdenesTrabajosPabloLivas.Comentarios;
                    centralOrdenesTrabajos.CostoRefacciones = Convert.ToDecimal(OrdenesTrabajosPabloLivas.CostoRefacciones);
                    centralOrdenesTrabajos.CostoManoObra = Convert.ToDecimal(OrdenesTrabajosPabloLivas.CostoManoObra);
                    centralOrdenesTrabajos.CargoAConductor = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosPabloLivas.CargoCond, false));
                    centralOrdenesTrabajos.CB = OrdenesTrabajosPabloLivas.CB;
                    centralOrdenesTrabajos.CB_Activo = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosPabloLivas.CB_Activo, false));


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

                //List<PabloLivas.Entities.OrdenesTrabajo> ordenestrabajosPabloLivas = PabloLivas.Entities.OrdenesTrabajo.Read();
                //foreach (PabloLivas.Entities.OrdenesTrabajo OrdenesTrabajosPabloLivas in ordenestrabajosPabloLivas)
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

                PabloLivas.Entities.Refacciones RefaccionesPabloLivas;
                int folio = folioinicial;

                while (PabloLivas.Entities.Refacciones.Read(out RefaccionesPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesPabloLivas.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesPabloLivas.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesPabloLivas.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesPabloLivas.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesPabloLivas.Marca == null)
                    {
                        if (RefaccionesPabloLivas.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesPabloLivas.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesPabloLivas.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesPabloLivas.Año;
                    //centralRefacciones.Pasillo = RefaccionesPabloLivas.Pasillo;
                    //centralRefacciones.Estante = RefaccionesPabloLivas.Estante;
                    //centralRefacciones.Nivel = RefaccionesPabloLivas.Nivel;
                    //centralRefacciones.Seccion = RefaccionesPabloLivas.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesPabloLivas.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesPabloLivas.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenExt, 0));
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

                PabloLivas.Entities.Refacciones RefaccionesPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (PabloLivas.Entities.Refacciones.Read(out RefaccionesPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesPabloLivas.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesPabloLivas.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesPabloLivas.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesPabloLivas.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesPabloLivas.Marca == null)
                    {
                        if (RefaccionesPabloLivas.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesPabloLivas.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesPabloLivas.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesPabloLivas.Año;
                    //centralRefacciones.Pasillo = RefaccionesPabloLivas.Pasillo;
                    //centralRefacciones.Estante = RefaccionesPabloLivas.Estante;
                    //centralRefacciones.Nivel = RefaccionesPabloLivas.Nivel;
                    //centralRefacciones.Seccion = RefaccionesPabloLivas.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesPabloLivas.NumeroDeParte;

                    //  Obtener la descripción a partir las variables
                    centralRefacciones.Descripcion = RefaccionesPabloLivas.Descripcion;

                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenExt, 0));

                    string sqlstr = "SELECT	SUM(Cantidad) Cantidad FROM Inventario WHERE	Refaccion = @Refaccion";
                    int cantidadInventario = Convert.ToInt32(PabloLivas.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesPabloLivas.Folio)));
                    //centralRefacciones.CantidadInventario = cantidadInventario;

                    sqlstr = "SELECT	SUM(Costo) Costo FROM Inventario WHERE	Refaccion = @Refaccion";
                    decimal valorInventario = Convert.ToDecimal(PabloLivas.DB.QueryScalar(sqlstr, Param("@Refaccion", RefaccionesPabloLivas.Folio)));
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

                List<PabloLivas.Entities.Refacciones> refaccionesPabloLivas = PabloLivas.Entities.Refacciones.Read(filter, "");
                foreach (PabloLivas.Entities.Refacciones RefaccionesPabloLivas in refaccionesPabloLivas)
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    centralRefacciones.Refaccion_ID = RefaccionesPabloLivas.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesPabloLivas.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesPabloLivas.Modelo;
                    centralRefacciones.MarcaRefaccion_ID = Convert.ToInt32(AppHelper.IsNull(RefaccionesPabloLivas.Marca, RefaccionesPabloLivas.Inventario[0].Marca));
                    centralRefacciones.Anio = RefaccionesPabloLivas.Año;
                    //centralRefacciones.Pasillo = RefaccionesPabloLivas.Pasillo;
                    //centralRefacciones.Estante = RefaccionesPabloLivas.Estante;
                    //centralRefacciones.Nivel = RefaccionesPabloLivas.Nivel;
                    //centralRefacciones.Seccion = RefaccionesPabloLivas.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesPabloLivas.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesPabloLivas.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesPabloLivas.MargenExt, 0));
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
                List<PabloLivas.Entities.Servicios> serviciosmantenimientosPabloLivas = PabloLivas.Entities.Servicios.Read();
                foreach (PabloLivas.Entities.Servicios ServiciosMantenimientosPabloLivas in serviciosmantenimientosPabloLivas)
                {
                    Central.Entities.ServiciosMantenimientos centralServiciosMantenimientos = new Central.Entities.ServiciosMantenimientos();
                    centralServiciosMantenimientos.ServicioMantenimiento_ID = ServiciosMantenimientosPabloLivas.Folio;
                    centralServiciosMantenimientos.TipoServicioMantenimiento_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Familia_ID = (ServiciosMantenimientosPabloLivas.Familia == 0) ? 1 : ServiciosMantenimientosPabloLivas.Familia;
                    centralServiciosMantenimientos.Modelo_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Nombre = ServiciosMantenimientosPabloLivas.Descripcion;
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
                List<PabloLivas.Entities.ServiciosTiposRefacciones> serviciosmantenimientos_tiposrefaccionesPabloLivas = PabloLivas.Entities.ServiciosTiposRefacciones.Read();
                foreach (PabloLivas.Entities.ServiciosTiposRefacciones ServiciosMantenimientos_TiposRefaccionesPabloLivas in serviciosmantenimientos_tiposrefaccionesPabloLivas)
                {
                    Central.Entities.ServiciosMantenimientos_TiposRefacciones centralServiciosMantenimientos_TiposRefacciones = new Central.Entities.ServiciosMantenimientos_TiposRefacciones();
                    centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID = ServiciosMantenimientos_TiposRefaccionesPabloLivas.Servicio;
                    centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID = ServiciosMantenimientos_TiposRefaccionesPabloLivas.TipoRefaccion;
                    centralServiciosMantenimientos_TiposRefacciones.Cantidad = ServiciosMantenimientos_TiposRefaccionesPabloLivas.Cantidad;

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

                PabloLivas.Entities.ControlCajas SesionesPabloLivas;
                int sesion;

                sesion = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.ControlCajas.Read(out SesionesPabloLivas, 1, filter, sort, Param("Sesion", sesion)))
                {
                    sesion = SesionesPabloLivas.Sesion;

                    Central.Entities.Sesiones centralSesiones = new Central.Entities.Sesiones();
                    centralSesiones.Sesion_ID = SesionesPabloLivas.Sesion;
                    centralSesiones.Empresa_ID = Empresa; // CAM
                    centralSesiones.Estacion_ID = Estacion; // PabloLivas

                    SesionesPabloLivas.Caja = SesionesPabloLivas.Caja.Trim();
                    centralSesiones.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Referencia_ID", SesionesPabloLivas.Caja), Param("Estacion_ID", Estacion)).Caja_ID;
                    PabloLivas.Entities.MovimientosCaja mc = PabloLivas.Entities.MovimientosCaja.Read(Param("Sesion", SesionesPabloLivas.Sesion));

                    centralSesiones.Usuario_ID = (mc == null) ? "SICAS" : mc.Usuario;

                    centralSesiones.FechaInicial = SesionesPabloLivas.Inicio;
                    centralSesiones.FechaFinal = SesionesPabloLivas.Corte;
                    centralSesiones.HostName = null;
                    centralSesiones.IPAddress = null;
                    centralSesiones.MACAddress = null;
                    centralSesiones.Activo = (SesionesPabloLivas.Corte == null) ? true : false;
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

                PabloLivas.Entities.Recibos TicketsPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.Recibos.Read(out TicketsPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TicketsPabloLivas.Folio;

                    Central.Entities.Tickets centralTickets = new Central.Entities.Tickets();

                    centralTickets.Ticket_ID = 0;
                    centralTickets.Referencia_ID = folio;

                    //  Consultar la sesión por usuario y fecha
                    PabloLivas.Entities.ControlCajas cc = PabloLivas.Entities.ControlCajas.GetBy(TicketsPabloLivas.Fecha, TicketsPabloLivas.Caja);
                    if (cc == null) continue;
                    int sesionlocal = cc.Sesion;

                    Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(Param("Referencia_ID", sesionlocal), Param("Estacion_ID", Estacion));
                    if (s == null) continue;

                    int sesion_id = s.Sesion_ID;
                    centralTickets.Sesion_ID = sesion_id;

                    centralTickets.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsPabloLivas.Caja)).Caja_ID;
                    centralTickets.Usuario_ID = TicketsPabloLivas.UsuarioAlta;

                    //  Si existe en cancelados
                    if (PabloLivas.DB.Exists("RecibosCancelados", Param("Estacion", Estacion), Param("Recibo", TicketsPabloLivas.Folio)))
                    {
                        centralTickets.EstatusTicket_ID = 2;
                    }
                    else
                    {
                        centralTickets.EstatusTicket_ID = 1;
                    }

                    centralTickets.Empresa_ID = Empresa; // CAM
                    centralTickets.Estacion_ID = Estacion; // PabloLivas

                    if (TicketsPabloLivas.Unidad == 0)
                    {
                        centralTickets.Unidad_ID = null;
                    }
                    else
                    {
                        centralTickets.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsPabloLivas.Unidad)).Unidad_ID;
                    }

                    centralTickets.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", TicketsPabloLivas.Conductor)).Conductor_ID;


                    centralTickets.Fecha = TicketsPabloLivas.Fecha;

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
                List<PabloLivas.Entities.RecibosCancelados> ticketscanceladosPabloLivas = PabloLivas.Entities.RecibosCancelados.Read();
                foreach (PabloLivas.Entities.RecibosCancelados TicketsCanceladosPabloLivas in ticketscanceladosPabloLivas)
                {
                    Central.Entities.TicketsCancelados centralTicketsCancelados = new Central.Entities.TicketsCancelados();

                    Central.Entities.Tickets ticket = Central.Entities.Tickets.Read(Param("Referencia_ID", TicketsCanceladosPabloLivas.Recibo), Param("Estacion_ID", Estacion));
                    if (ticket == null)
                    {
                        // Ticket no existe
                        continue;
                    }
                    centralTicketsCancelados.Ticket_ID = ticket.Ticket_ID;
                    centralTicketsCancelados.Motivo = TicketsCanceladosPabloLivas.Motivo;
                    centralTicketsCancelados.Usuario_ID = TicketsCanceladosPabloLivas.Usuario;
                    centralTicketsCancelados.Fecha = Convert.ToDateTime(TicketsCanceladosPabloLivas.Fecha);


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
                List<PabloLivas.Entities.TiposRefacciones> tiposrefaccionesPabloLivas
                    = PabloLivas.Entities.TiposRefacciones.Read();
                foreach (PabloLivas.Entities.TiposRefacciones TiposRefaccionesPabloLivas in tiposrefaccionesPabloLivas)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesPabloLivas.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesPabloLivas.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesPabloLivas.Descripcion;


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
                List<PabloLivas.Entities.TiposRefacciones> tiposrefaccionesPabloLivas = PabloLivas.Entities.TiposRefacciones.Read();
                foreach (PabloLivas.Entities.TiposRefacciones TiposRefaccionesPabloLivas in tiposrefaccionesPabloLivas)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesPabloLivas.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesPabloLivas.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesPabloLivas.Descripcion;

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

                PabloLivas.Entities.Unidades UnidadesPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                folio = 0;
                while (PabloLivas.Entities.Unidades.Read(out UnidadesPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesPabloLivas.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesPabloLivas.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // PabloLivas
                    centralUnidades.NumeroEconomico = UnidadesPabloLivas.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesPabloLivas.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesPabloLivas.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesPabloLivas.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesPabloLivas.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesPabloLivas.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesPabloLivas.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesPabloLivas.Locacion);

                    centralUnidades.Placas = (UnidadesPabloLivas.Concesion == null) ? "" : UnidadesPabloLivas.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesPabloLivas.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesPabloLivas.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesPabloLivas.Folio;


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


            public void SyncUnidades()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                PabloLivas.Entities.Unidades UnidadesPabloLivas;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.Unidades.Read(out UnidadesPabloLivas, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesPabloLivas.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesPabloLivas.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // PabloLivas
                    centralUnidades.NumeroEconomico = UnidadesPabloLivas.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesPabloLivas.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesPabloLivas.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesPabloLivas.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesPabloLivas.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesPabloLivas.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesPabloLivas.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesPabloLivas.Locacion);

                    centralUnidades.Placas = (UnidadesPabloLivas.Concesion == null) ? "" : UnidadesPabloLivas.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesPabloLivas.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesPabloLivas.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    centralUnidades.Referencia_ID = UnidadesPabloLivas.Folio;


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

                PabloLivas.Entities.RegistroKilometrajesUnidades Unidades_KilometrajesPabloLivas;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.RegistroKilometrajesUnidades.Read(out Unidades_KilometrajesPabloLivas, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_KilometrajesPabloLivas.Fecha;

                    Central.Entities.Unidades_Kilometrajes centralUnidades_Kilometrajes = new Central.Entities.Unidades_Kilometrajes();

                    centralUnidades_Kilometrajes.Unidad_Kilometraje_ID = 0; // A determinar

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", Unidades_KilometrajesPabloLivas.Unidad));
                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_KilometrajesPabloLivas.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Kilometrajes.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesPabloLivas.ConductorActual)).Conductor_ID;

                    Central.Entities.Conductores conductor =
                         Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesPabloLivas.ConductorActual));

                    if (conductor == null)
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = null;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = conductor.Conductor_ID;
                    }

                    centralUnidades_Kilometrajes.Kilometraje = Unidades_KilometrajesPabloLivas.Kilometraje;
                    centralUnidades_Kilometrajes.Fecha = Unidades_KilometrajesPabloLivas.Fecha;

                    if (Central.DB.Exists("Unidades_Kilometrajes", Param("Unidad_Kilometraje_ID", centralUnidades_Kilometrajes.Unidad_Kilometraje_ID)))
                    {
                        centralUnidades_Kilometrajes.Update();
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Create();
                    }

                    Central.DB.UpdateRow(
                        "Unidades",
                        Central.DB.GetParams(
                            Param("Kilometraje", Unidades_KilometrajesPabloLivas.Kilometraje)
                        ),
                        Central.DB.GetParams(
                            Param("Unidad_ID", centralUnidades_Kilometrajes.Unidad_ID)
                        )
                    );

                    Console.WriteLine(String.Format("Registro actualizado Unidad_Kilometraje_ID: {0}", centralUnidades_Kilometrajes.Unidad_Kilometraje_ID));
                }
            }	//	End Method SyncUnidades_Kilometrajes

            public void UpdateUnidadesKilometrajes()
            {
                string sql = @"UPDATE	Unidades
SET	Kilometraje =  K.Kilometraje
FROM	(
SELECT	U.Unidad_ID, MAX(UK.Fecha) Fecha, MAX(UK.Kilometraje) Kilometraje
FROM	Unidades_Kilometrajes UK
INNER JOIN	Unidades U
ON		U.Unidad_ID = UK.Unidad_ID
WHERE	U.Estacion_ID = @Estacion
GROUP BY	U.Unidad_ID
) K, Unidades U
WHERE	U.Unidad_ID = K.Unidad_ID";

                Central.DB.ExecuteCommand(
                    sql,
                    Central.DB.GetParams(
                        Param("@Estacion", Estacion)
                    )
                );
            }

            //  Unidades Locaciones
            public void SyncUnidades_Locaciones()
            {
                string filter = "Fecha > @Fecha";

                string sort = "Fecha ASC";

                string sqlQry = "SELECT ISNULL(MAX(UL.Fecha),0) Fecha FROM Unidades_Locaciones UL " +
                    "INNER JOIN Unidades U ON UL.Unidad_ID = U.Unidad_ID WHERE U.Estacion_ID = @Estacion";

                PabloLivas.Entities.RegistroLocacionesUnidades Unidades_LocacionesPabloLivas;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (PabloLivas.Entities.RegistroLocacionesUnidades.Read(out Unidades_LocacionesPabloLivas, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_LocacionesPabloLivas.Fecha;

                    Central.Entities.Unidades_Locaciones centralUnidades_Locaciones = new Central.Entities.Unidades_Locaciones();

                    Central.Entities.Unidades unidad =
                        Central.Entities.Unidades.Read(
                            Param("Estacion_ID", this.Estacion),
                                Param("Referencia_ID", Unidades_LocacionesPabloLivas.Unidad));

                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_LocacionesPabloLivas.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Locaciones.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Locaciones.LocacionUnidad_ID = LocacionCentral(Unidades_LocacionesPabloLivas.Locacion); // A consultar

                    centralUnidades_Locaciones.Fecha = Unidades_LocacionesPabloLivas.Fecha;


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

                PabloLivas.Entities.ValesPrepagados ValesPrepagadosPabloLivas;
                string vale;

                vale = Convert.ToString(Central.DB.QueryScalar(sqlQry));

                while (PabloLivas.Entities.ValesPrepagados.Read(out ValesPrepagadosPabloLivas, 1, filter, sort, Param("@Codigo", vale)))
                {
                    vale = ValesPrepagadosPabloLivas.Codigo;

                    Central.Entities.ValesPrepagados centralValesPrepagados = new Central.Entities.ValesPrepagados();
                    centralValesPrepagados.ValePrepagado_ID = ValesPrepagadosPabloLivas.Codigo;

                    if (ValesPrepagadosPabloLivas.Cliente == 0) continue;

                    int empresacliente_id = Central.Entities.Empresas.Read(Param("Rfc", ValesPrepagadosPabloLivas.Clientes.Rfc))[0].Empresa_ID;
                    centralValesPrepagados.EmpresaCliente_ID = empresacliente_id;

                    centralValesPrepagados.Usuario_ID = ValesPrepagadosPabloLivas.UsuarioEmision;
                    centralValesPrepagados.EstatusValePrepagado_ID = ValesPrepagadosPabloLivas.Status;
                    centralValesPrepagados.FolioDiario = ValesPrepagadosPabloLivas.FolioDiario;
                    centralValesPrepagados.Denominacion = ValesPrepagadosPabloLivas.Denominacion;
                    centralValesPrepagados.FechaEmision = ValesPrepagadosPabloLivas.FechaEmision;
                    centralValesPrepagados.FechaExpiracion = ValesPrepagadosPabloLivas.FechaExpiracion;

                    //  Se obtiene del recibo
                    if (ValesPrepagadosPabloLivas.RecibosValesPrepagados != null)
                    {
                        Central.Entities.Tickets ticket =
                            Central.Entities.Tickets.Read(
                            Param("Referencia_ID", ValesPrepagadosPabloLivas.Recibos.Folio),
                            Param("Estacion_ID", Estacion));

                        if (ticket != null)
                        {
                            centralValesPrepagados.Ticket_ID = ticket.Ticket_ID;
                        }
                        centralValesPrepagados.FechaCanje = ValesPrepagadosPabloLivas.Recibos.Fecha;
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
                IEnumerable<int> estaciones = PabloLivas.DB.QueryList<int>("SELECT DISTINCT Estacion FROM PlanillasFiscales", "Estacion");

                foreach (int estacion in estaciones)
                {
                    IEnumerable<string> series =
                        PabloLivas.DB.QueryList<string>("SELECT DISTINCT Serie FROM PlanillasFiscales WHERE Estacion = " + estacion.ToString(), "Serie");

                    foreach (string serie in series)
                    {
                        //  Obtener el ultimo folio de planilla fiscal para dicha estación y serie
                        //  Ejecutar el read
                        string filter = "Estacion = @Estacion AND Serie = @Serie AND Folio > @Folio";
                        string sort = "Folio ASC";
                        string sqlQry = "SELECT ISNULL(MAX(Folio),0) Folio FROM PlanillasFiscales WHERE Estacion_ID = @Estacion_ID AND Serie = @Serie";

                        PabloLivas.Entities.PlanillasFiscales PlanillasFiscalesPabloLivas;
                        int folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, PabloLivas.DB.GetParams(Param("@Estacion_ID", estacion), Param("@Serie", serie))));

                        while (PabloLivas.Entities.PlanillasFiscales.Read(out PlanillasFiscalesPabloLivas, 1, filter, sort,
                            Param("@Estacion", estacion), Param("@Serie", serie), Param("@Folio", folio)))
                        {
                            Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();
                            folio = PlanillasFiscalesPabloLivas.Folio;

                            if (PlanillasFiscalesPabloLivas.RecibosPlanillas == null)
                            {
                                centralPlanillasFiscales.Ticket_ID = null;
                            }
                            else
                            {
                                centralPlanillasFiscales.Ticket_ID =
                                    Central.Entities.Tickets.Read(
                                        Param("Referencia_ID", PlanillasFiscalesPabloLivas.RecibosPlanillas.Recibo),
                                            Param("Estacion_ID", Estacion)).Ticket_ID;
                            }

                            //  Mediante funcion
                            centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesPabloLivas.Precio);
                            centralPlanillasFiscales.Estacion_ID = estacion; // PabloLivas
                            centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesPabloLivas.Status;
                            centralPlanillasFiscales.Serie = serie;
                            centralPlanillasFiscales.Folio = folio;
                            centralPlanillasFiscales.Precio = PlanillasFiscalesPabloLivas.Precio;
                            centralPlanillasFiscales.Fecha = PlanillasFiscalesPabloLivas.FechaAlta;


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
