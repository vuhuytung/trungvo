using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSServiceInfo
{
    public class LocationBuyingGroup
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

        public LocationBuyingGroup() { }
        public LocationBuyingGroup(int locationID, int code, string name)
        {
            m_locationID = locationID;
            m_code = code;
            m_name = name;
        }
    }
}
