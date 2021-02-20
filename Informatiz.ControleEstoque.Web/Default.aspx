<%@ Page Title="CE - Controle de Estoque" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Informatiz.ControleEstoque.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <fieldset>
        <legend>Não sou cadastrado</legend>
        <table width="100%">
            <tr>
                <td width="100%">
                    Caso queira se cadastrar e baixar o software, clque no botão a seguir.
                </td>
                <td width="50px">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Proseguir" CssClass="botao" ForeColor="White"
                        Font-Bold="True" Font-Size="Medium" OnClick="btnCadastrar_Click" BackColor="Red" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Sou cadastrado</legend>
        <table width="100%">
            <tr>
                <td width="100%">
                    Caso seje um usuário ja cadastro, para baixar o software clique no botão a seguir.
                </td>
                <td width="50px">
                    <asp:Button ID="btnCandastrado" runat="server" Text="Proseguir" BackColor="#33CC33"
                        CssClass="botao" ForeColor="White" Font-Bold="True" Font-Size="Medium" OnClick="btnCandastrado_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
   <%-- <fieldset>
        <legend>Sou consultor</legend>
        <table width="100%">
            <tr>
                <td width="100%">
                    Caso seje um consultor, clique no botão a seguir para ir para a área do consultor.
                </td>
                <td width="50px">
                    <asp:Button ID="btnConsultor" runat="server" Text="Proseguir" BackColor="#0033CC"
                        CssClass="botao" ForeColor="White" Font-Bold="True" Font-Size="Medium" OnClick="btnConsultor_Click" />
                </td>
            </tr>
        </table>
    </fieldset>--%>
</asp:Content>
