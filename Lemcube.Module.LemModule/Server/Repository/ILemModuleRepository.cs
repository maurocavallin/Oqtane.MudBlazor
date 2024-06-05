using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lemcube.Module.LemModule.Repository
{
    public interface ILemModuleRepository
    {
        IEnumerable<Models.LemModule> GetLemModules(int ModuleId);
        Models.LemModule GetLemModule(int LemModuleId);
        Models.LemModule GetLemModule(int LemModuleId, bool tracking);
        Models.LemModule AddLemModule(Models.LemModule LemModule);
        Models.LemModule UpdateLemModule(Models.LemModule LemModule);
        void DeleteLemModule(int LemModuleId);

        Task<IEnumerable<Models.LemModule>> GetLemModulesAsync(int ModuleId);
        Task<Models.LemModule> GetLemModuleAsync(int LemModuleId);
        Task<Models.LemModule> GetLemModuleAsync(int LemModuleId, bool tracking);
        Task<Models.LemModule> AddLemModuleAsync(Models.LemModule LemModule);
        Task<Models.LemModule> UpdateLemModuleAsync(Models.LemModule LemModule);
        Task DeleteLemModuleAsync(int LemModuleId);
    }
}
