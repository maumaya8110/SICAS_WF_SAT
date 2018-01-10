namespace AutoUpdater
{
    partial class SettingsForm
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
            System.Windows.Forms.Label app_IDLabel;
            System.Windows.Forms.Label appNameLabel;
            System.Windows.Forms.Label mainFileLabel;
            System.Windows.Forms.Label currentVersionLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label imagePathLabel;
            System.Windows.Forms.Label appPathLabel;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LocalTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.appPathTextBox = new System.Windows.Forms.TextBox();
            this.localConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configDS = new AutoUpdater.ConfigDS();
            this.app_IDTextBox = new System.Windows.Forms.TextBox();
            this.imagePathTextBox = new System.Windows.Forms.TextBox();
            this.appNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.mainFileTextBox = new System.Windows.Forms.TextBox();
            this.currentVersionTextBox = new System.Windows.Forms.TextBox();
            this.HistorialTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.versionControlDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.WebServiceTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webServiceSettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webServiceSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FTPTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fTPSettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fTPSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HTTPTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.httpSettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.httpSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmailTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.emailSettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalirButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            app_IDLabel = new System.Windows.Forms.Label();
            appNameLabel = new System.Windows.Forms.Label();
            mainFileLabel = new System.Windows.Forms.Label();
            currentVersionLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            imagePathLabel = new System.Windows.Forms.Label();
            appPathLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.LocalTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configDS)).BeginInit();
            this.HistorialTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionControlDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionControlBindingSource)).BeginInit();
            this.WebServiceTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webServiceSettingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServiceSettingsBindingSource)).BeginInit();
            this.FTPTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fTPSettingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTPSettingsBindingSource)).BeginInit();
            this.HTTPTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.httpSettingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.httpSettingsBindingSource)).BeginInit();
            this.EmailTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailSettingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // app_IDLabel
            // 
            app_IDLabel.AutoSize = true;
            app_IDLabel.Location = new System.Drawing.Point(19, 29);
            app_IDLabel.Name = "app_IDLabel";
            app_IDLabel.Size = new System.Drawing.Size(43, 13);
            app_IDLabel.TabIndex = 0;
            app_IDLabel.Text = "App ID:";
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Location = new System.Drawing.Point(19, 55);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new System.Drawing.Size(60, 13);
            appNameLabel.TabIndex = 2;
            appNameLabel.Text = "App Name:";
            // 
            // mainFileLabel
            // 
            mainFileLabel.AutoSize = true;
            mainFileLabel.Location = new System.Drawing.Point(19, 81);
            mainFileLabel.Name = "mainFileLabel";
            mainFileLabel.Size = new System.Drawing.Size(52, 13);
            mainFileLabel.TabIndex = 4;
            mainFileLabel.Text = "Main File:";
            // 
            // currentVersionLabel
            // 
            currentVersionLabel.AutoSize = true;
            currentVersionLabel.Location = new System.Drawing.Point(19, 107);
            currentVersionLabel.Name = "currentVersionLabel";
            currentVersionLabel.Size = new System.Drawing.Size(82, 13);
            currentVersionLabel.TabIndex = 6;
            currentVersionLabel.Text = "Current Version:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(19, 133);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Description:";
            // 
            // imagePathLabel
            // 
            imagePathLabel.AutoSize = true;
            imagePathLabel.Location = new System.Drawing.Point(19, 159);
            imagePathLabel.Name = "imagePathLabel";
            imagePathLabel.Size = new System.Drawing.Size(64, 13);
            imagePathLabel.TabIndex = 10;
            imagePathLabel.Text = "Image Path:";
            // 
            // appPathLabel
            // 
            appPathLabel.AutoSize = true;
            appPathLabel.Location = new System.Drawing.Point(19, 185);
            appPathLabel.Name = "appPathLabel";
            appPathLabel.Size = new System.Drawing.Size(54, 13);
            appPathLabel.TabIndex = 12;
            appPathLabel.Text = "App Path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LocalTab);
            this.tabControl1.Controls.Add(this.HistorialTab);
            this.tabControl1.Controls.Add(this.WebServiceTab);
            this.tabControl1.Controls.Add(this.FTPTab);
            this.tabControl1.Controls.Add(this.HTTPTab);
            this.tabControl1.Controls.Add(this.EmailTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // LocalTab
            // 
            this.LocalTab.Controls.Add(this.groupBox1);
            this.LocalTab.Location = new System.Drawing.Point(4, 22);
            this.LocalTab.Name = "LocalTab";
            this.LocalTab.Padding = new System.Windows.Forms.Padding(3);
            this.LocalTab.Size = new System.Drawing.Size(579, 416);
            this.LocalTab.TabIndex = 0;
            this.LocalTab.Text = "Configuracion actual";
            this.LocalTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(app_IDLabel);
            this.groupBox1.Controls.Add(this.appPathTextBox);
            this.groupBox1.Controls.Add(this.app_IDTextBox);
            this.groupBox1.Controls.Add(appPathLabel);
            this.groupBox1.Controls.Add(appNameLabel);
            this.groupBox1.Controls.Add(this.imagePathTextBox);
            this.groupBox1.Controls.Add(this.appNameTextBox);
            this.groupBox1.Controls.Add(imagePathLabel);
            this.groupBox1.Controls.Add(mainFileLabel);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.mainFileTextBox);
            this.groupBox1.Controls.Add(descriptionLabel);
            this.groupBox1.Controls.Add(currentVersionLabel);
            this.groupBox1.Controls.Add(this.currentVersionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(28, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 233);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la configuración actual";
            // 
            // appPathTextBox
            // 
            this.appPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "AppPath", true));
            this.appPathTextBox.Location = new System.Drawing.Point(107, 182);
            this.appPathTextBox.Name = "appPathTextBox";
            this.appPathTextBox.Size = new System.Drawing.Size(230, 20);
            this.appPathTextBox.TabIndex = 13;
            // 
            // localConfigBindingSource
            // 
            this.localConfigBindingSource.DataMember = "LocalConfig";
            this.localConfigBindingSource.DataSource = this.configDS;
            // 
            // configDS
            // 
            this.configDS.DataSetName = "ConfigDS";
            this.configDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // app_IDTextBox
            // 
            this.app_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "App_ID", true));
            this.app_IDTextBox.Location = new System.Drawing.Point(107, 26);
            this.app_IDTextBox.Name = "app_IDTextBox";
            this.app_IDTextBox.Size = new System.Drawing.Size(230, 20);
            this.app_IDTextBox.TabIndex = 1;
            // 
            // imagePathTextBox
            // 
            this.imagePathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "ImagePath", true));
            this.imagePathTextBox.Location = new System.Drawing.Point(107, 156);
            this.imagePathTextBox.Name = "imagePathTextBox";
            this.imagePathTextBox.Size = new System.Drawing.Size(230, 20);
            this.imagePathTextBox.TabIndex = 11;
            // 
            // appNameTextBox
            // 
            this.appNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "AppName", true));
            this.appNameTextBox.Location = new System.Drawing.Point(107, 52);
            this.appNameTextBox.Name = "appNameTextBox";
            this.appNameTextBox.Size = new System.Drawing.Size(230, 20);
            this.appNameTextBox.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(107, 130);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(230, 20);
            this.descriptionTextBox.TabIndex = 9;
            // 
            // mainFileTextBox
            // 
            this.mainFileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "MainFile", true));
            this.mainFileTextBox.Location = new System.Drawing.Point(107, 78);
            this.mainFileTextBox.Name = "mainFileTextBox";
            this.mainFileTextBox.Size = new System.Drawing.Size(230, 20);
            this.mainFileTextBox.TabIndex = 5;
            // 
            // currentVersionTextBox
            // 
            this.currentVersionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localConfigBindingSource, "CurrentVersion", true));
            this.currentVersionTextBox.Location = new System.Drawing.Point(107, 104);
            this.currentVersionTextBox.Name = "currentVersionTextBox";
            this.currentVersionTextBox.Size = new System.Drawing.Size(230, 20);
            this.currentVersionTextBox.TabIndex = 7;
            // 
            // HistorialTab
            // 
            this.HistorialTab.AutoScroll = true;
            this.HistorialTab.Controls.Add(this.groupBox2);
            this.HistorialTab.Location = new System.Drawing.Point(4, 22);
            this.HistorialTab.Name = "HistorialTab";
            this.HistorialTab.Padding = new System.Windows.Forms.Padding(3);
            this.HistorialTab.Size = new System.Drawing.Size(579, 416);
            this.HistorialTab.TabIndex = 1;
            this.HistorialTab.Text = "Historial";
            this.HistorialTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.versionControlDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(19, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 377);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla de Historial";
            // 
            // versionControlDataGridView
            // 
            this.versionControlDataGridView.AutoGenerateColumns = false;
            this.versionControlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.versionControlDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.versionControlDataGridView.DataSource = this.versionControlBindingSource;
            this.versionControlDataGridView.Location = new System.Drawing.Point(21, 30);
            this.versionControlDataGridView.Name = "versionControlDataGridView";
            this.versionControlDataGridView.Size = new System.Drawing.Size(499, 321);
            this.versionControlDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "App_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "App_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Version";
            this.dataGridViewTextBoxColumn2.HeaderText = "Version";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AppPath";
            this.dataGridViewTextBoxColumn3.HeaderText = "AppPath";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MainFile";
            this.dataGridViewTextBoxColumn4.HeaderText = "MainFile";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Comments";
            this.dataGridViewTextBoxColumn5.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // versionControlBindingSource
            // 
            this.versionControlBindingSource.DataMember = "VersionControl";
            this.versionControlBindingSource.DataSource = this.configDS;
            // 
            // WebServiceTab
            // 
            this.WebServiceTab.Controls.Add(this.groupBox3);
            this.WebServiceTab.Location = new System.Drawing.Point(4, 22);
            this.WebServiceTab.Name = "WebServiceTab";
            this.WebServiceTab.Padding = new System.Windows.Forms.Padding(3);
            this.WebServiceTab.Size = new System.Drawing.Size(579, 416);
            this.WebServiceTab.TabIndex = 2;
            this.WebServiceTab.Text = "Web Service";
            this.WebServiceTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webServiceSettingsDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(18, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 362);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de Web Services";
            // 
            // webServiceSettingsDataGridView
            // 
            this.webServiceSettingsDataGridView.AutoGenerateColumns = false;
            this.webServiceSettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.webServiceSettingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.webServiceSettingsDataGridView.DataSource = this.webServiceSettingsBindingSource;
            this.webServiceSettingsDataGridView.Location = new System.Drawing.Point(19, 33);
            this.webServiceSettingsDataGridView.Name = "webServiceSettingsDataGridView";
            this.webServiceSettingsDataGridView.Size = new System.Drawing.Size(488, 300);
            this.webServiceSettingsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Order";
            this.dataGridViewTextBoxColumn6.HeaderText = "Order";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Url";
            this.dataGridViewTextBoxColumn7.HeaderText = "Url";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn8.HeaderText = "User";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Pwd";
            this.dataGridViewTextBoxColumn9.HeaderText = "Pwd";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // webServiceSettingsBindingSource
            // 
            this.webServiceSettingsBindingSource.DataMember = "WebServiceSettings";
            this.webServiceSettingsBindingSource.DataSource = this.configDS;
            // 
            // FTPTab
            // 
            this.FTPTab.Controls.Add(this.groupBox4);
            this.FTPTab.Location = new System.Drawing.Point(4, 22);
            this.FTPTab.Name = "FTPTab";
            this.FTPTab.Padding = new System.Windows.Forms.Padding(3);
            this.FTPTab.Size = new System.Drawing.Size(579, 416);
            this.FTPTab.TabIndex = 3;
            this.FTPTab.Text = "FTP";
            this.FTPTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fTPSettingsDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(18, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(541, 367);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de configuraciones FTP";
            // 
            // fTPSettingsDataGridView
            // 
            this.fTPSettingsDataGridView.AutoGenerateColumns = false;
            this.fTPSettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fTPSettingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.fTPSettingsDataGridView.DataSource = this.fTPSettingsBindingSource;
            this.fTPSettingsDataGridView.Location = new System.Drawing.Point(25, 39);
            this.fTPSettingsDataGridView.Name = "fTPSettingsDataGridView";
            this.fTPSettingsDataGridView.Size = new System.Drawing.Size(490, 305);
            this.fTPSettingsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Order";
            this.dataGridViewTextBoxColumn10.HeaderText = "Order";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Server";
            this.dataGridViewTextBoxColumn11.HeaderText = "Server";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn12.HeaderText = "User";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Pwd";
            this.dataGridViewTextBoxColumn13.HeaderText = "Pwd";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn14.HeaderText = "Path";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // fTPSettingsBindingSource
            // 
            this.fTPSettingsBindingSource.DataMember = "FTPSettings";
            this.fTPSettingsBindingSource.DataSource = this.configDS;
            // 
            // HTTPTab
            // 
            this.HTTPTab.AutoScroll = true;
            this.HTTPTab.Controls.Add(this.groupBox5);
            this.HTTPTab.Location = new System.Drawing.Point(4, 22);
            this.HTTPTab.Name = "HTTPTab";
            this.HTTPTab.Padding = new System.Windows.Forms.Padding(3);
            this.HTTPTab.Size = new System.Drawing.Size(579, 416);
            this.HTTPTab.TabIndex = 4;
            this.HTTPTab.Text = "HTTP";
            this.HTTPTab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.httpSettingsDataGridView);
            this.groupBox5.Location = new System.Drawing.Point(19, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(541, 365);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tabla de configuraciones HTTP";
            // 
            // httpSettingsDataGridView
            // 
            this.httpSettingsDataGridView.AutoGenerateColumns = false;
            this.httpSettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.httpSettingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.httpSettingsDataGridView.DataSource = this.httpSettingsBindingSource;
            this.httpSettingsDataGridView.Location = new System.Drawing.Point(22, 36);
            this.httpSettingsDataGridView.Name = "httpSettingsDataGridView";
            this.httpSettingsDataGridView.Size = new System.Drawing.Size(485, 305);
            this.httpSettingsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Order";
            this.dataGridViewTextBoxColumn15.HeaderText = "Order";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Uri";
            this.dataGridViewTextBoxColumn16.HeaderText = "Uri";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn17.HeaderText = "User";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Pwd";
            this.dataGridViewTextBoxColumn18.HeaderText = "Pwd";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // httpSettingsBindingSource
            // 
            this.httpSettingsBindingSource.DataMember = "HttpSettings";
            this.httpSettingsBindingSource.DataSource = this.configDS;
            // 
            // EmailTab
            // 
            this.EmailTab.AutoScroll = true;
            this.EmailTab.BackColor = System.Drawing.Color.Transparent;
            this.EmailTab.Controls.Add(this.groupBox6);
            this.EmailTab.Location = new System.Drawing.Point(4, 22);
            this.EmailTab.Name = "EmailTab";
            this.EmailTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmailTab.Size = new System.Drawing.Size(579, 416);
            this.EmailTab.TabIndex = 5;
            this.EmailTab.Text = "Email";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.emailSettingsDataGridView);
            this.groupBox6.Location = new System.Drawing.Point(17, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(540, 367);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tabla de configuraciones de correo";
            // 
            // emailSettingsDataGridView
            // 
            this.emailSettingsDataGridView.AutoGenerateColumns = false;
            this.emailSettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailSettingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23});
            this.emailSettingsDataGridView.DataSource = this.emailSettingsBindingSource;
            this.emailSettingsDataGridView.Location = new System.Drawing.Point(15, 31);
            this.emailSettingsDataGridView.Name = "emailSettingsDataGridView";
            this.emailSettingsDataGridView.Size = new System.Drawing.Size(502, 309);
            this.emailSettingsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Order";
            this.dataGridViewTextBoxColumn19.HeaderText = "Order";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Server";
            this.dataGridViewTextBoxColumn20.HeaderText = "Server";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn21.HeaderText = "User";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Pwd";
            this.dataGridViewTextBoxColumn22.HeaderText = "Pwd";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Port";
            this.dataGridViewTextBoxColumn23.HeaderText = "Port";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // emailSettingsBindingSource
            // 
            this.emailSettingsBindingSource.DataMember = "EmailSettings";
            this.emailSettingsBindingSource.DataSource = this.configDS;
            // 
            // SalirButton
            // 
            this.SalirButton.Location = new System.Drawing.Point(520, 485);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 44);
            this.SalirButton.TabIndex = 15;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(439, 485);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 44);
            this.GuardarButton.TabIndex = 16;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 541);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "AutoUpdater :: Aplicación de actualización automática";
            this.tabControl1.ResumeLayout(false);
            this.LocalTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configDS)).EndInit();
            this.HistorialTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.versionControlDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionControlBindingSource)).EndInit();
            this.WebServiceTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webServiceSettingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServiceSettingsBindingSource)).EndInit();
            this.FTPTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fTPSettingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTPSettingsBindingSource)).EndInit();
            this.HTTPTab.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.httpSettingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.httpSettingsBindingSource)).EndInit();
            this.EmailTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailSettingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LocalTab;
        private System.Windows.Forms.TabPage HistorialTab;
        private System.Windows.Forms.TabPage WebServiceTab;
        private System.Windows.Forms.TabPage FTPTab;
        private System.Windows.Forms.TabPage HTTPTab;
        private System.Windows.Forms.TabPage EmailTab;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox appPathTextBox;
        private System.Windows.Forms.BindingSource localConfigBindingSource;
        private ConfigDS configDS;
        private System.Windows.Forms.TextBox app_IDTextBox;
        private System.Windows.Forms.TextBox imagePathTextBox;
        private System.Windows.Forms.TextBox appNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox mainFileTextBox;
        private System.Windows.Forms.TextBox currentVersionTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView versionControlDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource versionControlBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView webServiceSettingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.BindingSource webServiceSettingsBindingSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView fTPSettingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.BindingSource fTPSettingsBindingSource;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView httpSettingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.BindingSource httpSettingsBindingSource;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView emailSettingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.BindingSource emailSettingsBindingSource;
        private System.Windows.Forms.Button GuardarButton;
    }
}