using BLT.Core.Import;
using BLT.Core.Logging;
using BLT.WWW.ViewModels;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BLT.WWW
{
    public class AdminModule :NancyModule
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();
        public AdminModule()
            : base("admin")
        {
            Get["/ksk"] = _ =>
            {
                logger.Debug("Get: admin/ksk (/ksk)");
                return View["admin/lootwheel.cshtml"];

            };

            Post["/ksk/upload"] = _ =>
            {
                logger.Debug("Post: ksk/upload (/ksk/upload)");
                var file = this.Request.Files.FirstOrDefault();
                string contents = string.Empty;
                KSKUploadResults results = new KSKUploadResults();
                if (file == null)
                {
                    throw new Exception("You didn't upload a file! I probably should catch this exception earlier!");
                }
                using (StreamReader sr = new StreamReader(file.Value))
                {
                    logger.Debug("Post: ksk/upload: reading file contents");
                    contents = sr.ReadToEnd();
                    logger.Debug("Post: ksk/upload: succesfully read file contents");
                }
                logger.Debug("Post: ksk/upload: parsing XML with ListImportResult class");
                results.ImportData = KSKListImportResult.Load(contents);
                logger.Debug("Post: ksk/upload: (ksk/upload) done");
                return View["admin/lootwheel_upload.cshtml", results];
            };

            Post["/ksk/save"] = _ =>
            {
                logger.Debug("Post: ksk/save (/ksk/save)");
                KSKSaveViewModel vm = this.Bind<KSKSaveViewModel>();
                

            };
        }
    }
}