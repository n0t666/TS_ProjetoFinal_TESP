namespace Cliente.Forms
{
    partial class Form_Conta
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_password = new SaaUI.SaaFlatTextBox();
            this.textBox_passwordConfirm = new SaaUI.SaaFlatTextBox();
            this.textBox_nome = new SaaUI.SaaFlatTextBox();
            this.textBox_username = new SaaUI.SaaFlatTextBox();
            this.button_update = new SaaUI.SaaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.pictureBoxLogout = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Confirmar password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 31);
            this.label3.TabIndex = 30;
            this.label3.Text = "Minha conta";
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.Color.White;
            this.textBox_password.Border = true;
            this.textBox_password.BorderActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.textBox_password.BorderColor = System.Drawing.Color.Gainsboro;
            this.textBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_password.Hint = "";
            this.textBox_password.Location = new System.Drawing.Point(184, 282);
            this.textBox_password.MaxLength = 32767;
            this.textBox_password.Multiline = false;
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '\0';
            this.textBox_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_password.SelectedText = "";
            this.textBox_password.SelectionLength = 0;
            this.textBox_password.SelectionStart = 0;
            this.textBox_password.Size = new System.Drawing.Size(263, 38);
            this.textBox_password.TabIndex = 31;
            this.textBox_password.TabStop = false;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // textBox_passwordConfirm
            // 
            this.textBox_passwordConfirm.BackColor = System.Drawing.Color.White;
            this.textBox_passwordConfirm.Border = true;
            this.textBox_passwordConfirm.BorderActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.textBox_passwordConfirm.BorderColor = System.Drawing.Color.Gainsboro;
            this.textBox_passwordConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_passwordConfirm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_passwordConfirm.Hint = "";
            this.textBox_passwordConfirm.Location = new System.Drawing.Point(184, 353);
            this.textBox_passwordConfirm.MaxLength = 32767;
            this.textBox_passwordConfirm.Multiline = false;
            this.textBox_passwordConfirm.Name = "textBox_passwordConfirm";
            this.textBox_passwordConfirm.PasswordChar = '\0';
            this.textBox_passwordConfirm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_passwordConfirm.SelectedText = "";
            this.textBox_passwordConfirm.SelectionLength = 0;
            this.textBox_passwordConfirm.SelectionStart = 0;
            this.textBox_passwordConfirm.Size = new System.Drawing.Size(263, 38);
            this.textBox_passwordConfirm.TabIndex = 32;
            this.textBox_passwordConfirm.TabStop = false;
            this.textBox_passwordConfirm.UseSystemPasswordChar = true;
            // 
            // textBox_nome
            // 
            this.textBox_nome.BackColor = System.Drawing.Color.White;
            this.textBox_nome.Border = true;
            this.textBox_nome.BorderActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.textBox_nome.BorderColor = System.Drawing.Color.Gainsboro;
            this.textBox_nome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_nome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_nome.Hint = "";
            this.textBox_nome.Location = new System.Drawing.Point(184, 140);
            this.textBox_nome.MaxLength = 32767;
            this.textBox_nome.Multiline = false;
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.PasswordChar = '\0';
            this.textBox_nome.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_nome.SelectedText = "";
            this.textBox_nome.SelectionLength = 0;
            this.textBox_nome.SelectionStart = 0;
            this.textBox_nome.Size = new System.Drawing.Size(263, 38);
            this.textBox_nome.TabIndex = 33;
            this.textBox_nome.TabStop = false;
            this.textBox_nome.UseSystemPasswordChar = false;
            // 
            // textBox_username
            // 
            this.textBox_username.BackColor = System.Drawing.Color.White;
            this.textBox_username.Border = true;
            this.textBox_username.BorderActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.textBox_username.BorderColor = System.Drawing.Color.Gainsboro;
            this.textBox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_username.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_username.Hint = "";
            this.textBox_username.Location = new System.Drawing.Point(184, 211);
            this.textBox_username.MaxLength = 32767;
            this.textBox_username.Multiline = false;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.PasswordChar = '\0';
            this.textBox_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_username.SelectedText = "";
            this.textBox_username.SelectionLength = 0;
            this.textBox_username.SelectionStart = 0;
            this.textBox_username.Size = new System.Drawing.Size(263, 38);
            this.textBox_username.TabIndex = 34;
            this.textBox_username.TabStop = false;
            this.textBox_username.UseSystemPasswordChar = false;
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_update.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_update.BackColorAngle = 90F;
            this.button_update.Border = 1;
            this.button_update.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.button_update.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.button_update.BorderColorAngle = 0;
            this.button_update.ClickColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(110)))), ((int)(((byte)(160)))));
            this.button_update.ClickColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(110)))), ((int)(((byte)(160)))));
            this.button_update.EnableDoubleBuffering = true;
            this.button_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button_update.ForeColor = System.Drawing.Color.White;
            this.button_update.HoverColor1 = System.Drawing.Color.SteelBlue;
            this.button_update.HoverColor2 = System.Drawing.Color.SteelBlue;
            this.button_update.Icon = null;
            this.button_update.IconOffsetX = 5F;
            this.button_update.IconOffsetY = 5F;
            this.button_update.IconSize = new System.Drawing.Size(20, 20);
            this.button_update.Location = new System.Drawing.Point(158, 409);
            this.button_update.Name = "button_update";
            this.button_update.Radius.BottomLeft = 10;
            this.button_update.Radius.BottomRight = 10;
            this.button_update.Radius.TopLeft = 10;
            this.button_update.Radius.TopRight = 10;
            this.button_update.Size = new System.Drawing.Size(315, 38);
            this.button_update.TabIndex = 35;
            this.button_update.TextOffsetX = 0F;
            this.button_update.TextOffsetY = 0F;
            this.button_update.Value = "Atualizar";
            this.button_update.Click += new System.EventHandler(this.button_update_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelReceiver);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 45);
            this.panel1.TabIndex = 36;
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiver.ForeColor = System.Drawing.Color.White;
            this.labelReceiver.Location = new System.Drawing.Point(12, 9);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(0, 31);
            this.labelReceiver.TabIndex = 0;
            // 
            // pictureBoxLogout
            // 
            this.pictureBoxLogout.Image = global::Cliente.Properties.Resources.quit;
            this.pictureBoxLogout.Location = new System.Drawing.Point(511, 64);
            this.pictureBoxLogout.Name = "pictureBoxLogout";
            this.pictureBoxLogout.Size = new System.Drawing.Size(65, 37);
            this.pictureBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogout.TabIndex = 37;
            this.pictureBoxLogout.TabStop = false;
            this.pictureBoxLogout.Click += new System.EventHandler(this.pictureBoxLogout_Click);
            // 
            // Form_Conta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 612);
            this.Controls.Add(this.pictureBoxLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.textBox_passwordConfirm);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Conta";
            this.Text = "Form_Conta";
            this.Load += new System.EventHandler(this.Form_Conta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private SaaUI.SaaFlatTextBox textBox_password;
        private SaaUI.SaaFlatTextBox textBox_passwordConfirm;
        private SaaUI.SaaFlatTextBox textBox_nome;
        private SaaUI.SaaFlatTextBox textBox_username;
        private SaaUI.SaaButton button_update;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.PictureBox pictureBoxLogout;
    }
}