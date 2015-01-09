using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using BLT.Core.Logging;
namespace BLT.Data
{
    public class DevInitializer : DropCreateDatabaseAlways<BLTContext>
    {
        private readonly static ILog Logger = LogProvider.GetCurrentClassLogger();
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
        private readonly static ILog Logger = LogProvider.GetCurrentClassLogger();
        public static void Go(BLTContext context)
        {
            Logger.Debug("Seeding data for Lookups");
            BLT.Data.Seed.Lookups.Seed(context);
            Logger.Debug("Done seeding data");
        }
    }
}
