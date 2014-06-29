/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular.js" />

angular.module('ToBeImplemented')
    .controller('ListController', function ($scope, $http, serviceAddress) {
        $scope.list = [];
        $scope.error = '';

        $scope.init = function () {
            $http.get(serviceAddress + '/concepts?include=author')
                .success(function (data, status, headers, config) {
                    $scope.list = angular.fromJson(data.Data).Concepts;
                })
                .error(function (data, stattus, headers, config) {
                    $scope.error = data;
                });
        };

    });
