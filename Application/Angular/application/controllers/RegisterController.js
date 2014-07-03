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

        $scope.init = function () {
            $http.get(serviceAddress + '/register')
                .success(function (response) {
                    $scope.registrationViewModel = angular.fromJson(response.Data);
                })
                .error(function (response) {
                    alert(response);
                });
        };

        $scope.register = function () {
            var result = authorizationService.register($scope.registrationViewModel);
            result
                .success(function (opearationResult) {
                    if (opearationResult.Success) {
                        $location.path('/login');
                    } else {
                        $scope.registrationErrors = opearationResult.Errors;
                    }
                })
                .error(function () {});
        };

        $scope.passwordsMatches = function (a, b) {
            console.log(a);
            console.log(b);
        }
    });
