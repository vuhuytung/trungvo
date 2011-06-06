//
// Author: trung.pham
// Creare Date: 2010-06-30
// Description: Enum trong BuyingGroup
//

namespace VTCO.Config.Enums
{
    public enum BuyingGroupStatusEnum : int
    {
        GetALL = 0,          // Lấy theo tất cả 
        NotStart = 1,        // Chưa diễn ra
        Starting = 2,        // Đang diễn ra
        End = 3,             // Đã kết thúc      
    }
}
