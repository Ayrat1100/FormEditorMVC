'use strict'
var formContainer = document.getElementsByClassName('form-container')[0];
formApp.controller('FormController',
    function FormController($scope, dataService, $location) {
        var promiseObj = dataService.getData($location.path());
        promiseObj.then(function (value) {
            $scope.datas = value;
        });
    },
    
)



