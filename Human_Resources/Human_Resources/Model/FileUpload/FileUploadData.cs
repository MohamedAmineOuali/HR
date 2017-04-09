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

        public bool Verify()
        {
            if (!acceptedType.Contains(Filetype))
                return false;
            return true;
        }
        public byte[] GetFileBytes()
        {
            string incoming = Base64Data.Replace('_', '/').Replace('-', '+');
            switch (Base64Data.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }
            return Convert.FromBase64String(incoming);
        }

        static List<string> acceptedType = new List<string> { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };
    }
}