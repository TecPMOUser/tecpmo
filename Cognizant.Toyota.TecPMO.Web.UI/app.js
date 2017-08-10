(function () {
    'use strict';

    angular
        .module('app', ['ngRoute', 'ngCookies', 'ui.calendar', 'ui.bootstrap', 'ui.bootstrap.modal', 'angularMoment', 'bootstrapLightbox', 'angularjs-dropdown-multiselect'])
        .config(config);

    //.run(run);

    config.$inject = ['$routeProvider', '$locationProvider', '$httpProvider', '$qProvider'];


    function config($routeProvider, $locationProvider, $httpProvider, $qProvider) {

        $qProvider.errorOnUnhandledRejections(false);

        $httpProvider.defaults.headers.common = {};
        $httpProvider.defaults.headers.post = {};
        $httpProvider.defaults.headers.put = {};
        $httpProvider.defaults.headers.patch = {};


        $locationProvider.html5Mode(false).hashPrefix('');


        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'view/home/home.view.html',
                controllerAs: 'vm'
            })
            .when('/upload-file', {
                controller: 'UploadController',
                templateUrl: 'view/upload/upload.html',
                controllerAs: 'vm'
            })
            .when('/project', {
                controller: 'ProjectController',
                templateUrl: 'view/project/project.html',
                controllerAs: 'vm'
            })
            .when('/projectdeliverymilestone', {
                controller: 'ProjectController',
                templateUrl: 'view/projectdelivery/projectdelivery.html',
                controllerAs: 'vm'
            })
            .when('/deliverycalendar', {
                controller: 'ADCalendarController',
                templateUrl: 'view/projectdelivery/deliverycalendar.html',
                controllerAs: 'vm'
            })
            .when('/avmdeliverycalendar', {
                controller: 'AVMCalendarController',
                templateUrl: 'view/AVMProjectDelivery/AVMProjectDeliveryCalendar.html',
                controllerAs: 'vm'
            })
            .when('/avmprojectdeliverymilestone', {
                controller: 'ProjectController',
                templateUrl: 'view/AVMProjectDelivery/AVMProjectDelivery.html',
                controllerAs: 'vm'
            })
             .when('/peoplecorner/accolades', {
                 controller: 'HomeController',
                 templateUrl: 'view/peoplecorner/accolades.html',
                 controllerAs: 'vm'
             })
            .when('/processtemplate', {
                controller: 'ProcessController',
                templateUrl: 'view/process/processtemplate.html',
                controllerAs: 'vm'
            })
             .when('/projectdetails', {
                 controller: 'projectdetailscontroller',
                 templateUrl: 'view/project/projectdetails.html',
                 controllerAs: 'vm'
             })
             .when('/operationalcorner/viewprojects', {
                 controller: 'projectdetailscontroller',
                 templateUrl: 'view/operationalcorner/viewprojects.html',
                 controllerAs: 'vm'
             })
            .when('/operationalcorner/adminprojects', {
                controller: 'AdminProjectsController',
                templateUrl: 'view/operationalcorner/adminprojects.html',
                controllerAs: 'vm'
            })
            .when('/operationalcorner/manageprojects', {
                controller: 'AdminProjectsController',
                templateUrl: 'view/operationalcorner/manageprojects.html',
                controllerAs: 'vm'
            }) 
            .when('/peoplecorner/toyotavideos', {
                controller: 'ProcessController',
                templateUrl: 'view/peoplecorner/toyotavideos.html',
                controllerAs: 'vm'
            })
             .when('/peoplecorner/breaksession', {
                 controller: 'ProcessController',
                 templateUrl: 'view/peoplecorner/breaksession.html',
                 controllerAs: 'vm'
             })
            .otherwise({ redirectTo: '/' });
    }

    // run.$inject = ['$rootScope', '$location', '$cookies', '$http'];
    // function run($rootScope, $location, $cookies, $http) {
    // keep user logged in after page refresh
    /*$rootScope.globals = $cookies.getObject('globals') || {};
    if ($rootScope.globals.currentUser) {
        $rootScope.globals.currentUser='Vinoth V'
    }*/

    /* $rootScope.$on('$locationChangeStart', function (event, next, current) {
         // redirect to login page if not logged in and trying to access a restricted page
         var restrictedPage = $.inArray($location.path(), ['/login', '/register']) === -1;
         var loggedIn = $rootScope.globals.currentUser;
         if (restrictedPage && !loggedIn) {
             $location.path('/');
         }
     });*/
    //}

})();