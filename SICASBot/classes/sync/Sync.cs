using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASBot.Sync
{
    public partial class Syncronization
    {
        
        public class SyncLA
        {
            private void DoLog(string entry)
            {
                entry  =String.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1}", DateTime.Now, entry);
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
                //SyncUnidades();
                SyncUnidadesInit();
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
                SyncCuentaDepositosGarantia();
                SyncTicketsCancelados();
                SyncUnidades_Kilometrajes();
                SyncUnidades_Locaciones();
                SyncValesPrepagados();
                UpdateUnidadesKilometrajes();
            }

            public void DoSyncMetro()
            {
                bool IsDebug = true;
                if (IsDebug)
                {
                    _DoSyncMetro();
                }
                else
                {
                    try
                    {
                        //errorcode -2146232060
                        Console.WriteLine("Comenzando con la sincronizacion. Estacion: LA");
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

            private void _DoSyncTaller()
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

                // Inventario
                SyncInventario();

                //  ActualizarInventario
                SyncActualizarInventario();

                //  Actualizar descripcion de refacciones
                SyncDescripcionRefacciones();

                //  Servicios
                SyncServiciosMantenimientos();

                //  Precios de Servicios
                SyncServiciosMantenimientosPrecios();

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
                SyncOrdenesTrabajosInit();

                // Estatus ordenes compras
                SyncEstatusOrdenesCompras();

                // Estatus ordenes servicios
                SyncEstatusOrdenesServicios();

                //  Ordenes de servicio
                SyncOrdenesServiciosInit();

                //  Cancelaciones de ordenes de trabajo
                SyncCancelacionesOrdenesTrabajos();

                //  Proveedores
                SyncProveedores();

                //  donde proveedor sea 0, obtener el de mayor porcentaje y pasarlo al mismo
                //  Ordenes de compras
                SyncOrdenesCompras();

                ////  Cancelaciones de compras
                SyncOrdenesComprasCanceladas();

                //  Notas de almacen
                SyncNotasAlmacen();

                //  Ajustes de inventario
                SyncAjustesInventario();

                //  Movimientos de inventario
                SyncMovimientosInventario();
            }

            public void DoSyncTaller()
            {
                bool IsDebug = false;

                if (IsDebug)
                {
                    _DoSyncTaller();
                }
                else
                {
                    try
                    {
                        DateTime fechaInicial = DateTime.Now;

                        _DoSyncTaller();

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

            private int Estacion = 1; // LA
            private int Empresa = 2; // CAM

            private KeyValuePair<string, object> Param(string key, object value)
            {
                return new KeyValuePair<string, object>(key, value);
            }

            public void SyncCuentaDepositosGarantia()
            {
                List<LA.Entities.CuentaDepositosGarantia> Depositos =
                    LA.Entities.CuentaDepositosGarantia.Read();

                foreach (LA.Entities.CuentaDepositosGarantia Deposito in Depositos)
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


            public void SyncDescripcionRefacciones()
            { 
                string sql = @"UPDATE	Refacciones
                SET		Descripcion = UPPER(TR.Nombre + ' ' + 
		                M.Nombre + ' ' + ISNULL(CONVERT(varchar,Anio),'') + ' ' + MR.Nombre)
                FROM	Refacciones R,
		                TiposRefacciones TR,
		                Modelos M,
		                MarcasRefacciones MR
                WHERE	R.TipoRefaccion_ID = TR.TipoRefaccion_ID
                AND		R.Modelo_ID = M.Modelo_ID
                AND		R.MarcaRefaccion_ID = MR.MarcaRefaccion_ID ";

                Central.DB.ExecuteQuery(sql);

                Console.WriteLine("Descripciones de refacciones actualizadas");
            }

            public void SyncPlanesDeRenta()
            {
                List<LA.Entities.Planes> planesderentaLA = LA.Entities.Planes.Read();
                foreach (LA.Entities.Planes PlanesDeRentaLA in planesderentaLA)
                {
                    Central.Entities.PlanesDeRenta centralPlanesDeRenta = new Central.Entities.PlanesDeRenta();
                    centralPlanesDeRenta.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(
                        Param("Referencia_id",
                        (int)PlanesDeRentaLA.Modelo), 
                        Param("EmpresaReferencia", Estacion)
                        ).ModeloUnidad_ID;
                    centralPlanesDeRenta.Usuario_ID = PlanesDeRentaLA.UsuarioAlta;
                    centralPlanesDeRenta.DiasDeCobro_ID = PlanesDeRentaLA.DiasDeCobro.Value;
                    centralPlanesDeRenta.Descripcion = PlanesDeRentaLA.Descripcion;
                    centralPlanesDeRenta.RentaBase = PlanesDeRentaLA.RentaBase;
                    centralPlanesDeRenta.FondoResidual = PlanesDeRentaLA.FondoResidual;
                    centralPlanesDeRenta.Fecha = PlanesDeRentaLA.FechaAlta;
                    centralPlanesDeRenta.Activo = (PlanesDeRentaLA.Status == 1);
                    centralPlanesDeRenta.Referencia_ID = PlanesDeRentaLA.Folio;
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

                    Console.WriteLine(String.Format("Registro actualizado Plan de Renta: {0}", PlanesDeRentaLA.Folio));

                }	//	End foreach

            }	//	End Method SyncPlanesDeRenta

           
            //  Estatus de ordenes de compras
            public void SyncEstatusOrdenesCompras()
            {
                List<LA.Entities.StatusOrdenesCompra> estatusordenescomprasLA = LA.Entities.StatusOrdenesCompra.Read();
                foreach (LA.Entities.StatusOrdenesCompra EstatusOrdenesComprasLA in estatusordenescomprasLA)
                {
                    Central.Entities.EstatusOrdenesCompras centralEstatusOrdenesCompras = new Central.Entities.EstatusOrdenesCompras();
                    centralEstatusOrdenesCompras.EstatusOrdenCompra_ID = EstatusOrdenesComprasLA.Folio;
                    centralEstatusOrdenesCompras.Nombre = EstatusOrdenesComprasLA.Descripcion;


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
                List<LA.Entities.StatusOrdenesServicio> estatusordenesserviciosLA = LA.Entities.StatusOrdenesServicio.Read();
                foreach (LA.Entities.StatusOrdenesServicio EstatusOrdenesServiciosLA in estatusordenesserviciosLA)
                {
                    Central.Entities.EstatusOrdenesServicios centralEstatusOrdenesServicios = new Central.Entities.EstatusOrdenesServicios();
                    centralEstatusOrdenesServicios.EstatusOrdenServicio_ID = EstatusOrdenesServiciosLA.Folio;
                    centralEstatusOrdenesServicios.Nombre = EstatusOrdenesServiciosLA.Descripcion;


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
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(AjusteInventario_ID),0) folio FROM AjustesInventario";

                LA.Entities.MovimientosDirectosAInventario mov;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                maxfolio = Convert.ToInt32(
                    LA.DB.QueryScalar("SELECT ISNULL(MAX(Folio),0) maxfolio FROM MovimientosDirectosAInventario"));

                while (LA.Entities.MovimientosDirectosAInventario.Read(out mov, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = mov.Folio;

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
                    ajuste.Empresa_ID = 4;
                    ajuste.Estacion_ID = 1;

                    if (Central.DB.Exists("AjustesInventario", Param("AjusteInventario_ID", ajuste.AjusteInventario_ID)))
                    {
                        ajuste.Update();
                    }
                    else
                    {
                        ajuste.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado AjusteInventario_ID: {0} de {1}", 
                        ajuste.AjusteInventario_ID, maxfolio));
                }
            }
            
            //  CancelacionesOrdenesTrabajos
            public void SyncCancelacionesOrdenesTrabajos()
            {
                string filter = "OrdenTrabajo > @Folio";

                string sort = "OrdenTrabajo ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenTrabajo_ID),0) folio FROM CancelacionesOrdenesTrabajos";

                LA.Entities.OrdenesTrabajoCanceladas ordenCancelada;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.OrdenesTrabajoCanceladas.Read(out ordenCancelada, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ordenCancelada.OrdenTrabajo;
                
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
                List<LA.Entities.CategoriasMecanicos> categoriasLA = LA.Entities.CategoriasMecanicos.Read();

                foreach (LA.Entities.CategoriasMecanicos LAcategoria in categoriasLA)
                {
                    Central.Entities.CategoriasMecanicos centralCategoria = new Central.Entities.CategoriasMecanicos();
                    centralCategoria.CategoriaMecanico_ID = LAcategoria.Folio;
                    centralCategoria.Familia_ID = LAcategoria.Familia;
                    centralCategoria.Nombre = LAcategoria.Descripcion;

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
            public void SyncCompras(int ordencompra)
            {                
                List<LA.Entities.Compras> comprasLA = LA.Entities.Compras.Read(Param("OrdenCompra", ordencompra));

                foreach (LA.Entities.Compras LAcompra in comprasLA)
                {
                    Central.Entities.Compras centralCompra = new Central.Entities.Compras();
                    centralCompra.Cantidad = LAcompra.Cantidad;
                    centralCompra.Compra_ID = 0;
                    centralCompra.CostoUnitario = LAcompra.CostoUnitario;
                    centralCompra.Fecha = LAcompra.FechaAlta;
                    centralCompra.MarcaRefaccion_ID = LAcompra.Marca;
                    centralCompra.OrdenCompra_ID = LAcompra.OrdenCompra;
                    centralCompra.Refaccion_ID = LAcompra.Refaccion;
                    centralCompra.RefaccionesSurtidas = (int)Central.DB.GetNullableInt32(LAcompra.RefSurtidas);
                    centralCompra.Usuario_ID = LAcompra.UsuarioAlta;
                    centralCompra.Empresa_ID = 4;
                    centralCompra.Estacion_ID = 1;

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

                    Console.WriteLine(String.Format("Registro actualizado Compra_ID {0}; OrdenCompra_ID: {1}", 
                        centralCompra.OrdenCompra_ID, centralCompra.Compra_ID));
                }
                
            }

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
                    List<LA.Entities.Compras> comprasLA = LA.Entities.Compras.Read(Param("OrdenCompra", ordencompra));

                    foreach (LA.Entities.Compras LAcompra in comprasLA)
                    {
                        Central.Entities.Compras centralCompra = new Central.Entities.Compras();
                        centralCompra.Cantidad = LAcompra.Cantidad;
                        centralCompra.Compra_ID = 0;
                        centralCompra.CostoUnitario = LAcompra.CostoUnitario;
                        centralCompra.Fecha = LAcompra.FechaAlta;
                        centralCompra.MarcaRefaccion_ID = LAcompra.Marca;
                        centralCompra.OrdenCompra_ID = LAcompra.OrdenCompra;
                        centralCompra.Refaccion_ID = LAcompra.Refaccion;
                        centralCompra.RefaccionesSurtidas = (int)Central.DB.GetNullableInt32(LAcompra.RefSurtidas);
                        centralCompra.Usuario_ID = LAcompra.UsuarioAlta;
                        centralCompra.Empresa_ID = 4;
                        centralCompra.Estacion_ID = 1;

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

                LA.Entities.Concesiones ConcesionesLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.Concesiones.Read(out ConcesionesLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConcesionesLA.Folio;

                    Central.Entities.Concesiones centralConcesion = new Central.Entities.Concesiones();
                    centralConcesion.Activo = (ConcesionesLA.Status == 1) ? true : false;
                    
                    centralConcesion.Empresa_ID = (int)((ConcesionesLA.EmpresaConcesionaria==null) ? 1 : ConcesionesLA.EmpresaConcesionaria); // CAM
                    centralConcesion.NumeroConcesion = ConcesionesLA.NumeroConcesion;
                    centralConcesion.Placa = ConcesionesLA.Placa;
                    centralConcesion.Referencia_ID = ConcesionesLA.Folio;
                    centralConcesion.TipoConcesion_ID = ConcesionesLA.Tipo;
                    centralConcesion.EstacionReferencia_ID = Estacion;

                    if (Central.DB.Exists("Concesiones",
                            Param("NumeroConcesion", centralConcesion.NumeroConcesion),
                                Param("Placa", centralConcesion.Placa),
                                    Param("Referencia_ID", centralConcesion.Referencia_ID),
                                        Param("EstacionReferencia_ID", Estacion)))
                    {
                        //  Consulta la concesion_ID
                        centralConcesion.Concesion_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Concesiones", "Concesion_ID",
                                Param("NumeroConcesion", centralConcesion.NumeroConcesion),
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

                LA.Entities.Conductores ConductoresLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.Conductores.Read(out ConductoresLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConductoresLA.Folio;

                    Central.Entities.Conductores centralConductor = new Central.Entities.Conductores();
                    centralConductor.ActaNacimiento = (ConductoresLA.DocumentacionConductor==null) ? "" : ConductoresLA.DocumentacionConductor.ActaNacimiento;
                    centralConductor.AñosExperiencia = (ConductoresLA.RegistroPublicitarioConductor == null) ? null : (Int32?)(AppHelper.IsNull(ConductoresLA.RegistroPublicitarioConductor.AñosExperiencia, 0));
                    centralConductor.Apellidos = ConductoresLA.ApellidoPaterno + " " + ConductoresLA.ApellidoMaterno;
                    centralConductor.Apellidos_Aval = (ConductoresLA.AvalConductor==null) ? "" : ConductoresLA.AvalConductor.ApellidoPaterno + " " + ConductoresLA.AvalConductor.ApellidoMaterno;
                    centralConductor.BloquearConductor = (ConductoresLA.Detalle == null) ? false : ConductoresLA.Detalle.BloquearConductor;
                    centralConductor.CartaNoAntecedentes = (ConductoresLA.DocumentacionConductor==null) ? "" :ConductoresLA.DocumentacionConductor.CartaNoAntecedentes;
                    centralConductor.Ciudad = ConductoresLA.Ciudad;
                    centralConductor.Ciudad_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Ciudad;
                    centralConductor.CodigoPostal = ConductoresLA.CP.ToString();
                    centralConductor.CodigoPostal_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.CP.ToString();
                    centralConductor.Comentarios = (ConductoresLA.RegistroPublicitarioConductor == null) ? "" :  ConductoresLA.RegistroPublicitarioConductor.Comentarios;
                    centralConductor.ComprobanteDomicilio = (ConductoresLA.DocumentacionConductor == null) ? "" : ConductoresLA.DocumentacionConductor.ComprobanteDomicilio;
                    centralConductor.ComprobanteDomicilio_Aval = (ConductoresLA.DocumentacionConductor == null) ? "" : ConductoresLA.DocumentacionConductor.ComprobanteDomicilioAval;
                    centralConductor.Conductor_ID = 0;
                    centralConductor.CredencialElector = (ConductoresLA.DocumentacionConductor == null) ? "" : ConductoresLA.DocumentacionConductor.CredencialElector;
                    centralConductor.CredencialElector_Aval = (ConductoresLA.DocumentacionConductor == null) ? "" : ConductoresLA.DocumentacionConductor.CredencialElectorAval;
                    centralConductor.Cronocasco = (ConductoresLA.Detalle == null) ? false : ConductoresLA.Detalle.Cronocasco;
                    centralConductor.CumplioPerfil = (ConductoresLA.RegistroPublicitarioConductor == null) ? false : ConductoresLA.RegistroPublicitarioConductor.CumplioPerfil;
                    centralConductor.CURP = ConductoresLA.Curp;
                    centralConductor.Curp_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Curp;
                    centralConductor.Domicilio = ConductoresLA.Calle + " No. " + ConductoresLA.NumeroCasa + ", Col. " + ConductoresLA.Colonia;
                    centralConductor.Domicilio_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Calle + " No. " + ConductoresLA.AvalConductor.NumeroCasa + ", Col. " + ConductoresLA.AvalConductor.Colonia;
                    centralConductor.Edad = (ConductoresLA.RegistroPublicitarioConductor == null) ? null : (int?)(AppHelper.IsNull(ConductoresLA.RegistroPublicitarioConductor.Edad, 0));
                    centralConductor.Email = ConductoresLA.CorreoElectronico;
                    centralConductor.Email_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.CorreoElectronico;
                    centralConductor.Entidad = ConductoresLA.Estado;
                    centralConductor.Estacion_ID = this.Estacion; // LA
                    centralConductor.Estado_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Estado;
                    centralConductor.EstadoCivil = (ConductoresLA.RegistroPublicitarioConductor == null) ? "" : ConductoresLA.RegistroPublicitarioConductor.EstadoCivil;
                    centralConductor.EstatusConductor_ID = (ConductoresLA.Status==1) ? 1 : ConductoresLA.Status + 4; // Convertir
                    centralConductor.Fecha = ConductoresLA.FechaAlta;
                    centralConductor.FolioLicencia = (ConductoresLA.Licencia == null) ? "" : ConductoresLA.Licencia.Folio.ToString();
                    centralConductor.Fotografia = null; //    Esta no se lleva    // Hay que actualizar el proceso de creación y actualización
                    centralConductor.Genero = "M";
                    centralConductor.Interesado = (ConductoresLA.RegistroPublicitarioConductor == null) ? false : ConductoresLA.RegistroPublicitarioConductor.Interesado;
                    centralConductor.MedioPublicitario_ID = (ConductoresLA.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresLA.RegistroPublicitarioConductor.MedioPublicitario;
                    centralConductor.MensajeACaja = (ConductoresLA.Detalle == null) ? "" : ConductoresLA.Detalle.MensajeACaja;
                    centralConductor.Mercado_ID = (ConductoresLA.RegistroPublicitarioConductor == null) ? null : (int?)ConductoresLA.RegistroPublicitarioConductor.PlanEmpresarial; // Hay que hacer el mapeo correcto
                    centralConductor.Movil = null;
                    centralConductor.Nombre = ConductoresLA.Nombre;
                    centralConductor.Nombre_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Nombre;
                    centralConductor.Referencia_ID = ConductoresLA.Folio;
                    centralConductor.RFC = ConductoresLA.Rfc;
                    centralConductor.Rfc_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Rfc;
                    centralConductor.SaldoATratar = (ConductoresLA.Detalle == null) ? 0 : ConductoresLA.Detalle.SaldoATratar;
                    centralConductor.Solicitud = (ConductoresLA.DocumentacionConductor == null) ? "" : ConductoresLA.DocumentacionConductor.Solicitud;
                    centralConductor.Telefono = ConductoresLA.Telefono;
                    centralConductor.Telefono_Aval = (ConductoresLA.AvalConductor == null) ? "" : ConductoresLA.AvalConductor.Telefono;
                    centralConductor.Telefono2 = null;
                    centralConductor.TerminalDatos = (ConductoresLA.Detalle == null) ? false : ConductoresLA.Detalle.TerminalDatos;
                    centralConductor.TipoLicencia_ID = (ConductoresLA.Licencia == null) ? null : (int?)ConductoresLA.Licencia.Tipo; // Revisar si entra directo
                    ConductoresLA.UsuarioAlta = ConductoresLA.UsuarioAlta.Replace("Ã±", "ñ");
                    //ConductoresLA.UsuarioAlta = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(ConductoresLA.UsuarioAlta));
                    centralConductor.Usuario_ID = ConductoresLA.UsuarioAlta;
                    centralConductor.VenceLicencia = (ConductoresLA.Licencia == null) ? null : (DateTime?)ConductoresLA.Licencia.FechaVencimiento;

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
                
                //List<LA.Entities.Conductores> conductoresLA = LA.Entities.Conductores.Read();

                //foreach (LA.Entities.Conductores LAconductor in conductoresLA)
                //{
                    
                //}   //  End foreach
            }   //  End Method

            public void SyncDetalleConductores()
            {
                //string filter = "Conductor > @Conductor AND MensajeACaja IS NOT NULL";

                //string sort = "Conductor ASC";

                //LA.Entities.DetalleConductor ConductoresLA;
                Console.WriteLine("Leyendo detalle conductores");
                int folio = 0;

                int count = LA.DB.GetCount("DetalleConductor");
                int cont = 0;

                List<LA.Entities.DetalleConductor> DetallesConductor = LA.Entities.DetalleConductor.Read();
                foreach (LA.Entities.DetalleConductor ConductoresLA in DetallesConductor)
                {
                    cont++;
                    folio = ConductoresLA.Conductor;

                    Central.Entities.Conductores centralConductor =
                        Central.Entities.Conductores.Read(
                        Param("Referencia_ID", folio),
                        Param("Estacion_ID", Estacion));

                    if (centralConductor == null) break;

                    centralConductor.BloquearConductor = ConductoresLA.BloquearConductor;
                    centralConductor.Cronocasco = ConductoresLA.Cronocasco;
                    centralConductor.MensajeACaja = ConductoresLA.MensajeACaja;
                    centralConductor.SaldoATratar = ConductoresLA.SaldoATratar;
                    centralConductor.TerminalDatos = ConductoresLA.TerminalDatos;
                    centralConductor.Update();

                    Console.WriteLine(String.Format("Registro actualizado DetalleConductor_ID: {0}, {1} de {2}",
                        centralConductor.Referencia_ID, cont, count));
                }

                //while (LA.Entities.DetalleConductor.Read(out ConductoresLA, 1, filter, sort, Param("Conductor", folio)))
                //{
                    
                //}

            }   //  End Method

            //  Actualizar contratos
            public void SyncUpdateContratos()
            {
                Console.WriteLine("Update Contratos");

                List<LA.Entities.Contratos> ContratosLA;
                ContratosLA = LA.Entities.Contratos.Read();
                //ContratosLA = new List<LA.Entities.Contratos>();
                //ContratosLA.Add(LA.Entities.Contratos.Read(3453));

                foreach (LA.Entities.Contratos contrato in ContratosLA)
                {
                    Central.Entities.Contratos c = 
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion), 
                        Param("Referencia_ID", contrato.Folio));

                    c.FechaFinal = contrato.FechaFinal;
                    c.MontoDiario = contrato.Planes.RentaBase;
                    c.EstatusContrato_ID = (contrato.Status == 1) ? 1 : contrato.Status + 7;
                    c.Update("FechaFinal", "EstatusContrato_ID", "MontoDiario");
                    Console.WriteLine(string.Format("Actualizado contrato {0}:",contrato.Folio));
                }
            }

            //  Contratos
            public void SyncContratos()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Contratos WHERE Estacion_ID = @Estacion";

                LA.Entities.Contratos ContratosLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                //folio = 0;                

                while (LA.Entities.Contratos.Read(out ContratosLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ContratosLA.Folio;

                    Central.Entities.Contratos centralContrato = new Central.Entities.Contratos();
                    centralContrato.CobroPermanente = (ContratosLA.FechaFinal == null) ? true : false;
                    centralContrato.Comentarios = "";
                    centralContrato.Concepto_ID = 1;
                    centralContrato.Conductor_ID = Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", ContratosLA.Conductor)).Conductor_ID;

                    // Si no existe el conductor copia, insertarlo y relacionarlo
                    if (ContratosLA.Copia == null)
                    {
                        centralContrato.ConductorCopia_ID = null;
                    }
                    else
                    {
                        Central.Entities.Conductores cond = Central.Entities.Conductores.Read(Param("Rfc", ContratosLA.Copia.Rfc));
                        if (cond == null)
                        {
                            //  Insertar conductor en Central
                            //  a partir de contratos copia
                            cond = new Central.Entities.Conductores();
                            cond.Apellidos = ContratosLA.Copia.ApellidoPaterno + " " + ContratosLA.Copia.ApellidoMaterno;
                            cond.Domicilio = ContratosLA.Copia.Colonia + ", " + ContratosLA.Copia.Calle + " No. " + ContratosLA.Copia.NumeroCasa;
                            cond.Ciudad = ContratosLA.Copia.Ciudad;
                            cond.Email = ContratosLA.Copia.CorreoElectronico;
                            cond.CodigoPostal = ContratosLA.Copia.CP.ToString();
                            cond.CURP = ContratosLA.Copia.Curp;
                            cond.Entidad = ContratosLA.Copia.Estado;
                            cond.Fecha = ContratosLA.Copia.FechaAlta;
                            cond.Nombre = ContratosLA.Copia.Nombre;
                            cond.RFC = ContratosLA.Copia.Rfc;
                            cond.Telefono = ContratosLA.Copia.Telefono;
                            cond.Usuario_ID = ContratosLA.Copia.UsuarioAlta;
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
                    centralContrato.Descripcion = "Contrato de renta folio " + ContratosLA.Folio.ToString();

                    //  Obtener los días de cobro
                    centralContrato.DiasDeCobro_ID = (int)ContratosLA.Planes.DiasDeCobro;

                    if (ContratosLA.Tipo == 3)
                    {
                        centralContrato.Empresa_ID = 5; // CCR
                    }
                    else
                    {
                        centralContrato.Empresa_ID = Empresa; // CAM
                    }
                    centralContrato.Estacion_ID = Estacion;
                    centralContrato.EstatusContrato_ID = (ContratosLA.Status == 1) ? 1 : ContratosLA.Status + 7;
                    centralContrato.FechaFinal = Central.DB.GetNullableDateTime(ContratosLA.FechaFinal);
                    centralContrato.FechaInicial = ContratosLA.FechaInicial;
                    centralContrato.FondoResidual = Convert.ToInt32(AppHelper.IsNull(ContratosLA.Planes.FondoResidual, 0));
                    centralContrato.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(Param("Referencia_id", (int)ContratosLA.Planes.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralContrato.MontoDiario = ContratosLA.Planes.RentaBase;
                    centralContrato.NumeroEconomico =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosLA.Unidad)).NumeroEconomico;
                    centralContrato.TipoContrato_ID = (ContratosLA.Tipo == 3) ? 2 : ContratosLA.Tipo; // Si 3 entonces es CCR
                    centralContrato.Unidad_ID = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosLA.Unidad)).Unidad_ID;
                    centralContrato.Referencia_ID = folio;
                    if (Central.DB.Exists("Contratos", Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosLA.Folio)))
                    {
                        //  Obtener el contrato ID
                        centralContrato.Contrato_ID =
                            Convert.ToInt32(Central.DB.ReadScalar("Contratos", "Contrato_ID",
                                Param("Estacion_ID", this.Estacion), Param("Referencia_ID", ContratosLA.Folio)));
                        centralContrato.Update();
                    }
                    else
                    {
                        centralContrato.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Contrato_ID: {0}", centralContrato.Contrato_ID));
                }

            }   //  End Method

            //  Contratos Liquidados
            public void SyncContratosLiquidados()
            {
                Console.WriteLine("Leyendo contratos liquidados");
                List<LA.Entities.ContratosLiquidados> contratosliquidadosLA = LA.Entities.ContratosLiquidados.Read();
                foreach (LA.Entities.ContratosLiquidados ContratosLiquidadosLA in contratosliquidadosLA)
                {
                    Central.Entities.ContratosLiquidados centralContratosLiquidados = new Central.Entities.ContratosLiquidados();
                    centralContratosLiquidados.ContratoLiquidado_ID = ContratosLiquidadosLA.Folio;
                    
                    centralContratosLiquidados.Contrato_ID = 
                        Central.Entities.Contratos.Read(
                        Param("Estacion_ID", Estacion), 
                        Param("Referencia_ID", ContratosLiquidadosLA.Contrato)
                        ).Contrato_ID; // Consultar contrato

                    Central.Entities.Conductores cond = Central.Entities.Conductores.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosLA.Conductor)
                        );

                    if (cond == null) break;

                    centralContratosLiquidados.Conductor_ID = 
                        cond.Conductor_ID;

                    Central.Entities.Unidades uni = Central.Entities.Unidades.Read(
                        Param("Estacion_ID", Estacion),
                        Param("Referencia_ID", ContratosLiquidadosLA.Unidad)
                        );

                    if (uni == null) break;

                    centralContratosLiquidados.Unidad_ID =
                        uni.Unidad_ID;

                    centralContratosLiquidados.LocacionUnidad_ID = LocacionCentral(ContratosLiquidadosLA.LocacionUnidad);

                    centralContratosLiquidados.EstatusConductor_ID = 
                        (ContratosLiquidadosLA.StatusConductor == 1) ? 1 : ContratosLiquidadosLA.StatusConductor + 4;

                    centralContratosLiquidados.EstatusContrato_ID = 
                        (ContratosLiquidadosLA.StatusContrato == 1) ? 1 : ContratosLiquidadosLA.StatusContrato + 7;
                    
                    centralContratosLiquidados.Comentarios = ContratosLiquidadosLA.Comentario; 
                    centralContratosLiquidados.Fecha = ContratosLiquidadosLA.Fecha;
                    centralContratosLiquidados.Usuario_ID = ContratosLiquidadosLA.Usuario.Trim();


                    if (Central.DB.Exists("ContratosLiquidados", Param("ContratoLiquidado_ID", centralContratosLiquidados.ContratoLiquidado_ID)))
                    {
                        centralContratosLiquidados.Update();
                    }
                    else
                    {
                        centralContratosLiquidados.Create();
                    }

                    Console.WriteLine(string.Format("Actualizado contrato liquidado {0}",ContratosLiquidadosLA.Folio));
                }	//	End foreach

            }	//	End Method SyncContratosLiquidados

            //  Usuarios
            public void SyncUsuarios()
            {
                List<LA.Entities.Usuarios> usuariosLA = LA.Entities.Usuarios.Read();
                foreach (LA.Entities.Usuarios usuarioLA in usuariosLA)
                {
                    Central.Entities.Usuarios usuario = new Central.Entities.Usuarios();
                    usuario.Activo = (usuarioLA.Status == 1) ? true : false;
                    usuario.Apellidos = usuarioLA.ApellidoPaterno + " " + usuarioLA.ApellidoMaterno;
                    usuario.Email = "";
                    usuario.Empresa_ID = Empresa; // CAM
                    usuario.Estacion_ID = Estacion; // LA
                    usuario.Nombre = usuarioLA.Nombre;
                    usuario.pwd = (byte[])Central.DB.QueryScalar(String.Format("SELECT PWDENCRYPT('{0}')", usuarioLA.Pwd));
                    usuario.Usuario_ID = usuarioLA.Clave;

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
                    case 1: empresa  = 2; break;
                    case 2: empresa  = 2; break;
                    case 3: empresa  = 2; break;
                    case 5: empresa  = 4; break;
                    case 11: empresa  = 6; break;
                    case 12: empresa  = 2; break;
                    case 13: empresa  = 2; break;
                    case 14: empresa  = 5; break;
                    case 15: empresa  = 6; break;
                    case 16: empresa  = 2; break;
                }

                return empresa;
            }

            //  CuentaCajas
            public void SyncCuentaCajas()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaCajas WHERE Estacion_ID = @Estacion";

                LA.Entities.MovimientosCaja CuentaCajasLA;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                maxfolio = Convert.ToInt32(LA.DB.QueryScalar("SELECT MAX(Folio) MaxFolio FROM MovimientosCaja"));

                while (LA.Entities.MovimientosCaja.Read(out CuentaCajasLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaCajasLA.Folio;

                    Central.Entities.CuentaCajas centralCuentaCajas = new Central.Entities.CuentaCajas();
                    centralCuentaCajas.Referencia_ID = CuentaCajasLA.Folio;
                    centralCuentaCajas.CuentaCaja_ID = 0;
                    centralCuentaCajas.Sesion_ID = Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasLA.Sesion),
                        Param("Estacion_ID", Estacion)).Sesion_ID; // Verificar correspondencia

                    //  La empresa tambien depende del fondo
                    centralCuentaCajas.Empresa_ID = EmpresaDeFondo(CuentaCajasLA.Fondo);

                    centralCuentaCajas.Estacion_ID = Estacion;
                    centralCuentaCajas.Caja_ID = (int)Central.Entities.Sesiones.Read(Param("Referencia_ID", CuentaCajasLA.Sesion),
                        Param("Estacion_ID", Estacion)).Caja_ID; // Se obtiene de la sesion
                    
                    centralCuentaCajas.Ticket_ID = null;    //  No esta supeditada a un ticket
                    
                    centralCuentaCajas.Cuenta_ID = CuentaDeFondo(CuentaCajasLA.Fondo); // De este dato obtener la cuenta
                    
                    centralCuentaCajas.Concepto_ID = null; // No se lleva concepto

                    decimal abono, cargo;
                    if (CuentaCajasLA.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaCajasLA.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaCajasLA.Monto);
                    }

                    centralCuentaCajas.Cargo = cargo; // De este dato depende
                    centralCuentaCajas.Abono = abono;
                    centralCuentaCajas.Saldo = 0; // Es calculado, meter dentro del create
                    centralCuentaCajas.Comentarios = "";
                    centralCuentaCajas.Fecha = CuentaCajasLA.Fecha;
                    centralCuentaCajas.Usuario_ID = CuentaCajasLA.Usuario;

                    if (Central.DB.Exists("CuentaCajas", Param("Referencia_ID", centralCuentaCajas.Referencia_ID),
                            Param("Estacion_ID",Estacion)))
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
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = @"SELECT ISNULL(MAX(Referencia_ID),0) folio 
FROM CuentaConductores 
WHERE Estacion_ID IN (1,2,3,4,6,7)
AND Fecha <= '2011-11-07'";
                
                LA.Entities.CuentaConductor CuentaConductoresLA;
                int folio, maxticket;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));
                maxticket = Convert.ToInt32(
                    Central.DB.QueryScalar(
                        "SELECT ISNULL(MAX(Referencia_ID),0) maxticket FROM Tickets WHERE Estacion_ID IN (1,2,3,4,6,7)"));

                while (LA.Entities.CuentaConductor.Read(out CuentaConductoresLA, 1, filter, sort, Param("Folio", folio)))
                {                    
                    folio = CuentaConductoresLA.Folio;
                    
                    Central.Entities.CuentaConductores centralCuentaConductores = new Central.Entities.CuentaConductores();
                    centralCuentaConductores.Referencia_ID = folio;
                    centralCuentaConductores.CuentaConductor_ID = 0;

                    //Obtener segun concepto
                    //Del concepto obtener la cuenta
                    int cuenta = LA.Entities.Conceptos.Read(CuentaConductoresLA.Concepto).Cuenta;
                    int fondo = LA.Entities.Cuentas.Read(cuenta).FondoCaja;
                    //De la cuenta, obtener el fondo
                    //Del fondo, la empresa.
                    centralCuentaConductores.Empresa_ID = EmpresaDeFondo(fondo);

                    centralCuentaConductores.Estacion_ID = Estacion; // LA

                    if (CuentaConductoresLA.Unidad == 0)
                    {
                        centralCuentaConductores.Unidad_ID = null;
                    }
                    else
                    {
                        centralCuentaConductores.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresLA.Unidad)).Unidad_ID;
                    }
                    
                    centralCuentaConductores.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", CuentaConductoresLA.Conductor)).Conductor_ID;

                    // Verificar la caja para obtener la estación
                    if (CuentaConductoresLA.Caja == null)
                    {
                        centralCuentaConductores.Caja_ID = null;
                    }
                    else
                    {
                        if (CuentaConductoresLA.Caja == 1 || CuentaConductoresLA.Caja == 9)
                        {
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", CuentaConductoresLA.Caja)).Caja_ID;
                        }
                        else
                        {
                            centralCuentaConductores.Estacion_ID = CuentaConductoresLA.Caja; // Otra estacion
                            centralCuentaConductores.Caja_ID =
                            Central.Entities.Cajas.Read(Param("Estacion_ID", CuentaConductoresLA.Caja), Param("Referencia_ID", CuentaConductoresLA.Caja)).Caja_ID;
                        }
                    }                                        

                    //  Es posible que se pueda hacer referencia
                    //  Si folio tiene ticket local, buscar su ticket remoto
                    if (LA.DB.Exists("RecibosMovimientos", Param("Movimiento", CuentaConductoresLA.Folio)))
                    {
                        int recibo = (int)LA.Entities.RecibosMovimientos.Read(Param("Movimiento", CuentaConductoresLA.Folio)).Recibo;
                        if (recibo > maxticket) return; // No hay ticket remoto, no ha sido cargado

                        int ticket_id = Central.Entities.Tickets.Read(Param("Referencia_ID", recibo), Param("Estacion_ID", Estacion)).Ticket_ID;
                        centralCuentaConductores.Ticket_ID = ticket_id;
                    }
                    else
                    {
                        centralCuentaConductores.Ticket_ID = null; // Ticket a null
                    }  

                    centralCuentaConductores.Cuenta_ID = CuentaDeCuenta(cuenta);
                    centralCuentaConductores.Concepto_ID = ConceptoCentral(CuentaConductoresLA.Concepto);

                    decimal abono, cargo;
                    if (CuentaConductoresLA.Monto < 0)
                    {
                        abono = 0;
                        cargo = Math.Abs(CuentaConductoresLA.Monto);
                    }
                    else
                    {
                        cargo = 0;
                        abono = Math.Abs(CuentaConductoresLA.Monto);
                    }

                    centralCuentaConductores.Cargo = cargo;
                    centralCuentaConductores.Abono = abono;
                    centralCuentaConductores.Saldo = 0; // Calculado
                    centralCuentaConductores.Comentarios = CuentaConductoresLA.Comentarios;
                    centralCuentaConductores.Fecha = CuentaConductoresLA.FechaAlta;
                    centralCuentaConductores.Usuario_ID = CuentaConductoresLA.UsuarioAlta;

                    if (Central.DB.Exists("CuentaConductores", 
                        Param("Referencia_ID", centralCuentaConductores.Referencia_ID),
                        Param("Estacion_ID", Estacion)))
                    {
                        //  Actualizar
                        centralCuentaConductores.Update();
                    }
                    else
                    {
                        centralCuentaConductores.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado CuentaConductor_ID: {0}, fecha {1:yyyy-MM-dd}",
                        centralCuentaConductores.Referencia_ID,
                        centralCuentaConductores.Fecha));

                }
            }	//	End Method SyncCuentaConductores

            public void SyncFamilias()
            {    
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Familia_ID),0) folio FROM Familias";

                LA.Entities.Familias FamiliasLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.Familias.Read(out FamiliasLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = FamiliasLA.Folio;
                    
                    Central.Entities.Familias centralFamilias = new Central.Entities.Familias();
                    centralFamilias.Familia_ID = FamiliasLA.Folio;
                    centralFamilias.Nombre = FamiliasLA.Descripcion;


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
                List<LA.Entities.MarcasRefacciones> marcasrefaccionesLA = 
                    LA.Entities.MarcasRefacciones.Read();
                foreach (LA.Entities.MarcasRefacciones MarcasRefaccionesLA in marcasrefaccionesLA)
                {
                    Central.Entities.MarcasRefacciones centralMarcasRefacciones = new Central.Entities.MarcasRefacciones();
                    centralMarcasRefacciones.MarcaRefaccion_ID = MarcasRefaccionesLA.Folio;
                    centralMarcasRefacciones.Nombre = MarcasRefaccionesLA.Descripcion;

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
                List<LA.Entities.StatusMecanicos> estatusmecanicosLA = LA.Entities.StatusMecanicos.Read();
                foreach (LA.Entities.StatusMecanicos EstatusMecanicosLA in estatusmecanicosLA)
                {
                    Central.Entities.EstatusMecanicos centralEstatusMecanicos = new Central.Entities.EstatusMecanicos();
                    centralEstatusMecanicos.EstatusMecanico_ID = EstatusMecanicosLA.Folio;
                    centralEstatusMecanicos.Nombre = EstatusMecanicosLA.Descripcion;


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
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Mecanico_ID),0) folio FROM Mecanicos";

                LA.Entities.Mecanicos MecanicosLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.Mecanicos.Read(out MecanicosLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = MecanicosLA.Folio;
                
                    Central.Entities.Mecanicos centralMecanicos = new Central.Entities.Mecanicos();
                    centralMecanicos.Mecanico_ID = MecanicosLA.Folio;
                    centralMecanicos.CategoriaMecanico_ID = MecanicosLA.Categoria;
                    centralMecanicos.EstatusMecanico_ID = MecanicosLA.Status;
                    centralMecanicos.Usuario_ID = MecanicosLA.UsuarioAlta;
                    centralMecanicos.Fecha = MecanicosLA.FechaAlta;
                    centralMecanicos.CodigoBarras = MecanicosLA.CodigoBarras;
                    centralMecanicos.Nombres = MecanicosLA.Nombre;
                    centralMecanicos.Apellidos = MecanicosLA.ApellidoPaterno +  " " + MecanicosLA.ApellidoMaterno;
                    centralMecanicos.Rfc = MecanicosLA.Rfc;
                    centralMecanicos.Curp = MecanicosLA.Curp;
                    centralMecanicos.NSS = MecanicosLA.NumeroSeguroSocial;
                    centralMecanicos.Domicilio = MecanicosLA.Calle + " No. " + MecanicosLA.Numero + ", Col. " + MecanicosLA.Colonia;
                    centralMecanicos.Ciudad = MecanicosLA.Ciudad;
                    centralMecanicos.Entidad = MecanicosLA.Estado;
                    centralMecanicos.CodigoPostal = MecanicosLA.CodigoPostal.ToString();
                    centralMecanicos.Telefono = MecanicosLA.Telefonos;
                    centralMecanicos.CorreoElectronico = MecanicosLA.CorreoElectronico;
                    centralMecanicos.SalarioDiario = MecanicosLA.SalarioDiario;
                    centralMecanicos.HorarioEntrada = MecanicosLA.HorarioEntrada;
                    centralMecanicos.HorarioSalida = MecanicosLA.HorarioSalida;
                    centralMecanicos.Empresa_ID = 4;
                    centralMecanicos.Estacion_ID = 1;


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
                List<LA.Entities.ModelosTaller> modelosLA = LA.Entities.ModelosTaller.Read();
                foreach (LA.Entities.ModelosTaller ModelosLA in modelosLA)
                {
                    Central.Entities.Modelos centralModelos = new Central.Entities.Modelos();
                    centralModelos.Modelo_ID = ModelosLA.Folio;
                    centralModelos.Nombre = ModelosLA.Descripcion;


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
                List<LA.Entities.Modelos> modelosunidadesLA = LA.Entities.Modelos.Read();
                foreach (LA.Entities.Modelos ModelosUnidadesLA in modelosunidadesLA)
                {
                    Central.Entities.ModelosUnidades centralModelosUnidades = new Central.Entities.ModelosUnidades();
                    centralModelosUnidades.ModeloUnidad_ID = 0;

                    centralModelosUnidades.MarcaUnidad_ID = 1; // Actualizar posteriormente
                    centralModelosUnidades.Descripcion = ModelosUnidadesLA.Descripcion;
                    centralModelosUnidades.PrecioLista = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesLA.PrecioLista, 0));
                    centralModelosUnidades.Anio = ModelosUnidadesLA.Año;
                    centralModelosUnidades.Deposito = Convert.ToDecimal(AppHelper.IsNull(ModelosUnidadesLA.Deposito, 0));
                    centralModelosUnidades.Activo = (ModelosUnidadesLA.Status == 1) ? true : false;
                    centralModelosUnidades.referencia_id = ModelosUnidadesLA.Folio;
                    centralModelosUnidades.EmpresaReferencia = Estacion; //    CAM

                    if (Central.DB.Exists(
                            "ModelosUnidades",
                            Param("Referencia_ID", ModelosUnidadesLA.Folio),
                            Param("EmpresaReferencia",Estacion)
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

                switch(tipo)
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
                string sqlQry = "SELECT ISNULL(MAX(Fecha),'') Fecha FROM MovimientosInventario";
                DateTime fecha;                
                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry));
                List<LA.Entities.HistorialInventario> Historial;

                List<DateTime> fechas = 
                    (List<DateTime>)LA.DB.QueryList<DateTime>(
                    "SELECT DISTINCT Fecha FROM HistorialInventario WHERE Fecha >= @Fecha", 
                    "Fecha", 
                    Param("@Fecha",fecha));

                int cont = fechas.Count;

                foreach (DateTime f in fechas)
                {
                    
                    Historial = LA.Entities.HistorialInventario.Read(Param("Fecha", f));

                    foreach (LA.Entities.HistorialInventario HistorialInventarioLA in Historial)
                    {                        
                        Central.Entities.MovimientosInventario centralMovimientosInventario = new Central.Entities.MovimientosInventario();                        
                        centralMovimientosInventario.MovimientoInventario_ID = 0;
                        int tipo = GetTipoMovimientoInventario(HistorialInventarioLA.Tipo);
                        centralMovimientosInventario.TipoMovimientoInventario_ID = tipo;

                        if (tipo == 2 || tipo == 4)
                        {
                            // Es orden de compra
                            //  Si no hay folio, ignorar
                            if (String.IsNullOrEmpty(HistorialInventarioLA.Folio))
                                continue;

                            //  Si no existe la compra, ignorar
                            if (
                                !Central.DB.Exists(
                                    "OrdenesCompras",
                                    Param("OrdenCompra_ID", HistorialInventarioLA.Folio)
                                )
                            )
                            {
                                continue;
                            }
                        }

                        if (tipo == 1 || tipo == 6)
                        {
                            // Es orden de trabajo
                            //  Si no hay folio, ignorar
                            if (String.IsNullOrEmpty(HistorialInventarioLA.Folio))
                                continue;

                            //  Si no existe la orden, ignorar
                            if (
                                !Central.DB.Exists(
                                    "OrdenesTrabajos",
                                    Param("OrdenTrabajo_ID", HistorialInventarioLA.Folio)
                                )
                            )
                            {
                                continue;
                            }
                        }

                        if (tipo == 3)
                        {
                            // Es ajuste de inventario
                            //  Si no hay folio, ignorar
                            if (String.IsNullOrEmpty(HistorialInventarioLA.Folio))
                                continue;

                            //  Si no existe el ajuste, ignorar
                            if (
                                !Central.DB.Exists(
                                    "AjustesInventario",
                                    Param("AjusteInventario_ID", HistorialInventarioLA.Folio)
                                )
                            )
                            {
                                continue;
                            }
                        }

                        centralMovimientosInventario.OrdenCompra_ID = 
                            (tipo == 2 || tipo == 4) ? Convert.ToInt32(HistorialInventarioLA.Folio) : Central.DB.GetNullableInt32(null);
                        centralMovimientosInventario.OrdenTrabajo_ID = 
                            (tipo == 1 || tipo == 6) ? Convert.ToInt32(HistorialInventarioLA.Folio) : Central.DB.GetNullableInt32(null);
                        centralMovimientosInventario.NotaAlmacen_ID = HistorialInventarioLA.NotaAlmacen;
                        centralMovimientosInventario.AjusteInventario_ID = 
                            (tipo == 3) ? Convert.ToInt32(HistorialInventarioLA.Folio) : Central.DB.GetNullableInt32(null);
                        centralMovimientosInventario.Usuario_ID = HistorialInventarioLA.Usuario;
                        centralMovimientosInventario.Refaccion_ID = HistorialInventarioLA.Refaccion;
                        centralMovimientosInventario.Fecha = HistorialInventarioLA.Fecha;
                        centralMovimientosInventario.Cantidad = Convert.ToInt32(HistorialInventarioLA.Cantidad);
                        centralMovimientosInventario.CostoUnitario = HistorialInventarioLA.CostoUnitario;
                        centralMovimientosInventario.Valor = HistorialInventarioLA.Valor;
                        centralMovimientosInventario.CantidadPrev = Convert.ToInt32(HistorialInventarioLA.CantidadPrev);
                        centralMovimientosInventario.ValorPrev = HistorialInventarioLA.ValorPrev;
                        centralMovimientosInventario.CantidadPost = Convert.ToInt32(HistorialInventarioLA.CantidadPost);
                        centralMovimientosInventario.ValorPost = HistorialInventarioLA.ValorPost;
                        centralMovimientosInventario.CantidadPrevProm = 0; // Por calcular
                        centralMovimientosInventario.ValorPrevProm = 0; // Por calcular
                        centralMovimientosInventario.CantidadPostProm = 0; // Por calcular
                        centralMovimientosInventario.ValorPostProm = 0; // Por calcular
                        centralMovimientosInventario.Referencia = HistorialInventarioLA.Movimiento;
                        centralMovimientosInventario.CostoUnitarioProm = 0; // Por calcular
                        centralMovimientosInventario.Empresa_ID = 4;
                        centralMovimientosInventario.Estacion_ID = 1;
                        if (Central.DB.Exists("MovimientosInventario", Param("Referencia", centralMovimientosInventario.Referencia)))
                        {
                            //  Get
                            centralMovimientosInventario.Update();
                        }
                        else
                        {
                            centralMovimientosInventario.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado MovimientoInventario_ID: {0}", 
                            centralMovimientosInventario.Referencia));
                    }	//	End foreach
                }	//	End foreach

            }	//	End Method SyncMovimientosInventario

            public void SyncNotasAlmacen()
            {
                string filter = "NotaAlmacenID > @Folio";

                string sort = "NotaAlmacenID ASC";

                string sqlQry = "SELECT ISNULL(MAX(NotaAlmacen_ID),0) folio FROM NotasAlmacen";

                LA.Entities.NotasAlmacen NotasAlmacenLA;
                int folio, maxfolio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                maxfolio = Convert.ToInt32(
                    LA.DB.QueryScalar("SELECT ISNULL(MAX(NotaAlmacenID),0) maxfolio FROM NotasAlmacen"));


                while (LA.Entities.NotasAlmacen.Read(out NotasAlmacenLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = NotasAlmacenLA.NotaAlmacenID;
                    if (NotasAlmacenLA.OrdenCompra != null && NotasAlmacenLA.OrdenCompra == 0) continue;
                    if (NotasAlmacenLA.OrdenTrabajo != null && NotasAlmacenLA.OrdenTrabajo == 0) continue;

                    if (!AppHelper.IsNullOrEmpty(NotasAlmacenLA.OrdenTrabajo))
                    {
                        if (!Central.DB.Exists("OrdenesTrabajos", Param("OrdenTrabajo_ID", NotasAlmacenLA.OrdenTrabajo)))
                        {
                            continue;
                        }
                    }

                    if (!AppHelper.IsNullOrEmpty(NotasAlmacenLA.OrdenCompra))
                    {
                        if (!Central.DB.Exists("OrdenesCompras", Param("OrdenCompra_ID", NotasAlmacenLA.OrdenCompra)))
                        {
                            continue;
                        }
                    }                    

                    Central.Entities.NotasAlmacen centralNotasAlmacen = new Central.Entities.NotasAlmacen();
                    centralNotasAlmacen.NotaAlmacen_ID = NotasAlmacenLA.NotaAlmacenID;
                    centralNotasAlmacen.Usuario_ID = NotasAlmacenLA.Usuario;
                    centralNotasAlmacen.TipoMovimientoInventario_ID = (NotasAlmacenLA.Tipo == "ENTRADA") ? 1 : 2;
                    centralNotasAlmacen.OrdenCompra_ID = NotasAlmacenLA.OrdenCompra;
                    centralNotasAlmacen.OrdenTrabajo_ID = NotasAlmacenLA.OrdenTrabajo;
                    centralNotasAlmacen.Fecha = NotasAlmacenLA.Fecha;
                    centralNotasAlmacen.Empresa_ID = 4;
                    centralNotasAlmacen.Estacion_ID = 1;

                    if (Central.DB.Exists("NotasAlmacen", Param("NotaAlmacen_ID", centralNotasAlmacen.NotaAlmacen_ID)))
                    {
                        centralNotasAlmacen.Update();
                    }
                    else
                    {
                        centralNotasAlmacen.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado NotaAlmacen_ID: {0} de {1}", 
                        centralNotasAlmacen.NotaAlmacen_ID, maxfolio));

                }	//	End foreach

            }	//	End Method SyncNotasAlmacen

            public void SyncProveedores()
            {
                string filter = "RFC > @RFC";

                string sort = "RFC ASC";

                string sqlQry = "SELECT ISNULL(MAX(RFC),'') RFC FROM Empresas WHERE TipoEmpresa_ID = 4";

                LA.Entities.Proveedores ProveedoresLA;
                string RFC;

                RFC = Convert.ToString(Central.DB.QueryScalar(sqlQry));
                RFC = "";

                while (LA.Entities.Proveedores.Read(out ProveedoresLA, 1, filter, sort, Param("RFC", RFC)))
                {
                    RFC = ProveedoresLA.Rfc;

                    Central.Entities.Empresas centralEmpresas = new Central.Entities.Empresas();
                    centralEmpresas.Activo = (ProveedoresLA.Status == 1) ? true : false;
                    centralEmpresas.Ciudad = ProveedoresLA.Ciudad;
                    centralEmpresas.CodigoPostal = ProveedoresLA.CodigoPostal.ToString();
                    centralEmpresas.Domicilio = ProveedoresLA.Calle + " " + ProveedoresLA.Numero + " " + ProveedoresLA.Colonia;
                    centralEmpresas.Email = ProveedoresLA.CorreoElectronico;                    
                    centralEmpresas.Estado = ProveedoresLA.Estado;
                    centralEmpresas.Mercado_ID = null;
                    centralEmpresas.Movil = null;
                    centralEmpresas.Nombre = Strings.Left(ProveedoresLA.RazonSocial,50);
                    centralEmpresas.RazonSocial = ProveedoresLA.RazonSocial;
                    centralEmpresas.RepresentanteLegal = null;
                    centralEmpresas.RFC = RFC;
                    centralEmpresas.Telefono1 = ProveedoresLA.Telefonos;
                    centralEmpresas.Telefono2 = null;
                    centralEmpresas.TipoEmpresa_ID = 4;
                    

                    if (Central.DB.Exists("Empresas", Param("RFC", RFC)))
                    {
                        centralEmpresas.Update();
                    }
                    else
                    {
                        centralEmpresas.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Empresa: {0}", ProveedoresLA.RazonSocial));
                }
            }

            public void SyncOrdenesCompras()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenCompra_ID),0) folio FROM OrdenesCompras";

                LA.Entities.OrdenesCompras OrdenesComprasLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.OrdenesCompras.Read(out OrdenesComprasLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesComprasLA.Folio;

                    Central.Entities.OrdenesCompras centralOrdenesCompras = new Central.Entities.OrdenesCompras();
                    centralOrdenesCompras.OrdenCompra_ID = OrdenesComprasLA.Folio;

                    //  Obtener el proveedor
                    //  Los proveedores deben estar datos de alta en el sistema previamente
                    //  buscar por rfc
                    int proveedor = Central.Entities.Empresas.Read(Param("Rfc", OrdenesComprasLA.Proveedores.Rfc))[0].Empresa_ID;
                    centralOrdenesCompras.Proveedor_ID = proveedor;
                    centralOrdenesCompras.EstatusOrdenCompra_ID = Convert.ToInt32(AppHelper.IsNull(OrdenesComprasLA.Status, 1));
                    centralOrdenesCompras.Usuario_ID = OrdenesComprasLA.UsuarioAlta;
                    centralOrdenesCompras.Fecha = OrdenesComprasLA.FechaAlta;
                    centralOrdenesCompras.Factura = OrdenesComprasLA.Factura;
                    centralOrdenesCompras.Subtotal = OrdenesComprasLA.SubTotal;
                    centralOrdenesCompras.IVA = OrdenesComprasLA.IVA;
                    centralOrdenesCompras.Total = OrdenesComprasLA.Total;
                    centralOrdenesCompras.Empresa_ID = 4;
                    centralOrdenesCompras.Estacion_ID = 1;

                    if (Central.DB.Exists("OrdenesCompras", Param("OrdenCompra_ID", centralOrdenesCompras.OrdenCompra_ID)))
                    {
                        centralOrdenesCompras.Update();
                    }
                    else
                    {
                        centralOrdenesCompras.Create(true);
                        SyncCompras(centralOrdenesCompras.OrdenCompra_ID);
                    }

                    Console.WriteLine(String.Format("Registro actualizado OrdenCompra_ID: {0}", centralOrdenesCompras.OrdenCompra_ID));
                }

                //List<LA.Entities.OrdenesCompras> ordenescomprasLA = LA.Entities.OrdenesCompras.Read();
                //foreach (LA.Entities.OrdenesCompras OrdenesComprasLA in ordenescomprasLA)
                //{                    
                    

                //}	//	End foreach

            }	//	End Method SyncOrdenesCompras

            public void SyncOrdenesComprasCanceladas()
            {
                string filter = "OrdenCompra > @Folio";

                string sort = "OrdenCompra ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenCompra_ID),0) folio FROM OrdenesComprasCanceladas";

                LA.Entities.OrdenesComprasCanceladas OrdenesComprasCanceladasLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.OrdenesComprasCanceladas.Read(out OrdenesComprasCanceladasLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesComprasCanceladasLA.OrdenCompra;
                    // si no tiene compra, no checar
                    if(!LA.DB.Exists("OrdenesCompras", Param("Folio", OrdenesComprasCanceladasLA.OrdenCompra))) continue;

                    Central.Entities.OrdenesComprasCanceladas centralOrdenesComprasCanceladas = new Central.Entities.OrdenesComprasCanceladas();
                    centralOrdenesComprasCanceladas.OrdenCompra_ID = OrdenesComprasCanceladasLA.OrdenCompra;                    
                    centralOrdenesComprasCanceladas.Usuario_ID = OrdenesComprasCanceladasLA.Usuario;
                    centralOrdenesComprasCanceladas.Fecha = OrdenesComprasCanceladasLA.Fecha;
                    centralOrdenesComprasCanceladas.Comentarios = OrdenesComprasCanceladasLA.Motivos;


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
                LA.Entities.OrdenesServicio OrdenesServiciosLA;
                string filter = "Folio > @Folio";
                string sort = "Folio ASC";
                int folio = Convert.ToInt32(Central.DB.QueryScalar("SELECT ISNULL(MAX(OrdenServicio_ID),0) folio FROM OrdenesServicios"));

                while (LA.Entities.OrdenesServicio.Read(out OrdenesServiciosLA,1,filter,sort,Param("@Folio",folio)))
                {
                    try
                    {
                        Central.Entities.OrdenesTrabajos.Read(OrdenesServiciosLA.OrdenTrabajo);
                    }
                    catch (SICASException sicasEx)
                    {
                        folio = OrdenesServiciosLA.Folio;
                        continue;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    Central.Entities.OrdenesServicios centralOrdenesServicios = new Central.Entities.OrdenesServicios();
                    folio = OrdenesServiciosLA.Folio;
                    
                    centralOrdenesServicios.OrdenServicio_ID = OrdenesServiciosLA.Folio;
                    centralOrdenesServicios.OrdenTrabajo_ID = OrdenesServiciosLA.OrdenTrabajo;
                    centralOrdenesServicios.ServicioMantenimiento_ID = OrdenesServiciosLA.Servicio;
                    centralOrdenesServicios.Mecanico_ID = OrdenesServiciosLA.Mecanico;
                    centralOrdenesServicios.EstatusOrdenServicio_ID = OrdenesServiciosLA.Status;
                    centralOrdenesServicios.Fecha = Central.DB.GetNullableDateTime(OrdenesServiciosLA.FechaSurtida);
                    centralOrdenesServicios.Cantidad = Convert.ToInt32(OrdenesServiciosLA.Cantidad);
                    centralOrdenesServicios.Precio = OrdenesServiciosLA.PrecioUnitario;
                    centralOrdenesServicios.Total = OrdenesServiciosLA.Total;


                    if (Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", centralOrdenesServicios.OrdenServicio_ID)))
                    {
                        centralOrdenesServicios.Update();
                    }
                    else
                    {
                        centralOrdenesServicios.Create(true);
                    }

                    // Aqui van las refacciones de las ordenes de servicio
                    SyncOrdenesServiciosRefacciones(OrdenesServiciosLA.Folio);

                    Console.WriteLine(String.Format("Registro actualizado OrdenServicio_ID: {0}", centralOrdenesServicios.OrdenServicio_ID));
                }

            }	//	End Method SyncOrdenesServicios

            public void SyncOrdenesServiciosInit()
            {
                LA.Entities.OrdenesServicio OrdenesServiciosLA;
                string filter = "Folio > @Folio";
                string sort = "Folio ASC";
                int folio = 0;

                while (LA.Entities.OrdenesServicio.Read(out OrdenesServiciosLA, 1, filter, sort, Param("@Folio", folio)))
                {
                    try
                    {
                        Central.Entities.OrdenesTrabajos.Read(OrdenesServiciosLA.OrdenTrabajo);
                    }
                    catch (SICASException sicasEx)
                    {
                        folio = OrdenesServiciosLA.Folio;
                        continue;
                    }
                    catch 
                    {
                        folio = OrdenesServiciosLA.Folio;
                        continue;
                    }

                    Central.Entities.OrdenesServicios centralOrdenesServicios = new Central.Entities.OrdenesServicios();
                    folio = OrdenesServiciosLA.Folio;

                    centralOrdenesServicios.OrdenServicio_ID = OrdenesServiciosLA.Folio;
                    centralOrdenesServicios.OrdenTrabajo_ID = OrdenesServiciosLA.OrdenTrabajo;
                    centralOrdenesServicios.ServicioMantenimiento_ID = OrdenesServiciosLA.Servicio;
                    centralOrdenesServicios.Mecanico_ID = OrdenesServiciosLA.Mecanico;
                    centralOrdenesServicios.EstatusOrdenServicio_ID = OrdenesServiciosLA.Status;
                    centralOrdenesServicios.Fecha = Central.DB.GetNullableDateTime(OrdenesServiciosLA.FechaSurtida);
                    centralOrdenesServicios.Cantidad = Convert.ToInt32(OrdenesServiciosLA.Cantidad);
                    centralOrdenesServicios.Precio = OrdenesServiciosLA.PrecioUnitario;
                    centralOrdenesServicios.Total = OrdenesServiciosLA.Total;


                    if (Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", centralOrdenesServicios.OrdenServicio_ID)))
                    {
                        centralOrdenesServicios.Update();
                    }
                    else
                    {
                        centralOrdenesServicios.Create(true);
                    }

                    // Aqui van las refacciones de las ordenes de servicio
                    SyncOrdenesServiciosRefacciones(OrdenesServiciosLA.Folio);

                    Console.WriteLine(String.Format("Registro actualizado OrdenServicio_ID: {0}", centralOrdenesServicios.OrdenServicio_ID));
                }

            }	//	End Method SyncOrdenesServicios

            public void SyncOrdenesServiciosRefacciones(int OrdenServicio)
            {
                //  Ajustar como con compras
                List<LA.Entities.OrdenesServicioRefacciones> ordenesserviciosrefaccionesLA = 
                    LA.Entities.OrdenesServicioRefacciones.Read(Param("OrdenServicio", OrdenServicio));
                if (ordenesserviciosrefaccionesLA == null) return;
                foreach (LA.Entities.OrdenesServicioRefacciones OrdenesServiciosRefaccionesLA in ordenesserviciosrefaccionesLA)
                {
                    if (!Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", OrdenesServiciosRefaccionesLA.OrdenServicio)))
                    {
                        continue;
                    }
                    Central.Entities.OrdenesServiciosRefacciones centralOrdenesServiciosRefacciones = new Central.Entities.OrdenesServiciosRefacciones();
                    centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID = 0;
                    centralOrdenesServiciosRefacciones.OrdenServicio_ID = OrdenesServiciosRefaccionesLA.OrdenServicio;
                    centralOrdenesServiciosRefacciones.Refaccion_ID = OrdenesServiciosRefaccionesLA.Refaccion;
                    centralOrdenesServiciosRefacciones.Cantidad = Convert.ToInt32(OrdenesServiciosRefaccionesLA.Cantidad);
                    centralOrdenesServiciosRefacciones.PrecioUnitario = OrdenesServiciosRefaccionesLA.PrecioUnitario;
                    centralOrdenesServiciosRefacciones.Total = OrdenesServiciosRefaccionesLA.Total;
                    centralOrdenesServiciosRefacciones.CostoUnitario = (decimal)OrdenesServiciosRefaccionesLA.CostoUnitario;
                    centralOrdenesServiciosRefacciones.RefSurtidas = Central.DB.GetNullableInt32(OrdenesServiciosRefaccionesLA.RefSurtidas);


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

            public void SyncOrdenesServiciosRefacciones()
            {
                //  Ajustar como con compras
                List<LA.Entities.OrdenesServicioRefacciones> ordenesserviciosrefaccionesLA = LA.Entities.OrdenesServicioRefacciones.Read();
                foreach (LA.Entities.OrdenesServicioRefacciones OrdenesServiciosRefaccionesLA in ordenesserviciosrefaccionesLA)
                {
                    if (!Central.DB.Exists("OrdenesServicios", Param("OrdenServicio_ID", OrdenesServiciosRefaccionesLA.OrdenServicio)))
                    {
                        continue;
                    }
                    Central.Entities.OrdenesServiciosRefacciones centralOrdenesServiciosRefacciones = new Central.Entities.OrdenesServiciosRefacciones();
                    centralOrdenesServiciosRefacciones.OrdenServicioRefaccion_ID = 0;
                    centralOrdenesServiciosRefacciones.OrdenServicio_ID = OrdenesServiciosRefaccionesLA.OrdenServicio;
                    centralOrdenesServiciosRefacciones.Refaccion_ID = OrdenesServiciosRefaccionesLA.Refaccion;
                    centralOrdenesServiciosRefacciones.Cantidad = Convert.ToInt32(OrdenesServiciosRefaccionesLA.Cantidad);
                    centralOrdenesServiciosRefacciones.PrecioUnitario = OrdenesServiciosRefaccionesLA.PrecioUnitario;
                    centralOrdenesServiciosRefacciones.Total = OrdenesServiciosRefaccionesLA.Total;
                    centralOrdenesServiciosRefacciones.CostoUnitario = (decimal)OrdenesServiciosRefaccionesLA.CostoUnitario;
                    centralOrdenesServiciosRefacciones.RefSurtidas = Central.DB.GetNullableInt32(OrdenesServiciosRefaccionesLA.RefSurtidas);


                    if (Central.DB.Exists("OrdenesServiciosRefacciones", 
                            Param("OrdenServicio_ID", centralOrdenesServiciosRefacciones.OrdenServicio_ID),
                                Param("Refaccion_ID",centralOrdenesServiciosRefacciones.Refaccion_ID)))
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
   
                clientes.Add(7,5);
                clientes.Add(5,585);
                clientes.Add(4,586);
                clientes.Add(2,3);
                clientes.Add(1,2);

                return clientes[clientetaller];
            }

            public void SyncEstatusOrdenesTrabajos()
            {
                List<LA.Entities.StatusOrdenesTrabajo> estatusordenestrabajosLA = LA.Entities.StatusOrdenesTrabajo.Read();
                foreach (LA.Entities.StatusOrdenesTrabajo EstatusOrdenesTrabajosLA in estatusordenestrabajosLA)
                {
                    Central.Entities.EstatusOrdenesTrabajos centralEstatusOrdenesTrabajos = new Central.Entities.EstatusOrdenesTrabajos();
                    centralEstatusOrdenesTrabajos.EstatusOrdenTrabajo_ID = EstatusOrdenesTrabajosLA.Folio;
                    centralEstatusOrdenesTrabajos.Nombre = EstatusOrdenesTrabajosLA.Descripcion;

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
                List<LA.Entities.TiposMantenimientos> tiposmantenimientosLA = LA.Entities.TiposMantenimientos.Read();
                foreach (LA.Entities.TiposMantenimientos TiposMantenimientosLA in tiposmantenimientosLA)
                {
                    Central.Entities.TiposMantenimientos centralTiposMantenimientos = new Central.Entities.TiposMantenimientos();
                    centralTiposMantenimientos.TipoMantenimiento_ID = TiposMantenimientosLA.Folio;
                    centralTiposMantenimientos.Nombre = TiposMantenimientosLA.Descripcion;


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

                LA.Entities.OrdenesTrabajo OrdenesTrabajosLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.OrdenesTrabajo.Read(out OrdenesTrabajosLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesTrabajosLA.Folio;
                    Central.Entities.OrdenesTrabajos centralOrdenesTrabajos = new Central.Entities.OrdenesTrabajos();
                    centralOrdenesTrabajos.OrdenTrabajo_ID = OrdenesTrabajosLA.Folio;
                    centralOrdenesTrabajos.Empresa_ID = GetEmpresaClienteTaller(OrdenesTrabajosLA.ClienteTaller.Tipo);
                    centralOrdenesTrabajos.TipoMantenimiento_ID = Convert.ToInt32(OrdenesTrabajosLA.TipoMantenimiento);
                    centralOrdenesTrabajos.ClienteFacturar_ID = GetEmpresaClienteTaller(OrdenesTrabajosLA.ClienteTaller.Tipo);

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", OrdenesTrabajosLA.Unidad), Param("Estacion_ID", Estacion));
                    int unidad_id = 0;

                    if (unidad == null)
                    {
                        // No tiene unidad como referencia
                        if (OrdenesTrabajosLA.Unidad == OrdenesTrabajosLA.NumeroEconomico)
                        {
                            // Buscar por numero economico
                            unidad = Central.Entities.Unidades.Read(Param("NumeroEconomico", OrdenesTrabajosLA.Unidad));
                            if (unidad == null)
                            {
                                // Unidad no existe
                                // Utilizar una de default
                                unidad_id = 1626;
                            }
                            else
                            {
                                unidad_id = unidad.Unidad_ID;
                            }                            
                        }
                        else
                        {
                            unidad_id = 1626;
                        }
                    }
                    else
                    {
                        unidad_id = unidad.Unidad_ID;
                    }

                    centralOrdenesTrabajos.Unidad_ID = unidad_id;
                    centralOrdenesTrabajos.EstatusOrdenTrabajo_ID = OrdenesTrabajosLA.Status;
                    centralOrdenesTrabajos.Caja_ID = (OrdenesTrabajosLA.Caja == 9) ? 2 : OrdenesTrabajosLA.Caja;
                    centralOrdenesTrabajos.Usuario_ID = OrdenesTrabajosLA.UsuarioAlta;
                    centralOrdenesTrabajos.Factura_ID = null;
                    centralOrdenesTrabajos.UsuarioFacturacion_ID = OrdenesTrabajosLA.UsuarioFacturacion;
                    centralOrdenesTrabajos.CodigoBarras = OrdenesTrabajosLA.CodigoBarras;
                    centralOrdenesTrabajos.Subtotal = OrdenesTrabajosLA.Subtotal;
                    centralOrdenesTrabajos.IVA = OrdenesTrabajosLA.IVA;
                    centralOrdenesTrabajos.Total = OrdenesTrabajosLA.Total;
                    centralOrdenesTrabajos.FechaAlta = OrdenesTrabajosLA.FechaAlta;
                    centralOrdenesTrabajos.FechaTerminacion = OrdenesTrabajosLA.FechaTerminacion;
                    centralOrdenesTrabajos.FechaPago = OrdenesTrabajosLA.FechaPago;
                    centralOrdenesTrabajos.NumeroEconomico = Convert.ToInt32(OrdenesTrabajosLA.NumeroEconomico);
                    centralOrdenesTrabajos.FechaInicioReparacion = OrdenesTrabajosLA.FechaInicioReparacion;
                    centralOrdenesTrabajos.ManoObra = Convert.ToDecimal(OrdenesTrabajosLA.ManoObra);
                    centralOrdenesTrabajos.IVAManoObra = Convert.ToDecimal(OrdenesTrabajosLA.IVAManoObra);
                    centralOrdenesTrabajos.Refacciones = Convert.ToDecimal(OrdenesTrabajosLA.Refacciones);
                    centralOrdenesTrabajos.IVARefacciones = Convert.ToDecimal(OrdenesTrabajosLA.IVARefacciones);
                    centralOrdenesTrabajos.FechaFacturacion = OrdenesTrabajosLA.FechaFacturacion;
                    centralOrdenesTrabajos.Kilometraje = OrdenesTrabajosLA.Kilometraje;
                    centralOrdenesTrabajos.Comentarios = OrdenesTrabajosLA.Comentarios;
                    centralOrdenesTrabajos.CostoRefacciones = Convert.ToDecimal(OrdenesTrabajosLA.CostoRefacciones);
                    centralOrdenesTrabajos.CostoManoObra = Convert.ToDecimal(OrdenesTrabajosLA.CostoManoObra);
                    centralOrdenesTrabajos.CargoAConductor = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosLA.CargoCond, false));
                    centralOrdenesTrabajos.CB = OrdenesTrabajosLA.CB;
                    centralOrdenesTrabajos.CB_Activo = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosLA.CB_Activo, false));
                    centralOrdenesTrabajos.Empresa_ID = 4;
                    centralOrdenesTrabajos.Estacion_ID = 1;

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

                //List<LA.Entities.OrdenesTrabajo> ordenestrabajosLA = LA.Entities.OrdenesTrabajo.Read();
                //foreach (LA.Entities.OrdenesTrabajo OrdenesTrabajosLA in ordenestrabajosLA)
                //{                    
                //}	//	End foreach

            }	//	End Method SyncOrdenesTrabajos

            public void SyncOrdenesTrabajosInit()
            {
                string filter = "Cliente <> 0 AND Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(OrdenTrabajo_ID),0) folio FROM OrdenesTrabajos";

                LA.Entities.OrdenesTrabajo OrdenesTrabajosLA;
                int folio;

                folio = 0;

                while (LA.Entities.OrdenesTrabajo.Read(out OrdenesTrabajosLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = OrdenesTrabajosLA.Folio;
                    Central.Entities.OrdenesTrabajos centralOrdenesTrabajos = new Central.Entities.OrdenesTrabajos();
                    centralOrdenesTrabajos.OrdenTrabajo_ID = OrdenesTrabajosLA.Folio;
                    centralOrdenesTrabajos.Empresa_ID = GetEmpresaClienteTaller(OrdenesTrabajosLA.ClienteTaller.Tipo);
                    centralOrdenesTrabajos.TipoMantenimiento_ID = Convert.ToInt32(OrdenesTrabajosLA.TipoMantenimiento);
                    centralOrdenesTrabajos.ClienteFacturar_ID = GetEmpresaClienteTaller(OrdenesTrabajosLA.ClienteTaller.Tipo);

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", OrdenesTrabajosLA.Unidad), Param("Estacion_ID", Estacion));
                    int unidad_id = 0;

                    if (unidad == null)
                    {
                        // No tiene unidad como referencia
                        if (OrdenesTrabajosLA.Unidad == OrdenesTrabajosLA.NumeroEconomico)
                        {
                            // Buscar por numero economico
                            unidad = Central.Entities.Unidades.Read(Param("NumeroEconomico", OrdenesTrabajosLA.Unidad));
                            if (unidad == null)
                            {
                                // Unidad no existe
                                // Utilizar una de default
                                unidad_id = 1626;
                            }
                            else
                            {
                                unidad_id = unidad.Unidad_ID;
                            }
                        }
                        else
                        {
                            unidad_id = 1626;
                        }
                    }
                    else
                    {
                        unidad_id = unidad.Unidad_ID;
                    }

                    centralOrdenesTrabajos.Unidad_ID = unidad_id;
                    centralOrdenesTrabajos.EstatusOrdenTrabajo_ID = OrdenesTrabajosLA.Status;
                    centralOrdenesTrabajos.Caja_ID = (OrdenesTrabajosLA.Caja == 9) ? 2 : OrdenesTrabajosLA.Caja;
                    centralOrdenesTrabajos.Usuario_ID = OrdenesTrabajosLA.UsuarioAlta;
                    centralOrdenesTrabajos.Factura_ID = null;
                    centralOrdenesTrabajos.UsuarioFacturacion_ID = OrdenesTrabajosLA.UsuarioFacturacion;
                    centralOrdenesTrabajos.CodigoBarras = OrdenesTrabajosLA.CodigoBarras;
                    centralOrdenesTrabajos.Subtotal = OrdenesTrabajosLA.Subtotal;
                    centralOrdenesTrabajos.IVA = OrdenesTrabajosLA.IVA;
                    centralOrdenesTrabajos.Total = OrdenesTrabajosLA.Total;
                    centralOrdenesTrabajos.FechaAlta = OrdenesTrabajosLA.FechaAlta;
                    centralOrdenesTrabajos.FechaTerminacion = OrdenesTrabajosLA.FechaTerminacion;
                    centralOrdenesTrabajos.FechaPago = OrdenesTrabajosLA.FechaPago;
                    centralOrdenesTrabajos.NumeroEconomico = Convert.ToInt32(OrdenesTrabajosLA.NumeroEconomico);
                    centralOrdenesTrabajos.FechaInicioReparacion = OrdenesTrabajosLA.FechaInicioReparacion;
                    centralOrdenesTrabajos.ManoObra = Convert.ToDecimal(OrdenesTrabajosLA.ManoObra);
                    centralOrdenesTrabajos.IVAManoObra = Convert.ToDecimal(OrdenesTrabajosLA.IVAManoObra);
                    centralOrdenesTrabajos.Refacciones = Convert.ToDecimal(OrdenesTrabajosLA.Refacciones);
                    centralOrdenesTrabajos.IVARefacciones = Convert.ToDecimal(OrdenesTrabajosLA.IVARefacciones);
                    centralOrdenesTrabajos.FechaFacturacion = OrdenesTrabajosLA.FechaFacturacion;
                    centralOrdenesTrabajos.Kilometraje = OrdenesTrabajosLA.Kilometraje;
                    centralOrdenesTrabajos.Comentarios = OrdenesTrabajosLA.Comentarios;
                    centralOrdenesTrabajos.CostoRefacciones = Convert.ToDecimal(OrdenesTrabajosLA.CostoRefacciones);
                    centralOrdenesTrabajos.CostoManoObra = Convert.ToDecimal(OrdenesTrabajosLA.CostoManoObra);
                    centralOrdenesTrabajos.CargoAConductor = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosLA.CargoCond, false));
                    centralOrdenesTrabajos.CB = OrdenesTrabajosLA.CB;
                    centralOrdenesTrabajos.CB_Activo = Convert.ToBoolean(AppHelper.IsNull(OrdenesTrabajosLA.CB_Activo, false));
                    centralOrdenesTrabajos.Empresa_ID = 4;
                    centralOrdenesTrabajos.Estacion_ID = 1;

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

                //List<LA.Entities.OrdenesTrabajo> ordenestrabajosLA = LA.Entities.OrdenesTrabajo.Read();
                //foreach (LA.Entities.OrdenesTrabajo OrdenesTrabajosLA in ordenestrabajosLA)
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
                
                LA.Entities.Refacciones RefaccionesLA;
                int folio = folioinicial;

                while (LA.Entities.Refacciones.Read(out RefaccionesLA, 1, filter, sort, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesLA.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesLA.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesLA.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesLA.Modelo;

                    int marcaRefaccion;
                    if (RefaccionesLA.Marca == null)
                    {
                        if (RefaccionesLA.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesLA.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesLA.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesLA.Año;
                    //centralRefacciones.Pasillo = RefaccionesLA.Pasillo;
                    //centralRefacciones.Estante = RefaccionesLA.Estante;
                    //centralRefacciones.Nivel = RefaccionesLA.Nivel;
                    //centralRefacciones.Seccion = RefaccionesLA.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesLA.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesLA.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenExt, 0));
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

            public void SyncActualizarInventario()
            {
                string sql = @"SELECT	Refaccion Folio, 
		                SUM(Cantidad) CantidadInventario, 
		                SUM(Costo) Valorinventario
                FROM	Inventario
                GROUP BY Refaccion";

                DataTable dt = LA.DB.Query(sql);

                int cont = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    cont++;
                    int folio, cantidadInventario;
                    decimal valorInventario;

                    folio = Convert.ToInt32(dr["Folio"]);
                    cantidadInventario = Convert.ToInt32(dr["CantidadInventario"]);
                    valorInventario = Convert.ToDecimal(dr["ValorInventario"]);

                    Central.DB.UpdateRow(
                        "Inventario",
                        Central.DB.GetParams(
                            Param("CantidadInventario", cantidadInventario),
                            Param("ValorInventario", valorInventario)
                        ),
                        Central.DB.GetParams(
                            Param("Refaccion_ID", folio)
                        )
                    );

                    cont++;
                    Console.WriteLine(string.Format("Actualizado folio {0}, {1} de {2}", folio, cont, dt.Rows.Count));
                }

                /*
                string sql = @"SELECT DISTINCT Folio 
                    FROM Refacciones
                    WHERE   (Folio IN
                    (SELECT Refaccion FROM Compras)
                    OR Folio IN
                    (SELECT Refaccion FROM OrdenesServicioRefacciones)
                    OR Folio IN (SELECT Refaccion FROM MovimientosDirectosAInventario))";

                IEnumerable<int> folios = 
                    LA.DB.QueryList<int>(sql, "Folio");

                int cont = 0;
                int total = new List<int>(folios).Count;

                foreach (int folio in folios)
                {
                    string sqlstr = @"SELECT	ISNULL(SUM(Cantidad),0) Cantidad 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    int cantidadInventario =
                        Convert.ToInt32(
                            LA.DB.QueryScalar(
                                sqlstr,
                                Param("@Refaccion", folio)
                            )
                        );
                    
                    sqlstr = @"SELECT	ISNULL(SUM(Costo),0) Costo 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    decimal valorInventario =
                        Convert.ToDecimal(
                            LA.DB.QueryScalar(
                                sqlstr,
                                Param("@Refaccion", folio)
                            )
                        );

                    Central.DB.UpdateRow(
                        "Refacciones", 
                        Central.DB.GetParams(
                            Param("CantidadInventario", cantidadInventario),
                            Param("ValorInventario", valorInventario)
                        ),
                        Central.DB.GetParams(
                            Param("Refaccion_ID", folio)
                        )
                    );

                    cont++;
                    Console.WriteLine(string.Format("Actualizado folio {0}, {1} de {2}", folio, cont, total));
                }
                */
            }

            public void SyncRefacciones()
            {
                                
                LA.Entities.Refacciones RefaccionesLA;
                int folio;

                folio = 0;

                while (LA.Entities.Refacciones.Read(out RefaccionesLA, 1, "Folio > @Folio", null, Param("Folio", folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesLA.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesLA.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesLA.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesLA.Modelo; // Empieza localmente en el 67

                    int marcaRefaccion;
                    if (RefaccionesLA.Marca == null)
                    {
                        if (RefaccionesLA.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesLA.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesLA.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesLA.Año;
                    centralRefacciones.NumeroSerial = RefaccionesLA.NumeroDeParte;

                    //  Obtener la descripción a partir las variables
                    centralRefacciones.Descripcion = RefaccionesLA.Descripcion;

                    if (centralRefacciones.Modelo_ID == 0)
                        continue;

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

            public void SyncInventario()
            {
                LA.Entities.Refacciones RefaccionesLA;
                int folio;

                //folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));
                folio = 0;

                while (LA.Entities.Refacciones.Read(out RefaccionesLA, 1, "Folio > @Folio", null, Param("Folio", folio)))
                {
                    Central.Entities.Inventario centralRefacciones = new Central.Entities.Inventario();
                    folio = RefaccionesLA.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesLA.Folio;
                    centralRefacciones.Pasillo = RefaccionesLA.Pasillo;
                    centralRefacciones.Estante = RefaccionesLA.Estante;
                    centralRefacciones.Nivel = RefaccionesLA.Nivel;
                    centralRefacciones.Seccion = RefaccionesLA.Seccion;
                    
                    centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.Costo, 0));
                    centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioInt, 0));
                    centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioExt, 0));
                    centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenInt, 0));
                    centralRefacciones.MargenExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenExt, 0));

                    if (!Central.DB.Exists("Refacciones", Param("Refaccion_ID", centralRefacciones.Refaccion_ID)))
                    {
                        continue;
                    }

                    string sqlstr = @"SELECT	ISNULL(SUM(Cantidad),0) Cantidad 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    int cantidadInventario =
                        Convert.ToInt32(
                            LA.DB.QueryScalar(
                                sqlstr,
                                Param("@Refaccion", RefaccionesLA.Folio)
                            )
                        );
                    centralRefacciones.CantidadInventario = cantidadInventario;

                    sqlstr = @"SELECT	ISNULL(SUM(Costo),0) Costo 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    decimal valorInventario =
                        Convert.ToDecimal(
                            LA.DB.QueryScalar(
                                sqlstr,
                                Param("@Refaccion", RefaccionesLA.Folio)
                            )
                        );

                    centralRefacciones.ValorInventario = valorInventario;

                    centralRefacciones.PuntoDeReOrden = cantidadInventario;

                    centralRefacciones.Empresa_ID = 4;
                    centralRefacciones.Estacion_ID = 1;

                    if (Central.DB.Exists("Refacciones", Param("Refaccion_ID", centralRefacciones.Refaccion_ID)))
                    {
                        centralRefacciones.Update();
                    }
                    else
                    {
                        centralRefacciones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Inventario Refaccion_ID: {0}", centralRefacciones.Refaccion_ID));
                }

            }	//	End Method SyncRefacciones

            public void SyncRefaccionesExisting()
            {
                string filter = "(Folio IN " +
                    "(SELECT Refaccion FROM Compras) " +
                    "OR Folio IN " +
                    "(SELECT Refaccion FROM OrdenesServicioRefacciones) " +
                    "OR Folio IN (SELECT Refaccion FROM MovimientosDirectosAInventario)) " +
                    "AND Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Refaccion_ID),0) folio FROM Refacciones";

                LA.Entities.Refacciones RefaccionesLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.Refacciones.Read(out RefaccionesLA, 1, filter, sort, Param("Folio",folio)))
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    folio = RefaccionesLA.Folio;
                    centralRefacciones.Refaccion_ID = RefaccionesLA.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesLA.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesLA.Modelo; // Empieza localmente en el 67
                    
                    int marcaRefaccion;
                    if (RefaccionesLA.Marca == null)
                    {
                        if (RefaccionesLA.Inventario.Count != 0)
                        {
                            marcaRefaccion = RefaccionesLA.Inventario[0].Marca;
                        }
                        else
                        {
                            // No tiene marca
                            marcaRefaccion = 1;
                        }
                    }
                    else
                    {
                        marcaRefaccion = Convert.ToInt32(RefaccionesLA.Marca);
                    }

                    centralRefacciones.MarcaRefaccion_ID = marcaRefaccion;
                    centralRefacciones.Anio = RefaccionesLA.Año;
                    //centralRefacciones.Pasillo = RefaccionesLA.Pasillo;
                    //centralRefacciones.Estante = RefaccionesLA.Estante;
                    //centralRefacciones.Nivel = RefaccionesLA.Nivel;
                    //centralRefacciones.Seccion = RefaccionesLA.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesLA.NumeroDeParte;

                    //  Obtener la descripción a partir las variables
                    centralRefacciones.Descripcion = RefaccionesLA.Descripcion;

                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenExt, 0));

                    string sqlstr = @"SELECT	ISNULL(SUM(Cantidad),0) Cantidad 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    int cantidadInventario = 
                        Convert.ToInt32(
                            LA.DB.QueryScalar(
                                sqlstr, 
                                Param("@Refaccion", RefaccionesLA.Folio)
                            )
                        );
                    //centralRefacciones.CantidadInventario = cantidadInventario; 

                    sqlstr = @"SELECT	ISNULL(SUM(Costo),0) Costo 
                    FROM Inventario 
                    WHERE	Refaccion = @Refaccion";

                    decimal valorInventario = 
                        Convert.ToDecimal(
                            LA.DB.QueryScalar(
                                sqlstr, 
                                Param("@Refaccion", RefaccionesLA.Folio)
                            )
                        );

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

                List<LA.Entities.Refacciones> refaccionesLA = LA.Entities.Refacciones.Read(filter, "");
                foreach (LA.Entities.Refacciones RefaccionesLA in refaccionesLA)
                {
                    Central.Entities.Refacciones centralRefacciones = new Central.Entities.Refacciones();
                    centralRefacciones.Refaccion_ID = RefaccionesLA.Folio;
                    centralRefacciones.TipoRefaccion_ID = RefaccionesLA.Tipo;
                    centralRefacciones.Modelo_ID = RefaccionesLA.Modelo;
                    centralRefacciones.MarcaRefaccion_ID = Convert.ToInt32(AppHelper.IsNull(RefaccionesLA.Marca, RefaccionesLA.Inventario[0].Marca));
                    centralRefacciones.Anio = RefaccionesLA.Año;
                    //centralRefacciones.Pasillo = RefaccionesLA.Pasillo;
                    //centralRefacciones.Estante = RefaccionesLA.Estante;
                    //centralRefacciones.Nivel = RefaccionesLA.Nivel;
                    //centralRefacciones.Seccion = RefaccionesLA.Seccion;
                    centralRefacciones.NumeroSerial = RefaccionesLA.NumeroDeParte;
                    centralRefacciones.Descripcion = RefaccionesLA.Descripcion;
                    //centralRefacciones.CostoUnitario = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.Costo, 0));
                    //centralRefacciones.PrecioInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioInt, 0));
                    //centralRefacciones.PrecioExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.PrecioExt, 0));
                    //centralRefacciones.MargenInterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenInt, 0));
                    //centralRefacciones.MargentExterno = Convert.ToDecimal(AppHelper.IsNull(RefaccionesLA.MargenExt, 0));
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
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(ServicioMantenimiento_ID),0) folio FROM ServiciosMantenimientos";

                LA.Entities.Servicios ServiciosMantenimientosLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));
                int maxfolio = Convert.ToInt32(
                    LA.DB.QueryScalar("SELECT MAX(Folio) MaxFolio FROM Servicios"));

                while (LA.Entities.Servicios.Read(out ServiciosMantenimientosLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ServiciosMantenimientosLA.Folio;

                    Central.Entities.ServiciosMantenimientos centralServiciosMantenimientos = new Central.Entities.ServiciosMantenimientos();
                    centralServiciosMantenimientos.ServicioMantenimiento_ID = ServiciosMantenimientosLA.Folio;
                    centralServiciosMantenimientos.TipoServicioMantenimiento_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Familia_ID = (ServiciosMantenimientosLA.Familia == 0) ? 1 : ServiciosMantenimientosLA.Familia;
                    centralServiciosMantenimientos.Modelo_ID = 1; // Posteriormente se ajustará
                    centralServiciosMantenimientos.Nombre = ServiciosMantenimientosLA.Descripcion;
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

                    Console.WriteLine(String.Format("Registro actualizado ServicioMantenimiento_ID: {0} de {1}", 
                        centralServiciosMantenimientos.ServicioMantenimiento_ID, maxfolio));

                }	//	End foreach

            }	//	End Method SyncServiciosMantenimientos

            private int TipoEmpresaDeTipoCliente(int empresa_id)
            {
                int result = 0;
                switch (empresa_id)
                {
                    case 1: result = 1; break;
                    case 2: result = 2; break;
                    case 4: result = 4; break;
                    case 5: result = 4; break;                    
                    case 7: result = 3; break;;
                }
                return result;
            }

            public void SyncServiciosMantenimientosPrecios()
            {
                string filter = @"TipoCliente IN (1,2,4,5,7) 
                                AND Servicio IN 
                                (SELECT Folio FROM Servicios)";
                List<LA.Entities.ServiciosPreciosManoDeObra> serviciosmantenimientospreciosLA =
                    LA.Entities.ServiciosPreciosManoDeObra.Read(filter);

                foreach (
                    LA.Entities.ServiciosPreciosManoDeObra ServiciosMantenimientosPreciosLA 
                    in serviciosmantenimientospreciosLA)
                {
                    Central.Entities.ServiciosMantenimientosPrecios centralServiciosMantenimientosPrecios = new Central.Entities.ServiciosMantenimientosPrecios();
                    centralServiciosMantenimientosPrecios.ServicioMantenimiento_ID = 
                        ServiciosMantenimientosPreciosLA.Servicio;
                    
                    centralServiciosMantenimientosPrecios.TipoClienteTaller_ID = 
                        TipoEmpresaDeTipoCliente(ServiciosMantenimientosPreciosLA.TipoCliente);

                    if (centralServiciosMantenimientosPrecios.TipoClienteTaller_ID == 0)
                        break;

                    centralServiciosMantenimientosPrecios.Precio = 
                        ServiciosMantenimientosPreciosLA.Precio;

                    centralServiciosMantenimientosPrecios.Empresa_ID = 4;
                    centralServiciosMantenimientosPrecios.Estacion_ID = 1;

                    if (
                        Central.DB.Exists(
                            "ServiciosMantenimientosPrecios", 
                            Param("ServicioMantenimiento_ID", centralServiciosMantenimientosPrecios.ServicioMantenimiento_ID),
                            Param("TipoClienteTaller_ID", centralServiciosMantenimientosPrecios.TipoClienteTaller_ID),
                            Param("Empresa_ID", centralServiciosMantenimientosPrecios.Empresa_ID),
                            Param("Estacion_ID", centralServiciosMantenimientosPrecios.Estacion_ID)
                            )
                        )
                    {
                        centralServiciosMantenimientosPrecios.Update();
                    }
                    else
                    {
                        centralServiciosMantenimientosPrecios.Create();
                    }

                    Console.WriteLine(
                        String.Format(
                            "Registro actualizado Precio de Servicio: {0} de {1}",
                            serviciosmantenimientospreciosLA.IndexOf(ServiciosMantenimientosPreciosLA) + 1,
                            serviciosmantenimientospreciosLA.Count
                            )
                        );
                }	//	End foreach

            }	//	End Method SyncServiciosMantenimientosPrecios

            public void SyncServiciosMantenimientos_TiposRefacciones()
            {
                //  Se tiene que actualizar, por si hay cambios
                string sql = "SELECT DISTINCT Servicio FROM ServiciosTiposRefacciones";
                IEnumerable<int> servicios = LA.DB.QueryList<int>(sql, "Servicio");

                foreach (int servicio in servicios)
                {
                    Central.DB.DeleteRow(
                        "ServiciosMantenimientos_TiposRefacciones",
                        Central.DB.GetParams(
                            Param(
                                "ServicioMantenimiento_ID",
                                servicio
                            )
                        )
                    );

                    Console.WriteLine(string.Format("Eliminadas tipos refacciones de servicio {0}", servicio));

                    List<LA.Entities.ServiciosTiposRefacciones> serviciosmantenimientos_tiposrefaccionesLA = 
                        LA.Entities.ServiciosTiposRefacciones.Read(servicio);

                    foreach (LA.Entities.ServiciosTiposRefacciones ServiciosMantenimientos_TiposRefaccionesLA in serviciosmantenimientos_tiposrefaccionesLA)
                    {
                        Central.Entities.ServiciosMantenimientos_TiposRefacciones centralServiciosMantenimientos_TiposRefacciones = new Central.Entities.ServiciosMantenimientos_TiposRefacciones();
                        centralServiciosMantenimientos_TiposRefacciones.ServicioMantenimiento_ID = ServiciosMantenimientos_TiposRefaccionesLA.Servicio;
                        centralServiciosMantenimientos_TiposRefacciones.TipoRefaccion_ID = ServiciosMantenimientos_TiposRefaccionesLA.TipoRefaccion;
                        centralServiciosMantenimientos_TiposRefacciones.Cantidad = ServiciosMantenimientos_TiposRefaccionesLA.Cantidad;

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
                }                
            }	//	End Method SyncServiciosMantenimientos_TiposRefacciones

            public void SyncUpdateSesiones()
            {
                List<LA.Entities.ControlCajas> Sesiones = LA.Entities.ControlCajas.Read();
                foreach (LA.Entities.ControlCajas SesionesLA in Sesiones)
                {
                    int sesion = SesionesLA.Sesion;

                    Central.Entities.Sesiones centralSesiones = 
                        Central.Entities.Sesiones.Read(
                        Param("Referencia_ID", sesion), 
                        Param("Estacion_ID", Estacion));
                    
                    centralSesiones.FechaInicial = SesionesLA.Inicio;
                    centralSesiones.FechaFinal = SesionesLA.Corte;                    
                    centralSesiones.Activo = (SesionesLA.Corte == null) ? true : false;                    

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

            public void SyncSesiones()
            {
                string filter = "Sesion > @Sesion";

                string sort = "Sesion ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Sesiones WHERE Estacion_ID = @Estacion";

                LA.Entities.ControlCajas SesionesLA;
                int sesion;

                sesion = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                
                while (LA.Entities.ControlCajas.Read(out SesionesLA, 1, filter, sort, Param("Sesion", sesion)))
                {
                    sesion = SesionesLA.Sesion;

                    Central.Entities.Sesiones centralSesiones = new Central.Entities.Sesiones();
                    centralSesiones.Sesion_ID = SesionesLA.Sesion;
                    centralSesiones.Empresa_ID = Empresa; // CAM
                    centralSesiones.Estacion_ID = Estacion; // LA

                    centralSesiones.Caja_ID = 
                        Central.Entities.Cajas.Read(Param("Referencia_ID", SesionesLA.Caja), Param("Estacion_ID", Estacion)).Caja_ID;
                    LA.Entities.MovimientosCaja mc = LA.Entities.MovimientosCaja.Read(Param("Sesion", SesionesLA.Sesion));

                    centralSesiones.Usuario_ID = (mc == null) ? "SICAS" : mc.Usuario;
                    
                    centralSesiones.FechaInicial = SesionesLA.Inicio;
                    centralSesiones.FechaFinal = SesionesLA.Corte;
                    centralSesiones.HostName = null;
                    centralSesiones.IPAddress = null;
                    centralSesiones.MACAddress = null;
                    centralSesiones.Activo = (SesionesLA.Corte == null) ? true : false;
                    centralSesiones.Referencia_ID = sesion;

                    if (Central.DB.Exists("Sesiones", Param("Sesion_ID", centralSesiones.Sesion_ID)))
                    {
                        centralSesiones.Update();
                    }
                    else
                    {
                        centralSesiones.Create();
                    }

                    Console.WriteLine(String.Format("Registrada Sesion_ID: {0}", centralSesiones.Sesion_ID));
                }

            }	//	End Method SyncSesiones

            public void SyncTickets()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Tickets WHERE Estacion_ID = @Estacion";
                //sqlQry += " AND Fecha < '2011-06-15'";

                LA.Entities.Recibos TicketsLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.Recibos.Read(out TicketsLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TicketsLA.Folio;

                    Central.Entities.Tickets centralTickets = new Central.Entities.Tickets();
                    
                    centralTickets.Ticket_ID = 0;
                    centralTickets.Referencia_ID = folio;

                    //  Consultar la sesión por usuario y fecha
                    LA.Entities.ControlCajas cc = LA.Entities.ControlCajas.GetBy(TicketsLA.Fecha, TicketsLA.Caja);                    
                    int sesionlocal = cc.Sesion;
                    int sesion_id = Central.Entities.Sesiones.Read(Param("Referencia_ID", sesionlocal), Param("Estacion_ID", Estacion)).Sesion_ID;
                    centralTickets.Sesion_ID = sesion_id;

                    centralTickets.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsLA.Caja)).Caja_ID;
                    centralTickets.Usuario_ID = TicketsLA.UsuarioAlta;

                    //  Si existe en cancelados
                    if (LA.DB.Exists("RecibosCancelados", Param("Estacion", Estacion), Param("Recibo", TicketsLA.Folio)))
                    {
                        centralTickets.EstatusTicket_ID = 2;
                    }
                    else
                    {
                        centralTickets.EstatusTicket_ID = 1;
                    }
                    
                    centralTickets.Empresa_ID = Empresa; // CAM
                    centralTickets.Estacion_ID = Estacion; // LA

                    if (TicketsLA.Unidad == 0)
                    {
                        centralTickets.Unidad_ID = null;
                    }
                    else
                    {
                        centralTickets.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsLA.Unidad)).Unidad_ID;
                    }

                    centralTickets.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", TicketsLA.Conductor)).Conductor_ID;


                    centralTickets.Fecha = TicketsLA.Fecha;

                    if (Central.DB.Exists("Tickets", Param("Ticket_ID", centralTickets.Ticket_ID)))
                    {
                        centralTickets.Update();
                    }
                    else
                    {
                        centralTickets.Create();
                    }

                    if (TicketsLA.Planillas != null)
                    { 
                        foreach(LA.Entities.RecibosPlanillas  rp in TicketsLA.Planillas)
                        {
                            Central.Entities.PlanillasFiscales planilla =
                                Central.Entities.PlanillasFiscales.Read(Estacion, rp.Serie, rp.Planilla);
                            if (planilla == null) break;
                            planilla.Ticket_ID = centralTickets.Ticket_ID;
                            planilla.EstatusPlanillaFiscal_ID = 2;
                            planilla.Update();

                            Console.WriteLine(String.Format("Registro actualizado Ticket_ID: {0} Planilla: {1}", folio, rp.Planilla));
                        }
                    }

                    Console.WriteLine(String.Format("Registro actualizado Ticket_ID: {0}", folio));
                }
            }	//	End Method SyncTickets

            public void SyncTicketsCancelados()
            {
                //  Ajustar con read
                List<LA.Entities.RecibosCancelados> ticketscanceladosLA = LA.Entities.RecibosCancelados.Read();
                foreach (LA.Entities.RecibosCancelados TicketsCanceladosLA in ticketscanceladosLA)
                {
                    Central.Entities.TicketsCancelados centralTicketsCancelados = new Central.Entities.TicketsCancelados();

                    Central.Entities.Tickets ticket = Central.Entities.Tickets.Read(Param("Referencia_ID",TicketsCanceladosLA.Recibo), Param("Estacion_ID", Estacion));
                    if(ticket == null)
                    {
                        // Ticket no existe
                        continue;
                    }
                    centralTicketsCancelados.Ticket_ID = ticket.Ticket_ID;
                    centralTicketsCancelados.Motivo = TicketsCanceladosLA.Motivo;
                    centralTicketsCancelados.Usuario_ID = TicketsCanceladosLA.Usuario;
                    centralTicketsCancelados.Fecha = Convert.ToDateTime(TicketsCanceladosLA.Fecha);


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
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(TipoRefaccion_ID),0) folio FROM TiposRefacciones";

                LA.Entities.TiposRefacciones TiposRefaccionesLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.TiposRefacciones.Read(out TiposRefaccionesLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TiposRefaccionesLA.Folio;
                
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesLA.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesLA.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesLA.Descripcion;


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
                List<LA.Entities.TiposRefacciones> tiposrefaccionesLA = LA.Entities.TiposRefacciones.Read();
                foreach (LA.Entities.TiposRefacciones TiposRefaccionesLA in tiposrefaccionesLA)
                {
                    Central.Entities.TiposRefacciones centralTiposRefacciones = new Central.Entities.TiposRefacciones();
                    centralTiposRefacciones.TipoRefaccion_ID = TiposRefaccionesLA.Folio;
                    centralTiposRefacciones.Familia_ID = TiposRefaccionesLA.Familia;
                    centralTiposRefacciones.Nombre = TiposRefaccionesLA.Descripcion;

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

                LA.Entities.Unidades UnidadesLA;
                int folio = 0;

                while (LA.Entities.Unidades.Read(out UnidadesLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesLA.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesLA.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // LA
                    centralUnidades.NumeroEconomico = UnidadesLA.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesLA.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesLA.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesLA.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesLA.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesLA.TarjetaCirculacion;

                    centralUnidades.EstatusUnidad_ID = UnidadesLA.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesLA.Locacion);

                    centralUnidades.Placas = (UnidadesLA.Concesion == null) ? "" : UnidadesLA.Concesion.Placa;

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesLA.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesLA.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }
                    }

                    if (UnidadesLA.NumeroEconomico == 1433)
                    {
                        int x = 0;
                    }

                    centralUnidades.Referencia_ID = UnidadesLA.Folio;


                    if (Central.DB.Exists("Unidades", Param("Referencia_ID", centralUnidades.Referencia_ID),
                        Param("Estacion_ID", Estacion)))
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
                        centralUnidades.Create();

                        Console.WriteLine(String.Format("Registro creado Unidad_ID: {0}, Num Eco {1}",
                            centralUnidades.Unidad_ID, centralUnidades.NumeroEconomico));
                    }                    
                }
            }	//	End Method SyncUnidades

            public void UpdateEstatusLocacionesUnidades()
            {
                string sql = "SELECT Folio, Status, Locacion FROM Unidades";
                DataTable dt = LA.DB.Query(sql);

                int unidad_id, estatusunidad_id, locacionunidad_id;

                foreach (DataRow dr in dt.Rows)
                {
                    unidad_id = 
                        Central.Entities.Unidades.Read(
                            Param("Estacion_ID", Estacion), 
                            Param("Referencia_ID", dr["Folio"])
                        ).Unidad_ID;

                    estatusunidad_id = Convert.ToInt32(dr["Status"]);

                    locacionunidad_id = LocacionCentral(Convert.ToInt32(dr["Locacion"]));

                    Hashtable m_params = new Hashtable();
                    Hashtable w_params = new Hashtable();
                    m_params.Add("EstatusUnidad_ID", estatusunidad_id);
                    m_params.Add("LocacionUnidad_ID", locacionunidad_id);
                    w_params.Add("Unidad_ID", unidad_id);

                    Central.DB.UpdateRow(
                        "Unidades",
                        m_params,
                        w_params
                    );

                    Console.WriteLine(
                        string.Format(
                            "Actualizando unidad {0} estatus {1} y locacion {2}",
                            unidad_id,
                            estatusunidad_id,
                            locacionunidad_id
                        )
                    );
                }
            }

            public void SyncUnidades()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                LA.Entities.Unidades UnidadesLA;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.Unidades.Read(out UnidadesLA, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesLA.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = UnidadesLA.Folio;
                    centralUnidades.Empresa_ID = Empresa; // CAM
                    centralUnidades.Estacion_ID = Estacion; // LA
                    centralUnidades.NumeroEconomico = UnidadesLA.NumeroEconomico;

                    int modelounidad_id = Central.Entities.ModelosUnidades.Read(Param("referencia_id", UnidadesLA.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralUnidades.ModeloUnidad_ID = modelounidad_id; // A consultar

                    centralUnidades.PrecioLista = UnidadesLA.PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesLA.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesLA.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesLA.TarjetaCirculacion;
                    
                    centralUnidades.EstatusUnidad_ID = UnidadesLA.Status;
                    centralUnidades.LocacionUnidad_ID = LocacionCentral(UnidadesLA.Locacion);
                    
                    centralUnidades.Placas = (UnidadesLA.Concesion==null) ? "" : UnidadesLA.Concesion.Placa; 

                    centralUnidades.Kilometraje = 0; // Consultar de registro // Actualizar despues de importación

                    centralUnidades.Propietario_ID = 1; // Casco
                    centralUnidades.Arrendamiento_ID = null; // No entra control de arrendamientos, // Debe ser nulo

                    if (UnidadesLA.Concesion == null)
                    {
                        centralUnidades.Concesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Concesiones concesion = Central.Entities.Concesiones.Read(Param("EstacionReferencia_ID", Estacion), Param("Referencia_ID", UnidadesLA.Concesion.Folio));
                        if (concesion == null)
                        {
                            centralUnidades.Concesion_ID = null;
                        }
                        else
                        {
                            centralUnidades.Concesion_ID = concesion.Concesion_ID; // Obtener de concesiones
                        }                        
                    }                    

                    centralUnidades.Referencia_ID = UnidadesLA.Folio;


                    if (Central.DB.Exists("Unidades", Param("Referencia_ID", centralUnidades.Referencia_ID),
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

                LA.Entities.RegistroKilometrajesUnidades Unidades_KilometrajesLA;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.RegistroKilometrajesUnidades.Read(out Unidades_KilometrajesLA, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_KilometrajesLA.Fecha;

                    Central.Entities.Unidades_Kilometrajes centralUnidades_Kilometrajes = new Central.Entities.Unidades_Kilometrajes();

                    centralUnidades_Kilometrajes.Unidad_Kilometraje_ID = 0; // A determinar
                    
                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", Unidades_KilometrajesLA.Unidad));
                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_KilometrajesLA.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Unidad_ID = unidad.Unidad_ID;                    
                    }

                    centralUnidades_Kilometrajes.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesLA.ConductorActual)).Conductor_ID;

                    Central.Entities.Conductores conductor =
                         Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", Unidades_KilometrajesLA.ConductorActual));

                    if (conductor == null)
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = null;
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Conductor_ID = conductor.Conductor_ID;
                    }

                    centralUnidades_Kilometrajes.Kilometraje = Unidades_KilometrajesLA.Kilometraje;
                    centralUnidades_Kilometrajes.Fecha = Unidades_KilometrajesLA.Fecha;

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
                        Param("@Estacion",Estacion)
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

                LA.Entities.RegistroLocacionesUnidades Unidades_LocacionesLA;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (LA.Entities.RegistroLocacionesUnidades.Read(out Unidades_LocacionesLA, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = Unidades_LocacionesLA.Fecha;

                    Central.Entities.Unidades_Locaciones centralUnidades_Locaciones = new Central.Entities.Unidades_Locaciones();                    

                    Central.Entities.Unidades unidad = 
                        Central.Entities.Unidades.Read(
                            Param("Estacion_ID", this.Estacion),
                                Param("Referencia_ID", Unidades_LocacionesLA.Unidad));

                    if (unidad == null)
                    {
                        DoLog(String.Format("Unidad {0} no existe", Unidades_LocacionesLA.Unidad));
                        continue;
                    }
                    else
                    {
                        centralUnidades_Locaciones.Unidad_ID = unidad.Unidad_ID;
                    }

                    centralUnidades_Locaciones.LocacionUnidad_ID = LocacionCentral(Unidades_LocacionesLA.Locacion); // A consultar
                    
                    centralUnidades_Locaciones.Fecha = Unidades_LocacionesLA.Fecha;


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

                LA.Entities.ValesPrepagados ValesPrepagadosLA;
                string vale;

                vale = Convert.ToString(Central.DB.QueryScalar(sqlQry));

                while (LA.Entities.ValesPrepagados.Read(out ValesPrepagadosLA, 1, filter, sort, Param("@Codigo", vale)))
                {
                    vale = ValesPrepagadosLA.Codigo;

                    Central.Entities.ValesPrepagados centralValesPrepagados = new Central.Entities.ValesPrepagados();
                    centralValesPrepagados.ValePrepagado_ID = ValesPrepagadosLA.Codigo;

                    if (ValesPrepagadosLA.Cliente == 0) continue;

                    int empresacliente_id = Central.Entities.Empresas.Read(Param("Rfc", ValesPrepagadosLA.Clientes.Rfc))[0].Empresa_ID;
                    centralValesPrepagados.EmpresaCliente_ID = empresacliente_id;

                    centralValesPrepagados.Usuario_ID = ValesPrepagadosLA.UsuarioEmision;
                    centralValesPrepagados.EstatusValePrepagado_ID = ValesPrepagadosLA.Status;
                    centralValesPrepagados.FolioDiario = ValesPrepagadosLA.FolioDiario;
                    centralValesPrepagados.Denominacion = ValesPrepagadosLA.Denominacion;
                    centralValesPrepagados.FechaEmision = ValesPrepagadosLA.FechaEmision;
                    centralValesPrepagados.FechaExpiracion = ValesPrepagadosLA.FechaExpiracion;

                    //  Se obtiene del recibo
                    if (ValesPrepagadosLA.RecibosValesPrepagados != null)
                    {
                        Central.Entities.Tickets ticket =
                            Central.Entities.Tickets.Read(
                            Param("Referencia_ID", ValesPrepagadosLA.Recibos.Folio),
                            Param("Estacion_ID", Estacion));

                        if (ticket != null)
                        {
                            centralValesPrepagados.Ticket_ID = ticket.Ticket_ID;
                        }                        
                        centralValesPrepagados.FechaCanje = ValesPrepagadosLA.Recibos.Fecha;
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

                List<LA.Entities.PlanillasFiscales> Planillas;

                List<DateTime> fechas =
                    (List<DateTime>)LA.DB.QueryList<DateTime>(
                    "SELECT DISTINCT FechaAlta FROM PlanillasFiscales WHERE FechaAlta >= @Fecha",
                    "FechaAlta",
                    Param("@Fecha", fecha));

                int cont = fechas.Count;

                foreach (DateTime f in fechas)
                {
                    Planillas = LA.Entities.PlanillasFiscales.ReadList(Param("FechaAlta", f));

                    foreach (LA.Entities.PlanillasFiscales PlanillasFiscalesLA in Planillas)
                    {
                        Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();                        

                        if (PlanillasFiscalesLA.RecibosPlanillas == null)
                        {
                            centralPlanillasFiscales.Ticket_ID = null;
                        }
                        else
                        {
                            Central.Entities.Tickets ticket = Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", PlanillasFiscalesLA.RecibosPlanillas.Recibo),
                                        Param("Estacion_ID", Estacion));

                            if (ticket != null)
                            {
                                centralPlanillasFiscales.Ticket_ID = ticket.Ticket_ID;
                            }
                        }

                        //  Mediante funcion
                        centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesLA.Precio);
                        centralPlanillasFiscales.Estacion_ID = PlanillasFiscalesLA.Estacion; // LA
                        centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesLA.Status;
                        centralPlanillasFiscales.Serie = PlanillasFiscalesLA.Serie;
                        centralPlanillasFiscales.Folio = PlanillasFiscalesLA.Folio;
                        centralPlanillasFiscales.Precio = PlanillasFiscalesLA.Precio;
                        centralPlanillasFiscales.Fecha = PlanillasFiscalesLA.FechaAlta;


                        if (Central.DB.Exists("PlanillasFiscales", Param("Estacion_ID", PlanillasFiscalesLA.Estacion),
                            Param("Serie", PlanillasFiscalesLA.Serie), Param("Folio", PlanillasFiscalesLA.Folio)))
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

            public void _SyncPlanillasFiscales()
            {                
                IEnumerable<int> estaciones = LA.DB.QueryList<int>("SELECT DISTINCT Estacion FROM PlanillasFiscales", "Estacion");

                foreach (int estacion in estaciones)
                {
                    IEnumerable<string> series = 
                        LA.DB.QueryList<string>("SELECT DISTINCT Serie FROM PlanillasFiscales WHERE Estacion = " + estacion.ToString(), "Serie");

                    foreach (string serie in series)
                    {
                        //  Obtener el ultimo folio de planilla fiscal para dicha estación y serie
                        //  Ejecutar el read
                        string filter = "Estacion = @Estacion AND Serie = @Serie AND Folio > @Folio";
                        string sort = "Folio ASC";
                        string sqlQry = "SELECT ISNULL(MAX(Folio),0) Folio FROM PlanillasFiscales WHERE Estacion_ID = @Estacion_ID AND Serie = @Serie";

                        LA.Entities.PlanillasFiscales PlanillasFiscalesLA;
                        int folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, LA.DB.GetParams(Param("@Estacion_ID", estacion),Param("@Serie",serie))));

                        while (LA.Entities.PlanillasFiscales.Read(out PlanillasFiscalesLA, 1, filter, sort, 
                            Param("@Estacion", estacion),Param("@Serie",serie), Param("@Folio", folio)))
                        {
                            Central.Entities.PlanillasFiscales centralPlanillasFiscales = new Central.Entities.PlanillasFiscales();
                            folio = PlanillasFiscalesLA.Folio;                            

                            if (PlanillasFiscalesLA.RecibosPlanillas == null)
                            {
                                centralPlanillasFiscales.Ticket_ID = null;
                            }
                            else
                            {
                                centralPlanillasFiscales.Ticket_ID =
                                    Central.Entities.Tickets.Read(
                                        Param("Referencia_ID", PlanillasFiscalesLA.RecibosPlanillas.Recibo),
                                            Param("Estacion_ID", Estacion)).Ticket_ID;
                            }

                            //  Mediante funcion
                            centralPlanillasFiscales.Denominacion = DenominacionPlanillas(PlanillasFiscalesLA.Precio);
                            centralPlanillasFiscales.Estacion_ID = estacion; // LA
                            centralPlanillasFiscales.EstatusPlanillaFiscal_ID = PlanillasFiscalesLA.Status;
                            centralPlanillasFiscales.Serie = serie;
                            centralPlanillasFiscales.Folio = folio;
                            centralPlanillasFiscales.Precio = PlanillasFiscalesLA.Precio;
                            centralPlanillasFiscales.Fecha = PlanillasFiscalesLA.FechaAlta;


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

        
        
        
    }   //  End Class

}   //  End Namespace