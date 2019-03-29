'use strict'

formApp.controller('SaveController',
function SaveController($scope,  $http){
         
    $scope.form={};
    $scope.save = function (form,userForm){
        alert();
        if(userForm.$valid){
             
            $http.post("http://localhost:53662/api/Forms", form).then(function success (response) {
                $scope.response=response.data;
                 
            });
        }
    };
}
    
)