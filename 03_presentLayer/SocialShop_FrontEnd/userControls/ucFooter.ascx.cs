using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class userControls_ucFooter : System.Web.UI.UserControl
{
    protected string add = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CtrAdmin ctrA = new CtrAdmin();
            try { add = ctrA.GetConfigInfo().Address; }
            catch { }
        }
    }
}