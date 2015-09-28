<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Shop.Web.Mvp.Checkout.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="page-header">
        <div class="container">
            <div class="contact-info-icons row">
                <div class="col-md-4 col-xs-12 col-sm-6">
                    <div class="contact-info">
                        <i class="icon icon-phone-icon"></i>
                        <span class="contact-info-title">+48 655 555 555</span><br />
                        <span class="contact-info-subtitle">Phone Us</span>
                    </div>
                    <!-- /.contact-info -->
                </div>
                <div class="col-md-4 col-xs-12 col-sm-6">
                    <div class="contact-info middle">
                        <i class="icon icon-mailicon"></i>
                        <span class="contact-info-title">info@bewear.com</span><br />
                        <span class="contact-info-subtitle">Write us Email</span>
                    </div>
                    <!-- /.contact-info -->
                </div>
                <div class="col-md-4 col-xs-12 hidden-sm">
                    <div class="contact-info pull-right last">
                        <i class="icon icon-faxicon"></i>
                        <span class="contact-info-title">+48 655 555 555</span><br />
                        <span class="contact-info-subtitle">FAX Us</span>
                    </div>
                    <!-- /.contact-info -->
                </div>
            </div>
            <!-- /.contact-info-icons -->
        </div>
        <!-- /.container -->
    </div>
    <!-- /.page-header -->
    <div class="catalog-content">
        <div class="container">
            <section class="checkout container">
                <div class="row">
                    <section class="billing-address col-md-4">
                        <header>
                            <h3 class="section-title"><span class="step-no">1.</span> Dove spediamo ?</h3>
                        </header>
                        <div class="billing-address-form">
                            <form>
                                <div class="form-group">
                                    <label for="first-name">Nome</label>
                                    <input type="text" class="form-control" id="first-name">
                                </div>
                                <div class="form-group">
                                    <label for="last-name">Cognome</label>
                                    <input type="text" class="form-control" id="last-name">
                                </div>
                                <div class="form-group">
                                    <label for="email">Email</label>
                                    <input type="email" class="form-control" id="email">
                                </div>
                                <div class="form-group">
                                    <label for="street-address">Via</label>
                                    <input type="text" class="form-control" id="street-address">
                                </div>
                                <div class="form-group">
                                    <label for="city">Città</label>
                                    <input type="text" class="form-control" id="city">
                                </div>
                                <div class="form-group">
                                    <label for="zip-code">CAP</label>
                                    <input type="text" class="form-control" id="zip-code">
                                </div>
                                <div class="form-group">
                                    <label for="company">Telefono</label>
                                    <input type="text" class="form-control" id="company">
                                </div>
                                <div class="form-group checkbox">
                                    <label>
                                        <input type="checkbox">
                                        Create an account for later use
                                    </label>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox">
                                        Ship to the same address
                                    </label>
                                </div>
                            </form>
                        </div>
                    </section>
                    <div class="col-md-1">&nbsp;</div>
                    <div class="col-md-7">
                        <section class="shipping-method">
                            <header>
                                <h3 class="section-title"><span class="step-no">2.</span> Come vuoi pagare ?</h3>
                            </header>
                            <ul class="payment-methods list-unstyled">
                                <li class="radio">
                                    <label>
                                        <input type="radio" name="payment-method">
                                        PayPal</label></li>
                                <li class="radio">
                                    <label>
                                        <input type="radio" name="payment-method">
                                        Bonifico</label></li>
                            </ul>
                            <br/><br/>
                            <header>
                                <h3 class="section-title"><span class="step-no">3.</span> Ecco il tuo Ordine</h3>
                            </header>
                            <table class="table order-review-table">
                                <thead>
                                    <tr>
                                        <th>Prodotti</th>
                                        <th>SubTotale</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Subtotal</th>
                                        <td>$424.99</td>
                                    </tr>
                                    <tr>
                                        <th>Shipping &amp; Handling</th>
                                        <td>$8.99</td>
                                    </tr>
                                    <tr>
                                        <th>Grand Total</th>
                                        <td>
                                            <div class="prices">$432.99</div>
                                        </td>
                                    </tr>
                                </tfoot>
                                <tbody>
                                    <tr ng-repeat="product in cartProducts">
                                        <td>
                                            <div class="product media">
                                                <div class="media-left">
                                                    <img src="assets/images/blank.gif" width="80" data-echo="{{ product.image }}" alt="{{ product.name }}" class="media-object">
                                                </div>
                                                <div class="media-body media-middle">
                                                    <h3 class="product-title"><span class="product-quantity">{{ product.count }} x</span> {{ product.name }}</h3>
                                                    <ul class="product-attributes">
                                                        <li>Color : Verdigris Red</li>
                                                        <li>Size : L</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="prices">
                                                € {{ product.price }}
                                            </div>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                            <div class="checkout-action text-right">
                                <button class="btn btn-primary">Checkout</button>
                            </div>
                        </section>
                    </div>
                    <%--   <section class="col-md-1">
                    </section>--%>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
