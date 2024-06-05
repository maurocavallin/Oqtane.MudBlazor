using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lemcube.Module.LemModule.Services
{
    public interface ILemModuleService 
    {
        Task<List<Models.LemModule>> GetLemModulesAsync(int ModuleId);

        Task<Models.LemModule> GetLemModuleAsync(int LemModuleId, int ModuleId);

        Task<Models.LemModule> AddLemModuleAsync(Models.LemModule LemModule);

        Task<Models.LemModule> UpdateLemModuleAsync(Models.LemModule LemModule);

        Task DeleteLemModuleAsync(int LemModuleId, int ModuleId);
    }
}
