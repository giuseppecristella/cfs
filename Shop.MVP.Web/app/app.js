var app = angular.module('app', ['ngResource', 'ui.slider','ui.bootstrap.modal']);

//app.value('identity', {});
//app.value('toastr', toastr);

app.factory('notifier', function (toastr) {
    return {
        notify: function(msg) {
            toastr.success(msg);
            console.log(msg);
        }
    };
});


app.filter('toEuros', function () {
    return function (input) {
        return   '€. ' + Number(input).toLocaleString("it-IT", { minimumFractionDigits: 2 });
    };
});