//
// Author: trung.pham
// Creare Date: 2010-06-30
// Description: Enum trong warning
//

namespace VTCO.Config.Enums
{
    public enum SMSTypeEnum : int
    {
        SSAdmin = 1,   // Hệ thống
        ShopOwner = 2, // Chủ Shop
        User = 3       // User
    }
    public enum SMSStatusPaymentEnum : int
    {
        GetAll=-1,                 // Lấy tất cả (Dùng trong hàm lấy danh sách SMS, ko dùng trong câu lệnh Insert)
        NotPayment = 0,            // Chưa thanh toán
        PaymentWithSocialShop = 2, // Đã thanh toán với SocialShop
        PaymentWithSMSPort = 3     // Đã thanh toán với cổng cung cấp dịch vụ SMS
    } 
}
