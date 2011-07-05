using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using VTCO.Utils;

namespace WorkFlowBLL
{
    public class CookieManagement
    {
        private RijndaelEnhanced m_rijn = new RijndaelEnhanced(VTCO.Config.Constants.PRIVATE_KEY, VTCO.Config.Global.Settings.PublicKey);
        /// <summary>
        /// Tạo &amp; lấy thông tin Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isHttpOnly"></param>
        /// <returns></returns>
        public string this[string name, bool isHttpOnly]
        {
            set
            {
                HttpCookie cookie = new HttpCookie(name, value);
                cookie.Expires = DateTime.Now.AddMonths(1);
                cookie.HttpOnly = isHttpOnly;
                if (HttpContext.Current.Request.Cookies[name] == null)
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Set(cookie);
                }
            }
        }
        public string this[string name]
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[name] == null)
                    return null;
                return HttpContext.Current.Request.Cookies[name].Value;
            }
            set
            {
                this[name, true] = value;
            }
        }

        public string UserName
        {
            get
            {
                return GetCookie("UserName");
            }
            set
            {
                if (value == null)
                {
                    DeleteCookie("UserName");
                }
                else
                {
                    SetCookie("UserName", value);
                }
            }
        }

        public string Password
        {
            get
            {
                try
                {
                    return m_rijn.Decrypt(GetCookie("Password"));
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value == null)
                {
                    DeleteCookie("Password");
                }
                else
                {
                    SetCookie("Password", m_rijn.Encrypt(value));
                }
            }
        }
        /// <summary>
        /// BoxMusicID
        /// </summary>
        public string BoxMusicID
        {
            get
            {
                try
                {
                    return GetCookie("BoxMusicID");
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value == null)
                {
                    DeleteCookie("BoxMusicID");
                }
                else
                {
                    SetCookie("BoxMusicID", value);
                }
            }
        }
        /// <summary>
        /// Lấy giá trị của Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Domain = "";
                cookie.Path = "/";
                return cookie.Value;
            }
            return null;
        }

        /// <summary>
        /// Thiết lập giá trị cho cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="value"></param>
        public void SetCookie(string cookieName, string value)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Domain = "";
            cookie.Path = "/";
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Xóa Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public void DeleteCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Domain = "";
                cookie.Path = "/";
                cookie.Expires = DateTime.Now.AddMonths(-1);
            }
        }
        private static CookieManagement m_istance;

        public static CookieManagement Instance
        {
            get
            {
                if (m_istance == null)
                {
                    m_istance = new CookieManagement();
                }
                return m_istance;
            }
        }
    }
}
