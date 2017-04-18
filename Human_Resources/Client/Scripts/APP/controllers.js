'use strict';

/* Controllers */
angular.module('myApp.controllers', [])
    .controller('MainControllor', ['$ocLazyLoad', function ($ocLazyLoad) {
        $ocLazyLoad.load('public/assets/plugins/waypoints/jquery.waypoints.min.js');
        $ocLazyLoad.load('public/assets/plugins/jquery-counterup/jquery.counterup.min.js');
        $ocLazyLoad.load('public/assets/plugins/toastr/toastr.min.js');
        $ocLazyLoad.load('public/assets/plugins/flot/jquery.flot.min.js');
        $ocLazyLoad.load('public/assets/plugins/flot/jquery.flot.time.min.js');
        $ocLazyLoad.load('public/assets/plugins/flot/jquery.flot.symbol.min.js');
        $ocLazyLoad.load('public/assets/plugins/flot/jquery.flot.resize.min.js');
        $ocLazyLoad.load('public/assets/plugins/flot/jquery.flot.tooltip.min.js');
        $ocLazyLoad.load('public/assets/plugins/curvedlines/curvedLines.js');
        $ocLazyLoad.load('public/assets/plugins/metrojs/MetroJs.min.js');
        $ocLazyLoad.load('public/assets/js/pages/dashboard.js');


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
