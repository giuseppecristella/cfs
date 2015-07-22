
app.controller('scCatalogCtrl', function ($scope, catalog, $http, $filter) {

    // Recupera il nome categoria dall'url ed esegue la chiamata Ajax
    $scope.categoryName = $filter('_uriseg')(1);

    $http({
        url: "/CatalogDataService.svc/GetProductsByCategoryName",
        method: "GET",
        params: { categoryName: $scope.categoryName }
    }).success(function (data) {
        $scope.catalog = data.d;
    });

    //$http.get("/CatalogDataService.svc/GetProducts")
    //    .success(function (data) {
    //        $scope.catalog = data.d;
    //    });

    // TODO: Recuperare i valori seguenti dal DB
    $scope.brands = ['Patrizia Azzi', 'Fly Flot', 'In Blu'];
    $scope.colors = ['Bianco', 'Nero', 'Rosso', 'Avio'];
    $scope.sizes = ['34', '35', '36', '37', '38', '39', '40', '41'];

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

});

