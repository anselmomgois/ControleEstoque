<%@ Page Title="CE - Controle de Estoque" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="Informatiz.ControleEstoque.Web.Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Donwload CE - Controle Estoque</legend>
        <table width="100%">
            <tr bgcolor="#99CCFF">
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="Descrição"></asp:Label>
                </td>
                <td align="center" width="100px">
                    <asp:Label ID="Label2" runat="server" Text="Versão"></asp:Label>
                </td>
                <td align="center" width="100px">
                    <asp:Label ID="Label1" runat="server" Text="Download"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#E9E9E9">
                <td align="center">
                    Instalador da versão gratis do IGERENCE.
                </td>
                <td align="center" width="100px">
                    1601.1201
                </td>
                <td align="center" width="100px">
                    <asp:HyperLink ID="lnkBaixar1" runat="server" 
                        NavigateUrl="~/Arquivos/IGERENCE.exe">Baixar</asp:HyperLink>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
