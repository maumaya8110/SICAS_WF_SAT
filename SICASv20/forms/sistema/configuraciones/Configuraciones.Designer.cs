namespace SICASv20.forms
{
    partial class Configuraciones
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BaseDatos = new System.Windows.Forms.TabPage();
            this.TestDBButton = new System.Windows.Forms.Button();
            this.DBTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PwdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FTP = new System.Windows.Forms.TabPage();
            this.FTPTestButton = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Web = new System.Windows.Forms.TabPage();
            this.TestWebButton = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TabPage();
            this.TestEmailButton = new System.Windows.Forms.Button();
            this.PuertoTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Locales = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CajaComboBox = new System.Windows.Forms.ComboBox();
            this.EstacionComboBox = new System.Windows.Forms.ComboBox();
            this.EmpresaComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.BaseDatos.SuspendLayout();
            this.FTP.SuspendLayout();
            this.Web.SuspendLayout();
            this.Email.SuspendLayout();
            this.Locales.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BaseDatos);
            this.tabControl1.Controls.Add(this.FTP);
            this.tabControl1.Controls.Add(this.Web);
            this.tabControl1.Controls.Add(this.Email);
            this.tabControl1.Controls.Add(this.Locales);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 656);
            this.tabControl1.TabIndex = 0;
            // 
            // BaseDatos
            // 
            this.BaseDatos.Controls.Add(this.TestDBButton);
            this.BaseDatos.Controls.Add(this.DBTextBox);
            this.BaseDatos.Controls.Add(this.label4);
            this.BaseDatos.Controls.Add(this.PwdTextBox);
            this.BaseDatos.Controls.Add(this.label3);
            this.BaseDatos.Controls.Add(this.UserIDTextBox);
            this.BaseDatos.Controls.Add(this.label2);
            this.BaseDatos.Controls.Add(this.ServerTextBox);
            this.BaseDatos.Controls.Add(this.label1);
            this.BaseDatos.Location = new System.Drawing.Point(4, 24);
            this.BaseDatos.Name = "BaseDatos";
            this.BaseDatos.Padding = new System.Windows.Forms.Padding(3);
            this.BaseDatos.Size = new System.Drawing.Size(992, 628);
            this.BaseDatos.TabIndex = 1;
            this.BaseDatos.Text = "Base de Datos";
            this.BaseDatos.UseVisualStyleBackColor = true;
            // 
            // TestDBButton
            // 
            this.TestDBButton.Location = new System.Drawing.Point(304, 134);
            this.TestDBButton.Name = "TestDBButton";
            this.TestDBButton.Size = new System.Drawing.Size(115, 23);
            this.TestDBButton.TabIndex = 17;
            this.TestDBButton.Text = "Probar conexión";
            this.TestDBButton.UseVisualStyleBackColor = true;
            // 
            // DBTextBox
            // 
            this.DBTextBox.Location = new System.Drawing.Point(126, 103);
            this.DBTextBox.Name = "DBTextBox";
            this.DBTextBox.Size = new System.Drawing.Size(159, 21);
            this.DBTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Base de datos:";
            // 
            // PwdTextBox
            // 
            this.PwdTextBox.Location = new System.Drawing.Point(126, 76);
            this.PwdTextBox.Name = "PwdTextBox";
            this.PwdTextBox.Size = new System.Drawing.Size(159, 21);
            this.PwdTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña:";
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Location = new System.Drawing.Point(126, 49);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(159, 21);
            this.UserIDTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(126, 22);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(159, 21);
            this.ServerTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // FTP
            // 
            this.FTP.Controls.Add(this.FTPTestButton);
            this.FTP.Controls.Add(this.Path);
            this.FTP.Controls.Add(this.label5);
            this.FTP.Controls.Add(this.textBox2);
            this.FTP.Controls.Add(this.label6);
            this.FTP.Controls.Add(this.textBox3);
            this.FTP.Controls.Add(this.label7);
            this.FTP.Controls.Add(this.textBox4);
            this.FTP.Controls.Add(this.label8);
            this.FTP.Location = new System.Drawing.Point(4, 24);
            this.FTP.Name = "FTP";
            this.FTP.Size = new System.Drawing.Size(992, 628);
            this.FTP.TabIndex = 2;
            this.FTP.Text = "FTP";
            this.FTP.UseVisualStyleBackColor = true;
            // 
            // FTPTestButton
            // 
            this.FTPTestButton.Location = new System.Drawing.Point(298, 140);
            this.FTPTestButton.Name = "FTPTestButton";
            this.FTPTestButton.Size = new System.Drawing.Size(115, 23);
            this.FTPTestButton.TabIndex = 16;
            this.FTPTestButton.Text = "Probar conexión";
            this.FTPTestButton.UseVisualStyleBackColor = true;
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(140, 107);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(159, 21);
            this.Path.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ruta/Subdirectorio:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(159, 21);
            this.textBox2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Contraseña:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(140, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(159, 21);
            this.textBox3.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Usuario:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 26);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(159, 21);
            this.textBox4.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Servidor:";
            // 
            // Web
            // 
            this.Web.Controls.Add(this.TestWebButton);
            this.Web.Controls.Add(this.textBox5);
            this.Web.Controls.Add(this.label10);
            this.Web.Controls.Add(this.textBox6);
            this.Web.Controls.Add(this.label11);
            this.Web.Controls.Add(this.textBox7);
            this.Web.Controls.Add(this.label12);
            this.Web.Location = new System.Drawing.Point(4, 24);
            this.Web.Name = "Web";
            this.Web.Size = new System.Drawing.Size(992, 628);
            this.Web.TabIndex = 3;
            this.Web.Text = "Sitio web";
            this.Web.UseVisualStyleBackColor = true;
            // 
            // TestWebButton
            // 
            this.TestWebButton.Location = new System.Drawing.Point(307, 132);
            this.TestWebButton.Name = "TestWebButton";
            this.TestWebButton.Size = new System.Drawing.Size(115, 23);
            this.TestWebButton.TabIndex = 26;
            this.TestWebButton.Text = "Probar conexión";
            this.TestWebButton.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(122, 78);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(159, 21);
            this.textBox5.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Contraseña:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(122, 51);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(159, 21);
            this.textBox6.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Usuario:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(122, 24);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(159, 21);
            this.textBox7.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Servidor:";
            // 
            // Email
            // 
            this.Email.Controls.Add(this.TestEmailButton);
            this.Email.Controls.Add(this.PuertoTextBox);
            this.Email.Controls.Add(this.label9);
            this.Email.Controls.Add(this.textBox8);
            this.Email.Controls.Add(this.label13);
            this.Email.Controls.Add(this.textBox9);
            this.Email.Controls.Add(this.label14);
            this.Email.Controls.Add(this.textBox10);
            this.Email.Controls.Add(this.label15);
            this.Email.Location = new System.Drawing.Point(4, 24);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(992, 628);
            this.Email.TabIndex = 4;
            this.Email.Text = "Email";
            this.Email.UseVisualStyleBackColor = true;
            // 
            // TestEmailButton
            // 
            this.TestEmailButton.Location = new System.Drawing.Point(301, 132);
            this.TestEmailButton.Name = "TestEmailButton";
            this.TestEmailButton.Size = new System.Drawing.Size(115, 23);
            this.TestEmailButton.TabIndex = 26;
            this.TestEmailButton.Text = "Probar conexión";
            this.TestEmailButton.UseVisualStyleBackColor = true;
            // 
            // PuertoTextBox
            // 
            this.PuertoTextBox.Location = new System.Drawing.Point(125, 103);
            this.PuertoTextBox.Name = "PuertoTextBox";
            this.PuertoTextBox.Size = new System.Drawing.Size(159, 21);
            this.PuertoTextBox.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Puerto:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(125, 76);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(159, 21);
            this.textBox8.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Contraseña:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(125, 49);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(159, 21);
            this.textBox9.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "Usuario:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(125, 22);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(159, 21);
            this.textBox10.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "Servidor:";
            // 
            // Locales
            // 
            this.Locales.Controls.Add(this.button1);
            this.Locales.Controls.Add(this.textBox1);
            this.Locales.Controls.Add(this.label20);
            this.Locales.Controls.Add(this.textBox11);
            this.Locales.Controls.Add(this.label21);
            this.Locales.Controls.Add(this.checkBox1);
            this.Locales.Controls.Add(this.label19);
            this.Locales.Controls.Add(this.CajaComboBox);
            this.Locales.Controls.Add(this.EstacionComboBox);
            this.Locales.Controls.Add(this.EmpresaComboBox);
            this.Locales.Controls.Add(this.label18);
            this.Locales.Controls.Add(this.label17);
            this.Locales.Controls.Add(this.label16);
            this.Locales.Location = new System.Drawing.Point(4, 24);
            this.Locales.Name = "Locales";
            this.Locales.Padding = new System.Windows.Forms.Padding(3);
            this.Locales.Size = new System.Drawing.Size(992, 628);
            this.Locales.TabIndex = 0;
            this.Locales.Text = "Locales";
            this.Locales.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Probar conexión";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 163);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 15);
            this.label20.TabIndex = 10;
            this.label20.Text = "Contraseña:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(163, 133);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(159, 21);
            this.textBox11.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(26, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 15);
            this.label21.TabIndex = 8;
            this.label21.Text = "Usuario:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(163, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "Iniciar con Windows";
            // 
            // CajaComboBox
            // 
            this.CajaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CajaComboBox.FormattingEnabled = true;
            this.CajaComboBox.Location = new System.Drawing.Point(163, 79);
            this.CajaComboBox.Name = "CajaComboBox";
            this.CajaComboBox.Size = new System.Drawing.Size(168, 23);
            this.CajaComboBox.TabIndex = 5;
            // 
            // EstacionComboBox
            // 
            this.EstacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionComboBox.FormattingEnabled = true;
            this.EstacionComboBox.Location = new System.Drawing.Point(163, 50);
            this.EstacionComboBox.Name = "EstacionComboBox";
            this.EstacionComboBox.Size = new System.Drawing.Size(168, 23);
            this.EstacionComboBox.TabIndex = 4;
            // 
            // EmpresaComboBox
            // 
            this.EmpresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresaComboBox.FormattingEnabled = true;
            this.EmpresaComboBox.Location = new System.Drawing.Point(163, 21);
            this.EmpresaComboBox.Name = "EmpresaComboBox";
            this.EmpresaComboBox.Size = new System.Drawing.Size(168, 23);
            this.EmpresaComboBox.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(26, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Caja:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Estacion:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Empresa:";
            // 
            // Configuraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.tabControl1);
            this.Name = "Configuraciones";
            this.Text = "Configuraciones";
            this.tabControl1.ResumeLayout(false);
            this.BaseDatos.ResumeLayout(false);
            this.BaseDatos.PerformLayout();
            this.FTP.ResumeLayout(false);
            this.FTP.PerformLayout();
            this.Web.ResumeLayout(false);
            this.Web.PerformLayout();
            this.Email.ResumeLayout(false);
            this.Email.PerformLayout();
            this.Locales.ResumeLayout(false);
            this.Locales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Locales;
        private System.Windows.Forms.TabPage BaseDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage FTP;
        private System.Windows.Forms.TabPage Web;
        private System.Windows.Forms.TabPage Email;
        private System.Windows.Forms.Button TestDBButton;
        private System.Windows.Forms.TextBox DBTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PwdTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.Button FTPTestButton;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button TestWebButton;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button TestEmailButton;
        private System.Windows.Forms.TextBox PuertoTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox CajaComboBox;
        private System.Windows.Forms.ComboBox EstacionComboBox;
        private System.Windows.Forms.ComboBox EmpresaComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
    }
}