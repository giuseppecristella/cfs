<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Login.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="container">
        <div class="col-md-4">
            <%--Login--%>
            <header>
                <h4 style="font-size: 18px"><b>Accedi</b></h4>
            </header>
            <asp:Login CssClass="table_reset" ID="Login" runat="server" DestinationPageUrl="~/Customers/Dashboard/" FailureText="String" OnLoginError="OnLoginError">
                <LayoutTemplate>
                     <div class="form_login">
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
                         </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <div class="col-md-8">
            <%--User Info--%>
             <h4 style="font-size: 18px"><b>Compila il modulo di registrazione</b></h4>
            <div class="billing-address-form">
               <div class="form-group">
                    <label for="txtFirstName">Nome</label>
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
            

            <%--Register User--%>
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
        </div>
    </div>
    </div> 
</asp:Content>
