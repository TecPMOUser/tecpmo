(function () {
    'use strict';

    angular
        .module('app')
        .factory('OperationalCornerService', OperationalCornerService);

    OperationalCornerService.$inject = ['$http', '$httpParamSerializer'];
    function OperationalCornerService($http, $httpParamSerializer) {

        $http.defaults.headers.common = {};
        $http.defaults.headers.post = {};
        $http.defaults.headers.put = {};
        $http.defaults.headers.patch = {};
        $http.defaults.headers.post = {};


        var service = {};
        var serviceURL = globalServiceURL;

        service.GetAllProjectDetails = GetAllProjectDetails;
        service.SaveProjectDetails = SaveProjectDetails;
        service.UploadProjectDocuments = UploadProjectDocuments;

        return service;

        function GetAllProjectDetails() {
            return $http.get(serviceURL + 'api/Operational/GetAllProjectDetails').then(handleSuccess, handleError);
        }

        function SaveProjectDetails(dataProject) {
            return $http({
                method: "POST",
                url: serviceURL + 'api/Operational/SaveProjectDetails',
                data: { projectid: dataProject.Projectid, DocumentType: dataProject.DocumentType, DocumentName: dataProject.DocumentName, DocumentLocation: dataProject.DocumentLocation },
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        }
       
        function UploadProjectDocuments(files) {

            var fd = new FormData();
            fd.append("files", files)

            return $http.post(serviceURL + 'api/Operational/UploadFile', fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });

        }

       
    }

})();
