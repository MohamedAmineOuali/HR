'use strict';

/* Controllers */
angular.module('myApp.controllers', [])
    .controller('MainControllor', [function () {
        
    }])
  .controller('LoginControllor', ['$scope', '$location', 'accountService', function ($scope, $location, accountService) {
      //FETCH DATA FROM SERVICES
      $scope.account = {
          login: '',
          password: ''
      }
      $scope.message = "";
      $scope.login = function () {
          accountService.login($scope.account).then(function (data) {
              $location.path('/');
          }, function (error) {
              $scope.message = error.error_description;
          })
      }
  }]);
