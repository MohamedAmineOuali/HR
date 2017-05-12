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

    fac.Add = function (data) {
        return $http.post(serviceBasePath + '/api/Comptes', data).then(function (response) {
            return response;
        })


    }

    fac.GetAllComptesResponsable=function()
    {
        return $http.get(serviceBasePath + '/api/comptes/responsable').then(function (response) {
            return response.data;
        })


    }
    return fac;
}]);
