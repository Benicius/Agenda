using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }

        public string Nome { get; set; }

        public long CPF { get; set; }

        public List<Telefone> Telefones { get; set; }

        public Endereco Endereco { get; set; }
    }
}