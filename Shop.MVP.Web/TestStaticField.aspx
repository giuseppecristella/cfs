<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestStaticField.aspx.cs" Inherits="Shop.Web.Mvp.TestStaticField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Nome :
    <asp:TextBox runat="server" Text="" ID="txtName"></asp:TextBox>
    <br/>
    Indirizzi :
    <asp:Repeater runat="server" ID="rptAdresses">
        <ItemTemplate>
            <%# Eval("Street") %>
        </ItemTemplate>

    </asp:Repeater>
    <br/>
    Nuovo Indirizzo :
    <asp:TextBox runat="server" Text="" ID="txtAddressStreet"></asp:TextBox>
    <br/>
    <asp:Button runat="server" ID="btnAddAddress" Text="Aggiungi Indirizzo" OnClick="btnAddAddress_OnClick"/>
    </div>
    </form>
</body>
</html>
