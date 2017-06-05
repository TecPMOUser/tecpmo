(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProcessService', ProcessService);

    ProcessService.$inject = ['$http', '$httpParamSerializer'];
    function ProcessService($http, $httpParamSerializer) {

        $http.defaults.headers.common = {};     
        $http.defaults.headers.post = {};
        $http.defaults.headers.put = {};
        $http.defaults.headers.patch = {};
        $http.defaults.headers.post = {};


        var service = {};
        var serviceURL = globalServiceURL;

        service.GetAllProcessTemplate = GetAllProcessTemplate;
        

        return service;

        function GetAllProcessTemplate() {
            return $http.get(serviceURL + 'api/Process/GetAllProcessTemplate').then(handleSuccess, handleError('Error getting all Process Template'));
        }

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
