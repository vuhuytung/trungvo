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
using ComponentBLL;

public partial class master_masterBackend : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 1;
        bool islogin = Convert.ToBoolean(Session[Constants.SESSION_ADMIN_ISLOGIN] ?? false);
        if (!islogin)
            Response.Redirect("~/admin/login");
        if (!Page.IsPostBack)
        {
            CtrAdmin _menu = new CtrAdmin();
            var strUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            var LocalPath = CommonBusiness.GetLocalPath(strUrl);
            int m_AccountID = Convert.ToInt32(Session[Constants.SESSION_ADMIN_ID]??0);
            int level = Convert.ToInt32(Session[Constants.SESSION_ADMIN_LEVEL]??2);            
            if (string.IsNullOrEmpty(LocalPath))
                LocalPath = "/admin/login";
            Session[Constants.SESSION_CURRENT_URL] = LocalPath;

            if ((LocalPath != "/admin") && (LocalPath != "/admin/notpermission"))
            {                
                var MenuID = _menu.GetMenuIDByLink(LocalPath);
                var MenuParrentID = _menu.GetParentIDByChildID(MenuID);
                if (MenuParrentID == 0)
                {
                    Session[Constants.SESSION_CURRENT_PAGE] = MenuID;
                    CookieManagement.Instance["current_page", false] = MenuID.ToString();
                }
                else
                {
                    Session[Constants.SESSION_CURRENT_PAGE] = MenuParrentID;
                    Session[Constants.SESSION_CURRENT_TAB] = MenuID;
                    CookieManagement.Instance["current_page", false] = MenuParrentID.ToString();
                    CookieManagement.Instance["current_tab", false] = MenuID.ToString();
                }

                var Read = ((_menu.CheckPermission(m_AccountID, LocalPath) & 1) == 1);
                if (!Read && (level != 1))
                {
                    Response.Redirect("~/admin/notpermission");
                }
            }
            else
            {
                ViewState[Constants.SESSION_CURRENT_PAGE] = "0";
                ViewState[Constants.SESSION_CURRENT_TAB] = null;
                CookieManagement.Instance["current_page", false] = "0";
                CookieManagement.Instance["current_tab", false] = null;
            }

        }
    }
   
}
