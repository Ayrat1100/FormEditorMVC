

formApp.directive("validationData", function () {
    return function (scope, element, attrs) {
        if (scope.dat.Mandatory) {
            element.attr('required', '');
        }
    }
});