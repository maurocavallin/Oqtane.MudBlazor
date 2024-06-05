using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace Lemcube.Module.LemModule.Services
{
    public class LemModuleService : ServiceBase, ILemModuleService, IService
    {
        public LemModuleService(IHttpClientFactory http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("LemModule");

        public async Task<List<Models.LemModule>> GetLemModulesAsync(int ModuleId)
        {
            List<Models.LemModule> LemModules = await GetJsonAsync<List<Models.LemModule>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.LemModule>().ToList());
            return LemModules.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.LemModule> GetLemModuleAsync(int LemModuleId, int ModuleId)
        {
            return await GetJsonAsync<Models.LemModule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LemModuleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.LemModule> AddLemModuleAsync(Models.LemModule LemModule)
        {
            return await PostJsonAsync<Models.LemModule>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, LemModule.ModuleId), LemModule);
        }

        public async Task<Models.LemModule> UpdateLemModuleAsync(Models.LemModule LemModule)
        {
            return await PutJsonAsync<Models.LemModule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LemModule.LemModuleId}", EntityNames.Module, LemModule.ModuleId), LemModule);
        }

        public async Task DeleteLemModuleAsync(int LemModuleId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{LemModuleId}", EntityNames.Module, ModuleId));
        }
    }
}
