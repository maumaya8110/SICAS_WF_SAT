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
	/// Verifica los servicios de los conductores. Tiene la capacidad
	/// de cambiar servicios para pagarlos el día actual y cambiarlos
	/// de conductor
	/// </summary>
	public partial class VerificacionBoletos : baseForm
	{
		#region Constructor

		/// <summary>
		/// Crea una nueva instancia de la verificación de los boletos
		/// </summary>
		public VerificacionBoletos()
		{
			InitializeComponent();
		}

		#endregion

		#region Model

		/// <summary>
		/// Modela la lógica de negocios de la verificación de boletos
		/// </summary>
		class RastreoCambioBoletos_Model
		{
			/// <summary>
			/// Crea una nueva instancia del rastreo y cambio de boletos
			/// </summary>
			public RastreoCambioBoletos_Model()
			{

			}

			/// <summary>
			/// Los datos del servicio
			/// </summary>
			public Entities.Vista_Servicios Vista_Servicio
			{
				get { return _Vista_Servicio; }
				set { _Vista_Servicio = value; }
			}
			private Entities.Vista_Servicios _Vista_Servicio;

			/// <summary>
			/// La entidad del servicio
			/// </summary>
			public Entities.Servicios Servicio
			{
				get { return _Servicio; }
				set { _Servicio = value; }
			}
			private Entities.Servicios _Servicio;

			/// <summary>
			/// El folio de la unidad a la cual se reasignará
			/// el servicio previamente asignado a otra unidad
			/// </summary>
			public int NuevaUnidad_ID
			{
				get { return _NuevaUnidad_ID; }
				set { _NuevaUnidad_ID = value; }
			}
			private int _NuevaUnidad_ID;

			/// <summary>
			/// El nombre del conductor al cual se reasignará
			/// el servicio previamente asignado a otro conductor
			/// </summary>
			public string NuevoConductor
			{
				get { return _NuevoConductor; }
				set { _NuevoConductor = value; }
			}
			private string _NuevoConductor;

			/// <summary>
			/// El folio del conductor al cual se reasignará
			/// el servicio previamente asignado a otro conductor
			/// </summary>
			public int NuevoConductor_ID
			{
				get { return _NuevoConductor_ID; }
				set { _NuevoConductor_ID = value; }
			}
			private int _NuevoConductor_ID;

			/// <summary>
			/// La fecha original del servicio
			/// </summary>
			public DateTime FechaAnterior
			{
				get { return _FechaAnterior; }
				set { _FechaAnterior = value; }
			}
			private DateTime _FechaAnterior;

			/// <summary>
			/// La nueva fecha del servicio
			/// </summary>
			public DateTime FechaServicio
			{
				get { return _FechaServicio; }
				set { _FechaServicio = value; }
			}
			private DateTime _FechaServicio;

			/// <summary>
			/// Indicador para determinar si es posible realizar el cambio
			/// </summary>
			public bool EsPosibleCambio
			{
				get { return _EsPosibleCambio; }
				set { _EsPosibleCambio = value; }
			}
			private bool _EsPosibleCambio = false;

			/// <summary>
			/// Guarda los cambios en la base de datos
			/// </summary>
			public void Guardar()
			{
				this.Servicio.Update();
			}

			/// <summary>
			/// Realiza el cambio de unidad y conductor
			/// </summary>
			public void CambiarUnidad()
			{
				this.Servicio.Unidad_ID = this.NuevaUnidad_ID;
				this.Servicio.Conductor_ID = this.NuevoConductor_ID;
			}

			/// <summary>
			/// Realiza el cambio de fechas
			/// </summary>
			public void CambiarFecha()
			{
				this.Servicio.FechaServicio = this.FechaAnterior;
			}

			/// <summary>
			/// Ejecuta el cambio de datos
			/// </summary>
			public void RealizarCambio()
			{
				//  Actualizamos la fecha del servicio a su valor de las 12:00 am
				this.FechaServicio = this.FechaServicio.Date;

				//  Si es vendido por EBS
				if (Servicio.Caja_ID.Value == 10)
				{
					//  Actualizamos la fecha de venta
					this.Servicio.Fecha = this.FechaServicio;
				}
				else // Si es vendido en cajas de casco
				{
					//  Actualizamos la fecha de servicio
					this.Servicio.FechaServicio = this.FechaServicio;
				}

				//  Le cambiamos la unidad, la tenga correcta o no, invariablemente
				this.Servicio.Unidad_ID = this.NuevaUnidad_ID;
				this.Servicio.Conductor_ID = this.NuevoConductor_ID;

				//  Si no tiene pago de conductor
				if (this.Servicio.PagoConductor == null)
				{
					//  Calculamos las comisiones
					string sql = "SELECT ISNULL(SUM(Monto),0) FROM Servicios_Comisiones WHERE Servicio_ID = @Servicio_ID";
					Servicio.PagoComisiones =
					    Convert.ToDecimal(
						   DB.QueryScalar(
							  sql,
							  DB.GetParams(
								 DB.Param(
									"@Servicio_ID",
									this.Servicio.Servicio_ID
								 )
							  )
						   )
					    );

					//  Determinamos el pago
					Servicio.PagoConductor = Servicio.Precio - Servicio.PagoComisiones;
				} // end if

				//  Guardamos los cambios en la base de datos
				this.Servicio.Update();

				//GMD - 2016-05-20
				//Inserta el usuario que realiza el cambio de fecha de boleto
				Entities.RegistraAsignacionDeServicio.InsertaAsigancionDeServicioPorusuario(Sesion.Usuario_ID, Servicio.Servicio_ID, Servicio.FechaServicio, Servicio.Unidad_ID, Servicio.Conductor_ID);

			} // RealizarCambio

			/// <summary>
			/// Consulta los datos del servicio
			/// </summary>
			/// <param name="servicio_id"></param>
			public void ConsultarServicio(string servicio_id)
			{
				//  Obtiene los datos del servicio
				this.Servicio = Entities.Servicios.Read(servicio_id);

				//  Obtiene la vista del servicio
				this.Vista_Servicio = Entities.Vista_Servicios.Get(servicio_id);

				//  Verificaciones para determinar
				//  si es posible el cambio

				//  Verificamos que el servicio este asignado
				if (this.Servicio.EstatusServicio_ID == 1
				    || this.Servicio.Conductor_ID == null
				    || this.Servicio.FechaServicio == null)
				{
					this.EsPosibleCambio = false;
					AppHelper.ThrowException("El servicio no está asignado a conductor");
				}

				//  Verificamos si el servicio ya ha sido cobrado
				if (this.Servicio.EstatusServicio_ID == 3
				    || this.Servicio.Ticket_ID != null)
				{
					this.EsPosibleCambio = false;
					AppHelper.ThrowException("El servicio ya esta cobrado");
				}

				//  Verificamos si el servicio ha sido cancelado
				if (this.Servicio.EstatusServicio_ID == 4)
				{
					this.EsPosibleCambio = false;
					AppHelper.ThrowException("El servicio esta cancelado");
				}

				//  Configuramos la fecha anterior
				this.FechaAnterior = this.Servicio.FechaServicio.Value.AddDays(-1);

				//  Si llegamos hasta aqui, es posible el cambio
				this.EsPosibleCambio = true;

			} // ConsultarServicio

			/// <summary>
			/// Consulta los datos de la unidad
			/// </summary>
			/// <param name="numeroeconomico"></param>
			public void ConsultarUnidad(int numeroeconomico)
			{
				//  Obtiene los datos de la unidad
				Entities.DatosConductorUnidad datosunidad = Entities.DatosConductorUnidad.Get(numeroeconomico);

				//  Si no obtiene dados, lanzamos error
				if (datosunidad == null)
				{
					AppHelper.ThrowException("La unidad no tiene conductor asignado");
				}

				//  Configuramos las variables
				this.NuevaUnidad_ID = datosunidad.Unidad_ID.Value;
				this.NuevoConductor_ID = datosunidad.Conductor_ID;
				this.NuevoConductor = datosunidad.Conductor;
			} // ConsultarUnidad
		} // end class Model

		#endregion

		#region Properties

		/// <summary>
		/// El modelo de negocios para utilizar en la forma
		/// </summary>
		RastreoCambioBoletos_Model Model;

		/// <summary>
		/// El modelo de caja de servicios
		/// </summary>
		forms.CajaDeServicios.CajaDeServicios_Model ServiciosModel;

		#endregion

		#region Events

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			//  Instanciamos los modelos
			Model = new RastreoCambioBoletos_Model();
			ServiciosModel = new CajaDeServicios.CajaDeServicios_Model();

			//  Actualizamos el botón, para asegurarnos 
			//  de que esté inactivo al inicio
			ActualizarBotonCambio();

			//  Agregamos validacion de solo números a la caja de texto
			AppHelper.AddTextBoxesOnlyNumbersValidation(this.ServicioTextBox, this.NumeroEconomicoTextBox);

			base.BindData();
		}

		/// <summary>
		/// Al hacer "Enter" en la caja de texto del servicio,
		/// consulta la información del servicio y la despliega
		/// en el apartado correspondiente, además de calcular la fecha
		/// a la cual se cambiaría el servicio
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ServicioTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			//  Si presionamos enter
			if (e.KeyData == Keys.Enter)
			{
				//  Intentamos consultar los servicios
				AppHelper.Try(
				    delegate
				    {
					    //  El reset
					    this.Model.EsPosibleCambio = false;
					    this.Model.Vista_Servicio = null;
					    this.vista_ServiciosBindingSource.Clear();
					    ActualizarBotonCambio();

					    //  Efectuamos las validaciones
					    //  Que no este vacia
					    if (string.IsNullOrEmpty(ServicioTextBox.Text))
					    {
						    throw new Exception("Debe capturar un código de boleto");
					    }
					    //  Que tenga la longitud necesaria
					    if (this.ServicioTextBox.Text.Length < 17)
					    {
						    throw new Exception("La longitud mínima de boleto es de 17 caracteres");
					    }
					    //  Que sea numerica
					    if (!AppHelper.IsNumeric(ServicioTextBox.Text))
					    {
						    throw new Exception("El boleto debe ser numérico");
					    }

					    this.Model.ConsultarServicio(ServicioTextBox.Text);
				    }
				);

				//  Si fueron consultados correctamente
				if (this.Model.Vista_Servicio != null)
				{
					this.vista_ServiciosBindingSource.DataSource = this.Model.Vista_Servicio;
					ActualizarBotonCambio();
				}

			} // end if

		} // end void

		/// <summary>
		/// Al hacer enter buscamos la unidad
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UnidadTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == Keys.Enter)
				{
					btnKilometraje.Visible = false;
					//  Validamos que se haya capturado el número económico
					if (!string.IsNullOrEmpty(NumeroEconomicoTextBox.Text))
					{
						//  Validamos que el número económico sea numérico
						if (!AppHelper.IsNumeric(NumeroEconomicoTextBox.Text))
						{
							throw new Exception("La unidad debe contener solo datos numéricos");
						}

						//  Asignamos las variables
						ServiciosModel.NumeroEconomico = Convert.ToInt32(NumeroEconomicoTextBox.Text);
						ServiciosModel.FechaPago = FechaPagoDateTimePicker.Value;
						try
						{
							ServiciosModel.Estacion_ID = Sesion.Estacion_ID.Value;
						}
						catch
						{
							throw new Exception("Se requiere solo una Empresa y una Estación Asignada");
						}

						//  Consultamos la unidad
						ServiciosModel.ObtenerDatosDeUnidadEstacion();

						btnKilometraje.Visible = ServiciosModel.MontoDiario <= 0;

						//  Asignamos la variable del nombre del conductor
						this.NombreConductorTextBox.Text = ServiciosModel.NombreConductor;

						//  Consultamos los servicios
						ConsultarServicios();

						//  Si no tiene servicios pendientes
						if (ServiciosModel.ServiciosPendientes.Count == 0)
						{
							//  Enviamos mensaje
							AppHelper.Info(string.Format("El conductor no tiene servicios pendientes para fecha {0:d}.", ServiciosModel.FechaPago));
						} // end if

					} // end if

				} // end if

			} // end try
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			} // end catch

		} // ebd void UnidadTextBox_KeyUp

		/// <summary>
		/// Consulta los servicios pendientes del conductor
		/// </summary>
		private void ConsultarServicios()
		{
			ServiciosModel.ObtenerServiciosPendientes();
			ServiciosModel.CalcularTotales();
			serviciosPendientesConductorBindingSource.DataSource = ServiciosModel.ServiciosPendientes;
			this.TotalServiciosTextBox.Text = string.Format("{0:C}", this.ServiciosModel.TotalServicios);
		} // ConsultarServicios

		#endregion

		/// <summary>
		/// Habilita o deshabilita el botón para realizar el cambio
		/// a partir de la condición 'EsPosibleCambio'
		/// </summary>
		private void ActualizarBotonCambio()
		{
			if (Model.EsPosibleCambio)
			{
				this.ActualizarButton.Enabled = true;
				this.ActualizarButton.BackColor = Color.Green;
				this.ActualizarButton.ForeColor = Color.White;
				this.ActualizarButton.Text = "Pagar el boleto hoy";
			}
			else
			{
				this.ActualizarButton.Enabled = false;
				this.ActualizarButton.BackColor = Color.Red;
				this.ActualizarButton.ForeColor = Color.White;
				this.ActualizarButton.Text = "No se puede pagar hoy";
			}
		}

		/// <summary>
		/// Al hacer clic en 'Actualizar', realizamos el cambio de unidad
		/// y/o fecha
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ActualizarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(
			    delegate
			    {
				    //  Asignamos las variables al modelo
				    Model.NuevaUnidad_ID = ServiciosModel.DatosConductor.Unidad_ID.Value;
				    Model.NuevoConductor_ID = ServiciosModel.DatosConductor.Conductor_ID;
				    Model.FechaServicio = FechaPagoDateTimePicker.Value;

				    //  Efectuamos el cambio
				    Model.RealizarCambio();

				    //  Regresamos a los valores de default
				    //  limpiamos la forma
				    Model.Vista_Servicio = null;
				    Model.Servicio = null;
				    Model.EsPosibleCambio = false;
				    this.vista_ServiciosBindingSource.ResetBindings(false);

				    //  Consultamos los servicios
				    ConsultarServicios();

				    //  Actualizamos el estado del botón
				    ActualizarBotonCambio();

				    //  Limpiamos la caja de texto de servicio
				    ServicioTextBox.Text = "";

				    //  y le damos el foco
				    ServicioTextBox.Focus();
			    },
			    this
			);
		}

		private void btnKilometraje_Click(object sender, EventArgs e)
		{
			forms.aeropuerto.herramientas.ActualizaKilometrajeNomina frm = new aeropuerto.herramientas.ActualizaKilometrajeNomina(ServiciosModel.DatosConductor);
			frm.ShowDialog();
		}

		private void ServiciosPendientesGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 1)
			{
				e.Value = e.RowIndex + 1;
			}
		} // end void ActualizarButton_Click

	} // end class

} // end namespace
