<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebApplication.Paginas.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro</title>
    <link type="text/css"rel="stylesheet" href="Content/bootstrap.css" />
</head>
<body>
    <form id="formCadastro" runat="server">
        <div class="container">
            <div class="span10 offset1">
                <div class="row">
                    <h3 class="well">Cadastro da Pessoa</h3>
                    <br />
                </div>

                <div class="row">
                    <div class="col-lg-6">
                        Nome:<br />
                        <asp:TextBox ID="txtNome" runat="server" placeholder="Nome Completo" CssClass="form-control"/>
                        <asp:RequiredFieldValidator 
                            ID="requierdNome" 
                            runat="server" 
                            ControlToValidate="txtNome"
                            ErrorMessage="O Nome é Necessário!"
                            ForeColor="Red"
                            />
                    </div>
                    <div class="col-lg-6">
                        CPF:<br />
                        <asp:TextBox ID="txtCPF" runat="server" placeholder="Nome Completo" CssClass="form-control" TextMode="Number"/>
                        <asp:RequiredFieldValidator 
                            ID="requierdCPF" 
                            runat="server" 
                            ControlToValidate="txtCPF"
                            ErrorMessage="O CPF é Necessário!"
                            ForeColor="Red"
                            />
                    </div>
                </div>
                <div class="row">
                    <br />
                    <asp:Panel runat="server" BorderStyle="Solid" BorderWidth="1px" >
                        <div class="row">
                            <br />
                            <div class="col-lg-3">
                                <asp:Label runat="server">DDD:</asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-lg-4">
                                <asp:Label runat="server">Número:</asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"/>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server">Tipo:</asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"/>
                            </div>
                            <div class="col-lg-2">
                                <br />
                            </div>
                        </div>
                        <br />
                    </asp:Panel>

                    <br />

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

                    <br />
                    <asp:Panel runat="server" BorderStyle="Solid" BorderWidth="1px" >
                        <div class="container">
                            <br />
                                <asp:Label runat="server" Font-Bold="true">Endereço</asp:Label>
                            <div class="container">
                                <br />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblLogradouro" runat="server">Logradouro:</asp:Label>
                                        <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:Label ID="lblNumero" runat="server">Número:</asp:Label>
                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="lblCEP" runat="server">CEP:</asp:Label>
                                        <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblBairro" runat="server">Bairro:</asp:Label>
                                        <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="col-lg-3">
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
                    <p><asp:Label ID="lblMensagemCadastro" runat="server"/></p>
                    <a href="Index.aspx" class="btn btn-primary">Voltar</a>
                    <asp:Button ID="btnCadastro" runat="server" Text="Cadastrar" CssClass="btn btn-primary" OnClick="btnCadastrar"/>
                    <div />
                </div>
            </div>
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
