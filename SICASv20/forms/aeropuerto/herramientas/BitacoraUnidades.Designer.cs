namespace SICASv20.forms
{
    partial class BitacoraUnidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.BitacoraUnidadesGridView = new System.Windows.Forms.DataGridView();
            this.Unidad_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conductor_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandByColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CirculandoColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CarreraColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.vista_BitacoraUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraUnidadesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_BitacoraUnidadesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox2.Controls.Add(this.BitacoraUnidadesGridView);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(974, 591);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bitácora de Unidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Agregar unidad: Numero economico:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(202, 29);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumeroEconomicoTextBox.TabIndex = 2;            
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // BitacoraUnidadesGridView
            // 
            this.BitacoraUnidadesGridView.AllowUserToAddRows = false;
            this.BitacoraUnidadesGridView.AllowUserToDeleteRows = false;
            this.BitacoraUnidadesGridView.AutoGenerateColumns = false;
            this.BitacoraUnidadesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BitacoraUnidadesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Unidad_IDColumn,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.Conductor_IDColumn,
            this.conductorDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.estacionIDDataGridViewTextBoxColumn,
            this.StandByColumn,
            this.CirculandoColumn,
            this.CarreraColumn});
            this.BitacoraUnidadesGridView.DataSource = this.vista_BitacoraUnidadesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BitacoraUnidadesGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.BitacoraUnidadesGridView.Location = new System.Drawing.Point(5, 71);
            this.BitacoraUnidadesGridView.Name = "BitacoraUnidadesGridView";
            this.BitacoraUnidadesGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BitacoraUnidadesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.BitacoraUnidadesGridView.Size = new System.Drawing.Size(955, 504);
            this.BitacoraUnidadesGridView.TabIndex = 0;
            this.BitacoraUnidadesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BitacoraUnidadesGridView_CellContentClick);
            this.BitacoraUnidadesGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.BitacoraUnidadesGridView_DataBindingComplete);
            // 
            // Unidad_IDColumn
            // 
            this.Unidad_IDColumn.DataPropertyName = "Unidad_ID";
            this.Unidad_IDColumn.HeaderText = "Unidad_ID";
            this.Unidad_IDColumn.Name = "Unidad_IDColumn";
            this.Unidad_IDColumn.ReadOnly = true;
            this.Unidad_IDColumn.Visible = false;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "Unidad";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Conductor_IDColumn
            // 
            this.Conductor_IDColumn.DataPropertyName = "Conductor_ID";
            this.Conductor_IDColumn.HeaderText = "Conductor_ID";
            this.Conductor_IDColumn.Name = "Conductor_IDColumn";
            this.Conductor_IDColumn.ReadOnly = true;
            this.Conductor_IDColumn.Visible = false;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "t";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Hora";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estacionIDDataGridViewTextBoxColumn
            // 
            this.estacionIDDataGridViewTextBoxColumn.DataPropertyName = "Estacion_ID";
            this.estacionIDDataGridViewTextBoxColumn.HeaderText = "Estacion_ID";
            this.estacionIDDataGridViewTextBoxColumn.Name = "estacionIDDataGridViewTextBoxColumn";
            this.estacionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.estacionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // StandByColumn
            // 
            this.StandByColumn.ActiveLinkColor = System.Drawing.Color.White;
            this.StandByColumn.HeaderText = "";
            this.StandByColumn.LinkColor = System.Drawing.Color.White;
            this.StandByColumn.Name = "StandByColumn";
            this.StandByColumn.ReadOnly = true;
            this.StandByColumn.Text = "StandBy";
            this.StandByColumn.UseColumnTextForLinkValue = true;
            this.StandByColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // CirculandoColumn
            // 
            this.CirculandoColumn.ActiveLinkColor = System.Drawing.Color.White;
            this.CirculandoColumn.HeaderText = "";
            this.CirculandoColumn.LinkColor = System.Drawing.Color.White;
            this.CirculandoColumn.Name = "CirculandoColumn";
            this.CirculandoColumn.ReadOnly = true;
            this.CirculandoColumn.Text = "Circulando";
            this.CirculandoColumn.UseColumnTextForLinkValue = true;
            this.CirculandoColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // CarreraColumn
            // 
            this.CarreraColumn.ActiveLinkColor = System.Drawing.Color.White;
            this.CarreraColumn.HeaderText = "";
            this.CarreraColumn.LinkColor = System.Drawing.Color.White;
            this.CarreraColumn.Name = "CarreraColumn";
            this.CarreraColumn.ReadOnly = true;
            this.CarreraColumn.Text = "Carrera";
            this.CarreraColumn.UseColumnTextForLinkValue = true;
            this.CarreraColumn.Visible = false;
            this.CarreraColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // vista_BitacoraUnidadesBindingSource
            // 
            this.vista_BitacoraUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_BitacoraUnidades);
            // 
            // BitacoraUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 615);
            this.Controls.Add(this.groupBox2);
            this.Name = "BitacoraUnidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsignacionServicios";
            this.Load += new System.EventHandler(this.BitacoraUnidades_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitacoraUnidadesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_BitacoraUnidadesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView BitacoraUnidadesGridView;
        private System.Windows.Forms.BindingSource vista_BitacoraUnidadesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn StandByColumn;
        private System.Windows.Forms.DataGridViewLinkColumn CirculandoColumn;
        private System.Windows.Forms.DataGridViewLinkColumn CarreraColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
    }
}