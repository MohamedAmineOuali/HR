'use strict';


// Declare app level module which depends on filters, and services
var myApp = angular.module('myApp', [
  'ui.router',

  'myApp.controllers',

  'myApp.ComptesControllor',
  'myApp.ComptesFactories',

  'myApp.EmployeesControllor',
  'myApp.EmployeesFactory',

  'myApp.PrimsContollor',
  'myApp.PrimsFactories',

  'myApp.CongesServices',
  'myApp.CongesController',


  'myApp.DepartmentService',
  'myApp.InfoBank',
  'myApp.Contrat',

  'myApp.factories',
  'myApp.interceptor',
  'oc.lazyLoad',
  'naif.base64',

  'myApp.config_empControllor',
  'checklist-model'

]).config(['$locationProvider', function($locationProvider) {
    $locationProvider.hashPrefix('');
}])
.config(function ($stateProvider) {
    $stateProvider
      .state('login', {
          url: '/login',
          templateUrl: 'public/views/Login.html',
          controller: 'LoginControllor'
      })
      .state('admin', {
          url: '/admin',
          templateUrl: 'public/views/Templates/Admin.html',
          controller: 'TemplateControllor'
      })
      .state('admin.Dashbord', {
          url: '/main',
          templateUrl: 'public/views/Admin/Home.html',
          controller: 'DashbordControllor'
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
          controller: 'TemplateControllor'
      })
      .state('responsable.Dashbord', {
         url: '/main',
         templateUrl: 'public/views/Responsable/Home.html',
         controller: 'DashbordControllor'
      })
    .state('responsable.addEmployee', {
        url: '/addemployee',
        templateUrl: 'public/views/Employes/AddEmp.html',
        controller: 'AddEmployee'
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
    


});


myApp.constant('ServiceURL', 'http://localhost:52364');
