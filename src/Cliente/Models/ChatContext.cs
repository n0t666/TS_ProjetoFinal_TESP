using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cliente
{
    internal class ChatContext : DbContext
    {
        public ChatContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ChatContext>(null);
        }



        public DbSet <Utilizador> Utilizadores { get; set; } // Tabela Utilizadores


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            Database.SetInitializer<ChatContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Utilizador>().ToTable("Utilizadores"); // Nome da tabela na base de dados para Utilizadores
           
        }
    }
}
