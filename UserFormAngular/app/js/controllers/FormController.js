'use strict'

formApp.controller('FormController',
    function FormController($scope, dataService) {

        var promiseObj = dataService.getData();
        promiseObj.then(function (value) {
            $scope.question = value;
        });
    }
)