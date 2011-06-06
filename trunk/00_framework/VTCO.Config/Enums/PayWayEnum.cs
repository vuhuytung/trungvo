//
// Author: thanh.le
// Creare Date: 10-08-2010
// Description: Enum trong PayWay
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config.Enums
{
    public enum PayWayEnum
    {
        Ebank = 1,
        TRANFER,
        VietComBank = 3,
        OnePay = 4,
        Vib = 5,
        TechComBank = 6,
        Mobivi = 7,
        Dab = 8,
        PayPal = 9,
        VtcCard = 10,
        DIRECT,
    }

    public enum PayStatusEnum
    {
        PayWaiting = 1, //Chưa chuyển
        PaySuccess = 2, //Chuyển thành công
    }
}
