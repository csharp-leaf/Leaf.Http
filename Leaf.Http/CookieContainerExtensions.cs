using System;
using System.Net;

namespace Leaf.Http
{
    public static class CookieContainerExtensions
    {
        #region Set

        public static void Set(this CookieContainer cc, string url, string name, string value)
        {
            Set(cc, new Uri(url), name, value);
        }

        public static void Set(this CookieContainer cc, Uri uri, string name, string value)
        {
            var cookies = cc.GetCookies(uri);
            // Remove old one if exists
            foreach (Cookie cookie in cookies)
            {
                if (cookie.Name != name) 
                    continue;

                cookie.Expired = true;
                break;
            }

            cc.Add(uri, new Cookie(name, value));
        }

        #endregion


        #region Clear

        public static void Clear(this CookieContainer cc, string url) => Clear(cc, new Uri(url));
        public static void Clear(this CookieContainer cc, Uri uri)
        {
            var cookies = cc.GetCookies(uri);
            foreach (Cookie cookie in cookies)
                cookie.Expired = true;
        }

        #endregion


        #region Remove

        public static bool Remove(this CookieContainer cc, string url, string name) => Remove(cc, new Uri(url), name);
        public static bool Remove(this CookieContainer cc, Uri uri, string name)
        {
            var cookies = cc.GetCookies(uri);
            foreach (Cookie cookie in cookies)
            {
                if (cookie.Name != name) 
                    continue;

                cookie.Expired = true;
                return true;
            }

            return false;
        }

        #endregion
    }
}