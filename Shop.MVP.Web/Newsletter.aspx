<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Newsletter.aspx.cs" Inherits="Shop.Web.Mvp.Newsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="page-header">
        <div class="container">
            <header class="text-center">
                <h3 class="section-title"><i class="icon icon-shopbag"></i></h3>
            </header>
        </div>
    </div>
    <div class="container">
        <header class="text-center">
            <h2 class="section-title">
                <asp:Literal runat="server" ID="ltResult" />
            </h2>
            <br />
            <%--     <span>
                Clicca questo <a href="../">link</a> per continuare gli acquisti.
            </span>--%>
        </header>
        <br />
    </div>

</asp:Content>
