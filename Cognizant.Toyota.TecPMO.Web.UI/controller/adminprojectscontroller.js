(function () {
    'use strict';

    angular
        .module('app')
        .controller('AdminProjectsController', AdminProjectsController);

    AdminProjectsController.$inject = ['$rootScope', '$scope', 'OperationalCornerService', '$window'];
    function AdminProjectsController($rootScope, $scope,  OperationalCornerService, $window) {
        var vm = this;
        vm.files = null;
        $scope.selectedProjects = [];
        LoadProjectDetails();       

        function LoadProjectDetails() {
            vm.loading = true;
            OperationalCornerService.GetAllProjectDetails()
                           .then(function (data) {
                               angular.forEach(data, function (item) {
                                   item.ProjectDisplayText = item.ProjectID + '-' + item.ProjectName;
                               });
                               vm.projectDetails = data;
                               $scope.projectDetails = data;
                               console.log($scope.projectDetails);
                           }).finally(function () {
                               vm.loading = false;
                           });

        };
       

        vm.getFileDetails = function (e) {
            vm.files = e.files[0];

        };
        vm.UpdateDocument = function (project) {
            if (vm.files) {                
                OperationalCornerService.UploadProjectDocuments(vm.files)
                         .then(function (data) {
                             vm.path = data.data;
                             project.DocumentLocation = vm.path;
                             project.Projectid = $scope.selectedProjects[0].ProjectID;
                             SaveProjectDocuments(project);
                             console.log(data);
                         }).finally(function () {
                             vm.loading = false;
                         });
            }          

        }
        function SaveProjectDocuments(project) {
            OperationalCornerService.SaveProjectDetails(project)
                       .then(function (data) {
                           LoadProjectDetails();
                           $window.location.href = '#/operationalcorner/viewprojects';
                           console.log(data)
                       }).finally(function () {
                           vm.loading = false;
                       });
        }

        vm.SubmitValue = function () {

            if (vm.files) {
                vm.loading = true;
                var reader = new FileReader();
                reader.onload = function (e) {
                    var data = e.target.result;
                    var arr = fixdata(data);
                    var workbook = XLSX.read(btoa(arr), { type: 'base64' });
                    var first_sheet_name = workbook.SheetNames[0];
                    var dataObjects = XLSX.utils.sheet_to_json(workbook.Sheets[first_sheet_name]);
                    if (dataObjects.length > 0) {
                        OperationalCornerService.SaveProjectDetails(dataObjects)
                           .then(function (data) {
                               angular.element("input[type='file']").val(null);
                               vm.files = null;
                               LoadProjectDetails();
                           }).finally(function () {
                               vm.loading = false;
                           });

                    } else {
                        console.log('Error : Something Wrong !');
                    }
                }
                reader.onerror = function (ex) {
                    console.log('Error : Something Wrong !');
                }
                reader.readAsArrayBuffer(vm.files);
            };


            function fixdata(data) {
                var o = "", l = 0, w = 10240;
                for (; l < data.byteLength / w; ++l) o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w, l * w + w)));
                o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w)));
                return o;
            };

        }



        vm.DownloadTemplate = function () {
            window.location.assign('/template/ProjectDetial.xlsx');
        }
    }

})();