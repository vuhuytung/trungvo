//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2010-05-29
// Description: Khai báo các hằng số dùng trong hệ thống
//
namespace VTCO.Config
{
    /// <summary>
    /// Khai báo các hằng số dùng trong hệ thống
    /// </summary>
    public class Constants
    {
        // Khai báo các Connection String key liên quan đến Solution
        #region ConnectionString Constant
        public const string CONNECTION_STRING = "ConnectionString";
        #endregion


        // Các hằng số cho Session của User
        #region SESSION cho User
        public const string SESSION_USER_ID = "SESSION_USER_ID";
        public const string SESSION_USER_NAME = "SESSION_USER_NAME";
        public const string SESSION_USER_FULLNAME = "SESSION_USER_FULLNAME";
        public const string SESSION_USER_LEVEL = "SESSION_USER_LEVEL";
        public const string SESSION_USER_ISLOGIN = "SESSION_USER_ISLOGIN";
        #endregion

        // Các hằng số cho Session của Admin
        #region SESSION cho ADmin
        public const string SESSION_ADMIN_ID = "SESSION_ADMIN_ID";
        public const string SESSION_ADMIN_NAME = "SESSION_ADMIN_NAME";
        public const string SESSION_ADMIN_FULLNAME = "SESSION_ADMIN_FULLNAME";
        public const string SESSION_ADMIN_LEVEL = "SESSION_ADMIN_LEVEL";
        public const string SESSION_ADMIN_ISLOGIN = "SESSION_ADMIN_ISLOGIN";
        public const string SESSION_ADMIN_PERMISSION = "SESSION_ADMIN_PERMISSION";
        #endregion

        // Các hằng số cho quyền của Admin
        #region PERMISSION cho ADmin
        public const int PERMISSION_READ = 8;
        public const int PERMISSION_ADD = 4;
        public const int PERMISSION_EDIT = 2;
        public const int PERMISSION_DELETE = 1;
        #endregion

        public const string SESSION_CURRENT_PAGE = "SESSION_CURRENT_PAGE";
        public const string SESSION_CURRENT_TAB = "SESSION_CURRENT_TAB";        
        public const string SESSION_CURRENT_URL = "SESSION_CURRENT_URL";
        public const string PRIVATE_KEY = "@1B2c3D4e5F6g7H8";
        public const string KEY = "KEY";
        /// <summary>
        /// Thư mục chứa Key cho mã hóa SHA
        /// </summary>
        public const string KEY_PATH = "KEY_PATH";        
    }
}
