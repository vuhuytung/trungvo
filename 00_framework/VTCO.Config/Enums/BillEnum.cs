//
// Author: trung.pham
// Creare Date: 2010-06-30
// Description: Enum trong Bill
//

namespace VTCO.Config.Enums
{
    public enum BillStatusEnum : int
    { 
        GetAll =-1,          // Tất cả
        Unpaid = 0,          // Chưa thanh toán
        AwaitingShipment = 1,// Chờ chuyển hàng
        Shiping = 2,         // Đang chuyển hàng
        Received = 3,        // Đã nhận  
        Complaints =4        // Có khiếu nại
    }
}
