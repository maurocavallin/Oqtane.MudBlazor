using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using Lemcube.Module.LemModule.Repository;

namespace Lemcube.Module.LemModule.Manager
{
    public class LemModuleManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly ILemModuleRepository _LemModuleRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public LemModuleManager(ILemModuleRepository LemModuleRepository, IDBContextDependencies DBContextDependencies)
        {
            _LemModuleRepository = LemModuleRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LemModuleContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LemModuleContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.LemModule> LemModules = _LemModuleRepository.GetLemModules(module.ModuleId).ToList();
            if (LemModules != null)
            {
                content = JsonSerializer.Serialize(LemModules);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.LemModule> LemModules = null;
            if (!string.IsNullOrEmpty(content))
            {
                LemModules = JsonSerializer.Deserialize<List<Models.LemModule>>(content);
            }
            if (LemModules != null)
            {
                foreach(var LemModule in LemModules)
                {
                    _LemModuleRepository.AddLemModule(new Models.LemModule { ModuleId = module.ModuleId, Name = LemModule.Name });
                }
            }
        }
    }
}
