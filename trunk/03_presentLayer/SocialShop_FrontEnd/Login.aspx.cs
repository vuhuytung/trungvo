using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using VTCO.Config;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CtrUser acc = new CtrUser();
        var dt = acc.UserLogin(this.txtUserName.Text.Trim(), VTCO.Utils.Encryption.GetMD5(this.txtPassword.Text.Trim()));

        if ((dt != null) && (dt.Status == 1))
        {
            Session[Constants.SESSION_USER_NAME] = dt.UserName;
            Session[Constants.SESSION_USER_ID] = dt.UserID;
            Session[Constants.SESSION_USER_FULLNAME] = dt.FullName;            
            Session[Constants.SESSION_USER_ISLOGIN] = true;

            Response.Redirect("/");
            this.lblmsg.Text = "";
        }
        else if ((dt != null) && (dt.Status == 0))
        {
            this.lblmsg.Text = "Tài khoản của bạn đã bị khóa.<br/> Hãy liên hệ với ban quản trị để biết thêm thông tin !!<br/><br/>";
        }
        else
        {
            this.lblmsg.Text = "Sai tên đăng nhập hoặc mật khẩu. Hãy đăng nhập lại!<br/><br/>";
        }
    }
}