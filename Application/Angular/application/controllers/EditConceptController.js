/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts\angular.js" />

angular.module('ToBeImplemented')
    .controller('EditConceptController', function ($scope, $http, $routeParams, $location, serviceAddress) {
        $scope.data = {};
        $scope.concept = {};
        $scope.data.id = $routeParams.id;
        $scope.init = function () {
            $http.get(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function (data, status) {
                    $scope.concept = angular.fromJson(data.Data);
                    $scope.concept.Tags = $scope.concept.Tags.join(';');
                })
                .error(function (data) {
                    $scope.error = data;
                });
        };

        $scope.saveChanges = function () {
            var title = $scope.concept.Title;
            var description = $scope.concept.Description;
            var tags = $scope.concept.Tags;
            var authorId = $scope.concept.AuthorId;
            var id = $scope.concept.Id;

            var concept = {
                Id: id,
                Title: title,
                AuthorId: authorId,
                Description: description,
                Tags: tags
            };

            $http.put(serviceAddress + '/concepts', concept)
                .success(function () {
                    $location.path('/concepts/' + id);
                })
                .error(function (data, status) {
                    $scope.error = data;
                });


        };
    });
