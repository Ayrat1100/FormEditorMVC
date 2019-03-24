'use strict'

formApp.controller('SaveController',
    function SaveController($scope, dataService, $location) {
        $scope.form = {};
        $scope.submit = function (form, userForm){
                /////////*******///// */
                console.log(this.form);
        };
    },
    
)