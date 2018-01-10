namespace SICASv20.forms
{
    partial class Adendums
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboConductores = new System.Windows.Forms.ComboBox();
            this.comboContrato = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvContratosAdendums = new System.Windows.Forms.DataGridView();
            this.contratoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAdendum = new System.Windows.Forms.DataGridView();
            this.ActualizarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewLinkColumn();
            this.adendumIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contratoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indefinidoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacionAdendumIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMontoAjustado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiasAjustar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adendumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnHistorialAdendum = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratosAdendums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdendum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adendumBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 653);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboConductores);
            this.groupBox1.Controls.Add(this.comboContrato);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 653);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administracion de Adendums";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Unidad:";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataSource = this.contratosBindingSource;
            this.comboBox1.DisplayMember = "Unidad";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(626, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 26);
            this.comboBox1.TabIndex = 8;
            // 
            // contratosBindingSource
            // 
            this.contratosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ContratosAdendum);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contrato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Conductor:";
            // 
            // comboConductores
            // 
            this.comboConductores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboConductores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboConductores.DataSource = this.contratosBindingSource;
            this.comboConductores.DisplayMember = "Conductor";
            this.comboConductores.FormattingEnabled = true;
            this.comboConductores.Location = new System.Drawing.Point(220, 17);
            this.comboConductores.Name = "comboConductores";
            this.comboConductores.Size = new System.Drawing.Size(337, 26);
            this.comboConductores.TabIndex = 5;
            // 
            // comboContrato
            // 
            this.comboContrato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboContrato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboContrato.DataSource = this.contratosBindingSource;
            this.comboContrato.DisplayMember = "Contrato";
            this.comboContrato.FormattingEnabled = true;
            this.comboContrato.Location = new System.Drawing.Point(65, 17);
            this.comboContrato.Name = "comboContrato";
            this.comboContrato.Size = new System.Drawing.Size(77, 26);
            this.comboContrato.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(3, 47);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnHistorialAdendum);
            this.splitContainer1.Panel2.Controls.Add(this.btnGuardar);
            this.splitContainer1.Size = new System.Drawing.Size(753, 603);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvContratosAdendums);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvAdendum);
            this.splitContainer2.Size = new System.Drawing.Size(753, 513);
            this.splitContainer2.SplitterDistance = 189;
            this.splitContainer2.TabIndex = 4;
            // 
            // dgvContratosAdendums
            // 
            this.dgvContratosAdendums.AutoGenerateColumns = false;
            this.dgvContratosAdendums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratosAdendums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contratoDataGridViewTextBoxColumn1,
            this.conductorDataGridViewTextBoxColumn,
            this.unidadDataGridViewTextBoxColumn,
            this.FechaInicio,
            this.FechaFin});
            this.dgvContratosAdendums.DataSource = this.contratosBindingSource;
            this.dgvContratosAdendums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContratosAdendums.Location = new System.Drawing.Point(0, 0);
            this.dgvContratosAdendums.Name = "dgvContratosAdendums";
            this.dgvContratosAdendums.ReadOnly = true;
            this.dgvContratosAdendums.Size = new System.Drawing.Size(753, 189);
            this.dgvContratosAdendums.TabIndex = 3;
            this.dgvContratosAdendums.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratosAdendums_CellEnter);
            // 
            // contratoDataGridViewTextBoxColumn1
            // 
            this.contratoDataGridViewTextBoxColumn1.DataPropertyName = "Contrato";
            this.contratoDataGridViewTextBoxColumn1.HeaderText = "Contrato";
            this.contratoDataGridViewTextBoxColumn1.Name = "contratoDataGridViewTextBoxColumn1";
            this.contratoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadDataGridViewTextBoxColumn
            // 
            this.unidadDataGridViewTextBoxColumn.DataPropertyName = "Unidad";
            this.unidadDataGridViewTextBoxColumn.HeaderText = "Unidad";
            this.unidadDataGridViewTextBoxColumn.Name = "unidadDataGridViewTextBoxColumn";
            this.unidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicial";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaInicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Visible = false;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFinal";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaFin.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Visible = false;
            // 
            // dgvAdendum
            // 
            this.dgvAdendum.AutoGenerateColumns = false;
            this.dgvAdendum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdendum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActualizarColumn,
            this.Imprimir,
            this.adendumIDDataGridViewTextBoxColumn,
            this.contratoIDDataGridViewTextBoxColumn,
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.fechaFinDataGridViewTextBoxColumn,
            this.indefinidoDataGridViewCheckBoxColumn,
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn,
            this.clasificacionAdendumIDDataGridViewTextBoxColumn,
            this.TotalMontoAjustado,
            this.TotalDiasAjustar,
            this.Observaciones});
            this.dgvAdendum.DataSource = this.adendumBindingSource;
            this.dgvAdendum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdendum.Location = new System.Drawing.Point(0, 0);
            this.dgvAdendum.Name = "dgvAdendum";
            this.dgvAdendum.ReadOnly = true;
            this.dgvAdendum.Size = new System.Drawing.Size(753, 320);
            this.dgvAdendum.TabIndex = 4;
            this.dgvAdendum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdendum_CellClick);
            // 
            // ActualizarColumn
            // 
            this.ActualizarColumn.HeaderText = "Actualizar";
            this.ActualizarColumn.Name = "ActualizarColumn";
            this.ActualizarColumn.ReadOnly = true;
            this.ActualizarColumn.Text = "Actualizar";
            this.ActualizarColumn.UseColumnTextForLinkValue = true;
            this.ActualizarColumn.Width = 65;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ReadOnly = true;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseColumnTextForLinkValue = true;
            this.Imprimir.Width = 60;
            // 
            // adendumIDDataGridViewTextBoxColumn
            // 
            this.adendumIDDataGridViewTextBoxColumn.DataPropertyName = "Adendum_ID";
            this.adendumIDDataGridViewTextBoxColumn.HeaderText = "Adendum";
            this.adendumIDDataGridViewTextBoxColumn.Name = "adendumIDDataGridViewTextBoxColumn";
            this.adendumIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.adendumIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // contratoIDDataGridViewTextBoxColumn
            // 
            this.contratoIDDataGridViewTextBoxColumn.DataPropertyName = "Contrato_ID";
            this.contratoIDDataGridViewTextBoxColumn.HeaderText = "Contrato";
            this.contratoIDDataGridViewTextBoxColumn.Name = "contratoIDDataGridViewTextBoxColumn";
            this.contratoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.contratoIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // clasificacionAdendumsDescripcionDataGridViewTextBoxColumn
            // 
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.DataPropertyName = "ClasificacionAdendums_Descripcion";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.HeaderText = "Clasificación";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.Name = "clasificacionAdendumsDescripcionDataGridViewTextBoxColumn";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "FechaInicio";
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "Inicio";
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            this.fechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaInicioDataGridViewTextBoxColumn.Width = 60;
            // 
            // fechaFinDataGridViewTextBoxColumn
            // 
            this.fechaFinDataGridViewTextBoxColumn.DataPropertyName = "FechaFin";
            this.fechaFinDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.fechaFinDataGridViewTextBoxColumn.Name = "fechaFinDataGridViewTextBoxColumn";
            this.fechaFinDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaFinDataGridViewTextBoxColumn.Width = 50;
            // 
            // indefinidoDataGridViewCheckBoxColumn
            // 
            this.indefinidoDataGridViewCheckBoxColumn.DataPropertyName = "Indefinido";
            this.indefinidoDataGridViewCheckBoxColumn.HeaderText = "Indefinido";
            this.indefinidoDataGridViewCheckBoxColumn.Name = "indefinidoDataGridViewCheckBoxColumn";
            this.indefinidoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indefinidoDataGridViewCheckBoxColumn.Width = 65;
            // 
            // estatusAdendumsDescripcionDataGridViewTextBoxColumn
            // 
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn.DataPropertyName = "EstatusAdendums_Descripcion";
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn.HeaderText = "EstatusAdendums_Descripcion";
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn.Name = "estatusAdendumsDescripcionDataGridViewTextBoxColumn";
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.estatusAdendumsDescripcionDataGridViewTextBoxColumn.Visible = false;
            // 
            // clasificacionAdendumIDDataGridViewTextBoxColumn
            // 
            this.clasificacionAdendumIDDataGridViewTextBoxColumn.DataPropertyName = "ClasificacionAdendum_ID";
            this.clasificacionAdendumIDDataGridViewTextBoxColumn.HeaderText = "ClasificacionAdendum_ID";
            this.clasificacionAdendumIDDataGridViewTextBoxColumn.Name = "clasificacionAdendumIDDataGridViewTextBoxColumn";
            this.clasificacionAdendumIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.clasificacionAdendumIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // TotalMontoAjustado
            // 
            this.TotalMontoAjustado.DataPropertyName = "TotalMontoAjustado";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.TotalMontoAjustado.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalMontoAjustado.HeaderText = "Monto Ajustado";
            this.TotalMontoAjustado.Name = "TotalMontoAjustado";
            this.TotalMontoAjustado.ReadOnly = true;
            this.TotalMontoAjustado.Width = 65;
            // 
            // TotalDiasAjustar
            // 
            this.TotalDiasAjustar.DataPropertyName = "TotalDiasAjustar";
            this.TotalDiasAjustar.HeaderText = "Dias Ajustados";
            this.TotalDiasAjustar.Name = "TotalDiasAjustar";
            this.TotalDiasAjustar.ReadOnly = true;
            this.TotalDiasAjustar.Width = 90;
            // 
            // adendumBindingSource
            // 
            this.adendumBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ContratosAdendumDetalle);
            // 
            // btnHistorialAdendum
            // 
            this.btnHistorialAdendum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorialAdendum.Location = new System.Drawing.Point(488, 3);
            this.btnHistorialAdendum.Name = "btnHistorialAdendum";
            this.btnHistorialAdendum.Size = new System.Drawing.Size(138, 23);
            this.btnHistorialAdendum.TabIndex = 19;
            this.btnHistorialAdendum.Text = "&Reporte de adendums";
            this.btnHistorialAdendum.UseVisualStyleBackColor = true;
            this.btnHistorialAdendum.Click += new System.EventHandler(this.btnHistorialAdendum_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(632, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(118, 23);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "&Agregar Adendum";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // Adendums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 652);
            this.Controls.Add(this.panel1);
            this.Name = "Adendums";
            this.Text = "addendums";
            this.Load += new System.EventHandler(this.Addendums_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratosAdendums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdendum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adendumBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvContratosAdendums;
        private System.Windows.Forms.DataGridView dgvAdendum;
        private System.Windows.Forms.BindingSource contratosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboConductores;
        private System.Windows.Forms.ComboBox comboContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewLinkColumn ActualizarColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn adendumIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionAdendumsDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indefinidoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusAdendumsDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionAdendumIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMontoAjustado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiasAjustar;
        private System.Windows.Forms.Button btnHistorialAdendum;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.BindingSource adendumBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;

    }
}