namespace SICASv20.forms
{
    partial class AjusteInventario
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
            this.GuardarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TiposMovimientosInventarioComboBox = new System.Windows.Forms.ComboBox();
            this.tiposAjustesInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.RefaccionesComboBox = new System.Windows.Forms.ComboBox();
            this.refaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.CantidadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.CantidadInventarioTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposAjustesInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajuste de Inventario";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(626, 253);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(88, 38);
            this.GuardarButton.TabIndex = 1;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TiposMovimientosInventarioComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RefaccionesComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CantidadNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ComentariosTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CantidadInventarioTextBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 213);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = " Tipo:";
            // 
            // TiposMovimientosInventarioComboBox
            // 
            this.TiposMovimientosInventarioComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TiposMovimientosInventarioComboBox.DataSource = this.tiposAjustesInventarioBindingSource;
            this.TiposMovimientosInventarioComboBox.DisplayMember = "Nombre";
            this.TiposMovimientosInventarioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiposMovimientosInventarioComboBox.FormattingEnabled = true;
            this.TiposMovimientosInventarioComboBox.Location = new System.Drawing.Point(95, 5);
            this.TiposMovimientosInventarioComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.TiposMovimientosInventarioComboBox.Name = "TiposMovimientosInventarioComboBox";
            this.TiposMovimientosInventarioComboBox.Size = new System.Drawing.Size(120, 23);
            this.TiposMovimientosInventarioComboBox.TabIndex = 1;
            this.TiposMovimientosInventarioComboBox.ValueMember = "TipoAjusteInventario_ID";
            this.TiposMovimientosInventarioComboBox.SelectionChangeCommitted += new System.EventHandler(this.TiposMovimientosInventarioComboBox_SelectionChangeCommitted);
            // 
            // tiposAjustesInventarioBindingSource
            // 
            this.tiposAjustesInventarioBindingSource.DataSource = typeof(SICASv20.Entities.TiposAjustesInventario);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Refacción:";
            // 
            // RefaccionesComboBox
            // 
            this.RefaccionesComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RefaccionesComboBox.DataSource = this.refaccionesBindingSource;
            this.RefaccionesComboBox.DisplayMember = "Descripcion";
            this.RefaccionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RefaccionesComboBox.FormattingEnabled = true;
            this.RefaccionesComboBox.Location = new System.Drawing.Point(95, 38);
            this.RefaccionesComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.RefaccionesComboBox.Name = "RefaccionesComboBox";
            this.RefaccionesComboBox.Size = new System.Drawing.Size(489, 23);
            this.RefaccionesComboBox.TabIndex = 3;
            this.RefaccionesComboBox.ValueMember = "Refaccion_ID";
            this.RefaccionesComboBox.SelectionChangeCommitted += new System.EventHandler(this.RefaccionesComboBox_SelectionChangeCommitted);
            // 
            // refaccionesBindingSource
            // 
            this.refaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Refacciones);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad:";
            // 
            // CantidadNumericUpDown
            // 
            this.CantidadNumericUpDown.Location = new System.Drawing.Point(95, 71);
            this.CantidadNumericUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.CantidadNumericUpDown.Name = "CantidadNumericUpDown";
            this.CantidadNumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.CantidadNumericUpDown.TabIndex = 10;
            this.CantidadNumericUpDown.ValueChanged += new System.EventHandler(this.CantidadNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Inventario:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Comentarios:";
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ComentariosTextBox.Location = new System.Drawing.Point(95, 135);
            this.ComentariosTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(523, 70);
            this.ComentariosTextBox.TabIndex = 9;
            this.ComentariosTextBox.TextChanged += new System.EventHandler(this.ComentariosTextBox_TextChanged);
            // 
            // CantidadInventarioTextBox
            // 
            this.CantidadInventarioTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CantidadInventarioTextBox.Location = new System.Drawing.Point(95, 102);
            this.CantidadInventarioTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.CantidadInventarioTextBox.Name = "CantidadInventarioTextBox";
            this.CantidadInventarioTextBox.Size = new System.Drawing.Size(59, 21);
            this.CantidadInventarioTextBox.TabIndex = 12;
            // 
            // AjusteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AjusteInventario";
            this.Text = "AjusteInventario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposAjustesInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TiposMovimientosInventarioComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RefaccionesComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown CantidadNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CantidadInventarioTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource refaccionesBindingSource;
        private System.Windows.Forms.BindingSource tiposAjustesInventarioBindingSource;
    }
}