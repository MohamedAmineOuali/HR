'use strict';

/* Directives */


angular.module('myApp.InfoBank', []).
factory('InfoBank', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
  
    fac.Add = function (data) {
        return $http.post(serviceBasePath + '/api/InfosBanque/Add', data).then(function (response) {
            return response.data;
        })


    }
    return fac;
}]);
