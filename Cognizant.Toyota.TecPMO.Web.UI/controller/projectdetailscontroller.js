(function () {
    'use strict';

    angular
        .module('app')
        .controller('projectdetailscontroller', projectdetailscontroller);

    projectdetailscontroller.$inject = ['ProjectService', '$rootScope', '$uibModal', '$window'];

    function projectdetailscontroller(ProjectService, $rootScope, $uibModal, $window) {
        var vm = this;
        vm.loading = false;
        vm.files = {};
        LoadProject();

        function LoadProject() {
            vm.loading = true;
            ProjectService.GetAllProjectDetails()
                           .then(function (data) {
                               console.log(data)
                               vm.projectdetails = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };
        $rootScope.getFileDetails = function (e) {
            vm.files = e.files[0];            
        };
      
        $rootScope.addRandomItem = function () {
            modalPopup().result
       .then(function (data) {
           console.log(data);
       })
       .then(null, function (reason) {
           console.log(data);
       });            
        }
       
        var modalPopup = function () {
            return $rootScope.modalInstance = $uibModal.open({
                backdrop: true,
                keyboard: true,
                backdropClick: true,
                templateUrl: 'view/modal/projectdetailsmodel.html',
                controller: 'projectdetailscontroller',
                controllerAs: $rootScope,
                size: 'lg'
            });
        };

        var modalPopupedit = function () {
            return $rootScope.modalInstanceedit = $uibModal.open({
                backdrop: true,
                keyboard: true,
                backdropClick: true,
                templateUrl: 'view/modal/projectdetailseditmodel.html',
                controller: 'projectdetailscontroller',
                controllerAs: $rootScope,
                size: 'lg'
            });
        };

        $rootScope.addItem = function (projectInfo) {
            console.log(projectInfo);
            if (vm.files) {
                //projectInfo.URL = vm.files.name
                ProjectService.UploadProjectDocuments(vm.files)
                         .then(function (data) {
                             console.log(data);
                         }).finally(function () {
                             vm.loading = false;
                         });
            }
            ProjectService.SaveProjectDetails(projectInfo)
                         .then(function (data) {                            
                             LoadProject();
                             console.log(data)
                             $rootScope.modalInstance.dismiss('No Button Clicked');
                         }).finally(function () {
                             vm.loading = false;
                         });

        },

        $rootScope.removeItem = function (projectid) {
            var deleteProject = $window.confirm('Are you sure you want to delete this?');
            console.log(projectid);
            if (deleteProject) {
                ProjectService.DeleteProjectDetails(projectid)
                               .then(function (data) {                                   
                                   LoadProject();
                                   console.log(data)
                               }).finally(function () {
                                   vm.loading = false;
                               });
            }
            else {
                LoadProject();
            }

        },
         $rootScope.ok = function () {             
             $rootScope.modalInstance.dismiss('No Button Clicked')

         },

        $rootScope.editItem = function (projectInfo) {
            console.log(projectInfo);
            $rootScope.editprojectInfo = projectInfo;
            modalPopupedit().result
                  .then(function (data) {
                     console.log(data);
                     })
                .then(null, function (reason) {
                     console.log(data);
                });        

            
        },
        $rootScope.updateItem = function (projectInfo) {
            console.log(projectInfo);
            ProjectService.UpdateProjectDetails(projectInfo)
                           .then(function (data) {
                               console.log(data)
                               LoadProject();
                               $rootScope.modalInstanceedit.dismiss('No Button Clicked')
                           }).finally(function () {
                               vm.loading = false;
                           });
        }

        $rootScope.editok = function () {
            $rootScope.modalInstanceedit.dismiss('No Button Clicked')

        }
        LoadProject();
    }
    

})();