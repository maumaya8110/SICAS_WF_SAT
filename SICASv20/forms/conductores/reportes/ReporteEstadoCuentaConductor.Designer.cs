namespace SICASv20.forms
{
    partial class ReporteEstadoCuentaConductor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AnioComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CuentaComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectCuentasDeEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.EmpresaComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.get_SelectEmpresasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectEmpresasTableAdapter();
            this.get_SelectCuentasDeEmpresaTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectCuentasDeEmpresaTableAdapter();
            this.Reporte_CuentaConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getMesDeAnioCuentaConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_MesDeAnioCuentaConductoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_MesDeAnioCuentaConductoresTableAdapter();
            this.getAniosCuentaConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_AniosCuentaConductoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_AniosCuentaConductoresTableAdapter();
            this.reporte_CuentaConductoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_CuentaConductoresTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectCuentasDeEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_CuentaConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMesDeAnioCuentaConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAniosCuentaConductoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "ReporteCuentaConductores_DataSet";
            reportDataSource6.Value = this.Reporte_CuentaConductoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_EstadoCuentaConductor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 121);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1021, 547);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MesComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AnioComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CuentaComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EmpresaComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // MesComboBox
            // 
            this.MesComboBox.DataSource = this.getMesDeAnioCuentaConductoresBindingSource;
            this.MesComboBox.DisplayMember = "Nombre";
            this.MesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MesComboBox.FormattingEnabled = true;
            this.MesComboBox.Location = new System.Drawing.Point(359, 54);
            this.MesComboBox.Name = "MesComboBox";
            this.MesComboBox.Size = new System.Drawing.Size(150, 23);
            this.MesComboBox.TabIndex = 7;
            this.MesComboBox.ValueMember = "Mes";
            this.MesComboBox.SelectionChangeCommitted += new System.EventHandler(this.MesComboBox_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mes:";
            // 
            // AnioComboBox
            // 
            this.AnioComboBox.DataSource = this.getAniosCuentaConductoresBindingSource;
            this.AnioComboBox.DisplayMember = "Nombre";
            this.AnioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnioComboBox.FormattingEnabled = true;
            this.AnioComboBox.Location = new System.Drawing.Point(359, 25);
            this.AnioComboBox.Name = "AnioComboBox";
            this.AnioComboBox.Size = new System.Drawing.Size(150, 23);
            this.AnioComboBox.TabIndex = 5;
            this.AnioComboBox.ValueMember = "Anio";
            this.AnioComboBox.SelectionChangeCommitted += new System.EventHandler(this.AnioComboBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Año:";
            // 
            // CuentaComboBox
            // 
            this.CuentaComboBox.DataSource = this.getSelectCuentasDeEmpresaBindingSource;
            this.CuentaComboBox.DisplayMember = "Nombre";
            this.CuentaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CuentaComboBox.FormattingEnabled = true;
            this.CuentaComboBox.Location = new System.Drawing.Point(77, 54);
            this.CuentaComboBox.Name = "CuentaComboBox";
            this.CuentaComboBox.Size = new System.Drawing.Size(202, 23);
            this.CuentaComboBox.TabIndex = 3;
            this.CuentaComboBox.ValueMember = "Cuenta_ID";
            this.CuentaComboBox.SelectionChangeCommitted += new System.EventHandler(this.CuentaComboBox_SelectionChangeCommitted);
            // 
            // getSelectCuentasDeEmpresaBindingSource
            // 
            this.getSelectCuentasDeEmpresaBindingSource.DataMember = "Get_SelectCuentasDeEmpresa";
            this.getSelectCuentasDeEmpresaBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cuenta:";
            // 
            // EmpresaComboBox
            // 
            this.EmpresaComboBox.DataSource = this.getSelectEmpresasBindingSource;
            this.EmpresaComboBox.DisplayMember = "Nombre";
            this.EmpresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresaComboBox.FormattingEnabled = true;
            this.EmpresaComboBox.Location = new System.Drawing.Point(77, 25);
            this.EmpresaComboBox.Name = "EmpresaComboBox";
            this.EmpresaComboBox.Size = new System.Drawing.Size(202, 23);
            this.EmpresaComboBox.TabIndex = 1;
            this.EmpresaComboBox.ValueMember = "Empresa_ID";
            this.EmpresaComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresaComboBox_SelectionChangeCommitted);
            // 
            // getSelectEmpresasBindingSource
            // 
            this.getSelectEmpresasBindingSource.DataMember = "Get_SelectEmpresas";
            this.getSelectEmpresasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa:";
            // 
            // get_SelectEmpresasTableAdapter
            // 
            this.get_SelectEmpresasTableAdapter.ClearBeforeFill = true;
            // 
            // get_SelectCuentasDeEmpresaTableAdapter
            // 
            this.get_SelectCuentasDeEmpresaTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_CuentaConductoresBindingSource
            // 
            this.Reporte_CuentaConductoresBindingSource.DataMember = "Reporte_CuentaConductores";
            this.Reporte_CuentaConductoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // getMesDeAnioCuentaConductoresBindingSource
            // 
            this.getMesDeAnioCuentaConductoresBindingSource.DataMember = "Get_MesDeAnioCuentaConductores";
            this.getMesDeAnioCuentaConductoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_MesDeAnioCuentaConductoresTableAdapter
            // 
            this.get_MesDeAnioCuentaConductoresTableAdapter.ClearBeforeFill = true;
            // 
            // getAniosCuentaConductoresBindingSource
            // 
            this.getAniosCuentaConductoresBindingSource.DataMember = "Get_AniosCuentaConductores";
            this.getAniosCuentaConductoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_AniosCuentaConductoresTableAdapter
            // 
            this.get_AniosCuentaConductoresTableAdapter.ClearBeforeFill = true;
            // 
            // reporte_CuentaConductoresTableAdapter
            // 
            this.reporte_CuentaConductoresTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Get_ArrendamientosDisponiblesTableAdapter = null;
            this.tableAdapterManager.Get_EmpresasPropietariasTableAdapter = null;
            this.tableAdapterManager.Get_ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ReporteEstadoCuentaConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 688);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteEstadoCuentaConductor";
            this.Text = "ReporteEstadoCuentaEmpresa";            
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectCuentasDeEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_CuentaConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMesDeAnioCuentaConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAniosCuentaConductoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox MesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AnioComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CuentaComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EmpresaComboBox;
        private System.Windows.Forms.Label label1;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource getSelectEmpresasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectEmpresasTableAdapter get_SelectEmpresasTableAdapter;
        private System.Windows.Forms.BindingSource getSelectCuentasDeEmpresaBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectCuentasDeEmpresaTableAdapter get_SelectCuentasDeEmpresaTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_CuentaConductoresBindingSource;
        private System.Windows.Forms.BindingSource getMesDeAnioCuentaConductoresBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_MesDeAnioCuentaConductoresTableAdapter get_MesDeAnioCuentaConductoresTableAdapter;
        private System.Windows.Forms.BindingSource getAniosCuentaConductoresBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_AniosCuentaConductoresTableAdapter get_AniosCuentaConductoresTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_CuentaConductoresTableAdapter reporte_CuentaConductoresTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}