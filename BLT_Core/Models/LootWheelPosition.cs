using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public class LootWheelPosition : BaseModel
    {
        public virtual LootWheel Wheel { get; set; }
        public int WheelId { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public int PlayerCharacerId { get; set; }

        public int Position { get; set; }
    }
}
