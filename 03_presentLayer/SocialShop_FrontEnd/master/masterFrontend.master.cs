using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_masterFrontend : System.Web.UI.MasterPage
{
    public bool VisibleNavigator
    {
        set
        {
            ucNavigator1.Visible = value;
        }       
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
