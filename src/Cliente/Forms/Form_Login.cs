using Cliente.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void button_login_Click(object sender, EventArgs e)
        {
            //Caso as credenciais inseridas sejam null ou vazias
            if(string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos necessários","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else{
                using (var db = new ChatContext())
                {
                    //Procura o utilizador na base de dados
                    var utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == textBox_username.Text);
                    if(utilizador == null)
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

                        if(passwordHash == utilizador.Password)
                        {
                            var frm = new Form2();
                            frm.Location = this.Location;
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Password incorreta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                }
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void label_registar_Click(object sender, EventArgs e)
        {
            var frm = new Form_Register();
            frm.Location = this.Location;
            frm.Show();
            this.Hide();

        }
    }
}
