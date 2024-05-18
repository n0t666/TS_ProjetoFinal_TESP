using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public class Form_Borderless : Form
    {
        private bool mouseDown; // Variável que indica se o rato está a ser pressionado
        private Point lastLocation; // Variável que guarda a última localização do rato

        public Form_Borderless()
        {
            this.MouseDown += Form_Borderless_MouseDown; // Evento que é chamado quando o rato é pressionado
            this.MouseMove += Form_Borderless_MouseMove; // Evento que é chamado quando o rato é movido
            this.MouseUp += Form_Borderless_MouseUp;
            this.StartPosition = FormStartPosition.CenterScreen; // Inicializa o form no centro do ecrã
        }
        private void Form_Borderless_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; // O rato está a ser pressionado, então move o form
            Cursor.Current = Cursors.SizeAll; // Muda o cursor para o cursor de mover
            lastLocation = e.Location; // Guarda a localização do rato
        }

        private void Form_Borderless_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) // Enquanto o rato estiver a ser pressionado 
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y); // Move o form para a nova localização do cursor do rato
                this.Update(); // Atualiza o form para mostrar a nova localização
            }
        }

        private void Form_Borderless_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form_Borderless
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Borderless";
            this.Load += new System.EventHandler(this.Form_Borderless_Load);
            this.ResumeLayout(false);

        }

        private void Form_Borderless_Load(object sender, EventArgs e)
        {

        }


        // Método que adiciona eventos ao panel passado pelos parametros para mover o form
        public void criarEventosPanel(Panel panel)
        {
            panel.MouseDown += Form_Borderless_MouseDown;
            panel.MouseMove += Form_Borderless_MouseMove;
            panel.MouseUp += Form_Borderless_MouseUp;
        }

        //Uso de pictures box para fechar e minimizar devido ao facto que ao utilizar um botão não fica esteticamente correto devido ao facto de ficar com borda
        public void criarEventosBtns(PictureBox fechar, PictureBox minimizar)
        {
            fechar.Click += Fechar_Click;
            minimizar.Click += Minimizar_Click;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento que é chamado quando o form está prestes a fechar, obtém a confirmação do utilizador
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja fechar o programa?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
