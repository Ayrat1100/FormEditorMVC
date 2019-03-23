formApp.factory('dataService', function ($http, $q) {
    return {
        getData: function () 
        {
            var deferred = $q.defer();
            $http({ method: 'GET', url: 'http://localhost:53662/api/Forms/1' }).
                then(function success(response) 
                {
                    deferred.resolve(response.data);
                });

            return deferred.promise;
        }
    }
})