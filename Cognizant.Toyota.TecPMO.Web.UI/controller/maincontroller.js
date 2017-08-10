(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController);

    MainController.$inject = ['AuthService', '$scope', '$rootScope'];

    function MainController(AuthService, $scope, $rootScope) {
        var vm = this;
        $rootScope.currentUser = {};
        LoadCurrentUserDetails();

        function LoadCurrentUserDetails() {

            AuthService.GetCurrentUser()
                           .then(function (data) {
                               $rootScope.currentUser = data;
                           });

        }
    }
})();
