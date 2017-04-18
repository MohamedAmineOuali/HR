'use strict';

/* Directives */


angular.module('myApp.Contrat', []).
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
    return fac;
}]);
