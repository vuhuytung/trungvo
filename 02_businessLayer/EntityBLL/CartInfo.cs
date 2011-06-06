using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityBLL
{
    public class CartInfo : VTCO.Config.Pattern.Prototype<CartInfo>
    {
        /// <summary>
        /// Đối tượng thể hiện BaseInfo
        /// </summary>
        public static CartInfo Instance
        {
            get
            {
                return VTCO.Config.Pattern.Singleton<CartInfo>.Instance;
            }
        }

        private int m_Quantity;
        /// <summary>
        /// Số lượng sản phẩm trong giỏ hàng
        /// </summary>
        public int Quantity
        {
            get { return m_Quantity; }
            set { m_Quantity = value; }
        }

        private double  m_TotalMoneyProduct;
        /// <summary>
        /// Tổng tiền giỏ hàng
        /// </summary>
        public double TotalMoneyProduct
        {
            get { return m_TotalMoneyProduct; }
            set { m_TotalMoneyProduct = value; }
        }

        private double m_TotalMoneyPromotion;

        /// <summary>
        ///  Tổng số tiền khuyến mãi
        /// </summary>
        public double TotalMoneyPromotion
        {
            get { return m_TotalMoneyPromotion; }
            set { m_TotalMoneyPromotion = value; }
        }

        private double m_TotalPercentPromotion;
        /// <summary>
        /// Tổng số phần trăm khuyến mãi
        /// </summary>
        public double TotalPercentPromotion
        {
            get { return m_TotalPercentPromotion; }
            set { m_TotalPercentPromotion = value; }
        }

        public SiteInfo Site
        {
            get
            {
                return SiteInfo.Instance;
            }
        }
    }
}
