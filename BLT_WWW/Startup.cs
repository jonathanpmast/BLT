namespace BLT.WWW
{
    using Microsoft.Owin;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using Nancy.ViewEngines.Razor;
    using Owin;
    using System.Collections.Generic;

    using BLT.Core.Logging;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            logger.Debug("Application Startup, Start");
            base.ApplicationStartup(container, pipelines);
            logger.Debug("Application Startup, Registering RazorConfig");
            container.Register<IRazorConfiguration>(new RazorConfig());
            
            logger.Debug("Application Startup, End");
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