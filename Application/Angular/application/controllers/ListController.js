/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular.js" />

angular.module('ToBeImplemented')
    .controller('ListController', function ($scope, $http) {
        $scope.list = [];
        $scope.error = '';

        $scope.init = function () {
            $http.get('http://localhost:7397/concept')
                .success(function (data, status, headers, config) {
                    $scope.list = angular.fromJson(data.Data).Concepts;
                })
                .error(function (data, stattus, headers, config) {
                    $scope.error = data;
                });
        };

    });