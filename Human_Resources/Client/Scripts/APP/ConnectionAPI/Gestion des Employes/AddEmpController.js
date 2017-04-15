'use strict';

/* Controllers */
angular.module('myApp.AddEmployeesControllor', [])
  .controller('Main.AddEmployees', ['$scope', '$location', '$ocLazyLoad', 'Employees', 'Departement', function ($scope, $location, $ocLazyLoad, emp, department) {

      $ocLazyLoad.load('public/assets/plugins/twitter-bootstrap-wizard/jquery.bootstrap.wizard.min.js');
      $ocLazyLoad.load('public/assets/plugins/jquery-validation/jquery.validate.min.js');
      $ocLazyLoad.load('public/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js');
      $ocLazyLoad.load('public/assets/js/pages/form-wizard.js');


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
