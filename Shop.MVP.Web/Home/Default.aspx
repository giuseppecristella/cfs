<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Default" %>
<%@ Register Src="~/Home/UserControls/UCShowcaseProducts.ascx" TagPrefix="uc1" TagName="UCShowcaseProducts" %>
<asp:Content ID="cMain" ContentPlaceHolderID="cpMain" runat="server">
    <div class="main-content home-2">
        <div class="container">
            <section class="home-2-features inner-top-xs">
                <div class="row">
                    <div class="col-md-6 col-sm-12  feature-block">
                        <a href="categories-grid.html" class="media features">
                            <div class="media-left">
                                <div class="image">
                                    <img width="300" height="300" class="lazy-load media-object img-responsive" src="/assets/images/blank.gif" data-echo="/assets/images/products/feature1.jpg" alt="">
                                </div>
                            </div>
                            <div class="media-body media-middle">
                                <div class="section text-center">
                                    <h5 class="name">Il nostro catalogo infradito</h5>
                                    <h3 class="tagline">In Blu / Fly Flot</h3>
                                </div>
                            </div>
                        </a>
                        <a href="categories-grid.html" class="media features">
                            <div class="media-body media-middle">
                                <div class="section text-center">
                                    <h5 class="name">Scopri la nostra collezione</h5>
                                    <h3 class="tagline">Sandali 2015</h3>
                                </div>
                            </div>
                            <div class="media-right">
                                <div class="image">
                                    <img width="300" height="300" class="lazy-load media-object img-responsive" src="/assets/images/blank.gif" data-echo="/assets/images/products/feature2.jpg" alt="">
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-6 col-sm-12 feature-block big-image hidden-sm">
                        <a href="categories-grid.html">
                            <img width="570" height="600" class="img-responsive lazy-load" src="/assets/images/blank.gif" data-echo="/assets/images/products/feature3.jpg" alt="">
                            <div class="centered-caption">
                                <div class="banner-text text-center">
                                    <h4 class="banner-title">calzature e accessori</h4>
                                    <h2 class="tagline">per la tua famiglia</h2>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </section>
            <div class="product-tab-ver2">
                <div role="tabpanel">
                    <div class="tab-nav-holder">
                        <ul class="nav nav-tabs uppercase" role="tablist">
                            <li role="presentation" class="active"><a href="#just-arrived" aria-controls="just-arrived" role="tab" data-toggle="tab">Nuovi arrivi 2015/2016</a></li>
                        </ul>
                    </div>
                    <div class="tab-content inner-top-xs">
                        <div role="tabpanel" class="tab-pane active" id="just-arrived">
                            <uc1:UCShowcaseProducts runat="server" id="UCShowcaseProducts" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="load-more-holder text-center">
            <a href="/nuovi-arrivi" class="btn btn-default load-more">Scopri tutti i Nuovi Arrivi</a>
        </div>
      <%--  <section class="wide-banners clearfix wow fadeIn">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="/assets/images/blank.gif" data-echo="/assets/images/brands/w2.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <h5>over 40s</h5>
                                    <h3>free delivery</h3>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="/assets/images/blank.gif" data-echo="/assets/images/brands/w1.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <div class="strip-inner">
                                        <h5>get up to</h5>
                                        <h1>40% off</h1>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="/assets/images/blank.gif" data-echo="/assets/images/brands/w3.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <div class="strip-inner">
                                        <h5>we care</h5>
                                        <h3>world shipping</h3>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </section>--%>
        <section class="container subscription wow fadeIn">
            <div class="form-inline form-subscribe text-center">
                <span class="form-subtitle">Ricevi le nostre offerte</span>
                <h3 class="form-title">Iscriviti alla Newsletter</h3>
                <div class="form-group">
                    <label for="email-subscribe" class="sr-only">Email</label>
                    <input type="email" class="form-control" id="email-subscribe" placeholder="Inserisci il tuo indirizzo e-mail">
                    <button type="submit" class="btn btn-primary btn-subscribe">Iscriviti</button>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
