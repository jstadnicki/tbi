/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts\angular.js" />

angular.module('ToBeImplemented')
    .controller('EditConceptController', function ($scope, $http, $routeParams, $location, serviceAddress) {
        $scope.data = {
            id: $routeParams.id
        };

        $scope.isBusy = {
            isLoading: false,
            isSaving: false
        }


        $scope.concept = {};
        $scope.init = function () {
            $scope.isBusy.isLoading = true;
            $http.get(serviceAddress + '/concepts/' + $scope.data.id)
                .success(function (data, status) {
                    $scope.concept = angular.fromJson(data.Data);
                    $scope.concept.Tags = $scope.concept.Tags.join(';');
                    $scope.isBusy.isLoading = false;
                })
                .error(function (data) {
                    $scope.error = data;
                    $scope.isBusy.isLoading = false;
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

            $scope.isBusy.isSaving = true;

            $http.put(serviceAddress + '/concepts', concept)
                .success(function () {
                    $scope.isBusy.isSaving = false;
                    $location.path('/concepts/' + id);
                })
                .error(function (data, status) {
                    $scope.error = data;
                    $scope.isBusy.isSaving = false;
                });


        };
    });
