<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Shop.Web.Mvp.Catalog.Products" %>

<%@ Register Src="~/UserControls/UCBreadcrumbs.ascx" TagPrefix="uc1" TagName="UCBreadcrumbs" %>
<%@ Register Src="~/UserControls/UCProductsFilters.ascx" TagPrefix="uc1" TagName="UCProductsFilters" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="catalog-content">
        <div class="container" ng-controller="scCatalogCtrl">
            <div class="row row-no-margin">
                <div class="col-md-9 col-sm-10">
                    <uc1:UCBreadcrumbs runat="server" ID="UCBreadcrumbs" />
                    <div class="catalog-products clearfix">
                        <div ng-repeat="product in catalog | filter: my.favorite |  filter: filterFunction | filter: filterPrice" class='col-md-6 col-sm-6 col-lg-4 col-xs-12 product-holder'>
                            <div class="product">
                                <div class="image">
                                    <a href="../product-simple.html">
                                        <img class="img-responsive" width="258" ng-src="{{product._imageurl}}" alt=""></a>
                                </div>
                                <!-- .image -->
                                <div class="product-info m-t-20 text-center">
                                    <a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>
                                    <ul class="color-picker clearfix">
                                        <li class="selected">
                                            <input class="le-radio group gray" type="radio" value="g1" checked="checked" name="c1">
                                        </li>
                                        <li>
                                            <input class="le-radio black" type="radio" value="g1-2" name="c1">
                                        </li>
                                    </ul>
                                    <!-- .color-picker -->
                                    <h5 class="name uppercase"><a href="../product-simple.html">{{ product._name }}</a></h5>
                                    <div class="product-price">
                                        <ins><span class="amount">{{ product._price }}</span></ins>
                                    </div>
                                    <!-- .product-price -->
                                    <div class="buttons-holder m-t-20">
                                        <div class="add-cart-holder">
                                            <a title="Add to cart" href="../checkout.html" class="cart-button btn btn-primary">
                                                <span>Add to bag</span>
                                            </a>
                                        </div>
                                        <!-- .add-cart-holder -->
                                        <div class="add-wishlist-holder">
                                            <a href="../checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                                <span class="icon icon-wishlist"></span>add to wishlist
                                            </a>
                                        </div>
                                        <!-- .add-wishlist-holder -->
                                    </div>
                                    <!-- .buttons-holder -->
                                </div>
                                <!-- .product-info -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-2">
                    <uc1:UCProductsFilters runat="server" ID="UCProductsFilters" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
