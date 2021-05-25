<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="WebApplication.Paginas.Consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta</title>
    <link type="text/css"rel="stylesheet" href="Content/bootstrap.css" />
</head>
<body>
    <form id="formConsulta" runat="server">
        <div class="container">
            <div class="spain10 col-lg-offset-1">
                <div class="row">
                    <h3 class="well">Consulta de Pessoas</h3>

                    <asp:GridView 
                        ID="gridPessoa" 
                        runat="server"
                        CssClass="table table-hover table-striped" 
                        GridLines="None" 
                        AutoGenerateColumns="false"
                        BackColor="#ccccff">

                        <Columns>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" />
                            <asp:BoundField DataField="CPF" HeaderText="CPF" />
                            <asp:BoundField DataField="Endereco.Logradouro" HeaderText="Logradouro" />
                            <asp:BoundField DataField="Telefone.Numero" HeaderText="Numero" />
                        </Columns>
                        <RowStyle CssClass="cursor-pointer" />

                    </asp:GridView>

                    <p><asp:Label ID="lblMensagemConsulta" runat="server"/></p>

                    <a href="Index.aspx" class="btn btn-primary">Voltar</a>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
