namespace BLT.WWW
{
    using Microsoft.Owin;
    using Nancy.ViewEngines.Razor;
    using Owin;
    using System.Collections.Generic;   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }

    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "BLT.WWW";
            yield return "BLT.Core";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "BLT.WWW";
            yield return "BLT.Core.Models";
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}