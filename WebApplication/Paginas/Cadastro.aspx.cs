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
                p.Nome = "Will Cirino";
                p.CPF = 222;

                p.Endereco = new Endereco();

                p.Endereco.Logradouro = "Rua dos Boy";
                p.Endereco.Numero = 192;
                p.Endereco.CEP = 08738120;
                p.Endereco.Bairro = "Boy";
                p.Endereco.Cidade = "Osasco";
                p.Endereco.Estado = "SP";

                Telefone tel = new Telefone();
                tel.DDD = 011;
                tel.Numero = 999995555;
                tel.TipoTelefone = new TipoTelefone();
                tel.TipoTelefone.IdTipoTelefone = 2;

                Telefone tel1 = new Telefone();
                tel1.DDD = 011;
                tel1.Numero = 44447777;
                tel1.TipoTelefone = new TipoTelefone();
                tel1.TipoTelefone.IdTipoTelefone = 1;

                p.Telefones = new List<Telefone>();

                p.Telefones.Add(tel);
                p.Telefones.Add(tel1);

                PessoaDAO d = new PessoaDAO();
                d.Salvar(p);

                lblMensagemCadastro.Text = "Pessoa salva com sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagemCadastro.Text = ex.Message;
            }
        }

    }
}