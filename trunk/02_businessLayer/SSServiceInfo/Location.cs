
namespace SSServiceInfo
{
    public class Location
    {
        private int m_locationID;
        /// <summary>
        /// ID Location
        /// </summary>
        public int LocationID
        {
            get { return m_locationID; }
            set { m_locationID = value; }
        }

        private int m_code;
        /// <summary>
        /// Mã ĐVHC
        /// </summary>
        public int Code
        {
            get { return m_code; }
            set { m_code = value; }
        }

        private string m_name;
        /// <summary>
        /// Tên ĐVHC
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private int m_provinceCode;
        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public int ProvinceCode
        {
            get { return m_provinceCode; }
            set { m_provinceCode = value; }
        }

        private int m_districtCode;
        /// <summary>
        /// Mã huyện
        /// </summary>
        public int DistrictCode
        {
            get { return m_districtCode; }
            set { m_districtCode = value; }
        }

        private int m_villageCode;
        /// <summary>
        /// Mã xã
        /// </summary>
        public int VillageCode
        {
            get { return m_villageCode; }
            set { m_villageCode = value; }
        }

        public Location() { }        

        public Location(int locationID, int code, string name, int provinceCode, int districtCode, int villageCode)
        {
            m_locationID = locationID;
            m_code = code;
            m_name = name;
            m_provinceCode = provinceCode;
            m_districtCode = districtCode;
            m_villageCode = villageCode;
        }   
    }
}
