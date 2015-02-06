using Nancy.ViewEngines.Razor;
using System;
using System.Text;

using BLT.Core.Logging;
namespace BLT.WWW.Helpers
{
    public static class BltUrl
    {
        private static readonly ILog logger = LogProvider.GetCurrentClassLogger();
        public static IHtmlString Content<T>(this HtmlHelpers<T> helper, string content)
        {
            string val = "";
            val = Combine(!string.IsNullOrWhiteSpace(helper.RenderContext.Context.Request.Url.BasePath) ? helper.RenderContext.Context.Request.Url.BasePath : @"/", @"Content", content);
            return new EncodedHtmlString(val);
        }


        public static string Combine(params string[] parts)
        {            
            if (parts == null || parts.Length == 0) return string.Empty;
            string url = "";
            foreach (var part in parts)
            {
                url = UrlCombine(url, part);
            }
            return url;
        }

        private static string UrlCombine(string url1, string url2)
        {
            logger.DebugFormat("Combining string {0} and {1}", url1, url2);
            if (string.IsNullOrWhiteSpace(url1))
            {
                return url2;
            }

            if (string.IsNullOrWhiteSpace(url2))
            {
                return url1;
            }

            url1 = url1.TrimEnd('/', '\\');
            url2 = url2.TrimStart('/', '\\');

            return string.Format("{0}/{1}", url1, url2);
        }
    }
}