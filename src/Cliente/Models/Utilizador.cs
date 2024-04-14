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
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "O nome apenas pode conter letras.")] //Apenas letras permitidas e espaços
        public string Nome { get; set; }

        [Required(ErrorMessage ="Necessita de introduzir o username!")]
        public  string Username { get; set; }


        [Required(ErrorMessage = "Necessita de introduzir a password!")]
        public string Password { get; set; }
        public string Salt { get; set; }

        public string ChavePublica { get; set; }
    }
}
