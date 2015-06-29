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
                <img src="assets/image/main.jpg" alt="Bell" />
            </div>
            <div class="overlay"></div>
            <div class="content">
                <div style="background: #eb5830"
                          <%--  min-height: 580px" --%>
                            class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-4 col-xs-4">
                            <!--<h1 class="logo">Bell</h1>-->
                        </div>
                        <div class="col-md-6 col-sm-8 col-xs-8 social">
                            <a target="_blank" href="https://www.facebook.com/kalzafacile?fref=ts" class="wow animated bounceIn" data-wow-delay=".75s"><i class="fa fa-facebook"></i></a>
                            <!--<a href="#" class="wow animated bounceIn" data-wow-delay=".5s"><i class="fa fa-twitter"></i></a>
                        <a href="#" class="wow animated bounceIn" data-wow-delay="1s"><i class="fa fa-dribbble"></i></a>-->
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h2 style="color: #34495e">Che <span style="color: #eb5830">belle</span>...Che <span style="color: #eb5830">Gratis!</span></h2>
                        </div>
                    </div>

                    <!--<div class="row">
                     <div class="col-md-12 countdown">
                         <ul id="countdown" class="wow animated fadeInDown"> <li> <span class="days">00</span> <p class="timeRefDays">giorni</p></li><li class="seperator">.</li><li> <span class="hours">00</span> <p class="timeRefHours">ore</p></li><li class="seperator">:</li><li> <span class="minutes">00</span> <p class="timeRefMinutes">minuti</p></li><li class="seperator">:</li><li> <span class="seconds">00</span> <p class="timeRefSeconds">secondi</p></li></ul>
                     </div>
                 </div>-->
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
                                        <asp:TextBox type="email" name="email" placeholder="Inserisci la tua e-mail" required runat="server"></asp:TextBox>
                                        <%--<input type="email" name="email" placeholder="Inserisci la tua e-mail" required />--%>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <asp:Button runat="server" ID="btnNesletterSubscribe" OnClick="btnNesletterSubscribe_OnClick" Text="Iscriviti"/>
                                       <%-- <button>Iscriviti</button>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-success success_alert">Got it, you've been added to our email list.</div>
                            <div class="alert alert-danger error_alert"><strong>Oops!</strong> There was a error!</div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    </form>
</body>
</html>
