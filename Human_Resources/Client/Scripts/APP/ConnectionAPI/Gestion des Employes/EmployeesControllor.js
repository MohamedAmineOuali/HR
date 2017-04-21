'use strict';

/* Controllers */
var myModule = angular.module('myApp.GestionEmploye');
myModule
  .controller('Main.Employees', ['$scope', 'Employees', function ($scope, Employees) {
      $scope.Emp = [];
      Employees.GetAllEmployees().then(function (data) {
          $scope.Emp = data;
      });
      $scope.resolveReferences = function resolveReferences(json) {
          if (typeof json === 'string')
              json = JSON.parse(json);

          var byid = {}, // all objects by id
              refs = []; // references to objects that could not be resolved
          json = (function recurse(obj, prop, parent) {
              if (typeof obj !== 'object' || !obj) // a primitive value
                  return obj;
              if (Object.prototype.toString.call(obj) === '[object Array]') {
                  for (var i = 0; i < obj.length; i++)
                      // check also if the array element is not a primitive value
                      if (typeof obj[i] !== 'object' || !obj[i]) // a primitive value
                          continue;
                      else if ("$ref" in obj[i])
                          obj[i] = recurse(obj[i], i, obj);
                      else
                          obj[i] = recurse(obj[i], prop, obj);
                  return obj;
              }
              if ("$ref" in obj) { // a reference
                  var ref = obj.$ref;
                  if (ref in byid)
                      return byid[ref];
                  // else we have to make it lazy:
                  refs.push([parent, prop, ref]);
                  return;
              } else if ("$id" in obj) {
                  var id = obj.$id;
                  delete obj.$id;
                  if ("$values" in obj) // an array
                      obj = obj.$values.map(recurse);
                  else // a plain object
                      for (var prop in obj)
                          obj[prop] = recurse(obj[prop], prop, obj);
                  byid[id] = obj;
              }
              return obj;
          })(json); // run it!

          for (var i = 0; i < refs.length; i++) { // resolve previously unknown references
              var ref = refs[i];
              ref[0][ref[1]] = byid[ref[2]];
              // Notice that this throws if you put in a reference at top-level
          }
          return json;
      }
  }])

  .controller('AddEmployee', ['$scope', '$location', '$ocLazyLoad', 'Employees', 'Departement', 'Contrat', 'InfoBank', function ($scope, $location, $ocLazyLoad, emp, department, contrat, infoBank) {

      $scope.$on('$viewContentLoaded', function () {
          $ocLazyLoad.load({
              cache: false,
              serie: true,
              files: [
                  'public/assets/plugins/twitter-bootstrap-wizard/jquery.bootstrap.wizard.min.js',
                  'public/assets/plugins/jquery-validation/jquery.validate.min.js',
                  'public/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js',
                  'public/assets/js/pages/form-wizard.js']
          });
      });

      $scope.bank = {};
      $scope.contrat = {};

      $scope.config = {};
      $scope.data = {};
      $scope.errorInsertion = false;

      emp.GetConfig().then(function (data) {
          if (data.status != 200)
              $location.path('/config')
          else {
              $scope.config = data.data;

          }




      });
      department.GetAllDep().then(function (data) { $scope.deps = data; });
      contrat.GetTypeContrat().then(function (data) {
          $scope.types = data;
      });
      contrat.GetCategories().then(function (data) { $scope.categories = data });
      $scope.AddEmp = function () {
          var bankid;
          infoBank.Add($scope.bank).then(function (response) {
              bankid = response;
              contrat.Add(contrat).then(function (response) {
                  var idContrat = response;
                  $scope.data.FK_Contrat = idContrat;
                  $scope.data.FK_InfosBanque = bankid;
                  emp.AddEmp($scope.data, $scope.departement).then(function (response) {
                      if (response.status != 200)
                          $scope.errorInsertion = true;
                      else
                          $location.path("/employees");
                  });
              })
          }
              );

      }

  }])

  .controller('Upload.Employees', ['$scope', '$location', 'Employees', function ($scope, $location ,Employees) {
      $scope.errors = "";
      $scope.upload = true;

      var changeMod = function (data) {
          $scope.upload = false;
          $scope.details = data.File.Sheets;
          $scope.etablissements = data.Etablissements;
          $scope.data = {
              Etablissement:null,
              FileName: data.File.FileName,
              Sheets: []
          };
      }

      $scope.uploadFile= function () {
          Employees.uploadFile($scope.file).then(function (data) {
              changeMod(data);
          }, function (error) {
              $scope.errors = error.error_description;
          })
      }

      $scope.genrateData = function () {

          Employees.genrateData($scope.data).then(function (data) {
              $location.path('/');
          }, function (error) {
              $scope.errors = error.error_description;
          })
      }

  }]);
