using BLT.Core.Logging;
using BLT.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLT.Data
{
    public class MySqlHistoryContext : HistoryContext
    {
        public MySqlHistoryContext(
          DbConnection existingConnection,
          string defaultSchema)
            : base(existingConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }


    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext(
            "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }


    public class BLTContext : DbContext
    {
        private readonly static ILog Logger = LogProvider.GetCurrentClassLogger();

        public IDbSet<CharacterClass> Classes { get; set; }
        public IDbSet<PlayerCharacter> Characters { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
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
