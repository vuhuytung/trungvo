//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2008.11.08
// Description: Lấy thông tin từ File Web.Config
//
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;
namespace VTCO.Config
{
    /// <summary>
    /// Lấy thông tin cấu hình từ File Web.Config
    /// </summary>
    public sealed class SettingSingleton
    {
        #region Singleton Pattern
        private static readonly SettingSingleton instance = new SettingSingleton();

        public static SettingSingleton Instance
        {
            get { return SettingSingleton.instance; }
        }
        #endregion
        #region Process Method
        /// <summary>
        /// Lấy giá trị của Key trong AppSetting
        /// </summary>
        /// <param name="_Key">Key</param>
        /// <returns>Return Null nếu không có key</returns>
        public string GetAppKeyValue(string _Key)
        {
            NameValueCollection appsettings = ConfigurationManager.AppSettings;
            if (appsettings == null) return null;
            if (appsettings.AllKeys.Contains(_Key))
            {
                return appsettings[_Key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy xâu kết nối trong file Web.Config
        /// </summary>
        /// <param name="_Key">key</param>
        /// <returns>Return null nếu không có key</returns>
        public string GetConnectionStringKeyValue(string _Key)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[_Key].ConnectionString;
            }
            catch { }
            return null;
        }
        #endregion Process Method


        #region Attribute Connection String
        /// <summary>
        /// Xâu kết nối cơ sở dữ liệu Club
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return GetConnectionStringKeyValue(Constants.CONNECTION_STRING);
            }
        }

        #endregion
        

        /// <summary>
        /// Key mã hóa công khai
        /// </summary>
        public string PublicKey
        {
            get
            {
                return GetAppKeyValue(Constants.KEY);
            }
        }

        /// <summary>
        /// Đường dẫn chứa PublicKey và PrivateKey cho RSA Cryptography
        /// </summary>
        public string KeyPath
        {
            get
            {
                return GetAppKeyValue(Constants.KEY_PATH);
            }
        }
    }
}
