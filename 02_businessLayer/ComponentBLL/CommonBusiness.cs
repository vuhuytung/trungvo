using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTCO.Config;
using System.Web;
using VTCO.Utils;

namespace ComponentBLL
{
    public class CommonBusiness
    {
        /// <summary>
        /// Lấy giới tính
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string GetSex(object sex)
        {
            try
            {
                if ((sex == DBNull.Value) || sex == null)
                    return "-";
                return Convert.ToBoolean(sex) ? "Nam" : "Nữ";
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Lấy FirstName của tên
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string GetFirstName(string fullName)
        {
            fullName = fullName.Trim();
            try
            {
                return fullName.Substring(0,fullName.LastIndexOf(' '));
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Lấy LastName của tên
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string GetLastName(string fullName)
        {
            fullName = fullName.Trim();
            try
            {
                return fullName.Substring(fullName.LastIndexOf(' ') + 1);
            }
            catch (Exception ex)
            {
                return fullName;
            }
        }
        /// <summary>
        /// Lấy Local Path của Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetLocalPath(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                return uri.LocalPath;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
