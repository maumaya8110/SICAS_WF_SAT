namespace SICASv20.forms
{
    partial class ActualizarModeloUnidad
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.datosUnidadTallerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.EmpresaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ModeloTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ModeloComboBox = new System.Windows.Forms.ComboBox();
            this.modelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ActualizarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datosUnidadTallerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualizar Modelo de Unidad";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumeroEconomicoTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EmpresaTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ModeloTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ModeloComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ActualizarButton, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 177);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidad:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumeroEconomicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datosUnidadTallerBindingSource, "NumeroEconomico", true));
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(108, 6);
            this.NumeroEconomicoTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.ReadOnly = true;
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(100, 21);
            this.NumeroEconomicoTextBox.TabIndex = 1;
            // 
            // datosUnidadTallerBindingSource
            // 
            this.datosUnidadTallerBindingSource.DataSource = typeof(SICASv20.Entities.DatosUnidadTaller);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empresa:";
            // 
            // EmpresaTextBox
            // 
            this.EmpresaTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmpresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datosUnidadTallerBindingSource, "Empresa", true));
            this.EmpresaTextBox.Location = new System.Drawing.Point(108, 39);
            this.EmpresaTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.EmpresaTextBox.Name = "EmpresaTextBox";
            this.EmpresaTextBox.ReadOnly = true;
            this.EmpresaTextBox.Size = new System.Drawing.Size(322, 21);
            this.EmpresaTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modelo actual:";
            // 
            // ModeloTextBox
            // 
            this.ModeloTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ModeloTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datosUnidadTallerBindingSource, "Modelo", true));
            this.ModeloTextBox.Location = new System.Drawing.Point(108, 72);
            this.ModeloTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.ModeloTextBox.Name = "ModeloTextBox";
            this.ModeloTextBox.ReadOnly = true;
            this.ModeloTextBox.Size = new System.Drawing.Size(223, 21);
            this.ModeloTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nuevo modelo:";
            // 
            // ModeloComboBox
            // 
            this.ModeloComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ModeloComboBox.DataSource = this.modelosBindingSource;
            this.ModeloComboBox.DisplayMember = "Nombre";
            this.ModeloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeloComboBox.FormattingEnabled = true;
            this.ModeloComboBox.Location = new System.Drawing.Point(108, 105);
            this.ModeloComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.ModeloComboBox.Name = "ModeloComboBox";
            this.ModeloComboBox.Size = new System.Drawing.Size(223, 23);
            this.ModeloComboBox.TabIndex = 7;
            this.ModeloComboBox.ValueMember = "Modelo_ID";
            this.ModeloComboBox.SelectionChangeCommitted += new System.EventHandler(this.ModeloComboBox_SelectionChangeCommitted);
            // 
            // modelosBindingSource
            // 
            this.modelosBindingSource.DataSource = typeof(SICASv20.Entities.Modelos);
            // 
            // ActualizarButton
            // 
            this.ActualizarButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ActualizarButton.Location = new System.Drawing.Point(373, 140);
            this.ActualizarButton.Margin = new System.Windows.Forms.Padding(6);
            this.ActualizarButton.Name = "ActualizarButton";
            this.ActualizarButton.Size = new System.Drawing.Size(94, 30);
            this.ActualizarButton.TabIndex = 8;
            this.ActualizarButton.Text = "Actualizar";
            this.ActualizarButton.UseVisualStyleBackColor = true;
            this.ActualizarButton.Click += new System.EventHandler(this.ActualizarButton_Click);
            // 
            // ActualizarModeloUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 257);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ActualizarModeloUnidad";
            this.Text = "Actualizar Modelo de Unidad";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datosUnidadTallerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmpresaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ModeloTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ModeloComboBox;
        private System.Windows.Forms.Button ActualizarButton;
        private System.Windows.Forms.BindingSource modelosBindingSource;
        private System.Windows.Forms.BindingSource datosUnidadTallerBindingSource;
    }
}