using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SICASBot.Sync
{
    public partial class Syncronization
    {
        public class SyncApto
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

            private void _DoSync()
            {
                SyncUsuarios();
                SyncModelosUnidades();
                SyncConductores();
                SyncUnidades();
                SyncContratos();
                SyncSesiones();
                SyncCuentaCajas();
                SyncCuentaConductores();
                SyncTickets();
                SyncZonas();
                SyncServicios();
                SyncTarifas();
                SyncUnidades_Kilometrajes();
                SyncUnidades_Locaciones();
            }

            public void DoSync()
            {
                bool IsDebug = true;
                if (IsDebug)
                {
                    _DoSync();
                }
                else
                {
                    try
                    {
                        _DoSync();
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

            private int Estacion = 5; // LA
            private int Empresa = 3; // CAT

            private KeyValuePair<string, object> Param(string key, object value)
            {
                return new KeyValuePair<string, object>(key, value);
            }

            public void SyncTickets()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Tickets WHERE Estacion_ID = @Estacion";
                //sqlQry += " AND Fecha < '2011-06-15'";

                Apto.Entities.RecibosAeropuerto TicketsApto;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                int cont = Apto.DB.GetCount("RecibosAeropuerto");

                while (Apto.Entities.RecibosAeropuerto.Read(out TicketsApto, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = TicketsApto.Folio;

                    Central.Entities.Tickets centralTickets = new Central.Entities.Tickets();

                    centralTickets.Ticket_ID = 0;
                    centralTickets.Referencia_ID = folio;

                    //  Consultar la sesión por usuario y fecha
                    Apto.Entities.ControlCajas cc = Apto.Entities.ControlCajas.GetBy(TicketsApto.Fecha.Value, 1);
                    int sesionlocal = cc.Folio;
                    int sesion_id = Central.Entities.Sesiones.Read(Param("Referencia_ID", sesionlocal), Param("Estacion_ID", Estacion)).Sesion_ID;
                    centralTickets.Sesion_ID = sesion_id;

                    centralTickets.Caja_ID =
                        Central.Entities.Cajas.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", 1)).Caja_ID;
                    centralTickets.Usuario_ID = cc.Usuario;

                    centralTickets.EstatusTicket_ID = 1;

                    centralTickets.Empresa_ID = Empresa; // CAM
                    centralTickets.Estacion_ID = Estacion; // Apto

                    if (TicketsApto.Unidad == 0)
                    {
                        centralTickets.Unidad_ID = null;
                    }
                    else
                    {
                        centralTickets.Unidad_ID =
                        Central.Entities.Unidades.Read(Param("Estacion_ID", this.Estacion), Param("Referencia_ID", TicketsApto.Unidad)).Unidad_ID;
                    }

                    centralTickets.Conductor_ID =
                        Central.Entities.Conductores.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", TicketsApto.Conductor)).Conductor_ID;


                    centralTickets.Fecha = TicketsApto.Fecha.Value;

                    if (Central.DB.Exists("Tickets", Param("Ticket_ID", centralTickets.Ticket_ID)))
                    {
                        centralTickets.Update();
                    }
                    else
                    {
                        centralTickets.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Ticket_ID: {0} de {1}", folio, cont));
                }
            }	//	End Method SyncTickets


            public void SyncConductores()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Conductores WHERE Estacion_ID = @Estacion";

                Apto.Entities.Conductores ConductoresApto;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Apto.Entities.Conductores.Read(out ConductoresApto, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = ConductoresApto.Folio;

                    Central.Entities.Conductores centralConductores = new Central.Entities.Conductores();
                    centralConductores.Conductor_ID = 0;
                    centralConductores.Nombre = ConductoresApto.Nombre;
                    centralConductores.Apellidos = ConductoresApto.ApellidoPaterno + " " + ConductoresApto.ApellidoMaterno;
                    centralConductores.Domicilio = ConductoresApto.Calle + " No. " + ConductoresApto.NumeroCasa + ", Col. " + ConductoresApto.Colonia; ;
                    centralConductores.Ciudad = ConductoresApto.Municipio;
                    centralConductores.Entidad = ConductoresApto.Estado;
                    centralConductores.Telefono = ConductoresApto.Telefono;
                    centralConductores.Telefono2 = "";
                    centralConductores.Movil = "";
                    centralConductores.Email = ConductoresApto.CorreoElectronico;
                    centralConductores.RFC = "";
                    centralConductores.Estacion_ID = Estacion;
                    centralConductores.CURP = "";
                    centralConductores.CodigoPostal = "";
                    centralConductores.Fotografia = "";
                    centralConductores.EstatusConductor_ID = 1;
                    centralConductores.MedioPublicitario_ID = null;
                    centralConductores.CumplioPerfil = null;
                    centralConductores.Interesado = null;
                    centralConductores.Mercado_ID = 2; // Aeropuerto
                    centralConductores.Comentarios = "";
                    centralConductores.Edad = null;
                    centralConductores.EstadoCivil = null;
                    centralConductores.AñosExperiencia = null;
                    centralConductores.Genero = "M";
                    centralConductores.TipoLicencia_ID = null;
                    centralConductores.FolioLicencia = null;
                    centralConductores.VenceLicencia = null;
                    centralConductores.Rfc_Aval = null;
                    centralConductores.Apellidos_Aval = null;
                    centralConductores.Nombre_Aval = null;
                    centralConductores.Curp_Aval = null;
                    centralConductores.Domicilio_Aval = null;
                    centralConductores.Ciudad_Aval = null;
                    centralConductores.Estado_Aval = null;
                    centralConductores.CodigoPostal_Aval = null;
                    centralConductores.Telefono_Aval = null;
                    centralConductores.Email_Aval = null;
                    centralConductores.Solicitud = null;
                    centralConductores.ActaNacimiento = null;
                    centralConductores.CredencialElector = null;
                    centralConductores.CartaNoAntecedentes = null;
                    centralConductores.ComprobanteDomicilio = null;
                    centralConductores.CredencialElector_Aval = null;
                    centralConductores.ComprobanteDomicilio_Aval = null;
                    centralConductores.SaldoATratar = 0;
                    centralConductores.Cronocasco = false;
                    centralConductores.TerminalDatos = false;
                    centralConductores.BloquearConductor = false;
                    centralConductores.MensajeACaja = null;
                    centralConductores.Fecha = LA.DB.GetDate();
                    centralConductores.Usuario_ID = null;
                    centralConductores.Referencia_ID = ConductoresApto.Folio;


                    if (Central.DB.Exists("Conductores", Param("Conductor_ID", centralConductores.Conductor_ID)))
                    {
                        centralConductores.Update();
                    }
                    else
                    {
                        centralConductores.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Conductor_ID: {0}", centralConductores.Conductor_ID));
                }
            }	//	End Method SyncConductores

            public void SyncContratos()
            {
                int folio, cont = 0;
                List<Apto.Entities.Contratos> Contratos = Apto.Entities.Contratos.Read();

                foreach (Apto.Entities.Contratos ContratosApto in Contratos)
                {
                    folio = ContratosApto.Folio;

                    Central.Entities.Contratos centralContratos = new Central.Entities.Contratos();
                    centralContratos.Referencia_ID = folio;
                    centralContratos.Contrato_ID = 0;
                    centralContratos.Empresa_ID = Empresa; // CAT
                    centralContratos.Estacion_ID = Estacion;
                    centralContratos.TipoContrato_ID = 1; // Renta venta
                    centralContratos.Descripcion = ContratosApto.Folio.ToString();

                    int modeloLocal = Apto.Entities.Unidades.Read((int)ContratosApto.Unidad).Modelo;
                    int modelounidad_id =
                        Central.Entities.ModelosUnidades.Read(
                            Param("Referencia_ID", modeloLocal),
                                Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;
                    centralContratos.ModeloUnidad_ID = modelounidad_id;

                    //  Obtener plan
                    Apto.Entities.ConductoresPlanesDeRenta cpr = Apto.Entities.ConductoresPlanesDeRenta.Read((int)ContratosApto.Conductor);
                    if (cpr == null) continue;
                    decimal montodiario = Apto.Entities.PlanesDeRenta.Read(cpr.PlanDeRenta).CuotaRenta;
                    centralContratos.MontoDiario = montodiario;

                    int diasdecobro_id = (
                        Apto.Entities.PlanesDeRenta.Read(
                            Apto.Entities.ConductoresPlanesDeRenta.Read(
                                (int)ContratosApto.Conductor).PlanDeRenta).Domingo) ? 2 : 1;
                    centralContratos.DiasDeCobro_ID = diasdecobro_id; // Obtener del plan

                    centralContratos.FondoResidual = 0;

                    int conductor_id =
                        Central.Entities.Conductores.Read(
                            Param("Referencia_ID", ContratosApto.Conductor),
                                Param("Estacion_ID", Estacion)).Conductor_ID;
                    centralContratos.Conductor_ID = conductor_id;

                    int unidad_id = Central.Entities.Unidades.Read(Param("Referencia_ID", ContratosApto.Unidad),
                        Param("Estacion_ID", Estacion)).Unidad_ID;
                    centralContratos.Unidad_ID = unidad_id;

                    int numeroeconomico = Central.Entities.Unidades.Read(unidad_id).NumeroEconomico;
                    centralContratos.NumeroEconomico = numeroeconomico;

                    centralContratos.Cuenta_ID = 1; // Todos son de renta
                    centralContratos.Concepto_ID = 1; // Todos son de renta
                    centralContratos.FechaInicial = (DateTime)ContratosApto.FechaInicio;
                    centralContratos.FechaFinal = ContratosApto.FechaTerminacion;
                    centralContratos.EstatusContrato_ID = 1; // Todos estan activos
                    centralContratos.Comentarios = null;
                    centralContratos.ConductorCopia_ID = null;
                    centralContratos.CobroPermanente = (ContratosApto.FechaTerminacion == null) ? true : false;

                    if (Central.DB.Exists("Contratos",
                        Param("Referencia_ID", ContratosApto.Folio),
                        Param("Estacion_ID", Estacion)))
                    {
                        centralContratos.Update();
                    }
                    else
                    {
                        centralContratos.Create();
                    }

                    cont++;
                    Console.WriteLine(String.Format("Registro actualizado Contrato_ID: {0}, {1} de {2}", ContratosApto.Folio, cont, Contratos.Count));
                }

                List<Central.Entities.Contratos> ContratosCentral =
                    Central.Entities.Contratos.ReadList(Param("Estacion_ID", Estacion), Param("EstatusContrato_ID", 1));

                foreach (Central.Entities.Contratos Contrato in ContratosCentral)
                {
                    Console.WriteLine(string.Format("Buscando coincidencias contrato {0}", Contrato.Referencia_ID));
                    if (!Contratos.Exists(delegate(Apto.Entities.Contratos c) { return c.Folio == Contrato.Referencia_ID; }))
                    {
                        Contrato.EstatusContrato_ID = 11;
                        Contrato.Update();
                        Console.WriteLine(String.Format("Registro actualizado baja Contrato_ID: {0}", Contrato.Referencia_ID));
                    }
                }
            }	//	End Method SyncContratos

            private int GetConcepto(int conceptolocal)
            {
                int concepto = 0;
                switch (conceptolocal)
                {
                    case 1: concepto = 92; break;
                    case 2: concepto = 93; break;
                    case 3: concepto = 94; break;
                    case 4: concepto = 95; break;
                    case 5: concepto = 96; break;
                    case 6: concepto = 97; break;
                    case 7: concepto = 98; break;
                    case 8: concepto = 99; break;
                    case 9: concepto = 100; break;
                    case 10: concepto = 101; break;
                    case 11: concepto = 102; break;
                    case 12: concepto = 103; break;
                    case 13: concepto = 104; break;
                    case 14: concepto = 105; break;
                    case 15: concepto = 106; break;
                    case 16: concepto = 107; break;
                    case 17: concepto = 108; break;
                    case 18: concepto = 109; break;
                    case 19: concepto = 110; break;
                    case 20: concepto = 111; break;
                    case 21: concepto = 112; break;
                    case 22: concepto = 113; break;
                    case 23: concepto = 114; break;
                    case 24: concepto = 115; break;
                    case 25: concepto = 116; break;
                    case 26: concepto = 117; break;
                    case 27: concepto = 118; break;
                    case 28: concepto = 119; break;
                    case 29: concepto = 120; break;
                    case 30: concepto = 121; break;
                    case 31: concepto = 122; break;
                    case 32: concepto = 123; break;
                    case 33: concepto = 124; break;
                    case 34: concepto = 125; break;
                    case 35: concepto = 126; break;
                    case 36: concepto = 127; break;
                    case 37: concepto = 128; break;
                    case 38: concepto = 129; break;
                    case 39: concepto = 130; break;
                    case 40: concepto = 131; break;
                    case 41: concepto = 132; break;
                    case 42: concepto = 133; break;
                    case 43: concepto = 134; break;
                    case 44: concepto = 135; break;
                    case 45: concepto = 136; break;
                    case 46: concepto = 137; break;

                    case 47: concepto = 138; break;
                    case 48: concepto = 139; break;
                    case 49: concepto = 140; break;
                    case 50: concepto = 141; break;
                    case 51: concepto = 142; break;
                    case 52: concepto = 143; break;
                    case 53: concepto = 144; break;
                    case 54: concepto = 145; break;

                    case 55: concepto = 146; break;
                }
                return concepto;
            }
            private int GetCuenta(int fondocaja)
            {
                int cuenta = 0;
                switch (fondocaja)
                {
                    case 1: cuenta = 9; break;
                    case 2: cuenta = 11; break;
                    case 3: cuenta = 20; break;
                    case 4: cuenta = 12; break;
                    case 5: cuenta = 10; break;
                    case 6: cuenta = 13; break;
                    case 7: cuenta = 4; break;
                    case 8: cuenta = 21; break;
                    case 9: cuenta = 22; break;
                    case 10: cuenta = 23; break;
                    case 11: cuenta = 24; break;
                    case 12: cuenta = 25; break;
                    case 13: cuenta = 26; break;
                    case 14: cuenta = 27; break;
                    case 15: cuenta = 28; break;
                    case 16: cuenta = 29; break;
                    case 17: cuenta = 30; break;
                    case 18: cuenta = 1; break;
                    case 19: cuenta = 14; break;
                    case 20: cuenta = 15; break;
                    case 21: cuenta = 16; break;
                    case 22: cuenta = 17; break;
                    case 23: cuenta = 18; break;
                    case 24: cuenta = 19; break;
                    case 25: cuenta = 32; break;

                    case 26: cuenta = 33; break;
                    case 27: cuenta = 34; break;
                    case 28: cuenta = 35; break;
                }
                return cuenta;
            }
            private int GetCuentaFromCuenta(int cta)
            {
                int cuenta = 0;
                switch (cta)
                {
                    case 1: cuenta = 9; break;
                    case 2: cuenta = 10; break;
                    case 3: cuenta = 11; break;
                    case 4: cuenta = 4; break;
                    case 5: cuenta = 12; break;
                    case 6: cuenta = 13; break;
                    case 7: cuenta = 14; break;
                    case 8: cuenta = 14; break;
                    case 10: cuenta = 1; break;
                    case 11: cuenta = 15; break;
                    case 12: cuenta = 16; break;
                    case 13: cuenta = 17; break;
                    case 14: cuenta = 18; break;
                    case 15: cuenta = 19; break;
                    case 16: cuenta = 32; break;
                    case 18: cuenta = 33; break;
                    case 19: cuenta = 34; break;
                    case 20: cuenta = 35; break;

                }
                return cuenta;
            }
            private int? ConceptoDeOperacion(int operacion)
            {
                int? concepto = null;
                switch (operacion)
                {
                    case 15: concepto = 92; break;
                    case 16: concepto = 100; break;
                    case 17: concepto = 95; break;
                    case 19: concepto = 97; break;
                    case 20: concepto = 102; break;
                    case 21: concepto = 103; break;
                    case 22: concepto = 105; break;
                    case 23: concepto = 92; break;
                    case 24: concepto = null; break;
                    case 26: concepto = 98; break;
                    case 27: concepto = 92; break;
                    case 28: concepto = null; break;
                    case 29: concepto = 92; break;
                    case 30: concepto = 92; break;
                    case 31: concepto = 92; break;
                    case 32: concepto = 92; break;
                    case 33: concepto = 92; break;
                    case 34: concepto = 92; break;
                    case 35: concepto = 92; break;
                    case 36: concepto = 124; break;
                    case 37: concepto = 123; break;
                    case 38: concepto = null; break;
                    case 39: concepto = 126; break;
                    case 41: concepto = 128; break;
                    case 42: concepto = 130; break;
                    case 43: concepto = 132; break;
                    case 44: concepto = 134; break;
                    case 45: concepto = 136; break;

                    case 46: concepto = 140; break;
                    case 47: concepto = 142; break;
                    case 48: concepto = 144; break;
                    case 49: concepto = 145; break;

                }

                return concepto;
            }

            public void SyncCuentaCajas()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaCajas WHERE Estacion_ID = @Estacion";

                Apto.Entities.MovimientosCaja CuentaCajasApto;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                int cont = Apto.DB.GetCount("MovimientosCaja");

                while (Apto.Entities.MovimientosCaja.Read(out CuentaCajasApto, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaCajasApto.Folio;
                    if (CuentaCajasApto.Caja != 1) { continue; }

                    Central.Entities.CuentaCajas centralCuentaCajas = new Central.Entities.CuentaCajas();
                    centralCuentaCajas.CuentaCaja_ID = 0;

                    Apto.Entities.ControlCajas cc = Apto.Entities.ControlCajas.Read("@Fecha BETWEEN FechaInicioCaja AND FechaCorteCaja",
                            Param("@Fecha", CuentaCajasApto.Fecha));
                    if (cc == null)
                    {
                        centralCuentaCajas.Sesion_ID = null;
                    }
                    else
                    {
                        Central.Entities.Sesiones s = Central.Entities.Sesiones.Read(
                            Param("Referencia_ID", cc.Folio),
                                Param("Estacion_ID", Estacion));
                        if (s == null)
                        {
                            centralCuentaCajas.Sesion_ID = null;
                        }
                        else
                        {
                            centralCuentaCajas.Sesion_ID = s.Sesion_ID;
                        }
                    }

                    centralCuentaCajas.Empresa_ID = Empresa;
                    centralCuentaCajas.Estacion_ID = Estacion;
                    centralCuentaCajas.Caja_ID = 3; // CAJA APTO LA
                    centralCuentaCajas.Ticket_ID = null; // No esta supeditada a un ticket
                    centralCuentaCajas.Referencia_ID = folio;

                    //  La cuenta a partir del fondo
                    //  El concepto a partir de la operación de caja
                    centralCuentaCajas.Cuenta_ID = this.GetCuenta(CuentaCajasApto.FondoCaja); // Obtener de fondo caja

                    centralCuentaCajas.Concepto_ID = ConceptoDeOperacion(CuentaCajasApto.Operacion); // Obtener de fondo caja y operación

                    decimal cargo, abono;
                    if (CuentaCajasApto.Monto < 0)
                    {
                        cargo = Math.Abs(CuentaCajasApto.Monto);
                        abono = 0;
                    }
                    else
                    {
                        abono = Math.Abs(CuentaCajasApto.Monto);
                        cargo = 0;
                    }

                    centralCuentaCajas.Cargo = cargo;
                    centralCuentaCajas.Abono = abono;
                    centralCuentaCajas.Saldo = 0; // Es calculado, incluido en el calculo

                    centralCuentaCajas.Comentarios = CuentaCajasApto.Motivo;
                    centralCuentaCajas.Fecha = CuentaCajasApto.Fecha;
                    centralCuentaCajas.Usuario_ID = CuentaCajasApto.Usuario;


                    if (Central.DB.Exists("CuentaCajas", Param("CuentaCaja_ID", centralCuentaCajas.CuentaCaja_ID)))
                    {
                        centralCuentaCajas.Update();
                    }
                    else
                    {
                        centralCuentaCajas.Create();
                    }

                    //Console.WriteLine(String.Format("Registro actualizado CuentaCaja_ID: {0}", centralCuentaCajas.CuentaCaja_ID));
                    Console.WriteLine(String.Format("Cuenta Caja ID {0} de {1}", folio, cont));
                }
            }	//	End Method SyncCuentaCajas

            public void SyncCuentaConductores()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM CuentaConductores WHERE Estacion_ID = @Estacion";

                Apto.Entities.CuentaConductor CuentaConductoresApto;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Apto.Entities.CuentaConductor.Read(out CuentaConductoresApto, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = CuentaConductoresApto.Folio;

                    Central.Entities.CuentaConductores centralCuentaConductores = new Central.Entities.CuentaConductores();
                    centralCuentaConductores.CuentaConductor_ID = 0;
                    centralCuentaConductores.Empresa_ID = Empresa; // CAT
                    centralCuentaConductores.Estacion_ID = Estacion; // CAT

                    int conductor_id =
                        Central.Entities.Conductores.Read(
                            Param("Referencia_ID", CuentaConductoresApto.Conductor),
                                Param("Estacion_ID", Estacion)).Conductor_ID;
                    centralCuentaConductores.Conductor_ID = conductor_id;

                    Central.Entities.Unidades uni = Central.Entities.Unidades.Read(Param("Referencia_ID", CuentaConductoresApto.Unidad),
                        Param("Estacion_ID", Estacion));

                    if (uni != null)
                    {
                        int unidad_id = uni.Unidad_ID;
                        centralCuentaConductores.Unidad_ID = unidad_id;
                    }
                    else
                    {
                        centralCuentaConductores.Unidad_ID = null;
                    }

                    centralCuentaConductores.Caja_ID = (int?)AppHelper.Iif((CuentaConductoresApto.Caja == 1), 1, null);
                    centralCuentaConductores.Ticket_ID = null;

                    //  Obtener cuenta del concepto
                    int cuenta = Apto.Entities.Conceptos.Read(CuentaConductoresApto.Concepto).Cuenta;
                    int cuenta_id = GetCuentaFromCuenta(cuenta);
                    centralCuentaConductores.Cuenta_ID = cuenta_id;

                    //  Efectuar la traducción directa del concepto
                    int concepto_id = GetConcepto(CuentaConductoresApto.Concepto);
                    centralCuentaConductores.Concepto_ID = concepto_id;

                    //  Si es menor a 0 es Cargo, contrario es abono
                    decimal cargo, abono;
                    if (CuentaConductoresApto.Monto < 0)
                    {
                        cargo = Math.Abs(CuentaConductoresApto.Monto);
                        abono = 0;
                    }
                    else
                    {
                        abono = Math.Abs(CuentaConductoresApto.Monto);
                        cargo = 0;
                    }

                    centralCuentaConductores.Cargo = cargo;
                    centralCuentaConductores.Abono = abono;
                    centralCuentaConductores.Saldo = 0; // Es calculado

                    centralCuentaConductores.Comentarios = CuentaConductoresApto.Comentario;
                    centralCuentaConductores.Fecha = CuentaConductoresApto.Fecha;
                    centralCuentaConductores.Usuario_ID = CuentaConductoresApto.Usuario;
                    centralCuentaConductores.Referencia_ID = folio;


                    if (Central.DB.Exists("CuentaConductores", Param("CuentaConductor_ID", centralCuentaConductores.CuentaConductor_ID)))
                    {
                        centralCuentaConductores.Update();
                    }
                    else
                    {
                        centralCuentaConductores.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado CuentaConductor_ID: {0}", folio));
                }

            }	//	End Method SyncCuentaConductores

            public void SyncEstatusServicios()
            {
                List<Apto.Entities.StatusBoletos> estatusserviciosApto = Apto.Entities.StatusBoletos.Read();
                foreach (Apto.Entities.StatusBoletos EstatusServiciosApto in estatusserviciosApto)
                {
                    Central.Entities.EstatusServicios centralEstatusServicios = new Central.Entities.EstatusServicios();
                    centralEstatusServicios.EstatusServicio_ID = EstatusServiciosApto.Folio;
                    centralEstatusServicios.Nombre = EstatusServiciosApto.Descripcion;


                    if (Central.DB.Exists("EstatusServicios", Param("EstatusServicio_ID", centralEstatusServicios.EstatusServicio_ID)))
                    {
                        centralEstatusServicios.Update();
                    }
                    else
                    {
                        centralEstatusServicios.Create();
                    }
                }	//	End foreach

            }	//	End Method SyncEstatusServicios

            public void SyncModelosUnidades()
            {
                List<Apto.Entities.ModelosUnidades> modelosunidadesApto = Apto.Entities.ModelosUnidades.Read();
                foreach (Apto.Entities.ModelosUnidades ModelosUnidadesApto in modelosunidadesApto)
                {
                    Central.Entities.ModelosUnidades centralModelosUnidades = new Central.Entities.ModelosUnidades();
                    centralModelosUnidades.ModeloUnidad_ID = 0;
                    centralModelosUnidades.MarcaUnidad_ID = ModelosUnidadesApto.Marca; // Traducir la marca
                    centralModelosUnidades.Descripcion = ModelosUnidadesApto.Descripcion;
                    centralModelosUnidades.PrecioLista = ModelosUnidadesApto.PrecioLista;
                    centralModelosUnidades.Anio = ModelosUnidadesApto.Anyo;
                    centralModelosUnidades.Deposito = 0;
                    centralModelosUnidades.Activo = true;
                    centralModelosUnidades.referencia_id = ModelosUnidadesApto.Folio;
                    centralModelosUnidades.EmpresaReferencia = Estacion;


                    if (Central.DB.Exists(
                                "ModelosUnidades",
                                Param("EmpresaReferencia", Estacion),
                                Param("Referencia_id", centralModelosUnidades.referencia_id)
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

            private int EstatusUnidad(int status)
            {
                int estatusunidad = 2;
                switch (status)
                {
                    case 1: estatusunidad = 2; break;
                    case 2: estatusunidad = 5; break;
                    case 3: estatusunidad = 10; break;
                }

                return estatusunidad;
            }

            public void SyncUnidades()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Unidades WHERE Estacion_ID = @Estacion";

                Apto.Entities.Unidades UnidadesApto;
                int folio;

                folio = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Apto.Entities.Unidades.Read(out UnidadesApto, 1, filter, sort, Param("Folio", folio)))
                {
                    folio = UnidadesApto.Folio;

                    Central.Entities.Unidades centralUnidades = new Central.Entities.Unidades();
                    centralUnidades.Unidad_ID = 0;
                    centralUnidades.Empresa_ID = Empresa; // CAT
                    centralUnidades.Estacion_ID = Estacion; // CAT
                    centralUnidades.NumeroEconomico = UnidadesApto.NumeroEconomico;

                    //  Obtener el equivalente en modelo
                    centralUnidades.ModeloUnidad_ID =
                        Central.Entities.ModelosUnidades.Read(
                            Param("Referencia_ID", UnidadesApto.Modelo), Param("EmpresaReferencia", Estacion)).ModeloUnidad_ID;

                    centralUnidades.PrecioLista = Apto.Entities.ModelosUnidades.Read(UnidadesApto.Modelo).PrecioLista;
                    centralUnidades.NumeroSerie = UnidadesApto.NumeroSerie;
                    centralUnidades.NumeroSerieMotor = UnidadesApto.NumeroSerieMotor;
                    centralUnidades.TarjetaCirculacion = UnidadesApto.TarjetaCirculacion;

                    //   Efectuar la conversión
                    centralUnidades.EstatusUnidad_ID = EstatusUnidad((int)UnidadesApto.Status);

                    //int locacion = Apto.Entities.RegistroLocacionesUnidades.Read()[0].Locacion;
                    //int locacion_id = Central.Entities.LocacionesUnidades.Read()[0].LocacionUnidad_ID;
                    centralUnidades.LocacionUnidad_ID = 1;

                    centralUnidades.Placas = UnidadesApto.Placas;

                    //int kilometraje = Apto.Entities.KilometrajesUnidades.Read(Param("Unidad", UnidadesApto.Folio)).Kilometraje;
                    centralUnidades.Kilometraje = 0;

                    centralUnidades.Propietario_ID = Empresa; // Todas son de cat
                    centralUnidades.Arrendamiento_ID = null;
                    centralUnidades.Concesion_ID = null;
                    centralUnidades.Referencia_ID = UnidadesApto.Folio;


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

                string sqlQry = "SELECT ISNULL(MAX(Fecha),0) fecha FROM Unidades_Kilometrajes " +
                    "WHERE Unidad_ID IN ( SELECT Unidad_ID FROM Unidades WHERE Estacion_ID = @Estacion )";

                Apto.Entities.KilometrajesUnidades Unidades_KilometrajesApto;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));
                int cont = Apto.DB.GetCount("KilometrajesUnidades");

                Hashtable data = new Hashtable();
                data.Add("Estacion_ID", Estacion);
                int current = 0;

                while (Apto.Entities.KilometrajesUnidades.Read(out Unidades_KilometrajesApto, 1, filter, sort, Param("Fecha", fecha)))
                {
                    current++;

                    fecha = Unidades_KilometrajesApto.Fecha;

                    Central.Entities.Unidades_Kilometrajes centralUnidades_Kilometrajes = new Central.Entities.Unidades_Kilometrajes();
                    centralUnidades_Kilometrajes.Unidad_Kilometraje_ID = 0;

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", Unidades_KilometrajesApto.Unidad),
                        Param("Estacion_ID", Estacion));

                    if (unidad == null) { continue; }

                    int unidad_id = unidad.Unidad_ID;

                    centralUnidades_Kilometrajes.Unidad_ID = unidad_id; // Obtener de unidades

                    centralUnidades_Kilometrajes.Conductor_ID = null; //    Debe poder ser null // Obtener de unidades conductores
                    centralUnidades_Kilometrajes.Kilometraje = Unidades_KilometrajesApto.Kilometraje;
                    centralUnidades_Kilometrajes.Fecha = Unidades_KilometrajesApto.Fecha;


                    if (Central.DB.Exists("Unidades_Kilometrajes", Param("Unidad_Kilometraje_ID", centralUnidades_Kilometrajes.Unidad_Kilometraje_ID)))
                    {
                        centralUnidades_Kilometrajes.Update();
                    }
                    else
                    {
                        centralUnidades_Kilometrajes.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Unidad_Kilometraje_ID  unidad: {0}, {1} de {2}",
                        centralUnidades_Kilometrajes.Unidad_ID, current, cont));
                }
            }	//	End Method SyncUnidades_Kilometrajes


            private int GetLocacion(int locacion)
            {
                int res = 0;
                switch (locacion)
                {
                    case 1: res = 15; break;
                    case 2: res = 3; break;
                    case 3: res = 8; break;
                    case 4: res = 20; break;
                    case 5: res = 23; break;
                    case 6: res = 25; break;
                    case 7: res = 24; break;
                }

                return res;
            }

            public void SyncUnidades_Locaciones()
            {
                string filter = "Fecha > @Fecha";

                string sort = "Fecha ASC";

                string sqlQry = "SELECT ISNULL(MAX(Fecha),0) fecha FROM Unidades_Locaciones " +
                    "WHERE Unidad_ID IN ( SELECT Unidad_ID FROM Unidades WHERE Estacion_ID = @Estacion )";

                Apto.Entities.UnidadesLocaciones Unidades_LocacionesApto;
                DateTime fecha;

                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Apto.Entities.UnidadesLocaciones.Read(out Unidades_LocacionesApto, 1, filter, sort, Param("Fecha", fecha)))
                {
                    fecha = (DateTime)Unidades_LocacionesApto.Fecha;

                    Central.Entities.Unidades_Locaciones centralUnidades_Locaciones = new Central.Entities.Unidades_Locaciones();
                    centralUnidades_Locaciones.Unidad_Locacion_ID = 0;

                    Central.Entities.Unidades unidad = Central.Entities.Unidades.Read(Param("Referencia_ID", Unidades_LocacionesApto.Unidad),
                        Param("Estacion_ID", Estacion));

                    if (unidad == null) { continue; }

                    int unidad_id = unidad.Unidad_ID;

                    centralUnidades_Locaciones.Unidad_ID = unidad_id;

                    centralUnidades_Locaciones.LocacionUnidad_ID = GetLocacion(Unidades_LocacionesApto.Locacion); // Obtener de unidades

                    centralUnidades_Locaciones.Fecha = (DateTime)Unidades_LocacionesApto.Fecha;

                    if (Central.DB.Exists("Unidades_Locaciones", Param("Unidad_Locacion_ID", centralUnidades_Locaciones.Unidad_Locacion_ID)))
                    {
                        centralUnidades_Locaciones.Update();
                    }
                    else
                    {
                        centralUnidades_Locaciones.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Fecha: {0}", centralUnidades_Locaciones.Fecha));
                }
            }	//	End Method SyncUnidades_Locaciones

            public void SyncUsuarios()
            {
                List<Apto.Entities.Usuarios> usuariosApto = Apto.Entities.Usuarios.Read();
                foreach (Apto.Entities.Usuarios UsuariosApto in usuariosApto)
                {
                    Central.Entities.Usuarios centralUsuarios = new Central.Entities.Usuarios();
                    centralUsuarios.Usuario_ID = UsuariosApto.Clave;
                    centralUsuarios.Nombre = UsuariosApto.Nombre;
                    centralUsuarios.Apellidos = UsuariosApto.ApellidoPaterno + " " + UsuariosApto.ApellidoMaterno;
                    centralUsuarios.Email = "";
                    centralUsuarios.Activo = UsuariosApto.Status == 1 ? true : false;
                    centralUsuarios.pwd = Apto.DB.PwdEncrypt(UsuariosApto.Pwd);
                    centralUsuarios.Empresa_ID = Empresa;
                    centralUsuarios.Estacion_ID = Estacion;

                    if (Central.DB.Exists("Usuarios", Param("Usuario_ID", centralUsuarios.Usuario_ID)))
                    {
                        centralUsuarios.Update();
                    }
                    else
                    {
                        centralUsuarios.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Usuario_ID: {0}", centralUsuarios.Usuario_ID));
                    AppHelper.ReconfigureUsuarios();
                }	//	End foreach

            }	//	End Method SyncUsuarios

            public void SyncTarifas()
            {
                List<Apto.Entities.Tarifas> tarifasApto = Apto.Entities.Tarifas.Read();
                foreach (Apto.Entities.Tarifas TarifasApto in tarifasApto)
                {
                    Central.Entities.Tarifas centralTarifas = new Central.Entities.Tarifas();
                    centralTarifas.Zona_ID = TarifasApto.Zona;
                    centralTarifas.TipoServicio_ID = TarifasApto.TipoServicio; // verificar referencia
                    centralTarifas.Tarifa = TarifasApto.Tarifa;

                    if (Central.DB.Exists("Tarifas", Param("Zona_ID", centralTarifas.Zona_ID)))
                    {
                        centralTarifas.Update();
                    }
                    else
                    {
                        centralTarifas.Create();
                    }

                    Console.WriteLine(String.Format("Registro actualizado Zona_ID: {0}", centralTarifas.Zona_ID));
                }	//	End foreach

            }	//	End Method SyncTarifas

            private int GetMoneda(int tipopago)
            {
                int moneda = 1;
                switch (tipopago)
                {
                    case 0: moneda = 1; break;
                    case 1: moneda = 7; break;
                    case 2: moneda = 8; break;
                    case 3: moneda = 9; break;
                    case 4: moneda = 10; break;
                    case 5: moneda = 11; break;
                    case 6: moneda = 12; break;
                    case 7: moneda = 13; break;
                    case 8: moneda = 14; break;
                    case 9: moneda = 15; break;
                    case 10: moneda = 16; break;
                    case 11: moneda = 17; break;
                    case 12: moneda = 18; break;
                    case 13: moneda = 4; break;
                    case 14: moneda = 20; break;
                    case 15: moneda = 21; break;
                    case 16: moneda = 3; break;
                }
                return moneda;
            }

            private int GetCaja(int caja)
            {
                int result = 0;
                switch (caja)
                {
                    case 1: result = 3; break;
                    case 3: result = 10; break;
                    case 4: result = 4; break;
                }
                return result;
            }

            private void SyncPagoBoletos()
            {
                List<Apto.Entities.PagoBoletos> PagoBoletos =
                    Apto.Entities.PagoBoletos.Read(
                        @"FechaCarreraLocal > DATEADD(dd,-1,GETDATE())",
                        null,
                        null
                    );

                Central.Entities.Servicios servicio;

                foreach (Apto.Entities.PagoBoletos pago in PagoBoletos)
                {
                    servicio = Central.Entities.Servicios.Read(pago.Boleto);
                    servicio.FechaPago = pago.Fecha;
                    servicio.Productividad = pago.CarrerasValidas;
                    servicio.PagoConductor = pago.PagoConductor;
                    servicio.PagoComisiones = pago.Precio - pago.PagoConductor;
                    servicio.Ticket_ID =
                        Central.Entities.Tickets.Read(
                            Param("Referencia_ID", pago.Recibo),
                                Param("Estacion_ID", Estacion)).Ticket_ID;
                    servicio.EstatusServicio_ID = 3;
                    servicio.Update();

                    Console.WriteLine(string.Format("Carrera actualizada {0}"));
                }
            }

            private void SyncCarreras()
            {
                List<Apto.Entities.CarrerasAeropuerto> Carreras =
                    Apto.Entities.CarrerasAeropuerto.Read(
                        @"FechaCarreraLocal > DATEADD(dd,-1,GETDATE())
AND FechaCarreraLocal IS NOT NULL", 
                        null, 
                        null
                    );

                Central.Entities.Servicios servicio;

                foreach (Apto.Entities.CarrerasAeropuerto carrera in Carreras)
                {
                    servicio = Central.Entities.Servicios.Read(carrera.Boleto);
                    servicio.Unidad_ID = 
                        Central.Entities.Unidades.Read(
                            Param("Referencia_ID", carrera.Unidad), 
                            Param("Estacion_ID", Estacion)
                        ).Unidad_ID;
                    servicio.Conductor_ID =
                        Central.Entities.Conductores.Read(
                            Param("Referencia_ID", carrera.Unidad),
                            Param("Estacion_ID", Estacion)
                        ).Conductor_ID;
                    servicio.FechaServicio = carrera.FechaCarreraLocal;
                    servicio.EstatusServicio_ID = 2;
                    servicio.Update();

                    Console.WriteLine(string.Format("Carrera actualizada {0}"));
                }
            }

            private void SyncBoletosSinPagar()
            {
                int maxRecibo;
                maxRecibo = Convert.ToInt32(Apto.DB.QueryScalar("SELECT MAX(Folio) FROM RecibosAeropuerto"));

                List<Apto.Entities.BoletosAeropuerto> Boletos;

                List<DateTime> fechas =
                    (List<DateTime>)Apto.DB.QueryList<DateTime>(
                    @"SELECT DISTINCT Fecha 
FROM BoletosAeropuerto 
WHERE Fecha >= '2011-01-01'
AND	Status = 2",
                    "Fecha");

                int cont = fechas.Count;

                Apto.Entities.TarifasPredefinidas tp = Apto.Entities.TarifasPredefinidas.Read()[0];

                foreach (DateTime f in fechas)
                {

                    Boletos = Apto.Entities.BoletosAeropuerto.Read(Param("Fecha", f));

                    foreach (Apto.Entities.BoletosAeropuerto ServiciosApto in Boletos)
                    {
                        Central.Entities.Servicios centralServicios = new Central.Entities.Servicios();
                        centralServicios.Servicio_ID = ServiciosApto.Codigo;
                        centralServicios.Mercado_ID = 2; // Aeropuerto
                        centralServicios.Empresa_ID = Empresa; // CAT
                        centralServicios.Estacion_ID = Estacion; // Apto Mty
                        centralServicios.Caja_ID = (ServiciosApto.Caja == null) ? null : new Nullable<int>(GetCaja(ServiciosApto.Caja.Value)); // Verificar                    
                        centralServicios.Zona_ID = ServiciosApto.Zona;
                        centralServicios.ClaseServicio_ID = ServiciosApto.ClaseServicio;
                        centralServicios.TipoServicio_ID = ServiciosApto.TipoServicio;
                        centralServicios.TipoServicioConductor_ID = null;
                        centralServicios.Moneda_ID = GetMoneda(ServiciosApto.TipoPago);
                        centralServicios.EstatusServicio_ID = ServiciosApto.Status;

                        if (ServiciosApto.ControlCaja == null)
                        {
                            centralServicios.Sesion_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Sesiones.Read(
                                    Param("Referencia_ID", ServiciosApto.ControlCaja.Folio),
                                        Param("Estacion_ID", Estacion)).Sesion_ID;
                        }

                        if (ServiciosApto.Carrera == null)
                        {
                            centralServicios.Unidad_ID = null;
                            centralServicios.Conductor_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Unidades.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Unidad),
                                        Param("Estacion_ID", Estacion)).Unidad_ID;

                            centralServicios.Conductor_ID =
                                Central.Entities.Conductores.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Conductor),
                                        Param("Estacion_ID", Estacion)).Conductor_ID;
                        }

                        centralServicios.Usuario_ID = (string.IsNullOrEmpty(ServiciosApto.Usuario)) ? "SICAS" : ServiciosApto.Usuario;
                        centralServicios.Cliente_ID = null;
                        centralServicios.TipoVenta_ID = null; // De acuerdo a codigo
                        centralServicios.Cuenta_ID = null; // De acuerdo solo para tipo boletos especiales, caso contrario, siempre a la misma cuenta
                        centralServicios.FolioDiario = ServiciosApto.FolioDiario;
                        centralServicios.Precio = ServiciosApto.Precio;
                        centralServicios.Fecha = ServiciosApto.Fecha;
                        centralServicios.FechaServicio = (ServiciosApto.Carrera == null) ? null : (DateTime?)(ServiciosApto.Carrera.FechaCarreraLocal);
                        centralServicios.FechaExpiracion = null;

                        if (ServiciosApto.Pago == null)
                        {
                            centralServicios.FechaPago = null;
                            centralServicios.Productividad = null;
                            centralServicios.Ticket_ID = null;

                            // Pago de conductor, Pago de comisiones
                            if (ServiciosApto.FolioDiarioEbssa != null)
                            {
                                centralServicios.PagoConductor = centralServicios.Precio - tp.TarifaEBSSA_CategoriaC;
                                centralServicios.PagoComisiones = tp.TarifaEBSSA_CategoriaC;
                            }
                            else
                            {
                                //  Si es regreso
                                Apto.Entities.BoletosRegresos regreso = Apto.Entities.BoletosRegresos.Read(centralServicios.Servicio_ID);
                                if (regreso != null)
                                {
                                    // Es regreso                                    
                                    centralServicios.PagoConductor = centralServicios.Precio - (tp.TarifaCascoRegresos.Value * 2);
                                    centralServicios.PagoComisiones = (tp.TarifaCascoRegresos.Value * 2);
                                }

                                //  Si es comisionada
                                Apto.Entities.Zonas zona = Apto.Entities.Zonas.Read(centralServicios.Zona_ID.Value);
                                if (zona.Comisionista != null)
                                {
                                    Apto.Entities.Comisionistas comisionista = Apto.Entities.Comisionistas.Read(zona.Comisionista.Value);
                                    centralServicios.PagoConductor -= (comisionista.PorcentajeComision / 100) * centralServicios.Precio;
                                    centralServicios.PagoComisiones += (comisionista.PorcentajeComision / 100) * centralServicios.Precio;
                                }

                                //  Si es compartida
                                Apto.Entities.CarrerasAeropuerto carrera = Apto.Entities.CarrerasAeropuerto.Read(centralServicios.Servicio_ID);
                                if (carrera != null)
                                {
                                    if (carrera.Compartida)
                                    {
                                        centralServicios.PagoConductor -= tp.TarifaCompartida;
                                        centralServicios.PagoComisiones += tp.TarifaCompartida;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (ServiciosApto.Pago.Recibo >= maxRecibo) return;

                            centralServicios.FechaPago = ServiciosApto.Pago.Fecha;
                            centralServicios.Productividad = ServiciosApto.Pago.CarrerasValidas;
                            centralServicios.PagoConductor = ServiciosApto.Pago.PagoConductor;
                            centralServicios.PagoComisiones = ServiciosApto.Pago.Precio - ServiciosApto.Pago.PagoConductor;
                            centralServicios.Ticket_ID =
                                Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", ServiciosApto.Pago.Recibo),
                                        Param("Estacion_ID", Estacion)).Ticket_ID;
                        }

                        if (Central.DB.Exists("Servicios", Param("Servicio_ID", centralServicios.Servicio_ID)))
                        {
                            centralServicios.Update();
                        }
                        else
                        {
                            centralServicios.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado boleto sin pagar Servicio_ID: {0}, {1} de {2}",
                            centralServicios.Servicio_ID, fechas.IndexOf(f), cont));
                    }
                }
            }


            private void SyncBoletos()
            {
                int maxRecibo;
                maxRecibo = Convert.ToInt32(Apto.DB.QueryScalar("SELECT MAX(Folio) FROM RecibosAeropuerto"));

                string sqlQry = "SELECT ISNULL(MAX(Fecha),'') Fecha FROM Servicios WHERE TipoServicioConductor_ID IS NULL";
                DateTime fecha;
                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry));
                List<Apto.Entities.BoletosAeropuerto> Boletos;

                List<DateTime> fechas =
                    (List<DateTime>)Apto.DB.QueryList<DateTime>(
                    "SELECT DISTINCT Fecha FROM BoletosAeropuerto WHERE Fecha >= @Fecha",
                    "Fecha",
                    Param("@Fecha", fecha));

                int cont = fechas.Count;

                Apto.Entities.TarifasPredefinidas tp = Apto.Entities.TarifasPredefinidas.Read()[0];

                foreach (DateTime f in fechas)
                {

                    Boletos = Apto.Entities.BoletosAeropuerto.Read(Param("Fecha", f));

                    foreach (Apto.Entities.BoletosAeropuerto ServiciosApto in Boletos)
                    {
                        Central.Entities.Servicios centralServicios = new Central.Entities.Servicios();
                        centralServicios.Servicio_ID = ServiciosApto.Codigo;
                        centralServicios.Mercado_ID = 2; // Aeropuerto
                        centralServicios.Empresa_ID = Empresa; // CAT
                        centralServicios.Estacion_ID = Estacion; // Apto Mty
                        centralServicios.Caja_ID = (ServiciosApto.Caja == null) ? null : new Nullable<int>(GetCaja(ServiciosApto.Caja.Value)); // Verificar                    
                        centralServicios.Zona_ID = ServiciosApto.Zona;
                        centralServicios.ClaseServicio_ID = ServiciosApto.ClaseServicio;
                        centralServicios.TipoServicio_ID = ServiciosApto.TipoServicio;
                        centralServicios.TipoServicioConductor_ID = null;
                        centralServicios.Moneda_ID = GetMoneda(ServiciosApto.TipoPago);
                        centralServicios.EstatusServicio_ID = ServiciosApto.Status;

                        if (ServiciosApto.ControlCaja == null)
                        {
                            centralServicios.Sesion_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Sesiones.Read(
                                    Param("Referencia_ID", ServiciosApto.ControlCaja.Folio),
                                        Param("Estacion_ID", Estacion)).Sesion_ID;
                        }

                        if (ServiciosApto.Carrera == null)
                        {
                            centralServicios.Unidad_ID = null;
                            centralServicios.Conductor_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Unidades.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Unidad),
                                        Param("Estacion_ID", Estacion)).Unidad_ID;

                            centralServicios.Conductor_ID =
                                Central.Entities.Conductores.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Conductor),
                                        Param("Estacion_ID", Estacion)).Conductor_ID;
                        }

                        centralServicios.Usuario_ID = (string.IsNullOrEmpty(ServiciosApto.Usuario)) ? "SICAS" : ServiciosApto.Usuario;
                        centralServicios.Cliente_ID = null;
                        centralServicios.TipoVenta_ID = null; // De acuerdo a codigo
                        centralServicios.Cuenta_ID = null; // De acuerdo solo para tipo boletos especiales, caso contrario, siempre a la misma cuenta
                        centralServicios.FolioDiario = ServiciosApto.FolioDiario;
                        centralServicios.Precio = ServiciosApto.Precio;
                        centralServicios.Fecha = ServiciosApto.Fecha;
                        centralServicios.FechaServicio = (ServiciosApto.Carrera == null) ? null : (DateTime?)(ServiciosApto.Carrera.FechaCarreraLocal);
                        centralServicios.FechaExpiracion = null;

                        if (ServiciosApto.Pago == null)
                        {
                            centralServicios.FechaPago = null;
                            centralServicios.Productividad = null;
                            centralServicios.Ticket_ID = null;

                            // Pago de conductor, Pago de comisiones
                            if (ServiciosApto.FolioDiarioEbssa != null)
                            {                                
                                centralServicios.PagoConductor = centralServicios.Precio - tp.TarifaEBSSA_CategoriaC;
                                centralServicios.PagoComisiones = tp.TarifaEBSSA_CategoriaC;
                            }
                            else
                            {
                                //  Si es regreso
                                Apto.Entities.BoletosRegresos regreso = Apto.Entities.BoletosRegresos.Read(centralServicios.Servicio_ID);
                                if (regreso != null)
                                {
                                    // Es regreso                                    
                                    centralServicios.PagoConductor = centralServicios.Precio - (tp.TarifaCascoRegresos.Value * 2);
                                    centralServicios.PagoComisiones = (tp.TarifaCascoRegresos.Value * 2);
                                }

                                //  Si es comisionada
                                Apto.Entities.Zonas zona = Apto.Entities.Zonas.Read(centralServicios.Zona_ID.Value);
                                if (zona.Comisionista != null)
                                {
                                    Apto.Entities.Comisionistas comisionista = Apto.Entities.Comisionistas.Read(zona.Comisionista.Value);
                                    centralServicios.PagoConductor -= (comisionista.PorcentajeComision / 100) * centralServicios.Precio;
                                    centralServicios.PagoComisiones += (comisionista.PorcentajeComision / 100) * centralServicios.Precio;
                                }

                                //  Si es compartida
                                Apto.Entities.CarrerasAeropuerto carrera = Apto.Entities.CarrerasAeropuerto.Read(centralServicios.Servicio_ID);
                                if (carrera != null)
                                {
                                    if (carrera.Compartida)
                                    {
                                        centralServicios.PagoConductor -= tp.TarifaCompartida;
                                        centralServicios.PagoComisiones += tp.TarifaCompartida;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (ServiciosApto.Pago.Recibo >= maxRecibo) return;

                            centralServicios.FechaPago = ServiciosApto.Pago.Fecha;
                            centralServicios.Productividad = ServiciosApto.Pago.CarrerasValidas;
                            centralServicios.PagoConductor = ServiciosApto.Pago.PagoConductor;
                            centralServicios.PagoComisiones = ServiciosApto.Pago.Precio - ServiciosApto.Pago.PagoConductor;
                            centralServicios.Ticket_ID =
                                Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", ServiciosApto.Pago.Recibo),
                                        Param("Estacion_ID", Estacion)).Ticket_ID;
                        }

                        if (Central.DB.Exists("Servicios", Param("Servicio_ID", centralServicios.Servicio_ID)))
                        {
                            centralServicios.Update();
                        }
                        else
                        {
                            centralServicios.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado Servicio_ID: {0}, {1} de {2}",
                            centralServicios.Servicio_ID, fechas.IndexOf(f), cont));
                    }
                }
            }

            private void SyncBoletosEspeciales()
            {
                string sqlQry = "SELECT ISNULL(MAX(Fecha),'') Fecha FROM Servicios WHERE TipoServicioConductor_ID IS NOT NULL";
                DateTime fecha;
                fecha = Convert.ToDateTime(Central.DB.QueryScalar(sqlQry));
                List<Apto.Entities.BoletosEspecialesAeropuerto> Boletos;

                List<DateTime> fechas =
                    (List<DateTime>)Apto.DB.QueryList<DateTime>(
                    "SELECT DISTINCT Fecha FROM BoletosEspecialesAeropuerto WHERE Fecha >= @Fecha",
                    "Fecha",
                    Param("@Fecha", fecha));

                int cont = fechas.Count;

                foreach (DateTime f in fechas)
                {

                    Boletos = Apto.Entities.BoletosEspecialesAeropuerto.Read(Param("Fecha", f));

                    foreach (Apto.Entities.BoletosEspecialesAeropuerto ServiciosApto in Boletos)
                    {
                        Central.Entities.Servicios centralServicios = new Central.Entities.Servicios();
                        centralServicios.Servicio_ID = ServiciosApto.Codigo;
                        centralServicios.Mercado_ID = 2; // Aeropuerto
                        centralServicios.Empresa_ID = Empresa; // CAT
                        centralServicios.Estacion_ID = Estacion; // Apto Mty
                        centralServicios.Caja_ID = new Nullable<int>(GetCaja(4)); // Verificar                    
                        centralServicios.Zona_ID = null;
                        centralServicios.ClaseServicio_ID = null;
                        centralServicios.TipoServicio_ID = null;
                        centralServicios.TipoServicioConductor_ID = null;
                        centralServicios.Moneda_ID = GetMoneda(ServiciosApto.TipoPago.Value);
                        centralServicios.EstatusServicio_ID = ServiciosApto.Status.Value;

                        if (ServiciosApto.ControlCaja == null)
                        {
                            centralServicios.Sesion_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Sesiones.Read(
                                    Param("Referencia_ID", ServiciosApto.ControlCaja.Folio),
                                        Param("Estacion_ID", Estacion)).Sesion_ID;
                        }

                        if (ServiciosApto.Carrera == null)
                        {
                            centralServicios.Unidad_ID = null;
                            centralServicios.Conductor_ID = null;
                        }
                        else
                        {
                            centralServicios.Unidad_ID =
                                Central.Entities.Unidades.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Unidad),
                                        Param("Estacion_ID", Estacion)).Unidad_ID;

                            centralServicios.Conductor_ID =
                                Central.Entities.Conductores.Read(
                                    Param("Referencia_ID", ServiciosApto.Carrera.Conductor),
                                        Param("Estacion_ID", Estacion)).Conductor_ID;
                        }

                        centralServicios.Usuario_ID = (string.IsNullOrEmpty(ServiciosApto.Usuario)) ? "SICAS" : ServiciosApto.Usuario;
                        centralServicios.Cliente_ID = null;
                        centralServicios.TipoVenta_ID = null; // De acuerdo a codigo
                        centralServicios.Cuenta_ID = null; // De acuerdo solo para tipo boletos especiales, caso contrario, siempre a la misma cuenta
                        centralServicios.FolioDiario = ServiciosApto.FolioDiario.Value;
                        centralServicios.Precio = ServiciosApto.Precio.Value;
                        centralServicios.Fecha = ServiciosApto.Fecha.Value;
                        centralServicios.FechaServicio = (ServiciosApto.Carrera == null) ? null : (DateTime?)(ServiciosApto.Carrera.FechaCarreraLocal);
                        centralServicios.FechaExpiracion = null;

                        if (ServiciosApto.Pago == null)
                        {
                            centralServicios.FechaPago = null;
                            centralServicios.Productividad = null;
                            centralServicios.PagoConductor = null;
                            centralServicios.PagoComisiones = null;
                            centralServicios.Ticket_ID = null;
                        }
                        else
                        {
                            centralServicios.FechaPago = ServiciosApto.Pago.Fecha;
                            centralServicios.Productividad = ServiciosApto.Pago.CarrerasValidas;
                            centralServicios.PagoConductor = ServiciosApto.Pago.PagoConductor;
                            centralServicios.PagoComisiones = ServiciosApto.Pago.Precio - ServiciosApto.Pago.PagoConductor;
                            centralServicios.Ticket_ID =
                                Central.Entities.Tickets.Read(
                                    Param("Referencia_ID", ServiciosApto.Pago.Recibo),
                                        Param("Estacion_ID", Estacion)).Ticket_ID;
                        }

                        if (Central.DB.Exists("Servicios", Param("Servicio_ID", centralServicios.Servicio_ID)))
                        {
                            centralServicios.Update();
                        }
                        else
                        {
                            centralServicios.Create();
                        }

                        Console.WriteLine(String.Format("Registro actualizado B.E. Servicio_ID: {0}, {1} de {2}",
                            centralServicios.Servicio_ID, fechas.IndexOf(f), cont));
                    }
                }
            }


            public void SyncServicios()
            {
                //SyncBoletosSinPagar();
                SyncBoletos();
                SyncBoletosEspeciales();

            }	//	End Method SyncServicios

            public void SyncServicios_Comisiones()
            {
                //List<Apto.Entities.Servicios_Comisiones> servicios_comisionesApto = Apto.Entities.Servicios_Comisiones.Read();
                //foreach (Apto.Entities.Servicios_Comisiones Servicios_ComisionesApto in servicios_comisionesApto)
                //{
                //    Central.Entities.Servicios_Comisiones centralServicios_Comisiones = new Central.Entities.Servicios_Comisiones();
                //    centralServicios_Comisiones.Servicio_ID = Servicios_ComisionesApto.Servicio_ID;
                //    centralServicios_Comisiones.ComisionServicio_ID = Servicios_ComisionesApto.ComisionServicio_ID;
                //    centralServicios_Comisiones.Ticket_ID = Servicios_ComisionesApto.Ticket_ID;
                //    centralServicios_Comisiones.Monto = Servicios_ComisionesApto.Monto;

                //    if (Central.DB.Exists("Servicios_Comisiones", Param("Servicio_ID", centralServicios_Comisiones.Servicio_ID)))
                //    {
                //        centralServicios_Comisiones.Update();
                //    }
                //    else
                //    {
                //        centralServicios_Comisiones.Create();
                //    }
                //}	//	End foreach

            }	//	End Method SyncServicios_Comisiones            

            public void SyncSesiones()
            {
                string filter = "Folio > @Folio";

                string sort = "Folio ASC";

                string sqlQry = "SELECT ISNULL(MAX(Referencia_ID),0) folio FROM Sesiones WHERE Estacion_ID = @Estacion";

                Apto.Entities.ControlCajas SesionesApto;
                int sesion;

                sesion = Convert.ToInt32(Central.DB.QueryScalar(sqlQry, Central.DB.GetParams(Param("@Estacion", Estacion))));

                while (Apto.Entities.ControlCajas.Read(out SesionesApto, 1, filter, sort, Param("Folio", sesion)))
                {
                    sesion = SesionesApto.Folio;

                    Central.Entities.Sesiones centralSesiones = new Central.Entities.Sesiones();
                    centralSesiones.Sesion_ID = 0;
                    centralSesiones.Empresa_ID = Empresa;
                    centralSesiones.Estacion_ID = Estacion;
                    centralSesiones.Caja_ID = Central.Entities.Cajas.Read(Param("Estacion_ID", Estacion), Param("Referencia_ID", SesionesApto.Caja)).Caja_ID;
                    centralSesiones.Usuario_ID = SesionesApto.Usuario;
                    centralSesiones.FechaInicial = SesionesApto.FechaInicioCaja;
                    centralSesiones.FechaFinal = SesionesApto.FechaCorteCaja;
                    centralSesiones.HostName = null;
                    centralSesiones.IPAddress = null;
                    centralSesiones.MACAddress = null;
                    centralSesiones.Activo = (SesionesApto.FechaCorteCaja == null) ? true : false;
                    centralSesiones.Referencia_ID = SesionesApto.Folio;

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

            public void SyncZonas()
            {
                List<Apto.Entities.Zonas> zonasApto = Apto.Entities.Zonas.Read();
                foreach (Apto.Entities.Zonas ZonasApto in zonasApto)
                {
                    Central.Entities.Zonas centralZonas = new Central.Entities.Zonas();
                    centralZonas.Zona_ID = ZonasApto.Folio;
                    centralZonas.TipoZona_ID = ZonasApto.Tipo;  //  Verificar conversión
                    centralZonas.ComisionServicio_ID = ZonasApto.Comisionista;  // Hacer tabla de conversión
                    centralZonas.Nombre = ZonasApto.Descripcion;


                    if (Central.DB.Exists("Zonas", Param("Zona_ID", centralZonas.Zona_ID)))
                    {
                        centralZonas.Update();
                    }
                    else
                    {
                        centralZonas.Create(true);
                    }

                    Console.WriteLine(String.Format("Registro actualizado Zona_ID: {0}", centralZonas.Zona_ID));
                }	//	End foreach

            }	//	End Method SyncZonas
        }

    }
}
