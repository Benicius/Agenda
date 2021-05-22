using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Telefone
    {
        protected int IdTelefone { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}