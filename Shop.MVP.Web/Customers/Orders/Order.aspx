<%@ Page Title="" EnableEventValidation="false"  Language="C#" MasterPageFile="~/Customers/MasterPages/Customers.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Shop.Web.Mvp.Customers.Orders.Order" %>

<%@ Register Src="~/UserControls/UCOrderDetail.ascx" TagPrefix="uc1" TagName="UCOrderDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="col-md-9">
        <uc1:UCOrderDetail  runat="server" id="UCOrderDetail" />
    </div>
</asp:Content>
