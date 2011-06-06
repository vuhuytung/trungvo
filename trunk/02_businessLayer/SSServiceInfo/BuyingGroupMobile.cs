using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSServiceInfo
{
    public class BuyingGroupMobile
    {
        private int m_buyingGroupID;
        /// <summary>
        /// ID BuyingGroup
        /// </summary>
        public int BuyingGroupID
        {
            get { return m_buyingGroupID; }
            set { m_buyingGroupID = value; }
        }

        private string m_title;
        /// <summary>
        /// Tiêu đề BuyingGroup
        /// </summary>
        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        private string m_description;
        /// <summary>
        /// Mô tả nhóm mua hàng
        /// </summary>
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        private string m_imageUrl;
        /// <summary>
        /// Ảnh của BuyingGroup
        /// </summary>
        public string ImageUrl
        {
            get { return m_imageUrl; }
            set { m_imageUrl = value; }
        }

        private long m_priceRoot;
        /// <summary>
        /// Giá gốc
        /// </summary>
        public long PriceRoot
        {
            get { return m_priceRoot; }
            set { m_priceRoot = value; }
        }

        private long m_priceMax;
        /// <summary>
        /// Giá lớn nhất
        /// </summary>
        public long PriceMax
        {
            get { return m_priceMax; }
            set { m_priceMax = value; }
        }

        private long m_priceMin;
        /// <summary>
        /// Giá nhỏ nhất
        /// </summary>
        public long PriceMin
        {
            get { return m_priceMin; }
            set { m_priceMin = value; }
        }

        private long m_currentPrice;
        /// <summary>
        /// Giá hiện tại
        /// </summary>
        public long CurrentPrice
        {
            get { return m_currentPrice; }
            set { m_currentPrice = value; }
        }

        private int m_currentProductAmount;
        /// <summary>
        /// Số sản phẩm hiện tại
        /// </summary>
        public int CurrentProductAmount
        {
            get { return m_currentProductAmount; }
            set { m_currentProductAmount = value; }
        }

        public BuyingGroupMobile() { }
        public BuyingGroupMobile(int buyingGroupID, string title, string imageUrl, long priceRoot,long priceMax, long priceMin, long currentPrice,int currentProductAmount)
        {
            m_buyingGroupID = buyingGroupID;
            m_title = title;
            m_imageUrl = imageUrl;
            m_priceRoot = priceRoot;
            m_priceMax = priceMax;
            m_priceMin = priceMin;
            m_currentPrice = currentPrice;
            m_currentProductAmount = CurrentProductAmount;
        }
        public BuyingGroupMobile(int buyingGroupID, string title,string description, string imageUrl, long priceRoot, long priceMax, long priceMin, long currentPrice, int currentProductAmount)
        {
            m_buyingGroupID = buyingGroupID;
            m_title = title;
            m_description = description;
            m_imageUrl = imageUrl;
            m_priceRoot = priceRoot;
            m_priceMax = priceMax;
            m_priceMin = priceMin;
            m_currentPrice = currentPrice;
            m_currentProductAmount = CurrentProductAmount;
        }
    }
}
