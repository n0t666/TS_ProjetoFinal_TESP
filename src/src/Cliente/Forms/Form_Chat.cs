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
        //Declaração de variáveis para a conexão com o servidor
        private const int PORTA = 10000;
        private Utilizador utilizadorAtual;
        NetworkStream networkStream;
        TcpClient clienteTCP;
        ProtocolSI protocoloSI;
        //--------------------------------------------------------------------------------

        //Construtor 
        public Form_Chat(string username) 
        {
            InitializeComponent();
            criarEventosPanel(this.panel_topBar); //Chamada ao método para permitir mover a barra superior
            criarEventosBtns(this.pictureBox_fechar, this.pictureBox_minimizar); //Chamada ao método para permitir fechar e minimizar a janela
            verificarBotaoEnviar(); //Chamada ao método para verificar se a mensagem está vazia, para ativar ou desativar o botão de enviar
            obterUtilizador(username); //Chamada ao método para obter o objeto Utilizador com base no username
            MessageBox.Show("Bem-vindo " + utilizadorAtual.Nome + "!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mensagem de boas-vindas
            //--------------------------------------------------------------------------------
            // Conexão com o servidor
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORTA);
            clienteTCP = new TcpClient();
            clienteTCP.Connect(endPoint);
            networkStream = clienteTCP.GetStream();
            protocoloSI = new ProtocolSI();
            //--------------------------------------------------------------------------------

        }

        private void Form_Chat_Load(object sender, EventArgs e)
        {
            atualizarMensagens();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_mensagem_TextChanged(object sender, EventArgs e)
        {
            verificarBotaoEnviar();
        }

        //Método para verificar se a mensagem está vazia, para ativar ou desativar o botão de enviar
        private void verificarBotaoEnviar()
        {
            if (string.IsNullOrWhiteSpace(textBox_mensagem.Text)) // Se a mensagem estiver vazia, desativar butão de envio da mensagem
            {
                button_enviarMsg.Enabled = false;
                button_enviarMsg.BackColor = Color.FromArgb(112, 112, 112);
            }
            else // Senão,ativar o botão de envio
            {
                button_enviarMsg.Enabled = true;
                button_enviarMsg.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        //Método para enviar a mensagem
        private void button_enviarMsg_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox_mensagem.Text)) // Certificar-se que existe realmente algum contéudo da textbox da mensagem
            {
                string mensagem = textBox_mensagem.Text; // Extrair a mensagem da textbox
                textBox_mensagem.Clear();
                armazenharMensagem(mensagem);
                byte[] pacote = protocoloSI.Make(ProtocolSICmdType.DATA, mensagem); // Criar o pacote com a mensagem
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

        //Método para fechar o cliente e disconectar do servidor
        private void fecharCliente()
        {
            byte[] eot = protocoloSI.Make(ProtocolSICmdType.EOT);
            networkStream.Write(eot, 0, eot.Length);
            networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
            networkStream.Close();
            clienteTCP.Close();
        }
        
        //Ao fechar a janela, chamar o método para fechar o cliente
        private void Form_Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            fecharCliente();
        }

        //Método para atualizar as mensagens na listbox
        private void atualizarMensagens()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString)) 
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                //Query para obter todas as mensagens associadas ao utilizador atual
                var mensagens= db.Mensagens
                    .Include(u => u.Utilizador.Mensagens.Select(m => m.Utilizador))
                    .ToList();

                //Fazer update da listbox, utilizar o método BeginUpdate e EndUpdate para melhorar a performance ao adicionar vários itens 
                listBox_mensagens.BeginUpdate();
                listBox_mensagens.Items.Clear();
                foreach (Mensagem msg in mensagens) // Para cada mensagem associada ao utilizador atual, adicionar à listbox
                {
                    listBox_mensagens.Items.Add(msg.Utilizador.Nome + ": " + msg.Texto + "(" + msg.DataEnvio.ToShortTimeString() + ")");
                }
                listBox_mensagens.EndUpdate();

            }
        }

        //Método para obter o objeto Utilizador com base no username com o qual o utilizador se autenticou
        private void obterUtilizador(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                utilizadorAtual = db.Utilizadores.Include(u => u.Mensagens).FirstOrDefault(u => u.Username == username);
            }
        }

        //Método para armazenhar a mensagem na base de dados
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
                utilizadorAtual.Mensagens.Add(msg); // adicionar mensagem com associação ao utilizador


                db.Mensagens.Add(msg);


                db.SaveChanges();   

                atualizarMensagens(); // Chamar o método para atualizar as mensagens na listbox
            }
        }

        private void textBox_mensagem_Enter(object sender, EventArgs e)
        {
            
        }


        //Método para enviar a mensagem ao pressionar a tecla Enter, sem ser necessário clicar no botão de enviar
        //Se o shift e o enter forem pressionados, é criada uma nova linha na textbox
        private void textBox_mensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impedir que a tecla Enter tenha o seu comportamento padrão (criar uma nova linha)
                if (e.Modifiers == Keys.Shift) // Se a tecla ENTER + Shift for pressionada, criar uma nova linha
                {
                    textBox_mensagem.AppendText("\r\n"); // Criar uma nova linha
                }
                else
                {
                    button_enviarMsg.PerformClick(); // Continuar com o comportamento padrão do botão de enviar
                }
            }
        }

        private void Form_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            fecharCliente();
        }
    }
}
