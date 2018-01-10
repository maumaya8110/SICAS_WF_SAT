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
    /// Formulario contenedor, encargado de contener a otros formularios, uno a la vez
    /// dentro de su interfaz
    /// </summary>
    public partial class containerForm : GradientForms.BaseFormGradient
    {
        /// <summary>
        /// Crea una nueva instancia del formulario contenedor
        /// </summary>
        public containerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El formulario de ayuda
        /// </summary>
        public Ayuda AyudaForm
        {
            get { return _AyudaForm; }
            set { _AyudaForm = value; }
        }
        private Ayuda _AyudaForm = new Ayuda();

        /// <summary>
        /// Método utilizado para cambiar el formulario contenido en la instancia de ContainderForm
        /// </summary>
        /// <param name="formulario">El nombre de la opción del formulario</param>
        public virtual void SwitchForma(string formulario)
        {

        }

        /// <summary>
        /// Método utilizado para cambiar el formulario contenido en la instancia de ContainderForm
        /// </summary>
        /// <param name="formulario">El nombre de la opción del formulario</param>
        /// <param name="forma">La instancia del formulario destino a utilizar</param>
        public virtual void SwitchForma(string formulario, baseForm forma)
        {
 
        }

        /// <summary>
        /// Utilizado para navegar a un formulario en blanco
        /// </summary>
        public virtual void CancelCurrentForm()
        {
 
        } // end CancelCurrentForm

    } // end class

} // end namespace