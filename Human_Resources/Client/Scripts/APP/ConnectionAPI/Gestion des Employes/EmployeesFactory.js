'use strict';

/* Directives */


angular.module('myApp.EmployeesFactory', [])
    .factory('Employees', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService, $httpParamSerializer) {
        var fac = {};
        fac.GetAllEmployees = function () {
            return $http.get(serviceBasePath + '/api/Employee/GetAll').then(function (response) {
                return response.data;
            })
        }

        fac.uploadFile = function (data) {
            var obj = {
                "filesize": data.filesize,
                "filetype": data.filetype,
                "filename": data.filename,
                "base64Data": data.base64
            };


            var defer = $q.defer();

            $http({
                method: 'POST',
                url: serviceBasePath + "/api/Employee/UploadFile",
                headers: {
                    'Content-Type': "application/json"
                },
                data: JSON.stringify(obj) 
            }).then(function (response) {
                defer.resolve(response.data);

            }, function (error) {
                defer.reject(error.data);
            })
            return defer.promise;
        }

        fac.genrateData = function (data) {
            var defer = $q.defer();

            $http({
                method: 'POST',
                url: serviceBasePath + "/api/Employee/GenerateData/" + data.Etablissement,
                headers: {
                    'Content-Type': "application/json"
                },
                data: JSON.stringify(data)
            }).then(function (response) {
                defer.resolve(response.data);

            }, function (error) {
                defer.reject(error.data);
            })
            return defer.promise;
        }
        fac.GetByMat=function(mat)
        {
            return $http.get(serviceBasePath + '/api/Employee/GetEmployeeByMat/' + mat).then(function (response) {
                return response;
            }, function (response) { return response; });
        }
        fac.GetConfig=function()
        {
            return $http.get(serviceBasePath + '/api/Employee/GetConfig').then(function (response) {
                return response;
            }, function (response) { return response; });
        }
        fac.AddEmp=function(data,dep)
        {
            return $http.post(serviceBasePath + '/api/Employee/AddEmployee/' + dep, data).then(function (response) { return response; }, function (response) { return response; });
        }
        return fac;
}]);
