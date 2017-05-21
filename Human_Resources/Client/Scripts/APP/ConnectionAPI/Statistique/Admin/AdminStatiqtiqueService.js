var module = angular.module('myApp.Statistique');
module.factory('AdminStatistiqueFactory', ['Employees','Comptes','Departement','Etablissements','Conges', function (emp,compte,dep,etab,conge) {

    fac = {};
 
    function resolveReferences(json) {
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



    fac.nbEmploye = function () {

        var emps = emp.GetAllEmployees();
        return resolveReferences(emps);



    }

    fac.nbResponsable = function () {
        var resps = compte.GetAllComptesResponsable();
        return resolveReferences(resps);

    }
    fac.nbDepartement = function () {
        var deps = dep.GetAllDep();
        return resolveReferences(deps);

    }
    fac.nbEtablissement = function () {
        var etabs = etab.GetAllEtablissement();
        return resolveReferences(etabs);

    }
    fac.EmpByEtab = function () {
        var etabs = etab.GetEmpByEtab();
        return resolveReferences(etabs);

    }
    fac.nbConge = function () {
        var etabs = conge.ActiveConge();
        return resolveReferences(etabs);

    }
    fac.EmpByDep = function () {
        var deps = dep.GetEmpByDep();
        return resolveReferences( deps);

    }



    



    return fac;
}
    ]); 