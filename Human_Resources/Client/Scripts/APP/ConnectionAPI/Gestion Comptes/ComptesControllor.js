'use strict';

/* Controllers */
//var myModule = angular.module('myApp.controllers', ['myApp.factories']);
angular.module('myApp.GestionCompte')
  .controller('Main.Comptes', ['$scope', 'Comptes', function ($scope, Comptes) {
      $scope.data = "";
      Comptes.GetAllComptes().then(function (data) {
          $scope.data = data;
      })
  }]);
