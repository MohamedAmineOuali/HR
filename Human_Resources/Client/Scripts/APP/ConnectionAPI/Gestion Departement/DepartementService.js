'use strict';

/* Directives */


angular.module('myApp.GestionDepartement')
    .factory('Departement', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
        var fac = {};
        fac.GetAllDep = function () {
            return $http.get(serviceBasePath + '/api/Departements').then(function (response) {
                return response.data;
            })
        }

        
        return fac;
    }]);
