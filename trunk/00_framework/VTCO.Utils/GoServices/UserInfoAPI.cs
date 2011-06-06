using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Utils.GoServices
{
    public class UserInfoAPI
    {
        /// <summary>
        /// Lấy paygateID thông qua paygateName
        /// </summary>
        /// <param name="paygateName"></param>
        /// <returns>Lỗi: -1</returns>
        public static long GetPaygateID(string paygateName)
        {
            Go.UserInfo.UserInfo uinfo = new Go.UserInfo.UserInfo();
            string strPaygateID = string.Empty;
            try
            {
                strPaygateID = uinfo.GetByUsername(paygateName);
            }
            catch
            {
                
                return -1;
            }
            
            if (string.IsNullOrEmpty(strPaygateID))
            {
                return -1;
            }
            return Convert.ToInt64(strPaygateID);
        }

        /// <summary>
        /// Lấy thông tin của user
        /// </summary>
        /// <param name="paygateID"></param>
        /// <returns></returns>
        public static Go.Solr.Entity.GoProfile GetGoProfile(long paygateID)
        {
            Go.UserInfo.UserInfo uinfo = new Go.UserInfo.UserInfo();
            Go.Solr.Entity.GoProfile _profile;
            try
            {
                _profile = Newtonsoft.Json.JsonConvert.DeserializeObject<Go.Solr.Entity.GoProfile>(uinfo.GetByID(paygateID.ToString()));
            }
            catch
            {
                return null;
            }
            return _profile;
        }

        /// <summary>
        /// Lấy publicName thông qua paygateID
        /// </summary>
        /// <param name="paygateID"></param>
        /// <returns>Lỗi:NULL</returns>
        public static string GetPublicName(long paygateID)
        {
            Go.UserInfo.UserInfo uinfo = new Go.UserInfo.UserInfo();
            Go.Solr.Entity.GoProfile _profile = GetGoProfile(paygateID);
            if (_profile == null)
                return null;
            return string.IsNullOrEmpty(_profile.PublicName) ? _profile.AccountName : _profile.PublicName;
        }        
    }
}
