namespace Cliente.Forms
{
    partial class Form_Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Chat));
            this.panel_topBar = new System.Windows.Forms.Panel();
            this.pictureBox_minimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox_fechar = new System.Windows.Forms.PictureBox();
            this.textBox_mensagem = new System.Windows.Forms.TextBox();
            this.button_enviarMsg = new System.Windows.Forms.Button();
            this.timer_UpdateMsgs = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).BeginInit();
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
            this.panel_topBar.Size = new System.Drawing.Size(651, 47);
            this.panel_topBar.TabIndex = 2;
            // 
            // pictureBox_minimizar
            // 
            this.pictureBox_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_minimizar.Image")));
            this.pictureBox_minimizar.Location = new System.Drawing.Point(574, 12);
            this.pictureBox_minimizar.Name = "pictureBox_minimizar";
            this.pictureBox_minimizar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_minimizar.TabIndex = 3;
            this.pictureBox_minimizar.TabStop = false;
            // 
            // pictureBox_fechar
            // 
            this.pictureBox_fechar.Image = global::Cliente.Properties.Resources.fechar;
            this.pictureBox_fechar.Location = new System.Drawing.Point(609, 12);
            this.pictureBox_fechar.Name = "pictureBox_fechar";
            this.pictureBox_fechar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fechar.TabIndex = 1;
            this.pictureBox_fechar.TabStop = false;
            // 
            // textBox_mensagem
            // 
            this.textBox_mensagem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_mensagem.Location = new System.Drawing.Point(69, 549);
            this.textBox_mensagem.Multiline = true;
            this.textBox_mensagem.Name = "textBox_mensagem";
            this.textBox_mensagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_mensagem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_mensagem.Size = new System.Drawing.Size(461, 49);
            this.textBox_mensagem.TabIndex = 4;
            this.textBox_mensagem.TextChanged += new System.EventHandler(this.textBox_mensagem_TextChanged);
            this.textBox_mensagem.Enter += new System.EventHandler(this.textBox_mensagem_Enter);
            this.textBox_mensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mensagem_KeyDown);
            // 
            // button_enviarMsg
            // 
            this.button_enviarMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_enviarMsg.BackgroundImage = global::Cliente.Properties.Resources.enviar5;
            this.button_enviarMsg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_enviarMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_enviarMsg.ForeColor = System.Drawing.Color.Transparent;
            this.button_enviarMsg.Location = new System.Drawing.Point(536, 549);
            this.button_enviarMsg.Name = "button_enviarMsg";
            this.button_enviarMsg.Size = new System.Drawing.Size(56, 49);
            this.button_enviarMsg.TabIndex = 5;
            this.button_enviarMsg.UseVisualStyleBackColor = false;
            this.button_enviarMsg.Click += new System.EventHandler(this.button_enviarMsg_Click);
            // 
            // timer_UpdateMsgs
            // 
            this.timer_UpdateMsgs.Interval = 5000;
            this.timer_UpdateMsgs.Tick += new System.EventHandler(this.timer_UpdateMsgs_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(69, 69);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 458);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // Form_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 676);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button_enviarMsg);
            this.Controls.Add(this.textBox_mensagem);
            this.Controls.Add(this.panel_topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Chat";
            this.Text = "Form_Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Chat_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Chat_FormClosed);
            this.Load += new System.EventHandler(this.Form_Chat_Load);
            this.panel_topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_minimizar;
        private System.Windows.Forms.PictureBox pictureBox_fechar;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.TextBox textBox_mensagem;
        private System.Windows.Forms.Button button_enviarMsg;
        private System.Windows.Forms.Timer timer_UpdateMsgs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}