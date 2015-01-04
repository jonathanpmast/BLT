using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
namespace BLT.Data
{
    public class DevInitializer : DropCreateDatabaseIfModelChanges<BLTContext>
    {
        protected override void Seed(BLTContext context)
        {
            base.Seed(context);
            Seeder.Go(context);
        }
    }

    public class ReleaseInitializer :CreateDatabaseIfNotExists<BLTContext>
    {
        protected override void Seed(BLTContext context)
        {
            base.Seed(context);
            Seeder.Go(context);
        }
    }

    internal static class Seeder
    {
        public static void Go(BLTContext context)
        {
            BLT.Data.Seed.Lookups.Seed(context);
        }
    }
}
