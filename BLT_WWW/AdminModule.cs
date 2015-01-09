using BLT.Core.Import;
using BLT.Core.Logging;
using BLT.Core.Models;
using BLT.Data;
using BLT.WWW.ViewModels;
using BLT.WWW.Serialization;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BLT.WWW
{
    public class AdminModule : NancyModule
    {
        private readonly static ILog logger = LogProvider.GetCurrentClassLogger();
        public AdminModule(IRootPathProvider rootPathProvider)
            : base("admin")
        {
            Get["/"] = _ => View["admin/index.cshtml"];
            Get["/ksk"] = _ =>
            {
                logger.Debug("Get: admin/ksk (/ksk)");
                return View["admin/ksk/lootwheel_upload.cshtml"];

            };

            Get["/ksk/upload"] = _ =>
            {
                //// this is just for testing!
                //string contents = File.ReadAllText(Path.Combine(rootPathProvider.GetRootPath(), @"sample data", "sample_all_lists_export.xml"));
                //KSKUploadResults results = new KSKUploadResults();
                //results.ImportData = KSKListImportResult.Load(contents);
                //results.CheckUsersAgainstDatabase();
                //return View["admin/lootwheel_confirm.cshtml", results];
                logger.Debug("Get: admin/ksk/upload");
                return View["admin/ksk/lootwheel_upload.cshtml"];

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
                results.CheckUsersAgainstDatabase();
                logger.Debug("Post: ksk/upload: (ksk/upload) done");
                return View["admin/ksk/lootwheel_confirm.cshtml", results];
            };

            Post["/ksk/save"] = _ =>
            {
                logger.Debug("Post: ksk/save (/ksk/save)");
                KSKSaveViewModel vm = new KSKSaveViewModel();
                string base64 = this.Request.Form["importData"];
                byte[] bytes = Convert.FromBase64String(base64);
                string json = System.Text.Encoding.UTF32.GetString(bytes);
                vm.ImportData = json.FromJson<KSKListImportResult>();

                using (BLTContext context = new BLTContext())
                {
                    var classes = context.Classes.ToList();
                    foreach (var u in vm.ImportData.Users.Where(u => !u.IsInDatabase))
                    {
                        logger.DebugFormat("Adding New User: {0} | {1}", u.Name, u.Class.Name);
                        var nameParts = u.Name.Split('-');
                        context.Characters.Add(
                            new PlayerCharacter()
                            {
                                Name = nameParts[0],
                                ServerName = nameParts[1],
                                Class = classes.First(c => c.KSKExportName.Equals(u.Class.Name,StringComparison.OrdinalIgnoreCase))
                            }
                        );
                        context.SaveChanges();                        
                    }

                    foreach(var list in vm.ImportData.Lists)
                    {
                        var lootWheel = new LootWheel();
                        lootWheel.Title = list.Name;
                        lootWheel.ExportDate = vm.ImportData.ExportDate;
                        lootWheel.CharacterPositions = new List<LootWheelPosition>();
                        for (int i = 0; i < list.Users.Count; i++)
                        {
                            string[] nameParts = list.Users[i].User.Name.Split('-');
                            string firstName = nameParts[0];
                            string serverName = nameParts[1];
                            LootWheelPosition position = new LootWheelPosition()
                            {
                                Position = i + 1,
                                PlayerCharacter = context.Characters.First(c => c.Name == firstName && c.ServerName == serverName)
                            };
                            position.Wheel = lootWheel;
                            lootWheel.CharacterPositions.Add(position);
                        }
                        context.LootWheel.Add(lootWheel);
                    }
                    context.SaveChanges();
                }
                logger.Debug("Post: ksk/save (/ksk/save) done");
                return View["admin/ksk/lootwheel_save.cshtml", vm];
            };
        }
    }
}