using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class TipoTelefone
    {
        protected int idTipoTelefone { get; set; }

        new public int IdTipoTelefone
        {
            get
            {
                return idTipoTelefone;
            }
            set
            {
                idTipoTelefone = value;
            }
        }
        public string Tipo { get; set; }
    }
}