'use strict';

/* Controllers */
//var myModule = angular.module('myApp.controllers', ['myApp.factories']);
angular.module('myApp.GestionCompte')
  .controller('Main.Comptes', ['$scope', '$ocLazyLoad', 'Comptes', 'Etablissements', function ($scope, $ocLazyLoad, Comptes,Etablissements) {

      $ocLazyLoad.load({

          serie: true,
          files: [
              'public/assets/plugins/datatables/css/jquery.datatables_themeroller.css',
              'public/assets/plugins/datatables/css/jquery.datatables.min.css'
          ] // include js file pour les template des menu lazyloading 
      });

      $scope.sortType = 'Nom'; // set the default sort type
      $scope.sortReverse = false;  // set the default sort order
      $scope.search = '';     // set the default search/filter term

      $scope.data = "";
      Comptes.GetAllComptes().then(function (data) {
          $scope.data = data;
      })

      var popUp = function (data) {
          $scope.etablissements = data;
          $scope.formdata = {
              Etablissement: null,
              Nom: "",
              Login: "",
              Password: "",
              Role:""
          };
      }

      $scope.Add = function () {
          Etablissements.GetAllEtablissement().then(function (data) {
              popUp(data);
          }, function (error) {
              $scope.errors = error.error_description;
          })
      }

      $scope.postdata = function () {
          $scope.formdata;
      }

  }]);
