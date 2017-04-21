'use strict';

/* Directives */


angular.module('myApp.GestionPrime').
factory('Prims', ['$http', '$q', 'ServiceURL', '$httpParamSerializer', function ($http, $q, serviceBasePath, $httpParamSerializer) {
    var fac = {};
    fac.AddPrim = function (prim) {
        var obj = { "Libelle": prim.lable, "Type": prim.type, "Valeur": prim.valeur, "Exoneres": prim.exoneres };

        Object.toparams = function ObjectsToParams(obj) {
            var p = [];
            for (var key in obj) {
                p.push(key + '=' + encodeURIComponent(obj[key]));
            }
            return p.join('&');
        }

        var defer = $q.defer();

        $http({
            method: 'POST',
            url: serviceBasePath + "/api/PrimeFixes",
            headers:{
                'Content-Type': "application/json"
            },
            data: obj
        }).then(function (response) {
            defer.resolve(response.data);

        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }
    return fac;
}]);
