'use strict';


// Declare app level module which depends on filters, and services
var myApp = angular.module('myApp', [
  'ngRoute',
  'myApp.filters',
  'myApp.services',
  'myApp.directives',
  'myApp.controllers',
  'myApp.ComptesControllor',
  'myApp.ComptesFactories',
  'myApp.EmployeesControllor',
  'myApp.EmployeesFactory',
  'myApp.PrimsContollor',
  'myApp.PrimsFactories',
  'myApp.factories',
  'myApp.interceptor',
  'myApp.CongesServices',
  'myApp.CongesController'
  'myApp.interceptor',
  'naif.base64',
  'myApp.config_empControllor',
  'checklist-model'

]).config(['$locationProvider', function($locationProvider) {
    $locationProvider.hashPrefix('');
}]).config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'public/views/Home.html', controller: 'MainControllor' });
    $routeProvider.when('/login', { templateUrl: 'public/views/Login.html', controller: 'LoginControllor' });
    $routeProvider.when('/comptes', { templateUrl: 'public/views/Comptes/Comptes.html', controller: 'Main.Comptes' });
    $routeProvider.when('/conges', { templateUrl: 'public/views/Conges/Conges.html', controller: 'Conges.Main' });
    $routeProvider.when('/addconges', { templateUrl: 'public/views/Conges/Add-Conges.html', controller: 'Conges.Main' });

    $routeProvider.when('/employees', { templateUrl: 'public/views/Employes/Employes.html', controller: 'Main.Employees' });
    $routeProvider.when('/uploadEmployees', { templateUrl: 'public/views/Employes/UploadEmployees.html', controller: 'Upload.Employees' });
    $routeProvider.when('/AddPrim', { templateUrl: 'public/views/Prims/addPrim.html', controller: 'Add.Prim' });
    $routeProvider.when('/config', { templateUrl: 'public/views/Employes/config_emp.html', controller: 'Main.config_emp' });
    $routeProvider.otherwise({ redirectTo: '/login' });
}]);


myApp.constant('ServiceURL', 'http://localhost:52364');
