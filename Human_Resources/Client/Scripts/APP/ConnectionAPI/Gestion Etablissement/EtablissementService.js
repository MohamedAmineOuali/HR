'use strict';

/* Directives */


angular.module('myApp.GestionEtablissement')
    .factory('Etablissements', ['$http','ServiceURL', function ($http,serviceBasePath) {
        var fac = {};
        fac.GetAllEtablissement = function () {
            return $http.get(serviceBasePath + '/api/Etablissements').then(function (response) {
                return response.data;
            })
        }

        
        return fac;
    }]);
