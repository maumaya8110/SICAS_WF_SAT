using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	/// <summary>
	/// Formulario que muestra el reporte de la sesión de caja de cobro
	/// </summary>
	public partial class ReporteCorteCajaCobro : baseForm
	{
		public ReporteCorteCajaCobro()
		{
			InitializeComponent();
		}

		class ReporteCorteCajaCobro_Model
		{
			/// <summary>
			/// La cantidad de Recibos (Tickets) cobrados
			/// durante la sesión
			/// </summary>
			public int CantidadRecibos
			{
				get { return _CantidadRecibos; }
				set { _CantidadRecibos = value; }
			}
			private int _CantidadRecibos;

			/// <summary>
			/// La cantidad de Recibos (Tickets) cancelados
			/// durante la sesión
			/// </summary>
			public int CantidadCancelaciones
			{
				get { return _CantidadCancelaciones; }
				set { _CantidadCancelaciones = value; }
			}
			private int _CantidadCancelaciones;

			/// <summary>
			/// Tabla que representa el flujo de caja
			/// de la sesión
			/// </summary>
			public DataTable FlujoCaja
			{
				get { return _FlujoCaja; }
				set { _FlujoCaja = value; }
			}
			private DataTable _FlujoCaja;

			/// <summary>
			/// Tabla que contiene las recaudaciones
			/// de la sesión
			/// </summary>
			public DataTable Recaudaciones
			{
				get { return _Recaudaciones; }
				set { _Recaudaciones = value; }
			}
			private DataTable _Recaudaciones;

			/// <summary>
			/// Crea una nueva instancia del modelo de lógica de negocios
			/// para el reporte de corte de caja de cobro, a partir
			/// de un folio identificador de sesión
			/// </summary>
			/// <param name="sesion_id"></param>
			public ReporteCorteCajaCobro_Model(int sesion_id)
			{
				//  Sentencia SQL para contabilizar los tickes
				string sql = @"SELECT COUNT(*) 
                    FROM Tickets 
                    WHERE Sesion_ID = @Sesion_ID";

				//  Obtenemos los tickets de la sesión
				//  consultando la base de datos
				this.CantidadRecibos =
				    DB.Select<int>(sql, DB.Param("@Sesion_ID", sesion_id));

				//  Preparamos la sentencia SQL para contabilizar
				//  las cancelaciones
				sql = @"SELECT COUNT(*) 
                    FROM TicketsCancelados
                    WHERE   Ticket_ID IN (
                        SELECT Ticket_ID
                        FROM Tickets
                        WHERE Sesion_ID = @Sesion_ID )";

				//  Obtenemos los tickets cancelados
				//  consultando la base de datos
				this.CantidadCancelaciones =
				    DB.Select<int>(sql, DB.Param("@Sesion_ID", sesion_id));


				//  Preparamos la sentencia SQL para obtener
				//  la tabla de flujo de caja
				sql = @"SELECT M.Nombre, SUM(CFC.Abono-CFC.Cargo) Saldo
                    FROM	CuentaFlujoCajas CFC
                    INNER JOIN	Monedas M
                    ON		CFC.Moneda_ID = M.Moneda_ID
                    WHERE	CFC.Sesion_ID = @Sesion_ID
                    GROUP BY	M.Nombre";

				//  Obtenemos el flujo de caja
				//  consultando la base de datos
				this.FlujoCaja =
				    DB.QueryCommand(sql, DB.GetParams(DB.Param("@Sesion_ID", sesion_id)));


				//  Preparamos la sentencia SQL para obtener
				//  la recaudación de caja
				sql = @"SELECT	E.Nombre Empresa, C.Nombre Cuenta,
		                SUM(CC.Abono - CC.Cargo) Saldo
                FROM	CuentaCajas CC
                INNER JOIN	Empresas E
                ON		CC.Empresa_ID = E.Empresa_ID
                INNER JOIN	Cuentas C
                ON		CC.Cuenta_ID = C.Cuenta_ID
                WHERE	CC.Sesion_ID = @Sesion_ID
                GROUP BY	E.Nombre, C.Nombre";

				//  Obtenemos las recaudaciones
				//  consultando la base de datos
				this.Recaudaciones =
				    DB.QueryCommand(sql, DB.GetParams(DB.Param("@Sesion_ID", sesion_id)));

			} // end ReporteCorteCajaCobro_Model

		} // end class

		/// <summary>
		/// La variable que representa el modelo
		/// de la lógica de negocios a utilizar
		/// en el formulario
		/// </summary>
		ReporteCorteCajaCobro_Model Model;

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			AppHelper.DoMethod(delegate
			{
				//  Instanciamos el modelo
				this.Model = new ReporteCorteCajaCobro_Model(Sesion.Sesion_ID);

				//  Formamos el ticket de corte
				//  a partir de los datos y
				//  lo mostramos en la imagen
				ObtenerTicketDeCorte();

				base.BindData();

			}, this);

		} // end BindData

		/// <summary>
		/// Forma una imagen del ticker de corte
		/// a partir de los datos y la muestra
		/// en pantalla
		/// </summary>
		private void ObtenerTicketDeCorte()
		{
			//  Instanciamos una nuevo ayudante de impresión
			PrintHelper ph = new PrintHelper();

			//  Formamos el ticket de corte
			//  a partir de los datos obtenidos

			//  Impresión de encabezados y datos de corte
			ph.PrintText("Ticket de Corte");
			ph.PrintText("Estación: {0}", Sesion.Estacion_ID);
			ph.PrintText("Caja: {0}", Sesion.Caja_ID);
			//DateTime dte = DB.GetDate();
			//DateTime dte = Convert.ToDateTime("2016-05-11");
			ph.PrintText("Fecha: {0:yyyy-MM-dd}", DB.GetDate());
			ph.PrintLine();

			//  Impresión de cantidades de tickets
			ph.PrintText("Cant. Tickets: {0}", this.Model.CantidadRecibos);
			ph.PrintText("Cant. Cancelaciones: {0}", this.Model.CantidadCancelaciones);
			ph.PrintLine();

			//  Impresión del flujo de caja
			ph.PrintText("Flujo de caja");
			ph.PrintTable(Model.FlujoCaja);
			ph.PrintLine();

			//  Impresión de las recaudaciones
			ph.PrintText("Recaudaciones");
			ph.PrintTable(Model.Recaudaciones);

			//  Mostramos la imágen
			this.CortePictureBox.Image = ph.PrintToBitmap();
		}

		/// <summary>
		/// Imprime el ticket de corte al dispositivo de impresión
		/// configurado por defecto en el sistema operativo
		/// </summary>
		private void ImprimirTicketDeCorte()
		{
			//  Instanciamos una nuevo ayudante de impresión
			PrintHelper ph = new PrintHelper();

			//  Formamos el ticket de corte
			//  a partir de los datos obtenidos

			//  Impresión de encabezados y datos de corte
			ph.PrintText("Ticket de Corte");
			ph.PrintText("Estación: {0}", Sesion.Estacion_ID);
			ph.PrintText("Caja: {0}", Sesion.Caja_ID);
			//DateTime dte = DB.GetDate();
			//DateTime dte = Convert.ToDateTime("2016-05-11");
			ph.PrintText("Fecha: {0:yyyy-MM-dd HH:mm:ss}", DB.GetDate());
			ph.PrintLine();

			//  Impresión de cantidades de tickets
			ph.PrintText("Cant. Tickets: {0}", this.Model.CantidadRecibos);
			ph.PrintText("Cant. Cancelaciones: {0}", this.Model.CantidadCancelaciones);
			ph.PrintLine();

			//  Impresión del flujo de caja
			ph.PrintText("Flujo de caja");
			ph.PrintTable(Model.FlujoCaja);
			ph.PrintLine();

			//  Impresión de las recaudaciones
			ph.PrintText("Recaudaciones");

			//  Impresión del pie de página
			ph.PrintTable(Model.Recaudaciones);
			ph.PrintLine();
			ph.PrintLine();
			ph.PrintLine();
			ph.PrintLine();
			ph.PrintText("=============================");

			//  Mandamos imprimir el documento a la impresora
			ph.Print();

		} // end ImprimirTicketDeCorte

		/// <summary>
		/// Realiza el corte de caja, lo imprime y sale del sistema
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CorteButton_Click(object sender, EventArgs e)
		{
			//  Solicitamos confirmación
			if (AppHelper.Confirm("¿Realmente desea efectuar el corte de caja?") == System.Windows.Forms.DialogResult.Yes)
			{
				AppHelper.DoMethod(delegate
				{
					// Imprimir el ticket las veces
					//  que este configurado

					//  Obtenemos el registro de la caja actual
					Entities.Cajas caja = Entities.Cajas.Read(Sesion.Caja_ID.Value);

					//  Si tiene impresión doble
					if (caja.ImpresionDoble.Value)
					{
						//  Imprimimos dos veces
						ImprimirTicketDeCorte();
						ImprimirTicketDeCorte();
					}
					else // Si no
					{
						//  Imprimimos solo una vez
						ImprimirTicketDeCorte();
					}

					// Cerrar la sesión
					//  Obtenemos el registro de la sesión actual
					Entities.Sesiones sesion = Entities.Sesiones.Read(Sesion.Sesion_ID);

					//  Desactivamos
					sesion.Activo = false;

					//  Configuramos fecha final
					sesion.FechaFinal = DB.GetDate();

					//  Actualizamos en la base de datos
					sesion.Update();

					//  Salimos del sistema
					Application.Exit();

				}, this);

			} // end if

		} // end Click

	} // end class

}// end namespace
