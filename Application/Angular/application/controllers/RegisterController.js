angular.module('ToBeImplemented')
    .controller('RegisterController', function ($scope, $http, authorizationService, $location, serviceAddress) {

        $scope.registrationViewModel = {
            Username: '',
            Password: '',
            PasswordConfirmation: '',
            DisplayName: '',
            Email: '',
            SecurityChallengeText: '',
            SecurityResult: '',
            ChallengeType: ''
        };

        $scope.registrationErrors = [];
        $scope.isBusy = {
            isLoading: false,
            isSaving: false
        };

        $scope.init = function () {
            $scope.isBusy.isLoading = true;
            $scope.isBusy.isSaving = false;
            $http.get(serviceAddress + '/register')
                .success(function (response) {
                    $scope.registrationViewModel = angular.fromJson(response.Data);
                    $scope.isBusy.isLoading = false;
                })
                .error(function (response) {
                    alert(response);
                    $scope.isBusy.isLoading = false;
                });
        };

        $scope.register = function () {
            $scope.isBusy.isSaving = true;
            var result = authorizationService.register($scope.registrationViewModel);
            result
                .success(function (opearationResult) {
                    $scope.isBusy.isSaving = false;
                    if (opearationResult.Success) {
                        $location.path('/login');
                    } else {
                        $scope.registrationErrors = opearationResult.Errors;
                    }
                })
                .error(function () {
                    $scope.isBusy.isSaving = false;
                });
        };
    });
