<%@ Page Title="" Language="C#" MasterPageFile="~/Customers/MasterPages/Customers.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Customers.Dashboard.Default" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2014.1.403.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register Src="~/UserControls/UCOrdersList.ascx" TagPrefix="uc1" TagName="UCOrdersList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <div class="col-md-9">
        <p>
            Attraverso il tuo Pannello hai la possibilità di visualizzare i tuoi ordini ed aggiornare le informazioni relative al tuo account. Selezione un link sottostante per controllare o modificare i dati inseriti.
        </p>
        <h3 class="form-title">Ordini Recenti</h3>
        <uc1:UCOrdersList runat="server" ID="UCOrdersList" />
        <br />
        <h3 class="form-title">Dati utente</h3>
        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
        <asp:Label ID="lblLastName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblEMail" runat="server"></asp:Label>
        <br />
        <h3 class="form-title">Indirizzo spedizione</h3>
        <asp:Label ID="lblAdrressFirstName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAdrressLastName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAdrressStreet" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAddressCity" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAddressZipCode" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAddressPhone" runat="server"></asp:Label>
        <br />
        <h3 class="form-title">Newsletter</h3>
        <p>
            Al momento non risulto iscritto alla newsletter.<br />
            <asp:LinkButton ID="lbChangeSubscription" runat="server">Modifica iscrizione</asp:LinkButton>
        </p>
    </div>
</asp:Content>
