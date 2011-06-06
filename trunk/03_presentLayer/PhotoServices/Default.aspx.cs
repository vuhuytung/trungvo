using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRequestPage = Request.ServerVariables["QUERY_STRING"].Replace("404;", "");
        string strServiceABSURL = Request.ServerVariables["SCRIPT_NAME"].Replace("srv_errorhandle.aspx", "");
        Response.Write(strRequestPage + "<br/>");
        Response.Write(strServiceABSURL);
    }
}