using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Import
{
    public class ImportList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ImportListUser> Users { get; set; }

        public ImportList()
        {
            Users = new List<ImportListUser>();
        }
    }
}
