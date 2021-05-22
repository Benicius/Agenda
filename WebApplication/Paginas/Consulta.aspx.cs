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
    public partial class Consulta : System.Web.UI.Page
    {
        protected void gridPessoaList(object sender, EventArgs e)
        {
            try
            {
                PessoaDAO d = new PessoaDAO();
                gridPessoa.DataSource = d.ListarPessoa();
                gridPessoa.DataBind();
            }
            catch (Exception ex)
            {
                lblMensagemConsulta.Text = ex.Message;
            }
        }
    }
}