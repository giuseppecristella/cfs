<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Shop.Web.Mvp.Catalog.Products" %>

<%@ Register Src="~/UserControls/UCBreadcrumbs.ascx" TagPrefix="uc1" TagName="UCBreadcrumbs" %>
<%@ Register Src="~/UserControls/UCProductsFilters.ascx" TagPrefix="uc1" TagName="UCProductsFilters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="catalog-content">
        <div class="container">
            <div class="row row-no-margin">
                <div class="col-md-9 col-sm-10">
                    <uc1:UCBreadcrumbs runat="server" ID="UCBreadcrumbs" />
                    <div class="catalog-products clearfix">
                        <div ng-repeat="product in catalog | filter: filterByBrands | filter: filterPrice | filter: filterByColors | filter: filterBySize" class='col-md-6 col-sm-6 col-lg-4 col-xs-12 product-holder'>
                            <div class="product">
                                <div class="image">
                                    <a href="{{ product._sku}}/{{ product._product_id}}">
                                        <img class="img-responsive" width="258" ng-src="{{product._imageurl}}" alt=""></a>
                                </div>
                                <!-- .image -->
                                <div class="product-info m-t-20 text-center">
                                    <h5 class="name uppercase"><a href="../product-simple.html">{{ product._name }}</a></h5>
                                    <div class="product-price">
                                        <ins><span class="amount">{{ product._price | currency }}</span></ins>
                                    </div>
                                    <div class="buttons-holder m-t-20">
                                    <div class="add-cart-holder">
                                      <a href="{{ product._sku}}/{{ product._product_id}}" class="cart-button btn btn-primary"><span>Vedi Dettaglio</span></a>
                                     
                                    </div>
                                    </div>
                                   
                                </div>
                                <!-- .product-info -->
                            </div>
                        </div>
                    </div>
                    <div id="top"><i class="fa fa-arrow-circle-up fa-4x" style="margin-top:7px;padding-left:85%"></i></div>
                    
                </div>
                <div class="col-md-3 col-sm-2">
                    <uc1:UCProductsFilters runat="server" ID="UCProductsFilters" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
