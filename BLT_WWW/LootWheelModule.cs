namespace BLT.WWW
{
    using Nancy;
    using BLT.Core.Models;
    using BLT.Core.Logging;
    using BLT.Core.Import;
    using System.Linq;
    using System.IO;
    using System;
    using BLT.WWW.ViewModels.sk;
    public class LootWheelModule : NancyModule
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();
        public LootWheelModule()
            : base("sk")
        {
            Get["/"] = _ =>
            {
                logger.Debug("Get: Lootwheel (/sk)");
                LootWheelIndexViewModel vm = new LootWheelIndexViewModel();
                vm.GetLootWheels();
                return View["sk/index.cshtml",vm];
            };

            
        }
    }
}