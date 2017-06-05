(function () {
    'use strict';

    angular
        .module('app')
        .controller('CalendarModalController', CalendarModalController);

    CalendarModalController.$inject = ['ProjectService', '$uibModalInstance', 'projectId'];

    function CalendarModalController(ProjectService, $uibModalInstance, projectId) {
        var vm = this;
        LoadProjectDetails(projectId);

        function LoadProjectDetails(projectId) {
            
            ProjectService.GetProjectDetailsById(projectId)
                           .then(function (data) {
                               vm.projectInfo = data;
                           });

        }
        vm.ok = function () {
            $uibModalInstance.dismiss('cancel');
        };

    }
})();




