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
        service.GetAllVideoDetail = GetAllVideoDetail;

        return service;

        function GetAllProcessTemplate() {
            return $http.get(serviceURL + 'api/Process/GetAllProcessTemplate').then(handleSuccess, handleError);
        }
        function GetAllVideoDetail() {
            return $http.get(serviceURL + 'api/Process/GetAllVideoDetail').then(handleSuccess, handleError);
        }
        // private functions
    }

})();
