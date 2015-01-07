using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public class Character : BaseModel
    {
        public string Name { get; set; }
        public virtual Character Parent { get; set; }
        public CharacterClass Class { get; set; }
        public string ServerName { get; set; }
    }
}
