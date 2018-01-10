/*
 * blankForm
 * Representa una forma en blanco
 * 
 * **  HISTORIAL  **
 *      2012-10-27, Modificado por Luis Espino
 *          Se modificó para que sea este formulario el que verifique          
 *          el formulario inicial de los usuarios
 *          Finalmente se descontinuó esta modificación
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
    /// <summary>
    /// Representa una formulario en blanco, utilizado al iniciar el sistema,
    /// a menos que el rol de usuario tengo configurado un formulario inicial
    /// </summary>
    public partial class blankForm : baseForm
    {
        /// <summary>
        /// Crea una instance de este formulario, en blanco
        /// </summary>
        public blankForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos al formulario,
        /// inicializa variables y procesos
        /// </summary>
        public override void BindData()
        {            
            
        }

        /// <summary>
        /// Ocurre al cargar la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blankForm_Load(object sender, EventArgs e)
        {

        } 

    } // end class

} // end namespace
