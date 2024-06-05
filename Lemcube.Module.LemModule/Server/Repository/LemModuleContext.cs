using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Lemcube.Module.LemModule.Repository
{
    public class LemModuleContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.LemModule> LemModule { get; set; }

        public LemModuleContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.LemModule>().ToTable(ActiveDatabase.RewriteName("LemcubeLemModule"));
        }
    }
}
