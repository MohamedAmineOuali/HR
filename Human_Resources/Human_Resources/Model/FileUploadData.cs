using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Human_Resources.Model
{
    public class FileUploadData
    {
        public string Base64Data { get; set; }
        public int Filesize { get; set; }
        public string Filetype { get; set; }
        public string Filename { get; set; }
    }
}