(function () {
    'use strict';

    angular
        .module('app')
        .controller('AVMCalendarController', AVMCalendarController);

    AVMCalendarController.$inject = ['$scope', '$compile', '$timeout', 'uiCalendarConfig', 'ProjectService', '$uibModal'];

    function AVMCalendarController($scope, $compile, $timeout, uiCalendarConfig, ProjectService, $uibModal) {

        var vm = this;
        $scope.isShow = false;
        var event = [];

        LoadCalender();


        /* Change View */
        function LoadCalender() {

            $timeout(function () {
                if (uiCalendarConfig.calendars['myCalendar']) {
                    uiCalendarConfig.calendars['myCalendar'].fullCalendar('render');
                }
            });

        }

        $scope.LoadData = function () {
            vm.loading = true;
            ProjectService.GetAVMProjectCalendar()
                           .then(function (data) {
                               for (var i = 0; i < data.length; i++) {
                                   event.push({ title: data[i].Title, start: new Date(data[i].EventTypeDate), color: loadColor(data[i].Status), allDay: true, projectId: data[i].ProjectID,stage: data[i].Stage,id: data[i].ID  });
                               }
                               $scope.isShow = true;
                               $scope.eventSources3 = [event];
                           }).finally(function () {
                               vm.loading = false;
                           });

        }

        /* Render Tooltip */
        $scope.eventRender = function (event, element, view) {
            element.attr({
                'tooltip': event.title,
                'tooltip-append-to-body': true
            });
            $compile(element)($scope);
        };

        /* config object */
        $scope.uiConfig = {
            calendar: {
                height: 550,
                editable: true,
                header: {
                    left: 'title',
                    center: '',
                    right: 'today prev,next'
                },
                eventRender: $scope.eventRender,
                eventClick: function (event) {
                    if (event.projectId) {

                        $uibModal.open({
                            backdrop: true,
                            keyboard: true,
                            backdropClick: true,
                            templateUrl: 'view/modal/calendarmodal.html',
                            controller: 'CalendarModalController',
                            controllerAs: 'vm',
                            size: 'lg',
                            resolve: {
                                ID: function () {
                                    return event.id;
                                },
                                Title: function () {
                                    return event.title;
                                },
                                Stage: function () {
                                    return event.stage;
                                }
                            }
                        });
                    }
                }
            }
        };





        $scope.LoadData();



        function loadColor(color) {
            var colourValue;
            switch (color) {
                case 'Red':
                    colourValue = 'red';
                    break;
                case 'Green':
                    colourValue = 'green';
                    break;
                case 'Amber':
                    colourValue = '#f49d41';
                    break;
                default:
                    colourValue = 'green';

            }
            return colourValue;

        }


    }
})();

