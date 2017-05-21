'use strict';

/* Directives */


angular.module('myApp.GestionEmploye').
factory('Contrat', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
    /*fac.GetAllContrat = function () {
        return $http.get(serviceBasePath + '/api/contrat').then(function (response) {
            return response.data;
        })
    }*/
    fac.Add=function(data)
    {
        return $http.post(serviceBasePath + '/api/Contrat/Add', data).then(function (response) {
            return response.data;
        })


    }
    fac.GetTypeContrat=function()
    {

        return $http.get(serviceBasePath + '/api/TypeContrats').then(function (response) {
            return response.data;
        });

    }
    fac.GetCategories = function () {

        return $http.get(serviceBasePath + '/api/Categories').then(function (response) {
            return response.data;
        });

    }
    return fac;
}]);
