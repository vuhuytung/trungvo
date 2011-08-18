using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.Text;
using DataContext;

public partial class userControls_ucDoitacl : System.Web.UI.UserControl
{
    CtrPartner partner = new CtrPartner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal1.Text = GenHtml();
        }
    }

    public string GenHtml()
    {
        StringBuilder sb = new StringBuilder();
        List<uspPartnersGetAllResult> pn = new List<uspPartnersGetAllResult>();
        CtrPartner ctrP = new CtrPartner();
        pn = ctrP.GetListPartner();

        foreach (uspPartnersGetAllResult item in pn)
        {
            sb.Append("<div class='item_pn'>");
            sb.Append("<a href=" + item.Website + ">");
            sb.Append("<img src=" + item.Img + "" + " alt='anh'/>");
            sb.Append("</a>");
            sb.Append("</div>");
        }
        if (pn.Count == 0)
            divDoitac.Visible = false;
        return sb.ToString();
    }
}