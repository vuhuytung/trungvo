using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Đăng ký thành viên";
    }
    protected void btnRegistor_Click(object sender, EventArgs e)
    {
        CtrUser ctrUser = new CtrUser();
        if (ctrUser.Insert(txtUserName.Text.Trim(), txtPassword.Text.Trim(), HttpUtility.HtmlEncode(txtFullName.Text.Trim()), rdpBirthday.SelectedDate.Value, 
            HttpUtility.HtmlEncode(txtAddress.Text.Trim()), HttpUtility.HtmlEncode(txtMobile.Text.Trim()), HttpUtility.HtmlEncode(txtEmail.Text.Trim())) > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Đăng ký thành công!'); window.location='/login';", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Có lỗi xảy ra! Xin lỗi bạn vì sự bất tiện này')", true);
        }        
    }
}