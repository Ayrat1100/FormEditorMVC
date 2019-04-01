'use strict'
formApp.controller('FormController',
    function FormController($scope, dataService, $location, $http) {
        var promiseObj = dataService.getData($location.path());
        promiseObj.then(function (value) {
            $scope.datas = value;
        });

        $scope.form = {};
        $scope.save = function (form, userForm) {
            if (userForm.$valid) {
                $http.post("http://localhost:53662/api/Forms/PostUserForm", form).then(function success(response) {
                    $scope.response = response.data;
                    if (response.data === "Ok") {
                        note({
                            content: "<p>Ваши данные отправлены. Спасибо за заполнение формы!</p>",
                            type: "success",
                            time: 5
                        });
                    }
                    else {
                        note({
                            content: "<p>Ошибка при сохранении!</p>",
                            type: "error",
                            time: 5
                        });
                    }
                });
            }
        };
    }
)



