namespace Cliente.Forms
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel_topBar = new System.Windows.Forms.Panel();
            this.pictureBox_minimizar = new System.Windows.Forms.PictureBox();
            this.pictureBox_fechar = new System.Windows.Forms.PictureBox();
            this.panelSideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMensagem = new DA_ProjetoFinal.Components.SideBarCustomButton();
            this.btnConta = new DA_ProjetoFinal.Components.SideBarCustomButton();
            this.panelLoadingArea = new System.Windows.Forms.Panel();
            this.panel_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).BeginInit();
            this.panelSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_topBar
            // 
            this.panel_topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel_topBar.Controls.Add(this.pictureBox_minimizar);
            this.panel_topBar.Controls.Add(this.pictureBox_fechar);
            this.panel_topBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_topBar.Location = new System.Drawing.Point(0, 0);
            this.panel_topBar.Name = "panel_topBar";
            this.panel_topBar.Size = new System.Drawing.Size(790, 66);
            this.panel_topBar.TabIndex = 3;
            // 
            // pictureBox_minimizar
            // 
            this.pictureBox_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_minimizar.Image")));
            this.pictureBox_minimizar.Location = new System.Drawing.Point(713, 20);
            this.pictureBox_minimizar.Name = "pictureBox_minimizar";
            this.pictureBox_minimizar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_minimizar.TabIndex = 3;
            this.pictureBox_minimizar.TabStop = false;
            // 
            // pictureBox_fechar
            // 
            this.pictureBox_fechar.Image = global::Cliente.Properties.Resources.fechar;
            this.pictureBox_fechar.Location = new System.Drawing.Point(748, 20);
            this.pictureBox_fechar.Name = "pictureBox_fechar";
            this.pictureBox_fechar.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_fechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_fechar.TabIndex = 1;
            this.pictureBox_fechar.TabStop = false;
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelSideBar.Controls.Add(this.panel2);
            this.panelSideBar.Controls.Add(this.pictureBox2);
            this.panelSideBar.Controls.Add(this.panel1);
            this.panelSideBar.Controls.Add(this.btnMensagem);
            this.panelSideBar.Controls.Add(this.btnConta);
            this.panelSideBar.Location = new System.Drawing.Point(0, 66);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(202, 612);
            this.panelSideBar.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 25);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cliente.Properties.Resources.logo2;
            this.pictureBox2.Location = new System.Drawing.Point(3, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(199, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 25);
            this.panel1.TabIndex = 0;
            // 
            // btnMensagem
            // 
            this.btnMensagem.FlatAppearance.BorderSize = 0;
            this.btnMensagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnMensagem.ForeColor = System.Drawing.Color.White;
            this.btnMensagem.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnMensagem.HoverImage = global::Cliente.Properties.Resources.messageSelect;
            this.btnMensagem.Image = global::Cliente.Properties.Resources.message;
            this.btnMensagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMensagem.Location = new System.Drawing.Point(3, 143);
            this.btnMensagem.Name = "btnMensagem";
            this.btnMensagem.NormalForeColor = System.Drawing.Color.White;
            this.btnMensagem.NormalImage = global::Cliente.Properties.Resources.message;
            this.btnMensagem.Size = new System.Drawing.Size(199, 37);
            this.btnMensagem.TabIndex = 6;
            this.btnMensagem.Text = "Mensagens";
            this.btnMensagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMensagem.UseVisualStyleBackColor = true;
            this.btnMensagem.Click += new System.EventHandler(this.btnMensagem_Click);
            // 
            // btnConta
            // 
            this.btnConta.FlatAppearance.BorderSize = 0;
            this.btnConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnConta.ForeColor = System.Drawing.Color.White;
            this.btnConta.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnConta.HoverImage = global::Cliente.Properties.Resources.userSelect;
            this.btnConta.Image = global::Cliente.Properties.Resources.user;
            this.btnConta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConta.Location = new System.Drawing.Point(3, 186);
            this.btnConta.Name = "btnConta";
            this.btnConta.NormalForeColor = System.Drawing.Color.White;
            this.btnConta.NormalImage = global::Cliente.Properties.Resources.user;
            this.btnConta.Size = new System.Drawing.Size(199, 37);
            this.btnConta.TabIndex = 7;
            this.btnConta.Text = "Conta";
            this.btnConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConta.UseVisualStyleBackColor = true;
            this.btnConta.Click += new System.EventHandler(this.btnConta_Click);
            // 
            // panelLoadingArea
            // 
            this.panelLoadingArea.BackColor = System.Drawing.Color.Transparent;
            this.panelLoadingArea.Location = new System.Drawing.Point(202, 66);
            this.panelLoadingArea.Name = "panelLoadingArea";
            this.panelLoadingArea.Size = new System.Drawing.Size(588, 612);
            this.panelLoadingArea.TabIndex = 5;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 676);
            this.Controls.Add(this.panelLoadingArea);
            this.Controls.Add(this.panelSideBar);
            this.Controls.Add(this.panel_topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.panel_topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fechar)).EndInit();
            this.panelSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_minimizar;
        private System.Windows.Forms.PictureBox pictureBox_fechar;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.FlowLayoutPanel panelSideBar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private DA_ProjetoFinal.Components.SideBarCustomButton btnMensagem;
        private System.Windows.Forms.Panel panelLoadingArea;
        private System.Windows.Forms.Panel panel2;
        private DA_ProjetoFinal.Components.SideBarCustomButton btnConta;
    }
}