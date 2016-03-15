<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="SingleProduct.aspx.cs" Inherits="Shop.Web.Mvp.Catalog.SingleProduct" %>

<%@ Import Namespace="Ez.Newsletter.MagentoApi" %>
<%@ Import Namespace="MagentoRepository.Helpers" %>
<%@ Register Src="~/UserControls/UCBreadcrumbs.ascx" TagPrefix="uc1" TagName="UCBreadcrumbs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="container">
        <div class="catalog-content">
            <div class="row row-no-margin">
                <div class="col-md-9 col-sm-10">
                    <uc1:UCBreadcrumbs runat="server" ID="UCBreadcrumbs" />
                </div>
            </div>
            <div id="single-product" class="inner-top-50">
                <div class="container">
                    <div class="row single-product-row wow fadeIn">
                        <div class="col-sm-6 col-lg-6 gallery-holder">
                            <div class="product-image-slider">
                                <section class="slider wow fadeIn">
                                    <div class="row">
                                        <div class="col-md-10 col-xs-12">
                                            <ul id="product-images">
                                                <li>
                                                     <%--<a href="<%= ProductViewModel.imageurl %>" data-title="Gallery" data-lightbox="<%= ProductViewModel.name %>">--%>
                                                        <img src="<%= ProductViewModel.imageurl %>" data-title="Gallery" data-lightbox="<%= ProductViewModel.name %>" alt="" />
                                                        <%--<img src="/assets/images/blank.gif" data-title="Gallery" data-lightbox="<%= ProductViewModel.name %>" data-echo="<%= ProductViewModel.imageurl %>" alt="" />--%>
                                                    <%-- </a>--%>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-6 body-holder body-holder-style-1">
                            <div class="product-info">
                                <div class="product-rating-holder">
                                    <%--<a href="product-extended.html" class="product-rating">
                                        <div class="star-rating gray" title="Rated 5.00 out of 5">
                                           <%-- <span style="width: 80%">
                                                <strong class="rating">5.00</strong>
                                                out of 5
                                            </span>
                                        </div>
                                    </a>--%>
                                   <%-- <a href="#reviews" class="review-link">(4 reviews)</a>--%>
                                </div>
                                <asp:HiddenField runat="server" ID="hfProductID" Value="<%# ProductViewModel.product_id %>"/>
                                <h1 class="single-product-title"><%= ProductViewModel.name %></h1>
                                <%--<div class="product-brand">Calvin Klein</div>--%>
                                  <div id="product-simple-tab">
                                    <div class="tabs">
                                        <ul class="nav nav-tabs nav-tab-cells">
                                            <li class="active"><a data-toggle="tab" href="#description">Descrizione</a></li>
                                        </ul>
                                        <div class="tab-content bewear-tab-content">
                                            <div id="Div2" class="tab-pane in active">
                                                <p class="text">
                                                    <%= ProductViewModel.description %>
                                                </p>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="product-price">
                                    <ins><span class="amount">€. <%= CommonHelper.FormatCurrency(ProductViewModel.price) %></span></ins>
                                </div>
                                <%--<div class="social-icons-holder">
                                    <ul class="social-icon-list clearfix">
                                        <li><a class="icon icon-facebook31" title="Facebook" href="https://www.facebook.com/kalzafacile?fref=ts"></a></li>
                                    </ul>
                                </div>--%>
                                <%-- <div class="product-attributes">
                                    <div class="color-holder clearfix">
                                        <span class="key">Colore:</span> <span class="value">Nero</span>
                                        <ul class="color-picker clearfix">
                                            <li>
                                                <input class="le-radio blue checked" type="radio" value="color1" name="main" checked="checked">
                                            </li>
                                        </ul>
                                    </div>
                                   
                                </div>--%>
                                    <div class="size-holder m-t-20 clearfix">
                                        <span class="key">Taglie disponibili:</span>
                                        <ul class="size-picker clearfix">
                                            <asp:Repeater runat="server" OnPreRender="rptSizes_OnPreRender" ID="rptSizes">
                                                <ItemTemplate>
                                                    <li>
                                                        <%--<asp:RadioButton OnCheckedChanged="rbSize_OnCheckedChanged" AutoPostBack="True" Text='<%#Eval("Name") %>' ID="rbSize"  runat="server"/>--%>
                                                        <input id='<%# Eval("Name") %>'  ng-click="<%#  string.Format("selectSize('{0}')", Eval ("name")) %>" class="attribute-radio" type="radio" name="group" />
                                                        <label for='<%# Eval("Name") %>'>
                                                            <span><%# Eval("Name").ToString().Replace("tg_",string.Empty) %></span>
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater> 
                                          </ul>
                                    </div>
                                </div>
                                <div class="qnt-holder">
                                    <div class="cart">
                                       <%-- <div class="quantity-holder">
                                            <span class="key">Qta.:</span>
                                            <input type="number" class="txt txt-qty" title="Qty" value="1" name="quantity" min="1" step="1">
                                        </div>--%>
                                     <a  
                                         data-toggle="offcanvas" 
                                         data-target="{{ activatePanelCart }}" 
                                         href="#"> <input ng-class="{{' classBtnAddProductToCart'  }}" ng-click="<%=  string.Format("addProductToCartFromUI('{0}','{1}','{2}','{3}')", ProductViewModel.product_id, ProductViewModel.name, ProductViewModel.price, ProductViewModel.imageurl) %>" class="btn btn-primary single-add-cart-button" value="Compralo Ora"></a>
                                        
                                    </div>
                                </div>
                                 <%--  <div id="product-simple-tab">
                                    <div class="tabs">
                                        <ul class="nav nav-tabs nav-tab-cells">
                                            <li class="active"><a data-toggle="tab" href="#description">Descrizione</a></li>
                                        </ul>
                                        <div class="tab-content bewear-tab-content">
                                            <div id="description" class="tab-pane in active">
                                                <p class="text">
                                                    <%= ProductViewModel.description %>
                                                </p>
                                                <ul>
                                                    <li>- 98% Cotton, 2% Elastane</li>
                                                    <li>- Zip fly and button fastening</li>
                                                    <li>- Five pocket model</li>
                                                    <li>- Belt loops</li>
                                                    <li>- Leather badge at back</li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
