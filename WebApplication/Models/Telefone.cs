using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Telefone
    {
        protected int idTelefone;

        new public int IdTelefone
        {
            get
            {
                return idTelefone;
            }
            set
            {
                idTelefone = value;
            }
        }
        public int Numero { get; set; }
        public int DDD { get; set; }
        public TipoTelefone TipoTelefone { get; set; }

        public  string Tipo { get; set;  }
    }
}