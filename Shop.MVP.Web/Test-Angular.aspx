<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test-Angular.aspx.cs" Inherits="Shop.Web.Mvp.Test_Angular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body ng-app="app">
    <form id="form1" runat="server">
        <div ng-controller="scCatalogCtrl">
            <div ng-repeat="product in catalog">
                {{ product._name }}
            </div>
        </div>
    </form>
    <script src="/Scripts/jquery-1.7.1.js"></script>
    <script src="/Scripts/jquery-1.8.2.js"></script>
    <script src="/assets/js/jquery-ui.min.js"></script>
    <script src="/Scripts/angular.js"></script>
    <script src="/Scripts/angular-resource.min.js"></script>
    <script src="/Scripts/slider.js"></script>
    <script src="/app/app.js"></script>
    <script src="/app/data.js"></script>
    <script src="/app/scCatalogCtrl.js"></script>
</body>
</html>
