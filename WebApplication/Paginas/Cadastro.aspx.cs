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
                p.Nome = txtNome.Text;
                p.CPF = long.Parse(txtCPF.Text);

                p.Endereco = new Endereco();

                p.Endereco.Logradouro = txtLogradouro.Text;
                p.Endereco.Numero = int.Parse(txtNumero.Text);
                p.Endereco.CEP = int.Parse(txtCEP.Text);
                p.Endereco.Bairro = txtBairro.Text;
                p.Endereco.Cidade = txtCidade.Text;
                p.Endereco.Estado = txtEstado.Text;

                PessoaDAO d = new PessoaDAO();
                d.Salvar(p);
                lblMensagemCadastro.Text = "Pessoa " + p.Nome + " cadastrado com sucesso!";

                txtNome.Text = string.Empty;
                txtCPF.Text = string.Empty;
                txtLogradouro.Text = string.Empty;
                txtNumero.Text = string.Empty;
                txtCEP.Text = string.Empty;
                txtBairro.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensagemCadastro.Text = ex.Message;
            }
        }
    }
}