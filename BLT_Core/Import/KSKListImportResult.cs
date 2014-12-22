using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLT.Core.Import
{
    public class KSKListImportResult
    {
        public DateTime ExportDate { get; set; }

        public List<ImportClass> Classes { get; private set; }
        public List<ImportUser> Users { get; private set; }
        public List<ImportList> Lists { get; private set; }
        private KSKListImportResult()
        {

            Classes = new List<ImportClass>();
            Users = new List<ImportUser>();
            Lists = new List<ImportList>();
        }

        public static KSKListImportResult Load(string xml)
        {
            KSKListImportResult result = new KSKListImportResult();
            XDocument source = XDocument.Parse(xml);
            XElement root = source.Element(Constants.ElementNames.KSK);
            
            // get the export date and time
            result.ExportDate = DateTime.Parse(root.Attribute("date").Value);
            TimeSpan ts = TimeSpan.Parse(root.Attribute("time").Value);
            result.ExportDate += ts;
            
            // get a collection of the exported classes

            return result;
        }
    }
}
