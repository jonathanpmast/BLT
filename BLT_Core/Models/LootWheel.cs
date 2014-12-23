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
        public List<Character> CharacterList{get; private set;}

        public LootWheel()
        {
            CharacterList = new List<Character>();
        }

    }
}
