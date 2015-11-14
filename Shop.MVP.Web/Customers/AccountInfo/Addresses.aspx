<%@ Page Title="" Language="C#" MasterPageFile="~/Customers/MasterPages/Customers.Master" AutoEventWireup="true" CodeBehind="Addresses.aspx.cs" Inherits="Shop.Web.Mvp.Customers.AccountInfo.Addresses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <section class="col-md-9">
        <p>Se desideri modificare il tuo indirizzo di spedizione per i tuoi acquisti futuri modifica i dati nel form sottostante e clicca "Aggiorna Indirizzo"</p>
    </section>
    <section class="billing-address col-md-6">
        <h3 class="form-title">Indirizzo spedizione</h3>
        <div class="billing-address-form">
            <div class="form-group">
                <label for="txtFirstName">Nome</label>
                <asp:TextBox ClientIDMode="Static" class="form-control" Text="<%# AddressVM.firstname %>" ID="txtFirstName" runat="server"></asp:TextBox>
            </div>
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

        <asp:Button CssClass="btn btn-primary" Text="Modifica Indirizzo" ID="btnUpdateAddress" runat="server" />
    </section>

</asp:Content>
