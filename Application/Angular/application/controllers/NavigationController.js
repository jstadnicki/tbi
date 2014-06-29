angular.module('ToBeImplemented')
    .controller('NavigationController', function ($scope, authorizationService) {

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
    });
