<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductsFilters.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCProductsFilters" %>
<div class="right-sidebar">
    <div class="sidebar">
        <h5 class="sidebar-title uppercase">Marche</h5>
        <div class="body">
            <ul>
                <li ng-repeat="category in categories">
                    <input type="checkbox" id="{{category}}" ng-click="toggleSelection(category)" ng-true-value="{{category}}" name="favorite" />
                    <label for="{{category}}">
                        <span>{{category}}</span></label>
                </li>
                <%--  You chose : {{selection}}
                <br />
                lenght : {{selection}}--%>
            </ul>
        </div>
        <!-- /.body -->
    </div>
    <!-- /.sidebar -->
    <div class="sidebar">
        <h5 class="sidebar-title uppercase">Colore</h5>
        <div class="body">
            <ul>
                <li ng-repeat="color in colors">
                    <input type="checkbox" id="{{color}}" ng-click="toggleSelectionColor(color)" ng-true-value="{{color}}" name="color" />
                    <label for="{{color}}">
                        <span>{{color}}</span></label>
                </li>
                <%-- <li><a href="../product-simple.html">Amuse Society</a></li>--%>
            </ul>
        </div>
    </div>
    <!-- /.sidebar -->
    <div class="sidebar">
      <%--  <h5 class="sidebar-title uppercase">Prezzo</h5>--%>
        <div class="body">
            <div class="accordion">
                <%--    <div ui-slider="{range: true}" min="0" max="200" step="10" use-decimals ng-model="priceRange"></div>
                <br />
                <br />--%>
                <%-- <input type="text" ng-model="priceRange" />--%>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapseOne" data-toggle="collapse" class="accordion-toggle">Prezzo
                        </a>
                    </div>
                    <!-- /.accordion-heading -->
                    <div class="_accordion-body" id="collapseOne_">
                        <div class="accordion-inner">
                            <div ui-slider="{range: true}" min="0" max="200" step="10" class="m-t-20" use-decimals ng-model="priceRange"></div>
                            <%--  <div id="slider-range" class="m-t-20"></div>--%>
                            <p class="slider-price-range">
                                <input ng-model="priceRange" type="text" id="amount">
                            </p>
                        </div>
                        <!-- /.accordion-inner -->
                    </div>
                    <!-- /.accordion-body -->
                </div>
                <!-- /.accordion-group -->
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapseTwo" data-toggle="collapse" class="accordion-toggle">Colore
                        </a>
                    </div>
                    <!-- /.accordion-heading -->
                    <div class="accordion-body" id="collapseTwo">
                        <div class="accordion-inner">
                            <div class="color-holder clearfix">
                                <ul class="color-picker clearfix">
                                    <%--                                    <li>
                                        <input class="le-radio bianco" type="radio" value="color1" name="sidebar" checked="checked"></li>--%>
                                    <li ng-repeat="color in colors">
                                        <input class="le-radio {{color}}" type="checkbox" id="{{color}}" ng-click="toggleSelectionColor(color)" ng-true-value="{{color}}" name="color" />
                                    </li>
                                    <%-- <li>
                                        <input class="le-radio gray" type="radio" value="color2" name="sidebar"></li>
                                    <li>
                                        <input class="le-radio red" type="radio" value="color3" name="sidebar"></li>
                                    <li>
                                        <input class="le-radio green" type="radio" value="color4" name="sidebar"></li>
                                    <li>
                                        <input class="le-radio" type="radio" value="color5" name="sidebar"></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapse3" data-toggle="collapse" class="accordion-toggle collapsed">Taglie
                        </a>
                    </div>
                    <div class="accordion-body collapse" id="collapse3">
                        <div class="accordion-inner">
                            <div class="size-holder clearfix">
                                <ul class="size-picker clearfix">
                                    <li>
                                        <input id="group1" class="attribute-radio" type="radio" value="color1" name="group">
                                        <label for="group1"><span>7</span></label>
                                    </li>
                                    <li>
                                        <input id="group2" class="attribute-radio" type="radio" value="color2" name="group">
                                        <label for="group2"><span>8</span></label>
                                    </li>
                                    <li>
                                        <input id="group3" class="attribute-radio" type="radio" value="color3" name="group">
                                        <label for="group3"><span>8.5</span></label>
                                    </li>
                                    <li>
                                        <input id="group4" class="attribute-radio" type="radio" value="color4" name="group">
                                        <label for="group4"><span>9</span></label>
                                    </li>
                                    <li>
                                        <input id="group5" class="attribute-radio" type="radio" value="color5" name="group">
                                        <label for="group5"><span>9.5</span></label>
                                    </li>
                                    <li>
                                        <input id="group6" class="attribute-radio" type="radio" value="color6" name="group">
                                        <label for="group6"><span>10</span></label>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
