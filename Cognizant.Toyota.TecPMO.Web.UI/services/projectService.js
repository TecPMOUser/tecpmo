﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProjectService', ProjectService);

    ProjectService.$inject = ['$http','$httpParamSerializer'];
    function ProjectService($http, $httpParamSerializer) {

        $http.defaults.headers.common = {};
        $http.defaults.headers.post = {};
        $http.defaults.headers.put = {};
        $http.defaults.headers.patch = {};
        $http.defaults.headers.post = {};
       
        var service = {};
        var serviceURL = globalServiceURL;

        service.GetAllProject = GetAllProject;
        service.GetAllADProject = GetAllADProject;
        service.GetAllAVMProject = GetAllAVMProject;
        service.SaveProject = SaveProject;
        service.SaveAccolades = SaveAccolades;
        service.GetADProjectStatus = GetADProjectStatus;
        service.GetAVMProjectStatus = GetAVMProjectStatus;
        service.GetAllAccolades = GetAllAccolades;
        service.GetProjectStatus = GetProjectStatus;
        service.GetADProjectCalendar = GetADProjectCalendar;
        service.GetAVMProjectCalendar = GetAVMProjectCalendar;
        service.GetProjectDetailsById = GetProjectDetailsById;
        service.GetAllProjectDetails = GetAllProjectDetails;
        service.UpdateProjectDetails = UpdateProjectDetails;
        service.SaveProjectDetails = SaveProjectDetails;
        service.DeleteProjectDetails = DeleteProjectDetails;
        service.UploadProjectDocuments = UploadProjectDocuments;
        service.GetDocumentsForProject = GetDocumentsForProject;
        service.RemoveAccolades = RemoveAccolades;

        return service;

        function GetAllProjectDetails() {
            return $http.get(serviceURL + 'api/ProjectDetails/GetAllProjectDetails').then(handleSuccess, handleError);
        }
        function GetDocumentsForProject(projectId) {
            return $http.get(serviceURL + 'api/ProjectDetails/GetDocumentsForProject', { params: { projectId: projectId } }).then(handleSuccess, handleError('Error getting all project'));
        }

        function UploadProjectDocuments(files) {
           
            var fd = new FormData();           
                fd.append("files", files)            
           
                return $http.post(serviceURL + 'api/ProjectDetails/UploadFile', fd, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                });

        }

        function GetADProjectCalendar() {
            return $http.get(serviceURL + 'api/Project/GetADProjectCalendar').then(handleSuccess, handleError);
        }
        function GetAVMProjectCalendar() {
            return $http.get(serviceURL + 'api/Project/GetAVMProjectCalendar').then(handleSuccess, handleError);
        }

        function GetAllAccolades() {
            return $http.get(serviceURL + 'api/Accolades/GetAllAccolades?c=' + new Date()).then(function (response) {
                return response.data;
            }, handleError);
        }

        function SaveAccolades(dataProject, typeobj) {
            return $http({
                method: "POST",
                url: serviceURL + 'api/Accolades/SubmitAccolades',
                data: { accolades: dataProject, type: typeobj },
                headers: {
                    'Content-Type': 'application/json'
                }



            });
        }
        function UpdateProjectDetails(projectInfo, typeobj) {            
            return $http({
                method: "POST",
                url: serviceURL + 'api/Projectdetails/UpdateProjectDetails',
                data: {
                    ID: projectInfo.ID, ProjectID:projectInfo.ProjectID,ESAProjectName: projectInfo.ESAProjectName, ProjectShortName: projectInfo.ProjectShortName,
                    ProjectDescription: projectInfo.ProjectDescription, ProjectManagerID: projectInfo.ProjectManagerID, ProjectManagerName: projectInfo.ProjectManagerName,
                    ProjectDMName:projectInfo.ProjectDMName},
                headers: {
                    'Content-Type': 'application/json'
                }

            });

        }
        function DeleteProjectDetails(projectid) {
            return $http.get(serviceURL + 'api/Projectdetails/DeleteProjectDetails', { params: { ID: projectid } }).then(handleSuccess, handleError);
        }
        function SaveProjectDetails(projectInfo, typeobj) {
            return $http({
                method: "POST",
                url: serviceURL + 'api/Projectdetails/SaveProjectDetails',
                data: {
                    ID: projectInfo.ID, ProjectID: projectInfo.ProjectID, ESAProjectName: projectInfo.ESAProjectName, ProjectShortName: projectInfo.ProjectShortName,
                    ProjectDescription: projectInfo.ProjectDescription, ProjectManagerID: projectInfo.ProjectManagerID, ProjectManagerName: projectInfo.ProjectManagerName,
                    ProjectDMName: projectInfo.ProjectDMName, URl: projectInfo.URL
                },              
                headers: {
                    'Content-Type': 'application/json'
                }
            });

        }
        function GetAllADProject() {
            return $http.get(serviceURL + 'api/Project/GetAllADProject').then(handleSuccess, handleError);
        }
        function GetAllProject() {
            return $http.get(serviceURL + 'api/Project/GetAllProject').then(handleSuccess, handleError);
        }
        function GetAllAVMProject() {
            return $http.get(serviceURL + 'api/Project/GetAllAVMProject').then(handleSuccess, handleError);
        }

        function GetADProjectStatus() {
            return $http.get(serviceURL + 'api/Project/GetADProjectStatus').then(handleSuccess, handleError);
        }
        function GetProjectStatus() {
            return $http.get(serviceURL + 'api/Project/GetProjectStatus').then(handleSuccess, handleError);
        }
        function GetAVMProjectStatus() {
            return $http.get(serviceURL + 'api/Project/GetAVMProjectStatus').then(handleSuccess, handleError);
        }

        function SaveProject(dataProject,typeobj) {
            
           // console.log(project)
            return $http({
                method: "POST",
                url: serviceURL + 'api/Project/SubmitProject',
                data: { project: dataProject, type: typeobj },
                headers: {
                    'Content-Type': 'application/json'
                }
               
            
                
            });
        }

        function GetProjectDetailsById(ID) {
            return $http.get(serviceURL + 'api/Project/GetProjectDetailsById', { params: { id: ID } }).then(handleSuccess, handleError);
        }
       
        function RemoveAccolades(accoladesdetails) {
            return $http({
                method: "POST",
                url: serviceURL + 'api/Accolades/RemoveAcclodates',
                data: { ID: accoladesdetails.ID, ProjectID: accoladesdetails.projectID, ProjectName: accoladesdetails.ProjectName },
                headers: {
                    'Content-Type': 'application/json'
                }



            });
        }
        


        //function handleSuccess(res) {
        //    return res.data;
        //}

        //function handleError(error) {
        //    return function () {
        //        return { success: false, message: error };
        //    };
        //}
    }

})();
