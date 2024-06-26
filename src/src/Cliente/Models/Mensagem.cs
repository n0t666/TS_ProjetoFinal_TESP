﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class Mensagem
    {
        //Especificar o id como chave primária
        [Key]
        public int id { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public string Assinatura { get; set; }

        [Required]
        public DateTime DataEnvio{ get; set; }

        public int UtilizadorId { get; set; }

        public int RecetorId { get; set; }

        //Relação muitos para 1 com a tabela Utilizador
        [ForeignKey("UtilizadorId")]
        public virtual Utilizador Utilizador { get; set; }

        //Relação muitos para 1 com a tabela Utilizador
        [ForeignKey("RecetorId")]
        public virtual Utilizador Recetor { get; set; }

        
    }
}
