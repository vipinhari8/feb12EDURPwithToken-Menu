﻿(function () {
    'use strict';

    angular
        .module('EduRpApp')
        .controller('scheduleExaminationController', scheduleExaminationCntrl);

    scheduleExaminationCntrl.$inject = ['$scope', '$q', '$modal', 'scheduleExaminationService', 'commonService', '$compile', 'uiCalendarConfig'];

    function scheduleExaminationCntrl($scope, $q, $modal, scheduleExaminationService, commonService, $compile, uiCalendarConfig) {
        $scope.eventSources = [];
        $scope.scheduleDetails = undefined;
        $scope.events = [];


        $scope.init = init;

        init();
        function init(){
            scheduleExaminationService.getScheduleDetails().then(detailSuccess, detailError);

        };

        $scope.example14model = [];

        $scope.example14settings = {
            scrollableHeight: '200px',
            scrollable: true,
            enableSearch: true
        };

        $scope.example14data = [{
            "label": "Alabama",
            "id": "AL"
        }, {
            "label": "Alaska",
            "id": "AK"
        }, {
            "label": "American Samoa",
            "id": "AS"
        }, {
            "label": "Arizona",
            "id": "AZ"
        }, {
            "label": "Arkansas",
            "id": "AR"
        }, {
            "label": "California",
            "id": "CA"
        }, {
            "label": "Colorado",
            "id": "CO"
        }, {
            "label": "Connecticut",
            "id": "CT"
        }, {
            "label": "Delaware",
            "id": "DE"
        }, {
            "label": "District Of Columbia",
            "id": "DC"
        }, {
            "label": "Federated States Of Micronesia",
            "id": "FM"
        }, {
            "label": "Florida",
            "id": "FL"
        }, {
            "label": "Georgia",
            "id": "GA"
        }, {
            "label": "Guam",
            "id": "GU"
        }, {
            "label": "Hawaii",
            "id": "HI"
        }, {
            "label": "Idaho",
            "id": "ID"
        }, {
            "label": "Illinois",
            "id": "IL"
        }, {
            "label": "Indiana",
            "id": "IN"
        }, {
            "label": "Iowa",
            "id": "IA"
        }, {
            "label": "Kansas",
            "id": "KS"
        }, {
            "label": "Kentucky",
            "id": "KY"
        }, {
            "label": "Louisiana",
            "id": "LA"
        }, {
            "label": "Maine",
            "id": "ME"
        }, {
            "label": "Marshall Islands",
            "id": "MH"
        }, {
            "label": "Maryland",
            "id": "MD"
        }, {
            "label": "Massachusetts",
            "id": "MA"
        }, {
            "label": "Michigan",
            "id": "MI"
        }, {
            "label": "Minnesota",
            "id": "MN"
        }, {
            "label": "Mississippi",
            "id": "MS"
        }, {
            "label": "Missouri",
            "id": "MO"
        }, {
            "label": "Montana",
            "id": "MT"
        }, {
            "label": "Nebraska",
            "id": "NE"
        }, {
            "label": "Nevada",
            "id": "NV"
        }, {
            "label": "New Hampshire",
            "id": "NH"
        }, {
            "label": "New Jersey",
            "id": "NJ"
        }, {
            "label": "New Mexico",
            "id": "NM"
        }, {
            "label": "New York",
            "id": "NY"
        }, {
            "label": "North Carolina",
            "id": "NC"
        }, {
            "label": "North Dakota",
            "id": "ND"
        }, {
            "label": "Northern Mariana Islands",
            "id": "MP"
        }, {
            "label": "Ohio",
            "id": "OH"
        }, {
            "label": "Oklahoma",
            "id": "OK"
        }, {
            "label": "Oregon",
            "id": "OR"
        }, {
            "label": "Palau",
            "id": "PW"
        }, {
            "label": "Pennsylvania",
            "id": "PA"
        }, {
            "label": "Puerto Rico",
            "id": "PR"
        }, {
            "label": "Rhode Island",
            "id": "RI"
        }, {
            "label": "South Carolina",
            "id": "SC"
        }, {
            "label": "South Dakota",
            "id": "SD"
        }, {
            "label": "Tennessee",
            "id": "TN"
        }, {
            "label": "Texas",
            "id": "TX"
        }, {
            "label": "Utah",
            "id": "UT"
        }, {
            "label": "Vermont",
            "id": "VT"
        }, {
            "label": "Virgin Islands",
            "id": "VI"
        }, {
            "label": "Virginia",
            "id": "VA"
        }, {
            "label": "Washington",
            "id": "WA"
        }, {
            "label": "West Virginia",
            "id": "WV"
        }, {
            "label": "Wisconsin",
            "id": "WI"
        }, {
            "label": "Wyoming",
            "id": "WY"
        }];
        $scope.example2settings = {
            displayProp: 'id'
        };

        function detailSuccess(response){
            $scope.scheduleDetails = response.ExamSchedule;

            angular.forEach($scope.scheduleDetails, function(i , j){
                    console.log(i);
                $scope.events.push({
                    title: i.subject,
                    start: new Date(i.startDate),
                    end: new Date(i.endDate),
                    stick: true
                });
            });

            console.log($scope.events);
        }

        function detailError(){
            console.log("Schedule Details Not found");
        }
        //model starts here 
        $scope.scheduleExamContainer = function () {
            $scope.Modals.openSubjectContainer();
        };

        $scope.Modals = {
            openSubjectContainer: function () {
                $scope.modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/App/Templates/ScheduleExamination/modelScheduleExamination.html',
                    size: 'lg',
                    scope: $scope,
                    backdrop: 'static'
                });

                $scope.modalInstance.result.then(
                    function (subject) {

                    },
                    function (event) {

                    });
            },
            closeSubjectContainer: function () {
                $scope.modalInstance.dismiss();
            }
        };
        //model ends here

        $scope.uiConfig = {
            calendar: {
                height: 450,
                editable: true,
                header: {
                    left: 'month basicWeek basicDay agendaWeek agendaDay',
                    center: 'title',
                    right: 'today prev,next'
                },
                eventClick: $scope.alertOnEventClick,
                eventDrop: $scope.alertOnDrop,
                eventResize: $scope.alertOnResize
            }
        };

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();


        $scope.changeTo = 'Hungarian';
        /* event source that pulls from google.com */
        $scope.eventSource = {
            url: "",
            className: 'gcal-event',           // an option!
            currentTimezone: 'America/Chicago' // an option!
        };
        /* event source that calls a function on every view switch */
        $scope.eventsF = function (start, end, timezone, callback) {
            var s = new Date(start).getTime() / 1000;
            var e = new Date(end).getTime() / 1000;
            var m = new Date(start).getMonth();
            var events = [{title: 'Feed Me ' + m,start: s + (50000),end: s + (100000),allDay: false, className: ['customFeed']}];
            callback(events);
        };

        $scope.calEventsExt = {
            color: '#f00',
            textColor: 'yellow',
            events: [
                {type:'party',title: 'Lunch',start: new Date(y, m, d, 12, 0),end: new Date(y, m, d, 14, 0),allDay: false},
                {type:'party',title: 'Lunch 2',start: new Date(y, m, d, 12, 0),end: new Date(y, m, d, 14, 0),allDay: false},
                {type:'party',title: 'Click for Google',start: new Date(y, m, 28),end: new Date(y, m, 29),url: 'http://google.com/'}
            ]
        };
        /* alert on eventClick */
        $scope.alertOnEventClick = function( date, jsEvent, view){
            $scope.alertMessage = (date.title + ' was clicked ');
            console.log($scope.alertMessage);
        };
        /* alert on Drop */
        $scope.alertOnDrop = function(event, delta, revertFunc, jsEvent, ui, view){
            $scope.alertMessage = ('Event Droped to make dayDelta ' + delta);
        };
        /* alert on Resize */
        $scope.alertOnResize = function(event, delta, revertFunc, jsEvent, ui, view ){
            $scope.alertMessage = ('Event Resized to make dayDelta ' + delta);
        };
        /* add and removes an event source of choice */
        $scope.addRemoveEventSource = function(sources,source) {
            var canAdd = 0;
            angular.forEach(sources,function(value, key){
                if(sources[key] === source){
                    sources.splice(key,1);
                    canAdd = 1;
                }
            });
            if(canAdd === 0){
                sources.push(source);
            }
        };
        /* add custom event*/
        $scope.addEvent = function() {
            $scope.events.push({
                title: 'Open Sesame',
                start: new Date(y, m, 28),
                end: new Date(y, m, 29),
                className: ['openSesame']
            });
        };
        /* remove event */
        $scope.remove = function(index) {
            $scope.events.splice(index,1);
        };
        /* Change View */
        $scope.changeView = function(view,calendar) {
            uiCalendarConfig.calendars[calendar].fullCalendar('changeView',view);
        };
        /* Change View */
        $scope.renderCalender = function(calendar) {
            if(uiCalendarConfig.calendars[calendar]){
                uiCalendarConfig.calendars[calendar].fullCalendar('render');
            }
        };
        /* Render Tooltip */
        $scope.eventRender = function( event, element, view ) {
            element.attr({'tooltip': event.title,
                'tooltip-append-to-body': true});
            $compile(element)($scope);
        };

        $scope.changeLang = function() {
            if($scope.changeTo === 'Hungarian'){
                $scope.uiConfig.calendar.dayNames = ["Vasárnap", "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat"];
                $scope.uiConfig.calendar.dayNamesShort = ["Vas", "Hét", "Kedd", "Sze", "Csüt", "Pén", "Szo"];
                $scope.changeTo= 'English';
            } else {
                $scope.uiConfig.calendar.dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
                $scope.uiConfig.calendar.dayNamesShort = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
                $scope.changeTo = 'Hungarian';
            }
        };
        /* event sources array*/
        $scope.eventSources = [$scope.events, $scope.eventSource, $scope.eventsF];
        //$scope.eventSources2 = [$scope.calEventsExt, $scope.eventsF, $scope.events];

    }
    
})();