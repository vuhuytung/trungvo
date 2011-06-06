using VTCO.Config;
using System.Web;
using System;

namespace VTCO.Utils
{
    public class AdminUtils
    {
        private static RijndaelEnhanced m_rijndaelKey = new RijndaelEnhanced("@1B2c3D5E5F6g7H7");
        private static string m_strSeparater = "_#|#$_$_";
        /// <summary>
        /// Kiểm tra login chưa
        /// </summary>
        public static bool IsLogin
        {
            get
            {
                return !((GetCookie(Constants.COOKIE_ADMIN_ID) == string.Empty)
                    || (GetCookie(Constants.COOKIE_ADMIN_USER_NAME) == string.Empty)
                    || (GetCookie(Constants.COOKIE_ADMIN_FULL_NAME) == string.Empty)
                    || (GetCookie(Constants.COOKIE_ADMIN_COMPANY_ID ) == string.Empty)
                    || (GetCookie(Constants.COOKIE_ADMIN_LEVER) == string.Empty));
            }
        }


        /// <summary>
        /// Lấy AdminID 
        /// </summary>
        public static int AdminID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_ADMIN_ID));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy UserName của Admin
        /// </summary>
        public static string UserName
        {
            get
            {
                try
                {
                    return GetCookie(Constants.COOKIE_ADMIN_USER_NAME);
                }
                catch { }
                return "";
            }
        }

        /// <summary>
        /// Lấy tên đầy đủ của Admin
        /// </summary>
        public static string FullName
        {
            get
            {
                return GetCookie(Constants.COOKIE_ADMIN_FULL_NAME);
            }
        }

        /// <summary>
        /// Lấy xâu quyền của Admin
        /// </summary>
        public static string Permission
        {
            get
            {
                return GetCookie(Constants.COOKIE_ADMIN_PERMISSION);
            }
        }

        /// <summary>
        /// Lấy Lever của Admin
        /// </summary>
        public static int Lever
        {
            get
            {
                return Convert.ToInt32(GetCookie(Constants.COOKIE_ADMIN_LEVER));
            }
        }

        /// <summary>
        /// Lấy CompanyID Shop của User
        /// </summary>
        public static int CompanyID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_ADMIN_COMPANY_ID));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy tên công ty
        /// </summary>
        public static string CompanyName
        {
            get
            {
                return GetCookie(Constants.COOKIE_ADMIN_COMPANY_NAME);
            }
        }


        /// <summary>
        /// Lấy IPAdress
        /// </summary>
        public static string IpAddress
        {
            get
            {
                return GetCookie(Constants.COOKIE_ADMIN_IP_ADDRESS);
            }
        }

        /// <summary>
        /// Dùng để hack cho việc đăng nhập
        /// </summary>
        public static void HackLogin()
        {
            SetCookie(Constants.COOKIE_ADMIN_ID, "2");
            SetCookie(Constants.COOKIE_ADMIN_USER_NAME, "thuphuong.tran");
            SetCookie(Constants.COOKIE_ADMIN_FULL_NAME, "Trần Thu Phương");
            SetCookie(Constants.COOKIE_ADMIN_LEVER, "1");
            SetCookie(Constants.COOKIE_ADMIN_PERMISSION, "");
            SetCookie(Constants.COOKIE_ADMIN_COMPANY_ID, "1");
            SetCookie(Constants.COOKIE_ADMIN_COMPANY_NAME, "VTC Online");

        }

        #region Helper
        /// <summary>
        /// Lấy thông tin từ cookie
        /// </summary>
        /// <param name="name">Tên cookie</param>
        /// <returns>Return null khi xảy ra lỗi hoặc không tồn tại cookie </returns>
        public static string GetCookie(string name)
        {
            string CookieValue = string.Empty;
            if (System.Web.HttpContext.Current.Request.Cookies[name] != null)
            {
                try
                {
                    CookieValue = m_rijndaelKey.Decrypt(System.Web.HttpContext.Current.Request.Cookies[name].Value.ToString());
                }
                catch { }
            }
            return CookieValue;
        }

        /// <summary>
        /// Set giá trị cho cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetCookie(string name, string value)
        {
            string strValueEn = m_rijndaelKey.Encrypt(value);
            if (System.Web.HttpContext.Current.Request.Cookies[name] == null)
            {
                System.Web.HttpContext.Current.Response.Cookies.Set(new HttpCookie(name, ""));
            }
            else
            {
                System.Web.HttpContext.Current.Request.Cookies[name].Value = strValueEn;
            }


            System.Web.HttpContext.Current.Response.Cookies[name].Value = strValueEn;
            if (!VTCO.Config.Global.Settings.CookieDomain.Equals(""))
            {
                System.Web.HttpContext.Current.Response.Cookies[name].Path = "/";
                System.Web.HttpContext.Current.Response.Cookies[name].Domain = VTCO.Config.Global.Settings.CookieDomain;
            }
            var iCookieExpires = 60 * 1; // mặc định
            try
            {
                iCookieExpires = Convert.ToInt32(VTCO.Config.Global.Settings.CookieExpires);
            }
            catch { }

            System.Web.HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddMinutes(iCookieExpires);
            System.Web.HttpContext.Current.Response.Cookies[name].HttpOnly = true;
        }

        /// <summary>
        /// Lấy thông tin Cookie chưa được giải mã
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCookieNotDeCode(string name)
        {
            string CookieValue = string.Empty;
            if (System.Web.HttpContext.Current.Request.Cookies[name] != null)
            {
                try
                {
                    CookieValue = System.Web.HttpContext.Current.Request.Cookies[name].Value.ToString();
                }
                catch { }
            }
            return CookieValue;
        }

        /// <summary>
        /// Mã hóa dữ liệu Cookie
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SetEnCodeCookieData()
        {
            string input = GetCookieNotDeCode(Constants.COOKIE_ADMIN_ID);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_USER_NAME);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_FULL_NAME);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_LEVER);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_PERMISSION);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_COMPANY_ID);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_ADMIN_COMPANY_NAME);
            try
            {
                return m_rijndaelKey.Encrypt(input);
            }
            catch { }
            return string.Empty;
        }

        /// <summary>
        /// Giải mã dữ liệu cookie
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] GetDeCodeCookieData(string input)
        {
            string[] arrOutput = { "", "", "", "", "", "", ""};
            int iIndex = 0;
            int i = 0;
            string strTemp = "";
            try
            {
                strTemp = m_rijndaelKey.Decrypt(input);
                iIndex = strTemp.IndexOf(m_strSeparater);
                while (iIndex != -1)
                {
                    arrOutput[i++] = strTemp.Substring(0, iIndex);
                    strTemp = strTemp.Substring(iIndex + m_strSeparater.Length);
                    iIndex = strTemp.IndexOf(m_strSeparater);
                    if (i == arrOutput.Length) break;
                }
                arrOutput[i] = strTemp;
            }
            catch { }
            return arrOutput;
        }

        #endregion
    }
}
