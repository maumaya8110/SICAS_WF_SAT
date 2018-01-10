using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SICASv20.Entities;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario de ayuda
    /// Consta de un control web browser para desplegar ayuda remota
    /// </summary>
    public partial class Ayuda : Form
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de ayuda
        /// </summary>
        public Ayuda()
        {
            InitializeComponent();
        }

        /// <summary>
        /// La url del recurso remoto a mostrar en el explorador
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        private string _Url;

        /// <summary>
        /// El nombre de la opción en el sistema para la cual se desplegará la ayuda
        /// </summary>
        public string Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        private string _Opcion;

        /// <summary>
        /// El formulario padre
        /// </summary>
        public containerForm Padre
        {
            get { return _Padre; }
            set { _Padre = value; }
        }
        private containerForm _Padre;

        /// <summary>
        /// Configura el manual para su navegación en el explorador de ayuda
        /// </summary>
        /// <param name="op">El nombre del manual</param>
        public void SetManual(string manual)
        {
            //  La dirección URL del manual
            this.Url = Sesion.DB.Server + "//Manual//" + manual;

            //  Verificamos sea válida
            if (!String.IsNullOrEmpty(this.Url))
            {
                //  Enviamos el navegador a la dirección
                this.AyudaBrowser.Navigate(this.Url);
            }
        }

        /// <summary>
        /// Configura la opción para su navegación en el explorador de ayuda
        /// </summary>
        /// <param name="op">El nombre de la opción, formulario o pantalla a desplegar ayuda</param>
        public void SetOpcion(string op)
        {
            //  Configuramos la opción
            this.Opcion = op;
            
            //  Obtenemos la url desde la base de datos
            this.Url = AyudasOpciones.GetUrlByOpcion(this.Opcion);
            
            //  Si nos devolvió una dirección
            if (!String.IsNullOrEmpty(this.Url))
            {
                //  Navegamos a ella en el webbrowser
                this.AyudaBrowser.Navigate(this.Url);                
            }
        } // end SetOpcion
    } // end class
} // end namespace
