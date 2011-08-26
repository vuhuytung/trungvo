using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class userControls_ucSuport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CtrAdmin config = new CtrAdmin();
            var info = config.GetConfigInfo();
            if (info == null)
                return;
            var listYahoo = new List<supportYahoo>();
            if ((info.Yahoo1 != null) && (info.Yahoo1.Trim() != ""))
            {
                listYahoo.Add(new supportYahoo(info.Yahoo1, info.TextYahoo1));
            }
            if ((info.Yahoo2 != null) && (info.Yahoo2.Trim() != ""))
            {
                listYahoo.Add(new supportYahoo(info.Yahoo2, info.TextYahoo2));
            }
            if ((info.Yahoo3 != null) && (info.Yahoo3.Trim() != ""))
            {
                listYahoo.Add(new supportYahoo(info.Yahoo3, info.TextYahoo3));
            }
            var listSkype = new List<supportSkype>();
            if ((info.Skype1 != null) && (info.Skype1.Trim() != ""))
            {
                listSkype.Add(new supportSkype(info.Skype1, info.TextSkype1));
            }
            if ((info.Skype2 != null) && (info.Skype2.Trim() != ""))
            {
                listSkype.Add(new supportSkype(info.Skype2, info.TextSkype2));
            }
            if ((info.Skype3 != null) && (info.Skype3.Trim() != ""))
            {
                listSkype.Add(new supportSkype(info.Skype3, info.TextSkype3));
            }
            rptYahoo.DataSource = listYahoo;
            rptYahoo.DataBind();
            rptSkype.DataSource = listSkype;
            rptSkype.DataBind();
        }
    }
    protected class supportYahoo
    {
        protected string m_YahooID = "";
        protected string m_YahooText = "";
        public string YahooID
        {
            get { return m_YahooID; }
            set { m_YahooID = value; }
        }
        public string YahooText
        {
            get { return m_YahooText; }
            set { m_YahooText = value; }
        }
        public supportYahoo(string id, string text)
        {
            m_YahooID = id;
            m_YahooText = text;
        }
    }
    protected class supportSkype
    {
        protected string m_SkypeID = "";
        protected string m_SkypeText = "";
        public string SkypeID
        {
            get { return m_SkypeID; }
            set { m_SkypeID = value; }
        }
        public string SkypeText
        {
            get { return m_SkypeText; }
            set { m_SkypeText = value; }
        }
        public supportSkype(string id, string text)
        {
            m_SkypeID = id;
            m_SkypeText = text;
        }
    }
}