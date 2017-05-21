'use strict';

/* Directives */


angular.module('myApp.GestionConge').
factory('Conges', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
    fac.ActiveConge = function () {

        return $http.get(serviceBasePath + '/api/Conges/active').then(function (result) {
            return result.data;



        })
    }
    fac.GetAllConge = function () {
        return $http.get(serviceBasePath + '/api/Conges').then(function (result) {
            return result.data;
        });}
        fac.GetCongeTypes = function () {
            return $http.get(serviceBasePath + '/api/TypeConges').then(function (result) {
                return result.data;
            });         
        }
        fac.AddConge=function(data) 
        {
           
            return $http.post(serviceBasePath + '/api/Conges', data).then(function (data) {
                console.log(data);
            }, function (err) {
                console.log(err);
            });
        }
    return fac; 
}]);
