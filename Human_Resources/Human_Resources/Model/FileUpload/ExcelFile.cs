using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Human_Resources.Model
{
    public class ExcelFile
    {
        public string FileName { get; set; }
        public List<string> Sheets { get; set; }
    }
}