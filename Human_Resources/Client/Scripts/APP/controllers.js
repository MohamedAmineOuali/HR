'use strict';

/* Controllers */
angular.module('myApp.controllers', [])
    .controller('MainControllor', ['$location', 'userService', function ($location,userService) {
        var user = userService.GetCurrentUser();
        
        if (user == null || user.role==null)
            $location.path('/login');

        if (user.role==="admin")
            $location.path('/admin/main');
        else if(user.role==="responsable")
            $location.path('/responsable/main');
        else
            $location.path('/login');
    }])
    .controller('TemplateControllor', ['$scope', '$ocLazyLoad', 'accountService', 'userService', function ($scope, $ocLazyLoad, accountService, userService) {
        var user = userService.GetCurrentUser();

        if (user == null || user.role == null)
            $location.path('/login');

        $scope.nom = user.login;
        $scope.$on('$viewContentLoaded', function () {
            $ocLazyLoad.load({
                
                serie: true,
                files: [
                    'public/assets/plugins/pace-master/pace.min.js',
                    'public/assets/plugins/jquery-blockui/jquery.blockui.js',
                    'public/assets/plugins/bootstrap/js/bootstrap.min.js',
                    'public/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js',
                    'public/assets/plugins/switchery/switchery.min.js',
                    'public/assets/plugins/uniform/jquery.uniform.min.js',
                    'public/assets/plugins/offcanvasmenueffects/js/classie.js',
                    'public/assets/plugins/waves/waves.min.js',
                    'public/assets/plugins/3d-bold-navigation/js/main.js',
                    'public/assets/js/modern.min.js'
                ]
            });
        });
    }])
    .controller('DashbordControllor', ['$scope', '$ocLazyLoad', function ($scope,$ocLazyLoad) {
        $scope.$on('$viewContentLoaded', function () {
            $ocLazyLoad.load({
                cache: false,
                serie: true,
                files: [
                    'public/assets/plugins/waypoints/jquery.waypoints.min.js',
                    'public/assets/plugins/jquery-counterup/jquery.counterup.min.js',
                    'public/assets/plugins/toastr/toastr.min.js',
                    'public/assets/plugins/flot/jquery.flot.min.js',
                    'public/assets/plugins/flot/jquery.flot.time.min.js',
                    'public/assets/plugins/flot/jquery.flot.symbol.min.js',
                    'public/assets/plugins/flot/jquery.flot.resize.min.js',
                    'public/assets/plugins/flot/jquery.flot.tooltip.min.js',
                    'public/assets/plugins/curvedlines/curvedLines.js',
                    'public/assets/plugins/metrojs/MetroJs.min.js',
                    'public/assets/js/pages/dashboard.js'
                ]
            });
        });

        


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
  }])
.controller('LogoutControllor', ['$scope', '$location', 'accountService', function ($scope, $location, accountService) {
    //FETCH DATA FROM SERVICES
    accountService.logout();
    $location.path('/');
}])
;
