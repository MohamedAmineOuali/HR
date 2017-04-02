'use strict';

/* Directives */


angular.module('myApp.EmployeesFactory', []).
factory('Employees', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
    var fac = {};
    fac.GetAllEmployees = function () {
        return $http.get(serviceBasePath + '/api/Employee/GetAll').then(function (response) {
            return response.data;
        })
    }
    return fac;
}]);
