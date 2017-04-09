//'use strict';

/* Controllers */
var myModule = angular.module('myApp.controllers', ['myApp.factories']);
angular.module('myApp.config_empControllor', [])
  .controller('Main.config_emp', ['ServiceURL', '$http', '$scope', function (serviceBasePath, $http, $scope) {

      
      

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
          Genre : false

      };
      $scope.submit = function () {




    $scope.configList = {
              CIN: $scope.CIN,
              Nom: $scope.Nom,
              Prenom: $scope.Prenom,
              Adresse: $scope.Adresse,
              NombreEnfants: $scope.NombreEnfants,
              LieuNaissance: $scope.LieuNaissance,
              DateNaissance: $scope.DateNaissance,
              Matricule: $scope.Matricule,
              StatutSocial: $scope.StatutSocial,
              Telephone: $scope.Telephone,
              Nationalite: $scope.Nationalite,
              NSS: $scope.NSS,
              Grade: $scope.Grade,
              Genre: $scope.Genre

    };

    var obj = $scope.configList

          

          $http({
              method: 'POST',
              url: serviceBasePath + "/api/Employee/config",
              headers: {
                  'Content-Type': "application/json"
              },
              data: obj
          }).then(function (response) {
              //defer.resolve(response.data);
              console.log(response);

          }, function (error) {
              console.log("error data");
          });

          //$location.path('/');

      }

      
  }]);

