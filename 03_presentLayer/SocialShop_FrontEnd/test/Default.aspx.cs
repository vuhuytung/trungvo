using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class test_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        CtrCategory ct = new CtrCategory();
        Literal1.Text = ct.ReturnHtmlMenu();
        
    }
}