/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular.js" />

angular.module('ToBeImplemented')
    .controller('ConceptDetailsController', function ($scope, $http, $routeParams, $location, serviceAddress) {

        $scope.data = {};
        $scope.data.id = $routeParams.id;
        $scope.concept = {};
        $scope.error = {};

        $scope.init = function () {
            $http.get(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function (data, status, headers, config) {
                    $scope.concept = angular.fromJson(data.Data);
                })
                .error(function (data, status, headers, config) {
                    $scope.error = data;
                });
        };

        $scope.delete = function () {
            $http.delete(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function () {
                    alert('deleted!');
                    $location.path('/');
                })
                .error(function (data) {
                    $scope.error = data;
                });
        };

        $scope.edit = function () {
            $location.path('/concepts/edit/' + $scope.data.id);
        };

    });
