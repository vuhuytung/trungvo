using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.Text;
public partial class pages_Contact : System.Web.UI.Page
{
    CtrSendMail mail = new CtrSendMail();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        StringBuilder content = new StringBuilder();
        content.Append(txtName.Text + "\n");
        if (txtAddress.Text != "")
        {
            content.Append(txtAddress.Text + "\n");
        }
        if (txtPhone.Text != "")
        {
            content.Append(txtPhone.Text + "\n");
        }
        content.Append(txtContent.Text + "\n");
        if (mail.Send_Email(txtEmail.Text, txtTitle.Text, content.ToString()))
        {
            //do somethings is here
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAddress.Text = "";
        txtContent.Text = "";
        txtEmail.Text = "";
        txtName.Text = "";
        txtPhone.Text = "";
        txtTitle.Text = "";
    }
}