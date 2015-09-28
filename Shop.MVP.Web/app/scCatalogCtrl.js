﻿
app.controller('scCatalogCtrl', function ($scope, catalog, $http, $filter) {

    // Recupera il nome categoria dall'url ed esegue la chiamata Ajax
    $scope.categoryName = $filter('_uriseg')(1);

    if ($scope.categoryName != false) {
        $http({
            url: "/WCFService/CatalogDataService.svc/GetProductsByCategoryName",
            method: "GET",
            params: { categoryName: $scope.categoryName }
        }).success(function (data) {
            $scope.catalog = data;
        });
    }
    $scope.categoryName = "dummy";
    $scope.totalCartItems = ($scope.cartProducts && $scope.cartProducts.length > 1) ? $scope.cartProducts.length + 1 : 0;

    // TODO: Recuperare i valori seguenti dal DB
    $scope.brands = ['Patrizia Azzi', 'Fly Flot', 'In Blu'];
    $scope.colors = ['Bianco', 'Nero', 'Rosso', 'Avio'];
    // Donna Default
    $scope.sizes = ['34', '35', '36', '37', '38', '39', '40', '41'];
    if ($scope.categoryName.indexOf("uomo") > -1) {
        $scope.sizes = ['39', '40', '41', '42', '43', '44', '45', '46'];
    }
    else if ($scope.categoryName.indexOf("bambino") > -1) {
        $scope.sizes = ['20', '21', '22', '23', '24', '25', '26', '27'];
    }

    //$scope.filterPrice = 0;
    $scope.filter = { name: "all" };

    // Filtro Marca
    $scope.selectedBrands = [];
    $scope.filterByBrands = function (element) {
        if ($scope.filter.name == "all" || $scope.filter.name == "" || $scope.selectedBrands.length == 0) return true;
        else {
            var ret = false;
            angular.forEach($scope.selectedBrands, function (brand) {
                if (element._name.indexOf(brand) > -1) ret = true;
            });
            return ret;
        }
    };
    $scope.toggleSelectionBrand = function toggleSelectionBrand(brandName) {
        $scope.filter.name = brandName;
        var idx = $scope.selectedBrands.indexOf(brandName);
        if (idx > -1) {
            $scope.selectedBrands.splice(idx, 1);
        }
        else {
            $scope.selectedBrands.push(brandName);
        }
    };

    // Filtro Colore
    $scope.selectedColors = [];
    $scope.filterByColors = function (element) {
        if ($scope.filter.name == "all" || $scope.filter.name == "" || $scope.selectedColors.length == 0) return true;
        else {
            var ret = false;
            angular.forEach($scope.selectedColors, function (filter) {
                if (element._name.indexOf(filter) > -1) ret = true;
            });
            return ret;
        }
    };
    $scope.toggleSelectionColor = function toggleSelectionColor(color) {
        $scope.filter.name = color;
        var idx = $scope.selectedColors.indexOf(color);

        // is currently selected
        if (idx > -1) {
            $scope.selectedColors.splice(idx, 1);
        }
            // is newly selected
        else {
            $scope.selectedColors.push(color);
        }
    };

    // Filtro Prezzo
    $scope.priceRange = [0, 200];
    $scope.filterPrice = function (element) {
        return element._price > $scope.priceRange[0] && element._price < $scope.priceRange[1] ? true : false;
    };

    // Filtro Taglia
    $scope.selectedSizes = [];
    $scope.toggleSelectionSize = function toggleSelectionSize(size) {
        $scope.filter.name = size;
        var idx = $scope.selectedSizes.indexOf(size);

        // is currently selected
        if (idx > -1) {
            $scope.selectedSizes.splice(idx, 1);
        }
            // is newly selected
        else {
            $scope.selectedSizes.push(size);
        }
    };
    $scope.filterBySize = function (element) {
        if ($scope.selectedSizes.length == 0) return true;
        else {
            var ret = false;
            angular.forEach($scope.selectedSizes, function (selectedSize) {
                if (element["_tg_" + selectedSize] > 1) ret = true;
            });
            return ret;
        }
    };

    // inizializzare il carrello con i dati presenti in sessione
    $scope.cartProducts = [];
    $scope.totalCartPrice = 0;
    $http({
        url: "/WCFService/CatalogDataService.svc/GetProductsFromSessionCart",
        method: "GET"
    }).success(function (data) {
        if (data) {
            $scope.cartProducts = data;
            
            angular.forEach($scope.cartProducts, function (p) {
                $scope.totalCartItems += p.qta;
            });
            $scope.totalCartPrice = 0;
            angular.forEach($scope.cartProducts, function (p) {
                $scope.totalCartPrice += p.qta * p.price;
            });

        }
    });

    $scope.addProductToCartFromUI = function (id, name, price) {
        // recupero la size da $scope.sizeName
        var product = { _product_id: id, _price: price, _name: name };
        $scope.addProductToCart(product);
    }

    $scope.addProductToCart = function (product) {

        var addedToExistingItem = false;
        for (var i = 0; i < $scope.cartProducts.length; i++) {
            if ($scope.cartProducts[i].id == product._product_id && $scope.cartProducts[i].size == $scope.selectedSize) {
                $scope.cartProducts[i].qta++;
                addedToExistingItem = true;
                break;
            }
        }
        if (!addedToExistingItem) {
            $scope.cartProducts.push({
                qta: 1, id: product._product_id, price: product._price, name: product._name, size: $scope.selectedSize
            });         
        }
        $scope.totalCartPrice = 0;
        angular.forEach($scope.cartProducts, function (p) {
            $scope.totalCartPrice += p.qta * p.price;
        });
        $scope.saveSessionCart();
        $scope.totalCartItems += 1;
    };

    $scope.removeProductToCart = function (product) {

        for (var i = 0; i < $scope.cartProducts.length; i++) {
            if ($scope.cartProducts[i].id == product._product_id) {
                $scope.cartProducts.splice(i, 1);
                $scope.saveSessionCart();
                break;
            }
        }
    };
    // Viene Salvato l'intero carrello in sessione (non il singolo prodotto)
    $scope.saveSessionCart = function () {
        $http({
            url: "/WCFService/CatalogDataService.svc/AddProductToSessionCart",
            method: "POST",
            data: $scope.cartProducts
        }).success(function (data) {
            // toastr Message
        });
    }

    $scope.getTotalCartItems = function () {
        $scope.totalCartItems = $scope.cartProducts.length - 1;
    }

    $scope.sizeNotChecked = true;
    $scope.selectedSize = "";

    $scope.selectSize = function (sizeName) {
        $scope.sizeNotChecked = false;
        $scope.selectedSize = sizeName;
    };

});

