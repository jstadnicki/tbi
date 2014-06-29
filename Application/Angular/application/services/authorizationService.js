/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular-local-storage.min.js" />
/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts\angular.js" />
'use strinct';

angular.module('ToBeImplemented')
    .factory('authorizationService', function ($http, $q, localStorageService) {

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


        var serviceBase = 'http://localhost:50000/';
        var authorizationServiceFactory = {};



        var _login = function (loginViewModel) {
            var data = 'grant_type=password&username=' + loginViewModel.loginName + '&password=' + loginViewModel.password;
            var deferred = $q.defer();

            $http.post(
                serviceBase + 'token',
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

        var _logout = function () {
            localStorageService.remove('authorizationData');
            _authentication.isAuthorized = false;
            _authentication.loginName = '';
        }




        authorizationServiceFactory.login = _login;
        authorizationServiceFactory.logout = _logout;
        authorizationServiceFactory.loginName = _authentication.loginName;
        authorizationServiceFactory.authentication = _authentication;
        return authorizationServiceFactory;
    });
