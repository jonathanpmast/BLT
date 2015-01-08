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
                return View["Home/index.cshtml"];
            };
        }
    }
}