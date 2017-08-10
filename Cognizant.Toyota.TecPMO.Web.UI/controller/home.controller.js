(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$rootScope', 'ProjectService', '$uibModal', '$window', 'moment','$route'];
    function HomeController($rootScope, ProjectService, $uibModal, $window, moment, $route) {
        var vm = this;
        vm.files = null;
        LoadADHomePage();
        //LoadAVMHomePage();
        //LoadAccolades();

        var savehtml="<td><button type='button' ng-click='editaccoladesItem(accolades)' class='btn btn-sm btn-danger'>"+
                      "<i class='glyphicon glyphicon-ok-circle'></i></button></td><td><button type='button' class='btn btn-sm btn-danger'>"+
                      "<i class='glyphicon glyphicon-remove-circle'></i></button></td>";
        var edithtml= "<td><button type='button' ng-click='removeItem(accolades)' class='btn btn-sm btn-danger'><i class='glyphicon glyphicon-trash'></i>"+
                       "</button></td><td><button type='button' id='editbutton' ng-click='editaccoladesItem(accolades)' class='btn btn-sm btn-warning'>"+
                       "<i class='glyphicon glyphicon-edit'></i></button></td>";

            function LoadADHomePage() {
                vm.loading = true;
                ProjectService.GetProjectStatus()
                               .then(function (data) {
                                   vm.project = data.ADProject;
                                   vm.avmproject = data.AVMProject;
                                   vm.accolades = data.Accolades;

                                   angular.forEach(vm.accolades, function (value) {
                                       value.MomentText = moment(new Date(value.Date)).fromNow();
                                   });

                               }).finally(function () {
                                   vm.loading = false;
                               });

            };
            function LoadAccolades() {
                vm.loading = true;
                ProjectService.GetAllAccolades()
                               .then(function (data) {
                                   vm.accolades = data.Accolades;
                               }).finally(function () {
                                   vm.loading = false;
                               });

            };
            $rootScope.getFileDetails = function (e) {
                vm.files = e.files[0];

            };
           
            $rootScope.addRandomItem = function () {
                modalPopup();
            };
            $rootScope.removeItem = function (row) {
                ProjectService.RemoveAccolades(row)
                              .then(function (data) {                                  
                                  vm.loading = true;                                  
                                  LoadAccolades();
                                  $route.reload();
                              }).finally(function () {
                                  vm.loading = false;
                              });
            };

            var modalPopup = function () {
                return $rootScope.modalInstance = $uibModal.open({
                    backdrop: true,
                    keyboard: true,
                    backdropClick: true,
                    templateUrl: 'view/modal/accoladesmodel.html',
                    controller: 'HomeController',
                    controllerAs: $rootScope,
                    size: 'lg'
                });
            };        

            $rootScope.SubmitValue = function () {

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
                            ProjectService.SaveAccolades(dataObjects)
                               .then(function (data) {
                                   angular.element("input[type='file']").val(null);
                                   vm.files = null;
                                   vm.loading = true;
                                   $rootScope.ok();
                                   LoadAccolades();
                                   $route.reload();
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
                }
            };
            $rootScope.ok = function () {
                $rootScope.modalInstance.dismiss('No Button Clicked')

            };

                function fixdata(data) {
                    var o = "", l = 0, w = 10240;
                    for (; l < data.byteLength / w; ++l) o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w, l * w + w)));
                    o += String.fromCharCode.apply(null, new Uint8Array(data.slice(l * w)));
                    return o;
                };

                $rootScope.editaccoladesItem = function (accolades) {
                    vm.oldaccolades = accolades;
                    document.getElementById(accolades.ID).innerHTML = "";
                    document.getElementById(accolades.ID).innerHTML = savehtml;
                }


                $rootScope.DownloadTemplate = function () {
                    window.location.assign('/template/Accolades.xlsx');
                };
    }

})();