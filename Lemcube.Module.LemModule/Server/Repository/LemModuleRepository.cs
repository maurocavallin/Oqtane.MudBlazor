using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;

namespace Lemcube.Module.LemModule.Repository
{
    public class LemModuleRepository : ILemModuleRepository, ITransientService
    {
        private readonly IDbContextFactory<LemModuleContext> _factory;

        public LemModuleRepository(IDbContextFactory<LemModuleContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.LemModule> GetLemModules(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.LemModule.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.LemModule GetLemModule(int LemModuleId)
        {
            return GetLemModule(LemModuleId, true);
        }

        public Models.LemModule GetLemModule(int LemModuleId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.LemModule.Find(LemModuleId);
            }
            else
            {
                return db.LemModule.AsNoTracking().FirstOrDefault(item => item.LemModuleId == LemModuleId);
            }
        }

        public Models.LemModule AddLemModule(Models.LemModule LemModule)
        {
            using var db = _factory.CreateDbContext();
            db.LemModule.Add(LemModule);
            db.SaveChanges();
            return LemModule;
        }

        public Models.LemModule UpdateLemModule(Models.LemModule LemModule)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(LemModule).State = EntityState.Modified;
            db.SaveChanges();
            return LemModule;
        }

        public void DeleteLemModule(int LemModuleId)
        {
            using var db = _factory.CreateDbContext();
            Models.LemModule LemModule = db.LemModule.Find(LemModuleId);
            db.LemModule.Remove(LemModule);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.LemModule>> GetLemModulesAsync(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return await db.LemModule.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.LemModule> GetLemModuleAsync(int LemModuleId)
        {
            return await GetLemModuleAsync(LemModuleId, true);
        }

        public async Task<Models.LemModule> GetLemModuleAsync(int LemModuleId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.LemModule.FindAsync(LemModuleId);
            }
            else
            {
                return await db.LemModule.AsNoTracking().FirstOrDefaultAsync(item => item.LemModuleId == LemModuleId);
            }
        }

        public async Task<Models.LemModule> AddLemModuleAsync(Models.LemModule LemModule)
        {
            using var db = _factory.CreateDbContext();
            db.LemModule.Add(LemModule);
            await db.SaveChangesAsync();
            return LemModule;
        }

        public async Task<Models.LemModule> UpdateLemModuleAsync(Models.LemModule LemModule)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(LemModule).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return LemModule;
        }

        public async Task DeleteLemModuleAsync(int LemModuleId)
        {
            using var db = _factory.CreateDbContext();
            Models.LemModule LemModule = db.LemModule.Find(LemModuleId);
            db.LemModule.Remove(LemModule);
            await db.SaveChangesAsync();
        }
    }
}
