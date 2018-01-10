using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ServiciosMantenimientosPrecios : baseForm
    {
        public ServiciosMantenimientosPrecios()
        {
            InitializeComponent();
        }

        class ServiciosMantenimientosPrecios_Model
        {
            private Entities.ServiciosMantenimientos _ServicioMantenimiento;
            public Entities.ServiciosMantenimientos ServicioMantenimiento
            {
                get { return _ServicioMantenimiento; }
                set { _ServicioMantenimiento = value; }
            }

            private BindingList<Entities.Vista_PreciosServicioMantenimiento> _Precios;
            public BindingList<Entities.Vista_PreciosServicioMantenimiento> Precios
            {
                get { return _Precios; }
                set { _Precios = value; }
            }

            public void ConsultarPrecios()
            {
                if (this.ServicioMantenimiento == null)
                    throw new Exception("El servicio mantenimiento no puede ser nulo");

                this.Precios =
                    new BindingList<Entities.Vista_PreciosServicioMantenimiento>(
                        Entities.Vista_PreciosServicioMantenimiento.Get(
                            this.ServicioMantenimiento.ServicioMantenimiento_ID,
                            Sesion.Empresa_ID.Value,
                            Sesion.Estacion_ID.Value
                        )
                    );
            }

            public void Guardar()
            {
                string sql = @"IF	EXISTS(
		SELECT * FROM ServiciosMantenimientosPrecios
		WHERE	TipoClienteTaller_ID = @TipoClienteTaller_ID
		AND		ServicioMantenimiento_ID = @ServicioMantenimiento_ID
        AND     Empresa_ID = @Empresa_ID
        AND     Estacion_ID = @Estacion_ID
	)
BEGIN
	UPDATE	ServiciosMantenimientosPrecios
	SET	Precio = @Precio
	WHERE	TipoClienteTaller_ID = @TipoClienteTaller_ID
	AND		ServicioMantenimiento_ID = @ServicioMantenimiento_ID
    AND     Empresa_ID = @Empresa_ID
    AND     Estacion_ID = @Estacion_ID
END
ELSE
BEGIN
	INSERT INTO ServiciosMantenimientosPrecios
	VALUES ( @ServicioMantenimiento_ID, @TipoClienteTaller_ID, @Precio, @Empresa_ID, @Estacion_ID )
END";
                foreach (Entities.Vista_PreciosServicioMantenimiento precio in this.Precios)
                {
                    DB.ExecuteCommand(
                        sql,
                        DB.GetParams(
                            DB.Param("@ServicioMantenimiento_ID", precio.ServicioMantenimiento_ID),
                            DB.Param("@TipoClienteTaller_ID", precio.TipoClienteTaller_ID),
                            DB.Param("@Precio", precio.Precio),
                            DB.Param("@Empresa_ID", Sesion.Empresa_ID.Value),
                            DB.Param("@Estacion_ID", Sesion.Estacion_ID.Value)
                        )
                    );
                } // End foreach
            } // End void

            public void ConsultarServicioMantenimiento(int serviciomantenimiento_id)
            {
                this.ServicioMantenimiento = Entities.ServiciosMantenimientos.Read(serviciomantenimiento_id);
            }
        } // End Class Model

        private ServiciosMantenimientosPrecios_Model Model;

        private int _ServicioMantenimiento_ID;
        public int ServicioMantenimiento_ID
        {
            get { return _ServicioMantenimiento_ID; }
            set { _ServicioMantenimiento_ID = value; }
        }

        public override void BindData()
        {            
            this.Model = new ServiciosMantenimientosPrecios_Model();
            this.Model.ConsultarServicioMantenimiento(this.ServicioMantenimiento_ID);
            this.Model.ConsultarPrecios();
            this.NombreTextBox.Text = this.Model.ServicioMantenimiento.Nombre;
            this.vista_PreciosServicioMantenimientoBindingSource.DataSource = this.Model.Precios;
            base.BindData();
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Guardar();
                    AppHelper.Info("Precios actualizados");
                },
                this
            );
        }
    } // End Class
} // End Namespace
