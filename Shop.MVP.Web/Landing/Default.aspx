<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Landing.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calzafacile - La scarpa che ti calza a pennello</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="assets/stylesheet/font-awesome.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="assets/stylesheet/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/stylesheet/animate.css" />
    <link rel="stylesheet" href="assets/stylesheet/style.css" />
</head>
<body class="green-color">
    <form id="form1" runat="server">
        <header id="header">
            <div class="background">
                <img src="<%= Page.ResolveClientUrl("assets/image/") %>main.jpg" alt="calzafacile" />
             <%--   <img src="assets/image/main.jpg" alt="calzafacile" />--%>
            </div>
            <div class="overlay"></div> 
            <div class="content">
                <div <%--style="min-height: 580px"--%>  class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-4 col-xs-4">
                        </div>
                        <div class="col-md-6 col-sm-8 col-xs-8 social">
                            <a target="_blank" href="https://www.facebook.com/kalzafacile?fref=ts" class="wow animated bounceIn" data-wow-delay=".75s"><i class="fa fa-facebook"></i></a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h2 style="color: #34495e">Che <span style="color: #eb5830">belle</span>...Che <span style="color: #eb5830">Gratis!</span></h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h2 style="color: #34495e">le infradito che ti regala <span style="color: #eb5830">C</span>alza<span style="color: #eb5830">f</span>acile</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3>iscriviti alla newsletter</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3 subscribe wow animated fadeInUp">
                            <div class="row">
                                <div>
                                    <div class="col-md-8 col-sm-8">
                                        <asp:TextBox type="email"  name="email" ID="txtEmail" placeholder="Inserisci la tua e-mail" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <asp:Button runat="server"  CssClass="btn-upper" ID="btnNesletterSubscribe" OnClick="btnNesletterSubscribe_OnClick" Text="Iscriviti" />
                                    </div>
                                </div>
                            </div>
                            <div id="divSuccess" runat="server" class="alert alert-success success_alert">
                                <asp:Literal ID="ltSuccessMessage" runat="server"></asp:Literal></div>
                            <div id="divError" runat="server" class="alert alert-danger error_alert"><strong>Oops!</strong>&nbsp;<asp:Literal ID="ltErrorMessage" runat="server"></asp:Literal></div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    </form>
</body>
</html>
