using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class SeleccionarCajaSesion : Form
    {
        public SeleccionarCajaSesion()
        {
            InitializeComponent();
            this.Model = new SeleccionarCajaSesion_Model();
        }

        #region Properties
        private SeleccionarCajaSesion_Model Model;

        private int _Caja_ID;
        public int Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private string _Usuario_ID;
        public string Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Model
        class SeleccionarCajaSesion_Model
        {
            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private List<Entities.Cajas> _Cajas;
            public List<Entities.Cajas> Cajas
            {
                get { return _Cajas; }
                set { _Cajas = value; }
            }

            public void Consultar()
            {
                if (!string.IsNullOrEmpty(this.Usuario_ID))
                {
                    this.Cajas = Entities.Cajas.ReadPorUsuario(this.Usuario_ID);
                }
                else
                {
                    this.Cajas = Entities.Cajas.ReadList(
                        DB.Param("Estacion_ID", Sesion.Estacion_ID),
                        DB.Param("Activa", true)
                    );
                }                
            }
        }
        #endregion

        #region Methods
        #endregion

        #region Events

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try
            (
                delegate
                {
                    Entities.Cajas caja =
                        (Entities.Cajas)this.CajasComboBox.SelectedItem;
                    this.Caja_ID = caja.Caja_ID;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            );
        }

        private void SeleccionarCajaSesion_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Usuario_ID = this.Usuario_ID;
                    this.Model.Consultar();                   
                    this.cajasBindingSource.DataSource = this.Model.Cajas;
                }
            );
        }               
        #endregion
    }
}
