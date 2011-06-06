//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2010-07-05
// Description: Các hằng số biểu thị trạng thái của sản phẩm
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Config
{
    /// <summary>
    /// Các hàng số biểu thị các trạng thái của sản phẩm
    /// </summary>
    public class ProductStatusConstants
    {
        /// <summary>
        /// Đã kiểm duyệt hay chưa
        /// </summary>
        public const int IS_CHECK = 128;
        

        /// <summary>
        /// Admin đã kiểm duyệt cho sản phẩm hay chưa
        /// </summary>
        public const int PRODUCT_CHECK = 64;


        /// <summary>
        /// Category Portal hiện hay ẩn
        /// </summary>
        public const int PORTAL_CATE_SHOW = 32;

        /// <summary>
        /// Shop Active hay chưa
        /// </summary>
        public const int SHOP_ACTIVE = 16;

        /// <summary>
        /// Category của shop hiện hay ẩn
        /// </summary>
        public const int SHOP_CATE_SHOW = 8;

        /// <summary>
        /// Sản phẩm hiện hay ẩn
        /// </summary>
        public const int PRODUCT_SHOW = 4;

        /// <summary>
        /// Còn hàng hay hết hàng
        /// </summary>
        public const int EXIST_PRODUCT = 2;

        /// <summary>
        /// Chưa xóa hay đã xóa
        /// </summary>
        public const int NOT_DELETE = 1;

        /// <summary>
        /// Product được phép hiển thị trên portal
        /// </summary>
        public const int PORTAL_VISIBLE_PRODUCT_STATUS = 125;// 01111101

        /// <summary>
        /// Product được phép hiển thị trên shop
        /// </summary>
        public const int SHOP_VISIBLE_PRODUCT_STATUS  = 93; //  01011101

        /// <summary>
        /// Set Status cho input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int SetStatus(int input, int status)
        {
            return input | status;
        }

        /// <summary>
        /// Clear status cho dữ liệu iput
        /// </summary>
        /// <param name="input"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int ClearStatus(int input, int status)
        {
            return input & (~status);
        }
    }

    public class BuyingGroupStatusConstants
    {
        /// <summary>
        /// Đã được kiểm duyệt hay chưa
        /// </summary>
        public const int IS_CHECK = 8;
        /// <summary>
        /// Đã kiểm duyệt hay chưa
        /// </summary>
        public const int SOCIALSHOP = 4;
        /// <summary>
        /// BuyingGroup ẩn hay hiện
        /// </summary>
        public const int BUYINGGROUP_SHOW = 2;
        /// <summary>
        /// Đã xóa hay chưa?
        /// </summary>
        public const int IS_NOT_DELETE = 1;

    }

    public class PermissionStatusConstants
    {
        /// <summary>
        /// Chỉ xem
        /// </summary>
        public const int READ_ONLY = 8;
        /// <summary>
        /// Thêm mới
        /// </summary>
        public const int ADD = 4;
        /// <summary>
        /// Sửa
        /// </summary>
        public const int EDIT = 2;
        /// <summary>
        /// Xóa
        /// </summary>
        public const int DELETE = 1;
        
    }

    public class LogActionConstants
    {
        /// <summary>
        /// Login
        /// </summary>
        public const char Login = 'L';
        /// <summary>
        /// Thêm mới
        /// </summary>
        public const char Add = 'A';
        /// <summary>
        /// Sửa
        /// </summary>
        public const char Modify = 'M';
        /// <summary>
        /// Xóa
        /// </summary>
        public const char Delete = 'D';
        /// <summary>
        /// Cập nhật trạng thái
        /// </summary>
        public const char ChangeStatus = 'C';
    }

    public class ShopNewsStatusConstants
    {
        /// <summary>
        /// chưa xóa hay đã xóa
        /// </summary>
        public const int NOT_DELETE = 1;
        /// <summary>
        /// hiện hay ẩn
        /// </summary>
        public const int NEWS_SHOW = 2;

    }
}
