using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    
    internal class Utilizador
    {
        //Especificar o id como chave primária
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Necessita de introduzir o nome!")]
        [RegularExpression(@"^[a-zA-ZãáàâéêíóõôúüçÇ ]+$", ErrorMessage = "O nome apenas pode conter letras.")] //Apenas letras permitidas e espaços, incluindo acentos
        public string Nome { get; set; }

        [Required(ErrorMessage ="Necessita de introduzir o username!")]
        public  string Username { get; set; }


        [Required(ErrorMessage = "Necessita de introduzir a password!")]
        public string Password { get; set; }
        public string Salt { get; set; }

        public string ChavePublica { get; set; }

        public bool Online { get; set; }

        public virtual ICollection<Mensagem> Mensagens { get; set; } //Relação 1 para muitos com a tabela Mensagem

        public Utilizador()
        {
            Online = false;
        }
    }
}
