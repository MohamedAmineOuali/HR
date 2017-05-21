'use strict';

/* Controllers */
//var myModule = angular.module('myApp.controllers', ['myApp.factories']);
angular.module('myApp.GestionPrime')
  .controller('Main.Prims', ['$scope', 'Prims', function ($scope, Prims) {
      $scope.data = "";
      Comptes.GetAllComptes().then(function (data) {
          $scope.data = data;
      })
  }])
.controller('Add.Prim', ['$scope', 'Prims', function ($scope, prims) {
    //FETCH DATA FROM SERVICES
    $scope.prim = {
        label: "",
        type: "",
        valeur: "",
        exoneres:""
    }
    $scope.errors = "";
    $scope.add = function () {
        prims.AddPrim($scope.prim).then(function (data) {
            $location.path('/');
        }, function (error) {
            $scope.errors = error.error_description;
        })
    }
}]);
