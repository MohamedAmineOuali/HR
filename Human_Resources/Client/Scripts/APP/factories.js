'use strict';

/* Directives */


angular.module('myApp.factories', []).
  factory('userService', function () {
      var fac = {};
      fac.CurrentUser = null;

      fac.SetCurrentUser = function (user) {
          fac.CurrentUser = user;
          sessionStorage.user = angular.toJson(user);
      }
      fac.GetCurrentUser = function () {
          fac.CurrentUser = angular.fromJson(sessionStorage.user);
          return fac.CurrentUser;
      }
      return fac;
  })
    //user service ysejel el user fel session  token 
.factory('accountService', ['$http', '$q', 'ServiceURL', 'userService', '$httpParamSerializer', function ($http, $q, serviceBasePath, userService,$httpParamSerializer) {
    var fac = {};
    fac.login = function (user) {
        var obj = { 'username': user.login, 'password': user.password, 'grant_type': 'password' };
        Object.toparams = function ObjectsToParams(obj) {
            var p = [];
            for (var key in obj) {
                p.push(key + '=' + encodeURIComponent(obj[key]));
            }
            return p.join('&');
        }

        var defer = $q.defer();
        $http({
            method: 'post',
            url: serviceBasePath + "/login",
            data: $httpParamSerializer(obj),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            userService.SetCurrentUser(response.data);
            defer.resolve(response.data);
        }, function (error) {
            defer.reject(error.data);
        })
        return defer.promise;
    }

    fac.logout = function () {
        userService.CurrentUser = null;
        userService.SetCurrentUser(userService.CurrentUser);
    }
    return fac;
}]);
// permet de faire le login + logout 
