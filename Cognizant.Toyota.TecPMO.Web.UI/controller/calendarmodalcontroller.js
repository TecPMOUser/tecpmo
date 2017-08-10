(function () {
    'use strict';

    angular
        .module('app')
        .controller('CalendarModalController', CalendarModalController);

    CalendarModalController.$inject = ['ProjectService', '$uibModalInstance', 'ID','Title','Stage'];

    function CalendarModalController(ProjectService, $uibModalInstance, ID,Title,Stage) {
        var vm = this;
        vm.Title = Title;
        vm.Stage = Stage;
        LoadProjectDetails(ID);

        function LoadProjectDetails(ID) {
            
            ProjectService.GetProjectDetailsById(ID)
                           .then(function (data) {
                               vm.projectInfo = data;
                           });

        }
        vm.ok = function () {
            $uibModalInstance.dismiss('cancel');
        };

    }
})();




