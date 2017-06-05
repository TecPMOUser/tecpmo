(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProcessController', ProcessController);

    ProcessController.$inject = ['ProcessService', '$rootScope'];
    function ProcessController(ProcessService, $rootScope) {
        var vm = this;
        vm.loading = false;


        LoadProcess();
        

        function LoadProcess() {
            vm.loading = true;
            ProcessService.GetAllProcessTemplate()
                           .then(function (data) {
                               console.log(data)
                               vm.processTemplate = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };
        
        vm.DownloadTemplate = function (url) {
            window.location.assign(url);
        }

    }

})();