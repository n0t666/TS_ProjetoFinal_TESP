using MySql.Data.MySqlClient;
using SaaUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Forms
{

    public partial class Form_Conta : Form
    {
        private Utilizador utilizadorAtual;
        private int user;
        public event EventHandler<bool> Logout_Invoked;
        public Form_Conta(int id)
        {
            InitializeComponent();
            user = id;
            obterUtilizador(id);
        }


        private void button_update_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_nome.Text))
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
                if (RegisterHelper.VerificarUsername(textBox_username.Text, utilizadorAtual.Username))
                {
                    MessageBox.Show("Username já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (RegisterHelper.UpdateUtilizador(utilizadorAtual.id, textBox_nome.Text, textBox_username.Text, textBox_password.Text))
                {
                    MessageBox.Show("Utilizador atualizado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obterUtilizador(user);
                    updateUtilizador();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar utilizador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void obterUtilizador(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();
                utilizadorAtual = db.Utilizadores.Include(u => u.Mensagens).FirstOrDefault(u => u.id == id);
            }
        }

        private void Form_Conta_Load(object sender, EventArgs e)
        {
            updateUtilizador();
        }

        private void updateUtilizador()
        {
            textBox_nome.Text = utilizadorAtual.Nome;
            textBox_username.Text = utilizadorAtual.Username;
            textBox_password.Text = "";
            textBox_passwordConfirm.Text = "";
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            Logout_Invoked?.Invoke(this, true);
        }
    }
}
