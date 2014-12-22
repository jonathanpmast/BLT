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

            Get["/admin"] = _ =>
            {                
                logger.Debug("Get: admin (/admin)");
                return View["sk/admin.cshtml"];
                
            };

            Post["/admin/upload"] = _ =>
            {
                logger.Debug("Post: upload (/admin/upload)");
                var file = this.Request.Files.FirstOrDefault();
                string contents = string.Empty;
                if (file == null)
                {
                    throw new Exception("You didn't upload a file! I probably should catch this exception earlier!");
                }
                using (StreamReader sr = new StreamReader(file.Value))
                {
                    logger.Debug("Post: upload: reading file contents");
                    contents = sr.ReadToEnd();
                    logger.Debug("Post: upload: succesfully read file contents");
                }
                logger.Debug("Post: upload: parsing XML with ListImportResult class");
                KSKListImportResult results = KSKListImportResult.Load(contents);
                logger.Debug("Post: upload: (/admin/upload) done");
                return View["sk/upload_results.cshtml", results];
            };
        }
    }
}