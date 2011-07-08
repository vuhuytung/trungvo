using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using WorkFlowBLL;
using VTCO.Config;

public partial class master_masterBackend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Timeout = 1;
        //if (!Page.IsPostBack)
        //{
            //MenuManagement _menu = new MenuManagement();
            //var strUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            //var LocalPath = CommonBusiness.GetLocalPath(strUrl);
            //int m_AccountID = Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID]);
            //if(string.IsNullOrEmpty(LocalPath))
            //    LocalPath="/default.aspx";
            //Session[Constants.SESSION_CURRENT_URL] = LocalPath;
            //if (!_menu.CheckPermission(m_AccountID,LocalPath))
            //{
            //    ViewState[Constants.SESSION_CURRENT_PAGE] = "0";
            //    ViewState[Constants.SESSION_CURRENT_TAB] = null;
            //    CookieManagement.Instance["current_page", false] = "0";
            //    CookieManagement.Instance["current_tab", false] = null;
            //    Response.Redirect("/default.aspx");
            //}
            //if (LocalPath != "/default.aspx")
            //{
            //    var MenuID = _menu.GetMenuIDByLink(LocalPath);
            //    var MenuParrentID = _menu.GetParentIDByChildID(MenuID);
            //    if (MenuParrentID == 0)
            //    {
            //        Session[Constants.SESSION_CURRENT_PAGE] = MenuID;
            //        CookieManagement.Instance["current_page", false] = MenuID.ToString();
            //    }
            //    else
            //    {
            //        Session[Constants.SESSION_CURRENT_PAGE] = MenuParrentID;
            //        Session[Constants.SESSION_CURRENT_TAB] = MenuID;
            //        CookieManagement.Instance["current_page", false] = MenuParrentID.ToString();
            //        CookieManagement.Instance["current_tab", false] = MenuID.ToString();
            //    }
            //}

        //}
    }
   
}
