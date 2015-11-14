<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOrderDetail.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCOrderDetail" %>
       <p>
            Ordine n. <%= OrderViewModel.MagentoOrderId %> eseguito da: <%= OrderViewModel.CustomerFirstName %> <%= OrderViewModel.CustomerSecondName %> il <%= OrderViewModel.SubmissionDate %> 
        </p>
        <h3 class="form-title">Prodotti</h3>
        <asp:ListView ID="lvOrderProducts" runat="server">
            <LayoutTemplate>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Taglia</th>
                            <th>Prezzo Unitario</th>
                            <th>Q.ta</th>
                            <th>Totale</th>
                        </tr>
                    </thead>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Size") %></td>
                    <td><%# Eval("UnitPrice") %></td>
                    <td><%# Eval("Qty") %></td>
                    <td><%# Eval("TotalPrice") %></td>

                </tr>
            </ItemTemplate>
        </asp:ListView>
         <h3 class="form-title">Indrizzo spedizione</h3>
        <p>
            <%= OrderViewModel.CustomerAddress %>
        </p>