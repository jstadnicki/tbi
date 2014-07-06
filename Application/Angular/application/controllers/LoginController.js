angular.module('ToBeImplemented')
    .controller('LoginController', function ($scope, $http, $location, authorizationService) {

        $scope.loginViewModel = {
            loginName: '',
            password: '',
            isBusy: false
        };

        $scope.init = function () {};

        $scope.login = function () {
            $scope.loginViewModel.isBusy = true;
            authorizationService.login($scope.loginViewModel)
                .then(function (response) {
                    $scope.loginViewModel.isBusy = false;
                    $location.path('/');
                }, function (error) {
                    $scope.loginViewModel.isBusy = false;
                    $scope.message = error.error_description;
                });
        }

    });
