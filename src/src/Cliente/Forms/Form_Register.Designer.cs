namespace Cliente.Forms
{
    partial class Form_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Register));
            this.panel_topBar = new System.Windows.Forms.Panel();
            this.pictureBox_minimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox_fechar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_register = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_passwordConfirm = new System.Windows.Forms.TextBox();
            this.panel_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
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
            this.panel_topBar.TabIndex = 1;
            // 
            // pictureBox_minimizar
            // 
            this.pictureBox_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_minimizar.Image")));
            this.pictureBox_minimizar.Location = new System.Drawing.Point(365, 12);
            this.pictureBox_minimizar.Name = "pictureBox_minimizar";
            this.pictureBox_minimizar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_minimizar.TabIndex = 3;
            this.pictureBox_minimizar.TabStop = false;
            // 
            // pictureBox_fechar
            // 
            this.pictureBox_fechar.Image = global::Cliente.Properties.Resources.fechar;
            this.pictureBox_fechar.Location = new System.Drawing.Point(400, 12);
            this.pictureBox_fechar.Name = "pictureBox_fechar";
            this.pictureBox_fechar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fechar.TabIndex = 1;
            this.pictureBox_fechar.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(252)))));
            this.label3.Location = new System.Drawing.Point(142, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "REGISTRO";
            // 
            // button_register
            // 
            this.button_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_register.ForeColor = System.Drawing.Color.White;
            this.button_register.Location = new System.Drawing.Point(102, 458);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(237, 23);
            this.button_register.TabIndex = 11;
            this.button_register.Text = "REGISTRAR";
            this.button_register.UseVisualStyleBackColor = false;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(144, 312);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(152, 20);
            this.textBox_username.TabIndex = 10;
            // 
            // textBox_nome
            // 
            this.textBox_nome.Location = new System.Drawing.Point(144, 257);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(152, 20);
            this.textBox_nome.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password:";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(144, 367);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(152, 20);
            this.textBox_password.TabIndex = 15;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.Enter += new System.EventHandler(this.textBox_password_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(99, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Já possuí uma conta?";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(252)))));
            this.label_login.Location = new System.Drawing.Point(286, 492);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(53, 20);
            this.label_login.TabIndex = 18;
            this.label_login.Text = "Entrar";
            this.label_login.Click += new System.EventHandler(this.label_login_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cliente.Properties.Resources.pfp;
            this.pictureBox2.Location = new System.Drawing.Point(102, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(140, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Confirmar password:";
            // 
            // textBox_passwordConfirm
            // 
            this.textBox_passwordConfirm.Location = new System.Drawing.Point(144, 422);
            this.textBox_passwordConfirm.Name = "textBox_passwordConfirm";
            this.textBox_passwordConfirm.Size = new System.Drawing.Size(152, 20);
            this.textBox_passwordConfirm.TabIndex = 19;
            this.textBox_passwordConfirm.UseSystemPasswordChar = true;
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 548);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_passwordConfirm);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel_topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Register";
            this.Load += new System.EventHandler(this.Form_Register_Load);
            this.panel_topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.PictureBox pictureBox_fechar;
        private System.Windows.Forms.PictureBox pictureBox_minimizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_passwordConfirm;
    }
}