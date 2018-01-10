namespace SICASv20.forms
{
    partial class ReporteSaldosCuentasConductores
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Reporte_SaldosCuentasConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.reporteSaldosCuentasConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_SaldosCuentasConductoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_SaldosCuentasConductoresTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConductorEnContratoCheckBox = new System.Windows.Forms.CheckBox();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.UnidadTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_SaldosCuentasConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteSaldosCuentasConductoresBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_SaldosCuentasConductoresBindingSource
            // 
            this.Reporte_SaldosCuentasConductoresBindingSource.DataMember = "Reporte_SaldosCuentasConductores";
            this.Reporte_SaldosCuentasConductoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SaldosCuentasConductores_DataSet";
            reportDataSource1.Value = this.Reporte_SaldosCuentasConductoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.conductores.Reporte_SaldosConductores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(19, 122);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(945, 497);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Drillthrough += new Microsoft.Reporting.WinForms.DrillthroughEventHandler(this.reportViewer1_Drillthrough);
            // 
            // reporte_SaldosCuentasConductoresTableAdapter
            // 
            this.reporte_SaldosCuentasConductoresTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConductorEnContratoCheckBox);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.UnidadTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EmpresasComboBox);
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 656);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de saldos de conductores";
            // 
            // ConductorEnContratoCheckBox
            // 
            this.ConductorEnContratoCheckBox.AutoSize = true;
            this.ConductorEnContratoCheckBox.Location = new System.Drawing.Point(530, 94);
            this.ConductorEnContratoCheckBox.Name = "ConductorEnContratoCheckBox";
            this.ConductorEnContratoCheckBox.Size = new System.Drawing.Size(189, 19);
            this.ConductorEnContratoCheckBox.TabIndex = 21;
            this.ConductorEnContratoCheckBox.Text = "Solo Conductores en Contrato";
            this.ConductorEnContratoCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.Location = new System.Drawing.Point(90, 57);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.Size = new System.Drawing.Size(346, 21);
            this.ConductorTextBox.TabIndex = 20;
            // 
            // UnidadTextBox
            // 
            this.UnidadTextBox.Location = new System.Drawing.Point(90, 31);
            this.UnidadTextBox.Name = "UnidadTextBox";
            this.UnidadTextBox.Size = new System.Drawing.Size(135, 21);
            this.UnidadTextBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Conductor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Unidad:";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(887, 34);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(77, 47);
            this.BuscarButton.TabIndex = 16;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Estación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Empresa:";
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.empresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(526, 31);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(348, 23);
            this.EmpresasComboBox.TabIndex = 12;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(526, 60);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(348, 23);
            this.EstacionesComboBox.TabIndex = 13;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // ReporteSaldosCuentasConductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteSaldosCuentasConductores";
            this.Text = "ReporteSaldosCuentasConductores";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_SaldosCuentasConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteSaldosCuentasConductoresBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource reporteSaldosCuentasConductoresBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_SaldosCuentasConductoresTableAdapter reporte_SaldosCuentasConductoresTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.TextBox UnidadTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource Reporte_SaldosCuentasConductoresBindingSource;
        private System.Windows.Forms.CheckBox ConductorEnContratoCheckBox;
    }
}