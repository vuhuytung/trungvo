using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config.Enums
{
    public enum PromotionStatusEnum
    {
        /// <summary>
        /// Bị khóa
        /// </summary>
        Lock = 0,
        /// <summary>
        /// Đang hoạt động
        /// </summary>
        Active = 1,
        /// <summary>
        /// Bị xóa
        /// </summary>
        Delete = 2
    }
}
