'use strict'
var formContainer = document.getElementsByClassName('form-container')[0];

formApp.controller('FormController',
    function FormController($scope, dataService, $location,  $http) {
        var promiseObj = dataService.getData($location.path());
        promiseObj.then(function (value) {
            $scope.datas = value;
        });

        $scope.form={};
    $scope.save = function (form,userForm){
        
        if(userForm.$valid){
            $http.post("http://localhost:53662/api/Forms/PostUserForm", form).then(function success (response) {
                $scope.response=response.data;
                alert();
            });
        }
    };
    }
)



