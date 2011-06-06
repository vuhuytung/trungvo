
namespace SSServiceInfo
{
    public class Category
    {
        private int m_categoryID;

        public int CategoryID
        {
            get { return m_categoryID; }
            set { m_categoryID = value; }
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private int? m_parentID;

        public int? ParentID
        {
            get { return m_parentID; }
            set { m_parentID = value; }
        }

        private int m_order;

        public int Order
        {
            get { return m_order; }
            set { m_order = value; }
        }

        private int m_status;

        public int Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        public Category() { }

        public Category(int categoryID, string name, int? parentID, int order, int status)
        {
            m_categoryID = categoryID;
            m_name = name;
            m_parentID = parentID;
            m_order = order;
            m_status = status;
        }

    }
}
