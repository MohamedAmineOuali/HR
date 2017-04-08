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
            var details = new ExcelFile { FileName=fileName, ExcelDetail = new List<SheetExcel>() };
            var worksheetNames = excel.GetWorksheetNames();
            foreach(string sheetName in worksheetNames)
            {
                var sheet = new SheetExcel {Columns=new List<string>() };
                sheet.Name = sheetName;
                var columnNames = excel.GetColumnNames(sheetName);
                foreach (string columnName in columnNames)
                    sheet.Columns.Add(columnName);
                details.ExcelDetail.Add(sheet);
            }
            return details;
        }



        public void GenerateData(ExcelFile f)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/" + f.FileName);
            var excel = new ExcelQueryFactory(path);


            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                foreach (var sheet in f.ExcelDetail)
                {
                    if (sheet.Columns.Count > 0)
                    {
                        var employees = from c in excel.Worksheet<Employe>(sheet.Name)
                                        select c;
                        foreach (var employe in employees)
                            db.Employes.Add(employe);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}