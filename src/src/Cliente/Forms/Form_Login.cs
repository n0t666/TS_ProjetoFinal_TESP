using Cliente.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_Login : Form_Borderless
    {
        private bool passwordEscondida = true;

        public Form_Login()
        {
            InitializeComponent();
            criarEventosPanel(this.panel_topBar);
            criarEventosBtns(this.pictureBox_fechar, this.pictureBox_minimizar);
            this.AcceptButton = button_login; // Permite fazer login ao pressionar a tecla Enter
        }

        //Evento que é chamado quando o botão de login é pressionado
        private void button_login_Click(object sender, EventArgs e)
        {
            //Caso as credenciais inseridas sejam null ou contenham espaços em branco
            if (string.IsNullOrWhiteSpace(textBox_username.Text) || string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos necessários", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
                {
                    ChatContext db = new ChatContext(connection, false);
                    connection.Open();

                    //Procura o utilizador na base de dados
                    var utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == textBox_username.Text);
                    if (utilizador == null)
                    {
                        MessageBox.Show("Utilizador não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Verifica se a password inserida é igual à password guardada na base de dados
                        byte[] salt = Convert.FromBase64String(utilizador.Salt); 
                        byte[] hash = RegisterHelper.GerarBytesHash(textBox_password.Text, salt, 1000);
                        string passwordHash = Convert.ToBase64String(hash);

                        if (passwordHash == utilizador.Password)
                        {
                            if(utilizador.Online == true) //Verifica se o utilizador já se encontra online e não permite o login
                            {
                                MessageBox.Show("Utilizador já se encontra online", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (RegisterHelper.VerificarNumeroUtilizadoresOnline(utilizador.id)) //Verifica se já existem 2 utilizadores online, caso existam, não permite o login
                            {
                                MessageBox.Show("No máximo apenas é permitido 2 utilizadores simultaneamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                RegisterHelper.AlterarEstado(utilizador.id, true);
                                var frm = new Form_Chat(textBox_username.Text);
                                frm.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Password ou utilizador errado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        //Evento que é chamado quando o label de registar é pressionado
        private void label_registar_Click(object sender, EventArgs e)
        {
            //Mudar para a janela de registo
            var frm = new Form_Register();
            frm.Show();
            this.Hide();

        }

        private void button_PasswordToggler_Click(object sender, EventArgs e)
        {
            //Caso a password esteja escondida, mostra-a
            if (passwordEscondida)
            {
                textBox_password.UseSystemPasswordChar = false;
                button_PasswordToggler.BackgroundImage = Properties.Resources.esconderPwd;
                passwordEscondida = false;
            }
            else //Caso contrário, esconde-a
            {
                textBox_password.UseSystemPasswordChar = true;
                button_PasswordToggler.BackgroundImage = Properties.Resources.mostrarPwd;
                passwordEscondida = true;
            }

        }
    }
}
