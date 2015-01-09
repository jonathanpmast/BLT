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
        private static readonly Dictionary<string,string> CLASSES = new Dictionary<string,string>(){
                                                       {"Death Knight","deathknight"},
                                                       {"Priest","priest"},
                                                       {"Rogue","rogue"},
                                                       {"Monk","monk"},
                                                       {"Warrior","warrior"},
                                                       {"Druid","druid"},
                                                       {"Paladin","paladin"},
                                                       {"Shaman","shaman"},
                                                       {"Mage","mage"},
                                                       {"Hunter","hunter"},
                                                       {"Warlock","warlock"}
                                                   };
        internal static void Seed(BLTContext context)
        {
            while (context.Classes.Count() > 0)
            {
                context.Classes.Remove(context.Classes.First());

            }

            context.SaveChanges();

            foreach (var c in CLASSES)
            {
                context.Classes.Add(new CharacterClass() { Name = c.Key, KSKExportName = c.Value }); 
            }
            context.SaveChanges();
        }
    }
}
