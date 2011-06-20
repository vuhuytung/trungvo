using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CtrCategory Menu = new CtrCategory();
        if (!IsPostBack)
        {
            //Literal1.Text = Menu.ReturnHtmlMenu();
        }
        
    }
}