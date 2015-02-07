using BLT.WWW.ViewModels;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLT.WWW
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                HomeViewModel vm = new HomeViewModel();
                vm.RecruitingNeeds.Add(
                    new RecruitingNeedViewModel()
                    {
                        ClassName = "Druid",
                        Specs = new List<string>()
                        {
                            "Balance"
                        }
                    }
                    );
                vm.RecruitingNeeds.Add(
                    new RecruitingNeedViewModel()
                    {
                        ClassName = "Mage",
                        Specs = new List<string>(){
                            "Arcane",
                            "Frost"
                        }
                    });
                return View["Home/index.cshtml", vm];
            };

            Get["/notrecruiting"] = _ => View["Home/index.cshtml", new HomeViewModel()];
        }
    }
}