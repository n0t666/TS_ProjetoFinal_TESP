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
            }
        }
    }
}
