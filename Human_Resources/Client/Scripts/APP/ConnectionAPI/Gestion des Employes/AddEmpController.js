'use strict';

/* Controllers */
angular.module('myApp.AddEmployeesControllor', [])
  .controller('Main.AddEmployees', ['$scope','$location','Employees', function ($scope, $location,emp) {
      $scope.config = {};
      emp.GetConfig().then(function (data) {
          if(data.status!=200) 
              $location.path('/config')
          else 
          {
              $scope.config = data.data;

          }




      }); 
     
  }]);
