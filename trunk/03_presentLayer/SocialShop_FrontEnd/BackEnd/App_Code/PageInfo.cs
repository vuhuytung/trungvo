using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for PageInfo
/// </summary>
public class PageInfo
{
    private string m_Text;
    public string Text
    {
        get { return this.m_Text; }
        set { this.m_Text = value; }
    }
    private int m_Page;
    public int Page
    {
        get { return this.m_Page; }
        set { this.m_Page = value; }
    }
    public PageInfo(string m_Text, int m_Page)
    {
        this.m_Text = m_Text;
        this.m_Page = m_Page;
    }
}
