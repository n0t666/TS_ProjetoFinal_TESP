using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;
using MySql.Data.MySqlClient;

namespace Cliente.Forms
{
    public partial class Form_Chat : Form_Borderless
    {
        private const int PORTA = 10000;
        private Utilizador utilizadorAtual;
        NetworkStream networkStream;
        TcpClient clienteTCP;
        ProtocolSI protocoloSI;

        public Form_Chat(string username) 
        {
            InitializeComponent();
            criarEventosPanel(this.panel_topBar);
            criarEventosBtns(this.pictureBox_fechar, this.pictureBox_minimizar);
            verificarBotaoEnviar();
            obterUtilizador(username);
            atualizarMensagens();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORTA);
            clienteTCP = new TcpClient();
            clienteTCP.Connect(endPoint);
            networkStream = clienteTCP.GetStream();
            protocoloSI = new ProtocolSI();

        }

        private void Form_Chat_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_mensagem_TextChanged(object sender, EventArgs e)
        {
            verificarBotaoEnviar();
        }

        private void verificarBotaoEnviar()
        {
            if (string.IsNullOrWhiteSpace(textBox_mensagem.Text))
            {
                button_enviarMsg.Enabled = false;
                button_enviarMsg.BackColor = Color.FromArgb(112, 112, 112);
            }
            else
            {
                button_enviarMsg.Enabled = true;
                button_enviarMsg.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void button_enviarMsg_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox_mensagem.Text))
            {
                string mensagem = textBox_mensagem.Text;
                textBox_mensagem.Clear();
                armazenharMensagem(mensagem);
                byte[] pacote = protocoloSI.Make(ProtocolSICmdType.DATA, mensagem);
                networkStream.Write(pacote, 0, pacote.Length);
                while(protocoloSI.GetCmdType() != ProtocolSICmdType.ACK) 
                {
                    networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
                }
            }
            else {
                MessageBox.Show("Não é possível enviar uma mensagem vazia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fecharCliente()
        {
            byte[] eot = protocoloSI.Make(ProtocolSICmdType.EOT);
            networkStream.Write(eot, 0, eot.Length);
            networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
            networkStream.Close();
            clienteTCP.Close();
        }

        private void Form_Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            fecharCliente();
        }

        private void atualizarMensagens()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                var mensagens = db.Utilizadores
                       .Include(u => u.Mensagens)
                       .Where(u => u.Username == utilizadorAtual.Username)
                       .SelectMany(u => u.Mensagens)
                       .ToList();
                listBox_mensagens.BeginUpdate();
                listBox_mensagens.Items.Clear();
                foreach (var msg in mensagens)
                {
                    listBox_mensagens.Items.Add(msg.Texto);
                }
                listBox_mensagens.EndUpdate();
            }
        }

        private void obterUtilizador(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                utilizadorAtual = db.Utilizadores.FirstOrDefault(u => u.Username == username);
            }
        }

        private void armazenharMensagem(string mensagem)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();

                Mensagem msg = new Mensagem();
                msg.Texto = mensagem;
                msg.DataEnvio = DateTime.Now;
                msg.UtilizadorId = utilizadorAtual.id;

                db.Mensagens.Add(msg);
                db.SaveChanges();

                atualizarMensagens();
            }
        }

        private void textBox_mensagem_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox_mensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (e.Modifiers == Keys.Shift)
                {
                    textBox_mensagem.AppendText("\r\n");
                }
                else
                {
                    button_enviarMsg.PerformClick();
                }
            }
        }
    }
}
