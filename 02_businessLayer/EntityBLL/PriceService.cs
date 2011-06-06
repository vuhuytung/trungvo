using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VTCO.Config.Enums;

namespace EntityBLL
{
    /// <summary>
    /// Lớp lưu giá trị của PriceService
    /// </summary>
    public class PriceServiceValue
    {
        private int m_priceServiceID;

        public int PriceServiceID
        {
            get { return m_priceServiceID; }
            set { m_priceServiceID = value; }
        }
        private long m_price;

        public long Price
        {
            get { return m_price; }
            set { m_price = value; }
        }
    }

    public class PriceService
    {
        private Dictionary<string, PriceServiceValue> m_dicPriceService;
        
        public static PriceService Instance 
        {
            get
            {
                return VTCO.Config.Pattern.Singleton<PriceService>.Instance;
            }
        }

        public PriceService()
        {
            if (m_dicPriceService != null)
            {
                m_dicPriceService.Clear();
            }
            else
            {
                m_dicPriceService = new Dictionary<string, PriceServiceValue>();
            }
           
        }
        
        public PriceServiceValue this[ServiceCodeEnum key]
        {
            get
            {
                string sKey = key.ToString();
                if (m_dicPriceService.ContainsKey(sKey))
                {
                    return m_dicPriceService[sKey];
                }
                else
                {
                    PriceServiceValue value = new PriceServiceValue();
                    value.PriceServiceID = -1;
                    value.Price = 0;
                    return value;
                }
            }
        }
    }
}
