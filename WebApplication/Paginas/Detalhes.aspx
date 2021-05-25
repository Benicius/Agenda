<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="WebApplication.Paginas.Detalhes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Detalhes</title>
    <link type="text/css"rel="stylesheet" href="Content/bootstrap.css" />
    <style>
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" >
            <div class="span10 col-lg-offset-1">
                <div class="row">
                    <h3 class="well">Detalhes da Pessoa</h3>
                </div>
                
                <div class="row">
                    <div>
                        <asp:TextBox ID="txtCPF" runat="server" placeholder="Número do CPF" CssClass="form-control"/>
                        <asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar"/>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Label ID="lblNome" runat="server">Nome:</asp:Label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-lg-6">
                        <asp:Label ID="lblCPF" runat="server">CPF:</asp:Label>
                        <asp:TextBox ID="txtCPF2" runat="server" CssClass="form-control"/>
                    </div>
                </div>
                <br />
                <br />

                <asp:Label runat="server" Font-Bold="true">Telefones</asp:Label>
                
                <asp:Table id="Table" runat="server"
                    class="table"
                    CellPadding="10" 
                    GridLines="Both"
                    HorizontalAlign="Center">
                    <asp:TableHeaderRow id="Table1HeaderRow" 
                        BackColor="#337ab7"
                        runat="server"
                        HorizontalAlign="Center">
                        <asp:TableHeaderCell 
                            Scope="Column" 
                            Text="DDD" />
                        <asp:TableHeaderCell  
                            Scope="Column" 
                            Text="Número" />
                        <asp:TableHeaderCell 
                            Scope="Column" 
                            Text="Tipo" />
                    </asp:TableHeaderRow>  

                    <asp:TableRow
                        HorizontalAlign="Center">
                        <asp:TableCell>
                            11
                        </asp:TableCell>
                        <asp:TableCell>
                            95566-4455
                        </asp:TableCell>
                        <asp:TableCell>
                            Celular
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow
                        HorizontalAlign="Center">
                        <asp:TableCell>
                            11
                        </asp:TableCell>
                        <asp:TableCell>
                            4789-5566
                        </asp:TableCell>
                        <asp:TableCell>
                            Comercial
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                
                <asp:Panel runat="server" BorderStyle="Solid" BorderWidth="1px" >
                    <div class="container">
                        <br />
                            <asp:Label runat="server" Font-Bold="true">Endereço</asp:Label>
                        <div class="container">
                            <br />
                            <div class="row">
                                <div class="col-lg-4">
                                    <asp:Label ID="lblLogradouro" runat="server">Logradouro:</asp:Label>
                                    <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control"/>
                                </div>
                                <div class="col-lg-3">
                                    <asp:Label ID="lblNumero" runat="server">Número:</asp:Label>
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"/>
                                </div>
                                <div class="col-lg-3">
                                    <asp:Label ID="lblCEP" runat="server">CEP:</asp:Label>
                                    <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control"/>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lblBairro" runat="server">Bairro:</asp:Label>
                                    <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control"/>
                                </div>
                                <div class="col-lg-2">
                                    <asp:Label ID="lblCidade" runat="server">Cidade:</asp:Label>
                                    <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control"/>
                                </div>
                                <div class="col-lg-2">
                                    <asp:Label ID="lblEstado" runat="server">Estado:</asp:Label>
                                    <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control"/>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </asp:Panel>

                <p><asp:Label ID="lblMensagemAtualizar" runat="server" /> </p>

                <br />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn btn-danger" />
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" CssClass="btn btn-primary" />
                <a href="Index.aspx" class="btn btn-primary">Voltar</a>
            </div>
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
