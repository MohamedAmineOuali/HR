'use strict';

/* Controllers */
angular.module('myApp.AddEmployeesControllor', [])
  .controller('Main.AddEmployees', ['$scope', '$location', 'Employees', 'Departement', function ($scope, $location, emp, department) {
      $scope.config = {};
      $scope.data = {}; 
      $scope.errorInsertion = false;

      emp.GetConfig().then(function (data) {
          if(data.status!=200) 
              $location.path('/config')
          else 
          {
              $scope.config = data.data;

          }




      });
      department.GetAllDep().then(function (data) { $scope.deps = data; });
     $scope.AddEmp = function () {
         emp.AddEmp($scope.data, $scope.departement).then(function (response) {
              if (response.status != 200)
                  $scope.errorInsertion = true;
              else
                  $location.path("/employees");
          });

      }
     
  }]);
