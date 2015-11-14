<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Shop.Web.Mvp.Admin.Orders.Order" %>
<%@ Register Src="~/UserControls/UCOrderDetail.ascx" TagPrefix="uc1" TagName="UCOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="col-md-12">
        <uc1:UCOrderDetail runat="server" ID="UCOrderDetail" />
    </div>
</asp:Content>
