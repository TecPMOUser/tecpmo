(function () {
    'use strict';

    angular
        .module('app')
        .controller('ProcessController', ProcessController);

    ProcessController.$inject = ['ProcessService','$scope', '$rootScope', '$uibModal', '$window', 'Lightbox'];
    function ProcessController(ProcessService, $scope, $rootScope, $uibModal, $window, Lightbox) {
        var vm = this;
        vm.loading = false;


        LoadProcess();
        LoadVideos();
        LoadGallery();
        

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

        function LoadVideos() {
            vm.loading = true;
            ProcessService.GetAllVideoDetail()
                           .then(function (data) {
                               console.log(data)
                               vm.videoDetails = data;
                           }).finally(function () {
                               vm.loading = false;
                           });

        };

        function LoadGallery() {
            $scope.images = [
            {
                'url': '/Tec-PMO-App/gallery-images/1-1600.jpg',
                'thumbUrl': '/Tec-PMO-App/gallery-images/thump/1-1600.jpg'
            },
            {
                'url': '/Tec-PMO-App/gallery-images/2-1600.jpg',
                'thumbUrl': '/Tec-PMO-App/gallery-images/thump/2-1600.jpg'
            },
            {
                'url': '/Tec-PMO-App/gallery-images/3-1600.jpg',
                'thumbUrl': '/Tec-PMO-App/gallery-images/thump/3-1600.jpg'
            },
            {
                'url': '/Tec-PMO-App/gallery-images/4-1600.png',
                'thumbUrl': '/Tec-PMO-App/gallery-images/thump/4-1600.png'
            }];

            $scope.openLightboxModal = function (index) {
                Lightbox.openModal($scope.images, index);
            };
        };

        $rootScope.fnVideoClick = function (videoInfo) {
            $rootScope.modelVideoInfo = videoInfo;
            modalPopup();
        }

        $rootScope.close = function () {
            $rootScope.modalInstance.dismiss('No Button Clicked');
        }
        $rootScope.ok = function () {
            $rootScope.modalInstance.dismiss('No Button Clicked')

        };

        var modalPopup = function () {
            return $rootScope.modalInstance = $uibModal.open({
                backdrop: true,
                keyboard: true,
                backdropClick: true,
                templateUrl: 'view/modal/videomodal.html',
                controllerAs: $rootScope,
                size: 'lg'
            });
        };
        
        vm.DownloadTemplate = function (url) {
            window.location.assign(url);
        }

    }

})();