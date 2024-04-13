using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    internal class Utilizador
    {
        public  string Username { get; set; }
        public string Password { get; set; }

        public Utilizador(string username,string passowrd)
        {
            Username = username;
            Password = passowrd;
        }

    }
}
