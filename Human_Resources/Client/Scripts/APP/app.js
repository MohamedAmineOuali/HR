'use strict';


// Declare app level module which depends on filters, and services
var myApp = angular.module('myApp', [
  'ui.router',
  'myApp.Route',
  'myApp.controllers',
  'myApp.GestionCompte',
  'myApp.GestionEmploye',
  'myApp.GestionPrime',
  'myApp.GestionConge',
  'myApp.GestionDepartement',
  'myApp.factories',
  'myApp.interceptor',
  'oc.lazyLoad',
  'naif.base64',

  'checklist-model'

]);
myApp.constant('ServiceURL', 'http://localhost:52364');
