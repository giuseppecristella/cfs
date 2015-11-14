<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Shop.Web.Mvp.Admin.Orders.Orders" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2014.1.403.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <telerik:RadGrid ID="rgAdminOrders" OnNeedDataSource="rgAdminOrders_OnNeedDataSource" runat="server"
        EnableViewState="true"
        AllowSorting="True" AllowMultiRowSelection="True"
        AllowPaging="True" AllowCustomPaging="false" ShowGroupPanel="True"
        EnableEmbeddedSkins="True"
        AllowFilteringByColumn="true" AutoGenerateColumns="False" GridLines="none">
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
        <HeaderStyle></HeaderStyle>
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn UniqueName="SubmissionDate" HeaderText="Data" HeaderButtonType="TextButton"
                    DataField="SubmissionDate">
                    <HeaderStyle />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="CustomerFirstName" HeaderText="Cognome" HeaderButtonType="TextButton"
                    DataField="CustomerFirstName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="CustomerSecondName" HeaderText="Nome" HeaderButtonType="TextButton"
                    DataField="CustomerSecondName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="CustomerAddress" HeaderText="Indirizzo" HeaderButtonType="TextButton"
                    DataField="CustomerAddress">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="PaymentType" HeaderText="Tipo Pagamento" HeaderButtonType="TextButton"
                    DataField="PaymentType">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="SubTotal" HeaderText="Sub Totale" HeaderButtonType="TextButton"
                    DataField="SubTotal">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Shipment" HeaderText="Spedizione" HeaderButtonType="TextButton"
                    DataField="Shipment">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Total" HeaderText="Tot." HeaderButtonType="TextButton"
                    DataField="Total">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbCustomerOrderDetail" PostBackUrl='<%# string.Format("../Orders/Order/{0}",Eval("Id")) %>' runat="server">Vedi dettaglio</asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
