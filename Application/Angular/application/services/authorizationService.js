/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular-local-storage.min.js" />
/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts\angular.js" />
'use strinct';

angular.module('ToBeImplemented')
    .factory('authorizationService', function ($http, $q, localStorageService, serviceAddress) {

        var _authentication = {};

        (function () {
            var token = localStorageService.get('authorizationData');
            if (token) {
                _authentication.isAuthorized = true;
                _authentication.loginName = token.loginName;
            } else {
                _authentication.isAuthorized = false;
                _authentication.loginName = '';

            }
        })();


        var authorizationServiceFactory = {};

        var _login = function (loginViewModel) {
            var data = 'grant_type=password&username=' + loginViewModel.loginName + '&password=' + loginViewModel.password;
            var deferred = $q.defer();

            $http.post(
                serviceAddress + '/token',
                data, {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .success(function (response) {
                    localStorageService.set('authorizationData', {
                        token: response.access_token,
                        loginName: loginViewModel.loginName
                    });
                    _authentication.isAuthorized = true;
                    _authentication.loginName = loginViewModel.loginName;
                    deferred.resolve(response);
                }).error(function (error, status) {
                    _logout();
                    deferred.reject(error);
                });

            return deferred.promise;
        };


        var _register = function (registerViewModel) {
            var p = $http.post(serviceAddress + '/register', registerViewModel)
                .success(function (response) {
                    var operationResult = angular.fromJson(response);
                })
                .error(function (response) {
                    var operationResult = angular.fromJson(response);
                });
            return p;
        };

        var _logout = function () {
            localStorageService.remove('authorizationData');
            _authentication.isAuthorized = false;
            _authentication.loginName = '';
        }




        authorizationServiceFactory.register = _register;
        authorizationServiceFactory.login = _login;
        authorizationServiceFactory.logout = _logout;
        authorizationServiceFactory.loginName = _authentication.loginName;
        authorizationServiceFactory.authentication = _authentication;
        return authorizationServiceFactory;
    });
