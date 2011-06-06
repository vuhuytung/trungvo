//
// Author:      duong.le
// Create Date: 2010-07-13
// Description: Trạng thái chứng thực của shop
//

namespace VTCO.Config.Enums
{
    public enum CertificateStatusEnum
    {
        /// <summary>
        /// Shop chưa chứng thực
        /// </summary>
        ChuaChungThuc = 0,

        /// <summary>
        /// Shop chờ chứng thực
        /// </summary>
        ChoChungThuc = 1,

        /// <summary>
        /// Shop Chứng thực
        /// </summary>
        ChungThuc = 2
    }
}
