using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Endereco
    {
        protected int idEndereco;

        new public int IdEndereco
        {
            get
            {
                return idEndereco;
            }
            set
            {
                idEndereco = value;
            }
        }

        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}