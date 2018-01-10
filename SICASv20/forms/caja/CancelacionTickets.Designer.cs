namespace SICASv20.forms
{
    partial class CancelacionTickets
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
            System.Windows.Forms.Label ticket_IDLabel;
            System.Windows.Forms.Label sesion_IDLabel;
            System.Windows.Forms.Label cajaLabel;
            System.Windows.Forms.Label usuario_IDLabel;
            System.Windows.Forms.Label estatusLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label estacionLabel;
            System.Windows.Forms.Label conductorLabel;
            System.Windows.Forms.Label unidadLabel;
            System.Windows.Forms.Label fechaLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MotivoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ticket_IDTextBox = new System.Windows.Forms.TextBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ticket_IDTextBox1 = new System.Windows.Forms.TextBox();
            this.vista_TicketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.sesion_IDTextBox = new System.Windows.Forms.TextBox();
            this.cajaTextBox = new System.Windows.Forms.TextBox();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.estatusTextBox = new System.Windows.Forms.TextBox();
            this.empresaTextBox = new System.Windows.Forms.TextBox();
            this.estacionTextBox = new System.Windows.Forms.TextBox();
            this.conductorTextBox = new System.Windows.Forms.TextBox();
            this.unidadTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vista_TicketsTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Vista_TicketsTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            ticket_IDLabel = new System.Windows.Forms.Label();
            sesion_IDLabel = new System.Windows.Forms.Label();
            cajaLabel = new System.Windows.Forms.Label();
            usuario_IDLabel = new System.Windows.Forms.Label();
            estatusLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            estacionLabel = new System.Windows.Forms.Label();
            conductorLabel = new System.Windows.Forms.Label();
            unidadLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TicketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ticket_IDLabel
            // 
            ticket_IDLabel.AutoSize = true;
            ticket_IDLabel.Location = new System.Drawing.Point(45, 42);
            ticket_IDLabel.Name = "ticket_IDLabel";
            ticket_IDLabel.Size = new System.Drawing.Size(57, 15);
            ticket_IDLabel.TabIndex = 0;
            ticket_IDLabel.Text = "Ticket ID:";
            // 
            // sesion_IDLabel
            // 
            sesion_IDLabel.AutoSize = true;
            sesion_IDLabel.Location = new System.Drawing.Point(45, 69);
            sesion_IDLabel.Name = "sesion_IDLabel";
            sesion_IDLabel.Size = new System.Drawing.Size(63, 15);
            sesion_IDLabel.TabIndex = 2;
            sesion_IDLabel.Text = "Sesion ID:";
            // 
            // cajaLabel
            // 
            cajaLabel.AutoSize = true;
            cajaLabel.Location = new System.Drawing.Point(45, 96);
            cajaLabel.Name = "cajaLabel";
            cajaLabel.Size = new System.Drawing.Size(35, 15);
            cajaLabel.TabIndex = 4;
            cajaLabel.Text = "Caja:";
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(45, 123);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 6;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // estatusLabel
            // 
            estatusLabel.AutoSize = true;
            estatusLabel.Location = new System.Drawing.Point(45, 150);
            estatusLabel.Name = "estatusLabel";
            estatusLabel.Size = new System.Drawing.Size(50, 15);
            estatusLabel.TabIndex = 8;
            estatusLabel.Text = "Estatus:";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new System.Drawing.Point(45, 177);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(60, 15);
            empresaLabel.TabIndex = 10;
            empresaLabel.Text = "Empresa:";
            // 
            // estacionLabel
            // 
            estacionLabel.AutoSize = true;
            estacionLabel.Location = new System.Drawing.Point(45, 204);
            estacionLabel.Name = "estacionLabel";
            estacionLabel.Size = new System.Drawing.Size(57, 15);
            estacionLabel.TabIndex = 12;
            estacionLabel.Text = "Estacion:";
            // 
            // conductorLabel
            // 
            conductorLabel.AutoSize = true;
            conductorLabel.Location = new System.Drawing.Point(45, 231);
            conductorLabel.Name = "conductorLabel";
            conductorLabel.Size = new System.Drawing.Size(66, 15);
            conductorLabel.TabIndex = 14;
            conductorLabel.Text = "Conductor:";
            // 
            // unidadLabel
            // 
            unidadLabel.AutoSize = true;
            unidadLabel.Location = new System.Drawing.Point(45, 258);
            unidadLabel.Name = "unidadLabel";
            unidadLabel.Size = new System.Drawing.Size(50, 15);
            unidadLabel.TabIndex = 16;
            unidadLabel.Text = "Unidad:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(45, 286);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(44, 15);
            fechaLabel.TabIndex = 18;
            fechaLabel.Text = "Fecha:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MotivoTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Ticket_IDTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelación de Tickets";
            // 
            // MotivoTextBox
            // 
            this.MotivoTextBox.Location = new System.Drawing.Point(98, 72);
            this.MotivoTextBox.Multiline = true;
            this.MotivoTextBox.Name = "MotivoTextBox";
            this.MotivoTextBox.Size = new System.Drawing.Size(246, 75);
            this.MotivoTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motivo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ticket ID:";
            // 
            // Ticket_IDTextBox
            // 
            this.Ticket_IDTextBox.Location = new System.Drawing.Point(98, 36);
            this.Ticket_IDTextBox.Name = "Ticket_IDTextBox";
            this.Ticket_IDTextBox.Size = new System.Drawing.Size(158, 21);
            this.Ticket_IDTextBox.TabIndex = 0;
            this.Ticket_IDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Ticket_IDTextBox_KeyUp);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(263, 197);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(112, 30);
            this.CancelarButton.TabIndex = 1;
            this.CancelarButton.Text = "Cancelar Ticket:";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(ticket_IDLabel);
            this.groupBox2.Controls.Add(this.ticket_IDTextBox1);
            this.groupBox2.Controls.Add(sesion_IDLabel);
            this.groupBox2.Controls.Add(this.sesion_IDTextBox);
            this.groupBox2.Controls.Add(cajaLabel);
            this.groupBox2.Controls.Add(this.cajaTextBox);
            this.groupBox2.Controls.Add(usuario_IDLabel);
            this.groupBox2.Controls.Add(this.usuario_IDTextBox);
            this.groupBox2.Controls.Add(estatusLabel);
            this.groupBox2.Controls.Add(this.estatusTextBox);
            this.groupBox2.Controls.Add(empresaLabel);
            this.groupBox2.Controls.Add(this.empresaTextBox);
            this.groupBox2.Controls.Add(estacionLabel);
            this.groupBox2.Controls.Add(this.estacionTextBox);
            this.groupBox2.Controls.Add(conductorLabel);
            this.groupBox2.Controls.Add(this.conductorTextBox);
            this.groupBox2.Controls.Add(unidadLabel);
            this.groupBox2.Controls.Add(this.unidadTextBox);
            this.groupBox2.Controls.Add(fechaLabel);
            this.groupBox2.Controls.Add(this.fechaDateTimePicker);
            this.groupBox2.Location = new System.Drawing.Point(410, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 329);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Ticket";
            // 
            // ticket_IDTextBox1
            // 
            this.ticket_IDTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Ticket_ID", true));
            this.ticket_IDTextBox1.Location = new System.Drawing.Point(119, 39);
            this.ticket_IDTextBox1.Name = "ticket_IDTextBox1";
            this.ticket_IDTextBox1.ReadOnly = true;
            this.ticket_IDTextBox1.Size = new System.Drawing.Size(129, 21);
            this.ticket_IDTextBox1.TabIndex = 1;
            // 
            // vista_TicketsBindingSource
            // 
            this.vista_TicketsBindingSource.DataMember = "Vista_Tickets";
            this.vista_TicketsBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sesion_IDTextBox
            // 
            this.sesion_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Sesion_ID", true));
            this.sesion_IDTextBox.Location = new System.Drawing.Point(119, 66);
            this.sesion_IDTextBox.Name = "sesion_IDTextBox";
            this.sesion_IDTextBox.ReadOnly = true;
            this.sesion_IDTextBox.Size = new System.Drawing.Size(129, 21);
            this.sesion_IDTextBox.TabIndex = 3;
            // 
            // cajaTextBox
            // 
            this.cajaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Caja", true));
            this.cajaTextBox.Location = new System.Drawing.Point(119, 93);
            this.cajaTextBox.Name = "cajaTextBox";
            this.cajaTextBox.ReadOnly = true;
            this.cajaTextBox.Size = new System.Drawing.Size(129, 21);
            this.cajaTextBox.TabIndex = 5;
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Usuario_ID", true));
            this.usuario_IDTextBox.Location = new System.Drawing.Point(119, 120);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.ReadOnly = true;
            this.usuario_IDTextBox.Size = new System.Drawing.Size(200, 21);
            this.usuario_IDTextBox.TabIndex = 7;
            // 
            // estatusTextBox
            // 
            this.estatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Estatus", true));
            this.estatusTextBox.Location = new System.Drawing.Point(119, 147);
            this.estatusTextBox.Name = "estatusTextBox";
            this.estatusTextBox.ReadOnly = true;
            this.estatusTextBox.Size = new System.Drawing.Size(129, 21);
            this.estatusTextBox.TabIndex = 9;
            // 
            // empresaTextBox
            // 
            this.empresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Empresa", true));
            this.empresaTextBox.Location = new System.Drawing.Point(119, 174);
            this.empresaTextBox.Name = "empresaTextBox";
            this.empresaTextBox.ReadOnly = true;
            this.empresaTextBox.Size = new System.Drawing.Size(200, 21);
            this.empresaTextBox.TabIndex = 11;
            // 
            // estacionTextBox
            // 
            this.estacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Estacion", true));
            this.estacionTextBox.Location = new System.Drawing.Point(119, 201);
            this.estacionTextBox.Name = "estacionTextBox";
            this.estacionTextBox.ReadOnly = true;
            this.estacionTextBox.Size = new System.Drawing.Size(200, 21);
            this.estacionTextBox.TabIndex = 13;
            // 
            // conductorTextBox
            // 
            this.conductorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Conductor", true));
            this.conductorTextBox.Location = new System.Drawing.Point(119, 228);
            this.conductorTextBox.Name = "conductorTextBox";
            this.conductorTextBox.ReadOnly = true;
            this.conductorTextBox.Size = new System.Drawing.Size(200, 21);
            this.conductorTextBox.TabIndex = 15;
            // 
            // unidadTextBox
            // 
            this.unidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_TicketsBindingSource, "Unidad", true));
            this.unidadTextBox.Location = new System.Drawing.Point(119, 255);
            this.unidadTextBox.Name = "unidadTextBox";
            this.unidadTextBox.ReadOnly = true;
            this.unidadTextBox.Size = new System.Drawing.Size(129, 21);
            this.unidadTextBox.TabIndex = 17;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vista_TicketsBindingSource, "Fecha", true));
            this.fechaDateTimePicker.Enabled = false;
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(119, 282);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(89, 21);
            this.fechaDateTimePicker.TabIndex = 19;
            // 
            // vista_TicketsTableAdapter
            // 
            this.vista_TicketsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Get_ArrendamientosDisponiblesTableAdapter = null;
            this.tableAdapterManager.Get_EmpresasPropietariasTableAdapter = null;
            this.tableAdapterManager.Get_MenuesTableAdapter = null;
            this.tableAdapterManager.Get_ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.Get_ModulosTableAdapter = null;
            this.tableAdapterManager.Get_OpcionesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // CancelacionTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelacionTickets";
            this.Text = "CancelacionTickets";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TicketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.TextBox MotivoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Ticket_IDTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource vista_TicketsBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Vista_TicketsTableAdapter vista_TicketsTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox ticket_IDTextBox1;
        private System.Windows.Forms.TextBox sesion_IDTextBox;
        private System.Windows.Forms.TextBox cajaTextBox;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.TextBox estatusTextBox;
        private System.Windows.Forms.TextBox empresaTextBox;
        private System.Windows.Forms.TextBox estacionTextBox;
        private System.Windows.Forms.TextBox conductorTextBox;
        private System.Windows.Forms.TextBox unidadTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
    }
}