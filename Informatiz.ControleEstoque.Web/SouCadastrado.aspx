<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SouCadastrado.aspx.cs" Inherits="Informatiz.ControleEstoque.Web.SouCadastrado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        <legend>Já Sou Cadastrado</legend>
        <table width="100%">
            <tr>
                <td width="15%">
                    <asp:Label ID="Label1" runat="server" Text="Usuário"></asp:Label>
                </td>
                <td width="85%">
                    <asp:TextBox ID="txtUsuarioExistente" runat="server" Width="400px" CssClass="textbox"
                        TabIndex="7" MaxLength="20"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Button ID="btnProseguir" runat="server" Text="Proseguir" CssClass="textbox"
                        TabIndex="8" onclick="btnProseguir_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
