using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cliente.Forms
{
    public partial class Form_Register : Form_Borderless 
    {

        private const int NUM_INTERACOES = 1000;
        private const int TAMANHO_SALT = 32;
        private RSACryptoServiceProvider rsa;

        public Form_Register()
        {
            InitializeComponent();
            criarEventosPanel(this.panel_topBar);
            criarEventosBtns(this.pictureBox_fechar, this.pictureBox_minimizar);
            this.AcceptButton = button_register; // Permite fazer registo ao pressionar a tecla Enter
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            // Verificar se os campos estão todos devidamente preenchidos
            if (string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_password.Text) || string.IsNullOrEmpty(textBox_nome.Text)) 
            {
                MessageBox.Show("Por favor, preencha todos os campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (textBox_password.Text != textBox_passwordConfirm.Text) // Verificar se as passwords inseridas são iguais
            {
                MessageBox.Show("As passwords não coincidem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(RegisterHelper.VerificarUsername(textBox_username.Text))
                {
                    MessageBox.Show("Username já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!RegisterHelper.ValidarPassword(textBox_password.Text))
                {
                    MessageBox.Show("A password deve ter no mínimo 8 caracteres, incluindo pelo menos 1 letra maiúscula, 1 letra minúscula e 1 carácter especial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string username = textBox_username.Text;
                string nome = textBox_nome.Text;
                string password = textBox_password.Text;

                byte[] salt = RegisterHelper.GerarSalt(TAMANHO_SALT);
                byte[] hash = RegisterHelper.GerarBytesHash(password, salt, NUM_INTERACOES);

                string passwordHash = Convert.ToBase64String(hash);

                rsa = new RSACryptoServiceProvider();
                string chavePublica = rsa.ToXmlString(false);
                string chavePrivada = rsa.ToXmlString(true);

                try 
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
                    {
                        ChatContext db = new ChatContext(connection, false);
                        var utilizador = new Utilizador { Username = username, Password = passwordHash, Salt = Convert.ToBase64String(salt), Nome = nome, ChavePublica = chavePublica,ChavePrivada = chavePrivada };

                        db.Utilizadores.Add(utilizador);
                        db.SaveChanges();

                        // Esta instrução é executada caso o registo seja efetuado com sucesso, caso ocorra um erro é lançada uma exceção e o try faz o catch da mesma
                        MessageBox.Show("Registo efetuado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var frm = new Form_Login();
                        frm.Show();
                        this.Hide();
                    }
                }catch(DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors) // Percorrer os erros de validação do modelo Utilizador 
                        {
                            MessageBox.Show(" Erro: " + validationError.ErrorMessage);
                        }
                    }

                }

            }
        }

        private void label_login_Click(object sender, EventArgs e)
        {
            var frm = new Form_Login();
            frm.Show();
            this.Hide();
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox_password_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip passwordToolTip = new System.Windows.Forms.ToolTip();
            passwordToolTip.Active = true;
            passwordToolTip.AutoPopDelay = 5000;
            passwordToolTip.InitialDelay = 500;
            passwordToolTip.ReshowDelay = 500;
            passwordToolTip.ShowAlways = true;
            passwordToolTip.IsBalloon = true;
            passwordToolTip.ShowAlways = true;
            passwordToolTip.UseAnimation = true;
            passwordToolTip.UseFading = true;
            passwordToolTip.ToolTipIcon = ToolTipIcon.Info;
            passwordToolTip.ToolTipTitle = "Requisitos Password:";
            passwordToolTip.SetToolTip(this.textBox_password, "A password deve ter no mínimo 8 caracteres, incluindo pelo menos 1 letra maiúscula, 1 letra minúscula e 1 carácter especial. ");
          
        }

    }
}
