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
            result.Classes.AddRange(from el in root.Element(Constants.ElementNames.CLASSES).Elements(Constants.ElementNames.CLASS)
                                    select new ImportClass()
                                    {
                                        Id = int.Parse(el.Attribute("id").Value),
                                        Name = el.Attribute("v").Value
                                    });

            // get the users
            result.Users.AddRange(from el in root.Element(Constants.ElementNames.USERS).Elements(Constants.ElementNames.USER)
                                  select new ImportUser()
                                  {
                                      Id = el.Attribute("id").Value,
                                      Name = el.Attribute("n").Value,
                                      Class = result.Classes.FirstOrDefault(c => c.Id == int.Parse(el.Attribute("c").Value))
                                  });

            // get the lootwheels
            result.Lists.AddRange(from el in root.Element(Constants.ElementNames.LISTS).Elements(Constants.ElementNames.LIST)
                                  select new ImportList()
                                  {
                                      Id = el.Attribute("id").Value,
                                      Name = el.Attribute("n").Value,
                                      Users = new List<ImportListUser>(
                                          from elUser in el.Elements(Constants.ElementNames.USER)                                        
                                          select new ImportListUser(){ User = result.Users.FirstOrDefault(u => u.Id == elUser.Attribute("id").Value)}
                                          )
                                  });            
            return result;
        }
    }
}
