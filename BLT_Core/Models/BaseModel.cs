using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public abstract class BaseModel
    {
        long ID { get; set; }
        DateTime DateUpdated { get; set; }
        DateTime DateCreated { get; set; }
    }
}
