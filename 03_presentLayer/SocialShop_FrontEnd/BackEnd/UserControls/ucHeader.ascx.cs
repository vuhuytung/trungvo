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

public partial class UserControls_ucHeader : System.Web.UI.UserControl
{
   
    //AccountManagement m_accmgr = new AccountManagement();
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        m_accmgr.LoginAuthentication();    
    //    }
    //}
    protected void linkLogout_Click(object sender, EventArgs e)
    {
        //Session[Constants.SESSION_USERNAME] = null;
        //m_accmgr.LoginAuthentication();
        //Session["MyCulture"] = "th";
    }
}
