'use strict'

var formApp = angular.module('formApp', ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when('/Forms',
            {
                templateUrl: 'views/Form.html',
                controller: 'FormController'
            });
    });
