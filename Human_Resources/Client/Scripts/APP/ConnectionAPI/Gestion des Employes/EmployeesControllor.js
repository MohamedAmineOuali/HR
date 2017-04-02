'use strict';

/* Controllers */
var myModule = angular.module('myApp.controllers', ['myApp.factories']);
angular.module('myApp.EmployeesControllor', [])
  .controller('Main.Employees', ['$scope', 'Employees', function ($scope, Employees) {
      $scope.Emp = {h : 'Hello'};
      Employees.GetAllEmployees().then(function (data) {
          $scope.Emp = data;
      })
  }]);
