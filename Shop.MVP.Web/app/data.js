
// In fase di bootstrap, vengono eseguite tutte le factory. In questo caso
// viene invocato il metodo del Web Service GetProducts, che valorizza lo scope
// relativamente alla variabile catalog che contiene i dati e può 
// essere iniettata in un modulo. 
app.factory('catalog', function($resource) {
    return $resource('/CatalogDataService.svc/GetProducts');
});

 