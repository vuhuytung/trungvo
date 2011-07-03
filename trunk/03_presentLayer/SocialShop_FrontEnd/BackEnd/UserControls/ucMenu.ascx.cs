using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VTCO.Config;
using WorkFlowBLL;

public partial class backend_UserControls_ucMenu : System.Web.UI.UserControl
{
    public string CurrentPage
    {
        get
        {
            if (Session[Constants.SESSION_CURRENT_PAGE] == null)
                return "";
            return Session[Constants.SESSION_CURRENT_PAGE].ToString();
            
        }
    }

    public string CurrentTab
    {
        get
        {
            if (Session[Constants.SESSION_CURRENT_TAB] == null)
                return "";
            return Session[Constants.SESSION_CURRENT_TAB].ToString();
        }
    }
    private int m_STT;
    private int m_RowCount;
    private DataTable tblMenuParent;
    private int m_LanguageID;
    private int m_AccountID;
    CtrAdmin _menu = new CtrAdmin();
    public string getHover(string _currentPage)
    {
        if (CurrentPage == _currentPage)
        {
            return "hover";
        }
        return "";
    }

    public string getDisplay(string _currentPage)
    {
        if (CurrentPage == _currentPage)
        {
            return "";
        }
        return "none";
    }

    public string getCurrent(string _currentTab)
    {
        if (CurrentTab == _currentTab)
        {
            return "current";
        }
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            m_AccountID = Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID]);
            var tblMenuParent = _menu.FunctionGetByParentID(0,1);
            m_RowCount = tblMenuParent.Count;
            m_STT = 1;
            rptMenuParent.DataSource = tblMenuParent;
            rptMenuParent.DataBind();

            rptTab.DataSource = tblMenuParent;
            rptTab.DataBind();
        }

    }
    protected void rptMenuParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var hdfMenuID = e.Item.FindControl("hdfMenuID") as HiddenField;
        var hdfName = e.Item.FindControl("hdfName") as HiddenField;
        var hdfLink = e.Item.FindControl("hdfLink") as HiddenField;
        var hdfImage = e.Item.FindControl("hdfImage") as HiddenField;
        var ltrItem = e.Item.FindControl("ltrItem") as Literal;
        if (ltrItem == null) return;
        string strItem = string.Empty;
       if (m_STT == m_RowCount)
        {
            strItem += "<li class=\"last\">";
        }
        else
        {
            strItem += "<li>";
        }
        strItem += "<a id=\"" +  hdfMenuID.Value + "\" href=\"#\" class=\"" + getHover(hdfMenuID.Value) + "\">";
        strItem += "<div style=\"position: relative;\">";
        strItem += "<span class=\"outer\">";
        strItem += "<span style=\"background-image: url(" + hdfImage.Value + "); background-repeat: no-repeat;\" class=\"inner\">";
        strItem += hdfName.Value + "</span> </span></div></a></li>";
        ltrItem.Text = strItem;
        m_STT++;
    }
    protected void rptTab_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var hdfMenuID = e.Item.FindControl("hdfMenuID") as HiddenField;
        var rptMenuChild = e.Item.FindControl("rptMenuChild") as Repeater;
        var ltrDiv = e.Item.FindControl("ltrDiv") as Literal;
        if (hdfMenuID  == null) return;
        
        rptMenuChild.DataSource = _menu.FunctionGetByParentID(Convert.ToInt32(hdfMenuID.Value),1);
        rptMenuChild.DataBind();
        string strDiv = string.Empty;
        strDiv += "<div id=\"subMenu_"+hdfMenuID.Value + "\" class=\"subMenu\" style=\"display:" + getDisplay(hdfMenuID.Value) +";\">";
        ltrDiv.Text = strDiv;
    }
    protected void rptMenuChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var hdfMenuID = e.Item.FindControl("hdfMenuID") as HiddenField;
        var ltrContent = e.Item.FindControl("ltrContent") as Literal;
        var hdfName = e.Item.FindControl("hdfName") as HiddenField;
        var hdfLink = e.Item.FindControl("hdfLink") as HiddenField;
         if (hdfMenuID  == null) return;
        string strContent = string.Empty;
        strContent = "<a id=\"tab_"+ hdfMenuID.Value +"\" class=\""+ getCurrent(hdfMenuID.Value) + "\" href=\""+hdfLink.Value+"\"><span>"+hdfName.Value+"</span></a>";
        ltrContent.Text = strContent;
    }
}
