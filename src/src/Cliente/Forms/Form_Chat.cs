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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;
using MySql.Data.MySqlClient;
using SaaUI;

namespace Cliente.Forms
{

    public partial class Form_Chat : Form
    {
        //Declaração de variáveis para a conexão com o servidor
        private const int PORTA = 10000;
        private Utilizador utilizadorAtual;
        NetworkStream networkStream;
        TcpClient clienteTCP;
        ProtocolSI protocoloSI;
        //--------------------------------------------------------------------------------

        private DateTime dataUltimaMensagem; // Variável para armazenar a data da última mensagem

        //Construtor 
        public Form_Chat(int id)
        {
            InitializeComponent();
            obterUtilizador(id); // Obter o utilizador com base no username
            MessageBox.Show("Bem-vindo " + utilizadorAtual.Nome + "!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mensagem de boas-vindas
            //--------------------------------------------------------------------------------
            // Conexão com o servidor
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORTA);
            clienteTCP = new TcpClient();
            clienteTCP.Connect(endPoint);
            networkStream = clienteTCP.GetStream();
            protocoloSI = new ProtocolSI();
            //-------------------------------------------------------------------------------
        }

        //Ao carregar o formulário, chamar o método para carregar todas as mensagens e iniciar o timer para atualizar as mensagens
        private void Form_Chat_Load(object sender, EventArgs e)
        {
            labelReceiver.Text = "Nenhum utilizador online";
            carregarTodasMensagens();
            timer_UpdateMsgs.Start(); 
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
            if (!string.IsNullOrWhiteSpace(textBox_mensagem.Text)) // Certificar-se que existe realmente algum contéudo da textbox da mensagem
            {
                if (RegisterHelper.NumeroUtilizadoresOnline() == 2) // Verificar se existe mais do que um utilizador online, para poder enviar a mensagem
                {
                    string mensagem = textBox_mensagem.Text;
                    textBox_mensagem.Clear();
                    armazenharMensagem(mensagem);
                    byte[] pacote = protocoloSI.Make(ProtocolSICmdType.DATA, mensagem); // Criar o pacote com a mensagem
                    networkStream.Write(pacote, 0, pacote.Length);
                    while (protocoloSI.GetCmdType() != ProtocolSICmdType.ACK)
                    {
                        networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
                    }
                }
                else // Se não existir mais do que um utilizador online, não permitir o envio da mensagem
                {
                    MessageBox.Show("Tem de haver obrigatoriamente mais um utilizador online!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else // Se a mensagem estiver vazia, mostrar uma mensagem de aviso
            {
                MessageBox.Show("Não é possível enviar uma mensagem vazia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Método para fechar o cliente e disconectar do servidor
        public void fecharCliente()
        {
            MessageBox.Show("A sessão foi terminada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            byte[] eot = protocoloSI.Make(ProtocolSICmdType.EOT);
            networkStream.Write(eot, 0, eot.Length);
            networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
            networkStream.Close();
            clienteTCP.Close();
            RegisterHelper.AlterarEstado(utilizadorAtual.id, false);

        }

        //Ao fechar a janela, chamar o método para fechar o cliente
        private void Form_Chat_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        //Método para atualizar as mensagens na listbox
        private void atualizarMensagens()
        {
            if (dataUltimaMensagem != null)
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
                {
                    ChatContext db = new ChatContext(connection, false);
                    connection.Open();
                    //Query para obter todas as mensagens associadas ao utilizador atual
                    var mensagens = db.Mensagens
                        .Include(u => u.Utilizador.Mensagens.Select(m => m.Utilizador))
                        .Where(m => m.DataEnvio > dataUltimaMensagem)
                        .Where(u => u.Utilizador.id != utilizadorAtual.id && u.RecetorId == utilizadorAtual.id)
                        .OrderBy(m => m.DataEnvio)
                        .ToList();
                    if (mensagens.Any())
                    {
                        foreach (Mensagem msg in mensagens) // Para cada mensagem associada ao utilizador atual, adicionar à listbox
                        {
                            string texto = Utils.DecryptData(msg.Texto, utilizadorAtual.ChavePrivada); // Desencriptar a mensagem, antes de verificar a assinatura
                            bool verificacao = Utils.VerifyData(texto, msg.Assinatura, msg.Utilizador.ChavePublica); // Verificar a assinatura da mensagem
                            if (verificacao) // Verificar se a mensagem foi enviada pelo utilizador correto
                            {
                                criarComponenteMensagem(texto, msg.Utilizador.id);
                            }
                            else // Se a mensagem não foi enviada pelo utilizador correto, mostrar uma mensagem de aviso a indicar que a mensagem não é válida
                            {
                                MessageBox.Show(texto + " - Erro ao validar o emissor da mensagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                db.Mensagens.Remove(msg); // Remover a mensagem da base de dados
                                db.SaveChanges();
                            }
                        }
                        dataUltimaMensagem = mensagens.Max(m => m.DataEnvio);
                    }
                }
            }
        }

        //Método para carregar todas as mensagens associadas ao utilizador atual, no inicio do chat
        private void carregarTodasMensagens()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                //Query para obter todas as mensagens associadas ao utilizador atual
                var mensagens = db.Mensagens
                    .Include(u => u.Utilizador.Mensagens.Select(m => m.Utilizador))
                    .Include(u => u.Recetor)
                    .OrderBy(m => m.DataEnvio)
                    .Where(u => u.Utilizador.id == utilizadorAtual.id || u.RecetorId == utilizadorAtual.id) // Obter mensagens enviadas e recebidas pelo utilizador atual
                    .ToList();
                if (mensagens.Any())
                {
                    //Fazer update da listbox, utilizar o método BeginUpdate e EndUpdate para melhorar a performance ao adicionar vários itens 
                    foreach (Mensagem msg in mensagens) // Para cada mensagem associada ao utilizador atual, adicionar à listbox
                    {
                        string texto;
                        if (msg.RecetorId == utilizadorAtual.id)
                        {
                            texto = Utils.DecryptData(msg.Texto, utilizadorAtual.ChavePrivada);
                        }
                        else
                        {
                            texto = Utils.DecryptData(msg.Texto, msg.Recetor.ChavePrivada);
                        }
                         
                        if(msg.RecetorId == utilizadorAtual.id && !Utils.VerifyData(texto, msg.Assinatura, msg.Utilizador.ChavePublica))
                        {
                            MessageBox.Show(texto + " - Erro ao validar o emissor da mensagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            db.Mensagens.
                            Remove(db.Mensagens.FirstOrDefault(m => m.id == msg.id));
                            db.SaveChanges();
                        }
                        else
                        {
                            criarComponenteMensagem(texto, msg.Utilizador.id);
                        }
                    }
                    dataUltimaMensagem = mensagens.Max(m => m.DataEnvio);
                }
            }

        }




        //Método para armazenhar a mensagem na base de dados
        private void armazenharMensagem(string mensagem)
        {
            string utilizarOnline = Utils.GetDestinatarioPublicKey(utilizadorAtual.id);
            string mensagemEncriptada = Utils.EncryptData(mensagem, utilizarOnline);
            string signature = Utils.SignData(mensagem, utilizadorAtual.ChavePrivada);
            Utilizador receptor = RegisterHelper.GetOnlineReceiver(utilizadorAtual.id);
            if (mensagemEncriptada == null || signature == null)
            {
                MessageBox.Show("Erro ao encriptar a mensagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
                {
                    ChatContext db = new ChatContext(connection, false);
                    connection.Open();


                    Mensagem msg = new Mensagem();
                    msg.Texto = mensagemEncriptada;
                    msg.Assinatura = signature;
                    msg.DataEnvio = DateTime.Now;
                    msg.UtilizadorId = utilizadorAtual.id;
                    msg.RecetorId = receptor.id;
                    utilizadorAtual.Mensagens.Add(msg); // adicionar mensagem com associação ao utilizador


                    db.Mensagens.Add(msg);


                    db.SaveChanges();

                    dataUltimaMensagem = msg.DataEnvio; // Atualizar a data da última mensagem

                    criarComponenteMensagem(mensagem, utilizadorAtual.id);


                }
            }
        }

        private void textBox_mensagem_Enter(object sender, EventArgs e)
        {

        }


        //Método para enviar a mensagem ao pressionar a tecla Enter, sem ser necessário clicar no botão de enviar
        //Se o shift e o enter forem pressionados, é criada uma nova linha na textbox
        private void textBox_mensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        //Método para fechar o cliente e disconectar do servidor, e atualizar o estado do utilizador para offline
        private void Form_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            fecharCliente();
        }

        //Método para atualizar as mensagens a cada 5 segundos
        private void timer_UpdateMsgs_Tick(object sender, EventArgs e)
        {
            atualizarMensagens();
            if(RegisterHelper.NumeroUtilizadoresOnline() == 2)
            {
                labelReceiver.Text = RegisterHelper.GetOnlineReceiver(utilizadorAtual.id).Username;
            }
            else
            {
                labelReceiver.Text = "Nenhum utilizador online";
            }

        }

        //Método para criar o componente da mensagem
        private void criarComponenteMensagem(string mensagem, int id)
        {
            SaaChatBubble chatBubble = new SaaChatBubble();

            if (mensagem.Length > 350)
            {
                chatBubble.MinimumSize = new Size(300, 300);
            }
            else if (mensagem.Length > 100)
            {
                chatBubble.MinimumSize = new Size(300, 150);
            }
            else
            {
                chatBubble.MinimumSize = new Size(300, 80);
            }


            if (id == utilizadorAtual.id)
            {
                chatBubble.MsgBackground = Color.FromArgb(51, 51, 51);
            }
            else
            {
                chatBubble.MsgBackground = Color.FromArgb(92, 92, 92);
                chatBubble.Margin = new Padding(200, 0, 0, 0);
            }

            chatBubble.BackColor = Color.Transparent;
            chatBubble.Profile = false;
            chatBubble.Padding = new Padding(10);
            chatBubble.BodyPadding = new Padding(10);
            chatBubble.PeakPosition = PeakPositions.TopRight;
            chatBubble.ProfilePosition = BubbleProfilePosition.Right;
            chatBubble.Peak = false;
            chatBubble.Body = mensagem;
            flowLayoutPanel1.Controls.Add(chatBubble);
            flowLayoutPanel1.ScrollControlIntoView(chatBubble);

        }


        //Método para obter o objeto Utilizador com base no username com o qual o utilizador se autenticou
        private void obterUtilizador(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                utilizadorAtual = db.Utilizadores.Include(u => u.Mensagens).FirstOrDefault(u => u.id == id);
            }
        }
    }


}

