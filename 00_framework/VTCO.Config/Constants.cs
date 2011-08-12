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

        // Khai báo các Constant key các phân hệ
        #region Comunicate GO.VN Features

        /// <summary>
        /// Portal Url homepage
        /// </summary>
        public const string GO_PORTAL_URL = "GO_PORTAL_URL";

        /// <summary>
        /// Trang đăng nhập SSO
        /// </summary>
        public const string GO_SSO_LOGIN_URL = "GO_SSO_LOGIN_URL";

        /// <summary>
        /// Trang đăng xuất SSO
        /// </summary>
        public const string GO_SSO_LOGOUT_URL = "GO_SSO_LOGOUT_URL";

        /// <summary>
        /// Trang đăng ký SSO
        /// </summary>
        public const string GO_SSO_REGISTER_URL = "GO_SSO_REGISTER_URL";

        /// <summary>
        /// Url Webservices lấy keySSO
        /// </summary>
        public const string GO_SSO_KEY_GENERATE_URL = "GO_SSO_KEY_GENERATE_URL";

        /// <summary>
        /// Site_ID Frond-End
        /// </summary>
        public const string GO_SSO_SITE_ID = "GO_SSO_SITE_ID";

        /// <summary>
        /// Services provice ID dùng cho việc generate SSOKEY
        /// </summary>
        public const string GO_SSO_SERVICE_PROVIDER_ID = "GO_SSO_SERVICE_PROVIDER_ID";

        /// <summary>
        /// Site_ID Frond-End
        /// </summary>
        public const string GO_SSO_SERVICE_PROVIDER_SITE_ID = "GO_SSO_SERVICE_PROVIDER_SITE_ID";

        /// <summary>
        /// URL Recived User Data
        /// </summary>
        public const string GO_SSO_URL_CONTINUE = "GO_SSO_URL_CONTINUE";
        
        /// <summary>
        /// Key mã hóa dữ liệu SSO
        /// </summary>
        public const string GO_SSO_KEY_ENCRYPT_DECRYPT = "SSO_KEY_ENCRYPT_DECRYPT";

        /// <summary>
        /// Thời gian timeout của sso
        /// </summary>
        public static string GO_SSO_TIMEOUT = "GO_SSO_TIMEOUT";


        public static string GO_SSO_SERVER_URL = "GO_SSO_SERVER_URL";

        public static string GO_SSO_SECRET_KEY = "GO_SSO_SECRET_KEY";

        #region SSO Other
        public static string GO_SSO_MODE_0 = "0";
        public static string GO_SSO_MODE_1 = "1";

        public static string GO_SSO_REQUEST_SID = "sid";//Request Site ID
        public static string GO_SSO_REQUEST_UR = "ur";//Request Return URL
        public static string GO_SSO_REQUEST_M = "m";//Request Mode
        public static string GO_SSO_RESPONSE_S = "s";//Response Status
        public static string GO_SSO_RESPONSE_UD = "ud";//Response User Data
        public static string GO_SSO_RESPONSE_UR = "ur";//Respose Return URL
        #endregion



        /// <summary>
        /// Avatar Url homepage
        /// </summary>
        public const string GO_AVATAR_URL = "GO_AVATAR_URL";

        /// <summary>
        /// GoRaoVat Url homepage
        /// </summary>
        public const string RAOVAT_URL = "RAOVAT_URL";


        /// <summary>
        /// MyGo Url
        /// </summary>
        public const string GO_MYGO_URL = "GO_MYGO_URL";

        /// <summary>
        /// MyGo Url homepage
        /// </summary>
        public const string GO_MYGO_HOME_URL = "GO_MYGO_HOME_URL";

        /// <summary>
        /// Trang setting của mygo
        /// </summary>
        public const string GO_MYGO_SETTING_URL = "GO_MYGO_SETTING_URL";

        /// <summary>
        /// Trang mua chung
        /// </summary>
        public const string GO_DEAL_URL = "GO_DEAL_URL";

        #endregion

        // Khai báo các URL Web Services của các phân hệ
        #region WebService URL Go.vn

        /// <summary>
        /// Activity
        /// </summary>
        public const string WS_ACTIVITY = "WS_ACTIVITY";

        public const string WS_ACTIVITY_FEED = "WS_ACTIVITY_FEED";

        public const string WS_ACTIVITY_FEED_KEY = "WS_ACTIVITY_FEED_KEY";

        /// <summary>
        /// GoRaoVat
        /// </summary>
        public const string WS_GORAOVAT = "WS_GORAOVAT";

        /// <summary>
        /// Location Map API
        /// </summary>
        public const string LOCATION_WSMAP_API = "WS_LOCAION_MAPAPI";

        #endregion

        // Các key khác
        #region Other

        /// <summary>
        /// Key chứa đường dẫn gốc của Web Front-End
        /// </summary>
        public const string WEB_ROOT = "WebRoot";

        /// <summary>
        /// Key chứa đường dẫn gốc của phần backend social shop
        /// </summary>
        public const string WEB_ROOT_BACKEND = "WebRoot.Backend";

        /// <summary>
        /// Key chứa đường dẫn thư mục website
        /// </summary>
        public const string PATH_ROOT = "PathRoot";

        /// <summary>
        /// Key chứa web title của website
        /// </summary>
        public const string WEB_TITLE = "WEB_TITLE";

        /// <summary>
        /// Key chứa web keyword của website
        /// </summary>
        public const string WEB_KEYWORD = "WEB_KEYWORD";

        /// <summary>
        /// Key chứa web keyword của website
        /// </summary>
        public const string WEB_DESCRIPTION = "WEB_DESCRIPTION";

        /// <summary>
        /// Cookie domain
        /// </summary>
        public const string COOKIE_DOMAIN = "COOKIE_DOMAIN";

        /// <summary>
        /// Thời gian tồn tại của cookie
        /// </summary>
        public const string COOKIE_EXPIRES = "COOKIE_EXPIRES";

        /// <summary>
        /// Thời gian tồn tại của cookie
        /// </summary>
        public const string IS_HACK_LOGIN = "IS_HACK_LOGIN";

        /// <summary>
        /// Key chứa URL photo services
        /// </summary>
        public const string SERVICES_PHOTO = "Services.Photo";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - Logo
        /// </summary>
        public const string RESOURCES_PHOTO_LOGO = "Resources.Photo.Logo";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - Product
        /// </summary>
        public const string RESOURCES_PHOTO_PRODUCT = "Resources.Photo.Product";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - ShowProduct
        /// </summary>
        public const string RESOURCES_PHOTO_SHOWPRODUCT = "Resources.Photo.ShowProduct";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - WantAds
        /// </summary>
        public const string RESOURCES_PHOTO_WANTADS = "Resources.Photo.WantAds";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - News
        /// </summary>
        public const string RESOURCES_PHOTO_NEWS = "Resources.Photo.News";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - Theme
        /// </summary>
        public const string RESOURCES_PHOTO_THEME = "Resources.Photo.Theme";

        /// <summary>
        /// Key chứa đường dẫn trỏ đến thư mục chứa tài nguyên ảnh của Website - Quảng cáo
        /// </summary>
        public const string RESOURCES_PHOTO_ADVERTISEMENT = "Resources.Photo.Advertisement";

        

        /// <summary>
        /// Đường dẫn ảnh mặc định
        /// </summary>
        public const string RESOURCES_NOIMAGE = "Resources.NoImage";

        /// <summary>
        /// Các key quy định kích thước save ảnh thumbnail
        /// </summary>
        public const string RESOURCE_IMAGESIZE_LOGO = "Resources.ImageSize.Logo";
        public const string RESOURCE_IMAGESIZE_NEWS = "Resources.ImageSize.News";
        public const string RESOURCE_IMAGESIZE_PRODUCT = "Resources.ImageSize.Product";
        public const string RESOURCE_IMAGESIZE_SHOWPRODUCT = "Resources.ImageSize.ShowProduct";
        public const string RESOURCE_IMAGESIZE_WANTADS = "Resources.ImageSize.WantAds";
        public const string RESOURCE_IMAGESIZE_THEME = "Resources.ImageSize.Theme";
        public const string RESOURCE_IMAGESIZE_ADVERTIMENT = "Resources.ImageSize.Advertiment";

        /// <summary>
        /// các key cấu hình mặc định ban đầu khi tạo Shop
        /// </summary>
        public const string LOGO_SHOP_DEFAULT = "LOGO_SHOP_DEFAULT";
        public const string SHOP_DAY_EXPIRY = "SHOP_DAY_EXPIRY";
        public const string FAN_SHOP_MAX = "FAN_SHOP_MAX";

        /// <summary>
        /// Điều khoản tạo Shop
        /// </summary>
        public const string POLICY_CREATE_SHOP = "PolicyCreateShop";

        public const string BUYING_GROUP_MAX_POINT = "BUYING_GROUP_MAX_POINT";

        public const string LAST_CHECK_MODE_PRODUCT = "LAST_CHECK_MODE_PRODUCT";

        public const string LAST_CHECK_MODE_BUYINGGROUP = "LAST_CHECK_MODE_BUYINGGROUP";

        public const string LAST_CHECK_MODE_CREATESHOP = "LAST_CHECK_MODE_CREATESHOP";

        public const string LAST_CHECK_MODE_NEWSSHOP = "LAST_CHECK_MODE_NEWSSHOP";

        public const string LAST_CHECK_MODE_SHOWPRODUCT = "LAST_CHECK_MODE_SHOWPRODUCT";

        public const string BLOCK_COMMENT = "BlockComment";
        public const string DELETE_COMMENT = "DeleteComment";

        #endregion

        #region Các key cấu hình thanh toán qua BankGate
        /// <summary>
        /// Địa chỉ cổng thanh toán
        /// </summary>
        public const string DESTINATION_URL = "DestinationUrl";

        /// <summary>
        /// ID
        /// </summary>
        public const string MERCHANT_IDS = "MerchantIDs";

        /// <summary>
        /// Key
        /// </summary>
        public const string MERCHANT_KEY = "MerchantKey";

        /// <summary>
        /// Key bảo mật
        /// </summary>
        public const string MERCHANT_SECURITY_KEY = "MerchantSecurityKey";

        /// <summary>
        /// Địa chỉ trang nhận kết quả trả về
        /// </summary>
        public const string MERCHANT_URL_DONE = "MerchantURLDone";

        /// <summary>
        /// Code
        /// </summary>
        public const string MERCHANT_CODE = "MerchantCode";

        /// <summary>
        /// Thanh toán VNĐ
        /// </summary>
        public const string PAY_VND = "PayVND";

        /// <summary>
        /// Thanh toán bằng Voin thanh toán
        /// </summary>
        public const string PAY_VCOIN_PAYMENT = "PayVcoinPayment";

        /// <summary>
        /// Mô tả thanh toán
        /// </summary>
        public const string MERCHANT_DESCRIPTION = "MerchantDescription";

        /// <summary>
        /// Phí thanh toán
        /// </summary>
        public const string PAY_COST = "PayCost";

        /// <summary>
        /// Tỉ lệ quy đổi giữa đồng GO và VNĐ (VNĐ = GO * GO_TO_VND)
        /// </summary>
        public const string MERCHANT_CERTIFICATES = "MerchantCertificates";
        #endregion

        #region Cấu hình thanh toán qua NganLuong
        public const string NGANLUONG_URL = "NganLuongUrl";
        public const string NGANLUONG_SITE_CODE = "NganLuongSiteCode";
        public const string NGANLUONG_SECURE = "NganLuongSecure";
        #endregion

        #region Cấu hình thanh toán qua Paygate
        public const string PAYGATE_URL = "PaygateURL";
        public const string PAYGATE_SITE_ID = "PaygateSiteID";
        public const string PAYGATE_VND_VCOIN = "PaygateVNDVcoin";
        public const string PAYGATE_VND = "PaygateVND";
        public const string PAYGATE_VCOIN = "PaygateVcoin";
        public const string PAYGATE_PRIVATE_KEY = "PaygatePrivateKey";
        public const string PAYGATE_PUBLIC_KEY = "PaygatePublicKey";
        #endregion

        #region Cấu hình thanh toán qua Banknetvn
        public const string BANKNETVN_URL = "BanknetvnURL";
        public const string BANKNETVN_CODE = "BanknetvnCode";
        public const string BANKETVN_COUNTRY_CODE = "BanknetvnCountryCode";
        public const string BANNETVN_TRANS_KEY = "BanknetvnTransKey";
        #endregion

        #region Cấu hình thanh toán qua Bet168
        public const string BET168_URL = "Bet168URL";
        public const string BET168_KEY = "Bet168Key";
        #endregion

        // Các hằng số cho Session của User
        #region SESSION cho User
        public const string SESSION_USER_ID = "SESSION_USER_ID";
        public const string SESSION_USER_NAME = "SESSION_USER_NAME";
        public const string SESSION_USER_FULLNAME = "SESSION_USER_FULLNAME";
        public const string SESSION_USER_LEVEL = "SESSION_USER_LEVEL";
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
        
        #region COOKIE cho User
        public const string COOKIE_USER_ID = "USER_ID";
        public const string COOKIE_PAYGATE_NAME = "PAYGATE_NAME";
        public const string COOKIE_PUBLIC_NAME = "PUBLIC_NAME";
        public const string COOKIE_PAYGATE_ID = "PAYGATE_ID";
        public const string COOKIE_LOGIN_PORT = "LOGIN_PORT";
        public const string COOKIE_LOGIN_TYPE = "LOGIN_TYPE";
        public const string COOKIE_SHOP_ID = "SHOP_ID";
        public const string COOKIE_SHOP_NAME = "SHOP_NAME";
        public const string COOKIE_IP_ADDRESS = "IP_ADDRESS";
        public const string COOKIE_USER_STATUS = "USER_STATUS";
        /// <summary>
        /// Chứa xâu mã hóa paygateID của sso goonline.vn
        /// </summary>
        public const string COOKIE_SSO_INFO = "ssoinfo";
        /// <summary>
        /// Chứa xâu mã hóa paygateID của sso của socialshop
        /// </summary>
        public const string COOKIE_SSO_INFO_SOCIALSHOP = "SSO_INFO_COOKIE";

        

        #endregion

        #region COOKIE cho Admin
        public const string COOKIE_ADMIN_ID = "ADMIN_ID";
        public const string COOKIE_ADMIN_USER_NAME = "ADMIN_USER_NAME";
        public const string COOKIE_ADMIN_FULL_NAME = "ADMIN_FULL_NAME";
        public const string COOKIE_ADMIN_LEVER = "ADMIN_LEVER";
        public const string COOKIE_ADMIN_PERMISSION = "ADMIN_PERMISSION";
        public const string COOKIE_ADMIN_COMPANY_ID = "ADMIN_COMPANY_ID";
        public const string COOKIE_ADMIN_COMPANY_NAME = "ADMIN_COMPANY_NAME";
        public const string COOKIE_ADMIN_IP_ADDRESS = "IP_ADDRESS";
        #endregion

        // Các hằng số sử dụng trong hệ thống
        #region Contanst
        public const string SESSION_IMAGE_CODE = "SESSION_IMAGE_CODE";
        public const string SESSION_LOGIN_FAIL = "SESSION_LOGIN_FAIL";
        #endregion

        #region Cấu hình thanh toán tiền Go trên trang SS
        public const string SS_PAYMENT_SITE_ID = "SS_PAYMENT_SITE_ID";
        public const string SS_PAYMENT_IP_SERVER = "SS_PAYMENT_IP_SERVER";
        public const string SS_PAYMENT_KEY = "SS_PAYMENT_KEY";
        public const string SS_PAYMENT_PASSWORD = "SS_PAYMENT_PASSWORD";
        public const string TIME_EDIT_PRODUCT = "TIME_EDIT_PRODUCT";
        public const string TIME_EDIT_BUYINGGROUP = "TIME_EDIT_BUYINGGROUP";
        public const string TIME_EDIT_NEWS = "TIME_EDIT_NEWS";
        
        #endregion

        #region Cấu hình Location
        public const string LOCATION_VIEW_MAP = "LOCATION_VIEW_MAP";
        public const string LOCATION_API_VIEW = "LOCATION_API_VIEW";
        public const string LOCATION_API_POST = "LOCATION_API_POST";
        public const string LOCATION_API_SEARCH = "LOCATION_API_SEARCH";
        #endregion

        // Cấu hình thư mục chứa File Excel
        #region Thư mục chứa File Excel
        public const string BUYINGGROUP_FILE_EXCEL = "BUYINGGROUP_FILE_EXCEL";
        #endregion

        #region Key cho phép đăng nhập và hệ thống qua gmail
        public const string GOOGLE_CONSUMER_KEY = "GoogleConsumerKey";
        public const string GOOGLE_CONSUMER_SECRET = "GoogleConsumerSecret";
        #endregion

    }
}
