using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace SICASBulletin
{
    class Bulletin
    {

        #region Constructors

        public Bulletin()
        {
        }

        #endregion


        #region Properties



        #endregion


        #region Methods

        /// <summary>
        /// Escribe un archivo en el directorio temporal del sistema
        /// </summary>
        /// <param name="content"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string WriteTempFile(string content, string filename)
        {
            //  Obtenemos la ruta del archivo
            string filepath = Path.Combine(Path.GetTempPath(), filename);

            //  Escribimos el contenido
            StreamWriter sw = new StreamWriter(filepath, false);
            sw.Write(content);
            sw.Flush();
            sw.Close();            
            sw.Dispose();

            //  Regresamos la ruta del archivo
            return filepath;
        }

        /// <summary>
        /// Obtiene el mensaje sustituyendo los valores en el template
        /// </summary>
        /// <param name="template"></param>
        /// <param name="vars"></param>
        /// <returns></returns>
        private string GetMessage(string template, Hashtable vars)
        {
            //  Asignamos el template al resultado
            string result = template;

            //  Recorremos el arreglo de valores
            foreach (string key in vars.Keys)
            {
                //  Sustituimos los valores de las variables
                result = result.Replace(key, vars[key].ToString());
            }

            //  Regresamos la cadena resultante
            return result;
        }

        /// <summary>
        /// Envia el reporte concentrado de flotilla
        /// a los involucrados
        /// </summary>
        public void ReporteConcentradoFlotilla()
        {
            AppHelper.Log("Reporte Concentrado de Flotilla");

            //  Executamos la instruccion para registrar el historial
            DB.ExecStoredProcedure("usp_RegistroFlotillaDiaria", null);

            //  El conjunto de adjuntos
            List<string> adjuntos = new List<string>();

            //  La tabla de estatus
            string tablaestatus = AppHelper.DataTableExport.TableToHTML(
                    Views.Vista_Reporte_Concentrado_Flotilla_Estatus.GetDataTable()
                );

            //  La tabla de locaciones
            string tablalocaciones = AppHelper.DataTableExport.TableToHTML(
                    Views.Vista_Reporte_Concentrado_Flotilla_Locaciones.GetDataTable()
                );

            //  El archivo de la tabla de estatus
            adjuntos.Add(
                this.WriteTempFile(
                    tablaestatus, 
                    string.Format(
                        "ReporteConcentradoFlotillaEstatus{0:yyyyMMdd}.xls", 
                        DateTime.Now
                    )
                )
            );

            //  El archivo de la tabla de locaciones
            adjuntos.Add(
                this.WriteTempFile(
                    tablalocaciones,
                    string.Format(
                        "ReporteConcentradoFlotillaInactivas{0:yyyyMMdd}.xls",
                        DateTime.Now
                    )
                )
            );
            
            //  Obtenemos la plantilla
            string message = global::SICASBulletin.Properties.Resources.ReporteConcentradoFlotilla_Template;

            AppHelper.Log("Template obtenido");
            
            //  Conformamos las variables a reemplazar
            //  Declaramos la tabla
            Hashtable vars = new Hashtable();

            //  La(s) empresas(s)
            vars.Add("@Empresa", "TODAS LAS EMPRESAS");

            //  La fecha
            vars.Add(
                "@Fecha", 
                string.Format("{0:yyyy-MM-dd}", DateTime.Now)
            );
            
            //  El total de la flotilla
            vars.Add(
                "@TotalFlotilla", 
                string.Format(
                    "{0:G}", 
                    Functions.Get_TotalFlotilla()
                )
            );

            //  El reporte de estatus
            vars.Add(
                "@TablaEstatus", 
                tablaestatus
            );

            AppHelper.Log("Estatus generados");

            //  El total de las inactivas
            vars.Add(
                "@TotalInactivas", 
                string.Format(
                    "{0:G}", 
                    Functions.Get_TotalInactivas()
                )
            );

            //  El reporte de locaciones
            vars.Add(
                "@TablaLocaciones",
                tablalocaciones
            );

            AppHelper.Log("Locaciones generadas");

            //  Realizamos los reemplazos
            message = GetMessage(message, vars);

            //  El boletin id
            int boletin_id = 1; // El reporte concentrado de flotilla

            //  Obtenemos la lista de correos
            List<Views.Vista_CorreosParaBoletin> correos = Views.Vista_CorreosParaBoletin.Get(boletin_id);            

            //  El titulo del mensaje
            string title = string.Format(
                        "Reporte Concentrado de Flotilla {0:yyyy-MM-dd}", 
                        DateTime.Now);

            //  El remitente del mensaje
            string from = "sicas@casco.com.mx";

            //  Enviamos los reportes
            foreach (Views.Vista_CorreosParaBoletin correo in correos)
            {
                AppHelper.SendEmail(
                    from,
                    correo.Email,
                    title,
                    message,
                    adjuntos
                );

                AppHelper.Log(string.Format("Correo enviado a {0}", correo.Email));

            } // end foreach

            AppHelper.Log("Proceso terminado");
            //Console.Read();

        } // end ReporteConcentradoFlotilla

        /// <summary>
        /// Envia el reporte comparativo de kilometrajes y mantenimientos
        /// a los involucrados
        /// </summary>
        public void ReporteKilometrajesMantenimientos_Diario()
        {
            try
            {
                AppHelper.Log("Reporte Kilometrajes - Mantenimientos");

                //  Executamos la instruccion para registrar el historial
                DB.ExecStoredProcedure("usp_RegistroDiarioKilometrajesMantenimientos", null);

                //  El conjunto de adjuntos
                List<string> adjuntos = new List<string>();

                //  La tabla de kilometrajes & Mantenimientos
                string tablaKMMttos = AppHelper.DataTableExport.TableToHTML(
                        Views.Vista_ReporteKilometrajesMantenimiento_Diario.GetDataTable(DateTime.Today.AddDays(-1))
                    );

                //  El archivo de la tabla de estatus
                adjuntos.Add(
                    this.WriteTempFile(
                        tablaKMMttos,
                        string.Format(
                            "ReporteKilometrajesMantenimientoDiario{0:yyyyMMdd}.xls",
                            DateTime.Now
                        )
                    )
                );

                //  Obtenemos la plantilla
                string message = global::SICASBulletin.Properties.Resources.ReporteKilometrajesMantenimientos_Diario_Template;

                AppHelper.Log("Template obtenido");

                //  Conformamos las variables a reemplazar
                //  Declaramos la tabla
                Hashtable vars = new Hashtable();

                //  La fecha
                vars.Add(
                    "@Fecha",
                    string.Format("{0:yyyy-MM-dd}", DateTime.Now)
                );

                //  El reporte
                vars.Add(
                    "@TablaKMMttos",
                    tablaKMMttos
                );

                AppHelper.Log("Reporte generado");

                //  Realizamos los reemplazos
                message = GetMessage(message, vars);

                //  El boletin id
                int boletin_id = 2; // El reporte de kilometrajes y mantenimientos

                //  Obtenemos la lista de correos
                List<Views.Vista_CorreosParaBoletin> correos = Views.Vista_CorreosParaBoletin.Get(boletin_id);

                //  El titulo del mensaje
                string title = string.Format(
                            "Reporte de Kilometrajes y Mantenimientos {0:yyyy-MM-dd}",
                            DateTime.Now);

                //  El remitente del mensaje
                string from = "sicas@casco.com.mx";

                //  Enviamos los reportes
                foreach (Views.Vista_CorreosParaBoletin correo in correos)
                {
                    AppHelper.SendEmail(
                        from,
                        correo.Email,
                        title,
                        message,
                        adjuntos
                    );

                    AppHelper.Log(string.Format("Correo enviado a {0}", correo.Email));

                } // end foreach

                AppHelper.Log("Proceso terminado");

                //  Si es día primero, mandaremos el reporte mensual
                if (DateTime.Today.Day == 1)
                    this.ReporteKilometrajesMantenimientos_Mensual();

            } // end try
            catch (Exception ex)
            {
                AppHelper.Log("**Error: " + ex.Message);

                try
                {
                    AppHelper.SendEmail(
                        "sicas@casco.com.mx",
                        "webmaster@prosyss.com",
                        "Error en SICAS Bulletin: ReporteKilometrajesMantenimientos_Diario",
                        string.Format("{0:yyyy-MM-dd HH:mm:ss}\n\n{1}", DateTime.Now, ex.Message),
                        false
                    );
                }
                catch (Exception e)
                {
                    AppHelper.Log("**Error (Email): " + e.Message);

                } // end catch

            } // end catch

        } // end Reporte Kilometrajes Mantenimientos Diario

        /// <summary>
        /// Envia el reporte comparativo de kilometrajes y mantenimientos
        /// a los involucrados
        /// </summary>
        public void ReporteKilometrajesMantenimientos_Mensual()
        {
            AppHelper.Log("Reporte Kilometrajes - Mantenimientos");

            //  El conjunto de adjuntos
            List<string> adjuntos = new List<string>();

            //  La fecha inicial
            //  Un mes menos a patir de hoy
            DateTime fechaInicial = DateTime.Now.AddMonths(-1);

            //  La fecha final, ayer a las 11:59:59
            DateTime fechaFinal = DateTime.Today.
                                    AddDays(-1).
                                        AddHours(23).
                                            AddMinutes(59).
                                                AddSeconds(59);

            //  La tabla de kilometrajes & Mantenimientos
            string tablaKMMttos = AppHelper.DataTableExport.TableToHTML(
                    Views.Vista_ReporteKilometrajesMantenimientos.GetDataTable(fechaInicial, fechaFinal)
                );

            //  El archivo de la tabla de estatus
            adjuntos.Add(
                this.WriteTempFile(
                    tablaKMMttos,
                    string.Format(
                        "ReporteKilometrajesMantenimientoMensual{0:yyyyMMdd}_{1:yyyyMMdd}.xls",
                        fechaInicial,
                        fechaFinal
                    )
                )
            );

            //  Obtenemos la plantilla
            string message = 
                global::SICASBulletin.Properties.Resources.ReporteKilometrajesMantenimientos_Mensual_Template;

            AppHelper.Log("Template obtenido");

            //  Conformamos las variables a reemplazar
            //  Declaramos la tabla
            Hashtable vars = new Hashtable();

            //  La fecha inicial
            vars.Add(
                "@FechaInicial",
                string.Format("{0:yyyy-MM-dd}", fechaInicial)
            );

            //  La fecha final
            vars.Add(
                "@FechaFinal",
                string.Format("{0:yyyy-MM-dd}", fechaFinal)
            );

            //  El reporte
            vars.Add(
                "@TablaKMMttos",
                tablaKMMttos
            );

            AppHelper.Log("Reporte generado");

            //  Realizamos los reemplazos
            message = GetMessage(message, vars);

            //  El boletin id
            int boletin_id = 2; // El reporte de kilometrajes y mantenimientos

            //  Obtenemos la lista de correos
            List<Views.Vista_CorreosParaBoletin> correos =
                Views.Vista_CorreosParaBoletin.Get(boletin_id);

            //  El titulo del mensaje
            string title = string.Format(
                        "Reporte de Kilometrajes y Mantenimientos {0:yyyy-MM-dd} a {1:yyyy-MM-dd}",
                        fechaInicial,
                        fechaFinal
                    );

            //  El remitente del mensaje
            string from = "sicas@casco.com.mx";

            //  Enviamos los reportes
            foreach (Views.Vista_CorreosParaBoletin correo in correos)
            {
                AppHelper.SendEmail(
                    from,
                    correo.Email,
                    title,
                    message,
                    adjuntos
                );

                AppHelper.Log(string.Format("Correo enviado a {0}", correo.Email));

            } // end foreach

            AppHelper.Log("Proceso terminado");
            //Console.Read();

        } // end Reporte Kilometrajes Mantenimientos Diario
        #endregion				
				
    } // end class Bulletin

} // end namespace