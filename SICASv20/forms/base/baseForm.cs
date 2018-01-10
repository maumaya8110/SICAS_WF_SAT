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
    /// El formulario que se toma como base en todo el sistema
    /// </summary>
    public partial class baseForm : GradientForms.BaseFormGradient
    {
        /// <summary>
        /// Crea una nueva instancia del formulario base
        /// </summary>
        public baseForm()
        {
            InitializeComponent();           
            //this.BackgroundImage = System.Drawing.Image.FromFile(AppHelper.ImagePath + "background1.jpg");
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            TopLevel = false;
        }

        /// <summary>
        /// El formulario padre, contenedor de la instancia del formulario
        /// </summary>
        public containerForm Padre
        {
            get { return _Padre; }
            set { _Padre = value; }
        }
        private containerForm _Padre;

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public virtual void BindData()
        {
            this.Color1 = Padre.Color1;
        }

        /// <summary>
        /// Despliega la ayuda dinámica
        /// </summary>
        private void AyudaButton_Click(object sender, EventArgs e)
        {
            if (Padre.AyudaForm.IsDisposed)
            {
                Padre.AyudaForm = new Ayuda();
            }
            Padre.AyudaForm.SetOpcion(this.Name);
            Padre.AyudaForm.Show();
        }

        /// <summary>
        /// Despliega la ayuda dinámica
        /// </summary>
        private void baseForm_KeyUp(object sender, KeyEventArgs e)
        {
            
        } // end baseForm_KeyUp

    } // end class

} // end namespace