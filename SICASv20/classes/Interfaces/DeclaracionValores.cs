using System;
using System.Collections.Generic;
using System.Text;
using SICASv20.classes.Entities.caja;
using System.Collections;
using System.Data;

namespace SICASv20.classes.Interfaces
{
    public static class DeclaracionValores
    {
        public static List<DetalleVale> GetValesPrepagados(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresosVP";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            return GetListDetallevale(ds.Tables[0]);
        }

        public static List<DetalleVale> GetValesEmpresariales(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresosVEmp";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            return GetListDetallevale(ds.Tables[0]);
        }



        public static List<DetalleVoucher> GetVouchersApto(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresosAptoVoucher";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            return GetListDetalleVoucher(ds.Tables[0]);
        }

        public static List<ResumenZonasApto> GetResumenZonasApto(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_AptoResumenZonas";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            return GetListResumenZonas(ds.Tables[0]);
        }


        private static List<DetalleVale> GetListDetallevale(DataTable dt)
        {
            List<DetalleVale> ld = new List<DetalleVale>();
            foreach (DataRow dr in dt.Rows)
            {
                DetalleVale dv = new DetalleVale();
                dv.Empresa_ID = Convert.ToInt32(dr["Empresa_ID"]);
                dv.TipoVale = Convert.ToInt32(dr["TipoVale"]);
                dv.Serie = dr["Serie"].ToString();
                dv.Folio = dr["Folio"].ToString();
                dv.Monto = Convert.ToDouble(dr["Monto"]);
                ld.Add(dv);
            }
            return ld;
        }

        public static List<DetalleEfectivo> GetEfectivoPorSesion(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresoEfectivo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            List<DetalleEfectivo> le = new List<DetalleEfectivo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DetalleEfectivo de = new DetalleEfectivo(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToDouble(dr["Monto"]));
                le.Add(de);
            }
            return le;
        }


        public static List<DetalleEfectivo> GetEfectivoAptoPorSesion(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresoAptoEfectivo";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            List<DetalleEfectivo> le = new List<DetalleEfectivo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DetalleEfectivo de = new DetalleEfectivo(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToDouble(dr["Monto"]));
                le.Add(de);
            }
            return le;
        }


        private static List<DetalleVoucher> GetListDetalleVoucher(DataTable dt)
        {
            List<DetalleVoucher> ld = new List<DetalleVoucher>();
            foreach (DataRow dr in dt.Rows)
            {
                DetalleVoucher dv = new DetalleVoucher();
                dv.Empresa_ID = Convert.ToInt32(dr["Empresa_ID"]);
                dv.TipoVenta = Convert.ToInt32(dr["TipoVenta"]);
                dv.Servicio_ID = dr["Servicio_ID"].ToString();
                dv.FolioDiario = dr["FolioDiario"].ToString();
                dv.Monto = Convert.ToDouble(dr["Monto"]);
                ld.Add(dv);
            }
            return ld;
        }


        private static List<ResumenZonasApto> GetListResumenZonas(DataTable dt)
        {
            List<ResumenZonasApto> ld = new List<ResumenZonasApto>();
            foreach (DataRow dr in dt.Rows)
            {
                ResumenZonasApto dv = new ResumenZonasApto();
                dv.Zona_ID = Convert.ToInt32(dr["Zona_ID"]);
                dv.Zona = dr["Zona"].ToString();
                dv.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                dv.Monto = Convert.ToDouble(dr["Monto"]);
                ld.Add(dv);
            }
            return ld;
        }
        public static Dictionary<string, double> GetIngresosEfectivoOtrasCuentas(int sesion_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_IngresosEfectivoOtrasCuentas";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            Dictionary<string, double> le = new Dictionary<string, double>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                le.Add(dr["Empresa"].ToString(), Convert.ToDouble(dr["Efectivo"]));
            }
            return le;
        }

        public static List<DetalleDeclaracion> GetDeclaracionBilletes(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_DeclaracionBilletes_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            List<DetalleDeclaracion> ld = new List<DetalleDeclaracion>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DetalleDeclaracion dd = new DetalleDeclaracion();
                dd.Id = Convert.ToInt32(dr["Id"]);
                dd.Id_Denominacion = Convert.ToInt32(dr["Id_Denominacion"]);
                dd.Descripcion_Denominacion = dr["Descripcion_Denominacion"].ToString();
                dd.Valor_Denominacion = Convert.ToDouble(dr["Valor_Denominacion"]);
                dd.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                ld.Add(dd);
            }
            return ld;
        }

        public static List<DetalleDeclaracion> GetDeclaracionMonedas(int sesion_id, int empresa_id)
        {
            string sqlstr = "dbo.usp_CortesCaja_DeclaracionMonedas_Consulta";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Sesion_ID", sesion_id);
            m_params.Add("@Empresa_ID", empresa_id);
            DataSet ds = DB.QueryDS(sqlstr, m_params);
            List<DetalleDeclaracion> ld = new List<DetalleDeclaracion>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DetalleDeclaracion dd = new DetalleDeclaracion();
                dd.Id = Convert.ToInt32(dr["Id"]);
                dd.Id_Denominacion = Convert.ToInt32(dr["Id_Denominacion"]);
                dd.Descripcion_Denominacion = dr["Descripcion_Denominacion"].ToString();
                dd.Valor_Denominacion = Convert.ToDouble(dr["Valor_Denominacion"]);
                dd.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                ld.Add(dd);
            }
            return ld;
        }

        public static void GuardaDeclaracion(classes.Entities.caja.DeclaracionValores ddv)
        {
            string sqlstr = "usp_CortesCaja_InsertaDeclaracion";
            Hashtable m_params = new Hashtable();
            m_params.Add("@Fecha", DateTime.Now);
            m_params.Add("@Caja_ID", Sesion.Caja_ID);
            m_params.Add("@Empresa_ID", ddv.Empresa_Id);
            m_params.Add("@Estacion_ID", Sesion.Estacion_ID);
            m_params.Add("@Usuario_ID", Sesion.Usuario_ID);
            m_params.Add("@Sesion_ID", Sesion.Sesion_ID);

            int iestatus = 1;
            if (ddv.Diferencia < 0) iestatus = 2; //Faltante
            if (ddv.Diferencia > 0) iestatus = 3; //Sobrante
            m_params.Add("@EstatusCorteCaja_ID", iestatus);

            m_params.Add("@TotalTickets", ddv.dTotalIngresosSesion);
            m_params.Add("@TotalIngresosEfectivo", ddv.dTotalEfectivo);
            m_params.Add("@TotalIngresosVales", ddv.dTotalValesEmpresariales + ddv.dTotalValesPrePagados);
            m_params.Add("@Observaciones", ddv.Observaciones);
            m_params.Add("@TotalIngresosVouchers", ddv.dTotalVouchers);
            DB.ExecuteCommandSP(sqlstr, m_params);
        }

        public static void GuardaDetalleEfectivo(classes.Entities.caja.DeclaracionValores ddv)
        {
            string sqlstr = "usp_CortesCaja_InsertaDetalleEfectivo";
            //Almacena el detalle de los billetes
            foreach (DetalleDeclaracion dd in ddv.Billetes)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("@Sesion_ID", Sesion.Sesion_ID);
                m_params.Add("@Empresa_ID", ddv.Empresa_Id);
                m_params.Add("@Id_Denominacion", dd.Id_Denominacion);
                m_params.Add("@Cantidad", dd.Cantidad);
                m_params.Add("@Monto", dd.Monto);
                DB.ExecuteCommandSP(sqlstr, m_params);
            }
            //Almacena el detalle de las monedas
            foreach (DetalleDeclaracion dd in ddv.Monedas)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("@Sesion_ID", Sesion.Sesion_ID);
                m_params.Add("@Empresa_ID", ddv.Empresa_Id);
                m_params.Add("@Id_Denominacion", dd.Id_Denominacion);
                m_params.Add("@Cantidad", dd.Cantidad);
                m_params.Add("@Monto", dd.Monto);
                DB.ExecuteCommandSP(sqlstr, m_params);
            }
        }

        public static void GuardaDetalleVales(classes.Entities.caja.DeclaracionValores ddv)
        {
            string sqlstr = "usp_CortesCaja_InsertaDetalleVale";
            //Almacena el detalle de los vales prepagados
            foreach (DetalleVale dv in ddv.ValesPrePagados)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("@Sesion_ID", Sesion.Sesion_ID);
                m_params.Add("@Empresa_ID", ddv.Empresa_Id);
                m_params.Add("@TipoVale", 1);
                m_params.Add("@Serie", dv.Serie);
                m_params.Add("@Folio", dv.Folio);
                m_params.Add("@Monto", dv.Monto);
                DB.ExecuteCommandSP(sqlstr, m_params);
            }
            //Almacena el detalle de los vales empresariales
            foreach (DetalleVale dv in ddv.ValesEmpresariales)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("@Sesion_ID", Sesion.Sesion_ID);
                m_params.Add("@Empresa_ID", ddv.Empresa_Id);
                m_params.Add("@TipoVale", 1);
                m_params.Add("@Serie", dv.Serie);
                m_params.Add("@Folio", dv.Folio);
                m_params.Add("@Monto", dv.Monto);
                DB.ExecuteCommandSP(sqlstr, m_params);
            }
        }

        public static void GuardaDetalleVouchers(classes.Entities.caja.DeclaracionValores ddv)
        {
            string sqlstr = "usp_CortesCaja_InsertaDetalleVouchers";
            //Almacena el detalle de los vales prepagados
            foreach (DetalleVoucher dv in ddv.Vouchers)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("@Sesion_ID", Sesion.Sesion_ID);
                m_params.Add("@Empresa_ID", ddv.Empresa_Id);
                m_params.Add("@TipoVenta", 1);
                m_params.Add("@Servicio_ID", dv.Servicio_ID);
                m_params.Add("@FolioDiario", dv.FolioDiario);
                m_params.Add("@Monto", dv.Monto);
                DB.ExecuteCommandSP(sqlstr, m_params);
            }
        }

        public static void Imprimir(classes.Entities.caja.DeclaracionValores dv, int idx)
        {
            PrintHelper printer = new PrintHelper();

            printer.PrintCLRF();
            printer.PrintText(string.Format("EID:    {0} - {1}", dv.Empresa_Id, dv.Empresa));
            printer.PrintText(string.Format("ESTID:    {0}", Sesion.Estacion_ID));
            printer.PrintText(string.Format("SID:   {0}", Sesion.Sesion_ID));
            printer.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", DateTime.Now));
            //printer.PrintText(string.Format("SID:   {0}", "35852"));
            //printer.PrintText("F:   2017-09-27     H:    19:10:09");
            printer.PrintCLRF();

            //Billetes
            printer.PrintText("Billetes");
            DataTable dtable = new DataTable();
            dtable.Columns.Add("Denominacion", typeof(System.String));
            dtable.Columns.Add("Cantidad", typeof(System.String));
            dtable.Columns.Add("Monto", typeof(System.String));
            foreach (classes.Entities.caja.DetalleDeclaracion dd in dv.Billetes)
            {
                dtable.Rows.Add(dd.Descripcion_Denominacion, dd.Cantidad, string.Format("{0:C2}", dd.Monto));
            }
            printer.PrintTable(dtable);
            printer.PrintText(string.Format("Tot Billetes:   {0}", dv.TotalBilletes));
            printer.PrintCLRF();

            //Monedas
            printer.PrintText("Monedas");
            dtable = new DataTable();
            dtable.Columns.Add("Denominacion", typeof(System.String));
            dtable.Columns.Add("Cantidad", typeof(System.String));
            dtable.Columns.Add("Monto", typeof(System.String));
            foreach (classes.Entities.caja.DetalleDeclaracion dd in dv.Monedas)
            {
                dtable.Rows.Add(dd.Descripcion_Denominacion, dd.Cantidad, string.Format("{0:C2}", dd.Monto));
            }
            printer.PrintTable(dtable);
            printer.PrintText(string.Format("Tot Monedas:   {0}", dv.TotalMonedas));
            printer.PrintCLRF();

            printer.PrintText(string.Format("Tot Ingresos Efectivo:   {0}", dv.TotalEfectivo));
            if (dv.Empresa_Id == 3)
            {
                printer.PrintText(string.Format("Tot Vouchers:   {0}", dv.TotalVouchers));
            }
            printer.PrintText(string.Format("Tot Vales Prepagado:   {0}", dv.TotalValesPrepagados));
            printer.PrintText(string.Format("Tot Vales Empresariales:   {0}", dv.TotalValesEmpresariales));
            printer.PrintText(string.Format("Tot Ingresos Declarados:   {0}", dv.TotalIngresosDeclarados));
            //printer.PrintText(string.Format("Tot Efectivo Sesión:   {0}", dv.TotalEfectivoSesion));
            printer.PrintText(string.Format("Tot Ingresos en Sistema:   {0}", dv.TotalIngresosSesion));

            if (dv.Incidencia.Length > 0)
            {
                printer.PrintLine();
                printer.PrintText(string.Format("Incidencia: {0}", dv.Incidencia));
            }
            printer.PrintLine();
            if (dv.Observaciones != null && dv.Observaciones.Trim().Length > 0)
            {
                printer.PrintText(string.Format("Observaciones: {0}", dv.Observaciones));
                printer.PrintText("================================");
                printer.PrintLine();
            }


            string sreferencia = "";
            string cBancaria = "";

            printer.PrintText("================================");
            List<SICASv20.Entities.Empresas_Cuentas> lempresas = SICASv20.Entities.Empresas_Cuentas.Read(dv.Empresa_Id, (!dv.EslaUltima ? true : false));
            if (lempresas.Count > 0)
            {
                cBancaria = lempresas[0].CuentaBancaria;

                // Sesion.Caja_ID.Value.ToString().PadLeft(2) + idx.ToString() + string.Format("{0:MMdd}", DateTime.Now);


                if (lempresas[0].Empresa_ID == 601 & lempresas[0].CuentaBancaria == "009-07800-001-2" & lempresas[0].Cuenta_ID == 1)
                {
                    sreferencia = lempresas[0].Referencia.ToString();//"1111127";//lempresas[0].Referencia.ToString();
                }
                else
                {
                    sreferencia = Sesion.Caja_ID.Value.ToString().PadLeft(2) + idx.ToString() + string.Format("{0:MMdd}", DateTime.Now);
                }
            }

            //if (sreferencia == "")
            //{ sreferencia = Sesion.Caja_ID.Value.ToString().PadLeft(2) + idx.ToString() + string.Format("{0:MMdd}", DateTime.Now); }

            printer.PrintText(string.Format("Cuenta Bancaria: {0}", cBancaria));
            printer.PrintText(string.Format("Referencia Bancaria: {0}", sreferencia));

            // if (lempresas[0].Empresa_ID != 601 & lempresas[0].CuentaBancaria != "009-07800-001-2")
            //{
            // sreferencia = Sesion.Caja_ID.Value.ToString().PadLeft(2) + idx.ToString() + string.Format("{0:MMdd}", DateTime.Now.AddDays(-2));
            //}
            //else
            //{

            //    sreferencia = lempresas[0].Referencia.ToString();// "1111127";// Sesion.Caja_ID.Value.ToString().PadLeft(2) + idx.ToString() + string.Format("{0:MMdd}", DateTime.Now);

            //}




            printer.PrintText("================================");
            printer.PrintLine();

            /// para Impresion de Detalle por Zona. Aeropuerto 
            if (dv.Empresa_Id == 3 && dv.ResumenZonasApto.Count > 0)
            {
                printer.Width = 350;
                printer.PrintLine();
                printer.PrintText("================================");
                printer.PrintText("Resumen por Zona");
                printer.PrintText("================================");
                //printer.PrintText("     " + "  Servicios  " + "     |       " + "    Monto   " + "      |       " + "Zona");
                //foreach (SICASv20.classes.Entities.caja.ResumenZonasApto rz in dv.ResumenZonasApto)
                //{
                //    printer.PrintText("     " + rz.Cantidad + "     |       " + string.Format("{0:C2}", rz.Monto) + "      |       " + rz.Zona);
                //}
                DataTable dtableZonas = new DataTable();
                dtableZonas.Columns.Add("Zona", typeof(System.String));
                dtableZonas.Columns.Add("Cantidad", typeof(System.String));
                dtableZonas.Columns.Add("Monto", typeof(System.String));
                foreach (classes.Entities.caja.ResumenZonasApto dd in dv.ResumenZonasApto)
                {
                    dtableZonas.Rows.Add(dd.Zona, dd.Cantidad, string.Format("{0:C2}", dd.Monto));
                }
                printer.PrintTable(dtableZonas);
            }
            printer.Width = 250;
            printer.Print();

            if (dv.EslaUltima && SICASv20.Entities.Estaciones.GetEsFranquicia(Sesion.Estacion_ID))
            {
                PrintHelper p1 = new PrintHelper();
                Dictionary<string, double> empresas = SICASv20.classes.Interfaces.DeclaracionValores.GetIngresosEfectivoOtrasCuentas(Sesion.Sesion_ID);
                foreach (string empresa in empresas.Keys)
                {
                    p1.PrintCLRF();
                    p1.PrintText("================================");
                    p1.PrintText("Ingresos Efectivo Otras Cuentas");
                    p1.PrintText(string.Format("ESTID:    {0}", Sesion.Estacion_ID));
                    p1.PrintText(string.Format("SID:   {0}", Sesion.Sesion_ID));
                    p1.PrintText(string.Format("F:   {0:yyyy-MM-dd}     H:    {0:HH:mm:ss}", DateTime.Now));
                    p1.PrintText(string.Format("{0}: {1}", empresa, empresas[empresa]));
                    p1.PrintText("================================");
                    p1.PrintLine();
                    p1.Print();
                }
            }
        }
    }
}
