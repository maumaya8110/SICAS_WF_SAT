using System;
using System.Data;
using System.IO;

namespace SICASBot.Sync
{
	public partial class Syncronization
	{
		public class SyncVentanillaUnica
		{
			private bool AmbientePROD
			{
				get
				{
					bool b = false;
					if (System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"] != null &&
						System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"].Length > 0)
						b = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"]);
					return b;
				}
			}

			private bool ConMK
			{
				get
				{
					bool b = false;
					if (System.Configuration.ConfigurationManager.AppSettings["IncluyeMK"] != null &&
						System.Configuration.ConfigurationManager.AppSettings["IncluyeMK"].Length > 0)
						b = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IncluyeMK"]);
					return b;
				}
			}

			#region Properties

			string USERNAME, PASSWORD;
			int CAJAEBSSA, EMPRESA, ESTACION, MERCADO, COMISIONEBS_ID;
			decimal COMISIONEBS;
			VentanillaUnica.VunicaWSSoapClient WS;

			#endregion

			private void DoLog(string entry)
			{
				entry = String.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1}", DateTime.Now, entry);
				Console.WriteLine(entry);
				
				System.IO.StreamWriter sw = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\logVU.txt", true);
				sw.WriteLine(entry);
				sw.Flush();
				sw.Close();
			}

			private int GetMoneda(int tarjeta)
			{
				int result = 1;

				switch (tarjeta)
				{
					case 0:
						result = 1;
						break;
					case 1:
						result = 7;
						break;
					case 2:
						result = 8;
						break;
					case 3:
						result = 9;
						break;
					case 4:
						result = 10;
						break;
				}

				return result;
			}

			private void GetComisionID(int zonaId)
			{
				//switch (zonaId)
				//{
				//    case 1:
				//        COMISIONEBS_ID = 52;  //Comision de 36 pesos para Zona 1
				//        break;
				//    case 2:
				//    case 3:
				//    case 4:
				//        COMISIONEBS_ID = 53;  //Comision de 37 pesos de la Zona 2 a la Zona 4
				//        break;
				//    case 5:
				//    case 11:
				//        COMISIONEBS_ID = 54;  //Comision de 38 pesos de la Zona 5 a la Zona 6
				//        break;
				//    case 12:
				//    case 13:
				//        COMISIONEBS_ID = 55;  //Comision de 39 pesos para la Zona 7 a la Zona 8
				//        break;
				//    case 14:
				//        COMISIONEBS_ID = 56;  //Comision de 40 pesos de la Zona 9
				//        break;
				//    default:
				//        COMISIONEBS_ID = 19;  //Comision de 40 pesos para TODO el resto de la Zonas
				//        break;
				//}
				COMISIONEBS_ID = 55;
				Central.Entities.ComisionesServicios comision = Central.Entities.ComisionesServicios.Read(COMISIONEBS_ID);
				COMISIONEBS = comision.Monto;
			}

			public void DoSync()
			{
				DoLog("Inicio de sincronizacion de boletos Ventanilla Unica");

				Console.WriteLine("Descargando zonas");
				SyncZonas();
				Console.WriteLine("Zonas actualizadas");

				Console.WriteLine("Descargando servicios");
				SyncServicios();
				Console.WriteLine("Servicios actualizados");

				Console.WriteLine("Descargando cancelaciones");
				SyncCancelaciones();
				Console.WriteLine("Cancelaciones actualizadas");

				DoLog("Terminacion de sincronizacion de boletos Ventanilla Unica");
			}

			public void SyncCancelaciones()
			{
				try
				{
					DataSet ds = WS.CancelacionesDiariasPorEmpresa(USERNAME, PASSWORD);
					DataTable dt = ds.Tables[0];
					Central.Entities.Servicios servicio;

					foreach (DataRow dr in dt.Rows)
					{
						servicio = Central.Entities.Servicios.Read(dr["CODIGO"].ToString());
						servicio.EstatusServicio_ID = 4;
						servicio.Update();

						Console.WriteLine("Servicio {0} cancelado", servicio.Servicio_ID);
					}
				}
				catch (Exception ex)
				{
					DoLog(ex.Message);
				}
			}

			public SyncVentanillaUnica()
			{
				USERNAME = "CASCOWS";
				PASSWORD = "teamxtrem2007!";
				EMPRESA = 3;
				ESTACION = 5;
				MERCADO = 2;
				CAJAEBSSA = 10;
				//COMISIONEBS_ID = 19;
				WS = new VentanillaUnica.VunicaWSSoapClient();

				//Central.Entities.ComisionesServicios comision =
				//    Central.Entities.ComisionesServicios.Read(COMISIONEBS_ID);

				//COMISIONEBS = comision.Monto;
			}

			public void SyncServicios()
			{
				try
				{
					DataSet ds = null;

					//if (ConMK)
						ds = WS.VentaDiariaPorEmpresa(USERNAME, PASSWORD);
					//else
					//     ds = WS.VentaDiariaPorEmpresaMKTest(USERNAME, PASSWORD);

					DataTable dt = ds.Tables[0];
					Central.Entities.Servicios servicio;

					foreach (DataRow dr in dt.Rows)
					{
						bool ExisteServicio =
						    Central.DB.Exists(
							   "Servicios",
							   Central.DB.Param("Servicio_ID", dr["CODIGO"])
						    );

						if (!ExisteServicio)
						{
							//  Insertar el servicio en la base de datos
							//  Obtener la zona
							Central.Entities.Zonas zona =
							    Central.Entities.Zonas.ReadByFolioEBSSA(
								   Central.DB.GetNullableInt32(dr["ZONA"])
							    );

							servicio = new Central.Entities.Servicios();
							servicio.Caja_ID = CAJAEBSSA;
							servicio.ClaseServicio_ID = 1;
							servicio.Precio = (decimal)dr["PRECIO"];
							if (servicio.Precio > 460)
							{
								servicio.TipoServicio_ID = 2;
							}
							else
							{
								servicio.TipoServicio_ID = 1;
							}
							servicio.Empresa_ID = EMPRESA;
							servicio.Estacion_ID = ESTACION;
							servicio.EstatusServicio_ID = 1;
							servicio.Fecha = (DateTime)dr["FECHA"];
							servicio.FechaExpiracion = servicio.Fecha.AddYears(1);
							servicio.FolioDiario = (int)dr["FOLIODIARIOEBSSA"];
							servicio.Mercado_ID = MERCADO;
							servicio.Moneda_ID = this.GetMoneda((int)dr["TIPOPAGO"]);
							servicio.Productividad = 1;
							servicio.Servicio_ID = dr["CODIGO"].ToString();
							servicio.Usuario_ID = "SICAS";
							servicio.Zona_ID = zona.Zona_ID;
							GetComisionID(zona.Zona_ID);
							servicio.PagoComisiones = COMISIONEBS;
							servicio.PagoConductor = servicio.Precio - COMISIONEBS;
							if (ConMK)
								servicio.Referencia_PayBack = dr["CLIENTE_MASTERKEY"].ToString();
							servicio.Create();

							Console.WriteLine("Servicio {0} actualizado", servicio.Servicio_ID);

							Central.Entities.Servicios_Comisiones serviciocomision =
							new Central.Entities.Servicios_Comisiones();
							serviciocomision.Servicio_ID = servicio.Servicio_ID;
							serviciocomision.ComisionServicio_ID = COMISIONEBS_ID;
							serviciocomision.Monto = COMISIONEBS;
							serviciocomision.Create();
						}
					} // endforeach            
				}
				catch (Exception ex)
				{
					DoLog(ex.Message);
				}
			}

			public void SyncZonas()
			{
				try
				{
					DataSet ds = WS.ZonasPorEmpresa(USERNAME, PASSWORD);
					DataTable dt = ds.Tables[0];
					Central.Entities.Zonas zona;

					foreach (DataRow dr in dt.Rows)
					{
						// if exist uppdate
						// if dont insert

						zona = Central.Entities.Zonas.ReadByFolioEBSSA(Central.DB.GetNullableInt32(dr["Folio"]));

						if (zona != null)
						{
							zona.Nombre = dr["DESCRIPCION"].ToString();
							zona.TipoZona_ID = (int)dr["TIPO"];
							zona.Update();
						}
						else
						{
							zona = new Central.Entities.Zonas();
							zona.Nombre = dr["DESCRIPCION"].ToString();
							zona.TipoZona_ID = (int)dr["TIPO"];
							zona.ComisionServicio_ID = null;
							zona.FolioEBSSA = (int)dr["FOLIO"];
							zona.Create();
						}

						Console.WriteLine("ZONA {0} actualizada", zona.Nombre);
					}
				}
				catch (Exception ex)
				{
					DoLog(ex.Message);
				}
			}
		}
	} // end class
} // end namespace
