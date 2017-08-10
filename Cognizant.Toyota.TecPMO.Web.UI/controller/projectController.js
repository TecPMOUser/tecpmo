﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProjectController', ProjectController);

    ProjectController.$inject = ['ProjectService', '$rootScope'];
    function ProjectController(ProjectService, $rootScope) {
        var vm = this;
        vm.loading = false;
        vm.files = null;
        vm.adproject = null;
        vm.avmproject = null;
        vm.project = null;
        

        LoadProject();
        LoadADProject();
        LoadAVMProject();

        function LoadProject() {
            vm.loading = true;
            ProjectService.GetAllProject()
                           .then(function (data) {
                               console.log(data)
                               vm.project = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };

        function LoadADProject() {
            vm.loading = true;
            ProjectService.GetAllADProject()
                           .then(function (data) {
                               console.log(data)
                               vm.adproject = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };

        function LoadAVMProject() {
            vm.loading = true;
            ProjectService.GetAllAVMProject()
                           .then(function (data) {
                               console.log(data)
                               vm.avmproject = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };
       

        vm.getFileDetails = function (e) {
            vm.files = e.files[0];

        };

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
                        ProjectService.SaveProject(dataObjects)
                           .then(function (data) {
                               angular.element("input[type='file']").val(null);
                                   vm.files = null;
                                   LoadProject();
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
            window.location.assign('/template/project.xlsx');
        }

    }

})();