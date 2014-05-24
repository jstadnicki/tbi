/// <reference path="c:\source\ToBeImplemented\Application\Angular\scripts/angular.js" />

angular.module('ToBeImplemented')
    .controller('tbiMainController', function($scope) {

        $scope.text = 'dupa';

        $scope.foo=function() {
            return "im in foo()";
        }
});