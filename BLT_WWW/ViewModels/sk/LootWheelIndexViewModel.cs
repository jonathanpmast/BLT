using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BLT.Core.Models;
using BLT.Data;
using System.Data.Entity;

namespace BLT.WWW.ViewModels.sk
{
    public class LootWheelIndexViewModel
    {
        public IList<LootWheel> LootWheels { get; set; }
        public LootWheelIndexViewModel() {

        }

        public void GetLootWheels()
        {
            using (BLTContext context = new BLTContext())
            {
                
                var groups = (from lw in context.LootWheel.Include( lw => lw.CharacterPositions )
                              orderby lw.DateCreated descending
                              group lw by lw.Title into lootWheelByTitle
                              select lootWheelByTitle);
                
                LootWheels = new List<LootWheel>();
                
                foreach (var group in groups)
                {
                    LootWheels.Add(group.First());
                }                                
            }
        }
    }
}