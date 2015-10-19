<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCShowcaseProducts.ascx.cs" Inherits="Shop.Web.Mvp.Home.UserControls.UCShowcaseProducts" %>
<%@ Import Namespace="MagentoRepository.Helpers" %>
<div class="row grid-view">
    <asp:Repeater runat="server" ID="rptShowcaseProducts">
        <ItemTemplate>
            <div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
                <div class="product">
                    <div class="image">
                        <a href="/<%# Eval("sku") %>/<%# Eval("product_id") %>">
                            <img class="img-responsive" width="258" src="assets/images/blank.gif" data-echo="<%# Eval("imageurl") %>" alt=""></a>
                    </div>
                    <div class="product-info m-t-20 text-center">
                        <h5 class="name uppercase"><a href="product-simple.html"><%#Eval("name") %></a></h5>
                        <div class="product-price">
                            <ins><span class="amount">€.<%# CommonHelper.FormatCurrency(Eval("price").ToString()) %></span></ins>
                        </div>
                        <div class="buttons-holder m-t-20">
                            <%--<div class="add-cart-holder">
                                <a title="Add to cart" ng-click="<%#  string.Format("addProductToCartFromUI('{0}','{1}','{2}')", Eval ("product_id"), Eval ("name"), Eval ("price")) %>" class="cart-button btn btn-primary">
                                    <%--   <a title="Add to cart" ng-click="addProductToCartFromUI('1')" class="cart-button btn btn-primary">--%>
                              <div class="add-cart-holder">
                                   <a href="/<%# Eval("sku") %>/<%# Eval("product_id") %>"class="cart-button btn btn-primary"><span>Vedi Dettaglio</span></a>
                                </a>
                            </div> 
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
