//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2010-06-2010
// Description: Khai báo các thuộc tính cơ bản của WEB, phục vụ cho xử lý jTemplate
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTCO.Config;

namespace EntityBLL
{
    public class SiteInfo : VTCO.Config.Pattern.Prototype<SiteInfo>
    {
        /// <summary>
        /// Đối tượng thể hiện BaseInfo
        /// </summary>
        public static SiteInfo Instance
        {
            get
            {
                return VTCO.Config.Pattern.Singleton<SiteInfo>.Instance;
            }
        }

        /// <summary>
        /// Đường dẫn gốc của WEB.
        /// Ex: http://ss.go.vn/
        /// </summary>
        public string WebRoot
        {
            get
            {
                return Global.Settings.WebRoot;
            }
        }

        /// <summary>
        /// Service ảnh
        /// Ex: http://myGo.go.vn/
        /// </summary>
        public string ServicesPhoto
        {
            get
            {
                return Global.Settings.ServicesPhoto;
            }
        }

        /// <summary>
        /// Đường dẫn gốc của avatar.
        /// Ex:http://avatar.go.vn/avatar.aspx
        /// </summary>
        public string GoAvatarUrl
        {
            get
            {
                return Global.Settings.GoAvatarUrl;
            }
        }

        /// <summary>
        /// Đường dẫn gốc của myGo.
        /// Ex: http://myGo.go.vn/
        /// </summary>
        public string GoMyGoUrl
        {
            get
            {
                return Global.Settings.GoMyGoUrl;
            }
        }

        /// <summary>
        /// Lấy UserID
        /// </summary>
        public int UserID
        {
            get
            {
                return VTCO.Utils.UserUtils.UserID;
            }
        }

        /// <summary>
        /// Lấy paygateID của user đang đăng nhập
        /// </summary>
        public long PaygateID
        {
            get 
            {
                return VTCO.Utils.UserUtils.PaygateID;
            }
        }

        //Lấy PaygateName của User đang đăng nhập
        public string PaygateName
        {
            get {
                return VTCO.Utils.UserUtils.PaygateName;
            }
        }

        /// <summary>
        /// Lấy ShopOwnerID
        /// </summary>
        public int ShopOwnerID
        {
            get
            {
                return VTCO.Utils.UserUtils.ShopOwnerID;
            }
        }
        /// <summary>
        /// Lấy tên Shop: Empty: chưa có shop
        /// </summary>
        public string ShopName
        {
            get
            {
                return VTCO.Utils.UserUtils.ShopName;
            }
        }

        /// <summary>
        /// Kiểm tra user đã login hay chưa
        /// </summary>
        public bool IsLogin
        {
            get { return VTCO.Utils.UserUtils.IsLogin; }
        }

        
    }
}
