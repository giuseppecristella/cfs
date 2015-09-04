﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCHeader" %>
<header>
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
        </div>
        <div class="yamm">
            <div class="navbar-collapse collapse animate-dropdown">
                <div class="container">
                    <a href="/" class="navbar-brand">
                        <img src="/assets/images/logo2.png" class="logo" alt=""></a>
                    <ul class="nav navbar-nav">
                        <li class="dropdown bewear-dropdown yamm-fw">
                            <a href="#" style="cursor: default;" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Donna</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/donna-sneakers">Sneakers</a></li>
                                                <li><a href="/donna-ciabatte">Ciabatte</a></li>
                                                <li><a href="/donna-sandali">Sandali</a></li>
                                                <li><a href="/donna-infradito">Infradito</a></li>
                                                <li><a href="/donna-zeppe">Zeppe</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="../MasterPages/categories-grid.html">Borse</a></li>
                                                <li><a href="../MasterPages/categories-grid.html">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega3.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>get up to</h5>
                                                        <h2>-50% off</h2>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega4.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>check out</h5>
                                                        <h3>new arrivals</h3>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown bewear-dropdown yamm-fw">
                            <a href="../MasterPages/home.html" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Uomo</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/uomo-sneakers">Sneakers</a></li>
                                                <li><a href="/uomo-ciabatte">Ciabatte</a></li>
                                                <li><a href="/uomo-sandali">Sandali</a></li>
                                                <li><a href="/uomo-infradito">Infradito</a></li>
                                                <li><a href="/uomo-antinfortunistica">Antinfortunistica</a></li>
                                                <li><a href="/uomo-stivali-in-gomma">Stivali in gomma</a></li>
                                            </ul>

                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="../MasterPages/categories-grid.html">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega3.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>get up to</h5>
                                                        <h2>-50% off</h2>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega4.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>check out</h5>
                                                        <h3>new arrivals</h3>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown bewear-dropdown"><a href="../MasterPages/home.html" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Bambino</span></a>
                            <ul class="dropdown-menu bewear-dropdown-menu">
                                <li class="dropdown yamm-fw">
                                    <div class="row mega-menu-ver2">
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Scarpe</h5>
                                            <ul class="sub-menu">
                                                <li><a href="/bambino-sneakers">Sneakers</a></li>
                                                <li><a href="/bambino-ciabatte">Ciabatte</a></li>
                                                <li><a href="/bambino-sandali">Sandali</a></li>
                                                <li><a href="/bambino-infradito">Infradito</a></li>
                                            </ul>

                                        </div>
                                        <div class="col-xs-12 col-md-3 col-sm-3">
                                            <h5 class="menu-title">Accessori</h5>
                                            <ul class="sub-menu">
                                                <li><a href="../MasterPages/categories-grid.html">Cinture</a></li>
                                            </ul>
                                        </div>
                                        <div class="col-ms-6 col-sm-6 banners col-xs-12">
                                            <div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega3.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>get up to</h5>
                                                        <h2>-50% off</h2>
                                                    </div>
                                                </a>
                                            </div>
                                            <%--<div class="wide-banner cnt-strip">
                                                <a href="../MasterPages/catalog.html">
                                                    <div class="image">
                                                        <img src="/assets/images/blank.gif" data-echo="/assets/images/products/mega4.jpg" alt="">
                                                    </div>
                                                    <div class="strip text-center">
                                                        <h5>check out</h5>
                                                        <h3>new arrivals</h3>
                                                    </div>
                                                </a>
                                            </div>--%>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="../MasterPages/home.html" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Promozioni</span></a>
                            <%--         <ul class="dropdown-menu bewear-dropdown-menu">
                                <li><a href="../MasterPages/home.html">Home</a></li>
                            </ul>--%>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown searchbox bewear-dropdown"><a href="#" data-hover="dropdown" class="no-drop-icon dropdown-toggle" data-toggle="dropdown"><i class="icon icon-search"></i></a>
                            <div class="dropdown-menu bewear-dropdown-menu">
                                <form id="search" class="navbar-form search" role="search">
                                    <input type="search" class="form-control" placeholder="Type to search">
                                    <button type="submit" class="btn btn-primary btn-submit icon icon-search"></button>
                                </form>
                            </div>
                        </li>
                        <li><a href="#"><i class="icon icon-user"></i></a></li>
                        <li><a id="menu-toggle" class="navbar-toggle shopping-cart-toggle" data-toggle="offcanvas" data-target="#shopping-cart-summary" href="#"><i class="icon icon-shopbag"></i><span ng-model="totalCartItems" class="item-count"> {{  totalCartItems }} </span></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</header>
