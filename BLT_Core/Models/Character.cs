using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public class PlayerCharacter : BaseModel
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public virtual PlayerCharacter Parent { get; set; }

        public int ClassId { get; set; }
        public virtual CharacterClass Class { get; set; }

        public string ServerName { get; set; }

        public ICollection<LootWheelPosition> LootWheelPositions { get; set; }
    }
}
