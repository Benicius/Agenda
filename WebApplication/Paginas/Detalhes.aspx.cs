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

                if(p != null)
                {
                    txtNome.Text = p.Nome;
                    txtCPF2.Text = p.CPF.ToString();
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
    }
}