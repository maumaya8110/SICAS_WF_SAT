/*
 * Modificado el 16 de Octubre de 2012
 * por Luis Espino
 * 
 * Se cambia la fuente de datos de DataSet
 * a objeto Entities.Unidades
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaUnidad : baseForm
    {
        public AltaUnidad()
        {
            InitializeComponent();
        }

        private void unidadesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void AltaUnidad_Load(object sender, EventArgs e)
        {

        }

        public override void BindData()
        {
            this.get_ArrendamientosDisponiblesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_ArrendamientosDisponibles);

            this.get_ConcesionesDisponiblesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_ConcesionesDisponibles);

            this.selectEmpresasInternasBindingSource.DataSource = Sesion.Empresas;

            this.selectEstacionesBindingSource.DataSource = Sesion.Estaciones;

            this.locacionesUnidadesTableAdapter.Fill(this.sICASCentralDataSet.LocacionesUnidades);

            this.estatusUnidadesTableAdapter.Fill(this.sICASCentralDataSet.EstatusUnidades);

            this.get_ModelosUnidadesTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_ModelosUnidades);

            this.get_EmpresasPropietariasTableAdapter.Fill(this.sICASCentralQuerysDataSet.Get_EmpresasPropietarias);

            unidadesBindingSource.AddNew();

            AppHelper.SetContainerDBValidations(this, "Unidades");

            base.BindData();
        }

        private void DoSave()
        {            
            //this.unidadesBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
            Entities.Unidades unidad = (Entities.Unidades)this.unidadesBindingSource.Current;
            
            //  Obtenemos el estatus
            Entities.LocacionesUnidades locacionunidad = Entities.LocacionesUnidades.Read(unidad.LocacionUnidad_ID);
            //  Configuramos el estatus
            unidad.EstatusUnidad_ID = locacionunidad.EstatusUnidad_ID;
            //  Realizamos la inserción
            unidad.Create();

            //  Creamos el registro de locacion y unidad
            Entities.Unidades_Locaciones unidad_locacion = new Entities.Unidades_Locaciones();
            unidad_locacion.Unidad_ID = unidad.Unidad_ID;
            unidad_locacion.LocacionUnidad_ID = unidad.LocacionUnidad_ID;
            unidad_locacion.Fecha = DB.GetDate();
            unidad_locacion.Comentarios = "ALTA DE LA UNIDAD";
            unidad_locacion.Usuario_ID = Sesion.Usuario_ID;
            unidad_locacion.Create();

            AppHelper.Info("Unidad creada");

            unidadesBindingSource.AddNew();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(DoSave, this);
        }
    }
}
