/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular.js" />

angular.module('ToBeImplemented')
    .controller('ConceptDetailsController', function ($scope, $http, $routeParams, $location, serviceAddress) {

        $scope.data = {};
        $scope.data.id = $routeParams.id;
        $scope.concept = {};
        $scope.error = {};
        $scope.details = {
            isBusy: false
        };

        $scope.init = function () {
            $scope.details.isBusy = true;
            $http.get(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function (data, status, headers, config) {
                    $scope.concept = angular.fromJson(data.Data);
                    $scope.details.isBusy = false;
                })
                .error(function (data, status, headers, config) {
                    $scope.error = data;
                    $scope.details.isBusy = false;
                });
        };

        $scope.delete = function () {
            $scope.details.isBusy = true;

            $http.delete(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function () {
                    $scope.details.isBusy = false;
                    $location.path('/');
                })
                .error(function (data) {
                    $scope.error = data;
                    $scope.details.isBusy = false;
                });
        };

        $scope.edit = function () {
            $location.path('/concepts/edit/' + $scope.data.id);
        };

    });
