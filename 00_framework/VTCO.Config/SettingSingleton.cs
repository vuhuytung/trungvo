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

        #region Attribute AppSeting

        /// <summary>
        /// Đường dẫn gốc của Web Front-End
        /// </summary>
        public string WebRoot
        {
            get
            {
                return GetAppKeyValue(Constants.WEB_ROOT);
            }
        }

        /// <summary>
        /// Đường dẫn gốc của backend social shop
        /// </summary>
        public string WebRootBackEnd
        {
            get
            {
                return GetAppKeyValue(Constants.WEB_ROOT_BACKEND);
            }
        }

        /// <summary>
        /// Key chứa đường dẫn thư mục website
        /// </summary>
        public string PathRoot
        {
            get
            {
                return GetAppKeyValue(Constants.PATH_ROOT);
            }
        }

        /// <summary>
        /// Tiêu đề chung của trang
        /// </summary>
        public string WebTitle
        {
            get
            {
                return GetAppKeyValue(Constants.WEB_TITLE);
            }
        }

        /// <summary>
        /// Từ khóa chung của trang
        /// </summary>
        public string WebKeyWord
        {
            get
            {
                return GetAppKeyValue(Constants.WEB_KEYWORD);
            }
        }

        /// <summary>
        /// Mô tả chung chung của trang
        /// </summary>
        public string WebDescription
        {
            get
            {
                return GetAppKeyValue(Constants.WEB_DESCRIPTION);
            }
        }

        /// <summary>
        /// Cookie domain
        /// </summary>
        public string CookieDomain
        {
            get
            {
                return GetAppKeyValue(Constants.COOKIE_DOMAIN);
            }
        }

        /// <summary>
        /// Thời gian tồn tại của cookie
        /// </summary>
        public string CookieExpires
        {
            get
            {
                return GetAppKeyValue(Constants.COOKIE_EXPIRES);
            }
        }

        /// <summary>
        /// Kiểm tra xem có hack login không
        /// </summary>
        public bool IsHackLogin
        {
            get
            {
                if (GetAppKeyValue(Constants.IS_HACK_LOGIN) == "1")
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Url của services ảnh
        /// </summary>
        public string ServicesPhoto
        {
            get
            {
                return GetAppKeyValue(Constants.SERVICES_PHOTO);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh - Logo
        /// </summary>
        public string ResourcesPhotoLogo
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_LOGO);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh - Product
        /// </summary>
        public string ResourcesPhotoProduct
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_PRODUCT);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh - ShowProduct
        /// </summary>
        public string ResourcesPhotoShowProduct
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_SHOWPRODUCT);
            }
        }


        /// <summary>
        /// Đường dẫn đến thư mục ảnh - WantAds
        /// </summary>
        public string ResourcesPhotoWantAds
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_WANTADS);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh - News
        /// </summary>
        public string ResourcesPhotoNews
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_NEWS);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh - Theme
        /// </summary>
        public string ResourcesPhotoTheme
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_THEME);
            }
        }

        /// <summary>
        /// Đường dẫn đến thư mục ảnh quảng cáo
        /// </summary>
        public string ResourcesPhotoAdvertisement
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_PHOTO_ADVERTISEMENT);
            }
        }

        /// <summary>
        /// Đường dẫn ảnh mặc định
        /// </summary>
        public string ResourcesNoImage
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCES_NOIMAGE);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - Logo
        /// </summary>
        public string ResourcesImageSizeLogo
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_LOGO);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - News
        /// </summary>
        public string ResourcesImageSizeNews
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_NEWS);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - Product
        /// </summary>
        public string ResourcesImageSizeProduct
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_PRODUCT);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - ShowProduct
        /// </summary>
        public string ResourcesImageSizeShowProduct
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_SHOWPRODUCT);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - WantAds
        /// </summary>
        public string ResourcesImageSizeWantAds
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_WANTADS);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - Theme
        /// </summary>
        public string ResourcesImageSizeTheme
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_THEME);
            }
        }

        /// <summary>
        /// Quy định các kích thước save thumnail - Quảng cáo
        /// </summary>
        public string ResourcesImageSizeAdvertisement
        {
            get
            {
                return GetAppKeyValue(Constants.RESOURCE_IMAGESIZE_ADVERTIMENT);
            }
        }

        
        /// <summary>
        /// Thời gian được phép sửa sản phẩm kể từ lúc up sản phẩm
        /// </summary>
        public string TIME_EDIT_PRODUCT
        {
            get
            {
                return  GetAppKeyValue(Constants.TIME_EDIT_PRODUCT);
            }
        }

        /// <summary>
        /// Thời gian được phép tin tức kể từ lúc tạo tin tức
        /// </summary>
        public string TIME_EDIT_NEWS
        {
            get
            {
                return GetAppKeyValue(Constants.TIME_EDIT_NEWS);
            }
        }

        /// <summary>
        /// Thời gian được phép sửa BuyingGroup kể từ lúc up lên
        /// </summary>
        public string TIME_EDIT_BUYINGGROUP
        {
            get
            {
                return GetAppKeyValue(Constants.TIME_EDIT_BUYINGGROUP);
            }
        }

        /// <summary>
        /// Tên logo shop mặc định sau khi tạo Shop
        /// </summary>
        public string LOGO_SHOP_DEFAULT
        {
            get
            {
                return GetAppKeyValue(Constants.LOGO_SHOP_DEFAULT);
            }
        }

        /// <summary>
        /// Số lượng FanShop tối đa cho phép khi tạo Shop
        /// </summary>
        public string FAN_SHOP_MAX
        {
            get
            {
                return GetAppKeyValue(Constants.FAN_SHOP_MAX);
            }
        }

        /// <summary>
        /// Số ngày được phép duy trì Shop kể từ khi shop được tạo(mặc định)
        /// </summary>
        public string SHOP_DAY_EXPIRY
        {
            get
            {
                return GetAppKeyValue(Constants.SHOP_DAY_EXPIRY);
            }
        }

        /// <summary>
        /// Điều khoản tạo Shop
        /// </summary>
        public string POLICY_CREATE_SHOP
        {
            get
            {
                return GetAppKeyValue(Constants.POLICY_CREATE_SHOP);
            }
        }

        /// <summary>
        /// Số điểm giá tối đa
        /// </summary>
        public string BUYING_GROUP_MAX_POINT
        {
            get
            {
                return GetAppKeyValue(Constants.BUYING_GROUP_MAX_POINT);
            }
        }

        /// <summary>
        /// Chế độ kiểm duyệt Product
        /// </summary>
        public string LAST_CHECK_MODE_PRODUCT
        {
            get
            {
                return GetAppKeyValue(Constants.LAST_CHECK_MODE_PRODUCT);
            }
        }

        /// <summary>
        /// Chế độ kiểm duyệt BuyingGroup
        /// </summary>
        public string LAST_CHECK_MODE_BUYINGGROUP
        {
            get
            {
                return GetAppKeyValue(Constants.LAST_CHECK_MODE_BUYINGGROUP);
            }
        }

        /// <summary>
        /// Chế độ kiểm duyệt CreateShop
        /// </summary>
        public string LAST_CHECK_MODE_CREATESHOP
        {
            get
            {
                return GetAppKeyValue(Constants.LAST_CHECK_MODE_CREATESHOP);
            }
        }

        /// <summary>
        /// Chế độ kiểm duyệt tin tức Shop 
        /// </summary>
        public string LAST_CHECK_MODE_NEWSSHOP
        {
            get
            {
                return GetAppKeyValue(Constants.LAST_CHECK_MODE_NEWSSHOP);
            }
        }

        /// <summary>
        /// Chế độ kiểm duyệt sản phẩm showProduct
        /// </summary>
        public string LAST_CHECK_MODE_SHOWPRODUCT
        {
            get
            {
                return GetAppKeyValue(Constants.LAST_CHECK_MODE_SHOWPRODUCT);
            }
        }

        /// <summary>
        /// Acc không được comment
        /// </summary>
        public string BLOCK_COMMENT
        {
            get { return GetAppKeyValue(Constants.BLOCK_COMMENT); }
        }

        /// <summary>
        /// Acc được phép xóa comment
        /// </summary>
        public string DELETE_COMMENT
        {
            get { return GetAppKeyValue(Constants.DELETE_COMMENT); }
        }

        /// <summary>
        /// Lấy GOOGLE_CONSUMER_KEY cho việc đăng nhập qua gmail
        /// </summary>
        public string GOOGLE_CONSUMER_KEY
        {
            get { return GetAppKeyValue(Constants.GOOGLE_CONSUMER_KEY); }
        }

        /// <summary>
        /// Lấy GOOGLE_CONSUMER_SECRET cho việc đăng nhập qua gmail
        /// </summary>
        public string GOOGLE_CONSUMER_SECRET
        {
            get { return GetAppKeyValue(Constants.GOOGLE_CONSUMER_SECRET); }
        }



         #endregion

        #region Attribute AppSeting GO Features
        
        /// <summary>
        /// Url trỏ đến go.vn
        /// </summary>
        public string GoPortalUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_PORTAL_URL);
            }
        }

        /// <summary>
        /// Url login go.vn
        /// </summary>
        public string GoSSOLoginUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_LOGIN_URL);
            }
        }

        /// <summary>
        /// Url Logout go.vn
        /// </summary>
        public string GoSSOLogoutUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_LOGOUT_URL);
            }
        }

        /// <summary>
        /// Url trang đăng ký go.vn
        /// </summary>
        public string GoSSORegisterUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_REGISTER_URL);
            }
        }

        /// <summary>
        /// Url Webservices lấy keySSO
        /// </summary>
        public string GoSSOKeyGenerateUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_KEY_GENERATE_URL);
            }
        }

        /// <summary>
        /// Site ID của Social Shop
        /// </summary>
        public string GO_SSO_SITE_ID
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_SITE_ID);
            }

        }

        /// <summary>
        /// Services provice ID dùng cho việc generate SSOKEY
        /// </summary>
        public string GO_SSO_SERVICE_PROVIDER_ID
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_SERVICE_PROVIDER_ID);
            }

        }

        /// <summary>
        /// Site_ID Frond-End
        /// </summary>
        public string GO_SSO_SERVICE_PROVIDER_SITE_ID
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_SERVICE_PROVIDER_SITE_ID);
            }

        }
        /// <summary>
        /// URL Recived User Data
        /// </summary>
        public string GO_SSO_URL_CONTINUE
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_URL_CONTINUE);
            }

        }  


        /// <summary>
        /// Key giải mã thông tin trả về từ SSO
        /// </summary>
        public string GO_SSO_KEY_ENCRYPT_DECRYPT
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_KEY_ENCRYPT_DECRYPT);
            }

        }

        /// <summary>
        /// Thời gian timeout của SSO
        /// </summary>
        public string GO_SSO_TIMEOUT
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_TIMEOUT);
            }

        }


        public string GO_SSO_SERVER_URL
        {
            get
            {
                return GetAppKeyValue(Constants.GO_SSO_SERVER_URL);
            }
        }
        
        
        public string GO_SSO_SERVER
        {
            get { return GO_SSO_SERVER_URL.EndsWith("/") ?  GO_SSO_SERVER_URL.Substring(0, GO_SSO_SERVER_URL.Length - 1) : GO_SSO_SERVER_URL; }
        }

        public string GO_SSO_SECRET_KEY
        {
            get {return GetAppKeyValue(Constants.GO_SSO_SECRET_KEY); }
        }





        /// <summary>
        /// Url của Avatar
        /// </summary>
        public string GoAvatarUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_AVATAR_URL);
            }

        }

        /// <summary>
        /// Url của GoRaoVat
        /// </summary>
        public string GoRaoVatUrl
        {
            get
            {
                return GetAppKeyValue(Constants.RAOVAT_URL);
            }

        }

        /// <summary>
        /// Url của myGo
        /// </summary>
        public string GoMyGoUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_MYGO_URL);
            }

        }

        /// <summary>
        /// Url của trang home của myGo
        /// </summary>
        public string GoMyGoHomeUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_MYGO_HOME_URL);
            }

        }

        /// <summary>
        /// Url trang setting của  myGo
        /// </summary>
        public string GoMyGoSettingUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_MYGO_SETTING_URL);
            }

        }

        /// <summary>
        /// Url trang mua chung
        /// </summary>
        public string GoDealUrl
        {
            get
            {
                return GetAppKeyValue(Constants.GO_DEAL_URL);
            }

        }

        
        #endregion

        #region Attribute Web Services URL
        /// <summary>
        /// Activity
        /// </summary>
        public string WSActivity
        {
            get
            {
                return GetAppKeyValue(Constants.WS_ACTIVITY);
            }
        }
        
        /// <summary>
        /// Activity
        /// </summary>
        public string WSActivityFeed
        {
            get
            {
                return GetAppKeyValue(Constants.WS_ACTIVITY_FEED);
            }
        }

        /// <summary>
        /// Key Activity
        /// </summary>
        public string WSActivityFeedKey
        {
            get
            {
                return GetAppKeyValue(Constants.WS_ACTIVITY_FEED_KEY);
            }
        }

        /// <summary>
        /// GoRaoVat
        /// </summary>
        public string WSGoRaoVat
        {
            get
            {
                return GetAppKeyValue(Constants.WS_GORAOVAT);
            }
        }

        /// <summary>
        /// Location Map
        /// </summary>
        public string WS_LOCATION_MAPAPI
        {
            get
            {
                return GetAppKeyValue(Constants.LOCATION_WSMAP_API);
            }
        }
        #endregion

        #region Config BankGate
        public string DestinationUrl
        {
            get
            {
                return GetAppKeyValue(Constants.DESTINATION_URL);
            }
        }

        public string MerchantIDs
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_IDS);
            }
        }

        public string MerchantKey
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_KEY);
            }
        }

        public string MerchantSecurityKey
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_SECURITY_KEY);
            }
        }

        public string MerchantURLDone
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_URL_DONE);
            }
        }

        public string MerchantCode
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_CODE);
            }
        }

        public string PayVND
        {
            get
            {
                return GetAppKeyValue(Constants.PAY_VND);
            }
        }

        public string PayVcoinPayment
        {
            get
            {
                return GetAppKeyValue(Constants.PAY_VCOIN_PAYMENT);
            }
        }

        public string MerchantDescription
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_DESCRIPTION);
            }
        }
        public string PayCost
        {
            get
            {
                return GetAppKeyValue(Constants.PAY_COST);
            }
        }
        public string MerchantCertificates
        {
            get
            {
                return GetAppKeyValue(Constants.MERCHANT_CERTIFICATES);
            }
        }
        
        #endregion

        #region Cấu hình thanh toán tiền Go trên trang SS
        public string SS_PAYMENT_SITE_ID
        {
            get
            {
                return GetAppKeyValue(Constants.SS_PAYMENT_SITE_ID);
            }
        }
        public string SS_PAYMENT_IP_SERVER
        {
            get
            {
                return GetAppKeyValue(Constants.SS_PAYMENT_IP_SERVER);
            }
        }
        public string SS_PAYMENT_KEY
        {
            get
            {
                return GetAppKeyValue(Constants.SS_PAYMENT_KEY);
            }
        }
        public string SS_PAYMENT_PASSWORD
        {
            get
            {
                return GetAppKeyValue(Constants.SS_PAYMENT_PASSWORD);
            }
        }
        #endregion

        #region Cấu hình thanh toán qua NganLuong
        public string NganLuongUrl
        {
            get
            {
                return GetAppKeyValue(Constants.NGANLUONG_URL);
            }
        }
        public string NganLuongSiteCode
        {
            get
            {
                return GetAppKeyValue(Constants.NGANLUONG_SITE_CODE);
            }
        }
        public string NganLuongSecure
        {
            get
            {
                return GetAppKeyValue(Constants.NGANLUONG_SECURE);
            }
        }
        #endregion

        #region Cấu hình thanh toán qua Paygate
        public string PaygateURL
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_URL);
            }
        }
        public string PaygateSiteID
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_SITE_ID);
            }
        }
        public string PaygateVNDVcoin
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_VND_VCOIN);
            }
        }
        public string PaygateVND
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_VND);
            }
        }
        public string PaygateVcoin
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_VCOIN);
            }
        }
        public string PaygatePrivateKey
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_PRIVATE_KEY);
            }
        }
        public string PaygatePublicKey
        {
            get
            {
                return GetAppKeyValue(Constants.PAYGATE_PUBLIC_KEY);
            }
        }
        #endregion

        #region Cấu hình thanh toán qua Banknetvn
        public string BanknetvnURL
        {
            get
            {
                return GetAppKeyValue(Constants.BANKNETVN_URL);
            }
        }
        public string BanknetvnCode
        {
            get
            {
                return GetAppKeyValue(Constants.BANKNETVN_CODE);
            }
        }
        public string BanknetvnCountryCode
        {
            get
            {
                return GetAppKeyValue(Constants.BANKETVN_COUNTRY_CODE);
            }
        }
        public string BanknetvnTransKey
        {
            get
            {
                return GetAppKeyValue(Constants.BANNETVN_TRANS_KEY);
            }
        }
        #endregion

        #region Cấu hình thanh toán qua Bet168
        public string Bet168URL
        {
            get
            {
                return GetAppKeyValue(Constants.BET168_URL);
            }
        }
        public string Bet168Key
        {
            get
            {
                return GetAppKeyValue(Constants.BET168_KEY);
            }
        }
        #endregion

        #region Cấu hình Location
        public string LOCATION_VIEW_MAP
        {
            get
            {
                return GetAppKeyValue(Constants.LOCATION_VIEW_MAP);
            }
        }
        public string LOCATION_API_VIEW
        {
            get
            {
                return GetAppKeyValue(Constants.LOCATION_API_VIEW);
            }
        }
        public string LOCATION_API_POST
        {
            get
            {
                return GetAppKeyValue(Constants.LOCATION_API_POST);
            }
        }
        public string LOCATION_API_SEARCH
        {
            get
            {
                return GetAppKeyValue(Constants.LOCATION_API_SEARCH);
            }
        }
        #endregion

        #region Cấu hình thư mục chứa File Excel
        public string BUYINGGROUP_FILE_EXCEL
        {
            get
            {
                return GetAppKeyValue(Constants.BUYINGGROUP_FILE_EXCEL);
            }
        }     
        #endregion
    }
}
