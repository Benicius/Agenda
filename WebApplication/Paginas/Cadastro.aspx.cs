using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;
using WebApplication.Models.PessoaDAO;
using WebApplication.Persistence;

namespace WebApplication.Paginas
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void btnCadastrar(object sender, EventArgs e)
        {
            try
            {
                Pessoa p = new Pessoa();
                p.Nome = "Benicius";
                p.CPF = 0123456789;

                p.Endereco = new Endereco();

                p.Endereco.Logradouro = "Aristides";
                p.Endereco.Numero = 192;
                p.Endereco.CEP = 08738120;
                p.Endereco.Bairro = "chato";
                p.Endereco.Cidade = "Mogi";
                p.Endereco.Estado = "SP";

                Telefone tel = new Telefone();
                tel.DDD = 011;
                tel.Numero = 47798521;
                tel.TipoTelefone = new TipoTelefone();
                tel.TipoTelefone.Tipo = "Celular";

                Telefone tel1 = new Telefone();
                tel1.DDD = 011;
                tel1.Numero = 47798521;
                tel1.TipoTelefone = new TipoTelefone();
                tel1.TipoTelefone.Tipo = "Comercial";

                p.Telefones = new List<Telefone>();

                p.Telefones.Add(tel);
                p.Telefones.Add(tel1);

                PessoaDAO d = new PessoaDAO();
                d.Salvar(p);
            }
            catch (Exception ex)
            {
                lblMensagemCadastro.Text = ex.Message;
            }
        }

    }
}