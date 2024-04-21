using Cliente.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            { 
            // Verificar se a base de dados existe, se não existir, cria-a
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                using (ChatContext chatContext = new ChatContext(connection, false))
                {
                    chatContext.Database.CreateIfNotExists();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar à base de dados" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0); // Fecha a aplicação
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Login()); // Form que será o primeiro a inicializar
            }

    }
}
