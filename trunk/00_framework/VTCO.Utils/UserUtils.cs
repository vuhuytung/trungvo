//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2010-06-30
// Description: Tiện ích tương tác với các tham số cơ bản của User
//

using VTCO.Config;
using System.Web;
using System;

namespace VTCO.Utils
{
    public class UserUtils
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
                return !((GetCookie(Constants.COOKIE_USER_ID) == string.Empty)
                    || (GetCookie(Constants.COOKIE_PAYGATE_ID) == string.Empty)
                    || (GetCookie(Constants.COOKIE_PAYGATE_NAME) == string.Empty)
                    || (GetCookie(Constants.COOKIE_LOGIN_TYPE) == string.Empty));
            }
        }

        /// <summary>
        /// Lấy loại login của User
        /// </summary>
        public static LoginTypeEnum LoginType
        {
            get
            {
                if (!IsLogin)
                    return LoginTypeEnum.NotLogin;
                try
                {
                    return (LoginTypeEnum)(Convert.ToInt32(GetCookie(Constants.COOKIE_LOGIN_TYPE)));
                }
                catch { }
                return LoginTypeEnum.NotLogin;
            }
        }

        /// <summary>
        /// Lấy UserID của 
        /// </summary>
        public static int UserID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_USER_ID));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy PaygateID của User
        /// </summary>
        public static long PaygateID
        {
            get
            {
                try
                {
                    return Convert.ToInt64(GetCookie(Constants.COOKIE_PAYGATE_ID));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy PaygateName của User
        /// </summary>
        public static string PaygateName
        {
            get
            {
                return GetCookie(Constants.COOKIE_PAYGATE_NAME);
            }
        }

        /// <summary>
        /// Lấy PublicName của User
        /// </summary>
        public static string PublicName
        {
            get
            {
                return GetCookie(Constants.COOKIE_PUBLIC_NAME);
            }
        }

        /// <summary>
        /// Lấy cổng đăng nhập của User (qua Paygate, Yahoo, Gmail)
        /// </summary>
        public static int LoginPort
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_LOGIN_PORT));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy ID Shop của User
        /// -1: Chưa có Shop
        /// >0: ID của Shop
        /// </summary>
        public static int ShopOwnerID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_SHOP_ID));
                }
                catch { }
                return -1;
            }
        }

        /// <summary>
        /// Lấy tên Shop của User
        /// string.Empty: Chưa có Shop
        /// </summary>
        public static string ShopName
        {
            get
            {
                return GetCookie(Constants.COOKIE_SHOP_NAME);
            }
        }

        /// <summary>
        /// Lấy IPAdress
        /// </summary>
        public static string IpAddress
        {
            get
            {
                return GetCookie(Constants.COOKIE_IP_ADDRESS);
            }
        }

        /// <summary>
        /// Lấy User Status: 0 - Bị khóa, 1: đang sử dụng, 2: bị xóa
        /// </summary>
        public static int UserStatus
        {
            get
            {
                try
                {
                    return Convert.ToInt32(GetCookie(Constants.COOKIE_USER_STATUS));
                }
                catch { }
                return 1;
            }
        }

        /// <summary>
        /// Dùng để hack cho việc đăng nhập
        /// </summary>
        public static void HackLogin()
        {
            SetCookie(Constants.COOKIE_USER_ID, "46");
            SetCookie(Constants.COOKIE_PAYGATE_ID, "17911126");
            SetCookie(Constants.COOKIE_PAYGATE_NAME, "bsv1");
            SetCookie(Constants.COOKIE_PUBLIC_NAME, "Trịnh Văn Hoan");
            SetCookie(Constants.COOKIE_LOGIN_TYPE, ((int)(LoginTypeEnum.ShopOwner)).ToString());
            SetCookie(Constants.COOKIE_SHOP_ID, "19");
            SetCookie(Constants.COOKIE_SHOP_NAME, "vtconline");
            SetCookie(Constants.COOKIE_LOGIN_PORT, "0");
        }

        /// <summary>
        /// Dùng để hack cho việc đăng nhập
        /// </summary>
        public static void ClearLogin()
        {
            SetCookie(Constants.COOKIE_USER_ID, "");
            SetCookie(Constants.COOKIE_PAYGATE_ID, "");
            SetCookie(Constants.COOKIE_PAYGATE_NAME, "");
            SetCookie(Constants.COOKIE_PUBLIC_NAME, "");
            SetCookie(Constants.COOKIE_LOGIN_TYPE, "");
            SetCookie(Constants.COOKIE_SHOP_ID, "");
            SetCookie(Constants.COOKIE_SHOP_NAME, "");
            SetCookie(Constants.COOKIE_LOGIN_PORT, "");
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
            var iCookieExpires = 60*1; // mặc định
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
            string input = GetCookieNotDeCode(Constants.COOKIE_LOGIN_TYPE);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_USER_ID);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_PAYGATE_ID);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_PAYGATE_NAME);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_PUBLIC_NAME);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_SHOP_ID);
            input += m_strSeparater + GetCookieNotDeCode(Constants.COOKIE_SHOP_NAME);
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
            string[] arrOutput = { "", "", "", "", "", "", "", "" };
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
