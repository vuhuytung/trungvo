using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VTCO.Config;

public partial class userControls_ucLogin : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtLogout_Click(object sender, EventArgs e)
    {
        Session[Constants.SESSION_USER_NAME] = null;
        Session[Constants.SESSION_USER_ID] = null;
        Session[Constants.SESSION_USER_FULLNAME] = null;
        Session[Constants.SESSION_USER_ISLOGIN] = false;
    }
}