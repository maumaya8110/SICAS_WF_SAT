namespace SICASv20.forms
{
    partial class ReporteFlotilla
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
            this.reporteFlotillaPorEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_FlotillaPorEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_FlotillaPorEstacionTableAdapter();
            this.Estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.estacionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstacionesTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFlotillaPorEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteFlotillaPorEstacionBindingSource
            // 
            this.reporteFlotillaPorEstacionBindingSource.DataMember = "Reporte_FlotillaPorEstacion";
            this.reporteFlotillaPorEstacionBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Reporte_Flotilla_DataSet";
            reportDataSource1.Value = this.reporteFlotillaPorEstacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_Flotilla.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1023, 613);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporte_FlotillaPorEstacionTableAdapter
            // 
            this.reporte_FlotillaPorEstacionTableAdapter.ClearBeforeFill = true;
            // 
            // Estacion_IDComboBox
            // 
            this.Estacion_IDComboBox.DataSource = this.estacionesBindingSource;
            this.Estacion_IDComboBox.DisplayMember = "Nombre";
            this.Estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estacion_IDComboBox.FormattingEnabled = true;
            this.Estacion_IDComboBox.Location = new System.Drawing.Point(84, 34);
            this.Estacion_IDComboBox.Name = "Estacion_IDComboBox";
            this.Estacion_IDComboBox.Size = new System.Drawing.Size(204, 23);
            this.Estacion_IDComboBox.TabIndex = 1;
            this.Estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataMember = "Estaciones";
            this.estacionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estacion:";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(294, 5);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 49);
            this.BuscarButton.TabIndex = 3;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // estacionesTableAdapter
            // 
            this.estacionesTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Empresa:";
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.empresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(84, 8);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(204, 23);
            this.EmpresasComboBox.TabIndex = 14;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            // 
            // ReporteFlotilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.EmpresasComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Estacion_IDComboBox);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteFlotilla";
            this.Text = "ReporteFlotilla";
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.Estacion_IDComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.BuscarButton, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.EmpresasComboBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.reporteFlotillaPorEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteFlotillaPorEstacionBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_FlotillaPorEstacionTableAdapter reporte_FlotillaPorEstacionTableAdapter;
        private System.Windows.Forms.ComboBox Estacion_IDComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarButton;
        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private SICASCentralDataSetTableAdapters.EstacionesTableAdapter estacionesTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
    }
}