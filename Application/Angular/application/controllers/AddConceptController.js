/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts\angular.js" />
angular.module('ToBeImplemented')
    .controller('AddConceptController', function ($scope, $http, $location) {
        $scope.concept = {};
        $scope.init = function () {
            $scope.concept.AuthorId = 1;
        };

        $scope.addConcept = function () {
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

            $http.post('http://localhost:50000/concepts', concept)
                .success(function (data) {
                    var id = angular.fromJson(data.Data);
                    $location.path('/concepts/details/' + id);
                })
                .error(function (data, status) {
                    $scope.error = data;
                });
        };

    });