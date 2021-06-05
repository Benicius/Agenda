using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;
using WebApplication.Persistence;
using WebApplication.Models.PessoaDAO;


namespace WebApplication.Paginas
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void btnPesquisarCPF(object sender, EventArgs e)
        {
            try
            {
                long CPF = Convert.ToInt64(txtCPF.Text);

                PessoaDAO d = new PessoaDAO();
                Pessoa p = d.PesquisarCpf(CPF);

                if (p != null)
                {


                    gridTelefone.DataSource = p.Telefones;
                    gridTelefone.DataBind();

                    txtIdPessoa.Text = p.IdPessoa.ToString();
                    txtNome.Text = p.Nome;
                    txtCPF2.Text = p.CPF.ToString();

                    txtIdEndereco.Text = p.Endereco.IdEndereco.ToString();
                    txtLogradouro.Text = p.Endereco.Logradouro;
                    txtNumero.Text = p.Endereco.Numero.ToString();
                    txtCEP.Text = p.Endereco.CEP.ToString();
                    txtBairro.Text = p.Endereco.Bairro;
                    txtCidade.Text = p.Endereco.Cidade;
                    txtEstado.Text = p.Endereco.Estado;
                }
            }
            catch (Exception ex)
            {
                lblMensagemAtualizar.Text = ex.Message;
            }
        }

        protected void btnExcluir(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtIdPessoa.Text);

                PessoaDAO d = new PessoaDAO();
                Pessoa p = d.PesquisarId(Id);

                d.Excluir(p);

                lblMensagemAtualizar.Text = "Pessoa excluída com sucesso!";

                txtIdPessoa.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtCPF2.Text = string.Empty;

                txtIdEndereco.Text = string.Empty;
                txtLogradouro.Text = string.Empty;
                txtNumero.Text = string.Empty;
                txtCEP.Text = string.Empty;
                txtBairro.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensagemAtualizar.Text = ex.Message;
            }
        }

        protected void btnAtualizar(object sender, EventArgs e)
        {
            try
            {
                Pessoa p = new Pessoa();
                p.IdPessoa = Convert.ToInt32(txtIdPessoa.Text);
                p.Nome = Convert.ToString(txtNome.Text);
                p.CPF = Convert.ToInt64(txtCPF2.Text);

                p.Endereco = new Endereco();
                p.Endereco.IdEndereco = Convert.ToInt32(txtIdEndereco.Text);
                p.Endereco.Logradouro = Convert.ToString(txtLogradouro.Text);
                p.Endereco.Numero = Convert.ToInt32(txtNumero.Text);
                p.Endereco.CEP = Convert.ToInt32(txtCEP.Text);
                p.Endereco.Bairro = Convert.ToString(txtBairro.Text);
                p.Endereco.Cidade = Convert.ToString(txtCidade.Text);
                p.Endereco.Estado = Convert.ToString(txtEstado.Text);

                PessoaDAO d = new PessoaDAO();
                d.Atualizar(p);

                lblMensagemAtualizar.Text = "Pessoa Atualizada com Sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagemAtualizar.Text = ex.Message;
            }
        }
    }
}