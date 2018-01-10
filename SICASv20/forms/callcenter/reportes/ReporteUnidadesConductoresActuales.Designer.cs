namespace SICASv20.forms
{
    partial class ReporteUnidadesConductoresActuales
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.PlacasTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vista_ConductoresUnidadesActualesDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_ConductoresUnidadesActualesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domicilioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoAvalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domicilioAvalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresUnidadesActualesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresUnidadesActualesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.PlacasTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vista_ConductoresUnidadesActualesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidades y Conductores Actuales";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(436, 26);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 6;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // PlacasTextBox
            // 
            this.PlacasTextBox.Location = new System.Drawing.Point(306, 27);
            this.PlacasTextBox.Name = "PlacasTextBox";
            this.PlacasTextBox.Size = new System.Drawing.Size(100, 21);
            this.PlacasTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Placas:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(139, 27);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(100, 21);
            this.NumeroEconomicoTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número económico:";
            // 
            // vista_ConductoresUnidadesActualesDataGridView
            // 
            this.vista_ConductoresUnidadesActualesDataGridView.AllowUserToAddRows = false;
            this.vista_ConductoresUnidadesActualesDataGridView.AllowUserToDeleteRows = false;
            this.vista_ConductoresUnidadesActualesDataGridView.AutoGenerateColumns = false;
            this.vista_ConductoresUnidadesActualesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ConductoresUnidadesActualesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estacionDataGridViewTextBoxColumn,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.conductorDataGridViewTextBoxColumn,
            this.placasDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.telefono2DataGridViewTextBoxColumn,
            this.domicilioDataGridViewTextBoxColumn,
            this.avalDataGridViewTextBoxColumn,
            this.telefonoAvalDataGridViewTextBoxColumn,
            this.domicilioAvalDataGridViewTextBoxColumn});
            this.vista_ConductoresUnidadesActualesDataGridView.DataSource = this.vista_ConductoresUnidadesActualesBindingSource;
            this.vista_ConductoresUnidadesActualesDataGridView.Location = new System.Drawing.Point(17, 65);
            this.vista_ConductoresUnidadesActualesDataGridView.Name = "vista_ConductoresUnidadesActualesDataGridView";
            this.vista_ConductoresUnidadesActualesDataGridView.ReadOnly = true;
            this.vista_ConductoresUnidadesActualesDataGridView.Size = new System.Drawing.Size(952, 540);
            this.vista_ConductoresUnidadesActualesDataGridView.TabIndex = 1;
            // 
            // vista_ConductoresUnidadesActualesBindingSource
            // 
            this.vista_ConductoresUnidadesActualesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ConductoresUnidadesActuales);
            // 
            // estacionDataGridViewTextBoxColumn
            // 
            this.estacionDataGridViewTextBoxColumn.DataPropertyName = "Estacion";
            this.estacionDataGridViewTextBoxColumn.HeaderText = "Estacion";
            this.estacionDataGridViewTextBoxColumn.Name = "estacionDataGridViewTextBoxColumn";
            this.estacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placasDataGridViewTextBoxColumn
            // 
            this.placasDataGridViewTextBoxColumn.DataPropertyName = "Placas";
            this.placasDataGridViewTextBoxColumn.HeaderText = "Placas";
            this.placasDataGridViewTextBoxColumn.Name = "placasDataGridViewTextBoxColumn";
            this.placasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefono2DataGridViewTextBoxColumn
            // 
            this.telefono2DataGridViewTextBoxColumn.DataPropertyName = "Telefono2";
            this.telefono2DataGridViewTextBoxColumn.HeaderText = "Telefono2";
            this.telefono2DataGridViewTextBoxColumn.Name = "telefono2DataGridViewTextBoxColumn";
            this.telefono2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // domicilioDataGridViewTextBoxColumn
            // 
            this.domicilioDataGridViewTextBoxColumn.DataPropertyName = "Domicilio";
            this.domicilioDataGridViewTextBoxColumn.HeaderText = "Domicilio";
            this.domicilioDataGridViewTextBoxColumn.Name = "domicilioDataGridViewTextBoxColumn";
            this.domicilioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // avalDataGridViewTextBoxColumn
            // 
            this.avalDataGridViewTextBoxColumn.DataPropertyName = "Aval";
            this.avalDataGridViewTextBoxColumn.HeaderText = "Aval";
            this.avalDataGridViewTextBoxColumn.Name = "avalDataGridViewTextBoxColumn";
            this.avalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoAvalDataGridViewTextBoxColumn
            // 
            this.telefonoAvalDataGridViewTextBoxColumn.DataPropertyName = "Telefono_Aval";
            this.telefonoAvalDataGridViewTextBoxColumn.HeaderText = "Telefono_Aval";
            this.telefonoAvalDataGridViewTextBoxColumn.Name = "telefonoAvalDataGridViewTextBoxColumn";
            this.telefonoAvalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // domicilioAvalDataGridViewTextBoxColumn
            // 
            this.domicilioAvalDataGridViewTextBoxColumn.DataPropertyName = "DomicilioAval";
            this.domicilioAvalDataGridViewTextBoxColumn.HeaderText = "DomicilioAval";
            this.domicilioAvalDataGridViewTextBoxColumn.Name = "domicilioAvalDataGridViewTextBoxColumn";
            this.domicilioAvalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ReporteUnidadesConductoresActuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteUnidadesConductoresActuales";
            this.Text = "ReporteUnidadesConductoresActuales";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresUnidadesActualesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresUnidadesActualesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView vista_ConductoresUnidadesActualesDataGridView;
        private System.Windows.Forms.BindingSource vista_ConductoresUnidadesActualesBindingSource;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox PlacasTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domicilioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoAvalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domicilioAvalDataGridViewTextBoxColumn;
    }
}