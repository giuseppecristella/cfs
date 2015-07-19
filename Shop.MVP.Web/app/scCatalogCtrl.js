

app.controller('scCatalogCtrl', function ($scope, catalog, $http, $filter) {
    $scope.model = { id: 1, name: "Giuseppe" };
    $scope.products = [{ id: 1, name: "Giu" }, { id: 2, name: "Giu2" }];
    //$scope.catalog = catalog.query();
    //var a = $location.search();

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

    $scope.categories = ['Patrizia Azzi', 'Fly Flot', 'In Blu'];
    $scope.colors = ['Bianco', 'Nero', 'Rosso', 'Avio'];
    $scope.category = { selected: 'all' };

    $scope.filterPrice = 0;
    $scope.filter = { name: "all" };
    $scope.filters = ["Sedia", "Tavolino", "Lume"];

    $scope.selection = [];
    $scope.filterFunction = function (element) {
        if ($scope.filter.name == "all" || $scope.filter.name == "" || $scope.selection.length == 0) return true;
        else {
            var ret = false;
            angular.forEach($scope.selection, function (filter) {
                if (element._name.indexOf(filter) > -1) ret = true;
            });
            return ret;
        }

    };
    $scope.toggleSelection = function toggleSelection(name) {
        $scope.filter.name = name;
        var idx = $scope.selection.indexOf(name);

        // is currently selected
        if (idx > -1) {
            $scope.selection.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.selection.push(name);
        }
    };


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
   

    $scope.my = { favorite: "" };

    $scope.priceRange = [0, 200];
    $scope.filterPrice = function (element) {
        return element._price > $scope.priceRange[0] && element._price < $scope.priceRange[1] ? true : false;
    };

    //$scope.filterColor = function (element) {
    //    return element._name > $scope.priceRange[0] && element._price < $scope.priceRange[1] ? true : false;
    //};

});

