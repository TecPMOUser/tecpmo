(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthService', AuthService);

    AuthService.$inject = ['$http', '$httpParamSerializer'];
    function AuthService($http, $httpParamSerializer) {

        $http.defaults.headers.common = {};
        $http.defaults.headers.post = {};
        $http.defaults.headers.put = {};
        $http.defaults.headers.patch = {};
        $http.defaults.headers.post = {};

        var service = {};
        var serviceURL = globalServiceURL;
        service.GetCurrentUser = GetCurrentUser;
        return service;

        function GetCurrentUser() {
            return $http.get(serviceURL + 'api/Auth/GetUser').then(handleSuccess, handleError);
        }
    }

})();
