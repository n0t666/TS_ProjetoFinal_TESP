using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    internal class Utils
    {
      
        // Método que assina a mensagem com a chave privada do utilizador 
        public static string SignData(string mensagem, string privateKey)
        {
            byte[] mensagemBytes = Encoding.UTF8.GetBytes(mensagem);

            try
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash = sha1.ComputeHash(mensagemBytes);
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.FromXmlString(privateKey); // Importa a chave privada do utilizador

                    byte[] signature = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA1")); 

                    return Convert.ToBase64String(signature);
                }
            }catch(CryptographicException)
            {
                MessageBox.Show("Não foi possível assinar a mensagem");
                return null;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + e.Message);
                return null;
            }

        }


        // No receptor, verifica se a assinatura é válida com a chave pública do emissor
        public static bool VerifyData(string mensagem, string signature, string publicKey)
        {
            if(mensagem!=null && signature !=null & publicKey != null && mensagem.Length > 0 && signature.Length > 0 && publicKey.Length > 0) { 
            try
            {
                byte[] mensagemBytes = Encoding.UTF8.GetBytes(mensagem);
            byte[] signatureBytes = Convert.FromBase64String(signature);
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash = sha1.ComputeHash(mensagemBytes);
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.FromXmlString(publicKey); // Importa a chave pública do emissor

                    return rsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signatureBytes);
                }
            }catch(CryptographicException)
            {
                MessageBox.Show("Não foi possível verificar a assinatura");
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + e.Message);
                return false;
            }
            }else
            {
                return false;
            }
        }


        // Encripta a mensagem com a chave pública do destinatário
        public static string EncryptData(string mensagem, string publicKey)
        {
            RSA rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            byte[] encryptedData = null;
            try
            {
                encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(mensagem), RSAEncryptionPadding.Pkcs1);
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Não foi possível encriptar a mensagem");
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + e.Message);
                return null;
            }


            return Convert.ToBase64String(encryptedData);
        }

        // Desencripta a mensagem com a chave privada do destinatário
        public static string DecryptData(string mensagemEncriptada, string privateKey)
        {
            RSA rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = null;
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(mensagemEncriptada);
                decryptedData = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);

            }
            catch(CryptographicException) // Se a chave privada não for a correta
            {
                MessageBox.Show("Não foi possível desencriptar a mensagem");
                return null;
            }
            catch(Exception e) // Outros erros
            {
                MessageBox.Show("Ocooreu um erro inesperado: " + e.Message);
                return null;
            }
           


            return Encoding.UTF8.GetString(decryptedData); // Retorna a mensagem desencriptada,ou seja, em plain text
           
        }

        // Método que devolve a chave pública do destinatário
        public static string GetDestinatarioPublicKey(int origemId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString))
            {
                ChatContext db = new ChatContext(connection, false);
                connection.Open();

                var utilizador = db.Utilizadores.FirstOrDefault(u => u.id != origemId && u.Online == true); // Procura o utilizador que não seja o emissor e que esteja online
                return utilizador.ChavePublica;
            }
        }

      


    }
}
