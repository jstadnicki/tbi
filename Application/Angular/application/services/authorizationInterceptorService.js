'use strict'
angular.module('ToBeImplemented')
.factory('authorizationInterceptorService', function($q, $location, localStorageService){
    var service={};

    var _request = function(config){
        config.headers = config.headers||{};

        var authorizationData = localStorageService.get('authorizationData');
        if(authorizationData){
            config.headers.Authorization = 'Bearer ' + authorizationData.token;
        }

        return config;
    };

    var _responseError = function(rejection){
        if(rejection.status === 401){
            $location.path('/login')
        }
        return $q.reject(rejection);
    };

    service.request = _request;
    service.responseError  = _responseError;

    return service;
});