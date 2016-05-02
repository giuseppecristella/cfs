<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Shop.Web.Mvp.Checkout.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateSecondAddressesFields(oSrc, args) {
            var iscbShowShipmentAddressVisible = $('#cbShowShipmentAddress').is(':visible');
            var iscbShowShipmentAddressChecked = $('#cbShowShipmentAddress').is(':checked');
            args.IsValid = (!iscbShowShipmentAddressVisible || iscbShowShipmentAddressChecked || args.Value != "");
        }

        function validatePaymentMethodsList(oSrc, args) {
            var rdbtnListPayMethods = document.getElementById("<%=rdbtnListPayMethods.ClientID %>");
            var options = rdbtnListPayMethods.getElementsByTagName("input");
           
            var checkvalue = false;
            var check;
           
                if (options[0].checked) {
                    checkvalue = true;
                    check = options[0].value;
                } else {
                    alert("Metodo di pagamento attualmente non disponibile!");
                }
            
            //for (i = 0; i < options.length; i++) {
            //    if (options[i].checked) {
            //        checkvalue = true;
            //        check = options[i].value;
            //    } 
                 
            //}
            if (!checkvalue) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <asp:MultiView ID="mvContainer" runat="server" ActiveViewIndex="1">
        <asp:View ID="viewEmptyCart" runat="server">
            <div class="page-header">
                <div class="container">
                    <header class="text-center">
                        <h3 class="section-title"><i class="icon icon-shopbag"></i></h3>
                    </header>
                </div>
            </div>
            <div class="container">
                <header class="text-center">
                    <h2 class="section-title">
                        <asp:Literal ID="ltEmptyCartTitle" runat="server"></asp:Literal></h2>
                    <br />
                    <span>
                        <asp:Literal ID="ltEmptyCartMsg" runat="server"></asp:Literal>
                        Clicca questo <a href="../">link</a> per continuare gli acquisti.
                    </span>
                </header>
                <br />
            </div>
        </asp:View>
        <asp:View ID="viewFullCart" runat="server">
            <div class="page-header">
                <div class="container">
                    <div class="contact-info-icons row">
                        <div class="col-md-4 col-xs-12 col-sm-6">
                            <div class="contact-info">
                                <i class="icon icon-user"></i>
                                <span class="contact-info-title"></span>
                                <span class="contact-info-subtitle">Registrazione</span>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-sm-6">
                            <div class="contact-info middle">
                                <i class="icon icon-secure-payment"></i>
                                <span class="contact-info-title"></span>
                                <span class="contact-info-subtitle">Pagamenti</span>
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-12 col-sm-6">
                            <div class="contact-info pull-right last">
                                <i class="icon icon-truck"></i>
                                <span class="contact-info-title"></span>
                                <span class="contact-info-subtitle">Spedizione</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlLoggedInUserHeader" CssClass="page-header" runat="server">
                <!-- /.container -->
                <div class="container">
                    <header>
                        <h4 style="font-size: 18px"><b>Hai già un account? Accedi!</b></h4>
                    </header>
                    <asp:Login CssClass="table_reset" ID="Login" runat="server" FailureText="String" OnLoggedIn="OnLoggedIn" OnLoginError="OnLoginError">
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
                                        UseSubmitBehavior="false" Text="Accedi" ValidationGroup="vgLogin" />
                                </div>
                                <%-- <div class="col-md-2 col-xs-12 hidden-sm">
                                    <br />
                                    <button class="btn btn-primary">Facebook Login</button>
                                </div>--%>
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
            </asp:Panel>
            <!-- /.page-header -->
            <div class="catalog-content">
                <div class="container">
                    <section class="checkout container">
                        <div class="row">
                            <header>
                                <h3 class="section-title">
                                    <asp:Literal ID="ltTreeStepCheckoutTitle" runat="server"></asp:Literal>
                                </h3>
                            </header>
                            <section class="billing-address col-md-4">
                                <header>
                                    <h3 class="section-title"><span class="step-no">1.</span> Dove spediamo ?</h3>
                                </header>
                                <div class="billing-address-form">
                                    <div class="form-group">
                                        <label for="txtFirstName" ng-model="name">Nome</label>
                                        <asp:TextBox ClientIDMode="Static" class="form-control" ID="txtFirstName" runat="server" />
                                        <asp:RequiredFieldValidator ID="rvtxtFirstName" runat="server" ControlToValidate="txtFirstName"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rvtxtFirstNameRegisterUser" runat="server" ControlToValidate="txtFirstName"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtLastName">Cognome</label>
                                        <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtLastName" />
                                        <asp:RequiredFieldValidator ID="rvtxtLastName" runat="server" ControlToValidate="txtLastName"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rvtxtLastNameRegisterUser" runat="server" ControlToValidate="txtLastName"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
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
                                        <asp:RequiredFieldValidator ID="rvtxtStreetRegisterUser" runat="server" ControlToValidate="txtStreet"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtCity">Città</label>
                                        <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtCity" />
                                        <asp:RequiredFieldValidator ID="rvtxtCity" runat="server" ControlToValidate="txtCity"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rvtxtCityRegisterUser" runat="server" ControlToValidate="txtCity"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtZipCode">CAP</label>
                                        <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtZipCode" />
                                        <asp:RequiredFieldValidator ID="rvtxtZipCode" runat="server" ControlToValidate="txtZipCode"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rvtxtZipCodeRegisterUser" runat="server" ControlToValidate="txtZipCode"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtPhone">Telefono</label>
                                        <asp:TextBox ClientIDMode="Static" class="form-control" runat="server" ID="txtPhone" />
                                        <asp:RequiredFieldValidator ID="rvtxtPhone" runat="server" ControlToValidate="txtPhone"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgCheckout"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rvtxtPhoneegisterUser" runat="server" ControlToValidate="txtPhone"
                                            Display="Dynamic" ErrorMessage="Questo campo è obbligatorio" ToolTip="Questo campo è obbligatorio"
                                            ValidationGroup="vgRegisterUser"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:Panel runat="server" ID="pnlCreateNewAccount" class="form-group checkbox">
                                        <label>
                                            <input ng-model="createNewAccount" type="checkbox" />
                                            Crea un account per i prossimi acquisti
                                        </label>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlShowShipmentAddress" class="form-group checkbox">
                                        <label>
                                            <input name="showShipmentAddress" ng-model="showShipmentAddress" type="checkbox" runat="server" clientidmode="Static" id="cbShowShipmentAddress" />
                                            Spedisci allo stesso indirizzo
                                        </label>
                                    </asp:Panel>
                                </div>
                                <div ng-show="createNewAccount">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel runat="server" ID="upPnlCheck">
                                        <ContentTemplate>
                                            <asp:CreateUserWizard LoginCreatedUser="True" DuplicateUserNameErrorMessage="Utente già presente"
                                                DuplicateEmailErrorMessage="email già presente" ID="cuwUser" runat="server"
                                                RequireEmail="False"
                                                OnCreatedUser="cuwUser_OnCreatedUser"
                                                OnCreatingUser="cuwUser_OnCreatingUser">
                                                <WizardSteps>
                                                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <label for="UserName">Nome Utente</label>
                                                                <asp:TextBox ClientIDMode="Static" runat="server" CssClass="form-control" ID="UserName" />
                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                    ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="Password">Password</label>
                                                                <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" class="text" ID="Password" />
                                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                    ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="ConfirmPassword">Conferma Password</label>
                                                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="ConfirmPassword" />
                                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="Le password non coincidono"
                                                                    ValidationGroup="vgRegisterUser"></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                                    ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Registrati"
                                                                    UseSubmitBehavior="false" ValidationGroup="vgRegisterUser" CssClass="btn btn-primary" />
                                                            </div>
                                                            <div class="form-group">
                                                                <span style="color: red;">
                                                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal></span>
                                                            </div>
                                                        </ContentTemplate>
                                                        <CustomNavigationTemplate>
                                                        </CustomNavigationTemplate>
                                                    </asp:CreateUserWizardStep>
                                                    <asp:CompleteWizardStep runat="server">
                                                        <ContentTemplate>
                                                            <span style="color: seagreen;">L'account è stato creato con successo.<br />
                                                                Puoi completare il tuo acquisto cliccando su <b>Conferma Ordine</b></span>
                                                        </ContentTemplate>
                                                    </asp:CompleteWizardStep>
                                                </WizardSteps>
                                            </asp:CreateUserWizard>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                <th>Subtotale</th>
                                                <td>{{ subTotalCartPrice | currency: "&euro;" }}</td>
                                            </tr>
                                            <tr>
                                                <th>Spedizione</th>
                                                <td>{{ shipmentPrice | currency: "&euro;"}}</td>
                                            </tr>
                                            <tr>
                                                <th>Totale</th>
                                                <td>
                                                    <div class="prices">{{ totalCartPrice | currency: "&euro;" }}</div>
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
                                                            <h3 class="product-title"><span class="product-quantity">
                                                                <input type="number" style="width: 50px;" class="txt txt-qty" title="Qty" ng-change="UpdateProductQty(product)" ng-model="product.qta" name="quantity" min="1" step="1" />
                                                                x
                                                            </span>{{ product.name }}</h3>
                                                            <ul class="product-attributes">
                                                                <li>Taglia : {{ product.size }}</li>
                                                                <li><a href="" ng-click="DeleteProduct(product)">Elimina</a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="prices">
                                                        {{ product.price | currency: "&euro;"}}
                                                    </div>
                                                </td>
                                            </tr>
                                            <div id="top"><i class="fa fa-chevron-circle-up fa-4x" style="margin-top: 7px; padding-left: 85%; color: rgba(114, 114, 114, 0.41);"></i></div>
                                        </tbody>
                                    </table>
                                    <div class="checkout-action text-right">
                                        <label for="txtPromo">Hai un Codice Promo?</label>
                                       <asp:TextBox ClientIDMode="Static" ID="txtPromo"  runat="server"></asp:TextBox> 
                                    </div>
                                    <div class="checkout-action text-right">
                                        <asp:Button UseSubmitBehavior="false" ID="btnCheckout" Text="Conferma l'ordine" ValidationGroup="vgCheckout" OnClick="btnCheckout_OnClick" runat="server" CssClass="btn btn-primary" />
                                    </div>
                                </section>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
