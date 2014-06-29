angular.module('ToBeImplemented')
    .controller('NavigationController', function ($scope, $location, authorizationService) {

        $scope.init = function () {};

        $scope.isLogged = function () {
            var r = authorizationService.authentication.isAuthorized;
            return r;
        };

        $scope.logout = function () {
            authorizationService.logout();
        }

        $scope.username = function () {
            var r = authorizationService.loginName;
            return r;
        };

        $scope.logout = function () {
            authorizationService.logout();
            $location.path('/');
        }
    });
