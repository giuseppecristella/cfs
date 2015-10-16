<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Shop.Web.Mvp.Checkout.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function validateSecondAddressesFields(oSrc, args) {
            var iscbShowShipmentAddressChecked = $('#showShipmentAddress').is(':checked');
            args.IsValid = (iscbShowShipmentAddressChecked || args.Value != "");
        }

        function validatePaymentMethodsList(oSrc, args) {
            var rdbtnListPayMethods = document.getElementById("<%=rdbtnListPayMethods.ClientID %>");
            var options = rdbtnListPayMethods.getElementsByTagName("input");
            var Checkvalue = false;
            var check;
            for (i = 0; i < options.length; i++) {
                if (options[i].checked) {
                    Checkvalue = true;    
                    check = options[i].value;
                }
            }
            if (!Checkvalue) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="page-header">
        <%-- <div class="container">
            <div class="contact-info-icons row">
                <div class="col-md-4 col-xs-12 col-sm-6">
                    <div class="contact-info">
                        <i class="icon icon-phone-icon"></i>
                        <span class="contact-info-title">+48 655 555 555</span><br />
                        <span class="contact-info-subtitle">Phone Us</span>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 col-sm-6">
                    <div class="contact-info middle">
                        <i class="icon icon-mailicon"></i>
                        <span class="contact-info-title">info@bewear.com</span><br />
                        <span class="contact-info-subtitle">Write us Email</span>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 hidden-sm">
                    <div class="contact-info pull-right last">
                        <i class="icon icon-faxicon"></i>
                        <span class="contact-info-title">+48 655 555 555</span><br />
                        <span class="contact-info-subtitle">FAX Us</span>
                    </div>
                </div>
            </div>
        </div>--%>
        <!-- /.container -->
        <div class="container">
            <header>
                <h4 style="font-size: 18px"><b>Hai già un account? Accedi!</b></h4>
            </header>
            <asp:Login CssClass="table_reset" ID="Login" runat="server" FailureText="String" OnLoggedIn="OnLoggedIn" OnLoginError="OnLoginError">
                <%--<FailureTextStyle ForeColor="White" BackColor="Red"></FailureTextStyle>--%>
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-md-4 col-xs-12 hidden-sm">
                            <label for="username">Username</label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-xs-12 hidden-sm">
                            <label for="password">Password</label>
                            <asp:TextBox ID="Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                        </div>
                        <div class="col-md-2 col-xs-12 hidden-sm">
                            <br />
                            <asp:Button CssClass="btn btn-primary" ID="LoginButton" runat="server" CommandName="Login"
                                Text="Accedi" ValidationGroup="vgLogin" />
                        </div>
                        <div class="col-md-2 col-xs-12 hidden-sm">
                            <br />
                            <button class="btn btn-primary">Facebook Login</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xs-12 hidden-sm">
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="Inserire Username" ToolTip="inserire Nome Utente"
                                ValidationGroup="vgLogin"></asp:RequiredFieldValidator><br />
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="<span class='required'>Inserire Password</span>" ToolTip="inserire Password"
                                ValidationGroup="vgLogin"></asp:RequiredFieldValidator><br />
                            <span style="color: red;">
                                <asp:Literal ID="lblFailureText" runat="server" /></span>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
    <!-- /.page-header -->
    <div class="catalog-content">
        <div class="container">
            <section class="checkout container">
                <div class="row">
                    <header>
                        <h3 class="section-title">Non hai un account? Non è necessario!</h3>
                    </header>
                    <section class="billing-address col-md-4">
                        <header>
                            <h3 class="section-title"><span class="step-no">1.</span> Dove spediamo ?</h3>
                        </header>
                        <div class="billing-address-form">
                            <div class="form-group">
                                <label for="txtFirstName">Nome</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" ID="txtFirstName" runat="server" />
                                <asp:RequiredFieldValidator ID="rvtxtFirstName" runat="server" ControlToValidate="txtFirstName"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtLastName">Cognome</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtLastName" />
                                <asp:RequiredFieldValidator ID="rvtxtLastName" runat="server" ControlToValidate="txtLastName"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtEmail">Email</label>
                                <%--TODO: Regex check email format--%>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtEmail" />
                                <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" runat="server" ID="rvtEMailCheckout" ControlToValidate="txtEmail" ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" runat="server" ID="rvtEMailRegisterUser" ControlToValidate="txtEmail" ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtStreet">Via</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtStreet" />
                                <asp:RequiredFieldValidator ID="rvtxtStreet" runat="server" ControlToValidate="txtStreet"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtCity">Città</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtCity" />
                                <asp:RequiredFieldValidator ID="rvtxtCity" runat="server" ControlToValidate="txtCity"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtZipCode">CAP</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtZipCode" />
                                <asp:RequiredFieldValidator ID="rvtxtZipCode" runat="server" ControlToValidate="txtZipCode"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtPhone">Telefono</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtPhone" />
                                <asp:RequiredFieldValidator ID="rvtxtPhone" runat="server" ControlToValidate="txtPhone"
                                    Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                    ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group checkbox">
                                <label>
                                    <input id="createNewAccount" ng-model="createNewAccount" type="checkbox">
                                    Crea un account per i prossimi acquisti
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input id="showShipmentAddress" name="showShipmentAddress" ng-model="showShipmentAddress" type="checkbox">
                                    Spedisci allo stesso indirizzo
                                </label>
                            </div>
                        </div>
                        <div ng-show="createNewAccount">
                            <asp:CreateUserWizard LoginCreatedUser="True" DuplicateUserNameErrorMessage="utente già presente"
                                DuplicateEmailErrorMessage="email già presente" ID="CreateUserWizard1" runat="server" RequireEmail="False"
                                CompleteSuccessText="Registrazione effettuata con successo." OnCreatedUser="CreateMagentoUser" OnCreatingUser="CreateUserWizard1_OnCreatingUser"
                                ContinueButtonText="Continua lo shopping" ContinueButtonType="Link" ContinueDestinationPageUrl="~/Design/Default.aspx"
                                FinishDestinationPageUrl="~/Contatti.aspx">
                                <WizardSteps>
                                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                        <ContentTemplate>
                                            <label for="UserName">
                                                Nome Utente<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="CreateUserWizard1"> </asp:RequiredFieldValidator></label>
                                            <asp:TextBox ClientIDMode="Static" runat="server" CssClass="form-control" ID="UserName" />
                                            Password<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage=" * campo obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator></label>
                                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" class="text" ID="Password" />
                                            <fieldset>
                                                <label>
                                                    Conferma Password
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="le passwords non coincidono"
                                        ValidationGroup="vgRegisterUser"></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                        ErrorMessage="campo obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="ConfirmPassword" />
                                            </fieldset>
                                            <br />
                                            <fieldset>
                                                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Registrati"
                                                    ValidationGroup="vgRegisterUser" CssClass="btn btn-primary" />
                                            </fieldset>
                                            <fieldset>
                                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                            </fieldset>
                                        </ContentTemplate>
                                        <CustomNavigationTemplate>
                                        </CustomNavigationTemplate>
                                    </asp:CreateUserWizardStep>
                                    <asp:CompleteWizardStep runat="server">
                                    </asp:CompleteWizardStep>
                                </WizardSteps>
                            </asp:CreateUserWizard>
                        </div>
                        <div ng-show="!showShipmentAddress">
                            <div class="form-group">
                                <label for="txtStreet_2">Via</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtStreet_2" />
                                <asp:CustomValidator ID="cvtxtStreet_2" runat="server" ValidateEmptyText="True"
                                    ValidationGroup="vgCheckout" ControlToValidate="txtStreet_2"
                                    ErrorMessage="Questo campo è obbligatorio." Display="Dynamic"
                                    ClientValidationFunction="validateSecondAddressesFields">
                                </asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtCity_2">Città</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtCity_2" />
                                <asp:CustomValidator ID="cvtxtCity_2" runat="server" ValidateEmptyText="True"
                                    ValidationGroup="vgCheckout" ControlToValidate="txtCity_2"
                                    ErrorMessage="Questo campo è obbligatorio." Display="Dynamic"
                                    ClientValidationFunction="validateSecondAddressesFields">
                                </asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtZipCode_2">CAP</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtZipCode_2" />
                                <asp:CustomValidator ID="cvtxtZipCode_2" runat="server" ValidateEmptyText="True"
                                    ValidationGroup="vgCheckout" ControlToValidate="txtZipCode_2"
                                    ErrorMessage="Questo campo è obbligatorio." Display="Dynamic"
                                    ClientValidationFunction="validateSecondAddressesFields">
                                </asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtPhone_2">Telefono</label>
                                <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtPhone_2" />
                                <asp:CustomValidator ID="cvtxtPhone_2" runat="server" ValidateEmptyText="True"
                                    ValidationGroup="vgCheckout" ControlToValidate="txtPhone_2"
                                    ErrorMessage="Questo campo è obbligatorio." Display="Dynamic"
                                    ClientValidationFunction="validateSecondAddressesFields">
                                </asp:CustomValidator>
                            </div>
                        </div>
                    </section>
                    <div class="col-md-1">&nbsp;</div>
                    <div class="col-md-7">
                        <section class="shipping-method">
                            <header>
                                <h3 class="section-title"><span class="step-no">2.</span> Come vuoi pagare ?</h3>
                            </header>
                            <%--<ul class="payment-methods list-unstyled">
                              
                                <li class="radio">
                                    <label>
                                        <input type="radio" name="payment-method">
                                        PayPal</label></li>
                                <li class="radio">
                                    <label>
                                        <input type="radio" name="payment-method">
                                        Bonifico</label></li>
                            </ul>--%>
                            <asp:RadioButtonList CssClass="payment-methods list-unstyled" ID="rdbtnListPayMethods" runat="server">
                            </asp:RadioButtonList>
                            <asp:CustomValidator ID="cvType" ValidationGroup="vgCheckout" runat="server" ControlToValidate="rdbtnListPayMethods"
                                ClientValidationFunction="validatePaymentMethodsList" Display="Dynamic" ValidateEmptyText="true" ErrorMessage="Seleziona un metodo di pagamento.">
                            </asp:CustomValidator>
                            <br />
                            <br />
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
                                <asp:Button ID="btnCheckout" Text="Conferma l'ordine" ValidationGroup="vgCheckout" runat="server" CssClass="btn btn-primary" />
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
