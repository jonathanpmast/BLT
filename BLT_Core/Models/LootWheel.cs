using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Core.Models
{
    public class LootWheel : BaseModel
    {
        public string Title { get; set; }
        public DateTime ExportDate { get; set; }
        public virtual IList<LootWheelPosition> CharacterPositions{get; set;}

        public LootWheel()
        {
            CharacterPositions = new List<LootWheelPosition>();
        }

    }
}
