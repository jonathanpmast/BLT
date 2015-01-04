using BLT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Data.Seed
{
    internal static class Lookups
    {
        private static readonly string[] CLASSES = {
                                                       "Death Knight",
                                                       "Priest",
                                                       "Rogue",
                                                       "Monk",
                                                       "Warrior",
                                                       "Druid",
                                                       "Paladin",
                                                       "Shaman",
                                                       "Mage",
                                                       "Hunter",
                                                       "Warlock"
                                                   };
        internal static void Seed(BLTContext context)
        {
            while (context.Classes.Count() > 0)
            {
                context.Classes.Remove(context.Classes.First());

            }

            context.SaveChanges();

            foreach (string c in CLASSES)
            {
                context.Classes.Add(new CharacterClass() { Name = c }); 
            }
            context.SaveChanges();
        }
    }
}
