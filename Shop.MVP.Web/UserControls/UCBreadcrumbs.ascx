<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBreadcrumbs.ascx.cs" Inherits="Shop.Web.Mvp.UserControls.UCBreadcrumbs" %>
<div class="control-bar">
    <ul class="breadcrumb">
        <li><a href="../home.html">Home</a></li>
        <li><a href="../categories-grid.html"></a></li>
        <li class="active"></li>
    </ul>
   <%-- <ul class="listing-options">
        <li class="sort-by">
            <label for="sort-by-name">Sort by Name:</label>
            <select ng-model="_query._name" id="sort-by-name">
                <option value="">Newest</option>
                <option value="Sedia">Sedia</option>
                <option value="eh">Eh</option>
                <option value="ooh">Ooh</option>
                <option value="whoop">Whoop</option>
            </select>
            <label for="sort-by-name">Sort by Price:</label>
            <select ng-model="priceMin" id="sort-by-price">
                <option value="">Newest</option>
                <option value="10">> 10</option>
                <option value="20">> 20</option>
                <option value="21">21</option>
                <option value="22">22</option>
            </select>
        </li>
        <li class="show-count">
            <select id="no-of-items">
                <option value="60">60</option>
                <option value="100">100</option>
            </select>
        </li>
    </ul>--%>
</div>
