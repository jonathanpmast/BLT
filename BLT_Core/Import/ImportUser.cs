using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Import
{
    public class ImportUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImportClass Class { get; set; }
    }
}
