<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductsFilters.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCProductsFilters" %>
<div class="right-sidebar">
    <div class="sidebar">
        <h5 class="sidebar-title uppercase">Marche</h5>
        <div class="body">
            <ul>
                <li ng-repeat="brand in brands">
                    <input type="checkbox" id="{{brand}}" ng-click="toggleSelectionBrand(brand)" ng-true-value="{{brand}}" name="brand" />
                    <label for="{{brand}}">
                        <span>{{brand}}</span></label>
                </li>
            </ul>
        </div>
    </div>
    <div class="sidebar">
        <div class="body">
            <div class="accordion">
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapseOne" data-toggle="collapse" class="accordion-toggle">PREZZO
                        </a>
                    </div>
                    <div class="accordion-body" id="collapseOne">
                        <div class="accordion-inner">
                            <div ui-slider="{range: true}" min="0" max="200" step="10" class="m-t-20" use-decimals ng-model="priceRange"></div>
                            <p class="slider-price-range">
                                <input ng-model="priceRange" type="text" id="amount">
                            </p>
                        </div>
                    </div>
                </div>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapseTwo" data-toggle="collapse" class="accordion-toggle">COLORE
                        </a>
                    </div>
                    <div class="accordion-body" id="collapseTwo">
                        <div class="accordion-inner">
                            <div class="color-holder clearfix">
                                <ul class="color-picker clearfix">
                                    <li ng-repeat="color in colors">
                                        <input class="le-radio {{color}}" type="checkbox" id="{{color}}" ng-click="toggleSelectionColor(color)" ng-true-value="{{color}}" name="color" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a href="#collapse3" data-toggle="collapse" class="accordion-toggle">TAGLIE
                        </a>
                    </div>
                    <div class="accordion-body" id="collapse3">
                        <div class="accordion-inner">
                            <div class="size-holder clearfix">
                                <ul class="size-picker clearfix">
                                    <li ng-repeat="size in sizes">
                                        <input type="checkbox" class="attribute-radio" id="{{size}}" ng-click="toggleSelectionSize(size)" ng-true-value="{{size}}" name="size" />
                                        <label for="{{size}}">
                                            <span>{{size}}</span></label></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
