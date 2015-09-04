
app.factory('catalog', function($resource) {
    return $resource('/CatalogDataService.svc/GetProducts');
})