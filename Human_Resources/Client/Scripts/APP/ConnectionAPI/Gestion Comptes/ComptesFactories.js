'use strict';

/* Directives */


angular.module('myApp.GestionCompte').
factory('Comptes', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
    fac.GetAllComptes = function () {
        return $http.get(serviceBasePath + '/api/comptes').then(function (response) {
            return response.data;
        })
    }
    return fac;
}]);
