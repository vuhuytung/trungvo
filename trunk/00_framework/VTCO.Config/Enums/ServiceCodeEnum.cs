//
// Author:      hoan.trinh
// Create Date: 2010-08-18
// Description: Bảng các mã dịch vụ trong SocialShop
//
namespace VTCO.Config.Enums
{
    /// <summary>
    /// Mã dịch vụ trong social shop
    /// </summary>
    public enum ServiceCodeEnum
    {
        /// <summary>
        /// Mua sản phẩm trên Social Shop
        /// </summary>
        BUY_PRODUCT,

        /// <summary>
        /// Mua hàng theo nhóm trên Social Shop
        /// </summary>
        BUY_BUYING_GROUP,

        /// <summary>
        /// Nộp tiền GO từ eBANK
        /// </summary>
        GO_PAYMENT_FROM_EBANK,
        
        /// <summary>
        /// Đặt cọc mua hàng theo nhóm
        /// </summary>
        JOIN_BUYING_GROUP,
        
        /// <summary>
        /// Phí xuất hiện tại vị trí hàng mới trên Shop
        /// </summary>
        UP_NEW_PRODUCT, 

        /// <summary>
        /// Phí đặt chỗ tại vị trí "Hàng mới trên Shop" trong khoảng thời gian nhất định
        /// </summary>
        BOOK_POSITION_NEW_PRODUCT,

        /// <summary>
        /// Phí xuất hiện tại vị trí "Hàng nổi bật"
        /// </summary>
        UP_HOT_PRODUCT, 

        /// <summary>
        /// Phí đặt chỗ tại vị trí "Hàng nổi bật trên Shop" trong khoản tg nhất định
        /// </summary>
        BOOK_POSITION_HOT_PRODUCT, 

        /// <summary>
        /// Phí tin dính trên trang listing các chuyên mục (2 vị trí)
        /// </summary>
        UP_NEWS, 

        /// <summary>
        /// Tạo shop
        /// </summary>
        CREATE_SHOP, 

        /// <summary>
        ///  Phí chứng thực shop
        /// </summary>
        CERTIFICATE_SHOP, 

        /// <summary>
        /// Phí đổi Skin theo yêu cầu của shop,sẽ tạo 2 loại Skin": có phí và Free
        /// </summary>
        CHANGE_SKIN, 

        /// <summary>
        /// Phí tạo widget (buying group)
        /// </summary>
        CREATE_BUYING_GROUP, 

        /// <summary>
        /// Phí duy trì gian hàng theo thời gian (tính bằng tháng)
        /// </summary>
        MAINTAIN_SHOP, 

        /// <summary>
        /// Phí up sản phẩm lên Shop
        /// </summary>
        CREATE_PRODUCT, 

        /// <summary>
        /// Phí sửa thông tin sản phẩm
        /// </summary>
        EDIT_PRODUCT, 

        /// <summary>
        /// Phí đăng tin trên trang Shop, sẽ có lợi nếu họ đăng nhiều ,đây là tin của Shop( khuyến mãi,gtsp) 
        /// </summary>
        CREATE_NEWS, 

        /// <summary>
        /// Phí sửa tin
        /// </summary>
        EDIT_NEWS, 

        /// <summary>
        /// Mua Theme đưa vào bộ sưu tập Theme
        /// </summary>
        BUY_THEME,

        /// <summary>
        /// Phí mở rộng FanClubs
        /// </summary>
        EXPAND_FANSHOP, 

        /// <summary>
        /// Phí rao tin trên hệ thống Loa của site (dưới header)
        /// </summary>
        TRUMPET_NEWS, 

        /// <summary>
        /// Phí xuất hiện shop tại vị trí Liên hệ trong trang Listing
        /// </summary>
        UP_SHOP_CONTACT, 

        /// <summary>
        /// Phí đặt chỗ shop tại vị trí liê hệ trong trang Listing trong khoảng thời gian nhất định
        /// </summary>
        BOOK_POSITION_SHOP_CONTACT, 
 
        /// <summary>
        /// Phí dịch vụ thông báo tới chủ Shop khi có đơn hàng
        /// </summary>
        SMS_NOTIFY_BILL, 

        /// <summary>
        /// Phí tham gia BuyingGroup
        /// </summary>
        USE_BUYING_GROUP, 

        /// <summary>
        /// Phí dịch vụ kết quả thông tin mua hàng theo nhóm tới user
        /// </summary>
        RECEIVED_BUYING_GROUP_RESULT,

        /// <summary>
        /// Đặt cọc mua hàng theo nhóm
        /// </summary>
        SECURITY_BUYING_GROUP,
        /// <summary>
        /// Phí up banner
        /// </summary>
        UP_BANNER
    }
}
