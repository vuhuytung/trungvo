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
        CtrCategory ctr = new CtrCategory();
        GridView1.DataSource = ctr.GetListCategory();
        GridView1.DataBind();
    }
}