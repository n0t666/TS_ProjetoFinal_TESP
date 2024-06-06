using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    internal class RegisterHelper
    {

        // Função que gera um salt aleatório
        public static byte[] GerarSalt(int tamanho)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[tamanho];
            rng.GetBytes(buffer);
            return buffer;
        }

        // Função que faz o hash da password
        public static byte[] GerarBytesHash(string password, byte[] salt,int numInteracoes)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, numInteracoes);
            return rfc.GetBytes(32);
        }


        // Função que verifica se o username inserido já existe na base de dados
        public static bool VerificarUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                var utilizador = db.Utilizadores.Where(u => u.Username == username).FirstOrDefault(); // Procura o utilizador na base de dados com o username inserido 
                if (utilizador != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Função que verifica se a password inserida é válida,ou seja, se tem pelo menos 8 caracteres, incluindo pelo menos 1 letra maiúscula, 1 letra minúscula e 1 carácter especial
        public static bool ValidarPassword(string password)
        {
            // Expressões regulares que fazem a validação da password
            var temNumero = new Regex("[0-9]+"); // Possui pelo menos um número
            var temMaiuscula = new Regex("[A-Z]+"); // Possui pelo menos uma letra maiúscula
            var temMinuscula = new Regex("[a-z]+"); // Possui pelo menos uma letra minúscula
            var temMinimoCaracteres = new Regex(".{8,}"); // Mínimo de 8 caracteres
            var temCaracterEspecial = new Regex("[!@#$%^&*()_+=\\[\\]{};:<>|./?,-]"); // Qualquer carácter especial
            // -------------------------

            // Comparar a password inserida com os padrões definidos
            if (temNumero.IsMatch(password) && temMaiuscula.IsMatch(password) && temMinuscula.IsMatch(password) && temMinimoCaracteres.IsMatch(password) && temCaracterEspecial.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Função que verifica se existe mais do que um utilizador online,no máximo 2 utilizadores online
        public static bool VerificarNumeroUtilizadoresOnline(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                var utilizadores = db.Utilizadores.Where(u => u.Online == true).ToList(); // Procura o utilizador na base de dados com o username inserido 
                MessageBox.Show(utilizadores.Count.ToString());
                if (utilizadores.Count > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void AlterarEstado(int id, bool estado)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                var utilizador = db.Utilizadores.Where(u => u.id == id).SingleOrDefault();
                if (utilizador != null)
                {
                    utilizador.Online = estado;
                    db.SaveChanges();

                }
            }
        }







    }
}
