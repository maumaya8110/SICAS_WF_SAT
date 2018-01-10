using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SICASBot
{
    class Program
    {
	   //static void VerificadorRentas()
	   //{
	   //    VerificarRentasEstacion(11, "Pablo Livas");
	   //    VerificarRentasEstacion(9, "Santa Catarina");
	   //    VerificarRentasEstacion(10, "Aztlan");
	   //}

//        static void VerificarRentasEstacion(int estacion_id, string Estacion)
//        {
//            Console.WriteLine("Verificando cobro de rentas");

//            string sql = @"SELECT	CC.CuentaConductor_ID,
//		CO.Apellidos + ' ' + CO.Nombre Conductor,
//		U.NumeroEconomico Unidad,
//		T.Ticket_ID,
//		E.Nombre Empresa,
//		EST.Nombre Estacion,
//		CA.Nombre Caja,
//		C.Nombre Cuenta,
//		CON.Nombre Concepto,
//		CC.Cargo,
//		CC.Abono,
//		CC.Saldo,
//		CC.Comentarios,		
//		CC.Fecha,
//		CC.Usuario_ID
//FROM	CuentaConductores CC
//	LEFT JOIN	Tickets T
//		ON		CC.Ticket_ID = T.Ticket_ID
//	INNER JOIN	Cuentas C
//		ON		CC.Cuenta_ID = C.Cuenta_ID
//	INNER JOIN	Empresas E
//		ON		CC.Empresa_ID = E.Empresa_ID
//	INNER JOIN	Estaciones EST
//		ON		CC.Estacion_ID = EST.Estacion_ID
//	LEFT JOIN	Cajas CA
//		ON		CC.Caja_ID = CA.Caja_ID
//	INNER JOIN	Conductores CO
//		ON		CC.Conductor_ID = CO.Conductor_ID
//	LEFT JOIN	Unidades U
//		ON		CC.Unidad_ID = U.Unidad_ID
//	INNER JOIN	Conceptos CON
//		ON		CC.Concepto_ID = CON.Concepto_ID		
//WHERE	 dbo.udf_DateValue(CC.Fecha) = dbo.udf_DateValue(GETDATE())
//and CC.Concepto_ID = 1
//and CC.Estacion_ID = @Estacion_ID";

//            sql = sql.Replace("@Estacion_ID", estacion_id.ToString());

//            System.Data.DataTable dt = Central.DB.Query(sql);
//            string body = "";
//            string title = "";

//            if (dt.Rows.Count > 0)
//            {
//                string table = AppHelper.GridExport.DataTableToHTML(dt);

//                title = "Rentas Cobradas Diarias";
//                body = string.Format(
//                    "<h3>Rentas Cobradas</h3><p>Estacion {1}, Dia {0:yyyy-MM-dd}</p>",
//                    DateTime.Now, Estacion) + table;
//            }
//            else
//            {
//                title = string.Format(
//                    "NO SE COBRARON RENTAS EN {0}",
//                    Estacion
//                );

//                body = string.Format(
//                    "Las rentas del día {0:yyyy-MM-dd} no fueron cobradas, en la estación {1}",
//                    DateTime.Today,
//                    Estacion
//                );
//            }
            
//            AppHelper.SendEmail(
//                "sicas@casco.com.mx", 
//                "sicas@casco.com.mx", 
//                title,
//                body, 
//                true
//            );

//            Console.WriteLine("Correo enviado " + Estacion);

//        }

        static void Main(string[] args)
        {
            //Sync.Syncronization.SyncLA syncLA = new Sync.Syncronization.SyncLA();
            //Sync.Syncronization.SyncApto syncApto = new Sync.Syncronization.SyncApto();
            //Sync.Syncronization.SyncAztlan syncAztlan = new Sync.Syncronization.SyncAztlan();
            //Sync.Syncronization.SyncPabloLivas syncPabloLivas = new Sync.Syncronization.SyncPabloLivas();
            //Sync.Syncronization.SynSantaCatarina syncSanta = new Sync.Syncronization.SynSantaCatarina();
            Sync.Syncronization.SyncVentanillaUnica syncVU = new Sync.Syncronization.SyncVentanillaUnica();

		  if (args.Length == 1 && args[0] == "-SyncZonas")
		  {
			  Console.WriteLine("Descargando zonas");
			  syncVU.SyncZonas();
			  Console.WriteLine("Zonas actualizadas");
		  }
		  else if (args.Length == 1 && args[0] == "-SyncServicios")
		  {
			  Console.WriteLine("Descargando servicios");
			  syncVU.SyncServicios();
			  Console.WriteLine("Servicios actualizados");
		  }
		  else if (args.Length == 1 && args[0] == "-SyncCancelaciones")
		  {
			  Console.WriteLine("Descargando cancelaciones");
			  syncVU.SyncCancelaciones();
			  Console.WriteLine("Cancelaciones actualizadas");
		  }
		  else if (args.Length == 1 && args[0] == "-SyncServsCancels")
		  {
			  Console.WriteLine("Descargando servicios");
			  syncVU.SyncServicios();
			  Console.WriteLine("Servicios actualizados");
			  Console.WriteLine("Descargando cancelaciones");
			  syncVU.SyncCancelaciones();
			  Console.WriteLine("Cancelaciones actualizadas");
		  }
		  else
		  {
			  syncVU.DoSync();
		  }

            //syncLA.SyncUpdateContratos();

            //AppHelper.ReconfigureUsuarios();
            //VerificadorRentas();
            //syncPabloLivas.SyncCuentaDepositosGarantia();
            //syncSanta.DoSyncMetro();
            //syncPabloLivas.SyncHistorialCobranzaConductores();
            //syncApto.DoSync();
            //syncAztlan.DoSyncMetro();
            //syncLA.SyncUpdateContratos();
            //syncLA.DoSyncTaller();

            //syncLA.SyncServiciosMantenimientosPrecios();
            //syncSanta.SyncHistorialCobranzaConductores();
            //syncAztlan.SyncHistorialCobranzaConductores();
            //syncLA.SyncUpdateContratos();
            //syncLA.SyncDetalleConductores();
            //Thread metroLAThread = new Thread(new ThreadStart(syncLA.DoSyncMetro));
            //metroLAThread.Start();

            //Thread aeroThread = new Thread(new ThreadStart(syncApto.DoSync));
            //aeroThread.Start();

            //Thread tallerThread = new Thread(new ThreadStart(syncLA.DoSyncTaller));
            //tallerThread.Start();

            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            //syncLA.DoSyncTaller();
            //Sync.Syncronization.SyncApto syncApto = new Sync.Syncronization.SyncApto();
            //syncApto.DoSync();

            /*
             * 1) Open thread SyncMetro
             * 2) Open thread SyncAero
             * 3) Open thread SyncTaller
             * 4) Do Infinite
            */
        }
    }
}
