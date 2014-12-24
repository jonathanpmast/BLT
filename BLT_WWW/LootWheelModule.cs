namespace BLT.WWW
{
    using Nancy;
    using BLT.Core.Models;
    using BLT.Core.Logging;
    using BLT.Core.Import;
    using System.Linq;
    using System.IO;
    using System;
    public class LootWheelModule : NancyModule
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();
        public LootWheelModule()
            : base("sk")
        {
            Get["/"] = _ =>
            {
                logger.Debug("Get: Lootwheel (/sk)");
                TestModel tm = new TestModel() { Message = System.Web.Configuration.WebConfigurationManager.AppSettings["TestKey"] };
                return View["sk/index.cshtml", tm];
            };

            
        }
    }
}