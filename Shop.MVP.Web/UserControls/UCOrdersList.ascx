<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOrdersList.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCOrdersList" %>
<asp:ListView ID="lvOrders" runat="server">
    <LayoutTemplate>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Data</th>
                    <th>Indirizzo</th>
                    <th>Pagamento</th>
                    <th>Sub Totale</th>
                    <th>Spedizione</th>
                    <th>Totale</th>
                    <th></th>
                </tr>
            </thead>
            <tr runat="server" id="itemPlaceholder" />
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("SubmissionDate") %></td>
            <td><%# Eval("CustomerAddress") %></td>
            <td><%# Eval("PaymentType") %></td>
            <td><%# Eval("SubTotal") %></td>
            <td><%# Eval("Shipment") %></td>
            <td><%# Eval("Total") %></td>
            <td>
                <asp:LinkButton ID="lbCustomerOrderDetail" PostBackUrl='<%# string.Format("~/{0}/Orders/Order/{1}",PageContainerName, Eval("Id")) %>' runat="server">Vedi dettaglio</asp:LinkButton></td>
        </tr>
    </ItemTemplate>
</asp:ListView>
