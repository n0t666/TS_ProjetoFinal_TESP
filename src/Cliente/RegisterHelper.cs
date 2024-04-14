using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    internal class RegisterHelper
    {
        public static byte[] GerarSalt(int tamanho)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[tamanho];
            rng.GetBytes(buffer);
            return buffer;
        }

        public static byte[] GerarBytesHash(string password, byte[] salt,int numInteracoes)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, numInteracoes);
            return rfc.GetBytes(32);
        }

        public static bool verificarUsername(string username)
        {
            using (var db = new ChatContext())
            {
                var utilizador = db.Utilizadores.Where(u => u.Username == username).FirstOrDefault();
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

        public static bool validarPassword(string password)
        {
            if (password.Length < 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        

        


    }
}
