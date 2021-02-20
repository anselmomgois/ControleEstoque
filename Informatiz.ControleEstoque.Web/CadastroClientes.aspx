<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroClientes.aspx.cs" Inherits="Informatiz.ControleEstoque.Web.CadastroClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/JS.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="DivError" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td width="100px">
                    <asp:Image ID="imgError" runat="server" ImageUrl="~/Image/symbol_error.png" />
                </td>
                <td width="100%">
                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <fieldset>
        <legend>Dados do Cliente </legend>
        <table width="100%">
            <tr>
                <td width="25%">
                    <asp:Label ID="lblEmpresa" runat="server" Text="Nome da Empresa"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtEmpresa" runat="server" Width="400px" CssClass="textbox" TabIndex="1"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtNome" runat="server" Width="400px" CssClass="textbox" TabIndex="2"
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblCep" runat="server" Text="CEP:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtCep" runat="server" Width="100px" CssClass="textbox" TabIndex="3"
                        MaxLength="8" AutoPostBack="True" OnTextChanged="txtCep_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="405px" CssClass="textbox"
                        AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" TabIndex="4">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:DropDownList ID="ddlciade" runat="server" Width="405px" CssClass="textbox" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlciade_SelectedIndexChanged" TabIndex="5">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblRua" runat="server" Text="Logradouro:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtRua" runat="server" Width="400px" CssClass="textbox" TabIndex="6"
                        MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblNumero" runat="server" Text="Número:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtNumero" runat="server" Width="100px" CssClass="textbox" TabIndex="7"
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtBairro" runat="server" Width="200px" CssClass="textbox" TabIndex="8"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblTelefoneFixo" runat="server" Text="Telefone Fixo:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtTelefoneFixo" runat="server" Width="100px" CssClass="textbox"
                        TabIndex="9" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblTelefoneCelular" runat="server" Text="Telefone Celular:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtTelefoneCelular" runat="server" Width="100px" CssClass="textbox"
                        TabIndex="10" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtEmail" runat="server" Width="400px" CssClass="textbox" TabIndex="11"
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblPublicidade" runat="server" Text="Onde nos conheceu?"></asp:Label>
                </td>
                <td width="75%">
                    <asp:DropDownList ID="ddlPublicidade" runat="server" Width="405px" CssClass="textbox"
                        AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlPublicidade_SelectedIndexChanged" TabIndex="12">
                    </asp:DropDownList>
                </td>
            </tr>
            <div id="DivAmigo" runat="server" visible="false">
                <tr>
                    <td width="25%">
                        <asp:Label ID="lblAmigo" runat="server" Text="Nome de quem te indicou:"></asp:Label>
                    </td>
                    <td width="75%">
                        <asp:TextBox ID="txtAmigo" runat="server" Width="400px" CssClass="textbox" TabIndex="13"
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
            </div>
            <div id="DivConsultores" runat="server" visible="false">
                <tr>
                    <td width="25%">
                        <asp:Label ID="lblConsultor" runat="server" Text="Nome do Consultor que te indicou:"></asp:Label>
                    </td>
                    <td width="75%">
                        <asp:DropDownList ID="ddlConsultor" runat="server" Width="405px" 
                            CssClass="textbox" TabIndex="14">
                        </asp:DropDownList>
                    </td>
                </tr>
            </div>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="400px" CssClass="textbox" TabIndex="15"
                        MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtSenha" runat="server" Width="400px" CssClass="textbox" TextMode="Password"
                        TabIndex="16" MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                    <asp:Label ID="lblConfirmarSenha" runat="server" Text="Confirmar Senha"></asp:Label>
                </td>
                <td width="75%">
                    <asp:TextBox ID="txtConfirmarSenha" runat="server" Width="400px" CssClass="textbox"
                        TextMode="Password" TabIndex="17" MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%">
                </td>
                <td width="75%" align="right" height="300px" valign="bottom">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Proseguir" CssClass="textbox"
                        OnClick="btnCadastrar_Click" TabIndex="18" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
