<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.Paginas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
    <link type="text/css"rel="stylesheet" href="Content/bootstrap.css" />
</head>
    
<body>
    <form id="formPesquisar" runat="server">
        <div class="jumbotron">
            <h1>Controle de Pessoas</h1>

            Selecione a operação Desejada:
            <asp:DropDownList ID="ddlMenuOpcao" runat="server">
                <asp:ListItem Value="0" Text="- Escolha uma opção -"/>
                <asp:ListItem Value="1" Text="- Cadastrar Pessoa -"/>
                <asp:ListItem Value="2" Text="- Consultar Pessoa -"/>
                <asp:ListItem Value="3" Text="- Obter Dados da Pessoa -"/>

            </asp:DropDownList>
            <asp:Button ID="btnMenuOpcao" runat="server" Text="Acessar" CssClass="btn btn-primary btn-lg" OnClick="btnAcessarPessoa"/>

            <p>
                <asp:Label ID="lblMensagemPesquisar" runat="server"/>
            </p>
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
