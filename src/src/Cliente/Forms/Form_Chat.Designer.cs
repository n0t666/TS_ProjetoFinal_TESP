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
            this.textBox_mensagem = new System.Windows.Forms.TextBox();
            this.timer_UpdateMsgs = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_enviarMsg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_mensagem
            // 
            this.textBox_mensagem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_mensagem.Location = new System.Drawing.Point(38, 549);
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
            // timer_UpdateMsgs
            // 
            this.timer_UpdateMsgs.Interval = 5000;
            this.timer_UpdateMsgs.Tick += new System.EventHandler(this.timer_UpdateMsgs_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 69);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 458);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // button_enviarMsg
            // 
            this.button_enviarMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_enviarMsg.BackgroundImage = global::Cliente.Properties.Resources.enviar5;
            this.button_enviarMsg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_enviarMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_enviarMsg.ForeColor = System.Drawing.Color.Transparent;
            this.button_enviarMsg.Location = new System.Drawing.Point(505, 549);
            this.button_enviarMsg.Name = "button_enviarMsg";
            this.button_enviarMsg.Size = new System.Drawing.Size(56, 49);
            this.button_enviarMsg.TabIndex = 5;
            this.button_enviarMsg.UseVisualStyleBackColor = false;
            this.button_enviarMsg.Click += new System.EventHandler(this.button_enviarMsg_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelReceiver);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 45);
            this.panel1.TabIndex = 8;
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
            // Form_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(588, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button_enviarMsg);
            this.Controls.Add(this.textBox_mensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Chat";
            this.Text = "Form_Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Chat_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Chat_FormClosed);
            this.Load += new System.EventHandler(this.Form_Chat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_mensagem;
        private System.Windows.Forms.Button button_enviarMsg;
        private System.Windows.Forms.Timer timer_UpdateMsgs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReceiver;
    }
}