using System.Web;
using VTCO.Config;

namespace VTCeBank.SSO.Utils
{
    public class SSOHelper
    {
        static string CACHE_KEY = "VTCeBank.SSO.Utils.CACHE_KEY";
        static string webRoot = Global.Settings.WebRoot.Remove(Global.Settings.WebRoot.Length - 1);


        public static string GetSSOKey()
        {
            return HttpRuntime.Cache.Get(CACHE_KEY) == null ? string.Empty : (string)HttpRuntime.Cache.Get(CACHE_KEY); ;
        }

        public static void SetSSOKey(string ssoKey)
        {
            // add key with time out 24h.
            HttpRuntime.Cache.Insert(CACHE_KEY, ssoKey); ;
        }


        public static string URLLogin
        {
            get
            {
                return string.Format("{0}/accounts/sso/login/?sid={1}&ur={2}&m=1&continue={3}",
                    Global.Settings.GO_SSO_SERVER,            // SSO_SERVER_LOGIN address            
                    Global.Settings.GO_SSO_SITE_ID,    // SERVICE_PROVIDER_SITE_ID hãy đăng ký với SSO server
                    HttpUtility.UrlEncode(webRoot + HttpContext.Current.Request.Url.AbsolutePath),      // ur
                    Global.Settings.GO_SSO_URL_CONTINUE      // URL Recived User Data
                   );
            }
        }


        public static string URLCheckLogin
        {
            get
            {
                return string.Format("{0}/accounts/sso/login/?sid={1}&ur={2}&m=0&continue={3}",
                      Global.Settings.GO_SSO_SERVER,            // SSO_SERVER_LOGIN address            
                      Global.Settings.GO_SSO_SITE_ID,    // SERVICE_PROVIDER_SITE_ID hãy đăng ký với SSO server
                        HttpUtility.UrlEncode(webRoot + HttpContext.Current.Request.Url.AbsolutePath),    // ur,
                        Global.Settings.GO_SSO_URL_CONTINUE    // URL Recived User Data
                      );
            }
        }

        public static string URLLogout
        {
            get
            {
                return string.Format("{0}/accounts/sso/logout/?ur={1}", Global.Settings.GO_SSO_SERVER, HttpUtility.UrlEncode(webRoot + HttpContext.Current.Request.Url.AbsolutePath));
            }
        }



        public static string GetURLLogout(string returnUrl)
        {

            return string.Format("{0}/accounts/sso/logout/?ur={1}", Global.Settings.GO_SSO_SERVER, HttpUtility.UrlEncode(returnUrl));

        }

        public static string GetURLLogin(string returnUrl)
        {
            return string.Format("{0}/accounts/sso/login/?sid={1}&ur={2}&m=1&continue={3}",
                Global.Settings.GO_SSO_SERVER,                   // SSO_SERVER_LOGIN address            
                Global.Settings.GO_SSO_SITE_ID,    // SERVICE_PROVIDER_SITE_ID hãy đăng ký với SSO server
                HttpUtility.UrlEncode(returnUrl),      // ur
                Global.Settings.GO_SSO_URL_CONTINUE      // URL Recived User Data
               );
        }
    }
}
