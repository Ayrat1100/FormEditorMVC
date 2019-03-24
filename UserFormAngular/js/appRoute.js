'use strict'

var formApp = angular.module('formApp', ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when('/Forms/:id',
            {
                templateUrl: 'views/Form.html',
                controller: 'FormController'
            });
    });
