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
                                            <ul id="product-images" class="product-imagesul">
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
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="top"><i class="fa fa-chevron-circle-up fa-4x" style="margin-top:7px;padding-left:85%;color:rgba(114, 114, 114, 0.41);"></i></div>
    </div>
</asp:Content>
