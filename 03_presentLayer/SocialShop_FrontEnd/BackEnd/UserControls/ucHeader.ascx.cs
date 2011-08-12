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
//using BusinessObject;
using VTCO.Config;
using WorkFlowBLL;

public partial class UserControls_ucHeader : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void linkLogout_Click(object sender, EventArgs e)
    {
        Session[Constants.SESSION_ADMIN_NAME] = null;
        Session[Constants.SESSION_ADMIN_ID] = null;
        Session[Constants.SESSION_ADMIN_FULLNAME] = null;
        Session[Constants.SESSION_ADMIN_LEVEL] = null;
        Session[Constants.SESSION_ADMIN_ISLOGIN] = false;

        ViewState[Constants.SESSION_CURRENT_PAGE] = "0";
        ViewState[Constants.SESSION_CURRENT_TAB] = null;
        CookieManagement.Instance["current_page", false] = "0";
        CookieManagement.Instance["current_tab", false] = null;
        Response.Redirect("~/admin/login");
    }
}
