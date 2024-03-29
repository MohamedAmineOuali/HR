'use strict';

/* Controllers */
angular.module('myApp.controllers', [])
    .controller('TemplateControllor', ['$scope', '$ocLazyLoad', '$location', 'accountService', 'userService', function ($scope, $ocLazyLoad, $location,accountService, userService) {
        var user = userService.GetCurrentUser();

     //   $scope.nom = user.login;
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
                ] // include js file pour les template des menu lazyloading 
            });
        });
    }])
    .controller('AdminDashbordControllor', ['$scope', '$ocLazyLoad','AdminStatistiqueFactory', function ($scope,$ocLazyLoad,stat) {
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
                ] // lazy loading du dashboard 
            });
            stat.nbEmploye().then(function (data) { $scope.nbEmploye = data.length; });
            stat.nbResponsable().then(function (data) {

                $scope.nbResponsable = data.length;
            });
            stat.nbDepartement().then(function (data) {

                $scope.nbDepartement = data.length;
            });
            stat.nbEtablissement().then(function (data) {

                $scope.nbEtablissement = data.length;
            });
            stat.EmpByEtab().then(function (data) {

                $scope.elements = data;
            });



            
        });

        


    }])
    .controller('ResponsableDashbordControllor', ['$scope', '$ocLazyLoad', 'AdminStatistiqueFactory', function ($scope, $ocLazyLoad, stat) {
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
                ] // lazy loading du dashboard 
            });
            stat.nbEmploye().then(function (data) { $scope.nbEmploye = data.length; });
          
           
            stat.nbDepartement().then(function (data) {

                $scope.nbDepartement = data.length;
            });  
            stat.nbConge().then(function (data) {

                $scope.nbConge = data.length;
            });
            
            stat.EmpByDep().then(function (data) {

                $scope.elements = data;
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
              if (data.nom == "" && data.role != "admin")
              {
                  $location.path('/responsable/associateEmployee');
                  return;
              }
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
