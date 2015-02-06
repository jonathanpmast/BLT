using Nancy.ViewEngines.Razor;
using System;
using System.Text;

namespace BLT.WWW.Helpers
{
    public static class BltUrl
    {
        public static IHtmlString Content<T>(this HtmlHelpers<T> helper, string content)
        {
            string val = "";
            val = Combine(helper.RenderContext.Context.Request.Url.BasePath, @"Content", content);
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
            if (url1.Length == 0)
            {
                return url2;
            }

            if (url2.Length == 0)
            {
                return url1;
            }

            url1 = url1.TrimEnd('/', '\\');
            url2 = url2.TrimStart('/', '\\');

            return string.Format("{0}/{1}", url1, url2);
        }
    }
}