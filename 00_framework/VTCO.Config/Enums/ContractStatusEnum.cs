using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config.Enums
{
    public enum ContractStatusEnum
    {
        /// <summary>
        /// Shop chưa ký hợp đồng
        /// </summary>
        ChuaHopDong = 0,

        /// <summary>
        /// Shop chờ ký hợp đồng
        /// </summary>
        ChoHopDong = 1,

        /// <summary>
        /// Shop đã ký hợ đồng với SS
        /// </summary>
        HopDong = 2
    }
}
