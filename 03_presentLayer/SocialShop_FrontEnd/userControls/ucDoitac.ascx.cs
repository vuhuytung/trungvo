using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class userControls_ucDoitacl : System.Web.UI.UserControl
{
    CtrPartner partner = new CtrPartner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal1.Text = partner.GenHtml();
        }
    }
}