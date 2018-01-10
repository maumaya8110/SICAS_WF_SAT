namespace SICASv20.forms
{
    partial class ActualizacionPermisosGruposUsuarios
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectNoneButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.PermisosTreeView = new System.Windows.Forms.TreeView();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreGrupoUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NombreGrupoUsuarioTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SelectNoneButton);
            this.groupBox2.Controls.Add(this.GuardarButton);
            this.groupBox2.Controls.Add(this.SelectAllButton);
            this.groupBox2.Controls.Add(this.PermisosTreeView);
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 635);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos de grupo de usuario";
            // 
            // SelectNoneButton
            // 
            this.SelectNoneButton.Location = new System.Drawing.Point(497, 70);
            this.SelectNoneButton.Name = "SelectNoneButton";
            this.SelectNoneButton.Size = new System.Drawing.Size(144, 28);
            this.SelectNoneButton.TabIndex = 22;
            this.SelectNoneButton.Text = "Seleccionar ninguno";
            this.SelectNoneButton.UseVisualStyleBackColor = true;
            this.SelectNoneButton.Click += new System.EventHandler(this.SelectNoneButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(497, 37);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(144, 28);
            this.SelectAllButton.TabIndex = 21;
            this.SelectAllButton.Text = "Seleccionar todos";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // PermisosTreeView
            // 
            this.PermisosTreeView.CheckBoxes = true;
            this.PermisosTreeView.Location = new System.Drawing.Point(23, 70);
            this.PermisosTreeView.Name = "PermisosTreeView";
            this.PermisosTreeView.Size = new System.Drawing.Size(468, 534);
            this.PermisosTreeView.TabIndex = 0;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(497, 104);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(144, 29);
            this.GuardarButton.TabIndex = 22;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Grupo de Usuarios:";
            // 
            // NombreGrupoUsuarioTextBox
            // 
            this.NombreGrupoUsuarioTextBox.Location = new System.Drawing.Point(142, 37);
            this.NombreGrupoUsuarioTextBox.Name = "NombreGrupoUsuarioTextBox";
            this.NombreGrupoUsuarioTextBox.Size = new System.Drawing.Size(349, 21);
            this.NombreGrupoUsuarioTextBox.TabIndex = 24;
            // 
            // ActualizacionPermisosGruposUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "ActualizacionPermisosGruposUsuarios";
            this.Text = "ActualizacionPermisosGruposUsuarios";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SelectNoneButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.TreeView PermisosTreeView;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.TextBox NombreGrupoUsuarioTextBox;
        private System.Windows.Forms.Label label1;
    }
}