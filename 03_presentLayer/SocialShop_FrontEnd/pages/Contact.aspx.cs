using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.Text;
using DataContext;
public partial class pages_Contact : System.Web.UI.Page
{
    CtrSendMail mail = new CtrSendMail();
    protected uspConfigGetInfoResult config;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CtrAdmin ctrA = new CtrAdmin();
            config = ctrA.GetConfigInfo();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        CtrNews ctrN = new CtrNews();
        if (ctrN.ContactInsert(HttpUtility.HtmlEncode(txtName.Text.Trim()), HttpUtility.HtmlEncode(txtAddress.Text.Trim()), HttpUtility.HtmlEncode(txtPhone.Text.Trim()), 
            HttpUtility.HtmlEncode(txtEmail.Text.Trim()), HttpUtility.HtmlEncode(txtContent.Text.Trim())) > 0)
        {
            tbdSuccess.Visible = true;
            tbdContact.Visible = false;
        }

    }
}