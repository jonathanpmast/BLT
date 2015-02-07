using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BLT.Core;
using System.Text;

namespace BLT.WWW.ViewModels
{
    public class RecruitingNeedViewModel
    {
        const string IMG_PATH_FMT = @"/img/class_{0}.jpg";
        public string ClassName { get; set; }
        public IList<string> Specs { get; set; }
        public string SpecsDisplay
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in Specs)
                {
                    if (sb.Length > 0)
                        sb.Append(", ");
                    sb.Append(s);
                }
                return sb.ToString();
            }
        }
        public string IconUrl
        {
            get
            {
                string url = string.Empty;
                switch (ClassName)
                {
                    case Constants.DEATH_KNIGHT:
                        url = String.Format(IMG_PATH_FMT, "deathknight");
                        break;
                    case Constants.DRUID:
                        url = String.Format(IMG_PATH_FMT, @"druid");
                        break;
                    case Constants.HUNTER:
                        url = String.Format(IMG_PATH_FMT, @"deathknight");
                        break;
                    case Constants.MAGE:
                        url = String.Format(IMG_PATH_FMT, "mage");
                        break;
                    case Constants.MONK:
                        url = String.Format(IMG_PATH_FMT, "monk");
                        break;
                    case Constants.PALADIN:
                        url = String.Format(IMG_PATH_FMT, "paladin");
                        break;
                    case Constants.PRIEST:
                        url = String.Format(IMG_PATH_FMT, "priest");
                        break;
                    case Constants.ROGUE:
                        url = String.Format(IMG_PATH_FMT, "rogue");
                        break;
                    case Constants.SHAMAN:
                        url = String.Format(IMG_PATH_FMT, "shaman");
                        break;
                    case Constants.WARLOCK:
                        url = String.Format(IMG_PATH_FMT, "warlock");
                        break;
                    case Constants.WARRIOR:
                        url = String.Format(IMG_PATH_FMT, "WARRIOR");
                        break;
                    default:
                        url = String.Format(IMG_PATH_FMT, "none");
                        break;

                }
                return url;
            }
        }
    }
}