var route = angular.module("myApp.Route", ['ui.router']);
route.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}])
.config(function ($urlRouterProvider, $stateProvider) {
    $stateProvider
        .state('main', {
            url: '/',
            resolve: {
                security: ['$location','userService', function ($location,userService) {
                    var user = userService.GetCurrentUser();
                    //  redirection des liens lors d'une authentification 
                    if (user == null || user.role == null)
                        $location.path('/login');
                    else if (user.role === "admin")
                        $location.path('/admin/main');
                    else if (user.role === "responsable")
                        $location.path('/responsable/main');
                    else
                        $location.path('/login');
                }]
            }
        })
      .state('login', {
          url: '/login',
          templateUrl: 'public/views/Login.html',
          controller: 'LoginControllor'
      })
        .state('logout', {
            url: '/logout',
            controller: 'LogoutControllor'
        })
        .state('notfound', {
            url: '/notfound',
            templateUrl: 'public/views/Errors/404.html',
        })
        .state('unauthorized', {
            url: '/unauthorized',
            templateUrl: 'public/views/Errors/403.html',
        })
      .state('admin', {
          url: '/admin',
          templateUrl: 'public/views/Templates/Admin.html',
          controller: 'TemplateControllor'
      })
      .state('admin.Dashbord', {
          url: '/main',
          templateUrl: 'public/views/Admin/Home.html',
          controller: 'AdminDashbordControllor'
      })
        .state('admin.config', {
            url: '/config',
            templateUrl: 'public/views/Employes/config_emp.html',
            controller: 'Main.config_emp'
        })
        .state('admin.AddPrim', {
            url: '/addPrim',
            templateUrl: 'public/views/Prims/addPrim.html',
            controller: 'Add.Prim'
        })
        .state('admin.comptes', {
            url: '/comptes',
            templateUrl: 'public/views/Comptes/Comptes.html',
            controller: 'Main.Comptes'
        })
      .state('responsable', {
          url: '/responsable',
          templateUrl: 'public/views/Templates/Responsable.html',
          controller: 'TemplateControllor',
          resolve: {
              security: ['$location', 'userService', function ($location, userService) {
                  var user = userService.GetCurrentUser();

                  if (user == null || user.role == null)
                      $location.path('/login');
              }]
          }
      })
      .state('responsable.Dashbord', {
          url: '/main',
          templateUrl: 'public/views/Responsable/Home.html',
          controller: 'ResponsableDashbordControllor'
      })
    .state('responsable.addEmployee', {
        url: '/addemployee',
        templateUrl: 'public/views/Employes/AddEmp.html',
        controller: 'AddEmployee'
    })
     .state('responsable.associcateEmployee', {
        url: '/associateEmployee',
        templateUrl: 'public/views/Employes/AddEmp.html',
        controller: 'AssociateEmployee'
    })   
    .state('responsable.employees', {
        url: '/employees',
        templateUrl: 'public/views/Employes/Employes.html',
        controller: 'Main.Employees'
    })
    .state('responsable.uploadEmployees', {
        url: '/uploadEmployees',
        templateUrl: 'public/views/Employes/UploadEmployees.html',
        controller: 'Upload.Employees'
    })
    .state('responsable.addconges', {
        url: '/addconge',
        templateUrl: 'public/views/Conges/Add-Conges.html',
        controller: 'Conges.Main'
    })
    .state('responsable.conges', {
        url: '/conges',
        templateUrl: 'public/views/Conges/Conges.html',
        controller: 'Conges.Main'
    })
    .state('responsable.EmployeeDetail', {
        url: '/detailEmployee',
        templateUrl: 'public/views/Employes/EmployeeDetail.html',
        controller: 'Get.Employees'
    });
    $urlRouterProvider.when('', '/');

    $urlRouterProvider.otherwise('/notfound');
});