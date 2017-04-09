'use strict';

/* Directives */


angular.module('myApp.CongesServices', []).
factory('Conges', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
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
