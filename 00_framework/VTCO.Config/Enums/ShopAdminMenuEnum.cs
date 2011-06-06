//
// Author:      duong.le
// Create Date: 2010-08-02
// Description: Danh sách menu của shop admin
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config.Enums
{
    public enum ShopAdminMenuEnum
    {
        /// <summary>
        /// Quản lý mua hàng theo nhóm
        /// </summary>
        BuyingGroup = 1,

        /// <summary>
        /// Quản lý khách hàng
        /// </summary>
        Customer = 2,

        /// <summary>
        /// Quản lý FanClub
        /// </summary>
        FanClub = 3,

        /// <summary>
        /// Quản lý thư viện ảnh
        /// </summary>
        Images = 4,

        /// <summary>
        /// Quản lý chuyên mục
        /// </summary>
        Category = 5,

        /// <summary>
        /// Quản lý sản phẩm
        /// </summary>
        Product = 6,

        /// <summary>
        /// Quản lý khuyến mãi
        /// </summary>
        Promotion = 7,

        /// <summary>
        /// Quản lý giao dịch
        /// </summary>
        Transaction = 8,

        /// <summary>
        /// Thống kê
        /// </summary>
        Report =  9,

        /// <summary>
        /// Quản lý đơn hàng
        /// </summary>
        Order = 10,

        /// <summary>
        /// Rao vặt
        /// </summary>
        WantAds = 11,
        /// <summary>
        /// Thông tin
        /// </summary>
        Info = 12,
        /// <summary>
        /// Tin nhắn
        /// </summary>
        Message = 13,
        /// <summary>
        /// Theme
        /// </summary>
        Theme = 14,
        /// <summary>
        /// QA
        /// </summary>
        QA = 15,
        /// <summary>
        /// Advertisement
        /// </summary>
        Advertisement=16,
        /// <summary>
        /// Contact
        /// </summary>
        Contact=17
    }
}
