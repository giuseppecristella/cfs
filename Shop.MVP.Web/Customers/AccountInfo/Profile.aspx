<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Customers/MasterPages/Customers.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Shop.Web.Mvp.Customers.AccountInfo.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <section class="col-md-9">
        <p>Per reimpostare la tua password inserisci una nuova e clicca su "Cambia Password"</p>
    </section>
    <section class="billing-address col-md-6">
        <div class="form-group">
            <label for="Password">Password Attuale</label>
            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" class="text" ID="Password" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password"
                ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="NewPassword">Nuova Password</label>
            <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" class="text" ID="NewPassword" />
            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="ConfirmNewPassword">Conferma Nuova Password</label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="ConfirmNewPassword" />
            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="NewPassword"
                ControlToValidate="ConfirmNewPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="Le password non coincidono"
                ValidationGroup="vgRegisterUser"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                ErrorMessage="Questo campo è obbligatorio" Display="Dynamic" ValidationGroup="vgRegisterUser"> </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn btn-primary" Text="Cambia Password" OnClick="btnChangePassword_OnClick" runat="server" ID="btnChangePassword" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblPasswordChangedResult" Text="" runat="server"></asp:Label>
        </div>
    </section>
</asp:Content>
