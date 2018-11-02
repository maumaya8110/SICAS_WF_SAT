using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SICASv20;

namespace SICASv20.forms
{
    public partial class ConductoresIdGNV : Form
    {
        public string _topvar;
        public string _conductorid;

        public ConductoresIdGNV()
        {
            InitializeComponent();
        }

        private void ConductoresIdGNV_Load(object sender, EventArgs e)
        {
            lbltop.Text = _topvar;
            lblconductorid.Text = _conductorid;
            
            
             DataSet dsx=DSConsulta("select top "+ lbltop.Text +" * from conductores order by conductor_id desc");

             dgvConductores.DataSource = dsx.Tables[0];
        }

        public DataSet DSConsulta(string query)
        {

            SqlConnection con = new SqlConnection( global::SICASv20.Properties.Settings.Default.SICASCentralConnectionString);

            con.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = query;
            cm.CommandType = CommandType.Text;
            cm.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cm);

            DataSet ds = new DataSet();
            da.Fill(ds);


            return ds;

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.dgvConductores, this);
        }
    }
}
