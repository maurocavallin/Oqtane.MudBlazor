using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Security;
using Oqtane.Shared;
using Lemcube.Module.LemModule.Repository;

namespace Lemcube.Module.LemModule.Services
{
    public class ServerLemModuleService : ILemModuleService, ITransientService
    {
        private readonly ILemModuleRepository _LemModuleRepository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerLemModuleService(ILemModuleRepository LemModuleRepository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _LemModuleRepository = LemModuleRepository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public async Task<List<Models.LemModule>> GetLemModulesAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return (await _LemModuleRepository.GetLemModulesAsync(ModuleId)).ToList();
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public async Task<Models.LemModule> GetLemModuleAsync(int LemModuleId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return await _LemModuleRepository.GetLemModuleAsync(LemModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Get Attempt {LemModuleId} {ModuleId}", LemModuleId, ModuleId);
                return null;
            }
        }

        public async Task<Models.LemModule> AddLemModuleAsync(Models.LemModule LemModule)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, LemModule.ModuleId, PermissionNames.Edit))
            {
                LemModule = await _LemModuleRepository.AddLemModuleAsync(LemModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LemModule Added {LemModule}", LemModule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Add Attempt {LemModule}", LemModule);
                LemModule = null;
            }
            return LemModule;
        }

        public async Task<Models.LemModule> UpdateLemModuleAsync(Models.LemModule LemModule)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, LemModule.ModuleId, PermissionNames.Edit))
            {
                LemModule = await _LemModuleRepository.UpdateLemModuleAsync(LemModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LemModule Updated {LemModule}", LemModule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Update Attempt {LemModule}", LemModule);
                LemModule = null;
            }
            return LemModule;
        }

        public async Task DeleteLemModuleAsync(int LemModuleId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                await _LemModuleRepository.DeleteLemModuleAsync(LemModuleId);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LemModule Deleted {LemModuleId}", LemModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Delete Attempt {LemModuleId} {ModuleId}", LemModuleId, ModuleId);
            }
        }
    }
}
