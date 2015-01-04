using BLT.Core.Logging;
using BLT.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Data
{
    public class BLTContext : DbContext
    {
        private readonly static ILog Logger = LogProvider.GetCurrentClassLogger();

        public IDbSet<CharacterClass> Classes { get; set; }
        public IDbSet<Character> Characters { get; set; }
        public IDbSet<LootWheel> LootWheel { get; set; }
        public BLTContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            initialize();
        }

        public BLTContext()
            : base("BLT")
        {
            initialize();
        }

        private void initialize()
        {
            Logger.Debug("Begin: Initialize DB Context");
            this.Configuration.LazyLoadingEnabled = false;
#if(DEBUG)
            Logger.Debug("DEBUG enabled, setting db initializer to dev");

            Database.SetInitializer(new DevInitializer());

#else
            Logger.Debug("RELEASE enabled, setting db initializer to Release");

            Database.SetInitializer(new ReleaseInitializer());
#endif
            Logger.Debug("Finished: Initialize DB Context");
        }

        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
            {
                if ((entity.State == EntityState.Added || entity.State == EntityState.Modified) &&
                     entity.Entity is BaseModel)
                {
                    ((BaseModel)entity.Entity).DateCreated = DateTime.Now;
                    ((BaseModel)entity.Entity).DateUpdated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
