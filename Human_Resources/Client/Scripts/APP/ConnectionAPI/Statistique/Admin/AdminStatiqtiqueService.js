var module = angular.module('myApp.Statistique');
module.factory('AdminStatistiqueFactory', ['Employees','Comptes','Departement','Etablissements','Conges', function (emp,compte,dep,etab,conge) {

    fac = {};
    fac.nbEmploye = function () {

        var emps = emp.GetAllEmployees();
        return emps; 



    }
    fac.nbResponsable = function () {
        var resps = compte.GetAllComptesResponsable();
        return resps;

    }
    fac.nbDepartement = function () {
        var deps = dep.GetAllDep();
        return deps;

    }
    fac.nbEtablissement = function () {
        var etabs = etab.GetAllEtablissement();
        return etabs;

    }
    fac.EmpByEtab = function () {
        var etabs = etab.GetEmpByEtab();
        return etabs;

    }
    fac.nbConge = function () {
        var etabs = conge.ActiveConge();
        return etabs;

    }
    fac.EmpByDep = function () {
        var deps = dep.GetEmpByDep();
        return deps;

    }



    



    return fac;
}
    ]); 