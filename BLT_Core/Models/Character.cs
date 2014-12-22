using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public class Character
    {
        public string Name { get; set; }
        public virtual Character Parent { get; set; }
        public string Class { get; set; }

    }
}
