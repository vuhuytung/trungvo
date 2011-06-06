//
// Author: thanh.le
// Creare Date: 10-09-2010
// Description: Enum trong BuyingGroupUser
//

namespace VTCO.Config.Enums
{
    public enum BuyingGroupUserEnum
    {
        SecurityMoneyNotPayment = -1,//Tham gia mua hàng theo nhóm chưa thanh toán
        SecurityMoney = 0,//Đặt cọc
        AwaitingShipment = 1,//Chờ chuyển hàng
    }
}
