<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaPessoa.aspx.cs" Inherits="WebApplication.AgendaIngo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
<link type="text/css"rel="stylesheet" href="Content/bootstrap.cs" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 467px;
        }
        .auto-style3 {
            width: 619px;
        }
        .auto-style4 {
            width: 474px;
        }
    </style>
    </head>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label>Nome:</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <label>CPF:</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
        </div>

        <div>
          <h1>Telefones</h1>
           <div>
               <div>
                   <label>DDD:</label>
                   <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                   
                   <label>Número:</label>
                   <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                   
                   <label>Tipo:</label>
                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                   <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" CssClass="btn btn-primary"/>

               </div>

               <div>
                   <table class="auto-style1">
                       <tr>
                           <td class="auto-style2">DDD</td>
                           <td class="auto-style3">Número</td>
                           <td class="auto-style4">Tipo</td>
                           <td>Excluir</td>
                       </tr>
                       <tr>
                           <td class="auto-style2">&nbsp;</td>
                           <td class="auto-style3">&nbsp;</td>
                           <td class="auto-style4">&nbsp;</td>
                           <td>&nbsp;</td>
                       </tr>
                       <tr>
                           <td class="auto-style2">&nbsp;</td>
                           <td class="auto-style3">&nbsp;</td>
                           <td class="auto-style4">&nbsp;</td>
                           <td>&nbsp;</td>
                       </tr>
                       <tr>
                           <td class="auto-style2">&nbsp;</td>
                           <td class="auto-style3">&nbsp;</td>
                           <td class="auto-style4">&nbsp;</td>
                           <td>&nbsp;</td>
                       </tr>
                       <tr>
                           <td class="auto-style2">&nbsp;</td>
                           <td class="auto-style3">&nbsp;</td>
                           <td class="auto-style4">&nbsp;</td>
                           <td>&nbsp;</td>
                       </tr>
                   </table>
               </div>
           </div>
       </div>

        <div>
           <h1>Endereço</h1>
           <div>

               <label>Logradouro:</label> 
               <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
               <label>Número:</label> 
               <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
               <label>CEP:</label> 
               <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

               <label>
               <br />
               Bairro:</label> 
               <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
               <label>Cidade:</label> 
               <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
               <label>Estado:</label> 
               <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
           </div>
       </div>
        
        <div>
            <asp:Button ID="Button2" runat="server" Text="Voltar" />
            <asp:Button ID="Button3" runat="server" Text="Cadastrar" OnClick="BtnCadastrar" />
        </div>
    </form>
</body>
</html>
