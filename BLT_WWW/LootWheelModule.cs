namespace BLT.WWW
{
    using Nancy;
    using BLT.Core.Models;
using BLT.Core.Logging;
    public class LootWheelModule : NancyModule
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();
        public LootWheelModule() {
            Get["sk"] = _ =>
            {
                logger.Debug("Get: Lootwheel (/sk)");
                TestModel tm = new TestModel() { Message = System.Web.Configuration.WebConfigurationManager.AppSettings["TestKey"] };
                return View["sk/index.cshtml",tm];
            };
        }
    }
}