using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Paginas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnAcessarPessoa(object sender, EventArgs e)
        {
            string opcao = ddlMenuOpcao.SelectedValue;
            switch (opcao)
            {
                case "0":
                    lblMensagemPesquisar.Text = "Por favor, selecione uma opção válida";
                    break;
                case "1":
                    Response.Redirect("/Paginas/Cadastro.aspx");
                    break;
                case "2":
                    Response.Redirect("/Paginas/Consulta.aspx");
                    break;
                case "3":
                    Response.Redirect("/Paginas/Detalhes.aspx");
                    break;
            }
        }
    }
}