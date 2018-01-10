using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class NuevaOrdenTrabajo : baseForm
    {
        public NuevaOrdenTrabajo()
        {
            InitializeComponent();
            OrdenTrabajo = new Entities.OrdenesTrabajos();                        
            LoadUserControls();            
        }
        
        public Entities.OrdenesTrabajos OrdenTrabajo;

        public bool EsCotizacion;

        private int? _ModeloUnidad_ID;
        public int? ModeloUnidad_ID
        {
            get { return _ModeloUnidad_ID; }
            set { _ModeloUnidad_ID = value; }
        }

        private int? _Modelo_ID;
        public int? Modelo_ID
        {
            get { return _Modelo_ID; }
            set { _Modelo_ID = value; }
        }

        Dictionary<string, baseUserControl> UControls = new Dictionary<string, baseUserControl>();
        
        public TiposMantenimientosUC tiposMantenimientosControl;
        public UnidadUC unidadControl;
        public ServiciosUC serviciosControl;
        public MecanicoUC mecanicoControl;
        public CobrarAUC cobrarAControl;
        public ResumenUC resumenControl;
        public RefaccionesUC refaccionesControl;

        private void LoadUserControls()
        {
            UControls.Clear();
            InnerPanel.Controls.Clear();

            tiposMantenimientosControl = new TiposMantenimientosUC();
            tiposMantenimientosControl.Name = "TiposMantenimientos";
            tiposMantenimientosControl.Padre = this;
            UControls.Add("TiposMantenimientos", tiposMantenimientosControl);
            InnerPanel.Controls.Add(tiposMantenimientosControl);

            unidadControl = new UnidadUC();
            unidadControl.Name = "Unidad";
            unidadControl.Padre = this;
            UControls.Add("Unidad", unidadControl);
            InnerPanel.Controls.Add(unidadControl);

            serviciosControl = new ServiciosUC();
            serviciosControl.Name = "Servicios";
            serviciosControl.Padre = this;
            UControls.Add("Servicios", serviciosControl);
            InnerPanel.Controls.Add(serviciosControl);

            mecanicoControl = new MecanicoUC();
            mecanicoControl.Name = "Mecanico";
            mecanicoControl.Padre = this;
            UControls.Add("Mecanico", mecanicoControl);
            InnerPanel.Controls.Add(mecanicoControl);

            cobrarAControl = new CobrarAUC();
            cobrarAControl.Name = "CobrarA";
            cobrarAControl.Padre = this;
            UControls.Add("CobrarA", cobrarAControl);
            InnerPanel.Controls.Add(cobrarAControl);

            resumenControl = new ResumenUC();
            resumenControl.Name = "Resumen";
            resumenControl.Padre = this;
            UControls.Add("Resumen", resumenControl);
            InnerPanel.Controls.Add(resumenControl);

            refaccionesControl = new RefaccionesUC();
            refaccionesControl.Name = "Refacciones";
            refaccionesControl.Padre = this;
            UControls.Add("Refacciones", refaccionesControl);
            InnerPanel.Controls.Add(refaccionesControl);
        }

        public void SwitchPanel(string name)
        {            
            this.InnerPanel.Controls[name].BringToFront();
        }

        public override void BindData()
        {
            this.tiposMantenimientosControl.BindData();
            SwitchPanel("TiposMantenimientos");
            base.BindData();
        }

        public void Clear()
        {
            OrdenTrabajo = new Entities.OrdenesTrabajos();
            LoadUserControls();
            AppHelper.ClearControl(this);
            BindData();
        }

        public void MostrarTotales()
        {
            this.ManoDeObraTextBox.Text = AppHelper.N2(OrdenTrabajo.ManoObra);
            this.RefaccionestextBox.Text = AppHelper.N2(OrdenTrabajo.Refacciones);
            this.SubTotalTextBox.Text = AppHelper.N2(OrdenTrabajo.Subtotal);
            this.IVATextBox.Text = AppHelper.N2(OrdenTrabajo.IVA);
            this.TotalTextBox.Text = AppHelper.N2(OrdenTrabajo.Total);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(Clear), this);
        }

    }
}
