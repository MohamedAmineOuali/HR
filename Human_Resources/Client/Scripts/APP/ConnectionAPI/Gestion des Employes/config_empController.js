//'use strict';

/* Controllers */
var myModule = angular.module('myApp.GestionEmploye');
myModule
  .controller('Main.config_emp', ['ServiceURL', '$http', '$scope', '$location','Employees', function (serviceBasePath, $http, $scope,$location, emp) {

      
      
      emp.GetConfig().then(function (response) {
          $scope.error = false;

          if (response.status != 200)
              $scope.configList = {
                  CIN: false,
                  Nom: false,
                  Prenom: false,
                  Adresse: false,
                  NombreEnfants: false,
                  LieuNaissance: false,
                  DateNaissance: false,
                  Matricule: false,
                  StatutSocial: false,
                  Telephone: false,
                  Nationalite: false,
                  NSS: false,
                  Grade: false,
                  Genre: false

              };
          else
              $scope.configList = response.data;
      });


      $scope.submit = function () {


    var obj = $scope.configList

          

          $http({
              method: 'POST',
              url: serviceBasePath + "/api/Employee/config",
              headers: {
                  'Content-Type': "application/json"
              },
              data: obj
          }).then(function (response) {
              $location.path('/');

          }, function (error) {
              $scope.error = true; 
          });

          //$location.path('/');

      }

      
  }]);

