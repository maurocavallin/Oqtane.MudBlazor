using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using System.Collections.Generic;

namespace Lemcube.Module.LemModule
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LemModule",
            Description = "ssss",
            Version = "1.0.1",
            ServerManagerType = "Lemcube.Module.LemModule.Manager.LemModuleManager, Lemcube.Module.LemModule.Server.Oqtane",
            ReleaseVersions = "1.0.1",
            Dependencies = "Lemcube.Module.LemModule.Shared.Oqtane, MudBlazor",
            PackageName = "Lemcube.Module.LemModule" ,
            Resources = new List<Resource>() {
                new Resource()
                {
                     ResourceType = ResourceType.Stylesheet,
                     Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap", // "Modules/" + GetType().Namespace + "/css/default.css"
                },
                new Resource()
                {
                     ResourceType = ResourceType.Stylesheet,
                     Url = "_content/MudBlazor/MudBlazor.min.css", // "Modules/" + GetType().Namespace + "/css/default.css"
                },
                new Resource()
                {
                     ResourceType = ResourceType.Script,
                     Url = "_content/MudBlazor/MudBlazor.min.js" // "Modules/" + GetType().Namespace + "/js/default.js"
                }
            }
        };
    }
}
