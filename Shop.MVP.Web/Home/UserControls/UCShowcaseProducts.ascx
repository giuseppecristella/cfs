<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCShowcaseProducts.ascx.cs" Inherits="Shop.Web.Mvp.Home.UserControls.UCShowcaseProducts" %>
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
                        <%--<a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>--%>
                        <%--<ul class="color-picker clearfix">
                            <li class="selected">
                                <input checked="checked" class="le-radio group black" type="radio" value="g1-0" name="rgroup-0"></li>
                            <li>
                                <input class="le-radio group gray" type="radio" value="g1-1" name="rgroup-0"></li>
                            <li>
                                <input class="le-radio group brown" type="radio" value="g1-2" name="rgroup-0"></li>
                        </ul>--%>
                        <h5 class="name uppercase"><a href="product-simple.html"><%#Eval("name") %></a></h5>
                        <div class="product-price">
                            <ins><span class="amount">€. <%#Eval ("price") %></span></ins>
                        </div>
                        <div class="buttons-holder m-t-20">
                            <div class="add-cart-holder">
                                <a title="Add to cart" href="checkout.html" class="cart-button btn btn-primary">
                                    <span>Compralo ora</span>
                                </a>
                            </div>
                            <%--          <div class="add-wishlist-holder">
                                <a href="checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                    <span class="icon icon-wishlist"></span>add to wishlist
                                </a>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
