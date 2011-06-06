//
// Author: thanh.le
// Creare Date: 10-09-2010
// Description: Enum trong MailTemplate
//

namespace VTCO.Config.Enums
{
    public enum MailTemplateEnum
    {
        BUYING_GROUP_JOIN_SUCCESS, //Tham gia mua hàng theo nhóm thành công
        BUYING_GROUP_PAYMENT_SUCCESS, //Gửi thông báo cho khách hàng khi thanh toán mua hàng theo nhóm online thành công
        BUYING_GROUP_PAYMENT_SUCCESS_TO_SHOP,//Gửi thông báo cho chủ shop khi thanh toán mua hàng theo nhóm thành công
        BUYING_GROUP_NOTIFY_FINISH, //Gửi thông báo mail cho user quan tâm khi Buying Group kết thúc
        BUYING_GROUP_NOTIFY_NEW_PRICE, //Gửi thông báo mail cho user quan tâm khi BuyingGroup đạt mức giá mới
        BUYING_GROUP_NOTIFY_FINISH_TO_SHOP, //Gửi thông báo mail cho chủ shop khi BuyingGroup kết thúc
        CREATE_SHOP_SUCCESS, //Gửi thông báo tạo shop thành công
        CENSOR_SHOP_ACCEPT, //Gửi thông báo shop đã được duyệt
        CENSOR_SHOP_REJECT, //Gửi thông báo shop đã bị từ chối sau khi duyệt
        BUYING_GROUP_NEW_SEND_MAIL //Gửi thông báo có nhóm mua mới được tạo
    }
}
