using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using System.Data.Common;


namespace Cliente
{
    
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class ChatContext : DbContext
    {


        public DbSet <Utilizador> Utilizadores { get; set; } // Tabela Utilizadores
        public DbSet<Mensagem> Mensagens { get; set; } // Tabela Mensagens

        public ChatContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Utilizador>()
                .ToTable("Utilizadores")
                .MapToStoredProcedures()
                .HasMany(u => u.Mensagens)
                .WithRequired(e=> e.Utilizador)
                .HasForeignKey(e=> e.UtilizadorId)
                .WillCascadeOnDelete(); // Cria a tabela Utilizadores e especifica o nome da tabela
            modelBuilder.Entity<Mensagem>()
                .ToTable("Mensagens").MapToStoredProcedures(); // Cria a tabela Mensagens e especifica o nome da tabel
        }



    }
}
