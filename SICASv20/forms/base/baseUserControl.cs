using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// UserControl que sirve de base para otros UserControl en todo el sistema
    /// </summary>
	public partial class baseUserControl: UserControl
	{
        /// <summary>
        /// Crea una nueva instancia de baseUserControl
        /// </summary>
		public baseUserControl()
		{
			InitializeComponent();
		}
	} // end class
} // end namespace
