//
// Author:      duong.le
// Create Date: 2010-07-10
// Description: UserMenu
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config.Enums
{
    public enum UserMenuEnum
    {
        /// <summary>
        /// Không focus menu nào
        /// </summary>
        None = 0,

        /// <summary>
        /// Thông tin giao dịch
        /// </summary>
        UserInfo = 1,

        /// <summary>
        /// Fan của shop
        /// </summary>
        UserShopFan = 2,

        /// <summary>
        /// Tin rao vặt
        /// </summary>
        UserWantAds = 3,

        /// <summary>
        /// Tài sản cá nhân
        /// </summary>
        UserOwnerProduct = 4,

        /// <summary>
        /// Sản phẩm yêu thích
        /// </summary>
        UserMarkProduct = 5,

        /// <summary>
        /// Ảnh khoe hàng
        /// </summary>
        UserShowImageProduct = 6,

        /// <summary>
        /// Hỏi đáp tham gia
        /// </summary>
        UserQA = 7,

        /// <summary>
        /// Quản lý giao dịch
        /// </summary>
        UserTransaction = 8,

        /// <summary>
        /// Thống kê
        /// </summary>
        UserReport = 9,

        /// <summary>
        /// Mua hàng theo nhóm
        /// </summary>
        UserBuyingGroup = 10,

        /// <summary>
        /// Nạp Go vào tài khoản
        /// </summary>
        UserPayGo = 11
    }
}
