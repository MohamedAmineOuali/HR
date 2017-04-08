using Human_Resources.Metier.Model;
using Human_Resources.Model;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Human_Resources.Metier.Traitement
{
    public class EmployeesManager
    {
        public ExcelFile SaveFile(Byte[] filebytes)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xlsx";
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/" + fileName);
            File.WriteAllBytes(path, filebytes);

            var excel = new ExcelQueryFactory(path);
            var details = new ExcelFile { FileName=fileName, Sheets = new List<string>() };
            var worksheetNames = excel.GetWorksheetNames();
            foreach(string sheetName in worksheetNames)
            {
                details.Sheets.Add(sheetName);
            }
            return details;
        }



        public void GenerateData(ExcelFile f)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/" + f.FileName);
            var excel = new ExcelQueryFactory(path);


            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                foreach (var sheet in f.Sheets)
                {
                    var employees = from c in excel.Worksheet<Employe>(sheet)
                                    select c;
                    foreach (var employe in employees)
                        db.Employes.Add(employe);
                }
                db.SaveChanges();
            }
        }
    }
}