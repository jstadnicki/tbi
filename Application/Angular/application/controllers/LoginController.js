angular.module('ToBeImplemented')
    .controller('LoginController', function ($scope, $http, $location, authorizationService) {

        $scope.loginViewModel = {
            loginName: '',
            password: ''
        };

        $scope.init = function () {};

        $scope.login = function () {
            authorizationService.login($scope.loginViewModel).then(function (response) {
                $location.path('/');
            }, function (error) {
                $scope.message = error.error_description;
            });
        }

    });
