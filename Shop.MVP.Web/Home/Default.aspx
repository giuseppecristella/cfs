<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Default" %>

<%@ Register Src="~/Home/UserControls/UCShowcaseProducts.ascx" TagPrefix="uc1" TagName="UCShowcaseProducts" %>
<asp:Content ID="cMain" ContentPlaceHolderID="cpMain" runat="server">
    <div class="main-content home-2">
        <div class="container">
            <section class="home-2-features inner-top-xs">
                <div class="row">
                    <div class="col-md-6 col-sm-12  feature-block">
                        <a href="#" class="media features">
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
                        <a href="#" class="media features">
                            <div class="media-body media-middle">
                                <div class="section text-center">
                                    <h5 class="name">Scopri la nostra collezione</h5>
                                    <h3 class="tagline">2015</h3>
                                </div>
                            </div>
                            <div class="media-right">
                                <div class="image">
                                    <img width="300" height="300" class="lazy-load media-object img-responsive" src="/assets/images/blank.gif" data-echo="/assets/images/products/homeInvernali.jpg" alt="">
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-6 col-sm-12 feature-block big-image hidden-sm">
                        <a href="#">
                            <img width="570" height="600" class="img-responsive lazy-load" src="/assets/images/blank.gif" data-echo="/assets/images/products/feature3.jpg" alt="" />
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
                            <uc1:UCShowcaseProducts runat="server" ID="UCShowcaseProducts" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="load-more-holder text-center">
            <a href="/nuovi-arrivi" class="btn btn-default load-more">Scopri tutti i Nuovi Arrivi</a>
        </div>
        <section class="container subscription wow fadeIn">
            <div class="form-inline form-subscribe text-center">
                <span class="form-subtitle">Ricevi le nostre offerte</span>
                <h3 class="form-title">Iscriviti alla Newsletter</h3>
                <div class="form-group">
                    <label for="email-subscribe" class="sr-only">Email</label>
                    <asp:TextBox type="email" class="form-control" ID="txtEmail" placeholder="Inserisci il tuo indirizzo e-mail" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" runat="server" ID="rvtEMailCheckout" ControlToValidate="txtEmail" ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Indirizzo e-mail non valido."></asp:RegularExpressionValidator>
                    <asp:Button runat="server" ID="btnNewsletterSubscibe" OnClick="btnNewsletterSubscibe_OnClick" class="btn btn-primary btn-subscribe" Text="Iscriviti"></asp:Button>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
