using Cliente.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            // Criação da base de dados caso não exista 
            var chatContext = new ChatContext();
            chatContext.Database.CreateIfNotExists();
            chatContext.SaveChanges();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Login());
            Database.SetInitializer<ChatContext>(new CreateDatabaseIfNotExists<ChatContext>());
        }

    }
}
