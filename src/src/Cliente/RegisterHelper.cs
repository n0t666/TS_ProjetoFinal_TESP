using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
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
        private const int NUM_INTERACOES = 1000;
        private const int TAMANHO_SALT = 32;

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
        public static bool VerificarUsername(string username, string usernameExistente = null)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                Utilizador utilizador = null;
                ChatContext db = new ChatContext(connection, false);
                if(!string.IsNullOrEmpty(usernameExistente))
                {
                     utilizador = db.Utilizadores.Where(u => u.Username == username && u.Username != usernameExistente).FirstOrDefault(); // Procura o utilizador na base de dados com o username inserido 
                }
                else
                {
                    utilizador = db.Utilizadores.Where(u => u.Username == username).FirstOrDefault();
                }
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

        public static int NumeroUtilizadoresOnline()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                var utilizadores = db.Utilizadores.Where(u => u.Online == true).ToList(); // Procura o utilizador na base de dados com o username inserido 
                return utilizadores.Count;
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

        public static Utilizador GetOnlineReceiver(int idSender)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                var utilizador = db.Utilizadores.Where(u => u.id != idSender && u.Online == true).SingleOrDefault();
                return utilizador;
            }
        }

        public static bool UpdateUtilizador(int id, string nome, string username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
                {
                    ChatContext db = new ChatContext(connection, false);
                    var utilizadorBD = db.Utilizadores.Where(u => u.id == id).SingleOrDefault();
                    if (utilizadorBD != null)
                    {
                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            if (!ValidarPassword(password))
                            {
                                MessageBox.Show("A password não cumpre com os requisitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            byte[] salt = Convert.FromBase64String(utilizadorBD.Salt);
                            byte[] hash = RegisterHelper.GerarBytesHash(password, salt, 1000);
                            string passwordHash = Convert.ToBase64String(hash);

                            if (passwordHash == utilizadorBD.Password)
                            {
                                MessageBox.Show("Palavra-passe já utilizada anteriormente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            else
                            {
                                utilizadorBD.Password = passwordHash;
                            }
                        }

                        utilizadorBD.Nome = nome;
                        utilizadorBD.Username = username;

                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Utilizador não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Erro: " + validationError.ErrorMessage);
                    }
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao atualizar utilizador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


    }
}
