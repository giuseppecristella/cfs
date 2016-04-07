<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCHeader" %>
<header>
    <!-- Favicon -->
    <link rel="shortcut icon" href="/assets/images/favicon2.png">
    <div class="navbar navbar-black">
        <div class="navbar-header">
            <div class="container">
                <a class="navbar-brand" href="/Default">
                    <img src="/assets/images/logo2.png" class="logo" alt=""></a>
                <a class="btn responsive-menu pull-right" data-toggle="collapse" data-target=".navbar-collapse">
                    <div class="bar"></div>
                    <div class="bar"></div>
                    <div class="bar"></div>
                </a>
            </div>
            <!-- /.container -->
        </div>
        <!-- /.navbar-header -->
        <div class="yamm">
            <div class="navbar-collapse collapse animate-dropdown">
                <div class="container">
                    <a href="/" class="navbar-brand">
                        <img src="/assets/images/logo2.png" class="logo" alt=""></a>
                    <ul class="nav navbar-nav">
                        <li class="dropdown bewear-dropdown yamm-fw">
                            <a href="/donna" style="cursor: default;" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Donna</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/donna-sanitarie">Sanitarie</a></li>
                                                <li><a href="/donna-ciabatte">Ciabatte</a></li>
                                                <li><a href="/donna-sandali">Sandali</a></li>
                                                <li><a href="/donna-infradito">Infradito</a></li>
                                                <li><a href="/donna-sneakers">Sneakers</a></li>
                                                <li><a href="/donna-pantofole">Pantofole</a></li>
                                                <li><a href="/donna-zeppe">Zeppe</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="#">Borse</a></li>
                                                <li><a href="#">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="../assets/images/CatalogoGenerale/BannerDonna.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <!-- <h2>DONNA</h2>
                                                        <!--<h2>DEL 50% </h2>-->
                                                    </div>
                                                </a>
                                            </div>

                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown bewear-dropdown yamm-fw">
                            <a href="/uomo" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Uomo</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/uomo-sanitarie">Sanitarie</a></li>
                                                <li><a href="/uomo-ciabatte">Ciabatte</a></li>
                                                <li><a href="/uomo-sandali">Sandali</a></li>
                                                <li><a href="/uomo-infradito">Infradito</a></li>
                                                <li><a href="/uomo-pantofole">Pantofole</a></li>
                                                <li><a href="/uomo-sneakers">Sneakers</a></li>
                                                <li><a href="/uomo-antinfortunistica">Antinfortunistica</a></li>
                                                <li><a href="/uomo-stivali-in-gomma">Stivali in gomma</a></li>
                                            </ul>

                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="#">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="../assets/images/CatalogoGenerale/BannerUomo.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <!--   <h2>UOMO</h2>
                                                       <!--<h2>DEL 50% </h2>-->
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown bewear-dropdown yamm-fw">
                            <a href="/bambino" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Bambino</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/bambino-ciabatte">Ciabatte</a></li>
                                                <li><a href="/bambino-sandali">Sandali</a></li>
                                                <li><a href="/bambino-infradito">Infradito</a></li>
                                                <li><a href="/bambino-pantofole">Pantofole</a></li>
                                                <li><a href="/bambino-sneakers">Sneakers</a></li>
                                            </ul>

                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="#">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="../assets/images/CatalogoGenerale/BannerBambino.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <!-- <h2>BAMBINO</h2>
                                                        <!--<h2>DEL 50% </h2>-->
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="../MasterPages/home.html" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Promozioni</span></a>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <%-- <asp:LoginName ID="lnAccount" runat="server" />--%>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" PostBackUrl="/Customers/Dashboard/" ID="lbAccountInfo">
                                <% if (!string.IsNullOrEmpty(Page.User.Identity.Name))
                                   {%>
                                <asp:LoginName Style="text-transform: lowercase; font-weight: 300" ID="LoginName1" runat="server" />
                                <%  } %>
                                <i class="icon icon-user"></i>
                            </asp:LinkButton>
                        </li>
                        <% if (!string.IsNullOrEmpty(Page.User.Identity.Name))
                           {%>
                        <li>
                            <asp:LinkButton runat="server" OnClick="lbLogout_OnClick" ID="lbLogout">
                                      <span Style="text-transform: lowercase; font-weight: 300" >log off</span>  
                                <i class="icon icon-lookbook-arrowright"></i>
                            </asp:LinkButton>
                        </li>
                        <%  } %>
                        <li>
                            <a id="menu-toggle" class="navbar-toggle shopping-cart-toggle" data-toggle="offcanvas" data-target="#shopping-cart-summary" href="#"><i class="icon icon-shopbag"></i><span ng-model="totalCartItems" class="item-count">{{  totalCartItems }} </span></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</header>
