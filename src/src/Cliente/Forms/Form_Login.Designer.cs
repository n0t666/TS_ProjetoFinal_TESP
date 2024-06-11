namespace Cliente
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_registar = new System.Windows.Forms.Label();
            this.panel_topBar = new System.Windows.Forms.Panel();
            this.pictureBox_minimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox_fechar = new System.Windows.Forms.PictureBox();
            this.button_PasswordToggler = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(146, 259);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(152, 20);
            this.textBox_username.TabIndex = 2;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(146, 320);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(152, 20);
            this.textBox_password.TabIndex = 3;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(104, 363);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(237, 23);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "ENTRAR";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(252)))));
            this.label3.Location = new System.Drawing.Point(173, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "LOGIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Não possuí uma conta?";
            // 
            // label_registar
            // 
            this.label_registar.AutoSize = true;
            this.label_registar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(252)))));
            this.label_registar.Location = new System.Drawing.Point(272, 397);
            this.label_registar.Name = "label_registar";
            this.label_registar.Size = new System.Drawing.Size(69, 20);
            this.label_registar.TabIndex = 9;
            this.label_registar.Text = "Registar";
            this.label_registar.Click += new System.EventHandler(this.label_registar_Click);
            // 
            // panel_topBar
            // 
            this.panel_topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel_topBar.Controls.Add(this.pictureBox_minimizar);
            this.panel_topBar.Controls.Add(this.pictureBox_fechar);
            this.panel_topBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_topBar.Location = new System.Drawing.Point(0, 0);
            this.panel_topBar.Name = "panel_topBar";
            this.panel_topBar.Size = new System.Drawing.Size(441, 47);
            this.panel_topBar.TabIndex = 0;
            // 
            // pictureBox_minimizar
            // 
            this.pictureBox_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_minimizar.Image")));
            this.pictureBox_minimizar.Location = new System.Drawing.Point(365, 12);
            this.pictureBox_minimizar.Name = "pictureBox_minimizar";
            this.pictureBox_minimizar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_minimizar.TabIndex = 5;
            this.pictureBox_minimizar.TabStop = false;
            // 
            // pictureBox_fechar
            // 
            this.pictureBox_fechar.Image = global::Cliente.Properties.Resources.fechar;
            this.pictureBox_fechar.Location = new System.Drawing.Point(400, 12);
            this.pictureBox_fechar.Name = "pictureBox_fechar";
            this.pictureBox_fechar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fechar.TabIndex = 4;
            this.pictureBox_fechar.TabStop = false;
            // 
            // button_PasswordToggler
            // 
            this.button_PasswordToggler.BackgroundImage = global::Cliente.Properties.Resources.mostrarPwd;
            this.button_PasswordToggler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_PasswordToggler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_PasswordToggler.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_PasswordToggler.Location = new System.Drawing.Point(310, 318);
            this.button_PasswordToggler.Name = "button_PasswordToggler";
            this.button_PasswordToggler.Size = new System.Drawing.Size(31, 23);
            this.button_PasswordToggler.TabIndex = 10;
            this.button_PasswordToggler.UseVisualStyleBackColor = true;
            this.button_PasswordToggler.Click += new System.EventHandler(this.button_PasswordToggler_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cliente.Properties.Resources.pfp;
            this.pictureBox2.Location = new System.Drawing.Point(104, 117);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 450);
            this.Controls.Add(this.button_PasswordToggler);
            this.Controls.Add(this.label_registar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel_topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.Text = "ChatterBox | Entrar";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.panel_topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_registar;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.PictureBox pictureBox_minimizar;
        private System.Windows.Forms.PictureBox pictureBox_fechar;
        private System.Windows.Forms.Button button_PasswordToggler;
    }
}