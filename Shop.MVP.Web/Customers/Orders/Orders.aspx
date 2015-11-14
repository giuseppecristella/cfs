<%@ Page Title="" Language="C#" MasterPageFile="~/Customers/MasterPages/Customers.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Shop.Web.Mvp.Customers.Orders.Orders" %>
<%@ Register Src="~/UserControls/UCOrdersList.ascx" TagPrefix="uc1" TagName="UCOrdersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="col-md-9">
        <uc1:UCOrdersList runat="server" id="UCOrdersList" />
    </div>
</asp:Content>
