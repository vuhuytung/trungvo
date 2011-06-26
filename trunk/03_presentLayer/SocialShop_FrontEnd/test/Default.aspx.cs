using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class test_Default : System.Web.UI.Page
{
    CtrDocument doc = new CtrDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["page"] != null)
        {
            GridView1.DataSource = doc.DocumentGetAll(21, Int32.Parse(Request.QueryString["page"]), 4, 4);
            GridView1.DataBind();
            Literal1.Text = doc.DocumentGetPage(21, Int32.Parse(Request.QueryString["page"]), 4, 4)[0].PhanTrang.ToString();
        }
        else
        {

            GridView1.DataSource = doc.DocumentGetAll(21, 1, 4, 4);
            GridView1.DataBind();
            Literal1.Text = doc.DocumentGetPage(21, 1, 4, 4)[0].PhanTrang.ToString();
        }
    }
}