using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Lemcube.Module.LemModule.Repository;
using Oqtane.Controllers;
using System.Net;

namespace Lemcube.Module.LemModule.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class LemModuleController : ModuleControllerBase
    {
        private readonly ILemModuleRepository _LemModuleRepository;

        public LemModuleController(ILemModuleRepository LemModuleRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LemModuleRepository = LemModuleRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.LemModule> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _LemModuleRepository.GetLemModules(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.LemModule Get(int id)
        {
            Models.LemModule LemModule = _LemModuleRepository.GetLemModule(id);
            if (LemModule != null && IsAuthorizedEntityId(EntityNames.Module, LemModule.ModuleId))
            {
                return LemModule;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Get Attempt {LemModuleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LemModule Post([FromBody] Models.LemModule LemModule)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, LemModule.ModuleId))
            {
                LemModule = _LemModuleRepository.AddLemModule(LemModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LemModule Added {LemModule}", LemModule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Post Attempt {LemModule}", LemModule);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LemModule = null;
            }
            return LemModule;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LemModule Put(int id, [FromBody] Models.LemModule LemModule)
        {
            if (ModelState.IsValid && LemModule.LemModuleId == id && IsAuthorizedEntityId(EntityNames.Module, LemModule.ModuleId) && _LemModuleRepository.GetLemModule(LemModule.LemModuleId, false) != null)
            {
                LemModule = _LemModuleRepository.UpdateLemModule(LemModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LemModule Updated {LemModule}", LemModule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Put Attempt {LemModule}", LemModule);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LemModule = null;
            }
            return LemModule;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.LemModule LemModule = _LemModuleRepository.GetLemModule(id);
            if (LemModule != null && IsAuthorizedEntityId(EntityNames.Module, LemModule.ModuleId))
            {
                _LemModuleRepository.DeleteLemModule(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LemModule Deleted {LemModuleId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LemModule Delete Attempt {LemModuleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
