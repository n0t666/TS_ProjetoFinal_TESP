using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Forms
{
    public partial class Form_Register : Form
    {

        private const int NUM_INTERACOES = 1000;
        private const int TAMANHO_SALT = 32;
        private RSACryptoServiceProvider rsa;

        public Form_Register()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_password.Text) || string.IsNullOrEmpty(textBox_nome.Text)) // Verificar se os campos estão todos devidamente preenchidos
            {
                MessageBox.Show("Por favor, preencha todos os campos necessários", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(RegisterHelper.verificarUsername(textBox_username.Text))
                {
                    MessageBox.Show("Username já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!RegisterHelper.validarPassword(textBox_password.Text))
                {
                    MessageBox.Show("Password deve possuir no mínimo 12 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                try { 
                using (var db = new ChatContext())
                {
                    var utilizador = new Utilizador { Username = username, Password = passwordHash, Salt = Convert.ToBase64String(salt), Nome = nome, ChavePublica = chavePublica };

                    db.Utilizadores.Add(utilizador);
                    db.SaveChanges();
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
            frm.Location = this.Location;
            frm.Show();
            this.Hide();
        }
    }
}
